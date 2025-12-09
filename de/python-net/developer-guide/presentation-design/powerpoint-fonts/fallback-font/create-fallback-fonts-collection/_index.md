---
title: Fallback-Schriftarten in Python konfigurieren
linktitle: Fallback-Schriftarten konfigurieren
type: docs
weight: 20
url: /de/python-net/create-fallback-fonts-collection/
keywords:
- Fallback-Schriftart
- Fallback-Regel
- Schriftartensammlung
- Schriftart konfigurieren
- Schriftart einrichten
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Einrichten einer Fallback-Schriftartensammlung in Aspose.Slides für Python via .NET, um Text in PowerPoint- und OpenDocument-Präsentationen konsistent und klar darzustellen."
---

## **Fallback-Regeln anwenden**

Instanzen der [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) Klasse können in einer [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) organisiert werden, die das [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/) Interface implementiert. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Dann kann diese Sammlung der [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) Eigenschaft der [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) Klasse zugewiesen werden. FontsManager steuert die Schriftarten in der gesamten Präsentation. Mehr dazu siehe [Über FontsManager und FontsLoader](/slides/de/python-net/about-fontsmanager-and-fontsloader/)​.

Jede [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) verfügt über eine [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Eigenschaft mit ihrer eigenen Instanz der Klasse FontsManager.

Hier ist ein Beispiel, wie man eine Sammlung von Fallback‑Schriftartregeln erstellt und sie dem FontsManager einer bestimmten Präsentation zuweist:  
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


Nachdem FontsManager mit der Fallback‑Schriftartsammlung initialisiert wurde, werden die Fallback‑Schriftarten während der Rendering der Präsentation angewendet.

{{% alert color="primary" %}} 
Mehr dazu, wie man eine [Präsentation mit Fallback‑Schriftart rendert](/slides/de/python-net/render-presentation-with-fallback-font/)​.
{{% /alert %}}

## **FAQ**

**Werden meine Fallback‑Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?**

Nein. Fallback‑Regeln sind Runtime‑Rendering‑Einstellungen; sie werden nicht in die PPTX serialisiert und erscheinen nicht in der PowerPoint‑Benutzeroberfläche.

**Wird Fallback auf Text in SmartArt, WordArt, Diagrammen und Tabellen angewendet?**

Ja. Der gleiche Glyph‑Substitutions‑Mechanismus wird für jeden Text in diesen Objekten verwendet.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Sie fügen Schriftarten selbst hinzu und verwenden sie auf eigene Verantwortung.

**Können Ersatz/Substitution fehlender Schriftarten und Fallback für fehlende Glyphen zusammen verwendet werden?**

Ja. Sie sind unabhängige Stufen derselben Font‑Auflösungspipeline: zuerst ermittelt die Engine die Verfügbarkeit von Schriftarten (Ersatz/Substitution), dann füllt Fallback Lücken für fehlende Glyphen in verfügbaren Schriftarten.