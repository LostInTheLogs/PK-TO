```mermaid
classDiagram
    class Program {
        +Main(args: string[]) Task
    }

    class IRemoteRepository {
        <<interface>>
        +GetData() Task~string~
    }

    class NBPRemoteRepository {
        +GetData() Task~string~
    }

    class IParser {
        <<interface>>
        +Parse(data: string, collection: ICurrencyCollection) void
    }

    class NBPXMLParser {
        +Parse(data: string, collection: ICurrencyCollection) void
    }

    class ICurrency {
        <<interface>>
        +Name: string
        +Code: string
        +Rate: decimal
        +Multiplier: decimal
        +Exchange(from: ICurrency, to: ICurrency, amount: decimal) decimal
    }

    class Currency {
        +Name: string
        +Code: string
        +Rate: decimal
        +Multiplier: decimal
        +Currency(name: string, code: string, rate: decimal, multiplier: decimal)
        +ToString() string
    }

    class ICurrencyCollection {
        <<interface>>
        +Add(currency: ICurrency) void
        +Remove(code: string) void
        +Get(code: string) ICurrency?
        +GetAll() ICurrency[]
    }

    class CurrencyCollection {
        -_currencies: Dictionary~string, ICurrency~
        +CurrencyCollection()
        +Add(currency: ICurrency) void
        +Remove(code: string) void
        +Get(code: string) ICurrency?
        +GetAll() ICurrency[]
    }

    Program --> IRemoteRepository


    Program --> IParser
    Program --> ICurrencyCollection

    NBPRemoteRepository ..|> IRemoteRepository
    NBPXMLParser ..|> IParser
    Currency ..|> ICurrency
    CurrencyCollection ..|> ICurrencyCollection

    ICurrencyCollection o-- ICurrency
    CurrencyCollection o-- Currency
    NBPXMLParser --> ICurrencyCollection
```
