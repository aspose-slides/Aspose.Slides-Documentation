---
title: У管理工作簿图表在Android演示中
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/androidjava/chart-workbook/
keywords:
- рабочая книга диаграммы
- данные диаграммы
- ячейка рабочей книги
- подпись данных
- лист
- источник данных
- внешняя рабочая книга
- внешние данные
- кеш диаграммы
- восстановление рабочей книги
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для Android на Java: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая данные вашей презентации."
---
## **Обзор**

Эта статья объясняет, как работать с рабочими книгами диаграмм в Aspose.Slides. В ней показано, как считывать и записывать данные диаграммы через потоки рабочей книги, использовать ячейки рабочей книги в качестве подписей данных диаграммы, получать доступ к коллекциям листов и задавать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных диаграммы. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

Для ячеек рабочей книги, представляющих отсутствующие данные, см. [Control the Display of Empty Cells](/slides/ru/androidjava/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение линейных диаграмм доступных режимов отображения.

## **Чтение и запись данных диаграммы из рабочей книги**
Aspose.Slides предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) и [WriteWorkbookStream](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) , которые позволяют считывать и записывать рабочие книги данных диаграмм (содержащие данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаково или иметь структуру, схожую с исходной.

Этот Java‑код демонстрирует пример операции:

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

### **Проверка компоновки диаграммы после изменения рабочей книги**

Когда вы заменяете встроенную рабочую книгу модифицированной, диаграмма сохраняет свои оригинальные коллекции рядов и категорий. Это несоответствие может привести к сбою [IChart.validateChartLayout](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IChart#validateChartLayout--) с ошибкой «индекс вне диапазона». Очистите существующие ряды и категории перед записью обновлённой рабочей книги обратно в диаграмму.

```java
// После изменения потока рабочей книги (например, с использованием Aspose.Cells)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// Очистить существующие ссылки на данные.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Очистка коллекций гарантирует, что структура данных диаграммы соответствует новой рабочей книге, позволяя `validateChartLayout` завершиться без ошибок.

## **Установка ячейки рабочей книги в качестве подписи данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте пузырчатую диаграмму с некоторыми данными.
1. Доступ к рядам диаграммы.
1. Установите ячейку рабочей книги в качестве подписи данных.
1. Сохраните презентацию.

Этот Java‑код показывает, как установить ячейку рабочей книги в качестве подписи данных диаграммы:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Создает экземпляр класса Presentation, представляющий файл презентации
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

## **Управление листами**

Этот Java‑код демонстрирует операцию, где метод [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) используется для доступа к коллекции листов:

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

## **Задание типа источника данных**

Этот Java‑код показывает, как задать тип для источника данных:

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

Aspose.Slides не поддерживает формат бинарных рабочих книг Excel (.xlsb), которые могут быть встроены в некоторые диаграммы. Вы можете использовать метод `getEmbeddedWorkbookType` интерфейса [IChartData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IChartData) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/WorkbookType) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм.

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

        // Читайте или изменяйте данные рабочей книги диаграммы здесь.
    }
} finally {
    presentation.dispose();
}
```

## **Внешняя рабочая книга**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Создание внешней рабочей книги**

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

### **Установка внешней рабочей книги**

С помощью метода **`setExternalWorkbook`** вы можете назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также можно использовать для обновления пути к внешней рабочей книге (если последняя была перемещена).

Хотя редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, нельзя, такие книги всё равно могут использоваться как внешний источник данных. Если указать относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

Этот Java‑код показывает, как установить внешнюю рабочую книгу:

```java
import com.aspose.slides.*;

// Создает экземпляр класса Presentation
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

Параметр `updateChartData` (в методе `setExternalWorkbook`) используется для указания, будет ли загружаться Excel‑книга.

* Когда значение `updateChartData` равно `false`, обновляется только путь к рабочей книге — данные диаграммы не загружаются и не обновляются из целевой книги. Этот параметр полезен, если целевая книга отсутствует или недоступна. 
* Когда значение `updateChartData` равно `true`, данные диаграммы обновляются из целевой книги.

```java
import com.aspose.slides.*;

// Создает экземпляр класса Presentation
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

### **Получение пути к внешнему источнику данных рабочей книги диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Создайте объект для формы диаграммы.
1. Создайте объект для типа источника (`ChartDataSourceType`), представляющего источник данных диаграммы.
1. Укажите соответствующее условие в зависимости от того, совпадает ли тип источника с типом внешней рабочей книги.

Этот Java‑код демонстрирует операцию:

```java
import com.aspose.slides.*;

// Создает экземпляр класса Presentation
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

### **Редактирование данных диаграммы**

Вы можете редактировать данные во внешних рабочих книгах так же, как меняете содержимое внутренних книг. Если внешняя рабочая книга не может быть загружена, будет выброшено исключение.

Этот Java‑код реализует описанный процесс:

```java
import com.aspose.slides.*;

// Создает экземпляр класса Presentation
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

### **Восстановление рабочей книги из кэша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которой нет или она недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из данных, кэшированных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/loadoptions/), настройте их с помощью [SpreadsheetOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/spreadsheetoptions/), и вызовите [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) со значением `true` перед открытием презентации.

Следующий Java‑пример открывает презентацию, у которой диаграмма ссылается на недоступную внешнюю рабочую книгу, и получает восстановленные данные через [IChart.getChartData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichart/#getChartData--) и [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Читать или изменять данные восстановленной рабочей книги здесь.
} finally {
    presentation.dispose();
}
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides бросит исключение. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы допустимо, поскольку кэш может не содержать изменений, внесённых во внешнюю книгу после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); если источник — внешняя рабочая книга, можно прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта; однако презентация сохраняет абсолютный путь в файле PPTX.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги могут использоваться как внешний источник данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — их можно лишь использовать как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Нет. Презентация хранит [ссылку на внешний файл](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) и использует её для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при привязке. Обычно снимают защиту заранее или готовят расшифрованную копию (например, с помощью [Aspose.Cells](/cells/androidjava/)) и привязывают её.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если они указывают на один и тот же файл, обновление этого файла будет отражено в каждой диаграмме при следующей загрузке данных.