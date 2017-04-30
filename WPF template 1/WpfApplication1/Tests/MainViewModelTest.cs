using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using WpfApplication1;

namespace Tests
{
    [TestFixture]
    public class MainViewModelTest
    {
        [Test]
        public void If_save_called_and_selected_exist_should_persist_record()
        {
            //Arrange
            var permitRepository = A.Fake<IWorkPermitRepository>();
            var attachmentRepository = A.Fake<IAttachmentRepository>();
            var viewModel = new MainViewModel(permitRepository, attachmentRepository);
            var selectedItem = new WorkPermitViewModel(null, null);
            viewModel.SelectedPermit = selectedItem;

            //Act
            viewModel.SavePermit();

            //Assert
            A.CallTo(() => permitRepository.Save(A<WorkPermit>.Ignored)).MustHaveHappened();
        }

        [Test]
        public void If_save_called_and_no_selected_should_not_persist_record()
        {
            //Arrange
            var permitRepository = A.Fake<IWorkPermitRepository>();
            var attachmentRepository = A.Fake<IAttachmentRepository>();
            var viewModel = new MainViewModel(permitRepository, attachmentRepository);

            //Act
            viewModel.SavePermit();

            //Assert
            A.CallTo(() => permitRepository.Save(A<WorkPermit>.Ignored)).MustNotHaveHappened();
        }

        [Test]
        public async Task Initialize_should_load_data()
        {
            //Arrange
            var permitRepository = A.Fake<IWorkPermitRepository>();
            var attachmentRepository = A.Fake<IAttachmentRepository>();
            var viewModel = new MainViewModel(permitRepository, attachmentRepository);

            //Act
            await viewModel.Initialize();

            //Assert
            A.CallTo(() => permitRepository.FindAll()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public async Task Initialize_should_be_idempotent()
        {
            //Arrange
            var permitRepository = A.Fake<IWorkPermitRepository>();
            var attachmentRepository = A.Fake<IAttachmentRepository>();
            var viewModel = new MainViewModel(permitRepository, attachmentRepository);

            //Act
            await viewModel.Initialize();
            await viewModel.Initialize();

            //Assert
            A.CallTo(() => permitRepository.FindAll()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public async Task Initialize_should_be_idempotent2()
        {
            //Arrange
            var permitRepository = A.Fake<IWorkPermitRepository>();
            var attachmentRepository = A.Fake<IAttachmentRepository>();
            var viewModel = new MainViewModel(permitRepository, attachmentRepository);

            //Act
            await Task.Run(() => viewModel.Initialize());
            await Task.Run(() => viewModel.Initialize());
            await Task.Run(() => viewModel.Initialize());

            //Assert
            A.CallTo(() => permitRepository.FindAll()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void If_initialize_was_not_called_should_not_add_elements()
        {
            //Arrange
            var permitRepository = A.Fake<IWorkPermitRepository>();
            var attachmentRepository = A.Fake<IAttachmentRepository>();
            var viewModel = new MainViewModel(permitRepository, attachmentRepository);
            viewModel.WorkPermits.MonitorEvents<INotifyCollectionChanged>();
            viewModel.MonitorEvents<INotifyPropertyChanged>();

            //Act
            viewModel.CreateWorkPermit();

            //Assert
            viewModel.WorkPermits.ShouldNotRaise("CollectionChanged");
            viewModel.ShouldNotRaise("PropertyChanged");
        }

        [Test]
        [Ignore("")]
        public async Task If_initialize_called_after_create_should_add_elements()
        {
            //Arrange
            var permitRepository = A.Fake<IWorkPermitRepository>();
            var attachmentRepository = A.Fake<IAttachmentRepository>();
            var viewModel = new MainViewModel(permitRepository, attachmentRepository);
            viewModel.WorkPermits.MonitorEvents<INotifyCollectionChanged>();
            viewModel.MonitorEvents<INotifyPropertyChanged>();

            //Act
            Task createTask = viewModel.CreateWorkPermit();
            await viewModel.Initialize();
            await createTask;

            //Assert
            viewModel.WorkPermits.ShouldRaise("CollectionChanged");
            viewModel.ShouldRaise("PropertyChanged");
        }
    }
}
