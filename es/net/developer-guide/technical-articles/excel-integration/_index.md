---
title: Integrar datos de Excel en presentaciones de PowerPoint
linktitle: Integración de Excel
type: docs
weight: 330
url: /es/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
keywords:
- Excel
- libro de trabajo
- leer Excel
- integrar Excel
- origen de datos
- combinación de correspondencia
- importar tabla
- Excel en PowerPoint
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Leer datos de libros de trabajo de Excel en Aspose.Slides usando la API ExcelDataWorkbook. Cargar hojas y celdas y usar los valores para generar presentaciones de PowerPoint basadas en datos."
---
## **Introducción**

Las presentaciones de PowerPoint son una forma potente de mostrar y comunicar información. A menudo se utilizan junto con libros de trabajo de Excel, donde Excel sirve como una excelente fuente de datos estructurados y PowerPoint sobresale al visualizar esos datos para una audiencia.

Existen muchos escenarios prácticos en los que combinar Excel y PowerPoint es esencial: combinaciones de correspondencia, rellenar tablas de datos, generar una diapositiva por registro de datos (generación por lotes de diapositivas), crear material de formación y consolidar varios informes de Excel en una única presentación, entre otros.

Hasta ahora, implementar esas funcionalidades con la API de Aspose.Slides requería depender de soluciones de terceros como Aspose.Cells. Aunque esas herramientas son robustas, pueden resultar excesivamente complejas y costosas para los usuarios que solo necesitan una funcionalidad básica de integración de datos.

## **Cómo funciona**

Para facilitar el trabajo con datos de Excel y hacerlo más fluido, Aspose.Slides ha introducido nuevas clases para leer datos de libros de trabajo de Excel e importar contenido a una presentación. Esta característica abre poderosas posibilidades para los usuarios de la API que desean aprovechar Excel como fuente de datos dentro de sus flujos de trabajo de presentaciones.

La nueva funcionalidad está diseñada para el acceso a datos de propósito general y no está integrada en el modelo de objetos del documento de presentación (DOM). Eso significa *que no permite editar ni guardar archivos de Excel* — su único propósito es abrir libros de trabajo y navegar por su contenido para obtener datos de celdas.

En el corazón de esta característica está la nueva clase [ExcelDataWorkbook](https://reference.aspose.com/slides/es/net/aspose.slides.excel/exceldataworkbook/). Esta clase permite cargar un libro de trabajo de Excel desde un archivo local o un flujo. Una vez cargado, ofrece varias sobrecargas del método [GetCell](https://reference.aspose.com/slides/es/net/aspose.slides.excel/exceldataworkbook/getcell/), que pueden usarse para obtener celdas específicas por su posición (p. ej., índices de fila y columna o rangos con nombre).

Cada llamada a [GetCell](https://reference.aspose.com/slides/es/net/aspose.slides.excel/exceldataworkbook/getcell/) devuelve una instancia de la clase [ExcelDataCell](https://reference.aspose.com/slides/es/net/aspose.slides.excel/exceldatacell/). Este objeto representa una única celda en el libro de trabajo de Excel y brinda acceso a su valor de manera simple e intuitiva.

#### **Importar un gráfico de Excel**

El siguiente paso para ampliar la funcionalidad es la clase [ExcelWorkbookImporter](https://reference.aspose.com/slides/es/net/aspose.slides.import/excelworkbookimporter/). Esta clase utilitaria proporciona funcionalidades para importar contenido de un libro de trabajo de Excel a una presentación. Contiene varias sobrecargas del método [AddChartFromWorkbook](https://reference.aspose.com/slides/es/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), que ayuda a obtener el gráfico seleccionado del libro de Excel especificado y añadirlo al final de la colección de formas indicada en las coordenadas especificadas.

#### **Importar una tabla de Excel**

La clase [ExcelWorkbookImporter](https://reference.aspose.com/slides/es/net/aspose.slides.import/excelworkbookimporter/) también contiene varias sobrecargas del método [AddTableFromWorkbook](https://reference.aspose.com/slides/es/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/). Estos métodos permiten importar un rango de celdas especificado de una hoja de cálculo concreta y añadirlo como tabla al final de la colección de formas indicada en las coordenadas especificadas.

En resumen, es una API ligera y directa para leer datos de Excel — exactamente lo que muchos desarrolladores necesitan sin la sobrecarga de una biblioteca completa de procesamiento de hojas de cálculo.

## **Vamos a programar**

### **Ejemplo de escenario de combinación de correspondencia**

En el siguiente ejemplo, implementaremos un escenario sencillo de combinación de correspondencia generando múltiples presentaciones basadas en los datos almacenados en un libro de trabajo de Excel.

Para comenzar, necesitamos dos cosas:
1. Un libro de trabajo de Excel que contenga los datos

![Ejemplo de datos de Excel](example1_image0.png)

2.  Plantilla de presentación de PowerPoint

![Ejemplo de plantilla de PowerPoint](example1_image1.png)

```csharp
// Carga el libro de trabajo de Excel con los datos de los empleados.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Carga la plantilla de presentación.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Recorre las filas de Excel (excluyendo el encabezado en la fila 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Crea una nueva presentación para cada registro de empleado.
    using Presentation employeePresentation = new Presentation();

    // Elimina la diapositiva en blanco predeterminada.
    employeePresentation.Slides.RemoveAt(0);

    // Clona la diapositiva de la plantilla en la nueva presentación.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Obtiene los párrafos de la forma objetivo (se asume que el índice de forma 1 se utiliza).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Reemplaza los marcadores de posición con los datos de Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Guarda la presentación personalizada en un archivo distinto.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Resultado](example1_image2.png)

### **Ejemplo de tabla de Excel**

En el segundo ejemplo, simplemente copiamos datos de una tabla de Excel y los mostramos en una diapositiva de PowerPoint con un formato más atractivo visualmente.

En este caso, reutilizamos el mismo libro de trabajo de Excel del primer ejemplo, que contiene una tabla sencilla de empleados.

```csharp
// Carga el libro de trabajo de Excel que contiene los datos de los empleados.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Crea una nueva presentación de PowerPoint.
using Presentation presentation = new Presentation();

// Añade una forma de tabla a la primera diapositiva.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Rellena la tabla de PowerPoint con los datos del libro de trabajo de Excel.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Guarda la presentación resultante en un archivo.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Resultado](example2_image0.png)

### **Ejemplo de importación de un gráfico de Excel**

En este ejemplo, importamos un gráfico de la primera hoja del libro de Excel usado en el ejemplo anterior. El gráfico se vinculará al libro externo en la presentación resultante.

Primero, añadimos un gráfico circular al libro de Excel a partir de la tabla de empleados.

![Ejemplo de gráfico de Excel](example3_image0.png)

```csharp
// Crea una nueva presentación de PowerPoint.
using Presentation presentation = new Presentation();

// Obtén la colección de formas de la primera diapositiva.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importa el gráfico llamado "Chart 1" de la primera hoja del libro de trabajo y añádelo a la colección de formas.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Guarda la presentación resultante en un archivo.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Resultado](example3_image1.png)

### **Ejemplo de importación de todos los gráficos de Excel**

Imagínese que tiene un libro de Excel lleno de gráficos y necesita importarlos todos a una presentación. Cada gráfico debe colocarse en una diapositiva nueva.

El siguiente código recorre todas las hojas del archivo de Excel de origen, extrae los gráficos de cada hoja y añade cada gráfico a una diapositiva separada usando un diseño de diapositiva en blanco. En la presentación resultante, solo se incrustarán los datos del gráfico, no todo el libro.

```csharp
// Carga el libro de trabajo de Excel que contiene los datos de los empleados.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Crea una nueva presentación de PowerPoint.
using Presentation presentation = new Presentation();

// Recupera la distribución de diapositiva en blanco.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Obtén los nombres de todas las hojas de cálculo contenidas en el libro de trabajo de Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Recupera un diccionario que asigna índices de gráficos a nombres de gráficos para la hoja de cálculo.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Añade una nueva diapositiva usando la distribución en blanco.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importa el gráfico especificado del libro de trabajo de Excel en la colección de formas de la diapositiva.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Guarda la presentación resultante en un archivo.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Ejemplo de importación de una tabla de Excel**

En este ejemplo, importamos una tabla con formato desde una hoja de cálculo de Excel directamente a una presentación de PowerPoint.

La hoja de cálculo de Excel de origen contiene una tabla con formato de datos de empleados:

![Ejemplo de tabla de Excel](example4_image0.png)

```csharp
// Crea una nueva presentación de PowerPoint.
using Presentation presentation = new Presentation();

// Obtén la colección de formas de la primera diapositiva.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importa la tabla de la primera hoja del libro de trabajo y añádela a la colección de formas.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Guarda la presentación resultante en un archivo.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![Resultado](example4_image1.png)


## **Resumen**

Este mecanismo, disponible directamente en Aspose.Slides, combina el trabajo con datos de Excel y presentaciones en un solo lugar. Permite crear diapositivas con gráficos visuales y datos presentados como tablas de Excel — sin bibliotecas adicionales ni integraciones complejas.