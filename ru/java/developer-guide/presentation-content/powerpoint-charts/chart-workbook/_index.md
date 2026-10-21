---
title: Управление рабочими книгами диаграмм в презентациях с использованием Java
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/java/chart-workbook/
keywords:
- рабочая книга диаграммы
- данные диаграммы
- ячейка рабочей книги
- подпись данных
- лист
- источник данных
- внешняя рабочая книга
- внешние данные
- кэш диаграммы
- восстановление рабочей книги
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для Java: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, оптимизируя данные вашей презентации."
---
## **Обзор**

Эта статья объясняет, как работать с рабочими книгами диаграмм в Aspose.Slides. В ней показано, как читать и записывать данные диаграммы через потоки рабочей книги, использовать ячейки рабочей книги в качестве подписей данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Она также охватывает работу с внешними рабочими книгами в качестве источников данных диаграмм. В примерах демонстрируется, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

Для ячеек рабочей книги, представляющих отсутствующие данные, см. [Управление отображением пустых ячеек](/slides/ru/java/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение режимов отображения на линейной диаграмме.

## **Включить данные из скрытых строк и столбцов**

Используйте [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) для управления тем, будет ли диаграмма отображать данные из скрытых строк и столбцов листа. Установите значение `true`, чтобы отображать только видимые ячейки, или `false`, чтобы включать как видимые, так и скрытые ячейки. Эта настройка влияет только на построение диаграммы; она не скрывает и не отображает строки или столбцы листа.

[пример презентации](hidden-source-data.pptx) содержит столбчатую диаграмму как первую форму на первом слайде. Встроенный лист `Sheet1` содержит следующий исходный диапазон `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё равно содержат значения.

| Строка листа | A: Месяц | B: Розничные | C: Оптовые (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте доступ к исходным ячейкам через [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) и читайте [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) для проверки их статуса скрытия. Этот метод сообщает статус скрытия без его изменения. В данном файле B2 видима, B3 относится к скрытой строке, а C2 — к скрытому столбцу; пример выводит `false`, `true` и `true` соответственно.

В этом примере обновите данные диаграммы после изменения настройки построения: сохраните встроенную рабочую книгу с помощью [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) и загрузите её снова с помощью [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). При включении всех ячеек также используйте [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) для восстановления полного диапазона, включая скрытую категорию февраля. Простое изменение флага недостаточно для обновления кэшированных данных диаграммы и подписей категорий в этом образце.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Обновить данные диаграммы из встроенной рабочей книги.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Восстановить полный исходный диапазон, включая скрытые категории.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Пример сохраняет две версии презентации: одну только с видимыми значениями розничных продаж (10 и 20), а другую со всеми шестью значениями. Ниже приведены изображения, иллюстрирующие два режима построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных рабочих книгах.

| Только видимые ячейки (`true`) | Все ячейки (`false`) |
| --- | --- |
| ![Только видимые ячейки: значения розничных 10 и 20 для Января и Марта.](hidden_cells_True.png) | ![Все ячейки: значения розничных и оптовых для Января, Февраля и Марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) управляет тем, как отображаются отсутствующие значения; он не включает и не исключает скрытые исходные данные. См. [Управление отображением пустых ячеек](/slides/ru/java/chart-series/#control-the-display-of-empty-cells) для примера.

## **Получить диапазон данных диаграммы**

Перед обновлением данных рабочей книги в существующей презентации проверьте исходные диапазоны, чтобы определить, какие ячейки листа использует каждая диаграмма. Метод [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) возвращает текущий диапазон данных в виде формулы, квалифицированной листом, например `Sheet1!$A$1:$D$5`. Здесь `Sheet1` — имя листа, `!` отделяет его от диапазона ячеек, а `$A$1:$D$5` обозначает ячейки от A1 до D5 включительно. Знак доллара указывает на абсолютные ссылки на строки и столбцы.

Метод читает текущий диапазон без изменения диаграммы или её рабочей книги. Если диаграмма не использует рабочую книгу в качестве источника данных, он выбрасывает `InvalidOperationException`. Дополнительную информацию см. в [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/).

Этот пример открывает презентацию и проверяет формы непосредственно на каждом слайде в поиске диаграмм. Он выводит имя каждой диаграммы и её исходный диапазон. Если диаграмма не использует рабочую книгу, он выводит сообщение и переходит к следующей диаграмме.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides for Java предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) и [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---), позволяющие читать и записывать рабочие книги данных диаграмм (содержащие данные, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаково или иметь структуру, похожую на исходную.

Этот пример использует презентацию с диаграммой в качестве первой формы на первом слайде. Он читает встроенную рабочую книгу в массив байтов, очищает существующие серии и категории и записывает ту же рабочую книгу обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Проверка макета диаграммы после изменения рабочей книги**

Когда вы заменяете встроенную рабочую книгу модифицированной, диаграмма сохраняет свои оригинальные коллекции серий и категорий. Это несоответствие может привести к ошибке [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) с сообщением об индексе вне диапазона. Очистите существующие серии и категории перед записью обновлённой рабочей книги обратно в диаграмму. Этот пример использует диаграмму, которая является первой формой на первом слайде. Комментарий отмечает место, где происходит редактирование рабочей книги; исполняемый пример записывает оригинальную рабочую книгу обратно и проверяет макет в памяти.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // Измените байты рабочей книги здесь, например, используя Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Очистка коллекций удаляет устаревшие ссылки на данные перед записью рабочей книги. Восстановите необходимые сопоставления серий и категорий для обновлённой рабочей книги перед использованием диаграммы.

## **Установка пользовательских числовых форматов для ячеек рабочей книги**

Используйте [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) для управления тем, как числовые значения отображаются в встроенной рабочей книге диаграммы. Например, в отчёте может потребоваться отображать коэффициент конверсии в виде процента с четырьмя десятичными знаками и коэффициент с пятью десятичными знаками. Оставляйте оба значения числовыми, чтобы они оставались доступными для вычислений и построения диаграммы.

Числовой формат изменяет только отображение, а не сохранённое значение. Формат `0.0000%` отображает `0.125` как `12.5000%`; он не заменяет сохранённое число на `12.5`. Аналогично, `0.00000` отображает `0.1234567` как `0.12346` без округления сохранённого значения. Если пользовательский формат — пустая строка (`""`), используется формат, возвращаемый [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--).

Ниже приведён пример, создающий столбчатую диаграмму и получающий доступ к её ячейкам через [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--). На листе 0 ячейка B2 содержит коэффициент конверсии, а C2 — коэффициент. Обе ячейки поставляют значения диаграммы. Пример также включает подписи значений, связанные с исходными форматами.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    IChartDataCell percentageName = workbook.getCell(0, "B1", "Conversion rate");
    IChartSeries percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    IChartDataCell precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    IChartDataCell precisionName = workbook.getCell(0, "C1", "Coefficient");
    IChartSeries precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Форматы ячеек рабочей книги отдельны от форматов, задаваемых напрямую на осях диаграммы или подписьях данных. В этом примере каждая подпись отображает значение своей исходной ячейки, потому что [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) установлено в `true`, а связь с исходным числовым форматом включена через [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) со значением `true`. После сохранения и повторного открытия презентации подписи отображают `12.5000%` и `0.12346`, как показано ниже. Вертикальная ось использует собственный числовой формат, заданный через [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) как `0.00`, при этом [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) установлено в `false`.

Чтобы отформатировать подпись данных независимо, отключите её связь с источником, установив `false`, и задайте формат через [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-). Это не изменит формат ячейки рабочей книги. Например, независимый формат подписи `0.00` отобразит первое значение как `0.13`, тогда как B2 по‑прежнему будет показывать `12.5000%`. См. [Подписи данных диаграммы](/slides/ru/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) для прямого форматирования подписей.

![Столбчатая диаграмма с подписями, связанными с источником, показывающими 12.5000% и 0.12346, а также независимо отформатированной числовой осью.](custom-cell-formats.png)

## **Установить ячейку рабочей книги в качестве подписи данных диаграммы**

Вы можете использовать текст из ячеек рабочей книги в качестве подписей данных диаграммы.

Этот пример добавляет пузырьковую диаграмму с данными по умолчанию на первый слайд существующей презентации. Он использует ячейки A10:A12 на листе 0 для первых трёх подписей в первой серии, включает подписи из ячеек и сохраняет обновлённую презентацию.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Управление листами**

Метод [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) предоставляет доступ к листам в рабочей книге диаграммы. Этот пример создаёт круговую диаграмму с данными по умолчанию и выводит имена всех листов в консоль.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Указать тип источника данных**

Этот пример создаёт 3D столбчатую диаграмму с данными по умолчанию и задаёт два названия серий, используя разные источники данных. Первое название задаётся строковым литералом; второе — ячейкой C1 на листе 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) выбирает источник для каждого названия. Пример сохраняет презентацию с обновлёнными названиями серий.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Обнаружить неподдерживаемые форматы встроенных рабочих книг**

Aspose.Slides не поддерживает формат Excel Binary Workbook (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать метод [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) на интерфейсе [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) вместе с перечислением [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска соответствующих диаграмм. Этот пример проверяет формы на первом слайде существующей презентации, пропускает не‑диаграммные формы и выводит диагностическое сообщение для каждой диаграммы с встроенной рабочей книгой .xlsb.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Читать или изменить поддерживаемые данные рабочей книги диаграммы здесь.
    }
} finally {
    presentation.dispose();
}
```

## **Внешняя рабочая книга**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Создать внешнюю рабочую книгу**

Используйте [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) и [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) для экспорта встроенной рабочей книги диаграммы в файл и привязки диаграммы к этой внешней рабочей книге.

Этот пример создаёт круговую диаграмму с данными по умолчанию и экспортирует её рабочую книгу. Запись в файл завершается перед назначением внешней рабочей книги в качестве источника данных диаграммы, после чего презентация сохраняется со ссылкой.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Установить внешнюю рабочую книгу**

С помощью метода [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) вы можете назначить внешнюю рабочую книгу диаграмме в качестве источника данных. Этот метод также может использоваться для обновления пути к внешней рабочей книге (если файл был перемещён).

Хотя вы не можете редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, такие книги всё равно могут использоваться как внешний источник данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в абсолютный путь.

В этом примере используется внешняя рабочая книга, лист которой с именем `Sheet1` содержит название серии в B1, названия категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает рабочую книгу и использует [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) для сопоставления A1:B4 с одной серией и тремя категориями. Презентация сохраняется с привязанной диаграммой.

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Параметр `updateChartData` метода [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) управляет тем, будет ли загружена рабочая книга.

* Когда `updateChartData` установлен в `false`, обновляется только путь к рабочей книге. Данные диаграммы не загружаются и не обновляются из целевой рабочей книги, поэтому рабочая книга может быть недоступна.
* Когда `updateChartData` установлен в `true`, данные диаграммы обновляются из целевой рабочей книги.

Следующий пример назначает фиктивный URL с `updateChartData`, установленным в `false`. Он сохраняет диаграмму с данными по умолчанию и не загружает недоступную рабочую книгу.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Получить путь к рабочей книге внешнего источника данных диаграммы**

Чтобы определить, к какой рабочей книге привязана диаграмма, проверьте, использует ли она внешний источник данных, и получите путь к её рабочей книге.

Этот пример проверяет первую форму на первом слайде презентации с привязанной внешней рабочей книгой. Если это диаграмма, связанная с внешней рабочей книгой, пример выводит [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) в консоль. Затем сохраняется копия презентации.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Редактировать данные диаграммы**

Вы можете редактировать данные во внешних рабочих книгах так же, как меняете содержимое внутренних рабочих книг. Если внешняя рабочая книга не может быть загружена, будет выброшено исключение.

Этот пример использует диаграмму, являющуюся первой формой на первом слайде и привязанную к доступной внешней рабочей книге. Он устанавливает значение первой точки данных первой серии в 100 и сохраняет обновлённую презентацию. Редактирование значений ячеек может обновлять связанный внешний файл XLSX, поэтому используйте копию, если необходимо сохранить оригинальную рабочую книгу.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Восстановить рабочую книгу из кэша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которая отсутствует или недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из кэшированных данных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/), вызовите [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), и установите [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) в `true` перед открытием презентации.

Следующий пример на Java восстанавливает данные рабочей книги для диаграммы, которая является первой формой на первом слайде и ссылается на недоступную внешнюю рабочую книгу. Он получает восстановленные данные через [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) и [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Читать или изменять восстановленные данные рабочей книги здесь.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides генерирует исключение. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы приемлемо, поскольку кэш может не содержать изменений, внесённых во внешнюю рабочую книгу после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. Диаграмма имеет [type of data source](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) и [path to an external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); если источник — внешняя рабочая книга, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому при перемещении рабочей книги может потребоваться обновить ссылку.

**Могу ли я использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие рабочие книги могут использоваться как внешний источник данных. Однако прямое редактирование удалённых рабочих книг из Aspose.Slides не поддерживается — их можно использовать только как источник.

**Перезаписывает ли Aspose.Slides внешний файл XLSX при сохранении презентации?**

Презентация сохраняет [link to the external file](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Редактирование данных диаграммы, привязанных к ячейкам, также может обновлять связанный локальный файл XLSX. Используйте копию рабочей книги, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при привязке. Обычно предварительно снимают защиту или готовят расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/java/)) и привязывают к этой копии.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один и тот же файл, обновление этого файла отразится в каждой диаграмме при следующей загрузке данных.