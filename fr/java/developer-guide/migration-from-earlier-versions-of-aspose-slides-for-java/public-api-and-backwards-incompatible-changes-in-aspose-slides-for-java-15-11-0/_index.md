---
title: API Public et Changements Incompatibles avec les Versions Précédentes dans Aspose.Slides pour Java 15.11.0
type: docs
weight: 190
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les classes, méthodes, propriétés, etc., [ajoutées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) ou [supprimées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/), ainsi que d'autres changements introduits avec l'API Aspose.Slides pour Java 15.11.0.

{{% /alert %}} 
## **Changements de l'API Publique**
#### **Méthodes obsolètes dans la classe com.aspose.slides.DataLabelCollection ont été supprimées**
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
Lorsque une nouvelle valeur de numéro de première diapositive est spécifiée, tous les numéros de diapositive sont recalculés.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```