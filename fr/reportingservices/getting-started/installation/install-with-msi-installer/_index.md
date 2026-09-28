---
title: Installer avec l'installateur MSI
type: docs
weight: 20
url: /fr/reportingservices/install-with-msi-installer/
keywords:
- installateur MSI
- installation
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Installez Aspose.Slides for Reporting Services avec son programme d'installation MSI : ce dont l'installateur a besoin, ce qu'il modifie sur chaque instance du serveur de rapports, et comment vérifier le résultat."
---
## **Installation**

Le programme d'installation MSI est la façon la plus simple d'installer Aspose.Slides for Reporting Services. Il nécessite le .NET Framework 3.5 et des droits d'administrateur sur le serveur de rapports ; voir [Exigences système](/slides/fr/reportingservices/system-requirements/).

1. Téléchargez le programme d'installation MSI, *Aspose.Slides for Reporting Services XX.XX*, depuis la [page de téléchargement](https://releases.aspose.com/slides/reportingservices/) et copiez‑le sur le serveur de rapports.
1. Exécutez‑le en tant qu'administrateur. Si le .NET Framework 3.5 est absent, l'installateur s'arrête avec un message ; installez les fonctionnalités du .NET Framework 3.5 et exécutez‑le de nouveau.
1. Acceptez le contrat de licence.
1. Sur la page **Custom Setup**, l'arborescence des fonctionnalités répertorie chaque instance de SQL Server Reporting Services et de Power BI Report Server détectée par l'installateur sur la machine. Pour laisser une instance inchangée, cliquez sur son icône et sélectionnez **Entire feature will be unavailable**. Les éditions Express ne prennent pas en charge les extensions de rendu, ne sélectionnez donc pas une instance Express. L'installateur masque les instances Express de SQL Server 2016 et antérieures.
1. Sélectionnez **Next**, puis **Install**.

La fonction optionnelle **Rpl Export** n'est pas sélectionnée par défaut. Elle ajoute une extension cachée qui enregistre les rapports au format RPL, ce qui est utile lorsque vous envoyez un rapport de problème à Aspose ; voir [Exportation de rapports au format RPL](/slides/fr/reportingservices/exporting-reports-to-rpl-format/).

## **Ce que l'installateur modifie**

L'installateur conserve ses fichiers dans *Aspose\Aspose.Slides for Reporting Services* sous le dossier Program Files — *Program Files (x86)* sur Windows 64 bits, car l'installateur est un package 32 bits. Ensuite, pour chaque instance sélectionnée, il :

- copie *Aspose.Slides.ReportingServices.dll* dans le dossier *ReportServer\bin* de l'instance — la version pour SQL Server 2005, ou la version pour SQL Server 2008 et ultérieurs ainsi que Power BI Report Server ;
- ajoute six extensions de rendu — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS et ASODP — à l'élément `<Render>` de *rsreportserver.config* ;
- ajoute un groupe de code qui accorde une confiance totale à l'assembly dans *rssrvpolicy.config* ;
- enregistre une copie de chaque fichier de configuration modifié, avec l'extension *.bak* ajoutée au nom du fichier.

[Installer manuellement](/slides/fr/reportingservices/install-manually/) montre ces modifications étape par étape.

Si une instance ne peut pas être configurée, l'installateur la mentionne dans un message et écrit les détails dans *rserrors<date>.log* dans le dossier d'installation. Installez l'extension sur cette instance manuellement.

## **Vérifier l'installation**

Ouvrez un rapport paginé dans le portail web (Report Manager sur SQL Server 2014 et versions antérieures) et ouvrez la liste **Export**. Elle inclut désormais ces formats :

- PPT - Présentation PowerPoint via Aspose.Slides
- PPS - Diaporama PowerPoint via Aspose.Slides
- PPTX - Présentation PowerPoint 2007 via Aspose.Slides
- PPSX - Diaporama PowerPoint 2007 via Aspose.Slides
- ODP - Présentation OpenDocument via Aspose.Slides
- XPS - via Aspose.Slides

Sans licence, les fichiers exportés portent un filigrane d'évaluation ; voir [Licence](/slides/fr/reportingservices/license-aspose-slides-for-reporting-services/).

## **Quand installer manuellement**

Installez l'extension [manuellement](/slides/fr/reportingservices/install-manually/) plutôt lorsque :

- l'installateur ne peut pas configurer une instance, par exemple à cause des paramètres de sécurité du serveur ;
- après une mise à jour, vous souhaitez remplacer uniquement l'assembly au lieu de désinstaller l'ancienne version et d'exécuter le nouvel installateur.

La désinstallation du produit supprime l'assembly ainsi que les entrées de configuration de chaque instance.