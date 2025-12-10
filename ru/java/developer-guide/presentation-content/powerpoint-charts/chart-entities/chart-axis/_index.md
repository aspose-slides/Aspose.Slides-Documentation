---
title: "Настройка осей диаграмм в презентациях с использованием Java"
linktitle: "Ось диаграммы"
type: docs
url: /ru/java/chart-axis/
keywords:
  - ось диаграммы
  - вертикальная ось
  - горизонтальная ось
  - настройка оси
  - управление осью
  - управление осью
  - свойства оси
  - максимальное значение
  - минимальное значение
  - линия оси
  - формат даты
  - заголовок оси
  - позиция оси
  - PowerPoint
  - презентация
  - Java
  - Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides для Java для настройки осей диаграмм в презентациях PowerPoint для отчетов и визуализации."
---

## **Получить максимальные значения на вертикальной оси диаграмм**
Aspose.Slides for Java позволяет получать минимальные и максимальные значения на вертикальной оси. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Добавьте диаграмму с данными по умолчанию.
1. Получите фактическое максимальное значение оси.
1. Получите фактическое минимальное значение оси.
1. Получите фактическую большую единицу оси.
1. Получите фактическую малую единицу оси.
1. Получите фактическую шкалу большой единицы оси.
1. Получите фактическую шкалу малой единицы оси.

Этот пример кода — реализация указанных шагов — показывает, как получить необходимые значения в Java:
```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// Сохраняет презентацию
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **Переключить данные между осями**
Aspose.Slides позволяет быстро поменять местами данные между осями — данные, отображаемые по вертикальной оси (y-axis), перемещаются на горизонтальную ось (x-axis) и наоборот.

Этот код на Java показывает, как выполнить задачу перестановки данных между осями в диаграмме:
```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Переключает строки и столбцы
	chart.getChartData().switchRowColumn();

	// Сохраняет презентацию
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **Отключить вертикальную ось для линейных диаграмм**

Этот код на Java показывает, как скрыть вертикальную ось в линейной диаграмме:
```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getVerticalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **Отключить горизонтальную ось для линейных диаграмм**

Этот код показывает, как скрыть горизонтальную ось в линейной диаграмме:
```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getHorizontalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **Изменить категориальную ось**

С помощью свойства **CategoryAxisType** можно указать желаемый тип категориальной оси (**date** или **text**). Этот код на Java демонстрирует операцию: 
```java
Presentation presentation = new Presentation("ExistingChart.pptx");
try {
	IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
	chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
	chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
	chart.getAxes().getHorizontalAxis().setMajorUnit(1);
	chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);
	presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```


## **Установить формат даты для значений категориальной оси**
Aspose.Slides for Java позволяет установить формат даты для значения категориальной оси. Операция продемонстрирована в этом коде на Java:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
	
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static String convertToOADate(GregorianCalendar date) throws ParseException
{
    double oaDate;
    SimpleDateFormat myFormat = new SimpleDateFormat("dd MM yyyy");
    java.util.Date baseDate = myFormat.parse("30 12 1899");
    Long days = TimeUnit.DAYS.convert(date.getTimeInMillis() - baseDate.getTime(), TimeUnit.MILLISECONDS);
    oaDate = (double) days + ((double) date.get(Calendar.HOUR_OF_DAY) / 24) + ((double) date.get(Calendar.MINUTE) / (60 * 24)) + ((double) date.get(Calendar.SECOND) / (60 * 24 * 60));
    return String.valueOf(oaDate);
}
```


## **Установить угол вращения заголовка оси диаграммы**
Aspose.Slides for Java позволяет установить угол вращения заголовка оси диаграммы. Этот код на Java демонстрирует операцию:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить позицию оси на категориальной или оси значений**
Aspose.Slides for Java позволяет задать позицию оси на категориальной или оси значений. Этот код на Java показывает, как выполнить задачу:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Включить отображение подписи единицы измерения на оси значений диаграммы**
Aspose.Slides for Java позволяет настроить диаграмму так, чтобы отображалась подпись единицы измерения на оси значений. Этот код на Java демонстрирует операцию:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Часто задаваемые вопросы**

**Как установить значение, при котором одна ось пересекает другую (пересечение осей)?**

Оси предоставляют [настройку пересечения](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-): вы можете выбрать пересечение в нуле, на максимальной категории/значении или в конкретном числовом значении. Это полезно для смещения оси X вверх или вниз или для выделения базовой линии.

**Как расположить подписи делений относительно оси (внутри, снаружи, рядом)?**

Установите [позицию подписи](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) в значение "cross", "outside" или "inside". Это влияет на читаемость и помогает экономить место, особенно в небольших диаграммах.