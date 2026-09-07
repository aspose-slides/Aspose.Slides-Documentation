---
title: Renderizar Slides de Apresentação como Imagens SVG em Python via Java
linktitle: Slide para SVG
type: docs
weight: 50
url: /pt/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint para SVG
- apresentação para SVG
- slide para SVG
- PPT para SVG
- PPTX para SVG
- opções de exportação SVG
- SVG interativo
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Exporte slides do PowerPoint como imagens SVG em Python via Java e controle fontes, texto, imagens, IDs e eventos com Aspose.Slides."
---
## **Visão geral**

SVG é um formato de imagem XML dimensionável que funciona bem para publicação na web, visualizadores de slides, fluxos de trabalho de acessibilidade e pós‑processamento automatizado. Aspose.Slides exporta cada slide para um arquivo SVG separado e permite controlar como texto, fontes, imagens e elementos SVG são gravados.

Use [SVGOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgoptions/) quando o SVG exportado precisar ser compacto, previsível em diferentes navegadores ou pronto para uso interativo.

## **Exportar um slide como SVG**

Crie uma [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/), selecione um slide e grave‑o em um stream com [Slide.writeAsSvg](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/). Os exemplos exigem um arquivo `presentation.pptx` existente. Cada exemplo inicia a JVM se necessário e fecha seus streams de saída. O exemplo a seguir exporta cada slide de uma apresentação como um arquivo SVG separado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

O nome do arquivo usa [Slide.getSlideNumber](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getSlideNumber) em vez do índice do loop. Você também pode exportar uma forma individual com [Shape.writeAsSvg](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/) quando um visualizador de slides ou página web precisa apenas dessa forma.

## **Configurar a saída SVG**

[SVGOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgoptions/) controla a renderização de SVG. Para quadros de texto, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgoptions/#setUseFrameSize) inclui o quadro de texto na área de renderização, e [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgoptions/#setUseFrameRotation) determina se a rotação do quadro é aplicada. Defina [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) como `True` quando o texto precisar ser renderizado sem ligaduras.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Controlar texto e fontes**

### **Vetorializar todo o texto**

Defina [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgoptions/#setVectorizeText) como `True` para gravar todo o texto do slide como gráficos vetoriais. Isso elimina dependências de fontes e torna o resultado visual mais consistente entre navegadores, mas o texto não fica mais selecionável ou pesquisável como texto SVG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **Escolher como as fontes externas são tratadas**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) usa um valor [SvgExternalFontsHandling](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgexternalfontshandling/) para fontes que são carregadas externamente. Escolha `AddLinksToFontFiles` para referenciar arquivos de fonte separados, `Embed` para incluir os dados da fonte no SVG ou `Vectorize` para renderizar apenas o texto que usa fontes externas como gráficos. Verifique a licença das fontes antes de incorporá‑las.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **Reduzir o tamanho de imagens incorporadas**

Use [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgoptions/#setPicturesCompression) para reduzir a resolução das imagens incorporadas, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) para omitir áreas recortadas da fonte e [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgoptions/#setJpegQuality) para controlar a qualidade da codificação JPEG. Essas configurações reduzem o tamanho do arquivo ao custo da fidelidade da imagem ou dos dados de imagem retidos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Atribuir IDs estáveis a formas e texto**

Use um controlador de formatação Python registrado via `jpype.JProxy` para atribuir valores [SvgShape.setId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgshape/#setId) às formas e valores [SvgTSpan.setId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgtspan/#setId) aos elementos `tspan` de texto. Atribua o proxy com [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

O controlador a seguir usa [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getOfficeInteropShapeId), que é estável durante a vida útil da forma, e um contador recorrente para seus trechos de texto. Isso torna os IDs gerados adequados para pós‑processamento de uma apresentação inalterada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Adicionar manipuladores de eventos SVG**

Em um controlador de formatação Python, chame [SvgShape.setEventHandler](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgshape/#setEventHandler) com um valor [SvgEvent](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgevent/) para adicionar um manipulador de evento JavaScript a uma forma exportada. Registre o controlador via `jpype.JProxy` e atribua‑o com [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Defina a função JavaScript na página ou documento SVG que hospeda o resultado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

A página host pode definir a função JavaScript referenciada pelo manipulador. Atribuir IDs e manipuladores de eventos permite visualizadores de slides, aprimoramentos de acessibilidade e outros fluxos de trabalho interativos de SVG.

## **FAQ**

**Quando devo usar [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgoptions/#setVectorizeText) em vez de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgoptions/#setVectorizeText) quando todo o texto precisar ser independente de fontes. Use [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) quando apenas o texto que usa fontes externas deve ser convertido em gráficos.

**Qual é a melhor maneira de tornar um SVG menor?**

Comece comprimindo as imagens incorporadas, excluindo áreas recortadas da imagem e escolhendo arquivos de fonte vinculados quando o ambiente de destino puder fornecê‑los. Teste o resultado, pois resolução de imagem mais baixa, qualidade JPEG reduzida e texto vetorizado têm compensações diferentes de qualidade e tamanho.

**Posso modificar os elementos SVG exportados após a exportação?**

Sim. Atribua IDs por meio de um controlador de formatação e, em seguida, selecione os elementos SVG correspondentes em sua ferramenta de pós‑processamento ou script de navegador.