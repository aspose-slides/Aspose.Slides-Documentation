---
title: Маркер данных диаграммы
type: docs
url: /ru/nodejs-java/chart-data-marker/
---

## **Настройка параметров маркеров диаграммы**

Маркеры можно задавать для точек данных диаграммы в конкретных рядах. Чтобы настроить параметры маркеров диаграммы, выполните следующие шаги:

- Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Создать диаграмму по умолчанию.
- Установить изображение.
- Получить первый ряд диаграммы.
- Добавить новую точку данных.
- Записать презентацию на диск.

В приведённом ниже примере мы настроили параметры маркеров диаграммы на уровне точек данных.
```javascript
// Создание пустой презентации
var pres = new aspose.slides.Presentation();
try {
    // Доступ к первому слайду
    var slide = pres.getSlides().get_Item(0);
    // Создание диаграммы по умолчанию
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // Получение индекса листа данных диаграммы по умолчанию
    var defaultWorksheetIndex = 0;
    // Получение листа данных диаграммы
    var fact = chart.getChartData().getChartDataWorkbook();
    // Удаление демонстрационной серии
    chart.getChartData().getSeries().clear();
    // Добавление новой серии
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // Загрузка изображения 1
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // Загрузка изображения 2
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // Получение первой серии диаграммы
    var series = chart.getChartData().getSeries().get_Item(0);
    // Добавление новой точки (1:3) туда.
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // Изменение маркера серии диаграммы
    series.getMarker().setSize(15);
    // Сохранение презентации с диаграммой
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Какие формы маркеров доступны из коробки?**

Стандартные формы доступны (круг, квадрат, ромб, треугольник и т. д.); список определяется перечислением [MarkerStyleType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markerstyletype/). Если вам нужна нестандартная форма, используйте маркер с заполнением изображением, чтобы имитировать пользовательскую визуализацию.

**Сохраняются ли маркеры при экспорте диаграммы в изображение или SVG?**

Да. При рендеринге диаграмм в [растровые форматы](/slides/ru/nodejs-java/convert-powerpoint-to-png/) или сохранении [форм в SVG](/slides/ru/nodejs-java/render-a-slide-as-an-svg-image/) маркеры сохраняют свой внешний вид и настройки, включая размер, заливку и контур.