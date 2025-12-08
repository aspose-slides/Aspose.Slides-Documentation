---
title: Создание или обновление диаграмм PowerPoint презентации в JavaScript
linktitle: Создать диаграмму
type: docs
weight: 10
url: /ru/nodejs-java/create-chart/
keywords: "Создать диаграмму, точечная диаграмма, круговая диаграмма, диаграмма древовидной карты, фондовая диаграмма, ящик с усами, гистограмма, воронкообразная диаграмма, взрывная диаграмма, многокатегориальная диаграмма, презентация PowerPoint, Java, Aspose.Slides для Node.js через Java"
description: "Создание диаграммы в презентации PowerPoint на JavaScript"
---

## Обзор

В этой статье описывается, как **создавать диаграммы PowerPoint Presentation в Java**. Вы также можете **обновлять диаграммы в JavaScript**. Рассматриваются следующие темы.

_Диаграмма_: **Обычная**
- [Java Создать диаграмму PowerPoint](#java-create-powerpoint-chart)
- [Java Создать диаграмму Presentation](#java-create-presentation-chart)
- [Java Создать диаграмму PowerPoint Presentation](#java-create-powerpoint-presentation-chart)

_Диаграмма_: **Точечная**
- [Java Создать точечную диаграмму](#java-create-scattered-chart)
- [Java Создать точечную диаграмму PowerPoint](#java-create-powerpoint-scattered-chart)
- [Java Создать точечную диаграмму PowerPoint Presentation](#java-create-powerpoint-presentation-scattered-chart)

_Диаграмма_: **Круговая**
- [Java Создать круговую диаграмму](#java-create-pie-chart)
- [Java Создать круговую диаграмму PowerPoint](#java-create-powerpoint-pie-chart)
- [Java Создать круговую диаграмму PowerPoint Presentation](#java-create-powerpoint-presentation-pie-chart)

_Диаграмма_: **Древовидная карта**
- [Java Создать диаграмму Древовидной карты](#java-create-tree-map-chart)
- [Java Создать диаграмму Древовидной карты PowerPoint](#java-create-powerpoint-tree-map-chart)
- [Java Создать диаграмму Древовидной карты PowerPoint Presentation](#java-create-powerpoint-presentation-tree-map-chart)

_Диаграмма_: **Фондовая**
- [Java Создать фондовую диаграмму](#java-create-stock-chart)
- [Java Создать фондовую диаграмму PowerPoint](#java-create-powerpoint-stock-chart)
- [Java Создать фондовую диаграмму PowerPoint Presentation](#java-create-powerpoint-presentation-stock-chart)

_Диаграмма_: **Ящик с усами**
- [Java Создать диаграмму ящик с усами](#java-create-box-and-whisker-chart)
- [Java Создать диаграмму ящик с усами PowerPoint](#java-create-powerpoint-box-and-whisker-chart)
- [Java Создать диаграмму ящик с усами PowerPoint Presentation](#java-create-powerpoint-presentation-box-and-whisker-chart)

_Диаграмма_: **Воронка**
- [Java Создать воронковую диаграмму](#java-create-funnel-chart)
- [Java Создать воронковую диаграмму PowerPoint](#java-create-powerpoint-funnel-chart)
- [Java Создать воронковую диаграмму PowerPoint Presentation](#java-create-powerpoint-presentation-funnel-chart)

_Диаграмма_: **Взрывная**
- [Java Создать взрывную диаграмму](#java-create-sunburst-chart)
- [Java Создать взрывную диаграмму PowerPoint](#java-create-powerpoint-sunburst-chart)
- [Java Создать взрывную диаграмму PowerPoint Presentation](#java-create-powerpoint-presentation-sunburst-chart)

_Диаграмма_: **Гистограмма**
- [Java Создать гистограмму](#java-create-histogram-chart)
- [Java Создать гистограмму PowerPoint](#java-create-powerpoint-histogram-chart)
- [Java Создать гистограмму PowerPoint Presentation](#java-create-powerpoint-presentation-histogram-chart)

_Диаграмма_: **Радарная**
- [Java Создать радарную диаграмму](#java-create-radar-chart)
- [Java Создать радарную диаграмму PowerPoint](#java-create-powerpoint-radar-chart)
- [Java Создать радарную диаграмму PowerPoint Presentation](#java-create-powerpoint-presentation-radar-chart)

_Диаграмма_: **Многокатегориальная**
- [Java Создать многокатегориальную диаграмму](#java-create-multi-category-chart)
- [Java Создать многокатегориальную диаграмму PowerPoint](#java-create-powerpoint-multi-category-chart)
- [Java Создать многокатегориальную диаграмму PowerPoint Presentation](#java-create-powerpoint-presentation-multi-category-chart)

_Диаграмма_: **Карта**
- [Java Создать картографическую диаграмму](#java-create-map-chart)
- [Java Создать картографическую диаграмму PowerPoint](#java-create-powerpoint-map-chart)
- [Java Создать картографическую диаграмму PowerPoint Presentation](#java-create-powerpoint-presentation-map-chart)

_Действие_: **Обновить диаграмму**
- [Java Обновить диаграмму PowerPoint](#java-update-powerpoint-chart)
- [Java Обновить диаграмму Presentation](#java-update-presentation-chart)
- [Java Обновить диаграмму PowerPoint Presentation](#java-update-powerpoint-presentation-chart)


## **Создание диаграмм**
Диаграммы помогают людям быстро визуализировать данные и получать инсайты, которые могут быть неочевидны из таблицы или электронных таблиц. 


**Почему создавать диаграммы?**

Используя диаграммы, вы можете

* агрегировать, уплотнять или суммировать большие объёмы данных на одном слайде презентации
* выявлять закономерности и тенденции в данных
* определять направление и динамику данных во времени или относительно определённой единицы измерения 
* находить выбросы, аномалии, отклонения, ошибки, бессмысленные данные и т.п. 
* эффективно представлять сложные данные

В PowerPoint вы можете создавать диаграммы через функцию вставки, которая предоставляет шаблоны для проектирования различных типов диаграмм. С помощью Aspose.Slides можно создавать обычные диаграммы (на основе популярных типов) и пользовательские диаграммы. 

{{% alert color="primary" %}} 

Чтобы создавать диаграммы, Aspose.Slides предоставляет класс [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType). Поля этого класса соответствуют различным типам диаграмм.

{{% /alert %}} 

### **Создание обычных диаграмм**

_Шаги: Создать диаграмму_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Шаги:</em> Создать диаграмму PowerPoint в JavaScript</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Шаги:</em> Создать диаграмму Presentation в JavaScript</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Шаги:</em> Создать диаграмму PowerPoint Presentation в JavaScript</strong></a>

_Кодовые шаги:_

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получить ссылку на слайд по его индексу.
3. Добавить диаграмму с данными и указать желаемый тип диаграммы. 
4. Добавить заголовок к диаграмме. 
5. Получить доступ к листу данных диаграммы.
6. Очистить все серии и категории по умолчанию.
7. Добавить новые серии и категории.
8. Добавить новые данные в серии диаграммы.
9. Установить цвет заливки для серии.
10. Добавить подписи для серии.
11. Сохранить изменённую презентацию в файл PPTX.

Этот JavaScript‑код показывает, как создать обычную диаграмму:
```javascript
// Создает экземпляр класса презентации, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавляет диаграмму с её данными по умолчанию
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Устанавливает заголовок диаграммы
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // Устанавливает отображение значений для первой серии
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Задает индекс листа данных диаграммы
    var defaultWorksheetIndex = 0;
    // Получает рабочий лист данных диаграммы
    var fact = chart.getChartData().getChartDataWorkbook();
    // Удаляет серии и категории, сгенерированные по умолчанию
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Добавляет новые серии
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Добавляет новые категории
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Берёт первую серию диаграммы
    var series = chart.getChartData().getSeries().get_Item(0);
    // Заполняет данные серии
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Устанавливает цвет заливки для серии
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Берёт вторую серию диаграммы
    series = chart.getChartData().getSeries().get_Item(1);
    // Заполняет данные серии
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Устанавливает цвет заливки для серии
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Создаёт пользовательские подписи для каждой категории новой серии
    // Устанавливает первую подпись отображать название категории
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


### **Создание точечных диаграмм**
Точечные диаграммы (также известные как разбросанные графики или графики x‑y) часто используются для проверки закономерностей или демонстрации корреляций между двумя переменными. 

Вы можете использовать точечную диаграмму, когда 

* у вас есть парные числовые данные
* у вас есть 2 переменные, которые хорошо сочетаются
* вы хотите определить, связаны ли 2 переменные
* у вас есть независимая переменная с множеством значений для зависимой переменной

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Шаги:</em> Создать точечную диаграмму в JavaScript</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Шаги:</em> Создать точечную диаграмму PowerPoint в JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Шаги:</em> Создать точечную диаграмму PowerPoint Presentation в JavaScript</strong></a>

1. Пожалуйста, следуйте шагам, описанным в разделе [Создание обычных диаграмм](#creating-normal-charts)
2. На третьем шаге добавьте диаграмму с данными и укажите тип диаграммы как один из следующих
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Представляет точечную диаграмму с маркерами._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Представляет точечную диаграмму, соединённую плавными линиями, с маркерами._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Представляет точечную диаграмму, соединённую плавными линиями, без маркеров._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Представляет точечную диаграмму, соединённую прямыми линиями, с маркерами._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Представляет точечную диаграмму, соединённую прямыми линиями, без маркеров._

Этот JavaScript‑код показывает, как создать точечные диаграммы с различными маркерами:
```javascript
// Создаёт экземпляр класса презентации, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Создаёт диаграмму по умолчанию
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Получает индекс листа данных диаграммы по умолчанию
    var defaultWorksheetIndex = 0;
    // Получает рабочий лист данных диаграммы
    var fact = chart.getChartData().getChartDataWorkbook();
    // Удаляет демонстрационную серию
    chart.getChartData().getSeries().clear();
    // Добавляет новую серию
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Берёт первую серию диаграммы
    var series = chart.getChartData().getSeries().get_Item(0);
    // Добавляет новую точку (1:3) в серию
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Добавляет новую точку (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Изменяет тип серии
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Изменяет маркер серии диаграммы
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // Берёт вторую серию диаграммы
    series = chart.getChartData().getSeries().get_Item(1);
    // Добавляет новую точку (5:2) туда
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // Добавляет новую точку (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // Добавляет новую точку (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // Добавляет новую точку (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // Изменяет маркер серии диаграммы
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

Круговые диаграммы лучше всего использовать для демонстрации отношения части к целому, особенно когда данные содержат категориальные подписи с числовыми значениями. Если данных слишком много, стоит рассмотреть гистограмму. 

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Шаги:</em> Создать круговую диаграмму в JavaScript</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Шаги:</em> Создать круговую диаграмму PowerPoint в JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Шаги:</em> Создать круговую диаграмму PowerPoint Presentation в JavaScript</strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получить ссылку на слайд по индексу.
3. Добавить диаграмму с данными по умолчанию и указать тип ([ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).Pie).
4. Получить доступ к листу данных [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Очистить серии и категории по умолчанию.
6. Добавить новые серии и категории.
7. Добавить новые данные в серии.
8. Добавить новые точки и задать пользовательские цвета секторов.
9. Установить подписи для серий.
10. Установить линии‑выноски для подписей.
11. Задать угол поворота для слайдов с круговой диаграммой.
12. Сохранить изменённую презентацию в файл PPTX.

Этот JavaScript‑код показывает, как создать круговую диаграмму:
```javascript
// Создаёт экземпляр класса презентации, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var slides = pres.getSlides().get_Item(0);
    // Добавляет диаграмму с данными по умолчанию
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Устанавливает заголовок диаграммы
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Устанавливает отображение значений для первой серии
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Устанавливает индекс листа данных диаграммы
    var defaultWorksheetIndex = 0;
    // Получает рабочий лист данных диаграммы
    var fact = chart.getChartData().getChartDataWorkbook();
    // Удаляет автоматически сгенерированные серии и категории
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Добавляет новые категории
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Добавляет новую серию
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Заполняет данные серии
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Не работает в новой версии
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Устанавливает границу сектора
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Устанавливает границу сектора
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Устанавливает границу сектора
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // Создаёт пользовательские подписи для каждой категории новой серии
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
    // Показывает линии‑выноски для диаграммы
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Устанавливает угол вращения секторов круговой диаграммы
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

Линейные диаграммы (также известные как графики) лучше всего использовать, когда нужно показать изменение значений во времени. Они позволяют сравнивать множество данных одновременно, отслеживать тренды, выделять аномалии и т.д.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получить ссылку на слайд по индексу.
1. Добавить диаграмму с данными по умолчанию и типом `ChartType.Line`.
1. Получить доступ к листу данных IChartDataWorkbook.
1. Очистить серии и категории по умолчанию.
1. Добавить новые серии и категории.
1. Добавить новые данные в серии.
1. Сохранить изменённую презентацию в файл PPTX.

Этот JavaScript‑код показывает, как создать линейную диаграмму:
```javascript
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


По умолчанию точки линейной диаграммы соединяются сплошными линиями. Чтобы соединить их пунктиром, укажите желаемый тип пунктирной линии так:
```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```


### **Создание диаграмм Древовидной карты**

Диаграммы Древовидной карты удобны для отображения относительных размеров категорий и одновременного выделения крупных вкладов в каждую категорию. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Шаги:</em> Создать диаграмму Древовидной карты в JavaScript</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Шаги:</em> Создать диаграмму Древовидной карты PowerPoint в JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Шаги:</em> Создать диаграмму Древовидной карты PowerPoint Presentation в JavaScript</strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Получить ссылку на слайд по индексу.
3. Добавить диаграмму с данными по умолчанию и типом [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).TreeMap.
4. Получить доступ к листу данных [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Очистить серии и категории по умолчанию.
6. Добавить новые серии и категории.
7. Добавить новые данные в серии.
8. Сохранить изменённую презентацию в файл PPTX.

Этот JavaScript‑код показывает, как создать диаграмму Древовидной карты:
```javascript
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


### **Создание фондовых диаграмм**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Шаги:</em> Создать фондовую диаграмму в JavaScript</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Шаги:</em> Создать фондовую диаграмму PowerPoint в JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Шаги:</em> Создать фондовую диаграмму PowerPoint Presentation в JavaScript</strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Получить ссылку на слайд по индексу.
3. Добавить диаграмму с данными по умолчанию и типом ([ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).OpenHighLowClose).
4. Получить доступ к листу данных [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Очистить серии и категории по умолчанию.
6. Добавить новые серии и категории.
7. Добавить новые данные в серии.
8. Задать формат HiLowLines.
9. Сохранить изменённую презентацию в файл PPTX.

Пример JavaScript‑кода для создания фондовой диаграммы:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
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


### **Создание диаграмм ящик с усами**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Шаги:</em> Создать диаграмму ящик с усами в JavaScript</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Шаги:</em> Создать диаграмму ящик с усами PowerPoint в JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Шаги:</em> Создать диаграмму ящик с усами PowerPoint Presentation в JavaScript</strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Получить ссылку на слайд по индексу.
3. Добавить диаграмму с данными по умолчанию и типом ([ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).BoxAndWhisker).
4. Получить доступ к листу данных [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Очистить серии и категории по умолчанию.
6. Добавить новые серии и категории.
7. Добавить новые данные в серии.
8. Сохранить изменённую презентацию в файл PPTX.

Этот JavaScript‑код показывает, как создать диаграмму ящик с усами:
```javascript
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


### **Создание воронковых диаграмм**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Шаги:</em> Создать воронковую диаграмму в JavaScript</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Шаги:</em> Создать воронковую диаграмму PowerPoint в JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Шаги:</em> Создать воронковую диаграмму PowerPoint Presentation в JavaScript</strong></a>


1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Получить ссылку на слайд по индексу.
3. Добавить диаграмму с данными по умолчанию и типом ([ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).Funnel).
4. Сохранить изменённую презентацию в файл PPTX.

JavaScript‑код, показывающий создание воронковой диаграммы:
```javascript
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


### **Создание взрывных диаграмм**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Шаги:</em> Создать взрывную диаграмму в JavaScript</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Шаги:</em> Создать взрывную диаграмму PowerPoint в JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Шаги:</em> Создать взрывную диаграмму PowerPoint Presentation в JavaScript</strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Получить ссылку на слайд по индексу.
3. Добавить диаграмму с данными по умолчанию и типом (в данном случае,[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).sunburst).
4. Сохранить изменённую презентацию в файл PPTX.

Этот JavaScript‑код показывает, как создать взрывную диаграмму:
```javascript
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


### **Создание гистограмм**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Шаги:</em> Создать гистограмму в JavaScript</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Шаги:</em> Создать гистограмму PowerPoint в JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Шаги:</em> Создать гистограмму PowerPoint Presentation в JavaScript</strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Получить ссылку на слайд по индексу.
3. Добавить диаграмму с данными по умолчанию и типом ([ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).Histogram).
4. Получить доступ к листу данных [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Очистить серии и категории по умолчанию.
6. Добавить новые серии и категории.
7. Сохранить изменённую презентацию в файл PPTX.

Этот JavaScript‑код показывает, как создать гистограмму:
```javascript
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


### **Создание радарных диаграмм**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Шаги:</em> Создать радарную диаграмму в JavaScript</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Шаги:</em> Создать радарную диаграмму PowerPoint в JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Шаги:</em> Создать радарную диаграмму PowerPoint Presentation в JavaScript</strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Получить ссылку на слайд по индексу. 
3. Добавить диаграмму с данными и указать желаемый тип (`ChartType.Radar` в данном случае).
4. Сохранить изменённую презентацию в файл PPTX.

Этот JavaScript‑код показывает, как создать радарную диаграмму:
```javascript
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


### **Создание многокатегориальных диаграмм**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Шаги:</em> Создать многокатегориальную диаграмму в JavaScript</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Шаги:</em> Создать многокатегориальную диаграмму PowerPoint в JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Шаги:</em> Создать многокатегориальную диаграмму PowerPoint Presentation в JavaScript</strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Получить ссылку на слайд по индексу. 
3. Добавить диаграмму с данными по умолчанию и типом ([ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).ClusteredColumn).
4. Получить доступ к листу данных [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Очистить серии и категории по умолчанию.
6. Добавить новые серии и категории.
7. Добавить новые данные в серии.
8. Сохранить изменённую презентацию в файл PPTX.

Этот JavaScript‑код показывает, как создать многокатегориальную диаграмму:
```javascript
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


### **Создание картографических диаграмм**

Картографическая диаграмма визуализирует область, содержащую данные. Такие диаграммы лучше всего использовать для сравнения данных или значений по географическим регионам.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Шаги:</em> Создать картографическую диаграмму в JavaScript</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Шаги:</em> Создать картографическую диаграмму PowerPoint в JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Шаги:</em> Создать картографическую диаграмму PowerPoint Presentation в JavaScript</strong></a>

Этот JavaScript‑код показывает, как создать картографическую диаграмму:
```javascript
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

Комбинированная диаграмма (или combo‑диаграмма) объединяет два или более типов диаграмм в одном графике. Она позволяет выделять, сравнивать или исследовать различия между наборами данных, помогая находить их взаимосвязи.

![The combination chart](combination_chart.png)

Следующий JavaScript‑код показывает, как создать комбинированную диаграмму, изображённую выше, в презентации PowerPoint:
```js
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

    // Удалить автоматически сгенерированные серии и категории.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Добавить новые категории.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Добавить первую серию.
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

    // Установить цвет основных линий сетки по вертикали.
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

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Шаги:</em> Обновить диаграмму PowerPoint в JavaScript</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Шаги:</em> Обновить диаграмму Presentation в JavaScript</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Шаги:</em> Обновить диаграмму PowerPoint Presentation в JavaScript</strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), представляющий презентацию с диаграммой, которую нужно обновить.
2. Получить ссылку на слайд по его индексу.
3. Пройтись по всем фигурам, чтобы найти нужную диаграмму.
4. Получить доступ к листу данных диаграммы.
5. Изменить данные серии, изменив значения.
6. Добавить новую серию и заполнить её данными.
7. Сохранить изменённую презентацию в файл PPTX.

Этот JavaScript‑код показывает, как обновить диаграмму:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Получить диаграмму с данными по умолчанию
    var chart = sld.getShapes().get_Item(0);
    // Установка индекса листа данных диаграммы
    var defaultWorksheetIndex = 0;
    // Получить рабочий лист данных диаграммы
    var fact = chart.getChartData().getChartDataWorkbook();
    // Изменение названия категории диаграммы
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Взять первую серию диаграммы
    var series = chart.getChartData().getSeries().get_Item(0);
    // Обновление данных серии
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Изменение имени серии
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Взять вторую серию диаграммы
    series = chart.getChartData().getSeries().get_Item(1);
    // Обновление данных серии
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Изменение имени серии
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Теперь добавляем новую серию
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Взять третью серию диаграммы
    series = chart.getChartData().getSeries().get_Item(2);
    // Заполнение данных серии
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


## **Установка диапазона данных для диаграмм**

Чтобы задать диапазон данных для диаграммы, выполните следующее:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), представляющий презентацию с диаграммой.
2. Получить ссылку на слайд по индексу.
3. Пройтись по всем фигурам, чтобы найти нужную диаграмму.
4. Получить доступ к данным диаграммы и задать диапазон.
5. Сохранить изменённую презентацию в файл PPTX.

Этот JavaScript‑код показывает, как задать диапазон данных для диаграммы:
```javascript
var pres = new aspose.slides.Presentation();
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


## **Использование стандартных маркеров в диаграммах**
При использовании стандартного маркера в диаграммах каждая серия получает автоматически разные символы маркера.

Этот JavaScript‑код показывает, как автоматически задать маркер серии диаграммы:
```javascript
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
    // Взять вторую серию диаграммы
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Сейчас заполняем данные серии
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
