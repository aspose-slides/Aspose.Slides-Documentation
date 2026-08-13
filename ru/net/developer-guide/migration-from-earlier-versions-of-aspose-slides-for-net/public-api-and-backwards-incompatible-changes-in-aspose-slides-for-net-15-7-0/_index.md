---
title: Публичный API и несовместимые изменения в Aspose.Slides for .NET 15.7.0
linktitle: Aspose.Slides для .NET 15.7.0
type: docs
weight: 180
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- миграция
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и критических изменений в Aspose.Slides for .NET для плавной миграции ваших решений презентаций PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 

На этой странице перечислены все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) классы, методы, свойства и т.д., а также другие изменения, введённые в API Aspose.Slides for .NET 15.7.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Добавлен перечисление ImagePixelFormat**
Перечисление Aspose.Slides.Export.ImagePixelFormat было добавлено для указания формата пикселей для создаваемых изображений.
#### **Метод IChartDataPoint.GetAutomaticDataPointColor() добавлен**
Возвращает автоматический цвет точки данных, основанный на индексе серии, индексе точки данных, ParentSeriesGroup, свойстве IsColorVaried и стиле диаграммы.
Этот цвет используется по умолчанию, если FillType равен NotDefined.
#### **Метод RenderToGraphics добавлен в Slide**
Метод RenderToGraphics (и его перегрузки) был добавлен в Aspose.Slides.Slide для отрисовки слайда в объект Graphics.
#### **Свойство PixelFormat добавлено в ITiffOptions и TiffOptions**
Свойство PixelFormat было добавлено в Aspose.Slides.Export.ITiffOptions и Aspose.Slides.Export.TiffOptions для указания формата пикселей для создаваемых TIFF‑изображений.