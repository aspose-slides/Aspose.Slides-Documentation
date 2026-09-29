---
title: Gestionar libretas de gráficos en presentaciones con Python
linktitle: Libro de gráficos
type: docs
weight: 70
url: /es/python-net/chart-workbook/
keywords:
- libreta de gráficos
- datos del gráfico
- celda de libreta
- etiqueta de datos
- hoja de cálculo
- origen de datos
- libreta externa
- datos externos
- caché del gráfico
- recuperación de libreta
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Descubra Aspose.Slides para Python vía .NET: gestione fácilmente libretas de gráficos en formatos PowerPoint y OpenDocument para optimizar los datos de su presentación."
---
## **Descripción general**

Este artículo explica cómo trabajar con libretas de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráficos a través de flujos de libretas, usar celdas de la libreta como etiquetas de datos del gráfico, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores del gráfico.

También cubre el trabajo con libretas externas como orígenes de datos de gráficos. Los ejemplos demuestran cómo crear y asignar una libreta externa, obtener la ruta de una libreta externa vinculada a un gráfico y editar los datos del gráfico cuando la libreta está disponible.

Para las celdas de la libreta que representan datos faltantes, vea [Controlar la visualización de celdas vacías](/slides/es/python-net/chart-series/) para conocer la diferencia entre una celda vacía y cero, y una comparación de gráfico de líneas de los modos de visualización disponibles.

## **Incluir datos de filas y columnas ocultas**

Use [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) para controlar si un gráfico trazará datos de filas y columnas ocultas de la hoja de cálculo. Establézcalo en `True` para trazar solo celdas visibles, o en `False` para incluir tanto celdas visibles como ocultas. Esta configuración controla el trazado del gráfico; no oculta ni muestra filas o columnas de la hoja de cálculo.

Descargue [hidden-source-data.pptx](hidden-source-data.pptx) y colóquelo en el directorio de trabajo. Su primera diapositiva contiene un gráfico de columnas como la primera forma. La hoja de cálculo incrustada, `Sheet1`, contiene el rango de origen `A1:C4`. La fila 3 y la columna C están ocultas, pero sus celdas siguen conteniendo valores.

| Fila de la hoja | A: Mes | B: Venta al por menor | C: Venta al por mayor (columna oculta) |
| --- | --- | --- | --- |
| 2 | Enero | 10 | 30 |
| 3 (fila oculta) | Febrero | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Acceda a las celdas de origen a través de [ChartData.chart_data_workbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) y lea [ChartDataCell.is_hidden](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatacell/is_hidden/) para inspeccionar su estado de ocultación. Esta propiedad es de solo lectura. En este archivo, B2 es visible, B3 pertenece a la fila oculta y C2 pertenece a la columna oculta; el ejemplo imprime `False`, `True` y `True`, respectivamente.

Para este ejemplo, actualice los datos del gráfico después de cambiar la configuración de trazado: conserve la libreta incrustada con [read_workbook_stream](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) y recárguela con [write_workbook_stream](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Al incluir todas las celdas, también use [set_range](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/set_range/) para restaurar el rango completo, incluida la categoría de febrero oculta. Simplemente cambiar la bandera no es suficiente para actualizar los datos en caché del gráfico y las etiquetas de categoría de esta muestra.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # Actualizar los datos del gráfico desde la libreta incrustada.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Restaurar el rango de origen completo, incluidas las categorías ocultas.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

El ejemplo guarda `hidden_cells_True.pptx` con solo los valores de venta al por menor visibles (10 y 20), y `hidden_cells_False.pptx` con los seis valores. Las imágenes a continuación se generaron a partir de las presentaciones guardadas tras volver a abrirlas; ambos archivos conservan su configuración de trazado asignada. La fila 3 y la columna C permanecen ocultas en ambas libretas incrustadas.

| Solo celdas visibles (`True`) | Todas las celdas (`False`) |
| --- | --- |
| ![Solo celdas visibles: valores de venta al por menor 10 y 20 para Enero y Marzo.](hidden_cells_True.png) | ![Todas las celdas: valores de venta al por menor y mayor para Enero, Febrero y Marzo.](hidden_cells_False.png) |

Una celda oculta que contiene un valor es diferente de una celda vacía. [Chart.display_blanks_as](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/display_blanks_as/) controla cómo se muestran los valores faltantes; no incluye ni excluye datos de origen ocultos. Consulte [Controlar la visualización de celdas vacías](/slides/es/python-net/chart-series/#control-the-display-of-empty-cells) para un ejemplo.

## **Leer y escribir datos de gráfico desde una libreta**

Aspose.Slides for Python vía .NET proporciona los métodos [read_workbook_stream](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) y [write_workbook_stream](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) que le permiten leer y escribir libretas de datos de gráficos (conteniendo datos de gráficos editados con Aspose.Cells). **Nota** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar al origen.

Este ejemplo abre `chart.pptx`, que debe contener un gráfico como la primera forma en su primera diapositiva. Lee la libreta incrustada en un flujo, elimina las series y categorías existentes y escribe la misma libreta de nuevo. Los cambios permanecen en memoria; el ejemplo no guarda la presentación.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **Validar el diseño del gráfico después de la modificación de la libreta**

Cuando sustituye una libreta incrustada por una modificada, el gráfico conserva sus colecciones originales de series y categorías. Esta discrepancia puede provocar que [Chart.validate_chart_layout](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/validate_chart_layout/) falle con un error de índice fuera de rango. Elimine las series y categorías existentes antes de escribir la libreta actualizada de nuevo en el gráfico. Este ejemplo requiere `chart.pptx` con un gráfico como la primera forma en su primera diapositiva. El comentario marca dónde se produciría la edición de la libreta; el ejemplo ejecutable escribe la libreta original de nuevo y valida el diseño en memoria.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Modifique el flujo de la libreta aquí, por ejemplo, usando Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Eliminar las colecciones elimina referencias a datos obsoletos antes de que la libreta se escriba de nuevo. Reconstruya cualquier asignación de series y categorías necesaria para la libreta actualizada antes de usar el gráfico.

## **Establecer una celda de libreta como etiqueta de datos del gráfico**

Puede usar texto de celdas de la libreta como etiquetas de datos del gráfico. Los pasos siguientes muestran cómo vincular las etiquetas en un gráfico de burbujas a celdas de su libreta de datos.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Acceder a la primera diapositiva por su índice base cero.
1. Añadir un gráfico de burbujas con datos predeterminados.
1. Acceder a la serie del gráfico.
1. Establecer la celda de la libreta como etiqueta de datos.
1. Guardar la presentación.

Este ejemplo abre `chart2.pptx`, que debe contener al menos una diapositiva, y añade un gráfico de burbujas con datos predeterminados. Usa las celdas A10:A12 en la hoja 0 para las tres primeras etiquetas de la primera serie, habilita las etiquetas desde celdas y guarda el resultado en `resultchart.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Administrar hojas de cálculo**

La propiedad [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) proporciona acceso a las hojas de cálculo en una libreta de gráfico. Este ejemplo crea un gráfico circular con datos predeterminados e imprime cada nombre de hoja en la consola.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **Especificar el tipo de origen de datos**

Este ejemplo crea un gráfico de columnas 3D con datos predeterminados y establece dos nombres de series usando diferentes orígenes de datos. El primer nombre usa un literal de cadena; el segundo usa la celda C1 en la hoja 0. La enumeración [DataSourceType](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datasourcetype/) selecciona el origen para cada nombre. El resultado se guarda en `pres.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Detectar formatos de libreta incrustada no compatibles**

Aspose.Slides no admite el formato de libreta binaria de Excel (.xlsb) que puede incrustarse en algunos gráficos. Puede usar la propiedad [embedded_workbook_type](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) en [ChartData](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/) junto con la enumeración [WorkbookType](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/workbooktype/) para detectar formatos no compatibles y omitir esos gráficos. Este ejemplo inspecciona las formas en la primera diapositiva de `sample.pptx`, omite las formas que no son gráficos y muestra un mensaje diagnóstico para cada gráfico con una libreta .xlsb incrustada.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # Leer o modificar los datos de la libreta del gráfico compatible aquí.
```

## **Libreta externa**

Aspose.Slides admite el uso de libretas externas como origen de datos para los gráficos.

### **Crear una libreta externa**

Use [read_workbook_stream](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) y [set_external_workbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/set_external_workbook/) para exportar una libreta de gráfico incrustada a un archivo y vincular el gráfico a esa libreta externa.

Este ejemplo crea un gráfico circular con datos predeterminados, escribe su libreta en `externalWorkbook1.xlsx` y cierra el flujo de salida antes de asignar el archivo como origen de datos del gráfico. Guarda la presentación vinculada en `externalWorkbook.pptx`.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)
    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Establecer una libreta externa**

Mediante el método [set_external_workbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/set_external_workbook/) puede asignar una libreta externa a un gráfico como su origen de datos. Este método también puede usarse para actualizar la ruta a la libreta externa (si ésta se ha movido).

Aunque no puede editar los datos en libretas almacenadas en ubicaciones remotas o recursos, sigue pudiendo utilizarlas como origen externo de datos. Si se proporciona una ruta relativa para una libreta externa, se convierte automáticamente en una ruta completa.

Este ejemplo requiere `externalWorkbook.xlsx` en el directorio de trabajo. Su hoja de cálculo llamada `Sheet1` debe contener un nombre de serie en B1, nombres de categoría en A2:A4 y valores numéricos en B2:B4. El ejemplo crea un gráfico circular, vincula la libreta y usa [set_range](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/set_range/) para mapear A1:B4 a una serie y tres categorías. Guarda el resultado en `Presentation_with_externalWorkbook.pptx`.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

El parámetro `update_chart_data` de [set_external_workbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/set_external_workbook/) controla si la libreta se carga.

* Cuando `update_chart_data` es `False`, solo se actualiza la ruta de la libreta. Los datos del gráfico no se cargan ni actualizan desde la libreta de destino, por lo que la libreta puede estar indisponible.
* Cuando `update_chart_data` es `True`, los datos del gráfico se actualizan desde la libreta de destino.

El siguiente ejemplo asigna una URL de marcador de posición con `update_chart_data` configurado en `False`. Conserva los datos predeterminados del gráfico circular y guarda la presentación sin cargar la libreta no disponible.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)

    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Obtener la ruta de la libreta de origen de datos externa de un gráfico**

Para identificar la libreta vinculada a un gráfico, primero compruebe si el gráfico usa un origen de datos externo. Si es así, puede obtener la ruta de la libreta siguiendo estos pasos.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Acceder a la primera diapositiva por su índice base cero.
1. Verificar que la primera forma sea un gráfico.
1. Leer el tipo de origen de datos del gráfico.
1. Si el origen es una libreta externa, leer su ruta.

Este ejemplo abre `externalWorkbook.pptx`, creado en el ejemplo anterior, e inspecciona la primera forma en la primera diapositiva. Si es un gráfico vinculado a una libreta externa, el ejemplo muestra [external_workbook_path](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/external_workbook_path/) en la consola. Luego guarda una copia de la presentación en `Result.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **Editar datos del gráfico**

Puede editar los datos en libretas externas de la misma manera que modifica el contenido de libretas internas. Cuando una libreta externa no puede cargarse, se lanza una excepción.

Este ejemplo requiere `presentation.pptx` con un gráfico como la primera forma en la primera diapositiva y una libreta externa accesible. Establece el valor respaldado por celda del primer punto de datos de la primera serie en 100 y guarda la presentación en `presentation_out.pptx`. Editar valores de celda puede actualizar el archivo XLSX externo vinculado, por lo que se recomienda usar una copia si necesita conservar la libreta original.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **Recuperar una libreta del caché del gráfico**

Si un gráfico usa una libreta externa que falta o no está disponible, Aspose.Slides puede reconstruir la libreta del gráfico a partir de los datos almacenados en caché en la presentación. Cree [LoadOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/), configure su [spreadsheet_options](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/spreadsheet_options/), y establezca [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/es/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) en `True` antes de abrir la presentación.

El siguiente ejemplo en Python abre `presentation.pptx`, cuya primera forma en la primera diapositiva debe ser un gráfico que hace referencia a una libreta externa no disponible, y accede a los datos recuperados a través de [Chart.chart_data](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/chart_data/) y [ChartData.chart_data_workbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # Leer o modificar los datos de la libreta recuperada aquí.
    else:
        print("The first shape is not a chart.")
```

Si la libreta externa no está disponible y la recuperación está desactivada, Aspose.Slides genera una excepción. Active la recuperación solo cuando usar los datos del gráfico en caché sea una alternativa aceptable, porque la caché puede no contener los cambios realizados en la libreta externa después de la última actualización de la presentación.

## **Preguntas frecuentes**

**¿Puedo determinar si un gráfico concreto está vinculado a una libreta externa o a una incrustada?**

Sí. Un gráfico tiene un [tipo de origen de datos](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/data_source_type/) y una [ruta a una libreta externa](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/external_workbook_path/); si el origen es una libreta externa, puede leer la ruta completa para asegurarse de que se está utilizando un archivo externo.

**¿Se admiten rutas relativas a libretas externas y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente en una ruta absoluta. La presentación almacena la ruta absoluta en el archivo PPTX, por lo que mover la libreta puede requerir actualizar el vínculo.

**¿Puedo usar libretas ubicadas en recursos/redes compartidas?**

Sí, esas libretas pueden usarse como origen de datos externo. Sin embargo, la edición directa de libretas remotas desde Aspose.Slides no está soportada; solo pueden usarse como fuente.

**¿Aspose.Slides sobrescribe el XLSX externo al guardar la presentación?**

La presentación almacena un [enlace al archivo externo](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Editar datos de gráfico respaldados por celdas también puede actualizar el archivo XLSX local vinculado. Use una copia de la libreta si el original debe permanecer sin cambios.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al crear el vínculo. Un enfoque habitual es eliminar la protección previamente o preparar una copia descifrada (por ejemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) y vincular a esa copia.

**¿Pueden varios gráficos referenciar la misma libreta externa?**

Sí. Cada gráfico almacena su propio vínculo. Si todos apuntan al mismo archivo, al actualizar ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.