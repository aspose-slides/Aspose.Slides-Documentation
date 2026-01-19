---
title: Fallback‑Schriftartsammlungen in Python konfigurieren
linktitle: Fallback‑Schriftartsammlung
type: docs
weight: 20
url: /de/python-net/create-fallback-fonts-collection/
keywords:
- Fallback‑Schriftart
- Fallback‑Regel
- Schriftartsammlung
- Schriftart konfigurieren
- Schriftart einrichten
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Richten Sie eine Fallback‑Schriftartsammlung in Aspose.Slides für Python via .NET ein, um Text in PowerPoint‑ und OpenDocument‑Präsentationen konsistent und scharf darzustellen."
---

## **Fallback-Regeln anwenden**

Instanzen der [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) Klasse können in [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) organisiert werden. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Dann kann diese Sammlung der Eigenschaft [font_fall_back_rules_collection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) der [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) Klasse zugewiesen werden. FontsManager steuert die Schriftarten in der gesamten Präsentation.

Jede [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) hat eine [fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) Eigenschaft mit ihrer eigenen Instanz der FontsManager‑Klasse.

Hier ist ein Beispiel, wie man eine Sammlung von Fallback‑Schriftarten‑Regeln erstellt und sie dem FontsManager einer bestimmten Präsentation zuweist:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    userRulesList = slides.FontFallBackRulesCollection()

    userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
    userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

    presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


Nachdem der FontsManager mit einer Fallback‑Schriftarten‑Sammlung initialisiert wurde, werden die Fallback‑Schriftarten während der Rendering‑Phase der Präsentation angewendet.

{{% alert color="primary" %}} 
Lesen Sie mehr darüber, wie Sie [Präsentation mit Fallback‑Schriftart rendern](/slides/de/python-net/render-presentation-with-fallback-font/) rendern.
{{% /alert %}}

## **FAQ**

**Werden meine Fallback‑Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?**

Nein. Fallback‑Regeln sind Laufzeit‑Rendering‑Einstellungen; sie werden nicht in die PPTX‑Datei serialisiert und erscheinen nicht in der PowerPoint‑Benutzeroberfläche.

**Wird Fallback auf Text in SmartArt, WordArt, Diagrammen und Tabellen angewendet?**

Ja. Der gleiche Glyph‑Substitutions‑Mechanismus wird für jeden Text in diesen Objekten verwendet.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Sie fügen Schriftarten selbst hinzu und verwenden sie auf eigene Verantwortung.

**Können Ersatz/Substitution für fehlende Schriftarten und Fallback für fehlende Glyphen zusammen verwendet werden?**

Ja. Sie sind unabhängige Stufen derselben Schriftart‑Auflösungs‑Pipeline: Zuerst ermittelt die Engine die Verfügbarkeit von Schriftarten ([replacement](/slides/de/python-net/font-replacement/)/[substitution](/slides/de/python-net/font-substitution/)), dann füllt Fallback Lücken für fehlende Glyphen in verfügbaren Schriftarten.