---
title: Notas de Presentación
type: docs
weight: 110
url: /es/net/presentation-notes/
keywords: "Notas, notas de PowerPoint, agregar notas, eliminar notas, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Agregar y eliminar notas en presentaciones de PowerPoint en C# o .NET"
---



Aspose.Slides admite la eliminación de diapositivas de notas de una presentación. En este tema, introduciremos esta nueva función de eliminación de notas así como la adición de diapositivas de estilo de notas de cualquier presentación. Aspose.Slides para .NET proporciona la función de eliminar notas de cualquier diapositiva, así como de agregar estilo a notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

- Eliminar notas de una diapositiva específica de una presentación.
- Eliminar notas de todas las diapositivas de una presentación.
## **Eliminar Notas de la Diapositiva**
Las notas de una diapositiva específica se pueden eliminar como se muestra en el siguiente ejemplo:

```c#
// Instanciar un objeto Presentation que representa un archivo de presentación 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Eliminar notas de la primera diapositiva
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Guardar la presentación en el disco
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **Eliminar Notas de Todas las Diapositivas**
Las notas de todas las diapositivas de una presentación se pueden eliminar como se muestra en el siguiente ejemplo:

```c#
// Instanciar un objeto Presentation que representa un archivo de presentación 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Eliminar notas de todas las diapositivas
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Guardar la presentación en el disco
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **Agregar Estilo de Notas**
La propiedad NotesStyle se ha añadido a la interfaz [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) y a la clase [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) respectivamente. Esta propiedad especifica el estilo de un texto de notas. La implementación se demuestra en el siguiente ejemplo.

```c#
// Instanciar la clase Presentation que representa el archivo de presentación
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Obtener el estilo de texto de MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // Establecer el tipo de viñeta símbolo para los párrafos de primer nivel
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Guardar el archivo PPTX en el disco
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```