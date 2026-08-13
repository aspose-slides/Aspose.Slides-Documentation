---
title: Управление сериями данных диаграмм в презентациях на Java
linktitle: Серии данных
type: docs
url: /ru/java/chart-series/
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
- Java
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной промежутка и отрицательными значениями в презентациях с помощью Java."
---
## **Обзор**

Диаграмма хранит свои построенные данные в рабочей книге данных диаграммы. [IChartSeries](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/) представляет один набор связанных значений, и каждый [IChartDataPoint](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapoint/) в серии ссылается на одну или несколько ячеек рабочей книги. Объекты [IChartCategory](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartcategory/) предоставляют метки или значения группировки, общие для серии. Поэтому имя серии, категории и значения точек связаны с объектами [IChartDataCell](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/), а не хранятся только как отображаемый текст.

Для типичной диаграммы категорий рабочая книга по умолчанию использует строку 0 для имен серий, столбец 0 для имен категорий и оставшиеся ячейки — для значений серий. Индексы листа, строки и столбца, передаваемые в [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-), начинаются с нуля. Такая раскладка удобна, когда вы создаёте диаграмму с данными по умолчанию, но не следует предполагать, что каждая существующая диаграмма использует её. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, прежде чем изменять значения в рабочей книге.

Настройки диаграммы имеют три разных уровня:

- Настройки уровня серии, такие как [IChartSeries.getFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#getFormat--), задают внешний вид по умолчанию для всех точек одной серии.
- Настройки точек данных, такие как [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapoint/#getFormat--), переопределяют формат серии для отдельной точки.
- Настройки группы применяются к совместимым сериям, которые принадлежат одному [IChartSeriesGroup](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseriesgroup/). Получите доступ к группе через [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) при необходимости задать параметры, такие как перекрытие или ширина промежутка.

Когда явное заполнение точки или серии не задано, стиль и тема диаграммы определяют автоматический внешний вид. Когда присутствует как форматирование серии, так и точек, форматирование точек имеет приоритет для этой точки.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить перекрытие серии диаграммы**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#getOverlap--) сообщает, насколько столбцы или бары перекрываются в 2D‑диаграмме, в диапазоне от -100 до 100 процентов. Это только чтение проекции настройки в родительской группе серий. Используйте [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) для обновления всех совместимых серий в этой группе. Эта опция применима к типам диаграмм, отображающим группированные бары или столбцы; она не затрагивает несвязанные группы серий в комбинированной диаграмме.

Следующий пример задаёт перекрытие для группы, содержащей первую серию:

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

## **Изменить цвет заливки серии**

Используйте [IChartSeries.getFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#getFormat--) для задания заливки по умолчанию для всей серии. Если у точки уже задана явная заливка, её настройка [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapoint/#getFormat--) переопределит заливку серии для этой точки.

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

## **Изменить имя серии**

Имя серии хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию для группированных столбчатых диаграмм ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные константы в следующем примере делают эту структуру явной:

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

Вы также можете обновить ячейку, уже возвращённую [IChartSeries.getName](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#getName--). Такой подход избегает предположений о конкретных строках и столбцах в существующей диаграмме:

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

## **Получить автоматический цвет заливки серии**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) возвращает цвет, вычисленный из индекса серии и стиля диаграммы. Это цвет, используемый, когда заливка серии не определена явно. Вызов метода лишь читает рассчитанный цвет; он не задаёт новую заливку.

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

## **Установить инвертированный цвет заливки для серии диаграммы**

Для серий типа бар, столбец и пузырь [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) может отображать отрицательные значения другими цветами. Задайте обычную заливку серии сплошной, включите инверсию и задайте цвет для отрицательных значений через [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Отрицательные числа в рабочей книге остаются без изменений; меняется только их цвет отображения.

Следующий пример заменяет данные по умолчанию одной серией. Строка 0 листа содержит имя серии, столбец 0 — имена категорий, столбец 1 — значения:

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

Вы можете включить инверсию для одной точки через [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присваивается отрицательное значение, чтобы эффект был видим:

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

Чтобы сделать одну точку пустой, не удаляя остальные, присвойте её ячейке в рабочей книге значение `null`. Для столбчатой диаграммы отображаемое значение доступно через [IChartDataPoint.getValue](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapoint/#getValue--). Точка остаётся в той же позиции категории, но диаграмма считает её значение пустым в соответствии с настройками отображения пустых значений.

Следующий пример очищает только вторую точку первой серии:

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

Диаграммы разброса используют отдельные ячейки X и Y, а пузырьковые диаграммы также используют ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое требуется удалить. Не вызывайте [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapointcollection/#clear--) когда нужно сохранить остальные точки, поскольку этот метод удаляет все точки из коллекции.

## **Установить ширину промежутка серии**

Ширина промежутка — это пространство между соседними кластерами баров или столбцов, выраженное в процентах от ширины бара или столбца. Как и перекрытие, она принадлежит родительской группе серий, а не отдельной серии. Вызовите [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) один раз для группы. Большое значение создаёт больше пространства между кластерами; меньшее значение делает их плотнее.

Следующий пример меняет ширину промежутка и сохраняет только итоговую презентацию:

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

**Какие типы диаграмм поддерживают сериалы данных?**

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/charttype/), используют данные диаграммы, но их серии не всегда имеют одинаковую структуру значений или настройки. Например, диаграммы категорий используют категории и значения, диаграммы разброса — X и Y, а пузырьковые — добавляют размеры пузырей. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина промежутка, применяются только к совместимым группам баров или столбцов.

**Что такое группа серий диаграммы?**

[IChartSeriesGroup](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseriesgroup/) содержит совместимые серии, которые разделяют настройки построения уровня группы. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы через одну серию не обязательно изменит все серии в диаграмме.

**Содержит ли только что созданная диаграмма данные по умолчанию?**

Да. По умолчанию [IShapeCollection.addChart](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) создаёт примерные серии, категории и значения. Вы можете отредактировать эти ячейки или очистить как коллекцию серий, так и категорий перед добавлением полностью кастомного набора данных. Существует перегрузка, позволяющая создать диаграмму без данных по умолчанию.

**Как объекты диаграммы связаны с ячейками рабочей книги?**

Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [IChartDataWorkbook](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdataworkbook/). Изменение ссылочной ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных поддерживайте выравнивание строк категорий и строк значений серий, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Присвойте соответствующей ячейке значения `null`, чтобы сохранить позицию категории точки как пустую. Используйте [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapointcollection/#clear--) только когда необходимо удалить все точки из серии.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и значения, заданного через [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Поддерживаемые диаграммы могут отображать пустоты как пробелы, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации.

**Как форматируются отрицательные значения?**

Для поддерживаемых баров, столбцов и пузырей вызовите [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) и задайте цвет, возвращаемый [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Для отдельной точки можете переопределить поведение с помощью [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Эти методы влияют на форматирование, а не на хранимые числовые значения.

**Какой формат имеет приоритет, когда и серия, и точка отформатированы?**

Явное форматирование точки данных имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если формат серии не задан, автоматический стиль и тему диаграммы. Настройки группы, такие как перекрытие и ширина промежутка, управляют раскладкой и не являются переопределениями формата уровня точки.

**Есть ли ограничение на количество серий в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество серий. На практике ограничения задаются размерами файла презентации, доступной памятью, временем рендеринга и читабельностью диаграммы.

**Что менять, когда столбцы слишком близко или слишком далеко друг от друга?**

Вызовите [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) у соответствующей родительской группы серий. Увеличьте значение, чтобы расширить промежуток между кластерами, или уменьшите его, чтобы собрать кластеры ближе.