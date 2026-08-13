---
title: PowerPoint-Präsentationen mit Notizen in PDF konvertieren in Java
linktitle: PowerPoint zu PDF mit Notizen
type: docs
weight: 50
url: /de/java/convert-powerpoint-to-pdf-with-notes/
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
- PPT exportieren nach PDF
- PPTX exportieren nach PDF
- Sprechernotizen
- PDF mit Notizen
- Java
- Aspose.Slides
description: "Konvertieren Sie die Formate PPT und PPTX mithilfe von Aspose.Slides für Java in PDF mit Notizen. Bewahren Sie Layouts und Sprechernotizen für professionelle Präsentationen."
---
## **Übersicht**

In diesem Artikel erfahren Sie, wie Sie PowerPoint‑Präsentationen mit Sprechernotizen mithilfe von Aspose.Slides in das PDF‑Format konvertieren. Dieser Leitfaden deckt die notwendigen Schritte ab und liefert Codebeispiele, die Ihnen helfen, diese Aufgabe effizient zu erledigen. Am Ende dieses Artikels können Sie:

- Den Konvertierungsprozess implementieren, um PowerPoint‑Folien in PDF‑Dokumente zu überführen, wobei die Sprechernotizen erhalten bleiben.
- Das ausgegebene PDF anpassen, damit die Sprechernotizen enthalten und gemäß Ihren Anforderungen formatiert sind.

## **PowerPoint in PDF mit Notizen konvertieren**

Die `save`‑Methode in der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) Klasse kann verwendet werden, um eine PPT‑ oder PPTX‑Präsentation in ein PDF mit Sprechernotizen zu konvertieren. Mit Aspose.Slides laden Sie einfach die Präsentation, konfigurieren die Layoutoptionen mithilfe der [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/notescommentslayoutingoptions/) Klasse, um Sprechernotizen einzuschließen, und speichern die Datei anschließend als PDF. Das folgende Code‑Snippet zeigt, wie man eine Beispielpräsentation in ein PDF im Notiz‑Folien‑Ansichtsmodus konvertiert.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// PDF-Optionen für die Darstellung von Sprechernotizen konfigurieren.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Sprechernotizen unterhalb der Folie rendern.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Präsentation mit Sprechernotizen als PDF speichern.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" %}} 
Vielleicht möchten Sie Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/de/conversion) ausprobieren. 
{{% /alert %}}