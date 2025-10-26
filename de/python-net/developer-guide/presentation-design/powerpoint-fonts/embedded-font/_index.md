---
title: Schriften in Präsentationen mit Python einbetten
linktitle: Schrift einbetten
type: docs
weight: 40
url: /de/python-net/developer-guide/presentation-design/powerpoint-fonts/embedded-font/
keywords:
- Schrift hinzufügen
- Schrift einbetten
- Schrifteinbettung
- eingebettete Schrift abrufen
- eingebettete Schrift hinzufügen
- eingebettete Schrift entfernen
- eingebettete Schrift komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "TrueType-Schriften in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET einbetten, um eine genaue Darstellung auf allen Plattformen zu gewährleisten."
---

## **Überblick**

Das Einbetten von Schriften in PowerPoint stellt sicher, dass Ihre Präsentation auf verschiedenen Systemen ihr beabsichtigtes Erscheinungsbild beibehält. Egal, ob Sie einzigartige Schriften für Kreativität oder Standardschriften verwenden, das Einbetten verhindert Text- und Layoutstörungen.

Wenn Sie eine Drittanbieter‑ oder nicht‑standardisierte Schrift verwendet haben, weil Sie kreativ waren, haben Sie noch mehr Gründe, Ihre Schrift einzubetten. Andernfalls (ohne eingebettete Schriften) können Texte oder Zahlen auf Ihren Folien, das Layout, das Styling usw. sich ändern oder in verwirrende Rechtecke verwandeln.

Verwenden Sie die Klassen [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) und [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) zur Verwaltung eingebetteter Schriften.

## **Abrufen und Entfernen eingebetteter Schriften**

Rufen Sie eingebettete Schriften aus einer Präsentation ab oder entfernen Sie sie mühelos mit den Methoden [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) und [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Dieser Python‑Code zeigt, wie Sie eingebettete Schriften aus einer Präsentation abrufen und entfernen:

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

## **Eingebettete Schriften hinzufügen**

Mit dem Aufzählungstyp [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) und zwei Überladungen der Methode [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/) können Sie die gewünschte Einbettungsregel auswählen, um Schriften in einer Präsentation einzubetten. Dieser Python‑Code zeigt, wie Sie Schriften einbetten und hinzufügen:

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

## **Eingebettete Schriften komprimieren**

Optimieren Sie die Dateigröße, indem Sie eingebettete Schriften mit [compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) komprimieren.

Beispielcode für die Komprimierung:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wie kann ich erkennen, dass eine bestimmte Schrift in der Präsentation beim Rendern trotz Einbettung noch substituiert wird?**

Überprüfen Sie die [Substitutionsinformationen](/slides/de/python-net/font-substitution/) im Font‑Manager und die [Fallback‑/Substitutionsregeln](/slides/de/python-net/fallback-font/): Wenn die Schrift nicht verfügbar oder eingeschränkt ist, wird ein Ersatz verwendet.

**Lohnt es sich, Systemschriften wie Arial/Calibri einzubetten?**

In der Regel nicht – sie sind fast immer verfügbar. Für volle Portabilität in „dünnen“ Umgebungen (Docker, ein Linux‑Server ohne vorinstallierte Schriften) kann das Einbetten von Systemschriften jedoch das Risiko unerwarteter Substitutionen eliminieren.