---
title: Управление данными серии диаграммы в презентациях на Java
linktitle: Серии данных
type: docs
url: /ru/java/chart-series/
keywords:
- серии диаграмм
- перекрытие серий
- цвет серии
- цвет категории
- имя серии
- точка данных
- промежуток серии
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм в Java для PowerPoint (PPT/PPTX) с практическими примерами кода и лучшими практиками для улучшения ваших презентаций данных."
---

Ряд — это строка или столбец чисел, отображённых на диаграмме.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить перекрытие серий диаграммы**

С помощью свойства [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) вы можете указать степень перекрытия столбцов и гистограмм на 2D-диаграмме (диапазон: -100 до 100). Это свойство применяется ко всем сериям родительской группы серий: это проекция соответствующего свойства группы. Следовательно, свойство только для чтения. 

Используйте свойство `ParentSeriesGroup.Overlap` с чтением/записью, чтобы задать требуемое значение для `Overlap`. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Добавьте сгруппированную столбчатую диаграмму на слайд.
1. Получите доступ к первой серии диаграммы.
1. Получите доступ к `ParentSeriesGroup` серии диаграммы и задайте требуемое значение перекрытия.
1. Сохраните изменённую презентацию в файл PPTX.

Этот код на Java показывает, как установить перекрытие для серии диаграммы:
```java
Presentation pres = new Presentation();
try {
    // Добавляет диаграмму
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Устанавливает перекрытие серии
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Записывает файл презентации на диск
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Изменить цвет серии**

Aspose.Slides for Java позволяет изменить цвет серии следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Добавьте диаграмму на слайд.
1. Получите доступ к серии, цвет которой необходимо изменить.
1. Установите требуемый тип заливки и цвет заливки.
1. Сохраните изменённую презентацию.

Этот код на Java показывает, как изменить цвет серии:
```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Изменить цвет категории серии**

Aspose.Slides for Java позволяет изменить цвет категории серии следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Добавьте диаграмму на слайд.
1. Получите доступ к категории серии, цвет которой необходимо изменить.
1. Установите требуемый тип заливки и цвет заливки.
1. Сохраните изменённую презентацию.

Этот код на Java показывает, как изменить цвет категории серии:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Изменить имя серии** 

По умолчанию имена в легенде диаграммы берутся из содержимого ячеек над каждым столбцом или строкой данных. 

В нашем примере (пример изображения),

* столбцы — *Series 1, Series 2,* и *Series 3*; * строки — *Category 1, Category 2, Category 3,* и *Category 4.* 

Aspose.Slides for Java позволяет обновлять или изменять имя серии в данных диаграммы и в легенде. 

Этот код на Java показывает, как изменить имя серии в данных диаграммы `ChartDataWorkbook`:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Этот код на Java показывает, как изменить имя серии в легенде через`Series`:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить цвет заливки серии диаграммы**

Aspose.Slides for Java позволяет установить автоматический цвет заливки серии диаграммы в области построения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию, выбрав предпочтительный тип (в примере ниже использовался `ChartType.ClusteredColumn`).
1. Получите доступ к серии диаграммы и установите цвет заливки в Automatic.
1. Сохраните презентацию в файл PPTX.

Этот код на Java показывает, как установить автоматический цвет заливки для серии диаграммы:
```java
Presentation pres = new Presentation();
try {
    // Создает сгруппированную столбчатую диаграмму
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Устанавливает автоматический формат заливки серии
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Записывает файл презентации на диск
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить инвертированный цвет заливки для серии диаграммы**

Aspose.Slides позволяет установить инвертированный цвет заливки для серии диаграммы в области построения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию, выбрав предпочтительный тип (в примере ниже использовался `ChartType.ClusteredColumn`).
1. Получите доступ к серии диаграммы и установите цвет заливки в invert.
1. Сохраните презентацию в файл PPTX.

Этот код демонстрирует операцию:
```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Добавляет новые серии и категории
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Получает первую серию диаграммы и заполняет её данные.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить инвертирование серии при отрицательном значении**

Aspose.Slides позволяет задавать инвертирование через свойства `IChartDataPoint.InvertIfNegative` и `ChartDataPoint.InvertIfNegative`. При установке инвертирования с помощью этих свойств точка данных изменяет свои цвета при получении отрицательного значения. 

Этот код на Java демонстрирует операцию:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Очистить данные конкретной точки**

Aspose.Slides for Java позволяет очистить данные `DataPoints` для конкретной серии диаграммы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Получите ссылку на диаграмму по её индексу.
4. Пройдите по всем `DataPoints` диаграммы и задайте `XValue` и `YValue` как null.
5. Очистите все`DataPoints` для конкретной серии диаграммы.
6. Запишите изменённую презентацию в файл PPTX.

Этот код демонстрирует операцию:
```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить ширину промежутка серии**

Aspose.Slides for Java позволяет установить ширину промежутка серии через свойство **`GapWidth`** следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Добавьте диаграмму с данными по умолчанию.
1. Получите доступ к любой серии диаграммы.
1. Задайте свойство `GapWidth`.
1. Запишите изменённую презентацию в файл PPTX.

Этот код на Java показывает, как установить ширину промежутка серии:
```java
// Создает пустую презентацию 
Presentation pres = new Presentation();
try {
    // Получает первый слайд презентации
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавляет диаграмму с данными по умолчанию
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Устанавливает индекс листа данных диаграммы
    int defaultWorksheetIndex = 0;
    
    // Получает рабочий лист данных диаграммы
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Добавляет серии
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Добавляет категории
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Получает вторую серию диаграммы
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
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
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Существует ли ограничение на количество серий, которые может содержать одна диаграмма?**

Aspose.Slides не накладывает фиксированного ограничения на количество добавляемых серий. Практический предел определяется читаемостью диаграммы и объёмом памяти, доступным вашему приложению.

**Что делать, если столбцы внутри кластера слишком близко расположены или наоборот слишком далеко друг от друга?**

Отрегулируйте значение `GapWidth` для этой серии (или её родительской группы серий). Увеличение значения расширяет пространство между столбцами, а уменьшение — сближает их.