---
title: Gestionar libros de trabajo de gráficos en presentaciones usando Java
linktitle: Libro de trabajo de gráfico
type: docs
weight: 70
url: /es/java/chart-workbook/
keywords:
- libro de trabajo de gráfico
- datos del gráfico
- celda del libro de trabajo
- etiqueta de datos
- hoja de cálculo
- origen de datos
- libro de trabajo externo
- datos externos
- caché del gráfico
- recuperación de libro de trabajo
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Descubra Aspose.Slides para Java: gestione sin esfuerzo los libros de trabajo de gráficos en formatos PowerPoint y OpenDocument para optimizar los datos de sus presentaciones."
---
## **Visión general**

Este artículo explica cómo trabajar con libros de trabajo de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráficos mediante flujos de libros de trabajo, usar celdas de libro de trabajo como etiquetas de datos de gráficos, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores del gráfico.

También trata el trabajo con libros de trabajo externos como fuentes de datos de gráficos. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, obtener la ruta de un libro de trabajo externo vinculado a un gráfico y editar los datos del gráfico cuando el libro de trabajo está disponible.

## **Leer y escribir datos de gráfico desde un libro de trabajo**

Aspose.Slides proporciona los métodos [ReadWorkbookStream](https://reference.aspose.com/slides/es/java/com.aspose.slides/IChartData#readWorkbookStream--) y [WriteWorkbookStream](https://reference.aspose.com/slides/es/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) que permiten leer y escribir libros de trabajo de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Nota** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar a la fuente.

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

### **Validar el diseño del gráfico después de la modificación del libro de trabajo**

Cuando reemplazas un libro de trabajo incrustado por uno modificado, el gráfico conserva sus colecciones originales de series y categorías. Esta inconsistencia puede causar que `chart.validateChartLayout()` lance una `ArgumentOutOfRangeException` (parámetro: index). Para evitar la excepción, elimina las series y categorías existentes **antes** de escribir el libro de trabajo actualizado de nuevo en el gráfico.

```java
// Después de modificar el flujo del libro de trabajo (p. ej., usando Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// Eliminar las referencias de datos existentes.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

// Escribir el libro de trabajo actualizado de nuevo en el gráfico.
chart.getChartData().writeWorkbookStream(updatedWorkbook);

// Ahora la validación tiene éxito.
chart.validateChartLayout();
```

Eliminar las colecciones garantiza que la estructura de los datos del gráfico coincida con el nuevo libro de trabajo, lo que permite que `validateChartLayout()` se complete sin errores.

## **Establecer una celda de libro de trabajo como etiqueta de datos del gráfico**

1. Crear una instancia de la clase [Presentation](https://apireference.aspose.com/slides/es/java/com.aspose.slides/presentation).
2. Obtener la referencia de una diapositiva mediante su índice.
3. Añadir un gráfico de burbujas con algunos datos.
4. Acceder a la serie del gráfico.
5. Establecer la celda del libro de trabajo como etiqueta de datos.
6. Guardar la presentación.

Este código Java muestra cómo establecer una celda de libro de trabajo como etiqueta de datos del gráfico:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

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

## **Administrar hojas de cálculo**

Este código Java demuestra una operación en la que se utiliza el método [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/es/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) para acceder a una colección de hojas de cálculo:

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

## **Especificar el tipo de origen de datos**

Este código Java muestra cómo especificar un tipo para un origen de datos:

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

## **Detectar formatos de libros de trabajo incrustados no compatibles**

Aspose.Slides no admite el formato de libro de trabajo binario de Excel (.xlsb) que puede incrustarse en algunos gráficos. Puedes usar el método `getEmbeddedWorkbookType` en [IChartData](https://reference.aspose.com/slides/es/java/com.aspose.slides/IChartData) junto con la enumeración [WorkbookType](https://reference.aspose.com/slides/es/java/com.aspose.slides/WorkbookType) para detectar formatos no compatibles y omitir esos gráficos.

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
            // El libro de trabajo incrustado está en formato .xlsb, que no es compatible.
            continue;
        }

        // Leer o modificar los datos del libro de trabajo del gráfico aquí.
    }
} finally {
    presentation.dispose();
}
```

## **Libro de trabajo externo**

{{% alert color="info" %}} 
En [Aspose.Slides 19.4](https://docs.aspose.com/slides/es/java/aspose-slides-for-java-19-4-release-notes/), implementamos soporte para libros de trabajo externos como origen de datos para los gráficos.
{{% /alert %}} 

### **Crear un libro de trabajo externo**

Usando los métodos **`readWorkbookStream`** y **`setExternalWorkbook`**, puedes crear un libro de trabajo externo desde cero o convertir un libro de trabajo interno en externo.

Este código Java demuestra el proceso de creación de un libro de trabajo externo:

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

### **Establecer un libro de trabajo externo**

Usando el método **`setExternalWorkbook`**, puedes asignar un libro de trabajo externo a un gráfico como su origen de datos. Este método también puede usarse para actualizar la ruta al libro de trabajo externo (si este se ha movido).

Aunque no puedes editar los datos en libros de trabajo almacenados en ubicaciones remotas o recursos, aún puedes utilizarlos como fuentes de datos externas. Si se proporciona una ruta relativa para un libro de trabajo externo, se convierte automáticamente en una ruta completa.

Este código Java muestra cómo establecer un libro de trabajo externo:

```java
import com.aspose.slides.*;

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

El segundo parámetro (`boolean`) del método `setExternalWorkbook` se usa para especificar si se cargará o no un libro de Excel.

* Cuando su valor se establece en `false`, solo se actualiza la ruta del libro de trabajo; los datos del gráfico no se cargarán ni actualizarán desde el libro de trabajo de destino. Puedes usar esta configuración cuando el libro de trabajo de destino no exista o no esté disponible. 
* Cuando su valor se establece en `true`, los datos del gráfico se actualizan desde el libro de trabajo de destino.

```java
import com.aspose.slides.*;

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

### **Obtener la ruta del libro de trabajo externo de origen de datos de un gráfico**

1. Crear una instancia de la clase [Presentation](https://apireference.aspose.com/slides/es/java/com.aspose.slides/presentation).
2. Obtener la referencia de una diapositiva mediante su índice.
3. Crear un objeto para la forma del gráfico.
4. Crear un objeto para el tipo de origen (`ChartDataSourceType`) que representa el origen de datos del gráfico.
5. Especificar la condición pertinente basándose en que el tipo de origen sea el mismo que el tipo de origen de libro de trabajo externo.

Este código Java demuestra la operación:

```java
import com.aspose.slides.*;

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

### **Editar datos del gráfico**

Puedes editar los datos en libros de trabajo externos de la misma manera que modificas el contenido de los libros de trabajo internos. Cuando no se puede cargar un libro de trabajo externo, se lanza una excepción.

Este código Java es una implementación del proceso descrito:

```java
import com.aspose.slides.*;

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

### **Recuperar un libro de trabajo de la caché del gráfico**

Si un gráfico utiliza un libro de trabajo externo que falta o no está disponible, Aspose.Slides puede reconstruir el libro de trabajo del gráfico a partir de los datos almacenados en caché en la presentación. Crea [LoadOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/), configúralo con [SpreadsheetOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/spreadsheetoptions/), y llama a [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/es/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) con `true` antes de abrir la presentación.

El siguiente ejemplo Java abre una presentación cuyo gráfico hace referencia a un libro de trabajo externo no disponible y accede a los datos recuperados mediante [IChart.getChartData](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichart/#getChartData--) y [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Leer o modificar los datos del libro de trabajo recuperado aquí.
} finally {
    presentation.dispose();
}
```

Si el libro de trabajo externo no está disponible y la recuperación está deshabilitada, Aspose.Slides lanza una excepción. Habilita la recuperación solo cuando usar los datos del gráfico en caché sea una solución aceptable, ya que la caché puede no contener cambios realizados en el libro de trabajo externo después de la última actualización de la presentación.

## **Preguntas frecuentes**

**¿Puedo determinar si un gráfico específico está vinculado a un libro de trabajo externo o incrustado?**

Sí. Un gráfico tiene un [tipo de origen de datos](https://reference.aspose.com/slides/es/java/com.aspose.slides/chartdata/#getDataSourceType--) y una [ruta a un libro de trabajo externo](https://reference.aspose.com/slides/es/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); si el origen es un libro de trabajo externo, puedes leer la ruta completa para asegurarte de que se está usando un archivo externo.

**¿Se admiten rutas relativas a libros de trabajo externos y cómo se almacenan?**

Sí. Si especificas una ruta relativa, se convierte automáticamente en una ruta absoluta. Esto es conveniente para la portabilidad del proyecto; sin embargo, ten en cuenta que la presentación almacenará la ruta absoluta en el archivo PPTX.

**¿Puedo usar libros de trabajo ubicados en recursos/redes compartidas?**

Sí, esos libros de trabajo pueden usarse como fuente de datos externa. No obstante, la edición directa de libros de trabajo remotos desde Aspose.Slides no está soportada; solo pueden usarse como origen.

**¿Aspose.Slides sobrescribe el XLSX externo al guardar la presentación?**

No. La presentación almacena un [enlace al archivo externo](https://reference.aspose.com/slides/es/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) y lo usa para leer los datos. El archivo externo en sí no se modifica al guardar la presentación.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al crear el vínculo. Un enfoque común es eliminar la protección con antelación o preparar una copia descifrada (por ejemplo, usando [Aspose.Cells](/cells/java/)) y enlazar a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro de trabajo externo?**

Sí. Cada gráfico almacena su propio enlace. Si todos apuntan al mismo archivo, la actualización de ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.