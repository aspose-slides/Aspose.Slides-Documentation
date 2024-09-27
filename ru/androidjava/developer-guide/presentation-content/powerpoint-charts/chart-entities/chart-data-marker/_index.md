---
title: Маркер данных диаграммы
type: docs
url: /ru/androidjava/chart-data-marker/
---

## **Настройка параметров маркера диаграммы**
Маркер можно установить на точки данных диаграммы внутри определенных серий. Чтобы установить параметры маркера диаграммы, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Создайте стандартную диаграмму.
- Установите изображение.
- Возьмите первую серию диаграммы.
- Добавьте новую точку данных.
- Сохраните презентацию на диск.

В приведенном ниже примере мы установили параметры маркера диаграммы на уровне точек данных.

```java
// Создание пустой презентации
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Создание стандартной диаграммы
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Получение индекса рабочего листа с данными диаграммы
    int defaultWorksheetIndex = 0;
    
    // Получение рабочего листа с данными диаграммы
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Удаление демонстрационной серии
    chart.getChartData().getSeries().clear();
    
    // Добавление новой серии
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Серия 1"), chart.getType());

    // Загрузка изображения 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Загрузка изображения 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Получение первой серии диаграммы
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Добавление новой точки (1:3) там.
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
    
    // Изменение размера маркера серии диаграммы
    series.getMarker().setSize(15);
    
    // Сохранение презентации с диаграммой
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```