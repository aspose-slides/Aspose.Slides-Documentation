---
title: Gestionar notas de presentación en .NET
linktitle: Notas de presentación
type: docs
weight: 110
url: /es/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Personaliza las notas de la presentación con Aspose.Slides para .NET. Trabaja sin problemas con notas de PowerPoint y OpenDocument para mejorar tu productividad."
---
## **Descripción general**

Aspose.Slides permite eliminar diapositivas de notas de una presentación. En este tema, presentaremos esta función, incluyendo cómo eliminar notas y cómo aplicar un estilo a las diapositivas de notas en una presentación. Aspose.Slides le permite eliminar notas de cualquier diapositiva y también aplicar estilos a las notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

- Eliminar notas de una diapositiva específica en una presentación.
- Eliminar notas de todas las diapositivas de una presentación.

Para leer o cambiar las dimensiones de la página de notas, cambiar la orientación y comprobar el comportamiento de exportación, consulte [Tamaño de página de notas](/slides/es/net/notes-size/).

## **Eliminar notas de una diapositiva**
Las notas de una diapositiva concreta pueden eliminarse como se muestra en el ejemplo a continuación:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation presentation = new Presentation("AccessSlides.pptx");

// Eliminar notas de la primera diapositiva
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Guardar la presentación en disco
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Eliminar notas de todas las diapositivas**
Las notas de todas las diapositivas de una presentación pueden eliminarse como se muestra en el ejemplo a continuación:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar un objeto Presentation que representa un archivo de presentación 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Eliminar notas de todas las diapositivas
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Guardar la presentación en disco
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **Agregar un estilo a las notas**
Se ha añadido la propiedad NotesStyle a la interfaz [IMasterNotesSlide](https://reference.aspose.com/slides/es/net/aspose.slides/imasternotesslide) y a la clase [MasterNotesSlide](https://reference.aspose.com/slides/es/net/aspose.slides/masternotesslide) respectivamente. Esta propiedad especifica el estilo del texto de las notas. La implementación se muestra en el ejemplo a continuación.

```c#
using Aspose.Slides;

// Instanciar la clase Presentation que representa el archivo de presentación
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Obtener el estilo de texto de MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Establecer viñeta de símbolo para los párrafos de primer nivel
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Guardar el archivo PPTX en el disco
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **FAQ**

### ¿Qué entidad de la API proporciona acceso a las notas de una diapositiva específica?

Las notas se acceden a través del gestor de notas de la diapositiva: la diapositiva tiene un [NotesSlideManager](https://reference.aspose.com/slides/es/net/aspose.slides/notesslidemanager/) y una [propiedad](https://reference.aspose.com/slides/es/net/aspose.slides/notesslidemanager/notesslide/) que devuelve el objeto de notas, o `null` si no existen notas.

### ¿Existen diferencias en el soporte de notas entre las versiones de PowerPoint con las que funciona la biblioteca?

La biblioteca está dirigida a una amplia gama de formatos de Microsoft PowerPoint (97 y posteriores) y ODP; las notas son compatibles con estos formatos sin depender de una copia instalada de PowerPoint.