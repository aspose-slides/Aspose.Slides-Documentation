---
title: Aprimore o Processamento de Imagens com a API Moderna em Python
linktitle: API Moderna
type: docs
weight: 237
url: /pt/python-java/modern-api/
keywords:
- API moderna
- desenho
- miniatura de slide
- slide para imagem
- miniatura de forma
- forma para imagem
- miniatura de apresentação
- apresentação para imagens
- adicionar imagem
- adicionar foto
- Python
- Java
- Aspose.Slides
description: "Modernize o processamento de imagens em Python via Java: renderize slides e formas, adicione fotos e migre chamadas de imagem obsoletas para a API Moderna do Aspose.Slides."
---
## **Introdução**

Aspose.Slides for Python via Java acessa a biblioteca Java através do JPype. Sua API legada de processamento de imagens usava [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) e [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) de `java.awt`.

A biblioteca Java tornou essas APIs de imagem obsoletas a partir da versão 24.4. A API Moderna usa [IImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/iimage/) para carregar, renderizar e salvar imagens. Use-a em novo código Python e ao migrar fluxos de trabalho de processamento de imagens existentes.

{{% alert color="info" title="Note" %}}
Os nomes de método antigos abaixo são referências de migração. Eles não estão mais disponíveis nas versões atuais. Os exemplos executáveis usam a API Moderna.

Esta mudança não elimina todos os tipos `java.awt`: sobrecargas de tamanho de imagem e cor de padrão ainda aceitam [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) e [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).
{{% /alert %}}

## **API Moderna**

Os principais tipos de processamento de imagens são:

- [IImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/iimage/) — representa uma imagem raster ou vetorial.
- [ImageFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imageformat/) — fornece constantes de formatos de arquivo de imagem.
- [Images](https://reference.aspose.com/slides/pt/python-java/aspose.slides/images/) — cria imagens, por exemplo com [Images.fromFile](https://reference.aspose.com/slides/pt/python-java/aspose.slides/images/#fromFile).

Use [Slide.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage) ou [Shape.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getImage) para renderizar um slide ou forma. Use [Presentation.getImages](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getImages) com opções de renderização para renderizar vários slides. A sobrecarga sem argumentos retorna a coleção de imagens da apresentação.

Carregue uma imagem com [Images.fromFile](https://reference.aspose.com/slides/pt/python-java/aspose.slides/images/#fromFile), adicione-a com [ImageCollection.addImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagecollection/#addImage) ou atualize uma imagem de apresentação existente com [PPImage.replaceImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/#replaceImage). Ambas as operações de coleção de imagens aceitam [IImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/iimage/).

Libere cada imagem que você carregar ou renderizar chamando seu método `dispose` em um bloco `finally`. Libere a apresentação com [Presentation.dispose](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#dispose).

### **Prepare o Ambiente Python**

Instale os pacotes conforme descrito em [Installation](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM, depois importa a API após a JVM estar em execução. Os exemplos deixam a JVM em execução para que possa ser reutilizada. Consulte [Limitations and API Differences](/slides/pt/python-java/limitations-and-api-differences/#import-the-library) para orientações sobre ciclo de vida do notebook e da JVM.

Exemplos que abrem `pres.pptx` exigem uma apresentação no diretório de trabalho. Exemplos que carregam `image.png` exigem um arquivo de imagem existente.

### **Carregar uma Imagem e Renderizar um Slide**

Este exemplo adiciona uma imagem ao primeiro slide e salva o slide como uma imagem JPEG. [IImage.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/iimage/#save) grava a imagem renderizada no formato especificado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **Substituindo Código Antigo pela API Moderna**

Substitua chamadas legadas de miniatura por métodos que retornam [IImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/iimage/), depois salve o resultado com [IImage.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/iimage/#save). Isso elimina a necessidade de passar imagens renderizadas para [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-).

### **Renderizar um Slide em um Tamanho Especificado**

Substitua a chamada legada `slide.getThumbnail(image_size)` por [Slide.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage) usando o mesmo tamanho de imagem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Obtendo uma Miniatura de Slide**

Substitua a chamada legada `slide.getThumbnail()` por [Slide.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage) sem argumentos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Obtendo uma Miniatura de Forma**

Substitua a chamada legada `shape.getThumbnail()` por [Shape.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getImage). Verifique se o slide contém uma forma antes de acessá‑la.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Obtendo uma Miniatura de Apresentação**

Substitua a chamada legada `presentation.getThumbnails(options, image_size)` por [Presentation.getImages](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getImages). Use [RenderingOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/renderingoptions/) para configurar a renderização.

Itere diretamente sobre o array retornado usando `enumerate` do Python. Libere cada imagem retornada em um bloco `finally` para que uma falha ao salvar não deixe imagens restantes sem liberação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **Adicionando uma Imagem a uma Apresentação**

Substitua o carregamento via [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) por [Images.fromFile](https://reference.aspose.com/slides/pt/python-java/aspose.slides/images/#fromFile), então passe a imagem resultante para [ImageCollection.addImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagecollection/#addImage). Adicione a imagem ao slide e salve a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Métodos Obsoletos e suas Substituições na API Moderna**

As tabelas usam a notação de chamada Python. Os nomes na coluna legada identificam APIs removidas; use os métodos de substituição vinculados. Os métodos modernos de renderização de imagem retornam objetos [IImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/iimage/) em vez de imagens buffered Java.

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getImages) retorna um array de imagens renderizadas quando chamado com opções de renderização.

| Chamada Legada | Substituição Moderna |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getImages) com `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getImages) com `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getImages) com `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getImages) com `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getImages) com `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getImages) com `options, image_size` |

Aqui, `slides` é um `int[]` Java de números de slide baseados em 1; crie‑lo com `jpype.JArray(jpype.JInt)([1, 3])` para selecionar os slides 1 e 3. `image_size` é um [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html).

### **Shape**

| Chamada Legada | Substituição Moderna |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getImage) sem argumentos |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getImage) com `bounds, scale_x, scale_y` |

### **Slide**

| Chamada Legada | Substituição Moderna |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage) sem argumentos |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage) com `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage) com `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage) com `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage) com `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage) com `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage) com `image_size` |
| `slide.renderToGraphics(options, graphics)` | Sem substituição direta; renderize para uma imagem em vez disso |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | Sem substituição direta; renderize para uma imagem em vez disso |
| `slide.renderToGraphics(options, graphics, image_size)` | Sem substituição direta; renderize para uma imagem em vez disso |

Aqui, `options` é [RenderingOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/renderingoptions/), e `tiff_options` é [TiffOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/tiffoptions/).

### **Output**

| Chamada Legada | Substituição Moderna |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/pt/python-java/aspose.slides/output/#add) com `path, image`, onde `image` é [IImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| Chamada Legada | Substituição Moderna |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagecollection/#addImage) com um [IImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/iimage/) |

### **PPImage**

| Chamada Legada | Substituição Moderna |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/#getImage) |

Para substituir o conteúdo de uma imagem de apresentação existente, use [PPImage.replaceImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/#replaceImage) com um [IImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/iimage/).

### **PatternFormat**

| Chamada Legada | Substituição Moderna |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/pt/python-java/aspose.slides/patternformat/#getTile) com `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/pt/python-java/aspose.slides/patternformat/#getTile) com `background, foreground` |

Os argumentos de cor permanecem objetos Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

### **PatternFormatEffectiveData**

Para dados de padrão efetivo retornados pela API Java via JPype, o método de substituição mantém o nome `getTileIImage`.

| Chamada Legada | Substituição Moderna |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, retornando [IImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/iimage/) |

## **Suporte da API para Graphics2D**

As sobrecargas legadas de `renderToGraphics` desenhavam em um contexto [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) fornecido pelo chamador. A API Moderna não possui substituição direta que desenhe nesse contexto.

Use [Slide.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage) para renderizar um slide ou [Presentation.getImages](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getImages) para renderizar vários slides, então salve as imagens retornadas com [IImage.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/iimage/#save). Aplicações que combinavam renderização de slide com desenho Java personalizado precisarão adaptar sua etapa de composição.

## **FAQ**

**Por que a antiga API de imagens Java foi substituída?**

A API Moderna move o carregamento, renderização e salvamento de imagens para [IImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/iimage/). Isso fornece uma abstração de imagem comum em vez de expor imagens buffered Java ou um contexto gráfico Java.

**Ainda preciso de Java e JPype?**

Sim. Aspose.Slides for Python via Java ainda é executado na JVM. A API Moderna altera apenas as chamadas de processamento de imagens, não os requisitos de runtime. Consulte [System Requirements](/slides/pt/python-java/system-requirements/).

**Como libero imagens em Python?**

Chame `dispose` em cada imagem que você carregar ou renderizar dentro de um bloco `finally`. Se você renderizar vários slides, libere cada imagem no array retornado. Libere a apresentação separadamente com [Presentation.dispose](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#dispose).

**A troca para a API Moderna garante geração mais rápida de miniaturas?**

Nenhuma melhoria de desempenho é garantida. As substituições suportam opções de renderização, dimensionamento e tamanhos de imagem; meça o desempenho com suas apresentações e configurações de saída.

**Por que o getter de imagem às vezes retorna uma coleção?**

[Presentation.getImages](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getImages) sem argumentos retorna imagens incorporadas da apresentação. Suas sobrecargas com opções de renderização retornam imagens de slide renderizadas.