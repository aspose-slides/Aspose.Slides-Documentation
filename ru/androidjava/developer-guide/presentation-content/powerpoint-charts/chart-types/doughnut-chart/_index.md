---
title: Настройка кольцевых диаграмм в презентациях на Android
linktitle: Кольцевая диаграмма
type: docs
weight: 30
url: /ru/androidjava/doughnut-chart/
keywords:
- кольцевая диаграмма
- центральный зазор
- размер отверстия
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как создавать и настраивать кольцевые диаграммы в Aspose.Slides для Android через Java, поддерживая форматы PowerPoint для динамических презентаций."
---

## **Укажите центральный зазор в кольцевой диаграмме**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java теперь поддерживает указание размера отверстия в кольцевой диаграмме. В этой статье мы на примере покажем, как указать размер отверстия в кольцевой диаграмме.

{{% /alert %}} 

Чтобы указать размер отверстия в кольцевой диаграмме, выполните следующие шаги:

1. Создайте объект [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) .
2. Добавьте кольцевую диаграмму на слайд.
3. Укажите размер отверстия в кольцевой диаграмме.
4. Запишите презентацию на диск.

В приведённом ниже примере мы задали размер отверстия в кольцевой диаграмме.
```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Запишите презентацию на диск
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Часто задаваемые вопросы**

**Могу ли я создать многоуровневую кольцевую диаграмму с несколькими кольцами?**

Да. Добавьте несколько серий в одну кольцевую диаграмму — каждая серия становится отдельным кольцом. Порядок колец определяется порядком серий в коллекции.

**Поддерживается "взрывная" кольцевая диаграмма (отдельные сектора)?**

Да. Существует тип диаграммы Exploded Doughnut [chart type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) и свойство взрыва у точек данных; вы можете отделять отдельные сектора.

**Как получить изображение кольцевой диаграммы (PNG/SVG) для отчёта?**

Диаграмма — это фигура; её можно отрисовать в [растровое изображение](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) или экспортировать в [SVG‑изображение](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).