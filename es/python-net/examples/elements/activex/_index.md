---
title: ActiveX
type: docs
weight: 200
url: /es/python-net/examples/elements/activex/
keywords:
- ActiveX
- control ActiveX
- añadir ActiveX
- acceder a ActiveX
- eliminar ActiveX
- propiedades ActiveX
- ejemplos de código
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda cómo encontrar, editar y eliminar controles ActiveX en Python con Aspose.Slides, incluyendo actualizaciones de propiedades para presentaciones de PowerPoint."
---
Demuestra cómo agregar, acceder, eliminar y configurar controles ActiveX en una presentación usando **Aspose.Slides for Python via .NET**.

## **Agregar un control ActiveX**

Insertar un nuevo control ActiveX.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Añadir un nuevo control ActiveX (TextBox).
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **Acceder a un control ActiveX**

Leer información del primer control ActiveX en la diapositiva.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Acceder al primer control ActiveX.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # Imprimir el nombre del control.
            print(f"Control Name: {control.name}")
```

## **Eliminar un control ActiveX**

Eliminar un control ActiveX existente de la diapositiva.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # Eliminar el primer control ActiveX.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **Establecer propiedades del ActiveX**

Configurar varias propiedades del ActiveX.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la colección de controles contiene al menos un control.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```