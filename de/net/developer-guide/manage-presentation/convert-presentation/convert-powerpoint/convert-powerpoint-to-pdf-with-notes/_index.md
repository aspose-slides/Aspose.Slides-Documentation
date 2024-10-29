---
title: PowerPoint mit Notizen in PDF konvertieren mit C#
linktitle: PowerPoint mit Notizen in PDF konvertieren
type: docs
weight: 50
url: /de/net/convert-powerpoint-to-pdf-with-notes/
keywords: "PowerPoint konvertieren, Präsentation, PowerPoint in PDF, Notizen, c#, csharp, .NET, Aspose.Slides"
description: "PowerPoint mit Notizen in PDF konvertieren mit C# oder .NET"
---

## **Überblick**

Beim [Konvertieren von PowerPoint in PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/) können Sie auch steuern, wie Notizen und Kommentare im exportierten Dokument platziert werden. Es werden die folgenden Themen behandelt.

- [C# PPT in PDF mit Notizen konvertieren](#convert-powerpoint-to-pdf-with-notes)
- [C# PPTX in PDF mit Notizen konvertieren](#convert-powerpoint-to-pdf-with-notes)
- [C# ODP in PDF mit Notizen konvertieren](#convert-powerpoint-to-pdf-with-notes)
- [C# PowerPoint in PDF mit Notizen konvertieren](#convert-powerpoint-to-pdf-with-notes)

## **PowerPoint mit Notizen in PDF konvertieren**

Die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) Methode der Klasse Presentation kann verwendet werden, um eine PowerPoint PPT- oder PPTX-Präsentation in PDF mit Notizen zu konvertieren. Das Speichern einer Microsoft PowerPoint-Präsentation in PDF-Notizen mit Aspose.Slides für .NET ist ein zweizeiliger Prozess. Sie öffnen einfach die Präsentation und speichern sie als PDF-Notizen. Die C#-Codebeispiele unten aktualisieren die Beispielpräsentation in das PDF im Notizfolienansicht:

```c#
// Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt 
Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

auxPresentation.Slides.InsertClone(0, slide);

// Einstellung des Folientyps und der Größe 
//auxPresentation.SlideSize.SetSize(presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height,SlideSizeScaleType.EnsureFit);
auxPresentation.SlideSize.SetSize(612F, 792F, SlideSizeScaleType.EnsureFit);

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomFull;

auxPresentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="primary" %}} 

Sie sollten sich den Aspose [PowerPoint zu PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) oder [PPT zu PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) Konverter ansehen. 

{{% /alert %}} 