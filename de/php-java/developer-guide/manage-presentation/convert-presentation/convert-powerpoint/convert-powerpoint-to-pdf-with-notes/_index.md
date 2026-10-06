---
title: PowerPoint-Präsentationen mit Notizen in PDF konvertieren in PHP
linktitle: PowerPoint zu PDF mit Notizen
type: docs
weight: 50
url: /de/php-java/convert-powerpoint-to-pdf-with-notes/
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
- PPT zu PDF exportieren
- PPTX zu PDF exportieren
- Sprechernotizen
- PDF mit Notizen
- PHP
- Aspose.Slides
description: "Formate PPT und PPTX mit Notizen in PDF konvertieren mit Aspose.Slides für PHP über Java. Layouts und Sprechernotizen für professionelle Präsentationen beibehalten."
---
## **Übersicht**

In diesem Artikel erfahren Sie, wie Sie PowerPoint‑Präsentationen mithilfe von Aspose.Slides in das PDF‑Format mit Sprechernotizen konvertieren. Dieser Leitfaden behandelt die erforderlichen Schritte und liefert Codebeispiele, die Ihnen helfen, diese Aufgabe effizient zu erledigen. Am Ende dieses Artikels können Sie:

- Den Konvertierungsprozess implementieren, um PowerPoint‑Folien in PDF‑Dokumente zu transformieren und dabei die Sprechernotizen beizubehalten.
- Das AusgabepDF anpassen, sodass die Sprechernotizen nach Ihren Anforderungen eingeschlossen und formatiert werden.

Um die Abmessungen und die Ausrichtung der Notizseite vor dem Export festzulegen, siehe [Notizseitengröße](/slides/de/php-java/notes-size/).

## **PowerPoint in PDF mit Notizen konvertieren**

Die `save`‑Methode in der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse kann verwendet werden, um eine PPT‑ oder PPTX‑Präsentation in ein PDF mit Sprechernotizen zu konvertieren. Mit Aspose.Slides laden Sie einfach die Präsentation, konfigurieren die Layout‑Optionen mithilfe der [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/notescommentslayoutingoptions/)‑Klasse, um Sprechernotizen einzubeziehen, und speichern die Datei anschließend als PDF. Das folgende Code‑Snippet demonstriert, wie Sie eine Beispiel‑Präsentation in ein PDF im Notizfolien‑Modus konvertieren.

```php
$presentation = new Presentation("sample.pptx");

// PDF-Optionen für die Darstellung von Sprechernotizen konfigurieren.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Sprechernotizen unterhalb der Folie rendern.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Präsentation mit Sprechernotizen als PDF speichern.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Hinweis" %}}

Vielleicht möchten Sie den Aspose [Online PowerPoint‑zu‑PDF‑Konverter](https://products.aspose.app/slides/de/conversion) ausprobieren.

{{% /alert %}}