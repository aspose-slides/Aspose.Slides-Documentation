---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 15.7.0
type: docs
weight: 180
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) или [удаленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) классы, методы, свойства и так далее, а также другие изменения, внесенные в API Aspose.Slides для .NET 15.7.0.

{{% /alert %}} 
## **Изменения в публичном API**
#### **Добавлен перечислимый тип ImagePixelFormat**
Добавлен перечисляемый тип Aspose.Slides.Export.ImagePixelFormat для указания формата пикселей для создаваемых изображений.
#### **Добавлен метод IChartDataPoint.GetAutomaticDataPointColor()**
Возвращает автоматический цвет точки данных на основе индекса серии, индекса точки данных, ParentSeriesGroup, свойства IsColorVaried и стиля диаграммы. 
Этот цвет используется по умолчанию, если FillType равен NotDefined.
#### **Метод RenderToGraphics добавлен в Slide**
Метод RenderToGraphics (и его перегрузки) был добавлен в Aspose.Slides.Slide для отрисовки слайда на объекте Graphics.
#### **Свойство PixelFormat добавлено в ITiffOptions и TiffOptions**
Свойство PixelFormat было добавлено в Aspose.Slides.Export.ITiffOptions и Aspose.Slides.Export.TiffOptions для указания формата пикселей для создаваемых изображений TIFF.