---
title: PowerPoint-Präsentationen mit Notizen in Java in PDF konvertieren
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
- PPT nach PDF exportieren
- PPTX nach PDF exportieren
- Sprechernotizen
- PDF mit Notizen
- Java
- Aspose.Slides
description: "Konvertieren Sie die Formate PPT und PPTX mit Notizen in PDF mit Aspose.Slides für Java. Bewahren Sie Layouts und Sprechernotizen für professionelle Präsentationen."
---
## **Übersicht**

In diesem Artikel erfahren Sie, wie Sie PowerPoint‑Präsentationen mit Aspose.Slides in das PDF‑Format inklusive Sprecher‑Notizen konvertieren. Dieser Leitfaden behandelt die erforderlichen Schritte und liefert Code‑Beispiele, damit Sie diese Aufgabe effizient erledigen können. Am Ende dieses Artikels können Sie:

- den Konvertierungsprozess implementieren, um PowerPoint‑Folien in PDF‑Dokumente zu überführen und dabei die Sprecher‑Notizen zu erhalten.
- das Ausgabe‑PDF anpassen, sodass die Sprecher‑Notizen nach Ihren Anforderungen enthalten und formatiert sind.

Um die Abmessungen und die Ausrichtung der Notizseite vor dem Export festzulegen, siehe [Notizseitengröße](/slides/de/java/notes-size/).

## **PowerPoint in PDF mit Notizen konvertieren**

Die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse kann verwendet werden, um eine PPT‑ oder PPTX‑Präsentation in ein PDF mit Sprecher‑Notizen zu konvertieren. Mit Aspose.Slides laden Sie einfach die Präsentation, konfigurieren die Layout‑Optionen mithilfe der [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/notescommentslayoutingoptions/)‑Klasse, um die Sprecher‑Notizen aufzunehmen, und speichern die Datei anschließend als PDF. Das folgende Code‑Snippet zeigt, wie Sie eine Beispiel‑Präsentation in ein PDF im Notiz‑Folien‑Ansicht konvertieren.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// PDF-Optionen für das Rendern von Sprechernotizen konfigurieren.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Sprechernotizen unterhalb der Folie rendern.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Präsentation als PDF mit Sprechernotizen speichern.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}

Vielleicht möchten Sie den Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/de/conversion) ausprobieren.

{{% /alert %}}