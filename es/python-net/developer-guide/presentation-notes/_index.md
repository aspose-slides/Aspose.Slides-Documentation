---
title: Administrar notas de presentación en Python
linktitle: Notas de presentación
type: docs
weight: 110
url: /es/python-net/presentation-notes/
keywords:
- notas
- diapositiva de notas
- agregar notas
- eliminar notas
- estilo de notas
- notas maestras
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Personaliza las notas de presentación con Aspose.Slides para Python mediante .NET. Trabaja sin problemas con notas de PowerPoint y OpenDocument para aumentar tu productividad."
---

Aspose.Slides admite la eliminación de diapositivas de notas de una presentación. En este tema, presentaremos esta nueva funcionalidad de eliminar notas y también de agregar diapositivas con estilo de notas a cualquier presentación. Aspose.Slides para Python mediante .NET ofrece la capacidad de eliminar notas de cualquier diapositiva, así como de añadir estilo a notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

- Eliminar notas de una diapositiva específica de una presentación.
- Eliminar notas de todas las diapositivas de una presentación.

## **Eliminar notas de una diapositiva**
Las notas de una diapositiva específica pueden eliminarse como se muestra en el ejemplo a continuación:

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Removing notes of first slide
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # save presentation to disk
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminar notas de todas las diapositivas**
Las notas de todas las diapositivas de una presentación pueden eliminarse como se muestra en el ejemplo a continuación:

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Removing notes of all slides
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # save presentation to disk
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Agregar estilo a las notas**
La propiedad NotesStyle se ha añadido a la interfaz [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) y a la clase [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/). Esta propiedad especifica el estilo del texto de las notas. La implementación se muestra en el ejemplo a continuación.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents the presentation file
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Get MasterNotesSlide text style
        notesStyle = notesMaster.notes_style

        #Set symbol bullet for the first level paragraphs
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # save the PPTX file to the Disk
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**¿Qué entidad de la API proporciona acceso a las notas de una diapositiva específica?**

Las notas se acceden a través del administrador de notas de la diapositiva: la diapositiva tiene un [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) y una [propiedad](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/) que devuelve el objeto de notas, o `None` si no existen notas.

**¿Existen diferencias en el soporte de notas entre las distintas versiones de PowerPoint con las que funciona la biblioteca?**

La biblioteca está diseñada para un amplio rango de formatos de Microsoft PowerPoint (97‑más recientes) y ODP; las notas son compatibles dentro de estos formatos sin depender de una copia instalada de PowerPoint.