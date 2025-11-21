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

## **Укажите центральный зазор в кольцевой диаграмме**
Чтобы задать размер отверстия в кольцевой диаграмме, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Добавьте кольцевую диаграмму на слайд.
- Укажите размер отверстия в кольцевой диаграмме.
- Запишите презентацию на диск.

В приведённом ниже примере мы задали размер отверстия в кольцевой диаграмме.
```c#
 // Создайте экземпляр класса Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

 // Сохраните презентацию на диск
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Могу ли я создать многоуровневую кольцевую диаграмму с несколькими кольцами?**

Да. Добавьте несколько серий в одну кольцевую диаграмму — каждая серия становится отдельным кольцом. Порядок колец определяется порядком серий в коллекции.

**Поддерживается ли «взрывная» кольцевая диаграмма (разделённые сектора)?**

Да. Существует тип диаграммы Exploded Doughnut [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) и свойство взрыва для точек данных; вы можете разделять отдельные сектора.

**Как получить изображение кольцевой диаграммы (PNG/SVG) для отчёта?**

Диаграмма является фигурой; её можно отрисовать в [растровое изображение](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) или экспортировать диаграмму в [SVG‑изображение](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).