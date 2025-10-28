---
title: Schriftarten in Präsentationen mit Python einbetten
linktitle: Schriftart einbetten
type: docs
weight: 40
url: /de/python-net/embedded-font/
keywords:
- Schriftart hinzufügen
- Schriftart einbetten
- Schriftart-Einbettung
- eingebettete Schriftart abrufen
- eingebettete Schriftart hinzufügen
- eingebettete Schriftart entfernen
- eingebettete Schriftart komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "TrueType‑Schriftarten in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Python via .NET einbetten und damit eine genaue Darstellung auf allen Plattformen sicherstellen."
---

## **Übersicht**

**Schriftarten in PowerPoint einbetten** stellt sicher, dass Ihre Präsentation auf verschiedenen Systemen ihr gewünschtes Erscheinungsbild behält. Egal, ob Sie einzigartige Schriftarten zur kreativen Gestaltung oder Standard‑Schriftarten verwenden, das Einbetten verhindert Text‑ und Layout‑Störungen.

Wenn Sie eine Drittanbieter‑ oder nicht‑standardmäßige Schriftart verwendet haben, weil Sie kreativ waren, haben Sie noch mehr Gründe, Ihre Schriftart einzubetten. Ohne eingebettete Schriftarten können Texte oder Zahlen auf Ihren Folien, das Layout, die Formatierung usw. sich ändern oder in verwirrende Rechtecke verwandeln.

Verwenden Sie die Klassen [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) und [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) zur Verwaltung eingebetteter Schriftarten.

## **Eingebettete Schriftarten abrufen und entfernen**

Rufen Sie eingebettete Schriftarten aus einer Präsentation ab oder entfernen Sie sie mühelos mit den Methoden [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) und [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Der folgende Python‑Code zeigt, wie Sie eingebettete Schriftarten aus einer Präsentation abrufen und entfernen:

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

Mit dem Enum [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) und zwei Überladungen der Methode [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/) können Sie die gewünschte (Einbettungs‑)Regel auswählen, um Schriftarten in einer Präsentation einzubetten. Der folgende Python‑Code zeigt, wie Sie Schriftarten einbetten und einer Präsentation hinzufügen:

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

Beispielcode für die Komprimierung:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wie kann ich feststellen, dass eine bestimmte Schriftart in der Präsentation trotz Einbettung beim Rendern noch substituiert wird?**

Prüfen Sie die [Substitutions‑Information](/slides/de/python-net/font-substitution/) im Font‑Manager und die [Fallback‑/Substitutions‑Regeln](/slides/de/python-net/fallback-font/): Wenn die Schriftart nicht verfügbar oder eingeschränkt ist, wird ein Fallback verwendet.

**Lohnt es sich, „System“-Schriftarten wie Arial/Calibri einzubetten?**

In der Regel nein – sie sind fast immer verfügbar. Aber für volle Portabilität in „dünnen“ Umgebungen (Docker, ein Linux‑Server ohne vorinstallierte Schriftarten) kann das Einbetten von System‑Schriftarten das Risiko unerwarteter Substitutionen ausschließen.