---
title: Рабочая тетрадь диаграмм
type: docs
weight: 70
url: /ru/java/chart-workbook/
keywords: "Рабочая тетрадь диаграмм, данные диаграммы, презентация PowerPoint, Java, Aspose.Slides для Java"
description: "Рабочая тетрадь диаграмм в презентации PowerPoint на Java"
---

## **Установка данных диаграммы из рабочей тетради**
Aspose.Slides предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#readWorkbookStream--) и [WriteWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-), которые позволяют читать и записывать рабочие тетради с данными диаграмм (содержит данные диаграмм, отредактированные с помощью Aspose.Cells). **Обратите внимание**, что данные диаграммы должны быть организованы тем же образом или иметь структуру, аналогичную исходной.

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

## **Установить ячейку рабочей тетради как метку данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму пузырьков с некоторыми данными.
4. Получите серию диаграммы.
5. Установите ячейку рабочей тетради в качестве метки данных.
6. Сохраните презентацию.

Этот код на Java показывает, как установить ячейку рабочей тетради в качестве метки данных диаграммы:

```java
String lbl0 = "Значение ячейки метки 0";
String lbl1 = "Значение ячейки метки 1";
String lbl2 = "Значение ячейки метки 2";

// Создает экземпляр класса презентации, который представляет файл презентации
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

Этот код на Java демонстрирует операцию, где используется метод [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) для доступа к коллекции рабочих листов:

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

## **Внешняя рабочая тетрадь**

{{% alert color="primary" %}} 
В [Aspose.Slides 19.4](https://docs.aspose.com/slides/java/aspose-slides-for-java-19-4-release-notes/) мы внедрили поддержку внешних рабочих тетрадей в качестве источника данных для диаграмм.
{{% /alert %}} 

### **Создание внешней рабочей тетради**

Используя методы **`readWorkbookStream`** и **`setExternalWorkbook`**, вы можете создать внешнюю рабочую тетрадь с нуля или сделать внутреннюю рабочую тетрадь внешней.

Этот код на Java демонстрирует процесс создания внешней рабочей тетради:

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

### **Установка внешней рабочей тетради**

Используя метод **`setExternalWorkbook`**, вы можете назначить внешнюю рабочую тетрадь диаграмме в качестве ее источника данных. Этот метод также может быть использован для обновления пути к внешней рабочей тетради (если последняя была перемещена).

Хотя вы не можете редактировать данные в рабочих тетрадях, хранящихся в удаленных местах или ресурсах, вы все равно можете использовать такие рабочие тетради в качестве внешнего источника данных. Если предоставлен относительный путь для внешней рабочей тетради, он автоматически преобразуется в полный путь.

Этот код на Java показывает, как установить внешнюю рабочую тетрадь:

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

Параметр `ChartData` (в методе `setExternalWorkbook`) используется для указания, будет ли загружена рабочая тетрадь Excel или нет. 

* Когда значение `ChartData` установлено в `false`, обновляется только путь к рабочей тетради — данные диаграммы не будут загружены или обновлены из целевой рабочей тетради. Вы можете захотеть использовать эту настройку, когда целевая рабочая тетрадь отсутствует или недоступна. 
* Когда значение `ChartData` установлено в `true`, данные диаграммы обновляются из целевой рабочей тетради.

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

### **Получить путь к рабочей тетради внешнего источника данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation).
2. Получите ссылку на слайд по его индексу.
3. Создайте объект для формы диаграммы.
4. Создайте объект для типа источника (`ChartDataSourceType`), который представляет источник данных диаграммы.
5. Укажите соответствующее условие, основываясь на том, что тип источника такой же, как тип источника данных внешней рабочей тетради.

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

### **Редактировать данные диаграммы**

Вы можете редактировать данные во внешних рабочих тетрадях так же, как вы вносите изменения в содержимое внутренних рабочих тетрадей. Когда внешняя рабочая тетрадь не может быть загружена, возникает исключение.

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