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
- proporção de aspecto
- alinhar texto
- formatação de texto
- estilo de tabela
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Crie e edite tabelas em slides do PowerPoint com Aspose.Slides para Python via Java. Descubra exemplos de código simples para simplificar seus fluxos de trabalho com tabelas."
---
## **Introdução**

As tabelas no PowerPoint organizam informações em linhas e colunas, facilitando a leitura e a comparação de valores.

Aspose.Slides fornece as classes [Tabela](https://reference.aspose.com/slides/python-java/aspose.slides/table/) e [Célula](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) e outros tipos para permitir que você crie, atualize e gerencie tabelas em apresentações.

## **Criar uma Tabela do Zero**

Crie uma tabela especificando sua posição, larguras das colunas e alturas das linhas. Após adicioná‑la a um slide, você pode formatar as bordas das células, mesclar células e inserir texto.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Obtenha uma referência ao slide pelo seu índice.
3. Defina uma lista de larguras de colunas em pontos.
4. Defina uma lista de alturas de linhas em pontos.
5. Adicione um objeto [Tabela](https://reference.aspose.com/slides/python-java/aspose.slides/table/) ao slide usando o método [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) .
6. Itere por cada [Célula](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) para aplicar formatação nas bordas superior, inferior, direita e esquerda.
7. Mescle as duas primeiras células da primeira linha da tabela.
8. Acesse a célula mesclada através do método [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) .
9. Defina o texto na célula mesclada.
10. Salve a apresentação modificada.

O exemplo abaixo cria uma tabela com três colunas e cinco linhas em (100, 50) pontos. Ele aplica bordas vermelhas com largura de 5 pontos, mescla as duas primeiras células na primeira linha e salva o resultado como `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

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

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numeração em uma Tabela Padrão**

Em uma tabela padrão, os índices das células são baseados em zero e usam a ordem (coluna, linha). A primeira célula tem índice (0, 0).

Por exemplo, as células em uma tabela com 4 colunas e 4 linhas são numeradas assim:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este exemplo cria a tabela 4 × 4 ilustrada acima, com larguras de coluna e alturas de linha de 70 pontos e bordas vermelhas nas células com largura de 5 pontos. As coordenadas ilustram os índices das células; o exemplo deixa as células vazias e salva a tabela como `StandardTables_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

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

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acessar uma Tabela Existente**

As tabelas são armazenadas na coleção de formas de um slide. Percorra as formas para localizar uma tabela e, em seguida, use a classe [Tabela](https://reference.aspose.com/slides/python-java/aspose.slides/table/) para ler ou atualizar suas células.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Obtenha uma referência ao slide que contém a tabela pelo seu índice.
3. Percorra os objetos [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) e pare quando encontrar uma tabela. Se o slide contiver várias tabelas, use [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) para identificar a que você precisa.
4. Atualize o texto na célula alvo.
5. Salve a apresentação modificada.

O exemplo abaixo abre `UpdateExistingTable.pptx` e encontra a primeira tabela no primeiro slide. Ele define a célula na coluna 0, linha 1 para `New` e salva o resultado como `table1_out.pptx`. A entrada deve conter ao menos um slide, e a primeira tabela desse slide deve ter ao menos uma coluna e duas linhas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para redimensionar uma linha em uma tabela existente e entender por que sua altura real pode exceder o mínimo solicitado, veja [Controlar Altura da Linha](/slides/pt/python-java/manage-rows-and-columns/#control-row-height).

## **Encontrar a Célula que Possui um Quadro de Texto**

Quando um código genérico de processamento de texto recebe um [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) de uma tabela, use o método [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) para recuperar a [Célula](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) proprietária. Para um quadro de texto de célula de tabela, [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) devolve o proprietário e [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) devolve `None`, embora a própria tabela seja uma forma.

As coordenadas da célula estão disponíveis através dos métodos somente‑leitura [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) e [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) também fornece navegação somente‑leitura: ele devolve o proprietário mas não altera a propriedade. Sempre verifique se a célula retornada é `None` antes de usá‑la.

Para um exemplo completo que identifica proprietários de célula‑tabela e de forma, incluindo formas associadas a nós de SmartArt, veja [Pesquisar e Substituir Texto](/slides/pt/python-java/search-and-replace-text/).

## **Alinhar Texto em uma Tabela**

Você pode controlar o ancoramento vertical e a direção do texto de células individuais da tabela. O exemplo nesta seção centraliza o texto na primeira célula e o gira 270 graus.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Obtenha uma referência ao slide pelo seu índice.
3. Adicione um objeto [Tabela](https://reference.aspose.com/slides/python-java/aspose.slides/table/) ao slide.
4. Acesse um objeto [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) da tabela.
5. Acesse o primeiro [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) e defina seu texto e cor.
6. Defina o ancoramento vertical da célula e a direção do texto usando [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) e [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType) .
7. Salve a apresentação modificada.

Este exemplo cria uma tabela 4 × 4 com larguras de coluna de 120 pontos e alturas de linha de 100 pontos. Ele formata o texto na célula (0, 0), adiciona valores às demais células da primeira linha e salva o resultado como `Vertical_Align_Text_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir Formatação de Texto no Nível da Tabela**

Use [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) para aplicar formatação de texto a todas as células de uma tabela. Suas sobrecargas aceitam formatação de porções, parágrafos e quadros de texto, permitindo definir essas propriedades sem iterar pelas células individualmente.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Obtenha uma referência ao slide pelo seu índice.
3. Acesse um objeto [Tabela](https://reference.aspose.com/slides/python-java/aspose.slides/table/) do slide.
4. Defina o tamanho da fonte usando [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) para o texto.
5. Defina o alinhamento do parágrafo e a margem direita usando [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) e [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) .
6. Defina a direção do texto usando [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) .
7. Salve a apresentação modificada.

O exemplo abaixo abre `table.pptx`, que deve conter ao menos um slide com uma tabela como sua primeira forma. Ele define o tamanho da fonte para 25 pontos, alinha os parágrafos à direita com margem direita de 20 pontos e torna o texto vertical. A apresentação formatada é salva como `result.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obter Propriedades de Estilo da Tabela**

Use [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) para ler o estilo predefinido de uma tabela e [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) para atribuí‑lo. Este exemplo aplica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) a uma tabela, imprime o valor predefinido e atribui o mesmo estilo a uma segunda tabela. Ambas as tabelas são salvas em `table-style.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bloquear Proporção de Aspecto de uma Tabela**

A proporção de aspecto de uma tabela é a relação entre sua largura e sua altura. Use [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) para bloquear essa proporção para uma tabela.

O exemplo abaixo abre `pres.pptx`, que deve conter ao menos um slide com uma tabela como sua primeira forma. Ele imprime o estado atual do bloqueio, habilita o bloqueio de proporção, imprime o estado atualizado (`True`) e salva o resultado como `pres-out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas Frequentes**

**Posso habilitar a direção de leitura da direita para a esquerda (RTL) para uma tabela inteira e o texto em suas células?**

Sim. A tabela expõe um método [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft). Os parágrafos têm [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft). Usar ambos garante a ordem RTL correta e a renderização dentro das células.

**Como posso impedir que os usuários movam ou redimensionem uma tabela no arquivo final?**

Use [travas de forma](/slides/pt/python-java/applying-protection-to-presentation/) para desativar mover, redimensionar, selecionar etc. Essas travas também se aplicam a tabelas.

**É suportada a inserção de uma imagem dentro de uma célula como fundo?**

Sim. Você pode definir um [preenchimento de imagem](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) para uma célula; a imagem cobrirá a área da célula de acordo com o modo escolhido (esticar ou repetir).