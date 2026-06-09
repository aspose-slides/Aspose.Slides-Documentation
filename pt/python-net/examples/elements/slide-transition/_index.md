---
title: "Transição de Slide"
type: docs
weight: 110
url: /pt/python-net/examples/elements/slide-transition/
keywords:
- transição de slide
- adicionar transição de slide
- acessar transição de slide
- remover transição de slide
- duração da transição
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Controle as transições de slides em Python com Aspose.Slides: escolha tipos, velocidade, som e tempo para aprimorar apresentações em PPT, PPTX e ODP."
---
Demonstra a aplicação de efeitos de transição de slides e tempos com **Aspose.Slides for Python via .NET**.

## **Adicionar uma Transição de Slide**

Aplique um efeito de transição fade ao primeiro slide.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Aplicar uma transição fade.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar uma Transição de Slide**

Leia o tipo de transição atualmente atribuído a um slide.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Acessar o tipo de transição.
        transition_type = slide.slide_show_transition.type
```

## **Remover uma Transição de Slide**

Remova qualquer efeito de transição definindo o tipo como `NONE`.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Remover a transição definindo NONE.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir a Duração da Transição**

Especifique por quanto tempo o slide é exibido antes de avançar automaticamente.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # em milissegundos.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```