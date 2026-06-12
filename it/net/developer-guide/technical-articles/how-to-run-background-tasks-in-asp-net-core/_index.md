---
title: Come eseguire attività in background in ASP.NET Core
type: docs
weight: 300
url: /it/net/how-to-run-background-tasks-in-asp-net-core/
keywords:
- ASP.NET Core
- attività in background
- elaborazione in background
- servizio hosted
- worker in background
- coda di lavori
- pianificazione asincrona dei lavori
- elaborazione file lato server
- monitoraggio dell'avanzamento
- interrogazione dello stato
- notifiche SignalR
- AWS SQS
- Amazon S3
- Amazon DynamoDB
- architettura scalabile
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Esegui attività in background in ASP.NET Core con Servizi hosted, code di lavori e aggiornamenti di stato – elabora e converti PPT, PPTX e ODP utilizzando Aspose.Slides."
---
## **Introduzione**

File processing (ad es., esportazione di una presentazione in PDF) è un tipico compito lato server. Eseguirlo all'interno del gestore della richiesta (mentre il client attende) presenta i seguenti svantaggi:

- *Interfaccia scadente.* La pagina si blocca e l'utente deve attendere il risultato. Ricaricare la pagina annulla l'operazione.
- *Timeout delle operazioni.* Non possiamo garantire che l'elaborazione termini entro un periodo fissato, quindi è probabile che l'utente veda un "timeout dell'operazione".
- *Bassa capacità di throughput e scalabilità.* ASP.NET Core è progettato per elaborare molte richieste in modo asincrono. Attività lunghe e CPU-bound bloccano i thread e riducono il throughput del server.
- *Scarsa tolleranza ai guasti.* Se qualcosa va storto durante un'attività di lunga durata (ad es., un problema di connettività), l'elaborazione fallisce e deve essere riavviata dall'inizio.

Un [approccio migliore](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-9.0#complete-long-running-tasks-outside-of-http-requests) consiste nel programmare il lavoro in modo asincrono, elaborarlo in background e restituire il risultato quando è pronto.

In questo modello, l'utente può vedere lo stato corrente (e può lasciare o ricaricare la pagina), le risorse del server possono essere scalate in modo efficiente e configurate flessibilmente, e può essere applicata una politica di retry.

Una tipica soluzione di elaborazione in background include:
1. Un'API per programmare il lavoro.
1. Un'API per monitorare lo stato del lavoro.
1. Un worker in background per elaborare i lavori programmati.
1. Un'API per memorizzare e recuperare il risultato.

## **Esempio di attività in background**

Per dimostrare questo approccio, considerare il [campione di applicazione web ASP.NET Core 3.1](./BackgroundJobDemo.zip). L'app include una pagina in cui l'utente può caricare una presentazione e fare clic su **Export to PDF**; la presentazione viene quindi caricata e convertita in PDF da un worker in background.

## **Applicazione web**

L'applicazione web campione (progetto *BackgroundJobDemo*) include:
- Pagina di caricamento file (pagina Razor "Upload").
- Pagina di avanzamento (pagina Razor "Progress" con alcune funzioni JavaScript che controllano e mostrano lo stato).
- Controller (`JobStatusController`) che fornisce lo stato dell'elaborazione (`api/status/{jobId}`).
- Controller (`JobResultController`) che restituisce il file PDF esportato (`api/result/{id}`).
- Worker in background basato sul servizio di hosting ASP.NET Core (vedi la classe `WorkerService`).

Le pagine Razor, i controller e il worker in background delegano il lavoro reale tramite interfacce definite nel progetto *BackgroundJobDemo.Common*. Implementazioni concrete di gestione e elaborazione dei lavori sono fornite in progetti separati (*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws*, ecc.) e possono essere cambiate nel metodo `Startup.ConfigureServices`.

Per scopi dimostrativi, la pagina "Upload" utilizza il binding del modello in modalità bufferizzata, ma per caricamenti di file di grandi dimensioni lo streaming non bufferizzato è [raccomandato](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads). Per la produzione, considerare gli [aspetti di sicurezza](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations). La pagina "Progress" interroga lo stato del lavoro programmato tramite JavaScript ogni due secondi (intervallo configurabile). L'interrogazione è tipica, ma per scenari più avanzati potrebbe essere necessaria la notifica in tempo reale via WebSockets (le comunicazioni in tempo reale sono al di fuori dell'ambito di questo articolo). [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) è uno strumento semplice ma potente per le comunicazioni in tempo reale.

Eseguire il worker in background nel processo del server è comodo per applicazioni semplici ma presenta [svantaggi](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx). Un approccio più robusto e scalabile è distribuire il worker in un processo separato (vedi, ad es., l'applicazione console *BackgroundJobDemo.Worker*).

## **Implementazione di base**

Il progetto *BackgroundJobDemo.Local* fornisce una semplice implementazione di gestione dei lavori usando un database SQLite (il percorso del database è configurato tramite `LocalConfig.DbFilePath`; vedi `Startup.ConfigureServices`). I file caricati e processati sono memorizzati sul file system (il percorso della cartella di archiviazione è configurato tramite `LocalConfig.FileStorageFolderPath`; vedi `Startup.ConfigureServices`). Per una migliore tolleranza ai guasti e prestazioni in applicazioni reali, la pianificazione dei lavori dovrebbe essere implementata tramite code di messaggi (ad es., RabbitMQ, AWS SQS, Azure Storage Queue).

## **Implementazione distribuita basata su Amazon Web Services**

Il progetto *BackgroundJobDemo.Aws* implementa l'elaborazione dei lavori su Amazon Web Services e dimostra un'architettura distribuita scalabile orizzontalmente. Include i seguenti componenti:
- Applicazione web — interagisce con l'utente e programma i compiti di esportazione PPTX‑to‑PDF, ecc.
- Worker — elabora le esportazioni (in-process, out-of-process o AWS Lambda).
- Coda di messaggi — memorizza i compiti da elaborare (Amazon SQS).
- Archiviazione file — memorizza i file caricati e processati (Amazon S3).
- Archivio chiave‑valore — traccia lo stato di elaborazione dei compiti (Amazon DynamoDB).

Un'architettura distribuita tipica si basa su [code di messaggi](https://aws.amazon.com/message-queue/): l'app web inserisce i compiti di background in una coda; un worker in background recupera i compiti dalla coda ed esegue il lavoro richiesto. Questo desacoppia i componenti e rende l'elaborazione asincrona e affidabile. La coda garantisce la consegna e utilizza un *visibility timeout*: quando un worker preleva un messaggio, questo diventa invisibile agli altri worker; solo il worker che lo elabora lo rimuove al completamento. Se l'elaborazione non termina entro il visibility timeout (ad es., per un guasto o un problema di rete), il messaggio non processato diventa nuovamente visibile.

La nostra implementazione utilizza [Amazon Simple Queue Service](https://aws.amazon.com/sqs/) (SQS), una coda di messaggi completamente gestita per microservizi, sistemi distribuiti e applicazioni serverless.

Le code di messaggi sono destinate a messaggi leggeri (ad es., il limite di dimensione dei messaggi SQS è 256 KB), quindi un messaggio dovrebbe contenere solo la descrizione del compito. Dati ingombranti (come i file da elaborare) dovrebbero essere memorizzati separatamente e referenziati dal messaggio. [Amazon S3](https://aws.amazon.com/s3/) è utilizzato per memorizzare i file caricati e processati.

È necessario un archivio chiave‑valore per persistere e recuperare i risultati dei lavori per ID. L'esempio utilizza [Amazon DynamoDB](https://aws.amazon.com/dynamodb/), un servizio di database NoSQL veloce e flessibile.

Per eseguire l'app dimostrativa con Amazon Web Services:
1. Nella stessa regione AWS, creare e configurare:
   1. una coda SQS,
   1. un bucket S3,
   1. una tabella DynamoDB.
1. Collegare l'app web a questi servizi chiamando *AddAws* in `Startup.ConfigureServices`, fornendo l'URL della coda SQS, il nome del bucket S3, il nome della tabella DynamoDB e la regione AWS.

## **Riferimenti**

- [Best practice di performance di ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices)
- [Caricamento file in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)
- [ASP.NET in tempo reale con SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)
- [Code di messaggi](https://aws.amazon.com/message-queue/)
- [Amazon Simple Queue Service](https://aws.amazon.com/sqs/)
- [Amazon S3](https://aws.amazon.com/s3/)
- [Amazon DynamoDB](https://aws.amazon.com/dynamodb/)