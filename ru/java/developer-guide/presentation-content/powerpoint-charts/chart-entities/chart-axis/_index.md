---
title: Настройка осей диаграмм в презентациях с использованием Java
linktitle: Ось диаграммы
type: docs
url: /ru/java/chart-axis/
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
- Java
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides for Java для настройки осей диаграмм в PowerPoint‑презентациях для отчетов и визуализаций."
---
## **Обзор**

В этой статье объясняется, как настроить оси диаграмм с помощью Aspose.Slides for Java. Описываются рассчитанные значения осей, переключение строк и столбцов диаграммы, видимость осей, интервалы подположений меток категорий и делений, даты категорий и их форматирование, вращение заголовка, позиционирование осей, единицы отображения и логарифмическое масштабирование.

## **Получить максимальные значения на вертикальной оси в диаграммах**

Создайте [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и добавьте областную диаграмму с данными по умолчанию. Вызовите [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) перед чтением рассчитанных значений осей, чтобы макет диаграммы был актуален.

Прочитайте [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) и [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) для пределов оси, а также [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) и [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) для интервалов делений. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) и [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) предоставляют масштабы единиц времени, которые актуальны для датовых осей. Пример сохраняет эти значения в локальные переменные и сохраняет диаграмму.

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

## **Обмен данными между осями**

Используйте [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) чтобы поменять роли серий и категорий в данных диаграммы. Каждая прежняя категория становится серией, а каждая прежняя серия — категорией. Это изменяет способ группировки данных; оси горизонтальная и вертикальная не меняются местами. В примере используется [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) для привязки данных по умолчанию к `Sheet1!A1:D5`, включая строку заголовка и столбец категорий, перед переключением строк и столбцов. Сохраняется диаграмма с четырьмя сериями и тремя категориями.

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

## **Обратный порядок построения оси**

Используйте [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) чтобы обратить категориальную или значимую ось. Например, горизонтальная гистограмма может показывать стадии проекта сверху вниз в том же порядке, что и лист: Планирование, Разработка, Тестирование. Обратный порядок оси меняет направление построения; он не сортирует и не перестраивает данные книги. Для сравнения [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) меняет роли серий и категорий.

Следующий пример создает горизонтальную гистограмму с тремя стадиями и одной серией. Он сохраняет презентацию из трёх слайдов: обычный порядок, обратные категории и обратные значения. Каждая копия использует один и тот же набор данных, и только одна ось обращена в каждой копии.

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

    // Слайд 2: отобразить первую категорию вверху.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Сохранить горизонтальную ось значений внизу.
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

Обратный порядок оси может также переместить перпендикулярную ось на противоположную сторону графика. [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) управляет тем, где другая ось пересекает настраиваемую ось. На слайде 2 вызов с `CrossesType.Maximum` для обратной категориальной оси сохраняет горизонтальную значимую ось внизу. Для указания конкретной точки пересечения используйте [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Проверяйте настройки пересечения при изменении направления, особенно если у диаграммы уже задана пользовательская точка пересечения. Вызов `setPlotOrderReversed` с `false` восстанавливает обычное направление построения; настройки пересечения остаются отдельными.

| Обычный порядок (слайд 1) | Обратные категории (слайд 2) | Обратные значения (слайд 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| Категории идут снизу вверх; значения растут слева направо. | Этапы Планирование, Разработка и Тестирование идут сверху вниз. Значения и порядок строк в книге не изменяются. | Категории сохраняют обычный порядок; значения растут справа налево. Ось категорий пересекает ноль справа. |

## **Отключить вертикальную ось для линейных диаграмм**

Вызовите [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) с `false` для вертикальной оси, чтобы скрыть её. Пример создает линейную диаграмму с данными по умолчанию и сохраняет её с скрытой вертикальной осью.

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

Вызовите [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) с `false` для горизонтальной оси, чтобы скрыть её. Пример создает линейную диаграмму с данными по умолчанию и сохраняет её с скрытой горизонтальной осью.

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

Используйте [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-), чтобы выбрать датовую или текстовую ось категорий. В примере требуется `ExistingChart.pptx`, где диаграмма является первой фигурой на первом слайде, а ячейки категорий содержат числовые даты Excel. Ось X меняется на датовую. Вызов [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) с `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) с `1` и [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) с `TimeUnitType.Months` размещает основные деления с интервалом в один месяц.

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

## **Управление интервалами меток оси категорий**

Когда в диаграмме много категорий, уменьшите количество видимых меток оси, не удаляя категории и точки данных. Вызовите [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) с `false`, затем передайте желаемый интервал категорий в [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Для текстовых категорий в обычном порядке отсчёт начинается с первой категории:

| Интервал | Отображаемые метки в примере |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Интервал `3` отображает каждую третью метку, скрывая две метки между отображаемыми. Он не удаляет соответствующие столбцы. Автоматический подбор выбирает интервал исходя из доступного пространства; он не обязательно отображает каждую метку.

Деления имеют отдельные настройки. Вызовите [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) с `false` и используйте [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) для задания их интервала. Например, `1` сохраняет деление на каждом интервале категории, тогда как метки появляются только каждые три категории. Используйте [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) с видимым стилем, чтобы увидеть результат. Повторный вызов любого из автоматических сеттеров с `true` позволяет диаграмме вновь подобрать интервал автоматически.

Следующий автономный пример создаёт 24 категории и одну серию, затем сохраняет три слайда в `CategoryAxisIntervals.pptx`: автоматический подбор, ручной подбор меток с независимыми делениями и восстановление автоматического подбора. Обе копии сохраняют исходные данные диаграммы. Входная презентация не требуется. Горизонтальный текст меток делает разницу в плотности легко различимой.

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

    // Слайд 2: показывать каждую третью метку, но оставлять деление для каждой категории.
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

**Automatic spacing (slide 1):** В этом отображении каждая вторая метка категории показывается и переносится на две строки. Автоматический результат может различаться в зависимости от размера диаграммы, шрифтов и рендерера.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Manual spacing (slide 2):** Каждая третья метка отображается в одну строку, тогда как деления остаются на каждом интервале категории. Все 24 столбца, включая те, у которых нет меток, остаются видимыми с теми же значениями. Слайд 3 восстанавливает автоматический вид, показанный выше.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Выберите правильную ось и интервал**

Используйте этот интервал количества категорий для текстовой оси категорий, например оси категорий столбчатой, линейной, площадной или гистограммы. В столбчатой диаграмме это горизонтальная ось. В горизонтальной гистограмме ось категорий вертикальная, поэтому применяйте эти настройки к оси, возвращаемой [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Настройка интервала делений также применяется к оси серии в диаграммах, где она присутствует.

Не используйте интервал меток категорий для задания числовой шкалы оси значений. На оси значений [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) задаёт разницу в значениях: например, основной шаг `10` создаёт деления 0, 10, 20 и т.д., если ось начинается с нуля. Интервал меток категорий `3` считает позиции категорий, независимо от их значений. Диаграммы разброса и пузырьковые используют оси значений, а не текстовую ось категорий. Для датовой оси используйте временные основные единицы и масштабы, описанные в разделе [Change a Category Axis](#change-a-category-axis).

## **Задать формат даты для значений оси категорий**

В примере заменяются исходные данные диаграммы четырьмя годовыми значениями. Даты хранятся как серийные номера OLE Automation в первом листе (индекс `0`), вычисляемые как количество дней, прошедших с 30 декабря 1899 для этих дат. Используйте [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) с `CategoryAxisType.Date`, вызовите [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) с `false` и передайте `yyyy` в [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-), чтобы метки категорий отображали четырёхзначные года независимо от формата ячеек.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
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

## **Задать угол вращения заголовка оси диаграммы**

Вызовите [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) с `true` для вертикальной оси, укажите текст заголовка и используйте [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) для его вращения. Угол измеряется в градусах; в примере сохраняется столбчатая диаграмма с заголовком оси значений, повернутым на 90 градусов.

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

## **Задать положение оси на категориальной или значимой оси**

Используйте [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-), чтобы контролировать, пересекает ли значимая ось категориальную ось между категориями или на делениях категорий. Эта настройка применяется к категориальным осям. В примере она установлена в `true` для горизонтальной категориальной оси столбчатой диаграммы и результат сохраняется.

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

## **Задать единицу отображения на оси значений диаграммы**

Используйте [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-), чтобы масштабировать подписи оси значений без изменения базовых данных. При установленном [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) `Millions` значение 60 000 000 отображается как 60. Пример создаёт столбчатую диаграмму и применяет единицу отображения «миллионы» к её вертикальной оси.

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

Логарифмическая ось значений полезна, когда положительные значения охватывают несколько порядков magnitude. Например, сервис может получать 10, 100, 1 000, 10 000 и 100 000 запросов за пять периодов. На линейной шкале меньшие значения располагаются близко друг к другу у нуля. Логарифмическая шкала упрощает сравнение их относительного роста: равные расстояния представляют равные отношения, а не равные разницы.

Вызовите [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) с `true` для оси значений и используйте [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) для выбора основания. Это меняет только отображение существующих значений; данные не меняются и не добавляется логарифмическая тренд‑линия. Тренд‑линия представляет подгонку данных и является отдельной функцией.

### **Выберите ось значений и основание**

Для линейной или столбчатой диаграммы ось значений возвращается методом [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Для горизонтальной гистограммы — методом [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Диаграммы разброса и пузырьковые имеют две оси значений, поэтому выбирайте горизонтальную ось для X, вертикальную для Y или обе. Не применяйте логарифмическое масштабирование к категориальной оси.

Исходное логарифмическое основание — `10`. Для PPTX‑диаграмм используйте основание от `2` до `1000` включительно; также поддерживаются дробные основания, такие как `2.5`. При основании `10` последовательные степени 10, 100, 1 000 и 10 000 располагаются на одинаковом расстоянии.

### **Сравнение линейного и логарифмического масштабирования**

Следующий автономный пример создаёт линейную диаграмму с пятью подсчётами запросов на первом слайде, затем клонирует этот слайд и включает логарифмическую ось значений с основанием 10 на втором. Оба слайда сохраняют одни и те же данные.

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

**Linear scale (slide 1):** Равные вертикальные расстояния представляют равные различия в количестве запросов. Наибольшее значение доминирует в диаграмме, делая меньшие значения трудно различимыми.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Logarithmic scale (slide 2):** Равные вертикальные расстояния представляют равные отношения. Каждый период содержит в десять раз больше запросов, чем предыдущий, поэтому точки образуют прямую восходящую линию на шкале с основанием 10. Метки оси всё равно показывают исходные количества запросов.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Обработка нулевых и отрицательных значений**

Логарифмическая шкала может отображать только строго положительные значения. Проверьте данные перед включением её. Если нулевые или отрицательные значения имеют смысл, оставьте линейную шкалу или показывайте их отдельно. Если исключение этих значений уместно для анализа, объясните причину. Не заменяйте их «тихо» небольшими положительными числами, так как это меняет смысл данных. Любой вручную заданный минимум или максимум для логарифмической оси также должен быть положительным.

## **FAQ**

**Как задать значение, в котором одна ось пересекает другую (пересечение осей)?**

Используйте [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) для выбора поведения пересечения. Чтобы указать числовое значение пересечения, используйте [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Эти настройки позволяют переместить пересечение осей к подходящей базовой линии.

**Как позиционировать метки делений относительно оси?**

Вызовите [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) с использованием [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` или `None`. Чтобы управлять самими делениями, используйте [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) или [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); они отдельны от позиционирования меток.