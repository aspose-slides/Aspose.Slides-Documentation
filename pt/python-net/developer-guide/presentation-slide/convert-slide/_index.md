---
title: Converter Slides de Apresentação em Imagens em Python
linktitle: Slide para Imagem
type: docs
weight: 41
url: /pt/python-net/convert-slide/
keywords:
- converter slide
- exportar slide
- slide para imagem
- salvar slide como imagem
- slide para EMF
- slide para PNG
- slide para JPEG
- slide para bitmap
- slide para TIFF
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Converta slides de apresentações PPT, PPTX e ODP para PNG, JPEG, GIF, TIFF, EMF e outros formatos de imagem em Python com Aspose.Slides."
---
## **Introdução**

Aspose.Slides for Python via .NET pode renderizar slides individuais de apresentações PowerPoint e OpenDocument como PNG, JPEG, GIF, TIFF e outros formatos de imagem.

Para converter um slide em uma imagem, siga estas etapas:

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Selecione o slide que você deseja renderizar.
3. Se necessário, configure a renderização com a classe [RenderingOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/renderingoptions/) ou [TiffOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/tiffoptions/).
4. Chame o método [Slide.get_image](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/get_image/). Ele retorna um objeto [IImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iimage/).
5. Chame o método [IImage.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iimage/save/) e especifique o formato de saída com um valor [ImageFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imageformat/).

## **Converter um Slide em uma Imagem PNG**

A conversão mais simples usa as configurações de renderização padrão. O objeto [IImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iimage/) resultante pode ser processado em memória ou salvo em um arquivo.

O exemplo em Python a seguir renderiza o primeiro slide e o salva como uma imagem PNG:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Converter Slides em Imagens com Tamanhos Personalizados**

Use a sobrecarga [Slide.get_image](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) que aceita um valor [Size](https://reference.aspose.com/slides/pt/python-net/aspose.pydrawing/size/) para renderizar um slide com dimensões de pixel exatas.

O exemplo a seguir cria uma imagem JPEG de 1820 × 1040:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Converter Slides com Anotações e Comentários em Imagens**

Por padrão, as imagens dos slides não incluem anotações nem comentários. Atribua um objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/notescommentslayoutingoptions/) à propriedade [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) para controlar onde as anotações e comentários aparecem.

O exemplo a seguir coloca anotações truncadas abaixo do slide e comentários à sua direita:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Aviso" color="warning" %}}

Para conversão de slide para imagem, não defina a propriedade [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) como [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/notespositions/). As notas podem conter mais texto do que o tamanho fixo da imagem comporta. Use [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/notespositions/) em vez disso.

{{% /alert %}}

## **Converter Slides em Imagens Usando Opções TIFF**

A classe [TiffOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/tiffoptions/) permite controlar o tamanho, a resolução e outras propriedades da imagem TIFF renderizada.

O exemplo a seguir renderiza o primeiro slide como uma imagem TIFF de 2160 × 2880 a 300 DPI:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Converter Todos os Slides em Imagens**

Itere pela coleção de slides para converter toda a apresentação em uma série de imagens. Slides ocultos são incluídos, a menos que você os ignore explicitamente.

O exemplo a seguir renderiza cada slide como uma imagem JPEG com fatores de escala horizontal e vertical iguais a 2:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **Criar Saída em Metarquivo Aprimorado**

Metarquivo Aprimorado (EMF) é útil quando gráficos baseados em vetor precisam ser trocados com o Microsoft Office ou outras aplicações Windows que suportam metarquivos Windows. Diferentemente de uma imagem baseada em pixels, um EMF pode manter as operações de desenho vetorial que escalam sem perda de nitidez. No entanto, EMF é principalmente um formato de compatibilidade para aplicações com suporte a metarquivos Windows, não um formato de intercâmbio universal. Além disso, conteúdo complexo de slides, como imagens bitmap e alguns efeitos, pode ser armazenado como elementos rasterizados dentro do contêiner vetorial do metarquivo.

### **Exportar um Slide para EMF**

O método [Slide.write_as_emf](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/write_as_emf/) grava um [Slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/) em um fluxo de destino no formato EMF. O exemplo a seguir carrega uma apresentação, seleciona o primeiro slide e o grava em um fluxo de arquivo EMF:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

O chamador possui o fluxo passado para [Slide.write_as_emf](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/write_as_emf/) e deve fechá‑lo. Aspose.Slides grava na posição atual do fluxo e deixa o fluxo aberto.

### **Converter uma Imagem SVG para EMF e adicioná‑la a uma Apresentação**

Use [SvgImage.write_as_emf](https://reference.aspose.com/slides/pt/python-net/aspose.slides/svgimage/write_as_emf/) para converter conteúdo SVG em EMF. Os bytes resultantes podem ser adicionados à apresentação através de [ImageCollection.add_image](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imagecollection/add_image/) e colocados em um slide com [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/add_picture_frame/).

O exemplo a seguir cria um [SvgImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/svgimage/) a partir de marcação SVG, converte‑o em um EMF em memória, insere o metarquivo no primeiro slide e salva a apresentação:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/pt/python-net/aspose.slides/svgimage/write_as_emf/) não assume a propriedade do fluxo de destino. Após a gravação, a posição do fluxo está no final dos dados gerados. Chame `getvalue` para obter o buffer completo independentemente da posição atual do fluxo, como mostrado acima. Mantenha o fluxo aberto até que os dados sejam lidos e feche‑o depois.

A geração de EMF está disponível nos sistemas operacionais suportados pelo Aspose.Slides for Python via .NET, mas a renderização pode variar entre plataformas quando fontes ou dependências gráficas nativas não estão disponíveis. Instale as fontes usadas pelo conteúdo de origem ou configure substituições adequadas, siga os [requisitos de plataforma](/slides/pt/python-net/system-requirements/) para Aspose.Slides e valide o resultado na aplicação que consumirá o EMF. Aplicações Linux e macOS costumam ter suporte limitado ou inconsistente para exibir e editar metarquivos Windows.

## **Renderização de Emoji Colorido**

{{% alert title="Nota" color="info" %}}

Para renderizar emojis coloridos corretamente ao converter slides de apresentações em imagens, as fontes de emoji usadas na apresentação devem estar instaladas e disponíveis no sistema que realiza a conversão. Por exemplo, se a apresentação usa **Segoe UI Emoji** e essa fonte está ausente, os emojis podem aparecer em monocromático nas imagens de saída.

{{% /alert %}}

## **FAQ**

**O Aspose.Slides suporta renderização de slides com animações?**

Não. O método [Slide.get_image](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/get_image/) renderiza uma imagem estática do slide e não exporta animações.

**Slides ocultos podem ser exportados como imagens?**

Sim. Slides ocultos podem ser renderizados como slides normais. Inclua‑os no loop de processamento, como mostrado no exemplo acima.

**Sombras e outros efeitos são preservados nas imagens dos slides?**

Sim. Aspose.Slides renderiza sombras, transparência e outros efeitos gráficos suportados nas imagens dos slides.