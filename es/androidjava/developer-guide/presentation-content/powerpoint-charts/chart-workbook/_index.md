---
title: Libro de Gráficos
type: docs
weight: 70
url: /androidjava/chart-workbook/
keywords: "Libro de gráficos, datos de gráficos, presentación de PowerPoint, Java, Aspose.Slides para Android a través de Java"
description: "Libro de gráficos en presentación de PowerPoint en Java"
---

## **Establecer Datos de Gráfico desde el Libro**
Aspose.Slides proporciona los métodos [ReadWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) y [WriteWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) que permiten leer y escribir libros de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Nota** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar a la fuente.

Este código Java demuestra una operación de ejemplo:

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

## **Establecer Celda de Libro como Etiqueta de Datos del Gráfico**

1. Crea una instancia de la [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/presentation) clase.
1. Obtén una referencia de la diapositiva a través de su índice.
1. Añade un gráfico de burbujas con algunos datos.
1. Accede a la serie del gráfico.
1. Establece la celda del libro como una etiqueta de datos.
1. Guarda la presentación.

Este código Java muestra cómo establecer una celda del libro como una etiqueta de datos del gráfico:

```java
String lbl0 = "Valor de la celda 0";
String lbl1 = "Valor de la celda 1";
String lbl2 = "Valor de la celda 2";

// Instancia una clase de presentación que representa un archivo de presentación
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

## **Gestionar Hojas de Cálculo**

Este código Java demuestra una operación donde se utiliza el método [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) para acceder a una colección de hojas de cálculo:

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

## **Especificar Tipo de Fuente de Datos**

Este código Java te muestra cómo especificar un tipo para una fuente de datos:

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

## **Libro Externo**

{{% alert color="primary" %}} 
En [Aspose.Slides 19.4](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-19-4-release-notes/), implementamos soporte para libros externos como fuente de datos para gráficos.
{{% /alert %}} 

### **Crear Libro Externo**

Usando los métodos **`readWorkbookStream`** y **`setExternalWorkbook`**, puedes crear un libro externo desde cero o hacer que un libro interno sea externo.

Este código Java demuestra el proceso de creación de un libro externo:

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

### **Establecer Libro Externo**

Usando el método **`setExternalWorkbook`**, puedes asignar un libro externo a un gráfico como su fuente de datos. Este método también se puede usar para actualizar una ruta al libro externo (si este último ha sido movido).

Mientras no puedes editar los datos en libros almacenados en ubicaciones o recursos remotos, aún puedes usar dichos libros como fuente de datos externa. Si se proporciona la ruta relativa para un libro externo, se convierte automáticamente en una ruta completa.

Este código Java te muestra cómo establecer un libro externo:

```java
// Crea una instancia de la clase Presentation
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

El parámetro `ChartData` (bajo el método `setExternalWorkbook`) se usa para especificar si un libro de excel será cargado o no. 

* Cuando el valor de `ChartData` se establece en `false`, solo se actualiza la ruta del libro; los datos del gráfico no se cargarán ni se actualizarán desde el libro de destino. Puede que desees usar esta configuración cuando estés en una situación donde el libro de destino no existe o no está disponible. 
* Cuando el valor de `ChartData` se establece en `true`, los datos del gráfico se actualizan desde el libro de destino.

```java
// Crea una instancia de la clase Presentation
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

### **Obtener la Ruta de la Fuente de Datos Externa del Gráfico**

1. Crea una instancia de la [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/presentation) clase.
1. Obtén una referencia de la diapositiva a través de su índice.
1. Crea un objeto para la forma del gráfico.
1. Crea un objeto para el tipo de fuente (`ChartDataSourceType`) que representa la fuente de datos del gráfico.
1. Especifica la condición relevante según el tipo de fuente sea el mismo que el tipo de fuente de datos del libro externo.

Este código Java demuestra la operación:

```java
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// Guarda la presentación
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Editar Datos del Gráfico**

Puedes editar los datos en los libros externos de la misma manera que realizas cambios en el contenido de los libros internos. Cuando un libro externo no se puede cargar, se lanza una excepción.

Este código Java es una implementación del proceso descrito:

```java
// Crea una instancia de la clase Presentation
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