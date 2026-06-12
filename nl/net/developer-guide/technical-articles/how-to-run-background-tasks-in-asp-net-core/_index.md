---
title: Hoe achtergrondtaken uit te voeren in ASP.NET Core
type: docs
weight: 300
url: /nl/net/how-to-run-background-tasks-in-asp-net-core/
keywords:
- ASP.NET Core
- achtergrondtaak
- achtergrondverwerking
- gehoste service
- achtergrondworker
- taakwachtrij
- asynchrone taakplanning
- server-side bestandsverwerking
- voortgangsbewaking
- status-polling
- SignalR-meldingen
- AWS SQS
- Amazon S3
- Amazon DynamoDB
- schaalbare architectuur
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Voer achtergrondtaken uit in ASP.NET Core met Hosted Services, taakwachtrijen en statusupdates – verwerk en converteer PPT, PPTX en ODP met Aspose.Slides."
---
## **Inleiding**

Bestandverwerking (bijv. het exporteren van een presentatie naar PDF) is een typische server‑side taak. Het uitvoeren ervan binnen de request‑handler (terwijl de client wacht) heeft de volgende nadelen:

- *Slechte UI.* De pagina vriest en de gebruiker moet wachten op het resultaat. De pagina opnieuw laden annuleert de taak.
- *Operationele time‑outs.* We kunnen niet garanderen dat de verwerking binnen een vaste periode voltooid wordt, waardoor de gebruiker waarschijnlijk een “operation timeout” zal zien.
- *Lage doorvoer en schaalbaarheid.* ASP.NET Core is ontworpen om veel verzoeken asynchroon te verwerken. CPU‑gebonden, langdurige taken blokkeren threads en verminderen de server‑doorvoer.
- *Slechte fouttolerantie.* Als er iets misgaat tijdens een langdurige taak (bijv. een verbindingsprobleem), faalt de verwerking en moet deze vanaf het begin opnieuw gestart worden.

Een [betere aanpak](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-9.0#complete-long-running-tasks-outside-of-http-requests) is om de taak asynchroon in te plannen, deze op de achtergrond te verwerken en het resultaat te retourneren wanneer het klaar is.

In dit model kan de gebruiker de huidige status zien (en de pagina verlaten of opnieuw laden), server‑resources kunnen efficiënt en flexibel geschaald worden, en kan een retry‑policy toegepast worden.

Een typische achtergrondverwerkingsoplossing omvat:

1. Een API om de taak in te plannen.
1. Een API om de taakstatus te volgen.
1. Een achtergrond‑worker om ingeplande taken te verwerken.
1. Een API om het resultaat op te slaan en op te halen.

## **Voorbeeld van achtergrondtaak**

Om deze aanpak te demonstreren, beschouw de [voorbeeld‑ASP.NET Core 3.1 webapplicatie](./BackgroundJobDemo.zip). De app bevat een pagina waarin een gebruiker een presentatie kan uploaden en op **Export to PDF** klikt; de presentatie wordt vervolgens geüpload en door een achtergrond‑worker naar PDF geconverteerd.

## **Webapp**

De voorbeeld‑webapp (*BackgroundJobDemo* project) bevat:

- Bestand‑uploadpagina (Razor‑pagina “Upload”).
- Voortgangspagina (Razor‑pagina “Progress” met enkele JavaScript‑functies die de status controleren en weergeven).
- Controller (`JobStatusController`) die de verwerkingsstatus levert (`api/status/{jobId}`).
- Controller (`JobResultController`) die het geëxporteerde PDF‑bestand retourneert (`api/result/{id}`).
- Achtergrond‑worker gebaseerd op de ASP.NET Core hosting‑service (zie de `WorkerService`‑klasse).

Razor‑pagina’s, controllers en de achtergrond‑worker delegeren het werk via interfaces gedefinieerd in het *BackgroundJobDemo.Common* project. Concrete implementaties van taakbeheer en verwerking worden geleverd in aparte projecten (*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws*, enz.) en kunnen worden verwisseld in de `Startup.ConfigureServices`‑methode.

Voor demonstratiedoeleinden gebruikt de “Upload”‑pagina gebufferde modelbinding, maar voor grote uploads wordt ongebufferde streaming aanbevolen ([aanbevolen](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)). Voor productie moet rekening gehouden worden met de relevante [security aspects](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations). De “Progress”‑pagina pollt elke twee seconden (dit interval is configureerbaar) de status van de ingeplande taak via JavaScript. Polling is gebruikelijk, maar voor meer geavanceerde scenario’s kan real‑time notificatie via WebSockets nodig zijn (real‑time communicatie valt buiten de reikwijdte van dit artikel). [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) is een eenvoudig maar krachtig hulpmiddel voor real‑time communicatie.

Het hosten van de achtergrond‑worker in het serverproces is handig voor eenvoudige applicaties, maar heeft [nadelen](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx). Een robuustere en schaalbare aanpak is om de worker in een apart proces te draaien (zie bv. de *BackgroundJobDemo.Worker* console‑applicatie).

## **Basisimplementatie**

Het *BackgroundJobDemo.Local* project biedt een eenvoudige taak‑beheervervulling met een SQLite‑database (het databasepad wordt geconfigureerd via `LocalConfig.DbFilePath`; zie `Startup.ConfigureServices`). Geüploade en verwerkte bestanden worden opgeslagen op het bestandssysteem (het opslagmap‑pad wordt geconfigureerd via `LocalConfig.FileStorageFolderPath`; zie `Startup.ConfigureServices`). Voor betere fouttolerantie en prestaties in productieomgevingen moet taakplanning geïmplementeerd worden via berichtenwachtrijen (bijv. RabbitMQ, AWS SQS, Azure Storage Queue).

## **Gedistribueerde implementatie op Amazon Web Services**

Het *BackgroundJobDemo.Aws* project implementeert taakverwerking op Amazon Web Services en toont een horizontaal schaalbare gedistribueerde architectuur. Het omvat de volgende componenten:

- Webapp — interacteert met de gebruiker en plant PPTX‑naar‑PDF‑exporttaken in, enz.
- Worker — verwerkt exports (in‑process, out‑of‑process, of AWS Lambda).
- Berichtwachtrij — slaat taken op die verwerkt moeten worden (Amazon SQS).
- Bestandopslag — slaat geüploade en verwerkte bestanden op (Amazon S3).
- Sleutel‑waarde store — houdt de status van taakverwerking bij (Amazon DynamoDB).

Een typische gedistribueerde architectuur leunt op [message queues](https://aws.amazon.com/message-queue/): de webapp plaatst achtergrondtaken in een wachtrij; een achtergrond‑worker haalt taken uit de wachtrij en voert het benodigde werk uit. Dit ontkoppelt componenten en maakt verwerking asynchroon en betrouwbaar. De wachtrij garandeert aflevering en gebruikt een *visibility timeout*: wanneer één worker een bericht neemt, wordt het onzichtbaar voor andere workers; alleen de verwerkende worker verwijdert het bij voltooiing. Als de verwerking niet binnen de visibility timeout eindigt (bijv. door een fout of netwerkprobleem), wordt het onvoltooide bericht weer zichtbaar.

Onze implementatie maakt gebruik van [Amazon Simple Queue Service](https://aws.amazon.com/sqs/) (SQS), een volledig beheerde berichtenwachtrij voor microservices, gedistribueerde systemen en serverless applicaties.

Berichtenwachtrijen zijn bedoeld voor lichte berichten (bijv. de SQS‑berichtgrootte‑limiet is 256 KB), dus een bericht moet alleen de taakomschrijving bevatten. Zware data (zoals te verwerken bestanden) moeten apart worden opgeslagen en vanuit het bericht worden gerefereerd. [Amazon S3](https://aws.amazon.com/s3/) wordt gebruikt om geüploade en verwerkte bestanden op te slaan.

Een sleutel‑waarde store is nodig om taakresultaten per ID te bewaren en op te halen. Het voorbeeld gebruikt [Amazon DynamoDB](https://aws.amazon.com/dynamodb/), een snelle en flexibele NoSQL‑databaseservice.

Om de demo‑app met Amazon Web Services te draaien:

1. In dezelfde AWS‑regio, maak en configureer:
   1. een SQS‑wachtrij,
   1. een S3‑bucket,
   1. een DynamoDB‑tabel.
1. Verbind de webapp met deze services door *AddAws* aan te roepen in `Startup.ConfigureServices`, met de SQS‑wachtrij‑URL, S3‑bucket‑naam, DynamoDB‑tabel‑naam en AWS‑regio.

## **Referenties**

- [ASP.NET Core Performance Best Practices](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices)
- [Upload files in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)
- [Real-time ASP.NET with SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)
- [Message Queues](https://aws.amazon.com/message-queue/)
- [Amazon Simple Queue Service](https://aws.amazon.com/sqs/)
- [Amazon S3](https://aws.amazon.com/s3/)
- [Amazon DynamoDB](https://aws.amazon.com/dynamodb/)