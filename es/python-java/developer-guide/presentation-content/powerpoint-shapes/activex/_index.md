---
title: Gestionar controles ActiveX en presentaciones usando Python
linktitle: ActiveX
type: docs
weight: 80
url: /es/python-java/activex/
keywords:
- ActiveX
- Control ActiveX
- gestionar ActiveX
- añadir ActiveX
- modificar ActiveX
- reproductor multimedia
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Edite cuadros de texto y botones ActiveX, actualice vistas previas de controles y reutilice un control Windows Media Player en presentaciones de PowerPoint con Aspose.Slides para Python vía Java."
---
## **Introducción**

Los controles ActiveX proporcionan a una diapositiva de PowerPoint elementos interactivos como cuadros de texto, botones de comando y reproductores multimedia. Aspose.Slides para Python vía Java expone los controles de una diapositiva a través de [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls). Utilice esta colección para editar un control, moverlo en la diapositiva o eliminarlo.

## **Enumerar controles ActiveX y sus propiedades almacenadas**

Para inspeccionar una plantilla desconocida, ábrala en modo lectura y recorra los controles de cada diapositiva. El ejemplo muestra el número de diapositiva, el nombre del control, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId), y cada par clave‑valor en [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties). Lee la presentación sin activar los controles, sin invocar eventos o macros, sin modificar valores ni guardar el archivo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
```

La salida seleccionada de `ActiveX.pptm` muestra un cuadro de texto y un botón de comando.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Una colección de propiedades vacía aparece como `[]`. Para los controles que utilizan almacenamiento binario, [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) puede devolver `None`, que se muestra como `Properties unavailable`. Si solo necesita los nombres, utilice [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) después de comprobar que la colección está disponible. El informe enumera las propiedades disponibles en la presentación. Un control puede admitir propiedades adicionales en tiempo de ejecución.

## **Modificar controles ActiveX**

El ejemplo supone una presentación con macros habilitadas que contiene un cuadro de texto llamado `TextBox1` y un botón de comando llamado `CommandButton1` en la primera diapositiva. Utiliza la [control properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) para cambiar el valor del cuadro de texto y el texto del botón. Cada control también tiene una vista previa estática que PowerPoint puede mostrar antes de la activación. Proporcione un PNG para cada control que muestre su texto y apariencia actualizados. El ejemplo asigna estas imágenes mediante [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat).

El ejemplo desplaza todos los controles de la primera diapositiva 100 puntos hacia abajo estableciendo su marco con [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame). Guarda la presentación editada en formato PPTM y, a continuación, utiliza [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) para guardar una segunda copia con todos los controles ActiveX eliminados de esa diapositiva.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **Agregar un control ActiveX de reproductor multimedia**

Para reutilizar un control Windows Media Player configurado, comience con una plantilla cuya primera diapositiva contenga un reproductor llamado `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) copia la diapositiva completa a una nueva presentación. El ejemplo establece la `URL` del reproductor en su [properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) y guarda la diapositiva clonada como la única diapositiva del resultado. El vídeo permanece externo, por lo que debe elegir una ruta a la que el reproductor pueda acceder durante la reproducción.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **Preguntas frecuentes**

**¿Puede Aspose.Slides conservar los controles ActiveX sin ejecutarlos?**

Sí. Aspose.Slides puede leer y guardar los controles, incluidas sus propiedades y posiciones, sin activarlos.

**¿En qué se diferencian los controles ActiveX de los objetos OLE?**

Los controles ActiveX permiten a los usuarios interactuar con una diapositiva, por ejemplo introduciendo texto o pulsando un botón. Un [OLE object](/slides/es/python-java/manage-ole/) permite que una diapositiva contenga o enlace a contenido gestionado por otra aplicación, como una hoja de cálculo de Excel.

**¿Seguirán los eventos ActiveX activar macros VBA después de guardar una presentación con Aspose.Slides?**

Guarde la presentación en un formato con macros habilitadas, como PPTM, para conservar su proyecto VBA. PowerPoint para Windows puede ejecutar los controladores de eventos existentes cuando su configuración de seguridad permite tanto controles ActiveX como macros.