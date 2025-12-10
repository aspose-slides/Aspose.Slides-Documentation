---
title: Настройка кольцевых диаграмм в презентациях с использованием Java
linktitle: Кольцевая диаграмма
type: docs
weight: 30
url: /ru/java/doughnut-chart/
keywords:
- кольцевая диаграмма
- центрический разрыв
- размер отверстия
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как создавать и настраивать кольцевые диаграммы в Aspose.Slides для Java, поддерживая форматы PowerPoint для динамических презентаций."
---

## **Указать центрический разрыв в кольцевой диаграмме**
{{% alert color="primary" %}} 

Aspose.Slides for Java теперь поддерживает указание размера отверстия в кольцевой диаграмме. В этой теме мы на примере покажем, как задать размер отверстия в кольцевой диаграмме.

{{% /alert %}} 

Чтобы указать размер отверстия в кольцевой диаграмме, выполните следующие шаги:

1. Создайте объект [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Добавьте кольцевую диаграмму на слайд.
1. Укажите размер отверстия в кольцевой диаграмме.
1. Сохраните презентацию на диск.

В приведённом ниже примере мы задали размер отверстия в кольцевой диаграмме.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Сохранить презентацию на диск
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Могу ли я создать многоуровневую кольцевую диаграмму с несколькими кольцами?**

Да. Добавьте несколько рядов в одну кольцевую диаграмму — каждый ряд станет отдельным кольцом. Порядок колец определяется порядком рядов в коллекции.

**Поддерживается ли «взрывная» кольцевая диаграмма (отделённые срезы)?**

Да. Существует тип диаграммы Exploded Doughnut [chart type](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) и свойство explosion у точек данных; вы можете отделять отдельные срезы.

**Как получить изображение кольцевой диаграммы (PNG/SVG) для отчёта?**

Диаграмма — это shape; её можно отрисовать в [raster image](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) или экспортировать в [SVG image](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).