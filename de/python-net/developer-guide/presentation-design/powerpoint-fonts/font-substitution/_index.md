---
title: Schriftartersetzung
type: docs
weight: 70
url: /python-net/font-substitution/
keywords: "Schriftart, Ersatzschriftart, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Schriftart in PowerPoint in Python ersetzen"
---

Aspose.Slides ermöglicht es Ihnen, Regeln für Schriftarten festzulegen, die bestimmen, was unter bestimmten Bedingungen getan werden muss (zum Beispiel, wenn eine Schriftart nicht zugänglich ist) auf folgende Weise:

1. Laden Sie die relevante Präsentation.
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart.
4. Fügen Sie eine Regel für den Ersatz hinzu.
5. Fügen Sie die Regel zur Regelkollektion für Schriftart-Ersatz der Präsentation hinzu.
6. Generieren Sie das Folienbild, um den Effekt zu beobachten.

Dieser Python-Code demonstriert den Schriftartersetzungsprozess:

```python
import aspose.slides as slides

# Lädt eine Präsentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Lädt die Quellschriftart, die ersetzt werden soll
    sourceFont = slides.FontData("SomeRareFont")

    # Lädt die neue Schriftart
    destFont = slides.FontData("Arial")

    # Fügt eine Schriftartregel für den Schriftartersatz hinzu
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Fügt die Regel zur Sammlung der Ersatzschriftartregeln hinzu
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Fügt die Schriftartregelsammlung zur Regel liste hinzu
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    # Die Arial-Schriftart wird anstelle von SomeRareFont verwendet, wenn Letztere nicht zugänglich ist
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Speichert das Bild im JPEG-Format auf der Festplatte
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="HINWEIS"  color="warning"   %}} 

Vielleicht möchten Sie [**Schriftart ersetzen**](/slides/python-net/font-replacement/). 

{{% /alert %}}