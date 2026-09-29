---
title: Управление рабочими книгами диаграмм в презентациях на Android
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/androidjava/chart-workbook/
keywords:
- рабочая книга диаграммы
- данные диаграммы
- ячейка рабочей книги
- метка данных
- лист
- источник данных
- внешняя рабочая книга
- внешние данные
- кэш диаграммы
- восстановление рабочей книги
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для Android через Java: без труда управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая данные вашей презентации."
---
## **Обзор**

Эта статья объясняет, как работать с книгами диаграмм в Aspose.Slides. Она показывает, как читать и записывать данные диаграммы через потоки книги, использовать ячейки книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Она также охватывает работу с внешними книгами в качестве источников данных диаграммы. Примеры демонстрируют, как создать и назначить внешнюю книгу, получить путь внешней книги, связанной с диаграммой, и редактировать данные диаграммы, когда книга доступна.

Для ячеек книги, представляющих отсутствующие данные, смотрите [Контроль отображения пустых ячеек](/slides/ru/androidjava/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение режимов отображения в линейной диаграмме.

## **Включить данные из скрытых строк и столбцов**

Используйте [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) для управления тем, будет ли диаграмма использовать данные из скрытых строк и столбцов листа. Установите `true`, чтобы использовать только видимые ячейки, или `false`, чтобы включить как видимые, так и скрытые ячейки. Эта настройка управляет построением диаграммы; она не скрывает и не отображает строки или столбцы листа.

Скачайте [hidden-source-data.pptx](hidden-source-data.pptx) и поместите её в рабочий каталог. На первом слайде находится столбчатая диаграмма как первая фигура. Встроенный лист `Sheet1` содержит диапазон источника `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё равно содержат значения.

| Строка листа | A: Месяц | B: Розничные | C: Оптовые (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте исходные ячейки через [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) и читайте [IChartDataCell.isHidden](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) для проверки их скрытого статуса. Этот метод сообщает статус скрытия без изменения его. В этом файле B2 видима, B3 относится к скрытой строке, а C2 — к скрытому столбцу; пример выводит `false`, `true` и `true` соответственно.

Для этого примера обновите данные диаграммы после изменения настройки построения: сохраните встроенную книгу с помощью [readWorkbookStream](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) и загрузите её снова с помощью [writeWorkbookStream](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-). При включении всех ячеек также используйте [setRange](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) для восстановления полного диапазона, включая скрытую категорию «Февраль». Простая смена флага недостаточна для обновления кэшированных данных диаграммы и меток категорий в этом образце.

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

Пример сохраняет `hidden_cells_true.pptx` только с видимыми значениями розничных продаж (10 и 20) и `hidden_cells_false.pptx` со всеми шестью значениями. Ниже приведены изображения, иллюстрирующие два режима построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных книгах.

| Только видимые ячейки (`true`) | Все ячейки (`false`) |
| --- | --- |
| ![Только видимые ячейки: розничные значения 10 и 20 для Января и Марта.](hidden_cells_True.png) | ![Все ячейки: розничные и оптовые значения для Января, Февраля и Марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) управляет тем, как отображаются отсутствующие значения; он не включает и не исключает скрытые исходные данные. Смотрите [Контроль отображения пустых ячеек](/slides/ru/androidjava/chart-series/#control-the-display-of-empty-cells) для примера.

## **Чтение и запись данных диаграммы из книги**

Aspose.Slides for Android via Java предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) и [writeWorkbookStream](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-), позволяющие читать и записывать книги данных диаграмм (содержащие данные, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаково или иметь структуру, аналогичную исходным данным.

Этот пример открывает `chart.pptx`, в которой первая фигура на первом слайде должна быть диаграммой. Он читает встроенную книгу в массив байтов, очищает существующие серии и категории и записывает ту же книгу обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

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

### **Проверка макета диаграммы после изменения книги**

Когда вы заменяете встроенную книгу модифицированной, диаграмма сохраняет оригинальные коллекции серий и категорий. Это несоответствие может привести к ошибке [IChart.validateChartLayout](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichart/#validateChartLayout--) с индексом вне диапазона. Очистите существующие серии и категории перед записью обновлённой книги обратно в диаграмму. Этот пример требует `chart.pptx` с диаграммой в качестве первой фигуры на первом слайде. Комментарием отмечено место, где могла бы происходить правка книги; исполняемый пример записывает оригинальную книгу обратно и проверяет макет в памяти.

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

Очистка коллекций удаляет устаревшие ссылки перед записью книги. Перед использованием диаграммы восстановите необходимые соответствия серий и категорий для обновлённой книги.

## **Установка ячейки книги в качестве метки данных диаграммы**

Можно использовать текст из ячеек книги в качестве меток данных диаграммы. Ниже перечислены шаги, показывающие, как привязать метки в «пузырьковой» диаграмме к ячейкам её книги данных.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите первый слайд по нулевому индексу.
3. Добавьте пузырьковую диаграмму с данными по умолчанию.
4. Получите серии диаграммы.
5. Установите ячейку книги в качестве метки данных.
6. Сохраните презентацию.

Этот пример открывает `chart2.pptx`, в которой должен быть как минимум один слайд, и добавляет пузырьковую диаграмму с данными по умолчанию. Он использует ячейки A10:A12 листа 0 для первых трёх меток первой серии, включает метки из ячеек и сохраняет результат в `resultchart.pptx`.

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

Метод [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) предоставляет доступ к листам в книге диаграммы. Этот пример создаёт круговую диаграмму с данными по умолчанию и выводит каждый лист в консоль.

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

## **Указание типа источника данных**

Этот пример создаёт 3‑мерную столбчатую диаграмму с данными по умолчанию и задаёт два имени серий, используя разные источники данных. Первое имя задаётся строковым литералом; второе — ячейкой C1 листа 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/datasourcetype/) выбирает источник для каждого имени. Результат сохраняется в `pres.pptx`.

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

## **Обнаружение неподдерживаемых форматов встроенных книг**

Aspose.Slides не поддерживает формат двоичной книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать метод [getEmbeddedWorkbookType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) на интерфейсе [IChartData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска соответствующих диаграмм. Этот пример просматривает фигуры на первом слайде `sample.pptx`, пропускает не‑диаграммные фигуры и выводит диагностическое сообщение для каждой диаграммы с встроенной книгой .xlsb.

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

## **Внешняя книга**

Aspose.Slides поддерживает использование внешних книг в качестве источника данных для диаграмм.

### **Создание внешней книги**

Используйте [readWorkbookStream](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) и [setExternalWorkbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) для экспорта встроенной книги диаграммы в файл и привязки диаграммы к этой внешней книге.

Этот пример создаёт круговую диаграмму с данными по умолчанию, записывает её книгу в `externalWorkbook1.xlsx` и завершает запись файла перед назначением его в качестве источника данных диаграммы. Затем сохраняет связанную презентацию в `externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Назначение внешней книги**

С помощью метода [setExternalWorkbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) можно присвоить внешнюю книгу диаграмме в качестве источника данных. Этот метод также может использоваться для обновления пути к внешней книге (если она была перемещена).

Хотя редактировать данные в книгах, хранящихся в удалённых местах или ресурсах, нельзя, такие книги всё равно могут использоваться как внешний источник данных. Если указан относительный путь к внешней книге, он автоматически преобразуется в абсолютный.

Этот пример требует файл `externalWorkbook.xlsx` в рабочем каталоге. Его лист `Sheet1` должен содержать имя серии в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает книгу и использует [setRange](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) для сопоставления A1:B4 с одной серией и тремя категориями. Результат сохраняется в `Presentation_with_externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Параметр `updateChartData` метода [setExternalWorkbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) управляет тем, будет ли книга загружена.

* Когда `updateChartData` равен `false`, обновляется только путь к книге. Данные диаграммы не загружаются и не обновляются из целевой книги, поэтому книга может быть недоступна.
* Когда `updateChartData` равен `true`, данные диаграммы обновляются из целевой книги.

В следующем примере задаётся заполнитель URL с `updateChartData`, установленным в `false`. Диаграмма сохраняет данные по умолчанию, а презентация сохраняется без загрузки недоступной книги.

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

### **Получение пути внешней книги‑источника диаграммы**

Чтобы определить, какая книга связана с диаграммой, сначала проверьте, использует ли диаграмма внешний источник данных. Если да, путь к книге можно получить, выполнив следующие шаги.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите первый слайд по нулевому индексу.
3. Убедитесь, что первая фигура — диаграмма.
4. Прочитайте тип источника данных диаграммы.
5. Если источник — внешняя книга, прочитайте её путь.

Этот пример открывает `externalWorkbook.pptx`, созданный в предыдущем примере, и проверяет первую фигуру на первом слайде. Если это диаграмма, связанная с внешней книгой, пример выводит [getExternalWorkbookPath](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) в консоль. Затем сохраняет копию презентации в `Result.pptx`.

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

### **Редактирование данных диаграммы**

Можно редактировать данные во внешних книгах так же, как и во внутренних. Если внешняя книга не может быть загружена, генерируется исключение.

Этот пример требует `presentation.pptx` с диаграммой в качестве первой фигуры на первом слайде и доступной внешней книги. Он задаёт значение 100 для первой точки первой серии и сохраняет презентацию в `presentation_out.pptx`. Редактирование значений ячеек может обновить связанный внешний файл XLSX, поэтому используйте копию, если необходимо сохранить оригинал.

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

### **Восстановление книги из кэша диаграммы**

Если диаграмма использует внешнюю книгу, которой нет или она недоступна, Aspose.Slides может восстановить книгу диаграммы из кэшированных данных презентации. Создайте объект [LoadOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/loadoptions/), вызовите [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) и установите [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) в `true` перед открытием презентации.

Следующий пример Java открывает `presentation.pptx`, первая фигура на первом слайде которого должна быть диаграммой, ссылающейся на недоступную внешнюю книгу, и получает восстановленные данные через [IChart.getChartData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichart/#getChartData--) и [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // Прочитать или изменить восстановленные данные рабочей книги здесь.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Если внешняя книга недоступна и восстановление отключено, Aspose.Slides генерирует исключение. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы приемлемо, так как кэш может не содержать изменений, внесённых во внешнюю книгу после последнего обновления презентации.

## **FAQ**

**Можно ли определить, связана ли конкретная диаграмма с внешней или встроенной книгой?**

Да. Диаграмма имеет [data source type](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) и [path to an external workbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); если источник — внешняя книга, можно прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому перемещение книги может потребовать обновления ссылки.

**Можно ли использовать книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги могут использоваться как внешний источник данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Презентация хранит [link to the external file](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Редактирование данных диаграммы, основанных на ячейках, также может обновить связанный локальный файл XLSX. Используйте копию книги, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при привязке. Обычным решением является предварительное снятие защиты или подготовка расшифрованной копии (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/java/)) и привязка к этой копии.

**Может ли несколько диаграмм ссылаться на одну и ту же внешнюю книгу?**

Да. Каждая диаграмма сохраняет собственную ссылку. Если они указывают на один и тот же файл, обновление этого файла отразится в каждой диаграмме при следующей загрузке данных.