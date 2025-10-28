---
title: Administrar Libros de Trabajo de Gráficos en Presentaciones con Python
linktitle: Libro de Trabajo de Gráfico
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
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Descubra Aspose.Slides para Python vía .NET: administre fácilmente los libros de trabajo de gráficos en formatos PowerPoint y OpenDocument para optimizar los datos de su presentación."
---

## **Establecer datos de gráfico desde un libro de trabajo**

Aspose.Slides proporciona métodos para leer y escribir libros de trabajo de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Nota:** Los datos del gráfico deben estar organizados de la misma manera o tener una estructura similar a la fuente.

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

## **Establecer una celda de libro de trabajo como etiqueta de datos de gráfico**

A veces necesita etiquetas de gráfico que provengan directamente de celdas en el libro de trabajo de datos subyacente. Aspose.Slides le permite vincular etiquetas de datos a celdas específicas del libro de trabajo para que el texto de la etiqueta siempre refleje el valor de la celda. El ejemplo a continuación muestra cómo habilitar etiquetas de valor-desde-celda y apuntar etiquetas seleccionadas a celdas personalizadas en el libro de trabajo del gráfico.

1. Cree una instancia de la clase [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva por índice.
3. Agregue un gráfico de burbujas con datos de ejemplo.
4. Acceda a la serie del gráfico.
5. Utilice una celda de libro de trabajo como etiqueta de datos.
6. Guarde la presentación.

El siguiente código Python muestra cómo establecer una celda de libro de trabajo como etiqueta de datos de gráfico:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instantiate the Presentation class that represents a presentation file.
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

## **Administrar hojas de cálculo**

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

## **Especificar el tipo de fuente de datos**

El siguiente código Python muestra cómo especificar un tipo de fuente de datos:

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

## **Libros de trabajo externos**

Aspose.Slides admite el uso de libros de trabajo externos como fuente de datos para los gráficos.

### **Establecer libros de trabajo externos**

Al usar el método [ChartData.set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) puede asignar un libro de trabajo externo a un gráfico como su fuente de datos. Este método también puede actualizar la ruta a un libro de trabajo externo si este se ha movido.

Aunque no puede editar datos en libros de trabajo almacenados en ubicaciones o recursos remotos, aún puede utilizarlos como fuentes de datos externas. Si proporciona una ruta relativa para un libro de trabajo externo, se convierte automáticamente en una ruta completa.

El siguiente código Python muestra cómo establecer un libro de trabajo externo:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

El parámetro `update_chart_data` del método [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) indica si se cargará el libro de Excel.

- Cuando `update_chart_data` se establece en `False`, solo se actualiza la ruta del libro; los datos del gráfico no se cargan ni se actualizan desde el libro de destino. Use esta configuración cuando el libro de destino no exista o no esté disponible.
- Cuando `update_chart_data` se establece en `True`, los datos del gráfico se cargan y se actualizan desde el libro de destino.

### **Crear libros de trabajo externos**

Al usar los métodos [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) y [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) puede crear un libro de trabajo externo desde cero o convertir un libro interno en uno externo.

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

### **Obtener la ruta del libro de trabajo fuente de datos externo para un gráfico**

A veces los datos de un gráfico están vinculados a un libro de Excel externo en lugar de los datos incrustados en la presentación. Con Aspose.Slides puede inspeccionar la fuente de datos del gráfico y, si es un libro externo, leer la ruta completa del libro.

1. Cree una instancia de la clase [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva por su índice.
3. Obtenga una referencia a la forma del gráfico.
4. Obtenga la fuente ([ChartDataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/)) que representa la fuente de datos del gráfico.
5. Verifique si el tipo de fuente coincide con el tipo de fuente de datos de libro externo.

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

Puede editar datos en libros de trabajo externos de la misma manera que lo hace en libros internos. Si no se puede cargar un libro externo, se lanza una excepción.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Puedo determinar si un gráfico específico está vinculado a un libro de trabajo externo o incrustado?**

Sí. Un gráfico tiene un [tipo de fuente de datos](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) y una [ruta a un libro de trabajo externo](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); si la fuente es un libro externo, puede leer la ruta completa para asegurarse de que se está usando un archivo externo.

**¿Se admiten rutas relativas a libros de trabajo externos y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente en una ruta absoluta. Esto es útil para la portabilidad del proyecto; sin embargo, tenga en cuenta que la presentación almacenará la ruta absoluta en el archivo PPTX.

**¿Puedo usar libros de trabajo ubicados en recursos/redes compartidas?**

Sí, dichos libros pueden usarse como fuente de datos externa. No obstante, la edición directa de libros remotos desde Aspose.Slides no está soportada; solo pueden usarse como fuente.

**¿Aspose.Slides sobrescribe el XLSX externo al guardar la presentación?**

No. La presentación guarda un [enlace al archivo externo](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) y lo utiliza para leer los datos. El archivo externo no se modifica al guardar la presentación.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al crear el vínculo. Un enfoque común es eliminar la protección con antelación o preparar una copia desencriptada (por ejemplo, usando [Aspose.Cells](/cells/python-net/)) y enlazar a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro de trabajo externo?**

Sí. Cada gráfico almacena su propio enlace. Si todos apuntan al mismo archivo, la actualización de ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.