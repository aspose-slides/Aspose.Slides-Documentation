---
title: Convertir PowerPoint a PDF con Notas en C#
linktitle: Convertir PowerPoint a PDF con Notas
type: docs
weight: 50
url: /es/net/convert-powerpoint-to-pdf-with-notes/
keywords: "convertir PowerPoint, Presentación, PowerPoint a PDF, notas, c#, csharp, .NET, Aspose.Slides"
description: "Convertir PowerPoint a PDF con notas con C# o .NET"
---

## **Descripción General**

Mientras [conviertes PowerPoint a PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/), también puedes controlar cómo se colocan las notas y los comentarios en el documento exportado. Cubre los siguientes temas.

- [C# Convertir PPT a PDF con Notas](#convert-powerpoint-to-pdf-with-notes)
- [C# Convertir PPTX a PDF con Notas](#convert-powerpoint-to-pdf-with-notes)
- [C# Convertir ODP a PDF con Notas](#convert-powerpoint-to-pdf-with-notes)
- [C# Convertir PowerPoint a PDF con Notas](#convert-powerpoint-to-pdf-with-notes)

## **Convertir PowerPoint a PDF con Notas**

El método [Guardar](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) expuesto por la clase Presentation se puede utilizar para convertir una presentación de PowerPoint PPT o PPTX a PDF con notas. Guardar una presentación de Microsoft PowerPoint en PDF con notas usando Aspose.Slides para .NET es un proceso de dos líneas. Simplemente abres la presentación y la guardas como PDF con notas. Los fragmentos de código en C# a continuación actualizan la presentación de muestra a PDF en vista de Diapositiva de Notas:

```c#
// Instanciar un objeto Presentation que representa un archivo de presentación 
Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

auxPresentation.Slides.InsertClone(0, slide);

// Estableciendo el Tipo y Tamaño de la Diapositiva 
//auxPresentation.SlideSize.SetSize(presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height,SlideSizeScaleType.EnsureFit);
auxPresentation.SlideSize.SetSize(612F, 792F, SlideSizeScaleType.EnsureFit);

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomFull;

auxPresentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="primary" %}} 

Puede que desees consultar el convertidor de Aspose [PowerPoint a PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) o [PPT a PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}} 