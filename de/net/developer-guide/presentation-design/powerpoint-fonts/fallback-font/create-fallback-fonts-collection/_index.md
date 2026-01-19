---
title: Fallback-Schriftartsammlungen in .NET konfigurieren
linktitle: Fallback-Schriftartsammlung
type: docs
weight: 20
url: /de/net/create-fallback-fonts-collection/
keywords:
- Fallback-Schriftart
- Fallback-Regel
- Schriftartsammlung
- Schriftart konfigurieren
- Schriftart einrichten
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Richten Sie eine Fallback-Schriftartsammlung in Aspose.Slides für .NET ein, um Text in PowerPoint- und OpenDocument-Präsentationen konsistent und scharf zu halten."
---

## **Fallback-Regeln anwenden**

Instanzen der Klasse [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) können in einer [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) organisiert werden, die das Interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection) implementiert. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Anschließend kann diese Sammlung der Eigenschaft [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) der Klasse [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager) zugewiesen werden. FontsManager steuert die Schriftarten in der gesamten Präsentation.

Jede [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) hat eine [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager)-Eigenschaft mit ihrer eigenen Instanz der FontsManager-Klasse.

Hier ist ein Beispiel, wie man eine Sammlung von Fallback-Schriftartregeln erstellt und sie dem FontsManager einer bestimmten Präsentation zuweist:
```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```


Nachdem der FontsManager mit der Fallback-Schriftartsammlung initialisiert wurde, werden die Fallback‑Schriftarten während der Präsentationsrenderung angewendet.

{{% alert color="primary" %}} 
Lesen Sie mehr darüber, wie man [Präsentation mit Fallback‑Schriftart rendern](/slides/de/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Werden meine Fallback-Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?**

Nein. Fallback-Regeln sind Laufzeit‑Render‑Einstellungen; sie werden nicht in die PPTX serialisiert und erscheinen nicht in der PowerPoint‑Benutzeroberfläche.

**Wird das Fallback auf Text in SmartArt, WordArt, Diagrammen und Tabellen angewendet?**

Ja. Der gleiche Glyph‑Substitutionsmechanismus wird für jeglichen Text in diesen Objekten verwendet.

**Stellt Aspose irgendwelche Schriftarten mit der Bibliothek bereit?**

Nein. Sie fügen Schriftarten selbst hinzu und nutzen sie auf eigene Verantwortung.

**Können Ersetzung/Substitution fehlender Schriftarten und Fallback für fehlende Glyphen gemeinsam verwendet werden?**

Ja. Sie sind unabhängige Stufen derselben Schriftart‑Auflösungs‑Pipeline: zuerst ermittelt die Engine die Verfügbarkeit von Schriftarten ([replacement](/slides/de/net/font-replacement/)/[substitution](/slides/de/net/font-substitution/)), dann füllt das Fallback Lücken für fehlende Glyphen in verfügbaren Schriftarten.