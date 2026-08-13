---
title: Fallback‑Schriftartsammlungen in Java konfigurieren
linktitle: Fallback‑Schriftartsammlung
type: docs
weight: 20
url: /de/java/create-fallback-fonts-collection/
keywords:
- Fallback‑Schriftart
- Fallback‑Regel
- Schriftartsammlung
- Schriftart konfigurieren
- Schriftart einrichten
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Richten Sie eine Fallback‑Schriftartsammlung in Aspose.Slides für Java ein, um Text in PowerPoint‑ und OpenDocument‑Präsentationen konsistent und klar darzustellen."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, eine Sammlung von Fallback‑Schriftartregeln für eine Präsentation zu konfigurieren. Jede Fallback‑Regel wird durch die Klasse `FontFallBackRule` dargestellt und kann zu einer `FontFallBackRulesCollection` hinzugefügt werden, die das Interface `IFontFallBackRulesCollection` implementiert.

Nach dem Erstellen der Sammlung können Sie sie der Eigenschaft `FontFallBackRulesCollection` des `FontsManager` der Präsentation zuweisen. Der `FontsManager` steuert die Schriftarten in der gesamten Präsentation, und jede `Presentation`‑Instanz verfügt über einen eigenen `FontsManager`.

Sobald der `FontsManager` mit der Fallback‑Schriftartsammlung initialisiert ist, werden die angegebenen Fallback‑Schriftarten während der Rendering‑Phase der Präsentation angewendet.

## **Fallback‑Regeln anwenden**

Instanzen der Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontFallBackRule) können in einer [FontFallBackRulesCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontFallBackRulesCollection) organisiert werden, die das [IFontFallBackRulesCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/IFontFallBackRulesCollection)‑Interface implementiert. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Anschließend kann diese Sammlung der Methode [FontFallBackRulesCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontFallBackRulesCollection) der Klasse [FontsManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontsManager) zugewiesen werden. Der FontsManager steuert die Schriftarten in der gesamten Präsentation.

Jede [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation) verfügt über eine [getFontsManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getFontsManager--)‑Methode mit einer eigenen Instanz der [FontsManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontsManager)‑Klasse.

Hier ein Beispiel, wie Sie eine Sammlung von Fallback‑Schriftartenregeln erstellen und sie dem [FontsManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getFontsManager--) einer bestimmten Präsentation zuweisen:  

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

Nachdem der FontsManager mit der Fallback‑Schriftartsammlung initialisiert wurde, werden die Fallback‑Schriftarten während des Renderns der Präsentation angewendet.

{{% alert color="info" %}} 
Erfahren Sie mehr, wie Sie eine Präsentation mit Fallback‑Schriftart rendern.
{{% /alert %}}

## **FAQ**

### Werden meine Fallback‑Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?

Nein. Fallback‑Regeln sind Laufzeit‑Rendering‑Einstellungen; sie werden nicht in die PPTX serialisiert und erscheinen nicht in der PowerPoint‑Benutzeroberfläche.

### Wird das Fallback auf Text in SmartArt, WordArt, Diagrammen und Tabellen angewendet?

Ja. Der gleiche Glyph‑Substitutions‑Mechanismus wird für jeglichen Text in diesen Objekten verwendet.

### Liefert Aspose irgendwelche Schriftarten mit der Bibliothek aus?

Nein. Sie fügen Schriftarten selbst hinzu und verwenden sie auf eigene Verantwortung.

### Können Ersatz/ Substitution für fehlende Schriftarten und Fallback für fehlende Glyphen zusammen verwendet werden?

Ja. Sie sind unabhängige Stufen derselben Schriftarten‑Auflösungs‑Pipeline: Zuerst löst die Engine die Verfügbarkeit von Schriftarten ([replacement](/slides/de/java/font-replacement/)/[substitution](/slides/de/java/font-substitution/)) auf, dann füllt das Fallback Lücken für fehlende Glyphen in den verfügbaren Schriftarten.