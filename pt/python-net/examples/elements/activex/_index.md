---
title: ActiveX
type: docs
weight: 200
url: /pt/python-net/examples/elements/activex/
keywords:
- ActiveX
- controle ActiveX
- adicionar ActiveX
- acessar ActiveX
- remover ActiveX
- propriedades ActiveX
- exemplos de código
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda como encontrar, editar e remover controles ActiveX em Python com Aspose.Slides, incluindo atualização de propriedades para apresentações PowerPoint."
---
Demonstra como adicionar, acessar, remover e configurar controles ActiveX em uma apresentação usando **Aspose.Slides for Python via .NET**.

## **Adicionar um Controle ActiveX**

Insira um novo controle ActiveX.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Adiciona um novo controle ActiveX (TextBox).
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **Acessar um Controle ActiveX**

Leia informações do primeiro controle ActiveX no slide.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Acessa o primeiro controle ActiveX.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # Imprime o nome do controle.
            print(f"Control Name: {control.name}")
```

## **Remover um Controle ActiveX**

Exclua um controle ActiveX existente do slide.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # Remove o primeiro controle ActiveX.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **Definir Propriedades do ActiveX**

Configure várias propriedades do ActiveX.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Assumindo que a coleção de controles contém ao menos um controle.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```