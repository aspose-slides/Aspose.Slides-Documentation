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
- externes Thema
- THMX
- Themenfarbe
- zusätzliche Palette
- Themen-Schrift
- Themenstil
- Thementeffekt
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für Python über .NET erstellen, anpassen und PowerPoint-Dateien mit konsistenter Markenbildung konvertieren."
---
## **Einführung**

Ein Präsentationsthema definiert ein abgestimmtes Set aus Farben, Schriften, Hintergrundstilen, Füllungen, Linien und Effekten. Themen‑bewusste Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass ein Themenwechsel viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das Präsentations‑thema über die [Presentation.master_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/master_theme/)‑Eigenschaft verfügbar. Eine Präsentation kann zudem Themen‑Überschreibungen auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.override_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/masterthememanager/override_theme/) überschreiben, ein Layout kann sein geerbtes Thema über [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) überschreiben und eine einzelne Folie kann dasselbe tun. In der Praxis wird das effektive Thema einer Folie über diese Vererbungskette ermittelt: Präsentationsthema, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gängigsten Themen‑Workflows: ein Thema untersuchen, Farben und Schriften ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren sowie effektive Werte nach Vererbung und Überschreibungen auslesen.

## **Ein Thema untersuchen**

Das [MasterTheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/mastertheme/)‑Objekt stellt die Eigenschaften [color_scheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/mastertheme/font_scheme/) und [format_scheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/mastertheme/format_scheme/) des Themas bereit. Diese Sammlungen zu untersuchen, bevor man Änderungen vornimmt, ist besonders hilfreich, wenn eine Präsentation aus einer externen Quelle stammt, da die Anzahl und der Inhalt der Stileinträge variieren können.

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

Verwendet eine Datei mehrere Master, darf man nicht davon ausgehen, dass jede Folie dasselbe effektive Thema hat. Untersuchen Sie den Master, der zur Folie gehört, und verwenden Sie den später in diesem Artikel gezeigten effektiven‑Thema‑Workflow, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein könnten.

## **Themenfarben ändern**

Themen‑bewusste Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/python-net/aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag im [ColorScheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/colorscheme/) des Themas ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch ein Update einer Themenfarbe nicht geändert.

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

Da das Rechteck weiterhin mit `ACCENT4` verknüpft ist, wird seine sichtbare Farbe nach dem Themenwechsel rot. Ersetzen Sie die Themenfarbe durch eine direkte Farbe in der Form, wirken spätere Änderungen an `accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint erzeugt hellere und dunklere Varianten einer Themenfarbe durch Farbtransformationen. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/de/python-net/aspose.slides/colortransformoperation/) bereit.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Hauptthemenfarben.

**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt wurden.

Das folgende Beispiel erstellt sechs Rechtecke auf Basis von `ACCENT4`, wendet auf fünf von ihnen Luminanz‑Transformationen an und speichert das Ergebnis:

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

### **`SchemeColor`‑Werte den `ColorScheme`‑Slots zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/python-net/aspose.slides/schemecolor/) verwendet `TEXT1`, `BACKGROUND1`, `TEXT2` und `BACKGROUND2`, während [ColorScheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/colorscheme/) dieselben Themen‑Slots als `dark1`, `light1`, `dark2` und `light2` bereitstellt. Die Zuordnung ist fest:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Dies sind alternative Bezeichnungen für dieselben Themen‑Slots; es handelt sich nicht um Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Themen‑Schriften ändern**

Ein Themen‑Schriftenschema enthält einen Hauptschriftensatz für Überschriften und einen Minder­schriftensatz für Fließtext. Die Eigenschaften [FontScheme.major](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/fontscheme/major/) und [FontScheme.minor](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/fontscheme/minor/) stellen diese Sätze bereit.

PowerPoint‑kompatible Themen‑Schrift‑Kennungen können in der Textformatierung verwendet werden:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latin‑Themen­schrift verwendet, und eine Textzeile, die die Minder‑Latin‑Themen­schrift verwendet. Anschließend werden die Themen­schriften geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Hauptschrift und der Fließtext folgt der Minder‑schrift. Text, dem ein expliziter Schriftsname anstelle einer Themen‑Kennung zugewiesen wurde, wechselt nicht automatisch, wenn das Themen‑Schriftenschema geändert wird.

Die Haupt‑ und Minder‑Schriftensammlungen können außerdem Schrift‑Mappings für einzelne Schriftsysteme wie Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana enthalten. Zum Untersuchen, Hinzufügen, Ersetzen oder Entfernen dieser Mappings siehe [Script‑Specific Theme Fonts](/slides/de/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tipp" %}}
Weitere Informationen zu Präsentations­schriften finden Sie unter [PowerPoint Fonts](/slides/de/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Ein Thema kopieren oder anwenden**

Die nachfolgenden Workflows lösen verschiedene themenbezogene Probleme.

### **Ein externes Thema auf Folien anwenden, die von einem Master abhängen**

Verwenden Sie [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/), wenn Sie eine PowerPoint‑Themadatei (`.thmx`) besitzen und jede Folie neu gestalten möchten, die von einem bestimmten Master abhängt. Wählen Sie den Master aus der [Presentation.masters](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/masters/)‑Sammlung aus, die [MasterSlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/) implementiert, und übergeben Sie den Pfad zur Themadatei an die Methode.

Die Methode führt folgende Schritte aus:

1. Erstellt eine neue Master‑Folien‑Instanz basierend auf dem ausgewählten Master.  
2. Wendet das externe Thema auf den neuen Master an.  
3. Ordnet den neuen Master allen Folien zu, die zuvor vom ausgewählten Master abhingen.  
4. Gibt das neu erstellte [IMasterSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/imasterslide/) zurück.

Das folgende Beispiel wendet ein externes Thema auf die Folien an, die vom ersten Master abhängen, und speichert die Präsentation:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Ein ungültiges, beschädigtes oder nicht unterstütztes Thema kann [PptxException](https://reference.aspose.com/slides/de/python-net/aspose.slides/pptxexception/) oder eine seiner formatbezogenen Unterklassen auslösen. Validieren Sie von Benutzern bereitgestellte Pfade, behandeln Sie Zugriffsfehler auf das Dateisystem und speichern Sie die Präsentation erst, wenn das Thema erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhingen, werden neu zugeordnet. Folien, die anderen Mastern zugeordnet sind, behalten ihre bestehenden Master und Themen bei. Themen‑bewusste Farben, Schriften, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Thema aufgelöst. Direkt zugewiesene Farben, Schriften, Füllungen und andere explizite Formatierungen können unverändert bleiben. Überschreibungen auf Layout‑ und Folienebene können ebenfalls Vorrang vor Werten haben, die vom neuen Master geerbt wurden.

Das Thema kann Schriften referenzieren, die zur Laufzeit nicht verfügbar sind. Für konsistente Darstellung und Export installieren Sie die benötigten Schriften, stellen Sie sie über [custom font sources](/slides/de/python-net/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/python-net/font-substitution/).

Dies ist ein direkter Master‑Level‑Workflow: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert keine manuelle Erstellung von Folien‑ oder Layout‑Themen‑Überschreibungen.

### **Verschiedene externe Themen in einer Mehr‑Master‑Präsentation anwenden**

Wenn der relevante Master nicht im Voraus bekannt ist, ermitteln Sie ihn über eine repräsentative Folie mittels [Slide.layout_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/layout_slide/) und [LayoutSlide.master_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/master_slide/). Bewahren Sie die ursprünglichen Master‑Referenzen auf, bevor Sie Themen anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erzeugt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, ermittelt deren Master und wendet jedem Gruppe ein unterschiedliches externes Thema an:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")
            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

Der erste Aufruf wirkt nur auf Folien, die von `first_group_master` abhingen, der zweite Aufruf nur auf Folien, die von `second_group_master` abhingen. Folien, die zu einem anderen Master gehören, bleiben unverändert.

### **Ein Quell‑Thema beim Verschieben von Folien erhalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und dabei ihr ursprüngliches Design beibehalten, klonen Sie den Quell‑Master in die Zielpräsentation mit [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/add_clone/), klonen Sie anschließend die Folie mit [SlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/) und dem geklonten Master. Damit werden Master, Layouts und das zugehörige Thema zusammen übertragen.

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

Dies ist der empfohlene Workflow, wenn die Quell‑Folie im Ziel exakt gleich aussehen soll. Das bloße Klonen von Inhalten auf einen fremden Ziel‑Master kann themen‑basierte Farben, Schriften, Hintergründe und Effekte ändern.

### **Themenwerte auf einer bestehenden Folie anwenden**

Möchten Sie, dass die Ziel‑Folie ihren aktuellen Master und ihr aktuelles Layout beibehält, initialisieren Sie eine Folien‑Überschreibung aus dem Quell‑Thema. Die Methoden [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) und [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) kopieren die drei Haupt‑Themenkomponenten in die Überschreibung.

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

### **Ein Themen‑Override auf ein Layout anwenden**

Ein Layout‑Level‑Override gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie nicht ihre eigene Überschreibung hat. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/layoutslidethememanager/) des Layouts verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe Basis‑Design teilen sollen, ein Layout‑Override, wenn eine Layout‑Familie ein abweichendes Styling benötigt, und ein Folien‑Override nur für echte Ausnahmen. Übermäßige Folien‑Overrides erschweren die Vorhersagbarkeit späterer globaler Themenänderungen.

## **Themen‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themas werden in [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) gespeichert. PowerPoint kann im UI mehr Hintergrundoptionen anbieten, als physisch in dieser Sammlung definiert sind, weil das UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, untersuchen Sie die gespeicherte Sammlung und den aktuellen [Background.style_index](https://reference.aspose.com/slides/de/python-net/aspose.slides/background/style_index/). `style_index` verwendet `0` für keine themenbasierte Füllung; positive Werte sind Referenzen auf themenbasierte Hintergrundstile. Das unterscheidet sich vom Indexieren einer Python‑Sammlung, bei dem `[0]` das erste Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl an Hintergrund‑Füllstilen enthält.

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

Das sichtbare Ergebnis hängt vom vom Master referenzierten Themen‑Eintrag sowie von etwaigen Hintergrund‑Überschreibungen auf Layout‑ oder Folienebene ab. Verwendet eine Folie ihr eigenes Hintergrundformat, ändert das Aktualisieren des Master‑Hintergrunds diese Folie möglicherweise nicht. Verwenden Sie [Background.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/background/get_effective/), wenn Sie den endgültigen Hintergrund nach angewandter Vererbung wissen müssen.

{{% alert color="warning" title="Warnung" %}}
Behandeln Sie `style_index` nicht als nullbasierten Sammlungs‑Index. Vermeiden Sie außerdem das Hard‑Coden einer Stilnummer aus einer Datei und die Annahme, dass sie in einer anderen Datei das gleiche Aussehen hat; Themen‑Stil‑Definitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Tipp" %}}
Für direkte Hintergrundformatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/python-net/presentation-background/).
{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Format‑Schema enthält separate Sammlungen [FormatScheme.fill_styles](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/line_styles/) und [FormatScheme.effect_styles](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/effect_styles/). Typische Office‑Themen enthalten oft drei Haupteinträge, die visuell subtil, moderat und intensiv formatiert sind, aber der Code sollte jede Sammlung prüfen, anstatt von einer festen Anzahl auszugehen.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Wenn Sie in Python auf diese Sammlungen zugreifen, ist der Sammlungs‑Index nullbasiert: `[0]` ist der erste gespeicherte Stil und `[2]` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/de/python-net/aspose.slides/ishapestyle/) bereitgestellt wird. Das Ändern eines Themen‑Stils wirkt sich auf Formen aus, die diesen Themen‑Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die erforderlichen Stil‑Einträge existieren, ändert den ersten Linienstil, ändert den dritten Füllstil, aktiviert einen äußeren Schatten im dritten Effekt‑Stil und speichert das Ergebnis:

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

Für Formen, die diese Slots referenzieren, wird der erste Themen‑Linienstil rot, der dritte Themen‑Füllstil zu einem satten Waldgrün und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einem Abstand von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Slots jede Form referenziert und ob direkte Formatierung die Themen‑Werte überschreibt.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Effektive Themenwerte auslesen**

Roh‑Themen‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich verwendet, nachdem Vererbung und lokale Überschreibungen aufgelöst wurden. Für eine Folie rufen Sie [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) auf. Für einen Hintergrund verwenden Sie [Background.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/background/get_effective/), und für eine Füllung [FillFormat.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/fillformat/get_effective/).

Das folgende Beispiel liest das effektive Thema, den Hintergrund und die Füllung der ersten Form von einer Folie aus:

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

Verwenden Sie effektive Daten für Render‑Diagnosen, Validierung und Vergleiche. Wenn Sie ausschließlich [Presentation.master_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/master_theme/) untersuchen, können Sie einen Master-, Layout‑, Folien‑ oder Form‑Override übersehen, der das endgültige Erscheinungsbild ändert.

## **FAQ**

**Wirkt das Anwenden eines externen Themas auf jede Folie der Präsentation?**

Nein. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) weist nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master verwenden, behalten ihre bestehenden Themen bei.

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/slidethememanager/) der Folie und initialisieren Sie dessen Override‑Thema. Die Änderung bleibt lokal zu dieser Folie; andere Folien erben weiterhin ihre bestehenden Themen.

**Wie übertrage ich ein Thema am sichersten von einer Präsentation in eine andere?**

Beim Verschieben einer Folie und Beibehalten ihres Quell‑Designs klonen Sie den Quell‑Master in das Ziel und klonen die Folie mit diesem Master mittels [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/add_clone/) und [SlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/). So bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Overrides sehen?**

Verwenden Sie [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) für ein Folien‑ oder Layout‑Thema und die entsprechenden effektiven‑Daten‑Methoden für Format‑Objekte wie [Background.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/background/get_effective/) und [FillFormat.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/fillformat/get_effective/). Diese APIs geben die nach Vererbung und Overrides aufgelösten Werte zurück.