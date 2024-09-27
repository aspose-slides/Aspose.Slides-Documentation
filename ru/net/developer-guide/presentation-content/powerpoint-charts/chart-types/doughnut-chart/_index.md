---
title: Донатная диаграмма
type: docs
weight: 30
url: /ru/net/doughnut-chart/
keywords: "Донатная диаграмма, центральный зазор, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Укажите центральный зазор в донатной диаграмме в презентации PowerPoint на C# или .NET"
---

## **Указать центральный зазор в донатной диаграмме**
Чтобы указать размер отверстия в донатной диаграмме, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Добавьте донатную диаграмму на слайд.
- Укажите размер отверстия в донатной диаграмме.
- Сохраните презентацию на диск.

В приведённом ниже примере мы задали размер отверстия в донатной диаграмме.

```c#
// Создайте экземпляр класса Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Сохраните презентацию на диск
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```