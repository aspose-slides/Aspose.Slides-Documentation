---
title: Schriften in Präsentationen mit Python einbetten
linktitle: Schriftart einbetten
type: docs
weight: 40
url: /de/python-net/embedded-font/
keywords:
- Schrift hinzufügen
- Schrift einbetten
- Schrift-Einbettung
- eingebettete Schrift abrufen
- eingebettete Schrift hinzufügen
- eingebettete Schrift entfernen
- eingebettete Schrift komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Betten Sie TrueType-Schriftarten in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python über .NET ein, um eine genaue Darstellung auf allen Plattformen sicherzustellen."
---

## **Übersicht**

**Einbetten von Schriftarten in PowerPoint** stellt sicher, dass Ihre Präsentation ihr beabsichtigtes Aussehen auf verschiedenen Systemen beibehält. Egal, ob Sie einzigartige Schriftarten für kreative Zwecke oder Standard‑Schriftarten verwenden, das Einbetten von Schriftarten verhindert Text‑ und Layout‑Störungen.

Wenn Sie eine Drittanbieter‑ oder nicht‑standardisierte Schriftart verwendet haben, weil Sie kreativ waren, haben Sie umso mehr Gründe, Ihre Schriftart einzubetten. Andernfalls (ohne eingebettete Schriftarten) können sich Texte oder Zahlen auf Ihren Folien, das Layout, Styling usw. ändern oder in verwirrende Rechtecke verwandeln.

Nutzen Sie die [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) und [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) Klassen, um eingebettete Schriftarten zu verwalten.

## **Eingebettete Schriftarten abrufen und entfernen**

Rufen Sie eingebettete Schriftarten ab oder entfernen Sie sie mühelos aus einer Präsentation mit den Methoden [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) und [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Dieser Python‑Code zeigt, wie Sie eingebettete Schriftarten aus einer Präsentation abrufen und entfernen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Rendern Sie die Folie, die einen Textrahmen enthält, der die eingebettete Schriftart 'FunSized' verwendet.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Alle eingebetteten Schriftarten abrufen.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Die Schriftart 'Calibri' finden.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Die Schriftart 'Calibri' entfernen.
    fonts_manager.remove_embedded_font(font_data)

    # Rendern Sie die Folie; die Schriftart 'Calibri' wird durch eine vorhandene ersetzt.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Speichern Sie die Präsentation ohne die eingebettete Schriftart 'Calibri' auf dem Datenträger.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Eingebettete Schriftarten hinzufügen**

Mit dem Enumerationswert [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) und zwei Überladungen der Methode [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/) können Sie die bevorzugte (Einbettungs‑)Regel auswählen, um die Schriftarten in einer Präsentation einzubetten. Dieser Python‑Code zeigt, wie Schriftarten in eine Präsentation eingebettet und hinzugefügt werden:

```python
import aspose.slides as slides

# Eine Präsentation laden.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Die Präsentation auf dem Datenträger speichern.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Eingebettete Schriftarten komprimieren**

Optimieren Sie die Dateigröße, indem Sie eingebettete Schriftarten mit [compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) komprimieren.

Beispielcode für die Kompression:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wie kann ich feststellen, dass eine bestimmte Schriftart in der Präsentation trotz Einbetten beim Rendern immer noch substituiert wird?**

Überprüfen Sie die [Substitutionsinformationen](/slides/de/python-net/font-substitution/) im Font‑Manager und die [Fallback‑/Substitutionsregeln](/slides/de/python-net/fallback-font/): Ist die Schriftart nicht verfügbar oder eingeschränkt, wird ein Fallback verwendet.

**Lohnt es sich, Systemschriftarten wie Arial/Calibri einzubetten?**

In der Regel nicht – sie sind fast immer verfügbar. Doch für volle Portabilität in „schlanken“ Umgebungen (Docker, ein Linux‑Server ohne vorinstallierte Schriftarten) kann das Einbetten von Systemschriftarten das Risiko unerwarteter Substitutionen beseitigen.