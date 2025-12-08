---
title: 3D диаграмма
type: docs
url: /ru/net/3d-chart/
keywords: "3d диаграмма, rotationX, rotationY, depthpercent, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Установить rotationX, rotationY и depthpercents для 3D диаграммы в презентации PowerPoint на C# или .NET"
---

## **Установить свойства RotationX, RotationY и DepthPercents 3D‑диаграммы**
Aspose.Slides for .NET предоставляет простой API для установки этих свойств. Эта статья поможет вам установить различные свойства, такие как вращение X, Y, **DepthPercents** и т.д. Пример кода демонстрирует установку указанных выше свойств.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите доступ к первому слайду.
1. Добавьте диаграмму с данными по умолчанию.
1. Установите свойства Rotation3D.
1. Запишите изменённую презентацию в файл PPTX.
```c#
// Создать экземпляр класса Presentation
Presentation presentation = new Presentation();
           
// Получить доступ к первому слайду
ISlide slide = presentation.Slides[0];

// Добавить диаграмму с данными по умолчанию
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Установка индекса листа данных диаграммы
int defaultWorksheetIndex = 0;

// Получение листа данных диаграммы
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Добавить серию
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Добавить категории
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Установить свойства Rotation3D
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Выбрать вторую серию диаграммы
IChartSeries series = chart.ChartData.Series[1];

// Теперь заполняем данные серии
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Установить значение OverLap
series.ParentSeriesGroup.Overlap = 100;         

// Сохранить презентацию на диск
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100% Stacked Column 3D, а также связанные 3D‑типы, доступные через перечисление [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Для точного и актуального списка проверьте члены [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) в справочнике API установленной версии.

**Можно ли получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение с помощью [chart API](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) или [render the entire slide](/slides/ru/net/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это полезно, когда требуется точный предварительный просмотр или нужно встроить диаграмму в документы, информационные панели или веб‑страницы без необходимости использовать PowerPoint.

**Насколько эффективно создавать и рендерить большие 3D‑диаграммы?**

Производительность зависит от объёма данных и визуальной сложности. Для достижения наилучших результатов минимизируйте 3D‑эффекты, избегайте тяжёлых текстур на стенах и областях построения, по возможности ограничьте количество точек данных в серии и рендерьте в выходной файл соответствующего размера (разрешения и размеров), чтобы соответствовать требованиям целевого отображения или печати.