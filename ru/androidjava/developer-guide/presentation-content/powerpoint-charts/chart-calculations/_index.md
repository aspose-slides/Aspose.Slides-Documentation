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
description: "Поймите вычисления диаграмм, обновление данных и контроль точности в Aspose.Slides для Android для форматов PPT и PPTX, с практическими примерами кода на Java."
---

## **Вычисление фактических значений элементов диаграммы**
Aspose.Slides for Android via Java предоставляет простой API для получения этих свойств. Свойства интерфейса [IAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis) предоставляют информацию о фактическом положении элемента оси диаграммы ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Необходимо предварительно вызвать метод [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) , чтобы заполнить свойства фактическими значениями.
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
Aspose.Slides for Android via Java предоставляет простой API для получения этих свойств. Свойства интерфейса [IActualLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout) предоставляют информацию о фактическом положении родительского элемента диаграммы ([IActualLayout.getActualX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)). Необходимо предварительно вызвать метод [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) , чтобы заполнить свойства фактическими значениями.
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


## **Скрыть элементы диаграммы**
Эта тема поможет вам понять, как скрыть информацию на диаграмме. С помощью Aspose.Slides for Android via Java вы можете скрыть **Заголовок**, **Вертикальную ось**, **Горизонтальную ось** и **Линии сетки** на диаграмме. Приведённый ниже пример кода показывает, как использовать эти свойства.
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Скрытие заголовка диаграммы
    chart.setTitle(false);

    ///Скрытие оси значений
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Видимость категориальной оси
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


## **FAQ**

**Можно ли использовать внешние книги Excel в качестве источника данных, и как это влияет на пересчёт?**

Да. Диаграмма может ссылаться на внешнюю книгу: при подключении или обновлении внешнего источника формулы и значения берутся из этой книги, и диаграмма отображает изменения во время открытых/редактируемых операций. API позволяет вам [указать внешний файл книги](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) и управлять связанными данными.

**Могу ли я вычислять и отображать линии тренда без самостоятельной реализации регрессии?**

Да. [Линии тренда](/slides/ru/androidjava/trend-line/) (линейные, экспоненциальные и другие) добавляются и обновляются Aspose.Slides; их параметры автоматически пересчитываются из данных серии, поэтому вам не нужно реализовывать собственные вычисления.

**Если в презентации несколько диаграмм с внешними ссылками, могу ли я управлять тем, какую книгу использует каждая диаграмма для вычисленных значений?**

Да. Каждая диаграмма может указывать свою собственную [внешнюю книгу](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-), либо вы можете создать/заменить внешнюю книгу для каждой диаграммы независимо друг от друга.