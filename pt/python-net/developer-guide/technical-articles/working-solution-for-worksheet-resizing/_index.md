---
title: Solução Funcional para Redimensionamento de Planilhas
type: docs
weight: 40
url: /pt/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagem de pré-visualização
- redimensionamento de imagem
- Excel
- planilha
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Corrija o redimensionamento de OLE de planilhas do Excel em apresentações: duas maneiras de manter as molduras de objetos consistentes — escale a moldura ou a planilha — nos formatos PPT e PPTX."
---
{{% alert color="primary" %}} 

Foi observado que planilhas do Excel incorporadas como objetos OLE em uma apresentação do PowerPoint por meio dos componentes Aspose são redimensionadas para uma escala não identificada após a primeira ativação. Esse comportamento cria uma diferença visual perceptível na apresentação entre os estados pré‑ e pós‑ativação do objeto OLE. Investigamos esse problema em detalhes e fornecemos uma solução, que é abordada neste artigo.

{{% /alert %}} 

## **Contexto**

No artigo [Gerenciar OLE](/slides/pt/python-net/manage-ole/), explicamos como adicionar uma moldura OLE a uma apresentação do PowerPoint usando Aspose.Slides for Python via .NET. Para resolver o [problema de visualização do objeto](/slides/pt/python-net/object-preview-issue-when-adding-oleobjectframe/), atribuímos uma imagem da área da planilha selecionada à moldura do objeto OLE. Na apresentação resultante, ao clicar duas vezes na moldura do objeto OLE que exibe a imagem da planilha, a pasta de trabalho do Excel é ativada. Os usuários podem fazer quaisquer alterações desejadas na pasta de trabalho real do Excel e, em seguida, retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho da moldura do objeto OLE mudará quando o usuário retornar ao slide. O fator de redimensionamento variará dependendo do tamanho da moldura do objeto OLE e da pasta de trabalho do Excel incorporada. 

## **Causa do Redimensionamento**

Como a pasta de trabalho do Excel possui seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. Por outro lado, a moldura do objeto OLE tem seu próprio tamanho. Segundo a Microsoft, quando a pasta de trabalho do Excel é ativada, Excel e PowerPoint negociam o tamanho para garantir que as proporções corretas sejam mantidas como parte do processo de incorporação. O redimensionamento ocorre com base nas diferenças entre o tamanho da janela do Excel e o tamanho e posição da moldura do objeto OLE.

## **Solução Funcional**

Existem duas soluções possíveis para evitar o efeito de redimensionamento.

- Dimensionar o tamanho da moldura OLE na apresentação do PowerPoint para corresponder à altura e largura do número desejado de linhas e colunas na moldura OLE.
- Manter o tamanho da moldura OLE constante e dimensionar o tamanho das linhas e colunas participantes para que caibam dentro do tamanho da moldura OLE selecionada.

### **Dimensionar o Tamanho da Moldura OLE**

Nesta abordagem, aprenderemos como definir o tamanho da moldura OLE da pasta de trabalho do Excel incorporada para corresponder ao tamanho cumulativo das linhas e colunas participantes na planilha do Excel.

Suponha que tenhamos uma planilha modelo do Excel e queiramos adicioná‑la a uma apresentação como uma moldura OLE. Nesse cenário, o tamanho da moldura do objeto OLE será primeiro calculado com base nas alturas cumulativas das linhas e nas larguras cumulativas das colunas participantes na pasta de trabalho. Em seguida, definiremos o tamanho da moldura OLE para esse valor calculado. Para evitar a mensagem vermelha “EMBEDDED OLE OBJECT” para a moldura OLE no PowerPoint, também capturaremos uma imagem das partes desejadas das linhas e colunas na pasta de trabalho e a definiremos como imagem da moldura OLE.

```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Definir o tamanho exibido quando o arquivo da pasta de trabalho é usado como objeto OLE no PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Obter a largura e altura da imagem OLE em pontos.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Precisamos usar a pasta de trabalho modificada.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Adicionar a imagem OLE aos recursos da apresentação.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Criar a moldura do objeto OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Dimensionar o Tamanho da Faixa de Células**

Nesta abordagem, aprenderemos como dimensionar as alturas das linhas participantes e a largura das colunas participantes para corresponder a um tamanho de moldura OLE personalizado.

Suponha que tenhamos uma planilha modelo do Excel e queiramos adicioná‑la a uma apresentação como uma moldura OLE. Nesse cenário, definiremos o tamanho da moldura OLE e dimensionaremos o tamanho das linhas e colunas que participam da área da moldura OLE. Em seguida, salvaremos a pasta de trabalho em um stream para aplicar as alterações e convertê‑la em um array de bytes para adicioná‑la à moldura OLE. Para evitar a mensagem vermelha “EMBEDDED OLE OBJECT” para a moldura OLE no PowerPoint, também capturaremos uma imagem das partes desejadas das linhas e colunas na pasta de trabalho e a definiremos como imagem da moldura OLE.

```py
# <param name="width">A largura esperada da faixa de células em pontos.</param>
# <param name="height">A altura esperada da faixa de células em pontos.</param>
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

```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Definir o tamanho exibido quando o arquivo da pasta de trabalho é usado como objeto OLE no PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Dimensionar a faixa de células para se ajustar ao tamanho da moldura.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Precisamos usar a pasta de trabalho modificada.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Adicionar a imagem OLE aos recursos da apresentação.
            ole_image = presentation.images.add_image(image_stream)

            # Criar a moldura do objeto OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Conclusão**

{{% alert color="primary" %}}

Existem duas abordagens para corrigir o problema de redimensionamento da planilha. A escolha da abordagem adequada depende dos requisitos específicos e do caso de uso. Ambas as abordagens funcionam da mesma forma, seja quando as apresentações são criadas a partir de um modelo ou do zero. Além disso, não há limite para o tamanho da moldura do objeto OLE nesta solução.

{{% /alert %}}