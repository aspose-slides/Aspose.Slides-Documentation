---
title: 3D-диаграмма
type: docs
url: /ru/nodejs-java/3d-chart/
---

## **Установить свойства RotationX, RotationY и DepthPercents у 3D‑диаграммы**

Aspose.Slides for Node.js via Java предоставляет простой API для установки этих свойств. В этой статье показано, как задать различные свойства, такие как **X‑ и Y‑поворот, DepthPercents** и т. д. Пример кода демонстрирует установку перечисленных выше свойств.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Получить первый слайд.
3. Добавить диаграмму с данными по умолчанию.
4. Задать свойства Rotation3D.
5. Сохранить изменённую презентацию в файл PPTX.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Доступ к первому слайду
    var slide = pres.getSlides().get_Item(0);
    // Добавить диаграмму с данными по умолчанию
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // Установка индекса листа данных диаграммы
    var defaultWorksheetIndex = 0;
    // Получение листа данных диаграммы
    var fact = chart.getChartData().getChartDataWorkbook();
    // Добавить серию
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Добавить категории
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Установить свойства Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // Получить вторую серию диаграммы
    var series = chart.getChartData().getSeries().get_Item(1);
    // Сейчас заполняем данные серии
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Установить значение перекрытия
    series.getParentSeriesGroup().setOverlap(100);
    // Сохранить презентацию на диск
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100 % Stacked Column 3D, а также связанные 3D‑типы, доступные через перечисление [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Для актуального списка см. члены [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) в справочнике API установленной версии.

**Можно ли получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение через [chart API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) или [render the entire slide](/slides/ru/nodejs-java/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это удобно, когда нужен пиксель‑точный просмотр или требуется встроить диаграмму в документы, панели мониторинга или веб‑страницы без необходимости использования PowerPoint.

**Насколько производительно построение и рендеринг больших 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для лучших результатов минимизируйте 3D‑эффекты, избегайте тяжёлых текстур на стенах и областях построения, по возможности ограничьте количество точек данных в серии и рендерите в подходящем размере вывода (разрешение и размеры), соответствующем требуемому отображению или печати.