---
title: Convertir PowerPoint en SWF Flash
type: docs
weight: 80
url: /net/convert-powerpoint-to-swf-flash/
keywords: "Convertir PowerPoint, Présentation, PowerPoint en SWF, SWF flash PPT en SWF, PPTX en SWF, C#, Csharp, .NET"
description: "Convertir une présentation PowerPoint en SWF Flash en C# ou .NET"
---

La méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) exposée par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) peut être utilisée pour convertir l'ensemble de la présentation en un document SWF. Vous pouvez également inclure des commentaires dans le SWF généré en utilisant la classe [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) et l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). L'exemple suivant montre comment convertir une présentation en document SWF en utilisant les options fournies par la classe SWFOptions.

```c#
// Instancier un objet Presentation qui représente un fichier de présentation
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;

    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Sauvegarder la présentation et les pages de notes
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```