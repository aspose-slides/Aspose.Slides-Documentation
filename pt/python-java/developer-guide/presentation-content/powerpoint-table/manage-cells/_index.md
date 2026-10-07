---
title: Gerenciar Células de Tabela em Apresentações Usando Python
linktitle: Gerenciar Células
type: docs
weight: 30
url: /pt/python-java/manage-cells/
keywords:
- célula de tabela
- mesclar células
- remover borda
- dividir célula
- imagem na célula
- cor de fundo
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Gerencie células de tabela do PowerPoint em Python: identifique células mescladas, remova bordas, divida células e defina cores de fundo e imagens com Aspose.Slides para Python via Java."
---
## **Visão geral**

Aspose.Slides permite que você acesse e modifique células de tabela em apresentações do PowerPoint. Este artigo explica como identificar células de tabela mescladas, remover bordas de célula, trabalhar com a numeração de células após mesclar ou dividir células, alterar a cor de fundo de uma célula e adicionar uma imagem dentro de uma célula de tabela. Os exemplos mostram como criar ou abrir uma apresentação, obter uma tabela de um slide, atualizar a formatação da célula por meio das propriedades da célula e salvar a apresentação modificada como um arquivo PPTX.

Aspose.Slides usa índices baseados em zero para acessar células de tabela na ordem `(coluna, linha)`.

## **Identificar uma Célula de Tabela Mesclada**

O exemplo abre uma apresentação existente e acessa a primeira forma no primeiro slide como uma tabela. Ele pressupõe que o slide e a forma existam e que a forma seja uma tabela. Em seguida, itera por todas as linhas e colunas e usa [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) para identificar células em regiões mescladas. Para cada correspondência, imprime as coordenadas da célula na ordem `linha;coluna`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) e as coordenadas iniciais da região, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) e [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **Remover Bordas de Células da Tabela**

Crie uma [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) e adicione uma tabela ao seu primeiro slide com [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). As larguras das colunas, alturas das linhas e a posição da tabela são especificadas em pontos. O exemplo define todas as quatro bordas da célula como [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), tornando-as invisíveis.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mesclar Células da Tabela**

Use [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) para combinar um intervalo retangular de células de tabela em uma única célula. Especifique as células nos cantos superior esquerdo e inferior direito do intervalo. O argumento final controla se a mesclagem pode incluir células fora do intervalo especificado; `False` mantém a mesclagem dentro desse intervalo.

O exemplo cria uma tabela de 4 por 4 com colunas e linhas de 70 pontos, então mescla as quatro células centrais de `(1, 1)` até `(2, 2)`. A célula resultante abrange duas colunas e duas linhas, enquanto a grade subjacente da tabela permanece com quatro colunas e quatro linhas. Para acessar o conteúdo ou a formatação da célula mesclada, use sua posição superior esquerda: `table.get_Item(1, 1)` neste exemplo. As outras posições no intervalo mesclado permanecem parte da grade da tabela, de modo que os índices das células fora do intervalo não mudam.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dividir Células da Tabela**

Mesclar células no exemplo anterior preserva a grade da tabela. Dividir uma célula pode introduzir uma nova coluna na grade e alterar os índices de coluna das células à sua direita. Aspose.Slides segue o modelo de grade de tabela do PowerPoint.

Este exemplo cria uma tabela de 4 por 4 com colunas e linhas de 70 pontos e chama [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) na célula `(1, 1)`. Metade da largura de 70 pontos da célula é usada para criar duas células de largura igual.

Após essa divisão, as duas metades são acessadas como `table.get_Item(1, 1)` e `table.get_Item(2, 1)`. A grade da tabela agora tem cinco colunas: células originalmente nas colunas 2 e 3 mudam para as colunas 3 e 4, respectivamente. Os índices de linha permanecem inalterados. Use esses índices de coluna atualizados ao acessar células após a divisão.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Dividir Células Mescladas por Intervalo de Linha ou Coluna**

Para preparar células de modelo mescladas para preenchimento de dados, use [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) para dividir ao longo de uma borda de linha existente, ou [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) para dividir ao longo de uma borda de coluna.

O argumento `index` conta linhas na parte superior ou colunas na parte esquerda da divisão; ele é relativo à região mesclada:

- Divisão de linha: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Divisão de coluna: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

O exemplo pressupõe que uma apresentação tenha uma tabela como a primeira forma no primeiro slide, com `(1, 2)` e `(1, 3)` mesclados verticalmente. Começando a partir da posição inferior, ele usa [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) e [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) para localizar a origem e verifica ambos os intervalos. `splitByRowSpan(1)` então separa as linhas 2 e 3 para os nomes dos produtos. Para uma mesclagem horizontal de duas colunas, use `splitByColSpan(1)`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # Recuperar as células resultantes da tabela após a divisão.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

A grade da tabela e os índices das células ao redor permanecem inalterados. Recupere as células resultantes por suas coordenadas; aqui, ambas têm intervalos de 1 e [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) imprime `False`. Regiões maiores podem permanecer parcialmente mescladas após uma divisão.

O texto original e sua formatação permanecem na célula superior (ou esquerda); a nova célula está vazia, mas herda a formatação da célula, como preenchimento, bordas e margens. Popule as células após a divisão e defina explicitamente qualquer formatação de texto necessária.

A apresentação salva contém células separadas "Product A" e "Product B" com a formatação da célula do modelo mantida. Consulte a [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) para obter detalhes.

## **Alterar a Cor de Fundo da Célula da Tabela**

Este exemplo cria uma tabela com colunas de 150 pontos e linhas de 50 pontos. Ele usa [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) para selecionar um preenchimento sólido e define a cor retornada por [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) como vermelho para a célula `(2, 3)`, na terceira coluna e quarta linha.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Adicionar uma Imagem Dentro de uma Célula de Tabela**

Coloque a imagem de entrada no diretório de trabalho antes de executar este exemplo. Ele carrega a imagem com [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) e a adiciona à coleção de imagens da apresentação com [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Em seguida, atribui a imagem ao preenchimento de imagem da célula `(0, 0)`, a primeira célula da tabela.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) estica a imagem para preencher a célula, o que pode alterar sua proporção. As larguras das colunas e as alturas das linhas estão em pontos. A imagem carregada é descartada em um bloco `finally` após ser adicionada à apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas Frequentes**

**Posso definir diferentes espessuras e estilos de linha para diferentes lados de uma única célula?**

Sim. As bordas [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) possuem propriedades separadas, de modo que a espessura e o estilo de cada lado podem ser diferentes.

**O que acontece com a imagem se eu alterar o tamanho da coluna/linha depois de definir uma imagem como plano de fundo da célula?**

O comportamento depende do [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). Com esticamento, a imagem se ajusta à nova célula; com mosaico, os blocos são recalculados.

**Posso atribuir um hyperlink a todo o conteúdo de uma célula?**

[Hyperlinks](/slides/pt/python-java/manage-hyperlinks/) são definidos no nível do texto (porção) dentro do quadro de texto da célula ou no nível de toda a tabela/forma. Na prática, você atribui o link a uma porção ou a todo o texto da célula.

**Posso definir fontes diferentes dentro de uma única célula?**

Sim. O quadro de texto de uma célula suporta [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (execuções) com formatação independente — família da fonte, estilo, tamanho e cor.