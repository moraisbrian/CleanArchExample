using ProjetoExemplo.Application.Models;
using ProjetoExemplo.Application.Interfaces;
using ProjetoExemplo.Domain.Entities;
using ProjetoExemplo.Domain.Interfaces.Repositories;
using AutoMapper;

namespace ProjetoExemplo.Application.Commands;

public class PersonCommand : IPersonCommand
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public PersonCommand(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PersonModel>> GetPersons()
    {
        var persons = await _personRepository.GetPersons();
        var personsModel = _mapper.Map<IEnumerable<PersonModel>>(persons);
        return personsModel;
    }

    public async Task<PersonModel> AddPerson(PersonModel personModel)
    {
        var person = _mapper.Map<Person>(personModel);
        person = await _personRepository.AddPerson(person);

        personModel = _mapper.Map<PersonModel>(person);
        return personModel;
    }
}