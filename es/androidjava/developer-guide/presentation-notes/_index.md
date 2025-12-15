---
title: Administrar notas de presentación en Android
linktitle: Notas de presentación
type: docs
weight: 110
url: /es/androidjava/presentation-notes/
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
- Android
- Java
- Aspose.Slides
description: "Personaliza las notas de presentación con Aspose.Slides para Android mediante Java. Trabaja sin problemas con notas de PowerPoint y OpenDocument para aumentar tu productividad."
---

{{% alert color="primary" %}} 

Aspose.Slides admite la eliminación de diapositivas de notas de una presentación. En este tema, presentaremos esta nueva función de eliminar notas y también de añadir diapositivas con estilo de notas a cualquier presentación. 

{{% /alert %}} 

Aspose.Slides for Android via Java ofrece la función de eliminar las notas de cualquier diapositiva, así como de aplicar estilo a notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

* Eliminar notas de una diapositiva específica de una presentación.
* Eliminar notas de todas las diapositivas de una presentación.


## **Eliminar notas de una diapositiva**
Las notas de una diapositiva concreta pueden eliminarse como se muestra en el ejemplo a continuación:
```java
// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Eliminando notas de la primera diapositiva
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Guardando la presentación en disco
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eliminar notas de una presentación**
Las notas de todas las diapositivas de una presentación pueden eliminarse como se muestra en el ejemplo a continuación:
```java
// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Eliminando notas de todas las diapositivas
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Guardando la presentación en disco
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Añadir un estilo de notas**
[getNotesStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) se ha añadido a la interfaz [IMasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide) y a la clase [MasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MasterNotesSlide) respectivamente. Esta propiedad especifica el estilo del texto de una nota. La implementación se muestra en el ejemplo a continuación.
```java
// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Obtener el estilo de texto de MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Establecer viñeta de símbolo para los párrafos de primer nivel
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Qué entidad de la API brinda acceso a las notas de una diapositiva específica?**

Las notas se acceden a través del gestor de notas de la diapositiva: la diapositiva tiene un [NotesSlideManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notesslidemanager/) y un [método](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) que devuelve el objeto de notas, o `null` si no existen notas.

**¿Existen diferencias en el soporte de notas entre las versiones de PowerPoint con las que funciona la biblioteca?**

La biblioteca admite una amplia gama de formatos de Microsoft PowerPoint (97‑más recientes) y ODP; las notas son compatibles en estos formatos sin depender de una copia instalada de PowerPoint.