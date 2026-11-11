---
title: Gestionar notas de presentación en Java
linktitle: Notas de presentación
type: docs
weight: 110
url: /es/java/presentation-notes/
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
- Java
- Aspose.Slides
description: "Personaliza las notas de la presentación con Aspose.Slides para Java. Trabaja sin problemas con notas de PowerPoint y OpenDocument para mejorar tu productividad."
---
## **Descripción general**

Aspose.Slides permite eliminar diapositivas de notas de una presentación. En este tema, presentaremos esta característica, incluyendo cómo eliminar notas y cómo aplicar un estilo a las diapositivas de notas en una presentación. Aspose.Slides permite eliminar notas de cualquier diapositiva y también aplicar estilo a notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

- Eliminar notas de una diapositiva específica en una presentación.
- Eliminar notas de todas las diapositivas de una presentación.

Para leer o cambiar las dimensiones de la página de notas, cambiar la orientación y comprobar el comportamiento de exportación, consulte [Tamaño de página de notas](/slides/es/java/notes-size/).

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

## **Añadir un estilo de notas**
El método [getNotesStyle](https://reference.aspose.com/slides/es/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) se ha añadido a la interfaz [IMasterNotesSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/IMasterNotesSlide) y a la clase [MasterNotesSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/MasterNotesSlide) respectivamente. Esta propiedad especifica el estilo del texto de notas. La implementación se muestra en el ejemplo a continuación.

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
    
        //Establecer viñeta símbolo para los párrafos de primer nivel
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Preguntas frecuentes**

**¿Qué entidad de la API proporciona acceso a las notas de una diapositiva específica?**

Las notas se acceden a través del gestor de notas de la diapositiva: la diapositiva tiene un [NotesSlideManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/notesslidemanager/) y un [método](https://reference.aspose.com/slides/es/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) que devuelve el objeto de notas, o `null` si no existen notas.

**¿Existen diferencias en el soporte de notas entre las versiones de PowerPoint con las que funciona la biblioteca?**

La biblioteca es compatible con una amplia gama de formatos de Microsoft PowerPoint (de 97 en adelante) y ODP; las notas están soportadas en estos formatos sin depender de una copia instalada de PowerPoint.