---
title: Публичный API и несовместимые изменения в Aspose.Slides для Java 15.7.0
type: docs
weight: 150
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) или [удаленные](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) классы, методы, свойства и другие изменения, введенные в API Aspose.Slides для Java 15.7.0.

{{% /alert %}} 
## **Изменения в публичном API**
#### **Добавлен Enum com.aspose.slides.ImagePixelFormat**
Добавлен Enum com.aspose.slides.ImagePixelFormat для указания формата пикселей для создаваемых изображений.
#### **Добавлен метод com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor()**
Этот метод возвращает автоматический цвет точки данных в зависимости от индекса серии, индекса точки данных, родительской группы серий, значений isColorVaried и стиля графика. Этот цвет используется по умолчанию, если fillType равен NotDefined.
#### **Методы getPixelFormat(), setPixelFormat(int) добавлены в com.aspose.slides.ITiffOptions**
Методы getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) добавлены в com.aspose.slides.ITiffOptions и com.aspose.slides.TiffOptions для указания формата пикселей для создаваемых TIFF изображений.

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```