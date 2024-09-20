---
title: 3D График
type: docs
url: /java/3d-chart/
---

## **Установка свойств RotationX, RotationY и DepthPercents для 3D графика**
Aspose.Slides для Java предоставляет простой API для установки этих свойств. Эта статья поможет вам установить различные свойства, такие как **X, Y Rotation, DepthPercents** и т. д. Пример кода применяет установку вышеупомянутых свойств.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите первый слайд.
1. Добавьте график с умолчательными данными.
1. Установите свойства Rotation3D.
1. Запишите измененную презентацию в файл PPTX.

```java
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавьте график с умолчательными данными
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Установка индекса рабочего листа графика
    int defaultWorksheetIndex = 0;
    
    // Получение рабочего листа данных графика
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Добавление серий
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Серия 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Серия 2"), chart.getType());
    
    // Добавление категорий
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Категория 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Категория 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Категория 3"));
    
    // Установка свойств Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Получите вторую серию графика
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Теперь заполняем данные серии
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Установка значения OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Запишите презентацию на диск
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```