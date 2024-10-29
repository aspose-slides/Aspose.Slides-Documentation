---
title: API publique et changements incompatibles avec les versions précédentes dans Aspose.Slides pour Java 15.7.0
type: docs
weight: 150
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les classes, méthodes, propriétés, etc. [ajoutées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) ou [supprimées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/), ainsi que d'autres changements introduits avec l'API Aspose.Slides pour Java 15.7.0.

{{% /alert %}} 
## **Changements de l'API publique**
#### **L'énumération com.aspose.slides.ImagePixelFormat a été ajoutée**
L'énumération com.aspose.slides.ImagePixelFormat a été ajoutée pour spécifier le format de pixel pour les images générées.
#### **La méthode com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() a été ajoutée**
Cette méthode renvoie une couleur automatique du point de données en fonction de l'index de la série, de l'index du point de données, du parentSeriesGroup, des valeurs isColorVaried et du style du graphique. Cette couleur est utilisée par défaut si fillType est égal à NotDefined.
#### **Les méthodes getPixelFormat(), setPixelFormat(int) ont été ajoutées à com.aspose.slides.ITiffOptions**
Les méthodes getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) ont été ajoutées à com.aspose.slides.ITiffOptions et com.aspose.slides.TiffOptions pour spécifier le format de pixel pour les images TIFF générées.

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```