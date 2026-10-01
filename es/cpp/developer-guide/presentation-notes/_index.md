---
title: Gestionar notas de la presentación en C++
linktitle: Notas de presentación
type: docs
weight: 110
url: /es/cpp/presentation-notes/
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
- C++
- Aspose.Slides
description: "Personaliza las notas de la presentación con Aspose.Slides para C++. Trabaja sin problemas con notas de PowerPoint y OpenDocument para aumentar tu productividad."
---
## **Resumen**

Aspose.Slides admite la eliminación de diapositivas de notas de una presentación. En este tema, presentaremos esta función, incluido cómo eliminar notas y cómo aplicar un estilo a las diapositivas de notas en una presentación. Aspose.Slides permite eliminar notas de cualquier diapositiva y también aplicar estilos a notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

- Eliminar notas de una diapositiva específica de una presentación.
- Eliminar notas de todas las diapositivas de una presentación.

Para leer o cambiar las dimensiones de la página de notas, cambiar la orientación y comprobar el comportamiento de exportación, vea [Tamaño de la página de notas](/slides/es/cpp/notes-size/).

## **Eliminar notas de una diapositiva específica**
Las notas de una diapositiva específica pueden eliminarse como se muestra en el ejemplo siguiente:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Eliminar notas de todas las diapositivas**
Las notas de todas las diapositivas de una presentación pueden eliminarse como se muestra en el ejemplo siguiente:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Añadir un estilo de notas**
La propiedad NotesStyle se ha añadido a la interfaz IMasterNotesSlide y a la clase MasterNotesSlide. Esta propiedad especifica el estilo del texto de las notas. La implementación se muestra en el ejemplo siguiente.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

### ¿Qué entidad de la API proporciona acceso a las notas de una diapositiva específica?

Las notas se acceden a través del gestor de notas de la diapositiva: la diapositiva tiene un [NotesSlideManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/notesslidemanager/) y un [method](https://reference.aspose.com/slides/es/cpp/aspose.slides/notesslidemanager/get_notesslide/) que devuelve el objeto de notas, o `null` si no existen notas.

### ¿Existen diferencias en el soporte de notas entre las versiones de PowerPoint con las que funciona la biblioteca?

La biblioteca está diseñada para un amplio rango de formatos de Microsoft PowerPoint (97-más reciente) y ODP; las notas son compatibles dentro de estos formatos sin depender de una copia instalada de PowerPoint.