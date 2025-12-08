---
title: Точки данных диаграмм Treemap и Sunburst
type: docs
url: /ru/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords: "Sunburst график в Aspose.Slides for Node.js via Java"
description: "Sunburst график, Sunburst диаграмма, Sunburst Chart, Radial Chart, Radial Graph или Multi Level Pie Chart с Aspose.Slides for Node.js via Java."
---

Среди прочих типов диаграмм PowerPoint существуют два «иерархических» типа — **Treemap** и **Sunburst** (также известные как Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph или Multi Level Pie Chart). Эти диаграммы отображают иерархические данные, организованные в виде дерева — от листьев к вершине ветви. Листья определяются точками данных серии, а каждый последующий вложенный уровень группировки определяется соответствующей категорией. Aspose.Slides for Node.js via Java позволяет форматировать точки данных диаграмм Sunburst и Treemap на JavaScript.

Here is a Sunburst Chart, where data in Series1 column define the leaf nodes, while other columns define hierarchical datapoints:
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Начнём с добавления новой диаграммы Sunburst в презентацию:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="Смотрите также" %}} 
- [**Создание диаграммы Sunburst**](/slides/ru/nodejs-java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Если необходимо отформатировать точки данных диаграммы, следует использовать следующее:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager), 
[ChartDataPointLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) классы 
и [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) метод 
предоставляют доступ к форматированию точек данных диаграмм Treemap и Sunburst. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager)
используется для доступа к многоуровневым категориям — он представляет контейнер объектов 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel). 
По сути это оболочка для 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartCategoryLevelsManager) 
с добавленными свойствами, специфичными для точек данных. 
Класс [**ChartDataPointLevel**] имеет два метода: [**getFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) и 
[**getDataLabel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) , которые предоставляют доступ к соответствующим настройкам.

## **Показать значение точки данных**
Показать значение точки данных «Leaf 4»:
```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Установить метку и цвет точки данных**
Установите метку данных «Branch 1», чтобы отображалось название серии («Series1») вместо имени категории. Затем задайте цвет текста — желтый:
```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Установить цвет ветки точки данных**
Изменить цвет ветки «Steam 4»:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Вопросы и ответы**

**Могу ли я изменить порядок (сортировку) сегментов в диаграммах Sunburst/Treemap?**

Нет. PowerPoint сортирует сегменты автоматически (обычно по убыванию значений, по часовой стрелке). Aspose.Slides повторяет это поведение: изменить порядок напрямую нельзя; его можно изменить предварительной обработкой данных.

**Как тема презентации влияет на цвета сегментов и меток?**

Цвета диаграмм наследуются от [тематической палитры](/slides/ru/nodejs-java/presentation-theme/) презентации, если вы явно не задаете заполнения/шрифты. Для получения согласованных результатов фиксируйте сплошные заливки и форматирование текста на нужных уровнях.

**Сохранит ли экспорт в PDF/PNG пользовательские цвета веток и настройки меток?**

Да. При экспорте презентации настройки диаграммы (заливки, метки) сохраняются в целевых форматах, так как Aspose.Slides рендерит их с применённым форматированием.

**Могу ли я вычислить реальные координаты метки/элемента для размещения пользовательского наложения поверх диаграммы?**

Да. После подтверждения компоновки диаграммы доступны реальные координаты X и Y для элементов (например, [DataLabel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/)), что помогает точно позиционировать наложения.