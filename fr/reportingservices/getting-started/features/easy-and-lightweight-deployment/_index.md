---
title: Déploiement Facile et Léger
type: docs
weight: 50
url: /reportingservices/easy-and-lightweight-deployment/
---

{{% alert color="primary" %}} 

Aspose.Slides pour Reporting Services est une [extension de rendu](http://msdn2.microsoft.com/en-us/library/ms154606.aspx) pour Microsoft SQL Server Reporting Services. 
Aspose.Slides pour Reporting Services est fourni sous la forme d'un seul installateur MSI qui peut s'installer sur les ordinateurs exécutant l'un des systèmes suivants : 

- Microsoft SQL Server 2005 Reporting Services (32 bits et 64 bits)
- Microsoft SQL Server 2008 Reporting Services (32 bits et 64 bits)

Il est également facile de déployer et de gérer Aspose.Slides pour Reporting Services manuellement, car il est composé d'une seule assembly .NET *Aspose.Slides* *.ReportingServices.dll*, entièrement écrite en C#, conforme au CLS et contenant uniquement du code managé sécurisé. 

{{% /alert %}} 

L'installateur MSI et le téléchargement ZIP incluent Aspose.Slides pour ReportingServices : 

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – construit pour Microsoft SQL Server 2005 et .NET Framework 2.0 (à utiliser pour x86 et x64)
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – construit pour Microsoft SQL Server 2008 et .NET Framework 2.0 (à utiliser pour x86 et x64)

Lors de l'installation, Aspose.Slides.ReportingServices.dll est copié dans le répertoire ReportServer\bin et le fichier de configuration est mis à jour afin que Reporting Services soit conscient de la nouvelle extension de rendu. Ces étapes sont effectuées par l'installateur Aspose.Slides pour Reporting Services, mais vous pouvez également les effectuer manuellement comme décrit plus loin dans cette documentation. 

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figure** : Aspose.Slides.ReportingServices.dll est copié dans le répertoire **ReportServer\bin**.