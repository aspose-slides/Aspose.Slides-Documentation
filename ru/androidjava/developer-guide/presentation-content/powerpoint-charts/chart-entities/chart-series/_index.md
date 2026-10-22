---
title: Управление сериями данных диаграмм в презентациях на Android
linktitle: Серии данных
type: docs
url: /ru/androidjava/chart-series/
keywords:
- серии диаграмм
- перекрытие серий
- цвет серий
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

Диаграмма может хранить построенные значения в ячейках рабочей книги или напрямую как числовые литералы. [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) представляет один набор связанных значений, а каждый [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) представляет точку в этом наборе. Объекты [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) предоставляют метки или группирующие значения, общие для серий. В диаграммах, созданных с данными по умолчанию, имена серий, категории и значения точек используют объекты [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) из рабочей книги диаграммы.

Для типичной категориальной диаграммы рабочая книга по умолчанию использует строку 0 для имён серий, столбец 0 для имён категорий и остальные ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) являются нулевыми. Такая схема полезна при создании диаграммы с данными по умолчанию, но не следует полагать, что каждая существующая диаграмма использует её. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, перед изменением значений в рабочей книге.

Настройки имеют три разных уровня:

- Настройки уровня серии, такие как [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--), предоставляют внешний вид по умолчанию для всех точек в одной серии.
- Настройки отдельной точки данных, такие как [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), переопределяют внешний вид серии для одной точки.
- Настройки группы применяются к совместимым сериям, принадлежащим одному [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/). Получите доступ к группе через [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) когда необходимо задать параметры, такие как перекрытие или ширина промежутка.

Если явная заливка точки или серии не задана, стиль и тема диаграммы определяют автоматическое оформление. Когда присутствуют как форматирование серии, так и точки, форматирование точки имеет приоритет для этой точки.

![серия диаграммы PowerPoint](chart-series-powerpoint.png)

## **Установка значений серии с использованием числовых литералов**

Используйте числовые литералы, когда значения серии получаются из данных приложения или вычислений и не требуют ссылок на ячейки листа. Вызовите [setDataSourceTypeForValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) с [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/#DoubleLiterals) перед присвоением каждому результату [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) через [setAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-).

Настройка коллекции управляет типом источника всех значений точек в этой серии. Метод [getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibasechartvalue/#getDataSourceType--) каждой точки возвращает выбранный тип; измените его через настройку коллекции. При использовании `Worksheet` применяйте [getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isinglecellchartvalue/#getAsCell--) для доступа к ссылочной ячейке. При `DoubleLiterals` используйте [getAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) или `setAsLiteralDouble` для прямого чтения или записи числа.

В следующем примере создаётся столбчатая диаграмма с сериями и категориями по умолчанию, затем ей присваиваются вычисленные значения 10, 20 и т.д. существующим точкам первой серии. Презентация сохраняется, открывается вновь и выводит сохранённые значения.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Тип источника значения точки отделён от [IChartData.getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) который определяет внутреннюю или внешнюю конфигурацию рабочей книги диаграммы. Использование числовых литералов само по себе не удаляет встраиваемую рабочую книгу. В этом примере рабочая книга остаётся доступной для меток категорий, имён серий и остальных серий. См. [Рабочая книга диаграммы](/slides/ru/androidjava/chart-workbook/) для управления рабочей книгой.

Для точечных и пузырьковых диаграмм используйте [setDataSourceTypeForXValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) и [setDataSourceTypeForYValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-), чтобы выбрать источники для [getXValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getXValue--) и [getYValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getYValue--). Пузырьковые диаграммы также используют [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) для [getBubbleSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getBubbleSize--). Установите каждый соответствующий источник в `DoubleLiterals` перед присвоением чисел через метод `setAsLiteralDouble` этого значения.

## **Установка перекрытия серии диаграммы**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) сообщает, насколько столбцы или бары перекрываются в 2‑D диаграмме, от -100 до 100 процентов. Это только чтение настройки у родительской группы серий. Используйте [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) чтобы обновить все совместимые серии в этой группе. Эта опция применяется к типам диаграмм, отображающим сгруппированные столбцы или бары; она не влияет на несвязанные группы серий в комбинированной диаграмме.

В следующем примере задаётся перекрытие для группы, содержащей первую серию:

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

![Перекрытие серии](series_overlap.png)

## **Изменение цвета заливки серии**

Используйте [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) чтобы задать заливку по умолчанию для всей серии. Если у точки уже задана явная заливка, её настройка [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) переопределяет заливку серии для этой точки.

В следующем примере применяется сплошная синяя заливка к первой серии:

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

![Цвет серии](series_color.png)

## **Изменение названия серии**

Имя серии хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию, создаваемой для сгруппированной столбчатой диаграммы, ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные константы в следующем примере делают эту структуру явной:

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

Вы также можете обновить ячейку, уже ссылку на которую имеет [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--). Этот подход исключает предположения о конкретных строке и столбце в существующей диаграмме:

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

![Имя серии](series_name.png)

### **Создание серии с именем из нескольких ячеек**

Составное имя серии полезно, когда название продукта и отчетный период хранятся в отдельных ячейках рабочей книги. Например, можно объединить `Product A` в B1 и `2026` в C1 в одно имя серии, при этом оба элемента остаются привязанными к своим исходным ячейкам.

Используйте [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) чтобы получить диапазон имён, затем передайте эту коллекцию в [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). Параметр `skipHiddenCells` определяет, включаются ли скрытые ячейки: `true` исключает их, `false` включает. В этом примере используется `false`, чтобы включить каждую ячейку в диапазоне имён.

В следующем примере создаётся презентация с одной серией и двумя точками данных. Ячейки B1:C1 предоставляют только имя серии; A2:A3 — метки категорий, а B2:B3 — числовые значения.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Эти две ячейки предоставляют имя серии.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // Отдельные ячейки предоставляют категории и числовые точки данных.
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Получившееся имя серии — `Product A 2026`, с пробелом между значениями двух ячеек. Легенда отображает его как одну запись для обоих столбцов. Ниже изображение результата:

![Столбчатая диаграмма с значениями Север и Юг и составным именем серии Product A 2026 в легенде](composite_series_name.png)

## **Получение автоматического цвета заливки серии**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) возвращает цвет, вычисленный из индекса серии и стиля диаграммы, в виде целого числа Android ARGB. Это цвет, который используется, когда заливка серии не определена явно. Вызов метода считывает вычисленный цвет; он не задаёт новую заливку.

В следующем примере выводится целочисленное значение автоматического цвета каждой серии по умолчанию:

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

Для серий баров, столбцов и пузырьков [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) позволяет отображать отрицательные значения другой заливкой. Установите обычную заливку серии сплошной, включите инверсию и задайте цвет отрицательного значения через [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Отрицательные числа остаются без изменений в рабочей книге; меняется только их цвет отображения.

В следующем примере заменяются данные диаграммы по умолчанию одной серией. Строка 0 листа содержит имя серии, столбец 0 — имена категорий, столбец 1 — значения:

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

![Инвертированный сплошной цвет заливки](inverted_solid_fill_color.png)

Инверсию можно включить для отдельной точки через [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также задаётся отрицательное значение, чтобы эффект был видим:

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

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её базовую ячейку рабочей книги значением `null`. Для столбчатой диаграммы построенное значение доступно через [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Точка остаётся в том же положении категории, но диаграмма рассматривает её значение как пустое в соответствии с настройками отображения пустых значений.

В следующем примере очищается только вторая точка первой серии:

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

Точечные диаграммы используют отдельные ячейки X и Y, а пузырьковые — также ячейку размера. Очищайте только ячейку, представляющую значение, которое необходимо удалить. Не вызывайте [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) когда нужно сохранить остальные точки, так как этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Скрытые ячейки, содержащие значения, отличаются от пустых ячеек. Чтобы включать или исключать данные из скрытых строк и столбцов листа, см. [Включить данные из скрытых строк и столбцов](/slides/ru/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns).

Пустая ячейка рабочей книги представляет отсутствующие данные; ячейка, содержащая `0`, представляет известное числовое значение. Вызовите [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) с `null`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулём независимо от настроек пустой ячейки.

Используйте [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) чтобы выбрать способ отображения пустых ячеек в диаграмме. Эта настройка применяется ко всей диаграмме. Она меняет способ построения пустот, не заполняя пустую ячейку рабочей книги нулём или интерполированным значением.

В следующем независимом примере создаётся линейная диаграмма с одной серией, очищается значение для Дня 3 и сохраняется диаграмма в каждом режиме. Входной файл не требуется. [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) использует лист 0, столбец 0 для меток категорий и столбец 1 для значений; строка 0 содержит имя серии. Финальные данные: `10, 20, empty, 30, 40`.

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

    // Оставить День 3 действительно пустым, при этом сохранить его категорию и точку данных.
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

Каждый выходной файл сохраняет режим, установленный перед сохранением: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте нужный режим и сохраните презентацию один раз, вместо перебора режимов.

Сравнение ниже показывает одинаковые данные во всех трёх файлах. День 3 пустой в рабочей книге во всех случаях:

![Линейные диаграммы с одинаковыми данными: Gap разрывает линию на Дне 3, Zero опускает линию до нуля, а Span соединяет День 2 с Днём 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. Линейная диаграмма позволяет легко сравнивать все три режима. Диаграммы баров и столбцов не имеют линии, соединяющей пропущенную категорию, поэтому `Span` не может создать соединительный сегмент, показанный выше; пустой столбец и столбец нулевой высоты могут выглядеть одинаково. Аналогично, точечная диаграмма только с маркерами не имеет соединительной линии. Не ожидайте три различных результата для каждого типа диаграммы; проверьте вывод для используемого типа.

## **Установка ширины промежутка серии**

Ширина промежутка — это пространство между соседними кластерами баров или столбцов, выраженное в процентах от ширины бара или столбца. Как и перекрытие, она относится к родительской группе серий, а не к отдельной серии. Вызовите [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) один раз для группы. Большое значение создаёт больше пространства между кластерами; небольшое значение делает их плотнее.

В следующем примере изменяется ширина промежутка и сохраняется только финальная презентация:

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

![Ширина промежутка](gap_width.png)

## **Часто задаваемые вопросы**

**Какие типы диаграмм поддерживают серии данных?**

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) используют данные диаграммы, но их серии не имеют одинаковой структуры значений или параметров. Например, категорические диаграммы используют категории и значения, точечные — X и Y значения, а пузырьковые — добавляют размеры пузырей. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина промежутка, применимы только к совместимым группам баров или столбцов.

**Что такое группа серий диаграммы?**

[IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) содержит совместимые серии, которые разделяют настройки построения уровня группы. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы, к которой доступна через одну серию, не обязательно изменит все серии в диаграмме.

**Содержит ли вновь созданная диаграмма данные по умолчанию?**

Да. По умолчанию [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) создаёт примерные серии, категории и значения. Вы можете изменять эти ячейки или очистить коллекции серий и категорий перед добавлением полностью пользовательского набора данных. Перегруженный метод также может создать диаграмму без данных по умолчанию.

**Как объекты диаграммы связаны с ячейками рабочей книги?**

Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/). Изменение ссылочной ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных держите строки категорий и строки значений серий выровненными, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Задайте соответствующей ячейке значения `null`, чтобы сохранить категориальное положение точки как пустой. Используйте [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) только когда нужно удалить все точки из этой серии. Если вы также удаляете категории, обновите каждую серию, чтобы их значения оставались согласованными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и значения, установленного через [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Поддерживаемые диаграммы могут отображать пустоты как промежутки, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. См. [Управление отображением пустых ячеек](#control-the-display-of-empty-cells) для полного примера и визуального сравнения.

**Как форматируются отрицательные значения?**

Для поддерживаемых серий баров, столбцов и пузырей вызовите [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) и задайте цвет, возвращаемый [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Вы можете переопределить поведение для отдельной точки с помощью [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Эти методы влияют на форматирование, а не на сохранённые числовые значения.

**Какое форматирование имеет приоритет, когда отформатированы и серия, и точка?**

Явное форматирование точки имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если формат серии не определён, автоматический стиль и тему диаграммы. Настройки группы, такие как перекрытие и ширина промежутка, управляют расположением и не являются переопределением форматирования точек.

**Есть ли ограничение на количество серий в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество серий. На практике ограничения файлов презентаций, доступная память, время рендеринга и читаемость диаграммы определяют практический предел.

**Что изменить, когда столбцы слишком близко друг к другу или слишком далеко?**

Вызовите [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) для соответствующей родительской группы серий. Увеличьте значение, чтобы расширить пространство между кластерами, или уменьшите его, чтобы собрать кластеры ближе.