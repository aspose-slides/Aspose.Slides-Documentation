---
title: Integrar datos de Excel en presentaciones de PowerPoint
linktitle: Integración de Excel
type: docs
weight: 330
url: /es/python-java/excel-integration/
keywords:
- Excel
- libro de trabajo
- leer Excel
- integrar Excel
- fuente de datos
- combinar correspondencia
- importar tabla
- Excel en PowerPoint
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Leer datos de libros de trabajo de Excel en Aspose.Slides para Python a través de Java mediante la API ExcelDataWorkbook. Cargar hojas y celdas y usar los valores para generar presentaciones de PowerPoint basadas en datos."
---
## **Introducción**

Las presentaciones de PowerPoint son una forma poderosa de mostrar y comunicar información. A menudo se utilizan junto con libros de Excel, donde Excel sirve como una excelente fuente de datos estructurados y PowerPoint sobresale al visualizar esos datos para una audiencia.

Hay muchos escenarios prácticos donde combinar Excel y PowerPoint es esencial: combinaciones de correspondencia, poblar tablas de datos, generar una diapositiva por registro de datos (generación por lotes de diapositivas), crear material de capacitación y consolidar varios informes de Excel en una sola presentación, por nombrar algunos.

Hasta ahora, implementar tales funciones con la API Aspose.Slides requería depender de soluciones de terceros como Aspose.Cells. Aunque estas herramientas son robustas, pueden resultar demasiado complejas y costosas para los usuarios que solo necesitan funcionalidad básica de integración de datos.

## **Cómo funciona**

Para facilitar y agilizar el trabajo con datos de Excel, Aspose.Slides ha introducido nuevas clases para leer datos de libros de Excel e importar contenido a una presentación. Esta característica abre poderosas posibilidades nuevas para los usuarios de la API que desean aprovechar Excel como fuente de datos dentro de sus flujos de trabajo de presentación.

La nueva funcionalidad está diseñada para el acceso a datos de propósito general y no está integrada en el Modelo de Objetos del Documento de Presentación (DOM). Eso significa *que no permite editar ni guardar archivos de Excel* — su único propósito es abrir libros de trabajo y navegar por su contenido para obtener datos de celdas.

En el corazón de esta característica se encuentra la nueva [ExcelDataWorkbook](https://reference.aspose.com/slides/es/python-java/aspose.slides/exceldataworkbook/) clase. Esta clase le permite cargar un libro de Excel desde un archivo local o un flujo. Una vez cargado, ofrece varias sobrecargas del método [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/es/python-java/aspose.slides/exceldataworkbook/#getCell), que puede usar para obtener celdas específicas por su posición (por ejemplo, índices de fila y columna o rangos nombrados).

Cada llamada a [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/es/python-java/aspose.slides/exceldataworkbook/#getCell) devuelve un objeto [ExcelDataCell](https://reference.aspose.com/slides/es/python-java/aspose.slides/exceldatacell/). Este objeto representa una única celda en el libro de Excel y le brinda acceso a su valor de forma sencilla e intuitiva.

#### **Importar un gráfico de Excel**

El siguiente paso para ampliar la funcionalidad es la clase [ExcelWorkbookImporter](https://reference.aspose.com/slides/es/python-java/aspose.slides/excelworkbookimporter/) . Esta clase de utilidad proporciona funcionalidad para importar contenido de un libro de Excel a una presentación. Contiene varias sobrecargas del método [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/es/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), que le ayuda a obtener el gráfico seleccionado del libro de Excel especificado y añadirlo al final de la colección de formas dada en las coordenadas especificadas.

#### **Importar una tabla de Excel**

La clase [ExcelWorkbookImporter](https://reference.aspose.com/slides/es/python-java/aspose.slides/excelworkbookimporter/) también contiene varias sobrecargas del método [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/es/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook). Estos métodos le permiten importar un rango de celdas especificado de una hoja de cálculo especificada y añadirlo como tabla al final de la colección de formas dada en las coordenadas especificadas.

En resumen, es una API ligera y directa para leer datos de Excel — exactamente lo que muchos desarrolladores necesitan sin la sobrecarga de una biblioteca completa de procesamiento de hojas de cálculo.

## **Vamos a codificar**

### **Ejemplo de escenario de combinación de correspondencia**

En el siguiente ejemplo, implementaremos un sencillo escenario de combinación de correspondencia generando múltiples presentaciones basadas en los datos almacenados en un libro de Excel.

Para comenzar, necesitamos dos cosas:

1. Un libro de Excel que contenga los datos

![Ejemplo de datos de Excel](example1_image0.png)

2. Una plantilla de presentación de PowerPoint

![Ejemplo de plantilla PowerPoint](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Cargar el libro de Excel con datos de empleados.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Cargar la plantilla de presentación.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # Recorrer las filas de Excel (excluyendo el encabezado en la fila 0).
    for row_index in range(1, 5):

        # Crear una presentación para cada registro de empleado.
        employee_presentation = Presentation()

        try:
            # Eliminar la diapositiva en blanco predeterminada.
            employee_presentation.getSlides().removeAt(0)

            # Clonar la diapositiva de la plantilla en la presentación.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # Obtener los párrafos de la forma objetivo (se asume que se usa el índice de forma 1).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # Reemplazar los marcadores de posición con datos de Excel.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # Guardar la presentación personalizada en un archivo separado.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Resultado](example1_image2.png)

### **Ejemplo de tabla de Excel**

En el segundo ejemplo, simplemente copiamos datos de una tabla de Excel y los mostramos en una diapositiva de PowerPoint en un formato más atractivo visualmente.

En este ejemplo, reutilizamos el mismo libro de Excel del primer ejemplo, que contiene una tabla simple de empleados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Cargar el libro de Excel que contiene los datos de los empleados.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Crear una presentación de PowerPoint.
presentation = Presentation()

try:
    # Añadir una forma de tabla a la primera diapositiva.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # Rellenar la tabla de PowerPoint con datos del libro de Excel.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # Guardar la presentación resultante en un archivo.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Resultado](example2_image0.png)

### **Ejemplo de importación de un gráfico de Excel**

En este ejemplo, importamos un gráfico de la primera hoja del libro de Excel usado en el ejemplo anterior. El gráfico se vinculará al libro externo en la presentación resultante.

Primero, añadimos un gráfico circular al libro de Excel basado en la tabla de empleados.

![Ejemplo de gráfico de Excel](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Crear una presentación de PowerPoint.
presentation = Presentation()
try:
    # Obtener la colección de formas de la primera diapositiva.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # Importar el gráfico llamado "Chart 1" de la primera hoja del libro y añadirlo a la colección de formas.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Guardar la presentación resultante en un archivo.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Resultado](example3_image1.png)

### **Ejemplo de importación de todos los gráficos de Excel**

Imaginemos que tiene un libro de Excel lleno de gráficos y necesita importarlos todos a una presentación. Cada gráfico debe colocarse en una nueva diapositiva.

El siguiente código recorre todas las hojas del archivo Excel de origen, extrae los gráficos de cada hoja y añade cada gráfico a una diapositiva separada usando un diseño de diapositiva en blanco. En la presentación resultante, solo se incrustarán los datos del gráfico, no todo el libro.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# Cargar el libro de Excel que contiene los datos de los empleados.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Crear una presentación de PowerPoint.
presentation = Presentation()
try:
    # Obtener el diseño de diapositiva en blanco.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # Eliminar la diapositiva predeterminada para que el resultado contenga una diapositiva por gráfico.
    presentation.getSlides().removeAt(0)

    # Obtener los nombres de todas las hojas de cálculo contenidas en el libro de Excel.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # Obtener un mapa que relaciona los índices de los gráficos con sus nombres para la hoja de cálculo.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # Añadir una diapositiva usando el diseño en blanco.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # Importar el gráfico especificado del libro de Excel a la colección de formas de la diapositiva.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # Guardar la presentación resultante en un archivo.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ejemplo de importación de una tabla de Excel**

En este ejemplo, importamos una tabla formateada de una hoja de Excel directamente a una presentación de PowerPoint.

La hoja de cálculo de origen contiene una tabla formateada con datos de empleados:

![Ejemplo de tabla de Excel](example4_image0.png)

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Crear una presentación de PowerPoint.
presentation = Presentation()
try:
    # Obtener la primera diapositiva y su colección de formas.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # Importar la tabla de la primera hoja del libro y añadirla a la colección de formas.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # Guardar la presentación resultante en un archivo.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Resultado](example4_image1.png)

## **Resumen**

Este mecanismo, disponible directamente en Aspose.Slides, combina el trabajo con datos de Excel y presentaciones en un solo lugar. Permite crear diapositivas con gráficos visuales y datos presentados como tablas de Excel — sin bibliotecas adicionales ni integraciones complejas.