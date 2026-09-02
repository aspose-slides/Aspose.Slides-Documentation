---
title: Управление данными серий диаграмм в презентациях на Android
linktitle: Серии данных
type: docs
url: /ru/androidjava/chart-series/
keywords:
- серии диаграмм
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

Диаграмма хранит свои построенные данные в рабочей книге данных диаграммы. [IChartSeries](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/) представляет один набор связанных значений, и каждый [IChartDataPoint](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapoint/) в серии ссылается на одну или несколько ячеек рабочей книги. Объекты [IChartCategory](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartcategory/) предоставляют метки или группирующие значения, общие для серий. Поэтому имя серии, категории и значения точек связаны с объектами [IChartDataCell](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatacell/), а не хранятся только как отображаемый текст.

Для типичной диаграммы категорий рабочая книга по умолчанию использует строку 0 для имен серий, столбец 0 для имен категорий и остальные ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-), нумеруются с 0. Такой макет удобен при создании диаграммы с данными по умолчанию, но не следует полагать, что каждая существующая диаграмма использует его. При работе с загруженной презентацией проверьте ячейки, на которые ссылаются серии, категории и точки данных, прежде чем изменять значения в рабочей книге.

Настройки диаграммы имеют три разных уровня:

- Настройки уровня серии, такие как [IChartSeries.getFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#getFormat--), задают внешний вид по умолчанию для всех точек в одной серии.
- Настройки точки данных, такие как [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), переопределяют внешний вид серии для отдельной точки.
- Настройки группы применяются к совместимым сериям, принадлежащим одному [IChartSeriesGroup](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseriesgroup/). Получить группу можно через [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) при необходимости задать параметры, такие как перекрытие или ширина промежутка.

Если явное заполнение точки или серии не задано, стиль диаграммы и тема определяют автоматический внешний вид. Когда присутствует как форматирование серии, так и точек, форматирование точек имеет приоритет для этой точки.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установка перекрытия серий диаграммы**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#getOverlap--) сообщает, насколько полосы или столбцы перекрываются в двумерной диаграмме, от ‑100 до 100 процентов. Это только для чтения проекция настройки группы родительских серий. Используйте [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) для обновления всех совместимых серий в этой группе. Эта опция применяется к типам диаграмм, отображающим сгруппированные полосы или столбцы; она не влияет на несвязанные группы серий в комбинированной диаграмме.

Следующий пример задает перекрытие для группы, содержащей первую серию:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Новая диаграмма содержит примерные серии, категории и значения.
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

Используйте [IChartSeries.getFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#getFormat--) для задания заливки по умолчанию для всей серии. Если у точки уже задано явное заполнение, её настройка [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) переопределяет заливку серии для этой точки.

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

Имя серии хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию, созданной для кластеризованной столбчатой диаграммы, ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные константы в следующем примере делают эту структуру явной:

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

Вы также можете обновить ячейку, уже возвращённую [IChartSeries.getName](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#getName--). Такой подход избавляет от предположений о конкретных строках и столбцах в существующей диаграмме:

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

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) возвращает цвет, вычисленный из индекса серии и стиля диаграммы, в виде целого числа Android ARGB. Это цвет, используемый, когда заливка серии не задана явно. Вызов метода только читает вычисленный цвет; он не задаёт новую заливку.

Следующий пример выводит автоматическое целочисленное значение цвета каждой серии по умолчанию:

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

## **Установка инверсии заливки для серии диаграммы**

Для столбчатых, линейных и пузырьковых серий [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) может отображать отрицательные значения другим заполнением. Установите обычную заливку серии сплошной, включите инверсию и задайте цвет отрицательного значения через [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Отрицательные числа в рабочей книге остаются без изменений; меняется только их отображаемый цвет.

Следующий пример заменяет данные диаграммы данными одной серии. Строка листа 0 содержит имя серии, столбец 0 — имена категорий, столбец 1 — значения:

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

Вы можете включить инверсию для одной точки через [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присвоено отрицательное значение, чтобы эффект был виден:

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

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её базовой ячейке рабочей книги значение `null`. Для столбчатой диаграммы построенное значение доступно через [IChartDataPoint.getValue](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Точка данных остаётся в той же позиции категории, но диаграмма рассматривает её значение как пустое в соответствии с настройками отображения пустых значений.

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

Диаграммы разброса используют отдельные ячейки X и Y, а пузырьковые диаграммы также используют ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое вы хотите удалить. Не вызывайте [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) когда нужно сохранить другие точки, так как этот метод удаляет все точки из коллекции.

## **Установка ширины промежутка между сериями**

Ширина промежутка — это пространство между соседними кластерами столбцов или полос, выраженное в процентах от их ширины. Как и перекрытие, она относится к группе родительских серий, а не к отдельной серии. Вызовите [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) один раз для группы. Большое значение создаёт более широкий промежуток между кластерами; меньшее значение делает их плотнее.

Следующий пример изменяет ширину промежутка и сохраняет только итоговую презентацию:

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

**Какие типы диаграмм поддерживают серии данных?**

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/), используют данные диаграммы, но их серии не всегда имеют одинаковую структуру значений или настройки. Например, диаграммы категорий используют категории и значения, диаграммы разброса — значения X и Y, а пузырьковые — добавляют размеры пузырей. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина промежутка, применимы только к совместимым группам столбцов или полос.

**Что такое группа серий диаграммы?**

[IChartSeriesGroup](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseriesgroup/) содержит совместимые серии, которые разделяют настройки построения на уровне группы. Комбинированная диаграмма может включать более одной группы, поэтому изменение группы через одну серию не обязательно меняет все серии в диаграмме.

**Создаётся ли в новой диаграмме набор данных по умолчанию?**

Да. По умолчанию [IShapeCollection.addChart](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) создает примерные серии, категории и значения. Вы можете изменить эти ячейки или очистить как серии, так и коллекции категорий перед добавлением полностью пользовательского набора данных. Есть перегрузка, позволяющая создать диаграмму без данных по умолчанию.

**Как объекты диаграммы связаны с ячейками рабочей книги?**

Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [IChartDataWorkbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdataworkbook/). Изменение ссылочной ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных следите за тем, чтобы строки категорий и строки значений серий были согласованы, чтобы каждая точка была построена под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Задайте соответствующей ячейке значение `null`, чтобы сохранить позицию категории точки как пустой. Используйте [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) только когда нужно удалить все точки из серии. Если вы также удаляете категории, обновите каждую серию, чтобы их значения оставались согласованными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и настройки, заданной через [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Поддерживаемые диаграммы могут показывать пустоты как пробелы, как нулевые значения или соединяя соседние точки. Выберите параметр, соответствующий смыслу отсутствующих данных в вашей презентации.

**Как форматируются отрицательные значения?**

Для поддерживаемых столбчатых, линейных и пузырьковых серий вызовите [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) и задайте цвет, возвращаемый [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Вы можете переопределить поведение для отдельной точки с помощью [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Эти методы влияют на форматирование, а не на хранимые числовые значения.

**Какой формат выигрывает, если одновременно отформатированы серия и точка?**

Явное форматирование точки данных имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если формат серии не задан, автоматический стиль и тему диаграммы. Настройки группы, такие как перекрытие и ширина промежутка, управляют расположением и не являются переопределениями форматирования точек.

**Существует ли ограничение на количество серий в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество серий. На практике ограничения задаются размером файла презентации, доступной памятью, временем рендеринга и читаемостью диаграммы.

**Что изменить, если столбцы слишком близко друг к другу или слишком далеко?**

Вызовите [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) у соответствующей группы родительских серий. Увеличьте значение, чтобы расширить пространство между кластерами, или уменьшите его, чтобы собрать их ближе.