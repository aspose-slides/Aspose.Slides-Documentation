---
title: Gerenciar Tabelas de Apresentação em Python
linktitle: Gerenciar Tabela
type: docs
weight: 10
url: /pt/python-java/manage-table/
keywords:
- adicionar tabela
- criar tabela
- acessar tabela
- proporção
- alinhar texto
- formatação de texto
- estilo de tabela
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Crie e edite tabelas em slides do PowerPoint com Aspose.Slides para Python via Java. Descubra exemplos de código simples para otimizar seus fluxos de trabalho com tabelas."
---
## **Introdução**

Uma tabela no PowerPoint é uma maneira eficiente de exibir informações. As informações em uma grade de células (organizadas em linhas e colunas) são diretas e fáceis de entender.

Aspose.Slides fornece a classe [Table](https://reference.aspose.com/slides/pt/python-java/aspose.slides/table/) , a classe [Cell](https://reference.aspose.com/slides/pt/python-java/aspose.slides/cell/) e outros tipos para permitir que você crie, atualize e gerencie tabelas em todos os tipos de apresentações.

## **Criar uma Tabela do Zero**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) .
2. Obtenha uma referência a um slide pelo seu índice.
3. Defina uma lista de larguras de coluna.
4. Defina uma lista de alturas de linha.
5. Adicione um objeto [Table](https://reference.aspose.com/slides/pt/python-java/aspose.slides/table/) ao slide através do método [addTable](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addTable) .
6. Itere por cada [Cell](https://reference.aspose.com/slides/pt/python-java/aspose.slides/cell/) para aplicar formatação às bordas superior, inferior, direita e esquerda.
7. Mescle as duas primeiras células da primeira linha da tabela.
8. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/) de um [Cell](https://reference.aspose.com/slides/pt/python-java/aspose.slides/cell/) .
9. Adicione algum texto ao [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/) .
10. Salve a apresentação modificada.

Este código Python mostra como criar uma tabela em uma apresentação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Instancia uma classe Presentation que representa um arquivo PPTX
presentation = Presentation()
try:

    # Acessa o primeiro slide
    slide = presentation.getSlides().get_Item(0)

    # Define colunas com larguras e linhas com alturas
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Adiciona um shape de tabela ao slide
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Define a formatação da borda para cada célula
    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    # Mescla as células 1 e 2 da linha 1
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # Adiciona algum texto à célula mesclada
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # Salva a apresentação no disco
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numeração em uma Tabela Padrão**

Em uma tabela padrão, a numeração das células é simples e baseada em zero. A primeira célula de uma tabela tem o índice 0,0 (coluna 0, linha 0).

Por exemplo, as células de uma tabela com 4 colunas e 4 linhas são numeradas da seguinte forma:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código Python mostra como criar uma tabela com numeração de células padrão:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Instancia uma classe Presentation que representa um arquivo PPTX
presentation = Presentation()
try:

    # Acessa o primeiro slide
    slide = presentation.getSlides().get_Item(0)

    # Define colunas com larguras e linhas com alturas
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Adiciona um shape de tabela ao slide
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Define o formato da borda para cada célula
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

    # Salva a apresentação no disco
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acessar uma Tabela Existente**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) .
2. Obtenha uma referência ao slide que contém a tabela pelo seu índice.
3. Inicialize uma variável para um objeto [Table](https://reference.aspose.com/slides/pt/python-java/aspose.slides/table/) e defina-a como `None` .
4. Itere por todos os objetos [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/) até encontrar a tabela.

   Se você suspeita que o slide em questão contém uma única tabela, pode simplesmente verificar todas as formas que ele contém. Quando uma forma é identificada como uma tabela, você pode usá-la como um objeto [Table](https://reference.aspose.com/slides/pt/python-java/aspose.slides/table/) . Mas se o slide contiver várias tabelas, é melhor pesquisar a tabela que você precisa através de seu [getAlternativeText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getAlternativeText) .

5. Use o objeto [Table](https://reference.aspose.com/slides/pt/python-java/aspose.slides/table/) para trabalhar com a tabela. No exemplo abaixo, atualizamos o texto na primeira coluna da segunda linha.
6. Salve a apresentação modificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# Instancia a classe Presentation que representa um arquivo PPTX
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # Acessa o primeiro slide
    slide = presentation.getSlides().get_Item(0)

    # Inicializa a referência da tabela.
    table = None

    # Percorre as formas e define uma referência para a tabela encontrada
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # Define o texto para a primeira coluna da segunda linha
            table.get_Item(0, 1).getTextFrame().setText("New")

    # Salva a apresentação modificada no disco
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Encontrar a Célula que Possui um Text Frame**

Quando um código genérico de processamento de texto recebe um [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/) de uma tabela, use o método [TextFrame.getParentCell](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/#getParentCell) para recuperar a [Cell](https://reference.aspose.com/slides/pt/python-java/aspose.slides/cell/) proprietária. Para um TextFrame de célula de tabela, [TextFrame.getParentCell](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/#getParentCell) retorna o proprietário e [TextFrame.getParentShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/#getParentShape) retorna `None`, embora a própria tabela seja uma forma.

As coordenadas da célula estão disponíveis por meio dos métodos somente leitura [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/pt/python-java/aspose.slides/cell/#getFirstColumnIndex) e [Cell.getFirstRowIndex](https://reference.aspose.com/slides/pt/python-java/aspose.slides/cell/#getFirstRowIndex) . [TextFrame.getParentCell](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/#getParentCell) também fornece navegação somente leitura: ele retorna o proprietário mas não altera a propriedade. Sempre verifique se a célula retornada é `None` antes de usá‑la.

Para um exemplo completo que identifica proprietários de células de tabela e de formas, incluindo formas associadas a nós de SmartArt, veja [Search and Replace Text](/slides/pt/python-java/search-and-replace-text/) .

## **Alinhar Texto em uma Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) .
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um objeto [Table](https://reference.aspose.com/slides/pt/python-java/aspose.slides/table/) ao slide.
4. Acesse um objeto [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/) da tabela.
5. Acesse o [Paragraph](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraph/) do objeto [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/) .
6. Alinhe o texto verticalmente.
7. Salve a apresentação modificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Cria uma instância da classe Presentation
presentation = Presentation()
try:

    # Obtém o primeiro slide
    slide = presentation.getSlides().get_Item(0)

    # Define colunas com larguras e linhas com alturas
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Adiciona o shape de tabela ao slide
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # Acessa o frame de texto
    text_frame = table.get_Item(0, 0).getTextFrame()

    # Acessa o primeiro parágrafo no frame de texto.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # Acessa a primeira porção no parágrafo.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Alinha o texto verticalmente
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # Salva a apresentação no disco
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir Formatação de Texto no Nível da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) .
2. Obtenha uma referência a um slide pelo seu índice.
3. Acesse um objeto [Table](https://reference.aspose.com/slides/pt/python-java/aspose.slides/table/) do slide.
4. Defina a altura da fonte do texto com [setFontHeight](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setFontHeight) .
5. Defina o alinhamento e a margem direita com [setAlignment](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraphformat/#setAlignment) e [setMarginRight](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraphformat/#setMarginRight) .
6. Defina o tipo de texto vertical com [setTextVerticalType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#setTextVerticalType) .
7. Salve a apresentação modificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Cria uma instância da classe Presentation
presentation = Presentation("simpletable.pptx")
try:

    # Vamos supor que a primeira forma no primeiro slide seja uma tabela
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # Define a altura da fonte das células da tabela
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # Define o alinhamento de texto e a margem direita das células da tabela em uma única chamada
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # Define o tipo de texto vertical das células da tabela
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Obter Propriedades de Estilo da Tabela**

Aspose.Slides permite que você recupere as propriedades de estilo de uma tabela para que possa usar esses detalhes em outra tabela ou em outro lugar. Este código Python mostra como obter as propriedades de estilo de um estilo predefinido de tabela:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # alterar o tema padrão do preset de estilo

    # Obtém o preset de estilo da tabela
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # Aplica o preset de estilo obtido a outra tabela
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bloquear Proporção da Tabela**

A razão de aspecto de uma forma geométrica é a proporção de seus tamanhos em diferentes dimensões. Aspose.Slides fornece o método [setAspectRatioLocked](https://reference.aspose.com/slides/pt/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) para permitir que você bloqueie a configuração de proporção para tabelas e outras formas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # inverter
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **FAQ**

**Posso habilitar a direção de leitura da direita para a esquerda (RTL) para uma tabela inteira e o texto em suas células?**

Sim. A tabela expõe o método [setRightToLeft](https://reference.aspose.com/slides/pt/python-java/aspose.slides/table/#setRightToLeft) e os parágrafos possuem [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraphformat/#setRightToLeft) . Usar ambos garante a ordem correta RTL e a renderização dentro das células.

**Como posso impedir que os usuários movam ou redimensionem uma tabela no arquivo final?**

Use [shape locks](/slides/pt/python-java/applying-protection-to-presentation/) para desabilitar mover, redimensionar, selecionar etc. Esses bloqueios também se aplicam às tabelas.

**É suportado inserir uma imagem dentro de uma célula como plano de fundo?**

Sim. Você pode definir um [picture fill](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/) para uma célula; a imagem cobrirá a área da célula de acordo com o modo escolhido (esticar ou repetir).