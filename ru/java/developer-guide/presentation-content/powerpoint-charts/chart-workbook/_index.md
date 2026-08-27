---
title: "Управление рабочими книгами диаграмм в презентациях с использованием Java"
linktitle: "Рабочая книга диаграммы"
type: docs
weight: 70
url: /ru/java/chart-workbook/
keywords:
- "рабочая книга диаграммы"
- "данные диаграммы"
- "ячейка рабочей книги"
- "метка данных"
- "рабочий лист"
- "источник данных"
- "внешняя рабочая книга"
- "внешние данные"
- "кеш диаграммы"
- "восстановление рабочей книги"
- "PowerPoint"
- "презентация"
- "Java"
- "Aspose.Slides"
description: "Откройте для себя Aspose.Slides для Java: без труда управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая данные ваших презентаций."
---
## **Обзор**

В этой статье объясняется, как работать с рабочими книгами диаграмм в Aspose.Slides. Показано, как читать и записывать данные диаграмм через потоки рабочей книги, использовать ячейки рабочей книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных диаграмм. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IChartData#readWorkbookStream--) и [WriteWorkbookStream](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) , которые позволяют читать и записывать рабочие книги данных диаграмм (содержащие данные диаграмм, отредактированные в Aspose.Cells). **Note** данные диаграммы должны быть организованы аналогичным образом или иметь структуру, схожую с исходной.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Проверка макета диаграммы после изменения рабочей книги**

Когда вы заменяете встроенную рабочую книгу изменённой, диаграмма сохраняет свои исходные коллекции серий и категорий. Эта несоответствие может привести к исключению `chart.validateChartLayout()` с `ArgumentOutOfRangeException` (параметр: index). Чтобы избежать исключения, очистите существующие серии и категории **до** записи обновлённой рабочей книги обратно в диаграмму.

```java
// После изменения потока рабочей книги (например, с помощью Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// Очистить существующие ссылки на данные.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

// Записать обновлённую рабочую книгу обратно в диаграмму.
chart.getChartData().writeWorkbookStream(updatedWorkbook);

// Теперь проверка проходит успешно.
chart.validateChartLayout();
```

Очистка коллекций гарантирует, что структура данных диаграммы соответствует новой рабочей книге, позволяя `validateChartLayout()` завершиться без ошибок.

## **Установить ячейку рабочей книги в качестве метки данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/ru/java/com.aspose.slides/presentation) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте пузырчатую диаграмму с некоторыми данными.
4. Получите доступ к сериям диаграммы.
5. Установите ячейку рабочей книги в качестве метки данных.
6. Сохраните презентацию.

Этот Java‑код показывает, как установить ячейку рабочей книги в качестве метки данных диаграммы:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Создаёт экземпляр класса презентации, представляющего файл презентации
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Управление рабочими листами**

Этот Java‑код демонстрирует операцию, где метод [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) используется для доступа к коллекции листов:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Указание типа источника данных**

Этот Java‑код показывает, как указать тип для источника данных:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Обнаружение неподдерживаемых форматов встроенных рабочих книг**

Aspose.Slides не поддерживает формат бинарных книг Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать метод `getEmbeddedWorkbookType` интерфейса [IChartData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IChartData) вместе с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/WorkbookType) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Встроенная рабочая книга в формате .xlsb, который не поддерживается.
            continue;
        }

        // Читать или изменять данные рабочей книги диаграммы здесь.
    }
} finally {
    presentation.dispose();
}
```

## **Внешняя рабочая книга**

{{% alert color="info" %}} 
В версии [Aspose.Slides 19.4](https://docs.aspose.com/slides/ru/java/aspose-slides-for-java-19-4-release-notes/) мы реализовали поддержку внешних рабочих книг в качестве источника данных для диаграмм.
{{% /alert %}} 

### **Создать внешнюю рабочую книгу**

С помощью методов **`readWorkbookStream`** и **`setExternalWorkbook`** вы можете либо создать внешнюю рабочую книгу с нуля, либо сделать внутреннюю рабочую книгу внешней.

Этот Java‑код демонстрирует процесс создания внешней рабочей книги:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Установить внешнюю рабочую книгу**

С помощью метода **`setExternalWorkbook`** вы можете назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также может использоваться для обновления пути к внешней рабочей книге (если она была перемещена).

Хотя вы не можете редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, такие книги всё равно могут использоваться как внешний источник данных. Если указать относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

Этот Java‑код показывает, как установить внешнюю рабочую книгу:

```java
import com.aspose.slides.*;

// Создаёт экземпляр класса Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Второй параметр (`boolean`) метода `setExternalWorkbook` используется для указания, будет ли загружена Excel‑книга.

* Когда его значение `false`, обновляется только путь к книге — данные диаграммы не загружаются и не обновляются из целевой книги. Этот режим полезен, если целевая книга отсутствует или недоступна. 
* Когда его значение `true`, данные диаграммы обновляются из целевой книги.

```java
import com.aspose.slides.*;

// Создаёт экземпляр класса Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Получить путь к рабочей книге внешнего источника данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/ru/java/com.aspose.slides/presentation) .
2. Получите ссылку на слайд по его индексу.
3. Создайте объект для формы диаграммы.
4. Создайте объект для типа источника (`ChartDataSourceType`), представляющего источник данных диаграммы.
5. Укажите соответствующее условие, основываясь на том, что тип источника совпадает с типом внешней рабочей книги.

Этот Java‑код демонстрирует операцию:

```java
import com.aspose.slides.*;

// Создаёт экземпляр класса Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
    // Сохраняет презентацию
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Редактировать данные диаграммы**

Вы можете редактировать данные во внешних рабочих книгах так же, как изменяете содержимое внутренних книг. Если внешняя рабочая книга не может быть загружена, будет выброшено исключение.

Этот Java‑код реализует описанный процесс:

```java
import com.aspose.slides.*;

// Создаёт экземпляр класса Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Восстановление рабочей книги из кеша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которой нет или она недоступна, Aspose.Slides может реконструировать рабочую книгу диаграммы из данных, закешированных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/), настройте их с помощью [SpreadsheetOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/spreadsheetoptions/), и вызовите [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) с `true` перед открытием презентации.

Следующий Java‑пример открывает презентацию, ссылки в которой указывают на недоступную внешнюю рабочую книгу, и получает восстановленные данные через [IChart.getChartData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichart/#getChartData--) и [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Читать или изменять восстановленные данные рабочей книги здесь.
} finally {
    presentation.dispose();
}
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides выбрасывает исключение. Включайте восстановление только тогда, когда использование закешированных данных диаграммы считается приемлемой альтернативой, поскольку кеш может не содержать изменений, внесённых во внешнюю книгу после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chartdata/#getDataSourceType--) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); если источник — внешняя рабочая книга, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта; однако помните, что презентация сохраняет абсолютный путь в файле PPTX.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги могут использоваться как внешний источник данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Нет. Презентация хранит [ссылку на внешний файл](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) и использует её только для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно снимают защиту заранее или создают расшифрованную копию (например, с помощью [Aspose.Cells](/cells/java/)) и связывают с этой копией.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если они указывают на один и тот же файл, обновление этого файла будет отражено во всех диаграммах при следующей загрузке данных.