---
title: Управление книгами диаграмм в презентациях с использованием Java
linktitle: Книга диаграмм
type: docs
weight: 70
url: /ru/java/chart-workbook/
keywords:
- книга диаграммы
- данные диаграммы
- ячейка книги
- подпись данных
- лист
- источник данных
- внешняя книга
- внешние данные
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Откройте Aspose.Slides для Java: легко управляйте книгами диаграмм в форматах PowerPoint и OpenDocument, чтобы оптимизировать данные вашей презентации."
---
## **Обзор**

В этой статье объясняется, как работать с книгами диаграмм в Aspose.Slides. Показано, как считывать и записывать данные диаграммы через потоки книг, использовать ячейки книги в качестве подписи данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними книгами в качестве источников данных диаграммы. В примерах демонстрируется, как создать и назначить внешнюю книгу, получить путь к внешней книге, связанной с диаграммой, и редактировать данные диаграммы, когда книга доступна.

## **Считывание и запись данных диаграммы из книги**
Aspose.Slides предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IChartData#readWorkbookStream--) и [WriteWorkbookStream](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) , которые позволяют считывать и записывать книги данных диаграмм (содержащие данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаковым образом или иметь структуру, похожую на исходную.

Этот Java‑код демонстрирует пример операции:

```java
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

## **Установка ячейки книги в качестве подписи данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/ru/java/com.aspose.slides/presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте пузырьковую диаграмму с некоторыми данными.
4. Получите доступ к сериям диаграммы.
5. Установите ячейку книги в качестве подписи данных.
6. Сохраните презентацию.

Этот Java‑код показывает, как установить ячейку книги в качестве подписи данных диаграммы:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Создает объект класса презентации, представляющий файл презентации
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

Этот Java‑код демонстрирует операцию, в которой используется метод [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) для доступа к коллекции листов:

```java
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

## **Обнаружение неподдерживаемых форматов встроенных книг**

Aspose.Slides не поддерживает формат двоичной книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать метод `getEmbeddedWorkbookType` у [IChartData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IChartData) вместе с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/WorkbookType) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Встроенная книга находится в формате .xlsb, который не поддерживается.
            continue;
        }

        // Здесь можно считывать или изменять данные книги диаграммы.
    }
} finally {
    presentation.dispose();
}
```

## **Внешняя книга**

{{% alert color="primary" %}} 
В [Aspose.Slides 19.4](https://docs.aspose.com/slides/ru/java/aspose-slides-for-java-19-4-release-notes/) мы реализовали поддержку внешних книг в качестве источника данных для диаграмм.
{{% /alert %}} 

### **Создание внешней книги**

С помощью методов **`readWorkbookStream`** и **`setExternalWorkbook`** можно либо создать внешнюю книгу с нуля, либо сделать внутреннюю книгу внешней.

Этот Java‑код демонстрирует процесс создания внешней книги:

```java
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

### **Назначение внешней книги**

С помощью метода **`setExternalWorkbook`** можно назначить внешнюю книгу диаграмме в качестве источника данных. Этот метод также может использоваться для обновления пути к внешней книге (если она была перемещена).

Хотя редактировать данные в книгах, хранящихся в удалённых местах или ресурсах, нельзя, такие книги всё равно можно использовать как внешний источник данных. Если указать относительный путь к внешней книге, он автоматически преобразуется в полный путь.

Этот Java‑код показывает, как назначить внешнюю книгу:

```java
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

Параметр `ChartData` (в методе `setExternalWorkbook`) используется для указания, будет ли загружена Excel‑книга.

* Когда значение `ChartData` установлено в `false`, обновляется только путь к книге — данные диаграммы не загружаются и не обновляются из целевой книги. Этот параметр полезен, если целевая книга отсутствует или недоступна.  
* Когда значение `ChartData` установлено в `true`, данные диаграммы обновляются из целевой книги.

```java
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

### **Получение пути к внешнему источнику данных книги диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/ru/java/com.aspose.slides/presentation).
2. Получите ссылку на слайд по его индексу.
3. Создайте объект для формы диаграммы.
4. Создайте объект для типа источника (`ChartDataSourceType`), представляющего источник данных диаграммы.
5. Укажите соответствующее условие в зависимости от того, совпадает ли тип источника с типом внешней книги.

Этот Java‑код демонстрирует операцию:

```java
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

Данные во внешних книгах можно редактировать так же, как и во внутренних. Если внешнюю книгу нельзя загрузить, будет выброшено исключение.

Этот Java‑код реализует описанный процесс:

```java
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

## **FAQ**

**Можно ли определить, связана ли конкретная диаграмма с внешней или встроенной книгой?**

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chartdata/#getDataSourceType--) и [путь к внешней книге](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); если источник — внешняя книга, можно прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта, однако презентация сохраняет абсолютный путь в файле PPTX.

**Можно ли использовать книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги могут использоваться как внешний источник данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — они могут только быть источником.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Нет. Презентация сохраняет [ссылку на внешний файл](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) и использует её только для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно снимают защиту заранее или готовят расшифрованную копию (например, с помощью [Aspose.Cells](/cells/java/)) и связываются с этой копией.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один файл, его обновление отразится во всех диаграммах при следующей загрузке данных.