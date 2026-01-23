---
title: "Fallback-Schriftartsammlungen in PHP konfigurieren"
linktitle: "Fallback-Schriftartsammlung"
type: docs
weight: 20
url: /de/php-java/create-fallback-fonts-collection/
keywords:
- "Fallback-Schriftart"
- "Fallback-Regel"
- "Schriftartsammlung"
- "Schriftart konfigurieren"
- "Schriftart einrichten"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "PHP"
- "Aspose.Slides"
description: "Richten Sie eine Fallback-Schriftartsammlung in Aspose.Slides für PHP über Java ein, um Text in PowerPoint- und OpenDocument-Präsentationen konsistent und scharf zu halten."
---

## **Fallback-Regeln anwenden**

Instanzen der [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) Klasse können in [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) organisiert werden. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder aus ihr zu entfernen.

Anschließend kann diese Sammlung der [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) Methode der [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) Klasse zugewiesen werden. FontsManager steuert die Schriften in der gesamten Präsentation.

Jede [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) verfügt über eine [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) Methode mit ihrer eigenen Instanz der [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) Klasse.

Hier ist ein Beispiel, wie man eine Sammlung von Fallback‑Schrift‑Regeln erstellt und sie dem [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) einer bestimmten Präsentation zuweist:  
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


Nachdem FontsManager mit der Fallback‑Schrift‑Sammlung initialisiert wurde, werden die Fallback‑Schriften während der Rendering‑Phase der Präsentation angewendet.

{{% alert color="primary" %}} 
Lesen Sie mehr darüber, wie man eine Präsentation mit Fallback‑Schrift rendert [/slides/php-java/render-presentation-with-fallback-font/](https://reference.aspose.com/slides/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Werden meine Fallback‑Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?**

Nein. Fallback‑Regeln sind Runtime‑Rendering‑Einstellungen; sie werden nicht in die PPTX serialisiert und erscheinen nicht in der PowerPoint‑Benutzeroberfläche.

**Gelten die Fallback‑Regeln für Text in SmartArt, WordArt, Diagrammen und Tabellen?**

Ja. Der gleiche Glyph‑Substitutions‑Mechanismus wird für jeden Text in diesen Objekten verwendet.

**Stellt Aspose irgendwelche Schriften zusammen mit der Bibliothek bereit?**

Nein. Sie fügen Schriften selbst hinzu und verwenden sie auf eigene Verantwortung.

**Können Ersatz/Substitution für fehlende Schriften und Fallback für fehlende Glyphen zusammen verwendet werden?**

Ja. Sie sind unabhängige Stufen derselben Schriftauflösungs‑Pipeline: Zuerst löst die Engine die Verfügbarkeit von Schriften ([replacement](/slides/de/php-java/font-replacement/)/[substitution](/slides/de/php-java/font-substitution/)) auf, danach füllt das Fallback fehlende Glyphen in den verfügbaren Schriften auf.