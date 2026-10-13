---
title: Настройка осей диаграмм в презентациях на Android
linktitle: Ось диаграммы
type: docs
url: /ru/androidjava/chart-axis/
keywords:
- ось диаграммы
- вертикальная ось
- горизонтальная ось
- настройка оси
- манипулирование осью
- управление осью
- свойства оси
- максимальное значение
- минимальное значение
- линия оси
- формат даты
- заголовок оси
- позиция оси
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как с помощью Aspose.Slides for Android через Java настраивать оси диаграмм в презентациях PowerPoint для отчетов и визуализаций."
---
## **Обзор**

Эта статья объясняет, как настраивать оси диаграмм с помощью Aspose.Slides for Android через Java. Она охватывает вычисленные значения осей, переключение строк и столбцов диаграммы, видимость осей, интервалы подписей категорий и делений, датированные категории и их форматирование, вращение заголовка, позиционирование осей, единицы отображения и логарифмическое масштабирование.

## **Получение максимальных значений на вертикальной оси диаграмм**

Создайте [Презентация](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и добавьте диаграмму области с данными по умолчанию. Вызовите [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) перед чтением вычисленных значений осей, чтобы макет диаграммы был актуален.

Считайте [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) и [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) для пределов оси, а также [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) и [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) для интервалов делений. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) и [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) предоставляют шкалы единиц времени, которые актуальны для датированных осей. Пример сохраняет эти значения в локальные переменные и сохраняет диаграмму.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Поменять данные между осями**

Используйте [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) для обмена ролями рядов и категорий в данных диаграммы. Каждая прежняя категория становится рядом, а каждый прежний ряд становится категорией. Это меняет способ группировки данных; это не меняет местами горизонтальную и вертикальную оси. Пример использует [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) для привязки данных по умолчанию к `Sheet1!A1:D5`, включая строку заголовка и столбец категорий, перед переключением строк и столбцов. Он сохраняет диаграмму с четырьмя рядами и тремя категориями.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Отключить вертикальную ось для линейных диаграмм**

Вызовите [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) с `false` у вертикальной оси, чтобы скрыть её. Пример создаёт линейную диаграмму с данными по умолчанию и сохраняет её с скрытой вертикальной осью.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Отключить горизонтальную ось для линейных диаграмм**

Вызовите [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) с `false` у горизонтальной оси, чтобы скрыть её. Пример создаёт линейную диаграмму с данными по умолчанию и сохраняет её с скрытой горизонтальной осью.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Изменить ось категорий**

Используйте [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) для выбора датированной или текстовой оси категорий. Этот пример требует `ExistingChart.pptx`, где диаграмма является первой фигурой на первом слайде, а ячейки категорий содержат числовые даты Excel. Он меняет горизонтальную ось на датированную. Вызов [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) с `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) с `1` и [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) с `TimeUnitType.Months` размещают основные деления через один‑месячный интервал.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Управление интервалами подписей оси категорий**

Когда диаграмма имеет много категорий, можно уменьшить количество видимых подписей оси, не удаляя категории и точки данных. Вызовите [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) с `false`, затем передайте желаемый интервал категорий в [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Для текстовых категорий в обычном порядке отсчёт начинается с первой категории:

| Интервал | Подписи, отображаемые в примере |
| --- | --- |
| `1` | Категория 1, Категория 2, Категория 3, ... Категория 24 |
| `2` | Категория 1, Категория 3, Категория 5, ... Категория 23 |
| `3` | Категория 1, Категория 4, Категория 7, ... Категория 22 |

Интервал `3` отображает каждую третью подпись, оставляя две подписи скрытыми между отображаемыми. Это не удаляет соответствующие столбцы. Автоматический интервал выбирает значение на основе доступного пространства; он не обязателен отображать каждую подпись.

Отметки делений имеют отдельные настройки. Вызовите [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) с `false` и используйте [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) для задания их интервала. Например, `1` оставляет отметку деления на каждом интервале категории, тогда как подписи появляются только каждые три категории. Используйте [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) с видимым стилем, чтобы увидеть результат. Повторный вызов любого автоматического сеттера с `true` снова позволяет диаграмме подобрать интервал автоматически.

Следующий автономный пример создаёт 24 категории и один ряд, затем сохраняет три слайда в `CategoryAxisIntervals.pptx`: автоматический интервал, ручной интервал подписи с независимыми отметками деления и восстановленный автоматический интервал. Две копии сохраняют исходные данные диаграммы. Входная презентация не требуется. Горизонтальный текст подписи делает разницу в плотности легко заметной.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Слайд 2: показывать каждую третью подпись, но оставлять отметку деления для каждой категории.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Слайд 3: позволить диаграмме снова выбрать оба интервала.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatic spacing (slide 1):** In this rendering, every second category label is displayed and wraps onto two lines. The automatic result can vary with chart size, fonts, and the renderer.

![Автоматический интервал подписей категорий с видимыми всеми 24 столбцами](category-axis-automatic.png)

**Manual spacing (slide 2):** Every third label is displayed on one line, while tick marks remain at every category interval. All 24 columns, including those without labels, remain visible with the same values. Slide 3 restores the automatic appearance shown above.

![Ручной интервал подписи категорий три с видимыми всеми 24 столбцами](category-axis-manual.png)

### **Выберите правильную ось и интервал**

Используйте этот интервал количества категорий для текстовой оси категорий, например оси категорий столбчатой, линейной, областной или гистограммы. В столбчатой диаграмме это горизонтальная ось. В горизонтальной гистограмме ось категорий вертикальна, поэтому применяйте эти настройки к оси, возвращаемой [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Интервал делений также применяется к оси рядов в диаграммах, где она присутствует.

Не используйте интервал подписи категорий для задания числовой шкалы оси значений. На оси значений [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) задаёт разницу в значениях: например, основной интервал `10` создаёт деления 0, 10, 20 и т.д., когда ось начинается с нуля. Интервал подписи `3` вместо этого считает позиции категорий, независимо от их значений. Точечные и пузырьковые диаграммы используют оси значений, а не текстовую ось категорий. Для датированной оси используйте временные основные интервалы и шкалы, как описано в [Изменить ось категорий](#изменить-ось-категорий).

## **Установить формат даты для значений оси категорий**

Пример заменяет данные диаграммы по умолчанию четырьмя годовыми значениями. Даты хранятся как серийные номера OLE Automation в первом листе (индекс `0`), вычисляемые как количество дней, прошедших с 30‑го декабря 1899 г. Оба календаря используют UTC и очищаются перед установкой дат, чтобы переход на летнее время и текущее время суток не влияли на расчёт. Используйте [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) с `CategoryAxisType.Date`, вызовите [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) с `false` и передайте `yyyy` в [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-), чтобы подписи категорий отображали четырёхзначные годы независимо от форматирования ячеек.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить угол поворота заголовка оси диаграммы**

Вызовите [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) с `true` у вертикальной оси, задайте текст заголовка и используйте [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) для поворота заголовка. Угол измеряется в градусах; этот пример сохраняет столбчатую диаграмму с заголовком оси значений, повернутым на 90 градусов.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить положение оси на оси категорий или значений**

Используйте [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) для управления тем, пересекает ли ось значений ось категорий между категориями или на отметках категорий. Эта настройка применяется к осям категорий. Пример устанавливает её в `true` на горизонтальной оси категорий столбчатой диаграммы и сохраняет результат.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить единицу отображения на оси значений диаграммы**

Используйте [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) для масштабирования подписей оси значений без изменения исходных данных. При установленном [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) в `Millions` значение 60 000 000 отображается как 60. Пример создаёт столбчатую диаграмму и применяет единицу отображения «миллионы» к её вертикальной оси.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Настроить логарифмическую ось значений**

Логарифмическая ось значений полезна, когда положительные значения охватывают несколько порядков величины. Например, сервис может получать 10, 100, 1 000, 10 000 и 100 000 запросов за пять периодов. На линейной шкале меньшие значения находятся близко друг к другу у нуля. Логарифмическая шкала упрощает сравнение их относительного роста: одинаковые расстояния представляют одинаковые отношения, а не одинаковые разницы.

Вызовите [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) с `true` у оси значений и используйте [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) для выбора основания. Это меняет отображение существующих значений; это не меняет данные и не добавляет логарифмическую трендовую линию. Трендовая линия представляет подгонку данных и является отдельной функцией.

### **Выберите ось значений и основание**

Для линейной или столбчатой диаграммы ось значений возвращается методом [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Для горизонтальной гистограммы — методом [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Точечные и пузырьковые диаграммы имеют две оси значений, поэтому выбирайте горизонтальную ось для значений X, вертикальную — для Y, либо обе. Не применяйте логарифмическое масштабирование к оси категорий.

Основание логарифма по умолчанию — `10`. Для диаграмм PPTX используйте основание от `2` до `1000` включительно; поддерживаются и дробные основания, такие как `2.5`. При основании `10` последовательные степени 10, 100, 1 000 и 10 000 находятся на одинаковом расстоянии.

### **Сравнение линейного и логарифмического масштабирования**

Следующий автономный пример создаёт линейную диаграмму с пятью количествами запросов на первом слайде, затем копирует этот слайд и включает логарифмическую ось значений с основанием 10 на втором. Оба слайда сохраняют одинаковые данные.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Оставить первый слайд линейным и изменить только масштаб оси значений копии.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Linear scale (slide 1):** Equal vertical distances represent equal differences in request counts. The largest value dominates the chart, making the smaller values difficult to distinguish.

![Линейная диаграмма в PowerPoint, показывающая пять количеств запросов на линейной оси значений](value-axis-linear.png)

**Logarithmic scale (slide 2):** Equal vertical distances represent equal ratios. Each period has ten times as many requests as the previous one, so the points form a straight rising line on the base-10 scale. The axis labels still show the original request counts.

![Те же пять количеств запросов в PowerPoint на логарифмической оси значений с основанием 10](value-axis-logarithmic.png)

### **Обработка нулевых и отрицательных значений**

Логарифмическая шкала может отображать только строго положительные значения. Проверьте данные перед её включением. Если нулевые или отрицательные значения имеют смысл, оставьте линейную шкалу или отображайте их отдельно. Если исключение этих значений оправдано для анализа, объясните отсутствие. Не заменяйте их тихо небольшими положительными числами, так как это меняет смысл данных. Любой вручную заданный минимум или максимум для логарифмической оси также должен быть положительным.

## **FAQ**

**Как установить значение, при котором одна ось пересекает другую (пересечение осей)?**

Используйте [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) для выбора поведения пересечения. Чтобы задать числовое значение пересечения, используйте [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Эти настройки позволяют переместить точку пересечения осей на подходящую базовую линию.

**Как позиционировать подписи делений относительно оси?**

Вызовите [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) с использованием [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` или `None`. Чтобы управлять самими отметками делений, используйте [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) или [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); они независимы от позиционирования подписей.