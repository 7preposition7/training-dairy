using Domain.Dto;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ITrainingService
    {
        TrainingDto GetById(int id);
        TrainingDto Create(TrainingDto newTraining);
        TrainingDto Edit(TrainingDto training);
        void Delete(int id);
        IEnumerable<TrainingDto> GetAll();
        IEnumerable<TrainingDto> GetAllForUser(int userId);
    }
}
