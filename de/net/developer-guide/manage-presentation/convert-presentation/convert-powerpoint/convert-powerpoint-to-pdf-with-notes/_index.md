---
title: PowerPoint-Präsentationen mit Notizen in PDF konvertieren in .NET
linktitle: PowerPoint zu PDF mit Notizen
type: docs
weight: 50
url: /de/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu PDF
- Präsentation zu PDF
- Folie zu PDF
- PPT zu PDF
- PPTX zu PDF
- Präsentation als PDF speichern
- PPT als PDF speichern
- PPTX als PDF speichern
- PPT zu PDF exportieren
- PPTX zu PDF exportieren
- Rednernotizen
- PDF mit Notizen
- .NET
- C#
- Aspose.Slides
description: "Formate PPT und PPTX mit Notizen mithilfe von Aspose.Slides für .NET in PDF konvertieren. Layouts und Rednernotizen für professionelle Präsentationen beibehalten."
---

## **Übersicht**

In diesem Artikel lernen Sie, wie Sie PowerPoint‑Präsentationen mithilfe von Aspose.Slides in das PDF‑Format mit Rednernotizen konvertieren. Dieser Leitfaden behandelt die erforderlichen Schritte und liefert Codebeispiele, die Ihnen helfen, diese Aufgabe effizient zu erledigen. Am Ende dieses Artikels können Sie:

- Den Konvertierungsprozess implementieren, um PowerPoint‑Folien in PDF‑Dokumente zu transformieren und dabei die Rednernotizen beizubehalten.
- Das Ausgabe‑PDF anpassen, um sicherzustellen, dass die Rednernotizen enthalten und gemäß Ihren Anforderungen formatiert werden.

## **PowerPoint in PDF mit Notizen konvertieren**

Die `Save`‑Methode in der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse kann verwendet werden, um eine PPT‑ oder PPTX‑Präsentation in ein PDF mit Rednernotizen zu konvertieren. Mit Aspose.Slides laden Sie einfach die Präsentation, konfigurieren die Layout‑Optionen mithilfe der [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/)‑Klasse, um Rednernotizen einzuschließen, und speichern die Datei anschließend als PDF. Der folgende Code‑Abschnitt demonstriert, wie Sie eine Beispielpräsentation in ein PDF im Notizen‑Folien‑Ansicht konvertieren.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // PDF-Optionen für die Darstellung von Rednernotizen konfigurieren.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Rednernotizen unterhalb der Folie rendern.
        }
    };

    // Präsentation mit Rednernotizen als PDF speichern.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```


{{% alert color="primary" %}} 
Vielleicht möchten Sie den Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion) ausprobieren. 
{{% /alert %}}