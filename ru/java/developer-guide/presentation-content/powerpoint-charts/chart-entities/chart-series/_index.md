---
title: Управление данными серии диаграммы в презентациях на Java
linktitle: Серии данных
type: docs
url: /ru/java/chart-series/
keywords:
- серии диаграмм
- перекрытие серии
- цвет серии
- имя серии
- точка данных
- ячейка рабочей книги
- зазор серии
- отрицательное значение
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной зазора и отрицательными значениями в презентациях с Java."
---
## **Обзор**

Диаграмма хранит построенные данные в рабочей книге данных диаграммы. [IChartSeries](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/) представляет один набор сопутствующих значений, и каждый [IChartDataPoint](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapoint/) в серии ссылается на одну или несколько ячеек рабочей книги. Объекты [IChartCategory](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartcategory/) предоставляют подписи или значения группировки, общие для серии. Таким образом, имя серии, категории и значения точек связаны с объектами [IChartDataCell](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/), а не хранятся только как отображаемый текст.

Для типичной диаграммы категорий рабочая книга по умолчанию использует строку 0 для имён серий, столбец 0 для имён категорий и оставшиеся ячейки — для значений серий. Индексы листа, строки и столбца, передаваемые в [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-), начинаются с нуля. Такая раскладка удобна при создании диаграммы с данными по умолчанию, но не следует полагать, что каждый существующий график использует её. При работе с загруженной презентацией изучите ячейки, на которые ссылаются серии, категории и точки данных, прежде чем менять значения в рабочей книге.

Настройки диаграммы имеют три разных уровня области применения:

- Настройки уровня серии, такие как [IChartSeries.getFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#getFormat--), задают оформление по умолчанию для всех точек в одной серии.
- Настройки точек данных, такие как [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapoint/#getFormat--), переопределяют оформление серии для одной точки.
- Настройки группы применяются к совместимым сериям, принадлежащим одному [IChartSeriesGroup](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseriesgroup/). Доступ к группе осуществляется через [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) при необходимости установить такие параметры, как перекрытие или ширина зазора.

Когда явное заполнение точки или серии не задано, стиль диаграммы и её тема определяют автоматическое оформление. Если присутствует как оформление серии, так и точек, оформление точек имеет приоритет для этой точки.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установка перекрытия серий диаграммы**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#getOverlap--) сообщает, насколько столбцы или полосы перекрываются в двумерной диаграмме, в диапазоне от -100 до 100 процентов. Это только для чтения проекция настройки группы родительской серии. Используйте [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) для обновления всех совместимых серий в этой группе. Эта опция применяется к типам диаграмм, где отображаются сгруппированные столбцы или полосы; она не влияет на несвязанные группы серий в комбинированной диаграмме.

Следующий пример задаёт перекрытие для группы, содержащей первую серию:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Новая диаграмма содержит образцы серий, категорий и значений.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The series overlap](series_overlap.png)

## **Изменение цвета заливки серии**

Используйте [IChartSeries.getFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#getFormat--) для задания заливки по умолчанию для всей серии. Если у точки уже задано явное заполнение, её настройка [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapoint/#getFormat--) переопределяет заливку серии для этой точки.

Следующий пример применяет сплошную синюю заливку к первой серии:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The color of the series](series_color.png)

## **Изменение имени серии**

Имя серии хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию для сгруппированной столбчатой диаграммы ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные константы в следующем примере делают эту структуру явной:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Вы также можете обновить ячейку, уже полученную через [IChartSeries.getName](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#getName--). Такой подход позволяет избежать предположений о конкретных строках и столбцах в существующей диаграмме:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The series name](series_name.png)

## **Получение автоматического цвета заливки серии**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) возвращает цвет, вычисленный из индекса серии и стиля диаграммы. Это цвет, который используется, когда заливка серии не задана явно. Вызов метода лишь читает вычисленный цвет; он не задаёт новую заливку.

Следующий пример выводит автоматический цвет каждой серии по умолчанию:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Пример вывода для стиля диаграммы по умолчанию:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Точные цвета зависят от стиля и темы диаграммы.

## **Установка инверсии цвета заливки для серии диаграммы**

Для столбцовых, колонных и пузырчатых серий [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) позволяет отображать отрицательные значения другим цветом. Задайте обычную заливку серии как сплошную, включите инверсию и укажите цвет отрицательного значения через [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Отрицательные числа в рабочей книге остаются без изменений; меняется только их цвет отображения.

Следующий пример заменяет данные диаграммы по умолчанию одной серией. Строка 0 листа содержит имя серии, столбец 0 — имена категорий, столбец 1 — значения:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The inverted solid fill color](inverted_solid_fill_color.png)

Для одной точки инверсию можно включить через [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присвоено отрицательное значение, чтобы эффект был видим:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Очистка конкретного значения точки данных**

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её ячейку рабочей книги `null`. Для столбцовой диаграммы построенное значение доступно через [IChartDataPoint.getValue](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapoint/#getValue--). Точка данных остаётся на той же позиции категории, но диаграмма трактует её значение как пустое согласно настройкам обработки пустых значений.

Следующий пример очищает только вторую точку в первой серии:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Диаграммы разброса используют отдельные ячейки X и Y, а пузырчатые диаграммы — ещё и ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое нужно убрать. Не вызывайте [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapointcollection/#clear--) если хотите оставить остальные точки, потому что этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Пустая ячейка рабочей книги обозначает отсутствие данных; ячейка, содержащая `0`, представляет известное числовое значение. Вызовите [IChartDataCell.setValue](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) с `null`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулём независимо от настройки пустой ячейки.

Используйте [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) для выбора способа отображения пустых ячеек. Эта настройка применяется ко всей диаграмме. Она меняет способ построения пустот, не заполняя пустую ячейку нулём или интерполированным значением.

Следующий автономный пример создаёт линейную диаграмму с одной серией, очищает значение для третьего дня и сохраняет одну и ту же диаграмму в каждом режиме. Входной файл не требуется. [IChartDataWorkbook](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdataworkbook/) использует лист 0, столбец 0 для меток категорий и столбец 1 для значений; строка 0 содержит имя серии. Итоговые данные: `10, 20, empty, 30, 40`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Оставить день 3 действительно пустым, сохранив его категорию и точку данных.
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Каждый выходной файл сохраняет режим, установленный перед сохранением: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте нужный режим и сохраните презентацию один раз вместо перебора режимов.

Сравнение ниже показывает одинаковые данные во всех трёх файлах. День 3 пуст в рабочей книге во всех случаях:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. Линейная диаграмма позволяет легко сравнить все три режима. У столбцовых и колонных диаграмм нет линии, соединяющей отсутствующую категорию, поэтому `Span` не может создать соединительный сегмент, показанный выше; отсутствующий столбец и столбец нулевой высоты также могут выглядеть одинаково. Аналогично, диаграмма разброса только с маркерами не имеет соединяющей линии. Не ожидайте три различных результата для каждого типа диаграммы; проверьте вывод для используемого типа.

## **Установка ширины зазора серии**

Ширина зазора — это пространство между соседними группами столбцов или полос, выраженное в процентах от ширины столбца или полосы. Как и перекрытие, она относится к группе родительской серии, а не к отдельной серии. Вызовите [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) один раз для группы. Большее значение создаёт больше пространства между кластерами; меньшее — делает их плотнее.

Следующий пример меняет ширину зазора и сохраняет только финальную презентацию:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The gap width](gap_width.png)

## **FAQ**

**Какие типы диаграмм поддерживают серии данных?**

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/charttype/), используют данные диаграммы, но их серии не всегда имеют одинаковую структуру значений или настройки. Например, диаграммы категорий используют категории и значения, диаграммы разброса — X и Y, а пузырчатые диаграммы добавляют размеры пузырей. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина зазора, применимы только к совместимым группам столбцов или полос.

**Что такое группа серий диаграммы?**

[IChartSeriesGroup](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseriesgroup/) содержит совместимые серии, которые разделяют настройки построения уровня группы. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы, полученной через одну серию, не обязательно меняет все серии в диаграмме.

**Содержит ли вновь созданная диаграмма данные по умолчанию?**

Да. По умолчанию [IShapeCollection.addChart](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) создаёт образцы серий, категорий и значений. Вы можете отредактировать эти ячейки или очистить коллекции серий и категорий перед добавлением полностью пользовательского набора данных. Существует перегрузка, позволяющая создать диаграмму без данных по умолчанию.

**Как объекты диаграммы связаны с ячейками рабочей книги?**

Имена серий, подписи категорий и значения точек данных ссылаются на ячейки в [IChartDataWorkbook](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdataworkbook/). Изменение ссылки‑ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных следите за тем, чтобы строки категорий и строки значений серий были согласованы, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Установите соответствующую ячейку значения в `null`, чтобы точка сохранила своё положение в категории как пустая. Используйте [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapointcollection/#clear--) только когда действительно нужно удалить все точки из этой серии. Если вы также удаляете категории, обновите каждую серию, чтобы их значения оставались согласованными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и значения, установленного через [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Поддерживаемые диаграммы могут отображать пустоты как разрывы, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. См. раздел **Управление отображением пустых ячеек** для полного примера и визуального сравнения.

**Как форматируются отрицательные значения?**

Для поддерживаемых столбцовых, колонных и пузырчатых серий вызовите [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) и задайте цвет, возвращаемый [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Поведение отдельной точки можно переопределить с помощью [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Эти методы влияют на оформление, а не на сохранённые числовые значения.

**Какой формат выигрывает, когда одновременно отформатированы и серия, и точка?**

Явное форматирование точки данных имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если формат серии не определён, автоматический стиль и тему диаграммы. Настройки группы, такие как перекрытие и ширина зазора, управляют размещением и не являются переопределениями формата точек.

**Существует ли ограничение на количество серий в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество серий. На практике ограничения файлов презентации, доступная память, время рендеринга и читаемость диаграммы определяют практический предел.

**Что изменить, если столбцы находятся слишком близко друг к другу или слишком далеко?**

Вызовите [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) для соответствующей группы родительской серии. Увеличьте значение, чтобы расширить пространство между кластерами, или уменьшите его, чтобы приблизить кластеры друг к другу.