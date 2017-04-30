using System;
using System.Threading;
using System.Threading.Tasks;

namespace Callbacks
{
    public class ClassCallbackProvocator
    {
        private readonly Func<Task> _callback1;
        private readonly Action _onCompletedCallback;

        public ClassCallbackProvocator(Func<Task> callback1, Action onCompletedCallback)
        {
            _callback1 = callback1;
            _onCompletedCallback = onCompletedCallback;
        }

        public async Task Callback1Run()
        {
             await _callback1();
        }

        public void Callback2Run()
        {
            _onCompletedCallback();
        }
    }
}