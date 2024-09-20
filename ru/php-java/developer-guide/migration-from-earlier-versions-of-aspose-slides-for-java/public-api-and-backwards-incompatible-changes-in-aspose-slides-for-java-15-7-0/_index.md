---
title: Публичный API и изменения, несовместимые с предыдущими версиями в Aspose.Slides для PHP через Java 15.7.0
type: docs
weight: 150
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) или [удалённых](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) классов, методов, свойств и так далее, а также других изменений, внедрённых в API Aspose.Slides для PHP через Java 15.7.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Добавлен enum com.aspose.slides.ImagePixelFormat**
Добавлен enum com.aspose.slides.ImagePixelFormat для задания формата пикселей для сгенерированных изображений.
#### **Добавлен метод com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor()**
Этот метод возвращает автоматический цвет точки данных, основываясь на индексе серии, индексе точки данных, родительской группе серий, значениях isColorVaried и стиле диаграммы. Этот цвет используется по умолчанию, если fillType равен NotDefined.
#### **Методы getPixelFormat(), setPixelFormat(int) добавлены в com.aspose.slides.ITiffOptions**
Методы getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) были добавлены в com.aspose.slides.ITiffOptions и com.aspose.slides.TiffOptions для задания формата пикселей для сгенерированных TIFF-изображений.

```php
  $pres = new Presentation("demo.pptx");
  $options = new TiffOptions();
  $options->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
  $pres->save("demo-out.tiff", SaveFormat::Tiff, $options);
```
