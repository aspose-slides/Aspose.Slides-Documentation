---
title: Gerenciar Linhas e Colunas em Tabelas PowerPoint Usando Python
linktitle: Linhas e Colunas
type: docs
weight: 20
url: /pt/python-java/manage-rows-and-columns/
keywords:
- linha de tabela
- coluna de tabela
- primeira linha
- cabeçalho da tabela
- clonar linha
- clonar coluna
- copiar linha
- copiar coluna
- remover linha
- remover coluna
- formatação de texto da linha
- formatação de texto da coluna
- estilo de tabela
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Gerencie linhas e colunas de tabelas no PowerPoint com Aspose.Slides para Python via Java e agilize a edição de apresentações e a atualização de dados."
---
## **Introdução**

Aspose.Slides for Python via Java permite que você gerencie a estrutura e a formatação de tabelas em apresentações PowerPoint através da classe [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Você pode designar uma linha de cabeçalho, clonar ou remover linhas e colunas e aplicar formatação de texto a uma linha ou coluna inteira.

Este artigo explica essas operações com exemplos em Python. Também mostra como recuperar o preset de estilo de uma tabela para que você possa reutilizá‑lo. Os índices de linhas e colunas da tabela são baseados em zero.

## **Controlar Altura da Linha**

Use [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) para definir a altura mínima de uma linha em pontos. É um limite inferior, não uma altura fixa. [Row.getHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#getHeight) retorna a altura real. Acesse a linha através de [Table.getRows](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getRows).

O exemplo carrega [row-height-input.pptx](row-height-input.pptx), que contém uma tabela como a primeira forma no primeiro slide. Sua primeira linha inicia em 70 pontos. As células utilizam texto Arial de 18 pontos, quebra de linha e margens superior e inferior de 6 pontos; o texto mais longo na segunda coluna quebra em várias linhas. O exemplo aumenta a mínima para 100 pontos, depois diminui para 20 pontos, imprime a altura real após cada alteração e salva ambos os resultados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("row-height-input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    row = table.getRows().get_Item(0)

    row.setMinimalHeight(100)
    print(f"Increased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx)

    row.setMinimalHeight(20)
    print(f"Decreased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Com a apresentação fornecida, aumentar a mínima adiciona espaço à linha. Reduzi‑la remove esse espaço extra, mas a altura real permanece maior que 20 pontos porque o texto e as margens da célula precisam de mais espaço. Reduzir apenas a mínima não pode forçar a linha abaixo do espaço exigido pelo seu conteúdo.

Vários fatores afetam a altura real:

- **Text and font size:** texto mais longo, quebras de linha explícitas ou uma fonte maior podem exigir mais espaço vertical.
- **Wrapping and column width:** com a quebra habilitada, reduzir a largura da coluna com [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) pode gerar mais linhas. Uma coluna mais larga pode reduzir o espaço necessário verticalmente.
- **Cell margins:** [Cell.setMarginTop](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginTop) e [Cell.setMarginBottom](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginBottom) adicionam espaço vertical. [Cell.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginLeft) e [Cell.setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginRight) reduzem a largura disponível para texto e podem causar quebras adicionais.

Para esta tabela sem células mescladas, a célula que necessita de mais espaço vertical determina o limite inferior baseado no conteúdo para toda a linha. Para encurtar a linha, pode ser necessário abreviar o texto, reduzir o tamanho da fonte ou as margens, ou alargar uma coluna.

As imagens abaixo mostram a mesma tabela na mesma escala. Nos resultados ilustrados, as alturas reais foram 70, 100 e 55.2 pontos: a linha final permaneceu mais alta que seu mínimo de 20 pontos. Medições exatas de texto podem variar com as fontes disponíveis no seu ambiente. Baixe os resultados salvos: [mínimo aumentado](row-height-increased.pptx) e [mínimo diminuído](row-height-decreased.pptx).

| Original: mínimo 70 pt, real 70 pt | Aumentado: mínimo 100 pt, real 100 pt | Diminuído: mínimo 20 pt, real 55.2 pt |
| --- | --- | --- |
| ![Tabela original com a primeira linha de 70 pontos.](row-height-before.png) | ![Tabela após aumentar o mínimo da primeira linha para 100 pontos.](row-height-increased.png) | ![Tabela após diminuir o mínimo da primeira linha para 20 pontos; texto com quebra mantém a linha mais alta que o mínimo.](row-height-decreased.png) |

## **Definir a Primeira Linha como Cabeçalho**

Use o método [setFirstRow](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setFirstRow) para marcar a primeira linha para formatação de cabeçalho. Sua aparência depende do estilo de tabela aplicado à tabela.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Acesse a tabela armazenada como a primeira forma no slide.
4. Habilite a formatação de cabeçalho para sua primeira linha.
5. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como a primeira forma no primeiro slide. Ele habilita a formatação de cabeçalho para a primeira linha e salva `First_row_header.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    table.setFirstRow(True)

    presentation.save("First_row_header.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Clonar uma Linha ou Coluna da Tabela**

Clone linhas ou colunas para reutilizar seu conteúdo e formatação. Você pode anexar uma cópia ao final da tabela ou inseri‑la em uma posição específica.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Defina as larguras das colunas e as alturas das linhas.
4. Adicione uma tabela com o método [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
5. Clone as linhas necessárias.
6. Clone as colunas necessárias.
7. Salve a apresentação modificada.

O exemplo requer `Test.pptx` com ao menos um slide. Ele cria uma tabela com três colunas e cinco linhas, com dimensões especificadas em pontos. Ele anexa cópias da primeira linha e coluna, depois insere cópias da segunda linha e coluna no índice 3 (a quarta posição). A tabela resultante tem sete linhas e cinco colunas. O argumento `False` desabilita a clonagem em linhas ou colunas mescladas adjacentes; esta tabela não possui células mescladas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([50, 50, 50])
    row_heights = jpype.JArray(jpype.JDouble)([50, 30, 30, 30, 30])
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)

    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)

    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Remover uma Linha ou Coluna de uma Tabela**

Remova linhas ou colunas que não são mais necessárias em uma tabela. Remover um item altera os índices das linhas ou colunas que o seguem.

1. Crie uma apresentação com a classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Defina as larguras das colunas e as alturas das linhas.
4. Adicione uma tabela com o método [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
5. Remova a segunda linha e a segunda coluna.
6. Salve a apresentação modificada.

Este exemplo cria uma tabela de três por três e remove a linha e a coluna no índice 1, deixando uma tabela de dois por dois em `TestTable_out.pptx`. As dimensões estão em pontos. O argumento `False` desabilita a remoção de linhas ou colunas mescladas adjacentes; esta tabela não possui células mescladas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 50, 30])
    row_heights = jpype.JArray(jpype.JDouble)([30, 50, 30])
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)

    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir Formatação de Texto no Nível de Linha da Tabela**

Aplique formatação de texto a uma linha inteira para manter suas células consistentes. Você pode definir propriedades de fonte, formatação de parágrafo e direção do texto sem formatar cada célula individualmente.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Acesse a tabela no primeiro slide.
3. Use [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) para a primeira linha.
4. Use [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) e [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) para a primeira linha.
5. Use [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) para a segunda linha.
6. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como a primeira forma no primeiro slide e pelo menos duas linhas. Ele aplica texto de 25 pontos, alinhamento à direita e margem de parágrafo direita de 20 pontos à primeira linha, depois define texto vertical na segunda linha.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getRows().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getRows().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getRows().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("row_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir Formatação de Texto no Nível de Coluna da Tabela**

Aplique formatação de texto a uma coluna inteira para manter suas células consistentes. Você pode definir propriedades de fonte, formatação de parágrafo e direção do texto sem formatar cada célula individualmente.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Acesse a tabela no primeiro slide.
3. Use [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) para a primeira coluna.
4. Use [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) e [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) para a primeira coluna.
5. Use [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) para a segunda coluna.
6. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como a primeira forma no primeiro slide e pelo menos duas colunas. Ele aplica texto de 25 pontos, alinhamento à direita e margem de parágrafo direita de 20 pontos à primeira coluna, depois define texto vertical na segunda coluna.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getColumns().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getColumns().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getColumns().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("column_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obter Propriedades de Estilo da Tabela**

Use o método [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) para recuperar o preset aplicado a uma tabela e reutilizá‑lo em outra tabela. Isso identifica o preset ao invés de sobrescritas de formatação individuais das células.

O exemplo cria uma tabela, aplica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/#DarkStyle1) e lê o preset de volta. Ele imprime o valor inteiro correspondente a `DarkStyle1` e salva a tabela em `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 150])
    row_heights = jpype.JArray(jpype.JDouble)([5, 5, 5])
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print(style_preset)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso aplicar temas/estilos do PowerPoint a uma tabela que já foi criada?**

Sim. A tabela herda o tema do slide/layout/master e ainda é possível sobrescrever preenchimentos, bordas e cores de texto sobre esse tema.

**Posso ordenar linhas de tabela como no Excel?**

Não, as tabelas do Aspose.Slides não possuem ordenação ou filtros incorporados. Classifique seus dados na memória primeiro e, em seguida, repopule as linhas da tabela nessa ordem.

**Posso ter colunas listradas (bandeadas) mantendo cores personalizadas em células específicas?**

Sim. Ative colunas listradas, depois sobrescreva células específicas com formatação local; a formatação nível célula tem precedência sobre o estilo da tabela.