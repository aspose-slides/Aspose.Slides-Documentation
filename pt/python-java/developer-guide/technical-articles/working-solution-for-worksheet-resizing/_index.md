---
title: Solução Funcional para Redimensionamento de Planilhas
type: docs
weight: 20
url: /pt/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagem de visualização
- redimensionamento de imagem
- Excel
- planilha
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Corrija o redimensionamento de planilhas do Excel OLE em apresentações: duas maneiras de manter os quadros de objetos consistentes—escalar a moldura ou a planilha—nos formatos PPT e PPTX."
---
{{% alert color="info" title="Observação" %}}

Foi observado que planilhas do Excel incorporadas como objetos OLE em uma apresentação do PowerPoint através dos componentes Aspose são redimensionadas para uma escala não especificada após a primeira ativação. Esse comportamento cria uma diferença visual notável na apresentação entre os estados antes e depois da ativação do objeto OLE. Investigamos esse problema em detalhes e fornecemos uma solução, que está descrita neste artigo.

{{% /alert %}}

## **Contexto**

No artigo [Gerenciar OLE](/slides/pt/python-java/manage-ole/), explicamos como adicionar uma moldura OLE a uma apresentação do PowerPoint usando Aspose.Slides para Python via Java. Para resolver o [problema de visualização do objeto](/slides/pt/python-java/object-preview-issue-when-adding-oleobjectframe/), atribuimos uma imagem da área da planilha selecionada à moldura do objeto OLE. Na apresentação resultante, ao clicar duas vezes na moldura do objeto OLE que exibe a imagem da planilha, a pasta de trabalho do Excel é ativada. Os usuários finais podem fazer as alterações desejadas na pasta de trabalho real do Excel e, em seguida, retornar ao slide clicando fora da pasta de trabalho do Excel ativada. O tamanho da moldura do objeto OLE mudará quando o usuário retornar ao slide. O fator de redimensionamento variará dependendo do tamanho da moldura do objeto OLE e da pasta de trabalho do Excel incorporada.

## **Causa do Redimensionamento**

Como a pasta de trabalho do Excel tem seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. Por outro lado, a moldura do objeto OLE tem seu próprio tamanho. De acordo com a Microsoft, quando a pasta de trabalho do Excel é ativada, o Excel e o PowerPoint negociam o tamanho para garantir que ele mantenha as proporções corretas como parte do processo de incorporação. O redimensionamento ocorre com base nas diferenças entre o tamanho da janela do Excel e o tamanho e a posição da moldura do objeto OLE.

## **Solução Funcional**

Existem duas soluções possíveis para evitar o efeito de redimensionamento.

- Redimensionar o tamanho da moldura OLE na apresentação do PowerPoint para corresponder à altura e largura do número desejado de linhas e colunas na moldura OLE.
- Manter o tamanho da moldura OLE constante e redimensionar o tamanho das linhas e colunas participantes para caber dentro do tamanho da moldura OLE selecionada.

### **Dimensionar o Tamanho da Moldura OLE**

Nesta abordagem, aprenderemos como definir o tamanho da moldura OLE da pasta de trabalho do Excel incorporada para corresponder ao tamanho cumulativo das linhas e colunas participantes na planilha do Excel.

Suponha que tenhamos uma planilha Excel modelo e desejamos adicioná‑la a uma apresentação como uma moldura OLE. Neste cenário, o tamanho da moldura do objeto OLE será primeiro calculado com base nas alturas cumulativas das linhas e larguras das colunas das linhas e colunas participantes na pasta de trabalho. Em seguida, definiremos o tamanho da moldura OLE para esse valor calculado. Para evitar a mensagem vermelha "EMBEDDED OLE OBJECT" da moldura OLE no PowerPoint, também capturaremos uma imagem das porções desejadas das linhas e colunas na pasta de trabalho e a definiremos como imagem da moldura OLE.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Defina o tamanho exibido quando a pasta de trabalho for usada como um objeto OLE no PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Obtenha a largura e a altura da imagem OLE em pontos.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Use a pasta de trabalho modificada.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Adicione a imagem OLE aos recursos da apresentação.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Crie a moldura do objeto OLE.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **Dimensionar o Tamanho do Intervalo de Células**

Nesta abordagem, aprenderemos como dimensionar as alturas das linhas participantes e as larguras das colunas participantes para corresponder a um tamanho customizado da moldura OLE.

Suponha que tenhamos uma planilha Excel modelo e desejamos adicioná‑la a uma apresentação como uma moldura OLE. Neste cenário, definiremos o tamanho da moldura OLE e dimensionaremos o tamanho das linhas e colunas que participam da área da moldura OLE. Em seguida, salvaremos a pasta de trabalho em um stream para aplicar as alterações e convertê‑la em um array de bytes para adicioná‑la à moldura OLE. Para evitar a mensagem vermelha "EMBEDDED OLE OBJECT" da moldura OLE no PowerPoint, também capturaremos uma imagem das porções desejadas das linhas e colunas na pasta de trabalho e a definiremos como imagem da moldura OLE.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # A largura e a altura esperadas do intervalo de células estão em pontos.
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Defina o tamanho exibido quando a pasta de trabalho for usada como um objeto OLE no PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Dimensione o intervalo de células para caber no tamanho da moldura.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Use a pasta de trabalho modificada.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Adicione a imagem OLE aos recursos da apresentação.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Crie a moldura do objeto OLE.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **Conclusão**

{{% alert color="info" title="Observação" %}} 

Existem duas abordagens para corrigir o problema de redimensionamento da planilha. A escolha da abordagem apropriada depende dos requisitos específicos e do caso de uso. Ambas as abordagens funcionam da mesma forma, independentemente de as apresentações serem criadas a partir de um modelo ou do zero. Além disso, não há limite para o tamanho da moldura do objeto OLE nesta solução.

{{% /alert %}}

## **FAQ**

**Por que uma planilha do Excel incorporada altera o tamanho na primeira ativação no PowerPoint?**

Isso ocorre porque o Excel tenta manter o tamanho original da janela ao ser ativado, enquanto a moldura do objeto OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**É possível evitar completamente esse problema de redimensionamento?**

Sim. Redimensionando a moldura OLE para caber no tamanho do intervalo de células do Excel ou dimensionando o intervalo de células para caber no tamanho desejado da moldura OLE, você pode evitar o redimensionamento indesejado.

**Qual método de dimensionamento devo usar, dimensionamento da moldura OLE ou dimensionamento do intervalo de células?**

Selecione **OLE frame scaling** se quiser manter os tamanhos originais das linhas e colunas do Excel. Selecione **cell range scaling** se desejar um tamanho fixo para a moldura OLE na sua apresentação.

**Essas soluções funcionarão se minha apresentação for baseada em um modelo?**

Sim. Ambas as soluções funcionam para apresentações criadas a partir de modelos e do zero.

**Existe um limite para o tamanho da moldura OLE ao usar esses métodos?**

Não. Você pode definir a moldura do objeto OLE em qualquer tamanho, desde que ajuste a escala adequadamente.

**Existe uma maneira de evitar o texto de espaço reservado “EMBEDDED OLE OBJECT” no PowerPoint?**

Sim. Capturando uma captura de tela do intervalo de células do Excel de destino e configurando‑a como a imagem de espaço reservado da moldura OLE, você pode exibir uma imagem de pré‑visualização personalizada no lugar do espaço reservado padrão.

## **Artigos Relacionados**

[Criando um Gráfico do Excel e Incorporando‑o em uma Apresentação como um Objeto OLE](/slides/pt/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)