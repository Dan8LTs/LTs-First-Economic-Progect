using System.Collections.Generic;


namespace LTSefpBL.Controller
{
    public abstract class ControllerBase
    {
        private readonly IDataSaver saver = new SerializeDataSaver();

        protected void Save<T>(List<T> item) where T : class
        {
            saver.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return saver.Load<T>();
        }

    }
}
