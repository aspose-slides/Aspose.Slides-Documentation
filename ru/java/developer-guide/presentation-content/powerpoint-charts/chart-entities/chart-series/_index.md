---
title: Управление рядами данных диаграммы в презентациях на Java
linktitle: Ряды данных
type: docs
url: /ru/java/chart-series/
keywords:
- ряды диаграммы
- перекрытие рядов
- цвет ряда
- имя ряда
- точка данных
- ячейка рабочей книги
- промежуток между рядами
- отрицательное значение
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как управлять рядами диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной промежутка и отрицательными значениями в презентациях с помощью Java."
---
## **Обзор**

Диаграмма может хранить построенные значения в ячейках рабочей книги или напрямую как числовые литералы. [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) представляет один набор связанных значений, а каждый [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) представляет точку в этом наборе. [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) объекты предоставляют метки или группирующие значения, общие для наборов. В диаграммах, созданных с данными по умолчанию, имена наборов, категории и значения точек используют [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) объекты из рабочей книги диаграммы.

Для типичной категориальной диаграммы рабочая книга по умолчанию использует строку 0 для имён наборов, столбец 0 для имён категорий и оставшиеся ячейки для значений наборов. Индексы листа, строки и столбца, передаваемые в [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-), нумеруются с нуля. Этот макет полезен, когда вы создаёте диаграмму с данными по умолчанию, но не следует считать, что каждая существующая диаграмма использует его. Для загруженной презентации проверьте ячейки, на которые ссылаются наборы, категории и точки данных, прежде чем менять значения в рабочей книге.

Настройки диаграммы имеют три разных уровня:

- Настройки уровня набора, такие как [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--), задают внешний вид по умолчанию для всех точек в одном наборе.
- Настройки точки данных, такие как [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--), переопределяют внешний вид набора для одной точки.
- Настройки группы применяются к совместимым наборам, принадлежащим одному [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/). Доступ к группе осуществляется через [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) — когда необходимо задать такие параметры, как перекрытие или ширина промежутка.

Если явное заполнение точки или набора не задано, стиль и тема диаграммы определяют автоматический внешний вид. Когда присутствуют как настройки набора, так и точки, настройки точки имеют приоритет для этой точки.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить значения ряда с использованием числовых литералов**

Используйте числовые литералы, когда значения ряда берутся из данных приложения или вычислений и не требуют ссылок на ячейки листа. Вызовите [setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) с [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals) перед назначением результата [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) каждой точки через [setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-).

Настройка коллекции управляет типом источника всех значений точек в данном ряду. Метод [getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--) каждой точки сообщает выбранный тип; изменить его можно через настройку коллекции. С `Worksheet` используйте [getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--) для доступа к ссылочной ячейке. С `DoubleLiterals` используйте [getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) или `setAsLiteralDouble` для чтения или записи числа напрямую.

В следующем примере создаётся столбчатая диаграмма с наборами и категориями по умолчанию, после чего вычисленные значения 10, 20 и т.д. присваиваются существующим точкам первого ряда. Затем презентация сохраняется, открывается заново и выводит сохранённые значения.

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

Тип источника значения точки отделён от [IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--), который определяет внутреннюю или внешнюю конфигурацию рабочей книги диаграммы. Использование числовых литералов само по себе не удаляет встраиваемую рабочую книгу. В этом примере рабочая книга остаётся доступной для меток категорий, имён наборов и остальных наборов. Смотрите [Chart Workbook](/slides/ru/java/chart-workbook/) для управления рабочей книгой.

Для диаграмм рассеивания и пузырей используйте [setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) и [setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) чтобы выбрать источники для [getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--) и [getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--). Диаграммы пузырей также используют [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) для [getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--). Установите каждый соответствующий источник в `DoubleLiterals` перед назначением чисел через метод `setAsLiteralDouble` этого значения.

## **Установить перекрытие рядов диаграммы**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) сообщает, насколько бары или столбцы перекрываются в 2‑D диаграмме, от ‑100 до 100 процентов. Это только считываемый проекционный параметр, задаваемый в родительской группе рядов. Используйте [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) чтобы обновить все совместимые ряды в этой группе. Эта опция применяется к типам диаграмм, отображающим сгруппированные бары или столбцы; она не влияет на несвязанные группы рядов в комбинированной диаграмме.

В следующем примере задаётся перекрытие для группы, содержащей первый ряд:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Новая диаграмма содержит примерные ряды, категории и значения.
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

## **Изменить цвет заливки ряда**

Используйте [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) чтобы задать заливку по умолчанию для всего ряда. Если у точки уже задана явная заливка, её настройка [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) переопределяет заливку ряда для этой точки.

В следующем примере применяется сплошная синяя заливка к первому ряду:

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

## **Изменить название ряда**

Название ряда хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию для сгруппированной столбчатой диаграммы ячейка B1 находится в строке 0, столбце 1 и содержит имя первого ряда. Именованные константы в следующем примере делают эту структуру явной:

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

Вы также можете обновить ячейку, уже используемую [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--). Такой подход избегает предположений о конкретных строках и столбцах в существующей диаграмме:

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

### **Создать ряд с именем из нескольких ячеек**

Составное имя ряда полезно, когда название продукта и период отчёта хранятся в разных ячейках рабочей книги. Например, можно объединить `Product A` из B1 и `2026` из C1 в одно имя ряда, при этом обе части остаются связанными с их исходными ячейками.

Используйте [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) для получения диапазона имён, затем передайте эту коллекцию в [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). Параметр `skipHiddenCells` контролирует включение скрытых ячеек: `true` — исключает их, `false` — включает. В этом примере используется `false`, чтобы включить каждую ячейку диапазона имён.

В следующем примере создаётся презентация с одним рядом и двумя точками данных. Ячейки B1:C1 содержат только имя ряда; A2:A3 — метки категорий, а B2:B3 — числовые значения.

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

    // Эти две ячейки задают имя ряда.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // Отдельные ячейки задают категории и числовые точки данных.
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

Получившееся имя ряда — `Product A 2026`, с пробелом между значениями двух ячеек. Легенда отображает его как одну запись для обоих столбцов. Ниже изображён результат:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Получить автоматический цвет заливки ряда**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) возвращает цвет, вычисленный из индекса ряда и стиля диаграммы. Это цвет, используемый, когда заливка ряда явно не задана. Вызов метода читает вычисленный цвет; он не назначает новую заливку.

В следующем примере выводится автоматический цвет каждого ряда по умолчанию:

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

## **Установить инвертированный цвет заливки для ряда диаграммы**

Для рядов‑баров, столбцов и пузырей [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) позволяет отображать отрицательные значения другой заливкой. Задайте обычную заливку ряда сплошной, включите инверсию и укажите цвет отрицательного значения через [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Отрицательные числа в рабочей книге остаются без изменений; меняется только их цвет отображения.

В следующем примере заменяется набор данных диаграммы одним рядом. Строка 0 листа содержит имя ряда, столбец 0 — метки категорий, столбец 1 — значения:

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

Вы можете включить инверсию для отдельной точки через [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). В следующем примере инверсия отключена для ряда и включена только для выбранной точки. Точке также присвоено отрицательное значение, чтобы эффект был виден:

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

## **Очистить конкретное значение точки данных**

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её ячейку в рабочей книге значение `null`. Для столбчатой диаграммы построенное значение доступно через [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--). Точка остаётся в том же положении категории, но диаграмма воспринимает её значение как пустое в соответствии с настройками отображения пустых значений.

В следующем примере очищается только вторая точка первого ряда:

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

Диаграммы рассеивания используют отдельные ячейки X и Y, а диаграммы пузырей — ещё ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое вы хотите удалить. Не вызывайте [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) если хотите сохранить остальные точки, потому что этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Скрытые ячейки, содержащие значения, — отдельный случай от пустых ячеек. Чтобы включать или исключать данные из скрытых строк и столбцов листа, см. [Include Data from Hidden Rows and Columns](/slides/ru/java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Пустая ячейка рабочей книги представляет отсутствующие данные; ячейка, содержащая `0`, представляет известное числовое значение. Вызовите [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) с `null`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулём независимо от настройки пустой ячейки.

Используйте [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) для выбора способа отображения пустых ячеек диаграммой. Эта настройка применяется ко всей диаграмме. Она меняет способ построения пустот без заполнения пустой ячейки нулём или интерполированным значением.

В следующем автономном примере создаётся линейная диаграмма с одним рядом, очищается значение для дня 3 и сохраняется диаграмма в каждом режиме. Входной файл не требуется. [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) использует лист 0, столбец 0 для меток категорий и столбец 1 для значений; строка 0 хранит имя ряда. Итоговые данные — `10, 20, empty, 30, 40`.

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

    // Оставить день 3 действительно пустым, при этом сохранить его категорию и точку данных.
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

Каждый файл вывода сохраняет режим, установленный перед сохранением: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте нужный режим и сохраните презентацию один раз вместо перебора режимов.

Сравнение ниже показывает одинаковые данные во всех трёх файлах. День 3 пуст в рабочей книге во всех случаях:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. Линейная диаграмма позволяет легко сравнить все три режима. Диаграммы‑бар и столбчатые не имеют линии, соединяющей пропущенные категории, поэтому `Span` не может создать соединительный сегмент, показанный выше; отсутствующий столбец и столбец нулевой высоты могут выглядеть одинаково. Аналогично, диаграмма‑рассеивание только с маркерами не имеет соединяющей линии. Не ожидайте трёх разных результатов для каждого типа диаграммы; проверяйте вывод для используемого типа.

## **Установить ширину промежутка между рядами**

Ширина промежутка — пространство между соседними кластерами баров или столбцов, выраженное в процентах от их ширины. Как и перекрытие, она относится к родительской группе рядов, а не к отдельному ряду. Вызовите [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) один раз для группы. Большее значение создаёт больше пространства между кластерами; меньшее — делает их плотнее.

В следующем примере меняется ширина промежутка и сохраняется только конечная презентация:

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

## **Вопросы и ответы**

**Какие типы диаграмм поддерживают ряды данных?**

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/), используют данные диаграммы, но их ряды не всегда имеют одинаковую структуру значений или настройки. Например, категориальные диаграммы используют категории и значения, диаграммы рассеивания — значения X и Y, а диаграммы пузырей добавляют размеры пузырей. Используйте метод создания точек данных, соответствующий типу ряда. Параметры, такие как перекрытие и ширина промежутка, применимы только к совместимым группам баров или столбцов.

**Что такое группа рядов диаграммы?**

[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) содержит совместимые ряды, которые разделяют настройки уровня группы. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы, полученной через один ряд, не обязательно изменит каждый ряд в диаграмме.

**Содержит ли недавно созданная диаграмма данные по умолчанию?**

Да. По умолчанию [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) создаёт примерные ряды, категории и значения. Вы можете отредактировать эти ячейки или очистить как коллекции рядов, так и категории перед добавлением полностью пользовательского набора данных. Существует перегрузка, позволяющая создать диаграмму без данных по умолчанию.

**Как объекты диаграммы связаны с ячейками рабочей книги?**

Имена рядов, метки категорий и значения точек данных ссылаются на ячейки в [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/). Изменение ссылочной ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных следите за тем, чтобы строки категорий и строки значений рядов были выровнены, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку, а не весь ряд?**

Задайте соответствующей ячейке значение `null`, чтобы сохранить позицию точки в категории как пустую точку. Используйте [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) только тогда, когда действительно хотите удалить все точки из ряда. Если вы также удаляете категории, обновите каждый ряд, чтобы их значения оставались согласованными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и значения, настроенного через [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Поддерживаемые диаграммы могут отображать пустоты как разрывы, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. См. [Control the Display of Empty Cells](#control-the-display-of-empty-cells) для полного примера и визуального сравнения.

**Как форматируются отрицательные значения?**

Для поддерживаемых рядов‑баров, столбцов и пузырей вызовите [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) и задайте цвет, возвращаемый [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Для отдельной точки поведение можно переопределить через [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Эти методы влияют на форматирование, а не на сохранённые числовые значения.

**Какой формат имеет приоритет, если и ряд, и точка отформатированы?**

Явное форматирование точки имеет приоритет для этой точки. Другие точки продолжают использовать явный формат ряда или, если формат ряда не задан, автоматический стиль и тему диаграммы. Настройки группы, такие как перекрытие и ширина промежутка, управляют расположением и не переопределяют форматирование точек.

**Есть ли ограничение на количество рядов в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество рядов. На практике ограничения файлов презентации, доступная память, время рендеринга и читаемость диаграммы определяют практический лимит.

**Что менять, если столбцы слишком близко расположены или слишком удалены?**

Вызовите [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) для соответствующей родительской группы рядов. Увеличьте значение, чтобы расширить пространство между кластерами, или уменьшите его, чтобы собрать кластеры ближе друг к другу.