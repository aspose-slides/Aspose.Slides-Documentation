---
title: Линия тренда
type: docs
url: /java/trend-line/
---

## **Добавить линию тренда**
Aspose.Slides для Java предоставляет простой API для управления различными линиями тренда графиков:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте график с данными по умолчанию вместе с любым из желаемых типов (в этом примере используется ChartType.ClusteredColumn).
1. Добавление экспоненциальной линии тренда для серии графика 1.
1. Добавление линейной линии тренда для серии графика 1.
1. Добавление логарифмической линии тренда для серии графика 2.
1. Добавление скользящей средней линии тренда для серии графика 2.
1. Добавление полиномиальной линии тренда для серии графика 3.
1. Добавление степенной линии тренда для серии графика 3.
1. Запишите измененную презентацию в файл PPTX.

Следующий код используется для создания графика с линиями тренда.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Создание графика с колонками
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Добавление экспоненциальной линии тренда для серии графика 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Добавление линейной линии тренда для серии графика 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    // Добавление логарифмической линии тренда для серии графика 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("Новая логарифмическая линия тренда");
    
    // Добавление линии тренда скользящей средней для серии графика 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("Новое имя линии тренда");
    
    // Добавление полиномиальной линии тренда для серии графика 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Добавление степенной линии тренда для серии графика 3
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Сохранение презентации
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавить настраиваемую линию**
Aspose.Slides для Java предоставляет простой API для добавления настраиваемых линий в график. Чтобы добавить простую линию на выбранный слайд презентации, следуйте следующим шагам:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)
- Получите ссылку на слайд, используя его индекс
- Создайте новый график, используя метод AddChart, предоставляемый объектом Shapes
- Добавьте фигуру типа линия, используя метод AddAutoShape, предоставляемый объектом Shapes
- Установите цвет линий фигуры.
- Запишите измененную презентацию в файл PPTX

Следующий код используется для создания графика с настраиваемыми линиями.

```java
// Создайте экземпляр класса Presentation
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