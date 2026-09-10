---
title: Administrar libros de trabajo de gráficos en presentaciones con Python mediante Java
linktitle: Libro de trabajo de gráfico
type: docs
weight: 70
url: /es/python-java/chart-workbook/
keywords:
- libro de trabajo de gráfico
- datos del gráfico
- celda del libro de trabajo
- etiqueta de datos
- hoja de cálculo
- fuente de datos
- libro de trabajo externo
- datos externos
- caché de gráfico
- recuperación de libro de trabajo
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Descubre Aspose.Slides para Python mediante Java: gestiona fácilmente los libros de trabajo de gráficos en PowerPowerPoint y formatos OpenDocument para optimizar los datos de tus presentaciones."
---
## **Descripción general**

Este artículo explica cómo trabajar con libros de trabajo de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráficos mediante flujos de libros de trabajo, usar celdas del libro de trabajo como etiquetas de datos del gráfico, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores del gráfico.

También cubre el trabajo con libros de trabajo externos como fuentes de datos del gráfico. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, recuperar la ruta de un libro de trabajo externo vinculado a un gráfico y editar los datos del gráfico cuando el libro de trabajo está disponible.

## **Leer y escribir datos de gráfico desde un libro de trabajo**
Aspose.Slides proporciona los métodos [readWorkbookStream](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdata/#readWorkbookStream) y [writeWorkbookStream](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdata/#writeWorkbookStream) que permiten leer y escribir libros de trabajo de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Nota** que los datos del gráfico deben estar organizados de la misma manera o tener una estructura similar a la fuente.

Este código Python muestra una operación de ejemplo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **Validar la distribución del gráfico después de la modificación del libro de trabajo**

Cuando sustituyes un libro de trabajo incrustado por uno modificado, el gráfico conserva sus colecciones originales de series y categorías. Esta incongruencia puede hacer que [Chart.validateChartLayout](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#validateChartLayout) lance una `ArgumentOutOfRangeException` (parámetro: index). Para evitar la excepción, elimina las series y categorías existentes **antes** de escribir el libro de trabajo actualizado de nuevo en el gráfico.

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

    # Leer el libro de trabajo después de modificarlo (p.ej., usando Aspose.Cells).
    updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Eliminar referencias de datos existentes.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

Eliminar las colecciones asegura que la estructura de datos del gráfico se alinee con el nuevo libro de trabajo, lo que permite que [validateChartLayout](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#validateChartLayout) se complete sin errores.

## **Establecer una celda de libro de trabajo como etiqueta de datos del gráfico**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtener la referencia de una diapositiva mediante su índice.
1. Añadir un gráfico de burbujas con algunos datos.
1. Acceder a la serie del gráfico.
1. Establecer la celda del libro de trabajo como etiqueta de datos.
1. Guardar la presentación.

Este código Python muestra cómo establecer una celda de libro de trabajo como etiqueta de datos del gráfico:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)
    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Administrar hojas de cálculo**

Este código Python muestra una operación en la que se utiliza el método [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdataworkbook/#getWorksheets) para acceder a una colección de hojas de cálculo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Especificar el tipo de origen de datos**

Este código Python muestra cómo especificar un tipo para un origen de datos:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Detectar formatos de libro de trabajo incrustado no compatibles**

Aspose.Slides no admite el formato de libro de trabajo binario de Excel (.xlsb) que puede estar incrustado en algunos gráficos. Puedes usar el método [getEmbeddedWorkbookType](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) en [ChartData](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdata/) junto con la enumeración [WorkbookType](https://reference.aspose.com/slides/es/python-java/aspose.slides/workbooktype/) para detectar formatos no compatibles y omitir esos gráficos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue
        chart_data = shape.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # El libro de trabajo incrustado está en formato .xlsb, que no está soportado.
            continue
        # Leer o modificar los datos del libro de trabajo del gráfico aquí.
finally:
    presentation.dispose()
```

### **Crear un libro de trabajo externo**

Usando los métodos [readWorkbookStream](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdata/#readWorkbookStream) y [setExternalWorkbook](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdata/#setExternalWorkbook), puedes crear un libro de trabajo externo desde cero o convertir un libro de trabajo interno en externo.

Este código Python muestra el proceso de creación del libro de trabajo externo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Establecer un libro de trabajo externo**

Usando el método [setExternalWorkbook](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdata/#setExternalWorkbook), puedes asignar un libro de trabajo externo a un gráfico como su origen de datos. Este método también puede usarse para actualizar la ruta al libro de trabajo externo (si este se ha movido).

Aunque no puedes editar los datos en libros de trabajo almacenados en ubicaciones remotas o recursos, aún puedes utilizarlos como origen de datos externo. Si se proporciona la ruta relativa para un libro de trabajo externo, se convierte automáticamente en una ruta completa.

Este código Python muestra cómo establecer un libro de trabajo externo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El segundo parámetro (`bool`) del método [setExternalWorkbook](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdata/#setExternalWorkbook) se usa para especificar si se cargará o no un libro de trabajo de Excel.

* Cuando su valor se establece en `False`, solo se actualiza la ruta del libro de trabajo; los datos del gráfico no se cargarán ni se actualizarán desde el libro de trabajo de destino. Puedes usar esta configuración cuando el libro de trabajo de destino no exista o no esté disponible. 
* Cuando su valor se establece en `True`, los datos del gráfico se actualizan desde el libro de trabajo de destino.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Obtener la ruta del libro de trabajo de origen de datos externo de un gráfico**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtener la referencia de una diapositiva mediante su índice.
1. Crear un objeto para la forma del gráfico.
1. Crear un objeto para el tipo de origen ([ChartDataSourceType](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatasourcetype/)) que representa el origen de datos del gráfico.
1. Especificar la condición pertinente en función de que el tipo de origen sea el mismo que el tipo de origen de datos del libro de trabajo externo.

Este código Python muestra la operación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Editar datos del gráfico**

Puedes editar los datos en libros de trabajo externos del mismo modo que modificas el contenido de libros de trabajo internos. Cuando no se puede cargar un libro de trabajo externo, se lanza una excepción.

Este código Python es una implementación del proceso descrito:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Recuperar un libro de trabajo desde la caché del gráfico**

Si un gráfico utiliza un libro de trabajo externo que falta o no está disponible, Aspose.Slides puede reconstruir el libro de trabajo del gráfico a partir de los datos almacenados en caché en la presentación. Crea [LoadOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/), configúralo con [SpreadsheetOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/spreadsheetoptions/), y llama a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/es/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) con `True` antes de abrir la presentación.

El siguiente ejemplo Python abre una presentación cuyo gráfico hace referencia a un libro de trabajo externo no disponible y accede a los datos recuperados mediante [Chart.getChartData](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#getChartData) y [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # Leer o modificar los datos del libro de trabajo recuperado aquí.
finally:
    presentation.dispose()
```

Si el libro de trabajo externo no está disponible y la recuperación está desactivada, Aspose.Slides lanza una excepción. Habilita la recuperación solo cuando usar los datos del gráfico en caché es una alternativa aceptable, porque la caché puede no contener los cambios realizados en el libro de trabajo externo después de la última actualización de la presentación.

## **Preguntas frecuentes**

**¿Puedo determinar si un gráfico concreto está vinculado a un libro de trabajo externo o incrustado?**

Sí. Un gráfico tiene un [data source type](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdata/#getDataSourceType) y una [ruta a un libro de trabajo externo](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); si la fuente es un libro de trabajo externo, puedes leer la ruta completa para asegurarte de que se está utilizando un archivo externo.

**¿Se admiten rutas relativas a libros de trabajo externos y cómo se almacenan?**

Sí. Si especificas una ruta relativa, se convierte automáticamente en una ruta absoluta. Esto es conveniente para la portabilidad del proyecto; sin embargo, ten en cuenta que la presentación almacenará la ruta absoluta en el archivo PPTX.

**¿Puedo usar libros de trabajo ubicados en recursos/redes compartidas?**

Sí, esos libros de trabajo pueden usarse como fuente de datos externa. No obstante, la edición directa de libros de trabajo remotos desde Aspose.Slides no está soportada; solo pueden utilizarse como fuente.

**¿Aspose.Slides sobrescribe el archivo XLSX externo al guardar la presentación?**

No. La presentación almacena un [enlace al archivo externo](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) y lo usa para leer los datos. El archivo externo no se modifica cuando se guarda la presentación.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al establecer el vínculo. Un enfoque habitual es eliminar la protección con antelación o preparar una copia descifrada (por ejemplo, usando [Aspose.Cells](/cells/python-java/)) y enlazar a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro de trabajo externo?**

Sí. Cada gráfico almacena su propio enlace. Si todos apuntan al mismo archivo, la actualización de ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.