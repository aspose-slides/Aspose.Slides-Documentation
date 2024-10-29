---
title: Libro de trabajo de gráficos
type: docs
weight: 70
url: /es/python-net/chart-workbook/
keywords: "Libro de trabajo de gráficos, datos de gráfico, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Libro de trabajo de gráficos en presentación de PowerPoint en Python"
---

## **Establecer datos de gráfico desde el libro de trabajo**

Aspose.Slides proporciona algunos métodos que permiten leer y escribir libros de trabajo de datos de gráficos (contienen datos de gráficos editados con Aspose.Cells). **Nota** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar a la fuente.

Este código Python demuestra una operación de ejemplo:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instancia una clase Presentation que representa un archivo de presentación 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series

    series[0].labels.default_data_label_format.show_label_value_from_cell = True

    wb = chart.chart_data.chart_data_workbook

    series[0].labels[0].value_from_cell = wb.get_cell(0, "A10", "Valor de celda de etiqueta 0")
    series[0].labels[1].value_from_cell = wb.get_cell(0, "A11", "Valor de celda de etiqueta 1")
    series[0].labels[2].value_from_cell = wb.get_cell(0, "A12", "Valor de celda de etiqueta 2")

    pres.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer celda del libro de trabajo como etiqueta de datos de gráfico**

1. Crea una instancia de la [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) clase.
1. Obtiene la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico de burbujas con algunos datos.
1. Accede a la serie del gráfico.
1. Establece la celda del libro de trabajo como etiqueta de datos.
1. Guarda la presentación.

Este código Python te muestra cómo establecer una celda del libro de trabajo como etiqueta de datos de gráfico: xxx

```python

```

## **Gestionar hojas de cálculo**

Este código Python demuestra una operación en la que se utiliza la propiedad `worksheets` para acceder a una colección de hojas de cálculo:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
   chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
   wb =  chart.chart_data.chart_data_workbook
   for i in range(len(wb.worksheets)):
      print(wb.worksheets[i].name)
```

## **Especificar tipo de fuente de datos**

Este código Python te muestra cómo especificar un tipo para una fuente de datos: 

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    val = chart.chart_data.series[0].name

    val.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    val.data = "CadenaLiteral"

    val = chart.chart_data.series[0].name
    val.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NuevaCelda")

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Libro de trabajo externo**

{{% alert color="primary" %}} 
En [Aspose.Slides para .NET 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/), implementamos soporte para libros de trabajo externos como fuente de datos para gráficos.
{{% /alert %}} 

### **Crear libro de trabajo externo**

Usando algunos métodos de **`IChartData`**, puedes crear un libro de trabajo externo desde cero o hacer que un libro de trabajo interno sea externo.

Este código Python demuestra el proceso de creación de un libro de trabajo externo:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:

    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.chart_data_workbook.clear(0)

    chart.chart_data.set_external_workbook(path + "externalWorkbook.xlsx")

    chart.chart_data.set_range("Sheet1!$A$2:$B$5")
    series = chart.chart_data.series[0]
    series.parent_series_group.is_color_varied = True
    pres.save("response2.pptx", slides.export.SaveFormat.PPTX)
```

### **Establecer libro de trabajo externo**

Usando el método **`chartData.set_external_workbook`**, puedes asignar un libro de trabajo externo a un gráfico como su fuente de datos. Este método también se puede utilizar para actualizar una ruta al libro de trabajo externo (si este último ha sido movido).

Aunque no puedes editar los datos en libros de trabajo almacenados en ubicaciones o recursos remotos, todavía puedes usar dichos libros de trabajo como una fuente de datos externa. Si se proporciona la ruta relativa para un libro de trabajo externo, se convierte automáticamente en una ruta completa.

Este código Python te muestra cómo establecer un libro de trabajo externo:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

# La ruta al directorio de documentos.
with slides.Presentation() as pres:

    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chartData = chart.chart_data
                    
    chartData.set_external_workbook(path + "externalWorkbook.xlsx")
                  

    chartData.series.add(chartData.chart_data_workbook.get_cell(0, "B1"), charts.ChartType.PIE)
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B2"))
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B3"))
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B4"))

    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A2"))
    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A3"))
    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A4"))
    pres.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

El parámetro `chart_data` (bajo el método `set_external_workbook`) se utiliza para especificar si un libro de trabajo de Excel se cargará o no. 

* Cuando el valor de `chart_data` se establece en `false`, solo se actualiza la ruta del libro de trabajo: los datos del gráfico no se cargarán ni actualizarán desde el libro de trabajo de destino. Puede que desees usar esta configuración cuando te encuentres en una situación en la que el libro de trabajo de destino no existe o no está disponible. 
* Cuando el valor de `chart_data` se establece en `true`, los datos del gráfico se actualizan desde el libro de trabajo de destino.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chartData = chart.chart_data

    chartData.set_external_workbook("http://path/doesnt/exists", False)

    pres.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Obtener la ruta del libro de trabajo de la fuente de datos externa del gráfico**

1. Crea una instancia de la [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) clase.
1. Obtén la referencia de una diapositiva a través de su índice.
1. Crea un objeto para la forma del gráfico.
1. Crea un objeto para el tipo de fuente (`ChartDataSourceType`) que representa la fuente de datos del gráfico.
1. Especifica la condición relevante según el tipo de fuente sea el mismo que el tipo de fuente de datos del libro de trabajo externo.

Este código Python demuestra la operación:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("response2.pptx") as pres:
    chart = pres.slides[0].shapes[0]
    sourceType = chart.chart_data.data_source_type
    if sourceType == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Editar datos del gráfico**

Puedes editar los datos en libros de trabajo externos de la misma manera que realizas cambios en el contenido de libros de trabajo internos. Cuando no se puede cargar un libro de trabajo externo, se lanza una excepción.

Este código Python es una implementación del proceso descrito:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "presentation.pptx") as pres:
    pres.slides[0].shapes[0].chart_data.series[0].data_points[0].value.as_cell.value = 100
    pres.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
```