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
- Themen-Stil
- Themen-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für Python über .NET erstellen, anpassen und PowerPoint-Dateien mit konsistenter Markenidentität konvertieren."
---
## **Einführung**

Ein Präsentationsthema definiert ein koordiniertes Set aus Farben, Schriften, Hintergrundstilen, Füllungen, Linien und Effekten. Themenbewusste Objekte beziehen sich auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass ein Themenwechsel viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das thema‑bezogene Präsentations‑Level über die Eigenschaft [Presentation.master_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/master_theme/) verfügbar. Eine Präsentation kann außerdem Themen‑Überschreibungen auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.override_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/masterthememanager/override_theme/) überschreiben, ein Layout kann sein geerbtes Thema über [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) überschreiben, und eine einzelne Folie kann dasselbe tun. In der Praxis wird das effektive Thema einer Folie über diese Vererbungskette ermittelt: Präsentationsthema, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Themenkomponenten: Farben, Schriften, Hintergrundstile und Effekte](theme-constituents.png)

Die nachstehenden Abschnitte zeigen die gebräuchlichsten Themen‑Workflows: ein Thema inspizieren, Farben und Schriften ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Auflösung von Vererbung und Überschreibungen lesen.

## **Ein Thema inspizieren**

Das Objekt [MasterTheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/mastertheme/) stellt die Eigenschaften [color_scheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/mastertheme/font_scheme/) und [format_scheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/mastertheme/format_scheme/) des Themas zur Verfügung. Das Inspizieren dieser Sammlungen, bevor sie geändert werden, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, da die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Themas und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Thema gespeichert sind:

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

Verwendet eine Datei mehrere Master, darf man nicht davon ausgehen, dass jede Folie dasselbe effektive Thema hat. Inspizieren Sie den Master, der der Folie zugeordnet ist, und verwenden Sie den später in diesem Artikel gezeigten effektiven‑Thema‑Workflow, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein können.

## **Themenfarben ändern**

Themen‑bewusste Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/python-net/aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag in der [ColorScheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/colorscheme/) des Themas ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch ein Update der Themenfarbe nicht geändert.

Das folgende End‑to‑End‑Beispiel erstellt eine Form, die `ACCENT4` verwendet, ändert die Themenfarbe `accent4` zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die effektive Füllfarbe aus:

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

Da das Rechteck weiterhin mit `ACCENT4` verknüpft ist, wird seine sichtbare Farbe nach der Themenänderung Rot. Ersetzen Sie die Schema‑Farbe durch eine direkte Farbe auf der Form, wirken spätere Änderungen von `accent4` nicht mehr auf diese Füllung.

### **Farben aus der Zusatzpalette verwenden**

PowerPoint leitet hellere und dunklere Varianten von einer Themenfarbe ab, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/de/python-net/aspose.slides/colortransformoperation/) bereit.

![Hauptthemenfarben und aus der Zusatzpalette erzeugte hellere und dunklere Farben](additional-palette-colors.png)

**1** – Hauptthemenfarben.

**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt werden.

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

Diese Varianten bleiben an der Themenfarbe ausgerichtet. Ändert sich `accent4` später, werden die transformierten Farben aus dem neuen `accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `ColorScheme`‑Plätzen zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/python-net/aspose.slides/schemecolor/) verwendet `TEXT1`, `BACKGROUND1`, `TEXT2` und `BACKGROUND2`, während [ColorScheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/colorscheme/) dieselben Themenplätze als `dark1`, `light1`, `dark2` und `light2` bereitstellt. Die Zuordnung ist fest:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Dies sind alternative Bezeichnungen für dieselben Themenplätze; es handelt sich nicht um Werte, die dynamisch von einer Form zur anderen konvertiert werden.

## **Themenschriften ändern**

Ein Themen‑Schriftartenschema enthält ein Hauptschriftset für Überschriften und ein Neben­schriftset für Fließtext. Die Eigenschaften [FontScheme.major](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/fontscheme/major/) und [FontScheme.minor](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/fontscheme/minor/) stellen diese Sets bereit.

PowerPoint‑kompatible Themen‑Schriftart‑Kennungen können in der Textformatierung verwendet werden:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latin‑Themen­schrift verwendet, und eine Textzeile, die die Neben‑Latin‑Themen­schrift verwendet. Anschließend werden die Themen­schriften geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Hauptschrift und der Fließtext der Neben­schrift. Text, dem ein expliziter Schriftname statt einer Themen‑Kennung zugewiesen ist, wechselt nicht automatisch, wenn das Themen‑Schriftartenschema geändert wird.

Die Haupt‑ und Neben­schrift‑Sammlungen können außerdem Schrift‑Mappings für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Inspizieren, Hinzufügen, Ersetzen oder Entfernen dieser Mappings siehe [Script‑Specific Theme Fonts](/slides/de/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tipp" %}}
Für weitere Informationen zu Präsentationsschriften siehe [PowerPoint Fonts](/slides/de/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Ein Thema kopieren oder anwenden**

Es gibt zwei gängige Workflows, die unterschiedliche Probleme lösen.

### **Quell‑Thema beim Verschieben von Folien beibehalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und das ursprüngliche Design erhalten, klonen Sie den Quell‑Master in die Zielpräsentation mit [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/add_clone/), und klonen Sie dann die Folie mit [SlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/) und dem geklonten Master. Damit werden Master, Layouts und das zugehörige Thema zusammen übertragen.

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

Dies ist der bevorzugte Workflow, wenn die Quell‑Folie im Ziel exakt gleich aussehen muss. Das bloße Klonen von Inhalten auf einen nicht zugehörigen Ziel‑Master kann themen‑basierte Farben, Schriften, Hintergründe und Effekte ändern.

### **Themenwerte auf eine vorhandene Folie anwenden**

Muss die Ziel‑Folie auf ihrem aktuellen Master und Layout bleiben, initialisieren Sie eine Folien‑Ebene‑Überschreibung aus dem Quell‑Thema. Die Methoden [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) und [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) kopieren die drei Haupt‑Themenkomponenten in die Überschreibung.

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

Damit wird das von dieser Folie verwendete Thema geändert, ohne das von anderen Folien geerbte Thema zu beeinflussen. Entfernen Sie die lokale Überschreibung und kehren Sie zu den geerbten Werten zurück, indem Sie [OverrideTheme.clear](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/overridetheme/clear/) aufrufen.

### **Eine Themen‑Überschreibung auf ein Layout anwenden**

Eine Layout‑Ebene‑Überschreibung gilt für Folien, die dieses Layout verwenden, es sei denn, eine bestimmte Folie hat eine eigene Überschreibung. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/layoutslidethememanager/) des Layouts verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe Grunddesign teilen sollen, eine Layout‑Überschreibung, wenn eine Layout‑Familie ein anderes Styling benötigt, und eine Folien‑Überschreibung nur für echte Ausnahmen. Übermäßige Folien‑Überschreibungen erschweren die Vorhersagbarkeit späterer globaler Themenänderungen.

## **Themen‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themas werden in [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) gespeichert. PowerPoint kann im UI mehr Hintergrund‑Optionen präsentieren, als tatsächlich in dieser Sammlung definiert sind, weil das UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrundstil‑Galerie für ein Präsentationsthema](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, inspizieren Sie die gespeicherte Sammlung und den aktuellen [Background.style_index](https://reference.aspose.com/slides/de/python-net/aspose.slides/background/style_index/). `style_index` verwendet `0` für keine themenbasierte Füllung; positive Werte sind Referenzen zu Themen‑Hintergrundstilen. Das unterscheidet sich vom Indexieren einer Python‑Sammlung, bei der `[0]` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl von Hintergrund‑Füllstilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl von Hintergrund‑Füllungen aus, weist dem ersten Master eine themenbasierte Hintergrund‑Referenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt vom vom Master referenzierten Themen‑Eintrag sowie von etwaigen Hintergrund‑Überschreibungen im Layout oder auf Folien‑Ebene ab. Verwendet eine Folie einen eigenen Hintergrund, kann das Ändern des Master‑Hintergrunds diese Folie unverändert lassen. Nutzen Sie [Background.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/background/get_effective/), wenn Sie den endgültigen Hintergrund nach Anwendung der Vererbung wissen müssen.

{{% alert color="warning" title="Warnung" %}}
Behandeln Sie `style_index` nicht als nullbasierten Sammlungs‑Index. Vermeiden Sie außerdem das Hard‑Coden einer Stildnummer aus einer Datei und die Annahme, dass sie in einer anderen Datei gleich aussieht; Themen‑Stil‑Definitionen sind präsentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Tipp" %}}
Für direkte Hintergrundformatierung und Hintergrundvererbung siehe [Presentation Background](/slides/de/python-net/presentation-background/).
{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Format‑Schema enthält separate Sammlungen für [FormatScheme.fill_styles](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/line_styles/) und [FormatScheme.effect_styles](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/effect_styles/). Typische Office‑Themen enthalten häufig drei Haupteinträge, die visuell subtil, moderat und intensiv formatiert sind, aber der Code sollte jede Sammlung inspizieren, anstatt eine feste Anzahl anzunehmen.

![Subtile, moderate und intensive Themen‑Effekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Wenn Sie in Python auf diese Sammlungen zugreifen, ist der Sammlungs‑Index nullbasiert: `[0]` ist der erste gespeicherte Stil und `[2]` der dritte. Die Indexe von Stil‑Referenzen einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/de/python-net/aspose.slides/ishapestyle/) bereitgestellt wird. Das Ändern eines Themen‑Stils wirkt sich auf Formen aus, die diesen Themen‑Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die erforderlichen Stileinträge existieren, ändert den ersten Linien‑Stil, ändert den dritten Füll‑Stil, aktiviert einen äußeren Schatten im dritten Effekt‑Stil und speichert das Ergebnis:

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

Für Formen, die diese Plätze referenzieren, wird der erste Themen‑Linienstil Rot, der dritte Themen‑Füllstil ein massives Waldgrün und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einem Abstand von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Plätze jede Form referenziert und ob direkte Formatierung die Themen‑Einstellung überschreibt.

![Themen‑Effekt‑Stile nach Änderung von Linie, Füllung und Schatten‑Einstellungen](presentation-design_11.png)

## **Effektive Themenwerte lesen**

Roh‑Themenobjekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte geben an, was eine Folie oder Form tatsächlich nach Vererbung und lokalen Überschreibungen verwendet. Für eine Folie rufen Sie [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) auf. Für einen Hintergrund verwenden Sie [Background.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/background/get_effective/), und für eine Füllung [FillFormat.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/fillformat/get_effective/).

Das folgende Beispiel liest das effektive Thema, den Hintergrund und die erste Form‑Füllung von einer Folie:

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

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation.master_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/master_theme/) inspizieren, können Sie eine Master‑, Layout‑, Folien‑ oder Form‑Überschreibung übersehen, die das Endergebnis verändert.

## **FAQ**

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/slidethememanager/) der Folie und initialisieren Sie dessen Überschreibungsthema. Die Änderung bleibt lokal für diese Folie; andere Folien erben weiterhin ihre bestehenden Themen.

**Was ist der sicherste Weg, ein Thema von einer Präsentation in eine andere zu übertragen?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Aussehen bewahren wollen, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master mithilfe von [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/add_clone/) und [SlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/). Damit bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Überschreibungen sehen?**

Verwenden Sie [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) für ein Folien‑ oder Layout‑Thema und die entsprechenden effektiven‑Daten‑Methoden für Format‑Objekte wie [Background.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/background/get_effective/) und [FillFormat.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/fillformat/get_effective/). Diese APIs geben die aufgelösten Werte nach Anwendung von Vererbung und Überschreibungen zurück.