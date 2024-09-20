---
title: Трендовая линия
type: docs
url: /androidjava/trend-line/
---

## **Добавить трендовую линию**
Aspose.Slides для Android через Java предоставляет простой API для управления различными трендовыми линиями в диаграммах:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию вместе с любым желаемым типом (в этом примере используется ChartType.ClusteredColumn).
1. Добавьте экспоненциальную трендовую линию для серии диаграммы 1.
1. Добавьте линейную трендовую линию для серии диаграммы 1.
1. Добавьте логарифмическую трендовую линию для серии диаграммы 2.
1. Добавьте скользящую среднюю трендовую линию для серии диаграммы 2.
1. Добавьте полиномиальную трендовую линию для серии диаграммы 3.
1. Добавьте степенную трендовую линию для серии диаграммы 3.
1. Запишите модифицированную презентацию в файл PPTX.

Следующий код используется для создания диаграммы с трендовыми линиями.

```java
// Создание экземпляра класса Presentation
Presentation pres = new Presentation();
try {
    // Создание диаграммы столбчатого типа
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Добавление экспоненциальной трендовой линии для серии диаграммы 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Добавление линейной трендовой линии для серии диаграммы 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Добавление логарифмической трендовой линии для серии диаграммы 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("Новая логарифмическая трендовая линия");
    
    // Добавление скользящей средней трендовой линии для серии диаграммы 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("Новое имя трендовой линии");
    
    // Добавление полиномиальной трендовой линии для серии диаграммы 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Добавление степенной трендовой линии для серии диаграммы 3
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Сохранение презентации
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавить пользовательскую линию**
Aspose.Slides для Android через Java предоставляет простой API для добавления пользовательских линий в диаграмму. Чтобы добавить простую линию на выделенный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)
- Получите ссылку на слайд, используя его индекс
- Создайте новую диаграмму, используя метод AddChart, предоставленный объектом Shapes
- Добавьте автофигура типа линия, используя метод AddAutoShape, предоставленный объектом Shapes
- Установите цвет линий фигуры.
- Запишите модифицированную презентацию в файл PPTX

Следующий код используется для создания диаграммы с пользовательскими линиями.

```java
// Создание экземпляра класса Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```