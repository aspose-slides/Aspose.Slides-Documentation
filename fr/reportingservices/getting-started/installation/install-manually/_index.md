---
title: Installer Manuellement
type: docs
weight: 30
url: /fr/reportingservices/install-manually/
---

{{% alert color="primary" %}} 

Suivez ces étapes uniquement si vous prévoyez d'installer Aspose.Slides pour Reporting Services manuellement. Dans ce cas, vous avez téléchargé le paquet ZIP contenant les fichiers d'assemblage. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides pour Reporting Services** nécessite l'installation de **.NET Framework 3.5** sur la machine hôte. 

{{% /alert %}}

### **Installation Manuelle**
Ces instructions vous montrent comment copier et modifier des fichiers dans le répertoire où Microsoft SQL Server Reporting Services est installé :

1. Localisez le répertoire d'installation du serveur de rapports.
   Le répertoire racine pour Microsoft SQL Server se trouve généralement ici : ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 et 2008** : Il peut y avoir plusieurs instances de Microsoft SQL Server configurées sur la machine et elles peuvent occuper différents sous-répertoires MSSQL.x tels que MSSQL.1, MSSQL.2, etc. Vous devez trouver le bon répertoire ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** avant de continuer à l'étape suivante.
   
   {{% /alert %}} Tous les chemins utilisés ci-dessous se référeront à ce répertoire comme <Instance>. 

2. Copiez Aspose.Slides.ReportingServices.dll dans le dossier **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin**.
   Le téléchargement **Aspose.Slides.ReportingServices.zip** contient **Aspose.Slides.ReportingServices.dll**. {{% alert color="primary" %}} 

Dans certains cas, lorsque vous copiez le DLL dans le répertoire **ReportServer\bin**, il peut être copié avec les permissions de fichiers NTFS explicites qui lui sont assignées. Les permissions NTFS empêchent Microsoft SQL Server Reporting Services d'accéder à **Aspose.Slides.ReportingServices.dll**. Si cela se produit, les nouveaux formats d'exportation ne seront pas disponibles. Vérifiez et confirmez que les bonnes permissions NTFS sont en place :

   1. Cliquez avec le bouton droit sur **Aspose.Slides.ReportingServices.dll**.
   1. Cliquez sur **Propriétés** et sélectionnez l'onglet **Sécurité**.
   1. Supprimez toutes les permissions NTFS explicitement assignées et laissez uniquement les permissions héritées.

{{% /alert %}}

3. Enregistrez Aspose.Slides pour Reporting Services en tant qu'extension de rendu : 
   1. Ouvrez *C:\Program
      Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*.
   1. Ajoutez ces lignes à l'élément <Render> : 

**<Render>**

``` xml

   ...

  <!--Commencez ici.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--Fin ici.-->

</Render>



```

4. Donnez à Aspose.Slides pour Reporting Services les permissions d'exécution : 
   1. Ouvrez **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**.
   1. Ajoutez ce qui suit comme dernier élément dans le deuxième élément <CodeGroup> extérieur (qui devrait être <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="Ce groupe de code accorde la permission d'exécution du code MyComputer. ">). 

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--Commencez ici.-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="Ce groupe de code accorde une confiance totale à l'assemblage AS4SSRS.">

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

5. Vérifiez qu'Aspose.Slides pour Reporting Services a été installé avec succès : 
   1. Ouvrez le Gestionnaire de rapports et vérifiez la liste des types d'exportation disponibles pour un rapport. 
   
      {{% alert color="primary" %}} Vous pouvez lancer le Gestionnaire de rapports en ouvrant un navigateur (Microsoft Internet Explorer 6.0 ou version ultérieure) et en tapant l'URL du Gestionnaire de rapports dans la barre d'adresse (par défaut, c'est http://< ComputerName >/Reports ). 
   
      {{% /alert %}}

1. Sélectionnez un rapport sur le serveur.
1. Ouvrez la liste **Sélectionner le format**.
   Vous devriez voir une liste de formats d'exportation fournis par Aspose.Slides pour Reporting Services. 
1. Sélectionnez **PPT – Présentation PowerPoint via Aspose.Slides**. 

   **Aspose.Slides pour Reporting Services installé avec succès et les nouveaux formats d'exportation sont disponibles.** 

![todo:image_alt_text](install-manually_1.png)




6. Cliquez sur le lien **Exporter**.
   Le rapport est généré dans le format choisi, envoyé au client, puis ouvert dans une application appropriée. Dans notre cas, le rapport a été ouvert dans Microsoft PowerPoint. 

   **Un rapport PPT généré par Aspose.Slides pour Reporting Services.** 

![todo:image_alt_text](install-manually_2.png)

Vous avez installé avec succès Aspose.Slides pour Reporting Services et généré un rapport au format présentation Microsoft PowerPoint ! 