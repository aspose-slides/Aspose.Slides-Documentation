---
title: "Gerenciar Células de Tabela em Apresentações Usando Python"
linktitle: "Gerenciar Células"
type: docs
weight: 30
url: /pt/python-java/manage-cells/
keywords:
  - "célula de tabela"
  - "mesclar células"
  - "remover borda"
  - "dividir célula"
  - "imagem na célula"
  - "cor de fundo"
  - "PowerPoint"
  - "apresentação"
  - "Python"
  - "Aspose.Slides"
description: "Gerencie facilmente células de tabela no PowerPoint com Aspose.Slides para Python via Java. Domine o acesso, modificação e estilo de células rapidamente para automação de slides sem interrupções."
---
## **Visão geral**

Aspose.Slides permite acessar e modificar células de tabela em apresentações do PowerPoint. Este artigo explica como identificar células de tabela mescladas, remover bordas de células, trabalhar com a numeração de células após mesclar ou dividir células, alterar a cor de fundo de uma célula e adicionar uma imagem dentro de uma célula de tabela. Os exemplos mostram como criar ou abrir uma apresentação, obter uma tabela de um slide, atualizar a formatação das células por meio das propriedades das células e salvar a apresentação modificada como um arquivo PPTX.

## **Identificar uma Célula de Tabela Mesclada**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Obtenha a tabela do primeiro slide.
3. Percorra as linhas e colunas da tabela para encontrar células mescladas.
4. Exiba uma mensagem quando células mescladas forem encontradas.

Este código Python mostra como identificar células de tabela mescladas em uma apresentação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpuel.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # Presuma que a primeira forma no primeiro slide seja uma tabela.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Remover Bordas de Células da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Defina uma lista de larguras de colunas.
4. Defina uma lista de alturas de linhas.
5. Adicione uma tabela ao slide usando o método [addTable](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addTable).
6. Percorra cada célula para limpar as bordas superior, inferior, direita e esquerda.
7. Salve a apresentação modificada como um arquivo PPTX.

Este código Python mostra como remover as bordas das células da tabela:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # Acesse o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Defina as larguras das colunas e as alturas das linhas.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Adicione uma tabela ao slide.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Defina o formato da borda para cada célula.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # Salve a apresentação como um arquivo PPTX.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numeração em Células Mescladas**

Se mesclarmos dois pares de células, (1, 1) e (2, 1), e (1, 2) e (2, 2), a tabela resultante mantém a numeração das células. Este código Python demonstra o processo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Acesse o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Defina as larguras das colunas e as alturas das linhas.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Adicione uma tabela ao slide.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Defina o formato da borda para cada célula.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Mescle as células (1, 1) e (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Mescle as células (1, 2) e (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Salve a apresentação como um arquivo PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Em seguida, mesclamos ainda mais as células, mesclando (1, 1) e (1, 2). O resultado é uma tabela contendo uma grande célula mesclada no centro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Acesse o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Defina as larguras das colunas e as alturas das linhas.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Adicione uma tabela ao slide.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Defina o formato da borda para cada célula.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Mescle as células (1, 1) e (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Mescle as células (1, 2) e (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Mescle as células (1, 1) e (1, 2).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # Salve a apresentação como um arquivo PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numeração em uma Célula Dividida**

Nos exemplos anteriores, mesclar células da tabela não alterou a numeração das demais células.

Desta vez, pegamos uma tabela regular (uma tabela sem células mescladas) e então tentamos dividir a célula (1, 1) para obter uma tabela especial. Você pode querer prestar atenção à numeração desta tabela, que pode parecer estranha. No entanto, essa é a forma como o Microsoft PowerPoint numera as células de tabela e o Aspose.Slides faz o mesmo.

Este código Python demonstra o processo que descrevemos:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Acesse o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Defina as larguras das colunas e as alturas das linhas.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Adicione uma tabela ao slide.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Defina o formato da borda para cada célula.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Divida a célula (1, 1).
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # Salve a apresentação como um arquivo PPTX.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Alterar a Cor de Fundo da Célula da Tabela**

Este código Python mostra como alterar a cor de fundo de uma célula de tabela:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Acesse o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Defina as larguras das colunas e as alturas das linhas.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Adicione uma tabela ao slide.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Defina a cor de fundo para uma célula.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Salve a apresentação como um arquivo PPTX.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Adicionar uma Imagem Dentro de uma Célula de Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Defina uma lista de larguras de colunas.
4. Defina uma lista de alturas de linhas.
5. Adicione uma tabela ao slide usando o método [addTable](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addTable).
6. Carregue o arquivo de imagem usando [Images.fromFile](https://reference.aspose.com/slides/pt/python-java/aspose.slides/images/#fromFile).
7. Adicione a imagem à apresentação para criar um objeto [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/).
8. Defina o tipo de preenchimento da [FillFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fillformat/) da célula da tabela como [FillType.Picture](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filltype/#Picture).
9. Adicione a imagem à primeira célula da tabela.
10. Salve a apresentação modificada como um arquivo PPTX.

Este código Python mostra como colocar uma imagem dentro de uma célula de tabela ao criar uma tabela:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # Acesse o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Defina as larguras das colunas e as alturas das linhas.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # Adicione uma tabela ao slide.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Crie uma imagem da apresentação a partir do arquivo de imagem.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Adicione a imagem à primeira célula da tabela.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Salve a apresentação como um arquivo PPTX.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso definir espessuras e estilos de linha diferentes para os lados de uma única célula?**

Sim. As bordas [top](https://reference.aspose.com/slides/pt/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/pt/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/pt/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/pt/python-java/aspose.slides/cellformat/#getBorderRight) têm propriedades separadas, portanto a espessura e o estilo de cada lado podem ser diferentes. Isso decorre logicamente do controle de bordas por lado para uma célula demonstrado no artigo.

**O que acontece com a imagem se eu alterar o tamanho da coluna/linha após definir uma imagem como plano de fundo da célula?**

O comportamento depende do [fill mode](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillmode/) (stretch/tile). Com o redimensionamento, a imagem se ajusta à nova célula; com o modo de ladrilho, os ladrilhos são recalculados. O artigo menciona os modos de exibição de imagem em uma célula.

**Posso atribuir um hyperlink a todo o conteúdo de uma célula?**

[Hyperlinks](/slides/pt/python-java/manage-hyperlinks/) são definidos no nível do texto (porção) dentro da moldura de texto da célula ou no nível de toda a tabela/forma. Na prática, você atribui o link a uma porção ou a todo o texto da célula.

**Posso definir fontes diferentes dentro de uma única célula?**

Sim. A moldura de texto de uma célula suporta [portions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/) (trechos) com formatação independente — família de fonte, estilo, tamanho e cor.