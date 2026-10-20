---
title: Solução Funcional para Redimensionamento de Planilha
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
description: "Corrija o redimensionamento de OLE de planilhas do Excel em apresentações: duas maneiras de manter as molduras de objetos consistentes—dimensionando a moldura ou a planilha—nos formatos PPT e PPTX."
---
{{% alert color="info" title="Note" %}}

Planilhas do Excel incorporadas como objetos OLE em uma apresentação do PowerPoint usando componentes Aspose podem redimensionar inesperadamente após sua primeira ativação. Esse comportamento cria uma diferença visual perceptível entre o objeto OLE antes e depois da ativação. Este artigo explica o problema e descreve duas maneiras de resolvê‑lo.

{{% /alert %}}

## **Contexto**

No artigo [Gerenciar OLE](/slides/pt/python-java/manage-ole/), explicamos como adicionar uma moldura OLE a uma apresentação do PowerPoint usando Aspose.Slides para Python via Java. Para resolver o [problema de visualização do objeto](/slides/pt/python-java/object-preview-issue-when-adding-oleobjectframe/), atribuimos uma imagem da área da planilha selecionada à moldura do objeto OLE. Na apresentação resultante, ao clicar duas vezes na moldura do objeto OLE que exibe a imagem da planilha, a pasta de trabalho do Excel é ativada. Os usuários finais podem fazer quaisquer alterações desejadas na pasta de trabalho real do Excel e, em seguida, retornar ao slide clicando fora da pasta de trabalho do Excel ativada. O tamanho da moldura do objeto OLE mudará quando o usuário retornar ao slide. O fator de redimensionamento variará dependendo do tamanho da moldura do objeto OLE e da pasta de trabalho do Excel incorporada.

## **Causa do Redimensionamento**

Como a pasta de trabalho do Excel possui seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. Por outro lado, a moldura do objeto OLE tem seu próprio tamanho. De acordo com a Microsoft, quando a pasta de trabalho do Excel é ativada, o Excel e o PowerPoint negociam o tamanho para garantir que ele mantenha as proporções corretas como parte do processo de incorporação. O redimensionamento ocorre com base nas diferenças entre o tamanho da janela do Excel e o tamanho e posição da moldura do objeto OLE.

## **Solução Funcional**

Existem duas soluções possíveis para evitar o efeito de redimensionamento.

- Dimensionar a moldura OLE na apresentação do PowerPoint para corresponder à altura e largura totais das linhas e colunas selecionadas.
- Manter o tamanho da moldura OLE constante e dimensionar as linhas e colunas selecionadas para caber dentro dela.

### **Dimensionar o Tamanho da Moldura OLE**

Essa abordagem define o tamanho da moldura OLE para corresponder à altura e largura totais das linhas e colunas selecionadas na planilha do Excel incorporada.

O exemplo carrega uma pasta de trabalho do Excel existente e seleciona as primeiras 10 linhas e 13 colunas da sua primeira planilha usando índices baseados em zero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) define a faixa exibida. A visualização é renderizada a 96 DPI, e suas dimensões em pixels são convertidas para pontos usando 72 pontos por polegada. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) incorpora a pasta de trabalho modificada em uma moldura com essas dimensões. A visualização é atribuída por meio de [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) para substituir o marcador de posição "EMBEDDED OLE OBJECT" na apresentação salva.

O auxílio de visualização define [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) para a faixa selecionada e remove margens, cabeçalhos e rodapés. Com [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) habilitado, [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) renderiza a faixa como uma imagem PNG. O auxílio devolve um novo fluxo de entrada contendo a imagem PNG, posicionado no início para uso na apresentação.

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

### **Dimensionar o Tamanho da Faixa de Células**

Essa abordagem dimensiona as alturas das linhas selecionadas e as larguras das colunas selecionadas para corresponder a um tamanho de moldura OLE personalizado.

O exemplo carrega uma pasta de trabalho do Excel existente e seleciona as primeiras 10 linhas e 13 colunas da sua primeira planilha usando índices baseados em zero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) define a faixa exibida, e o auxílio scale_cell_range dimensiona essa faixa para caber em uma moldura de 400 pontos de largura por 100 pontos de altura. Após salvar a pasta de trabalho modificada em um fluxo, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) a incorpora no tamanho especificado. Uma visualização renderizada a 96 DPI é atribuída por meio de [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), de modo que a apresentação salva exiba as células selecionadas em vez do marcador de posição padrão.

O auxílio de dimensionamento calcula razões de largura e altura separadas para a faixa selecionada, preservando as larguras relativas de suas colunas e as alturas relativas de suas linhas. Ele converte as dimensões calculadas de pontos para polegadas antes de aplicá‑las com [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) e [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch). A faixa selecionada deve ter largura e altura diferentes de zero.

Esse auxílio de visualização renderiza a faixa redimensionada usando [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage). Ele limita [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) a essa faixa, remove margens, cabeçalhos e rodapés, e devolve um fluxo PNG posicionado no início.

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
    # A largura e altura esperadas da faixa de células estão em pontos.
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
    # Dimensione a faixa de células para caber no tamanho da moldura.
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

{{% alert color="info" title="Note" %}} 

Existem duas abordagens para corrigir o problema de redimensionamento da planilha. Escolha a abordagem que melhor se adapta aos seus requisitos e caso de uso. Ambas as abordagens funcionam da mesma forma, tanto se as apresentações forem criadas a partir de um modelo quanto do zero. Além disso, não há limite para o tamanho da moldura do objeto OLE nesta solução.

{{% /alert %}}

## **Perguntas Frequentes**

**Por que uma planilha do Excel incorporada altera o tamanho quando é ativada pela primeira vez no PowerPoint?**

Isso ocorre porque o Excel tenta manter o tamanho original da janela ao ser ativado, enquanto a moldura do objeto OLE no PowerPoint possui suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**É possível impedir totalmente esse problema de redimensionamento?**

Sim. Dimensionando a moldura OLE para caber no tamanho da faixa de células do Excel ou dimensionando a faixa de células para caber no tamanho desejado da moldura OLE, você pode evitar o redimensionamento indesejado.

**Qual método de dimensionamento devo usar, dimensionamento da moldura OLE ou dimensionamento da faixa de células?**

Selecione **dimensionamento da moldura OLE** se desejar manter os tamanhos originais das linhas e colunas do Excel. Selecione **dimensionamento da faixa de células** se quiser um tamanho fixo para a moldura OLE em sua apresentação.

**Essas soluções funcionarão se minha apresentação for baseada em um modelo?**

Sim. Ambas as soluções funcionam para apresentações criadas a partir de modelos e do zero.

**Existe um limite para o tamanho da moldura OLE ao usar esses métodos?**

Não. Você pode definir a moldura do objeto OLE em qualquer tamanho, desde que ajuste a escala adequadamente.

**Existe uma maneira de evitar o texto de marcador de posição "EMBEDDED OLE OBJECT" no PowerPoint?**

Sim. Capturando uma imagem da faixa de células do Excel alvo e definindo‑a como a imagem de marcador de posição da moldura OLE, você pode exibir uma imagem de visualização personalizada no lugar do marcador de posição padrão.

## **Artigos Relacionados**

[Criando um Gráfico do Excel e Incorporando‑lo em uma Apresentação como um Objeto OLE](/slides/pt/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Atualizando Objetos OLE Automaticamente Usando um Complemento do MS PowerPoint](/slides/pt/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)