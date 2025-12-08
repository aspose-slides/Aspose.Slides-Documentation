---
title: PowerPoint-Präsentationsthemen in Python verwalten
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/python-net/presentation-theme/
keywords:
- PowerPoint-Thema
- Präsentationsthema
- Folienthema
- Thema festlegen
- Thema ändern
- Thema verwalten
- Themenfarbe
- zusätzliche Palette
- Themen-Schriftart
- Themenstil
- Themen-Effekt
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie Präsentationsthemen in Aspose.Slides für Python über .NET, um PowerPoint-Dateien mit einheitlicher Markenidentität zu erstellen, anzupassen und zu konvertieren."
---

## **Übersicht**

Ein Präsentationsthema definiert die Eigenschaften seiner Designelemente. Wenn Sie ein Thema auswählen, wählen Sie ein abgestimmtes Set visueller Elemente und deren Eigenschaften.

In PowerPoint umfasst ein Thema Farben, [Schriftarten](/slides/de/python-net/powerpoint-fonts/), [Hintergrundstile](/slides/de/python-net/presentation-background/) und Effekte.

![theme-constituents](theme-constituents.png)

## **Ändern der Themenfarbe**

Ein PowerPoint‑Thema verwendet ein bestimmtes Farbschema für verschiedene Elemente einer Folie. Wenn Ihnen die Vorgaben nicht gefallen, können Sie sie ändern, indem Sie neue Themenfarben anwenden. Damit Sie eine neue Themenfarbe auswählen können, stellt Aspose.Slides Werte in der [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/)‑Aufzählung bereit.

Dieser Python‑Code zeigt, wie man die Akzentfarbe eines Themas ändert:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```


Sie können den effektiven Wert der resultierenden Farbe wie folgt bestimmen:
```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# Beispielausgabe:
#
# ff8064a2 (Farbe [A=255, R=128, G=100, B=162])
```


Um die Farbänderung weiter zu demonstrieren, erstellen wir ein weiteres Element, weisen ihm die Akzentfarbe aus dem ersten Schritt zu und aktualisieren anschließend die Themenfarbe.
```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```


Die neue Farbe wird automatisch auf beide Elemente angewendet.

### **Festlegen einer Themenfarbe aus der zusätzlichen Palette**

Wenn Sie Luminanz‑Transformationen auf die Hauptthemenfarbe (1) anwenden, werden Farben aus der zusätzlichen Palette (2) erzeugt. Sie können diese Themenfarben anschließend setzen und abrufen.

![additional-palette-colors](additional-palette-colors.png)

**1** — Hauptthemenfarben

**2** — Farben aus der zusätzlichen Palette

Dieser Python‑Code demonstriert, wie zusätzliche Palettenfarben aus der Hauptthemenfarbe abgeleitet und anschließend in Formen verwendet werden:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Akzent 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Akzent 4, Aufgehellt 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Akzent 4, Aufgehellt 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Akzent 4, Aufgehellt 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Akzent 4, Dunkler 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Akzent 4, Dunkler 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```


## **Ändern der Themen‑schriftart**

Damit Sie Schriftarten für Themen und andere Zwecke auswählen können, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich wie in PowerPoint):

- **+mn-lt** — Body‑Schriftart Latin (Minor Latin Font)
- **+mj-lt** — Überschrift‑Schriftart Latin (Major Latin Font)
- **+mn-ea** — Body‑Schriftart Ostasiatisch (Minor East Asian Font)
- **+mj-ea** — Überschrift‑Schriftart Ostasiatisch (Major East Asian Font)

Dieser Python‑Code zeigt, wie man die Latin‑Schriftart einem Themen‑Element zuweist:
```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```


Dieses Python‑Beispiel zeigt, wie man die Themen‑Schriftart der Präsentation ändert:
```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```


Alle Textfelder werden auf die neue Schriftart aktualisiert.

{{% alert color="primary" title="TIP" %}}
Weitere Informationen finden Sie unter [Master PowerPoint-Schriftarten mit Python](/slides/de/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Ändern des Themen‑Hintergrundstils**

Standardmäßig stellt PowerPoint 12 vordefinierte Hintergründe bereit, aber eine typische Präsentation speichert nur 3 davon.

![todo:image_alt_text](presentation-design_8.png)

Zum Beispiel können Sie nach dem Speichern einer Präsentation in PowerPoint den folgenden Python‑Code ausführen, um zu ermitteln, wie viele vordefinierte Hintergründe sie enthält:
```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```


{{% alert color="warning" %}}
Mit der Eigenschaft `background_fill_styles` der Klasse [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/) können Sie Hintergrundstile in einem PowerPoint‑Thema hinzufügen oder darauf zugreifen.
{{% /alert %}}

Dieses Python‑Beispiel zeigt, wie man den Präsentations‑Hintergrund festlegt:
```python
presentation.masters[0].background.style_index = 2  # 0 bedeutet keine Füllung; die Indizierung beginnt bei 1.
```


{{% alert color="primary" title="TIP" %}}
Weitere Informationen finden Sie unter [Verwalten von Präsentationshintergründen in Python](/slides/de/python-net/presentation-background/).
{{% /alert %}}

## **Ändern der Themen‑effekte**

Ein PowerPoint‑Thema enthält typischerweise drei Werte in jedem Stil‑Array. Diese Arrays werden zu drei Effektstufen kombiniert: dezent, moderat und intensiv. Zum Beispiel ist hier das Ergebnis, wenn diese Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Mit den drei Eigenschaften — `FillStyles`, `LineStyles` und `EffectStyles` — der Klasse [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/) können Sie Thema‑Elemente verändern (noch flexibler als in PowerPoint).

Dieser Python‑Code zeigt, wie man einen Themen‑Effekt ändert, indem man Teile dieser Elemente anpasst:
```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


Die resultierenden Änderungen umfassen Aktualisierungen der Füllfarbe, des Fülltyps, des Schattens und weiterer Eigenschaften:
![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Aspose.Slides unterstützt thema‑Overrides auf Folienebene, sodass Sie ein lokales Thema nur auf diese Folie anwenden können, während das Master‑Thema unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/)).

**Was ist der sicherste Weg, ein Thema von einer Präsentation zur anderen zu übertragen?**

[Clone slides](/slides/de/python-net/clone-slides/) zusammen mit ihrem Master in die Zielpräsentation. Dadurch bleiben der ursprüngliche Master, die Layouts und das zugehörige Thema erhalten, sodass das Aussehen konsistent bleibt.

**Wie kann ich die „effektiven“ Werte nach allen Vererbungen und Overrides sehen?**

Verwenden Sie die ["effective"-Ansichten](/slides/de/python-net/shape-effective-properties/) der API für Thema/Farbe/Schriftart/Effekt. Diese geben die aufgelösten, endgültigen Eigenschaften zurück, nachdem der Master sowie etwaige lokale Overrides angewendet wurden.