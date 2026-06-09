---
title: Slide
type: docs
weight: 10
url: /pt/python-net/examples/elements/slide/
keywords:
- slide
- adicionar slide
- acessar slide
- índice do slide
- clonar slide
- reordenar slides
- remover slide
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Gerencie slides em Python com Aspose.Slides: crie, clone, reorganize, oculte, defina planos de fundo e tamanho, aplique transições e exporte para PowerPoint e OpenDocument."
---
Este artigo fornece uma série de exemplos que demonstram como trabalhar com slides usando **Aspose.Slides for Python via .NET**. Você aprenderá como adicionar, acessar, clonar, reorganizar e remover slides usando a classe `Presentation`.

Cada exemplo abaixo inclui uma breve explicação seguida por um trecho de código em Python.

## **Adicionar um Slide**

Para adicionar um novo slide, você deve primeiro selecionar um layout. Neste exemplo, usamos o layout `Blank` e adicionamos um slide vazio à apresentação.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # Cada slide é baseado em um layout, que por sua vez é baseado em um slide mestre.
        # Use o layout Blank para criar um novo slide.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Add a new empty slide using the selected layout.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Dica:** Cada layout de slide é derivado de um slide mestre, que define o design geral e a estrutura de marcadores de posição. A imagem abaixo ilustra como os slides mestres e seus layouts associados são organizados no PowerPoint.

![Relacionamento de Mestre e Layout](master-layout-slide.png)

## **Acessar Slides por Índice**

Você pode acessar slides usando seu índice. Isso é útil para iterar ou modificar slides específicos.

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # Acesse um slide por índice.
        first_slide = presentation.slides[0]
```

## **Clonar um Slide**

Este exemplo demonstra como clonar um slide existente. O slide clonado é adicionado automaticamente ao final da coleção de slides.

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Clone o slide; ele será adicionado ao final da apresentação.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **Reordenar Slides**

Você pode mudar a ordem dos slides movendo um para um novo índice. Neste caso, movemos um slide para a primeira posição.

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # Mova o slide para a primeira posição (os demais deslocam para baixo).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **Remover um Slide**

Para remover um slide, basta referenciá-lo e chamar `remove`. Este exemplo remove o primeiro slide.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Remova o slide.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```