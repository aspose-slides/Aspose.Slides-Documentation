---
title: "Fallback-Schriftartensammlungen in Python konfigurieren"
linktitle: "Fallback-Schriftartensammlung"
type: docs
weight: 20
url: /de/python-net/create-fallback-fonts-collection/
keywords:
- "Fallback-Schriftart"
- "Fallback-Regel"
- "Schriftartensammlung"
- "Schriftart konfigurieren"
- "Schriftart einrichten"
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Richten Sie eine Sammlung von Fallback-Schriftarten in Aspose.Slides für Python via .NET ein, um Text in PowerPoint- und OpenDocument-Präsentationen konsistent und scharf darzustellen."
---

## **Fallback-Regeln anwenden**

Instanzen der Klasse [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) können in [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) organisiert werden, die das [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/) Interface implementiert. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Dann kann diese Sammlung der Eigenschaft [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) der Klasse [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) zugewiesen werden. FontsManager steuert die Schriften über die gesamte Präsentation. Mehr erfahren [Über FontsManager und FontsLoader](/slides/de/python-net/about-fontsmanager-and-fontsloader/).

Jede [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) hat eine [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Eigenschaft mit ihrer eigenen Instanz der FontsManager‑Klasse.

Hier ein Beispiel, wie man eine Sammlung von Fallback‑Schriftartenregeln erstellt und sie dem FontsManager einer bestimmten Präsentation zuweist:  
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


Nachdem der FontsManager mit einer Fallback‑Schriftartensammlung initialisiert wurde, werden die Fallback‑Schriften während der Präsentationsrenderung angewendet.

{{% alert color="primary" %}} 
Mehr erfahren, wie man [Präsentation mit Fallback‑Schrift rendern](/slides/de/python-net/render-presentation-with-fallback-font/) kann. 
{{% /alert %}}

## **FAQ**

**Werden meine Fallback‑Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?**

Nein. Fallback‑Regeln sind Laufzeit‑Render‑Einstellungen; sie werden nicht in die PPTX‑Datei serialisiert und erscheinen nicht in der Benutzeroberfläche von PowerPoint.

**Gilt Fallback für Text in SmartArt, WordArt, Diagrammen und Tabellen?**

Ja. Der gleiche Glyph‑Substitutions‑Mechanismus wird für jeden Text in diesen Objekten verwendet.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Sie fügen Schriftarten selbst hinzu und verwenden sie auf eigene Verantwortung.

**Können Ersatz‑/Substitution für fehlende Schriftarten und Fallback für fehlende Glyphen zusammen verwendet werden?**

Ja. Sie sind unabhängige Schritte derselben Schriftauflösungs‑Pipeline: Zuerst löst die Engine die Verfügbarkeit von Schriftarten ([Ersatz](/slides/de/python-net/font-replacement/)/[Substitution](/slides/de/python-net/font-substitution/)) auf, dann füllt Fallback Lücken für fehlende Glyphen in verfügbaren Schriften.