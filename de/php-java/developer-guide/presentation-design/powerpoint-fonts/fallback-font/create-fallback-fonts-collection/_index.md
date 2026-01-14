---
title: Konfigurieren von Fallback‑Schriftartensammlungen in PHP
linktitle: Fallback‑Schriftartensammlung
type: docs
weight: 20
url: /de/php-java/create-fallback-fonts-collection/
keywords:
- Fallback‑Schriftart
- Fallback‑Regel
- Schriftartensammlung
- Schriftart konfigurieren
- Schriftart einrichten
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Richten Sie eine Fallback‑Schriftartensammlung in Aspose.Slides für PHP über Java ein, um Text in PowerPoint‑ und OpenDocument‑Präsentationen konsistent und scharf zu halten."
---

## **Fallback-Regeln anwenden**

Instanzen der Klasse [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) können in [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) organisiert werden. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Anschließend kann diese Sammlung der Methode [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) der Klasse [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) zugewiesen werden. FontsManager steuert die Schriftarten in der gesamten Präsentation. Lesen Sie mehr [About FontsManager and FontsLoader](/slides/de/php-java/about-fontsmanager-and-fontsloader/).

Jede [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) hat eine [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) Methode mit ihrer eigenen Instanz der [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) Klasse.

Hier ist ein Beispiel, wie man eine Sammlung von Fallback‑Schriftarten‑Regeln erstellt und sie dem [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) einer bestimmten Präsentation zuweist:
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


Nachdem der FontsManager mit einer Fallback‑Schriftarten‑Sammlung initialisiert wurde, werden die Fallback‑Schriftarten während der Präsentations‑Renderung angewendet.

{{% alert color="primary" %}} 
Lesen Sie mehr, wie Sie eine Präsentation mit einer Fallback‑Schriftart rendern: [Präsentation mit Fallback‑Schriftart rendern](/slides/de/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Häufig gestellte Fragen**

**Werden meine Fallback‑Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?**

Nein. Fallback‑Regeln sind Laufzeit‑Render‑Einstellungen; sie werden nicht in die PPTX serialisiert und erscheinen nicht in der PowerPoint‑Benutzeroberfläche.

**Wendet sich das Fallback auf Text in SmartArt, WordArt, Diagrammen und Tabellen an?**

Ja. Der gleiche Glyph‑Substitutions‑Mechanismus wird für beliebigen Text in diesen Objekten verwendet.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Sie fügen Schriftarten selbst hinzu und verwenden sie auf eigene Verantwortung.

**Können Ersatz/Substitution für fehlende Schriftarten und Fallback für fehlende Glyphen gemeinsam verwendet werden?**

Ja. Sie sind unabhängige Phasen derselben Schrift‑Auflösungs‑Pipeline: zuerst löst die Engine die Verfügbarkeit von Schriftarten ([replacement](/slides/de/php-java/font-replacement/)/[substitution](/slides/de/php-java/font-substitution/)) auf, dann füllt das Fallback Lücken für fehlende Glyphen in verfügbaren Schriftarten.