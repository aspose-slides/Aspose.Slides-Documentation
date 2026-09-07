---
title: PowerPoint-Präsentationen mit Notizen in TIFF konvertieren in Python
linktitle: PowerPoint zu TIFF mit Notizen
type: docs
weight: 100
url: /de/python-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu TIFF
- Präsentation zu TIFF
- Folie zu TIFF
- PPT zu TIFF
- PPTX zu TIFF
- PPT als TIFF speichern
- PPTX als TIFF speichern
- PPT zu TIFF exportieren
- PPTX zu TIFF exportieren
- PowerPoint mit Notizen
- Präsentation mit Notizen
- Folie mit Notizen
- PPT mit Notizen
- PPTX mit Notizen
- TIFF mit Notizen
- Python
- Java
- Aspose.Slides
description: "PowerPoint-Präsentationen mit Notizen in TIFF konvertieren mit Aspose.Slides für Python via Java. Erfahren Sie, wie Sie Folien mit Sprecher-Notizen effizient exportieren."
---
## **Einleitung**

Aspose.Slides for Python via Java bietet eine einfache Lösung zum Konvertieren von PowerPoint- und OpenDocument-Präsentationen (PPT, PPTX und ODP) mit Notizen in das TIFF-Format. Dieses Format wird häufig für die hochwertige Bildspeicherung, den Druck und die Dokumentenarchivierung verwendet. Verwenden Sie die [save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) Methode der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse, um Folien und deren Sprecher‑Notizen in eine einzelne mehrseitige TIFF‑Datei zu exportieren.

## **Konvertieren einer Präsentation in TIFF mit Notizen**

Das Speichern einer PowerPoint‑ oder OpenDocument‑Präsentation in TIFF mit Notizen unter Verwendung von Aspose.Slides for Python via Java umfasst die folgenden Schritte:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse: Laden Sie eine PowerPoint‑ oder OpenDocument‑Datei.
1. Konfigurieren Sie die Ausgabe‑Layout‑Optionen: Verwenden Sie die [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/) Klasse, um festzulegen, wie Notizen und Kommentare angezeigt werden sollen.
1. Speichern Sie die Präsentation als TIFF: Übergeben Sie die konfigurierten Optionen an die [save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) Methode.

Angenommen, wir haben eine Datei „speaker_notes.pptx“ mit der folgenden Folie:

![Die Präsentationsfolie mit Sprecher‑Notizen](slide_with_notes.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # Zeigt die vollständigen Sprecher-Notizen unter jeder Folie an.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # Konfiguriere die TIFF-Auflösung und das Notiz-Layout.
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # Speichert die Präsentation als TIFF mit Sprecher-Notizen.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Das TIFF‑Bild mit Sprecher‑Notizen](TIFF_with_notes.png)

{{% alert title="Tip" color="success" %}}
Schauen Sie sich den Aspose [Kostenlosen PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/de/conversion/convert-ppt-to-poster-online) an.
{{% /alert %}}

## **FAQ**

**Kann ich die Position des Notizbereichs im resultierenden TIFF steuern?**

Ja. Konfigurieren Sie [setNotesPosition](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) mit [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/de/python-java/aspose.slides/notespositions/#BottomTruncated), um die Notizen auf einer Seite unterzubringen, ggf. zu kürzen, oder [NotesPositions.BottomFull](https://reference.aspose.com/slides/de/python-java/aspose.slides/notespositions/#BottomFull), um alle Notizen bei Bedarf auf zusätzlichen Seiten anzuzeigen. Um Folien ohne Notizen zu exportieren, lassen Sie die Notiz‑Layout‑Konfiguration weg, wie in [Convert PowerPoint to TIFF](/slides/de/python-java/convert-powerpoint-to-tiff/) gezeigt.

**Wie kann ich die Größe einer TIFF‑Datei mit Notizen reduzieren, ohne die Bildqualität zu verlieren?**

Verwenden Sie verlustfreie [LZW compression](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffcompressiontypes/#LZW) über [setCompressionType](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/#setCompressionType). Das Reduzieren der Auflösung oder Farbtiefe kann die Dateigröße weiter verringern, kann jedoch die Bildqualität und Lesbarkeit der Notizen beeinträchtigen. Siehe [TIFF export settings](/slides/de/python-java/convert-powerpoint-to-tiff/) für weitere Optionen.

**Beeinflusst die Schriftart in den Notizen das Ergebnis, wenn die Originalschriften im System fehlen?**

Ja. Fehlende Schriftarten lösen [font substitution](/slides/de/python-java/font-selection-sequence/) aus, was Textmaße und Aussehen ändern kann. [Supply the required fonts](/slides/de/python-java/custom-font/) stellt sicher, dass die gewünschten Schriftarten verwendet werden.