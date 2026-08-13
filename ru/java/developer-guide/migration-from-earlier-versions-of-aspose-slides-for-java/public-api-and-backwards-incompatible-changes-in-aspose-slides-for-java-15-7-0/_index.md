---
title: Публичный API и обратные несовместимые изменения в Aspose.Slides for Java 15.7.0
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- миграция
- наследуемый код
- современный код
- наследуемый подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Обзор обновлений публичного API и критических изменений в Aspose.Slides for Java для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 
Эта страница перечисляет все [добавленные](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) или [удалённые](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) классы, методы, свойства и т.д., а также другие изменения, внесённые в API Aspose.Slides for Java 15.7.0.
{{% /alert %}} 
## **Изменения публичного API**
#### **Перечисление com.aspose.slides.ImagePixelFormat добавлено**
Перечисление com.aspose.slides.ImagePixelFormat было добавлено для указания формата пикселей для генерируемых изображений.
#### **Метод com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() добавлен**
Этот метод возвращает автоматический цвет точки данных на основе индекса серии, индекса точки данных, parentSeriesGroup, значений isColorVaried и стиля диаграммы. Этот цвет используется по умолчанию, если fillType равно NotDefined.
#### **Методы getPixelFormat(), setPixelFormat(int) добавлены в com.aspose.slides.ITiffOptions**
Методы getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) были добавлены в com.aspose.slides.ITiffOptions и com.aspose.slides.TiffOptions для указания формата пикселей для генерируемых TIFF‑изображений.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```