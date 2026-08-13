---
title: PowerPoint-Präsentationen mit Notizen in .NET in PDF konvertieren
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
- Sprechernotizen
- PDF mit Notizen
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie die Formate PPT und PPTX mit Notizen in PDF mit Aspose.Slides für .NET. Bewahren Sie Layouts und Sprechernotizen für professionelle Präsentationen."
---
## **Übersicht**

In diesem Artikel lernen Sie, wie Sie PowerPoint‑Präsentationen mit Sprechernotizen mithilfe von Aspose.Slides in das PDF‑Format konvertieren. Dieser Leitfaden behandelt die erforderlichen Schritte und liefert Codebeispiele, damit Sie diese Aufgabe effizient erledigen können. Am Ende dieses Artikels können Sie:

- Den Konvertierungsprozess implementieren, um PowerPoint‑Folien in PDF‑Dokumente zu transformieren und dabei die Sprechernotizen beizubehalten.
- Das Ausgabe‑PDF anpassen, um sicherzustellen, dass die Sprechernotizen enthalten und nach Ihren Anforderungen formatiert sind.

## **PowerPoint in PDF mit Notizen konvertieren**

Die `Save`‑Methode der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) kann verwendet werden, um eine PPT‑ oder PPTX‑Präsentation in ein PDF mit Sprechernotizen zu konvertieren. Mit Aspose.Slides laden Sie einfach die Präsentation, konfigurieren die Layout‑Optionen mithilfe der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/notescommentslayoutingoptions/) zum Einbeziehen der Sprechernotizen und speichern die Datei anschließend als PDF. Der folgende Code‑Abschnitt zeigt, wie eine Beispiel‑Präsentation in ein PDF im Notiz‑Folien‑Modus konvertiert wird.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // PDF-Optionen für die Wiedergabe von Sprechernotizen konfigurieren.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Sprechernotizen unterhalb der Folie rendern.
        }
    };

    // Präsentation mit Sprechernotizen als PDF speichern.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
Vielleicht möchten Sie den Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/de/conversion) ausprobieren. 
{{% /alert %}}