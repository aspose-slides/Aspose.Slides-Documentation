---
title: Управление сериями данных диаграммы в презентациях на Android
linktitle: Серии данных
type: docs
url: /ru/androidjava/chart-series/
keywords:
- серии диаграммы
- перекрытие серий
- цвет серии
- имя серии
- точка данных
- ячейка рабочей книги
- промежуток между сериями
- отрицательное значение
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной промежутка и отрицательными значениями в презентациях на Android."
---
## **Обзор**

Диаграмма хранит данные в рабочей книге данных диаграммы. [IChartSeries](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/) представляет один набор связанных значений, и каждый [IChartDataPoint](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapoint/) в серии ссылается на одну или несколько ячеек рабочей книги. Объекты [IChartCategory](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartcategory/) предоставляют метки или группирующие значения, общие для серий. Поэтому имя серии, категории и значения точек привязаны к объектам [IChartDataCell](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatacell/), а не хранятся только как отображаемый текст.

Для типичной диаграммы категорий рабочая книга по умолчанию использует строку 0 для имён серий, столбец 0 для имён категорий и остальные ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-), начинаются с 0. Такое расположение удобно при создании диаграммы с данными по умолчанию, но не следует полагать, что каждый существующий график использует его. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, прежде чем менять значения в рабочей книге.

Настройки диаграммы имеют три разных уровня:

- Настройки уровня серии, такие как [IChartSeries.getFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#getFormat--), задают внешний вид всех точек в одной серии.
- Настройки отдельной точки, такие как [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), переопределяют внешний вид серии для одной точки.
- Настройки группы применяются к совместимым сериям, принадлежащим одному [IChartSeriesGroup](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseriesgroup/). Доступ к группе осуществляется через [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) при необходимости задать параметры, такие как перекрытие или ширина промежутка.

Когда явное заливание точки или серии не задано, стиль и тема диаграммы определяют автоматический внешний вид. Когда присутствует как форматирование серии, так и точки, форматирование точки имеет приоритет для этой точки.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установка перекрытия серий диаграммы**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#getOverlap--) сообщает, насколько столбцы или полосы перекрываются в 2‑D диаграмме, от -100 до 100 процентов. Это только чтение проекции параметра в родительской группе серий. Используйте [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) для обновления всех совместимых серий в этой группе. Эта опция применяется к типам диаграмм, отображающим сгруппированные полосы или столбцы; она не влияет на несвязанные группы серий в комбинированной диаграмме.

Следующий пример задаёт перекрытие для группы, содержащей первую серию:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Новая диаграмма содержит образцовые серии, категории и значения.
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

Используйте [IChartSeries.getFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#getFormat--) для установки заливки по умолчанию для всей серии. Если у точки уже задана явная заливка, её настройка [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) переопределяет заливку серии для этой точки.

Следующий пример применяет сплошную синюю заливку к первой серии:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Имя серии хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию для кластеризованной столбчатой диаграммы ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные константы в следующем примере делают эту структуру явной:

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

Вы также можете обновить ячейку, уже возвращённую [IChartSeries.getName](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#getName--). Такой подход избавляет от предположений о конкретных строке и столбце в существующей диаграмме:

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

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) возвращает цвет, рассчитанный из индекса серии и стиля диаграммы, в виде целого Android ARGB. Это тот цвет, который используется, когда заливка серии не определена явно. Вызов метода только считывает рассчитанный цвет; он не задаёт новую заливку.

Следующий пример выводит целочисленное значение автоматического цвета для каждой серии по умолчанию:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Точные целочисленные значения зависят от стиля и темы диаграммы.

## **Установка инвертированного цвета заливки для серии диаграммы**

Для столбчатых, колонных и пузырьковых серий [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) позволяет отображать отрицательные значения другим цветом. Установите обычную заливку серии как сплошную, включите инверсию и задайте цвет отрицательного значения через [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Отрицательные числа в рабочей книге остаются без изменений; изменяется только их цвет отображения.

Следующий пример заменяет данные диаграммы данными одной серии. Строка 0 листа содержит имя серии, столбец 0 — имена категорий, столбец 1 — значения:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

Вы можете включить инверсию для отдельной точки через [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присваивается отрицательное значение, чтобы эффект был виден:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её ячейке в рабочей книге значение `null`. Для столбчатой диаграммы plotted‑значение доступно через [IChartDataPoint.getValue](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Точка остаётся в той же позиции категории, но диаграмма рассматривает её значение как пустое согласно настройкам отображения пустых значений.

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

Диаграммы разброса используют отдельные ячейки X и Y, а пузырьковые добавляют ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое хотите удалить. Не вызывайте [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) при желании сохранить остальные точки, поскольку этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Скрытые ячейки, содержащие значения, — отдельный случай от пустых ячеек. Чтобы включать или исключать данные из скрытых строк и столбцов листа, см. [Включить данные из скрытых строк и столбцов](/slides/ru/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns).

Пустая ячейка рабочей книги представляет отсутствующие данные; ячейка, содержащая `0`, представляет известное числовое значение. Вызовите [IChartDataCell.setValue](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) с `null`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулём независимо от настройки отображения пустых ячеек.

Используйте [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) для выбора способа отображения пустых ячеек. Эта настройка применяется ко всей диаграмме. Она меняет способ построения пустот без заполнения пустой ячейки нулём или интерполированным значением.

Следующий автономный пример создаёт линейную диаграмму с одной серией, очищает значение для третьего дня и сохраняет диаграмму в каждом режиме. Входной файл не требуется. [IChartDataWorkbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdataworkbook/) использует лист 0, столбец 0 для меток категорий и столбец 1 для значений; строка 0 хранит имя серии. Окончательные данные: `10, 20, empty, 30, 40`.

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

    // Оставить третий день действительно пустым, сохранив его категорию и точку данных.
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

Каждый файл‑вывод сохраняет режим, выбранный перед сохранением: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте нужный режим и сохраните презентацию один раз вместо перебора режимов.

Сравнение ниже показывает одинаковые данные во всех трёх файлах. День 3 пуст во всех рабочих книгах:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. Линейная диаграмма позволяет легко сравнивать все три режима. Для столбчатых и колонных диаграмм нет линии, соединяющей пропущенную категорию, поэтому `Span` не может создать соединительный отрезок, показанный выше; отсутствующий столбец и столбец нулевой высоты могут выглядеть одинаково. Аналогично, диаграмма разброса только с маркерами не имеет соединительной линии. Не ожидайте три разных результата для каждого типа диаграммы; проверяйте вывод для используемого типа.

## **Установка ширины промежутка между сериями**

Ширина промежутка — пространство между соседними кластерами столбцов или полос, выраженное в процентах от их ширины. Как и перекрытие, она принадлежит родительской группе серий, а не отдельной серии. Вызовите [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) один раз для группы. Большее значение создаёт больше пространства между кластерами; меньшее — делает их плотнее.

Следующий пример меняет ширину промежутка и сохраняет только окончательную презентацию:

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

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/), используют данные диаграммы, но их серии не имеют одинаковой структуры значений или настроек. Например, диаграммы категорий используют категории и значения, диаграммы разброса — X и Y, а пузырьковые добавляют размеры пузырей. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина промежутка, применимы только к совместимым группам столбцов или полос.

**Что такое группа серий диаграммы?**

[IChartSeriesGroup](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseriesgroup/) содержит совместимые серии, которые разделяют настройки построения уровня группы. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы, полученной через одну серию, не обязательно изменит все серии в диаграмме.

**Создаёт ли новая диаграмма данные по умолчанию?**

Да. По умолчанию [IShapeCollection.addChart](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) создаёт примерные серии, категории и значения. Вы можете изменить эти ячейки или очистить коллекции серий и категорий перед добавлением полностью пользовательского набора данных. Существуют перегрузки, позволяющие создать диаграмму без данных по умолчанию.

**Как объекты диаграммы связаны с ячейками рабочей книги?**

Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [IChartDataWorkbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdataworkbook/). Изменение ссылки ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных сохраняйте выравнивание строк категорий и строк значений серий, чтобы каждая точка была построена под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Задайте соответствующей ячейке значение `null`, чтобы сохранить позицию категории точки как пустой. Используйте [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) только когда хотите удалить все точки из серии. Если вы также удаляете категории, обновите каждую серию, чтобы их значения оставались выровненными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и значения, установленного через [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Поддерживаемые диаграммы могут показывать пустоты как разрывы, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. См. [Управление отображением пустых ячеек](#control-the-display-of-empty-cells) для полного примера и визуального сравнения.

**Как форматируются отрицательные значения?**

Для поддерживаемых столбчатых, колонных и пузырьковых серий вызовите [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) и задайте цвет, возвращаемый [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Вы можете переопределить поведение для отдельной точки через [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Эти методы влияют на форматирование, а не на хранимые числовые значения.

**Какой формат выигрывает, если форматированы и серия, и точка?**

Явное форматирование точки имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если формат серии не определён, автоматический стиль и тему диаграммы. Настройки группы, такие как перекрытие и ширина промежутка, управляют расположением и не являются переопределениями форматирования уровня точки.

**Существует ли ограничение на количество серий в диаграмме?**

Aspose.Slides не налагает отдельного фиксированного ограничения на количество серий. На практике ограничения файлов презентации, доступная память, время рендеринга и читаемость диаграммы определяют практический предел.

**Что изменить, если столбцы слишком близко или слишком далеко друг от друга?**

Вызовите [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) для соответствующей родительской группы серий. Увеличьте значение, чтобы расширить пространство между кластерами, или уменьшите его, чтобы собрать кластеры ближе.