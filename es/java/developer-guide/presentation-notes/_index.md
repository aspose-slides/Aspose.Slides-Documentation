---
title: Notas de Presentación
type: docs
weight: 110
url: /es/java/presentation-notes/
keywords: "Notas de orador de PowerPoint en Java"
description: "Notas de presentación, notas de orador en Java"
---


{{% alert color="primary" %}} 

Aspose.Slides soporta la eliminación de diapositivas de notas de una presentación. En este tema, introduciremos esta nueva función de eliminar notas y también agregar diapositivas de estilo de notas de cualquier presentación. 

{{% /alert %}} 

Aspose.Slides para Java proporciona la función de eliminar notas de cualquier diapositiva, así como agregar estilo a las notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

* Eliminar notas de una diapositiva específica de una presentación.
* Eliminar notas de todas las diapositivas de una presentación.


## **Eliminar Notas de la Diapositiva**
Las notas de una diapositiva específica pueden ser eliminadas como se muestra en el ejemplo a continuación:

```java
// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Eliminando notas de la primera diapositiva
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Guardando la presentación en el disco
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eliminar Notas de la Presentación**
Las notas de todas las diapositivas de una presentación pueden ser eliminadas como se muestra en el ejemplo a continuación:

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
    
    // Guardando la presentación en el disco
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Agregar Estilo de Notas**
[getNotesStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) método ha sido agregado a la interfaz [IMasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide) y a la clase [MasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/MasterNotesSlide) respectivamente. Esta propiedad especifica el estilo de un texto de notas. La implementación se demuestra en el ejemplo a continuación.

```java
// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Obtener el estilo de texto de MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Establecer símbolo de viñeta para los párrafos de primer nivel
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```