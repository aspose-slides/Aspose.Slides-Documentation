---
title: Gerenciar Hyperlinks em Apresentações com Python
linktitle: Gerenciar Hyperlink
type: docs
weight: 20
url: /pt/python-net/manage-hyperlinks/
keywords:
- adicionar URL
- adicionar hyperlink
- criar hyperlink
- formatar hyperlink
- remover hyperlink
- atualizar hyperlink
- hyperlink de texto
- hyperlink de slide
- hyperlink de forma
- hyperlink de imagem
- hyperlink de vídeo
- hyperlink mutável
- PowerPoint
- OpenDocument
- apresentação
- Python
description: "Gerencie hyperlinks de forma fácil em apresentações PowerPoint e OpenDocument com Aspose.Slides for Python via .NET — melhore a interatividade e o fluxo de trabalho em minutos."
---
## **Introdução**

Um hyperlink é uma referência a um recurso externo, um objeto ou item de dados, ou a um local específico dentro de um arquivo. Os tipos comuns de hyperlink em apresentações do PowerPoint incluem:

* Links para sites incorporados em texto, formas ou mídia
* Links para slides

Aspose.Slides for Python via .NET permite uma ampla gama de operações relacionadas a hyperlinks em apresentações.

## **Adicionar Hyperlinks de URL**

Esta seção explica como adicionar hyperlinks de URL a elementos de slides ao trabalhar com Aspose.Slides. Ela aborda a atribuição de endereços de link a texto, formas e imagens para garantir navegação fluida durante as apresentações.

### **Adicionar Hyperlinks de URL ao Texto**

O exemplo de código a seguir mostra como adicionar um hyperlink de site ao texto:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Adicionar Hyperlinks de URL a Formas ou Quadros**

O exemplo de código a seguir mostra como adicionar um hyperlink de site a uma forma:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Adicionar Hyperlinks de URL a Mídia**

Aspose.Slides permite adicionar hyperlinks a imagens, arquivos de áudio e vídeo.

O exemplo de código a seguir mostra como adicionar um hyperlink a uma **imagem**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adicionar uma imagem à apresentação.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Criar um quadro de imagem no slide 1 usando a imagem adicionada anteriormente.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

O exemplo de código a seguir mostra como adicionar um hyperlink a um **arquivo de áudio**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

O exemplo de código a seguir mostra como adicionar um hyperlink a um **vídeo**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Você pode querer ver [Gerenciar OLE em Apresentações Usando Python](/slides/pt/python-net/manage-ole/).
{{% /alert %}}

## **Usar Hyperlinks para Criar um Sumário**

Como os hyperlinks permitem que você faça referência a objetos ou locais, pode usá‑los para criar um sumário.

O código de exemplo abaixo mostra como criar um sumário com hyperlinks:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Formatar Hyperlinks**

Esta seção mostra como formatar a aparência dos hyperlinks no Aspose.Slides. Você aprenderá a controlar a cor e outras opções de estilo para manter a formatação de hyperlinks consistente em texto, formas e imagens.

### **Cor do Hyperlink**

Usando a propriedade [color_source](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/color_source/) da classe [Hyperlink](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/), você pode definir a cor de um hyperlink e ler suas informações de cor. Esse recurso foi introduzido no PowerPoint 2019, portanto as alterações feitas através desta propriedade não se aplicam às versões anteriores do PowerPoint.

O exemplo a seguir demonstra como adicionar hyperlinks com cores diferentes ao mesmo slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Remover Hyperlinks de Apresentações**

Esta seção explica como remover hyperlinks de apresentações ao trabalhar com Aspose.Slides. Você aprenderá a limpar os destinos de link de texto, formas e imagens, preservando o conteúdo e a formatação originais.

### **Remover Hyperlinks do Texto**

O exemplo de código a seguir mostra como remover hyperlinks do texto em um slide de apresentação:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **Remover Hyperlinks de Formas ou Quadros**

O exemplo de código a seguir mostra como remover hyperlinks de formas em um slide de apresentação: 

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperlinks Mutáveis**

A classe [Hyperlink](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/) é mutável. Usando esta classe, você pode alterar os valores dessas propriedades:

- [target_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

O trecho de código a seguir mostra como adicionar um hyperlink a um slide e depois editar sua dica de ferramenta:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Propriedades Compatíveis em IHyperlinkQueries**

Você pode acessar [HyperlinkQueries](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkqueries/) a partir da apresentação, do slide ou do texto que contém o hyperlink.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/hyperlink_queries/)

A classe [HyperlinkQueries](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkqueries/) suporta estes métodos: 

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Você pode querer conferir o simples e gratuito [editor de PowerPoint online da Aspose](https://products.aspose.app/slides/pt/editor).
{{% /alert %}}

## **FAQ**

**Como posso criar navegação interna não apenas para um slide, mas para uma “seção” ou o primeiro slide de uma seção?**

As seções no PowerPoint são agrupamentos de slides; a navegação tecnicamente aponta para um slide específico. Para “navegar para uma seção”, normalmente você cria um link para o seu primeiro slide.

**Posso anexar um hyperlink a elementos do slide mestre para que funcione em todos os slides?**

Sim. Elementos do slide mestre e dos layouts suportam hyperlinks. Esses links aparecem nos slides filhos e são clicáveis durante a apresentação.

**Os hyperlinks serão preservados ao exportar para PDF, HTML, imagens ou vídeo?**

Em [PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/) e [HTML](/slides/pt/python-net/convert-powerpoint-to-html/), sim — os links geralmente são preservados. Ao exportar para [imagens](/slides/pt/python-net/convert-powerpoint-to-png/) e [vídeo](/slides/pt/python-net/convert-powerpoint-to-video/), a capacidade de clicar não será mantida devido à natureza desses formatos (quadros raster/vídeo não suportam hyperlinks).