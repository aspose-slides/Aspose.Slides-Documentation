---
title: Кольцевая диаграмма
type: docs
weight: 30
url: /ru/net/doughnut-chart/
keywords: "Кольцевая диаграмма, центральный промежуток, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Указание центрального промежутка в кольцевой диаграмме в презентации PowerPoint на C# или .NET"
---

## **Указание центрального промежутка в кольцевой диаграмме**
Чтобы задать размер отверстия в кольцевой диаграмме, выполните следующие шаги:

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

**Могу ли я создать многоуровневую кольцевую диаграмму с несколькими кольцами?**

Да. Добавьте несколько последовательностей в одну кольцевую диаграмму — каждая последовательность станет отдельным кольцом. Порядок колец определяется порядком последовательностей в коллекции.

**Поддерживается ли "взрывная" кольцевая диаграмма (отделённые сегменты)?**

Да. Существует тип диаграммы Exploded Doughnut [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) и свойство взрыва для точек данных; вы можете отделять отдельные сегменты.

**Как получить изображение кольцевой диаграммы (PNG/SVG) для отчёта?**

Диаграмма является фигурой; её можно отрисовать в [raster image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) или экспортировать в [SVG image](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).