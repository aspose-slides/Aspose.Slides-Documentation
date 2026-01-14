---
title: PowerPoint-Präsentationen in SWF Flash mit Python konvertieren
linktitle: PowerPoint zu SWF Flash
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
description: "PowerPoint (PPT/PPTX) in SWF Flash mit Python und Aspose.Slides konvertieren. Schritt‑für‑Schritt‑Codebeispiele, schnelle Qualitätsausgabe, keine PowerPoint‑Automatisierung."
---

## **Präsentationen in Flash konvertieren**

Die mit der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) bereitgestellte [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)-Methode kann verwendet werden, um die gesamte Präsentation in ein SWF‑Dokument zu konvertieren. Sie können außerdem Kommentare im erzeugten SWF einbinden, indem Sie die Klassen [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) und [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) verwenden. Das folgende Beispiel zeigt, wie man eine Präsentation mit den von der Klasse SWFOptions bereitgestellten Optionen in ein SWF‑Dokument konvertiert.
```py
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Speichern der Präsentation und Notizseiten
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```


## **FAQ**

**Kann ich verborgene Folien in das SWF einbinden?**

Ja. Aktivieren Sie die [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) Option in [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/). Standardmäßig werden verborgene Folien nicht exportiert.

**Wie kann ich die Kompression und die endgültige SWF‑Größe steuern?**

Verwenden Sie das [compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/) Flag (standardmäßig aktiviert) und passen Sie [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/) an, um Dateigröße und Bildqualität auszubalancieren.

**Wofür ist 'viewer_included' vorgesehen und wann sollte ich es deaktivieren?**

[viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/) fügt eine eingebettete Player‑UI (Navigations‑Steuerelemente, Panels, Suche) hinzu. Deaktivieren Sie es, wenn Sie einen eigenen Player verwenden oder einen reinen SWF‑Rahmen ohne UI benötigen.

**Was passiert, wenn eine Quellschriftart auf dem Export‑Rechner fehlt?**

Aspose.Slides wird die Schriftart, die Sie über [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/) in [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) angeben, substituieren, um ein unbeabsichtigtes Fallback zu vermeiden.