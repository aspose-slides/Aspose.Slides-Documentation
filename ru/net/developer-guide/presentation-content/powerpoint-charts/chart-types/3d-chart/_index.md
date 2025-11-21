---
title: Настройка 3D диаграмм в презентациях на .NET
linktitle: 3D диаграмма
type: docs
url: /ru/net/3d-chart/
keywords:
- 3D диаграмма
- вращение
- глубина
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как создавать и настраивать 3-D диаграммы в Aspose.Slides для .NET с поддержкой файлов PPT и PPTX — улучшите свои презентации уже сегодня."
---

## **Установить свойства RotationX, RotationY и DepthPercents 3D‑диаграммы**
Aspose.Slides for .NET предоставляет простой API для установки этих свойств. В этой статье показано, как установить различные свойства, такие как вращение по X и Y, **DepthPercents** и т.д. Пример кода демонстрирует установку указанных выше свойств.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите доступ к первому слайду.
3. Добавьте диаграмму с данными по умолчанию.
4. Установите свойства Rotation3D.
5. Запишите изменённую презентацию в файл PPTX.
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

// Добавить серии
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

// Получить вторую серию диаграммы
IChartSeries series = chart.ChartData.Series[1];

// Сейчас заполняем данные серии
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

Да. Вы можете экспортировать диаграмму в изображение с помощью [chart API](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) или [render the entire slide](/slides/ru/net/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это удобно, когда требуется пиксельно‑точный предварительный просмотр или необходимо встроить диаграмму в документы, панели мониторинга или веб‑страницы без необходимости использовать PowerPoint.

**Насколько эффективно создаются и визуализируются большие 3D‑диаграммы?**

Производительность зависит от объёма данных и визуальной сложности. Для получения наилучших результатов сохраняйте 3D‑эффекты минимальными, избегайте тяжёлых текстур на стенах и областях графика, по возможности ограничивайте количество точек данных в серии и рендерите в выходной файл подходящего размера (разрешение и размеры), соответствующего целевому отображению или печати.