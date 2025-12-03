---
title: Настройка точек данных в диаграммах Treemap и Sunburst с использованием Java
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- диаграмма treemap
- диаграмма sunburst
- точка данных
- цвет метки
- цвет ветки
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как управлять точками данных в диаграммах treemap и sunburst с помощью Aspose.Slides для Java, совместимо с форматами PowerPoint."
---

Среди прочих типов диаграмм PowerPoint есть два «иерархических» типа — **Treemap** и **Sunburst** (также известные как Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph или Multi Level Pie Chart). Эти диаграммы отображают иерархические данные, организованные в виде дерева — от листьев к вершине ветви. Листья определяются точками данных серии, а каждый последующий уровень вложенной группировки определяется соответствующей категорией. Aspose.Slides for Java позволяет форматировать точки данных диаграмм Sunburst и Treemap на Java.

Ниже приведена диаграмма Sunburst, где данные в столбце Series1 определяют листовые узлы, а остальные столбцы задают иерархические точки данных:

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
- [**Создание диаграммы Sunburst**](/slides/ru/java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Если необходимо форматировать точки данных диаграммы, следует использовать следующее:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) классы 
и [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) метод 
обеспечивают доступ к форматированию точек данных Treemap и Sunburst диаграмм. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager) 
используется для доступа к многоуровневым категориям — он представляет контейнер 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) объектов. 
По сути это оболочка для 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartCategoryLevelsManager) с 
добавленными специфическими для точек данных свойствами. 
Класс [**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) имеет 
два метода: [**getFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getFormat--) и 
[**getDataLabel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getLabel--) которые 
предоставляют доступ к соответствующим настройкам.

## **Показать значение точки данных**
Показать значение точки данных «Leaf 4»:
```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Установить метку и цвет точки данных**
Установить метку данных «Branch 1», чтобы отображалось имя серии («Series1») вместо имени категории. Затем установить цвет текста в желтый:
```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Установить цвет ветки точки данных**
Изменить цвет ветки «Steam 4»:
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

**Могу ли я изменить порядок (сортировку) сегментов в диаграммах Sunburst/Treemap?**

Нет. PowerPoint сортирует сегменты автоматически (обычно по убыванию значений по часовой стрелке). Aspose.Slides отражает это поведение: изменить порядок непосредственно нельзя; его можно изменить, предварительно обработав данные.

**Как тема презентации влияет на цвета сегментов и меток?**

Цвета диаграмм наследуют [тему/палитру](/slides/ru/java/presentation-theme/) презентации, если только вы явно не задаете заливки/шрифты. Для согласованных результатов фиксируйте сплошные заливки и форматирование текста на нужных уровнях.

**Сохранит ли экспорт в PDF/PNG пользовательские цвета веток и настройки меток?**

Да. При экспорте презентации настройки диаграммы (заливки, метки) сохраняются в выходных форматах, поскольку Aspose.Slides рендерит их с применённым форматированием.

**Могу ли я вычислить фактические координаты метки/элемента для размещения пользовательского наложения поверх диаграммы?**

Да. После проверки компоновки диаграммы доступны фактические *x* и *y* для элементов (например, [DataLabel](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/)), что помогает точно позиционировать наложения.