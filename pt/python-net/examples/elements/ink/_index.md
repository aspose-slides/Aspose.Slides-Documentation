---
title: Tinta
type: docs
weight: 180
url: /pt/python-net/examples/elements/ink/
keywords:
- tinta
- acessar tinta
- remover tinta
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Manipule tinta digital em slides no Python com Aspose.Slides: adicione traços de caneta, edite caminhos, defina cor e largura, e exporte os resultados para PowerPoint e OpenDocument."
---
Fornece exemplos de acesso a formas de tinta existentes e sua remoção usando **Aspose.Slides for Python via .NET**.

> ❗ **Observação:** As formas de tinta representam a entrada do usuário a partir de dispositivos especializados. O Aspose.Slides não pode criar novos traços de tinta programaticamente, mas você pode ler e modificar a tinta existente.

## **Acessar Tinta**

Obtenha a primeira forma de tinta de um slide.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **Remover Tinta**

Exclua uma forma de tinta do slide.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # Supondo que a primeira forma seja um objeto Ink.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```