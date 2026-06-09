---
title: Imagem
type: docs
weight: 50
url: /pt/python-net/examples/elements/picture/
keywords:
- imagem
- quadro de imagem
- adicionar imagem
- acessar imagem
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Trabalhe com imagens em Python usando Aspose.Slides: insira, substitua, recorte, compacte, ajuste transparência e efeitos, preencha formas e exporte para PPT, PPTX e ODP."
---
Mostra como inserir e acessar imagens a partir de imagens em memória usando **Aspose.Slides for Python via .NET**. Os exemplos abaixo criam uma imagem em memória, a colocam em um slide e então a recuperam.

## **Adicionar uma Imagem**

Este código carrega uma imagem de um arquivo e a insere como um quadro de imagem no primeiro slide.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Carregue uma imagem de um arquivo.
        with open("image.png", "rb") as image_stream:
            # Adicione a imagem aos recursos da apresentação.
            image = presentation.images.add_image(image_stream)

        # Insira um quadro de imagem exibindo a imagem no primeiro slide.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar uma Imagem**

Este exemplo garante que um slide contenha um quadro de imagem e, em seguida, acessa o primeiro que encontrar.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # Acesse o primeiro quadro de imagem no slide.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```