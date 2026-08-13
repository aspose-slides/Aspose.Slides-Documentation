---
title: API publique et modifications incompatibles avec les versions antérieures d'Aspose.Slides for Java 14.8.0
linktitle: Aspose.Slides pour Java 14.8.0
type: docs
weight: 70
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Examinez les mises à jour de l'API publique et les changements majeurs d'Aspose.Slides for Java afin de migrer en douceur vos solutions de présentations PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 

Cette page répertorie toutes les [ajoutées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) classes, méthodes, propriétés, etc., ainsi que toutes les nouvelles restrictions et autres [modifications](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) introduites avec l'API Aspose.Slides for Java 14.8.0.

{{% /alert %}} 
## **Modifications de l'API publique**
### **Ajout des méthodes Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() et setOverlap(byte)**
La méthode Aspose.Slides.Charts.IChartSeries.getOverlap() indique le degré de chevauchement des barres et colonnes sur les graphiques 2D (dans une plage de -100 à 100).  
Cette méthode ne concerne pas seulement une série spécifique mais toutes les séries du groupe de séries parent – il s'agit d'une projection de la propriété de groupe appropriée.

- Utilisez la méthode IChartSeries.getParentSeriesGroup() pour accéder au groupe de séries parent.  
- Utilisez les méthodes IChartSeriesGroup.getOverlap() et setOverlap(byte) pour gérer la valeur.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **Ajout de la valeur d'énumération ShapeThumbnailBounds.Appearance**
Cette méthode de création de vignettes de forme permet aux développeurs de générer une vignette de forme dans les limites de son apparence. Elle tient compte de tous les effets de forme. La vignette de forme générée est limitée par les limites de la diapositive.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Ajout des classes VbaProject et IVbaProject, modification des méthodes Presentation.getVbaProject() et setVbaProject(VbaProject)**
Une nouvelle fonctionnalité permet aux développeurs de créer et modifier des projets VBA dans une présentation.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// Créer un nouveau projet VBA

pres.setVbaProject(new VbaProject());

// Ajouter un module vide au projet VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Définir le code source du module

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Créer une référence à <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Créer une référence à Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Ajouter des références au projet VBA

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);
```