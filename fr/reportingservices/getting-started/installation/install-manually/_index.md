---
title: Installation manuelle
type: docs
weight: 30
url: /fr/reportingservices/install-manually/
keywords:
  - installation manuelle
  - rsreportserver.config
  - rssrvpolicy.config
  - SQL Server Reporting Services
  - Power BI Report Server
  - Aspose.Slides for Reporting Services
description: "Installez Aspose.Slides for Reporting Services manuellement à partir du paquet ZIP contenant uniquement les DLL : quelle assembly copier et quoi ajouter à rsreportserver.config et rssrvpolicy.config."
---
## **Vue d'ensemble**

Suivez ces étapes pour installer Aspose.Slides for Reporting Services sans l'installateur MSI, à partir du paquet ZIP *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* sur la [page de téléchargement](https://releases.aspose.com/slides/fr/reportingservices/). Elles enregistrent les mêmes extensions que l'[installateur MSI](/slides/fr/reportingservices/install-with-msi-installer/). Répétez-les pour chaque instance du serveur de rapports.

Avant de commencer, vérifiez les [conditions système](/slides/fr/reportingservices/system-requirements/). Vous avez besoin de droits d'administrateur local sur le serveur de rapports.

## **Choisir l'assembly**

Le paquet ZIP contient plusieurs compilations. Copiez exactement un *Aspose.Slides.ReportingServices.dll* sur le serveur de rapports :

| Fichier dans le paquet ZIP | Utilisation |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 et les versions ultérieures Reporting Services, et Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | Pas pour un serveur de rapports : applications qui exportent depuis le contrôle ReportViewer 2010 ou 2012, voir [Utilisation d'Aspose.Slides avec ReportViewer 2010 et 2012](/slides/fr/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | Facultatif : enregistre les rapports au format RPL pour les rapports de problème, voir [Exportation de rapports au format RPL](/slides/fr/reportingservices/exporting-reports-to-rpl-format/) |

## **Trouver le dossier du serveur de rapports**

Les étapes ci‑dessous font référence au dossier *ReportServer* du serveur de rapports, qui contient *rsreportserver.config* et *rssrvpolicy.config*. Dans une installation par défaut, il se trouve à :

| Serveur de rapports | Dossier *ReportServer* par défaut |
| :- | :- |
| SQL Server 2017 et les versions ultérieures Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 et les versions antérieures Reporting Services | `C:\Program Files\Microsoft SQL Server\<dossier d'instance>\Reporting Services\ReportServer`, où le dossier d'instance est, par exemple, `MSRS13.MSSQLSERVER` pour SQL Server 2016 ou `MSSQL.x` pour SQL Server 2005 |

Pour plus d'emplacements, consultez l'article [RsReportServer.config configuration file](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file).

## **Installer l'extension**

1. Copiez l'assembly choisi dans le sous‑dossier *bin* du dossier *ReportServer*.

   Le fichier copié ne doit pas conserver d’autorisations NTFS explicites, sinon le serveur de rapports se voit refuser l’accès lors du chargement de l’assembly et les nouveaux formats d’exportation n’apparaissent pas. Faites un clic droit sur le fichier, choisissez **Propriétés**, puis dans l’onglet **Sécurité** supprimez toutes les autorisations explicitement attribuées, ne laissant que celles héritées. Si l’onglet **Général** affiche une option **Débloquer**, sélectionnez‑la.

2. Enregistrez une copie de *rsreportserver.config*, puis ouvrez le fichier dans un éditeur de texte. Ajoutez ces entrées à l’intérieur de l’élément `<Render>` :

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   Chaque entrée enregistre un format d’exportation ; `Name` doit être unique parmi les extensions de rendu. L’installateur MSI enregistre les mêmes six noms et types. Omettez une entrée si vous ne souhaitez pas son format dans la liste d’exportation.

3. Enregistrez une copie de *rssrvpolicy.config*, puis ouvrez le fichier dans un éditeur de texte. Recherchez le groupe de code dont la `Description` est "This code group grants MyComputer code Execution permission." et ajoutez ce groupe de code comme son dernier enfant :

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` est la clé publique de l’assembly Aspose.Slides.ReportingServices. Conservez‑la sur une seule ligne.

4. Enregistrez les deux fichiers. Le serveur de rapports relit ses fichiers de configuration chaque fois qu’ils sont enregistrés. Si un fichier contient du XML mal formé, le serveur de rapports l’ignore ou ne démarre pas, alors restaurez votre copie si quelque chose tourne mal.

## **Vérifier l'installation**

Ouvrez un rapport paginé dans le portail Web (Report Manager sur SQL Server 2014 et antérieur) et ouvrez la liste **Export**. Elle inclut maintenant ces formats :

- PPT – PowerPoint Presentation via Aspose.Slides
- PPS – PowerPoint SlideShow via Aspose.Slides
- PPTX – PowerPoint 2007 Presentation via Aspose.Slides
- PPSX – PowerPoint 2007 SlideShow via Aspose.Slides
- ODP – OpenDocument Presentation via Aspose.Slides
- XPS – via Aspose.Slides

Sélectionnez‑en un pour exporter le rapport. Le fichier s’ouvre dans l’application associée à son format.

![Un rapport exporté vers PowerPoint par Aspose.Slides for Reporting Services](install-manually_2.png)

Si les formats n’apparaissent pas, vérifiez les autorisations NTFS de l’assembly copié. Sans licence, les fichiers exportés portent un filigrane d’évaluation ; voir [Licensing](/slides/fr/reportingservices/license-aspose-slides-for-reporting-services/).