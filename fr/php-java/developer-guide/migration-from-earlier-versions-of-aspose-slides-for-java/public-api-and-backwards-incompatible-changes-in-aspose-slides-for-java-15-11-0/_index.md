---
title: API Public et Changements Incompatibles avec les Versions Précédentes dans Aspose.Slides pour PHP via Java 15.11.0
type: docs
weight: 190
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les [ajoutées](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) ou [supprimées](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) classes, méthodes, propriétés, etc., et d'autres changements introduits avec l'API Aspose.Slides pour PHP via Java 15.11.0.

{{% /alert %}} 
## **Modifications de l'API Publique**
#### **Les méthodes obsolètes dans la classe com.aspose.slides.DataLabelCollection ont été supprimées**
Les méthodes obsolètes dans la classe com.aspose.slides.DataLabelCollection ont été supprimées :

DataLabelCollection.getNumberFormat()
DataLabelCollection.setNumberFormat(String value)
DataLabelCollection.getLinkedSource()
DataLabelCollection.setLinkedSource(boolean value)
DataLabelCollection.getDelete()
DataLabelCollection.setDelete(boolean value)
DataLabelCollection.getFormat()
DataLabelCollection.setFormat(Format value)
DataLabelCollection.getPosition()
DataLabelCollection.setPosition(int value)
DataLabelCollection.getSeparator()
DataLabelCollection.setSeparator(String value)
DataLabelCollection.getShowLegendKey()
DataLabelCollection.setShowLegendKey(boolean value)
DataLabelCollection.getShowLeaderLines()
DataLabelCollection.setShowLeaderLines(boolean value)
DataLabelCollection.getShowCategoryName()
DataLabelCollection.setShowCategoryName(boolean value)
DataLabelCollection.getShowValue()
DataLabelCollection.setShowValue(boolean value)
DataLabelCollection.getShowPercentage()
DataLabelCollection.setShowPercentage(boolean value)
DataLabelCollection.getShowSeriesName()
DataLabelCollection.setShowSeriesName(boolean value)
DataLabelCollection.getShowBubbleSize()
DataLabelCollection.setShowBubbleSize(boolean value)


#### **De nouvelles méthodes getFirstSlideNumber() et setFirstSlideNumber() ont été ajoutées à la classe Presentation**
Les nouvelles méthodes getFirstSlideNumber() et setFirstSlideNumber() permettent d'obtenir ou de définir le numéro de la première diapositive dans une présentation.
Lorsqu'une nouvelle valeur de numéro de première diapositive est spécifiée, tous les numéros de diapositives sont recalculés.

```php
  $pres = new Presentation($path);
  $firstSlideNumber = $pres->getFirstSlideNumber();
  $pres->setFirstSlideNumber(10);
  $pres->save($newPath, SaveFormat::Pptx);

```