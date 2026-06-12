---
title: Jak spouštět úlohy na pozadí v ASP.NET Core
type: docs
weight: 300
url: /cs/net/how-to-run-background-tasks-in-asp-net-core/
keywords:
- ASP.NET Core
- úloha na pozadí
- zpracování na pozadí
- hostovaná služba
- worker na pozadí
- fronta úloh
- asynchronní plánování úloh
- zpracování souborů na serveru
- sledování průběhu
- dotazování stavu
- SignalR notifikace
- AWS SQS
- Amazon S3
- Amazon DynamoDB
- škálovatelná architektura
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Spouštějte úlohy na pozadí v ASP.NET Core pomocí hostovaných služeb, front úloh a aktualizací stavu – zpracovávejte a převádějte PPT, PPTX a ODP pomocí Aspose.Slides."
---
## **Úvod**

Zpracování souborů (např. export prezentace do PDF) je typický úkol na straně serveru. Provádění uvnitř obsluhy požadavku (zatímco klient čeká) má následující nevýhody:

- *Špatné UI.* Stránka zmrzne a uživatel musí čekat na výsledek. Obnovení stránky úlohu zruší.
- *Časová limitace operace.* Nemůžeme zajistit, že zpracování bude dokončeno během pevně stanovené doby, takže uživatel pravděpodobně uvidí „timeout operace“.
- *Nízká propustnost a škálovatelnost.* ASP.NET Core je navržen pro asynchronní zpracování mnoha požadavků. Úlohy náročné na CPU a dlouho běžící blokují vlákna a snižují propustnost serveru.
- *Špatná odolnost proti chybám.* Pokud během dlouho běžící úlohy (např. kvůli problémům s připojením) něco selže, zpracování selže a musí se spustit znovu od začátku.

Lepším přístupem je [lepší přístup](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-9.0#complete-long-running-tasks-outside-of-http-requests), který úlohu naplánuje asynchronně, zpracuje ji na pozadí a vrátí výsledek, až bude připraven.

V tomto modelu může uživatel vidět aktuální stav (a může stránku opustit nebo obnovit), serverové zdroje lze efektivně škálovat a flexibilně ladit a lze použít politiku opakování.

Typické řešení zpracování na pozadí zahrnuje:

1. API pro plánování úlohy.
1. API pro sledování stavu úlohy.
1. Background worker pro zpracování naplánovaných úloh.
1. API pro ukládání a získávání výsledku.

## **Příklad úlohy na pozadí**

Pro demonstraci tohoto přístupu zvažte [vzorovou webovou aplikaci ASP.NET Core 3.1](./BackgroundJobDemo.zip). Aplikace obsahuje stránku, kde uživatel může nahrát prezentaci a kliknout na **Export do PDF**; prezentace je následně nahrána a převedena do PDF background workerem.

## **Webová aplikace**

Vzorová webová aplikace (projekt *BackgroundJobDemo*) zahrnuje:

- Stránku pro nahrávání souborů (Razor stránka „Upload“).
- Stránku s průběhem (Razor stránka „Progress“ s několika JavaScript funkcemi, které kontrolují a zobrazují stav).
- Controller (`JobStatusController`) poskytující stav zpracování (`api/status/{jobId}`).
- Controller (`JobResultController`) vracející exportovaný PDF soubor (`api/result/{id}`).
- Background worker založený na hostovací službě ASP.NET Core (viz třída `WorkerService`).

Razor stránky, controllery a background worker delegují skutečnou práci prostřednictvím rozhraní definovaných v projektu *BackgroundJobDemo.Common*. Konkrétní implementace správy úloh a zpracování jsou poskytovány v samostatných projektech (*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws* atd.) a lze je přepínat v metodě `Startup.ConfigureServices`.

Pro demonstrační účely používá stránka „Upload“ bufferované modelové svázání, ale pro velké nahrávání souborů je [doporučeno](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads) nebufferované streamování. Pro produkci zvažte relevantní [bezpečnostní aspekty](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations). Stránka „Progress“ pomocí JavaScriptu každé dvě sekundy (toto interval je konfigurovatelný) dotazuje stav naplánované úlohy. Polling je běžný, ale pro pokročilejší scénáře můžete potřebovat notifikace v reálném čase přes WebSockets (komunikace v reálném čase je mimo rozsah tohoto článku). [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) je jednoduchý, ale výkonný nástroj pro komunikaci v reálném čase.

Nasazení background workeru v serverovém procesu je pohodlné pro jednoduché aplikace, ale má [nevýhody](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx). Robustnější a škálovatelnější přístup je nasadit worker v samostatném procesu (viz např. konzolová aplikace *BackgroundJobDemo.Worker*).

## **Základní implementace**

Projekt *BackgroundJobDemo.Local* poskytuje jednoduchou implementaci správy úloh pomocí SQLite databáze (cesta k databázi je konfigurována přes `LocalConfig.DbFilePath`; viz `Startup.ConfigureServices`). Nahrané a zpracované soubory jsou ukládány do souborového systému (cesta k úložištní složce je konfigurována přes `LocalConfig.FileStorageFolderPath`; viz `Startup.ConfigureServices`). Pro lepší odolnost vůči chybám a výkon v reálných aplikacích by mělo být plánování úloh implementováno pomocí front zpráv (např. RabbitMQ, AWS SQS, Azure Storage Queue).

## **Distribuovaná implementace založená na Amazon Web Services**

Projekt *BackgroundJobDemo.Aws* implementuje zpracování úloh v Amazon Web Services a demonstruje horizontálně škálovatelnou distribuovanou architekturu. Obsahuje následující komponenty:

- Webová aplikace — interaguje s uživatelem a plánuje úlohy exportu PPTX do PDF atd.
- Worker — zpracovává exporty (v procesu, mimo proces nebo AWS Lambda).
- Fronta zpráv — ukládá úlohy k zpracování (Amazon SQS).
- Úložiště souborů — ukládá nahrané a zpracované soubory (Amazon S3).
- Klíč‑hodnotový obchod — sleduje stav zpracování úlohy (Amazon DynamoDB).

Typická distribuovaná architektura se spoléhá na [fronty zpráv](https://aws.amazon.com/message-queue/): webová aplikace vkládá úlohy na pozadí do fronty; background worker je z fronty načítá a provádí požadovanou práci. To odděluje komponenty a činí zpracování asynchronní a spolehlivé. Fronta garantuje doručení a používá *visibility timeout*: když jeden worker přijme zprávu, stane se neviditelnou pro ostatní workery; pouze zpracovávající worker ji po dokončení odstraní. Pokud zpracování nedokončí během visibility timeout (např. kvůli selhání nebo síťovému problému), nevyřízená zpráva se opět zpřístupní.

Naše implementace používá [Amazon Simple Queue Service](https://aws.amazon.com/sqs/) (SQS), plně řízenou frontu zpráv pro mikroservisy, distribuované systémy a serverless aplikace.

Fronty zpráv jsou určeny pro lehké zprávy (např. limit velikosti zprávy v SQS je 256 KB), takže zpráva by měla obsahovat pouze popis úkolu. Těžká data (jako soubory k zpracování) by měla být uložena odděleně a v zprávě na ně odkazováno. [Amazon S3] se používá k ukládání nahraných a zpracovaných souborů.

Klíč‑hodnotový obchod je potřeba k ukládání a získávání výsledků úloh podle ID. Příklad používá [Amazon DynamoDB], rychlou a flexibilní NoSQL databázovou službu.

Pro spuštění demonstrační aplikace s Amazon Web Services:

1. Ve stejném regionu AWS vytvořte a nakonfigurujte:
   1. SQS frontu,
   1. S3 bucket,
   1. tabulku DynamoDB.
1. Propojte webovou aplikaci s těmito službami voláním *AddAws* v `Startup.ConfigureServices` a poskytněte URL SQS fronty, název S3 bucketu, název tabulky DynamoDB a region AWS.

## **Reference**

- [Nejlepší postupy výkonu ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices)
- [Nahrávání souborů v ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)
- [ASP.NET v reálném čase se SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)
- [Fronty zpráv](https://aws.amazon.com/message-queue/)
- [Amazon Simple Queue Service](https://aws.amazon.com/sqs/)
- [Amazon S3](https://aws.amazon.com/s3/)
- [Amazon DynamoDB](https://aws.amazon.com/dynamodb/)