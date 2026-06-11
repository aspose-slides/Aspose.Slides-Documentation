---
title: Hur man kör bakgrundsuppgifter i ASP.NET Core
type: docs
weight: 300
url: /sv/net/how-to-run-background-tasks-in-asp-net-core/
keywords:
- ASP.NET Core
- bakgrundsuppgift
- bakgrundsbehandling
- hostad tjänst
- bakgrundsarbetare
- jobbkö
- asynkron jobbplanering
- serversidig filbehandling
- framstegsspårning
- statuspollning
- SignalR‑aviseringar
- AWS SQS
- Amazon S3
- Amazon DynamoDB
- skalbar arkitektur
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Kör bakgrundsuppgifter i ASP.NET Core med hostade tjänster, jobbköer och statusuppdateringar – bearbeta och konvertera PPT, PPTX och ODP med Aspose.Slides."
---
## **Introduktion**

Filbehandling (t.ex. export av en presentation till PDF) är en typisk server‑sidig uppgift. Att utföra den i begäranhanteraren (medan klienten väntar) har följande nackdelar:

- *Dåligt UI.* Sidan fryser och användaren måste vänta på resultatet. Att ladda om sidan avbryter uppgiften.
- *Timeout för operationer.* Vi kan inte säkerställa att bearbetningen slutförs inom en fast period, så användaren får sannolikt ett "operation timeout".
- *Låg genomströmning och skalbarhet.* ASP.NET Core är designat för att behandla många begäranden asynkront. CPU‑intensiva, långvariga uppgifter blockerar trådar och minskar serverns genomströmning.
- *Dålig fel tolerans.* Om något går fel under en långvarig uppgift (t.ex. ett anslutningsproblem) misslyckas bearbetningen och måste startas om från början.

En [bättre metod](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-9.0#complete-long-running-tasks-outside-of-http-requests) är att schemalägga jobbet asynkront, bearbeta det i bakgrunden och returnera resultatet när det är klart.

I denna modell kan användaren se den aktuella statusen (och kan lämna eller ladda om sidan), serverresurser kan skalas effektivt och justeras flexibelt, och en återförsökningspolicy kan tillämpas.

En typisk bakgrundsbehandlingslösning innehåller:

1. Ett API för att schemalägga jobbet.
1. Ett API för att spåra jobbstatus.
1. En bakgrundsarbetare för att bearbeta schemalagda jobb.
1. Ett API för att lagra och hämta resultatet.

## **Bakgrundsuppgiftsexempel**

För att demonstrera detta tillvägagångssätt, överväg [exempel‑ASP.NET Core 3.1‑webbapplikationen](./BackgroundJobDemo.zip). Appen innehåller en sida där en användare kan ladda upp en presentation och klicka på **Export to PDF**; presentationen laddas sedan upp och konverteras till PDF av en bakgrundsarbetare.

## **Webbapp**

Exempel‑webbappen (*BackgroundJobDemo*-projektet) innehåller:

- Filuppladdningssida (Razor‑sida "Upload").
- Framstegssida (Razor‑sida "Progress" med några JavaScript‑funktioner som kontrollerar och visar status).
- Controller (`JobStatusController`) som tillhandahåller bearbetningsstatus (`api/status/{jobId}`).
- Controller (`JobResultController`) som returnerar den exporterade PDF‑filen (`api/result/{id}`).
- Bakgrundsarbetare baserad på ASP.NET Core‑hosting‑tjänsten (se klassen `WorkerService`).

Razor‑sidor, controllers och bakgrundsarbetaren delegerar det faktiska arbetet via gränssnitt definierade i *BackgroundJobDemo.Common*-projektet. Konkret implementation av jobbhantering och bearbetning tillhandahålls i separata projekt (*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws* osv.) och kan bytas i metoden `Startup.ConfigureServices`.

För demonstrationsändamål använder "Upload"-sidan buffrad modellbindning, men för stora filuppladdningar rekommenderas [osbuffrad strömning](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads). För produktion bör relevanta [säkerhetsaspekter](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations) beaktas. "Progress"-sidan frågar (pollar) den schemalagda jobbstatusen via JavaScript varannan sekund (intervallet är konfigurerbart). Polling är vanligt, men för mer avancerade scenarier kan du behöva realtidsnotifikationer via WebSockets (realtidskommunikation ligger utanför detta avsnitts omfattning). [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) är ett enkelt men kraftfullt verktyg för realtidskommunikation.

Att hosta bakgrundsarbetaren i serverprocessen är bekvämt för enkla applikationer men har [nackdelar](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx). Ett mer robust och skalbart tillvägagångssätt är att distribuera arbetaren i en separat process (se t.ex. konsolapplikationen *BackgroundJobDemo.Worker*).

## **Grundläggande implementation**

*BackgroundJobDemo.Local*-projektet tillhandahåller en enkel jobb‑hanteringsimplementation med en SQLite‑databas (databasens sökväg konfigureras via `LocalConfig.DbFilePath`; se `Startup.ConfigureServices`). Uppladdade och bearbetade filer lagras i filsystemet (lagringsmappens sökväg konfigureras via `LocalConfig.FileStorageFolderPath`; se `Startup.ConfigureServices`). För bättre feltolerans och prestanda i verkliga tillämpningar bör jobb‑schemaläggning implementeras via meddelandeköer (t.ex. RabbitMQ, AWS SQS, Azure Storage Queue).

## **Distribuerad implementering baserad på Amazon Web Services**

*BackgroundJobDemo.Aws*-projektet implementerar jobb‑bearbetning på Amazon Web Services och demonstrerar en horisontellt skalbar distribuerad arkitektur. Det inkluderar följande komponenter:

- Webbapp — interagerar med användaren och schemalägger PPTX‑till‑PDF‑exportuppgifter osv.
- Arbetare — bearbetar exporter (i‑process, ut‑process eller AWS Lambda).
- Meddelandekö — lagrar uppgifter som ska bearbetas (Amazon SQS).
- Fillagring — lagrar uppladdade och bearbetade filer (Amazon S3).
- Nyckel‑värde‑lagring — spårar uppgiftsbearbetningsstatus (Amazon DynamoDB).

En typisk distribuerad arkitektur bygger på [meddelandeköer](https://aws.amazon.com/message-queue/): webbappen placerar bakgrundsuppgifter i en kö; en bakgrundsarbetare hämtar uppgifter från kön och utför det nödvändiga arbetet. Detta frikopplar komponenter och gör bearbetning asynkron och pålitlig. kön garanterar leverans och använder en *visibility timeout*: när en arbetare tar ett meddelande blir det osynligt för andra arbetare; endast den bearbetande arbetaren tar bort det vid slutförandet. Om bearbetningen inte avslutas inom visibility timeout (t.ex. på grund av ett fel eller nätverksproblem) blir det obehandlade meddelandet synligt igen.

Vår implementation använder [Amazon Simple Queue Service](https://aws.amazon.com/sqs/) (SQS), en helt hanterad meddelandekö för mikrotjänster, distribuerade system och serverlösa applikationer.

Meddelandeköer är avsedda för lätta meddelanden (t.ex. SQS meddelandestorleksgräns är 256 KB), så ett meddelande bör endast innehålla uppgiftsbeskrivningen. Tunga data (såsom filer som ska bearbetas) bör lagras separat och refereras från meddelandet. [Amazon S3](https://aws.amazon.com/s3/) används för att lagra uppladdade och bearbetade filer.

En nyckel‑värde‑lagring krävs för att beständigt spara och hämta jobbrresultat efter ID. Exemplet använder [Amazon DynamoDB](https://aws.amazon.com/dynamodb/), en snabb och flexibel NoSQL‑databasservice.

För att köra demo‑appen med Amazon Web Services:

1. I samma AWS‑region, skapa och konfigurera:
   1. en SQS‑kö,
   1. en S3‑hink,
   1. ett DynamoDB‑bord.
1. Anslut webbappen till dessa tjänster genom att anropa *AddAws* i `Startup.ConfigureServices`, och ange SQS‑kö‑URL, S3‑hinknamn, DynamoDB‑bordnamn samt AWS‑region.

## **Referenser**

- [Bästa praxis för ASP.NET Core-prestanda](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices)
- [Ladda upp filer i ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)
- [Realtid ASP.NET med SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)
- [Meddelandeköer](https://aws.amazon.com/message-queue/)
- [Amazon Simple Queue Service](https://aws.amazon.com/sqs/)
- [Amazon S3](https://aws.amazon.com/s3/)
- [Amazon DynamoDB](https://aws.amazon.com/dynamodb/)