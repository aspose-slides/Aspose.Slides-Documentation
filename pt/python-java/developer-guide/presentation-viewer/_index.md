---
title: Criar um visualizador de apresentações em Python via Java
linktitle: Visualizador de Apresentações
type: docs
weight: 50
url: /pt/python-java/presentation-viewer/
keywords:
- visualizar apresentação
- visualizador de apresentação
- criar visualizador de apresentação
- visualizar PPT
- visualizar PPTX
- visualizar ODP
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Crie um visualizador de apresentações personalizado em Python via Java usando Aspose.Slides. Exiba facilmente arquivos PowerPoint e OpenDocument sem o Microsoft PowerPoint."
---
## **Introdução**

Aspose.Slides for Python via Java é usado para criar arquivos de apresentação com slides. Esses slides podem ser visualizados ao abrir apresentações no Microsoft PowerPoint, por exemplo. No entanto, às vezes os desenvolvedores podem precisar ver os slides como imagens em seu visualizador de imagens preferido ou criar seu próprio visualizador de apresentações. Nesses casos, o Aspose.Slides permite exportar um slide individual como imagem. Este artigo descreve como fazer isso.

## **Gerar uma imagem SVG de um slide**

Para gerar uma imagem SVG a partir de um slide de apresentação com Aspose.Slides, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha a referência do slide pelo seu índice.
1. Abra um fluxo de bytes.
1. Salve o slide como uma imagem SVG no fluxo e grave‑o em um arquivo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Gerar um SVG com um ID de Forma Personalizado**

Aspose.Slides pode ser usado para gerar um [SVG](https://docs.fileformat.com/page-description-language/svg/) a partir de um slide com um ID de forma personalizado. Para isso, use o método [SvgShape.setId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgshape/#setId) de [SvgShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` pode ser usado para definir o ID da forma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Criar uma imagem de miniatura de slide**

Aspose.Slides ajuda a gerar imagens em miniatura de slides. Para gerar uma miniatura de um slide usando Aspose.Slides, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha a referência do slide pelo seu índice.
1. Obtenha a imagem em miniatura do slide referenciado em uma escala definida.
1. Salve a imagem em miniatura em qualquer formato de imagem desejado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Criar uma miniatura de slide com dimensões definidas pelo usuário**

Para criar uma imagem de miniatura de slide com dimensões definidas pelo usuário, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha a referência do slide pelo seu índice.
1. Obtenha a imagem em miniatura do slide referenciado com as dimensões definidas.
1. Salve a imagem em miniatura em qualquer formato de imagem desejado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Criar uma miniatura de slide com notas do apresentador**

Para gerar a miniatura de um slide com notas do apresentador usando Aspose.Slides, siga os passos abaixo:

1. Crie uma instância da classe [RenderingOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/renderingoptions/).
1. Use o método [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) para definir a posição das notas do apresentador.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha a referência do slide pelo seu índice.
1. Obtenha a imagem em miniatura do slide referenciado com as opções de renderização.
1. Salve a imagem em miniatura em qualquer formato de imagem desejado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Exemplo ao vivo**

Você pode experimentar o aplicativo gratuito [**Aspose.Slides Viewer**](https://products.aspose.app/slides/pt/viewer/) para ver o que pode implementar com a API do Aspose.Slides:

![Visualizador de PowerPoint Online](online-PowerPoint-viewer.png)

## **Perguntas frequentes**

**Posso incorporar um visualizador de apresentações em uma aplicação web?**

Sim. Você pode usar o Aspose.Slides no lado do servidor para renderizar slides como imagens ou HTML e exibí‑los no navegador. Recursos de navegação e zoom podem ser implementados com JavaScript para uma experiência interativa.

**Qual é a melhor maneira de exibir slides dentro de um visualizador personalizado?**

A abordagem recomendada é renderizar cada slide como uma imagem (por exemplo, PNG ou SVG) ou convertê‑lo para HTML usando Aspose.Slides, e então exibir a saída dentro de um picture box (para desktop) ou de um contêiner HTML (para web).

**Como lidar com apresentações grandes com muitos slides?**

Para decks grandes, considere o carregamento preguiçoso (lazy‑loading) ou renderização sob demanda dos slides. Isso significa gerar o conteúdo de um slide apenas quando o usuário navega até ele, reduzindo o uso de memória e o tempo de carregamento.