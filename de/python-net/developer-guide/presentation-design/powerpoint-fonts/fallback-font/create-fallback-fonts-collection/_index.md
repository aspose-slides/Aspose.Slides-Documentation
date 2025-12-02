---
title: Fallback-Schriftartensammlungen in Python konfigurieren
linktitle: Fallback-Schriftartsammlung
type: docs
weight: 20
url: /de/python-net/create-fallback-fonts-collection/
keywords:
- Fallback-Schriftart
- Fallback-Regel
- Schriftartsammlung
- Schriftart konfigurieren
- Schriftart einrichten
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Richten Sie eine Fallback-Schriftartsammlung in Aspose.Slides für Python über .NET ein, um Text in PowerPoint- und OpenDocument-Präsentationen konsistent und klar darzustellen."
---

## **Fallback-Regeln anwenden**

Instanzen der Klasse [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) können in eine [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) organisiert werden, die das Interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/) implementiert. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Dann kann diese Sammlung der Eigenschaft [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) der Klasse [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) zugewiesen werden. FontsManager steuert die Schriftarten in der gesamten Präsentation. Mehr dazu [Über FontsManager und FontsLoader](/slides/de/python-net/about-fontsmanager-and-fontsloader/).

Jede [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) hat eine [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Eigenschaft mit einer eigenen Instanz der FontsManager‑Klasse.

Hier ist ein Beispiel, wie man eine Sammlung von Fallback‑Schriftartenregeln erstellt und sie dem FontsManager einer bestimmten Präsentation zuweist:  
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


Nachdem FontsManager mit der Fallback‑Schriftartensammlung initialisiert wurde, werden die Fallback‑Schriftarten während der Präsentationsrendierung angewendet.

{{% alert color="primary" %}} 
Erfahren Sie mehr, wie man [Präsentation mit Fallback‑Schriftart rendern](/slides/de/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Werden meine Fallback‑Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?**

Nein. Fallback‑Regeln sind Laufzeit‑Render‑Einstellungen; sie werden nicht in die PPTX serialisiert und erscheinen nicht in der PowerPoint‑Benutzeroberfläche.

**Wird Fallback auf Text in SmartArt, WordArt, Diagrammen und Tabellen angewendet?**

Ja. Der gleiche Glyph‑Substitutionsmechanismus wird für jeglichen Text in diesen Objekten verwendet.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Sie fügen Schriftarten selbst hinzu und verwenden sie eigenverantwortlich.

**Können Ersatz/Substitution für fehlende Schriftarten und Fallback für fehlende Glyphen zusammen verwendet werden?**

Ja. Sie sind unabhängige Stufen derselben Schriftarten‑Auflösungspipeline: Zuerst löst die Engine die Verfügbarkeit von Schriftarten ([replacement](/slides/de/python-net/font-replacement/)/[substitution](/slides/de/python-net/font-substitution/)) auf, anschließend füllt Fallback Lücken für fehlende Glyphen in verfügbaren Schriftarten.