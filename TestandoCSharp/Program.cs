using TestandoCSharp;

Exemplo exemplo = new Exemplo();
var numberList = exemplo.ObterNumeros().ToList(); 
var numeros = exemplo.ObterNumeros();
var personList = exemplo.CriarListaDeObjetos();



exemplo.ProcessarNumeros(numberList);

var result = exemplo.ObterMaioresDeIdade(personList);
foreach (var output in result)
{
    Console.WriteLine(output);
}

var dictionary = exemplo.createNewDictionary(personList);

foreach (var item in dictionary)
{
    Console.WriteLine($"{item.Key} - {item.Value}");
}

await foreach (var item in exemplo.GetPersonAsync())
{
   Console.WriteLine($"{item.Name} está aqui");
}

var nameToSearch = "Alice";

var peopleList = await exemplo.GetPersonByNameAsync(personList, nameToSearch);

if (peopleList.Any())
{
    foreach (var person in peopleList)
    {
        Console.WriteLine($"{person.Name} está aqui");
    }
}
else
{
    Console.WriteLine($"Nenhuma pessoa encontrada com o nome {nameToSearch}");
}

public class Exemplo
{
    private List<int> dados = new List<int> { 1, 2, 3, 4, 5 };

    public IEnumerable<int> ObterNumeros()
    {
        foreach (var numero in dados)
        {
            Console.WriteLine($"Gerando {numero}");
            yield return numero;
        }
    }

    public void ProcessarNumeros(IEnumerable<int> numeros)
    {
        foreach (var numero in numeros)
        {
            Console.WriteLine($"Processando {numero}");
        }
    }

    public IEnumerable<string> ObterMaioresDeIdade(List<Person> personList)
    {

        foreach (var person in personList)
        {
            if (EhMaiorDeIdade(person.Age))
            {
                yield return $"{person.Name} é maior de idade";
            }
        }

    }

    public bool EhMaiorDeIdade(int idade)
    {
        if (idade < 18)
        {
            return false;
        }
        return true;
    }

    public List<Person> CriarListaDeObjetos()
    {
        return new List<Person>
        {
            new Person { Name = "John", Age = 18, Role = "ADM"  },
            new Person { Name = "John", Age = 21, Role = "Doctor"  },
            new Person { Name = "Jane", Age =  15, Role = "Desenvolvedor"},
            new Person { Name = "Azardel", Age = 18, Role = "Engenheiro" },
        };
    }

    public Dictionary<string, string> createNewDictionary(List<Person> personList)
    {
        var newPersons = new Dictionary<string, string>();

        foreach (var person in personList)
        {
            if (!newPersons.ContainsKey(person.Name))
            {
                newPersons.Add(person.Name, person.Role);
            }
        }

        return newPersons;
    }

    public async IAsyncEnumerable<Person> GetPersonAsync() {
        var personList = new List<Person>
        {
            new Person { Name = "John", Age = 18, Role = "ADM"  },
            new Person { Name = "John", Age = 21, Role = "Doctor"  },
            new Person { Name = "John", Age = 21, Role = "Doctor"  },
            new Person { Name = "John", Age = 21, Role = "Doctor"  },
            new Person { Name = "John", Age = 21, Role = "Doctor"  },
            new Person { Name = "John", Age = 21, Role = "Doctor"  },
            new Person { Name = "John", Age = 21, Role = "Doctor"  },
            new Person { Name = "John", Age = 21, Role = "Doctor"  },
            new Person { Name = "Jane", Age =  15, Role = "Desenvolvedor"},
            new Person { Name = "Azardel", Age = 18, Role = "Engenheiro" },
            new Person { Name = "Azardel", Age = 18, Role = "Engenheiro" },
            new Person { Name = "Azardel", Age = 18, Role = "Engenheiro" },
            new Person { Name = "Azardel", Age = 18, Role = "Engenheiro" },
            new Person { Name = "Azardel", Age = 18, Role = "Engenheiro" },
            new Person { Name = "Azardel", Age = 18, Role = "Engenheiro" },
            new Person { Name = "Azardel", Age = 18, Role = "Engenheiro" },
            new Person { Name = "Azardel", Age = 18, Role = "Engenheiro" },
            new Person { Name = "Azardel", Age = 18, Role = "Engenheiro" },
            new Person { Name = "Azardel", Age = 18, Role = "Engenheiro" },
            new Person { Name = "Azardel", Age = 18, Role = "Engenheiro" },
            new Person { Name = "Azardel", Age = 18, Role = "Engenheiro" },
            new Person { Name = "Azardel", Age = 18, Role = "Engenheiro" },
            new Person { Name = "Azardel", Age = 18, Role = "Engenheiro" },
            new Person { Name = "Azardel", Age = 18, Role = "Engenheiro" },
        };

        await Task.Delay(100);

        foreach (var person in personList)
        {
            yield return person;
        }
    }

    public async Task<IEnumerable<Person>> GetPersonByNameAsync(List<Person> personList,string name)
    {
        var newPersonList = new List<Person>();

        await Task.Delay(100);
        foreach (var person in personList) {
            if (person.Name == name)
            {
                newPersonList.Add(person);
            }
        }

        if (!newPersonList.Any())
        {
            return Enumerable.Empty<Person>();
        }

        return newPersonList;
    }
}
