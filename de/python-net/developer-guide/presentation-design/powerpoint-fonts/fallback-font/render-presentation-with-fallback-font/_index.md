---
title: Präsentationen mit Fallback-Schriftarten in Python rendern
linktitle: Präsentationen rendern
type: docs
weight: 30
url: /de/python-net/render-presentation-with-fallback-font/
keywords:
- Fallback-Schriftart
- PowerPoint rendern
- Präsentation rendern
- Folie rendern
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Präsentationen mit Fallback-Schriftarten in Aspose.Slides für Python über .NET rendern - Text über PPT, PPTX und ODP hinweg konsistent halten mit schrittweisen Codebeispielen."
---

Das folgende Beispiel enthält diese Schritte:

1. Wir [create fallback font rules collection](/slides/de/python-net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) eine Fallback-Schriftartregel und [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) zu einer anderen Regel.
1. Setzen Sie die Regelsammlung auf die [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) Eigenschaft.
1. Mit [Presentation.Save()](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Methode können wir die Präsentation im selben Format speichern oder in ein anderes Format konvertieren. Nachdem die Fallback-Schriftartregelsammlung dem FontsManager zugewiesen wurde, werden diese Regeln bei allen Vorgängen mit der Präsentation angewendet: Speichern, Rendern, Konvertieren usw.
```py
import aspose.slides as slides

# Neue Instanz einer Regel-Sammlung erstellen
rulesList = slides.FontFallBackRulesCollection()

# Eine Anzahl von Regeln erstellen
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# Versucht, die Fallback-Schriftart "Tahoma" aus den geladenen Regeln zu entfernen
	fallBackRule.remove("Tahoma")

	# Und die Regeln für den angegebenen Bereich aktualisieren
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# Wir können auch vorhandene Regeln aus der Liste entfernen
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# Zuweisen einer vorbereiteten Regel-Liste zur Verwendung
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Rendern eines Thumbnails unter Verwendung der initialisierten Regel-Sammlung und Speichern als PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```


{{% alert color="primary" %}} 
Lesen Sie mehr darüber, wie Sie [Convert PowerPoint Slides to PNG in Python](/slides/de/python-net/convert-powerpoint-to-png/) können.
{{% /alert %}}