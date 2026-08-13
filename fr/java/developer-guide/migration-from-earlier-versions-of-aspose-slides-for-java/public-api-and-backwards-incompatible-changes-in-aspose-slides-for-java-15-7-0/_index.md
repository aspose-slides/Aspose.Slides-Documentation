---
title: API publique et changements incompatibles rétroactifs dans Aspose.Slides pour Java 15.7.0
linktitle: Aspose.Slides pour Java 15.7.0
type: docs
weight: 150
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
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
description: "Passez en revue les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides pour Java afin de migrer en douceur vos solutions de présentations PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc. [ajoutées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) ou [supprimées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/), ainsi que les autres modifications introduites avec l'API Aspose.Slides for Java 15.7.0.

{{% /alert %}} 
## **Modifications de l'API publique**
#### **Enum com.aspose.slides.ImagePixelFormat a été ajouté**
Enum com.aspose.slides.ImagePixelFormat a été ajouté pour spécifier le format de pixel des images générées.
#### **com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() a été ajoutée**
Cette méthode renvoie une couleur automatique du point de données basée sur l'index de la série, l'index du point de données, parentSeriesGroup, les valeurs isColorVaried et le style du graphique. Cette couleur est utilisée par défaut si fillType est égal à NotDefined.
#### **Les méthodes getPixelFormat(), setPixelFormat(int) ont été ajoutées à com.aspose.slides.ITiffOptions**
Les méthodes getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) ont été ajoutées à com.aspose.slides.ITiffOptions et com.aspose.slides.TiffOptions pour spécifier le format de pixel des images TIFF générées.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```