---
title: ActiveX
type: docs
weight: 200
url: /es/python-java/examples/elements/activex/
keywords:
- ejemplo de código
- ActiveX
- control ActiveX
- propiedades ActiveX
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Utilice Aspose.Slides for Python via Java para agregar, acceder, eliminar y configurar controles ActiveX en presentaciones de PowerPoint con ejemplos de código prácticos."
---
Este artículo demuestra cómo agregar, acceder, eliminar y configurar controles ActiveX en una presentación usando **Aspose.Slides for Python via Java**.

Instale el paquete como se describe en [Instalación](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM y luego importa la API una vez que la JVM está en ejecución. Los ejemplos de acceso y eliminación usan `add_activex.pptm`, creado por el primer ejemplo.

## **Agregar un control ActiveX**

Inserte un control Windows Media Player en la primera diapositiva y guarde la presentación como un archivo PPTM.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Añadir un control Windows Media Player.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Acceder a un control ActiveX**

Lea el nombre y la configuración de reproducción automática del primer control ActiveX en la diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Acceder al primer control ActiveX.
            control = slide.getControls().get_Item(0)
            print("Control Name:", control.getName())
            print("autoStart:", control.getProperties().get_Item("autoStart"))
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

## **Eliminar un control ActiveX**

Elimine el primer control ActiveX de la diapositiva y guarde la presentación modificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Eliminar el primer control ActiveX.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Establecer propiedades ActiveX**

Añada un control Windows Media Player, desactive la reproducción automática y oculte sus controles de reproducción. Utilice [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/es/python-java/aspose.slides/controlpropertiescollection/#set_Item) para asignar valores de propiedad como cadenas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Añadir un control Windows Media Player y configurar sus propiedades.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```