---
title: Déploiement facile et léger
type: docs
weight: 50
url: /fr/reportingservices/easy-and-lightweight-deployment/
description: "Découvrez comment Aspose.Slides for Reporting Services est déployé : une assembly dans le dossier bin du serveur de rapports, enregistrée dans la configuration du serveur de rapports."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for Reporting Services est une [extension de rendu](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) pour Microsoft SQL Server Reporting Services et Power BI Report Server.  
Aspose.Slides for Reporting Services est fourni sous la forme d'un seul installateur MSI qui peut s'installer sur des ordinateurs exécutant un serveur de rapports pris en charge, en 32 bits ou 64 bits ; voir la [Configuration requise](/slides/fr/reportingservices/system-requirements/).

Il est également facile de déployer et de gérer Aspose.Slides for Reporting Services manuellement, car il se compose d'une seule assembly .NET *Aspose.Slides* *.ReportingServices.dll*, entièrement écrite en C#, conforme CLS et ne contenant que du code géré sécurisé.

{{% /alert %}}

Le téléchargement ZIP comprend deux versions de Aspose.Slides.ReportingServices.dll pour les serveurs de rapports :

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – compilé pour Microsoft SQL Server 2005 et .NET Framework 2.0 (à utiliser pour x86 et x64)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – compilé pour Microsoft SQL Server 2008 et versions ultérieures, Power BI Report Server et .NET Framework 2.0 (à utiliser pour x86 et x64)

L'installateur MSI installe les deux mêmes versions et sélectionne la bonne pour chaque instance de serveur de rapports. [Installation manuelle](/slides/fr/reportingservices/install-manually/) répertorie chaque fichier du téléchargement ZIP.

Lors de l'installation, Aspose.Slides.ReportingServices.dll est copié dans le répertoire ReportServer\bin et le fichier de configuration est mis à jour afin que Reporting Services prenne en compte la nouvelle extension de rendu. Ces étapes sont effectuées par l'installateur Aspose.Slides for Reporting Services, mais vous pouvez également les réaliser manuellement comme décrit plus loin dans cette documentation.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figure** : Aspose.Slides.ReportingServices.dll est copié dans le répertoire **ReportServer\bin**.