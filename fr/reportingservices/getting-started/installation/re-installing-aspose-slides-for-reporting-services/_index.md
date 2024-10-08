---
title: Réinstallation d'Aspose.Slides pour Reporting Services
type: docs
weight: 40
url: /fr/reportingservices/re-installing-aspose-slides-for-reporting-services/
---

{{% alert color="primary" %}} 

Cet article décrit la solution d'une situation dans laquelle Aspose.Slides pour Reporting Services est déjà installé, mais pour une raison quelconque, il doit être réinstallé.

{{% /alert %}} 

{{% alert title="Remarque" color="warning" %}} 

**Aspose.Slides pour Reporting Services** nécessite l'installation de **.NET Framework 3.5** sur la machine hôte. 

{{% /alert %}}

## **Étapes de réinstallation d'Aspose.Slides pour Reporting Services**
La chose la plus importante est la suppression complète des précédentes installations d'Aspose.Slides pour Reporting Services. Bien que l'installateur MSI puisse effectuer avec succès les actions nécessaires pour désinstaller et, par conséquent, réinstaller Aspose.Slides pour Reporting Services automatiquement, ces étapes doivent être suivies :

1. Désinstaller Aspose.Slides pour Reporting Services à l'aide de l'installateur MSI. 

2. Localiser le répertoire d'installation d'Aspose.Slides pour Reporting Services qui se trouve généralement à :

   **Lecteur de racine OS\Program Files\Aspose\Aspose.Slides pour Reporting Services** 

3. Si l'installateur MSI n'a pas supprimé le répertoire « Aspose.Slides pour Reporting Services » lorsqu'il a désinstallé Aspose.Slides pour Reporting Services, supprimez le dossier. 

4. Localiser le fichier binaire **Aspose.Slides.ReportingServices.dll** dans le répertoire « bin » de chaque instance SQL Server Reporting Service. Par exemple, s'il y a une instance Microsoft SQL Server 2008 « MSSQLSERVER », le répertoire « bin » de Reporting Service se trouve probablement à : 

   **Lecteur de racine OS\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. Si l'installateur MSI n'a pas supprimé le fichier binaire Aspose.Slides.ReportingServices.dll du répertoire ci-dessus lorsqu'il a désinstallé Aspose.Slides pour Reporting Services, supprimez le fichier maintenant.

6. Localiser le fichier **rsreportserver.config** pour chaque instance SSRS. Par exemple, s'il y a une instance de Reporting Service « **MSRS10.MSSQLSERVER** », le fichier **rsreportserver.config** sera dans ce répertoire :

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. Ouvrir le fichier **rsreportserver.config** dans n'importe quel éditeur et trouver les lignes qui ont été créées pour ajouter les extensions de format PowerPoint lors de l'installation d'Aspose.Slides pour Reporting Services. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

``` 

**Étape** **8 :** Si l'installateur MSI n'a pas supprimé ces lignes lorsqu'il a désinstallé Aspose.Slides pour Reporting Services, supprimez les lignes du fichier **rsreportserver.config** maintenant.

**Étape** **9 :** Localiser le fichier **rssrvpolicy.config** pour chaque instance SSRS. Par exemple, s'il y a une instance de Reporting Service « MSRS10.MSSQLSERVER », le fichier **rssrvpolicy.config** sera dans ce répertoire :

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Étape** **10 :** Ouvrir le fichier **rssrvpolicy.config** dans n'importe quel éditeur et trouver les lignes qui ont été créées pour accorder des autorisations d'exécution à Aspose.Slides pour Reporting Services lors de l'installation d'Aspose.Slides pour Reporting Services. 

**<CodeGroup>**

``` xml

   ...

  <CodeGroup>

    ...

    <!--Commencer ici.-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="Ce groupe de code accorde la pleine confiance à l'assemblage AS4SSRS.">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

           PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--Fin ici.-->

  </CodeGroup>

</CodeGroup>

``` 

**Étape** **11 :** Si l'installateur MSI n'a pas supprimé les lignes ci-dessus lorsqu'il a désinstallé le produit, supprimez ces lignes du fichier **rssrvpolicy.config** maintenant. 

**Étape** **12 :** Si Aspose.Slides pour Reporting Services a également été installé avec Microsoft Visual Studio pour le développement de rapports RDL et l'exportation vers les formats PowerPoint dans l'environnement Microsoft Visual Studio, le fichier binaire Aspose.Slides.ReportingServices.dll et les fichiers de configuration ( **rsreportserver.config** et **rssrvpolicy.config** ) dans le cas de Microsoft Visual Studio 2008 devraient être : 

**Lecteur de racine OS\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Étape** **13 :** Si l'installateur MSI n'a pas supprimé le fichier **Aspose.Slides.ReportingServices.dll** binaire, supprimez-le. De plus, s'il n'a pas mis à jour les fichiers **rsreportserver.config** et **rssrvpolicy.config** pour supprimer respectivement les extensions de format PowerPoint et les autorisations d'exécution de code, vous devez les supprimer manuellement de la même manière que vous l'avez fait avec les fichiers dans les étapes précédentes. 

**Étape** **14 :** Il est temps de réinstaller Aspose.Slides pour Reporting Services. Utilisez l'installateur MSI pour une installation automatique ou effectuez-le manuellement.