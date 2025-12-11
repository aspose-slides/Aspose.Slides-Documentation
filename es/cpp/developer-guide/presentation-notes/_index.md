---
title: Administrar notas de presentación en C++
linktitle: Notas de presentación
type: docs
weight: 110
url: /es/cpp/presentation-notes/
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
- C++
- Aspose.Slides
description: "Personaliza las notas de la presentación con Aspose.Slides para C++. Trabaja sin problemas con notas de PowerPoint y OpenDocument para impulsar tu productividad."
---

## **Agregar y eliminar notas de diapositivas**
Aspose.Slides ahora admite la eliminación de diapositivas de notas de la presentación. En este tema, presentaremos esta nueva función de eliminación de notas y también de agregar diapositivas de estilo de notas a cualquier presentación. Aspose.Slides para C++ ofrece la función de eliminar notas de cualquier diapositiva, así como agregar estilo a las notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

- Eliminar notas de una diapositiva específica de una presentación.
- Eliminar notas de todas las diapositivas de una presentación.

## **Eliminar notas de una diapositiva específica**
Las notas de una diapositiva específica pueden eliminarse como se muestra en el ejemplo a continuación:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Eliminar notas de todas las diapositivas**
Las notas de todas las diapositivas de una presentación pueden eliminarse como se muestra en el ejemplo a continuación:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Agregar un estilo de notas**
La propiedad NotesStyle se ha añadido a la interfaz IMasterNotesSlide y a la clase MasterNotesSlide respectivamente. Esta propiedad especifica el estilo del texto de notas. La implementación se muestra en el ejemplo a continuación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

**¿Qué entidad API proporciona acceso a las notas de una diapositiva específica?**

Las notas se acceden a través del gestor de notas de la diapositiva: la diapositiva tiene un [NotesSlideManager](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/) y un [method](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/get_notesslide/) que devuelve el objeto de notas, o `null` si no hay notas.

**¿Existen diferencias en el soporte de notas entre las versiones de PowerPoint con las que funciona la biblioteca?**

La biblioteca se dirige a una amplia gama de formatos de Microsoft PowerPoint (97-más recientes) y ODP; las notas son compatibles con estos formatos sin depender de una copia instalada de PowerPoint.