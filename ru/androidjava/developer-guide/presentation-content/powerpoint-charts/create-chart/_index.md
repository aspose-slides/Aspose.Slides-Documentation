---
title: Создание или обновление диаграмм PowerPoint в презентациях на Android
linktitle: Создание или обновление диаграмм
type: docs
weight: 10
url: /ru/androidjava/create-chart/
keywords:
- добавить диаграмму
- создать диаграмму
- редактировать диаграмму
- изменить диаграмму
- обновить диаграмму
- диаграмма рассеяния
- круговая диаграмма
- линейная диаграмма
- диаграмма дерево-карта
- биржевая диаграмма
- диаграмма box and whisker
- воронкообразная диаграмма
- диаграмма «sunburst»
- гистограмма
- радарная диаграмма
- мультикатегориальная диаграмма
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Создавайте и настраивайте диаграммы в презентациях PowerPoint с помощью Aspose.Slides для Android. Добавляйте, форматируйте и редактируйте диаграммы, используя практические примеры кода на Java."
---
## **Обзор**

Эта статья предоставляет полное руководство по созданию и настройке диаграмм с помощью Aspose.Slides. Вы узнаете, как программно добавить диаграмму на слайд, заполнить её данными и применить различные параметры форматирования, чтобы соответствовать вашим требованиям к дизайну. В статье приведены подробные примеры кода, иллюстрирующие каждый шаг — от инициализации презентации и объекта диаграммы до настройки серий, осей и легенд. Следуя этому руководству, вы получите прочное понимание того, как интегрировать динамическое создание диаграмм в свои приложения, упрощая процесс создания презентаций на основе данных.

## **Создание диаграммы**

Диаграммы помогают людям быстро визуализировать данные и получать инсайты, которые могут быть неочевидны из таблицы или электронной таблицы.

**Зачем создавать диаграммы?**

С помощью диаграмм вы можете:

* агрегировать, сжимать или суммировать большие объёмы данных на одном слайде презентации
* выявлять закономерности и тенденции в данных
* определять направление и динамику данных во времени или относительно конкретной единицы измерения
* обнаруживать выбросы, аномалии, отклонения, ошибки, бессмысленные данные и т.д.
* эффективно представлять сложные данные

В PowerPoint диаграммы можно создавать через функцию *Insert*, которая предоставляет шаблоны для проектирования различных типов диаграмм. С помощью Aspose.Slides можно создавать как обычные диаграммы (на основе популярных типов), так и пользовательские диаграммы.

{{% alert color="info" title="Note" %}}
Чтобы создавать диаграммы, используйте класс [ChartType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/) . Поля этого класса соответствуют различным типам диаграмм.
{{% /alert %}}

### **Create Clustered Column Charts**

В этом разделе объясняется, как создавать сгруппированные столбчатые диаграммы с помощью Aspose.Slides. Вы узнаете, как инициализировать презентацию, добавить диаграмму и настроить её элементы, такие как заголовок, данные, серии, категории и стили. Выполните следующие шаги, чтобы увидеть, как генерируется стандартная сгруппированная столбчатая диаграмма:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation) .
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с некоторыми данными и укажите тип `ChartType.ClusteredColumn` .
1. Добавьте заголовок к диаграмме.
1. Получите доступ к рабочему листу данных диаграммы.
1. Очистите все серии и категории по умолчанию.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для серий.
1. Примените цвет заливки к сериям диаграммы.
1. Добавьте подписи к сериям диаграммы.
1. Сохраните изменённую презентацию как файл PPTX.

Этот C# код демонстрирует, как создать сгруппированную столбчатую диаграмму:

```java
import com.aspose.slides.*;
import java.awt.Color;

//    // Создает экземпляр класса презентации, представляющий файл PPTX
Presentation pres = new Presentation();
try {
    //    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    //    // Добавляет диаграмму с данными по умолчанию
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    //    // Устанавливает заголовок диаграммы
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    //    // Устанавливает индекс листа данных диаграммы
    int defaultWorksheetIndex = 0;
    
    //    // Получает рабочий лист данных диаграммы
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    //    // Удаляет автоматически сгенерированные серии и категории
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    //    // Добавляет новые серии
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    //    // Добавляет новые категории
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    //    // Берет первую серию диаграммы
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    //    // Теперь заполняет данные серии
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    //    // Устанавливает цвет заливки для серии
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    //    // Берет вторую серию диаграммы
    series = chart.getChartData().getSeries().get_Item(1);
    
    //    // Заполняет данные серии
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    //    // Устанавливает цвет заливки для серии
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //    //Создает пользовательские подписи для каждой категории новой серии
    //    // Устанавливает первую подпись для показа имени категории
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    //    // Показывает значение для третьей подписи
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    //    // Saves the presentation with chart
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Create Scatter Charts**
Диаграммы рассеяния (также известные как scatter plots или графики x‑y) часто используют для поиска закономерностей или демонстрации корреляций между двумя переменными.

Используйте диаграмму рассеяния, когда:

* у вас есть парные числовые данные
* две переменные хорошо сочетаются друг с другом
* вы хотите определить, связаны ли две переменные
* у вас есть независимая переменная, имеющая несколько значений для зависимой переменной

1. Выполните шаги из раздела [Create Clustered Column Charts](#create-clustered-column-charts) .
2. На третьем шаге добавьте диаграмму с данными и укажите один из следующих типов:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Представляет диаграмму рассеяния._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Представляет диаграмму рассеяния, соединённую кривыми, с маркерами данных._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Представляет диаграмму рассеяния, соединённую кривыми, без маркеров данных._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Представляет диаграмму рассеяния, соединённую линиями, с маркерами данных._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Представляет диаграмму рассеяния, соединённую линиями, без маркеров данных._

Этот Java код показывает, как создать диаграмму рассеяния с разными маркерами для каждой серии:

```java
import com.aspose.slides.*;

// Создаёт экземпляр класса презентации, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Создает диаграмму по умолчанию
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Получает индекс листа данных диаграммы по умолчанию
    int defaultWorksheetIndex = 0;
    
    // Получает рабочий лист данных диаграммы
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Удаляет демонстрационную серию
    chart.getChartData().getSeries().clear();
    
    // Добавляет новые серии
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Берет первую серию диаграммы
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
    
    // Берет вторую серию диаграммы
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

### **Create Pie Charts**

Круговые диаграммы лучше всего использовать для отображения отношений «часть‑к‑целому» в данных, особенно когда данные содержат категориальные метки с числовыми значениями. Если в данных много частей или меток, имеет смысл использовать столбчатую диаграмму.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Pie](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/#Pie) .
4. Получите доступ к рабочей книге данных диаграммы [IChartDataWorkbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Добавьте новые данные диаграммы для серий.
8. Добавьте новые точки для диаграммы и примените пользовательские цвета к секторам круговой диаграммы.
9. Задайте подписи для серий.
10. Включите линии‑подвески для подписей серий.
11. Установите угол поворота секторов круговой диаграммы.
12. Сохраните изменённую презентацию как файл PPTX.

Этот Java код показывает, как создать круговую диаграмму:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создаёт экземпляр класса презентации, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Добавляет диаграмму с данными по умолчанию
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Устанавливает заголовок диаграммы
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Устанавливает индекс листа данных диаграммы
    int defaultWorksheetIndex = 0;
    
    // Получает рабочий лист данных диаграммы
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Удаляет автоматически сгенерированные серии и категории
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Добавляет новые категории
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Добавляет новую серию
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
    
    // Показывает линии‑подвески для диаграммы
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Устанавливает угол поворота секторов круговой диаграммы
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Сохраняет презентацию с диаграммой
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Create Line Charts**

Линейные диаграммы (также известные как линейные графики) лучше всего использовать, когда нужно показать изменения значения во времени. С их помощью можно сравнивать большие объёмы данных, отслеживать изменения и тенденции, выделять аномалии в сериалах данных и т.д.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) .
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Line](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/#Line) .
1. Сохраните изменённую презентацию как файл PPTX.

Этот Java код показывает, как создать линейную диаграмму:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

По умолчанию точки на линейной диаграмме соединяются сплошными прямыми линиями. Чтобы соединять точки пунктиром, укажите желаемый тип пунктиров следующим образом:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Create Tree Map Charts**

Диаграммы дерево‑карт лучше всего использовать для данных о продажах, когда нужно показать относительный размер категорий и быстро обратить внимание на крупные вклады в каждой категории.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Treemap](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/#Treemap) .
4. Получите доступ к рабочей книге данных диаграммы [IChartDataWorkbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Добавьте новые данные диаграммы для серий.
8. Сохраните изменённую презентацию как файл PPTX.

Этот Java код показывает, как создать диаграмму дерево‑карт:

```java
import com.aspose.slides.*;

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

### **Create Stock Charts**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/#OpenHighLowClose) .
4. Получите доступ к рабочей книге данных диаграммы [IChartDataWorkbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Добавьте новые данные диаграммы для серий.
8. Укажите формат линий «high‑low».
9. Сохраните изменённую презентацию как файл PPTX.

Этот Java код показывает, как создать биржевую диаграмму:

```java
import com.aspose.slides.*;

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

### **Create Box and Whisker Charts**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/#BoxAndWhisker) .
4. Получите доступ к рабочей книге данных диаграммы [IChartDataWorkbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Добавьте новые данные диаграммы для серий.
8. Сохраните изменённую презентацию как файл PPTX.

Этот Java код показывает, как создать диаграмму «box and whisker»:

```java
import com.aspose.slides.*;

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

### **Create Funnel Charts**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Funnel](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/#Funnel) .
4. Сохраните изменённую презентацию как файл PPTX.

Этот Java код показывает, как создать воронкообразную диаграмму:

```java
import com.aspose.slides.*;

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

### **Create Sunburst Charts**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Sunburst](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/#Sunburst) .
4. Сохраните изменённую презентацию как файл PPTX.

Этот Java код показывает, как создать радиальную диаграмму:

```java
import com.aspose.slides.*;

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

### **Create Histogram Charts**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Histogram](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/#Histogram) .
4. Получите доступ к рабочей книге данных диаграммы [IChartDataWorkbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Сохраните изменённую презентацию как файл PPTX.

Этот Java код показывает, как создать гистограмму:

```java
import com.aspose.slides.*;

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

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Create Radar Charts**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными и укажите предпочтительный тип диаграммы ([ChartType.Radar](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/#Radar) в данном случае) .
4. Сохраните изменённую презентацию как файл PPTX.

Этот Java код показывает, как создать радиальную (радужную) диаграмму:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Create Multi-Category Charts**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.ClusteredColumn](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/#ClusteredColumn) .
4. Получите доступ к рабочей книге данных диаграммы [IChartDataWorkbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Добавьте новые данные диаграммы для серий.
8. Сохраните изменённую презентацию как файл PPTX.

Этот Java код показывает, как создать мультикатегориальную диаграмму:

```java
import com.aspose.slides.*;

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

### **Create Map Charts**

Картографические диаграммы визуализируют географические данные и помогают сравнивать значения по регионам.

Этот Java код показывает, как создать картографическую диаграмму:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Create Combination Charts**

Комбинированная диаграмма (или combo chart) объединяет два или более типов диаграмм в одном графике. Такая диаграмма позволяет выделять, сравнивать или анализировать различия между несколькими наборами данных, помогая выявлять взаимосвязи.

![Комбинированная диаграмма](combination_chart.png)

Следующий Java код показывает, как создать комбинированную диаграмму, изображённую выше, в презентации PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // Удалить автоматически сгенерированные серии и категории.
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

    // Установить цвет основных вертикальных линий сетки.
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

## **Update Charts**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) , представляющего презентацию с диаграммой, которую необходимо обновить.
2. Получите ссылку на слайд, используя его индекс.
3. Пройдитесь по всем фигурам, чтобы найти нужную диаграмму.
4. Получите доступ к рабочему листу данных диаграммы.
5. Измените серию данных диаграммы, изменив значения серии.
6. Добавьте новую серию и заполните её данными.
7. Сохраните изменённую презентацию как файл PPTX.

Этот Java код показывает, как обновить диаграмму:

```java
import com.aspose.slides.*;

// Открывает презентацию, содержащую диаграмму для обновления
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Получаем диаграмму со слайда
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Устанавливаем индекс листа данных диаграммы
    int defaultWorksheetIndex = 0;

    // Получаем рабочий лист данных диаграммы
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Изменяем название категории диаграммы
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Берём первую серию диаграммы
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Обновляем данные серии
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Изменение имени серии
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Берём вторую серию диаграммы
    series = chart.getChartData().getSeries().get_Item(1);

    // Обновляем данные серии
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Изменение имени серии
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Теперь добавляем новую серию
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Берём третью серию диаграммы
    series = chart.getChartData().getSeries().get_Item(2);

    // Заполняем данные серии
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Сохраняем презентацию с диаграммой
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Data Range for a Chart**

Чтобы задать диапазон данных для диаграммы, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) , представляющего презентацию с диаграммой.
2. Получите ссылку на слайд, используя его индекс.
3. Пройдитесь по всем фигурам, чтобы найти нужную диаграмму.
4. Получите доступ к данным диаграммы и задайте диапазон.
5. Сохраните изменённую презентацию как файл PPTX.

Этот Java код показывает, как задать диапазон данных для диаграммы:

```java
import com.aspose.slides.*;

// Открывает презентацию, содержащую диаграмму
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Use Default Markers in Charts**

При использовании маркеров по умолчанию в диаграммах каждый ряд автоматически получает отдельный символ маркера.

Этот Java код показывает, как автоматически установить маркер для ряда диаграммы:

```java
import com.aspose.slides.*;

// Открывает презентацию, содержащую диаграмму
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
    // Берём вторую серию диаграммы
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // Теперь заполняем данные серии
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

Aspose.Slides поддерживает широкий спектр [chart types](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/), включая столбчатые, линейные, круговые, областные, рассеяния, гистограммы, радиальные и многие другие. Такая гибкость позволяет выбрать наиболее подходящий тип диаграммы для визуализации ваших данных.

**Как добавить новую диаграмму на слайд?**

Чтобы добавить диаграмму, сначала создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) , получите нужный слайд по индексу, а затем вызовите метод добавления диаграммы, указав тип диаграммы и начальные данные. Этот процесс интегрирует диаграмму непосредственно в вашу презентацию.

**Как обновить данные, отображаемые в диаграмме?**

Вы можете обновить данные диаграммы, получив доступ к её рабочей книге ([IChartDataWorkbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdataworkbook/)), очистив любые серии и категории по умолчанию и затем добавив свои собственные данные. Это позволяет актуализировать диаграмму в соответствии с новыми данными.

**Можно ли настроить внешний вид диаграммы?**

Да, Aspose.Slides предоставляет обширные возможности настройки. Вы можете изменять цвета, шрифты, подписи, легенды и другие [formatting elements](/slides/ru/androidjava/chart-entities/) чтобы адаптировать внешний вид диаграммы под конкретные требования дизайна.