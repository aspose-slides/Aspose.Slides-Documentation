---
title: Administrar libros de trabajo de gráficos en presentaciones con Python
linktitle: Libro de trabajo del gráfico
type: docs
weight: 70
url: /es/python-net/chart-workbook/
keywords:
- libro de trabajo de gráfico
- datos de gráfico
- celda de libro de trabajo
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
- Aspose.Slides
description: "Descubra Aspose.Slides para Python mediante .NET: administre fácilmente los libros de trabajo de gráficos en formatos PowerPoint y OpenDocument para optimizar los datos de su presentación."
---
## **Visión general**

Este artículo explica cómo trabajar con libros de trabajo de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráficos a través de flujos de libros de trabajo, utilizar celdas del libro como etiquetas de datos del gráfico, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores del gráfico.

También aborda el trabajo con libros de trabajo externos como fuentes de datos del gráfico. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, obtener la ruta de un libro de trabajo externo vinculado a un gráfico y editar los datos del gráfico cuando el libro de trabajo está disponible.

Para celdas de libro de trabajo que representan datos ausentes, consulte [Controlar la visualización de celdas vacías](/slides/es/python-net/chart-series/) para conocer la diferencia entre una celda vacía y cero, y una comparación de gráficos de líneas de los modos de visualización disponibles.

## **Leer y escribir datos de gráfico desde un libro de trabajo**

Aspose.Slides proporciona métodos para leer y escribir libros de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Nota:** Los datos del gráfico deben estar organizados de la misma forma o tener una estructura similar a la fuente.

El siguiente código Python muestra una operación de ejemplo:

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

### **Validar la disposición del gráfico después de la modificación del libro de trabajo**

Cuando sustituye un libro de trabajo incrustado por uno modificado, el gráfico conserva sus colecciones originales de series y categorías. Esta discrepancia puede provocar que [IChart.validate_chart_layout](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/ichart/validate_chart_layout/) falle con un error de índice fuera de rango. Limpie las series y categorías existentes antes de escribir el libro de trabajo actualizado de nuevo en el gráfico.

```python
# Después de modificar el flujo del libro de trabajo (p.ej., usando Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Borrar referencias de datos existentes.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Eliminar las colecciones garantiza que la estructura de datos del gráfico sea coherente con el nuevo libro de trabajo, permitiendo que `validate_chart_layout` se complete sin errores.

## **Establecer una celda de libro de trabajo como etiqueta de datos del gráfico**

A veces necesita etiquetas de gráfico que provengan directamente de celdas del libro de datos subyacente. Aspose.Slides permite enlazar etiquetas de datos a celdas específicas del libro para que el texto de la etiqueta refleje siempre el valor de la celda. El ejemplo a continuación muestra cómo habilitar etiquetas basadas en el valor de la celda y apuntar etiquetas seleccionadas a celdas personalizadas en el libro del gráfico.

1. Crear una instancia de la clase [Presentación](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides/presentation/).
1. Obtener una referencia a la diapositiva por índice.
1. Añadir un gráfico de burbujas con datos de ejemplo.
1. Acceder a las series del gráfico.
1. Utilizar una celda del libro como etiqueta de datos.
1. Guardar la presentación.

El siguiente código Python muestra cómo establecer una celda de libro como etiqueta de datos del gráfico:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestionar hojas de cálculo**

El siguiente código Python demuestra cómo usar la propiedad `worksheets` para acceder a la colección de hojas de cálculo:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **Especificar el tipo de origen de datos**

El siguiente código Python muestra cómo especificar un tipo de origen de datos:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Detectar formatos de libro incrustado no compatibles**

Aspose.Slides no admite el formato de libro binario de Excel (.xlsb) que puede incrustarse en algunos gráficos. Puede usar la propiedad `embedded_workbook_type` en [ChartData](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/) junto con la enumeración [WorkbookType](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/workbooktype/) para detectar formatos no compatibles y omitir esos gráficos.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # El libro de trabajo incrustado está en formato .xlsb, que no es compatible.
            continue

        # Leer o modificar los datos del libro de trabajo del gráfico aquí.
```

## **Libros de trabajo externos**

Aspose.Slides admite el uso de libros de trabajo externos como fuente de datos para los gráficos.

### **Establecer libros de trabajo externos**

Utilizando el método [ChartData.set_external_workbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/set_external_workbook/) puede asignar un libro de trabajo externo a un gráfico como su fuente de datos. Este método también puede actualizar la ruta a un libro de trabajo externo si se ha movido.

Aunque no puede editar datos en libros de trabajo almacenados en ubicaciones o recursos remotos, aún puede utilizar esos libros como fuentes de datos externas. Si proporciona una ruta relativa para un libro de trabajo externo, se convierte automáticamente en una ruta completa.

El siguiente código Python muestra cómo establecer un libro de trabajo externo:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Pase False para que solo se almacene la ruta: el libro de trabajo de destino no tiene que existir todavía.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

El parámetro `update_chart_data` del método [set_external_workbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/set_external_workbook/) especifica si el libro de Excel se cargará.

- Cuando `update_chart_data` se establece en `False`, solo se actualiza la ruta del libro; los datos del gráfico no se cargan ni se actualizan desde el libro de destino. Use esta configuración cuando el libro de destino no exista o no esté disponible.
- Cuando `update_chart_data` se establece en `True` (valor predeterminado), los datos del gráfico se cargan y actualizan desde el libro de destino. Si ese libro no puede abrirse, se lanza una excepción con el mensaje "External workbook is not available".

### **Crear libros de trabajo externos**

Utilizando los métodos [read_workbook_stream](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) y [set_external_workbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/set_external_workbook/) puede crear un libro de trabajo externo desde cero o convertir un libro interno en uno externo.

Este código Python demuestra el proceso de creación de un libro de trabajo externo:

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Obtener la ruta del libro de trabajo externo fuente de datos para un gráfico**

A veces los datos de un gráfico están vinculados a un libro de Excel externo en lugar de a los datos incrustados en la presentación. Con Aspose.Slides, puede inspeccionar la fuente de datos del gráfico y, si es un libro externo, leer la ruta completa del libro.

1. Crear una instancia de la clase [Presentación](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides/presentation/).
1. Obtener una referencia a la diapositiva por su índice.
1. Obtener una referencia a la forma del gráfico.
1. Obtener la fuente ([ChartDataSourceType](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatasourcetype/)) que representa la fuente de datos del gráfico.
1. Comprobar si el tipo de fuente coincide con el tipo de fuente de libro externo.

El siguiente código Python demuestra la operación:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Editar datos del gráfico**

Puede editar datos en libros externos de la misma forma que edita datos en libros internos. Si un libro externo no puede cargarse, se lanza una excepción.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Recuperar un libro de trabajo de la caché del gráfico**

Si un gráfico utiliza un libro externo que falta o no está disponible, Aspose.Slides puede reconstruir el libro de trabajo del gráfico a partir de los datos almacenados en caché en la presentación. Cree [LoadOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/), luego habilite [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/es/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) a través de [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/spreadsheet_options/) antes de abrir la presentación.

El siguiente ejemplo Python abre una presentación cuyo gráfico hace referencia a un libro externo no disponible y accede a los datos recuperados mediante [Chart.chart_data](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/chart_data/) y [ChartData.chart_data_workbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Leer o modificar los datos del libro de trabajo recuperado aquí.
```

Si el libro externo no está disponible y la recuperación está desactivada, Aspose.Slides lanza una excepción. Habilite la recuperación solo cuando usar los datos del gráfico en caché sea una solución alternativa aceptable, porque la caché puede no contener los cambios realizados en el libro externo después de la última actualización de la presentación.

## **FAQ**

**¿Puedo determinar si un gráfico específico está vinculado a un libro externo o incrustado?**

Sí. Un gráfico tiene un [data source type](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/data_source_type/) y una [path to an external workbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/external_workbook_path/); si la fuente es un libro externo, puede leer la ruta completa para asegurarse de que se está utilizando un archivo externo.

**¿Se admiten rutas relativas a libros externos, y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente en una ruta absoluta. Esto es conveniente para la portabilidad del proyecto; sin embargo, tenga en cuenta que la presentación almacenará la ruta absoluta en el archivo PPTX.

**¿Puedo utilizar libros ubicados en recursos/comparticiones de red?**

Sí, esos libros pueden usarse como fuente de datos externa. Sin embargo, la edición directa de libros remotos desde Aspose.Slides no está soportada; solo pueden usarse como fuente.

**¿Aspose.Slides sobrescribe el XLSX externo al guardar la presentación?**

Sólo si ha editado los datos del gráfico. La presentación almacena un [link to the external file](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/external_workbook_path/) y lo utiliza para leer los datos, por lo que abrir y guardar una presentación deja el libro sin modificaciones. No obstante, los valores que cambie a través de los datos del gráfico (ver [Edit Chart Data](#edit-chart-data) más arriba) se escriben de vuelta en el libro externo cuando se guarda la presentación; trabaje con una copia si el original debe permanecer intacto.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al crear el enlace. Un enfoque común es eliminar la protección con antelación o preparar una copia descifrada (por ejemplo, usando [Aspose.Cells](/cells/python-net/)) y enlazar a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro externo?**

Sí. Cada gráfico almacena su propio enlace. Si todos apuntan al mismo archivo, al actualizar ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.