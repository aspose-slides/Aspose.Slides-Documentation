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
- zusätzliche Farbpalette
- Themen-Schriftart
- Themenstil
- Themen-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für Python über .NET, um PowerPoint-Dateien mit einheitlichem Branding zu erstellen, anzupassen und zu konvertieren."
---
## **Einführung**

Ein Präsentationsthema definiert ein koordiniertes Set von Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Themen‑bewusste Objekte verweisen auf diese geteilten Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass ein Themenwechsel viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das Präsentations‑Thema über die [Presentation.master_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/master_theme/)‑Eigenschaft verfügbar. Eine Präsentation kann zudem Themen‑Überschreibungen auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.override_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/masterthememanager/override_theme/) überschreiben, ein Layout kann sein geerbtes Thema über [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) überschreiben, und eine einzelne Folie kann dasselbe tun. In der Praxis wird das effektive Thema für eine Folie über diese Vererbungskette aufgelöst: Präsentationsthema, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Themen‑Komponenten: Farben, Schriftarten, Hintergrundstile und Effekte](theme-constituents.png)

Die folgenden Abschnitte zeigen die gebräuchlichsten Arbeitsabläufe zum Thema: ein Thema untersuchen, Farben und Schriftarten ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Vererbung und Überschreibungen auslesen.

## **Ein Thema untersuchen**

Das [MasterTheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/mastertheme/)‑Objekt stellt die Eigenschaften [color_scheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/mastertheme/font_scheme/) und [format_scheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/mastertheme/format_scheme/) des Themas bereit. Das Untersuchen dieser Sammlungen, bevor sie geändert werden, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, da die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die wichtigsten Themen‑Eigenschaften aus und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Thema gespeichert sind:

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

Verwendet eine Datei mehrere Master, sollte man nicht davon ausgehen, dass jede Folie dasselbe effektive Thema hat. Untersuchen Sie den Master, der der Folie zugeordnet ist, und verwenden Sie den später in diesem Artikel gezeigten Workflow für das effektive Thema, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein könnten.

## **Themen‑Farben ändern**

Themen‑bewusste Füllungen, Linien und Texte können auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/python-net/aspose.slides/schemecolor/) verweisen. Ändert man den entsprechenden Eintrag im [ColorScheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/colorscheme/) des Themas, werden alle Objekte, die noch auf diese Themenfarbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch ein Update der Themenfarbe nicht verändert.

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

Da das Rechteck weiterhin mit `ACCENT4` verknüpft ist, wird seine sichtbare Farbe nach der Themenänderung Rot. Ersetzt man die Themenfarbe durch eine direkte Farbe in der Form, beeinflussen spätere Änderungen von `accent4` diese Füllung nicht mehr.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten von einer Themenfarbe ab, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/de/python-net/aspose.slides/colortransformoperation/) bereit.

![Hauptthemenfarben und hellere sowie dunklere Farben, die aus der zusätzlichen Palette erzeugt werden](additional-palette-colors.png)

**1** – Hauptthemenfarben.  
**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt werden.

Das folgende Beispiel erstellt sechs Rechtecke basierend auf `ACCENT4`, wendet Luminanz‑Transformationen auf fünf davon an und speichert das Ergebnis:

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

Diese Varianten bleiben an die Themenfarbe gebunden. Ändert sich später `accent4`, werden die transformierten Farben aus dem neuen `accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `ColorScheme`‑Plätzen zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/python-net/aspose.slides/schemecolor/) verwendet `TEXT1`, `BACKGROUND1`, `TEXT2` und `BACKGROUND2`, während [ColorScheme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/colorscheme/) dieselben Themenplätze als `dark1`, `light1`, `dark2` und `light2` bereitstellt. Die Zuordnung ist fest:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Dies sind alternative Namen für dieselben Themenplätze; sie sind keine Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Themen‑Schriftarten ändern**

Ein Themen‑Schriftartenschema enthält einen Hauptschriftartensatz für Überschriften und einen Nebensatz für Fließtext. Die Eigenschaften [FontScheme.major](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/fontscheme/major/) und [FontScheme.minor](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/fontscheme/minor/) stellen diese Sätze bereit.

PowerPoint‑kompatible Themen‑Schriftart‑Bezeichner können in der Textformatierung verwendet werden:

* `+mn‑lt` – Body Font Latin (Minor Latin Font)
* `+mj‑lt` – Heading Font Latin (Major Latin Font)
* `+mn‑ea` – Body Font East Asian (Minor East Asian Font)
* `+mj‑ea` – Heading Font East Asian (Major East Asian Font)

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

Die Überschrift folgt der Hauptschriftart und der Fließtext folgt der Nebenschriftart. Text, dem ein expliziter Schriftartname statt eines Themen‑Bezeichners zugewiesen ist, wechselt nicht automatisch, wenn sich das Themen‑Schriftartenschema ändert.

Die Haupt‑ und Nebenschriftartensammlungen können zudem Schriftart‑Zuordnungen für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Untersuchen, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tipp" %}}
Weitere Informationen zu Präsentations‑Schriftarten finden Sie unter [PowerPoint Fonts](/slides/de/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Ein Thema kopieren oder anwenden**

Die nachfolgenden Arbeitsabläufe lösen unterschiedliche themenbezogene Probleme.

### **Ein externes Thema auf die Folien eines Masters anwenden**

Verwenden Sie [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/), wenn Sie eine PowerPoint‑Themen‑Datei (`.thmx`) besitzen und jede Folie, die von einem bestimmten Master abhängt, neu gestalten möchten. Wählen Sie den Master aus der [Presentation.masters](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/masters/)‑Sammlung aus, die [MasterSlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/) implementiert, und übergeben Sie den Pfad zur Themen‑Datei an die Methode.

Die Methode führt folgende Schritte aus:

1. Erstellt eine neue Master‑Folie basierend auf dem ausgewählten Master.  
1. Wendet das externe Thema auf den neuen Master an.  
1. Ordnet den neuen Master allen Folien zu, die zuvor vom ausgewählten Master abhingen.  
1. Gibt das neu erstellte [IMasterSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/imasterslide/) zurück.

Das folgende Beispiel wendet ein externes Thema auf die Folien an, die vom ersten Master abhängen, und speichert die Präsentation:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Ein ungültiges, beschädigtes oder nicht unterstütztes Thema kann eine [PptxException](https://reference.aspose.com/slides/de/python-net/aspose.slides/pptxexception/) oder eine ihrer formatbezogenen Unterklassen auslösen. Validieren Sie vom Benutzer bereitgestellte Pfade, behandeln Sie Dateisystem‑Zugriffsfehler und speichern Sie die Präsentation erst, nachdem das Thema erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhingen, werden neu zugeordnet. Folien, die anderen Mastern zugeordnet sind, behalten ihre bestehenden Master und Themen. Themen‑bewusste Farben, Schriftarten, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Thema aufgelöst. Direkt zugewiesene Farben, Schriftarten, Füllungen und andere explizite Formatierungen können unverändert bleiben. Überschreibungen auf Layout‑ und Folien‑Ebene können ebenfalls Vorrang vor den vom neuen Master geerbten Werten haben.

Das Thema kann Schriftarten referenzieren, die in der Laufzeitumgebung nicht verfügbar sind. Für konsistentes Rendering und Export installieren Sie die benötigten Schriftarten, stellen Sie sie über [custom font sources](/slides/de/python-net/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/python-net/font-substitution/).

Dies ist ein reiner Master‑Level‑Workflow: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert keine manuelle Erstellung von Layout‑ oder Folien‑Themen‑Überschreibungen.

### **Verschiedene externe Themen in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master nicht im Voraus bekannt ist, ermitteln Sie ihn über eine repräsentative Folie mittels [Slide.layout_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/layout_slide/) und [LayoutSlide.master_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/layoutslide/master_slide/). Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Themen anwenden, da jeder Aufruf einen weiteren Master in die Präsentation einfügt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, ermittelt deren Master und wendet ein unterschiedliches externes Thema auf jede Gruppe an:

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

Der erste Aufruf betrifft nur Folien, die von `first_group_master` abhingen, der zweite Aufruf betrifft nur Folien, die von `second_group_master` abhingen. Folien, die zu anderen Mastern gehören, werden nicht neu gestaltet.

### **Ein Quell‑Thema beim Verschieben von Folien beibehalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und ihr ursprüngliches Design beibehalten, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/add_clone/), klonen Sie anschließend die Folie mit [SlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/) und dem geklonten Master. Damit werden Master, seine Layouts und das zugehörige Thema gemeinsam übertragen.

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

Dies ist der bevorzugte Workflow, wenn die Quell‑Folie im Ziel exakt gleich aussehen soll. Das reine Kopieren von Inhalten auf einen fremden Ziel‑Master kann themen‑gesteuerte Farben, Schriftarten, Hintergründe und Effekte ändern.

### **Themen‑Werte auf eine bestehende Folie anwenden**

Muss die Ziel‑Folie ihren aktuellen Master und ihr Layout behalten, initialisieren Sie eine Folien‑Überschreibung aus dem Quell‑Thema. Die Methoden [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) und [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) kopieren die drei Haupt‑Themenkomponenten in die Überschreibung.

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

Eine Layout‑Überschreibung gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie nicht ihre eigene Überschreibung besitzt. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/layoutslidethememanager/) des Layouts verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe Grunddesign teilen sollen, eine Layout‑Überschreibung, wenn eine Layout‑Familie ein abweichendes Styling benötigt, und eine Folien‑Überschreibung nur für echte Ausnahmen. Übermäßige Folien‑Überschreibungen erschweren spätere globale Themenänderungen.

## **Themen‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen eines Themas werden in [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) gespeichert. PowerPoint kann in seiner Benutzeroberfläche mehr Hintergrundoptionen anzeigen, als physisch in dieser Sammlung definiert sind, weil die UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrund‑Stilgalerie für ein Präsentationsthema](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, untersuchen Sie die gespeicherte Sammlung und den aktuellen [Background.style_index](https://reference.aspose.com/slides/de/python-net/aspose.slides/background/style_index/). `style_index` verwendet `0` für keine themenbasierte Füllung; positive Werte sind Referenzen zu Themen‑Hintergrund‑Stilen. Das unterscheidet sich von der Indexierung einer Python‑Sammlung, bei der `[0]` das erste Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl von Hintergrund‑Füllstilen enthält.

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

Das sichtbare Ergebnis hängt vom vom Master referenzierten Themen‑Eintrag sowie von etwaigen Hintergrund‑Überschreibungen im Layout oder auf Folienebene ab. Verwendet eine Folie einen eigenen Hintergrund, ändert möglicherweise nur das Master‑Hintergrund nicht diese Folie. Nutzen Sie [Background.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/background/get_effective/), wenn Sie den endgültigen Hintergrund nach angewandter Vererbung ermitteln müssen.

{{% alert color="warning" title="Warnung" %}}
Behandeln Sie `style_index` nicht als nullbasierten Sammlungs‑Index. Vermeiden Sie außerdem, eine Stil‑Nummer aus einer Datei zu hard‑coden und anzunehmen, dass sie in einer anderen Datei das gleiche Aussehen hat; Themen‑Stil‑Definitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Tipp" %}}
Für direkte Hintergrund‑Formatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/python-net/presentation-background/).
{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Format‑Schema enthält separate Sammlungen für [FormatScheme.fill_styles](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/line_styles/) und [FormatScheme.effect_styles](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/formatscheme/effect_styles/). Typische Office‑Themen enthalten oft drei Haupteinträge, die visuell subtilen, moderaten und intensiven Formatierungen entsprechen, aber der Code sollte jede Sammlung prüfen, anstatt von einer festen Anzahl auszugehen.

![Subtile, moderate und intensive Themen‑Effekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Greift man in Python auf diese Sammlungen zu, ist der Index nullbasiert: `[0]` ist der erste gespeicherte Stil, `[2]` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/de/python-net/aspose.slides/ishapestyle/) offengelegt wird. Ändert man einen Themen‑Stil, wirken sich die Änderungen auf Formen aus, die diesen Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die erforderlichen Stileinträge existieren, ändert den ersten Linienstil, den dritten Füllstil, aktiviert einen äußeren Schatten im dritten Effektstil und speichert das Ergebnis:

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

Für Formen, die diese Plätze referenzieren, wird der erste Themen‑Linienstil rot, der dritte Themen‑Füllstil zu einem soliden Waldgrün und der dritte Effektstil erhält einen äußeren Schatten mit einer Distanz von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Plätze jede Form referenziert und ob direkte Formatierung den Themen‑Stil überschreibt.

![Themen‑Effekt‑Stile nach Änderung von Linie, Füllung und Schatteneinstellungen](presentation-design_11.png)

## **Ermitteln, ob eine effektive einfarbige Füllung eine Themenfarbe verwendet**

Eine Füllung kann direkt auf einem Objekt gespeichert oder von einem Absatz, Layout, Master, Themen‑Stil oder einer anderen Formatierungsebene geerbt werden. Rufen Sie [FillFormat.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/fillformat/get_effective/) auf, um diese Hierarchie in ein unveränderliches [IFillFormatEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/ifillformateffectivedata/) aufzulösen. Prüfen Sie zuerst [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/ifillformateffectivedata/fill_type/). Nur wenn es `FillType.SOLID` ist, sollten Sie die einfarbigen Füll‑Eigenschaften auslesen.

Für eine einfarbige Füllung liefert [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/de/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) den endgültigen gerenderten RGB‑Wert nach Vererbung, Themen‑Lookup und Farb‑Transformationen. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/de/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) gibt den entsprechenden logischen [SchemeColor](https://reference.aspose.com/slides/de/python-net/aspose.slides/schemecolor/)‑Platz zurück, z. B. `TEXT1` oder `ACCENT6`. Ein Wert von `SchemeColor.NOT_DEFINED` bedeutet, dass die effektive einfarbige Füllung nicht auf einer Scheme‑Farbe basiert. In einem Workflow, bei dem Füllungen entweder Themen‑Farben oder direkte RGB‑Farben sind, identifiziert dieser Wert eine direkte RGB‑Füllung.

Verwenden Sie nicht allein den lokalen [IColorFormat.scheme_color](https://reference.aspose.com/slides/de/python-net/aspose.slides/icolorformat/scheme_color/)‑Wert, um eine Füllung zu klassifizieren. Ein Textanteil kann beispielsweise keinen lokal definierten Scheme‑Farbwert besitzen, sodass sein lokaler Wert `NOT_DEFINED` ist, während seine effektive Füllung eine Themenfarbe erbt und zu `TEXT1` oder `ACCENT6` aufgelöst wird. Im Gegenzug gibt `solid_fill_scheme_color` an, welcher logische Themen‑Platz die effektive Farbe erzeugt hat, jedoch nicht, aus welcher Ebene (Objekt, Absatz, Layout, Master usw.) dieser Platz stammt.

Das folgende Beispiel lädt eine Präsentation, prüft sowohl Formen‑Füllungen als auch Text‑Abschnitts‑Füllungen, gibt jeweils den finalen RGB‑Wert und die zugehörige Scheme‑Farbe aus und markiert einfarbige Füllungen, die Theme‑Farbänderungen nicht folgen:

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

Der `NOT_DEFINED`‑Zweig liefert eine Prüf‑Liste einfarbiger Füllungen, die nicht auf Änderungen von Themen‑Farbplätzen reagieren. Überprüfen Sie diese Objekte, wenn eine Präsentation einer neuen Marken‑Palette folgen muss. Der gemeldete RGB‑Wert zeigt weiterhin das aktuelle Aussehen, während der Scheme‑Wert erklärt, ob dieses Aussehen mit dem Thema verbunden ist.

Effektive Format‑Objekte sind Momentaufnahmen. Nach einer Änderung des Präsentations‑Themas, einer Themen‑Überschreibung oder irgendeiner geerbten Formatierung rufen Sie erneut `get_effective` auf und lesen ein neues `IFillFormatEffectiveData`‑Objekt, bevor Sie Farben vergleichen oder berichten.

## **Effektive Themen‑Werte auslesen**

Roh‑Themen‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich nach Vererbung und lokalen Überschreibungen verwendet. Für eine Folie rufen Sie [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) auf. Für einen Hintergrund verwenden Sie [Background.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/background/get_effective/), und für eine Füllung [FillFormat.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/fillformat/get_effective/).

Das folgende Beispiel liest das effektive Thema, den Hintergrund und die erste Form‑Füllung einer Folie aus:

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

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation.master_theme](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/master_theme/) untersuchen, können Sie einen Master‑, Layout‑, Folien‑ oder Form‑Überschreibung übersehen, die das endgültige Erscheinungsbild ändert.

## **FAQ**

**Hat das Anwenden eines externen Themas Auswirkungen auf jede Folie der Präsentation?**

Nein. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) ordnet nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master verwenden, behalten ihre bestehenden Themen.

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/slidethememanager/) der Folie und initialisieren Sie dessen Überschreibungsthema. Die Änderung bleibt auf diese Folie beschränkt; andere Folien erben weiterhin ihre bestehenden Themen.

**Wie übertrage ich ein Thema sicher von einer Präsentation in eine andere?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Aussehen bewahren möchten, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master mittels [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/masterslidecollection/add_clone/) und [SlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/). Dadurch bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Überschreibungen einsehen?**

Verwenden Sie [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) für ein Folien‑ oder Layout‑Thema und die entsprechenden effektiven‑Daten‑Methoden für Format‑Objekte wie [Background.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/background/get_effective/) und [FillFormat.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/fillformat/get_effective/). Diese APIs geben die aufgelösten Werte nach angewandter Vererbung und Überschreibungen zurück.