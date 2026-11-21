---
title: PowerPoint‑Präsentationen mit Notizen in JavaScript in PDF konvertieren
linktitle: PowerPoint zu PDF mit Notizen
type: docs
weight: 50
url: /de/nodejs-java/convert-powerpoint-to-pdf-with-notes/
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
- Referenten-Notizen
- PDF mit Notizen
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertieren Sie die Formate PPT und PPTX in PDF mit Notizen in JavaScript mithilfe von Aspose.Slides für Node.js. Bewahren Sie Layouts und Referenten-Notizen für professionelle Präsentationen."
---
## **Übersicht**

In diesem Artikel erfahren Sie, wie Sie PowerPoint‑Präsentationen mit Aspose.Slides in das PDF‑Format mit Referenten‑Notizen konvertieren. Dieser Leitfaden behandelt die notwendigen Schritte und liefert Codebeispiele, um diese Aufgabe effizient zu erledigen. Am Ende dieses Artikels können Sie:

- Den Konvertierungsprozess implementieren, um PowerPoint‑Folien in PDF‑Dokumente zu verwandeln und dabei die Referenten‑Notizen zu erhalten.
- Das Ausgabe‑PDF anpassen, sodass die Referenten‑Notizen enthalten und nach Ihren Vorgaben formatiert sind.

Um die Abmessungen und die Ausrichtung der Notizseite vor dem Export festzulegen, siehe [Notizseitengröße](/slides/de/nodejs-java/notes-size/).

## **PowerPoint in PDF mit Notizen konvertieren**

Die `save`‑Methode in der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse kann verwendet werden, um eine PPT‑ oder PPTX‑Präsentation in ein PDF mit Referenten‑Notizen zu konvertieren. Mit Aspose.Slides laden Sie einfach die Präsentation, konfigurieren die Layout‑Optionen mit der [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notescommentslayoutingoptions/)‑Klasse, um Referenten‑Notizen einzuschließen, und speichern die Datei anschließend als PDF. Der folgende Code‑Abschnitt zeigt, wie Sie eine Beispiel‑Präsentation in ein PDF im Notizen‑Folien‑Modus konvertieren.

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// PDF-Optionen für das Rendern von Referenten-Notizen konfigurieren.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Referenten-Notizen unterhalb der Folie rendern.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
Vielleicht möchten Sie den Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/de/conversion) ausprobieren.
{{% /alert %}}