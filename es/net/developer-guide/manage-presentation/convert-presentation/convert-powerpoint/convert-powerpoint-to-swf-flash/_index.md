---
title: Convertir PowerPoint a SWF Flash
type: docs
weight: 80
url: /es/net/convert-powerpoint-to-swf-flash/
keywords: "Convertir PowerPoint, Presentación, PowerPoint a SWF, SWF flash PPT a SWF, PPTX a SWF, C#, Csharp, .NET"
description: "Convertir presentación de PowerPoint a SWF Flash en C# o .NET"
---

## **Convertir presentaciones a Flash**

El método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) expuesto por la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) se puede usar para convertir toda la presentación en un documento SWF. También puede incluir comentarios en el SWF generado usando la clase [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) y la interfaz [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). El siguiente ejemplo muestra cómo convertir una presentación en un documento SWF utilizando las opciones proporcionadas por la clase SWFOptions.
```c#
// Instanciar un objeto Presentation que representa un archivo de presentación
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Guardar la presentación y las páginas de notas
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```


## **Preguntas frecuentes**

**¿Puedo incluir diapositivas ocultas en el SWF?**

Sí. Active la opción [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) en [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/). Por defecto, las diapositivas ocultas no se exportan.

**¿Cómo puedo controlar la compresión y el tamaño final del SWF?**

Use el indicador [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) (activado por defecto) y ajuste [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) para equilibrar el tamaño del archivo y la fidelidad de la imagen.

**¿Para qué sirve 'ViewerIncluded' y cuándo debería desactivarlo?**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) agrega una interfaz de reproductor incrustada (controles de navegación, paneles, búsqueda). Desactívelo si planea usar su propio reproductor o necesita un marco SWF sin interfaz.

**¿Qué ocurre si una fuente de origen falta en la máquina de exportación?**

Aspose.Slides sustituirá la fuente que especifique mediante [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) en [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) para evitar una sustitución no deseada.