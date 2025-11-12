---
title: PowerPoint-Präsentationen in SWF-Flash mit Python konvertieren
linktitle: PowerPoint zu SWF-Flash
type: docs
weight: 80
url: /de/python-net/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PowerPoint zu SWF
- Präsentation zu SWF
- Folie zu SWF
- PPT zu SWF
- PPTX zu SWF
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) mit Python und Aspose.Slides in SWF-Flash konvertieren. Schritt‑für‑Schritt‑Codebeispiele, schnelle qualitativ hochwertige Ausgabe, ohne PowerPoint‑Automatisierung."
---

## **Präsentationen in Flash konvertieren**

Die [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Methode, die von der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in ein SWF‑Dokument zu konvertieren. Sie können außerdem Kommentare in das erzeugte SWF einbinden, indem Sie die [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) Klasse und das [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/)‑Interface verwenden. Das folgende Beispiel zeigt, wie man eine Präsentation mit den von der SWFOptions‑Klasse bereitgestellten Optionen in ein SWF‑Dokument konvertiert.

```py
import aspose.slides as slides

# Erzeugt ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Speichert die Präsentation und die Notizseiten
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **FAQ**

**Kann ich verborgene Folien in das SWF einbinden?**

Ja. Aktivieren Sie die Option [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) in [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/). Standardmäßig werden verborgene Folien nicht exportiert.

**Wie kann ich die Kompression und die endgültige SWF‑Größe steuern?**

Verwenden Sie das Flag [compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/) (standardmäßig aktiviert) und passen Sie [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/) an, um Dateigröße und Bildqualität auszubalancieren.

**Wofür ist 'viewer_included' und wann sollte ich es deaktivieren?**

[viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/) fügt eine eingebettete Player‑UI (Navigationssteuerungen, Panels, Suche) hinzu. Deaktivieren Sie es, wenn Sie einen eigenen Player verwenden möchten oder ein reines SWF‑Gerüst ohne UI benötigen.

**Was passiert, wenn auf dem Export‑Rechner eine Quellschrift fehlt?**

Aspose.Slides ersetzt die Schriftart durch die über [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/) in [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) angegebene Schrift, um ein unbeabsichtigtes Ausweichen zu vermeiden.