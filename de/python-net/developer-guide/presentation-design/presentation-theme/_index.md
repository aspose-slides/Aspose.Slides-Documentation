---
title: Präsentationsthema
type: docs
weight: 10
url: /de/python-net/presentation-theme/
keywords: "Thema, PowerPoint-Thema, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "PowerPoint-Präsentationsthema in Python"
---

Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen einen bestimmten Satz von visuellen Elementen und deren Eigenschaften aus.

In PowerPoint umfasst ein Thema Farben, [Schriften](/slides/de/python-net/powerpoint-fonts/), [Hintergrundstile](/slides/de/python-net/presentation-background/) und Effekte.

![theme-constituents](theme-constituents.png)

## **Theme-Farbe ändern**

Ein PowerPoint-Thema verwendet eine spezifische Farbpalette für verschiedene Elemente auf einer Folie. Wenn Ihnen die Farben nicht gefallen, können Sie sie ändern, indem Sie neue Farben für das Thema anwenden. Um Ihnen die Auswahl einer neuen Themenfarbe zu ermöglichen, stellt Aspose.Slides Werte unter der [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) Aufzählung bereit.

Dieser Python-Code zeigt Ihnen, wie Sie die Akzentfarbe für ein Thema ändern:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

Sie können den effektiven Wert der resultierenden Farbe auf diese Weise bestimmen:

```python
fillEffective = shape.fill_format.get_effective()
print("{0} ({1})".format(fillEffective.solid_fill_color.name, fillEffective.solid_fill_color)) # ff8064a2 (Farbe [A=255, R=128, G=100, B=162])
```

Um den Farbänderungsvorgang weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus dem anfänglichen Vorgang) zu. Dann ändern wir die Farbe im Thema:

```python
otherShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
otherShape.fill_format.fill_type = slides.FillType.SOLID
otherShape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

pres.master_theme.color_scheme.accent4.color = draw.Color.red
```

Die neue Farbe wird automatisch auf beiden Elementen angewendet.

### **Themenfarbe aus zusätzlicher Palette festlegen**

Wenn Sie Helligkeitstransformationen auf die Hauptfarben des Themas(1) anwenden, entstehen Farben aus der zusätzlichen Palette(2). Sie können diese Themenfarben dann festlegen und abrufen.

![additional-palette-colors](additional-palette-colors.png)

**1**- Hauptfarbthemen

**2** - Farben aus der zusätzlichen Palette.

Dieser Python-Code demonstriert einen Vorgang, bei dem zusätzliche Palettenfarben aus der Hauptfarbe des Themas abgeleitet und dann in Shapes verwendet werden:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Akzent 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Akzent 4, Heller 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Akzent 4, Heller 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Akzent 4, Heller 40%
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

## **Themen-Schrift ändern**

Um Ihnen die Auswahl von Schriften für Themen und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Identifier (ähnlich denen in PowerPoint):

* **+mn-lt** - Schrift für den Haupttext Latein (Minor Latin Font)
* **+mj-lt** - Schrift für Überschriften Latein (Major Latin Font)
* **+mn-ea** - Schrift für den Haupttext Ostasiatisch (Minor East Asian Font)
* **+mj-ea** - Schrift für Überschriften Ostasiatisch (Major East Asian Font)

Dieser Python-Code zeigt Ihnen, wie Sie die lateinische Schrift einem Themenelement zuweisen:

```python
shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)

paragraph = slides.Paragraph()
portion = slides.Portion("Themen-Textformat")
paragraph.portions.add(portion)
shape.text_frame.paragraphs.add(paragraph)
portion.portion_format.latin_font = slides.FontData("+mn-lt")
```

Dieser Python-Code zeigt Ihnen, wie Sie die Schriftart des Präsentationsthemas ändern:

```python
pres.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

Die Schriftart in allen Textfeldern wird aktualisiert.

{{% alert color="primary" title="TIPP" %}} 

Sie möchten möglicherweise die [PowerPoint-Schriften](/slides/de/python-net/powerpoint-fonts/) ansehen.

{{% /alert %}}

## **Themen-Hintergrundstil ändern**

Standardmäßig bietet die PowerPoint-App 12 vordefinierte Hintergründe, aber nur 3 von diesen 12 Hintergründen werden in einer typischen Präsentation gespeichert.

![todo:image_alt_text](presentation-design_8.png)

Nachdem Sie beispielsweise eine Präsentation in der PowerPoint-App gespeichert haben, können Sie diesen Python-Code ausführen, um die Anzahl der vordefinierten Hintergründe in der Präsentation herauszufinden:

```python
with slides.Presentation() as pres:
    numberOfBackgroundFills = len(pres.master_theme.format_scheme.background_fill_styles)
    print("Anzahl der Hintergrundfüllstile für das Thema beträgt {0}".format(numberOfBackgroundFills))
```

{{% alert color="warning" %}} 

Mit der `BackgroundFillStyles`-Eigenschaft der [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/) Klasse können Sie den Hintergrundstil in einem PowerPoint-Thema hinzufügen oder darauf zugreifen. 

{{% /alert %}}

Dieser Python-Code zeigt Ihnen, wie Sie den Hintergrund für eine Präsentation festlegen:

```python
pres.masters[0].background.style_index = 2
```

**Index-Leitfaden**: 0 wird für keine Füllung verwendet. Der Index beginnt bei 1.

{{% alert color="primary" title="TIPP" %}} 

Sie möchten möglicherweise den [PowerPoint-Hintergrund](/slides/de/python-net/presentation-background/) ansehen.

{{% /alert %}}

## **Themen-Effekt ändern**

Ein PowerPoint-Thema enthält normalerweise 3 Werte für jedes Stil-Array. Diese Arrays werden in diese 3 Effekte kombiniert: subtil, moderat und intensiv. Zum Beispiel ist dies das Ergebnis, wenn die Effekte auf ein bestimmtes Shape angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Anhand von 3 Eigenschaften (`FillStyles`, `LineStyles`, `EffectStyles`) der  [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/) Klasse können Sie die Elemente in einem Thema ändern (sogar flexibler als die Optionen in PowerPoint).

Dieser Python-Code zeigt Ihnen, wie Sie einen Themaeffekt ändern, indem Sie Teile von Elementen ändern:

```python
with slides.Presentation("combined_with_master.pptx") as pres:
    pres.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    pres.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    pres.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    pres.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", slides.export.SaveFormat.PPTX)
```

Die resultierenden Änderungen in der Füllfarbe, dem Fülltyp, dem Schattierungseffekt usw.:

![todo:image_alt_text](presentation-design_11.png)