---
title: Converter apresentações PowerPoint para GIF animados em Python
linktitle: PowerPoint para GIF
type: docs
weight: 65
url: /pt/python-java/convert-powerpoint-to-animated-gif/
keywords:
- GIF animado
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para GIF
- apresentação para GIF
- slide para GIF
- PPT para GIF
- PPTX para GIF
- salvar PPT como GIF
- salvar PPTX como GIF
- exportar PPT como GIF
- exportar PPTX como GIF
- configurações padrão
- configurações personalizadas
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Converta facilmente apresentações PowerPoint (PPT, PPTX) em GIFs animados com Aspose.Slides para Python via Java. Resultados rápidos e de alta qualidade."
---
## **Visão geral**

Aspose.Slides for Python via Java permite converter apresentações PowerPoint em arquivos GIF animados com apenas algumas linhas de código. Isso é útil para compartilhar o conteúdo dos slides em páginas da web, mensageiros ou documentação. Este artigo explica como exportar uma apresentação usando as configurações padrão e como personalizar o tamanho do quadro, o atraso do slide e a taxa de quadros de transição através do [GifOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/gifoptions/).

## **Converter apresentações para GIF animado usando configurações padrão**

O exemplo Python a seguir carrega `pres.pptx` e o salva como um GIF animado usando as configurações padrão:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.gif", SaveFormat.Gif)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
Para personalizar a saída do GIF, passe um objeto [GifOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/gifoptions/) ao salvar, como mostrado abaixo.
{{% /alert %}}

## **Converter apresentações para GIF animado usando configurações personalizadas**

Use [setFrameSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/gifoptions/#setFrameSize) para especificar as dimensões de saída em pixels, [setDefaultDelay](https://reference.aspose.com/slides/pt/python-java/aspose.slides/gifoptions/#setDefaultDelay) para definir o atraso padrão do slide em milissegundos e [setTransitionFps](https://reference.aspose.com/slides/pt/python-java/aspose.slides/gifoptions/#setTransitionFps) para controlar a taxa de quadros de transição.

O exemplo a seguir exporta um GIF de 960 × 720 com um atraso padrão de slide de dois segundos e 35 quadros por segundo para as transições. O atraso padrão se aplica quando o tempo de avanço do slide não está definido.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GifOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    gif_options = GifOptions()
    frame_size = Dimension(960, 720)
    gif_options.setFrameSize(frame_size)
    gif_options.setDefaultDelay(2000)
    gif_options.setTransitionFps(35)

    presentation.save("pres.gif", SaveFormat.Gif, gif_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Você também pode experimentar o conversor gratuito [Text to GIF](https://products.aspose.app/slides/pt/text-to-gif) da Aspose.
{{% /alert %}}

## **Perguntas frequentes**

**E se as fontes usadas na apresentação não estiverem instaladas no sistema?**

Instale as fontes ausentes ou [configure fallback fonts](/slides/pt/python-java/powerpoint-fonts/). A substituição de fontes pode alterar a aparência do GIF exportado. Disponibilizar as fontes originais é essencial para que o design da apresentação seja mantido.

**Posso sobrepor uma marca d'água nos quadros do GIF?**

Sim. [Add a semi-transparent object or logo](/slides/pt/python-java/watermark/) nos slides mestres relevantes ou em slides individuais antes da exportação. A marca d'água passa a fazer parte do conteúdo renderizado do slide.