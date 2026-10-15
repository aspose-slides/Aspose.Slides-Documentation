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
- положение оси
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides for Android через Java для настройки осей диаграмм в презентациях PowerPoint для отчетов и визуализаций."
---
## **Обзор**

Эта статья объясняет, как настраивать оси диаграмм с помощью Aspose.Slides for Android через Java. Она охватывает вычисленные значения осей, переключение строк и столбцов диаграммы, видимость осей, интервалы меток категорий и делений, категории дат и их форматирование, вращение заголовка, позиционирование осей, единицы отображения и логарифмическое масштабирование.

## **Получить максимальные значения на вертикальной оси диаграмм**

Создайте [Презентацию](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и добавьте областную диаграмму с данными по умолчанию. Вызовите [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) перед чтением вычисленных значений осей, чтобы макет диаграммы был актуальным.

Прочитайте [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) и [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) для пределов оси, а также [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) и [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) для интервалов делений. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) и [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) предоставляют шкалы единиц времени, которые актуальны для датированных осей. Пример сохраняет эти значения в локальные переменные и сохраняет диаграмму.

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

## **Переставить данные между осями**

Используйте [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) для обмена ролями рядов и категорий в данных диаграммы. Каждая прежняя категория становится рядом, а каждый прежний ряд становится категорией. Это меняет способ группировки данных; это не меняет местами горизонтальную и вертикальную оси. В примере используется [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) для привязки данных по умолчанию к `Sheet1!A1:D5`, включая строку заголовков и столбец категорий, перед перестановкой строк и столбцов. Сохраняется диаграмма с четырьмя рядами и тремя категориями.

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

## **Изменить порядок построения оси**

Используйте [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) для обратного порядка построения категориальной или значимой оси. Например, горизонтальная столбчатая диаграмма может показывать стадии проекта сверху вниз в том же порядке, что и лист: Планирование, Разработка, Тестирование. Обратный порядок меняет направление построения; он не сортирует и не переставляет данные листа. Для сравнения, [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) меняет роли рядов и категорий.

В следующем примере создаётся горизонтальная столбчатая диаграмма с тремя стадиями и одним рядом. Сохраняется презентация с тремя слайдами: обычный порядок, обратные категории и обратные значения. Каждая копия использует один и тот же набор данных, и на каждой копии обратный порядок применяется только к одной оси.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Слайд 2: показать первую категорию вверху.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Оставить горизонтальную ось значений внизу.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // Слайд 3: обратить только горизонтальную числовую шкалу.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Обратный порядок оси также может перемещать перпендикулярную ось на противоположную сторону графика. [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) управляет тем, где другая ось пересекает настраиваемую ось. На слайде 2 вызов с `CrossesType.Maximum` на обратной категориальной оси сохраняет горизонтальную значимую ось внизу. Для конкретной точки пересечения используйте [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Проверяйте настройки пересечения при изменении направления, особенно если диаграмма уже имеет пользовательскую точку пересечения. Вызов `setPlotOrderReversed` с `false` восстанавливает обычное направление построения; настройки пересечения остаются отдельными.

| Обычный порядок (слайд 1) | Обратные категории (слайд 2) | Обратные значения (слайд 3) |
| --- | --- | --- |
| ![Горизонтальная столбчатая диаграмма с обычным порядком категорий и значений](axis-order-normal.png) | ![Горизонтальная столбчатая диаграмма с категориями, отображаемыми сверху вниз](axis-order-categories-reversed.png) | ![Горизонтальная столбчатая диаграмма с обратной значимой осью и нулём справа](axis-order-values-reversed.png) |
| Категории идут снизу вверх; значения растут слева направо. | Планирование, Разработка и Тестирование идут сверху вниз. Значения и порядок строк листа остаются без изменений. | Категории сохраняют обычный порядок; значения растут справа налево. Категориальная ось пересекается в нуле справа. |

## **Отключить вертикальную ось для линейных диаграмм**

Вызовите [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) с `false` для вертикальной оси, чтобы скрыть её. Пример создаёт линейную диаграмму с данными по умолчанию и сохраняет её с отключённой вертикальной осью.

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

Вызовите [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) с `false` для горизонтальной оси, чтобы скрыть её. Пример создаёт линейную диаграмму с данными по умолчанию и сохраняет её с отключённой горизонтальной осью.

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

## **Изменить категориальную ось**

Используйте [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) для выбора датированной или текстовой категориальной оси. Этот пример требует `ExistingChart.pptx`, где диаграмма является первой фигурой на первом слайде, а ячейки категорий содержат числовые значения дат Excel. Он меняет горизонтальную ось на датированную. Вызов [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) с `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) с `1` и [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) с `TimeUnitType.Months` размещает основные деления через один месяц.

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

## **Управление интервалами меток категориальной оси**

Когда диаграмма содержит много категорий, уменьшите количество видимых меток оси, не удаляя категории или точки данных. Вызовите [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) с `false`, затем передайте требуемый интервал категорий в [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Для текстовых категорий в обычном порядке отсчёт начинается с первой категории:

| Интервал | Меток, отображённых в примере |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Интервал `3` отображает каждую третью метку, оставляя две скрытыми между отображаемыми. Он не удаляет соответствующие столбцы. Автоматический выбор интервала основывается на доступном месте; он не обязательно отображает каждую метку.

Деления имеют отдельные настройки. Вызовите [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) с `false` и используйте [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) для задания их интервала. Например, `1` оставляет деление на каждом интервале категории, пока метки отображаются каждый третий. Используйте [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) с видимым стилем, чтобы увидеть результат. Повторный вызов любого из автоматических сеттеров с `true` возвращает диаграмме возможность автоматически выбирать интервал.

Следующий автономный пример создаёт 24 категории и один ряд, затем сохраняет три слайда в `CategoryAxisIntervals.pptx`: автоматический интервал, ручной интервал меток с независимыми делениями и восстановленный автоматический интервал. Две копии сохраняют исходные данные диаграммы. Входная презентация не требуется. Горизонтальный текст меток делает разницу в плотности легко заметной.

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

    // Слайд 2: показывать каждую третью метку, но сохранять деление для каждой категории.
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

**Автоматический интервал (слайд 1):** При таком отображении каждая вторая метка категории отображается и переходит на две строки. Автоматический результат может варьироваться в зависимости от размера диаграммы, шрифтов и рендерера.

![Автоматический интервал меток категорий при видимых всех 24 столбцах](category-axis-automatic.png)

**Ручной интервал (слайд 2):** Каждая третья метка отображается в одну строку, в то время как деления остаются на каждом интервале категории. Все 24 столбца, включая те, у которых нет меток, остаются видимыми с теми же значениями. Слайд 3 восстанавливает автоматический вид, показанный выше.

![Ручной интервал меток категорий в три с видимыми всеми 24 столбцами](category-axis-manual.png)

### **Выберите правильную ось и интервал**

Используйте этот интервал количества категорий для текстовой категориальной оси, такой как ось категорий столбчатой, линейной, областной или столбчатой диаграммы. В столбчатой диаграмме это горизонтальная ось. В горизонтальной столбчатой диаграмме категориальная ось вертикальна, поэтому применяйте эти настройки к оси, возвращаемой методом [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Интервал делений также применяется к оси ряда в диаграммах, где она присутствует.

Не используйте интервалы меток категорий для задания числовой шкалы значимой оси. На значимой оси [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) задаёт разницу значений: например, основной шаг `10` создаёт деления 0, 10, 20 и т.д., когда ось начинается с нуля. Интервал меток категорий `3` считает позиции категорий независимо от их значений. Диаграммы разброса и пузырьковые диаграммы используют значимые оси, а не текстовую категориальную ось. Для датированной оси используйте основанные на времени основные единицы и шкалы, как описано в разделе [Изменить категориальную ось](#изменить-категориальную-ось).

## **Установить формат даты для значений категориальной оси**

Пример заменяет данные диаграммы по умолчанию четырьмя годовыми значениями. Даты хранятся как серийные числа OLE Automation в первом листе (индекс `0`), рассчитываемые как количество дней, прошедших с 30 декабря 1899, для указанных дат. Оба календаря используют UTC и очищаются перед установкой дат, чтобы переход на летнее время и текущее время суток не влияли на расчёт. Используйте [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) с `CategoryAxisType.Date`, вызовите [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) с `false` и передайте `yyyy` в [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-), чтобы метки категорий отображали четырёхзначный год независимо от форматирования ячейки.

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

Вызовите [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) с `true` для вертикальной оси, задайте текст заголовка и используйте [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) для поворота заголовка. Угол измеряется в градусах; пример сохраняет столбчатую диаграмму с заголовком значимой оси, повернутым на 90 градусов.

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

## **Установить позицию оси на категориальной или значимой оси**

Используйте [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) для управления тем, пересекает ли значимая ось категориальную между категориями или на делениях категорий. Эта настройка применяется к категориальным осям. Пример устанавливает её в `true` для горизонтальной категориальной оси столбчатой диаграммы и сохраняет результат.

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

## **Установить единицу отображения на значимой оси диаграммы**

Используйте [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) для масштабирования меток значимой оси без изменения исходных данных. При установленном [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) в `Millions` значение 60 000 000 отображается как 60. Пример создаёт столбчатую диаграмму и применяет единицу отображения «миллионы» к её вертикальной оси.

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

## **Настроить логарифмическую значимую ось**

Логарифмическая значимая ось полезна, когда положительные значения охватывают несколько порядков величины. Например, сервис может получать 10, 100, 1 000, 10 000 и 100 000 запросов за пять периодов. При линейной шкале меньшие значения собираются рядом с нулём. Логарифмическая шкала упрощает сравнение их относительного роста: равные расстояния представляют равные коэффициенты, а не равные разницы.

Вызовите [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) с `true` для значимой оси и используйте [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) для выбора основания. Это меняет отображение существующих значений; она не меняет данные и не добавляет логарифмическую трендовую линию. Трендовая линия представляет подгонку отношения в данных и является отдельной функцией.

### **Выберите ось значений и основание**

Для линейной или столбчатой диаграммы значимая ось возвращается методом [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Для горизонтальной столбчатой диаграммы — методом [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Диаграммы разброса и пузырьковые диаграммы имеют две значимые оси, поэтому выбирайте горизонтальную ось для значений X, вертикальную для Y или обе. Не применяйте логарифмическое масштабирование к категориальной оси.

Основание логарифма по умолчанию — `10`. Для PPTX‑диаграмм используйте основание от `2` до `1000` включительно; поддерживаются также дробные основания, такие как `2.5`. При основании `10` последовательные степени 10, 100, 1 000 и 10 000 равномерно распределены.

### **Сравнение линейного и логарифмического масштабирования**

Следующий автономный пример создаёт линейную диаграмму с пятью подсчётами запросов на первом слайде, затем клонирует этот слайд и включает логарифмическую значимую ось с основанием 10 на втором. Оба слайда сохраняют одинаковые данные.

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

    // Сохранить первый слайд линейным и изменить только масштаб оси значений копии.
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

**Линейная шкала (слайд 1):** Равные вертикальные расстояния представляют равные различия в количестве запросов. Наибольшее значение доминирует, делая меньшие значения трудноразличимыми.

![Линейная диаграмма в PowerPoint, показывающая пять подсчётов запросов на линейной значимой оси](value-axis-linear.png)

**Логарифмическая шкала (слайд 2):** Равные вертикальные расстояния представляют равные коэффициенты. Каждый период содержит в десять раз больше запросов, чем предыдущий, поэтому точки образуют прямую восходящую линию на шкале с основанием 10. Метки оси по‑прежнему показывают исходные количества запросов.

![Те же пять подсчётов запросов в PowerPoint на логарифмической значимой оси с основанием 10](value-axis-logarithmic.png)

### **Обработка нулевых и отрицательных значений**

Логарифмическая шкала может отображать только строго положительные значения. Проверьте данные перед её включением. Если нулевые или отрицательные значения имеют смысл, оставьте линейную шкалу или показывайте их отдельно. Если исключение этих значений оправдано, объясните причину. Не заменяйте их без уведомления небольшими положительными числами, так как это изменит смысл данных. Любой вручную установленный минимум или максимум для логарифмической оси также должен быть положительным.

## **FAQ**

**Как задать значение, где одна ось пересекает другую (пересечение осей)?**

Используйте [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) для выбора поведения пересечения. Чтобы задать числовое значение пересечения, используйте [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Эти настройки позволяют переместить пересечение осей к подходящей базовой линии.

**Как расположить метки делений относительно оси?**

Вызовите [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) с использованием [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` или `None`. Для управления самими делениями используйте [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) или [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); они отдельны от позиционирования меток.