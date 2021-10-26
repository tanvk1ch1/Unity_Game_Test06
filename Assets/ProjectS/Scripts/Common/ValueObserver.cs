using System;

namespace ProjectS
{
    public class ValueObserver<T>
    {
        public event Action<T> OnChange;
        private T value;
        
        public T Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                OnChange?.Invoke(value);
            }
        }
        
        public ValueObserver(T value)
        {
            this.value = value;
        }
    }
}