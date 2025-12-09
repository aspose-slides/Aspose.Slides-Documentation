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
- PPT nach PDF exportieren
- PPTX nach PDF exportieren
- Sprecher-Notizen
- PDF mit Notizen
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie die Formate PPT und PPTX mit Notizen in PDF mithilfe von Aspose.Slides für .NET. Bewahren Sie Layouts und Sprecher-Notizen für professionelle Präsentationen."
---

## **Übersicht**

In diesem Artikel erfahren Sie, wie Sie PowerPoint‑Präsentationen mit Sprecherankündigungen in das PDF‑Format konvertieren können, indem Sie Aspose.Slides verwenden. Dieser Leitfaden behandelt die erforderlichen Schritte und liefert Codebeispiele, um diese Aufgabe effizient zu erledigen. Am Ende dieses Artikels können Sie:

- Den Konvertierungsprozess implementieren, um PowerPoint‑Folien in PDF‑Dokumente zu transformieren und dabei die Sprecherankündigungen zu erhalten.
- Das Ausgabe‑PDF anpassen, um sicherzustellen, dass die Sprecherankündigungen enthalten und nach Ihren Anforderungen formatiert sind.

## **PowerPoint in PDF mit Notizen konvertieren**

Die `Save`‑Methode in der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) kann verwendet werden, um eine PPT‑ oder PPTX‑Präsentation in ein PDF mit Sprecherankündigungen zu konvertieren. Mit Aspose.Slides laden Sie einfach die Präsentation, konfigurieren die Layout‑Optionen mithilfe der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/), um Sprecherankündigungen einzuschließen, und speichern die Datei anschließend als PDF. Das folgende Code‑Snippet zeigt, wie Sie eine Beispiel‑Präsentation in ein PDF im Notiz‑Folien‑Ansicht konvertieren.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // PDF-Optionen für das Rendern von Sprecher-Notizen konfigurieren.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Rendern der Sprecher-Notizen unterhalb der Folie.
        }
    };

    // Präsentation mit Sprecher-Notizen als PDF speichern.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```


{{% alert color="primary" %}} 

Vielleicht möchten Sie den Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion) ausprobieren. 

{{% /alert %}}