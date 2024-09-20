---
title: Рабочая книга графиков
type: docs
weight: 70
url: /androidjava/chart-workbook/
keywords: "Рабочая книга графиков, данные графиков, презентация PowerPoint, Java, Aspose.Slides для Android через Java"
description: "Рабочая книга графиков в презентации PowerPoint на Java"
---

## **Установить данные графика из рабочей книги**
Aspose.Slides предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) и [WriteWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-), которые позволяют читать и записывать рабочие книги данных графиков (содержащие данные графиков, отредактированные с помощью Aspose.Cells). **Обратите внимание**, что данные графиков должны быть организованы тем же образом или должны иметь структуру, аналогичную исходной.

Этот код на Java демонстрирует пример операции:

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

## **Установить ячейку Workbook как метку данных графика**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте пузырьковый график с некоторыми данными.
1. Получите доступ к сериям графиков.
1. Установите ячейку рабочей книги в качестве метки данных.
1. Сохраните презентацию.

Этот код на Java показывает, как установить ячейку рабочей книги в качестве метки данных графика:

```java
String lbl0 = "Значение ячейки метки 0";
String lbl1 = "Значение ячейки метки 1";
String lbl2 = "Значение ячейки метки 2";

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

## **Управление рабочими листами**

Этот код на Java демонстрирует операцию, в которой метод [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) используется для доступа к коллекции рабочих листов:

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

## **Указать тип источника данных**

Этот код на Java показывает, как указать тип для источника данных:

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

## **Внешняя рабочая книга**

{{% alert color="primary" %}} 
В [Aspose.Slides 19.4](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-19-4-release-notes/) мы реализовали поддержку внешних рабочих книг в качестве источника данных для графиков.
{{% /alert %}} 

### **Создать внешнюю рабочую книгу**

Используя методы **`readWorkbookStream`** и **`setExternalWorkbook`**, вы можете либо создать внешнюю рабочую книгу с нуля, либо сделать внутреннюю рабочую книгу внешней.

Этот код на Java демонстрирует процесс создания внешней рабочей книги:

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

### **Установить внешнюю рабочую книгу**

Используя метод **`setExternalWorkbook`**, вы можете назначить внешнюю рабочую книгу графику в качестве его источника данных. Этот метод также может использоваться для обновления пути к внешней рабочей книге (если последняя была перемещена).

Хотя вы не можете редактировать данные в рабочих книгах, хранящихся в удаленных местах или ресурсах, вы все равно можете использовать такие рабочие книги в качестве внешнего источника данных. Если относительный путь для внешней рабочей книги предоставлен, он автоматически преобразуется в полный путь.

Этот код на Java показывает, как установить внешнюю рабочую книгу:

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

Параметр `ChartData` (в методе `setExternalWorkbook`) используется для указания, будет ли загружена рабочая книга Excel или нет. 

* Когда значение `ChartData` установлено в `false`, обновляется только путь к рабочей книге — данные графика не будут загружены или обновлены из целевой рабочей книги. Вам может понадобиться использовать эту настройку, когда целевая рабочая книга отсутствует или недоступна. 
* Когда значение `ChartData` установлено в `true`, данные графика обновляются из целевой рабочей книги.

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

### **Получить путь к внешнему источнику данных графика**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Создайте объект для формы графика.
1. Создайте объект для типа источника (`ChartDataSourceType`), который представляет источник данных графика.
1. Укажите соответствующее условие в зависимости от того, является ли тип источника тем же, что и тип источника внешней рабочей книги.

Этот код на Java демонстрирует операцию:

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

### **Редактировать данные графика**

Вы можете редактировать данные во внешних рабочих книгах так же, как вносите изменения в содержимое внутренних рабочих книг. Когда внешняя рабочая книга не может быть загружена, возникает исключение.

Этот код на Java является реализацией описанного процесса:

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