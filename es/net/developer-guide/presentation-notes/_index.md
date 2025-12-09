---
title: Notas de la presentación
type: docs
weight: 110
url: /es/net/presentation-notes/
keywords: "Notas, notas de PowerPoint, agregar notas, eliminar notas, presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Agregar y eliminar notas en presentaciones de PowerPoint en C# o .NET"
---

Aspose.Slides admite eliminar diapositivas de notas de una presentación. En este tema, presentaremos esta nueva característica de eliminar notas y también agregar diapositivas de estilo de notas a cualquier presentación. Aspose.Slides para .NET ofrece la funcionalidad de eliminar notas de cualquier diapositiva así como agregar estilo a notas existentes. Los desarrolladores pueden eliminar notas de las siguientes formas:

- Eliminar notas de una diapositiva específica de una presentación.
- Eliminar notas de todas las diapositivas de una presentación.

## **Eliminar notas de la diapositiva**
Las notas de una diapositiva específica pueden eliminarse como se muestra en el ejemplo a continuación:
```c#
// Instanciar un objeto Presentation que representa un archivo de presentación 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Eliminando notas de la primera diapositiva
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Guardar la presentación en disco 
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **Eliminar notas de todas las diapositivas**
Las notas de todas las diapositivas de una presentación pueden eliminarse como se muestra en el ejemplo a continuación:
```c#
// Instanciar un objeto Presentation que representa un archivo de presentación 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Eliminando notas de todas las diapositivas
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Guardar la presentación en disco
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **Agregar NotesStyle**
Se ha añadido la propiedad NotesStyle a la interfaz [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) y a la clase [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) respectivamente. Esta propiedad especifica el estilo del texto de notas. La implementación se muestra en el ejemplo a continuación.
```c#
 // Instantiate Presentation class that represents the presentation file
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Get MasterNotesSlide text style
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Set symbol bullet for the first level paragraphs
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Save the PPTX file to the Disk
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```


## **FAQ**

**¿Qué entidad de API proporciona acceso a las notas de una diapositiva específica?**

Las notas se acceden a través del administrador de notas de la diapositiva: la diapositiva tiene un [NotesSlideManager](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/) y una [propiedad](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/notesslide/) que devuelve el objeto de notas, o `null` si no hay notas.

**¿Existen diferencias en el soporte de notas entre las versiones de PowerPoint con las que funciona la biblioteca?**

La biblioteca admite una amplia gama de formatos de Microsoft PowerPoint (97–newer) y ODP; las notas son compatibles con estos formatos sin depender de una copia instalada de PowerPoint.