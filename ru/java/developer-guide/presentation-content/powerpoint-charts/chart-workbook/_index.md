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
- метка данных
- лист
- источник данных
- внешняя рабочая книга
- внешние данные
- кеш диаграммы
- восстановление рабочей книги
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для Java: без труда управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, чтобы упростить работу с данными вашей презентации."
---
## **Обзор**

Эта статья объясняет, как работать с рабочими книгами диаграмм в Aspose.Slides. Она показывает, как читать и писать данные диаграммы через потоки рабочей книги, использовать ячейки рабочей книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и задавать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных диаграммы. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь внешней рабочей книги, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

Для ячеек рабочей книги, представляющих отсутствующие данные, см. [Управление отображением пустых ячеек](/slides/ru/java/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение режимов отображения в линейной диаграмме.

## **Включить данные из скрытых строк и столбцов**

Используйте [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) для управления тем, будет ли диаграмма отображать данные из скрытых строк и столбцов листа. Установите `true`, чтобы отображать только видимые ячейки, или `false`, чтобы включать как видимые, так и скрытые ячейки. Эта настройка управляет построением диаграммы; она не скрывает и не отображает строки или столбцы листа.

[Пример презентации](hidden-source-data.pptx) содержит столбчатую диаграмму в виде первой фигуры на первом слайде. Встроенный лист `Sheet1` имеет исходный диапазон `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё равно содержат значения.

| Строка листа | A: Месяц | B: Розничные | C: Оптовые (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте доступ к исходным ячейкам через [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) и читайте [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) для проверки их скрытого статуса. Этот метод сообщает о скрытом статусе без его изменения. В данном файле B2 видима, B3 относится к скрытой строке, а C2 — к скрытому столбцу; пример выводит `false`, `true` и `true` соответственно.

Для этого примера обновите данные диаграммы после изменения настройки построения: сохраните встроенную рабочую книгу с помощью [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) и загрузите её снова с помощью [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). При включении всех ячеек также используйте [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) для восстановления полного диапазона, включая скрытую категорию «Февраль». Простое изменение флага недостаточно для обновления кэшированных данных диаграммы и меток категорий в этом примере.

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

Пример сохраняет две версии презентации: одну только с видимыми значениями розничных продаж (10 и 20), другую со всеми шестью значениями. Ниже показаны два режима построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных рабочих книгах.

| Только видимые ячейки (`true`) | Все ячейки (`false`) |
| --- | --- |
| ![Только видимые ячейки: значения розничных продаж 10 и 20 для Января и Марта.](hidden_cells_True.png) | ![Все ячейки: значения розничных и оптовых продаж для Января, Февраля и Марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) управляет тем, как отображаются отсутствующие значения; он не включает и не исключает скрытые исходные данные. Смотрите [Управление отображением пустых ячеек](/slides/ru/java/chart-series/#control-the-display-of-empty-cells) для примера.

## **Получить диапазон данных диаграммы**

Перед обновлением данных рабочей книги в существующей презентации проверьте исходные диапазоны, чтобы определить, какие ячейки листа использует каждая диаграмма. Метод [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) возвращает текущий диапазон данных в виде формулы, квалифицированной листом, например `Sheet1!$A$1:$D$5`. Здесь `Sheet1` — имя листа, `!` отделяет его от диапазона ячеек, а `$A$1:$D$5` указывает ячейки от A1 до D5 включительно. Символы `$` обозначают абсолютные ссылки на строки и столбцы.

Метод читает текущий диапазон без изменения диаграммы или её рабочей книги. Если диаграмма не использует рабочую книгу в качестве источника данных, выбрасывается `InvalidOperationException`. Подробнее см. в [Справочнике API ChartData](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/).

В этом примере открывается презентация и проверяются фигуры на каждом слайде на наличие диаграмм. Выводятся имя каждой диаграммы и её исходный диапазон. Если диаграмма не использует рабочую книгу, выводится сообщение и переход к следующей диаграмме.

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

Aspose.Slides for Java предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) и [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---), позволяющие читать и писать рабочие книги данных диаграммы (содержащие данные, отредактированные в Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы тем же способом или иметь структуру, аналогичную исходной.

В этом примере используется презентация с диаграммой в виде первой фигуры на первом слайде. Встроенная рабочая книга считывается в массив байтов, очищаются существующие серии и категории, и та же рабочая книга записывается обратно. Изменения остаются в памяти; презентация не сохраняется.

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

При замене встроенной рабочей книги изменённой диаграмма сохраняет свои исходные коллекции серий и категорий. Это несоответствие может вызвать ошибку [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) с сообщением о выходе индекса за пределы. Очистите существующие серии и категории перед записью обновлённой рабочей книги обратно в диаграмму. В примере используется диаграмма, являющаяся первой фигурой на первом слайде. Комментарий отмечает место, где могла бы произойти правка рабочей книги; исполняемый пример записывает оригинальную рабочую книгу обратно и проверяет макет в памяти.

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

Очистка коллекций удаляет устаревшие ссылки на данные перед записью рабочей книги. Восстановите необходимые серии и соответствия категорий для обновлённой рабочей книги перед использованием диаграммы.

## **Установить пользовательские числовые форматы для ячеек рабочей книги**

Используйте [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) для контроля отображения числовых значений в встроенной рабочей книге диаграммы. Например, в отчёте может потребоваться коэффициент конверсии, отображаемый в виде процента с четырьмя знаками после запятой, и коэффициент, отображаемый с пятью знаками после запятой. Оставляйте оба значения числовыми, чтобы они оставались доступными для вычислений и построения диаграммы.

Числовой формат меняет только отображение, а не сохранённое значение. Формат `0.0000%` отображает `0.125` как `12.5000%`; он не заменяет сохранённое число на `12.5`. Аналогично, `0.00000` отображает `0.1234567` как `0.12346`, не округляя сохранённое значение. Если пользовательский формат — пустая строка (`""`), используется формат, возвращаемый [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--).

В следующем примере создаётся столбчатая диаграмма и её ячейки получаются через [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--). На листе 0 ячейка B2 содержит коэффициент конверсии, а C2 — коэффициент. Обе ячейки поставляют значения в диаграмму. Пример также включает метки значений, привязанные к исходным форматам.

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

Форматы ячеек рабочей книги отделены от форматов, задаваемых непосредственно на осях диаграммы или метках данных. В этом примере каждая метка отображает значение своей исходной ячейки, потому что [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) установлен в `true`, а [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) также `true`. После сохранения и повторного открытия презентации метки показывают `12.5000%` и `0.12346`, как показано ниже. Вертикальная ось использует собственный числовой формат, заданный через [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) как `0.00`, а [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) установлен в `false`.

Чтобы задать самостоятельный формат метки, отключите флаг привязки к источнику (`false`) и задайте формат через [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-). Это не меняет формат ячейки рабочей книги. Например, независимый формат метки `0.00` отображает первое значение как `0.13`, тогда как B2 всё равно показывает `12.5000%`. См. [Метки данных диаграммы](/slides/ru/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) для прямого форматирования меток.

Изображение ниже было получено из сохранённой презентации после её повторного открытия:

![Столбчатая диаграмма с метками, привязанными к источнику, показывающая 12.5000% и 0.12346, и независимо отформатированной числовой осью.](custom-cell-formats.png)

## **Установить ячейку рабочей книги в качестве метки данных диаграммы**

Можно использовать текст из ячеек рабочей книги в качестве меток данных диаграммы.

В этом примере добавляется пузырьковая диаграмма с данными по умолчанию на первый слайд существующей презентации. Используются ячейки A10:A12 на листе 0 для первых трёх меток первой серии, включаются метки из ячеек и сохраняется обновлённая презентация.

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

Метод [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) предоставляет доступ к листам в рабочей книге диаграммы. В примере создаётся круговая диаграмма с данными по умолчанию и выводятся имена всех листов в консоль.

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

## **Задать тип источника данных**

Значения точек серии также могут храниться непосредственно как числовые литералы. См. [Задать значения серии с помощью числовых литералов](/slides/ru/java/chart-series/#set-series-values-using-numeric-literals) для полного примера, сохраняющего и читающего их. Тип источника значений точек отделён от внутренней или внешней конфигурации рабочей книги диаграммы; использование числовых литералов само по себе не удаляет встроенную рабочую книгу.

В этом примере создаётся 3D‑столбчатая диаграмма с данными по умолчанию и задаются два имени серии, использующие разные источники данных. Первое имя задаётся строковым литералом; второе — ячейкой C1 на листе 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) выбирает источник для каждого имени. Пример сохраняет презентацию с обновлёнными именами серий.

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

## **Обнаружение неподдерживаемых форматов встроенных рабочих книг**

Aspose.Slides не поддерживает формат бинарных рабочих книг Excel (.xlsb), которые могут быть встроены в некоторые диаграммы. Вы можете использовать метод [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) на интерфейсе [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) вместе с перечислением [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска соответствующих диаграмм. Пример проверяет фигуры на первом слайде существующей презентации, пропускает не‑диаграммные фигуры и выводит диагностическое сообщение для каждой диаграммы с встроенной рабочей книгой .xlsb.

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

        // Читать или изменять поддерживаемые данные рабочей книги диаграммы здесь.
    }
} finally {
    presentation.dispose();
}
```

## **Внешняя рабочая книга**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Создать внешнюю рабочую книгу**

Используйте [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) и [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) для экспорта встроенной рабочей книги диаграммы в файл и связывания диаграммы с этой внешней рабочей книгой.

В примере создаётся круговая диаграмма с данными по умолчанию и экспортируется её рабочая книга. Запись в файл завершается перед назначением внешней рабочей книги в качестве источника данных диаграммы, после чего сохраняется связанная презентация.

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

### **Назначить внешнюю рабочую книгу**

С помощью метода [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) можно назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также может использоваться для обновления пути к внешней рабочей книге (если она была перемещена).

Хотя редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, нельзя, такие книги можно использовать в качестве внешнего источника данных. Если задаётся относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

В примере используется внешняя рабочая книга, лист которой `Sheet1` содержит имя серии в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает рабочую книгу и с помощью [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) отображает диапазон A1:B4 в одну серию и три категории. Презентация сохраняется с привязанной диаграммой.

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

* Когда `updateChartData` равно `false`, обновляется только путь к рабочей книге. Данные диаграммы не загружаются и не обновляются из целевой рабочей книги, поэтому рабочая книга может быть недоступна.
* Когда `updateChartData` равно `true`, данные диаграммы обновляются из целевой рабочей книги.

В следующем примере задаётся заполнитель URL с `updateChartData`, установленным в `false`. Сохраняется презентация с данными круговой диаграммы по умолчанию без загрузки недоступной рабочей книги.

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

### **Получить путь к внешней рабочей книге, используемой диаграммой**

Чтобы определить, к какой рабочей книге привязана диаграмма, проверьте, использует ли она внешний источник данных, и получите её путь.

Пример проверяет первую фигуру на первом слайде презентации с привязанной внешней рабочей книгой. Если это диаграмма, связанная с внешней рабочей книгой, выводится [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) в консоль. Затем сохраняется копия презентации.

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

Данные во внешних рабочих книгах можно редактировать так же, как и содержимое внутренних рабочих книг. Если внешняя рабочая книга не может быть загружена, генерируется исключение.

В примере используется диаграмма, являющаяся первой фигурой на первом слайде и привязанная к доступной внешней рабочей книге. Значение первой точки данных первой серии задаётся равным 100, после чего презентация сохраняется. Редактирование значений ячеек может обновлять связанный внешний файл XLSX, поэтому используйте копию, если необходимо сохранить оригинальную рабочую книгу.

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

Если диаграмма использует внешнюю рабочую книгу, которой нет или она недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из данных, кэшированных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/), вызовите [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), и установите [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) в `true` перед открытием презентации.

Следующий пример на Java восстанавливает данные рабочей книги для диаграммы, являющейся первой фигурой на первом слайде и ссылающейся на недоступную внешнюю рабочую книгу. Доступ к восстановленным данным осуществляется через [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) и [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides генерирует исключение. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемой альтернативой, поскольку кэш может не содержать изменений, внесённых во внешнюю рабочую книгу после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. Диаграмма имеет [тип источника данных](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); если источник — внешняя рабочая книга, можно считать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому при перемещении рабочей книги может потребоваться обновить ссылку.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие рабочие книги могут служить внешними источниками данных. Однако прямое редактирование удалённых рабочих книг из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Презентация хранит [ссылку на внешний файл](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Редактирование данных диаграммы, привязанных к ячейкам, также может обновлять связанный локальный XLSX файл. Используйте копию рабочей книги, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно заранее снимают защиту или готовят расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/java/)) и связывают её.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один и тот же файл, обновление этого файла будет отражено в каждой диаграмме при следующей загрузке данных.