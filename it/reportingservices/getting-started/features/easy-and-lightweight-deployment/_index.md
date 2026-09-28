---
title: Distribuzione facile e leggera
type: docs
weight: 50
url: /it/reportingservices/easy-and-lightweight-deployment/
description: "Scopri come viene distribuito Aspose.Slides for Reporting Services: una singola assembly nella cartella bin del server di report, registrata nella configurazione del server di report."
---
{{% alert color="info" title="Nota" %}}

Aspose.Slides for Reporting Services è una [estensione di rendering](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) per Microsoft SQL Server Reporting Services e Power BI Report Server.  
Aspose.Slides for Reporting Services è fornita come un unico installer MSI che può essere installato su computer che eseguono un server di report supportato, a 32‑bit o 64‑bit; vedere i [Requisiti di sistema](/slides/it/reportingservices/system-requirements/).

È anche facile distribuire e gestire Aspose.Slides for Reporting Services manualmente, poiché è composta da una sola assembly .NET *Aspose.Slides* *.ReportingServices.dll* , scritta interamente in C#, conforme a CLS e contenente solo codice gestito sicuro.

{{% /alert %}}

Il download ZIP include due build di Aspose.Slides.ReportingServices.dll per i server di report:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – compilata per Microsoft SQL Server 2005 e .NET Framework 2.0 (da usare per x86 e x64)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – compilata per Microsoft SQL Server 2008 e versioni successive, Power BI Report Server e .NET Framework 2.0 (da usare per x86 e x64)

L’installer MSI installa le stesse due build e seleziona quella corretta per ogni istanza del server di report. [Installa manualmente](/slides/it/reportingservices/install-manually/) elenca tutti i file nel download ZIP.

Durante l’installazione, Aspose.Slides.ReportingServices.dll viene copiata nella directory ReportServer\bin e il file di configurazione viene aggiornato in modo che Reporting Services sia a conoscenza della nuova estensione di rendering. Queste operazioni vengono eseguite dall’installer di Aspose.Slides for Reporting Services, ma è possibile effettuarle manualmente come descritto più avanti in questa documentazione.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figura**: Aspose.Slides.ReportingServices.dll è copiata nella directory **ReportServer\bin**.