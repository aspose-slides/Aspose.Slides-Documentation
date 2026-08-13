---
title: Konfigurieren von Fallback‑Schriftartsammlungen in .NET
linktitle: Fallback‑Schriftart‑Sammlung
type: docs
weight: 20
url: /de/net/create-fallback-fonts-collection/
keywords:
- Fallback‑Schriftart
- Fallback‑Regel
- Schriftartsammlung
- Schriftart konfigurieren
- Schriftart einrichten
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Richten Sie eine Fallback‑Schriftartsammlung in Aspose.Slides für .NET ein, um Text in PowerPoint‑ und OpenDocument‑Präsentationen konsistent und klar darzustellen."
---
## **Übersicht**

Aspose.Slides ermöglicht das Konfigurieren einer Sammlung von Fallback‑Schriftartregeln für eine Präsentation. Jede Fallback‑Regel wird durch die Klasse `FontFallBackRule` dargestellt und kann zu einer `FontFallBackRulesCollection` hinzugefügt werden, die das Interface `IFontFallBackRulesCollection` implementiert.

Nach dem Erstellen der Sammlung können Sie sie der Eigenschaft `FontFallBackRulesCollection` des `FontsManager` der Präsentation zuweisen. Der `FontsManager` steuert die Schriften über die gesamte Präsentation, und jede `Presentation`‑Instanz hat ihren eigenen `FontsManager`.

Sobald der `FontsManager` mit der Fallback‑Schriftartsammlung initialisiert ist, werden die angegebenen Fallback‑Schriften während der Präsentationsrenderung angewendet.

## **Fallback‑Regeln anwenden**

Instanzen der Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/net/aspose.slides/FontFallBackRule) können zu einer [FontFallBackRulesCollection](https://reference.aspose.com/slides/de/net/aspose.slides/fontfallbackrulescollection) organisiert werden, die das Interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/de/net/aspose.slides/ifontfallbackrulescollection) implementiert. Es ist möglich, Regeln aus der Sammlung hinzuzufügen oder zu entfernen.

Dann kann diese Sammlung der Eigenschaft [FontFallBackRulesCollection ](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) des [FontsManager](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager)‑Klasse zugewiesen werden. FontsManager steuert die Schriften über die Präsentation.

Jede [Presentation ](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) hat eine [FontsManager ](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/properties/fontsmanager)‑Eigenschaft mit ihrer eigenen Instanz der FontsManager‑Klasse.

Hier ist ein Beispiel, wie man eine Sammlung von Fallback‑Schriftartregeln erstellt und sie dem FontsManager einer bestimmten Präsentation zuweist:  

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Nach der Initialisierung des FontsManager mit der Fallback‑Schriftartsammlung werden die Fallback‑Schriften während der Präsentationsrenderung angewendet.

{{% alert color="info" %}} 
Erfahren Sie mehr, wie Sie [Render Presentation with Fallback Font](/slides/de/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Werden meine Fallback‑Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?

Nein. Fallback‑Regeln sind Einstellungen zur Laufzeit beim Rendern; sie werden nicht in die PPTX‑Datei serialisiert und erscheinen nicht in der Benutzeroberfläche von PowerPoint.

### Wird das Fallback auf Text in SmartArt, WordArt, Diagrammen und Tabellen angewendet?

Ja. Der gleiche Glyph‑Substitutionsmechanismus wird für jeden Text in diesen Objekten verwendet.

### Verteilt Aspose irgendwelche Schriften mit der Bibliothek?

Nein. Sie fügen Schriften selbst hinzu und verwenden sie auf eigene Verantwortung.

### Können Ersatz‑/Substitution für fehlende Schriften und Fallback für fehlende Glyphen zusammen verwendet werden?

Ja. Sie sind unabhängige Stufen derselben Schriftauflösungs‑Pipeline: zuerst löst die Engine die Verfügbarkeit von Schriften ([replacement](/slides/de/net/font-replacement/)/[substitution](/slides/de/net/font-substitution/)) auf, dann füllt das Fallback Lücken für fehlende Glyphen in verfügbaren Schriften.