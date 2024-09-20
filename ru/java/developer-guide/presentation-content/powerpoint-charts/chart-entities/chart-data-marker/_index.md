---
title: Маркеры данных графика
type: docs
url: /java/chart-data-marker/
---

## **Установка параметров маркера графика**
Маркеры могут быть установлены на точках данных графика внутри определённых серий. Чтобы установить параметры маркера графика, выполните следующие шаги:

- Создайте объект класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Создайте график по умолчанию.
- Установите изображение.
- Получите первую серию графика.
- Добавьте новую точку данных.
- Запишите презентацию на диск.

В приведённом ниже примере мы установили параметры маркера графика на уровне точек данных.

```java
// Создание пустой презентации
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Создание графика по умолчанию
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Получение индекса рабочего листа данных графика по умолчанию
    int defaultWorksheetIndex = 0;
    
    // Получение рабочего листа данных графика
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Удаление демонстрационной серии
    chart.getChartData().getSeries().clear();
    
    // Добавление новой серии
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Серия 1"), chart.getType());

    // Загрузка изображения 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Загрузка изображения 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Получение первой серии графика
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Добавление новой точки (1:3).
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // Изменение маркера серии графика
    series.getMarker().setSize(15);
    
    // Сохранение презентации с графиком
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```