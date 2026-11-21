---
title: Administrar notas de presentación en Android
linktitle: Notas de presentación
type: docs
weight: 110
url: /es/androidjava/presentation-notes/
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
- Android
- Java
- Aspose.Slides
description: "Personaliza las notas de la presentación con Aspose.Slides para Android mediante Java. Trabaja sin problemas con notas de PowerPoint y OpenDocument para aumentar tu productividad."
---
## **Descripción general**

Aspose.Slides admite la eliminación de diapositivas de notas de una presentación. En este tema, presentaremos esta función, incluida la forma de eliminar notas y de aplicar un estilo a las diapositivas de notas en una presentación. Aspose.Slides le permite eliminar notas de cualquier diapositiva y también aplicar estilo a las notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

- Eliminar notas de una diapositiva específica en una presentación.
- Eliminar notas de todas las diapositivas en una presentación.

Para leer o cambiar las dimensiones de la página de notas, cambiar la orientación y comprobar el comportamiento de exportación, consulte [Notes Page Size](/slides/es/androidjava/notes-size/).

## **Eliminar notas de una diapositiva**
Las notas de una diapositiva específica pueden eliminarse como se muestra en el ejemplo a continuación:

```java
import com.aspose.slides.*;

// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Eliminar notas de la primera diapositiva
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Guardar la presentación en disco
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eliminar notas de una presentación**
Las notas de todas las diapositivas de una presentación pueden eliminarse como se muestra en el ejemplo a continuación:

```java
import com.aspose.slides.*;

// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Eliminar notas de todas las diapositivas
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Guardar la presentación en disco
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Agregar un estilo de notas**
El método [getNotesStyle](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) se ha añadido a la interfaz [IMasterNotesSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IMasterNotesSlide) y a la clase [MasterNotesSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/MasterNotesSlide) respectivamente. Esta propiedad especifica el estilo del texto de las notas. La implementación se muestra en el ejemplo a continuación.

```java
import com.aspose.slides.*;

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

Las notas se acceden a través del gestor de notas de la diapositiva: la diapositiva tiene un [NotesSlideManager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/notesslidemanager/) y un [método](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) que devuelve el objeto de notas, o `null` si no existen notas.

**¿Existen diferencias en la compatibilidad de notas entre las versiones de PowerPoint con las que funciona la biblioteca?**

La biblioteca está dirigida a una amplia gama de formatos de Microsoft PowerPoint (97‑más reciente) y ODP; las notas son compatibles en estos formatos sin depender de una copia instalada de PowerPoint.