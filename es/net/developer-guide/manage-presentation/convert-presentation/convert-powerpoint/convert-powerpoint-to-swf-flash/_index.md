---
title: Convertir PowerPoint a SWF Flash
type: docs
weight: 80
url: /es/net/convert-powerpoint-to-swf-flash/
keywords: "Convertir PowerPoint, Presentación, PowerPoint a SWF, SWF flash PPT a SWF, PPTX a SWF, C#, Csharp, .NET"
description: "Convertir Presentación de PowerPoint a SWF Flash en C# o .NET"
---

El método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) expuesto por la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) se puede usar para convertir toda la presentación en un documento SWF. También puedes incluir comentarios en el SWF generado utilizando la clase [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) y la interfaz [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). El siguiente ejemplo muestra cómo convertir una presentación en un documento SWF utilizando las opciones proporcionadas por la clase SWFOptions.

```c#
// Instanciar un objeto Presentation que representa un archivo de presentación
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;

    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Guardar presentación y páginas de notas
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```