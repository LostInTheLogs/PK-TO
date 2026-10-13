```mermaid
classDiagram
    class Program {
        -_repository: IRemoteRepository
        -_parser: IParser
        -_collection: ICurrencyCollection
        +Program(repository: IRemoteRepository, parser: IParser, collection: ICurrencyCollection)
        +Main(args: string[]) void
        +Run() Task
    }

    class IRemoteRepository {
        <<interface>>
        +GetData() Task~string~
    }

    class NBPRemoteRepository {
        +Endpoint: string
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
        +Exchange(from: ICurrency, to: ICurrency, amount: decimal) decimal
        +ToString() string
    }

    class ICurrencyCollection {
        <<interface>>
        +Add(currency: ICurrency) void
        +Remove(code: string) void
        +Get(code: string) ICurrency?
        +TryGet(code: string) ICurrency?
        +GetAll() ICurrency[]
        +Contains(code: string) bool
        +Count: int
        +Clear() void
        +Update(currency: ICurrency) void
    }

    class CurrencyCollection {
        -_currencies: Dictionary~string, ICurrency~
        +CurrencyCollection()
        +Add(currency: ICurrency) void
        +Remove(code: string) void
        +Get(code: string) ICurrency?
        +TryGet(code: string) ICurrency?
        +GetAll() ICurrency[]
        +Contains(code: string) bool
        +Count: int
        +Clear() void
        +Update(currency: ICurrency) void
    }

    Program --> IRemoteRepository
    Program --> IParser
    Program --> ICurrencyCollection

    NBPRemoteRepository ..|> IRemoteRepository
    NBPXMLParser ..|> IParser
    Currency ..|> ICurrency
    CurrencyCollection ..|> ICurrencyCollection

    ICurrencyCollection --> ICurrency
    CurrencyCollection --> Currency
    NBPXMLParser --> ICurrencyCollection
