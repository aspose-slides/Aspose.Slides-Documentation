---
title: Crear gráficos de Excel e incrustarlos en presentaciones como objetos OLE
type: docs
weight: 30
url: /es/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- gráfico de Excel
- incrustar gráfico
- objeto OLE
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones de PowerPoint y OpenDocument con Python. Guía paso a paso con ejemplos de código."
---
## **Antecedentes**

En PowerPoint, usar gráficos editables para mostrar datos de forma gráfica es una práctica habitual. Aspose permite crear gráficos de Excel con Aspose.Cells para Python a través de Java, y estos gráficos pueden incorporarse como objetos OLE en diapositivas de PowerPoint mediante Aspose.Slides para Python a través de Java. Este artículo aborda los pasos necesarios y proporciona un ejemplo de código Python para crear un gráfico de Excel e incrustarlo como objeto OLE en una presentación de PowerPoint usando Aspose.Cells y Aspose.Slides.

## **Pasos requeridos**

La siguiente secuencia de pasos es necesaria para crear e incrustar un gráfico de Excel como objeto OLE en una diapositiva de PowerPoint:

1. Crear un gráfico de Excel con Aspose.Cells.  
1. Establecer el tamaño OLE del gráfico de Excel con Aspose.Cells.  
1. Obtener una imagen del gráfico de Excel con Aspose.Cells.  
1. Incrustar el gráfico de Excel como objeto OLE en una presentación PPTX con Aspose.Slides.  
1. Reemplazar la imagen "EMBEDDED OLE OBJECT" con la imagen obtenida en el paso 3 para solucionar el [problema de vista previa del objeto](/slides/es/python-java/object-preview-issue-when-adding-oleobjectframe/).  
1. Guardar la presentación en disco en formato PPTX.

## **Implementación de los pasos requeridos**

La implementación en Python de los pasos anteriores es la siguiente:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def add_excel_chart_in_workbook(workbook, chart_rows, chart_columns):
    # Una matriz de nombres de celdas.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # Una matriz de datos de celdas.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # Agregar una nueva hoja de cálculo para rellenar celdas con datos.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # Rellenar la hoja de datos con información.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # Agregar una hoja de gráfico.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # Agregar un gráfico a la hoja de gráfico con series de datos de la hoja de datos.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # Establecer la hoja de gráfico como la hoja activa.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # Describir el libro de trabajo como datos OLE incrustados.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# Crear un libro de trabajo.
workbook = Workbook()

# Agregar un gráfico de Excel.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# Establecer el tamaño OLE del gráfico.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# Obtener la imagen del gráfico y guardarla en un flujo.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# Guardar el libro de trabajo en un flujo.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# Crear una presentación.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Agregar el libro de trabajo a una diapositiva.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # Guardar la presentación en disco.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La presentación creada con el método anterior contendrá el gráfico de Excel como objeto OLE que puede activarse haciendo doble clic en el marco del objeto OLE.

## **Conclusión**

Al utilizar Aspose.Cells para Python a través de Java junto con Aspose.Slides para Python a través de Java, podemos crear cualquier gráfico de Excel admitido por Aspose.Cells e incrustarlo como objeto OLE en una diapositiva de PowerPoint. También se puede definir el tamaño OLE del gráfico de Excel. Los usuarios finales pueden editar el gráfico de Excel como cualquier otro objeto OLE.

## **Secciones relacionadas**

- [Solución funcional para el cambio de tamaño de gráficos en PPTX](/slides/es/python-java/working-solution-for-chart-resizing-in-pptx/)  
- [Problema de vista previa del objeto al añadir OleObjectFrame](/slides/es/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **Preguntas frecuentes**

**¿Qué bibliotecas se utilizan para crear e incrustar el gráfico de Excel?**

Aspose.Cells para Python a través de Java crea el gráfico de Excel, y Aspose.Slides para Python a través de Java lo incrusta como objeto OLE en una diapositiva de PowerPoint.

**¿Cómo pueden los usuarios editar el gráfico de Excel incrustado?**

Los usuarios pueden hacer doble clic en el marco del objeto OLE para activar el gráfico y editarlo como cualquier otro objeto OLE.

**¿Cómo se sustituye la vista previa predeterminada del objeto OLE?**

El ejemplo obtiene una imagen del gráfico de Excel con Aspose.Cells y la utiliza para reemplazar la imagen "EMBEDDED OLE OBJECT".