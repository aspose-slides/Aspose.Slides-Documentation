---
title: Настройка точек данных в диаграммах Treemap и Sunburst с использованием JavaScript
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- диаграмма treemap
- диаграмма sunburst
- точка данных
- цвет метки
- цвет ветви
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как управлять точками данных в диаграммах treemap и sunburst с помощью JavaScript и Aspose.Slides для Node.js через Java, совместимо с форматами PowerPoint."
---

Среди других типов диаграмм PowerPoint есть два «иерархических» типа - **Treemap** и **Sunburst** диаграмма (также известные как Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph или Multi Level Pie Chart). Эти диаграммы отображают иерархические данные, организованные как дерево - от листьев к вершине ветки. Листья определяются точками данных серии, а каждый последующий вложенный уровень группировки определяется соответствующей категорией. Aspose.Slides for Node.js via Java позволяет форматировать точки данных Sunburst Chart и Treemap на JavaScript.

Вот диаграмма Sunburst, где данные в столбце Series1 определяют листовые узлы, а остальные столбцы определяют иерархические точки данных:
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


{{% alert color="primary" title="См. также" %}} 
- [**Создать или обновить диаграммы PowerPoint презентации на JavaScript**](/slides/ru/nodejs-java/create-chart/)
{{% /alert %}}

Если необходимо отформатировать точки данных диаграммы, следует использовать следующее:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager), [ChartDataPointLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) классы и [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) метод дают доступ к форматированию точек данных Treemap и Sunburst диаграмм. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager) используется для доступа к многуровневым категориям - это контейнер для объектов [**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel). По сути это оболочка для [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartCategoryLevelsManager) с добавленными специфичными для точек данных свойствами. Класс [**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) имеет два метода: [**getFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) и [**getDataLabel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) , которые дают доступ к соответствующим настройкам.

## **Показать значение точки данных**
Показать значение точки данных «Leaf 4»:
```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Установить метку и цвет точки данных**
Установить метку данных «Branch 1» так, чтобы отображалось имя серии («Series1») вместо имени категории. Затем установить цвет текста в желтый:
```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Установить цвет ветви точки данных**
Изменить цвет ветви «Steam 4»:
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

## **FAQ**

**Могу ли я изменить порядок (сортировку) сегментов в Sunburst/Treemap?**

Нет. PowerPoint автоматически сортирует сегменты (обычно по убывающим значениям, по часовой стрелке). Aspose.Slides повторяет это поведение: изменить порядок напрямую нельзя; его можно добиться предварительной обработкой данных.

**Как тема презентации влияет на цвета сегментов и меток?**

Цвета диаграмм наследуют [тему/палитру](/slides/ru/nodejs-java/presentation-theme/) презентации, если вы явно не задаёте заливки/шрифты. Для согласованных результатов фиксируйте сплошные заливки и форматирование текста на нужных уровнях.

**Сохранит ли экспорт в PDF/PNG пользовательские цвета ветвей и настройки меток?**

Да. При экспорте презентации настройки диаграммы (заливки, метки) сохраняются в выходных форматах, поскольку Aspose.Slides рендерит диаграмму с применённым форматированием.

**Могу ли я вычислить фактические координаты метки/элемента для пользовательского размещения наложения поверх диаграммы?**

Да. После проверки компоновки диаграммы доступны фактические X и Y для элементов (например, [DataLabel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/)), что помогает точно позиционировать наложения.