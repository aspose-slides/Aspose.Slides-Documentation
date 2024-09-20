---
title: Вычисления графиков
type: docs
weight: 50
url: /androidjava/chart-calculations/
---

## **Вычисление фактических значений элементов графика**
Aspose.Slides для Android через Java предоставляет простой API для получения этих свойств. Свойства интерфейса [IAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis) предоставляют информацию о фактическом положении элемента графика оси ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Необходимо предварительно вызвать метод [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--), чтобы заполнить свойства фактическими значениями.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Вычисление фактического положения родительских элементов графика**
Aspose.Slides для Android через Java предоставляет простой API для получения этих свойств. Свойства интерфейса [IActualLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout) предоставляют информацию о фактическом положении родительского элемента графика ([IActualLayout.getActualX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)). Необходимо предварительно вызвать метод [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--), чтобы заполнить свойства фактическими значениями.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Скрытие информации из графика**
Эта тема поможет вам понять, как скрыть информацию из графика. Используя Aspose.Slides для Android через Java, вы можете скрыть **Заголовок, Вертикальную ось, Горизонтальную ось** и **Сеточные линии** из графика. Пример кода ниже демонстрирует, как использовать эти свойства.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Скрытие заголовка графика
    chart.setTitle(false);

    //Скрытие оси значений
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Видимость оси категорий
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Скрытие легенды
    chart.setLegend(false);

    //Скрытие основных сеточных линий
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Установка цвета линии серии
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```