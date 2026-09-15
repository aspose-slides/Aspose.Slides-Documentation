---
title: Criar Gráficos do Excel e Incorporá-los em Apresentações como Objetos OLE
type: docs
weight: 30
url: /pt/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- gráfico do Excel
- incorporar gráfico
- objeto OLE
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Crie gráficos do Excel e incorpore-os como objetos OLE em apresentações PowerPoint e OpenDocument com Python. Guia passo a passo com exemplos de código."
---
## **Contexto**

No PowerPoint, usar gráficos editáveis para exibir dados graficamente é uma prática comum. O Aspose oferece suporte à criação de gráficos do Excel com Aspose.Cells for Python via Java, e esses gráficos podem ser incorporados como objetos OLE em slides do PowerPoint através do Aspose.Slides for Python via Java. Este artigo aborda as etapas necessárias e fornece um exemplo de código Python para criar um gráfico do Excel e incorporá‑lo como objeto OLE em uma apresentação PowerPoint usando Aspose.Cells e Aspose.Slides.

## **Etapas Necessárias**

A sequência de etapas a seguir é necessária para criar e incorporar um gráfico do Excel como objeto OLE em um slide do PowerPoint:

1. Criar um gráfico do Excel usando Aspose.Cells.
1. Definir o tamanho OLE do gráfico do Excel usando Aspose.Cells.
1. Obter uma imagem do gráfico do Excel com Aspose.Cells.
1. Incorporar o gráfico do Excel como objeto OLE em uma apresentação PPTX usando Aspose.Slides.
1. Substituir a imagem "EMBEDDED OLE OBJECT" pela imagem obtida na etapa 3 para resolver o [problema de visualização do objeto](/slides/pt/python-java/object-preview-issue-when-adding-oleobjectframe/).
1. Salvar a apresentação no disco no formato PPTX.

## **Implementação das Etapas Necessárias**

A implementação em Python das etapas acima é a seguinte:

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
    # Uma matriz de nomes de células.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # Uma matriz de dados de células.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # Adicionar uma nova planilha para preencher células com dados.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # Preencher a planilha de dados com valores.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # Adicionar uma planilha de gráfico.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # Adicionar um gráfico à planilha de gráfico com séries de dados da planilha de dados.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # Definir a planilha de gráfico como a planilha ativa.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # Descrever a pasta de trabalho como dados OLE incorporados.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# Criar uma pasta de trabalho.
workbook = Workbook()

# Adicionar um gráfico do Excel.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# Definir o tamanho OLE do gráfico.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# Obter a imagem do gráfico e salvá‑la em um fluxo.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# Salvar a pasta de trabalho em um fluxo.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# Criar uma apresentação.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Adicionar a pasta de trabalho a um slide.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # Salvar a apresentação no disco.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A apresentação criada pelo método acima conterá o gráfico do Excel como objeto OLE que pode ser ativado ao dar duplo‑clique no quadro do objeto OLE.

## **Conclusão**

Usando Aspose.Cells for Python via Java juntamente com Aspose.Slides for Python via Java, podemos criar qualquer gráfico do Excel suportado pelo Aspose.Cells e incorporá‑lo como objeto OLE em um slide do PowerPoint. O tamanho OLE do gráfico do Excel também pode ser definido. Os usuários finais podem então editar o gráfico do Excel como qualquer outro objeto OLE.

## **Seções Relacionadas**

- [Solução Funcional para Redimensionamento de Gráficos em PPTX](/slides/pt/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Problema de Visualização de Objeto ao Adicionar OleObjectFrame](/slides/pt/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **FAQ**

**Quais bibliotecas são usadas para criar e incorporar o gráfico do Excel?**

Aspose.Cells for Python via Java cria o gráfico do Excel, e Aspose.Slides for Python via Java o incorpora como objeto OLE em um slide do PowerPoint.

**Como os usuários podem editar o gráfico do Excel incorporado?**

Os usuários podem dar duplo‑clique no quadro do objeto OLE para ativar o gráfico e editá‑lo como qualquer outro objeto OLE.

**Como a visualização padrão do objeto OLE é substituída?**

O exemplo obtém uma imagem do gráfico do Excel com Aspose.Cells e a usa para substituir a imagem "EMBEDDED OLE OBJECT".