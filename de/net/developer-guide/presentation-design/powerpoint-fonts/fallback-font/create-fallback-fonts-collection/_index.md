---
title: Fallback-Schriftarten-Sammlung erstellen
type: docs
weight: 20
url: /de/net/create-fallback-fonts-collection/
keywords: "Fallback-Schriftarten-Sammlung, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides for .NET"
description: "Fallback-Schriftarten-Sammlung in PowerPoint in C# oder .NET"
---

## **Fallback-Regeln anwenden**

Instanzen der Klasse [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) können in [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) organisiert werden, die das [IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection) Interface implementiert. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Dann kann diese Sammlung der Eigenschaft [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) der Klasse [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager) zugewiesen werden. FontsManager steuert die Schriften in der gesamten Präsentation. Erfahren Sie mehr [Über FontsManager und FontsLoader](/slides/de/net/about-fontsmanager-and-fontsloader/).

Jede [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) hat eine [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager)‑Eigenschaft mit ihrer eigenen Instanz der FontsManager‑Klasse.

Hier ein Beispiel, wie man eine Sammlung von Fallback‑Schrift‑Regeln erstellt und sie dem FontsManager einer bestimmten Präsentation zuweist:  
```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```


Nachdem der FontsManager mit einer Fallback‑Schrift‑Sammlung initialisiert wurde, werden die Fallback‑Schriften während der Render­ung der Präsentation angewendet.

{{% alert color="primary" %}} 
Erfahren Sie mehr, wie man [Präsentation mit Fallback‑Schrift rendern](/slides/de/net/render-presentation-with-fallback-font/) verwendet.
{{% /alert %}}

## **FAQ**

**Werden meine Fallback‑Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?**

Nein. Fallback‑Regeln sind Laufzeit‑Render‑Einstellungen; sie werden nicht in die PPTX serialisiert und erscheinen nicht in der PowerPoint‑Benutzeroberfläche.

**Wird Fallback auf Text in SmartArt, WordArt, Diagrammen und Tabellen angewendet?**

Ja. Der gleiche Glyph‑Substitutions‑Mechanismus wird für jeglichen Text in diesen Objekten verwendet.

**Stellt Aspose irgendwelche Schriften mit der Bibliothek bereit?**

Nein. Sie fügen Schriften eigenständig hinzu und verwenden sie auf eigene Verantwortung.

**Können Ersatz/ Substitution für fehlende Schriften und Fallback für fehlende Glyphen zusammen verwendet werden?**

Ja. Sie sind unabhängige Phasen derselben Schrift‑Auflösungs‑Pipeline: zuerst löst die Engine die Verfügbarkeit von Schriften ([replacement](/slides/de/net/font-replacement/)/[substitution](/slides/de/net/font-substitution/)), dann füllt Fallback fehlende Glyphen in verfügbaren Schriften.