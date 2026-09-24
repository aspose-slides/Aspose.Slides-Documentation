---
title: Gestionar libros de trabajo de gráfico en presentaciones usando JavaScript
linktitle: Libro de trabajo de gráfico
type: docs
weight: 70
url: /es/nodejs-java/chart-workbook/
keywords:
- libro de trabajo de gráfico
- datos de diagrama
- celda de libro de trabajo
- etiqueta de datos
- hoja de cálculo
- origen de datos
- libro de trabajo externo
- datos externos
- caché de diagrama
- recuperación de libro de trabajo
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra Aspose.Slides para Node.js mediante Java: gestione sin esfuerzo los libros de trabajo de diagramas en formatos PowerPoint y OpenDocument para optimizar los datos de su presentación."
---
## **Visión general**

Este artículo explica cómo trabajar con libros de trabajo de diagramas en Aspose.Slides. Muestra cómo leer y escribir datos de diagramas a través de flujos de libros de trabajo, usar celdas del libro como etiquetas de datos del diagrama, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores del diagrama.

También cubre el trabajo con libros de trabajo externos como fuentes de datos del diagrama. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, recuperar la ruta de un libro de trabajo externo vinculado a un diagrama y editar los datos del diagrama cuando el libro de trabajo está disponible.

Para celdas del libro que representan datos ausentes, vea [Control the Display of Empty Cells](/slides/es/nodejs-java/chart-series/) para conocer la diferencia entre una celda vacía y cero, y una comparación de diagramas de líneas de los modos de visualización disponibles.

## **Leer y escribir datos de diagramas desde un libro de trabajo**

Aspose.Slides proporciona los métodos [readWorkbookStream](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) y [writeWorkbookStream](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) que le permiten leer y escribir libros de trabajo con datos de diagramas (conteniendo datos de diagramas editados con Aspose.Cells). **Nota** que los datos del diagrama deben estar organizados de la misma manera o deben tener una estructura similar a la fuente.

Este código JavaScript muestra una operación de ejemplo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Validar la distribución del diagrama después de la modificación del libro de trabajo**

Cuando sustituye un libro de trabajo incrustado por uno modificado, el diagrama conserva sus colecciones originales de series y categorías. Esta discrepancia puede hacer que [Chart.validateChartLayout](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Chart#validateChartLayout--) falle con un error de índice fuera de rango. Borre las series y categorías existentes antes de escribir el libro de trabajo actualizado de nuevo en el diagrama.

```javascript
// Después de modificar el flujo del libro de trabajo (p.ej., usando Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// Borrar referencias de datos existentes.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Borrar las colecciones garantiza que la estructura de datos del diagrama sea coherente con el nuevo libro de trabajo, permitiendo que `validateChartLayout` se complete sin errores.

## **Establecer una celda del libro como etiqueta de datos del diagrama**

1. Cree una instancia de la [Presentation](https://apireference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation) clase.
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Añada un diagrama de burbujas con algunos datos.
4. Acceda a la serie del diagrama.
5. Establezca la celda del libro como una etiqueta de datos.
6. Guarde la presentación.

Este código JavaScript le muestra cómo establecer una celda del libro como etiqueta de datos del diagrama:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Instancia una clase de presentación que representa un archivo de presentación
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Administrar hojas de cálculo**

Este código JavaScript muestra una operación donde se utiliza el método [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) para acceder a una colección de hojas de cálculo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Especificar el tipo de origen de datos**

Este código JavaScript le muestra cómo especificar un tipo para un origen de datos:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Detectar formatos de libro de trabajo incrustado no compatibles**

Aspose.Slides no admite el formato de libro de trabajo binario de Excel (.xlsb) que puede estar incrustado en algunos diagramas. Puede usar el método `getEmbeddedWorkbookType` en [ChartData](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/) junto con la enumeración [WorkbookType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/workbooktype/) para detectar formatos no compatibles y omitir esos diagramas.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // El libro de trabajo incrustado está en formato .xlsb, que no es compatible.
            continue;
        }

        // Leer o modificar los datos del libro de trabajo del diagrama aquí.
    }
} finally {
    presentation.dispose();
}
```

## **Libro de trabajo externo**

Aspose.Slides admite libros de trabajo externos como fuente de datos para diagramas.

### **Crear libro de trabajo externo**

Usando los métodos **`readWorkbookStream`** y **`setExternalWorkbook`**, puede crear un libro de trabajo externo desde cero o convertir un libro interno en externo.

Este código JavaScript demuestra el proceso de creación del libro de trabajo externo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream devuelve los bytes del libro de trabajo como un Buffer de Node.
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Establecer libro de trabajo externo**

Usando el método **`setExternalWorkbook`**, puede asignar un libro de trabajo externo a un diagrama como su fuente de datos. Este método también puede emplearse para actualizar la ruta al libro de trabajo externo (si este último se ha movido).

Aunque no puede editar los datos en libros almacenados en ubicaciones remotas o recursos, puede seguir utilizándolos como fuente de datos externa. Si se proporciona la ruta relativa para un libro externo, se convierte automáticamente en una ruta completa.

Este código JavaScript le muestra cómo establecer un libro de trabajo externo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crea una instancia de la clase Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

El segundo parámetro del método `setExternalWorkbook`, `updateChartData`, indica si el libro de trabajo Excel se cargará o no.

* Cuando `updateChartData` se establece en `false`, solo se actualiza la ruta del libro; los datos del diagrama no se cargarán ni se actualizarán desde el libro de destino. Puede usar esta configuración cuando el libro de destino no exista o no esté disponible.
* Cuando `updateChartData` se establece en `true`, los datos del diagrama se actualizan desde el libro de destino.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crea una instancia de la clase Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Obtener la ruta del libro de datos externo del diagrama**

1. Cree una instancia de la [Presentation](https://apireference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation) clase.
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Cree un objeto para la forma del diagrama.
4. Cree un objeto para el tipo de origen (`ChartDataSourceType`) que representa el origen de datos del diagrama.
5. Especifique la condición pertinente en función de que el tipo de origen sea el mismo que el tipo de origen de libro de trabajo externo.

Este código JavaScript muestra la operación:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crea una instancia de la clase Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // Guarda la presentación
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Editar datos del diagrama**

Puede editar los datos en libros externos de la misma forma que modifica el contenido de los libros internos. Cuando no se puede cargar un libro externo, se lanza una excepción.

Este código JavaScript es una implementación del proceso descrito:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crea una instancia de la clase Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Recuperar un libro de trabajo desde la caché del diagrama**

Si un diagrama utiliza un libro externo que falta o no está disponible, Aspose.Slides puede reconstruir el libro del diagrama a partir de los datos almacenados en caché en la presentación. Cree un [LoadOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/), configúrelo con [SpreadsheetOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/spreadsheetoptions/), y llame a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) con `true` antes de abrir la presentación.

El siguiente ejemplo JavaScript abre una presentación cuyo diagrama hace referencia a un libro externo no disponible y accede a los datos recuperados mediante [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Leer o modificar los datos del libro de trabajo recuperado aquí.
} finally {
    presentation.dispose();
}
```

Si el libro externo no está disponible y la recuperación está desactivada, Aspose.Slides lanza una excepción. Active la recuperación solo cuando el uso de los datos del diagrama en caché sea una alternativa aceptable, porque la caché puede no contener los cambios realizados en el libro externo después de la última actualización de la presentación.

## **FAQ**

**¿Puedo determinar si un diagrama concreto está vinculado a un libro externo o incrustado?**

Sí. Un diagrama tiene un [data source type](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) y una [path to an external workbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); si el origen es un libro externo, puede leer la ruta completa para comprobar que se está utilizando un archivo externo.

**¿Se admiten rutas relativas a libros externos y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente en una ruta absoluta. Esto resulta práctico para la portabilidad del proyecto; sin embargo, tenga en cuenta que la presentación almacenará la ruta absoluta en el archivo PPTX.

**¿Puedo usar libros ubicados en recursos/redes compartidas?**

Sí, esos libros pueden usarse como fuente de datos externa. No obstante, la edición directa de libros remotos desde Aspose.Slides no está soportada; solo pueden utilizarse como origen.

**¿Sobrescribe Aspose.Slides el XLSX externo al guardar la presentación?**

No. La presentación almacena un [link to the external file](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) y lo usa para leer los datos. El archivo externo no se modifica al guardar la presentación.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al crear el vínculo. Un enfoque habitual es eliminar la protección previamente o preparar una copia desencriptada (por ejemplo, usando [Aspose.Cells](/cells/nodejs-java/)) y vincular a esa copia.

**¿Pueden varios diagramas referenciar el mismo libro externo?**

Sí. Cada diagrama almacena su propio vínculo. Si todos apuntan al mismo archivo, la actualización de ese archivo se reflejará en cada diagrama la próxima vez que se carguen los datos.