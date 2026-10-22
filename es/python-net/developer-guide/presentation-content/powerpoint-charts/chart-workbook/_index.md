---
title: Gestionar libros de trabajo de gráficos en presentaciones con Python
linktitle: Libro de trabajo del gráfico
type: docs
weight: 70
url: /es/python-net/chart-workbook/
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
- Python
- Aspose.Slides
description: "Descubra Aspose.Slides for Python via .NET: gestione sin esfuerzo los libros de trabajo de gráficos en formatos PowerPoint y OpenDocument para optimizar los datos de sus presentaciones."
---
## **Visión general**

Este artículo explica cómo trabajar con libros de trabajo de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráficos a través de flujos de libros de trabajo, usar celdas de libros de trabajo como etiquetas de datos de gráficos, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores del gráfico.

También trata el uso de libros de trabajo externos como fuentes de datos de gráficos. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, recuperar la ruta de un libro de trabajo externo vinculado a un gráfico y editar los datos del gráfico cuando el libro de trabajo está disponible.

Para celdas de libro de trabajo que representan datos ausentes, consulte [Controlar la visualización de celdas vacías](/slides/es/python-net/chart-series/) para conocer la diferencia entre una celda vacía y cero, y una comparación de gráfico de líneas de los modos de visualización disponibles.

## **Incluir datos de filas y columnas ocultas**

Utilice [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) para controlar si un gráfico representa datos de filas y columnas de hoja de cálculo ocultas. Establézcalo en `True` para representar solo celdas visibles, o en `False` para incluir tanto celdas visibles como ocultas. Esta configuración controla la representación del gráfico; no oculta ni muestra filas o columnas de la hoja de cálculo.

La [presentación de ejemplo](hidden-source-data.pptx) contiene un gráfico de columnas como la primera forma en su primera diapositiva. La hoja de cálculo incrustada, `Sheet1`, contiene el siguiente rango de origen, `A1:C4`. La fila 3 y la columna C están ocultas, pero sus celdas siguen conteniendo valores.

| Fila de hoja de cálculo | A: Mes | B: Venta al por menor | C: Venta al por mayor (columna oculta) |
| --- | --- | --- | --- |
| 2 | Enero | 10 | 30 |
| 3 (fila oculta) | Febrero | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Acceda a las celdas de origen a través de [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) y lea [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) para inspeccionar su estado de ocultación. Esta propiedad es de solo lectura. En este archivo, B2 es visible, B3 pertenece a la fila oculta y C2 pertenece a la columna oculta; el ejemplo imprime `False`, `True` y `True`, respectivamente.

Para este ejemplo, actualice los datos del gráfico después de cambiar la configuración de representación: conserve el libro de trabajo incrustado con [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) y recárguelo con [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Cuando se incluyen todas las celdas, utilice también [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) para restaurar el rango completo, incluida la categoría de febrero oculta. Cambiar simplemente el indicador no es suficiente para actualizar los datos en caché de este ejemplo ni las etiquetas de categoría.

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

            # Actualiza los datos del gráfico desde el libro de trabajo incrustado.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Restaura el rango de origen completo, incluidas las categorías ocultas.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

El ejemplo guarda dos versiones de la presentación: una con solo los valores visibles de Venta al por menor (10 y 20) y otra con los seis valores. Las imágenes a continuación se generaron a partir de las presentaciones guardadas tras volver a abrirlas; ambos archivos conservan su configuración de representación asignada. La fila 3 y la columna C permanecen ocultas en ambos libros de trabajo incrustados.

| Solo celdas visibles (`True`) | Todas las celdas (`False`) |
| --- | --- |
| ![Solo celdas visibles: valores de venta al por menor 10 y 20 para enero y marzo.](hidden_cells_True.png) | ![Todas las celdas: valores de venta al por menor y mayor para enero, febrero y marzo.](hidden_cells_False.png) |

Una celda oculta que contiene un valor es diferente de una celda vacía. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) controla cómo se muestran los valores ausentes; no incluye ni excluye datos de origen ocultos. Vea [Controlar la visualización de celdas vacías](/slides/es/python-net/chart-series/#control-the-display-of-empty-cells) para un ejemplo.

## **Recuperar el rango de datos de un gráfico**

Antes de actualizar los datos del libro de trabajo en una presentación existente, inspeccione los rangos de origen para identificar qué celdas de hoja de cálculo usa cada gráfico. El método [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) devuelve el rango de datos actual como una fórmula calificada por hoja, como `Sheet1!$A$1:$D$5`. Aquí, `Sheet1` es el nombre de la hoja, `!` lo separa del rango de celdas y `$A$1:$D$5` identifica las celdas A1 a D5, inclusive. Los signos de dólar indican referencias absolutas de fila y columna.

El método lee el rango actual sin modificar el gráfico ni su libro de trabajo. Si el gráfico no usa un libro de trabajo como origen de datos, se lanza una excepción. Para más información, consulte la [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Este ejemplo abre una presentación y comprueba directamente las formas en cada diapositiva para buscar gráficos. Imprime el nombre y el rango de origen de cada gráfico. Si no se puede obtener el rango, imprime un mensaje diagnóstico y continúa con el siguiente gráfico.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **Leer y escribir datos de gráfico desde un libro de trabajo**

Aspose.Slides for Python via .NET proporciona los métodos [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) y [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) que permiten leer y escribir libros de trabajo de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Note** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar a la del origen.

Este ejemplo usa una presentación con un gráfico como la primera forma en su primera diapositiva. Lee el libro de trabajo incrustado en un flujo, borra las series y categorías existentes y escribe el mismo libro de trabajo de nuevo. Los cambios permanecen en memoria; el ejemplo no guarda la presentación.

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

### **Validar la disposición del gráfico después de la modificación del libro de trabajo**

Cuando sustituye un libro de trabajo incrustado por uno modificado, el gráfico conserva sus colecciones originales de series y categorías. Esta discrepancia puede hacer que [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) falle con un error de índice fuera de rango. Borra las series y categorías existentes antes de escribir el libro de trabajo actualizado en el gráfico. Este ejemplo usa un gráfico que es la primera forma en la primera diapositiva. El comentario indica dónde se produciría la edición del libro de trabajo; el ejemplo ejecutable escribe el libro de trabajo original de nuevo y valida la disposición en memoria.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Modifique el flujo del libro de trabajo aquí, por ejemplo, usando Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Borrar las colecciones elimina referencias a datos obsoletos antes de que el libro de trabajo se escriba de nuevo. Reconstruya cualquier asignación de series y categorías necesaria para el libro de trabajo actualizado antes de usar el gráfico.

## **Establecer formatos numéricos personalizados para celdas de libro de trabajo**

Utilice [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) para controlar cómo aparecen los valores numéricos en el libro de trabajo incrustado de un gráfico. Por ejemplo, un informe puede necesitar que una tasa de conversión se muestre como porcentaje con cuatro decimales y que un coeficiente se muestre con cinco decimales. Mantenga ambos valores como numéricos para que sigan disponibles para cálculos y representación de gráficos.

Un formato numérico cambia la visualización, no el valor almacenado. El formato `0.0000%` muestra `0.125` como `12.5000%`; no reemplaza el número almacenado por `12.5`. De forma similar, `0.00000` muestra `0.1234567` como `0.12346` sin redondear el valor almacenado. Si el formato personalizado es una cadena vacía (`""`), se utiliza [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) en su lugar.

El siguiente ejemplo crea un gráfico de columnas y accede a sus celdas mediante [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/). En la hoja 0, B2 contiene la tasa de conversión y C2 contiene el coeficiente. Ambas celdas suministran valores al gráfico. El ejemplo también habilita etiquetas de valor vinculadas a los formatos de origen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

Los formatos de celda del libro de trabajo son independientes de los formatos establecidos directamente en los ejes del gráfico o en las etiquetas de datos. En este ejemplo, cada etiqueta muestra el valor de su celda de origen porque [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) está habilitado, y sigue el formato numérico de origen porque [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) es `True`. Después de guardar y volver a abrir la presentación, las etiquetas muestran `12.5000%` y `0.12346`, como se muestra a continuación. El eje vertical usa su propio [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) de `0.00`, con [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) establecido en `False`.

Para formatear una etiqueta de datos de forma independiente, establezca su bandera de vínculo a origen en `False` y asigne su [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/). Esto no cambia el formato de la celda del libro de trabajo. Por ejemplo, un formato independiente de etiqueta `0.00` muestra el primer valor como `0.13`, mientras que B2 sigue mostrando `12.5000%`. Consulte [Chart Data Labels](/slides/es/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) para el formateo directo de etiquetas.

La imagen siguiente se generó a partir de la presentación guardada tras volver a abrirla:

![Gráfico de columnas con etiquetas vinculadas al origen que muestran 12.5000% y 0.12346 y un eje numérico formateado de forma independiente.](custom-cell-formats.png)

## **Establecer una celda de libro de trabajo como etiqueta de datos del gráfico**

Puede usar texto de celdas de libro de trabajo como etiquetas de datos del gráfico.

Este ejemplo añade un gráfico de burbujas con datos predeterminados a la primera diapositiva de una presentación existente. Utiliza las celdas A10:A12 en la hoja 0 para las tres primeras etiquetas de la primera serie, habilita las etiquetas desde celdas y guarda la presentación actualizada.

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

## **Gestionar hojas de cálculo**

La propiedad [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) proporciona acceso a las hojas de cálculo en un libro de trabajo de gráfico. Este ejemplo crea un gráfico circular con datos predeterminados e imprime cada nombre de hoja en la consola.

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

Los valores de los puntos de la serie también pueden almacenarse directamente como literales numéricos. Vea [Set Series Values Using Numeric Literals](/slides/es/python-net/chart-series/#set-series-values-using-numeric-literals) para un ejemplo completo que los guarda y los lee. El tipo de origen de los valores de los puntos es independiente de la configuración interna o externa del libro de trabajo del gráfico; usar literales numéricos no elimina, por sí mismo, el libro de trabajo incrustado.

Este ejemplo crea un gráfico de columnas 3D con datos predeterminados y establece dos nombres de serie mediante diferentes orígenes de datos. El primer nombre usa un literal de cadena; el segundo usa la celda C1 en la hoja 0. La enumeración [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) selecciona el origen para cada nombre. El ejemplo guarda la presentación con los nombres de serie actualizados.

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

## **Detectar formatos de libro de trabajo incrustado no compatibles**

Aspose.Slides no admite el formato de libro de trabajo binario de Excel (.xlsb) que puede incrustarse en algunos gráficos. Puede usar la propiedad [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) en [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) junto con la enumeración [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) para detectar formatos no compatibles y omitir esos gráficos. Este ejemplo inspecciona las formas en la primera diapositiva de una presentación existente, omite las formas que no son gráficos e imprime un mensaje diagnóstico para cada gráfico con un libro de trabajo .xlsb incrustado.

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

        # Leer o modificar los datos compatibles del libro de trabajo del gráfico aquí.
```

## **Libro de trabajo externo**

Aspose.Slides admite el uso de libros de trabajo externos como fuente de datos para gráficos.

### **Crear un libro de trabajo externo**

Utilice [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) y [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) para exportar un libro de trabajo de gráfico incrustado a un archivo y vincular el gráfico a ese libro de trabajo externo.

Este ejemplo crea un gráfico circular con datos predeterminados y exporta su libro de trabajo. Cierra el flujo de salida antes de asignar el libro de trabajo externo como origen de datos del gráfico y luego guarda la presentación vinculada.

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

### **Asignar un libro de trabajo externo**

Mediante el método [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) puede asignar un libro de trabajo externo a un gráfico como su origen de datos. Este método también puede usarse para actualizar la ruta al libro de trabajo externo (si este se ha movido).

Aunque no puede editar los datos en libros de trabajo almacenados en ubicaciones remotas o recursos, puede seguir utilizándolos como fuente de datos externa. Si se proporciona una ruta relativa para un libro de trabajo externo, se convierte automáticamente en una ruta absoluta.

Este ejemplo usa un libro de trabajo externo cuya hoja llamada `Sheet1` contiene un nombre de serie en B1, nombres de categoría en A2:A4 y valores numéricos en B2:B4. El ejemplo crea un gráfico circular, vincula el libro de trabajo y usa [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) para mapear A1:B4 a una serie y tres categorías. Guarda la presentación con el gráfico vinculado.

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

El parámetro `update_chart_data` de [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) controla si se carga el libro de trabajo.

* Cuando `update_chart_data` es `False`, solo se actualiza la ruta del libro de trabajo. Los datos del gráfico no se cargan ni se actualizan desde el libro de trabajo de destino, por lo que el libro de trabajo puede estar indisponible.
* Cuando `update_chart_data` es `True`, los datos del gráfico se actualizan desde el libro de trabajo de destino.

El siguiente ejemplo asigna una URL de marcador de posición con `update_chart_data` establecido en `False`. Conserva los datos predeterminados del gráfico circular y guarda la presentación sin cargar el libro de trabajo indisponible.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Obtener la ruta del libro de trabajo externo de origen de datos de un gráfico**

Para identificar el libro de trabajo vinculado a un gráfico, compruebe si el gráfico usa un origen de datos externo y recupere su ruta.

Este ejemplo inspecciona la primera forma en la primera diapositiva de una presentación con un libro de trabajo externo vinculado. Si es un gráfico vinculado a un libro de trabajo externo, el ejemplo imprime [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) en la consola. Luego guarda una copia de la presentación.

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

Puede editar los datos en libros de trabajo externos de la misma manera que modifica el contenido de los libros de trabajo internos. Cuando un libro de trabajo externo no se puede cargar, se lanza una excepción.

Este ejemplo usa un gráfico que es la primera forma en la primera diapositiva y está vinculado a un libro de trabajo externo accesible. Establece el valor respaldado por celda del primer punto de datos de la primera serie en 100 y guarda la presentación actualizada. Editar valores de celda puede actualizar el archivo XLSX externo vinculado, por lo que debe usar una copia si necesita conservar el libro de trabajo original.

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

### **Recuperar un libro de trabajo desde la caché del gráfico**

Si un gráfico usa un libro de trabajo externo que falta o no está disponible, Aspose.Slides puede reconstruir el libro de trabajo del gráfico a partir de los datos en caché de la presentación. Cree [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), configure su [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), y establezca [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) en `True` antes de abrir la presentación.

El siguiente ejemplo en Python recupera los datos del libro de trabajo para un gráfico que es la primera forma en la primera diapositiva y hace referencia a un libro de trabajo externo no disponible. Accede a los datos recuperados a través de [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) y [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

        # Leer o modificar los datos del libro de trabajo recuperado aquí.
    else:
        print("The first shape is not a chart.")
```

Si el libro de trabajo externo no está disponible y la recuperación está desactivada, Aspose.Slides lanza una excepción. Active la recuperación solo cuando usar los datos del gráfico en caché sea una alternativa aceptable, porque la caché puede no contener los cambios realizados en el libro de trabajo externo después de la última actualización de la presentación.

## **FAQ**

**¿Puedo determinar si un gráfico concreto está vinculado a un libro de trabajo externo o incrustado?**

Sí. Un gráfico tiene un [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) y una [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); si el origen es un libro de trabajo externo, puede leer la ruta completa para asegurarse de que se está usando un archivo externo.

**¿Se admiten rutas relativas a libros de trabajo externos y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente en una ruta absoluta. La presentación almacena la ruta absoluta en el archivo PPTX, por lo que mover el libro de trabajo puede requerir actualizar el enlace.

**¿Puedo usar libros de trabajo ubicados en recursos/redes compartidas?**

Sí, esos libros pueden usarse como fuente de datos externa. Sin embargo, la edición directa de libros de trabajo remotos desde Aspose.Slides no está soportada; solo pueden utilizarse como origen.

**¿Aspose.Slides sobrescribe el XLSX externo al guardar la presentación?**

La presentación almacena un [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Editar datos de gráficos respaldados por celdas también puede actualizar el archivo XLSX local vinculado. Use una copia del libro de trabajo si el original debe permanecer sin cambios.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al crear el vínculo. Un enfoque habitual es eliminar la protección con antelación o preparar una copia descifrada (por ejemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) y enlazar a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro de trabajo externo?**

Sí. Cada gráfico almacena su propio vínculo. Si todos apuntan al mismo archivo, actualizar ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.