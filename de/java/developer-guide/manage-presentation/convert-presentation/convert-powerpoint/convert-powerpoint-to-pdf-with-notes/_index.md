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
- Referenten-Notizen
- PDF mit Notizen
- Java
- Aspose.Slides
description: "Konvertieren Sie die Formate PPT und PPTX mit Notizen in PDF mithilfe von Aspose.Slides für Java. Bewahren Sie Layouts und Referenten-Notizen für professionelle Präsentationen."
---

## **Übersicht**

In diesem Artikel erfahren Sie, wie Sie PowerPoint-Präsentationen mit Aspose.Slides in das PDF-Format mit Referenten-Notizen konvertieren. Dieser Leitfaden behandelt die erforderlichen Schritte und liefert Code‑Beispiele, um diese Aufgabe effizient zu erledigen. Am Ende dieses Artikels können Sie:

- Den Konvertierungsprozess implementieren, um PowerPoint‑Folien in PDF‑Dokumente zu transformieren und dabei die Referenten‑Notizen zu erhalten.
- Das ausgegebene PDF anpassen, sodass die Referenten‑Notizen eingeschlossen und gemäß Ihren Anforderungen formatiert sind.

## **PowerPoint in PDF mit Notizen konvertieren**

Die `save`‑Methode in der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse kann verwendet werden, um eine PPT‑ oder PPTX‑Präsentation in ein PDF mit Referenten‑Notizen zu konvertieren. Mit Aspose.Slides laden Sie einfach die Präsentation, konfigurieren die Layout‑Optionen mithilfe der [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/)‑Klasse, um Referenten‑Notizen einzuschließen, und speichern die Datei anschließend als PDF. Das folgende Code‑Snippet demonstriert, wie Sie eine Beispiel‑Präsentation in ein PDF im Notizen‑Folien‑Ansicht konvertieren.
```java
Presentation presentation = new Presentation("sample.pptx");

// PDF-Optionen für das Rendern von Referenten-Notizen konfigurieren.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Referenten-Notizen unterhalb der Folie rendern.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Speichert die Präsentation als PDF mit Referenten-Notizen.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```


{{% alert color="primary" %}} 
Vielleicht möchten Sie den Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion) ausprobieren. 
{{% /alert %}}