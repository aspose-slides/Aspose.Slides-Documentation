---
title: Fallback-Schriftartensammlungen auf Android konfigurieren
linktitle: Fallback-Schriftartensammlung
type: docs
weight: 20
url: /de/androidjava/create-fallback-fonts-collection/
keywords:
- Fallback-Schriftart
- Fallback-Regel
- Schriftartensammlung
- Schriftart konfigurieren
- Schriftart einrichten
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Richten Sie eine Fallback-Schriftartensammlung in Aspose.Slides für Android über Java ein, um Text in PowerPoint- und OpenDocument-Präsentationen konsistent und klar zu halten."
---

## **Fallback-Regeln anwenden**

Instanzen der Klasse [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) können in [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) organisiert werden, die das [IFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRulesCollection) Interface implementiert. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Dann kann diese Sammlung der Methode [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) der [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) Klasse zugewiesen werden. FontsManager steuert die Schriften in der gesamten Präsentation. Lesen Sie mehr [Über FontsManager und FontsLoader](/slides/de/androidjava/about-fontsmanager-and-fontsloader/).

Jede [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) hat eine Methode [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) mit ihrer eigenen Instanz der Klasse [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager).

Hier ist ein Beispiel, wie man eine Sammlung von Fallback‑Schriftregeln erstellt und sie dem [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) einer bestimmten Präsentation zuweist:
```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```


Nachdem FontsManager mit einer Fallback‑Schriftartensammlung initialisiert wurde, werden die Fallback‑Schriften während der Präsentationsrenderung angewendet.

{{% alert color="primary" %}} 
Lesen Sie mehr darüber, wie Sie die Präsentation mit einer Fallback‑Schrift rendern [Präsentation mit Fallback‑Schrift rendern](/slides/de/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Werden meine Fallback‑Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?**

Nein. Fallback‑Regeln sind Laufzeit‑Render‑Einstellungen; sie werden nicht in die PPTX serialisiert und erscheinen nicht in der PowerPoint‑Benutzeroberfläche.

**Wird Fallback auf Text in SmartArt, WordArt, Diagrammen und Tabellen angewendet?**

Ja. Der gleiche Glyph‑Substitutions‑Mechanismus wird für jeglichen Text in diesen Objekten verwendet.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Sie fügen Schriftarten selbst hinzu und verwenden sie auf eigene Verantwortung.

**Können Ersatz/Substitution für fehlende Schriftarten und Fallback für fehlende Glyphen zusammen verwendet werden?**

Ja. Sie sind unabhängige Stufen derselben Schriftauflösungs‑Pipeline: Zuerst löst die Engine die Verfügbarkeit von Schriftarten ([Ersatz](/slides/de/androidjava/font-replacement/)/[Substitution](/slides/de/androidjava/font-substitution/)) auf, anschließend füllt Fallback Lücken für fehlende Glyphen in verfügbaren Schriftarten.