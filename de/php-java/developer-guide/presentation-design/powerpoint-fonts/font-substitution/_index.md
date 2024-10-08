---
title: Schriftartenersetzung - PowerPoint Java API
linktitle: Schriftartenersetzung
type: docs
weight: 70
url: /de/php-java/font-substitution/
keywords: "Schriftart, Ersatzschriftart, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Ersatzschriftart in PowerPoint"
---

Aspose.Slides ermöglicht es Ihnen, Regeln für Schriftarten festzulegen, die bestimmen, was unter bestimmten Bedingungen (zum Beispiel, wenn auf eine Schriftart nicht zugegriffen werden kann) zu tun ist:

1. Laden Sie die relevante Präsentation.
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart.
4. Fügen Sie eine Regel für den Austausch hinzu.
5. Fügen Sie die Regel zur Schriftartenersetzungsregel-Sammlung der Präsentation hinzu.
6. Generieren Sie das Folienbild, um den Effekt zu beobachten.

Dieser PHP-Code demonstriert den Prozess der Schriftartenersetzung:

```php
  # Lädt eine Präsentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Lädt die Quellschriftart, die ersetzt werden soll
    $sourceFont = new FontData("SomeRareFont");
    # Lädt die neue Schriftart
    $destFont = new FontData("Arial");
    # Fügt eine Schriftartregel für die Schriftartenersetzung hinzu
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # Fügt die Regel zur Sammlung der Ersatzschriftartenregeln hinzu
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # Fügt eine Schriftartenregel-Sammlung zur Regel-Liste hinzu
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # Die Arial-Schriftart wird anstelle von SomeRareFont verwendet, wenn Letztere nicht zugänglich ist
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Speichert das Bild im JPEG-Format auf der Festplatte
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
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

{{%  alert title="HINWEIS"  color="warning"   %}} 

Möglicherweise möchten Sie [**Schriftartenersetzung**](/slides/de/php-java/font-replacement/) sehen.

{{% /alert %}}