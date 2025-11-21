---
title: Convertir presentaciones de PowerPoint a SWF Flash en .NET
linktitle: PowerPoint a SWF
type: docs
weight: 80
url: /es/net/convert-powerpoint-to-swf-flash/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a SWF
- presentación a SWF
- diapositiva a SWF
- PPT a SWF
- PPTX a SWF
- PowerPoint a Flash
- presentación a Flash
- diapositiva a Flash
- PPT a Flash
- PPTX a Flash
- guardar PPT como SWF
- guardar PPTX como SWF
- exportar PPT a SWF
- exportar PPTX a SWF
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) a SWF Flash en .NET con Aspose.Slides. Ejemplos de código C# paso a paso, salida de alta calidad y rápida, sin automatización de PowerPoint."
---

## **Convertir presentaciones a Flash**

El método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) expuesto por la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) puede usarse para convertir toda la presentación a un documento SWF. También puede incluir comentarios en el SWF generado utilizando la clase [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) y la interfaz [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). El siguiente ejemplo muestra cómo convertir una presentación a un documento SWF mediante las opciones proporcionadas por la clase SWFOptions.
```c#
 // Instanciar un objeto Presentation que representa un archivo de presentación
 using (Presentation presentation = new Presentation("HelloWorld.pptx"))
 {
     SwfOptions swfOptions = new SwfOptions();
     swfOptions.ViewerIncluded = false;


     INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
     notesOptions.NotesPosition = NotesPositions.BottomFull;

     // Guardando la presentación y las páginas de notas
     presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
     swfOptions.ViewerIncluded = true;
     presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
 }
```


## **Preguntas frecuentes**

**¿Puedo incluir diapositivas ocultas en el SWF?**

Sí. Habilite la opción [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) en [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/). Por defecto, las diapositivas ocultas no se exportan.

**¿Cómo puedo controlar la compresión y el tamaño final del SWF?**

Utilice el indicador [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) (activado por defecto) y ajuste [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) para equilibrar el tamaño del archivo y la fidelidad de la imagen.

**¿Para qué sirve 'ViewerIncluded' y cuándo debería desactivarlo?**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) agrega una interfaz de reproductor incrustada (controles de navegación, paneles, búsqueda). Desactívelo si planea usar su propio reproductor o necesita un marco SWF básico sin interfaz de usuario.

**¿Qué ocurre si falta una fuente origen en la máquina de exportación?**

Aspose.Slides sustituirá la fuente que especifique mediante [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) en [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) para evitar un reemplazo no deseado.