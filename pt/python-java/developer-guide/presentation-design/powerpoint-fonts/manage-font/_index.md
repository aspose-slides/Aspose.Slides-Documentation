---
title: Gerenciar Fontes em Apresentações Usando Python via Java
linktitle: Gerenciar Fontes
type: docs
weight: 10
url: /pt/python-java/manage-fonts/
keywords:
- gerenciar fontes
- propriedades de fonte
- parágrafo
- formatação de texto
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Controle fontes em Python via Java com Aspose.Slides: incorpore, substitua e carregue fontes personalizadas para manter apresentações PPT, PPTX e ODP claras, seguras para a marca e consistentes."
---
## **Visão Geral**

O Aspose.Slides permite que você gerencie propriedades de fonte no texto de apresentações diretamente a partir do seu código. Você pode acessar o texto nos slides por meio de shapes, quadros de texto, parágrafos e porções, e então aplicar formatação ao texto selecionado.

Este artigo explica como configurar propriedades relacionadas a fontes para texto existente em uma apresentação, incluindo família de fontes, estilos negrito e itálico, alinhamento de parágrafo e cor da fonte. Também demonstra como criar uma caixa de texto, adicionar texto a ela e definir propriedades de fonte como família, negrito, itálico, sublinhado, tamanho e cor antes de salvar o resultado como um arquivo PPTX.

## **Gerenciar Propriedades Relacionadas à Fonte**
{{% alert color="info" title="Nota" %}} 

As apresentações geralmente contêm texto e imagens. O texto pode ser formatado de várias maneiras, seja para destacar seções e palavras específicas ou para estar em conformidade com estilos corporativos. A formatação de texto ajuda os usuários a variar a aparência e a sensação do conteúdo da apresentação. Este artigo mostra como usar o Aspose.Slides for Python via Java para configurar as propriedades de fonte de parágrafos de texto nos slides.

{{% /alert %}} 

Para gerenciar propriedades de fonte de um parágrafo usando Aspose.Slides for Python via Java:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha a referência de um slide usando seu índice.
1. Acesse as formas [Placeholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/placeholder/) no slide como [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/).
1. Recupere o [Paragraph](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraph/) do [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/) exposto por [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/).
1. Justifique o parágrafo.
1. Acesse a [Portion](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/) de texto de um [Paragraph](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraph/).
1. Defina a fonte usando [FontData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontdata/) e ajuste a **Font** da [Portion](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/) de texto de acordo.
   1. Defina a fonte como negrito.
   1. Defina a fonte como itálico.
1. Defina a cor da fonte usando o [FillFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fillformat/) exposto pelo objeto [Portion](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/).
1. Salve a apresentação modificada em um arquivo PPTX.

A implementação das etapas acima é apresentada a seguir. Ela recebe uma apresentação simples e formata as fontes em um dos slides. As capturas de tela a seguir mostram o arquivo de entrada e como os trechos de código o alteram. O código altera a fonte, a cor e o estilo da fonte.

|![Texto na apresentação de entrada](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: O texto no arquivo de entrada**|


|![Texto com formatação de fonte atualizada](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: O mesmo texto com formatação atualizada**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# Carregar a apresentação.
presentation = Presentation("FontProperties.pptx")
try:
    # Acessar o primeiro slide e os quadros de texto de seus dois primeiros marcadores de posição.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # Acessar o primeiro parágrafo em cada quadro de texto.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # Acessar a primeira porção em cada parágrafo.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # Definir e atribuir novas fontes.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # Definir as fontes como negrito e itálico.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # Definir as cores das fontes.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Salvar a apresentação.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir Propriedades de Fonte do Texto**
{{% alert color="info" title="Nota" %}} 

Conforme mencionado em **Gerenciar Propriedades Relacionadas à Fonte**, um [Portion](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/) é usado para conter texto com um estilo de formatação semelhante em um parágrafo. Este artigo mostra como usar o Aspose.Slides for Python via Java para criar uma caixa de texto com algum conteúdo e, em seguida, definir uma fonte específica e várias outras propriedades de fonte.

{{% /alert %}} 

Para criar uma caixa de texto e definir propriedades de fonte do texto nela:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha a referência de um slide usando seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) do tipo **Rectangle** ao slide.
1. Remova o estilo de preenchimento associado ao [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/).
1. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/) do [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/).
1. Adicione algum texto ao [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/).
1. Acesse o objeto [Portion](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/) associado ao [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/).
1. Defina a fonte a ser usada para o [Portion](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/).
1. Defina outras propriedades de fonte, como negrito, itálico, sublinhado, cor e altura, usando as propriedades relevantes expostas pelo objeto [Portion](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/).
1. Grave a apresentação modificada como um arquivo PPTX.

A implementação das etapas acima é apresentada a seguir.

|![Texto com propriedades de fonte aplicadas](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Texto com algumas propriedades de fonte definidas pelo Aspose.Slides for Python via Java**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # Obter o primeiro slide e adicionar um retângulo.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # Remover o preenchimento da forma.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Adicionar texto ao quadro de texto da forma.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # Definir a família da fonte.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # Definir negrito, itálico, sublinhado e tamanho da fonte.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # Definir a cor da fonte.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Salvar a apresentação.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```