---
title: Настройка точек данных в диаграммах Treemap и Sunburst на Android
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- диаграмма Treemap
- диаграмма Sunburst
- точка данных
- цвет метки
- цвет ветви
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как управлять точками данных в диаграммах Treemap и Sunburst с помощью Aspose.Slides для Android через Java, совместимыми с форматами PowerPoint."
---

Среди прочих типов диаграмм PowerPoint существуют два «иерархических» типа — **Treemap** и **Sunburst** (также известные как Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph или Multi Level Pie Chart). Эти диаграммы отображают иерархические данные, организованные в виде дерева — от листьев к вершине ветви. Листья определяются точками данных серии, а каждый последующий вложенный уровень группировки определяется соответствующей категорией. Aspose.Slides for Android via Java позволяет форматировать точки данных диаграмм Sunburst и Treemap на Java.

Ниже представлена диаграмма Sunburst, где данные в столбце Series1 определяют листовые узлы, а остальные столбцы определяют иерархические точки данных:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Начнём с добавления новой диаграммы Sunburst в презентацию:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="См. также" %}} 
- [**Создание или обновление диаграмм PowerPoint в Android**](/slides/ru/androidjava/create-chart/)
{{% /alert %}}

Если необходимо отформатировать точки данных диаграммы, следует использовать следующее:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevelsManager), [IChartDataPointLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) classes and [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) method provide access to format data points of Treemap and Sunburst charts. [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevelsManager) is used for accessing multi-level categories - it represents the container of [**IChartDataPointLevel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) objects. Basically it is a wrapper for [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartCategoryLevelsManager) with the properties added specific for data points. [**IChartDataPointLevel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) class has two methods: [**getFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) and [**getDataLabel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) which provide access to corresponding settings.

## **Показать значение точки данных**
Показать значение точки данных "Leaf 4":
```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Установить метку и цвет точки данных**
Установите метку данных "Branch 1" так, чтобы отображалось имя серии ("Series1") вместо имени категории. Затем задайте цвет текста желтым:
```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Установить цвет ветви точки данных**
Изменить цвет ветви "Steam 4":
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Могу ли я изменить порядок (сортировку) сегментов в Sunburst/Treemap?**

No. PowerPoint sorts segments automatically (typically by descending values, clockwise). Aspose.Slides mirrors this behavior: you can’t change the order directly; you achieve it by preprocessing the data.

**Как тема презентации влияет на цвета сегментов и меток?**

Chart colors inherit the presentation’s [theme/palette](/slides/ru/androidjava/presentation-theme/) unless you explicitly set fills/fonts. For consistent results, lock in solid fills and text formatting at the required levels.

**Будут ли экспорт в PDF/PNG сохранять пользовательские цвета ветвей и настройки меток?**

Yes. When exporting the presentation, chart settings (fills, labels) are preserved in the output formats because Aspose.Slides renders with the chart’s formatting applied.

**Могу ли я вычислить реальные координаты метки/элемента для размещения пользовательского наложения поверх диаграммы?**

Yes. After the chart layout is validated, actual *x* and actual *y* are available for elements (for example, a [DataLabel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/)), which helps with precise positioning of overlays.