using LogicAPI.Client;
using LogicLog;
using UnityEngine;
using UnityExplorer;

namespace FoxFireFive.UnityExplorerLW.Client
{
    public class Loader : ClientMod
    {
        public ILogicLogger logger;

        protected override void Initialize()
        {
        	logger = this.Logger;

        	if (ExplorerStandalone.Instance != null) return; 

            ExplorerStandalone.CreateInstance();
            ExplorerStandalone.OnLog += HandleExplorerLog;
        }

        private void HandleExplorerLog(string message, LogType type)
        {
            switch (type)
            {
                case LogType.Error:
                    logger.Error(message);
                    break;

                case LogType.Assert:
                    logger.Error(message);
                    break;

                case LogType.Warning:
                    logger.Warn(message);
                    break;

                case LogType.Log:
                    logger.Info(message);
                    break;

                case LogType.Exception:
                    logger.Error(message);
                    break;
            }
        }
    }
}