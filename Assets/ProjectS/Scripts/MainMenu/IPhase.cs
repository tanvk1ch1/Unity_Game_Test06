using System;

namespace ProjectS
{
    public interface IPhase
    {
        Action OnEndPhase { get; set; }
        void Init();
        void Run(float deltaTime);
    }
}