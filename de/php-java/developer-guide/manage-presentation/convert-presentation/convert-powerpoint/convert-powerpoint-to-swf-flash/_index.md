---
title: PowerPoint-Präsentationen in SWF-Flash in PHP konvertieren
linktitle: PowerPoint zu SWF
type: docs
weight: 80
url: /de/php-java/convert-powerpoint-to-swf-flash/
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
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) in SWF-Flash in PHP mit Aspose.Slides konvertieren. Schritt-für-Schritt-Codebeispiele, schnelle Ausgabe in hoher Qualität, keine PowerPoint-Automatisierung."
---

## **Präsentationen zu Flash konvertieren**

Die [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) Methode, die von der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in ein **SWF**‑Dokument zu konvertieren. Das folgende Beispiel zeigt, wie man eine Präsentation mit den von der [SWFOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) Klasse bereitgestellten Optionen in ein **SWF**‑Dokument konvertiert. Sie können außerdem Kommentare im erzeugten SWF mithilfe der [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) Klasse einbinden.
```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Präsentation speichern
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Kann ich ausgeblendete Folien in das SWF einbinden?**

Ja. Aktivieren Sie ausgeblendete Folien mit der [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setshowhiddenslides/) Methode in [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/). Standardmäßig werden ausgeblendete Folien nicht exportiert.

**Wie kann ich die Kompression und die endgültige SWF‑Größe steuern?**

Verwenden Sie die [setCompressed](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setcompressed/) Methode und [adjust JPEG quality](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setjpegquality/), um die Dateigröße und die Bildtreue auszubalancieren.

**Wofür dient 'setViewerIncluded' und wann sollte ich es deaktivieren?**

[setViewerIncluded](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setviewerincluded/) fügt eine eingebettete Player‑UI (Navigations‑Steuerungen, Panels, Suche) hinzu. Deaktivieren Sie es, wenn Sie einen eigenen Player verwenden möchten oder einen reinen SWF‑Rahmen ohne UI benötigen.

**Was passiert, wenn eine Quellschriftart auf dem Export‑Computer fehlt?**

Aspose.Slides ersetzt die fehlende Schriftart durch die von Ihnen über [setDefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) angegebene Schriftart, um ein unbeabsichtigtes Fallback zu vermeiden.