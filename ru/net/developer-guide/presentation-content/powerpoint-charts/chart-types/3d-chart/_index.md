---
title: Настройка 3D графиков в презентациях на .NET
linktitle: 3D график
type: docs
url: /ru/net/3d-chart/
keywords:
- 3D график
- вращение
- глубина
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как создавать и настраивать 3-D графики в Aspose.Slides для .NET с поддержкой файлов PPT и PPTX - улучшите ваши презентации уже сегодня."
---

## **Установить свойства RotationX, RotationY и DepthPercents трехмерного графика**
Aspose.Slides for .NET предоставляет простой API для установки этих свойств. В этой статье показано, как задавать различные свойства, такие как вращение по X и Y, **DepthPercents** и т.д. Пример кода демонстрирует установку указанных выше свойств.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получить первый слайд.
1. Добавить график с данными по умолчанию.
1. Установить свойства Rotation3D.
1. Записать изменённую презентацию в файл PPTX.
```c#
// Создать экземпляр класса Presentation
Presentation presentation = new Presentation();
           
// Получить первый слайд
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

// Получить вторую серию диаграммы
IChartSeries series = chart.ChartData.Series[1];

// Заполняем данные серии
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Установить значение Overlap
series.ParentSeriesGroup.Overlap = 100;         

// Сохранить презентацию на диск
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Какие типы графиков поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых графиков, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100% Stacked Column 3D, а также связанные 3D‑типы, доступные через перечисление [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Для актуального полного списка проверяйте члены [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) в справочнике API установленной версии.

**Можно ли получить растровое изображение 3D‑графика для отчёта или веба?**

Да. Вы можете экспортировать график в изображение с помощью [chart API](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) или [render the entire slide](/slides/ru/net/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это удобно, когда нужен пиксельный предварительный просмотр или требуется внедрить график в документы, панели мониторинга или веб‑страницы без необходимости PowerPoint.

**Насколько эффективна сборка и рендеринг больших 3D‑графиков?**

Производительность зависит от объёма данных и визуальной сложности. Для достижения лучших результатов минимизируйте 3D‑эффекты, избегайте тяжёлых текстур на стенах и областях построения, по возможности ограничьте количество точек данных в серии и рендерите в подходящем разрешении и размерах, соответствующих целевому отображению или печати.