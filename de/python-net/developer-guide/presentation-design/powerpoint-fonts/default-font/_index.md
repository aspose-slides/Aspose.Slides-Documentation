---
title: Standard-Schriftarten in Präsentationen mit Python anpassen
linktitle: Standardschriftart
type: docs
weight: 30
url: /de/python-net/default-font/
keywords:
- Standardschriftart
- Reguläre Schriftart
- Normale Schriftart
- Asiatische Schriftart
- PDF-Export
- XPS-Export
- Bildexport
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Legen Sie Standardschriftarten in Aspose.Slides for Python fest, um eine korrekte Konvertierung von PowerPoint (PPT, PPTX) und OpenDocument (ODP) in PDF, XPS und Bilder sicherzustellen."
---

## **Verwendung von Standard-Schriftarten für das Rendern von Präsentationen**
Aspose.Slides ermöglicht es Ihnen, die Standard-Schriftart für das Rendern der Präsentation in PDF, XPS oder Thumbnails festzulegen. Dieser Artikel zeigt, wie Sie DefaultRegular Font und DefaultAsian Font als Standard-Schriftarten definieren können. Bitte folgen Sie den untenstehenden Schritten, um Schriftarten aus externen Verzeichnissen mithilfe der Aspose.Slides für Python über .NET API zu laden:

1. Erstellen Sie eine Instanz von LoadOptions.
1. Setzen Sie die DefaultRegularFont auf die gewünschte Schriftart. Im folgenden Beispiel habe ich Wingdings verwendet.
1. Setzen Sie die DefaultAsianFont auf die gewünschte Schriftart. Ich habe im folgenden Beispiel Wingdings verwendet.
1. Laden Sie die Präsentation mit Presentation und setzen Sie die Ladeoptionen.
1. Generieren Sie nun das Folien-Thumbnil, PDF und XPS, um die Ergebnisse zu überprüfen.

Die Implementierung des obigen ist unten angegeben.

```py
import aspose.slides as slides

# Verwenden Sie Ladeoptionen, um die Standard-Schriftarten für Regular und Asian zu definieren
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Präsentation laden
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Folien-Thumbnails generieren
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # PDF generieren
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # XPS generieren
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```