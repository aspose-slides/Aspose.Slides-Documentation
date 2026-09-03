---
title: Gerenciar Caixas de Texto em Apresentações com Python
linktitle: Gerenciar Caixa de Texto
type: docs
weight: 20
url: /pt/python-net/manage-textbox/
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
- Aspose.Slides
description: "Criar, identificar, formatar e atualizar caixas de texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides for Python via .NET."
---
## **Introdução**

No Aspose.Slides for Python via .NET, o texto dos slides é armazenado em quadros de texto que pertencem a formas. A classe [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) representa a forma mais comum que contém texto e expõe seu texto através da propriedade [AutoShape.text_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/text_frame/).

{{% alert color="info" title="Nota" %}}
Toda forma automática herda de [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/), mas nem toda forma é uma forma automática ou oferece um quadro de texto. Ao processar uma apresentação existente, use `isinstance(shape, slides.AutoShape)` para verificar o tipo da forma antes de acessar seu texto.
{{% /alert %}}

## **Criar uma Caixa de Texto em um Slide**

Para criar uma caixa de texto, adicione uma forma automática a um slide, adicione texto ao seu quadro de texto e salve a apresentação. O exemplo a seguir cria uma caixa de texto retangular:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

As coordenadas e dimensões passadas para [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/add_auto_shape/) são medidas em pontos. [AutoShape.add_text_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/add_text_frame/) inicializa o quadro de texto com o texto fornecido.

## **Verificar se uma Forma é uma Caixa de Texto**

Use a propriedade [AutoShape.is_text_box](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/is_text_box/) para determinar se uma forma automática é tratada como uma caixa de texto. Isso é útil quando uma apresentação contém tanto formas automáticas com texto quanto formas puramente gráficas.

![Uma caixa de texto e uma forma](istextbox.png)

O exemplo a seguir inspeciona cada forma automática em uma apresentação:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

Uma forma automática recém‑adicionada não é considerada uma caixa de texto até que contenha texto não vazio. Você pode fornecer esse texto através de [AutoShape.add_text_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/add_text_frame/) ou [TextFrame.text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/text/). Adicionar ou atribuir uma string vazia deixa [is_text_box](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/is_text_box/) definido como `False`:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

As duas primeiras chamadas imprimem `True`; as duas últimas imprimem `False`.

## **Encontrar a Forma que Possui um Quadro de Texto**

O código genérico de processamento de texto pode receber um [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) sem saber qual objeto da apresentação o contém. Use a propriedade somente‑leitura [TextFrame.parent_shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/parent_shape/) para navegar de volta à sua [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/) proprietária.

Para um quadro de texto pertencente a uma forma automática ou outra forma que contém texto, parent_shape contém o proprietário e [TextFrame.parent_cell](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/parent_cell/) é `None`. Verifique o valor retornado antes de acessá‑lo. Para identificar tanto proprietários de forma quanto de célula de tabela, incluindo formas associadas a nós de SmartArt, consulte [Search and Replace Text](/slides/pt/python-net/search-and-replace-text/).

## **Adicionar Colunas a uma Caixa de Texto**

A propriedade [TextFrameFormat.column_count](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/column_count/) divide o quadro de texto em colunas, enquanto [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/column_spacing/) define o espaço entre as colunas em pontos. Ambas as configurações pertencem a [TextFrameFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/) e podem ser alteradas através do quadro de texto de uma caixa de texto existente. O texto é redistribuído entre as colunas dentro da mesma forma; não continua em outra forma.

O exemplo a seguir cria uma caixa de texto de três colunas com 10 pontos entre as colunas, salva a apresentação e lê as configurações armazenadas do arquivo de saída:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **Extrair Texto de Colunas Individuais**

Use [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/split_text_by_columns/) para recuperar o texto atribuído a cada coluna visual em um quadro de texto existente. O método retorna uma string para cada coluna, na ordem de leitura baseada em colunas. Um quadro de texto de única coluna produz uma lista com um elemento, e uma coluna vazia é representada por uma string vazia. As strings contêm apenas texto simples; a formatação em nível de porção não é preservada.

Isso é útil quando você precisa:
- Extrair texto preservando sua ordem de leitura baseada em colunas.
- Indexar ou comparar o conteúdo de slides com múltiplas colunas.
- Exportar cada coluna para um arquivo separado, campo de banco de dados ou outro destino.
- Inspecionar como o texto é redistribuído após alterar [TextFrameFormat.column_count](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/column_count/), [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/column_spacing/), a fonte ou o tamanho do quadro de texto.

O método informa o texto distribuído dentro do [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) atual; ele não faz o fluxo automático de texto entre formas ou caixas de texto separadas. A distribuição das colunas pode depender das fontes disponíveis e de outras configurações de layout de texto, portanto certifique‑se de que as fontes necessárias estejam disponíveis quando resultados consistentes forem importantes.

O exemplo a seguir carrega uma apresentação, encontra a primeira forma automática de múltiplas colunas com um quadro de texto, lê sua contagem de colunas configurada e grava o texto de cada coluna em um arquivo separado. Formas que não fornecem um quadro de texto são ignoradas.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **Atualizar Texto**

Para atualizar texto em toda a apresentação, itere pelos slides e formas, selecione formas automáticas e então edite suas porções de texto. Trabalhar ao nível de porção permite alterar tanto o texto quanto a formatação dos caracteres.

O exemplo a seguir substitui cada ocorrência de `years` por `months` no texto de formas automáticas e torna cada porção afetada em negrito:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

Essa travessia atualiza o texto apenas em formas automáticas. Texto armazenado em tabelas, gráficos, SmartArt ou formas agrupadas requer a travessia das coleções próprias desses objetos.

## **Adicionar uma Caixa de Texto com um Hiperlink**

Um hiperlink pode ser atribuído a uma porção específica de texto, de modo que somente esse texto funcione como o link clicável. Use [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) para associar a porção a um URL externo.

O exemplo a seguir cria texto com link e o salva em uma apresentação:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas Frequentes**

**Qual é a diferença entre uma caixa de texto e um placeholder de texto em um slide mestre ou de layout?**

Um [placeholder](/slides/pt/python-net/manage-placeholder/) pode herdar sua posição e formatação de um [master slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslide/) ou [layout slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/). Uma caixa de texto regular é uma forma independente no slide onde foi criada e não adquire o comportamento de placeholder quando o layout é alterado.

**Como posso substituir texto sem alterar o texto em gráficos, tabelas ou SmartArt?**

Limite a travessia a instâncias de [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/), como mostrado no exemplo Atualizar Texto. Gráficos, tabelas e SmartArt armazenam texto em seus próprios modelos de objetos, portanto não são modificados por esse loop.