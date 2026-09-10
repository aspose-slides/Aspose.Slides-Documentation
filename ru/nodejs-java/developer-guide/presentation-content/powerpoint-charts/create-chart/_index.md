---
title: Создание или обновление диаграмм PowerPoint презентаций на JavaScript
linktitle: Создание или обновление диаграмм
type: docs
weight: 10
url: /ru/nodejs-java/create-chart/
keywords:
- добавить диаграмму
- создать диаграмму
- редактировать диаграмму
- изменить диаграмму
- обновить диаграмму
- диаграмма рассеяния
- круговая диаграмма
- линейная диаграмма
- диаграмма дерева
- диаграмма акций
- диаграмма ящик с усами
- воронкообразная диаграмма
- лучевая диаграмма
- гистограмма
- радиальная диаграмма
- многоуровневая диаграмма
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Создавайте и настраивайте диаграммы в презентациях PowerPoint с помощью Aspose.Slides для Node.js. Добавляйте, форматируйте и редактируйте диаграммы, используя практические примеры кода на JavaScript."
---
## **Обзор**

В этой статье представлено полное руководство по созданию и настройке диаграмм с помощью Aspose.Slides. Вы узнаете, как программно добавить диаграмму на слайд, заполнить её данными и применить различные параметры форматирования, чтобы соответствовать вашим конкретным требованиям к дизайну. На протяжении всей статьи подробно приводятся примеры кода, иллюстрирующие каждый шаг — от инициализации презентации и объекта диаграммы до настройки рядов, осей и легенд. Следуя этому руководству, вы получите прочное понимание того, как интегрировать динамическое создание диаграмм в свои приложения, упростив процесс создания презентаций, основанных на данных.

## **Создание диаграммы**

Диаграммы помогают быстро визуализировать данные и получить инсайты, которые могут быть неочевидны из таблицы или электронной таблицы.

**Почему создают диаграммы?**

С помощью диаграмм вы можете:

* агрегировать, конденсировать или суммировать большие объёмы данных на одном слайде презентации
* выявлять закономерности и тренды в данных
* определять направление и динамику данных во времени или относительно конкретной единицы измерения
* обнаруживать выбросы, аномалии, отклонения, ошибки, бессмысленные данные и т.п.
* эффективно представлять сложные данные

В PowerPoint диаграммы создаются через функцию *Insert*, которая предоставляет шаблоны для разработки различных типов диаграмм. С Aspose.Slides вы можете создавать как обычные диаграммы (на основе популярных типов), так и пользовательские диаграммы.

{{% alert color="info" title="Note" %}}

Для создания диаграмм используйте класс [ChartType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/). Поля этого класса соответствуют различным типам диаграмм.

{{% /alert %}}

### **Создание гистограмм с кластеризованными столбцами**

В этом разделе объясняется, как создать гистограмму с кластеризованными столбцами с помощью Aspose.Slides. Вы научитесь инициализировать презентацию, добавить диаграмму и настроить её элементы, такие как заголовок, данные, ряды, категории и стиль. Следуйте инструкциям ниже, чтобы увидеть, как генерируется стандартная гистограмма с кластеризованными столбцами:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с некоторыми данными и укажите тип `ChartType.ClusteredColumn`.
4. Добавьте заголовок к диаграмме.
5. Получите доступ к листу данных диаграммы.
6. Очистите все строки и категории по умолчанию.
7. Добавьте новые ряды и категории.
8. Добавьте новые данные диаграммы для рядов.
9. Примените цвет заливки к рядам диаграммы.
10. Добавьте подписи к рядам диаграммы.
11. Сохраните изменённую презентацию в файл PPTX.

Этот код C# демонстрирует, как создать гистограмму с кластеризованными столбцами:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создает экземпляр класса презентации, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Доступ к первому слайду
    var sld = pres.getSlides().get_Item(0);
    // Добавляет диаграмму с её данными по умолчанию
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Устанавливает заголовок диаграммы
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    // Устанавливает отображение значений для первого ряда
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Устанавливает индекс листа данных диаграммы
    var defaultWorksheetIndex = 0;
    // Получает рабочий лист данных диаграммы
    var fact = chart.getChartData().getChartDataWorkbook();
    // Удаляет сгенерированные по умолчанию ряды и категории
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Добавляет новые ряды
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Добавляет новые категории
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Получает первый ряд диаграммы
    var series = chart.getChartData().getSeries().get_Item(0);
    // Заполняет данные ряда
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Устанавливает цвет заливки для ряда
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Получает второй ряд диаграммы
    series = chart.getChartData().getSeries().get_Item(1);
    // Заполняет данные ряда
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Устанавливает цвет заливки для ряда
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Создает пользовательские подписи для каждой категории нового ряда
    // Устанавливает первую подпись для отображения названия категории
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Отображает значение для третьей подписи
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Сохраняет презентацию с диаграммой
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Создание диаграмм рассеяния**

Диаграммы рассеяния (также известные как scatter plot или графики x‑y) часто используются для поиска закономерностей или демонстрации корреляций между двумя переменными.

Используйте диаграмму рассеяния, когда:

* у вас есть парные числовые данные
* у вас две переменные, которые хорошо сочетаются друг с другом
* вы хотите выяснить, связаны ли две переменные
* у вас независимая переменная имеет несколько значений для зависимой переменной

1. Выполните шаги из раздела [Create Clustered Column Charts](#create-clustered-column-charts).
2. На третьем шаге добавьте диаграмму с данными и укажите тип диаграммы одним из следующих:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) — _Представляет диаграмму рассеяния с маркерами._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) — _Представляет диаграмму рассеяния, соединённую сглаженными линиями, с маркерами._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) — _Представляет диаграмму рассеяния, соединённую сглаженными линиями, без маркеров._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) — _Представляет диаграмму рассеяния, соединённую прямыми линиями, с маркерами._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) — _Представляет диаграмму рассеяния, соединённую прямыми линиями, без маркеров._

Этот код JavaScript показывает, как создать диаграмму рассеяния с разными маркерами для каждого ряда:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создает экземпляр класса презентации, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает доступ к первому слайду
    var slide = pres.getSlides().get_Item(0);
    // Создает диаграмму по умолчанию
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Получает индекс листа данных диаграммы по умолчанию
    var defaultWorksheetIndex = 0;
    // Получает лист данных диаграммы
    var fact = chart.getChartData().getChartDataWorkbook();
    // Удаляет демонстрационный ряд
    chart.getChartData().getSeries().clear();
    // Добавляет новые ряды
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Получает первый ряд диаграммы
    var series = chart.getChartData().getSeries().get_Item(0);
    // Добавляет новую точку (1:3) в ряд
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Добавляет новую точку (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Изменяет тип ряда
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Изменяет маркер ряда диаграммы
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // Получает второй ряд диаграммы
    series = chart.getChartData().getSeries().get_Item(1);
    // Добавляет новую точку (5:2) туда
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // Добавляет новую точку (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // Добавляет новую точку (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // Добавляет новую точку (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // Изменяет маркер ряда диаграммы
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Создание круговых диаграмм**

Круговые диаграммы лучше всего использовать для демонстрации отношения части к целому, особенно когда данные содержат категориальные метки с числовыми значениями. Однако если в данных много частей или меток, стоит рассмотреть использование гистограммы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Pie](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/#Pie).
4. Получите доступ к рабочей книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/).
5. Очистите ряды и категории по умолчанию.
6. Добавьте новые ряды и категории.
7. Добавьте новые данные диаграммы для рядов.
8. Добавьте новые точки для диаграммы и примените пользовательские цвета к секторам круговой диаграммы.
9. Установите подписи для рядов.
10. Включите линии‑выноски для подписей рядов.
11. Установите угол поворота секторов круговой диаграммы.
12. Сохраните изменённую презентацию в файл PPTX.

Этот код JavaScript показывает, как создать круговую диаграмму:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создает экземпляр класса презентации, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает доступ к первому слайду
    var slides = pres.getSlides().get_Item(0);
    // Добавляет диаграмму с данными по умолчанию
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Устанавливает заголовок диаграммы
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Устанавливает отображение значений для первого ряда
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Устанавливает индекс листа данных диаграммы
    var defaultWorksheetIndex = 0;
    // Получает лист данных диаграммы
    var fact = chart.getChartData().getChartDataWorkbook();
    // Удаляет сгенерированные по умолчанию ряды и категории
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Добавляет новые категории
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Добавляет новые ряды
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Заполняет данные ряда
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Не работает в новой версии
    // Добавление новых точек и установка цвета сектора
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Устанавливает границу сектора
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    point.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Устанавливает границу сектора
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    point1.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Устанавливает границу сектора
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    point2.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));
    // Создает пользовательские подписи для каждой категории нового ряда
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // Отображает линии‑выноски для диаграммы
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Устанавливает угол поворота секторов круговой диаграммы
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Сохраняет презентацию с диаграммой
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Создание линейных диаграмм**

Линейные диаграммы (также известные как линейные графики) лучше всего использовать, когда необходимо продемонстрировать изменения значения во времени. С помощью линейной диаграммы можно одновременно сравнивать большой объём данных, отслеживать изменения и тренды, выделять аномалии в рядах данных и многое другое.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Line](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/#Line).
4. Получите доступ к рабочей книге данных диаграммы ([ChartDataWorkbook](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/)).
5. Очистите ряды и категории по умолчанию.
6. Добавьте новые ряды и категории.
7. Добавьте новые данные диаграммы для рядов.
8. Сохраните изменённую презентацию в файл PPTX.

Этот код JavaScript показывает, как создать линейную диаграмму:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

По умолчанию точки на линейной диаграмме соединяются сплошными прямыми линиями. Если вы хотите, чтобы точки соединялись пунктиром, укажите желаемый тип штриха следующим образом:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Создание иерархических диаграмм (Tree Map)**

Иерархические диаграммы (Tree Map) лучше всего подходят для отображения объёмов продаж, когда нужно показать относительный размер категорий данных и быстро привлечь внимание к элементам, вносящим большой вклад в каждую категорию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Treemap](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/#Treemap).
4. Получите доступ к рабочей книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/).
5. Очистите ряды и категории по умолчанию.
6. Добавьте новые ряды и категории.
7. Добавьте новые данные диаграммы для рядов.
8. Сохраните изменённую презентацию в файл PPTX.

Этот код JavaScript показывает, как создать иерархическую диаграмму:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // ветка 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // ветка 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Создание диаграмм «Акции» (Stock Charts)**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/#OpenHighLowClose).
4. Получите доступ к рабочей книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/).
5. Очистите ряды и категории по умолчанию.
6. Добавьте новые ряды и категории.
7. Добавьте новые данные диаграммы для рядов.
8. Укажите формат линий high‑low.
9. Сохраните изменённую презентацию в файл PPTX.

Этот код JavaScript показывает, как создать диаграмму «Акции»:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));
    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));
    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));
    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));
    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Создание диagrama «Box and Whisker»**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/#BoxAndWhisker).
4. Получите доступ к рабочей книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/).
5. Очистите ряды и категории по умолчанию.
6. Добавьте новые ряды и категории.
7. Добавьте новые данные диаграммы для рядов.
8. Сохраните изменённую презентацию в файл PPTX.

Этот код JavaScript показывает, как создать диаграмму «Box and Whisker»:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Создание воронкообразных диаграмм (Funnel Charts)**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Funnel](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/#Funnel).
4. Сохраните изменённую презентацию в файл PPTX.

Этот код JavaScript показывает, как создать воронкообразную диаграмму:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Создание лучевых диаграмм (Sunburst Charts)**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Sunburst](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/#Sunburst).
4. Сохраните изменённую презентацию в файл PPTX.

Этот код JavaScript показывает, как создать лучевую диаграмму:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // ветка 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // ветка 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Создание гистограмм (Histogram Charts)**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Histogram](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/#Histogram).
4. Получите доступ к рабочей книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/).
5. Очистите ряды и категории по умолчанию.
6. Добавьте новые ряды и категории.
7. Сохраните изменённую презентацию в файл PPTX.

Этот код JavaScript показывает, как создать гистограмму:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **Создание радиальных диаграмм (Radar Charts)**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными и укажите предпочтительный тип диаграммы ([ChartType.Radar](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/#Radar) в данном случае).
4. Сохраните изменённую презентацию в файл PPTX.

Этот код JavaScript показывает, как создать радиальную диаграмму:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Создание многоуровневых диаграмм (Multi-Category Charts)**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.ClusteredColumn](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/#ClusteredColumn).
4. Получите доступ к рабочей книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/).
5. Очистите ряды и категории по умолчанию.
6. Добавьте новые ряды и категории.
7. Добавьте новые данные диаграммы для рядов.
8. Сохраните изменённую презентацию в файл PPTX.

Этот код JavaScript показывает, как создать диаграмму с несколькими категориями:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));
    // Добавление серии
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Сохранить презентацию с диаграммой
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Создание карт (Map Charts)**

Картовые диаграммы визуализируют географические данные и помогают сравнивать значения по регионам.

Этот код JavaScript показывает, как создать картовую диаграмму:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Создание комбинированных диаграмм**

Комбинированная диаграмма (или combo chart) объединяет два и более типа диаграмм в одном графике. Такая диаграмма позволяет выделять, сравнивать или исследовать различия между двумя и более наборами данных, помогая выявлять взаимосвязи между ними.

![The combination chart](combination_chart.png)

Следующий код JavaScript показывает, как создать комбинированную диаграмму, изображённую выше, в презентации PowerPoint:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Установить заголовок диаграммы.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Установить легенду диаграммы.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Удалить сгенерированные по умолчанию ряды и категории.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Добавить новые категории.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Добавить первый ряд.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // Установить горизонтальную ось.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Установить вертикальную ось.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Установить цвет основных линий сетки вертикальной оси.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Установить вторичную горизонтальную ось.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Установить вторичную вертикальную ось.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **Обновление диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/), представляющего презентацию, содержащую диаграмму, которую нужно обновить.
2. Получите ссылку на слайд, используя его индекс.
3. Пройдите по всем фигурам, чтобы найти нужную диаграмму.
4. Получите доступ к листу данных диаграммы.
5. Измените ряд данных диаграммы, изменив значения ряда.
6. Добавьте новый ряд и заполните его данными.
7. Сохраните изменённую презентацию в файл PPTX.

Этот код JavaScript показывает, как обновить диаграмму:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Получить первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Получить диаграмму с данными по умолчанию
    var chart = sld.getShapes().get_Item(0);
    // Установка индекса листа данных диаграммы
    var defaultWorksheetIndex = 0;
    // Получение листа данных диаграммы
    var fact = chart.getChartData().getChartDataWorkbook();
    // Изменение названия категории диаграммы
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Получить первый ряд диаграммы
    var series = chart.getChartData().getSeries().get_Item(0);
    // Обновление данных ряда
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Изменение названия ряда
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Получить второй ряд диаграммы
    series = chart.getChartData().getSeries().get_Item(1);
    // Обновление данных ряда
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Изменение названия ряда
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Добавление нового ряда
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Получить третий ряд диаграммы
    series = chart.getChartData().getSeries().get_Item(2);
    // Заполнение данных ряда
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Сохранить презентацию с диаграммой
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Установка диапазона данных для диаграммы**

Чтобы задать диапазон данных для диаграммы, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/), представляющего презентацию, содержащую диаграмму.
2. Получите ссылку на слайд, используя его индекс.
3. Пройдите по всем фигурам, чтобы найти нужную диаграмму.
4. Получите доступ к данным диаграммы и задайте диапазон.
5. Сохраните изменённую презентацию в файл PPTX.

Этот код JavaScript показывает, как задать диапазон данных для диаграммы:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Использование маркеров по умолчанию в диаграммах**

При использовании маркеров по умолчанию каждый ряд диаграммы автоматически получает различный символ маркера.

Этот код JavaScript показывает, как автоматически задать маркер для ряда диаграммы:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Получить второй ряд диаграммы
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Сейчас заполняем данные ряда
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Какие типы диаграмм поддерживает Aspose.Slides?**

Aspose.Slides поддерживает широкий спектр [типов диаграмм](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/charttype/), включая столбчатые, линейные, круговые, площадные, точечные, гистограммы, радиальные и многие другие. Такая гибкость позволяет выбирать наиболее подходящий тип диаграммы для ваших задач визуализации данных.

**Как добавить новую диаграмму на слайд?**

Для добавления диаграммы сначала создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/), получите нужный слайд по индексу, а затем вызовите метод добавления диаграммы, указав тип диаграммы и начальные данные. Этот процесс интегрирует диаграмму напрямую в вашу презентацию.

**Как обновить данные, отображаемые в диаграмме?**

Вы можете обновить данные диаграммы, получив доступ к её рабочей книге данных ([ChartDataWorkbook](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/)), очистив любые ряды и категории по умолчанию, а затем добавив собственные данные. Это позволяет программно обновлять диаграмму для отображения актуальной информации.

**Можно ли настроить внешний вид диаграммы?**

Да, Aspose.Slides предоставляет обширные возможности настройки. Вы можете изменять цвета, шрифты, подписи, легенды и другие [элементы форматирования](/slides/ru/nodejs-java/chart-entities/), чтобы адаптировать внешний вид диаграммы под конкретные требования дизайна.