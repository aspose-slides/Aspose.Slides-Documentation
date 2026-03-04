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
description: "Verwalten Sie Master-Präsentationsthemen in Aspose.Slides für Python über .NET, um PowerPoint-Dateien mit einheitlichem Branding zu erstellen, anzupassen und zu konvertieren."
---
## **Übersicht**

Ein Präsentationsthema definiert die Eigenschaften seiner Designelemente. Wenn Sie ein Thema auswählen, wählen Sie ein abgestimmtes Set visueller Elemente und deren Eigenschaften.

In PowerPoint umfasst ein Thema Farben, [Schriften](/slides/de/python-net/powerpoint-fonts/), [Hintergrundstile](/slides/de/python-net/presentation-background/) und Effekte.

![theme-constituents](theme-constituents.png)

## **Themafarbe ändern**

Ein PowerPoint‑Thema verwendet für verschiedene Elemente auf einer Folie ein festgelegtes Farbspektrum. Wenn Ihnen die Vorgaben nicht gefallen, können Sie sie ändern, indem Sie neue Themenfarben anwenden. Um Ihnen die Auswahl einer neuen Themenfarbe zu ermöglichen, stellt Aspose.Slides Werte in der [SchemeColor](https://reference.aspose.com/slides/de/python-net/aspose.slides/schemecolor/)‑Enumeration bereit.

Dieser Python‑Code zeigt, wie die Akzentfarbe eines Themas geändert wird:

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
# ff8088a2 (Farbe [A=255, R=128, G=100, B=162])
```

Um die Farbänderung weiter zu demonstrieren, erstellen wir ein weiteres Element, weisen ihm die Akzentfarbe aus dem ersten Schritt zu und aktualisieren anschließend die Themenfarbe.

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

Die neue Farbe wird automatisch auf beide Elemente angewendet.

### **Themafarbe aus der zusätzlichen Palette setzen**

Wenn Sie Luminanz‑Transformationen auf die Hauptthemenfarbe (1) anwenden, werden Farben aus der zusätzlichen Palette (2) erzeugt. Diese Themenfarben können Sie anschließend setzen und abrufen.

![additional-palette-colors](additional-palette-colors.png)

**1** — Hauptthemenfarben  

**2** — Farben aus der zusätzlichen Palette

Dieser Python‑Code demonstriert, wie Farben der zusätzlichen Palette aus der Hauptthemenfarbe abgeleitet und anschließend in Formen verwendet werden:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Akzent 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Akzent 4, 80% heller
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Akzent 4, 60% heller
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Akzent 4, 40% heller
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Akzent 4, 25% dunkler
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Akzent 4, 50% dunkler
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **`SchemeColor` zu `ColorScheme`‑Farben zuordnen**

Wenn Sie mit [SchemeColor](https://reference.aspose.com/slides/de/python-net/aspose.slides/schemecolor/) arbeiten, bemerken Sie vielleicht, dass sie die folgenden Themenfarbwerte enthält:

`BACKGROUND1`, `BACKGROUND2`, `TEXT1` und `TEXT2`.

`Presentation.master_theme.color_scheme` liefert jedoch ein [ColorScheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/colorscheme/), das die entsprechenden Farben als

`dark1`, `dark2`, `light1` und `light2`

exponiert.

Dieser Unterschied besteht nur in der Benennung. Diese Werte beziehen sich auf dieselben Themenfarb‑Slots und die Zuordnung ist fest:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Es gibt keine dynamische Konvertierung zwischen `TEXT`/`BACKGROUND` und `dark`/`light`. Es handelt sich lediglich um alternative Bezeichnungen für dieselben Themenfarben.

Diese Benennungsunterschiede stammen aus der Microsoft‑Office‑Terminologie. Ältere Office‑Versionen verwendeten `Dark 1`, `Light 1`, `Dark 2` und `Light 2`, während neuere Benutzeroberflächen dieselben Slots als `Text 1`, `Background 1`, `Text 2` und `Background 2` anzeigen.

## **Thema‑Schriftart ändern**

Um Ihnen die Auswahl von Schriften für Themen und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich denen in PowerPoint):

- **+mn-lt** — Body Font Latin (Minor Latin Font)  
- **+mj-lt** — Heading Font Latin (Major Latin Font)  
- **+mn-ea** — Body Font East Asian (Minor East Asian Font)  
- **+mj-ea** — Heading Font East Asian (Major East Asian Font)

Dieser Python‑Code zeigt, wie die lateinische Schrift einer Themen‑Komponente zugewiesen wird:

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

Dieses Python‑Beispiel zeigt, wie die Schriftart des Präsentationsthemas geändert wird:

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

Alle Textfelder werden auf die neue Schriftart aktualisiert.

{{% alert color="primary" title="TIPP" %}}
Weitere Informationen finden Sie unter [Master PowerPoint Fonts with Python](/slides/de/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Thema‑Hintergrundstil ändern**

Standardmäßig stellt PowerPoint 12 vordefinierte Hintergründe bereit, aber eine typische Präsentation speichert nur 3 davon.

![todo:image_alt_text](presentation-design_8.png)

Beispielsweise können Sie nach dem Speichern einer Präsentation in PowerPoint den folgenden Python‑Code ausführen, um zu ermitteln, wie viele vordefinierte Hintergründe sie enthält:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
Über die Eigenschaft `background_fill_styles` der Klasse [FormatScheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/) können Sie Hintergrundstile in einem PowerPoint‑Thema hinzufügen oder darauf zugreifen.
{{% /alert %}}

Dieses Python‑Beispiel zeigt, wie der Präsentationshintergrund gesetzt wird:

```python
presentation.masters[0].background.style_index = 2  # 0 bedeutet keine Füllung; die Indizierung beginnt bei 1.
```

{{% alert color="primary" title="TIPP" %}}
Weitere Informationen finden Sie unter [Manage Presentation Backgrounds in Python](/slides/de/python-net/presentation-background/).
{{% /alert %}}

## **Thema‑Effekte ändern**

Ein PowerPoint‑Thema enthält typischerweise drei Werte in jedem Stil‑Array. Diese Arrays ergeben drei Effektstufen: dezent, mittel und intensiv. Beispielhaft ist hier das Ergebnis, wenn diese Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Über die drei Eigenschaften — `FillStyles`, `LineStyles` und `EffectStyles` — der Klasse [FormatScheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/) können Sie Themen‑Elemente (noch flexibler als in PowerPoint) anpassen.

Dieser Python‑Code zeigt, wie ein Thema‑Effekt geändert wird, indem Teile dieser Elemente modifiziert werden:

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Die resultierenden Änderungen umfassen Updates von Füllfarbe, Fülltyp, Schatteneffekt und weiteren Eigenschaften:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Kann ich ein Thema nur auf einer einzelnen Folie anwenden, ohne das Master‑Thema zu ändern?**

Ja. Aspose.Slides unterstützt Folien‑bezogene Themen‑Überschreibungen, sodass Sie ein lokales Thema nur auf dieser Folie anwenden können, während das Master‑Thema unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/slidethememanager/)).

**Wie übertrage ich ein Thema am sichersten von einer Präsentation in eine andere?**

[Slides klonen](/slides/de/python-net/clone-slides/) zusammen mit ihrem Master in die Zielpräsentation. Dadurch bleiben Master, Layouts und das zugehörige Thema erhalten, sodass das Erscheinungsbild konsistent bleibt.

**Wie kann ich die „effektiven“ Werte nach allen Vererbungen und Überschreibungen einsehen?**

Verwenden Sie die API‑„[effective”‑Ansichten](/slides/de/python-net/shape-effective-properties/) für Thema/Farbe/Schrift/Effekt. Diese geben die aufgelösten Endwerte nach Anwendung des Masters sowie aller lokalen Überschreibungen zurück.