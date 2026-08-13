---
title: Fallback-Schriftartsammlungen auf Android konfigurieren
linktitle: Fallback-Schriftartsammlung
type: docs
weight: 20
url: /de/androidjava/create-fallback-fonts-collection/
keywords:
- Fallback-Schriftart
- Fallback-Regel
- Schriftartsammlung
- Schriftart konfigurieren
- Schriftart einrichten
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Richten Sie eine Fallback-Schriftartsammlung in Aspose.Slides für Android über Java ein, um Text in PowerPoint- und OpenDocument-Präsentationen konsistent und klar zu halten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, eine Sammlung von Fallback‑Schriftartenregeln für eine Präsentation zu konfigurieren. Jede Fallback‑Regel wird durch die Klasse `FontFallBackRule` dargestellt und kann zu einer `FontFallBackRulesCollection` hinzugefügt werden, die das Interface `IFontFallBackRulesCollection` implementiert.

Nach dem Erstellen der Sammlung können Sie sie der Eigenschaft `FontFallBackRulesCollection` des `FontsManager` der Präsentation zuweisen. Der `FontsManager` steuert die Schriftarten in der gesamten Präsentation, und jede `Presentation`‑Instanz hat ihren eigenen `FontsManager`.

Sobald der `FontsManager` mit der Fallback‑Schriftartensammlung initialisiert ist, werden die angegebenen Fallback‑Schriftarten während der Renderung der Präsentation angewendet.

## **Fallback‑Regeln anwenden**

Instanzen der Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontFallBackRule) können in eine [FontFallBackRulesCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontFallBackRulesCollection) geordnet werden, die das Interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IFontFallBackRulesCollection) implementiert. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Anschließend kann diese Sammlung der Methode [FontFallBackRulesCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontFallBackRulesCollection) der Klasse [FontsManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontsManager) zugewiesen werden. Der FontsManager steuert die Schriftarten in der gesamten Präsentation.

Jede [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) verfügt über eine Methode [getFontsManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getFontsManager--) mit ihrer eigenen Instanz der Klasse [FontsManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontsManager).

Hier ist ein Beispiel, wie Sie eine Sammlung von Fallback‑Schriftartregeln erstellen und sie dem [FontsManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getFontsManager--) einer bestimmten Präsentation zuweisen:  

```java
import com.aspose.slides.*;

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

Nachdem der FontsManager mit der Fallback‑Schriftartensammlung initialisiert wurde, werden die Fallback‑Schriftarten während der Renderung der Präsentation angewendet.

{{% alert color="info" %}} 
Lesen Sie mehr darüber, wie Sie [Präsentation mit Fallback‑Schriftart rendern](/slides/de/androidjava/render-presentation-with-fallback-font/) können.
{{% /alert %}}

## **FAQ**

### Wird meine Fallback‑Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?

Nein. Fallback‑Regeln sind Laufzeit‑Render‑Einstellungen; sie werden nicht in die PPTX serialisiert und erscheinen nicht in der PowerPoint‑Benutzeroberfläche.

### Wird Fallback auf Text innerhalb von SmartArt, WordArt, Diagrammen und Tabellen angewendet?

Ja. Der gleiche Glyph‑Substitutionsmechanismus wird für jeden Text in diesen Objekten verwendet.

### Stellt Aspose irgendwelche Schriftarten mit der Bibliothek bereit?

Nein. Sie fügen Schriftarten selbst hinzu und verwenden sie auf eigene Verantwortung.

### Können Ersetzung/Substitution für fehlende Schriftarten und Fallback für fehlende Glyphen zusammen verwendet werden?

Ja. Sie sind unabhängige Stufen derselben Schriftart‑Auflösungspipeline: Zuerst löst die Engine die Verfügbarkeit von Schriftarten ([Ersetzung](/slides/de/androidjava/font-replacement/)/[Substitution](/slides/de/androidjava/font-substitution/)) auf, anschließend füllt Fallback Lücken für fehlende Glyphen in verfügbaren Schriftarten.