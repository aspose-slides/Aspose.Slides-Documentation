---
title: Параметры маркеров данных диаграммы
type: docs
url: /net/chart-data-marker/
keywords: "Опции маркеров диаграммы, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Установите параметры маркеров диаграммы в презентациях PowerPoint на C# или .NET"
---

## **Настройка параметров маркеров диаграммы**
Маркеры могут быть установлены на точки данных диаграммы внутри конкретных рядов. Чтобы установить параметры маркеров диаграммы, следуйте приведенным ниже шагам:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Создайте стандартную диаграмму.
- Установите изображение.
- Получите первый ряд диаграммы.
- Добавьте новую точку данных.
- Сохраните презентацию на диск.

В приведенном ниже примере мы установили параметры маркеров диаграммы на уровне точек данных.

```c#
// Создайте экземпляр класса Presentation
Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Создание стандартной диаграммы
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Получаем индекс рабочего листа данных диаграммы
int defaultWorksheetIndex = 0;

// Получаем рабочий лист данных диаграммы
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Удаляем демонстрационные ряды
chart.ChartData.Series.Clear();

// Добавляем новые ряды
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Ряд 1"), chart.Type);
            
// Установите изображение
System.Drawing.Image image1 = (System.Drawing.Image)new Bitmap("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Установите изображение
System.Drawing.Image image2 = (System.Drawing.Image)new Bitmap("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Получите первый ряд диаграммы
IChartSeries series = chart.ChartData.Series[0];

// Добавляем новую точку (1:3) туда.
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

// Изменение маркера ряда диаграммы
series.Marker.Size = 15;

// Сохраняем презентацию на диск
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```