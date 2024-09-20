---
title: Точки данных диаграммы Солнечного зайца и Древовидной диаграммы
type: docs
url: /androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords: "График солнечного зайца в Aspose.Slides для Android через Java"
description: "График солнечного зайца, диаграмма солнечного зайца, диаграмма солнечного зайца, радиальная диаграмма, радиальный график или многоуровневая круговая диаграмма с Aspose.Slides для Android через Java."
---

Среди других типов диаграмм PowerPoint существуют два "иерархических" типа - **Древовидная диаграмма** и **Диаграмма солнечного зайца** (также известная как график солнечного зайца, диаграмма солнечного зайца, радиальная диаграмма, радиальный график или многоуровневая круговая диаграмма). Эти диаграммы отображают иерархические данные, организованные в виде дерева - от листьев до вершины ветки. Листья определяются точками данных серии, а каждый последующий вложенный уровень группировки определяется соответствующей категорией. Aspose.Slides для Android через Java позволяет форматировать точки данных диаграммы солнечного зайца и древовидной диаграммы на Java.

Вот диаграмма солнечного зайца, где данные в столбце Series1 определяют узлы листьев, в то время как другие столбцы определяют иерархические точки данных:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Начнем с добавления новой диаграммы солнечного зайца в презентацию:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="Смотрите также" %}} 
- [**Создание диаграммы солнечного зайца**](/slides/androidjava/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


Если необходимо отформатировать точки данных диаграммы, мы должны использовать следующее:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevelsManager),  
[IChartDataPointLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) классы  
и [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) метод  
предоставляют доступ для форматирования точек данных диаграмм древовидной диаграммы и солнечного зайца.  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevelsManager)
используется для доступа к многоуровневым категориям - он представляет собой контейнер для  
[**IChartDataPointLevel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) объектов. 
По сути, это обертка для  
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartCategoryLevelsManager) с 
дополниительными свойствами, специфичными для точек данных.  
Класс [**IChartDataPointLevel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) имеет 
два метода: [**getFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) и  
[**getDataLabel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) которые 
предоставляют доступ к соответствующим настройкам.
## **Показать значение точки данных**
Показать значение точки данных "Лист 4":

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Установить метку и цвет точки данных**
Установить метку данных "Ветка 1" так, чтобы она показывала имя серии ("Series1") вместо имени категории. Затем установите цвет текста на желтый:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Установить цвет ветки точки данных**
Изменить цвет ветки "Стебель 4":

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
