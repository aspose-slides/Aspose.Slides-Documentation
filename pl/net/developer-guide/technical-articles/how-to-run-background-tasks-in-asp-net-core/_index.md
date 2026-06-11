---
title: Jak uruchamiać zadania w tle w ASP.NET Core
type: docs
weight: 300
url: /pl/net/how-to-run-background-tasks-in-asp-net-core/
keywords:
- ASP.NET Core
- zadanie w tle
- przetwarzanie w tle
- usługa hostowana
- pracownik w tle
- kolejka zadań
- asynchroniczne planowanie zadań
- przetwarzanie plików po stronie serwera
- śledzenie postępu
- odpytywanie statusu
- powiadomienia SignalR
- AWS SQS
- Amazon S3
- Amazon DynamoDB
- skalowalna architektura
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Uruchamiaj zadania w tle w ASP.NET Core przy użyciu usług hostowanych, kolejek zadań i aktualizacji statusu – przetwarzaj i konwertuj pliki PPT, PPTX i ODP przy użyciu Aspose.Slides."
---
## **Wstęp**

Przetwarzanie plików (np. eksport prezentacji do formatu PDF) jest typowym zadaniem po stronie serwera. Wykonywanie go w obrębie obsługi żądania (gdy klient czeka) ma następujące wady:

- *Słaby interfejs użytkownika.* Strona zamarza i użytkownik musi czekać na wynik. Odświeżenie strony anuluje zadanie.
- *Timeouty operacji.* Nie możemy zagwarantować, że przetwarzanie zakończy się w określonym czasie, więc użytkownik prawdopodobnie zobaczy „timeout operacji”.
- *Niska przepustowość i skalowalność.* ASP.NET Core jest zaprojektowany do asynchronicznego obsługiwania wielu żądań. Zadania obciążające CPU i trwające długo blokują wątki i zmniejszają przepustowość serwera.
- *Słaba tolerancja na błędy.* Jeśli coś pójdzie nie tak podczas długotrwałego zadania (np. problem z łącznością), przetwarzanie nie powiedzie się i będzie musiało zostać uruchomione od początku.

Lepsze podejście([better approach](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-9.0#complete-long-running-tasks-outside-of-http-requests)) polega na asynchronicznym planowaniu zadania, przetwarzaniu go w tle i zwróceniu wyniku, gdy będzie gotowy.

W tym modelu użytkownik może widzieć aktualny status (i może opuścić lub odświeżyć stronę), zasoby serwera można skalować efektywnie i elastycznie dostosowywać, a także zastosować politykę ponownych prób.

Typowe rozwiązanie przetwarzania w tle obejmuje:

1. API do planowania zadania.
1. API do śledzenia statusu zadania.
1. Proces w tle przetwarzający zaplanowane zadania.
1. API do przechowywania i pobierania wyniku.

## **Przykład zadania w tle**

Aby zademonstrować to podejście, rozważ [przykładową aplikację internetową ASP.NET Core 3.1](./BackgroundJobDemo.zip). Aplikacja zawiera stronę, na której użytkownik może przesłać prezentację i kliknąć **Export to PDF**; prezentacja zostaje następnie przesłana i skonwertowana do PDF przez proces w tle.

## **Aplikacja internetowa**

Przykładowa aplikacja internetowa (projekt *BackgroundJobDemo*) zawiera:

- Strona przesyłania plików (strona Razor „Upload”).
- Strona postępu (strona Razor „Progress” z kilkoma funkcjami JavaScript, które sprawdzają i wyświetlają status).
- Kontroler (`JobStatusController`) udostępniający status przetwarzania (`api/status/{jobId}`).
- Kontroler (`JobResultController`) zwracający wyeksportowany plik PDF (`api/result/{id}`).
- Proces w tle oparty na usłudze hostingu ASP.NET Core (zobacz klasę `WorkerService`).

Strony Razor, kontrolery i proces w tle delegują rzeczywistą pracę poprzez interfejsy zdefiniowane w projekcie *BackgroundJobDemo.Common*. Konkretne implementacje zarządzania zadaniami i ich przetwarzania są dostarczane w oddzielnych projektach (*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws* itd.) i mogą być przełączane w metodzie `Startup.ConfigureServices`.

Do celów demonstracyjnych strona „Upload” używa buforowanego wiązania modelu, ale przy dużych plikach przesyłanie bez buforowania jest [zalecane](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads). W środowisku produkcyjnym rozważ odpowiednie [aspekty bezpieczeństwa](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations). Strona „Progress” odpytyuje status zaplanowanego zadania za pomocą JavaScript co dwie sekundy (ten interwał jest konfigurowalny). Odpytywanie jest typowe, ale w bardziej zaawansowanych scenariuszach może być wymagane powiadamianie w czasie rzeczywistym za pomocą WebSockets (komunikacja w czasie rzeczywistym wykracza poza zakres tego artykułu). [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) jest prostym, ale potężnym narzędziem do komunikacji w czasie rzeczywistym.

Hostowanie procesu w tle w procesie serwera jest wygodne dla prostych aplikacji, ale ma [wady](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx). Bardziej solidne i skalowalne podejście polega na wdrożeniu procesu w osobnym procesie (zobacz np. aplikację konsolową *BackgroundJobDemo.Worker*).

## **Podstawowa implementacja**

Projekt *BackgroundJobDemo.Local* zapewnia prostą implementację zarządzania zadaniami przy użyciu bazy danych SQLite (ścieżka bazy konfigurowana jest przez `LocalConfig.DbFilePath`; zobacz `Startup.ConfigureServices`). Przesłane i przetworzone pliki są przechowywane w systemie plików (ścieżka folderu przechowywania konfigurowana jest przez `LocalConfig.FileStorageFolderPath`; zobacz `Startup.ConfigureServices`). Dla lepszej tolerancji błędów i wydajności w rzeczywistych aplikacjach, planowanie zadań powinno być realizowane przy użyciu kolejek komunikatów (np. RabbitMQ, AWS SQS, Azure Storage Queue).

## **Rozproszona implementacja oparta na Amazon Web Services**

Projekt *BackgroundJobDemo.Aws* implementuje przetwarzanie zadań w Amazon Web Services i demonstruje poziomo skalowalną architekturę rozproszoną. Zawiera następujące komponenty:

- Aplikacja internetowa — współdziała z użytkownikiem i planuje zadania eksportu PPTX do PDF itp.
- Proces w tle — przetwarza eksporty (w‑procesie, poza procesem lub AWS Lambda).
- Kolejka komunikatów — przechowuje zadania do przetworzenia (Amazon SQS).
- Przechowywanie plików — przechowuje przesłane i przetworzone pliki (Amazon S3).
- Magazyn klucz‑wartość — śledzi status przetwarzania zadań (Amazon DynamoDB).

Typowa rozproszona architektura opiera się na [kolejkach komunikatów](https://aws.amazon.com/message-queue/): aplikacja internetowa umieszcza zadania w tle w kolejce; proces w tle pobiera zadania z kolejki i wykonuje wymaganą pracę. To oddziela komponenty i sprawia, że przetwarzanie jest asynchroniczne i niezawodne. Kolejka zapewnia dostawę i używa *timeoutu widoczności*: gdy jeden proces pobierze wiadomość, staje się ona niewidoczna dla innych procesów; tylko proces przetwarzający usuwa ją po zakończeniu. Jeśli przetwarzanie nie zakończy się w ramach timeoutu widoczności (np. z powodu awarii lub problemu sieciowego), nieprzetworzona wiadomość ponownie staje się widoczna.

Nasza implementacja używa [Amazon Simple Queue Service](https://aws.amazon.com/sqs/) (SQS), w pełni zarządzanej kolejki komunikatów dla mikroserwisów, systemów rozproszonych i aplikacji serverless.

Kolejki komunikatów przeznaczone są do lekkich wiadomości (np. limit rozmiaru wiadomości w SQS wynosi 256 KB), więc wiadomość powinna zawierać wyłącznie opis zadania. Ciężkie dane (takie jak pliki do przetworzenia) powinny być przechowywane osobno i referencjonowane w wiadomości. Do przechowywania przesłanych i przetworzonych plików używany jest [Amazon S3](https://aws.amazon.com/s3/).

Do przechowywania i pobierania wyników zadań według identyfikatora potrzebny jest magazyn klucz‑wartość. Przykład wykorzystuje [Amazon DynamoDB](https://aws.amazon.com/dynamodb/), szybki i elastyczny serwis bazodanowy NoSQL.

Aby uruchomić aplikację demonstracyjną z Amazon Web Services:

1. W tym samym regionie AWS utwórz i skonfiguruj:
   1. kolejkę SQS,
   1. koszyk S3,
   1. tabelę DynamoDB.
2. Połącz aplikację internetową z tymi usługami, wywołując *AddAws* w `Startup.ConfigureServices`, podając URL kolejki SQS, nazwę koszyka S3, nazwę tabeli DynamoDB oraz region AWS.

## **Referencje**

- [Najlepsze praktyki wydajności ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices)
- [Przesyłanie plików w ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)
- [ASP.NET w czasie rzeczywistym z SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)
- [Kolejki komunikatów](https://aws.amazon.com/message-queue/)
- [Amazon Simple Queue Service](https://aws.amazon.com/sqs/)
- [Amazon S3](https://aws.amazon.com/s3/)
- [Amazon DynamoDB](https://aws.amazon.com/dynamodb/)