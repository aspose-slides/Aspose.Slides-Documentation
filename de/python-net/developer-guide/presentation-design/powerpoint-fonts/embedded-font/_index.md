---
title: Schriftarten in Präsentationen mit Python einbetten
linktitle: Schrift einbetten
type: docs
weight: 40
url: /de/python-net/embedded-font/
keywords:
- add font
- embed font
- font embedding
- get embedded font
- add embedded font
- remove embedded font
- compress embedded font
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "TrueType-Schriftarten in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Python via .NET einbetten, um eine korrekte Darstellung auf allen Plattformen sicherzustellen."
---

## **Übersicht**

**Das Einbetten von Schriftarten in PowerPoint** sorgt dafür, dass Ihre Präsentation ihr geplantes Aussehen auf verschiedenen Systemen beibehält. Egal, ob Sie kreative, einzigartige Schriftarten oder Standardschriftarten verwenden, das Einbetten von Schriftarten verhindert Text‑ und Layout‑Störungen.

Wenn Sie aufgrund kreativer Arbeit eine Drittanbieter‑ oder Nicht‑Standard‑Schriftart verwendet haben, haben Sie umso mehr Gründe, diese Schriftart einzubetten. Ohne eingebettete Schriftarten können Texte oder Zahlen auf Ihren Folien, das Layout, das Styling usw. sich ändern oder in verwirrende Rechtecke verwandeln.

Verwenden Sie die Klassen [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) und [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) zur Verwaltung eingebetteter Schriftarten.

## **Eingebettete Schriftarten abrufen und entfernen**

Rufen Sie eingebettete Schriftarten aus einer Präsentation ab oder entfernen Sie sie mühelos mit den Methoden [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) und [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Dieses Python‑Beispiel zeigt, wie Sie eingebettete Schriftarten aus einer Präsentation abrufen und entfernen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Render the slide containing a text frame that uses the embedded 'FunSized' font.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Get all embedded fonts.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Find the 'Calibri' font.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Remove the 'Calibri' font.
    fonts_manager.remove_embedded_font(font_data)

    # Render the slide; the 'Calibri' font will be replaced with an existing one.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Save the presentation without the embedded 'Calibri' font to disk.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Eingebettete Schriftarten hinzufügen**

Durch die Verwendung des Enums [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) und zweier Überladungen der Methode [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/) können Sie die gewünschte Einbettungsregel auswählen, um Schriftarten in einer Präsentation zu embedden. Dieses Python‑Beispiel zeigt, wie Schriftarten eingebettet und zu einer Präsentation hinzugefügt werden:

```python
import aspose.slides as slides

# Load a presentation.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Save the presentation to disk.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Eingebettete Schriftarten komprimieren**

Optimieren Sie die Dateigröße, indem Sie eingebettete Schriftarten mit [compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) komprimieren.

Beispielcode zur Kompression:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wie kann ich feststellen, dass eine bestimmte Schriftart in der Präsentation trotz Einbettung beim Rendern ersetzt wird?**

Prüfen Sie die [substitution information](/slides/de/python-net/font-substitution/) im Font‑Manager und die [fallback/substitution rules](/slides/de/python-net/fallback-font/): Wenn die Schriftart nicht verfügbar oder eingeschränkt ist, wird ein Fallback verwendet.

**Lohnt es sich, Systemschriftarten wie Arial/Calibri einzubetten?**

In der Regel nicht – sie sind fast immer verfügbar. In besonders schlanken Umgebungen (Docker, ein Linux‑Server ohne vorinstallierte Schriftarten) kann das Einbetten von Systemschriftarten jedoch das Risiko unerwarteter Ersetzungen ausschließen.