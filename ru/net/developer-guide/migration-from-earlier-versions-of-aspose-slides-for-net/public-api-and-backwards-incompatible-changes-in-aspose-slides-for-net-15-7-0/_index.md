---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 15.7.0
linktitle: Aspose.Slides для .NET 15.7.0
type: docs
weight: 180
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- миграция
- наследуемый код
- современный код
- наследуемый подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для .NET, позволяющий плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 
Эта страница перечисляет все [added](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) или [removed](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) классы, методы, свойства и т.д., а также другие изменения, внесённые в API Aspose.Slides for .NET 15.7.0.
{{% /alert %}} 
## **Изменения публичного API**
#### **Добавлен enum ImagePixelFormat**
Enum Aspose.Slides.Export.ImagePixelFormat добавлен для указания формата пикселей генерируемых изображений.
#### **Метод IChartDataPoint.GetAutomaticDataPointColor() добавлен**
Возвращает автоматический цвет точки данных, основанный на индексе серии, индексе точки данных, ParentSeriesGroup, свойстве IsColorVaried и стиле диаграммы.
Этот цвет используется по умолчанию, если FillType равен NotDefined.
#### **Метод RenderToGraphics добавлен в Slide**
Метод RenderToGraphics (и его перегрузки) добавлен в Aspose.Slides.Slide для отрисовки слайда в объект Graphics.
#### **Свойство PixelFormat добавлено в ITiffOptions и TiffOptions**
Свойство PixelFormat добавлено в Aspose.Slides.Export.ITiffOptions и Aspose.Slides.Export.TiffOptions для указания формата пикселей генерируемых TIFF‑изображений.