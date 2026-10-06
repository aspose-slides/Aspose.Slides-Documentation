---
title: PowerPoint-Präsentationen mit Notizen in Python in PDF konvertieren
linktitle: PowerPoint zu PDF mit Notizen
type: docs
weight: 50
url: /de/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu PDF
- Präsentation zu PDF
- PPT zu PDF
- PPTX zu PDF
- Präsentation als PDF speichern
- PPT nach PDF exportieren
- PPTX nach PDF exportieren
- Sprecher-Notizen
- PDF mit Notizen
- Python
- Java
- Aspose.Slides
description: "PPT- und PPTX-Präsentationen mit Sprecher-Notizen in PDF konvertieren mithilfe von Aspose.Slides für Python über Java. Notizplatzierung konfigurieren und lange Notizen erhalten."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Sprecher‑Notizen mithilfe von Aspose.Slides für Python über Java in PDF konvertiert werden. Sie können Notizen unter jeder Folie einfügen und lange Notizen auf zusätzliche Seiten fortsetzen lassen. Für weitere PDF‑Export‑Einstellungen siehe [PowerPoint in PDF konvertieren](/slides/de/python-java/convert-powerpoint-to-pdf/).

Um die Abmessungen und Ausrichtung der Notizenseite vor dem Export festzulegen, siehe [Größe der Notizenseite](/slides/de/python-java/notes-size/).

## **PowerPoint mit Notizen in PDF konvertieren**

Verwenden Sie die [save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)-Methode der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/), um eine PPT‑ oder PPTX‑Präsentation als PDF zu exportieren. Um Sprecher‑Notizen einzufügen, erstellen Sie ein Objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/) und konfigurieren die Platzierung der Notizen mit dessen Methode [setNotesPosition](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Weisen Sie dieses Layout den [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/) mittels [setSlidesLayoutOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) zu.

Das folgende Beispiel lädt `sample.pptx` und exportiert es zu `output.pdf` mit Sprecher‑Notizen unter den Folien:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # PDF-Optionen für die Darstellung von Sprecher-Notizen konfigurieren.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Die Präsentation mit Sprecher-Notizen als PDF speichern.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Sie können auch den [Online PowerPoint‑zu‑PDF‑Konverter](https://products.aspose.app/slides/de/conversion) ausprobieren.
{{% /alert %}}

## **FAQ**

**Wie kann ich verhindern, dass lange Sprecher‑Notizen abgeschnitten werden?**

Verwenden Sie [NotesPositions.BottomFull](https://reference.aspose.com/slides/de/python-java/aspose.slides/notespositions/#BottomFull), wie im obigen Beispiel. Diese Einstellung zeigt die vollständigen Notizen an und verwendet bei Bedarf zusätzliche Seiten.

**Kann ich jede Folie und ihre Notizen auf einer einzelnen Seite behalten?**

Verwenden Sie [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/de/python-java/aspose.slides/notespositions/#BottomTruncated), diese Einstellung begrenzt die Notizen auf eine Seite, sodass nicht passende Notizen eventuell abgeschnitten werden.

**Wie exportiere ich Folien ohne Sprecher‑Notizen?**

Lassen Sie die Notiz‑Layout‑Konfiguration weg und verwenden Sie den standardmäßigen PDF‑Export, der in [PowerPoint in PDF konvertieren](/slides/de/python-java/convert-powerpoint-to-pdf/) beschrieben ist.