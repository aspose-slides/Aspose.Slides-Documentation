---
title: Gestionar notas de la presentación en Python a través de Java
linktitle: Notas de la presentación
type: docs
weight: 110
url: /es/python-java/presentation-notes/
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
- Java
- Aspose.Slides
description: "Personaliza las notas de la presentación con Aspose.Slides para Python a través de Java. Trabaja sin problemas con notas de PowerPoint y OpenDocument para aumentar tu productividad."
---
## **Resumen**

Aspose.Slides admite la eliminación de diapositivas de notas de una presentación. Este tema presenta esta función, incluyendo cómo eliminar notas y cómo aplicar un estilo a las diapositivas de notas en una presentación. Aspose.Slides le permite eliminar notas de cualquier diapositiva y aplicar estilo a las notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

- Eliminar notas de una diapositiva específica de una presentación.
- Eliminar notas de todas las diapositivas de una presentación.

Para leer o cambiar las dimensiones de la página de notas, cambiar la orientación y comprobar el comportamiento de exportación, consulte [Tamaño de página de notas](/slides/es/python-java/notes-size/).

## **Eliminar notas de una diapositiva**

Las notas de una diapositiva específica pueden eliminarse como se muestra en el siguiente ejemplo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanciar un objeto Presentation que representa un archivo de presentación.
presentation = Presentation("presWithNotes.pptx")
try:
    # Eliminar notas de la primera diapositiva.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Guardar la presentación en disco.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Eliminar notas de una presentación**

Las notas de todas las diapositivas de una presentación pueden eliminarse como se muestra en el siguiente ejemplo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanciar un objeto Presentation que representa un archivo de presentación.
presentation = Presentation("presWithNotes.pptx")
try:
    # Eliminar notas de todas las diapositivas.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Guardar la presentación en disco.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Añadir un estilo de notas**

El método [getNotesStyle](https://reference.aspose.com/slides/es/python-java/aspose.slides/masternotesslide/#getNotesStyle) de la clase [MasterNotesSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/masternotesslide/) permite acceder al estilo del texto de las notas. La implementación se muestra en el ejemplo a continuación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Instanciar un objeto Presentation que representa un archivo de presentación.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Obtener el estilo de texto de la diapositiva maestra de notas.
        notes_style = notes_master.getNotesStyle()

        # Establecer viñetas de símbolo para párrafos de primer nivel.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Qué entidad de la API proporciona acceso a las notas de una diapositiva específica?**

Las notas se acceden a través del gestor de notas de la diapositiva: la diapositiva tiene un [NotesSlideManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/notesslidemanager/) y un método [getNotesSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/notesslidemanager/#getNotesSlide) que devuelve el objeto de notas, o `None` si no hay notas.

**¿Existen diferencias en la compatibilidad de notas entre las versiones de PowerPoint con las que funciona la biblioteca?**

La biblioteca está diseñada para un amplio rango de formatos de Microsoft PowerPoint (97 y posteriores) y ODP; las notas son compatibles en estos formatos sin depender de una copia instalada de PowerPoint.