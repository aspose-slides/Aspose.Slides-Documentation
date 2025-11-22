---
title: Notas de la presentación
type: docs
weight: 110
url: /es/nodejs-java/presentation-notes/
keywords: "Notas del presentador de PowerPoint en JavaScript"
description: "Notas de la presentación, notas del presentador en JavaScript"
---

{{% alert color="primary" %}} 

Aspose.Slides admite la eliminación de diapositivas de notas de una presentación. En este tema, presentaremos esta nueva función de eliminar notas y también agregar diapositivas de estilo de notas a cualquier presentación. 

{{% /alert %}} 

Aspose.Slides para Node.js mediante Java ofrece la función de eliminar notas de cualquier diapositiva, así como agregar estilo a notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

* Eliminar notas de una diapositiva específica de una presentación.
* Eliminar notas de todas las diapositivas de una presentación


## **Eliminar notas de la diapositiva**
Las notas de una diapositiva específica pueden eliminarse como se muestra en el ejemplo a continuación:
```javascript
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


## **Eliminar notas de la presentación**
Las notas de todas las diapositivas de una presentación pueden eliminarse como se muestra en el ejemplo a continuación:
```javascript
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
El método [getNotesStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) se ha añadido a la clase [MasterNotesSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide) y a la clase [MasterNotesSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide) respectivamente. Esta propiedad especifica el estilo del texto de una nota. La implementación se muestra en el ejemplo a continuación.
```javascript
// Instanciar un objeto Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Obtener el estilo de texto de MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Establecer viñeta de símbolo para los párrafos de primer nivel
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Qué entidad de la API proporciona acceso a las notas de una diapositiva específica?**

Las notas se acceden a través del administrador de notas de la diapositiva: la diapositiva tiene un [NotesSlideManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notesslidemanager/) y un [method](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) que devuelve el objeto de notas, o `null` si no hay notas.

**¿Existen diferencias en el soporte de notas entre las versiones de PowerPoint con las que funciona la biblioteca?**

La biblioteca es compatible con una amplia gama de formatos de Microsoft PowerPoint (97-en adelante) y ODP; las notas se admiten en estos formatos sin depender de una copia instalada de PowerPoint.