---
title: Flash-Objekte aus Präsentationen in PHP extrahieren
linktitle: Flash
type: docs
weight: 10
url: /de/php-java/flash/
keywords:
- Flash extrahieren
- Flash-Objekt
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Flash-Objekte aus PowerPoint- und OpenDocument-Folien mit Aspose.Slides für PHP via Java extrahieren, inklusive vollständiger Code-Beispiele und bewährter Vorgehensweisen."
---

## **Flash-Objekte aus Präsentationen extrahieren**

Aspose.Slides for PHP via Java bietet eine Möglichkeit zum Extrahieren von Flash-Objekten aus einer Präsentation. Sie können die Flash-Steuerung anhand ihres Namens zugreifen und sie aus der Präsentation extrahieren sowie die SWF-Objektdaten speichern.
```php
  # Instanziieren Sie die Presentation‑Klasse, die das PPTX darstellt
  $pres = new Presentation();
  try {
    $controls = $pres->getSlides()->get_Item(0)->getControls();
    $flashControl = null;
    foreach($controls as $control) {
      if (java_values($control->getName()) == "ShockwaveFlash1") {
        $flashControl = $control;
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Welche Präsentationsformate werden beim Extrahieren von Flash-Inhalten unterstützt?**

[Aspose.Slides supports](/slides/de/php-java/supported-file-formats/) die wichtigsten PowerPoint-Formate wie PPT und PPTX, da es diese Container laden und auf deren Steuerelemente zugreifen kann, einschließlich Flash-bezogener ActiveX-Elemente.

**Kann ich eine Präsentation mit Flash nach HTML5 konvertieren und die Flash-Interaktivität beibehalten?**

Nein. Aspose.Slides führt keinen SWF-Inhalt aus und konvertiert dessen Interaktivität nicht. Während der Export nach [HTML](/slides/de/php-java/convert-powerpoint-to-html/)/[HTML5](/slides/de/php-java/export-to-html5/) unterstützt wird, wird Flash in modernen Browsern aufgrund des Endes der Unterstützung nicht abgespielt. Der empfohlene Weg ist, Flash vor dem Export durch Alternativen wie Video oder HTML5-Animationen zu ersetzen.

**Wird aus Sicherheitsperspektive von Aspose.Slides SWF-Dateien beim Lesen einer Präsentation ausgeführt?**

Nein. Aspose.Slides behandelt Flash als Binärdaten, die in die Datei eingebettet sind, und führt keinen SWF-Inhalt während der Verarbeitung aus.

**Wie sollte ich mit Präsentationen umgehen, die Flash zusammen mit anderen eingebetteten Dateien über OLE enthalten?**

Aspose.Slides unterstützt das [extracting embedded OLE objects](/slides/de/php-java/manage-ole/), sodass Sie alle zugehörigen eingebetteten Inhalte in einem Durchgang verarbeiten können, dabei Flash-Steuerelemente und andere OLE-eingebettete Dokumente gemeinsam handhaben.