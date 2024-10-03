---
title: Серии графиков
type: docs
url: /ru/java/chart-series/
keywords: "Серии графиков, цвет серии, презентация PowerPoint, Java, Aspose.Slides для Java"
description: "Серии графиков в презентациях PowerPoint на Java"
---

Серия — это строка или столбец чисел, нанесенных на график.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить перекрытие серий графика**

С помощью свойства [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) вы можете задать, насколько бары и столбцы должны перекрываться на 2D-графике (диапазон: от -100 до 100). Это свойство применяется ко всем сериям родительской группы серий: это проекция соответствующего свойства группы. Следовательно, это свойство только для чтения.

Используйте свойство `ParentSeriesGroup.Overlap`, которое имеет доступ для записи/чтения, чтобы установить желаемое значение для `Overlap`.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Добавьте кластерный столбчатый график на слайд.
1. Получите доступ к первой серии графика.
1. Получите доступ к `ParentSeriesGroup` серии графика и задайте желаемое значение перекрытия для серии.
1. Запишите измененную презентацию в файл PPTX.

Этот код на Java показывает, как установить перекрытие для серии графика:

```java
Presentation pres = new Presentation();
try {
    // Добавляет график
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
Aspose.Slides для Java позволяет изменить цвет серии следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Добавьте график на слайд.
1. Получите доступ к серии, цвет которой вы хотите изменить.
1. Установите предпочитаемый тип заливки и цвет заливки.
1. Сохраните измененную презентацию.

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
Aspose.Slides для Java позволяет изменить цвет категории серии следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Добавьте график на слайд.
1. Получите доступ к категории серии, цвет которой вы хотите изменить.
1. Установите предпочитаемый тип заливки и цвет заливки.
1. Сохраните измененную презентацию.

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

По умолчанию имена легенд для графика — это содержимое ячеек над каждой колонкой или строкой данных. 

В нашем примере (образец изображения), 

* столбцы — это *Серия 1, Серия 2,* и *Серия 3*;
* строки — это *Категория 1, Категория 2, Категория 3,* и *Категория 4.* 

Aspose.Slides для Java позволяет обновлять или изменять имя серии в данных графика и легенде. 

Этот код на Java показывает, как изменить имя серии в данных графика `ChartDataWorkbook`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("Новое имя");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Этот код на Java показывает, как изменить имя серии в ее легенде через `Series`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("Новое имя");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установить цвет заливки серии графика**

Aspose.Slides для Java позволяет установить автоматический цвет заливки для серий графиков внутри области построения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте график с данными по умолчанию на основе вашего предпочтительного типа (в примере ниже мы использовали `ChartType.ClusteredColumn`).
1. Получите доступ к серии графика и установите цвет заливки на автоматический.
1. Сохраните презентацию в файл PPTX.

Этот код на Java показывает, как установить автоматический цвет заливки для серии графика:

```java
Presentation pres = new Presentation();
try {
    // Создает кластерный столбчатый график
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Устанавливает формат заливки серии на автоматический
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

## **Установить инвертированный цвет заливки серий графиков**
Aspose.Slides позволяет установить инвертированный цвет заливки для серий графиков внутри области построения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте график с данными по умолчанию на основе вашего предпочтительного типа (в примере ниже мы использовали `ChartType.ClusteredColumn`).
1. Получите доступ к серии графика и установите цвет заливки на инвертированный.
1. Сохраните презентацию в файл PPTX.

Этот код на Java демонстрирует операцию:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Добавляет новые серии и категории
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Серия 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Категория 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Категория 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Категория 3"));

    // Берет первую серию графика и заполняет ее данные.
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

## **Установить инвертирование серий при отрицательном значении**
Aspose.Slides позволяет установить инвертирование через свойства `IChartDataPoint.InvertIfNegative` и `ChartDataPoint.InvertIfNegative`. Когда инверсия задана с помощью этих свойств, точка данных инвертирует свои цвета, когда она получает отрицательное значение. 

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

## **Очистить данные для конкретных точек данных**
Aspose.Slides для Java позволяет очистить данные `DataPoints` для конкретной серии графиков таким образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Получите ссылку на график по его индексу.
4. Переберите все `DataPoints` графика и установите `XValue` и `YValue` в null.
5. Очистите все `DataPoints` для конкретной серии графиков.
6. Запишите измененную презентацию в файл PPTX.

Этот код на Java демонстрирует операцию:

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

## **Установить ширину зазора для серии**
Aspose.Slides для Java позволяет установить ширину зазора серии с помощью свойства **`GapWidth`** таким образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте график с данными по умолчанию.
4. Получите доступ к любой серии графика.
5. Установите свойство `GapWidth`.
6. Запишите измененную презентацию в файл PPTX.

Этот код на Java показывает, как установить ширину зазора для серии:

```java
// Создает пустую презентацию 
Presentation pres = new Presentation();
try {
    // Получает первый слайд презентации
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавляет график с данными по умолчанию
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Устанавливает индекс листа данных графика
    int defaultWorksheetIndex = 0;
    
    // Получает рабочую книгу данных графика
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Добавляет серии
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Серия 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Серия 2"), chart.getType());
    
    // Добавляет категории
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Категория 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Категория 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Категория 3"));
    
    // Берет вторую серию графика
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