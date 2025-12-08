---
title: Круговая диаграмма
type: docs
url: /ru/nodejs-java/pie-chart/
---

## **Параметры вторичного построения для диаграмм 'Круг в круге' и 'Бар в круге'**
Aspose.Slides for Node.js via Java теперь поддерживает параметры вторичного построения для диаграмм 'Круг в круге' или 'Бар в круге'. В этой статье мы покажем, как задать эти параметры с помощью Aspose.Slides. Чтобы задать свойства, выполните следующее:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Добавьте диаграмму на слайд.
1. Укажите параметры вторичного построения диаграммы.
1. Сохраните презентацию на диск.

В приведённом ниже примере мы задали различные свойства диаграммы 'Круг в круге'.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Добавить диаграмму на слайд
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // Установить разные свойства
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // Сохранить презентацию на диск
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить автоматические цвета секторов круговой диаграммы**
Aspose.Slides for Node.js via Java предоставляет простой API для установки автоматических цветов секторов круговой диаграммы. Пример кода применяет указанные выше свойства.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Добавьте диаграмму с данными по умолчанию.
1. Установите заголовок диаграммы.
1. Установите отображение значений для первой серии.
1. Установите индекс листа данных диаграммы.
1. Получите лист данных диаграммы.
1. Удалите сгенерированные по умолчанию серии и категории.
1. Добавьте новые категории.
1. Добавьте новую серию.

Сохраните изменённую презентацию в файл PPTX.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Добавить диаграмму с данными по умолчанию
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Установка заголовка диаграммы
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Установить отображение значений для первой серии
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Установка индекса листа данных диаграммы
    var defaultWorksheetIndex = 0;
    // Получение листа данных диаграммы
    var fact = chart.getChartData().getChartDataWorkbook();
    // Удалить автоматически сгенерированные серии и категории
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Добавление новых категорий
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Добавление новой серии
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Заполнение данных серии
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Поддерживаются ли варианты 'Круг в круге' и 'Бар в круге'?**

Да, библиотека [supports](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) вторичное построение для круговых диаграмм, включая типы 'Круг в круге' и 'Бар в круге'.

**Могу ли я экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [export the chart itself as an image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (например, PNG) без всей презентации.