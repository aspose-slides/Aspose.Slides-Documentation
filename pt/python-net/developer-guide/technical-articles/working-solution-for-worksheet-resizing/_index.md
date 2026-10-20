---
title: Solução Funcional para Redimensionamento de Planilha
type: docs
weight: 40
url: /pt/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagem de visualização
- redimensionamento de imagem
- Excel
- planilha
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Corrija o redimensionamento OLE de planilhas do Excel em apresentações: duas maneiras de manter os quadros de objetos consistentes — dimensionar o quadro ou a planilha — nos formatos PPT e PPTX."
---
{{% alert color="info" title="Note" %}}
Planilhas do Excel incorporadas como objetos OLE em uma apresentação do PowerPoint usando componentes Aspose podem redimensionar inesperadamente após a primeira ativação. Esse comportamento cria uma diferença visual perceptível entre o objeto OLE antes e depois da ativação. Este artigo explica o problema e descreve duas maneiras de resolvê‑lo.
{{% /alert %}} 

## **Contexto**

No artigo [Gerenciar OLE](/slides/pt/python-net/manage-ole/), explicamos como adicionar uma moldura OLE a uma apresentação do PowerPoint usando Aspose.Slides for Python via .NET. Para resolver o [problema de visualização do objeto](/slides/pt/python-net/object-preview-issue-when-adding-oleobjectframe/), atribuímos uma imagem da área da planilha selecionada ao quadro do objeto OLE. Na apresentação resultante, ao dar um duplo clique no quadro do objeto OLE que exibe a imagem da planilha, a pasta de trabalho do Excel é ativada. Os usuários finais podem fazer as alterações desejadas na pasta de trabalho real do Excel e, em seguida, retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho do quadro do objeto OLE mudará quando o usuário retornar ao slide. O fator de redimensionamento variará dependendo do tamanho do quadro do objeto OLE e da pasta de trabalho do Excel incorporada. 

## **Causa do Redimensionamento**

Como a pasta de trabalho do Excel possui seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. Por outro lado, o quadro do objeto OLE tem seu próprio tamanho. De acordo com a Microsoft, quando a pasta de trabalho do Excel é ativada, Excel e PowerPoint negociam o tamanho para garantir que ele mantenha as proporções corretas como parte do processo de incorporação. O redimensionamento ocorre com base nas diferenças entre o tamanho da janela do Excel e o tamanho e posição do quadro do objeto OLE. 

## **Solução Funcional**

Existem duas soluções possíveis para evitar o efeito de redimensionamento.

- Redimensionar o quadro OLE na apresentação do PowerPoint para corresponder à altura e largura totais das linhas e colunas selecionadas.
- Manter o tamanho do quadro OLE constante e redimensionar as linhas e colunas selecionadas para que caibam dentro dele.

### **Escalar o Tamanho do Quadro OLE**

Essa abordagem define o tamanho do quadro OLE para corresponder à altura e largura totais das linhas e colunas selecionadas na planilha do Excel incorporada.

O exemplo carrega uma pasta de trabalho do Excel existente e seleciona as primeiras 10 linhas e 13 colunas de sua primeira planilha usando índices baseados em zero. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) define o intervalo exibido. A visualização é renderizada a 96 DPI, e suas dimensões em pixels são convertidas para pontos usando 72 pontos por polegada. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) incorpora a pasta de trabalho modificada em um quadro com essas dimensões. A visualização é atribuída por meio de [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) para substituir o placeholder "EMBEDDED OLE OBJECT" na apresentação salva.

O ajudante de visualização define [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) para o intervalo selecionado e remove margens, cabeçalhos e rodapés. Com [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) habilitado, [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) renderiza o intervalo como uma imagem PNG. O ajudante reposiciona o fluxo de imagem antes de retorná‑lo para uso na apresentação.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

O exemplo completo abaixo combina os ajudantes com a incorporação da pasta de trabalho e salva a apresentação como `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Defina o tamanho exibido quando o arquivo da pasta de trabalho for usado como objeto OLE no PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Obtenha a largura e a altura da imagem OLE em pontos.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Precisamos usar a pasta de trabalho modificada.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Adicione a imagem OLE aos recursos da apresentação.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Crie o quadro do objeto OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Escalar o Tamanho do Intervalo de Células**

Essa abordagem escala as alturas das linhas selecionadas e as larguras das colunas selecionadas para corresponder a um tamanho de quadro OLE personalizado.

O exemplo carrega uma pasta de trabalho do Excel existente e seleciona as primeiras 10 linhas e 13 colunas de sua primeira planilha usando índices baseados em zero. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) define o intervalo exibido, e o ajudante abaixo escala esse intervalo para caber em um quadro de 400 pontos de largura por 100 pontos de altura. Após salvar a pasta de trabalho modificada em um fluxo, [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) a incorpora no tamanho especificado. Uma visualização renderizada a 96 DPI é atribuída por meio de [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/), de modo que a apresentação salva exiba as células selecionadas em vez do placeholder padrão.

O ajudante de dimensionamento calcula razões de largura e altura separadas para o intervalo selecionado, preservando as larguras relativas de suas colunas e as alturas relativas de suas linhas. Converte as dimensões calculadas de pontos para polegadas antes de aplicá‑las com [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) e [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/). O intervalo selecionado deve ter largura e altura diferentes de zero.

```py
import aspose.cells as cells

# <param name="width">A largura esperada do intervalo de células em pontos.</param>
# <param name="height">A altura esperada do intervalo de células em pontos.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```

Este ajudante de visualização renderiza o intervalo redimensionado usando [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/). Ele limita [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) a esse intervalo, remove margens, cabeçalhos e rodapés e devolve um fluxo PNG posicionado no início.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

O exemplo completo abaixo combina os ajudantes com a incorporação da pasta de trabalho e salva a apresentação como `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">A largura esperada do intervalo de células em pontos.</param>
# <param name="height">A altura esperada do intervalo de células em pontos.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Defina o tamanho exibido quando o arquivo da pasta de trabalho for usado como objeto OLE no PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Redimensione o intervalo de células para caber no tamanho da moldura.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Precisamos usar a pasta de trabalho modificada.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Adicione a imagem OLE aos recursos da apresentação.
            ole_image = presentation.images.add_image(image_stream)

            # Crie o quadro do objeto OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Conclusão**

{{% alert color="info" title="Note" %}}
Existem duas abordagens para corrigir o problema de redimensionamento da planilha. Escolha a abordagem que melhor se adapta aos seus requisitos e caso de uso. Ambas as abordagens funcionam da mesma forma, independentemente de as apresentações serem criadas a partir de um modelo ou do zero. Além disso, não há limite para o tamanho do quadro do objeto OLE nesta solução.
{{% /alert %}}

## **Perguntas Frequentes**

**Por que uma planilha do Excel incorporada muda de tamanho quando ativada pela primeira vez no PowerPoint?**

Isso acontece porque o Excel tenta manter o tamanho original da janela ao ser ativado, enquanto o quadro do objeto OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**É possível evitar completamente esse problema de redimensionamento?**

Sim. Redimensionando o quadro OLE para caber no tamanho do intervalo de células do Excel ou dimensionando o intervalo de células para se ajustar ao tamanho desejado do quadro OLE, você pode impedir o redimensionamento indesejado.

**Qual método de dimensionamento devo usar, OLE frame scaling ou cell range scaling?**

Selecione **OLE frame scaling** se você deseja manter os tamanhos originais das linhas e colunas do Excel. Selecione **cell range scaling** se quiser um tamanho fixo para o quadro OLE em sua apresentação.

**Essas soluções funcionam se minha apresentação for baseada em um modelo?**

Sim. Ambas as soluções funcionam para apresentações criadas a partir de modelos e do zero.

**Existe um limite para o tamanho do quadro OLE ao usar esses métodos?**

Não. Você pode definir o quadro do objeto OLE em qualquer tamanho, contanto que ajuste a escala adequadamente.

**Há uma maneira de evitar o texto placeholder "EMBEDDED OLE OBJECT" no PowerPoint?**

Sim. Tirando uma captura do intervalo de células do Excel de destino e definindo‑a como a imagem de placeholder do quadro OLE, você pode exibir uma imagem de visualização personalizada em vez do placeholder padrão.