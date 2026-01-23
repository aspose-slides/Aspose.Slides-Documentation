---
title: Präsentationen mit Fallback-Schriften in PHP rendern
linktitle: Präsentationen rendern
type: docs
weight: 30
url: /de/php-java/render-presentation-with-fallback-font/
keywords:
- Fallback-Schriftart
- PowerPoint rendern
- Präsentation rendern
- Folie rendern
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Präsentationen mit Fallback-Schriften in Aspose.Slides für PHP über Java rendern – den Text über PPT, PPTX und ODP hinweg konsistent halten mit Schritt-für-Schritt-Codebeispielen."
---

Das folgende Beispiel enthält diese Schritte:

1. Wir [Fallback‑Schriftregelsammlung erstellen](/slides/de/php-java/create-fallback-fonts-collection/).
2. [Entfernen](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) eine Fallback‑Schriftartregel und [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) zu einer anderen Regel.
3. Setzen Sie die Regelsammlung auf [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--)‑Methode.
4. Mit der [Presentation.save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-)‑Methode können wir die Präsentation im selben Format speichern oder in ein anderes Format konvertieren. Nachdem die Fallback‑Schriftartregeln‑Sammlung im [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) gesetzt wurde, werden diese Regeln bei allen Vorgängen über die Präsentation angewendet: speichern, rendern, konvertieren usw.
```php
  # Neue Instanz einer Regelsammlung erstellen
  $rulesList = new FontFallBackRulesCollection();
  # Eine Anzahl von Regeln erstellen
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Versucht, die Fallback-Schriftart "Tahoma" aus den geladenen Regeln zu entfernen
    $fallBackRule->remove("Tahoma");
    # Und die Regeln für den angegebenen Bereich zu aktualisieren
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Außerdem können wir vorhandene Regeln aus der Liste entfernen
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Zuweisung einer vorbereiteten Regel-Liste zur Verwendung
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Rendering des Vorschaubilds unter Verwendung der initialisierten Regelsammlung und Speichern als JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Bild im JPEG-Format auf die Festplatte speichern
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 
Lesen Sie mehr darüber, wie Sie [PPT und PPTX nach JPG in PHP konvertieren](/slides/de/php-java/convert-powerpoint-to-jpg/).
{{% /alert %}}