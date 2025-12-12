---
title: Оптимизация вычислений диаграмм для презентаций на Android
linktitle: Вычисления диаграмм
type: docs
weight: 50
url: /ru/androidjava/chart-calculations/
keywords:
- вычисления диаграмм
- элементы диаграммы
- позиция элемента
- фактическая позиция
- дочерний элемент
- родительский элемент
- значения диаграммы
- фактическое значение
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Поймите вычисления диаграмм, обновление данных и контроль точности в Aspose.Slides для Android для PPT и PPTX, с практическими примерами кода на Java."
---

## **Вычисление фактических значений элементов диаграммы**
Aspose.Slides для Android через Java предоставляет простой API для получения этих свойств. Свойства интерфейса [IAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis) предоставляют информацию о фактическом положении элемента диаграммы оси ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Необходимо предварительно вызвать метод [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) для заполнения свойств фактическими значениями.
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


## **Вычисление фактического положения родительских элементов диаграммы**
Aspose.Slides для Android через Java предоставляет простой API для получения этих свойств. Свойства интерфейса [IActualLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout) предоставляют информацию о фактическом положении родительского элемента диаграммы ([IActualLayout.getActualX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)). Необходимо предварительно вызвать метод [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) для заполнения свойств фактическими значениями.
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


## **Скрытие элементов диаграммы**
Эта тема поможет понять, как скрыть информацию на диаграмме. С помощью Aspose.Slides для Android через Java вы можете скрыть **Заголовок, Вертикальную ось, Горизонтальную ось** и **Линии сетки**. Ниже приведён пример кода, показывающий, как использовать эти свойства.
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Скрытие заголовка диаграммы
    chart.setTitle(false);

    ///Скрытие оси значений
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Видимость оси категорий
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Скрытие легенды
    chart.setLegend(false);

    //Скрытие основных линий сетки
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


## **Часто задаваемые вопросы**

**Могут ли внешние книги Excel использоваться в качестве источника данных и как это влияет на перерасчёт?**

Да. Диаграмма может ссылаться на внешнюю книгу: при подключении или обновлении внешнего источника формулы и значения берутся из этой книги, и диаграмма отражает изменения во время открытых/редактируемых операций. API позволяет [указать путь к внешней книге](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) и управлять связанными данными.

**Могу ли я вычислять и отображать линии тренда без реализации регрессии самостоятельно?**

Да. [Линии тренда](/slides/ru/androidjava/trend-line/) (линейные, экспоненциальные и др.) добавляются и обновляются Aspose.Slides; их параметры автоматически перерассчитываются из данных серии, поэтому вам не нужно выполнять собственные расчёты.

**Если в презентации несколько диаграмм со внешними ссылками, могу ли я управлять тем, какую книгу каждый график использует для вычисленных значений?**

Да. Каждая диаграмма может указывать свою собственную [внешнюю книгу](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-), либо вы можете создать/заменить внешнюю книгу для каждой диаграммы независимо от остальных.