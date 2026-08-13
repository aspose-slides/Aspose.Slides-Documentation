---
title: Публичный API и несовместимые изменения в Aspose.Slides для Java 15.11.0
linktitle: Aspose.Slides для Java 15.11.0
type: docs
weight: 190
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- миграция
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Обзор обновлений публичного API и критических изменений в Aspose.Slides для Java, чтобы плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 

На этой странице перечислены все [added](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) или [removed](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) классы, методы, свойства и т.д., а также другие изменения, внесённые в API Aspose.Slides for Java 15.11.0.

{{% /alert %}} 
## **Изменения публичного API**
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
Новые методы getFirstSlideNumber() и setFirstSlideNumber() позволяют получить или установить номер первого слайда в презентации. При указании нового значения номера первого слайда нумерация всех слайдов пересчитывается.

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    int firstSlideNumber = pres.getFirstSlideNumber();

    pres.setFirstSlideNumber(10);

    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```