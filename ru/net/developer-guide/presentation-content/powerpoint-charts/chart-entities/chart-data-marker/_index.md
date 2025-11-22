---
title: Маркер данных диаграммы
type: docs
url: /ru/net/chart-data-marker/
keywords:
- параметры маркеров диаграммы
- PowerPoint
- презентация
- C#
- Csharp
- Aspose.Slides for .NET
description: "Установите параметры маркеров диаграммы в презентациях PowerPoint на C# или .NET"
---

## **Настройка параметров маркеров диаграммы**
Маркеры можно установить на точках данных диаграммы в конкретных сериях. Чтобы настроить параметры маркеров диаграммы, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Создайте диаграмму по умолчанию.
- Установите изображение.
- Получите первую серию диаграммы.
- Добавьте новую точку данных.
- Сохраните презентацию на диск.

В приведенном ниже примере мы настроили параметры маркеров диаграммы на уровне точек данных.
```c#
// Создать экземпляр класса Presentation
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Creating the default chart
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Getting the default chart data worksheet index
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Delete demo series
chart.ChartData.Series.Clear();

// Add new series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Set the picture
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Set the picture
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Take first chart series
IChartSeries series = chart.ChartData.Series[0];

// Add new point (1:3) there.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// Changing the chart series marker
series.Marker.Size = 15;

// Write presentation to disk
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Какие формы маркеров доступны из коробки?**

Доступны стандартные формы (круг, квадрат, ромб, треугольник и т.д.); список определяется перечислением [MarkerStyleType](https://reference.aspose.com/slides/net/aspose.slides.charts/markerstyletype/). Если нужна нестандартная форма, используйте маркер с заполнением изображением, чтобы имитировать пользовательскую визуализацию.

**Сохраняются ли маркеры при экспорте диаграммы в изображение или SVG?**

Да. При рендеринге диаграмм в [растровые форматы](/slides/ru/net/convert-powerpoint-to-png/) или сохранении [форм в SVG](/slides/ru/net/render-a-slide-as-an-svg-image/), маркеры сохраняют свой внешний вид и настройки, включая размер, заливку и контур.