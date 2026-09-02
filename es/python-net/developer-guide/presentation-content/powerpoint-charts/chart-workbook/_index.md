---
title: Gestionar libros de trabajo de gráficos en presentaciones con Python
linktitle: Libro de trabajo de gráfico
type: docs
weight: 70
url: /es/python-net/chart-workbook/
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
- Aspose.Slides
description: "Descubra Aspose.Slides para Python vía .NET: gestione sin esfuerzo los libros de trabajo de gráficos en formatos PowerPoint y OpenDocument para optimizar los datos de su presentación."
---
## **Visión general**

Este artículo explica cómo trabajar con libros de trabajo de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráfico mediante flujos de libros de trabajo, usar celdas de libro de trabajo como etiquetas de datos del gráfico, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores del gráfico.

También cubre el trabajo con libros de trabajo externos como fuentes de datos del gráfico. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, obtener la ruta de un libro de trabajo externo enlazado a un gráfico y editar los datos del gráfico cuando el libro de trabajo está disponible.

## **Leer y escribir datos de gráfico desde un libro de trabajo**

Aspose.Slides proporciona métodos para leer y escribir libros de trabajo de datos de gráfico (que contienen datos de gráfico editados con Aspose.Cells). **Nota:** Los datos del gráfico deben estar organizados de la misma manera o tener una estructura similar a la fuente.

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

Cuando reemplaza un libro de trabajo incrustado por uno modificado, el gráfico conserva sus colecciones originales de series y categorías. Esta discrepancia puede hacer que [IChart.validate_chart_layout](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/ichart/validate_chart_layout/) falle con un error de índice fuera de rango. Elimine las series y categorías existentes antes de escribir el libro de trabajo actualizado de vuelta al gráfico.

```python
# Después de modificar el flujo del libro de trabajo (p.ej., usando Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Eliminar referencias de datos existentes.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Eliminar las colecciones garantiza que la estructura de datos del gráfico sea coherente con el nuevo libro de trabajo, permitiendo que `validate_chart_layout` se ejecute sin errores.

## **Establecer una celda de WorkBook como etiqueta de datos del gráfico**

A veces necesita etiquetas de gráfico que provengan directamente de celdas en el libro de datos subyacente. Aspose.Slides le permite vincular etiquetas de datos a celdas específicas del libro de trabajo para que el texto de la etiqueta siempre refleje el valor de la celda. El ejemplo a continuación muestra cómo habilitar etiquetas que toman el valor de la celda y apuntar etiquetas seleccionadas a celdas personalizadas en el libro de trabajo del gráfico.

1. Cree una instancia de la clase [Presentation](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides/presentation/).
1. Obtenga una referencia a la diapositiva por índice.
1. Añada un gráfico de burbujas con datos de ejemplo.
1. Acceda a las series del gráfico.
1. Utilice una celda de workbook como etiqueta de datos.
1. Guarde la presentación.

El siguiente código Python muestra cómo establecer una celda de libro de trabajo como etiqueta de datos del gráfico:

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

El siguiente código Python muestra cómo usar la propiedad `worksheets` para acceder a la colección de hojas de cálculo:

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

## **Detectar formatos de libro de trabajo incrustado no compatibles**

Aspose.Slides no admite el formato de libro de trabajo binario de Excel (.xlsb) que puede incrustarse en algunos gráficos. Puede usar la propiedad `embedded_workbook_type` en [ChartData](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/) junto con la enumeración [WorkbookType](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/workbooktype/) para detectar formatos no compatibles y omitir esos gráficos.

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

Aspose.Slides admite el uso de libros de trabajo externos como fuente de datos para gráficos.

### **Establecer libros de trabajo externos**

Al usar el método [ChartData.set_external_workbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/set_external_workbook/), puede asignar un libro de trabajo externo a un gráfico como su fuente de datos. Este método también puede actualizar la ruta a un libro de trabajo externo si se ha movido.

Aunque no puede editar datos en libros de trabajo almacenados en ubicaciones o recursos remotos, aún puede usar esos libros como fuentes externas de datos. Si proporciona una ruta relativa para un libro de trabajo externo, se convierte automáticamente en una ruta completa.

El siguiente código Python muestra cómo establecer un libro de trabajo externo:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Pase False para que solo se almacene la ruta: el libro de trabajo de destino no tiene que existir aún.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

El parámetro `update_chart_data` del método [set_external_workbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/set_external_workbook/) especifica si el libro de Excel se cargará.

- Cuando `update_chart_data` se establece en `False`, solo se actualiza la ruta del libro; los datos del gráfico no se cargan ni se actualizan desde el libro de destino. Use esta configuración cuando el libro de destino no exista o no esté disponible.
- Cuando `update_chart_data` se establece en `True` (valor predeterminado), los datos del gráfico se cargan y se actualizan desde el libro de destino. Si ese libro no puede abrirse, se lanza una excepción con el mensaje "External workbook is not available".

### **Crear libros de trabajo externos**

Al usar los métodos [read_workbook_stream](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) y [set_external_workbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/set_external_workbook/), puede crear un libro de trabajo externo desde cero o convertir un libro interno en uno externo.

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

### **Obtener la ruta del libro de trabajo de origen de datos externo para un gráfico**

A veces los datos de un gráfico están vinculados a un libro de Excel externo en lugar de a los datos incrustados de la presentación. Con Aspose.Slides, puede inspeccionar el origen de datos del gráfico y, si es un libro externo, leer la ruta completa del libro.

1. Cree una instancia de la clase [Presentation](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides/presentation/).
1. Obtenga una referencia a la diapositiva por su índice.
1. Obtenga una referencia a la forma del gráfico.
1. Obtenga el origen ([ChartDataSourceType](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatasourcetype/)) que representa la fuente de datos del gráfico.
1. Verifique si el tipo de origen coincide con el tipo de origen de datos de libro externo.

El siguiente código Python muestra la operación:

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

Puede editar los datos en libros de trabajo externos de la misma forma que lo hace con los libros internos. Si un libro externo no puede cargarse, se lanza una excepción.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Recuperar un libro de trabajo desde la caché del gráfico**

Si un gráfico utiliza un libro externo que falta o no está disponible, Aspose.Slides puede reconstruir el libro del gráfico a partir de los datos almacenados en caché en la presentación. Cree [LoadOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/), luego habilite [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/es/python-net/aspose.slides.spreadsheetoptions/recover_workbook_from_chart_cache/) a través de [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/spreadsheet_options/) antes de abrir la presentación.

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

Si el libro externo no está disponible y la recuperación está deshabilitada, Aspose.Slides genera una excepción. Active la recuperación solo cuando usar los datos del gráfico en caché sea una alternativa aceptable, ya que la caché puede no contener los cambios realizados en el libro externo después de la última actualización de la presentación.

## **Preguntas frecuentes**

**¿Puedo determinar si un gráfico específico está enlazado a un libro de trabajo externo o incrustado?**

Sí. Un gráfico tiene un [data source type](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/data_source_type/) y una [path to an external workbook](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/external_workbook_path/); si el origen es un libro externo, puede leer la ruta completa para asegurarse de que se está utilizando un archivo externo.

**¿Se admiten rutas relativas a libros de trabajo externos y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente en una ruta absoluta. Esto es práctico para la portabilidad del proyecto; sin embargo, tenga en cuenta que la presentación almacenará la ruta absoluta en el archivo PPTX.

**¿Puedo usar libros de trabajo ubicados en recursos o comparticiones de red?**

Sí, esos libros pueden usarse como fuente de datos externa. No se admite la edición directa de libros remotos desde Aspose.Slides; solo pueden utilizarse como origen.

**¿Sobrescribe Aspose.Slides el XLSX externo al guardar la presentación?**

Solo si editó los datos del gráfico. La presentación almacena un [link to the external file](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/external_workbook_path/) y lo usa para leer datos, por lo que abrir y guardar la presentación deja el libro intacto. No obstante, los valores que cambie a través de los datos del gráfico (ver [Edit Chart Data](#edit-chart-data) arriba) se escriben de nuevo en el libro externo cuando se guarda la presentación; trabaje con una copia si el original debe permanecer intacto.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al crear el enlace. Un enfoque común es eliminar la protección con antelación o preparar una copia desencriptada (por ejemplo, usando [Aspose.Cells](/cells/python-net/)) y enlazar a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro de trabajo externo?**

Sí. Cada gráfico almacena su propio enlace. Si todos apuntan al mismo archivo, la actualización de ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.