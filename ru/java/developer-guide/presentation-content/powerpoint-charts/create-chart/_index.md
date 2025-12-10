---
title: Создать или обновить диаграммы PowerPoint презентаций на Java
linktitle: Создать или обновить диаграммы
type: docs
weight: 10
url: /ru/java/create-chart/
keywords:
- добавить диаграмму
- создать диаграмму
- редактировать диаграмму
- изменить диаграмму
- обновить диаграмму
- точечная диаграмма
- круговая диаграмма
- линейная диаграмма
- диаграмма древовидной карты
- диаграмма акций
- диаграмма ящик с усами
- диаграмма воронки
- взрывная диаграмма
- гистограмма
- радарная диаграмма
- мультикатегориальная диаграмма
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Создавайте и настраивайте диаграммы в PowerPoint презентациях с помощью Aspose.Slides для Java. Добавляйте, форматируйте и редактируйте диаграммы, используя практические примеры кода на Java."
---

## Обзор

Эта статья описывает, как **создавать диаграммы PowerPoint презентаций на Java**. Вы также можете **обновлять диаграммы на Java**. Она охватывает следующие темы.

_Диаграмма_: **Обычная**
- [Java Создать PowerPoint Диаграмму](#java-create-powerpoint-chart)
- [Java Создать Презентационную Диаграмму](#java-create-presentation-chart)
- [Java Создать PowerPoint Презентационную Диаграмму](#java-create-powerpoint-presentation-chart)

_Диаграмма_: **Точечная**
- [Java Создать Точечную Диаграмму](#java-create-scattered-chart)
- [Java Создать PowerPoint Точечную Диаграмму](#java-create-powerpoint-scattered-chart)
- [Java Создать PowerPoint Презентационную Точечную Диаграмму](#java-create-powerpoint-presentation-scattered-chart)

_Диаграмма_: **Круговая**
- [Java Создать Круговую Диаграмму](#java-create-pie-chart)
- [Java Создать PowerPoint Круговую Диаграмму](#java-create-powerpoint-pie-chart)
- [Java Создать PowerPoint Презентационную Круговую Диаграмму](#java-create-powerpoint-presentation-pie-chart)

_Диаграмма_: **Древовидная карта**
- [Java Создать Древовидную карту Диаграмму](#java-create-tree-map-chart)
- [Java Создать PowerPoint Древовидную карту Диаграмму](#java-create-powerpoint-tree-map-chart)
- [Java Создать PowerPoint Презентационную Древовидную карту Диаграмму](#java-create-powerpoint-presentation-tree-map-chart)

_Диаграмма_: **Акции**
- [Java Создать Акций Диаграмму](#java-create-stock-chart)
- [Java Создать PowerPoint Акций Диаграмму](#java-create-powerpoint-stock-chart)
- [Java Создать PowerPoint Презентационную Акций Диаграмму](#java-create-powerpoint-presentation-stock-chart)

_Диаграмма_: **Ящик с усами**
- [Java Создать Ящик с усами Диаграмму](#java-create-box-and-whisker-chart)
- [Java Создать PowerPoint Ящик с усами Диаграмму](#java-create-powerpoint-box-and-whisker-chart)
- [Java Создать PowerPoint Презентационную Ящик с усами Диаграмму](#java-create-powerpoint-presentation-box-and-whisker-chart)

_Диаграмма_: **Воронка**
- [Java Создать Воронку Диаграмму](#java-create-funnel-chart)
- [Java Создать PowerPoint Воронку Диаграмму](#java-create-powerpoint-funnel-chart)
- [Java Создать PowerPoint Презентационную Воронку Диаграмму](#java-create-powerpoint-presentation-funnel-chart)

_Диаграмма_: **Взрывная**
- [Java Создать Взрывную Диаграмму](#java-create-sunburst-chart)
- [Java Создать PowerPoint Взрывную Диаграмму](#java-create-powerpoint-sunburst-chart)
- [Java Создать PowerPoint Презентационную Взрывную Диаграмму](#java-create-powerpoint-presentation-sunburst-chart)

_Диаграмма_: **Гистограмма**
- [Java Создать Гистограмму Диаграмму](#java-create-histogram-chart)
- [Java Создать PowerPoint Гистограмму Диаграмму](#java-create-powerpoint-histogram-chart)
- [Java Создать PowerPoint Презентационную Гистограмму Диаграмму](#java-create-powerpoint-presentation-histogram-chart)

_Диаграмма_: **Радарная**
- [Java Создать Радарную Диаграмму](#java-create-radar-chart)
- [Java Создать PowerPoint Радарную Диаграмму](#java-create-powerpoint-radar-chart)
- [Java Создать PowerPoint Презентационную Радарную Диаграмму](#java-create-powerpoint-presentation-radar-chart)

_Диаграмма_: **Мультикатегория**
- [Java Создать Мультикатегорию Диаграмму](#java-create-multi-category-chart)
- [Java Создать PowerPoint Мультикатегорию Диаграмму](#java-create-powerpoint-multi-category-chart)
- [Java Создать PowerPoint Презентационную Мультикатегорию Диаграмму](#java-create-powerpoint-presentation-multi-category-chart)

_Диаграмма_: **Карта**
- [Java Создать Карту Диаграмму](#java-create-map-chart)
- [Java Создать PowerPoint Карту Диаграмму](#java-create-powerpoint-map-chart)
- [Java Создать PowerPoint Презентационную Карту Диаграмму](#java-create-powerpoint-presentation-map-chart)

_Действие_: **Обновить диаграмму**
- [Java Обновить PowerPoint Диаграмму](#java-update-powerpoint-chart)
- [Java Обновить Презентационную Диаграмму](#java-update-presentation-chart)
- [Java Обновить PowerPoint Презентационную Диаграмму](#java-update-powerpoint-presentation-chart)


## **Создать диаграмму**
Диаграммы помогают людям быстро визуализировать данные и получать инсайты, которые могут быть неочевидны из таблицы или электронной таблицы. 


**Зачем создавать диаграммы?**

Используя диаграммы, вы можете

* агрегировать, сжимать или суммировать большие объёмы данных на одном слайде презентации
* выявлять шаблоны и тенденции в данных
* определять направление и импульс данных во времени или относительно конкретной единицы измерения 
* обнаруживать выбросы, отклонения, ошибки, нелогичные данные и т.п. 
* эффективно передавать или представлять сложные данные

В PowerPoint вы можете создавать диаграммы через функцию вставки, которая предоставляет шаблоны для большинства типов диаграмм. С помощью Aspose.Slides вы можете создавать обычные диаграммы (на основе популярных типов) и пользовательские диаграммы. 

{{% alert color="primary" %}} 

Чтобы вы могли создавать диаграммы, Aspose.Slides предоставляет класс [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType). Поля этого класса соответствуют различным типам диаграмм. 

{{% /alert %}} 

### **Создать обычные диаграммы**

_Steps: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Шаги:</em> Создать PowerPoint Диаграмму на Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Шаги:</em> Создать Презентационную Диаграмму на Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Шаги:</em> Создать PowerPoint Презентационную Диаграмму на Java</strong></a>

_Кодовые шаги:_

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными и укажите предпочитаемый тип диаграммы. 
4. Добавьте заголовок к диаграмме. 
5. Получите доступ к листу данных диаграммы. 
6. Очистите все серии и категории по умолчанию. 
7. Добавьте новые серии и категории. 
8. Добавьте новые данные для серии диаграммы. 
9. Укажите цвет заливки для серии диаграммы. 
10. Добавьте подписи для серии диаграммы. 
11. Сохраните изменённую презентацию в файл PPTX.

Этот код на Java показывает, как создать обычную диаграмму:
```java
// Создаёт экземпляр класса презентации, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает доступ к первому слайду
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Добавляет диаграмму с данными по умолчанию
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Устанавливает заголовок диаграммы
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    
    // Настраивает первую серию для отображения значений
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Устанавливает индекс листа данных диаграммы
    int defaultWorksheetIndex = 0;
    
    // Получает лист данных диаграммы
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Удаляет сгенерированные по умолчанию серии и категории
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Добавляет новые серии
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Добавляет новые категории
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Берёт первую серию диаграммы
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Заполняет данные серии
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Устанавливает цвет заливки для серии
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Берёт вторую серию диаграммы
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Заполняет данные серии
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Устанавливает цвет заливки для серии
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Создаёт пользовательские подписи для каждой категории новой серии
    // Устанавливает первую подпись для отображения названия категории
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Отображает значение для третьей подписи
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Сохраняет презентацию с диаграммой
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Создать точечные диаграммы**
Точечные диаграммы (также известные как точечные графики или графики x‑y) часто используются для проверки шаблонов или демонстрации корреляций между двумя переменными. 

Вы можете использовать точечную диаграмму, когда 

* у вас есть парные числовые данные
* есть 2 переменные, которые логично сопоставляются
* вы хотите определить, связаны ли 2 переменные
* имеется независимая переменная с несколькими значениями зависимой переменной

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Шаги:</em> Создать Точечную Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Шаги:</em> Создать PowerPoint Точечную Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Шаги:</em> Создать PowerPoint Презентационную Точечную Диаграмму на Java</strong></a>

1. Пожалуйста, выполните шаги, описанные выше в [Creating Normal Charts](#creating-normal-charts)
2. На третьем шаге добавьте диаграмму с данными и укажите тип диаграммы как один из следующих
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _Представляет точечную диаграмму._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Представляет точечную диаграмму, соединённую кривыми, с маркерами данных._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Представляет точечную диаграмму, соединённую кривыми, без маркеров данных._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Представляет точечную диаграмму, соединённую прямыми линиями, с маркерами данных._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Представляет точечную диаграмму, соединённую прямыми линиями, без маркеров данных._

Этот код на Java показывает, как создать точечные диаграммы с разными типами маркеров: 
```java
// Создаёт экземпляр класса презентации, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);

    // Создаёт диаграмму по умолчанию
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Получает индекс листа данных диаграммы по умолчанию
    int defaultWorksheetIndex = 0;
    
    // Получает лист данных диаграммы
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Удаляет демонстрационную серию
    chart.getChartData().getSeries().clear();
    
    // Добавляет новые серии
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Берёт первую серию диаграммы
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Добавляет новую точку (1:3) в серию
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Добавляет новую точку (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Изменяет тип серии
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Изменяет маркер серии диаграммы
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
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
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Создать Круговые Диаграммы**

Круговые диаграммы лучше всего использовать для отображения соотношения части к целому, особенно когда данные содержат категориальные метки с числовыми значениями. Однако если данных слишком много, лучше использовать гистограмму. 

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Шаги:</em> Создать Круговую Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Шаги:</em> Создать PowerPoint Круговую Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Шаги:</em> Создать PowerPoint Презентационную Круговую Диаграмму на Java</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию и укажите желаемый тип (в данном случае [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Pie).
4. Получите доступ к листу данных диаграммы [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Добавьте новые данные для серии диаграммы.
8. Добавьте новые точки и задайте пользовательские цвета для секторов круговой диаграммы.
9. Установите подписи для серии.
10. Установите линии‑выноски для подписей серии.
11. Установите угол поворота для слайдов с круговой диаграммой.
12. Сохраните изменённую презентацию в файл PPTX.

Этот код на Java показывает, как создать круговую диаграмму:
```java
// Создаёт экземпляр класса презентации, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает доступ к первому слайду
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Добавляет диаграмму с данными по умолчанию
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Устанавливает заголовок диаграммы
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Настраивает первую серию для отображения значений
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Устанавливает индекс листа данных диаграммы
    int defaultWorksheetIndex = 0;
    
    // Получает лист данных диаграммы
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Удаляет сгенерированные по умолчанию серии и категории
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Добавляет новые категории
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Добавляет новые серии
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    // Заполняет данные серии
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Не работает в новой версии
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
    
    // Устанавливает границу сектора
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Устанавливает границу сектора
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Устанавливает границу сектора
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Создаёт пользовательские подписи для каждой категории новой серии
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // Показывает линии‑выноски для диаграммы
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Устанавливает угол поворота секторов круговой диаграммы
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Сохраняет презентацию с диаграммой
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Создать Линейные Диаграммы**

Линейные диаграммы (также известные как линейные графики) лучше всего подходят для демонстрации изменения значений со временем. С их помощью можно сравнивать множество данных одновременно, отслеживать изменения и тенденции, выделять аномалии и т.д.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и укажите желаемый тип (в данном случае `ChartType.Line`).
1. Получите доступ к листу данных IChartDataWorkbook.
1. Очистите серии и категории по умолчанию.
1. Добавьте новые серии и категории.
1. Добавьте новые данные для серии диаграммы.
1. Сохраните изменённую презентацию в файл PPTX.

Этот код на Java показывает, как создать линейную диаграмму:
```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


По умолчанию точки линейной диаграммы соединяются сплошными линиями. Чтобы соединить их пунктиром, укажите желаемый тип штриха так:
```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```


### **Создать Древовидные карты**

Древовидные карты лучше всего подходят для отображения объёма категорий продаж и одновременного выделения крупных вкладчиков в каждой категории. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Шаги:</em> Создать Древовидную карту Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Шаги:</em> Создать PowerPoint Древовидную карту Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Шаги:</em> Создать PowerPoint Презентационную Древовидную карту Диаграмму на Java</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию и укажите желаемый тип (в данном случае [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).TreeMap).
4. Получите доступ к листу данных [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Добавьте новые данные для серии диаграммы.
8. Сохраните изменённую презентацию в файл PPTX

Этот код на Java показывает, как создать древовидную карту диаграмму:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //ветка 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //ветка 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Создать Акций Диаграммы**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Шаги:</em> Создать Акций Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Шаги:</em> Создать PowerPoint Акций Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Шаги:</em> Создать PowerPoint Презентационную Акций Диаграмму на Java</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию и укажите желаемый тип ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).OpenHighLowClose).
4. Получите доступ к листу данных [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Добавьте новые данные для серии диаграммы.
8. Укажите формат HiLowLines.
9. Сохраните изменённую презентацию в файл PPTX

Пример кода на Java, используемый для создания акций диаграммы:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Создать Ящик с усами Диаграммы**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Шаги:</em> Создать Ящик с усами Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Шаги:</em> Создать PowerPoint Ящик с усами Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Шаги:</em> Создать PowerPoint Презентационную Ящик с усами Диаграмму на Java</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию и укажите желаемый тип ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).BoxAndWhisker).
4. Получите доступ к листу данных [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Добавьте новые данные для серии диаграммы.
8. Сохраните изменённую презентацию в файл PPTX

Этот код на Java показывает, как создать ящик с усами диаграмму:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
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

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Создать Воронка Диаграммы**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Шаги:</em> Создать Воронка Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Шаги:</em> Создать PowerPoint Воронка Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Шаги:</em> Создать PowerPoint Презентационную Воронка Диаграмму на Java</strong></a>


1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию и укажите желаемый тип ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Funnel).
4. Сохраните изменённую презентацию в файл PPTX

Код Java, показывающий, как создать воронку диаграмму:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Создать Взрывные Диаграммы**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Шаги:</em> Создать Взрывную Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Шаги:</em> Создать PowerPoint Взрывную Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Шаги:</em> Создать PowerPoint Презентационную Взрывную Диаграмму на Java</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию и укажите желаемый тип (в данном случае,[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).sunburst).
4. Сохраните изменённую презентацию в файл PPTX

Этот код на Java показывает, как создать взрывную диаграмму:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //ветка 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //ветка 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Создать Гистограммы**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Шаги:</em> Создать Гистограмму Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Шаги:</em> Создать PowerPoint Гистограмму Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Шаги:</em> Создать PowerPoint Презентационную Гистограмму Диаграмму на Java</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию и укажите желаемый тип ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Histogram).
4. Получите доступ к листу данных [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Сохраните изменённую презентацию в файл PPTX

Этот код на Java показывает, как создать гистограмму:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic;)

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Создать Радарные Диаграммы**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Шаги:</em> Создать Радарную Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Шаги:</em> Создать PowerPoint Радарную Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Шаги:</em> Создать PowerPoint Презентационную Радарную Диаграмму на Java</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Получите ссылку на слайд по его индексу. 
3. Добавьте диаграмму с данными и укажите предпочитаемый тип диаграммы (`ChartType.Radar` в данном случае).
4. Сохраните изменённую презентацию в файл PPTX

Этот код на Java показывает, как создать радарную диаграмму:
```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Создать Мультикатегорийные Диаграммы**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Шаги:</em> Создать Мультикатегорию Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Шаги:</em> Создать PowerPoint Мультикатегорию Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Шаги:</em> Создать PowerPoint Презентационную Мультикатегорию Диаграмму на Java</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Получите ссылку на слайд по его индексу. 
3. Добавьте диаграмму с данными по умолчанию и укажите желаемый тип ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).ClusteredColumn).
4. Получите доступ к листу данных [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Добавьте новые данные для серии диаграммы.
8. Сохраните изменённую презентацию в файл PPTX.

Этот код на Java показывает, как создать мультикатегориальную диаграмму:
```java
Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Сохранить презентацию с диаграммой
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Создать Карту Диаграммы**

Карта диаграмма визуализирует область, содержащую данные. Такие диаграммы лучше всего использовать для сравнения данных или значений по географическим регионам.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Шаги:</em> Создать Карту Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Шаги:</em> Создать PowerPoint Карту Диаграмму на Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Шаги:</em> Создать PowerPoint Презентационную Карту Диаграмму на Java</strong></a>

Этот код на Java показывает, как создать карту диаграмму:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Создать Комбинационные Диаграммы**

Комбинационная (или комбинированная) диаграмма объединяет два и более типа диаграмм в одном графике. Этот тип позволяет выделять, сравнивать или исследовать различия между несколькими наборами данных, помогая определить их взаимосвязи.

![The combination chart](combination_chart.png)

Следующий код на Java показывает, как создать комбинационную диаграмму, показанную выше, в презентации PowerPoint:
```java
static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Установить заголовок диаграммы.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Установить легенду диаграммы.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Удалить сгенерированные по умолчанию серии и категории.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Добавить новые категории.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Добавить первую серию.
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // Установить горизонтальную ось.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Установить вертикальную ось.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Установить цвет основных линий сетки по вертикали.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // Установить вторичную горизонтальную ось.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // Установить вторичную вертикальную ось.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```


## **Обновить диаграммы**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Шаги:</em> Обновить PowerPoint Диаграмму на Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Шаги:</em> Обновить Презентационную Диаграмму на Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Шаги:</em> Обновить PowerPoint Презентационную Диаграмму на Java</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), представляющего презентацию, содержащую диаграмму, которую необходимо обновить. 
2. Получите ссылку на слайд, используя его индекс.
3. Пройдитесь по всем фигурам, чтобы найти нужную диаграмму.
4. Получите доступ к листу данных диаграммы.
5. Измените данные серии, изменив значения серии.
6. Добавьте новую серию и заполните её данными.
7. Сохраните изменённую презентацию в файл PPTX.

Этот код на Java показывает, как обновить диаграмму:
```java
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide sld = pres.getSlides().get_Item(0);

    // Получить диаграмму с данными по умолчанию
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Установка индекса листа данных диаграммы
    int defaultWorksheetIndex = 0;

    // Получение листа данных диаграммы
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Изменение названия категории диаграммы
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Получить первую серию диаграммы
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Сейчас обновляем данные серии
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Изменение имени серии
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Получить вторую серию диаграммы
    series = chart.getChartData().getSeries().get_Item(1);

    // Сейчас обновляем данные серии
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Изменение имени серии
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Теперь добавляем новую серию
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Получить третью серию диаграммы
    series = chart.getChartData().getSeries().get_Item(2);

    // Сейчас заполняем данные серии
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Сохранить презентацию с диаграммой
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить диапазон данных для диаграммы**

Чтобы установить диапазон данных для диаграммы, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), представляющего презентацию, содержащую диаграмму.
2. Получите ссылку на слайд по его индексу.
3. Пройдитесь по всем фигурам, чтобы найти нужную диаграмму.
4. Получите доступ к данным диаграммы и задайте диапазон.
5. Сохраните изменённую презентацию в файл PPTX.

Этот код на Java показывает, как установить диапазон данных для диаграммы:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Использовать стандартные маркеры в диаграммах**
При использовании стандартного маркера в диаграммах каждая серия автоматически получает различный маркер.

Этот код на Java показывает, как автоматически задать маркер серии диаграммы:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Получить вторую серию диаграммы
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // Сейчас заполняем данные серии
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Какие типы диаграмм поддерживает Aspose.Slides?**

Aspose.Slides поддерживает широкий набор [типов диаграмм](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/), включая столбчатые, линейные, кольцевые, областные, точечные, гистограммы, радарные и многие другие. Эта гибкость позволяет выбрать наиболее подходящий тип диаграммы для визуализации ваших данных.

**Как добавить новую диаграмму на слайд?**

Чтобы добавить диаграмму, сначала создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) , получите нужный слайд по индексу, а затем вызовите метод добавления диаграммы, указав тип диаграммы и начальные данные. Этот процесс интегрирует диаграмму непосредственно в вашу презентацию.

**Как обновить данные, отображаемые в диаграмме?**

Вы можете обновить данные диаграммы, получив доступ к её листу данных ([IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/)), очистив любые серии и категории по умолчанию, а затем добавив свои пользовательские данные. Это позволяет обновить диаграмму до актуального состояния.

**Можно ли настроить внешний вид диаграммы?**

Да, Aspose.Slides предоставляет обширные возможности настройки. Вы можете изменить цвета, шрифты, подписи, легенды и другие [элементы форматирования](/slides/ru/java/chart-entities/), чтобы адаптировать внешний вид диаграммы к вашим требованиям дизайна.