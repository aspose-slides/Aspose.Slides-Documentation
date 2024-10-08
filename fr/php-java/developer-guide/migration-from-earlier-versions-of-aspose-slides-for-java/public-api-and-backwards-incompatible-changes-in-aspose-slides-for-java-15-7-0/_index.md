---
title: API Public et Changements Incompatibles avec les Versions Précédentes dans Aspose.Slides pour PHP via Java 15.7.0
type: docs
weight: 150
url: /fr/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc., [ajoutées](/slides/fr/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) ou [supprimées](/slides/fr/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/), ainsi que d'autres changements introduits avec l'API Aspose.Slides pour PHP via Java 15.7.0.

{{% /alert %}} 
## **Changements de l'API Publique**
#### **Enum com.aspose.slides.ImagePixelFormat ajouté**
L'énumération com.aspose.slides.ImagePixelFormat a été ajoutée pour spécifier le format des pixels pour les images générées.
#### **La méthode com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() a été ajoutée**
Cette méthode retourne une couleur automatique du point de données basée sur l'indice de la série, l'indice du point de données, le groupeSérieParent, les valeurs isColorVaried et le style de graphique. Cette couleur est utilisée par défaut si le fillType est égal à NotDefined.
#### **Les méthodes getPixelFormat(), setPixelFormat(int) ont été ajoutées à com.aspose.slides.ITiffOptions**
Les méthodes getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) ont été ajoutées à com.aspose.slides.ITiffOptions et com.aspose.slides.TiffOptions pour spécifier le format des pixels pour les images TIFF générées.

```php
  $pres = new Presentation("demo.pptx");
  $options = new TiffOptions();
  $options->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
  $pres->save("demo-out.tiff", SaveFormat::Tiff, $options);

```