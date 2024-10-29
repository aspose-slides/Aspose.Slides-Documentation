---
title: Eingebettete Schriftart
type: docs
weight: 40
url: /de/python-net/embedded-font/
keywords: "Schriftarten, eingebettete Schriftarten, Schriftarten hinzufügen, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Verwenden Sie eingebettete Schriftarten in PowerPoint-Präsentationen in Python"
---

**Eingebettete Schriftarten in PowerPoint** sind nützlich, wenn Sie möchten, dass Ihre Präsentation korrekt angezeigt wird, wenn sie auf einem beliebigen System oder Gerät geöffnet wird. Wenn Sie eine Schriftart eines Drittanbieters oder eine nicht standardmäßige Schriftart verwendet haben, weil Sie kreativ mit Ihrer Arbeit waren, haben Sie noch mehr Gründe, Ihre Schriftart einzubetten. Andernfalls (ohne eingebettete Schriftarten) können sich die Texte oder Zahlen auf Ihren Folien, das Layout, die Gestaltung usw. ändern oder in verwirrende Rechtecke umwandeln.

Die Klasse [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/), die Klasse [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/), die Klasse [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) und deren Schnittstellen enthalten die meisten Eigenschaften und Methoden, die Sie benötigen, um mit eingebetteten Schriftarten in PowerPoint-Präsentationen zu arbeiten.

## **Eingebettete Schriftarten aus der Präsentation abrufen oder entfernen**

Aspose.Slides bietet die Methode `get_embedded_fonts()` (bereitgestellt von der Klasse [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)), um Ihnen zu ermöglichen, die in einer Präsentation eingebetteten Schriftarten abzurufen (oder herauszufinden). Um Schriftarten zu entfernen, wird die Methode `remove_embedded_font(font_data)` (bereitgestellt von derselben Klasse) verwendet.

Dieser Python-Code zeigt Ihnen, wie Sie eingebettete Schriftarten aus einer Präsentation abrufen und entfernen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellt ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
with slides.Presentation(path + "EmbeddedFonts.pptx") as presentation:
    # Rendert eine Folie mit einem Textfeld, das die eingebettete Schriftart "FunSized" verwendet
    with presentation.slides[0].get_image(draw.Size(960, 720)) as img:
        img.save("picture1_out.png", slides.ImageFormat.PNG)

    fontsManager = presentation.fonts_manager

    # Ruft alle eingebetteten Schriftarten ab
    embeddedFonts = fontsManager.get_embedded_fonts()

    # Findet die Schriftart "Calibri"
    
    funSizedEmbeddedFont = list(filter(lambda data : data.font_name == "Calibri", embeddedFonts))[0]

    # Entfernt die Schriftart "Calibri"
    fontsManager.remove_embedded_font(funSizedEmbeddedFont)

    # Rendert die Präsentation; die Schriftart "Calibri" wird durch eine vorhandene ersetzt
    with presentation.slides[0].get_image(draw.Size(960, 720)) as img:
        img.save("picture2_out.png", slides.ImageFormat.PNG)

    # Speichert die Präsentation ohne die eingebettete Schriftart "Calibri" auf der Festplatte
    presentation.save("WithoutManageEmbeddedFonts_out.ppt", slides.export.SaveFormat.PPT)
```

## **Eingebettete Schriftarten zur Präsentation hinzufügen**

Mit dem Enum [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) und zwei Überladungen der Methode `add_embedded_font(font_data, embed_font_rule)` können Sie Ihre bevorzugte (Einbettungs-) Regel auswählen, um die Schriftarten in einer Präsentation einzubetten. Dieser Python-Code zeigt Ihnen, wie Sie Schriftarten in einer Präsentation einbetten und hinzufügen:

```python
import aspose.slides as slides

# Lädt die Präsentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Lädt die zu ersetzende Quellschriftart
    sourceFont = slides.FontData("Arial")

    allFonts = presentation.fonts_manager.get_fonts()
    embeddedFonts = presentation.fonts_manager.get_embedded_fonts()
    for font in allFonts:
        if font not in embeddedFonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Speichert die Präsentation auf der Festplatte
    presentation.save("AddEmbeddedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Eingebettete Schriftarten komprimieren**

Um Ihnen zu ermöglichen, die in einer Präsentation eingebetteten Schriftarten zu komprimieren und die Dateigröße zu reduzieren, bietet Aspose.Slides die Methode `compress_embedded_fonts` (bereitgestellt von der Klasse [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)).

Dieser Python-Code zeigt Ihnen, wie Sie eingebettete PowerPoint-Schriftarten komprimieren:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:

    slides.lowcode.Compress.compress_embedded_fonts(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```