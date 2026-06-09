---
title: Gerenciar sobrescrito e subscrito em Python
linktitle: Sobrescrito e Subscrito
type: docs
weight: 80
url: /pt/python-net/superscript-and-subscript/
keywords:
- sobrescrito
- subscrito
- adicionar sobrescrito
- adicionar subscrito
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Domine sobrescrito e subscrito no Aspose.Slides para Python via .NET e eleve suas apresentações com formatação de texto profissional para máximo impacto."
---
## **Visão geral**

Aspose.Slides oferece recursos para integrar texto sobrescrito e subscrito em suas apresentações PowerPoint (PPT, PPTX) e OpenDocument (ODP). Seja para destacar fórmulas químicas, equações matemáticas ou anotar conteúdo com notas de rodapé, essas opções de formatação especial ajudam a manter clareza e precisão. Neste artigo, você aprenderá como aplicar estilos de sobrescrito e subscrito de forma fluida e garantir resultados profissionais em cada slide.

## **Adicionar texto sobrescrito e subscrito**

Você pode adicionar texto sobrescrito e subscrito a qualquer porção de parágrafo. No Aspose.Slides, use a propriedade `escapement` da classe [PortionFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/) para controlar isso.

`escapement` é uma porcentagem de **-100% a 100%**:

- **> 0** → sobrescrito (por exemplo, 25% = elevação leve; 100% = sobrescrito completo)
- **0** → linha base (sem sobrescrito/subscrito)
- **< 0** → subscrito (por exemplo, -25% = redução leve; -100% = subscrito completo)

1. Crie uma [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e obtenha um slide.  
2. Adicione um retângulo [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) e acesse seu [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/).  
3. Limpe os parágrafos existentes.  
4. Para sobrescrito: crie um parágrafo e uma porção, defina `portion.portion_format.escapement` para um valor entre **0 e 100**, defina o texto e adicione a porção.  
5. Para subscrito: crie outro parágrafo e uma porção, defina `escapement` para um valor entre **-100 e 0**, defina o texto e adicione a porção.  
6. Salve a apresentação como PPTX.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Obter um slide.
    slide = presentation.slides[0]

    # Criar uma caixa de texto.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # Criar um parágrafo para texto sobrescrito.
    superscript_paragraph = slides.Paragraph()

    # Criar uma porção de texto com texto normal.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # Criar uma porção de texto com texto sobrescrito.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # Criar um parágrafo para o texto subscrito.
    subscript_paragraph = slides.Paragraph()

    # Criar uma porção de texto com texto normal.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # Criar uma porção de texto com texto subscrito.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # Adicionar os parágrafos à caixa de texto.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso aplicar sobrescrito/subscrito em tabelas e outros contêineres, não apenas em caixas de texto normais?**

Sim. Você pode formatar o texto como sobrescrito ou subscrito dentro de qualquer objeto que exponha um [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) (incluindo células de tabela). A formatação é aplicada às porções de texto dentro desse frame.

**Os sobrescritos/subscritos serão preservados ao exportar para PDF, HTML ou imagens?**

Sim. Aspose.Slides preserva a formatação de sobrescrito/subscrito durante a exportação para formatos comuns como [PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/pt/python-net/convert-powerpoint-to-html/) e [raster images](/slides/pt/python-net/convert-powerpoint-to-png/) porque o pipeline de renderização respeita a formatação de texto em nível de porção.

**Posso combinar sobrescrito/subscrito com hyperlinks no mesmo fragmento de texto?**

Sim. [Hyperlinks](/slides/pt/python-net/manage-hyperlinks/) são atribuídos ao nível da porção (fragmento), de modo que uma porção pode ter simultaneamente um hyperlink e estar formatada como sobrescrito ou subscrito.