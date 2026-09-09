---
title: PowerPoint-Präsentationen mit Notizen in PDF konvertieren in Python
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
- Rednernotizen
- PDF mit Notizen
- Python
- Java
- Aspose.Slides
description: "PowerPoint- und PPTX-Präsentationen mit Rednernotizen in PDF konvertieren mithilfe von Aspose.Slides für Python über Java. Notizplatzierung konfigurieren und lange Notizen erhalten."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Rednernotizen in PDF konvertiert werden können, wobei Aspose.Slides für Python über Java verwendet wird. Sie können Notizen unter jeder Folie einfügen und lange Notizen auf zusätzliche Seiten fortsetzen lassen. Weitere PDF‑Export‑Einstellungen finden Sie unter [Convert PowerPoint to PDF](/slides/de/python-java/convert-powerpoint-to-pdf/).

## **PowerPoint in PDF mit Notizen konvertieren**

Verwenden Sie die [save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)-Methode der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)-Klasse, um eine PPT‑ oder PPTX‑Präsentation nach PDF zu exportieren. Um Rednernotizen einzuschließen, erstellen Sie ein [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/)-Objekt und konfigurieren Sie die Notizplatzierung mit dessen [setNotesPosition](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition)-Methode. Ordnen Sie dieses Layout den [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/) mittels [setSlidesLayoutOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) zu.

Das folgende Beispiel lädt `sample.pptx` und exportiert es nach `output.pdf` mit Rednernotizen unter den Folien:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # PDF-Optionen für die Darstellung von Rednernotizen konfigurieren.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Präsentation mit Rednernotizen als PDF speichern.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Hinweis" %}}
Sie können auch den [Online PowerPoint zu PDF Konverter](https://products.aspose.app/slides/de/conversion) ausprobieren.
{{% /alert %}}

## **FAQ**

**Wie kann ich verhindern, dass lange Rednernotizen abgeschnitten werden?**

Verwenden Sie [NotesPositions.BottomFull](https://reference.aspose.com/slides/de/python-java/aspose.slides/notespositions/#BottomFull), wie im obigen Beispiel. Diese Einstellung zeigt die vollständigen Notizen an und verwendet bei Bedarf zusätzliche Seiten.

**Kann ich jede Folie und ihre Notizen auf einer einzigen Seite behalten?**

Verwenden Sie [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/de/python-java/aspose.slides/notespositions/#BottomTruncated). Diese Einstellung begrenzt die Notizen auf eine Seite, sodass nicht passende Notizen abgeschnitten werden können.

**Wie exportiere ich Folien ohne Rednernotizen?**

Lassen Sie die Notizen‑Layout‑Konfiguration weg und verwenden Sie den Standard‑PDF‑Export, der in [Convert PowerPoint to PDF](/slides/de/python-java/convert-powerpoint-to-pdf/) beschrieben ist.