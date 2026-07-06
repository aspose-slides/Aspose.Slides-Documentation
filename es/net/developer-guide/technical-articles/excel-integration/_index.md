---
title: Integrar datos de Excel en presentaciones de PowerPoint
linktitle: Integración de Excel
type: docs
weight: 330
url: /es/net/excel-integration/
keywords:
- Excel
- libro de trabajo
- leer Excel
- integrar Excel
- fuente de datos
- combinar correspondencia
- importar tabla
- Excel a PowerPoint
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Leer datos de libros de Excel en Aspose.Slides usando la API ExcelDataWorkbook. Cargar hojas y celdas y usar los valores para generar presentaciones de PowerPoint basadas en datos."
---
## **Introducción**

Las presentaciones de PowerPoint son una forma potente de mostrar y comunicar información. A menudo se utilizan junto con libros de Excel, donde Excel sirve como una excelente fuente de datos estructurados y PowerPoint sobresale en visualizar esos datos para una audiencia.

Existen numerosos escenarios prácticos en los que combinar Excel y PowerPoint es esencial: combinaciones de correspondencia, rellenado de tablas de datos, generación de una diapositiva por registro de datos (generación masiva de diapositivas), creación de material de formación y consolidación de varios informes de Excel en una única presentación, por mencionar algunos.

Hasta ahora, implementar esas funciones con la API de Aspose.Slides requería depender de soluciones de terceros como Aspose.Cells. Aunque estas herramientas son robustas, pueden resultar demasiado complejas y costosas para los usuarios que solo necesitan funcionalidades básicas de integración de datos.

## **Cómo funciona**

Para facilitar y agilizar el trabajo con datos de Excel, Aspose.Slides ha introducido nuevas clases para leer datos de libros de Excel e importar contenido a una presentación. Esta función abre poderosas nuevas posibilidades para los usuarios de la API que desean utilizar Excel como fuente de datos dentro de sus flujos de trabajo de presentaciones.

La nueva funcionalidad está diseñada para acceso a datos de propósito general y no está integrada en el Modelo de Objeto de Documento (DOM) de la presentación. Eso significa que *no permite editar ni guardar archivos de Excel* — su único propósito es abrir libros y navegar por su contenido para obtener datos de celdas.

En el núcleo de esta función se encuentra la nueva clase [ExcelDataWorkbook](https://reference.aspose.com/slides/es/net/aspose.slides.excel/exceldataworkbook/). Esta clase le permite cargar un libro de Excel desde un archivo local o un flujo. Una vez cargado, proporciona varias sobrecargas del método [GetCell](https://reference.aspose.com/slides/es/net/aspose.slides.excel/exceldataworkbook/getcell/), que puede usar para obtener celdas específicas por su posición (p.ej. índices de fila y columna o rangos con nombre).

Cada llamada a [GetCell](https://reference.aspose.com/slides/es/net/aspose.slides.excel/exceldataworkbook/getcell/) devuelve una instancia de la clase [ExcelDataCell](https://reference.aspose.com/slides/es/net/aspose.slides.excel/exceldatacell/). Este objeto representa una única celda del libro de Excel y le brinda acceso a su valor de manera simple e intuitiva.

#### **Importar un gráfico de Excel**

El siguiente paso para ampliar la funcionalidad es la clase [ExcelWorkbookImporter](https://reference.aspose.com/slides/es/net/aspose.slides.import/excelworkbookimporter/). Esta clase de utilidad proporciona la funcionalidad para importar contenido de un libro de Excel a una presentación. Contiene varias sobrecargas del método [AddChartFromWorkbook](https://reference.aspose.com/slides/es/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), que le ayuda a obtener el gráfico seleccionado del libro de Excel especificado y añadirlo al final de la colección de formas indicada en las coordenadas especificadas.

#### **Importar una tabla de Excel**

La clase [ExcelWorkbookImporter](https://reference.aspose.com/slides/es/net/aspose.slides.import/excelworkbookimporter/) también contiene varias sobrecargas del método [AddTableFromWorkbook](https://reference.aspose.com/slides/es/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/). Estos métodos le permiten importar un rango de celdas especificado de una hoja de cálculo determinada y añadirlo como tabla al final de la colección de formas indicada en las coordenadas especificadas.

En resumen, es una API ligera y directa para leer datos de Excel — exactamente lo que muchos desarrolladores necesitan sin la sobrecarga de una biblioteca completa de procesamiento de hojas de cálculo.

## **Vamos a programar**

### **Ejemplo de escenario de combinación de correspondencia**

En el siguiente ejemplo, implementaremos un escenario sencillo de combinación de correspondencia generando múltiples presentaciones basadas en datos almacenados en un libro de Excel.

Para comenzar, necesitamos dos cosas:
1. Un libro de Excel que contenga los datos

![Ejemplo de datos de Excel](example1_image0.png)

2. Plantilla de presentación de PowerPoint

![Ejemplo de plantilla de PowerPoint](example1_image1.png)

```csharp
// Cargar el libro de Excel con datos de empleados.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Cargar la plantilla de presentación.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Recorrer las filas de Excel (excluyendo la cabecera en la fila 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Crear una nueva presentación para cada registro de empleado.
    using Presentation employeePresentation = new Presentation();

    // Eliminar la diapositiva en blanco predeterminada.
    employeePresentation.Slides.RemoveAt(0);

    // Clonar la diapositiva de plantilla en la nueva presentación.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Obtener párrafos de la forma objetivo (se asume que se usa el índice de forma 1).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Reemplazar los marcadores de posición con datos de Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Guardar la presentación personalizada en un archivo separado.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Resultado](example1_image2.png)

### **Ejemplo de tabla de Excel**

En el segundo ejemplo, simplemente copiamos datos de una tabla de Excel y los mostramos en una diapositiva de PowerPoint con un formato más atractivo visualmente.

En este ejemplo, reutilizamos el mismo libro de Excel del primer ejemplo, que contiene una tabla sencilla de empleados.

```csharp
// Cargar el libro de Excel que contiene los datos de los empleados.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Crear una nueva presentación de PowerPoint.
using Presentation presentation = new Presentation();

// Añadir una forma de tabla a la primera diapositiva.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Rellenar la tabla de PowerPoint con datos del libro de Excel.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Guardar la presentación resultante en un archivo.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Resultado](example2_image0.png)

### **Ejemplo de importación de un gráfico de Excel**

En este ejemplo, importamos un gráfico de la primera hoja del libro de Excel usado en el ejemplo anterior. El gráfico se enlazará al libro externo en la presentación resultante.

Primero, añadimos un gráfico circular al libro de Excel basado en la tabla de empleados.

![Ejemplo de gráfico de Excel](example3_image0.png)

```csharp
// Crear una nueva presentación de PowerPoint.
using Presentation presentation = new Presentation();

// Obtener la colección de formas de la primera diapositiva.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importar el gráfico llamado "Chart 1" desde la primera hoja del libro y añadirlo a la colección de formas.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Guardar la presentación resultante en un archivo.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Resultado](example3_image1.png)

### **Ejemplo de importación de todos los gráficos de Excel**

Imaginemos que tiene un libro de Excel lleno de gráficos y necesita importarlos todos a una presentación. Cada gráfico debe colocarse en una nueva diapositiva.

El siguiente código recorre todas las hojas del archivo de Excel de origen, extrae los gráficos de cada hoja y añade cada gráfico a una diapositiva independiente usando un diseño de diapositiva en blanco. En la presentación resultante, solo se incrustarán los datos del gráfico, no el libro completo.

```csharp
// Cargar el libro de Excel que contiene los datos de los empleados.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Crear una nueva presentación de PowerPoint.
using Presentation presentation = new Presentation();

// Obtener el diseño de diapositiva en blanco.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Obtener los nombres de todas las hojas de cálculo contenidas en el libro de Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Obtener un diccionario que asigna índices de gráfico a nombres de gráfico para la hoja.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Añadir una nueva diapositiva usando el diseño en blanco.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importar el gráfico especificado del libro de Excel a la colección de formas de la diapositiva.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Guardar la presentación resultante en un archivo.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Ejemplo de importación de una tabla de Excel**

En este ejemplo, importamos una tabla con formato de una hoja de Excel directamente a una presentación de PowerPoint.

La hoja de Excel de origen contiene una tabla con formato con datos de empleados:

![Ejemplo de tabla de Excel](example4_image0.png)

```csharp
// Crear una nueva presentación de PowerPoint.
using Presentation presentation = new Presentation();

// Obtener la colección de formas de la primera diapositiva.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importar la tabla de la primera hoja del libro y añadirla a la colección de formas.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Guardar la presentación resultante en un archivo.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```
![Resultado](example4_image1.png)

## **Resumen**

Este mecanismo, disponible directamente en Aspose.Slides, combina el trabajo con datos de Excel y presentaciones en un solo lugar. Le permite crear diapositivas con gráficos visuales y datos presentados como tablas de Excel, sin bibliotecas adicionales ni integraciones complejas.