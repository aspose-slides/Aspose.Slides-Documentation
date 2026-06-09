---
title: SmartArt
type: docs
weight: 140
url: /pt/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- adicionar SmartArt
- acessar SmartArt
- remover SmartArt
- layout SmartArt
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Crie e edite SmartArt em Python com Aspose.Slides: adicione nós, altere layouts e estilos, converta em formas com precisão e exporte para PPT, PPTX e ODP."
---
Mostra como adicionar gráficos SmartArt, acessá‑los, removê‑los e alterar layouts usando **Aspose.Slides for Python via .NET**.

## **Adicionar SmartArt**

Insira um gráfico SmartArt usando um dos layouts pré‑definidos.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar SmartArt**

Recupere o primeiro objeto SmartArt em um slide.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Acesse a primeira forma SmartArt.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **Remover SmartArt**

Exclua uma forma SmartArt do slide.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Pressupondo que a primeira forma seja um objeto SmartArt.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Alterar Layout do SmartArt**

Atualize o tipo de layout de um gráfico SmartArt existente.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Pressupondo que a primeira forma seja um objeto SmartArt.
        smart_art = slide.shapes[0]

        # Altere o layout do SmartArt.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```