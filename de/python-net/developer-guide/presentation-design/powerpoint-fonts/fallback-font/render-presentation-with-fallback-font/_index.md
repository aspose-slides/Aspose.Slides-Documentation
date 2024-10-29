---
title: Präsentation mit Fallback-Schriftart rendern
type: docs
weight: 30
url: /de/python-net/render-presentation-with-fallback-font/
keywords: "Fallback-Schriftart, PowerPoint rendern, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Rendern von PowerPoint mit Fallback-Schriftart in Python"
---

Das folgende Beispiel umfasst diese Schritte:

1. Wir [erstellen eine Sammlung von Fallback-Schriftartregeln](/slides/de/python-net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) eine Fallback-Schriftartregel entfernen und [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) zu einer anderen Regel hinzufügen.
1. Setzen Sie die Regelauffassung auf die [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) Eigenschaft.
1. Mit der [Presentation.Save()](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Methode können wir die Präsentation im gleichen Format speichern oder in ein anderes speichern. Nachdem die Fallback-Schriftartregeln Sammlung auf FontsManager gesetzt wurde, werden diese Regeln während aller Operationen an der Präsentation angewendet: speichern, rendern, konvertieren usw.

```py
import aspose.slides as slides

# Neue Instanz einer Regelnammlung erstellen
rulesList = slides.FontFallBackRulesCollection()

# eine Anzahl von Regeln erstellen
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# Versuch, die Fallback-Schriftart "Tahoma" aus geladenen Regeln zu entfernen
	fallBackRule.remove("Tahoma")

	# Und die Regeln für den angegebenen Bereich zu aktualisieren
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# Auch können wir vorhandene Regeln aus der Liste entfernen
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# Zuordnen einer vorbereiteten Regel-Liste zur Verwendung
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Rendern eines Thumbnails mit Verwendung der initialisierten Regelsammlung und Speichern als PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
Erfahren Sie mehr über [Speichern und Konvertieren in Präsentationen](/slides/de/python-net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}