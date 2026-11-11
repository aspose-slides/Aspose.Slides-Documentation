---
title: Renderizar slides de apresentação como imagens SVG em Python via Java
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
description: "Exporte slides de PowerPoint como imagens SVG em Python via Java e controle fontes, texto, imagens, IDs e eventos com Aspose.Slides."
---
## **Visão geral**

SVG é um formato de imagem escalável baseado em XML que funciona bem para publicação na web, visualizadores de slides, fluxos de trabalho de acessibilidade e pós‑processamento automatizado. Aspose.Slides exporta cada slide para um arquivo SVG separado e permite controlar como texto, fontes, imagens e elementos SVG são escritos.

Use [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) quando o SVG exportado precisar ser compacto, previsível em diferentes navegadores ou pronto para uso interativo.

## **Exportar um Slide como SVG**

Crie uma [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), selecione um slide e escreva‑o em um stream com [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Os exemplos exigem um arquivo `presentation.pptx` existente. Cada exemplo inicia a JVM, se necessário, e fecha seus streams de saída. O exemplo a seguir exporta cada slide de uma apresentação como um arquivo SVG separado.

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

O nome do arquivo usa [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) em vez do índice do loop. Você também pode exportar uma forma individual com [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) quando um visualizador de slides ou página da web precisar apenas daquela forma.

## **Configurar Saída SVG**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) controla a renderização SVG. Para quadros de texto, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) inclui o quadro de texto na área de renderização, e [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) determina se a rotação do quadro é aplicada. Defina [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) como `True` quando o texto precisar ser renderizado sem ligaduras.

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

## **Controlar Texto e Fontes**

Ao exportar slides para SVG, você pode controlar se o texto permanece como texto ou é convertido em gráficos vetoriais, e como fontes externas são incluídas ou referenciadas. As opções a seguir ajudam a equilibrar consistência visual, seleção de texto e dependências de fonte no SVG exportado.

### **Vetorializar Todo o Texto**

Defina [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) como `True` para gravar todo o texto do slide como gráficos vetoriais. Isso elimina dependências de fontes e torna o resultado visual mais consistente entre navegadores, mas o texto deixa de ser selecionável ou pesquisável como texto SVG.

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

### **Escolher Como Fontes Externas São Tratadas**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) usa um valor [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) para fontes carregadas externamente. Escolha `AddLinksToFontFiles` para referenciar arquivos de fonte separados, `Embed` para incluir os dados da fonte no SVG, ou `Vectorize` para renderizar como gráficos apenas o texto que usa fontes externas. Verifique a licença das fontes antes de incorporá‑las.

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

## **Reduzir Tamanho de Imagens Incorporadas**

Use [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) para reduzir a resolução das imagens incorporadas, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) para omitir áreas recortadas da origem, e [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) para controlar a qualidade da codificação JPEG. Essas configurações diminuem o tamanho do arquivo ao custo da fidelidade da imagem ou dos dados de imagem retidos.

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

## **Controlar Resolução de Rasterização de Metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) define o limite inferior de resolução para rasterizar metafilfiles durante a exportação SVG. Use‑o para equilibrar detalhe e tamanho do arquivo quando uma imagem EMF ou WMF é rasterizada. Ele não define um DPI global para o SVG nem obriga que todo objeto do slide se torne uma imagem raster.

Baixe [metafile-rasterization.pptx](metafile-rasterization.pptx), que contém uma imagem EMF com linhas diagonais espaçadas de forma estreita. O exemplo a seguir exporta o primeiro slide em três resoluções de rasterização através de [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Todas as demais configurações de exportação permanecem idênticas para que os resultados possam ser comparados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()

```

Na saída, o EMF tornou‑se um PNG incorporado em cada SVG. As medições a seguir referem‑se à apresentação fornecida; não constituem uma fórmula geral para converter DPI em dimensões de pixel.

| Rasterização de Metafile DPI | Dimensões do PNG incorporado | Tamanho do arquivo SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

A comparação abaixo mostra a mesma área do raster incorporado no mesmo tamanho de exibição ampliado. As linhas diagonais exibem pixelização visível em 72 DPI e bordas mais suaves em resoluções maiores, enquanto o arquivo SVG aumenta. Aumentar o valor não melhora necessariamente cada detalhe nem altera todas as imagens exportadas.

![Detalhe da linha diagonal ampliada em 72, 150 e 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) controla a redução da resolução da imagem e pode mascarar o efeito da mudança da resolução de rasterização do metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) controla a qualidade da codificação JPEG, não a resolução de rasterização do metafile.

## **Atribuir IDs Estáveis a Formas e Texto**

Use um controlador de formatação Python registrado via `jpype.JProxy` para atribuir valores [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) a formas e valores [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) a elementos de texto `tspan`. Associe o proxy com [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

O controlador a seguir usa [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId), que é estável enquanto a forma existir, e um contador repetível para seus spans de texto. Isso torna os IDs gerados adequados para o pós‑processamento de uma apresentação que não foi alterada.

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

## **Adicionar Manipuladores de Eventos SVG**

Em um controlador de formatação Python, chame [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) com um valor [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) para adicionar um manipulador de evento JavaScript a uma forma exportada. Registre o controlador através de `jpype.JProxy` e associe‑o com [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Defina a função JavaScript na página ou documento SVG que hospeda o resultado.

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

A página de hospedagem pode definir a função JavaScript referenciada pelo manipulador. A atribuição de IDs e manipuladores de eventos possibilita visualizadores de slides, aprimoramentos de acessibilidade e outros fluxos de trabalho SVG interativos.

## **Perguntas Frequentes**

**Quando devo usar [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) em vez de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) quando todo o texto precisar ser independente de fontes. Use [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) quando somente o texto que usa fontes externas deve ser convertido em gráficos.

**Qual é a melhor maneira de deixar um SVG menor?**

Comece comprimindo as imagens incorporadas, excluindo áreas recortadas e escolhendo arquivos de fonte vinculados quando o ambiente de destino puder servi‑los. Teste o resultado, pois resolução de imagem mais baixa, qualidade JPEG reduzida e texto vetorializado têm compensações diferentes de qualidade e tamanho.

**Posso modificar elementos SVG exportados após a exportação?**

Sim. Atribua IDs por meio de um controlador de formatação e, em seguida, selecione os elementos SVG correspondentes na sua ferramenta de pós‑processamento ou script do navegador.