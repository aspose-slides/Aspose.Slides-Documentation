---
title: PowerPoint-Präsentationen mit Notizen auf Android in PDF konvertieren
linktitle: PowerPoint zu PDF mit Notizen
type: docs
weight: 50
url: /de/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- Rednernotizen
- PDF mit Notizen
- Android
- Java
- Aspose.Slides
description: "Konvertieren Sie die Formate PPT und PPTX mit Aspose.Slides für Android über Java in PDF mit Notizen. Bewahren Sie Layouts und Rednernotizen für professionelle Präsentationen."
---
## **Übersicht**

In diesem Artikel erfahren Sie, wie Sie PowerPoint-Präsentationen mit Aspose.Slides in das PDF-Format mit Rednernotizen konvertieren. Dieser Leitfaden behandelt die notwendigen Schritte und liefert Codebeispiele, um diese Aufgabe effizient zu erledigen. Am Ende dieses Artikels können Sie:

- Den Konvertierungsprozess implementieren, um PowerPoint-Folien in PDF-Dokumente zu verwandeln und dabei die Rednernotizen zu erhalten.
- Das Ausgabe-PDF anpassen, sodass die Rednernotizen enthalten und nach Ihren Anforderungen formatiert werden.

## **PowerPoint in PDF mit Notizen konvertieren**

Die `save`‑Methode in der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) kann verwendet werden, um eine PPT- oder PPTX-Präsentation in ein PDF mit Rednernotizen zu konvertieren. Mit Aspose.Slides laden Sie einfach die Präsentation, konfigurieren die Layout-Optionen mithilfe der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/notescommentslayoutingoptions/) um Rednernotizen einzuschließen, und speichern die Datei anschließend als PDF. Das folgende Code‑Snippet zeigt, wie Sie eine Beispielpräsentation in ein PDF im Notiz-Folien-Ansicht konvertieren.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// PDF-Optionen für das Rendern von Rednernotizen konfigurieren.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Rednernotizen unterhalb der Folie rendern.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Die Präsentation mit Rednernotizen als PDF speichern.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" %}} 
Möglicherweise möchten Sie den Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/de/conversion) ausprobieren. 
{{% /alert %}}