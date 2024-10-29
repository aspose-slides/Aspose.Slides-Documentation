---
title: Convertir PowerPoint en PDF avec des notes en C#
linktitle: Convertir PowerPoint en PDF avec des notes
type: docs
weight: 50
url: /fr/net/convert-powerpoint-to-pdf-with-notes/
keywords: "convertir PowerPoint, Présentation, PowerPoint en PDF, notes, c#, csharp, .NET, Aspose.Slides"
description: "Convertir PowerPoint en PDF avec des notes avec C# ou .NET"
---

## **Aperçu**

Tout en [convertissant PowerPoint en PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/), vous pouvez également contrôler comment les notes et les commentaires sont placés dans le document exporté. Cela couvre les sujets suivants.

- [C# Convertir PPT en PDF avec des notes](#convert-powerpoint-to-pdf-with-notes)
- [C# Convertir PPTX en PDF avec des notes](#convert-powerpoint-to-pdf-with-notes)
- [C# Convertir ODP en PDF avec des notes](#convert-powerpoint-to-pdf-with-notes)
- [C# Convertir PowerPoint en PDF avec des notes](#convert-powerpoint-to-pdf-with-notes)

## **Convertir PowerPoint en PDF avec des notes**

La méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) exposée par la classe Presentation peut être utilisée pour convertir une présentation PowerPoint PPT ou PPTX en PDF avec des notes. Sauvegarder une présentation Microsoft PowerPoint au format PDF avec des notes à l'aide d'Aspose.Slides pour .NET est un processus en deux lignes. Vous ouvrez simplement la présentation et l'enregistrez au format PDF avec des notes. Les extraits de code C# ci-dessous mettent à jour la présentation d'exemple en PDF en vue des diapositives de notes :

```c#
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

auxPresentation.Slides.InsertClone(0, slide);

// Définir le type et la taille de la diapositive 
//auxPresentation.SlideSize.SetSize(presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height,SlideSizeScaleType.EnsureFit);
auxPresentation.SlideSize.SetSize(612F, 792F, SlideSizeScaleType.EnsureFit);

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomFull;

auxPresentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter Aspose [PowerPoint en PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) ou [PPT en PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) convertisseur. 

{{% /alert %}} 