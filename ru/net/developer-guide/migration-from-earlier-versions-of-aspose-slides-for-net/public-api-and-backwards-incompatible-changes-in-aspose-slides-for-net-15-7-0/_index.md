---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 15.7.0
linktitle: Aspose.Slides для .NET 15.7.0
type: docs
weight: 180
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- миграция
- унаследованный код
- современный код
- унаследованный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides для .NET, чтобы плавно мигрировать решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) классы, методы, свойства и т.д., а также другие изменения, введённые в API Aspose.Slides for .NET 15.7.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Enum ImagePixelFormat добавлен**
Enum Aspose.Slides.Export.ImagePixelFormat добавлен для указания пиксельного формата генерируемых изображений.
#### **Метод IChartDataPoint.GetAutomaticDataPointColor() добавлен**
Возвращает автоматический цвет точки данных на основе индекса серии, индекса точки данных, ParentSeriesGroup, свойства IsColorVaried и стиля диаграммы.  
Этот цвет используется по умолчанию, если FillType равно NotDefined.
#### **Метод RenderToGraphics добавлен в Slide**
Метод RenderToGraphics (и его перегрузки) добавлен в Aspose.Slides.Slide для отрисовки слайда в объект Graphics.
#### **Свойство PixelFormat добавлено в ITiffOptions и TiffOptions**
Свойство PixelFormat добавлено в Aspose.Slides.Export.ITiffOptions и Aspose.Slides.Export.TiffOptions для указания пиксельного формата генерируемых TIFF‑изображений.