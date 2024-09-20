---
title: 3D Чарт
type: docs
url: /androidjava/3d-chart/
---

## **Установите свойства RotationX, RotationY и DepthPercents для 3D Чарта**
Aspose.Slides для Android на Java предоставляет простой API для установки этих свойств. Эта статья поможет вам установить различные свойства, такие как **X,Y Вращение, DepthPercents** и т.д. Пример кода показывает, как установить вышеуказанные свойства.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите первый слайд.
1. Добавьте чарт с данными по умолчанию.
1. Установите свойства Rotation3D.
1. Запишите измененную презентацию в файл PPTX.

```java
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавьте чарт с данными по умолчанию
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Установка индекса листа данных чарта
    int defaultWorksheetIndex = 0;
    
    // Получение рабочего листа данных чарта
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Добавление рядов
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Ряд 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Ряд 2"), chart.getType());
    
    // Добавление категорий
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Категория 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Категория 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Категория 3"));
    
    // Установка свойств Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Получаем вторую серию чарта
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