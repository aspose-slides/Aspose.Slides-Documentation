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
  - кэш диаграммы
  - восстановление рабочей книги
  - PowerPoint
  - презентация
  - Java
  - Aspose.Slides
description: "Откройте для себя Aspose.Slides для Java: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая работу с данными вашей презентации."
---
## **Обзор**

В этой статье объясняется, как работать с рабочими книгами диаграмм в Aspose.Slides. Показано, как читать и записывать данные диаграмм через потоки рабочих книг, использовать ячейки рабочей книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных для диаграмм. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

## **Чтение и запись данных диаграммы из рабочей книги**
Aspose.Slides предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IChartData#readWorkbookStream--) и [WriteWorkbookStream](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) , которые позволяют читать и записывать рабочие книги данных диаграмм (содержащие данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаково или иметь структуру, схожую с исходной.

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

### **Проверка расположения диаграммы после изменения рабочей книги**

Когда вы заменяете встроенную рабочую книгу изменённой, диаграмма сохраняет свои исходные коллекции серий и категорий. Такая несогласованность может привести к тому, что [IChart.validateChartLayout](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichart/#validateChartLayout--) бросит `ArgumentOutOfRangeException` (parameter: index). Чтобы избежать исключения, очистите существующие серии и категории **до** записи обновлённой рабочей книги обратно в диаграмму.

```java
// После изменения потока рабочей книги (например, с использованием Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// Очистить существующие ссылки на данные.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Очистка коллекций гарантирует, что структура данных диаграммы соответствует новой рабочей книге, позволяя `validateChartLayout` завершиться без ошибок.

## **Установка ячейки рабочей книги в качестве метки данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/ru/java/com.aspose.slides/presentation) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте пузырчатую диаграмму с некоторыми данными.
1. Получите доступ к сериям диаграммы.
1. Установите ячейку рабочей книги в качестве метки данных.
1. Сохраните презентацию.

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Создает экземпляр класса презентации, представляющего файл презентации
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

Этот Java‑код демонстрирует операцию, в которой метод [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) используется для доступа к коллекции листов:

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

Aspose.Slides не поддерживает двоичный формат Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать метод `getEmbeddedWorkbookType` у [IChartData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IChartData) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/WorkbookType) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм.

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

        // Здесь можно читать или изменять данные рабочей книги диаграммы.
    }
} finally {
    presentation.dispose();
}
```

## **Внешняя рабочая книга**

{{% alert color="info" %}} 
В [Aspose.Slides 19.4](https://docs.aspose.com/slides/ru/java/aspose-slides-for-java-19-4-release-notes/) мы реализовали поддержку внешних рабочих книг в качестве источника данных для диаграмм.
{{% /alert %}} 

### **Создание внешней рабочей книги**

Используя методы **`readWorkbookStream`** и **`setExternalWorkbook`**, вы можете либо создать внешнюю рабочую книгу с нуля, либо сделать внутреннюю рабочую книгу внешней.

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

С помощью метода **`setExternalWorkbook`** можно назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также может использоваться для обновления пути к внешней рабочей книге (если она была перемещена).

Хотя вы не можете редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, такие книги всё равно можно использовать в качестве внешнего источника данных. Если указать относительный путь к внешней рабочей книге, он автоматически будет преобразован в полный путь.

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

Второй (`boolean`) параметр метода `setExternalWorkbook` используется для указания, будет ли загружена Excel‑рабочая книга.

* Когда его значение установлено в `false`, обновляется только путь к рабочей книге — данные диаграммы не загружаются и не обновляются из целевой рабочей книги. Этот вариант полезен, если целевая рабочая книга отсутствует или недоступна. 
* Когда его значение установлено в `true` , данные диаграммы обновляются из целевой рабочей книги.

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

### **Получение пути к внешней рабочей книге источника данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/ru/java/com.aspose.slides/presentation) .
1. Получите ссылку на слайд по его индексу.
1. Создайте объект для формы диаграммы.
1. Создайте объект типа источника (`ChartDataSourceType`), представляющего источник данных диаграммы.
1. Укажите соответствующее условие, исходя из того, что тип источника совпадает с типом внешней рабочей книги.

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

Вы можете редактировать данные во внешних рабочих книгах так же, как меняете содержимое внутренних книг. Если внешняя рабочая книга не может быть загружена, бросается исключение.

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

Если диаграмма использует внешнюю рабочую книгу, которой нет или она недоступна, Aspose.Slides может воссоздать рабочую книгу диаграммы из данных, кэшированных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/), настройте их с помощью [SpreadsheetOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/spreadsheetoptions/), и вызовите [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) с `true` перед открытием презентации.

Следующий Java‑пример открывает презентацию, в которой диаграмма ссылается на недоступную внешнюю рабочую книгу, и получает восстановленные данные через [IChart.getChartData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichart/#getChartData--) и [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Здесь можно читать или изменять данные восстановленной рабочей книги.
} finally {
    presentation.dispose();
}
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides бросает исключение. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемой заменой, поскольку кэш может не содержать изменения, сделанные во внешней рабочей книге после последнего обновления презентации.

## **Часто задаваемые вопросы**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**  
Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chartdata/#getDataSourceType--) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) ; если источник — внешняя рабочая книга, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**  
Да. При указании относительного пути он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта, однако презентация сохраняет абсолютный путь в файле PPTX.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**  
Да, такие рабочие книги могут использоваться в качестве внешнего источника данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — они могут быть только источниками.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**  
Нет. Презентация хранит [ссылку на внешний файл](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) и использует её только для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**  
Aspose.Slides не принимает пароль при создании ссылки. Обычно снимают защиту заранее или готовят расшифрованную копию (например, с помощью [Aspose.Cells](/cells/java/)) и ссылаются на неё.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**  
Да. Каждая диаграмма хранит свою собственную ссылку. Если они указывают на один и тот же файл, изменения в этом файле отразятся во всех диаграммах при следующей загрузке данных.