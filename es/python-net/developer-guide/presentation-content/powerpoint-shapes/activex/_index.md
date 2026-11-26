---
title: Gestionar controles ActiveX en presentaciones con Python
linktitle: ActiveX
type: docs
weight: 80
url: /es/python-net/activex/
keywords:
- ActiveX
- control ActiveX
- gestionar ActiveX
- añadir ActiveX
- modificar ActiveX
- reproductor multimedia
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Edite cuadros de texto y botones ActiveX, actualice las vistas previas de los controles y reutilice un control Windows Media Player en presentaciones de PowerPoint con Aspose.Slides para Python a través de .NET."
---
## **Introducción**

Los controles ActiveX proporcionan a una diapositiva de PowerPoint elementos interactivos como cuadros de texto, botones de comando y reproductores multimedia. Aspose.Slides for Python via .NET expone los controles de una diapositiva a través de [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/). Utilice esta colección para editar un control, moverlo en la diapositiva o eliminarlo.

## **Lista de controles ActiveX y sus propiedades almacenadas**

Para inspeccionar una plantilla desconocida, ábrala en modo lectura e itere a través de los controles de cada diapositiva. El ejemplo informa el número de diapositiva, el nombre del control, [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/), y cada par clave‑valor en [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties). Lee la presentación sin activar los controles, invocar eventos o macros, cambiar valores o guardar el archivo.

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
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

Una colección de propiedades vacía aparece como `[]`. Para los controles que utilizan almacenamiento binario, `properties` puede devolver `None`, mostrado como `Properties unavailable`. Si solo necesita los nombres, use [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) después de comprobar `None`. El informe enumera las propiedades disponibles en la presentación. Un control puede admitir propiedades adicionales en tiempo de ejecución.

## **Modificar controles ActiveX**

El ejemplo espera una presentación con macros que contenga un cuadro de texto llamado `TextBox1` y un botón de comando llamado `CommandButton1` en la primera diapositiva. Utiliza la [colección de propiedades del control](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) para cambiar el valor del cuadro de texto y el título del botón. Cada control también tiene una vista previa estática que PowerPoint puede mostrar antes de la activación. Proporcione un PNG para cada control que muestre su texto y apariencia actualizados. El ejemplo asigna estas imágenes mediante [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/).

El ejemplo desplaza cada control en la primera diapositiva 100 puntos hacia abajo cambiando su [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/). Guarda la presentación editada en formato PPTM y luego usa [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) para guardar una segunda copia con todos los controles ActiveX eliminados de esa diapositiva.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **Añadir un control ActiveX Media Player**

Para reutilizar un control Windows Media Player configurado, comience con una plantilla cuya primera diapositiva contiene un reproductor llamado `WindowsMediaPlayer1`. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) copia toda la diapositiva en una nueva presentación. El ejemplo establece la `URL` del reproductor en su [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) y guarda la diapositiva clonada como la única diapositiva en la salida. El vídeo permanece externo, por lo que debe elegir una ruta a la que el reproductor pueda acceder durante la reproducción.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Puede Aspose.Slides conservar los controles ActiveX sin ejecutarlos?**

Sí. Aspose.Slides puede leer y guardar los controles, incluidas sus propiedades y posiciones, sin activarlos.

**¿En qué se diferencian los controles ActiveX de los objetos OLE?**

Los controles ActiveX permiten a los usuarios interactuar con una diapositiva, por ejemplo introduciendo texto o pulsando un botón. Un [OLE object](/slides/es/python-net/manage-ole/) permite que una diapositiva contenga o vincule contenido gestionado por otra aplicación, como una hoja de cálculo de Excel.

**¿Seguirán los eventos ActiveX disparar macros VBA después de guardar una presentación con Aspose.Slides?**

Guarde la presentación en un formato con macros, como PPTM, para conservar su proyecto VBA. PowerPoint para Windows puede ejecutar los controladores de eventos existentes cuando su configuración de seguridad permite tanto los controles ActiveX como las macros.