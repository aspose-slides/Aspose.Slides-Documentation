---
title: Область построения диаграммы
type: docs
url: /ru/androidjava/chart-plot-area/
---


## **Получить ширину, высоту области построения диаграммы**
Aspose.Slides для Android на Java предоставляет простое API для . 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите первый слайд.
1. Добавьте диаграмму с данными по умолчанию.
1. Вызовите метод [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) перед получением актуальных значений.
1. Получите актуальное положение по оси X (слева) элемента диаграммы относительно верхнего левого угла диаграммы.
1. Получите актуальную верхнюю границу элемента диаграммы относительно верхнего левого угла диаграммы.
1. Получите актуальную ширину элемента диаграммы.
1. Получите актуальную высоту элемента диаграммы.

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

## **Установить режим макета области построения диаграммы**
Aspose.Slides для Android на Java предоставляет простое API для установки режима макета области построения диаграммы. Методы [**setLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) и [**getLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) были добавлены в класс [**ChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea) и интерфейс [**IChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartPlotArea). Если макет области построения задан вручную, это свойство указывает, следует ли располагать область построения внутри (не включая оси и подписи осей) или снаружи (включая оси и подписи осей). Есть два возможных значения, определенных в перечислении [**LayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Inner) - указывает, что размер области построения должен определять размер области построения, не включая метки делений и подписи осей.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Outer) - указывает, что размер области построения должен определять размер области построения, меток делений и подписей осей.

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