---
title: PowerPoint-Präsentationen mit Notizen auf Android in PDF konvertieren
linktitle: PowerPoint zu PDF mit Notizen
type: docs
weight: 50
url: /de/androidjava/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folien konvertieren
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
- Android
- Java
- Aspose.Slides
description: "Konvertieren Sie die Formate PPT und PPTX mit Notizen in PDF mithilfe von Aspose.Slides für Android in Java. Bewahren Sie Layouts und Sprecher-Notizen für professionelle Präsentationen."
---
## **Übersicht**

In diesem Artikel lernen Sie, wie Sie PowerPoint‑Präsentationen mit Sprecher­notizen in das PDF‑Format konvertieren können, und zwar mit Aspose.Slides. Dieser Leitfaden behandelt die erforderlichen Schritte und liefert Code‑Beispiele, um diese Aufgabe effizient zu erledigen. Am Ende dieses Artikels können Sie:

- Den Konvertierungsprozess implementieren, um PowerPoint‑Folien in PDF‑Dokumente zu überführen und dabei die Sprecher­notizen zu erhalten.
- Das Ausgabe‑PDF anpassen, sodass die Sprecher­notizen nach Ihren Vorgaben eingeschlossen und formatiert werden.

Um die Abmessungen und die Ausrichtung der Notizseite vor dem Export festzulegen, siehe [Notes Page Size](/slides/de/androidjava/notes-size/).

## **PowerPoint in PDF mit Notizen konvertieren**

Die `save`‑Methode in der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Klasse kann verwendet werden, um eine PPT‑ oder PPTX‑Präsentation mit Sprecher­notizen in ein PDF zu konvertieren. Mit Aspose.Slides laden Sie einfach die Präsentation, konfigurieren die Layout‑Optionen mit der [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/notescommentslayoutingoptions/)‑Klasse, um die Sprecher­notizen einzuschließen, und speichern die Datei dann als PDF. Der folgende Code‑Abschnitt demonstriert, wie eine Beispiel‑Präsentation in ein PDF im Notiz‑Folien‑Modus konvertiert wird.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// PDF-Optionen für das Rendern von Sprecher-Notizen konfigurieren.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Sprecher-Notizen unterhalb der Folie rendern.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Präsentation mit Sprecher-Notizen als PDF speichern.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Vielleicht möchten Sie den Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/de/conversion) ausprobieren.
{{% /alert %}}