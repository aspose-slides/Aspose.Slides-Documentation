---
title: Animar Texto do PowerPoint em Python
linktitle: Texto Animado
type: docs
weight: 60
url: /pt/python-net/animated-text/
keywords:
- texto animado
- animação de texto
- parágrafo animado
- animação de parágrafo
- efeito de animação
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Crie texto animado dinâmico em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via .NET, com exemplos de código fáceis de seguir e otimizados."
---
## **Visão geral**

Este artigo mostra como animar texto em apresentações do PowerPoint usando Aspose.Slides para Python. Você aprenderá a adicionar efeitos a parágrafos individuais, ajustar gatilhos e ler sequências de animação existentes. Ao final, será capaz de criar fluxos de trabalho reutilizáveis de animação de texto que exportam para PPTX padrão e são reproduzidos corretamente no PowerPoint.

## **Adicionar efeitos de animação de parágrafo**

O método [add_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/sequence/add_effect/) da classe [Sequence](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/sequence/) permite aplicar um efeito de animação a um único parágrafo. O código de exemplo abaixo demonstra como fazer isso:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # Selecione o parágrafo para adicionar o efeito.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Adicione um efeito de animação Fly ao parágrafo selecionado.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```

## **Obter efeitos de animação de parágrafo**

Você pode querer determinar quais efeitos de animação são aplicados a um parágrafo — por exemplo, se planeja copiar esses efeitos para outro parágrafo ou forma.

Aspose.Slides para Python permite recuperar todos os efeitos de animação aplicados aos parágrafos em um quadro de texto (forma). O código de exemplo abaixo mostra como obter os efeitos de animação de um parágrafo:

```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```

## **Perguntas frequentes**

**Como as animações de texto diferem das transições de slide e podem ser combinadas?**

As animações de texto controlam o comportamento do objeto ao longo do tempo em um slide, enquanto [transitions](/slides/pt/python-net/slide-transition/) controlam como os slides mudam. Elas são independentes e podem ser usadas juntas; a ordem de reprodução é governada pela linha do tempo da animação e pelas configurações de transição.

**As animações de texto são preservadas ao exportar para PDF ou imagens?**

Não. PDF e imagens raster são estáticas, portanto você verá apenas um estado único do slide sem movimento. Para manter o movimento, use a exportação para [video](/slides/pt/python-net/convert-powerpoint-to-video/) ou [HTML](/slides/pt/python-net/export-to-html5/).

**As animações de texto funcionam em layouts e no slide mestre?**

Os efeitos aplicados a objetos de layout/mestre são herdados pelos slides, mas seu timing e interação com animações ao nível do slide dependem da sequência final no slide.