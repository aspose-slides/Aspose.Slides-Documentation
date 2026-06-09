---
title: Gerenciar Listas com Marcadores e Numeradas em Apresentações em Python
linktitle: Gerenciar Listas
type: docs
weight: 70
url: /pt/python-net/manage-lists/
keywords:
- marcador
- lista com marcadores
- lista numerada
- marcador de símbolo
- marcador de imagem
- marcador personalizado
- lista multinível
- criar marcador
- adicionar marcador
- adicionar lista
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda como criar e formatar listas com marcadores, imagem, multiníveis e numeradas em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via .NET."
---
## **Visão geral**

Aspose.Slides para Python via .NET permite criar e formatar listas com marcadores e numeradas em apresentações PowerPoint e OpenDocument. Um item de lista é um parágrafo cujas configurações de marcador são controladas por meio do seu formato de parágrafo.

Use a propriedade [Paragraph.paragraph_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/paragraph_format/) para acessar as configurações de listas no nível de parágrafo. O ponto de entrada principal é [ParagraphFormat.bullet](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/bullet/), que devolve um objeto [BulletFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/). Com esse objeto, você pode definir o tipo de marcador, símbolo, imagem, cor, tamanho, estilo de numeração e número inicial.

Este artigo mostra como:

- criar uma lista com marcadores usando um símbolo personalizado
- criar um marcador de imagem
- criar uma lista multinível definindo a profundidade do parágrafo
- criar uma lista numerada
- inspecionar e alterar a formatação de lista em uma apresentação existente

## **Criar uma lista com marcadores**

Para criar uma lista com marcadores, adicione objetos [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) a um [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) e defina [BulletFormat.type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/type/) como [BulletType.SYMBOL](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bullettype/). Em seguida, você pode definir [BulletFormat.char](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/color/) e [BulletFormat.height](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/height/) para controlar a aparência do marcador.

O código Python a seguir demonstra como criar uma lista com marcadores em um slide:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![Os marcadores de símbolo](symbol_bullets.png)

## **Criar uma lista numerada**

Use listas numeradas quando a ordem dos itens for importante. Defina [BulletFormat.type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/type/) como [BulletType.NUMBERED](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bullettype/). Você também pode escolher um formato de numeração com [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/numbered_bullet_style/) ou definir [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) quando a lista deve começar a partir de um valor diferente de 1.

O código Python a seguir mostra como criar uma lista numerada em um slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![Os marcadores numerados](numbered_bullets.png)

## **Criar um marcador de imagem**

Aspose.Slides permite substituir um símbolo de marcador padrão por uma imagem. Marcadores de imagem funcionam melhor com imagens simples que permanecem legíveis em tamanho pequeno, como ícones ou pequenos arquivos PNG transparentes.

{{% alert color="primary" %}}
Idealmente, se você pretende substituir o símbolo de marcador padrão por uma imagem, o melhor é escolher um gráfico simples com fundo transparente. Essas imagens funcionam bem como símbolos de marcador personalizados.

Lembre-se de que a imagem será reduzida a um tamanho muito pequeno. Por esse motivo, recomendamos fortemente selecionar uma imagem que permaneça clara e visualmente eficaz quando usada como marcador em uma lista.
{{% /alert %}}

Para criar um marcador de imagem, adicione uma imagem a [Presentation.images](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/images/) e atribua o objeto de imagem retornado a [BulletFormat.picture](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/picture/). Defina [BulletFormat.type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/type/) como [BulletType.PICTURE](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bullettype/) antes de atribuir a imagem.

Suponha que tenhamos um “image.png”:

![Uma imagem para os marcadores](picture_for_bullets.png)

O código Python a seguir mostra como criar marcadores de imagem em um slide:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![Os marcadores de imagem](picture_bullets.png)

## **Criar uma lista multinível**

Use [ParagraphFormat.depth](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/depth/) para colocar itens de lista em diferentes níveis. O nível 0 é o nível superior, o nível 1 está aninhado abaixo dele e assim sucessivamente.

O código Python a seguir mostra como criar uma lista com marcadores multinível:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![A lista multinível](multilevel_list.png)

## **Alterar uma lista existente**

Para alterar a formatação de lista em uma apresentação existente, acesse o parágrafo alvo e atualize suas configurações de [ParagraphFormat.bullet](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/bullet/). As mesmas propriedades usadas para criar listas podem ser usadas para inspecionar ou modificar listas carregadas de um arquivo PPT, PPTX ou ODP.

O código Python a seguir altera o primeiro parágrafo em um quadro de texto para usar um estilo de lista numerada:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**É possível exportar listas com marcadores e numeradas para PDF ou imagens?**

Sim. Aspose.Slides preserva a formatação das listas quando o formato de destino suporta o layout de texto e os recursos de marcadores correspondentes.

**Posso editar listas em apresentações existentes?**

Sim. Carregue a apresentação, acesse o parágrafo alvo, inspecione ou atualize suas configurações de [ParagraphFormat.bullet](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/bullet/), e salve a apresentação.

**As listas podem conter texto não‑latino?**

Sim. O texto dos itens de lista pode conter caracteres Unicode, permitindo criar listas em apresentações multilíngues. Certifique‑se de que as fontes usadas na apresentação suportem os caracteres necessários.