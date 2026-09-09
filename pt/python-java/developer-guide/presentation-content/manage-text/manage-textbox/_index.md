---
title: Gerenciar Caixas de Texto em Apresentações Usando Python via Java
linktitle: Gerenciar Caixa de Texto
type: docs
weight: 20
url: /pt/python-java/manage-textbox/
keywords:
- caixa de texto
- quadro de texto
- adicionar texto
- atualizar texto
- criar caixa de texto
- verificar caixa de texto
- adicionar coluna de texto
- adicionar hiperlink
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Criar, identificar, formatar e atualizar caixas de texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via Java."
---
## **Introdução**

No Aspose.Slides for Python via Java, o texto dos slides é armazenado em quadros de texto que pertencem a formas. A classe [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) representa a forma mais comum que contém texto e expõe seu texto através do método [AutoShape.getTextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
Toda autoforma herda de [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/), mas nem toda forma é uma autoforma ou oferece suporte a um quadro de texto. Ao processar uma apresentação existente, verifique se a forma é uma instância de [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) antes de acessar seu texto.
{{% /alert %}}

## **Criar uma Caixa de Texto em um Slide**

Para criar uma caixa de texto, adicione uma autoforma a um slide, insira texto em seu quadro de texto e salve a apresentação. O exemplo a seguir cria uma caixa de texto retangular:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

As coordenadas e dimensões passadas para [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addAutoShape) são medidas em pontos. [AutoShape.addTextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/#addTextFrame) inicializa o quadro de texto com o texto fornecido.

## **Verificar se a Forma é uma Caixa de Texto**

Use o método [AutoShape.isTextBox](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/#isTextBox) para determinar se uma autoforma é tratada como caixa de texto. Isso é útil quando uma apresentação contém tanto autoformas que carregam texto quanto autoformas puramente gráficas.

![Uma caixa de texto e uma forma](istextbox.png)

O exemplo a seguir examina cada autoforma em uma apresentação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

Uma autoforma recém‑adicionada não é considerada caixa de texto até que contenha texto não vazio. Você pode fornecer esse texto através de [AutoShape.addTextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/#addTextFrame) ou [TextFrame.setText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/#setText). Inserir ou atribuir uma string vazia deixa [AutoShape.isTextBox](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/#isTextBox) retornando `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

As duas primeiras chamadas imprimem `True`; as duas últimas imprimem `False`.

## **Encontrar a Forma que Possui um Quadro de Texto**

Um código genérico de processamento de texto pode receber um [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/) sem saber qual objeto da apresentação o contém. Use o método somente‑leitura [TextFrame.getParentShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/#getParentShape) para navegar de volta até a sua [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/) proprietária.

Para um quadro de texto pertencente a uma autoforma ou a outra forma que contém texto, [TextFrame.getParentShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/#getParentShape) devolve o proprietário e [TextFrame.getParentCell](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/#getParentCell) devolve `None`. Verifique o valor retornado antes de acessá‑lo. Para identificar proprietários de forma e de célula de tabela, incluindo formas associadas a nós de SmartArt, consulte [Search and Replace Text](/slides/pt/python-java/search-and-replace-text/).

## **Adicionar Colunas a uma Caixa de Texto**

O método [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#setColumnCount) divide o quadro de texto em colunas, enquanto [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#setColumnSpacing) define o espaçamento entre colunas em pontos. Ambas as configurações pertencem a [TextFrameFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/) e podem ser alteradas através do quadro de texto de uma caixa de texto existente. O texto é redistribuído entre as colunas dentro da mesma forma; não continua em outra forma.

O exemplo a seguir cria uma caixa de texto com três colunas e 10 pontos entre elas, salva a apresentação e lê as configurações armazenadas do arquivo de saída:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **Extrair Texto de Colunas Individuais**

Use [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/#splitTextByColumns) para obter o texto atribuído a cada coluna visual em um quadro de texto existente. O método devolve uma string para cada coluna, na ordem de leitura baseada em colunas. Um quadro de texto de única coluna produz um array com um elemento, e uma coluna vazia é representada por uma string vazia. As strings contêm apenas texto puro; a formatação ao nível de porções não é preservada.

Isso é útil quando você precisa:

- Extrair texto preservando a ordem de leitura baseada em colunas.
- Indexar ou comparar o conteúdo de slides com múltiplas colunas.
- Exportar cada coluna para um arquivo separado, campo de banco de dados ou outro destino.
- Inspecionar como o texto é redistribuído após alterar a contagem de colunas com [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#setColumnCount), o espaçamento com [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#setColumnSpacing), a fonte ou o tamanho do quadro de texto.

O método relata o texto distribuído dentro do [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/) atual; não faz fluxo automático de texto entre formas ou caixas de texto separadas. A distribuição em colunas pode depender das fontes disponíveis e de outras configurações de layout de texto, portanto certifique‑se de que as fontes necessárias estejam presentes quando resultados consistentes forem importantes.

O exemplo a seguir carrega uma apresentação, localiza a primeira autoforma com múltiplas colunas e quadro de texto, lê a contagem de colunas configurada e grava o texto de cada coluna em um arquivo separado. Formas que não fornecem um quadro de texto são ignoradas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **Atualizar Texto**

Para atualizar texto em toda a apresentação, percorra os slides e formas, selecione autoformas e então edite suas porções de texto. Trabalhar ao nível de porções permite mudar tanto o texto quanto a formatação de caracteres.

O exemplo a seguir substitui cada ocorrência de `years` por `months` no texto de autoformas e deixa cada porção afetada em negrito:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Essa iteração atualiza o texto apenas em autoformas. Texto armazenado em tabelas, gráficos, SmartArt ou formas agrupadas requer a travessia das próprias coleções desses objetos.

## **Adicionar uma Caixa de Texto com Hiperlink**

Um hiperlink pode ser atribuído a uma porção de texto específica, de modo que somente esse texto funcione como link clicável. Use [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) para associar a porção a uma URL externa.

O exemplo a seguir cria texto com link e o salva em uma apresentação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Qual é a diferença entre uma caixa de texto e um marcador de posição de texto em um slide mestre ou de layout?**

Um [placeholder](/slides/pt/python-java/manage-placeholder/) pode herdar sua posição e formatação de um [master slide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/) ou de um [layout slide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutslide/). Uma caixa de texto normal é uma forma independente no slide onde foi criada e não adquire comportamento de marcador quando o layout muda.

**Como substituir texto sem alterar o texto em gráficos, tabelas ou SmartArt?**

Limite a travessia às formas que são instâncias de [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/), como mostrado no exemplo de Atualizar Texto. Gráficos, tabelas e SmartArt armazenam texto em seus próprios modelos de objeto, portanto não são modificados por esse loop.