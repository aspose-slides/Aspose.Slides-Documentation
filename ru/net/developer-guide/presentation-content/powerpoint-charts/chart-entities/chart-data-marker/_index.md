---
title: Управление маркерами данных диаграммы в презентациях на .NET
linktitle: Маркер данных
type: docs
url: /ru/net/chart-data-marker/
keywords:
- диаграмма
- точка данных
- маркер
- параметры маркера
- размер маркера
- тип заливки
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как настраивать маркеры данных диаграмм в Aspose.Slides для .NET, повышая эффективность презентаций в форматах PPT и PPTX с помощью понятных примеров кода на C#."
---

## **Установить параметры маркеров диаграммы**
Маркеры можно задавать для точек данных диаграммы в отдельных сериях. Чтобы установить параметры маркеров диаграммы, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Создайте диаграмму по умолчанию.
- Установите изображение.
- Получите первую серию диаграммы.
- Добавьте новую точку данных.
- Запишите презентацию на диск.

В приведённом ниже примере мы задали параметры маркеров диаграммы на уровне точек данных.
```c#
// Создайте экземпляр класса Presentation
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Получение индекса листа данных диаграммы по умолчанию
int defaultWorksheetIndex = 0;

// Получение листа данных диаграммы
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Удалить демонстрационную серию
chart.ChartData.Series.Clear();

// Добавить новую серию
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Установить изображение
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Установить изображение
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Получить первую серию диаграммы
IChartSeries series = chart.ChartData.Series[0];

// Добавить новую точку (1:3) туда.
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

// Изменение маркера серии диаграммы
series.Marker.Size = 15;

// Сохранить презентацию на диск
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Какие формы маркеров доступны из коробки?**

Доступны стандартные формы (круг, квадрат, ромб, треугольник и т.д.); список определён в перечислении [MarkerStyleType](https://reference.aspose.com/slides/net/aspose.slides.charts/markerstyletype/). Если вам нужна нестандартная форма, используйте маркер с заливкой изображением, чтобы имитировать пользовательские визуальные элементы.

**Сохраняются ли маркеры при экспорте диаграммы в изображение или SVG?**

Да. При рендеринге диаграмм в [raster formats](/slides/ru/net/convert-powerpoint-to-png/) или сохранении [shapes as SVG](/slides/ru/net/render-a-slide-as-an-svg-image/), маркеры сохраняют свой внешний вид и настройки, включая размер, заливку и контур.