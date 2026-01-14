---
title: Gestionar notas de la presentación en Python
linktitle: Notas de la presentación
type: docs
weight: 110
url: /es/python-net/presentation-notes/
keywords:
- notas
- diapositiva de notas
- añadir notas
- eliminar notas
- estilo de notas
- notas maestras
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Personaliza las notas de la presentación con Aspose.Slides para Python mediante .NET. Trabaja sin problemas con notas de PowerPoint y OpenDocument para aumentar tu productividad."
---

Aspose.Slides admite eliminar diapositivas de notas de una presentación. En este tema, presentaremos esta nueva funcionalidad de eliminar notas y también de añadir diapositivas con estilo de notas a cualquier presentación. Aspose.Slides for Python mediante .NET ofrece la capacidad de eliminar notas de cualquier diapositiva, así como de añadir estilo a las notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

- Eliminar notas de una diapositiva específica de una presentación.
- Eliminar notas de todas las diapositivas de una presentación.

## **Eliminar notas de la diapositiva**
Las notas de una diapositiva concreta pueden eliminarse como se muestra en el ejemplo a continuación:
```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Eliminar notas de la primera diapositiva
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # guardar la presentación en disco
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Eliminar notas de todas las diapositivas**
Las notas de todas las diapositivas de una presentación pueden eliminarse como se muestra en el ejemplo a continuación:
```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Eliminar notas de todas las diapositivas
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # guardar la presentación en disco
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Añadir NotesStyle**
La propiedad [notes_style](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/notes_style/) se ha añadido a la clase [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/). Esta propiedad especifica el estilo del texto de notas. La implementación se muestra en el ejemplo a continuación.
```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa el archivo de presentación
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Obtener el estilo de texto de MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Set Establecer viñeta de símbolo para los párrafos del primer nivel
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # guardar el archivo PPTX en el disco
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**¿Qué entidad de la API permite acceder a las notas de una diapositiva específica?**

Las notas se acceden a través del gestor de notas de la diapositiva: la diapositiva tiene un [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) y una [property](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/) que devuelve el objeto de notas, o `None` si no hay notas.

**¿Existen diferencias en el soporte de notas entre las versiones de PowerPoint con las que funciona la biblioteca?**

La biblioteca está orientada a un amplio rango de formatos de Microsoft PowerPoint (97 y posteriores) y ODP; las notas son compatibles en estos formatos sin depender de una copia instalada de PowerPoint.