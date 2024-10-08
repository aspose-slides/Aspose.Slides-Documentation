---
title: Intégration manuelle avec le concepteur de rapports Visual Studio 2005 ou 2008
type: docs
weight: 50
url: /fr/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---

{{% alert color="primary" %}} 

Cet article vous apprend à intégrer Aspose.Slides pour Reporting Services manuellement avec Visual Studio. 

{{% /alert %}} 

{{% alert title="Remarque" color="warning" %}} 

**Aspose.Slides pour Reporting Services** nécessite l'installation de **.NET Framework 3.5** sur la machine hôte. 

{{% /alert %}}

## **Intégration d'Aspose.Slides pour Reporting Services avec Visual Studio**
Nous vous recommandons d'utiliser l'installateur MSI pour installer Aspose.Slides pour Reporting Services car il exécute toutes les tâches d'installation et les processus de configuration nécessaires automatiquement. Cependant, si l'installation avec l'installateur MSI échoue, utilisez le guide ici. 

Cet article vous montre également comment installer Aspose.Slides pour Reporting Services sur un ordinateur avec Business Intelligence Development Studio. Cela vous permettra d'exporter des rapports vers des formats Microsoft PowerPoint au moment de la conception depuis le concepteur de rapports Microsoft Visual Studio 2005 ou 2008. 

1. Copiez Aspose.Slides.ReportingServices.dll dans le répertoire de Visual Studio.

   - Pour intégrer avec le concepteur de rapports Visual Studio 2005, copiez **Aspose.Slides.ReportingServices.dll** dans le répertoire **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies**.
   - Pour intégrer avec le concepteur de rapports Visual Studio 2008, copiez **Aspose.Slides.ReportingServices.dll** dans le répertoire **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies**.
2. Enregistrez Aspose.Slides pour Reporting Services en tant qu'extension de rendu. 

3. Ouvrez **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config** (où <Version> est “8” pour Visual Studio 2005 ou “9.0” pour Visual Studio 2008) et ajoutez ces lignes dans l'élément <Render>: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. Donnez à Aspose.Slides pour Reporting Services les permissions d'exécution. 
   1. Ouvrez **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** (où <Version> est “8” pour Visual Studio 2005 ou “9.0” pour Visual Studio 2008).
   1. Ajoutez cette ligne en tant que dernier élément dans le deuxième élément <CodeGroup> extérieur (qui devrait être <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="Ce groupe de code accorde une permission d'exécution au code MyComputer.">) 

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

5. Vérifiez qu'Aspose.Slides pour Reporting Services a été installé avec succès. 
6. Exécutez ou redémarrez le concepteur de rapports Microsoft Visual Studio 2005 ou 2008. Vous devriez remarquer de nouveaux formats dans la liste des formats d'exportation.

**De nouveaux formats d'exportation apparaissent dans le concepteur de rapports.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)