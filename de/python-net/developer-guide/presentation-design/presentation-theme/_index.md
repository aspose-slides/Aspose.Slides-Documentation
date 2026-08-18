---
title: PowerPoint-Präsentations-Themen in Python verwalten
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
- Zusätzliche Palette
- Themen-Schriftart
- Themenstil
- Thema-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für Python via .NET erstellen, anpassen und PowerPoint-Dateien mit konsistenter Markenführung konvertieren."
---
## **Einführung**

Ein Präsentationsthema definiert einen abgestimmten Satz aus Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Themen‑bewusste Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass ein Themenwechsel viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das themenbezogene Presentation‑Level‑Thema über die [Presentation.master_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/master_theme/)‑Eigenschaft verfügbar. Eine Präsentation kann außerdem Themen‑Überschreibungen auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.override_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/masterthememanager/override_theme/) überschreiben, ein Layout kann sein geerbtes Thema über [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) überschreiben, und eine einzelne Folie kann dasselbe tun. In der Praxis wird das effektive Thema einer Folie über diese Vererbungskette ermittelt: Präsentationsthema, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gängigsten Workflows für Themen: Thema untersuchen, Farben und Schriftarten ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren sowie wirksame Werte nach Auflösung von Vererbung und Überschreibungen auslesen.

## **Ein Thema untersuchen**

Das [MasterTheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/mastertheme/)‑Objekt stellt die Eigenschaften [color_scheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/mastertheme/font_scheme/) und [format_scheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/mastertheme/format_scheme/) des Themas bereit. Das Untersuchen dieser Sammlungen vor Änderungen ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, weil die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die wichtigsten Thema‑Eigenschaften aus und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Thema gespeichert sind:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

Verwendet eine Datei mehrere Master, darf man nicht annehmen, dass jede Folie dasselbe effektive Thema hat. Untersuchen Sie den mit der Folie verknüpften Master und verwenden Sie den später in diesem Artikel gezeigten Workflow für das effektive Thema, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein können.

## **Themenfarben ändern**

Themen‑bewusste Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/python-net/aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag in der [ColorScheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/colorscheme/) des Themas ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch eine Themenfarb‑Aktualisierung nicht geändert.

Das folgende End‑to‑End‑Beispiel erstellt eine Form, die `ACCENT4` verwendet, ändert die Themenfarbe `accent4` zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die wirksame Füllfarbe aus:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

Da das Rechteck mit `ACCENT4` verknüpft bleibt, wird seine sichtbare Farbe nach Änderung des Themas rot. Ersetzen Sie die Schema‑Farbe durch eine direkte Farbe in der Form, wirken spätere Änderungen an `accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten von einer Themenfarbe ab, indem es Farbtransformationen anwendet. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/de/python-net/aspose.slides/colortransformoperation/) bereit.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Hauptthemenfarben.

**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt wurden.

Das folgende Beispiel erstellt sechs Rechtecke auf Basis von `ACCENT4`, wendet Luminanz‑Transformationen auf fünf davon an und speichert das Ergebnis:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

Diese Varianten bleiben auf der Themenfarbe basierend. Ändert sich `accent4` später, werden die transformierten Farben aus dem neuen `accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `ColorScheme`‑Plätzen zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/python-net/aspose.slides/schemecolor/) verwendet `TEXT1`, `BACKGROUND1`, `TEXT2` und `BACKGROUND2`, während [ColorScheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/colorscheme/) dieselben Themenplätze als `dark1`, `light1`, `dark2` und `light2` bereitstellt. Die Zuordnung ist fest:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Dies sind alternative Bezeichnungen für dieselben Themenplätze; es handelt sich nicht um Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Themen‑Schriftarten ändern**

Ein Themen‑Schriftartenschema enthält einen Hauptschriftartensatz für Überschriften und einen Nebensatz für Fließtext. Die Eigenschaften [FontScheme.major](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/fontscheme/major/) und [FontScheme.minor](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/fontscheme/minor/) stellen diese Sätze bereit.

PowerPoint‑kompatible Themen‑Schriftart‑Kennungen können in der Textformatierung verwendet werden:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latin‑Themen‑Schriftart verwendet, und eine Textzeile, die die Neben‑Latin‑Themen‑Schriftart verwendet. Anschließend werden die Themen‑Schriftarten geändert und das Ergebnis gespeichert:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

Die Überschrift folgt der Hauptschriftart und der Fließtext folgt der Nebenschriftart. Text, dem ein expliziter Schriftartname anstelle einer Themen‑Kennung zugewiesen ist, wechselt nicht automatisch, wenn das Themen‑Schriftartenschema geändert wird.

{{% alert color="info" title="Hinweis" %}}
Weitere Informationen zu Präsentations‑Schriftarten finden Sie unter [PowerPoint Fonts](/slides/de/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Ein Thema kopieren oder anwenden**

Es gibt zwei gängige Workflows, die unterschiedliche Probleme lösen.

### **Quell‑Thema beim Verschieben von Folien erhalten**

Wenn Sie eine Folie in eine andere Präsentation verschieben und ihr ursprüngliches Design beibehalten möchten, klonen Sie den Quell‑Master in die Zielpräsentation mit [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/add_clone/), und klonen Sie anschließend die Folie mit [SlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/) und dem geklonten Master. Dadurch werden Master, seine Layouts und das zugehörige Thema zusammen transportiert.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

Dies ist der bevorzugte Workflow, wenn die Quell‑Folie im Ziel exakt gleich aussehen soll. Das reine Klonen von Inhalten auf einen nicht verwandten Ziel‑Master kann themenbasierte Farben, Schriftarten, Hintergründe und Effekte ändern.

### **Themen‑Werte auf eine vorhandene Folie anwenden**

Muss die Ziel‑Folie auf ihrem aktuellen Master und Layout bleiben, initialisieren Sie eine folienbezogene Überschreibung aus dem Quell‑Thema. Die Methoden [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) und [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) kopieren die drei Haupt‑Themenkomponenten in die Überschreibung.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

Damit wird das von dieser Folie genutzte Thema geändert, ohne das von anderen Folien geerbte Thema zu beeinflussen. Um die lokale Überschreibung zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.clear](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/overridetheme/clear/) auf.

### **Eine Themen‑Überschreibung auf ein Layout anwenden**

Eine Layout‑Überschreibung wirkt auf alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie nicht ihre eigene Überschreibung besitzt. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/layoutslidethememanager/) des Layouts verwendet werden:

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe Basis‑Design teilen sollen, eine Layout‑Überschreibung, wenn eine Layout‑Familie ein abweichendes Styling benötigt, und eine Folien‑Überschreibung nur für wahre Ausnahmen. Exzessive Folien‑Überschreibungen erschweren die Vorhersagbarkeit späterer globaler Themenänderungen.

## **Themen‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themas werden in [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) gespeichert. PowerPoint kann im UI mehr Hintergrund‑Optionen anbieten, als tatsächlich in dieser Sammlung definiert sind, da das UI Themen‑Füllungen mit Themen‑Farben und anderen Stilreferenzen kombinieren kann.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, untersuchen Sie die gespeicherte Sammlung und den aktuellen [Background.style_index](https://reference.aspose.com/slides/de/python-net/aspose.slides/background/style_index/). `style_index` verwendet `0` für keine themenbezogene Füllung; positive Werte sind Referenzen auf Themen‑Hintergrund‑Stile. Das unterscheidet sich vom Index einer Python‑Sammlung, bei der `[0]` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl von Hintergrund‑Füllstilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl von Hintergrund‑Füllungen aus, weist dem ersten Master eine themenbezogene Hintergrundreferenz zu und speichert die Präsentation:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

Das sichtbare Ergebnis hängt vom vom Master referenzierten Themaintrag sowie von etwaigen Hintergrund‑Überschreibungen auf Layout‑ oder Folien‑Ebene ab. Verwendet eine Folie ihren eigenen Hintergrund, kann das Ändern nur des Master‑Hintergrunds diese Folie nicht beeinflussen. Nutzen Sie [Background.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/background/get_effective/), wenn Sie den endgültigen Hintergrund nach angewandter Vererbung kennen müssen.

{{% alert color="warning" title="Warnung" %}}
Betrachten Sie `style_index` nicht als nullbasierten Sammlungs‑Index. Vermeiden Sie außerdem, eine Stil‑Nummer aus einer Datei zu hard‑coden und anzunehmen, dass sie in einer anderen Datei gleich aussieht; Themen‑Stil‑Definitionen sind präsentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Hinweis" %}}
Für direkte Hintergrundformatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/python-net/presentation-background/).
{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Format‑Schema enthält separate Sammlungen für [FormatScheme.fill_styles](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/line_styles/) und [FormatScheme.effect_styles](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/effect_styles/). Typische Office‑Themen enthalten häufig drei Haupteinträge, die visuell subtil, moderat und intensiv formatiert sind, aber der Code sollte jede Sammlung prüfen, anstatt eine feste Anzahl anzunehmen.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Wenn Sie in Python auf diese Sammlungen zugreifen, ist der Index nullbasiert: `[0]` ist der zuerst gespeicherte Stil und `[2]` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/de/python-net/aspose.slides/ishapestyle/) bereitgestellt wird. Das Ändern eines Themen‑Stils beeinflusst Formen, die diesen Stilreferenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die benötigten Stileinträge vorhanden sind, ändert den ersten Linienstil, den dritten Füllstil, aktiviert einen äußeren Schatten im dritten Effektstil und speichert das Ergebnis:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

Für Formen, die diese Plätze referenzieren, wird der erste Themen‑Linienstil rot, der dritte Themen‑Füllstil wird zu einem gesättigten Waldgrün und der dritte Effektstil erhält einen äußeren Schatten mit einem Abstand von 10 pt. Das genaue visuelle Ergebnis hängt nach wie vor davon ab, welche Stilplätze jede Form referenziert und ob direkte Formatierung die Themen‑Einstellungen überschreibt.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Wirksame Themen‑Werte auslesen**

Roh‑Thema‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Wirksame Werte geben an, was eine Folie oder Form tatsächlich nach Auflösung von Vererbung und lokalen Überschreibungen nutzt. Für eine Folie rufen Sie [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) auf. Für einen Hintergrund verwenden Sie [Background.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/background/get_effective/), und für eine Füllung [FillFormat.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/fillformat/get_effective/).

Das folgende Beispiel liest das wirksame Thema, den Hintergrund und die erste Form‑Füllung einer Folie aus:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

Verwenden Sie wirksame Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation.master_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/master_theme/) untersuchen, können Sie einen Master‑, Layout‑, Folien‑ oder Form‑Überschreibung übersehen, die das endgültige Aussehen ändert.

## **FAQ**

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/slidethememanager/) der Folie und initialisieren Sie dessen Überschreibungsthema. Die Änderung bleibt lokal für diese Folie; andere Folien erben weiterhin ihre bestehenden Themen.

**Was ist der sicherste Weg, ein Thema von einer Präsentation in eine andere zu übernehmen?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Erscheinungsbild erhalten wollen, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master mithilfe von [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/add_clone/) und [SlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/). Dadurch bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die wirksamen Werte nach Vererbung und Überschreibungen sehen?**

Verwenden Sie [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) für ein Folien‑ oder Layout‑Thema und die entsprechenden wirksamen‑Daten‑Methoden für Format‑Objekte wie [Background.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/background/get_effective/) und [FillFormat.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/fillformat/get_effective/). Diese APIs liefern die aufgelösten Werte nach Anwendung von Vererbung und Überschreibungen.