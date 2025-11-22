---
title: Fallback-Schriftartensammlung erstellen
type: docs
weight: 20
url: /de/nodejs-java/create-fallback-fonts-collection/
---

## **Fallback-Regeln anwenden**

Instanzen der Klasse [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) können in einer [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) organisiert werden, die die Klasse [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) implementiert. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Dann kann diese Sammlung der Methode [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) der Klasse [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) zugewiesen werden. FontsManager steuert die Schriftarten in der gesamten Präsentation. Mehr dazu [Über FontsManager und FontsLoader](/slides/de/nodejs-java/about-fontsmanager-and-fontsloader/).

Jede [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) hat eine Methode [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) mit ihrer eigenen Instanz der Klasse [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager).

Hier ein Beispiel, wie man eine Sammlung von Fallback-Schriftartregeln erstellt und sie dem [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) einer bestimmten Präsentation zuweist:  
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


Nachdem der FontsManager mit einer Fallback-Schriftartsammlung initialisiert wurde, werden die Fallback-Schriftarten während der Präsentationsrendering angewendet.

{{% alert color="primary" %}} 
Erfahren Sie mehr, wie Sie eine Präsentation mit Fallback‑Schriftart rendern [Render Presentation with Fallback Font](/slides/de/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Werden meine Fallback-Regeln in die PPTX-Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?**

Nein. Fallback‑Regeln sind Laufzeit‑Render‑Einstellungen; sie werden nicht in die PPTX serialisiert und erscheinen nicht in der PowerPoint‑Benutzeroberfläche.

**Wendet sich das Fallback auf Text in SmartArt, WordArt, Diagrammen und Tabellen an?**

Ja. Der gleiche Glyph‑Substitutions‑Mechanismus wird für jeglichen Text in diesen Objekten verwendet.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Sie fügen Schriftarten selbst hinzu und verwenden sie auf eigene Verantwortung.

**Können Ersetzung/Substitution fehlender Schriftarten und Fallback für fehlende Glyphen zusammen verwendet werden?**

Ja. Sie sind unabhängige Stufen derselben Font‑Auflösungspipeline: Zuerst löst die Engine die Verfügbarkeit von Schriftarten ([replacement](/slides/de/nodejs-java/font-replacement/)/[substitution](/slides/de/nodejs-java/font-substitution/)) auf, dann füllt das Fallback Lücken für fehlende Glyphen in verfügbaren Schriftarten.