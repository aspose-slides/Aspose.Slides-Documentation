---
title: Fallback-Schriftartkollektionen in JavaScript konfigurieren
linktitle: Fallback-Schriftartkollektion
type: docs
weight: 20
url: /de/nodejs-java/create-fallback-fonts-collection/
keywords:
- Fallback-Schriftart
- Fallback-Regel
- Schriftartsammlung
- Schriftart konfigurieren
- Schriftart einrichten
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Richten Sie eine Fallback-Schriftartkollektion in JavaScript mit Aspose.Slides für Node.js ein, um Text in PowerPoint- und OpenDocument-Präsentationen konsistent und klar darzustellen."
---

## **Fallback-Regeln anwenden**

Instanzen der Klasse [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) können in [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) organisiert werden, die die Klasse [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) implementiert. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Dann kann diese Sammlung der Methode [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) der Klasse [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) zugewiesen werden. FontsManager steuert die Schriftarten in der gesamten Präsentation.

Jede [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) hat eine Methode [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) mit ihrer eigenen Instanz der Klasse [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager).

Hier ist ein Beispiel, wie man eine Sammlung von Fallback-Schriftartenregeln erstellt und sie dem [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) einer bestimmten Präsentation zuweist:  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Nachdem FontsManager mit einer Fallback-Schriftarten-Sammlung initialisiert wurde, werden die Fallback-Schriftarten während der Präsentationsrendering angewendet.

{{% alert color="primary" %}} 
Lesen Sie mehr, wie man [Präsentation mit Fallback-Schriftart rendern](/slides/de/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Werden meine Fallback-Regeln in die PPTX-Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?**

Nein. Fallback-Regeln sind Laufzeit-Rendering-Einstellungen; sie werden nicht in die PPTX serialisiert und erscheinen nicht in der PowerPoint-Oberfläche.

**Wird Fallback auf Text in SmartArt, WordArt, Diagrammen und Tabellen angewendet?**

Ja. Der gleiche Glyph‑Substitutionsmechanismus wird für jeglichen Text in diesen Objekten verwendet.

**Stellt Aspose irgendwelche Schriftarten mit der Bibliothek bereit?**

Nein. Sie fügen Schriftarten hinzu und verwenden sie auf Ihrer Seite und auf eigene Verantwortung.

**Kann Ersatz/Substitution fehlender Schriftarten und Fallback für fehlende Glyphen zusammen verwendet werden?**

Ja. Sie sind unabhängige Stufen derselben Schriftartenauflösungs-Pipeline: Zuerst ermittelt die Engine die Verfügbarkeit von Schriftarten ([replacement](/slides/de/nodejs-java/font-replacement/)/[substitution](/slides/de/nodejs-java/font-substitution/)), dann füllt Fallback Lücken für fehlende Glyphen in verfügbaren Schriftarten.