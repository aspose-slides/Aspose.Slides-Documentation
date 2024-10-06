---
title: API public et modifications incompatibles avec les versions précédentes dans Aspose.Slides pour Java 14.8.0
type: docs
weight: 70
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les [ajouts](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) de classes, méthodes, propriétés, etc., ainsi que toute nouvelle restriction et d'autres [changements](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) introduits avec l'API Aspose.Slides pour Java 14.8.0.

{{% /alert %}} 
## **Changements de l'API publique**
### **Ajout des méthodes Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap(), et setOverlap(byte)**
La méthode Aspose.Slides.Charts.IChartSeries.getOverlap() obtient la mesure de chevauchement des barres et colonnes sur des graphiques 2D (dans une plage de -100 à 100).
Cette méthode ne concerne pas seulement des séries spécifiques mais toutes les séries du groupe de séries parent - il s'agit de la projection de la propriété du groupe approprié.

- Utilisez la méthode IChartSeries.getParentSeriesGroup() pour accéder au groupe de séries parent.
- Utilisez les méthodes IChartSeriesGroup.getOverlap() et setOverlap(byte) pour gérer la valeur.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **Ajout de la valeur de l'énumération ShapeThumbnailBounds.Appearance**
Cette méthode de création de vignettes de formes permet aux développeurs de générer une vignette de forme dans les limites de son apparence. Elle prend en compte tous les effets de forme. La vignette générée est limitée par les limites de la diapositive.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Ajout de la classe VbaProject et de l'interface IVbaProject, modification des méthodes Presentation.getVbaProject() et setVbaProject(VbaProject)**
Une nouvelle fonctionnalité permet aux développeurs de créer et d'éditer des projets VBA dans une présentation.

``` java

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

pres.save("data\\test.pptm", SaveFormat.Pptm);

```