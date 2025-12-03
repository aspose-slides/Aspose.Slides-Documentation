---
title: Управление маркерами данных диаграммы в презентациях с помощью Java
linktitle: Маркер данных
type: docs
url: /ru/java/chart-data-marker/
keywords:
- диаграмма
- точка данных
- маркер
- параметры маркера
- размер маркера
- тип заливки
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как настраивать маркеры данных диаграммы в Aspose.Slides для Java, повышая воздействие презентаций в форматах PPT и PPTX с помощью ясных примеров кода Java."
---

## **Настройка параметров маркеров диаграммы**
Маркеры можно задавать для точек данных диаграммы внутри определённых рядов. Чтобы установить параметры маркеров диаграммы, выполните следующие действия:

- Создать объект класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Создать диаграмму по умолчанию.
- Установить изображение.
- Получить первый ряд диаграммы.
- Добавить новую точку данных.
- Сохранить презентацию на диск.

В приведённом ниже примере параметры маркеров диаграммы заданы на уровне точек данных.
```java
// Создание пустой презентации
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Создание диаграммы по умолчанию
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Получение индекса листа данных диаграммы по умолчанию
    int defaultWorksheetIndex = 0;
    
    // Получение листа данных диаграммы
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Удаление демонстрационной серии
    chart.getChartData().getSeries().clear();
    
    // Добавление новой серии
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Загрузка изображения 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Загрузка изображения 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Получение первой серии диаграммы
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Добавление новой точки (1:3) туда.
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
    
    // Изменение маркера серии диаграммы
    series.getMarker().setSize(15);
    
    // Сохранение презентации с диаграммой
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **ЧаВо**

**Какие формы маркеров доступны из коробки?**

Доступны стандартные формы (круг, квадрат, ромб, треугольник и т.д.); список определяется классом [MarkerStyleType](https://reference.aspose.com/slides/java/com.aspose.slides/markerstyletype/). Если требуется нестандартная форма, используйте маркер с заполнением изображением для имитации пользовательского визуала.

**Сохраняются ли маркеры при экспорте диаграммы в изображение или SVG?**

Да. При рендеринге диаграмм в [raster formats](/slides/ru/java/convert-powerpoint-to-png/) или сохранении [shapes as SVG](/slides/ru/java/render-a-slide-as-an-svg-image/), маркеры сохраняют свой внешний вид и настройки, включая размер, заливку и контур.