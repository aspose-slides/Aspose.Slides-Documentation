---
title: Область графика
type: docs
url: /ru/java/chart-plot-area/
---


## **Получить ширину и высоту области графика**
Aspose.Slides для Java предоставляет простой API для . 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Добавьте график с данными по умолчанию.
1. Вызовите метод [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) перед тем, как получить актуальные значения.
1. Получите фактическое положение X (слева) элемента графика относительно верхнего левого угла графика.
1. Получите фактическую верхнюю границу элемента графика относительно верхнего левого угла графика.
1. Получите фактическую ширину элемента графика.
1. Получите фактическую высоту элемента графика.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установить режим компоновки области графика**
Aspose.Slides для Java предоставляет простой API для установки режима компоновки области графика. Методы [**setLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) и [**getLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) были добавлены в класс [**ChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea) и интерфейс [**IChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartPlotArea). Если компоновка области графика определена вручную, это свойство указывает, следует ли размещать область графика внутри (не включая оси и метки осей) или снаружи (включая оси и метки осей). Есть два возможных значения, которые определены в перечислении [**LayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Inner) - указывает на то, что размер области графика должен определяться размером области графика, не включая деления и метки осей.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Outer) - указывает на то, что размер области графика должен определяться размером области графика, делений и меток осей.

Пример кода приведён ниже.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```