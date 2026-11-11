---
title: Gestionar notas de presentación en Python
linktitle: Notas de presentación
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
## **Descripción general**

Aspose.Slides permite eliminar diapositivas de notas de una presentación. En este tema, presentaremos esta característica, incluida la forma de eliminar notas y de aplicar un estilo a las diapositivas de notas en una presentación. Aspose.Slides le permite eliminar notas de cualquier diapositiva y también aplicar estilo a las notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

- Eliminar notas de una diapositiva específica en una presentación.
- Eliminar notas de todas las diapositivas de una presentación.

Para leer o cambiar las dimensiones de la página de notas, cambiar la orientación y comprobar el comportamiento de exportación, consulte [Notes Page Size](/slides/es/python-net/notes-size/).

## **Eliminar notas de una diapositiva**
Las notas de una diapositiva específica pueden eliminarse como se muestra en el siguiente ejemplo:

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Eliminando notas de la primera diapositiva
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # guardar la presentación en disco
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminar notas de todas las diapositivas**
Las notas de todas las diapositivas de una presentación pueden eliminarse como se muestra en el siguiente ejemplo:

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Eliminando notas de todas las diapositivas
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # guardar la presentación en disco
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aplicar un estilo a las notas**
La propiedad [notes_style](https://reference.aspose.com/slides/es/python-net/aspose.slides/masternotesslide/notes_style/) se ha añadido a la clase [MasterNotesSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/masternotesslide/). Esta propiedad especifica el estilo del texto de las notas. La implementación se muestra en el siguiente ejemplo.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa el archivo de presentación
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Obtener el estilo de texto de MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Establecer viñeta de símbolo para los párrafos de primer nivel
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # guardar el archivo PPTX en el disco
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Qué entidad de la API proporciona acceso a las notas de una diapositiva específica?**

Las notas se acceden a través del gestor de notas de la diapositiva: la diapositiva tiene un [NotesSlideManager](https://reference.aspose.com/slides/es/python-net/aspose.slides/notesslidemanager/) y una [property](https://reference.aspose.com/slides/es/python-net/aspose.slides/notesslidemanager/notes_slide/) que devuelve el objeto de notas, o `None` si no hay notas.

**¿Existen diferencias en la compatibilidad con notas entre las versiones de PowerPoint con las que funciona la biblioteca?**

La biblioteca está dirigida a un amplio rango de formatos de Microsoft PowerPoint (97 y posteriores) y ODP; las notas son compatibles en estos formatos sin depender de una copia instalada de PowerPoint.