---
title: Extração avançada de texto de apresentações em Python
linktitle: Extrair texto
type: docs
weight: 90
url: /pt/python-net/extract-text-from-presentation/
keywords:
- extrair texto
- extrair texto de slide
- extrair texto de apresentação
- extrair texto de PowerPoint
- extrair texto de OpenDocument
- extrair texto de PPT
- extrair texto de PPTX
- extrair texto de ODP
- recuperar texto
- recuperar texto de slide
- recuperar texto de apresentação
- recuperar texto de PowerPoint
- recuperar texto de OpenDocument
- recuperar texto de PPT
- recuperar texto de PPTX
- recuperar texto de ODP
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Extraia texto rapidamente de apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via .NET. Siga nosso guia simples, passo a passo, para economizar tempo."
---
## **Visão geral**

Extrair texto de apresentações é uma tarefa comum, porém essencial, para desenvolvedores que trabalham com conteúdo de slides. Seja lidando com arquivos Microsoft PowerPoint nos formatos PPT ou PPTX, ou apresentações OpenDocument (ODP), acessar e recuperar dados textuais pode ser crucial para análise, automação, indexação ou migração de conteúdo.

Este artigo fornece um guia completo sobre como extrair texto de forma eficiente de vários formatos de apresentação, incluindo PPT, PPTX e ODP, usando Aspose.Slides for Python via .NET. Você aprenderá como iterar sistematicamente pelos elementos da apresentação para recuperar com precisão o conteúdo textual necessário.

## **Extrair texto de um slide**

Aspose.Slides for Python via .NET fornece o namespace [aspose.slides.util](https://reference.aspose.com/slides/pt/python-net/aspose.slides.util/) que inclui a classe [SlideUtil](https://reference.aspose.com/slides/pt/python-net/aspose.slides.util/slideutil/). Essa classe expõe vários métodos estáticos sobrecarregados para extrair todo o texto de uma apresentação ou slide. Para extrair texto de um slide em uma apresentação, use o método [get_all_text_boxes](https://reference.aspose.com/slides/pt/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). Esse método aceita um objeto do tipo [BaseSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslide/) como parâmetro. Quando executado, o método varre todo o slide em busca de texto e devolve um array de objetos do tipo [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/), preservando qualquer formatação de texto.

O trecho de código a seguir extrai todo o texto do primeiro slide da apresentação:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Extrair texto de uma apresentação**

Para varrer texto de toda a apresentação, use o método estático [get_all_text_frames](https://reference.aspose.com/slides/pt/python-net/aspose.slides.util/slideutil/get_all_text_frames/) exposto pela classe [SlideUtil](https://reference.aspose.com/slides/pt/python-net/aspose.slides.util/slideutil/). Ele aceita dois parâmetros:

1. Primeiro, um objeto [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) que representa uma apresentação PowerPoint ou OpenDocument da qual o texto será extraído.  
2. Segundo, um valor `Boolean` que indica se os slides mestre devem ser incluídos ao varrer texto da apresentação.

O método devolve um array de objetos do tipo [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/), incluindo informações de formatação de texto. O código abaixo varre o texto e os detalhes de formatação de uma apresentação, incluindo os slides mestre.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Extração de texto categorizada e rápida**

A classe [PresentationFactory](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationfactory/) também fornece métodos para extrair todo o texto de apresentações:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

O argumento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textextractionarrangingmode/) indica o modo de organização do resultado da extração de texto e pode ser definido com os seguintes valores:
- `UNARRANGED` – O texto bruto sem considerar sua posição no slide.  
- `ARRANGED` – O texto é organizado na mesma ordem em que aparece no slide.

O modo `UNARRANGED` pode ser usado quando a velocidade é crítica; ele é mais rápido que o modo `ARRANGED`.

[PresentationText](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationtext/) representa o texto bruto extraído da apresentação. Sua propriedade `slides_text` devolve um array de objetos de texto de slide. Cada objeto representa o texto do slide correspondente e possui as seguintes propriedades:

- `text` – O texto dentro das formas do slide.  
- `master_text` – O texto dentro das formas do slide mestre associado a este slide.  
- `layout_text` – O texto dentro das formas do slide de layout associado a este slide.  
- `notes_text` – O texto dentro das formas da nota do slide associado a este slide.  
- `comments_text` – O texto dentro dos comentários associados a este slide.

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **Perguntas frequentes**

**Quão rápido o Aspose.Slides processa apresentações grandes durante a extração de texto?**

Aspose.Slides está otimizado para alto desempenho e pode processar até [apresentações grandes](/slides/pt/python-net/open-presentation/), tornando‑se adequado para cenários de processamento em tempo real ou em lote.

**O Aspose.Slides pode extrair texto de tabelas e gráficos dentro das apresentações?**

Sim. Aspose.Slides pode extrair texto de muitos elementos de slide, incluindo tabelas e objetos relacionados a gráficos, permitindo que você acesse e analise o conteúdo textual em estruturas de apresentação comuns.

**Preciso de uma licença especial do Aspose.Slides para extrair texto de apresentações?**

Você pode extrair texto usando a versão de avaliação gratuita do Aspose.Slides, embora ela tenha [determinadas limitações](/slides/pt/python-net/licensing/), como processamento de um número limitado de slides. Para uso irrestrito e para lidar com apresentações maiores, recomenda‑se adquirir uma licença completa.