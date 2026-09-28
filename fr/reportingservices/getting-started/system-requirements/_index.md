---
title: Exigences du système
type: docs
weight: 15
url: /fr/reportingservices/system-requirements/
keywords:
- exigences du système
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "Vérifiez quels serveurs de rapports, quelles éditions et quelle version du .NET Framework Aspose.Slides for Reporting Services nécessite avant de l'installer."
---
## **Vue d'ensemble**

Aspose.Slides for Reporting Services s'exécute à l'intérieur du serveur de rapports en tant qu'extension de rendu. Cette page répertorie ce dont la machine du serveur de rapports a besoin avant de [installer](/slides/fr/reportingservices/installing-aspose-slides-for-reporting-services/) l'extension. Microsoft PowerPoint et Microsoft Office ne sont pas requis.

## **Serveurs de rapports pris en charge**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, pour les rapports paginés (RDL) reports

Les serveurs de rapports 32 bits et 64 bits sont tous deux pris en charge. SQL Server 2005 utilise sa propre version de l'extension ; toutes les versions ultérieures et Power BI Report Server utilisent la même version. [Installer manuellement](/slides/fr/reportingservices/install-manually/) indique quel fichier copier.

Si la version de votre serveur de rapports ne figure pas dans cette liste, demandez sur le [forum de support gratuit](https://forum.aspose.com/c/slides/11) avant de déployer.

## **Éditions du serveur de rapports**

Pour SQL Server 2016 Reporting Services et versions ultérieures ainsi que pour Power BI Report Server, Microsoft prend en charge les extensions de rendu dans les éditions Enterprise, Standard, Developer et Evaluation ; les éditions Web et Express ne les prennent pas en charge. Voir [Reporting Services features supported by editions](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). Le programme d'installation MSI ignore les instances d'édition Express de SQL Server 2016 et antérieures.

## **.NET Framework**

Le .NET Framework 3.5 doit être installé sur la machine du serveur de rapports. Les assemblages de l'extension sont construits pour le runtime .NET Framework 2.0, et le programme d'installation MSI s'arrête avec un message si le .NET Framework 3.5 est absent. Sous Windows Server, ajoutez **.NET Framework 3.5 Features** dans l'Assistant Ajout de rôles et de fonctionnalités ; voir [Install .NET Framework 3.5 on Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **Permissions**

L'installation de l'extension modifie des fichiers dans le dossier du serveur de rapports, donc les deux méthodes d'installation nécessitent des droits d'administrateur local. Si vous lancez le programme d'installation MSI sans ces droits, il propose de redémarrer avec les privilèges administrateur.

## **FAQ**

**Ai-je besoin de Microsoft PowerPoint sur le serveur de rapports ?**

Non. L'extension crée les présentations elle-meme; ni PowerPoint ni Microsoft Office n'ont besoin d'etre installes.

**Puis-je installer l'extension sur une édition Express ?**

Non. Les éditions Express ne prennent pas en charge les extensions de rendu. Le programme d'installation MSI masque les instances Express de SQL Server 2016 et antérieures ; sur les versions ultérieures, ne choisissez pas d'instance Express.

**Quels formats l'extension ajoute-t-elle à la liste d'exportation ?**

PPT, PPS, PPTX, PPSX, ODP et XPS. Voir [Supported File Formats](/slides/fr/reportingservices/supported-file-formats/).