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
description: "Konvertieren Sie PPT- und PPTX-Formate mit Notizen in PDF mithilfe von Aspose.Slides für .NET. Bewahren Sie Layouts und Sprechernotizen für professionelle Präsentationen."
---

## **Übersicht**

In diesem Artikel lernen Sie, wie Sie PowerPoint‑Präsentationen mit Sprecher‑Notizen mithilfe von Aspose.Slides in das PDF‑Format konvertieren. Diese Anleitung behandelt die erforderlichen Schritte und liefert Code‑Beispiele, um diese Aufgabe effizient zu erledigen. Am Ende dieses Artikels können Sie:

- Den Konvertierungsprozess implementieren, um PowerPoint‑Folien in PDF‑Dokumente zu überführen und dabei die Sprecher‑Notizen zu erhalten.
- Das Ausgabe‑PDF anpassen, sodass die Sprecher‑Notizen wie gewünscht eingebettet und formatiert werden.

## **PowerPoint in PDF mit Notizen konvertieren**

Die `Save`‑Methode in der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse kann verwendet werden, um eine PPT‑ oder PPTX‑Präsentation mit Sprecher‑Notizen in ein PDF zu konvertieren. Mit Aspose.Slides laden Sie einfach die Präsentation, konfigurieren die Layout‑Optionen mit der [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/)‑Klasse, um die Sprecher‑Notizen einzuschließen, und speichern die Datei anschließend als PDF. Das folgende Code‑Snippet demonstriert, wie eine Beispiel‑Präsentation in ein PDF im Notizen‑Folien‑Modus konvertiert wird.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // PDF-Optionen für die Darstellung der Sprecher-Notizen konfigurieren.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Sprecher-Notizen unterhalb der Folie darstellen.
        }
    };

    // Die Präsentation mit Sprecher-Notizen als PDF speichern.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```


{{% alert color="primary" %}} 

Möglicherweise möchten Sie den Aspose [Online PowerPoint‑zu‑PDF‑Konverter](https://products.aspose.app/slides/conversion) ausprobieren. 

{{% /alert %}}