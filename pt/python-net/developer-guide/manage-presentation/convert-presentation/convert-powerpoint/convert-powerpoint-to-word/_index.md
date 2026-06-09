---
title: Converter apresentações PowerPoint em documentos Word em Python
linktitle: PowerPoint para Word
type: docs
weight: 110
url: /pt/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint para DOCX
- OpenDocument para DOCX
- apresentação para DOCX
- slide para DOCX
- PPT para DOCX
- PPTX para DOCX
- ODP para DOCX
- PowerPoint para DOC
- OpenDocument para DOC
- apresentação para DOC
- slide para DOC
- PPT para DOC
- PPTX para DOC
- ODP para DOC
- PowerPoint para Word
- OpenDocument para Word
- apresentação para Word
- slide para Word
- PPT para Word
- PPTX para Word
- ODP para Word
- converter PowerPoint
- converter OpenDocument
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- converter ODP
- Python
- Aspose.Slides
description: "Aprenda a converter de forma simples apresentações PowerPoint e OpenDocument em documentos Word usando Aspose.Slides for Python via .NET. Nosso guia passo a passo com código de exemplo em Python fornece a solução para desenvolvedores que desejam simplificar seus fluxos de trabalho de documentos."
---
## **Visão geral**

Este artigo fornece uma solução para desenvolvedores converter apresentações PowerPoint e OpenDocument em documentos Word usando Aspose.Slides for Python via .NET e Aspose.Words for Python via .NET. O guia passo a passo leva você por cada etapa do processo de conversão.

## **Converter uma apresentação em um documento Word**

Siga as instruções abaixo para converter uma apresentação PowerPoint ou OpenDocument em um documento Word:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue um arquivo de apresentação.
2. Instancie as classes [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) e [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) para gerar um documento Word.
3. Defina o tamanho da página do documento Word para corresponder ao da apresentação usando a propriedade [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).
4. Defina as margens no documento Word usando a propriedade [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).
5. Percorra todos os slides da apresentação usando a propriedade [Presentation.slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/slides/pt/).
    - Gere uma imagem do slide usando o método `get_image` da classe [Slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/) e salve-a em um fluxo de memória.
    - Adicione a imagem do slide ao documento Word usando o método `insert_image` da classe [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/).
6. Salve o documento Word em um arquivo.

Vamos supor que temos uma apresentação "sample.pptx" que se parece com isso:

![PowerPoint presentation](PowerPoint.png)

O exemplo de código Python a seguir demonstra como converter a apresentação PowerPoint em um documento Word:

```py
import aspose.slides as slides
import aspose.words as words

# Carregar um arquivo de apresentação.
with slides.Presentation("sample.pptx") as presentation:

    # Criar objetos Document e DocumentBuilder.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Definir o tamanho da página no documento Word.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Definir margens no documento Word.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # Percorrer todos os slides da apresentação.
    for slide in presentation.slides:

        # Gerar uma imagem do slide e salvá-la em um fluxo de memória.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # Adicionar a imagem do slide ao documento Word.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Salvar o documento Word em um arquivo.
    document.save("output.docx")
```

O resultado:

![Word document](Word.png)

{{% alert color="primary" %}} 

Experimente nosso [**Conversor Online de PPT para Word**](https://products.aspose.app/slides/pt/conversion/ppt-to-word) para ver o que você pode ganhar ao converter apresentações PowerPoint e OpenDocument em documentos Word. 

{{% /alert %}}

## **FAQ**

**Quais componentes precisam ser instalados para converter apresentações PowerPoint e OpenDocument em documentos Word?**

Você só precisa adicionar os pacotes correspondentes para [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) e [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) ao seu projeto Python. Ambos os pacotes funcionam como APIs independentes, e não há necessidade de instalar o Microsoft Office.

**Todos os formatos de apresentação PowerPoint e OpenDocument são suportados?**

Aspose.Slides for Python .NET [suporta todos os formatos de apresentação](/slides/pt/python-net/supported-file-formats/), incluindo PPT, PPTX, ODP e outros tipos de arquivo comuns. Isso garante que você possa trabalhar com apresentações criadas em várias versões do Microsoft PowerPoint.