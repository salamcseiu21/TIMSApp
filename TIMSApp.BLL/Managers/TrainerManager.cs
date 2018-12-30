using System;
using System.Collections.Generic;
using System.Text;
using TIMSApp.BLL.Contracts;
using TIMSApp.Models.EntityModels;
using TIMSApp.Repositories.Contracts;

namespace TIMSApp.BLL.Managers
{
   public class TrainerManager:Manager<Trainer>,ITrainerManager
    {
        public TrainerManager(ITrainerRepository repository) : base(repository)
        {
        }
    }
}
