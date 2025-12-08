---
title: Einbetten von Schriften in Präsentationen mit Python
linktitle: Schrift einbetten
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
description: "Einbetten von TrueType-Schriften in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET, um eine genaue Darstellung auf allen Plattformen zu gewährleisten."
---

## **Übersicht**

**Das Einbetten von Schriften in PowerPoint** sorgt dafür, dass Ihre Präsentation ihr beabsichtigtes Aussehen auf verschiedenen Systemen beibehält. Unabhängig davon, ob Sie einzigartige Schriften für kreative Zwecke oder Standard‑Schriften verwenden, verhindert das Einbetten von Schriften Text‑ und Layout‑Störungen.

Wenn Sie aus kreativen Gründen eine Drittanbieter‑ oder nicht standardmäßige Schriftart verwendet haben, haben Sie umso mehr Gründe, diese Schriftart einzubetten. Andernfalls (ohne eingebettete Schriften) können Texte oder Zahlen auf Ihren Folien, das Layout, das Styling usw. sich ändern oder in verwirrende Rechtecke umgewandelt werden.

Verwenden Sie die Klassen [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) und [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) , um eingebettete Schriften zu verwalten.

## **Abrufen und Entfernen eingebetteter Schriften**

Rufen Sie eingebettete Schriften aus einer Präsentation ab oder entfernen Sie sie mühelos mit den Methoden [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) und [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Dieser Python‑Code zeigt, wie man eingebettete Schriften aus einer Präsentation abruft und entfernt:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren der Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Rendere die Folie, die einen Textrahmen enthält, der die eingebettete Schrift 'FunSized' verwendet.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Alle eingebetteten Schriften abrufen.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Die Schrift 'Calibri' finden.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Die Schrift 'Calibri' entfernen.
    fonts_manager.remove_embedded_font(font_data)

    # Rendere die Folie; die Schrift 'Calibri' wird durch eine vorhandene ersetzt.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Speichere die Präsentation ohne die eingebettete Schrift 'Calibri' auf die Festplatte.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```


## **Hinzufügen eingebetteter Schriften**

Mit dem Enum [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) und zwei Überladungen der Methode [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/) können Sie Ihre bevorzugte (Einbettungs‑)Regel auswählen, um Schriften in einer Präsentation einzubetten. Dieser Python‑Code zeigt, wie man Schriften in eine Präsentation einbettet und hinzufügt:
```python
import aspose.slides as slides

# Präsentation laden.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Präsentation auf die Festplatte speichern.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```


## **Komprimieren eingebetteter Schriften**

Optimieren Sie die Dateigröße, indem Sie eingebettete Schriften mit [compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) komprimieren.

Beispielcode für die Komprimierung:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Wie kann ich erkennen, dass eine bestimmte Schriftart in der Präsentation trotz Einbettung beim Rendern noch ersetzt wird?**

Prüfen Sie die [substitution information](/slides/de/python-net/font-substitution/) im Font‑Manager und die [fallback/substitution rules](/slides/de/python-net/fallback-font/): Ist die Schriftart nicht verfügbar oder eingeschränkt, wird ein Ersatz verwendet.

**Lohnt es sich, Systemschriften wie Arial/Calibri einzubetten?**

In der Regel nein — sie sind fast immer verfügbar. Aber für vollständige Portabilität in „dünnen“ Umgebungen (Docker, ein Linux‑Server ohne vorinstallierte Schriften) kann das Einbetten von Systemschriften das Risiko unerwarteter Ersetzungen eliminieren.