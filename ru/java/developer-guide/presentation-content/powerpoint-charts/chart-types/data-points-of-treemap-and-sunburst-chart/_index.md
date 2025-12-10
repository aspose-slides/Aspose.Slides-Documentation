---
title: Настройка точек данных в диаграммах Treemap и Sunburst с использованием Java
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- диаграмма Treemap
- диаграмма Sunburst
- точка данных
- цвет подписи
- цвет ветки
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как управлять точками данных в диаграммах Treemap и Sunburst с помощью Aspose.Slides для Java, совместимыми с форматами PowerPoint."
---

Среди прочих типов диаграмм PowerPoint существуют два «иерархических» типа – **Treemap** и **Sunburst** (также известные как Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph или Multi Level Pie Chart). Эти диаграммы отображают иерархические данные, организованные в виде дерева — от листьев к вершине ветви. Листья определяются точками данных серии, а каждый последующий вложенный уровень группировки определяется соответствующей категорией. Aspose.Slides for Java позволяет форматировать точки данных Sunburst‑диаграммы и Treemap в Java.

Ниже приведена Sunburst‑диаграмма, где данные в столбце Series1 определяют листовые узлы, а остальные столбцы задают иерархические точки данных:
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Начнём с добавления новой Sunburst‑диаграммы в презентацию:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="See also" %}} 
- [**Создание Sunburst‑диаграммы**](/slides/ru/java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Если необходимо отформатировать точки данных диаграммы, следует использовать следующее:
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) классы 
и метод [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) 
предоставляют доступ к форматированию точек данных Treemap и Sunburst диаграмм. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager) используется для доступа к многоуровневым категориям - он представляет контейнер объектов [**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel). По сути это оболочка для [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartCategoryLevelsManager) с добавленными свойствами, специфичными для точек данных. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) класс имеет два метода: [**getFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getFormat--) и [**getDataLabel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getLabel--) которые предоставляют доступ к соответствующим настройкам.

## **Отображение значения точки данных**
Показать значение точки данных «Leaf 4»:
```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Установка подписи и цвета точки данных**
Установить подпись точки данных «Branch 1», чтобы отображалось имя серии («Series1») вместо имени категории. Затем установить цвет текста в желтый:
```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Установка цвета ветки точки данных**
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

## **Вопросы и ответы**

**Можно ли изменить порядок (сортировку) сегментов в Sunburst/Treemap?**

Нет. PowerPoint сортирует сегменты автоматически (обычно по убыванию значений по часовой стрелке). Aspose.Slides отражает это поведение: изменить порядок напрямую нельзя; его можно изменить только предварительной обработкой данных.

**Как тема презентации влияет на цвета сегментов и подписей?**

Цвета диаграммы наследуют [тему/палитру](/slides/ru/java/presentation-theme/) презентации, если только вы явно не задаете заливки/шрифты. Для согласованных результатов фиксируйте сплошные заливки и форматирование текста на необходимых уровнях.

**Сохранится ли при экспорте в PDF/PNG пользовательские цвета веток и настройки подписей?**

Да. При экспорте презентации настройки диаграммы (заливки, подписи) сохраняются в выходных форматах, поскольку Aspose.Slides рендерит диаграмму с применённым форматированием.

**Можно ли вычислить фактические координаты подписи/элемента для пользовательского наложения поверх диаграммы?**

Да. После того как раскладка диаграммы проверена, доступны реальные *x* и *y* координаты элементов (например, [DataLabel](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/)), что помогает точно позиционировать наложения.