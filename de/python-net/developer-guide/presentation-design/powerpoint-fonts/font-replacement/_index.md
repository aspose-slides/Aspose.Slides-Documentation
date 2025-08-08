---
title: Schriftartenersetzung in Präsentationen mit Python vereinfachen
linktitle: Schriftartenersetzung
type: docs
weight: 60
url: /de/python-net/font-replacement/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftartenersetzung
- Schriftart ändern
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Schriftarten nahtlos in Aspose.Slides for Python via .NET ersetzen, um eine konsistente Typografie in PowerPoint- und OpenDocument-Präsentationen sicherzustellen."
---

Wenn Sie Ihre Meinung über die Verwendung einer Schriftart ändern, können Sie diese Schriftart durch eine andere ersetzen. Alle Instanzen der alten Schriftart werden durch die neue Schriftart ersetzt.

Aspose.Slides ermöglicht es, eine Schriftart auf diese Weise zu ersetzen:

1. Laden Sie die relevante Präsentation.
2. Laden Sie die zu ersetzende Schriftart.
3. Laden Sie die neue Schriftart.
4. Ersetzen Sie die Schriftart.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code demonstriert den Schriftartwechsel:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Lädt eine Präsentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Lädt die Quellschriftart, die ersetzt werden soll
    sourceFont = slides.FontData("Arial")

    # Lädt die neue Schriftart
    destFont = slides.FontData("Times New Roman")

    # Ersetzt die Schriftarten
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Speichert die Präsentation
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Hinweis" color="warning" %}} 

Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen passiert (wenn eine Schriftart nicht zugegriffen werden kann, zum Beispiel), siehe [**Schriftartsubstitution**](/slides/de/python-net/font-substitution/). 

{{% /alert %}}