---
title: Fallback-Schriftartsammlungen in Java konfigurieren
linktitle: Fallback-Schriftartsammlung
type: docs
weight: 20
url: /de/java/create-fallback-fonts-collection/
keywords:
- Fallback-Schriftart
- Fallback-Regel
- Schriftartsammlung
- Schriftart konfigurieren
- Schriftart einrichten
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Richten Sie eine Fallback-Schriftartsammlung in Aspose.Slides für Java ein, um Text in PowerPoint- und OpenDocument-Präsentationen konsistent und klar zu halten."
---

## **Fallback-Regeln anwenden**

Instanzen der Klasse [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) können in [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) organisiert werden, das das Interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection) implementiert. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Anschließend kann diese Sammlung der Methode [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) der Klasse [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) zugewiesen werden. FontsManager steuert die Schriftarten in der gesamten Präsentation. Weitere Informationen [Über FontsManager und FontsLoader](/slides/de/java/about-fontsmanager-and-fontsloader/).

Jede [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) hat eine Methode [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) mit ihrer eigenen Instanz der Klasse [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager).

Hier ein Beispiel, wie man eine Sammlung von Fallback‑Schriftartregeln erstellt und in den [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) einer bestimmten Präsentation zuweist:  
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


Nachdem FontsManager mit der Fallback‑Schriftartsammlung initialisiert wurde, werden die Fallback‑Schriftarten während der Rendering‑Phase der Präsentation angewendet.

{{% alert color="primary" %}} 
Weitere Informationen, wie man [Präsentation mit Fallback‑Schriftart rendern](/slides/de/java/render-presentation-with-fallback-font/) kann.
{{% /alert %}}

## **FAQ**

**Werden meine Fallback‑Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?**

Nein. Fallback‑Regeln sind Laufzeit‑Rendering‑Einstellungen; sie werden nicht in die PPTX serialisiert und erscheinen nicht in der PowerPoint‑Benutzeroberfläche.

**Wird das Fallback auch auf Text in SmartArt, WordArt, Diagrammen und Tabellen angewendet?**

Ja. Der gleiche Glyph‑Substitutions‑Mechanismus wird für jeden Text in diesen Objekten verwendet.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Sie fügen Schriftarten selbst hinzu und verwenden sie auf eigene Verantwortung.

**Können Ersatz/Substitution für fehlende Schriftarten und Fallback für fehlende Glyphen zusammen verwendet werden?**

Ja. Sie sind unabhängige Stufen derselben Font‑Auflösungspipeline: Zuerst löst die Engine die Verfügbarkeit von Schriftarten ([replacement](/slides/de/java/font-replacement/)/[substitution](/slides/de/java/font-substitution/)) auf, danach füllt das Fallback Lücken für fehlende Glyphen in den verfügbaren Schriftarten.