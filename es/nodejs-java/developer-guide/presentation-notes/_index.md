---
title: Gestionar notas de presentación en JavaScript
linktitle: Notas de presentación
type: docs
weight: 110
url: /es/nodejs-java/presentation-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Personaliza las notas de la presentación en JavaScript con Aspose.Slides para Node.js. Trabaja sin problemas con notas de PowerPoint y OpenDocument para aumentar tu productividad."
---
## **Visión general**

Aspose.Slides admite la eliminación de diapositivas de notas de una presentación. En este tema, presentaremos esta característica, incluido cómo eliminar notas y cómo aplicar un estilo a las diapositivas de notas en una presentación. Aspose.Slides permite eliminar notas de cualquier diapositiva y también aplicar estilo a las notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

- Eliminar notas de una diapositiva específica en una presentación.
- Eliminar notas de todas las diapositivas en una presentación.

Para leer o cambiar las dimensiones de la página de notas, cambiar la orientación y verificar el comportamiento de exportación, vea [Tamaño de la página de notas](/slides/es/nodejs-java/notes-size/).

## **Eliminar notas de una diapositiva**
Las notas de una diapositiva específica pueden eliminarse como se muestra en el ejemplo a continuación:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanciar un objeto Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Eliminando notas de la primera diapositiva
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Guardando la presentación en disco
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Eliminar notas de una presentación**
Las notas de todas las diapositivas de una presentación pueden eliminarse como se muestra en el ejemplo a continuación:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanciar un objeto Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Eliminando notas de todas las diapositivas
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Guardando la presentación en disco
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Agregar NotesStyle**
El método [getNotesStyle](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) se ha añadido a la clase [MasterNotesSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/MasterNotesSlide) y a la clase [MasterNotesSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/MasterNotesSlide) respectivamente. Esta propiedad especifica el estilo del texto de una nota. La implementación se muestra en el ejemplo a continuación.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar un objeto Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Obtener el estilo de texto de MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Establecer viñeta de símbolo para los párrafos del primer nivel
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Preguntas frecuentes**

**¿Qué entidad de la API proporciona acceso a las notas de una diapositiva específica?**

Las notas se acceden a través del administrador de notas de la diapositiva: la diapositiva tiene un [NotesSlideManager](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notesslidemanager/) y un [método](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) que devuelve el objeto de notas, o `null` si no hay notas.

**¿Existen diferencias en la compatibilidad de notas entre las versiones de PowerPoint con las que funciona la biblioteca?**

La biblioteca se orienta a una amplia gama de formatos de Microsoft PowerPoint (97 y versiones posteriores) y ODP; las notas son compatibles en estos formatos sin depender de una copia instalada de PowerPoint.