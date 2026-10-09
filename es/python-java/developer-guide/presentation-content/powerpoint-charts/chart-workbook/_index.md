---
title: Gestionar libros de trabajo de gráficos en presentaciones usando Python vía Java
linktitle: Libro de trabajo de gráfico
type: docs
weight: 70
url: /es/python-java/chart-workbook/
keywords:
- libro de trabajo de gráfico
- datos de gráfico
- celda de libro de trabajo
- etiqueta de datos
- hoja de cálculo
- origen de datos
- libro de trabajo externo
- datos externos
- caché de gráfico
- recuperación de libro de trabajo
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Descubra Aspose.Slides para Python vía Java: gestione sin esfuerzo los libros de trabajo de gráficos en formatos PowerPoint y OpenDocument para optimizar los datos de su presentación."
---
## **Visión general**

Este artículo explica cómo trabajar con libros de datos de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráficos mediante flujos de libros de trabajo, usar celdas del libro de trabajo como etiquetas de datos del gráfico, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores del gráfico.

También trata el uso de libros de trabajo externos como orígenes de datos del gráfico. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, obtener la ruta de un libro de trabajo externo vinculado a un gráfico y editar los datos del gráfico cuando el libro de trabajo está disponible.

Para las celdas del libro de trabajo que representan datos faltantes, vea [Controlar la visualización de celdas vacías](/slides/es/python-java/chart-series/) para conocer la diferencia entre una celda vacía y cero, y una comparación de gráficos de líneas de los modos de visualización disponibles.

## **Incluir datos de filas y columnas ocultas**

Utilice [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) para controlar si un gráfico traza datos de filas y columnas ocultas de la hoja de cálculo. Establézcalo en `True` para trazar solo celdas visibles, o en `False` para incluir tanto celdas visibles como ocultas. Esta configuración controla el trazado del gráfico; no oculta ni muestra filas o columnas de la hoja de cálculo.

La [presentación de ejemplo](hidden-source-data.pptx) contiene un gráfico de columnas como la primera forma de su primera diapositiva. La hoja de cálculo incrustada, `Sheet1`, contiene el rango de origen `A1:C4`. La fila 3 y la columna C están ocultas, pero sus celdas siguen conteniendo valores.

| Fila de la hoja | A: Mes | B: Minorista | C: Mayorista (columna oculta) |
| --- | --- | --- | --- |
| 2 | Enero | 10 | 30 |
| 3 (fila oculta) | Febrero | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Acceda a las celdas de origen mediante [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) y lea [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) para inspeccionar su estado de ocultamiento. Este método informa el estado sin modificarlo. En este archivo, B2 es visible, B3 pertenece a la fila oculta y C2 pertenece a la columna oculta; el ejemplo imprime `False`, `True` y `True`, respectivamente.

Para este ejemplo, actualice los datos del gráfico después de cambiar la configuración de trazado: mantenga el libro de trabajo incrustado con [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) y recárguelo con [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). Al incluir todas las celdas, también utilice [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) para restaurar el rango completo, incluida la categoría oculta de febrero. Simplemente cambiar el indicador no es suficiente para refrescar los datos en caché de este ejemplo ni las etiquetas de categoría.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # Actualizar los datos del gráfico desde el libro de trabajo incrustado.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Restaurar el rango de origen completo, incluidas las categorías ocultas.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

El ejemplo guarda dos versiones de la presentación: una con solo los valores visibles de Minorista (10 y 20) y otra con los seis valores. Las imágenes a continuación ilustran los dos modos de trazado. La fila 3 y la columna C permanecen ocultas en ambos libros de trabajo incrustados.

| Solo celdas visibles (`True`) | Todas las celdas (`False`) |
| --- | --- |
| ![Solo celdas visibles: Valores de Minorista 10 y 20 para Enero y Marzo.](hidden_cells_True.png) | ![Todas las celdas: Valores de Minorista y Mayorista para Enero, Febrero y Marzo.](hidden_cells_False.png) |

Una celda oculta que contiene un valor es diferente de una celda vacía. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) controla cómo se muestran los valores faltantes; no incluye ni excluye datos de origen ocultos. Consulte [Controlar la visualización de celdas vacías](/slides/es/python-java/chart-series/#control-the-display-of-empty-cells) para un ejemplo.

## **Obtener el rango de datos de un gráfico**

Antes de actualizar los datos del libro de trabajo en una presentación existente, inspeccione los rangos de origen para identificar qué celdas de la hoja de cálculo usa cada gráfico. El método [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) devuelve el rango de datos actual como una fórmula calificada por hoja, como `Sheet1!$A$1:$D$5`. Aquí, `Sheet1` es el nombre de la hoja, `!` lo separa del rango de celdas y `$A$1:$D$5` identifica las celdas A1 a D5, inclusive. Los signos de dólar indican referencias absolutas de fila y columna.

El método lee el rango actual sin cambiar el gráfico ni su libro de trabajo. Si el gráfico no usa un libro de trabajo como origen de datos, lanza `InvalidOperationException`. Para más información, consulte la [Referencia de la API de ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Este ejemplo abre una presentación y verifica las formas directamente en cada diapositiva en busca de gráficos. Imprime el nombre de cada gráfico y su rango de origen. Si un gráfico no usa un libro de trabajo, muestra un mensaje y continúa con el siguiente gráfico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **Leer y escribir datos de gráficos desde un libro de trabajo**

Aspose.Slides for Python via Java proporciona los métodos [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) y [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) que le permiten leer y escribir libros de trabajo de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Nota** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar a la fuente.

Este ejemplo usa una presentación con un gráfico como la primera forma de su primera diapositiva. Lee el libro de trabajo incrustado en una matriz de bytes, elimina las series y categorías existentes, y escribe de nuevo el mismo libro de trabajo. Los cambios permanecen en memoria; el ejemplo no guarda la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Validar el diseño del gráfico después de la modificación del libro de trabajo**

Cuando reemplaza un libro de trabajo incrustado por uno modificado, el gráfico conserva sus colecciones originales de series y categorías. Esta discordancia puede provocar que [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) falle con un error de índice fuera de rango. Elimine las series y categorías existentes antes de escribir el libro de trabajo actualizado de nuevo en el gráfico. Este ejemplo usa un gráfico que es la primera forma de la primera diapositiva. El comentario marca donde ocurriría la edición del libro de trabajo; el ejemplo ejecutable escribe el libro original de nuevo y valida el diseño en memoria.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # Modificar los bytes del libro de trabajo aquí, por ejemplo, usando Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Eliminar las colecciones elimina referencias a datos obsoletos antes de que el libro de trabajo sea escrito de nuevo. Reconstruya cualquier asignación de series y categorías necesaria para el libro de trabajo actualizado antes de usar el gráfico.

## **Establecer una celda del libro de trabajo como etiqueta de datos del gráfico**

Puede usar texto de celdas del libro de trabajo como etiquetas de datos del gráfico.

Este ejemplo añade un gráfico de burbujas con datos predeterminados a la primera diapositiva de una presentación existente. Utiliza las celdas A10:A12 en la hoja 0 para las tres primeras etiquetas de la primera serie, habilita las etiquetas desde celdas y guarda la presentación actualizada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
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

El método [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) proporciona acceso a las hojas de cálculo en un libro de trabajo de gráfico. Este ejemplo crea un gráfico circular con datos predeterminados e imprime cada nombre de hoja en la consola.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Especificar el tipo de origen de datos**

Este ejemplo crea un gráfico de columnas 3D con datos predeterminados y establece dos nombres de series usando diferentes orígenes de datos. El primer nombre usa una cadena literal; el segundo usa la celda C1 en la hoja 0. La enumeración [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) selecciona el origen para cada nombre. El ejemplo guarda la presentación con los nombres de serie actualizados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Detectar formatos de libro de trabajo incrustado no compatibles**

Aspose.Slides no admite el formato de libro de trabajo binario de Excel (.xlsb) que puede estar incrustado en algunos gráficos. Puede usar el método [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) en [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) junto con la enumeración [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) para detectar formatos no compatibles y omitir esos gráficos. Este ejemplo inspecciona las formas en la primera diapositiva de una presentación existente, omite las formas que no son gráficos y muestra un mensaje diagnóstico para cada gráfico con un libro de trabajo .xlsb incrustado.

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

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # Leer o modificar datos compatibles del libro de trabajo del gráfico aquí.
finally:
    presentation.dispose()
```

## **Libro de trabajo externo**

Aspose.Slides admite el uso de libros de trabajo externos como origen de datos para los gráficos.

### **Crear un libro de trabajo externo**

Utilice [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) y [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) para exportar un libro de trabajo de gráfico incrustado a un archivo y vincular el gráfico a ese libro externo.

Este ejemplo crea un gráfico circular con datos predeterminados y exporta su libro de trabajo. Completa la escritura del archivo antes de asignar el libro externo como origen de datos del gráfico, luego guarda la presentación enlazada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


### **Establecer un libro de trabajo externo**

Usando el método [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook), puede asignar un libro de trabajo externo a un gráfico como su origen de datos. Este método también puede usarse para actualizar la ruta al libro externo (si este se ha movido).

Aunque no puede editar los datos en libros almacenados en ubicaciones remotas o recursos, aún puede usarlos como origen de datos externo. Si se proporciona una ruta relativa para un libro externo, se convierte automáticamente a una ruta completa.

Este ejemplo usa un libro de trabajo externo cuya hoja llamada `Sheet1` contiene un nombre de serie en B1, nombres de categoría en A2:A4 y valores numéricos en B2:B4. El ejemplo crea un gráfico circular, vincula el libro de trabajo y usa [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) para mapear A1:B4 a una serie y tres categorías. Guarda la presentación con el gráfico vinculado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El parámetro `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) controla si el libro de trabajo se carga.

* Cuando `updateChartData` es `False`, solo se actualiza la ruta del libro de trabajo. Los datos del gráfico no se cargan ni actualizan desde el libro de trabajo de destino, por lo que el libro puede estar indisponible.
* Cuando `updateChartData` es `True`, los datos del gráfico se actualizan desde el libro de trabajo de destino.

El siguiente ejemplo asigna una URL ficticia con `updateChartData` establecido en `False`. Conserva los datos predeterminados del gráfico circular y guarda la presentación sin cargar el libro de trabajo indisponible.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Obtener la ruta del libro de datos externo de un gráfico**

Para identificar el libro vinculado a un gráfico, compruebe si el gráfico usa un origen de datos externo y recupere su ruta.

Este ejemplo inspecciona la primera forma de la primera diapositiva de una presentación con un libro externo vinculado. Si es un gráfico vinculado a un libro externo, el ejemplo muestra [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) en la consola. Luego guarda una copia de la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Editar datos del gráfico**

Puede editar los datos en libros externos de la misma manera que modifica el contenido de los libros internos. Cuando un libro externo no puede cargarse, se lanza una excepción.

Este ejemplo usa un gráfico que es la primera forma de la primera diapositiva y está vinculado a un libro externo accesible. Establece el valor respaldado por celda del primer punto de datos de la primera serie en 100 y guarda la presentación actualizada. Editar valores de celda puede actualizar el archivo XLSX externo vinculado, por lo que debe usar una copia si necesita conservar el libro original.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Recuperar un libro de trabajo desde la caché del gráfico**

Si un gráfico usa un libro externo que falta o no está disponible, Aspose.Slides puede reconstruir el libro de trabajo del gráfico a partir de los datos almacenados en caché en la presentación. Cree [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), llame a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) y establezca [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) en `True` antes de abrir la presentación.

El siguiente ejemplo en Python recupera los datos del libro de trabajo para un gráfico que es la primera forma de la primera diapositiva y referencia un libro externo no disponible. Accede a los datos recuperados mediante [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) y [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # Leer o modificar los datos del libro recuperado aquí.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Si el libro externo no está disponible y la recuperación está desactivada, Aspose.Slides lanza una excepción. Active la recuperación solo cuando usar los datos en caché del gráfico sea una alternativa aceptable, ya que la caché puede no contener los cambios realizados en el libro externo después de la última actualización de la presentación.

## **Preguntas frecuentes**

**¿Puedo determinar si un gráfico concreto está vinculado a un libro externo o a uno incrustado?**

Sí. Un gráfico tiene un [tipo de origen de datos](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) y una [ruta a un libro externo](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); si el origen es un libro externo, puede leer la ruta completa para asegurarse de que se está usando un archivo externo.

**¿Se admiten rutas relativas a libros externos y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente en una ruta absoluta. La presentación almacena la ruta absoluta en el archivo PPTX, por lo que mover el libro puede requerir actualizar el vínculo.

**¿Puedo usar libros ubicados en recursos/redes compartidas?**

Sí, esos libros pueden usarse como origen de datos externo. Sin embargo, la edición directa de libros remotos desde Aspose.Slides no está soportada; solo pueden usarse como fuente.

**¿Aspose.Slides sobrescribe el XLSX externo al guardar la presentación?**

La presentación almacena un [vínculo al archivo externo](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Editar datos de gráficos respaldados por celdas también puede actualizar el archivo XLSX local vinculado. Use una copia del libro si el original debe permanecer sin cambios.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al vincular. Un enfoque común es eliminar la protección con antelación o preparar una copia descifrada (por ejemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) y vincular a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro externo?**

Sí. Cada gráfico almacena su propio vínculo. Si todos apuntan al mismo archivo, actualizar ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.