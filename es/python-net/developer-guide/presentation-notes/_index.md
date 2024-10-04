---
title: Notas de Presentación
type: docs
weight: 110
url: /python-net/presentation-notes/
keywords: "Notas, notas de PowerPoint, agregar notas, eliminar notas, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Agregar y eliminar notas en presentaciones de PowerPoint en Python"
---



Aspose.Slides admite la eliminación de diapositivas de notas de una presentación. En este tema, introduciremos esta nueva característica de eliminar notas, así como agregar diapositivas de estilo de notas desde cualquier presentación. Aspose.Slides para Python a través de .NET proporciona la función de eliminar notas de cualquier diapositiva, así como agregar estilo a las notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

- Eliminar notas de una diapositiva específica de una presentación.
- Eliminar notas de todas las diapositivas de una presentación.
## **Eliminar notas de la diapositiva**
Las notas de una diapositiva específica se pueden eliminar, como se muestra en el ejemplo a continuación:

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Eliminando notas de la primera diapositiva
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # guardar la presentación en el disco
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Eliminar notas de todas las diapositivas**
Las notas de todas las diapositivas de una presentación se pueden eliminar, como se muestra en el ejemplo a continuación:

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Eliminando notas de todas las diapositivas
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # guardar la presentación en el disco
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Agregar estilo de notas**
La propiedad NotesStyle se ha agregado a [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) y a la clase [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) respectivamente. Esta propiedad especifica el estilo de un texto de notas. La implementación se demuestra en el ejemplo a continuación.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa el archivo de presentación
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Obtener el estilo de texto de MasterNotesSlide
        notesStyle = notesMaster.notes_style

        # Establecer símbolo de viñeta para los párrafos de primer nivel
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # guardar el archivo PPTX en el disco
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```