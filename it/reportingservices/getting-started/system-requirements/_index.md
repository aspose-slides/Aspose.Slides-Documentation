---
title: Requisiti di sistema
type: docs
weight: 15
url: /it/reportingservices/system-requirements/
keywords:
- requisiti di sistema
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "Verifica quali server di report, edizioni e versione di .NET Framework richiede Aspose.Slides for Reporting Services prima di installarlo."
---
## **Panoramica**

Aspose.Slides per Reporting Services viene eseguito all'interno del server report come un'estensione di rendering. Questa pagina elenca ciò che la macchina del server report richiede prima di [installare](/slides/it/reportingservices/installing-aspose-slides-for-reporting-services/) l'estensione. Microsoft PowerPoint e Microsoft Office non sono richiesti.

## **Server report supportati**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, per report paginati (RDL)

Sia i server report a 32 bit sia a 64 bit sono supportati. SQL Server 2005 utilizza una propria build dell'estensione; tutte le versioni successive e Power BI Report Server utilizzano la stessa build. [Installare manualmente](/slides/it/reportingservices/install-manually/) mostra quale file copiare.

Se la versione del tuo server report non è in questo elenco, chiedi sul [forum di supporto gratuito](https://forum.aspose.com/c/slides/it/11) prima di distribuire.

## **Edizioni del server report**

Per SQL Server 2016 Reporting Services e versioni successive e per Power BI Report Server, Microsoft supporta le estensioni di rendering nelle edizioni Enterprise, Standard, Developer e Evaluation; le edizioni Web ed Express non le supportano. Vedi [Funzionalità di Reporting Services supportate per edizione](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). Il programma di installazione MSI ignora le istanze dell'edizione Express di SQL Server 2016 e precedenti.

## **.NET Framework**

.NET Framework 3.5 deve essere installato sulla macchina del server report. Gli assembly dell'estensione sono compilati per il runtime .NET Framework 2.0 e il programma di installazione MSI si interrompe con un messaggio se .NET Framework 3.5 è mancante. Su Windows Server, aggiungi **.NET Framework 3.5 Features** nella procedura guidata Aggiungi ruoli e funzionalità; vedi [Installa .NET Framework 3.5 su Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **Autorizzazioni**

L'installazione dell'estensione modifica i file nella cartella del server report, quindi entrambi i percorsi di installazione richiedono diritti di amministratore locale. Se avvii il programma di installazione MSI senza di essi, ti offre di riavviarsi con privilegi di amministratore.

## **FAQ**

**Ho bisogno di Microsoft PowerPoint sul server report?**

No. L'estensione crea le presentazioni da sé; né PowerPoint né Microsoft Office devono essere installati.

**Posso installare l'estensione su un'edizione Express?**

No. Le edizioni Express non supportano le estensioni di rendering. Il programma di installazione MSI nasconde le istanze Express di SQL Server 2016 e precedenti; per le versioni successive, non selezionare un'istanza Express.

**Quali formati aggiunge l'estensione all'elenco di esportazione?**

PPT, PPS, PPTX, PPSX, ODP e XPS. Vedi [Formati di file supportati](/slides/it/reportingservices/supported-file-formats/).