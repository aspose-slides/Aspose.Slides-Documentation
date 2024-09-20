---
title: Публичный API и изменения, несовместимые с предыдущими версиями, в Aspose.Slides для PHP через Java 15.11.0
type: docs
weight: 190
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) или [удаленные](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) классы, методы, свойства и так далее, а также другие изменения, внедренные в API Aspose.Slides для PHP через Java 15.11.0.

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


#### **Добавлены новые методы getFirstSlideNumber() и setFirstSlideNumber() в класс Presentation**
Новые методы getFirstSlideNumber() и setFirstSlideNumber() позволяют получить или установить номер первого слайда в презентации.
При указании нового значения номера первого слайда все номера слайдов пересчитываются.

```php
  $pres = new Presentation($path);
  $firstSlideNumber = $pres->getFirstSlideNumber();
  $pres->setFirstSlideNumber(10);
  $pres->save($newPath, SaveFormat::Pptx);
```