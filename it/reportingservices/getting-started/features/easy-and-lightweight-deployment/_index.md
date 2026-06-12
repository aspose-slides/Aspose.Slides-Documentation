---
title: Distribuzione facile e leggera
type: docs
weight: 50
url: /it/reportingservices/easy-and-lightweight-deployment/
---
{{% alert color="primary" %}} 

Aspose.Slides for Reporting Services è un'[estensione di rendering](http://msdn2.microsoft.com/en-us/library/ms154606.aspx) per Microsoft SQL Server Reporting Services.  
Aspose.Slides for Reporting Services viene fornito come singolo installer MSI che può essere installato sui computer che eseguono una delle seguenti versioni:

- Microsoft SQL Server 2005 Reporting Services (32‑bit e 64‑bit)
- Microsoft SQL Server 2008 Reporting Services (32‑bit e 64‑bit)

È inoltre semplice distribuire e gestire manualmente Aspose.Slides for Reporting Services, poiché è costituito da un unico assembly .NET *Aspose.Slides*.ReportingServices.dll, scritto interamente in C#, conforme a CLS e contenente solo codice gestito sicuro.  

{{% /alert %}} 

L’installer MSI e il download ZIP includono Aspose.Slides for ReportingServices:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – compilato per Microsoft SQL Server 2005 e .NET Framework 2.0 (da usare per x86 e x64)
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – compilato per Microsoft SQL Server 2008 e .NET Framework 2.0 (da usare per x86 e x64)

Durante l’installazione, Aspose.Slides.ReportingServices.dll viene copiato nella cartella ReportServer\bin e il file di configurazione viene aggiornato affinché Reporting Services riconosca la nuova estensione di rendering. Queste operazioni sono eseguite dall’installer di Aspose.Slides for Reporting Services, ma è anche possibile effettuarle manualmente come descritto più avanti nella presente documentazione. 

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figura**: Aspose.Slides.ReportingServices.dll viene copiato nella directory **ReportServer\bin**.