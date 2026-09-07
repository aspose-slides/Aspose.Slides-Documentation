---
title: PowerPoint-Präsentationen zu SWF-Flash in Python via Java konvertieren
linktitle: PowerPoint zu SWF
type: docs
weight: 80
url: /de/python-java/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu SWF
- Präsentation zu SWF
- Folie zu SWF
- PPT zu SWF
- PPTX zu SWF
- PowerPoint zu Flash
- Präsentation zu Flash
- Folie zu Flash
- PPT zu Flash
- PPTX zu Flash
- PPT als SWF speichern
- PPTX als SWF speichern
- PPT nach SWF exportieren
- PPTX nach SWF exportieren
- Python
- Java
- Aspose.Slides
description: "PowerPoint-Präsentationen in SWF-Flash in Python via Java mit Aspose.Slides konvertieren. Viewer, Notizen, ausgeblendete Folien, Kompression und Schriften konfigurieren."
---
## **Übersicht**

Aspose.Slides for Python via Java ermöglicht das Konvertieren von PowerPoint‑Präsentationen in SWF ohne Microsoft PowerPoint. Verwenden Sie [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) zum Exportieren der Präsentation und [SwfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/swfoptions/) zum Konfigurieren der Viewereinstellungen, Bildqualität und des Layouts von Notizen oder Kommentaren.

## **Präsentationen in Flash konvertieren**

Laden Sie die Quelldatei mit [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/), konfigurieren Sie [SwfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/swfoptions/), und speichern Sie sie mit [SaveFormat.Swf](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Swf).

Das folgende Beispiel exportiert `presentation.pptx` nach `presentation.swf`. Es deaktiviert den eingebetteten Viewer mit [setViewerIncluded](https://reference.aspose.com/slides/de/python-java/aspose.slides/swfoptions/#setViewerIncluded) und fügt Sprechernotizen unter den Folien mittels [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/) hinzu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

Bevor Sie das Beispiel ausführen, [installieren Sie Aspose.Slides für Python via Java](/slides/de/python-java/installation/) und legen Sie `presentation.pptx` im Arbeitsverzeichnis ab. Die JVM wird einmal pro Python‑Prozess gestartet.

Das Beispiel wendet [NotesPositions.BottomFull](https://reference.aspose.com/slides/de/python-java/aspose.slides/notespositions/#BottomFull) über [setNotesPosition](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) an und übergibt das Layout an [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions). Um auch Kommentare einzuschließen, konfigurieren Sie vor dem Exportieren [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition).

## **FAQ**

**Kann ich ausgeblendete Folien in das SWF einbinden?**

Ja. Rufen Sie [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) mit `True` auf. Standardmäßig werden ausgeblendete Folien nicht exportiert.

**Wie kann ich die Kompression und die endgültige SWF‑Größe steuern?**

Verwenden Sie [SwfOptions.setCompressed](https://reference.aspose.com/slides/de/python-java/aspose.slides/swfoptions/#setCompressed), um die Kompression zu aktivieren oder zu deaktivieren, und [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/de/python-java/aspose.slides/swfoptions/#setJpegQuality), um die JPEG‑Bildqualität anzupassen. Eine niedrigere JPEG‑Qualität kann die Dateigröße verringern, geht jedoch zulasten der Bildtreue.

**Wofür dient der eingebettete Viewer und wann sollte ich ihn deaktivieren?**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/de/python-java/aspose.slides/swfoptions/#setViewerIncluded) steuert, ob das erzeugte SWF den Viewer enthält. Übergeben Sie `False`, wenn Sie die exportierten Folien ohne eingebetteten Viewer benötigen, wie im obigen Beispiel.

**Was passiert, wenn eine Quellschriftart auf dem Exportrechner fehlt?**

Sie können mit [setDefaultRegularFont](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) eine Standardschriftart festlegen, die von [SwfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/swfoptions/) geerbt wird. Wählen Sie eine Schriftart, die im Exportprozess verfügbar ist; die Schriftartsubstitution kann das Erscheinungsbild und das Layout des Textes ändern.