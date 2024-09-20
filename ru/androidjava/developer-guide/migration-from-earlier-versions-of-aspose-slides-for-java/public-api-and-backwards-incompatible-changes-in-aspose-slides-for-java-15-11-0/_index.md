---
title: Публичный API и несовместимые изменения в Aspose.Slides для Java 15.11.0
type: docs
weight: 190
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) или [удаленных](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) классов, методов, свойств и так далее, а также других изменений, внесенных в API Aspose.Slides для Java 15.11.0.

{{% /alert %}} 
## **Изменения в публичном API**
#### **Устаревшие методы в классе com.aspose.slides.DataLabelCollection были удалены**
Устаревшие методы в классе com.aspose.slides.DataLabelCollection были удалены:

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


#### **Новые методы getFirstSlideNumber() и setFirstSlideNumber() были добавлены в класс Presentation**
Новые методы getFirstSlideNumber() и setFirstSlideNumber() позволяют получить или установить номер первого слайда в презентации. Когда указывается новое значение номера первого слайда, все номера слайдов пересчитываются.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```