---
title: Standardpräsentationsschriften in PHP festlegen
linktitle: Standardschrift
type: docs
weight: 30
url: /de/php-java/default-font/
keywords:
- Standardschrift
- Standardschrift
- normale Schrift
- asiatische Schrift
- PDF-Export
- XPS-Export
- Bildexport
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Legen Sie Standard-Schriften in Aspose.Slides für PHP über Java fest, um eine korrekte Konvertierung von PowerPoint (PPT, PPTX) und OpenDocument (ODP) zu PDF, XPS und Bildern sicherzustellen."
---

## **Verwenden von Standardschriften zum Rendern einer Präsentation**
Aspose.Slides ermöglicht das Festlegen der Standardschrift für das Rendern der Präsentation zu PDF, XPS oder Miniaturansichten. Dieser Artikel zeigt, wie man DefaultRegularFont und DefaultAsianFont als Standardschriften definiert. Bitte folgen Sie den untenstehenden Schritten, um Schriften aus externen Verzeichnissen zu laden, indem Sie Aspose.Slides für PHP über die Java‑API verwenden:

1. Erstellen Sie eine Instanz von [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) auf die gewünschte Schrift. Im folgenden Beispiel habe ich Wingdings verwendet.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) auf die gewünschte Schrift. Ich habe Wingdings im folgenden Beispiel verwendet.
1. Laden Sie die Präsentation mit Presentation und den Ladeoptionen.
1. Erzeugen Sie nun die Folien‑Miniaturansicht, das PDF und das XPS, um die Ergebnisse zu überprüfen.

Die Implementierung des obigen Vorgangs wird unten angegeben.
```php
  # Verwenden Sie Ladeoptionen, um die Standard‑Regular‑ und Asian‑Schriften festzulegen
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Laden Sie die Präsentation
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Erstellen Sie die Folien‑Miniaturansicht
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # Bild auf der Festplatte speichern.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # PDF erzeugen
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # XPS erzeugen
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Was genau beeinflussen DefaultRegularFont und DefaultAsianFont – nur den Export oder auch Miniaturansichten, PDF, XPS, HTML und SVG?**

Sie nehmen am Rendering‑Pipeline für alle unterstützten Ausgaben teil. Dazu gehören Folien‑Miniaturansichten, [PDF](/slides/de/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/de/php-java/convert-powerpoint-to-xps/), [Rasterbilder](/slides/de/php-java/convert-powerpoint-to-png/), [HTML](/slides/de/php-java/convert-powerpoint-to-html/) und [SVG](/slides/de/php-java/render-a-slide-as-an-svg-image/), da Aspose.Slides dieselbe Layout‑ und Glyphen‑Auflösungslogik über diese Ziele hinweg verwendet.

**Werden Standardschriften angewendet, wenn man eine PPTX nur liest und speichert, ohne zu rendern?**

Nein. Standardschriften sind relevant, wenn Text gemessen und gezeichnet werden muss. Ein einfaches Öffnen‑und‑Speichern einer Präsentation ändert weder die gespeicherten Schriftläufe noch die Dateistruktur. Standardschriften kommen bei Vorgängen zum Tragen, die Text rendern oder umfließen.

**Wenn ich eigene Schriftordner hinzufüge oder Schriften aus dem Speicher bereitstelle, werden sie bei der Auswahl der Standardschriften berücksichtigt?**

Ja. [Custom font sources](/slides/de/php-java/custom-font/) erweitern den Katalog verfügbarer Familien und Glyphen, die die Engine verwenden kann. Standardschriften und alle [fallback rules](/slides/de/php-java/fallback-font/) werden zuerst gegen diese Quellen aufgelöst, was auf Servern und in Containern eine zuverlässigere Abdeckung liefert.

**Werden Standardschriften die Textmetriken (Kerning, Vorstufen) und damit Zeilenumbrüche und Textumbruch beeinflussen?**

Ja. Das Ändern der Schrift ändert die Glyphenmetriken und kann Zeilenumbrüche, Textumbruch und Paginierung beim Rendern beeinflussen. Für Layout‑Stabilität sollten Sie die Originalschriften [embed the original fonts](/slides/de/php-java/embedded-font/) oder metrisch kompatible Standard‑ und Fallback‑Familien auswählen.

**Hat das Festlegen von Standardschriften einen Sinn, wenn alle in der Präsentation verwendeten Schriften eingebettet sind?**

Oft ist es nicht nötig, da [embedded fonts](/slides/de/php-java/embedded-font/) bereits ein einheitliches Erscheinungsbild gewährleisten. Standardschriften sind dennoch als Sicherheitsnetz nützlich für Zeichen, die im eingebetteten Subset fehlen, oder wenn eine Datei eingebetteten und nicht eingebetteten Text kombiniert.