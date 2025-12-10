---
title: Настройка кольцевых диаграмм в презентациях на .NET
linktitle: Кольцевая диаграмма
type: docs
weight: 30
url: /ru/net/doughnut-chart/
keywords:
- кольцевая диаграмма
- центральный зазор
- размер отверстия
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как создавать и настраивать кольцевые диаграммы в Aspose.Slides для .NET, поддерживая форматы PowerPoint для динамических презентаций."
---

## **Specify the Center Gap in a Doughnut Chart**
Для указания размера отверстия в кольцевой диаграмме выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Добавьте кольцевую диаграмму на слайд.
- Укажите размер отверстия в кольцевой диаграмме.
- Сохраните презентацию на диск.

В приведённом ниже примере мы задали размер отверстия в кольцевой диаграмме.
```c#
// Создать экземпляр класса Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Сохранить презентацию на диск
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Can I create a multi-level doughnut with multiple rings?**

Могу ли я создать многоуровневую кольцевую диаграмму с несколькими кольцами?

Да. Добавьте несколько рядов в одну кольцевую диаграмму — каждый ряд становится отдельным кольцом. Порядок колец определяется порядком рядов в коллекции.

**Is an "exploded" doughnut (separated slices) supported?**

Поддерживается ли «взрывная» кольцевая диаграмма (разделённые сегменты)?

Да. Существует тип диаграммы Exploded Doughnut [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) и свойство взрыва для точек данных; вы можете отделять отдельные сегменты.

**How can I get an image of a doughnut chart (PNG/SVG) for a report?**

Как получить изображение кольцевой диаграммы (PNG/SVG) для отчёта?

Диаграмма является фигурой; её можно отрисовать в [raster image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) или экспортировать диаграмму в [SVG image](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).