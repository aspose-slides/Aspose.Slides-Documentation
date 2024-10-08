---
title: Personnaliser la légende de l'extension de rendu PowerPoint
type: docs
weight: 60
url: /fr/reportingservices/customizing-powerpoint-rendering-extension-caption/
---

{{% alert color="primary" %}} 

Cet article vous montre comment personnaliser les légendes des options de rendu d'Aspose.Slides pour Reporting Services.

{{% /alert %}} 
## **Exemple**
Lors de l'installation d'Aspose.Slides pour Reporting Services, 4 options d'exportation supplémentaires sont ajoutées dans le menu déroulant des options d'exportation :

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **Comment modifier le texte des légendes**
Les légendes par défaut de ces extensions peuvent être changées en remplaçant les noms par défaut. Ces étapes vous montrent comment changer la légende de “ **PPT – Présentation PowerPoint** **via** **Aspose.Slides** ” à “ **Format PowerPoint 97 – 2003 (PPT)** ”. 

**Étape 1 :** Localisez le fichier **rsreportserver.config** qui se trouve généralement dans ce répertoire : 

**Disque Racine OS\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Étape 2 :** Trouvez ces lignes dans le fichier rsreportserver.config : 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

``` 

**Étape 3 :** Remplacez le paramètre d'extension par ceci : 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">Format PowerPoint 97 - 2003 (PPT)</Name>

        </OverrideNames>

</Extension>

``` 

Les options d'exportation apparaîtront maintenant comme ceci : 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)