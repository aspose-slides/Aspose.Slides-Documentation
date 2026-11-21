---
title: Präsentationen mit Notizen in PDF konvertieren in Python
linktitle: Präsentation zu PDF mit Notizen
type: docs
weight: 50
url: /de/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- PPT konvertieren
- PPTX konvertieren
- ODP konvertieren
- PowerPoint zu PDF
- OpenDocument zu PDF
- Präsentation zu PDF
- PPT zu PDF
- PPTX zu PDF
- ODP zu PDF
- Sprecherhinweise
- PDF mit Notizen
- Python
- Aspose.Slides
description: "Konvertieren Sie die Formate PPT, PPTX und ODP in PDF mit Notizen mithilfe von Aspose.Slides für Python. Bewahren Sie Layouts und Sprecherhinweise für professionelle Präsentationen."
---
## **Übersicht**

In diesem Artikel lernen Sie, wie Sie PowerPoint‑Präsentationen mit Sprecherankündigungen in das PDF‑Format konvertieren können, und zwar mit Aspose.Slides. Dieser Leitfaden behandelt die erforderlichen Schritte und liefert Codebeispiele, die Ihnen helfen, diese Aufgabe effizient zu erledigen. Am Ende dieses Artikels können Sie:

- Den Konvertierungsprozess implementieren, um PowerPoint‑Folien in PDF‑Dokumente zu überführen und dabei die Sprecherankündigungen beizubehalten.
- Das Ausgabe‑PDF anpassen, sodass die Sprecherankündigungen enthalten und nach Ihren Vorgaben formatiert sind.

Um die Notizseitengröße und Orientierung vor dem Export festzulegen, siehe [Notizseitengröße](/slides/de/python-net/notes-size/).

## **PowerPoint in PDF mit Notizen konvertieren**

Die `save`‑Methode in der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse kann verwendet werden, um eine PPT‑ oder PPTX‑Präsentation in ein PDF mit Sprecherankündigungen zu konvertieren. Mit Aspose.Slides laden Sie einfach die Präsentation, konfigurieren die Layout‑Optionen mit der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/notescommentslayoutingoptions/), um Sprecherankündigungen einzubeziehen, und speichern dann die Datei als PDF. Der folgende Codeausschnitt demonstriert, wie Sie eine Beispielpräsentation in ein PDF im Notiz‑Folien‑Ansicht konvertieren.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # PDF-Optionen für die Darstellung von Sprecheranmerkungen konfigurieren.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Präsentation mit Sprecheranmerkungen als PDF speichern.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
Vielleicht möchten Sie den Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/de/conversion) ausprobieren.
{{% /alert %}}