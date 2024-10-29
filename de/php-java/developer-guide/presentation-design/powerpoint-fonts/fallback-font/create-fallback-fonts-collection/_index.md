---
title: Erstelle Fallback-Schriftartenkollektion
type: docs
weight: 20
url: /de/php-java/create-fallback-fonts-collection/
---

Instanzen der [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) Klasse können in einer [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) organisiert werden, die das [IFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRulesCollection) Interface implementiert. Es ist möglich, Regeln von der Sammlung hinzuzufügen oder zu entfernen.

Diese Sammlung kann dann der [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) Methode der [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) Klasse zugewiesen werden. FontsManager steuert die Schriftarten in der Präsentation. Erfahren Sie mehr [Über FontsManager und FontsLoader](/slides/de/php-java/about-fontsmanager-and-fontsloader/).

Jede [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) hat eine [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) Methode mit ihrer eigenen Instanz der [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) Klasse.

Hier ist ein Beispiel, wie man eine Fallback-Schriftartenregeln-Kollektion erstellt und sie dem [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) einer bestimmten Präsentation zuweist: 

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Nachdem der FontsManager mit der Fallback-Schriftartenkollektion initialisiert wurde, werden die Fallback-Schriftarten während der Präsentationsdarstellung angewendet.

{{% alert color="primary" %}} 
Erfahren Sie mehr, wie man eine [Präsentation mit Fallback-Schriftart rendern](/slides/de/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}