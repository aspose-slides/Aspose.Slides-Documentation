---
title: Eenvoudige en Lichtgewicht Implementatie
type: docs
weight: 50
url: /nl/reportingservices/easy-and-lightweight-deployment/
description: "Leer hoe Aspose.Slides for Reporting Services wordt geïmplementeerd: één assembly in de bin-map van de rapportserver, geregistreerd in de configuratie van de rapportserver."
---
{{% alert color="info" title="Opmerking" %}}

Aspose.Slides for Reporting Services is een [rendering extension](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) voor Microsoft SQL Server Reporting Services en Power BI Report Server.  
Aspose.Slides for Reporting Services wordt geleverd als één MSI‑installatieprogramma dat kan worden geïnstalleerd op computers met een ondersteunde rapportserver, 32‑bit of 64‑bit; zie [System Requirements](/slides/nl/reportingservices/system-requirements/).

Het is bovendien eenvoudig om Aspose.Slides for Reporting Services handmatig te implementeren en beheren, omdat het bestaat uit slechts één .NET‑assembly *Aspose.Slides* *.ReportingServices.dll* , volledig geschreven in C#, CLS‑compatible en alleen veilige beheerde code bevat.

{{% /alert %}}

De ZIP‑download bevat twee builds van Aspose.Slides.ReportingServices.dll voor rapportservers:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – gecompileerd voor Microsoft SQL Server 2005 en .NET Framework 2.0 (gebruik voor x86 en x64)  
- Bin\Universal\Aspose.Slides.ReportingServices.dll – gecompileerd voor Microsoft SQL Server 2008 en later, Power BI Report Server en .NET Framework 2.0 (gebruik voor x86 en x64)

Het MSI‑installatieprogramma installeert dezelfde twee builds en selecteert de juiste voor elke rapportserver‑instantie. [Install Manually](/slides/nl/reportingservices/install-manually/) vermeldt elk bestand in de ZIP‑download.

Bij installatie wordt Aspose.Slides.ReportingServices.dll gekopieerd naar de map ReportServer\bin en wordt het configuratiebestand bijgewerkt zodat Reporting Services op de hoogte is van de nieuwe rendering‑extension. Deze stappen worden uitgevoerd door het Aspose.Slides for Reporting Services‑installatieprogramma, maar u kunt ze ook handmatig uitvoeren zoals verder beschreven in deze documentatie.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figure**: Aspose.Slides.ReportingServices.dll wordt gekopieerd naar de **ReportServer\bin**‑map.