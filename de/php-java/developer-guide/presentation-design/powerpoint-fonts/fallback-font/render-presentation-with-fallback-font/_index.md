---
title: Präsentation mit Fallback-Schriftart rendern
type: docs
weight: 30
url: /de/php-java/render-presentation-with-fallback-font/
---

Das folgende Beispiel beinhaltet diese Schritte:

1. Wir [erstellen eine Sammlung von Fallback-Schriftartregeln](/slides/de/php-java/create-fallback-fonts-collection/).
1. [Entfernen](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) Sie eine Fallback-Schriftartregel und [fügen Sie Fallback-Schriftarten hinzu](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) zu einer anderen Regel.
1. Setzen Sie die Regel-Sammlung auf [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) Methode.
1. Mit der [Presentation.save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) Methode können wir die Präsentation im gleichen Format speichern oder sie in ein anderes speichern. Nachdem die Fallback-Schriftartregeln-Sammlung auf [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) gesetzt wurde, werden diese Regeln während aller Operationen über die Präsentation angewendet: speichern, rendern, konvertieren usw.

```php
  # Erstellen Sie eine neue Instanz einer Regel-Sammlung
  $rulesList = new FontFallBackRulesCollection();
  # Erstellen Sie eine Anzahl von Regeln
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Versuchen, die Fallback-Schriftart "Tahoma" aus den geladenen Regeln zu entfernen
    $fallBackRule->remove("Tahoma");
    # Und um die Regeln für den angegebenen Bereich zu aktualisieren
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Auch können wir vorhandene Regeln aus der Liste entfernen
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Zuweisen einer vorbereiteten Regel-Liste zur Nutzung
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Rendering eines Thumbnails unter Verwendung der initialisierten Regel-Sammlung und Speichern als JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Speichern Sie das Bild auf der Festplatte im JPEG-Format
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
Erfahren Sie mehr über [Speichern und Konvertierung in Präsentationen](/slides/de/php-java/creating-saving-and-converting-a-presentation/).
{{% /alert %}}