---
title: Gestionar notas de la presentación en Python
linktitle: Notas de la presentación
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
description: "Personaliza las notas de la presentación con Aspose.Slides para Python a través de .NET. Trabaja sin problemas con notas de PowerPoint y OpenDocument para mejorar tu productividad."
---

Aspose.Slides admite la eliminación de diapositivas de notas de una presentación. En este tema, presentaremos esta nueva función de eliminación de notas y también la adición de diapositivas con estilo de notas desde cualquier presentación. Aspose.Slides for Python via .NET proporciona la función de eliminar notas de cualquier diapositiva, así como de añadir estilo a las notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

- Eliminar notas de una diapositiva específica de una presentación.
- Eliminar notas de todas las diapositivas de una presentación.

## **Eliminar notas de la diapositiva**
Las notas de una diapositiva específica pueden eliminarse como se muestra en el ejemplo a continuación:
```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Eliminar notas de la primera diapositiva
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # Guardar la presentación en disco
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
    # Guardar la presentación en disco
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Agregar NotesStyle**
La propiedad NotesStyle se ha añadido a la interfaz [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) y a la clase [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) respectivamente. Esta propiedad especifica el estilo del texto de notas. La implementación se muestra en el ejemplo a continuación.
```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa el archivo de presentación
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Obtener el estilo de texto de MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Establecer viñeta de símbolo para los párrafos de primer nivel
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # Guardar el archivo PPTX en el disco
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas frecuentes**

**¿Qué entidad de la API brinda acceso a las notas de una diapositiva específica?**

Las notas se acceden a través del gestor de notas de la diapositiva: la diapositiva tiene un [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) y una [propiedad](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/) que devuelve el objeto de notas, o `None` si no hay notas.

**¿Existen diferencias en la compatibilidad de notas entre las versiones de PowerPoint con las que funciona la biblioteca?**

La biblioteca está dirigida a una amplia gama de formatos de Microsoft PowerPoint (97–newer) y ODP; las notas son compatibles en estos formatos sin depender de una copia instalada de PowerPoint.