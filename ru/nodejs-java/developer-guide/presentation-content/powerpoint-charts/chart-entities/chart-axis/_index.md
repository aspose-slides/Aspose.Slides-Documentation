---
title: Ось диаграммы
type: docs
url: /ru/nodejs-java/chart-axis/
keywords: "Ось диаграммы PowerPoint, Диаграммы презентаций, Java, Манипулирование осью диаграммы, Данные диаграммы"
description: "Как редактировать ось диаграммы PowerPoint на JavaScript"
---

## **Получение максимальных значений по вертикальной оси на диаграммах**

Aspose.Slides for Node.js via Java позволяет получать минимальные и максимальные значения по вертикальной оси. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте диаграмму с данными по умолчанию.
4. Получите фактическое максимальное значение оси.
5. Получите фактическое минимальное значение оси.
6. Получите фактическую основную единицу измерения оси.
7. Получите фактическую второстепенную единицу измерения оси.
8. Получите фактический масштаб основной единицы измерения оси.
9. Получите фактический масштаб второстепенной единицы измерения оси.

Этот пример кода — реализация описанных выше шагов — демонстрирует, как получить требуемые значения на JavaScript:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // Сохраняет презентацию
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Обмен данными между осями**

Aspose.Slides позволяет быстро обменять данные между осями — данные, отображаемые по вертикальной оси (y-axis), перемещаются на горизонтальную ось (x-axis) и наоборот.

Этот JavaScript‑код показывает, как выполнить задачу обмена данными между осями на диаграмме:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // Переставляет строки и столбцы
    chart.getChartData().switchRowColumn();
    // Сохраняет презентацию
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Отключение вертикальной оси для линейных диаграмм**

Этот JavaScript‑код показывает, как скрыть вертикальную ось линейной диаграммы:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Отключение горизонтальной оси для линейных диаграмм**

Этот код показывает, как скрыть горизонтальную ось линейной диаграммы:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Изменение оси категорий**

С помощью свойства **CategoryAxisType** можно указать предпочтительный тип оси категорий (**date** или **text**). Этот JavaScript‑код демонстрирует операцию: 
```javascript
var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);
    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Установка формата даты для значения оси категорий**

Aspose.Slides for Node.js via Java позволяет задать формат даты для значения оси категорий. Операция продемонстрирована в этом JavaScript‑коде:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 450, 300);
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(java.newInstanceSync("GregorianCalendar", 2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(java.newInstanceSync("GregorianCalendar", 2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(java.newInstanceSync("GregorianCalendar", 2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(java.newInstanceSync("GregorianCalendar", 2018, 1, 1))));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
const dayjs = require('dayjs');

function convertToOADate(date) {
    const baseDate = dayjs('1899-12-30');

    const days = date.diff(baseDate, 'day');

    const fractionalDay = (date.hour() / 24) +
                          (date.minute() / (60 * 24)) +
                          (date.second() / (60 * 24 * 60));

    const oaDate = days + fractionalDay;

    return String(oaDate);
}
```


## **Установка угла поворота заголовка оси диаграммы**

Aspose.Slides for Node.js via Java позволяет задать угол поворота заголовка оси диаграммы. Этот JavaScript‑код демонстрирует операцию:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установка позиции оси в оси категорий или значений**

Aspose.Slides for Node.js via Java позволяет задать позицию оси в оси категорий или значений. Этот JavaScript‑код показывает, как выполнить задачу:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Включение отображения единицы измерения на оси значений диаграммы**

Aspose.Slides for Node.js via Java позволяет настроить диаграмму для отображения метки единицы измерения на её оси значений. Этот JavaScript‑код демонстрирует операцию:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Как задать значение, при котором одна ось пересекает другую (пересечение осей)?**

Оси предоставляют [настройку пересечения](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/): можно выбрать пересечение на нуле, на максимальной категории/значении или на конкретном числовом значении. Это полезно для смещения оси X вверх или вниз либо для выделения базовой линии.

**Как разместить подписи делений относительно оси (рядом, снаружи, внутри)?**

Установите [позицию подписи](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) в значение «cross», «outside» или «inside». Это влияет на читаемость и помогает экономить пространство, особенно в небольших диаграммах.