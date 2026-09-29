---
title: Управление рабочими книгами диаграмм в презентациях с помощью Java
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/java/chart-workbook/
keywords:
- рабочая книга диаграмм
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
- Java
- Aspose.Slides
description: "Познакомьтесь с Aspose.Slides для Java: легко управлять рабочими книгами диаграмм в форматах PowerPoint и OpenDocument для упрощения данных вашей презентации."
---
## **Обзор**

Эта статья объясняет, как работать с рабочими книгами диаграмм в Aspose.Slides. Она показывает, как читать и записывать данные диаграммы через потоки рабочей книги, использовать ячейки рабочей книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и задавать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных диаграмм. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

Для ячеек рабочей книги, представляющих отсутствующие данные, см. [Управление отображением пустых ячеек](/slides/ru/java/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение режимов отображения в линейной диаграмме.

## **Включить данные из скрытых строк и столбцов**

Используйте [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) для управления тем, будет ли диаграмма строить данные из скрытых строк и столбцов листа. Установите `true`, чтобы строить только видимые ячейки, или `false`, чтобы включить и видимые, и скрытые ячейки. Эта настройка управляет построением диаграммы; она не скрывает и не отображает строки или столбцы листа.

Скачайте [hidden-source-data.pptx](hidden-source-data.pptx) и разместите его в рабочем каталоге. На первом слайде находится столбчатая диаграмма как первая фигура. Встроенный лист `Sheet1` содержит диапазон `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё ещё содержат значения.

| Строка листа | A: Месяц | B: Розница | C: Оптовая (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте доступ к ячейкам‑источникам через [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) и проверяйте их скрытый статус с помощью [IChartDataCell.isHidden](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/#isHidden--). Этот метод сообщает статус скрытия без его изменения. В этом файле B2 видима, B3 относится к скрытой строке, а C2 — к скрытому столбцу; пример выводит `false`, `true` и `true` соответственно.

Для этого примера обновите данные диаграммы после изменения настройки построения: сохраните встроенную рабочую книгу с помощью [readWorkbookStream](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#readWorkbookStream--) и загрузите её заново с помощью [writeWorkbookStream](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-). При включении всех ячеек также используйте [setRange](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) для восстановления полного диапазона, включая скрытую категорию «Февраль». Простая смена флага недостаточна для обновления кэшированных данных диаграммы и меток категорий в этом образце.

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
                // Восстановить полный диапазон источника, включая скрытые категории.
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

Пример сохраняет `hidden_cells_true.pptx` только с видимыми значениями розницы (10 и 20) и `hidden_cells_false.pptx` со всеми шестью значениями. Ниже показаны два режима построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных рабочих книгах.

| Только видимые ячейки (`true`) | Все ячейки (`false`) |
| --- | --- |
| ![Только видимые ячейки: значения розницы 10 и 20 для января и марта.](hidden_cells_True.png) | ![Все ячейки: значения розницы и оптовой цены для января, февраля и марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) управляет тем, как отображаются отсутствующие значения; он не включает и не исключает скрытые исходные данные. См. [Управление отображением пустых ячеек](/slides/ru/java/chart-series/#control-the-display-of-empty-cells) для примера.

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides for Java предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#readWorkbookStream--) и [writeWorkbookStream](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-), позволяющие читать и записывать рабочие книги данных диаграмм (содержащие данные, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаковым способом или иметь структуру, похожую на исходную.

Этот пример открывает `chart.pptx`, в котором первая фигура на первом слайде должна быть диаграммой. Он читает встроенную рабочую книгу в массив байтов, очищает существующие серии и категории и записывает ту же рабочую книгу обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

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

Когда вы заменяете встроенную рабочую книгу модифицированной, диаграмма сохраняет исходные коллекции серий и категорий. Это несоответствие может привести к сбою [IChart.validateChartLayout](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichart/#validateChartLayout--) с ошибкой «выход за пределы индекса». Очистите существующие серии и категории перед записью обновлённой рабочей книги обратно в диаграмму. Пример требует `chart.pptx` с диаграммой как первой фигурой на первом слайде. Комментарий отмечает место, где будет происходить редактирование рабочей книги; исполняемый пример записывает оригинальную рабочую книгу обратно и проверяет макет в памяти.

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

Очистка коллекций удаляет устаревшие ссылки на данные перед записью рабочей книги. Перед использованием диаграммы перестройте необходимые сопоставления серий и категорий для обновлённой рабочей книги.

## **Установить ячейку рабочей книги в качестве метки данных диаграммы**

Можно использовать текст из ячеек рабочей книги в качестве меток данных диаграммы. Ниже представлены шаги, показывающие, как привязать метки в пузырьковой диаграмме к ячейкам её рабочей книги.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) .
2. Получите первый слайд по нулевому индексу.
3. Добавьте пузырьковую диаграмму с данными по умолчанию.
4. Доступ к сериям диаграммы.
5. Установите ячейку рабочей книги в качестве метки данных.
6. Сохраните презентацию.

Этот пример открывает `chart2.pptx`, в котором должен быть хотя бы один слайд, и добавляет пузырьковую диаграмму с данными по умолчанию. Он использует ячейки A10:A12 листа 0 для первых трёх меток в первой серии, включает метки из ячеек и сохраняет результат в `resultchart.pptx`.

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

Метод [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) предоставляет доступ к листам в рабочей книге диаграммы. Этот пример создаёт круговую диаграмму с данными по умолчанию и выводит имена каждого листа в консоль.

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

Этот пример создаёт 3‑D столбчатую диаграмму с данными по умолчанию и задаёт два имени серий, используя разные источники данных. Первое имя задаётся строковым литералом; второе — ячейкой C1 листа 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/datasourcetype/) выбирает источник для каждого имени. Результат сохраняется в `pres.pptx`.

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

Aspose.Slides не поддерживает формат бинарных рабочих книг Excel (.xlsb), которые могут быть встроены в некоторые диаграммы. Вы можете использовать метод [getEmbeddedWorkbookType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) на интерфейсе [IChartData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм. Пример проверяет фигуры на первом слайде `sample.pptx`, пропускает не‑диаграммы и выводит диагностическое сообщение для каждой диаграммы с вложенной рабочей книгой .xlsb.

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

### **Создание внешней рабочей книги**

Используйте [readWorkbookStream](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#readWorkbookStream--) и [setExternalWorkbook](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) для экспорта встроенной рабочей книги диаграммы в файл и привязки диаграммы к этой внешней рабочей книге.

Этот пример создаёт круговую диаграмму с данными по умолчанию, сохраняет её рабочую книгу в `externalWorkbook1.xlsx` и завершает запись файла перед назначением его в качестве источника данных диаграммы. Он сохраняет связанную презентацию в `externalWorkbook.pptx`.

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

### **Назначение внешней рабочей книги**

С помощью метода [setExternalWorkbook](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) можно назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот же метод можно использовать для обновления пути к внешней рабочей книге (если файл был перемещён).

Хотя редактировать данные в рабочих книгах, хранящихся в удалённых ресурсах, нельзя, их всё равно можно использовать как внешний источник данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в абсолютный.

Пример требует `externalWorkbook.xlsx` в рабочем каталоге. На листе `Sheet1` должны быть: имя серии в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает рабочую книгу и с помощью [setRange](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) сопоставляет диапазон A1:B4 с одной серией и тремя категориями. Результат сохраняется в `Presentation_with_externalWorkbook.pptx`.

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

Параметр `updateChartData` метода [setExternalWorkbook](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) управляет тем, будет ли загружена рабочая книга.

* Когда `updateChartData` равно `false`, обновляется только путь к рабочей книге. Данные диаграммы не загружаются и не обновляются из целевой книги, поэтому сама книга может быть недоступна.
* Когда `updateChartData` равно `true`, данные диаграммы обновляются из целевой рабочей книги.

Следующий пример назначает фиктивный URL с `updateChartData`, установленным в `false`. Он сохраняет диаграмму с данными по умолчанию и не пытается загрузить недоступную книгу.

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

### **Получение пути к внешней рабочей книге, используемой диаграммой**

Чтобы определить, какая рабочая книга связана с диаграммой, сначала проверьте, использует ли диаграмма внешний источник данных. Если да, вы можете получить путь к книге, выполнив следующие шаги.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) .
2. Получите первый слайд по нулевому индексу.
3. Убедитесь, что первая фигура — это диаграмма.
4. Прочитайте тип источника данных диаграммы.
5. Если источник — внешняя рабочая книга, прочитайте её путь.

Этот пример открывает `externalWorkbook.pptx`, созданный в предыдущем примере, и проверяет первую фигуру на первом слайде. Если это диаграмма, связанная с внешней рабочей книгой, пример выводит [getExternalWorkbookPath](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) в консоль. Затем сохраняет копию презентации в `Result.pptx`.

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

Данные во внешних рабочих книгах можно редактировать так же, как и во внутренних. Если внешняя рабочая книга не может быть загружена, будет выброшено исключение.

Пример требует `presentation.pptx` с диаграммой как первой фигурой на первом слайде и доступной внешней рабочей книгой. Он устанавливает значение первой точки данных в первой серии равным 100 и сохраняет презентацию в `presentation_out.pptx`. Редактирование значений ячеек может обновлять связанный внешний файл XLSX, поэтому используйте копию, если необходимо сохранить оригинал.

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

### **Восстановление рабочей книги из кэша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которой нет или она недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из кэшированных данных презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/), вызовите [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), и установите [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) в `true` перед открытием презентации.

Следующий пример Java открывает `presentation.pptx`, где первая фигура на первом слайде должна быть диаграммой, ссылающейся на недоступную внешнюю рабочую книгу, и получает восстановленные данные через [IChart.getChartData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichart/#getChartData--) и [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

Если внешняя рабочая книга недоступна, а восстановление отключено, Aspose.Slides бросит исключение. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемой альтернативой, так как кэш может не содержать изменения, внесённые во внешнюю книгу после последнего обновления презентации.

## **FAQ**

**Можно ли определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chartdata/#getDataSourceType--) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); если источник — внешняя рабочая книга, можно считать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому при перемещении книги может потребоваться обновить ссылку.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги можно использовать как внешний источник данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Презентация сохраняет [ссылку на внешний файл](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). При редактировании данных, основанных на ячейках, может также обновляться связанный локальный файл XLSX. Используйте копию рабочей книги, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычный подход — снять защиту заранее или подготовить расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/java/)) и привязать её.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один и тот же файл, обновление этого файла будет отражено в каждой диаграмме при следующей загрузке данных.