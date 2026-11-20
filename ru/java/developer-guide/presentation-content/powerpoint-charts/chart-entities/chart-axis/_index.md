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
- позиция оси
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides для Java, чтобы настраивать оси диаграмм в презентациях PowerPoint для отчетов и визуализаций."
---
## **Обзор**

В этой статье объясняется, как настраивать оси диаграмм с помощью Aspose.Slides для Java. Она охватывает вычисленные значения осей, переключение строк и столбцов диаграммы, видимость осей, интервалы подписей категорий и делений, датированные категории и их форматирование, поворот заголовка, позиционирование осей, единицы измерения и логарифмическое масштабирование.

## **Получение максимальных значений на вертикальной оси диаграмм**

Создайте [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и добавьте линейчатую диаграмму с данными по умолчанию. Вызовите [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) перед чтением вычисленных значений осей, чтобы макет диаграммы был актуален.

Считайте [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) и [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) для пределов оси, а также [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) и [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) для интервалов делений. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) и [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) предоставляют шкалы единиц времени, которые актуальны для датированных осей. В примере эти значения сохраняются в локальные переменные и диаграмма сохраняется.

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

## **Перестановка данных между осями**

Используйте [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) для обмена ролями рядов и категорий в данных диаграммы. Каждая бывшая категория становится рядом, а каждый бывший ряд становится категорией. Это меняет способ группировки данных; оси горизонтальная и вертикальная не меняются местами. В примере применяется [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) для привязки данных по умолчанию к `Sheet1!A1:D5`, включая строку заголовка и столбец категорий, перед перестановкой строк и столбцов. Сохраняется диаграмма с четырьмя рядами и тремя категориями.

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

Используйте [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) для обратного порядка построения категориальной или значения оси. Например, горизонтальная гистограмма может показывать стадии проекта сверху вниз в том же порядке, что и в листе: Планирование, Разработка, Тестирование. Обратный порядок оси меняет направление построения; он не сортирует и не перестраивает данные книги. Для сравнения, [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) меняет роли рядов и категорий.

Следующий пример создает горизонтальную гистограмму с тремя стадиями и одним рядом. Он сохраняет презентацию из трех слайдов: обычный порядок, обратные категории и обратные значения. Каждая копия использует один и тот же набор данных, и на каждой копии инвертирована только одна оси.

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

    // Слайд 2: отображать первую категорию наверху.
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

Обратный порядок оси может также переместить перпендикулярную ось на противоположную сторону графика. [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) управляет тем, где другая ось пересекает конфигурируемую ось. На слайде 2 вызов с `CrossesType.Maximum` на обратной оси категории сохраняет горизонтальную ось значений внизу. Для конкретной точки пересечения используйте [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Проверьте настройки пересечения при изменении направления, особенно если диаграмма уже имеет пользовательскую точку пересечения. Вызов `setPlotOrderReversed` с `false` восстанавливает обычное направление построения; настройки пересечения остаются отдельными.

| Обычный порядок (слайд 1) | Обратные категории (слайд 2) | Обратные значения (слайд 3) |
| --- | --- | --- |
| ![Горизонтальная гистограмма с обычным порядком категориальной и оси значений](axis-order-normal.png) | ![Горизонтальная гистограмма с категориями, отображаемыми сверху вниз](axis-order-categories-reversed.png) | ![Горизонтальная гистограмма с обратной осью значений и нулем справа](axis-order-values-reversed.png) |
| Категории идут снизу вверх; значения увеличиваются слева направо. | Планирование, Разработка и Тестирование идут сверху вниз. Значения и порядок строк книги остаются без изменений. | Категории сохраняют обычный порядок; значения увеличиваются справа налево. Ось категорий пересекает ноль справа. |

## **Отключение вертикальной оси для линейных диаграмм**

Вызовите [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) с `false` для вертикальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой вертикальной осью.

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

## **Отключение горизонтальной оси для линейных диаграмм**

Вызовите [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) с `false` для горизонтальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой горизонтальной осью.

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

## **Показать или скрыть линии сетки диаграммы**

Вызовите [getShowMajorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMajorGridLines--) и [getShowMinorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMinorGridLines--) чтобы проверить, какие линии сетки отображает ось. Эти методы сообщают текущую видимость. Чтобы показать мелкие линии сетки, используйте [getMinorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) и задайте её заливку линии сплошным, видимым цветом. Чтобы скрыть их, установите заливку в [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/#NoFill). Используйте [getMajorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) для изменения заливки линий сетки главных делений тем же способом. Изменение заливки сохраняет видимость оси и деления.

Вертикальная ось этой сгруппированной столбчатой диаграммы изначально показывает только главные линии сетки. В примере мелкие линии сетки отображаются тёмно-оранжевым цветом, затем снова скрываются перед сохранением презентации. На каждом этапе выводится видимость линий сетки.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(new Color(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Включены мелкие линии сетки | Скрыты мелкие линии сетки |
| --- | --- |
| ![Оранжевые мелкие линии сетки между главными линиями сетки на вертикальной оси](minor-gridlines-enabled.png) | ![Та же столбчатая диаграмма, где видны только главные линии сетки](minor-gridlines-hidden.png) |

## **Изменение оси категорий**

Используйте [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) для выбора датированной или текстовой оси категорий. Этот пример требует `ExistingChart.pptx`, где диаграмма является первой фигурой на первом слайде, а ячейки категорий содержат числовые значения дат Excel. Он меняет горизонтальную ось на датированную. Вызов [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) с `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) с `1` и [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) с `TimeUnitType.Months` размещает главные деления с интервалом в один месяц.

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

### **Определение типа оси категорий из данных**

Вызовите [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--) после заполнения категорий, затем прочитайте [getCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getCategoryAxisType--) для проверки выбора. Это полезно, когда одна и та же диаграмма получает либо текстовые метки, либо числовые значения дат. Метод определяет тип в момент вызова; он не включает постоянный режим, переоценивающий изменения данных позже. Вызовите его снова после замены категорий.

В следующем примере создаётся диаграмма с текстовыми категориями и выводится `true`, когда выбранный тип — `CategoryAxisType.Text`. Затем значения ячеек категорий заменяются датами и метод вызывается повторно, выводя `true`, когда выбранный тип — `CategoryAxisType.Date`. Даты хранятся как числовые значения OLE Automation, рассчитываемые как количество дней, прошедших с 30‑го декабря 1899 г., а не как строки дат. [setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) управляет тем, как эти значения отображаются; он не преобразует текст в числовые даты. Подробнее о ячейках категорий см. в разделе [Chart Workbook](/slides/ru/java/chart-workbook/).

Используйте автоматическое определение, когда известно, что ввод содержит текстовые категории или числовые даты, как в этом примере. Для обычных числовых меток, смешанных категорий или пустых данных явно вызывайте [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisType-int-) для соответствия предполагаемому смыслу. Одни лишь числовые значения не устанавливают, что категории представляют даты.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    String[] labels = { "First", "Second", "Third" };

    for (int i = 0; i < labels.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Text); // истина

    LocalDate baseDate = LocalDate.of(1899, 12, 30);
    LocalDate[] dates = { LocalDate.of(2026, 1, 1), LocalDate.of(2026, 1, 2), LocalDate.of(2026, 2, 1) };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        categoryCell.setValue((double)(dates[i].toEpochDay() - baseDate.toEpochDay()));
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // истина

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Управление интервалами подписей оси категорий**

Когда в диаграмме много категорий, уменьшите количество видимых подписей оси, не удаляя категории или точки данных. Вызовите [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) с `false`, затем передайте желаемый интервал категорий в [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Для текстовых категорий в их обычном порядке отсчёт начинается с первой категории:

| Интервал | Подписи, отображаемые в примере |
| --- | --- |
| `1` | Категория 1, Категория 2, Категория 3, ... Категория 24 |
| `2` | Категория 1, Категория 3, Категория 5, ... Категория 23 |
| `3` | Категория 1, Категория 4, Категория 7, ... Категория 22 |

Интервал `3` отображает каждую третью подпись, скрывая две подписи между отображаемыми. Он не удаляет соответствующие столбцы. Автоматический подбор выбирает интервал исходя из доступного места; он не обязательно отображает каждую подпись.

Деления имеют отдельные настройки. Вызовите [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) с `false` и используйте [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) для установки их интервала. Например, `1` оставляет деление на каждом интервале категории, в то время как подписи появляются только каждые три категории. Используйте [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) с видимым стилем, чтобы увидеть результат. Вызов любого из автоматических наборов с `true` снова позволяет диаграмме выбрать этот интервал.

Следующий автономный пример создаёт 24 категории и один ряд, затем сохраняет три слайда в `CategoryAxisIntervals.pptx`: автоматический подбор, ручной подбор подписей с независимыми делениями и восстановленный автоматический подбор. Обе копии сохраняют исходные данные диаграммы. Входная презентация не требуется. Горизонтальный текст подписей облегчает визуальное различие плотности.

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

    // Слайд 2: показывать каждую третью подпись, но оставлять деление для каждой категории.
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

**Автоматический подбор (слайд 1):** В этом отображении каждая вторая подпись категории отображается и переносится на две строки. Автоматический результат может различаться в зависимости от размера диаграммы, шрифтов и средств визуализации.

![Автоматический интервал подписей категорий при отображении всех 24 столбцов](category-axis-automatic.png)

**Ручной подбор (слайд 2):** Каждая третья подпись отображается на одной строке, при этом деления остаются на каждом интервале категории. Все 24 столбца, включая те, у которых нет подписи, остаются видимыми с теми же значениями. Слайд 3 восстанавливает автоматический вид, показанный выше.

![Ручной интервал подписей категорий в три при отображении всех 24 столбцов](category-axis-manual.png)

### **Выбор правильной оси и интервала**

Используйте данный интервал подсчёта категорий для текстовой оси категорий, например оси категорий столбчатой, линейной, областной или гистограммы. В столбчатой диаграмме это горизонтальная ось. В горизонтальной гистограмме ось категорий вертикальная, поэтому применяйте эти настройки к оси, возвращаемой [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Интервалы делений также применимы к оси рядов в диаграммах, где она присутствует.

Не используйте интервал подписей категорий для задания числовой шкалы оси значений. На оси значений [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) задаёт разницу в значениях: например, основной единицей `10` создаёт деления 0, 10, 20 и т.д., когда ось начинается с нуля. Интервал подписи категории `3` считает позиции категорий, независимо от их значений данных. Диаграммы разброса и пузырьковые используют оси значений, а не текстовую ось категорий. Для датированной оси используйте единицы времени и шкалы, описанные в разделе [Change a Category Axis](#change-a-category-axis).

## **Установка формата даты для значений оси категорий**

В примере заменяются данные диаграммы по умолчанию четырьмя годовыми значениями. Даты хранятся как серийные номера OLE Automation в первом листе (индекс `0`), рассчитываемые как количество дней, прошедших с 30‑го декабря 1899 г. Для этого используйте [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) с `CategoryAxisType.Date`, вызовите [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) с `false` и передайте `yyyy` в [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-), чтобы подписи категорий отображали четырёхзначные годы независимо от форматирования ячейки.

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

## **Установка угла вращения заголовка оси диаграммы**

Вызовите [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) с `true` для вертикальной оси, задайте текст заголовка и используйте [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) для вращения заголовка. Угол измеряется в градусах; в этом примере сохраняется столбчатая диаграмма с заголовком оси значений, повернутым на 90 градусов.

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

## **Установка положения оси на оси категорий или значений**

Используйте [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) для управления тем, пересекает ли ось значений ось категорий между категориями или на делениях категорий. Эта настройка применяется к осям категорий. В примере она устанавливается в `true` для горизонтальной оси категорий столбчатой диаграммы и результат сохраняется.

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

## **Установка единицы отображения на оси значений диаграммы**

Используйте [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) для масштабирования подписей оси значений без изменения исходных данных. При значении [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) `Millions` значение 60 000 000 отображается как 60. В примере создаётся столбчатая диаграмма и к её вертикальной оси применяется единица отображения «миллионы».

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

## **Настройка логарифмической оси значений**

Логарифмическая ось значений полезна, когда положительные значения охватывают несколько порядков величины. Например, сервис может получать 10, 100, 1 000, 10 000 и 100 000 запросов за пять периодов. На линейной шкале небольшие значения находятся близко друг к другу около нуля. Логарифмическая шкала упрощает сравнение их относительного роста: одинаковые расстояния представляют одинаковые отношения, а не одинаковые различия.

Вызовите [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) с `true` для оси значений и используйте [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) для выбора основания. Это меняет способ отображения существующих значений; данные не меняются и не добавляется логарифмическая тренд‑линия. Тренд‑линия представляет собой построенную модель зависимости в данных и является отдельной функцией.

### **Выбор оси значений и основания**

Для линейных или столбчатых диаграмм ось значений возвращается методом [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Для горизонтальной гистограммы — методом [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Диаграммы разброса и пузырьковые имеют две оси значений, поэтому выбирайте горизонтальную ось для значений X, вертикальную — для Y, либо обе. Не применяйте логарифмическое масштабирование к оси категорий.

Основание логарифма по умолчанию — `10`. Для PPTX‑диаграмм используйте основание от `2` до `1000` включительно; также поддерживаются дробные основания, такие как `2.5`. При основании `10` последовательные степени 10, 100, 1 000 и 10 000 расположены на одинаковом расстоянии.

### **Сравнение линейного и логарифмического масштабирования**

Следующий автономный пример создаёт линейную диаграмму с пятью счётчиками запросов на первом слайде, затем клонирует этот слайд и включает логарифмическую ось значений с основанием 10 на втором. Оба слайда сохраняют одинаковые данные.

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

**Линейный масштаб (слайд 1):** Одинаковые вертикальные расстояния представляют равные различия в количестве запросов. Наибольшее значение доминирует в диаграмме, делая меньшие значения трудно различимыми.

![Линейная диаграмма в PowerPoint, показывающая пять количеств запросов на линейной оси значений](value-axis-linear.png)

**Логарифмический масштаб (слайд 2):** Одинаковые вертикальные расстояния представляют одинаковые отношения. Каждый период имеет в десять раз больше запросов, чем предыдущий, поэтому точки образуют прямую восходящую линию на шкале с основанием 10. Метки оси всё равно отображают исходные количества запросов.

![Те же пять количеств запросов в PowerPoint на логарифмической оси значений с основанием 10](value-axis-logarithmic.png)

### **Обработка нулевых и отрицательных значений**

Логарифмическая шкала может отображать только строго положительные значения. Проверьте данные перед включением её. Если нулевые или отрицательные значения имеют смысл, сохраните линейную шкалу или отображайте их отдельно. Если исключение этих значений уместно для анализа, объясните причину. Не заменяйте их тихо на небольшие положительные числа, так как это меняет смысл данных. Любой вручную установленный минимум или максимум для логарифмической оси также должен быть положительным.

## **FAQ**

**Как задать значение, в котором одна ось пересекает другую (пересечение осей)?**

Используйте [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) для выбора поведения пересечения. Чтобы задать числовое значение пересечения, используйте [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Эти настройки позволяют переместить пересечение осей к подходящей базовой линии.

**Как позиционировать подписи делений относительно оси?**

Вызовите [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) используя [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` или `None`. Чтобы управлять самими делениями, используйте [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) или [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); они независимы от позиционирования подписей.