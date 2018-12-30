﻿using System;
using System.Collections.Generic;
using System.Text;
using TIMSApp.BLL.Contracts;
using TIMSApp.Models.EntityModels;
using TIMSApp.Repositories.Contracts;

namespace TIMSApp.BLL.Managers
{
  public class TraineeManager:Manager<Trainee>,ITraineeManager
    {
        public TraineeManager(ITraineeRepository repository) : base(repository)
        {
        }
    }
}
