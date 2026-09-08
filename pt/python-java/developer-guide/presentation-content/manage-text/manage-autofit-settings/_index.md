---
title: Melhore suas apresentações com AutoFit em Python
linktitle: Configurações de Autofit
type: docs
weight: 30
url: /pt/python-java/manage-autofit-settings/
keywords:
- caixa de texto
- autofit
- não autoajustar
- ajustar texto
- reduzir texto
- quebrar texto
- redimensionar forma
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda como gerenciar as configurações de AutoFit no Aspose.Slides para Python via Java para otimizar a exibição de texto nas suas apresentações PowerPoint e OpenDocument e melhorar a legibilidade do conteúdo."
---
## **Introdução**

Por padrão, ao adicionar uma caixa de texto, o Microsoft PowerPoint usa a configuração **Resize shape to fix text** para a caixa de texto — ele redimensiona automaticamente a caixa de texto para garantir que o texto sempre caiba nela. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Quando o texto na caixa de texto fica mais longo ou maior, o PowerPoint amplia automaticamente a caixa de texto — aumenta sua altura — para permitir que contenha mais texto. 
* Quando o texto na caixa de texto fica mais curto ou menor, o PowerPoint reduz automaticamente a caixa de texto — diminui sua altura — para eliminar o espaço redundante. 

No PowerPoint, estes são os 4 parâmetros ou opções importantes que controlam o comportamento de autoajuste para uma caixa de texto: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java fornece opções semelhantes — algumas propriedades da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/) — que permitem controlar o comportamento de autoajuste para caixas de texto em apresentações. 

## **Redimensionar uma Forma para Caber no Texto**

Se você deseja que o texto em uma caixa sempre caiba nessa caixa após alterações no texto, deve usar a opção **Resize shape to fix text**. Para especificar essa configuração, use o método [setAutofitType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#setAutofitType) (da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/)) com [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textautofittype/#Shape).

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Este código Python mostra como especificar que um texto deve sempre caber em sua caixa em uma apresentação do PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Se o texto ficar mais longo ou maior, a caixa de texto será redimensionada automaticamente (aumentando a altura) para garantir que todo o texto caiba nela. Se o texto ficar mais curto, o efeito inverso ocorre. 

## **Do Not Autofit**

Se você deseja que uma caixa de texto ou forma mantenha suas dimensões independentemente das alterações feitas no texto que contém, deve usar a opção **Do not Autofit**. Para especificar essa configuração, use o método [setAutofitType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#setAutofitType) (da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/)) com [None](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textautofittype/#None). 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Este código Python mostra como especificar que uma caixa de texto deve sempre manter suas dimensões em uma apresentação do PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Quando o texto fica muito longo para a caixa, ele transborda. 

## **Shrink Text on Overflow**

Se um texto ficar muito longo para a caixa, por meio da opção **Shrink text on overflow** você pode especificar que o tamanho e o espaçamento do texto devem ser reduzidos para que ele caiba na caixa. Para especificar essa configuração, use o método [setAutofitType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#setAutofitType) (da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/)) com [Normal](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textautofittype/#Normal).

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Este código Python mostra como especificar que um texto deve ser reduzido ao transbordar em uma apresentação do PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Nota" color="info" %}}
Ao usar a opção **Shrink text on overflow**, a configuração é aplicada somente quando o texto fica muito longo para a caixa. 
{{% /alert %}}

## **Wrap Text**

Se você deseja que o texto em uma forma seja envolvido dentro dessa forma quando o texto ultrapassa a borda da forma (apenas a largura), deve usar o parâmetro **Wrap text in shape**. Para especificar essa configuração, use o método [setWrapText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#setWrapText) (da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/)) com [NullableBool.True](https://reference.aspose.com/slides/pt/python-java/aspose.slides/nullablebool/#True). 

Este código Python mostra como usar a configuração Wrap Text em uma apresentação do PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Aviso" color="warning" %}} 
Se você usar o método [setWrapText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#setWrapText) com [NullableBool.False](https://reference.aspose.com/slides/pt/python-java/aspose.slides/nullablebool/#False) para uma forma, quando o texto dentro da forma ficar mais longo que a largura da forma, o texto se estenderá além das bordas da forma em uma única linha. 
{{% /alert %}}

## **FAQ**

**As margens internas do quadro de texto afetam o AutoFit?**

Sim. O preenchimento (margens internas) reduz a área utilizável para o texto, de modo que o AutoFit entra em ação mais cedo — reduzindo a fonte ou redimensionando a forma antes. Verifique e ajuste as margens antes de sintonizar o AutoFit.

**Como o AutoFit interage com quebras de linha manuais e suaves?**

Quebras forçadas permanecem no lugar, e o AutoFit adapta o tamanho da fonte e o espaçamento ao redor delas. Remover quebras desnecessárias costuma reduzir a agressividade com que o AutoFit precisa encolher o texto.

**Alterar a fonte do tema ou acionar substituição de fonte afeta os resultados do AutoFit?**

Sim. Substituir por uma fonte com métricas de glifos diferentes altera a largura/altura do texto, o que pode mudar o tamanho final da fonte e a quebra de linha. Após qualquer alteração ou substituição de fonte, reveja os slides.