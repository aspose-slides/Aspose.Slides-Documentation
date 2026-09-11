---
title: Gerenciar Linhas e Colunas em Tabelas do PowerPoint usando Python
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
- estilo da tabela
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Gerencie linhas e colunas de tabelas no PowerPoint com Aspose.Slides para Python via Java e acelere a edição de apresentações e atualizações de dados."
---
## **Introdução**

Para permitir que você gerencie as linhas e colunas de uma tabela em uma apresentação do PowerPoint, o Aspose.Slides oferece a classe [Table](https://reference.aspose.com/slides/pt/python-java/aspose.slides/table/) e muitos outros tipos.

## **Definir a Primeira Linha como Cabeçalho**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e carregue a apresentação.  
2. Obtenha uma referência a um slide pelo seu índice.  
3. Crie uma referência a um [Table](https://reference.aspose.com/slides/pt/python-java/aspose.slides/table/) e defina-a como `None`.  
4. Itere por todos os objetos [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/) para encontrar a tabela relevante.  
5. Defina a primeira linha da tabela como seu cabeçalho.

Este código Python mostra como definir a primeira linha de uma tabela como seu cabeçalho:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Clonar uma Linha ou Coluna de Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e carregue a apresentação.  
2. Obtenha uma referência a um slide pelo seu índice.  
3. Defina uma lista de larguras de colunas.  
4. Defina uma lista de alturas de linhas.  
5. Adicione um objeto [Table](https://reference.aspose.com/slides/pt/python-java/aspose.slides/table/) ao slide através do método [addTable](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addTable).  
6. Clone a linha da tabela.  
7. Clone a coluna da tabela.  
8. Salve a apresentação modificada.

Este código Python mostra como clonar a linha ou coluna de uma tabela PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
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

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).  
2. Obtenha uma referência a um slide pelo seu índice.  
3. Defina uma lista de larguras de colunas.  
4. Defina uma lista de alturas de linhas.  
5. Adicione um objeto [Table](https://reference.aspose.com/slides/pt/python-java/aspose.slides/table/) ao slide através do método [addTable](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addTable).  
6. Remova a linha da tabela.  
7. Remova a coluna da tabela.  
8. Salve a apresentação modificada.

Este código Python mostra como remover uma linha ou coluna de uma tabela:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir Formatação de Texto no Nível de Linha da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e carregue a apresentação.  
2. Obtenha uma referência a um slide pelo seu índice.  
3. Acesse o objeto [Table](https://reference.aspose.com/slides/pt/python-java/aspose.slides/table/) relevante no slide.  
4. Defina a altura da fonte das células da primeira linha usando [setFontHeight](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Defina o alinhamento de texto e a margem direita das células da primeira linha usando [setAlignment](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraphformat/#setAlignment) e [setMarginRight](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Defina o tipo de texto vertical das células da segunda linha usando [setTextVerticalType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Salve a apresentação modificada.

Este código Python demonstra a operação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
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
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Definir Formatação de Texto no Nível de Coluna da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e carregue a apresentação.  
2. Obtenha uma referência a um slide pelo seu índice.  
3. Acesse o objeto [Table](https://reference.aspose.com/slides/pt/python-java/aspose.slides/table/) relevante no slide.  
4. Defina a altura da fonte das células da primeira coluna usando [setFontHeight](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Defina o alinhamento de texto e a margem direita das células da primeira coluna usando [setAlignment](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraphformat/#setAlignment) e [setMarginRight](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Defina o tipo de texto vertical das células da segunda coluna usando [setTextVerticalType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Salve a apresentação modificada.

Este código Python demonstra a operação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
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
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Obter Propriedades de Estilo da Tabela**

O Aspose.Slides permite que você recupere as propriedades de estilo de uma tabela para que possa usar esses detalhes em outra tabela ou em outro lugar. Este código Python mostra como obter as propriedades de estilo de um estilo predefinido de tabela:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
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

Não, as tabelas do Aspose.Slides não possuem ordenação ou filtros embutidos. Ordene seus dados na memória primeiro e, em seguida, repopule as linhas da tabela nessa ordem.

**Posso ter colunas em faixa (listradas) mantendo cores personalizadas em células específicas?**

Sim. Ative colunas em faixa e, depois, sobrescreva células específicas com formatação local; a formatação ao nível da célula tem precedência sobre o estilo da tabela.