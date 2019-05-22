using AutoMapper;
using Domain.Dto;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class TrainingService : ITrainingService
    {
        private DairyContext _context;
        private IMapper _mapper;

        public TrainingService(DairyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TrainingDto Create(TrainingDto newTraining)
        {
            AppUser sportsman = _context.Users.Where(u => u.Id == newTraining.SportsmanID.ToString()).FirstOrDefault();
            if (sportsman == null)
            {
                throw new NullReferenceException($"The user with ID {newTraining.ID} does not exist");
            }

            Training trainingToCreate = _mapper.Map<Training>(newTraining);
            _context.Trainings.Add(trainingToCreate);
            _context.SaveChanges();

            return GetById(trainingToCreate.ID);
        }

        public void Delete(int id)
        {
            Training trainingToDelete = GetTrainingEntity(id);

            _context.Entry(trainingToDelete).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }

        public TrainingDto Edit(TrainingDto training)
        {
            Training existing = GetTrainingEntity(training.ID);

            _context.Entry(existing).CurrentValues.SetValues(_mapper.Map<Training>(training));
            _context.SaveChanges();

            return GetById(existing.ID);
        }

        public IEnumerable<TrainingDto> GetAll()
        {
            IEnumerable<Training> trainingList = _context.Trainings.ToList();
            return _mapper.Map<IEnumerable<TrainingDto>>(trainingList);
        }

        public IEnumerable<TrainingDto> GetAllForUser(int userId)
        {
            IEnumerable<Training> trainingList = _context.Trainings.Where(u => u.ID == userId).ToList();
            return _mapper.Map<IEnumerable<TrainingDto>>(trainingList);
        }

        public TrainingDto GetById(int id)
        {
            return _mapper.Map<TrainingDto>(GetTrainingEntity(id));
        }

        private Training GetTrainingEntity(int id)
        {
            Training training = _context.Trainings.Where(t => t.ID == id).FirstOrDefault();
            if (training == null)
            {
                throw new NullReferenceException($"The training with ID {id} does not exist");
            }
            return training;
        }
    }
}
