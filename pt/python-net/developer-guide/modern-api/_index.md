---
title: Aprimore o Processamento de Imagens com a API Moderna
linktitle: API Moderna
type: docs
weight: 280
url: /pt/python-net/modern-api/
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
- Aspose.Slides
description: "Modernize o processamento de imagens de slides substituindo APIs de imagens obsoletas pela API Moderna do Python para automação perfeita de PowerPoint e OpenDocument."
---
## **Introdução**

A API pública do Aspose.Slides para Python atualmente depende dos seguintes tipos `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

A partir da versão 24.4, esta API pública está **obsoleta** devido a [alterações](https://releases.aspose.com/slides/pt/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) na API pública do Aspose.Slides para Python.

Para eliminar `aspose.pydrawing` da API pública, introduzimos a **API Moderna**. Métodos que utilizam `aspose.pydrawing.Image` e `aspose.pydrawing.Bitmap` estão obsoletos e devem ser substituídos por seus equivalentes na API Moderna. Métodos que utilizam `aspose.pydrawing.Graphics` estão obsoletos e não possuem substituição direta na API Moderna.

Nas versões atuais, trate a API pública que depende de `aspose.pydrawing` como legado/obsoleta. Use a API Moderna para novo código e ao migrar fluxos de trabalho de processamento de imagens existentes.

## **API Moderna**

As seguintes classes e enumerações foram adicionadas à API pública:

- [aspose.slides.IImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iimage/) - representa uma imagem raster ou vetorial.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imageformat/) - representa um formato de arquivo de imagem.
- [aspose.slides.Images](https://reference.aspose.com/slides/pt/python-net/aspose.slides/images/) - fornece métodos para criar e trabalhar com [IImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iimage/).

Use `get_image` para renderizar um único slide ou forma. Use `get_images` para renderizar vários slides de apresentação. Use os métodos de [Images](https://reference.aspose.com/slides/pt/python-net/aspose.slides/images/) para carregar imagens, `add_image` com [IImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iimage/) para adicioná‑las a uma apresentação e `replace_image` com [IImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iimage/) para atualizar uma imagem existente da apresentação.

Um cenário típico de uso da nova API é o seguinte:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## **Substituir o Código Antigo pela API Moderna**

Para facilitar a transição, a nova classe [IImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iimage/) reflete as APIs separadas das classes `aspose.pydrawing.Image` e `aspose.pydrawing.Bitmap`. Na maioria dos casos, você só precisa substituir chamadas a métodos que utilizam `aspose.pydrawing` por seus equivalentes na API Moderna.

### **Obter uma Miniatura de Slide**

**API Obsoleta:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**API Moderna:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **Obter uma Miniatura de Forma**

**API Obsoleta:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**API Moderna:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **Obter uma Miniatura de Apresentação**

**API Obsoleta:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**API Moderna:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **Adicionar uma Imagem a uma Apresentação**

**API Obsoleta:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**API Moderna:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **Métodos e Propriedades a Serem Removidos e Suas Substituições Modernas**

### **Classe Presentation**

|Assinatura do Método|Assinatura do Método de Substituição|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|Nenhuma substituição na API Moderna|
|save(fname, format, options, response, show_inline)|Nenhuma substituição na API Moderna|
|print()|Nenhuma substituição na API Moderna|
|print(printer_settings)|Nenhuma substituição na API Moderna|
|print(printer_name)|Nenhuma substituição na API Moderna|
|print(printer_settings, pres_name)|Nenhuma substituição na API Moderna|

### **Classe Slide**

|Assinatura do Método|Assinatura do Método de Substituição|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingssize)|
|render_to_graphics(options, graphics)|Nenhuma substituição na API Moderna|
|render_to_graphics(options, graphics, scale_x, scale_y)|Nenhuma substituição na API Moderna|
|render_to_graphics(options, graphics, rendering_size)|Nenhuma substituição na API Moderna|

### **Classe Shape**

|Assinatura do Método|Assinatura do Método de Substituição|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **Classe ImageCollection**

|Assinatura do Método|Assinatura do Método de Substituição|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **Classe PPImage**

|Assinatura do Método/Propriedade|Assinatura do Método/Propriedade de Substituição|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/image/)|

### **Classe ImageWrapperFactory**

|Assinatura do Método|Assinatura do Método de Substituição|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **Classe PatternFormat**

|Assinatura do Método|Assinatura do Método de Substituição|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **Classe IPatternFormatEffectiveData**

|Assinatura do Método|Assinatura do Método de Substituição|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Classe Output**

|Assinatura do Método|Assinatura do Método de Substituição|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **Suporte da API para aspose.pydrawing.Graphics**

Métodos que utilizam `aspose.pydrawing.Graphics` estão obsoletos e não possuem substituição direta na API Moderna.

Use os métodos de renderização de imagem da API Moderna em vez da API que renderiza para `aspose.pydrawing.Graphics`:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **FAQ**

**Por que `aspose.pydrawing.Graphics` foi removido?**

O suporte a `aspose.pydrawing.Graphics` está obsoleto na API pública para unificar o trabalho com renderização e imagens, eliminar dependências específicas de plataforma e adotar uma abordagem multiplataforma com [IImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iimage/). Use `get_image` ou `get_images` em vez de renderizar para `aspose.pydrawing.Graphics`.

**Qual é o benefício prático de [IImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iimage/) em comparação com `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap`?**

[IImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iimage/) unifica o trabalho com imagens raster e vetoriais, simplifica a gravação em vários formatos via [ImageFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imageformat/), reduz a dependência do pydrawing e torna o código mais portátil entre ambientes.

**A API Moderna afetará o desempenho da geração de miniaturas?**

A troca de `get_thumbnail` por `get_image` não piora os cenários: os novos métodos oferecem as mesmas capacidades de produzir imagens com opções e tamanhos, mantendo o suporte a opções de renderização. O ganho ou perda específico depende do cenário, mas funcionalmente as substituições são equivalentes.