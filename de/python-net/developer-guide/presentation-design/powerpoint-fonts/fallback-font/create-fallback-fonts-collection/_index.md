---
title: Erstellen einer Fallback-Schriftarten-Sammlung
type: docs
weight: 20
url: /de/python-net/create-fallback-fonts-collection/
keywords: "Fallback-Schriftarten-Sammlung, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Fallback-Schriftarten-Sammlung in PowerPoint in Python"
---

Instanzen der [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) Klasse können in der [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) organisiert werden, die das [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/) Interface implementiert. Es ist möglich, Regeln von der Sammlung hinzuzufügen oder zu entfernen.

Dann kann diese Sammlung der [FontFallBackRulesCollection ](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)Eigenschaft der [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) Klasse zugewiesen werden. FontsManager steuert die Schriftarten der Präsentation. Erfahren Sie mehr [Über FontsManager und FontsLoader](/slides/de/python-net/about-fontsmanager-and-fontsloader/).

Jede [Präsentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)hat eine [FontsManager ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)Eigenschaft mit ihrer eigenen Instanz der FontsManager-Klasse.

Hier ist ein Beispiel, wie man eine Sammlung von Fallback-Schriftartenregeln erstellt und sie dem FontsManager einer bestimmten Präsentation zuweist:  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

Nachdem der FontsManager mit der Fallback-Schriftartensammlung initialisiert wurde, werden die Fallback-Schriftarten während der Präsentationsdarstellung angewendet.

{{% alert color="primary" %}} 
Erfahren Sie mehr darüber, wie man eine [Präsentation mit Fallback-Schriftart rendern](/slides/de/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}