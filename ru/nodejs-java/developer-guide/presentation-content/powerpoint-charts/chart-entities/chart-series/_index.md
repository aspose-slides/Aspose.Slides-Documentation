---
title: Серии диаграмм
type: docs
url: /ru/nodejs-java/chart-series/
keywords: "Серии диаграмм, цвет серии, презентация PowerPoint, Java, Aspose.Slides for Node.js via Java"
description: "Серии диаграмм в презентациях PowerPoint на JavaScript"
---

Серия — это строка или столбец чисел, отображенных на диаграмме.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить перекрытие серии диаграммы**

С помощью метода [ChartSeries.getOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) вы можете задать степень перекрытия столбцов и колонок на 2D‑диаграмме (диапазон: -100 — 100). Это свойство применяется ко всем сериям родительской группы серий: это проекция соответствующего свойства группы. Поэтому свойство доступно только для чтения.

Используйте свойство чтения/записи `ParentSeriesGroup.getOverlap`, чтобы задать желаемое значение для `Overlap`.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Добавьте сгруппированную колонную диаграмму на слайд.
3. Получите первую серию диаграммы.
4. Получите `ParentSeriesGroup` серии и задайте желаемое значение перекрытия.
5. Запишите изменённую презентацию в файл PPTX.

Этот код JavaScript показывает, как задать перекрытие для серии диаграммы:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Добавляет диаграмму
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // Устанавливает перекрытие серии
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // Записывает файл презентации на диск
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Изменить цвет серии**

Aspose.Slides for Node.js via Java позволяет изменить цвет серии следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Добавьте диаграмму на слайд.
3. Получите серию, цвет которой нужно изменить.
4. Задайте нужный тип заливки и цвет заливки.
5. Сохраните изменённую презентацию.

Этот JavaScript‑код показывает, как изменить цвет серии:
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Изменить цвет категории серии**

Aspose.Slides for Node.js via Java позволяет изменить цвет категории серии следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Добавьте диаграмму на слайд.
3. Получите категорию серии, цвет которой нужно изменить.
4. Задайте нужный тип заливки и цвет заливки.
5. Сохраните изменённую презентацию.

Этот код JavaScript показывает, как изменить цвет категории серии:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Изменить имя серии** 

По умолчанию имена в легенде диаграммы берутся из ячеек, расположенных над каждым столбцом или строкой данных.

В нашем примере (см. изображение):

* столбцы имеют имена *Series 1, Series 2* и *Series 3*;
* строки – *Category 1, Category 2, Category 3* и *Category 4*.

Aspose.Slides for Node.js via Java позволяет обновить или изменить имя серии в данных диаграммы и в легенде.

Этот JavaScript‑код показывает, как изменить имя серии в данных диаграммы `ChartDataWorkbook`:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Этот JavaScript‑код показывает, как изменить имя серии в легенде через `Series`:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить цвет заливки серии диаграммы**

Aspose.Slides for Node.js via Java позволяет установить автоматический цвет заливки для серии диаграммы в области построения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию, выбрав нужный тип (в примере ниже использован `ChartType.ClusteredColumn`).
4. Получите серию диаграммы и задайте цвет заливки **Automatic**.
5. Сохраните презентацию в файл PPTX.

Этот JavaScript‑код показывает, как установить автоматический цвет заливки для серии диаграммы:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Создает диаграмму с группированными столбцами
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // Устанавливает автоматический формат заливки серии
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // Записывает файл презентации на диск
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить инвертированный цвет заливки серии диаграммы**

Aspose.Slides позволяет установить инвертированный цвет заливки для серии диаграммы в области построения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию, выбрав нужный тип (в примере ниже использован `ChartType.ClusteredColumn`).
4. Получите серию диаграммы и задайте инвертированный цвет заливки.
5. Сохраните презентацию в файл PPTX.

Этот JavaScript‑код демонстрирует операцию:
```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Добавляет новые серии и категории
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // Берёт первую серию диаграммы и заполняет её данные
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить инверсию серии при отрицательном значении**

Aspose.Slides позволяет установить инверсию через метод `ChartDataPoint.setInvertIfNegative`. При установке инверсии через свойства точка данных меняет цвета, когда её значение становится отрицательным.

Этот JavaScript‑код демонстрирует операцию:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Очистить данные конкретных точек данных**

Aspose.Slides for Node.js via Java позволяет очистить данные `DataPoints` для конкретной серии диаграммы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Получите ссылку на диаграмму по её индексу.
4. Пройдитесь по всем `DataPoints` диаграммы и задайте `XValue` и `YValue` равными `null`.
5. Очистить все`DataPoints` для конкретной серии диаграммы.
6. Запишите изменённую презентацию в файл PPTX.

Этот JavaScript‑код демонстрирует операцию:
```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить ширину промежутка серии**

Aspose.Slides for Node.js via Java позволяет задать ширину промежутка серии через свойство **`GapWidth`** следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Откройте первый слайд.
3. Добавьте диаграмму с данными по умолчанию.
4. Получите любую серию диаграммы.
5. Задайте свойство `GapWidth`.
6. Запишите изменённую презентацию в файл PPTX.

Этот код JavaScript показывает, как задать ширину промежутка серии:
```javascript
// Создает пустую презентацию
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд презентации
    var slide = pres.getSlides().get_Item(0);
    // Добавляет диаграмму с данными по умолчанию
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // Устанавливает индекс листа данных диаграммы
    var defaultWorksheetIndex = 0;
    // Получает лист данных диаграммы
    var fact = chart.getChartData().getChartDataWorkbook();
    // Добавляет серии
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Добавляет категории
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Берет вторую серию диаграммы
    var series = chart.getChartData().getSeries().get_Item(1);
    // Заполняет данные серии
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Устанавливает значение GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    // Сохраняет презентацию на диск
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Существует ли ограничение на количество серий, которое может содержать одна диаграмма?**

Aspose.Slides не накладывает фиксированного ограничения на количество добавляемых серий. Практический максимум определяется читаемостью диаграммы и доступной памяти вашего приложения.

**Что делать, если столбцы в кластере слишком близко расположены или слишком далеко друг от друга?**

Отрегулируйте параметр **Gap Width** для этой серии (или её родительской группы серий). Увеличение значения расширяет промежуток между столбцами, а уменьшение делает их ближе друг к другу.