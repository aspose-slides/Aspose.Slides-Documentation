---
title: Оптимизация вычислений диаграмм для презентаций на JavaScript
linktitle: Вычисления диаграмм
type: docs
weight: 50
url: /ru/nodejs-java/chart-calculations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Поймите вычисления диаграмм, обновление данных и контроль точности в Aspose.Slides для Node.js для PPT и PPTX, с практическими примерами кода на JavaScript."
---

## **Вычисление фактических значений элементов диаграммы**

Aspose.Slides for Node.js via Java предоставляет простой API для получения этих свойств. Свойства класса [Axis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis) предоставляют информацию о фактическом положении оси элемента диаграммы ([Axis.getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). Необходимо предварительно вызвать метод [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) для заполнения свойств фактическими значениями.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Вычисление фактического положения родительских элементов диаграммы**

Aspose.Slides for Node.js via Java предоставляет простой API для получения этих свойств. Свойства класса `ActualLayout` предоставляют информацию о фактическом положении родительского элемента диаграммы `ActualLayout.getActualX`, `ActualLayout.getActualY`, `ActualLayout.getActualWidth`, `ActualLayout.getActualHeight`. Необходимо предварительно вызвать метод [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) для заполнения свойств фактическими значениями.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Скрытие информации на диаграмме**

Эта тема поможет вам понять, как скрыть информацию на диаграмме. С помощью Aspose.Slides for Node.js via Java вы можете скрыть **Title, Vertical Axis, Horizontal Axis** и **Grid Lines** на диаграмме. Приведённый ниже пример кода показывает, как использовать эти свойства.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // Скрытие заголовка диаграммы
    chart.setTitle(false);
    // /Скрытие оси значений
    chart.getAxes().getVerticalAxis().setVisible(false);
    // Видимость оси категорий
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // Скрытие легенды
    chart.setLegend(false);
    // Скрытие основных линий сетки
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // Установка цвета линии серии
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Работают ли внешние Excel‑книги в качестве источника данных и как это влияет на пересчёт?**

Да. Диаграмма может ссылаться на внешнюю книгу: когда вы подключаете или обновляете внешний источник, формулы и значения берутся из этой книги, и диаграмма отражает изменения во время операций открытия/редактирования. API позволяет вам [указать внешний рабочий файл](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) путь и управлять связанными данными.

**Могу ли я вычислять и отображать линии тренда без реализации регрессии самостоятельно?**

Да. [Trendlines](/slides/ru/nodejs-java/trend-line/) (linear, exponential, and others) добавляются и обновляются Aspose.Slides; их параметры автоматически пересчитываются из данных серии, поэтому вам не нужно реализовывать собственные вычисления.

**Если презентация содержит несколько диаграмм с внешними ссылками, могу ли я контролировать, какую книгу использует каждая диаграмма для вычисляемых значений?**

Да. Каждая диаграмма может указывать на свою [external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/), или вы можете создать/заменить внешний рабочий файл для каждой диаграммы независимо от других.