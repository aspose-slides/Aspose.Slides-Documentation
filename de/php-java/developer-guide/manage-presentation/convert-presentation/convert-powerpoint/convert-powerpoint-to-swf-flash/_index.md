---
title: PowerPoint-Präsentationen in SWF Flash mit PHP konvertieren
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
description: "PowerPoint (PPT/PPTX) in SWF Flash mit PHP und Aspose.Slides konvertieren. Schritt-fuer-Schritt-Codebeispiele, schnelle hochwertige Ausgabe, keine PowerPoint-Automatisierung."
---

## **Präsentationen in Flash konvertieren**
Die [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode, die von der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in ein **SWF**‑Dokument zu konvertieren. Das folgende Beispiel zeigt, wie man eine Präsentation mit den von der [**SWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SwfOptions) Klasse bereitgestellten Optionen in ein **SWF**‑Dokument konvertiert. Sie können auch Kommentare in das erzeugte SWF einbinden, indem Sie die [**ISWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISwfOptions) Klasse und das [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions) Interface verwenden.
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

**Kann ich versteckte Folien in das SWF einbeziehen?**

Ja. Aktivieren Sie die versteckten Folien mit der [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setshowhiddenslides/) Methode in [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/). Standardmäßig werden versteckte Folien nicht exportiert.

**Wie kann ich die Kompression und die endgültige SWF‑Größe steuern?**

Verwenden Sie die [setCompressed](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setcompressed/) Methode und die [JPEG‑Qualität anpassen](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setjpegquality/), um Dateigröße und Bildtreue auszubalancieren.

**Wofür dient 'setViewerIncluded' und wann sollte ich es deaktivieren?**

[setViewerIncluded](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setviewerincluded/) fügt eine eingebettete Player‑Benutzeroberfläche (Navigations‑Steuerelemente, Paneele, Suche) hinzu. Deaktivieren Sie es, wenn Sie einen eigenen Player verwenden möchten oder einen reinen SWF‑Rahmen ohne UI benötigen.

**Was passiert, wenn eine Quellschriftart auf dem Export‑Rechner fehlt?**

Aspose.Slides ersetzt die Schriftart durch die, die Sie über [setDefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) angeben, um ein unbeabsichtigtes Fallback zu vermeiden.