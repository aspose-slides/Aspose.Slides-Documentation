---
title: PowerPoint-Präsentationsthemen in Python verwalten
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/python-net/presentation-theme/
keywords:
- PowerPoint-Theme
- Präsentationstheme
- Folientheme
- Theme festlegen
- Theme ändern
- Theme verwalten
- Externes Theme
- THMX
- Themefarbe
- Zusätzliche Palette
- Theme-Schriftart
- Theme-Stil
- Theme-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für Python über .NET erstellen, anpassen und PowerPoint-Dateien mit einheitlichem Branding konvertieren."
---
## **Einführung**

Ein Präsentationsthema definiert einen koordinierten Satz von Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Themenbewusste Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass eine Themenänderung viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das Präsentations‑Theme über die Eigenschaft [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) verfügbar. Eine Präsentation kann zudem Theme‑Überschreibungen auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationstheme über [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/) überschreiben, ein Layout kann sein geerbtes Theme über [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) überschreiben, und eine einzelne Folie kann dasselbe tun. In der Praxis wird das effektive Theme für eine Folie über diese Vererbungskette aufgelöst: Präsentationstheme, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Theme‑Komponenten: Farben, Schriftarten, Hintergrundstile und Effekte](theme-constituents.png)

Die folgenden Abschnitte zeigen die gängigsten Theme‑Workflows: ein Theme untersuchen, Farben und Schriftarten ändern, ein Theme kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Vererbung und Überschreibungen auslesen.

## **Ein Theme untersuchen**

Das Objekt [MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) stellt die Eigenschaften [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/) und [format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/) des Themes bereit. Das Untersuchen dieser Sammlungen, bevor sie geändert werden, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, da die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Themes und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Theme gespeichert sind:

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

Verwendet eine Datei mehrere Master, darf nicht davon ausgegangen werden, dass jede Folie dasselbe effektive Theme hat. Untersuchen Sie den dem Folienmaster zugehörigen Master und verwenden Sie den später gezeigten effektiven‑Theme‑Workflow, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein können.

## **Theme‑Farben ändern**

Themenbewusste Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag in der [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) des Themes ändern, werden alle Objekte, die noch auf diese Theme‑Farbe verweisen, anhand des neuen Werts aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch eine Theme‑Farb‑Aktualisierung nicht geändert.

Das folgende End‑to‑End‑Beispiel erstellt eine Form, die `ACCENT4` verwendet, ändert die Theme‑Farbe `accent4` zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die effektive Füllfarbe aus:

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

Da das Rechteck weiterhin mit `ACCENT4` verknüpft ist, wird seine sichtbare Farbe nach der Theme‑Änderung Rot. Wenn Sie die Scheme‑Color durch eine direkte Farbe in der Form ersetzen, wirken spätere Änderungen an `accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten von einer Theme‑Farbe ab, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/) bereit.

![Haupt‑Theme‑Farben sowie hellere und dunklere Farben, die aus der zusätzlichen Palette erzeugt wurden](additional-palette-colors.png)

**1** – Haupt‑Theme‑Farben.  
**2** – Hellere und dunklere Varianten, die aus den Haupt‑Theme‑Farben erzeugt wurden.

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

Diese Varianten bleiben auf der Theme‑Farbe basierend. Ändert sich später `accent4`, werden die transformierten Farben aus dem neuen `accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `ColorScheme`‑Slots zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) verwendet `TEXT1`, `BACKGROUND1`, `TEXT2` und `BACKGROUND2`, während [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) die gleichen Theme‑Slots als `dark1`, `light1`, `dark2` und `light2` bereitstellt. Die Zuordnung ist fest:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Dies sind alternative Bezeichnungen für dieselben Theme‑Slots; sie sind keine Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Theme‑Schriftarten ändern**

Ein Theme‑Schriftartenschema enthält einen Hauptschriftartensatz für Überschriften und einen Neben‑schriftartensatz für Fließtext. Die Eigenschaften [FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) und [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) stellen diese Sätze bereit.

PowerPoint‑kompatible Theme‑Schriftart‑Bezeichner können in der Textformatierung verwendet werden:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)
* `+mn-cs` – Body Font Complex Script (Minor Complex Script Font)
* `+mj-cs` – Heading Font Complex Script (Major Complex Script Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latin‑Theme‑Schrift verwendet, und eine Fließtextzeile, die die Neben‑Latin‑Theme‑Schrift verwendet. Anschließend werden die Theme‑Schriftarten geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Hauptschriftart und der Fließtext der Neben‑schriftart. Text, dem ein expliziter Schriftartname statt eines Theme‑Bezeichners zugewiesen ist, wechselt nicht automatisch, wenn sich das Theme‑Schriftartenschema ändert.

Die Haupt‑ und Neben‑Schriftartensammlungen können zudem Schriftartenzuordnungen für einzelne Schriftsysteme enthalten, etwa Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Untersuchen, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Weitere Informationen zu Präsentations‑Schriftarten finden Sie unter [PowerPoint Fonts](/slides/de/python-net/powerpoint-fonts/).
{{% /alert %}}

### **Theme‑Schriftart‑Referenzen auflösen**

Beim Untersuchen von Text kann [FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) eine Theme‑Referenz wie `+mn-lt` anstelle eines Schriftfamiliennamens enthalten. Rufen Sie [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) mit dem passenden [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/) auf, um diese Referenz aufzulösen. Die Präfixe `+mj` und `+mn` wählen den Haupt‑ bzw. Neben‑Schriftartensatz; die Suffixe `-lt`, `-ea` und `-cs` wählen jeweils die Latin‑, East‑Asian‑ bzw. Complex‑Script‑Schrift.

Ermitteln Sie das effektive Theme über [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) am Objekt, dessen Theme auf den untersuchten Text angewendet wird. Für normalen Text auf einer Folie verwenden Sie `slide.create_theme_effective`, sodass der Kontext das geerbte Theme der Folie und lokale Overrides enthält. Beim Untersuchen eines Layouts oder Masters verwenden Sie dessen eigenes effektives Theme. Gehen Sie nicht davon aus, dass das Theme des ersten Masters für alle Folien gilt.

Das folgende Beispiel erstellt einen Textabschnitt, der explizit die Neben‑Latin‑Schrift referenziert. Es initialisiert ein Folien‑Schriftartenschema über [OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) und setzt die Haupt‑ und Neben‑Latin‑Familien auf `Arial` bzw. `Calibri`, sodass das Ergebnis reproduzierbar ist, ohne eine Eingabedatei zu benötigen:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    theme = slide.theme_manager.override_theme
    theme.init_font_scheme_from_inherited()
    theme.font_scheme.major.latin_font = slides.FontData("Arial")
    theme.font_scheme.minor.latin_font = slides.FontData("Calibri")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Text using the minor theme font"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.latin_font = slides.FontData("+mn-lt")

    font = portion.portion_format.latin_font
    effective_theme = slide.create_theme_effective()
    print(f"{font.font_name} -> {font.get_font_name(effective_theme)}")

    explicit_font = slides.FontData("Verdana")
    print(f"{explicit_font.font_name} -> {explicit_font.get_font_name(effective_theme)}")
```

Die Ausgabe ist `+mn-lt -> Calibri` gefolgt von `Verdana -> Verdana`. Die gespeicherte Referenz bleibt unverändert, während ein expliziter Familienname unverändert zurückgegeben wird. Würde der Abschnitt `+mj-lt` verwenden, würde er in diesem Theme zu `Arial` aufgelöst werden.

Das Auflösen einer Theme‑Referenz ermittelt die durch das Theme angegebene Schriftfamilie. Es wird nicht geprüft, ob die Schriftart tatsächlich verfügbar ist oder welche Schriftdatei letztlich nach Substitution oder Glyph‑Fallback beim Rendern verwendet wird. Siehe [Font Selection Sequence](/slides/de/python-net/font-selection-sequence/) und [Font Substitution](/slides/de/python-net/font-substitution/) für diese separaten Schritte.

## **Ein Theme kopieren oder anwenden**

Die nachfolgenden Workflows lösen verschiedene Theme‑bezogene Probleme.

### **Ein externes Theme auf die von einem Master abhängigen Folien anwenden**

Verwenden Sie [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/), wenn Sie eine PowerPoint‑Theme‑Datei (`.thmx`) haben und jede Folie, die von einem bestimmten Master abhängt, neu stylen möchten. Wählen Sie den Master aus der Sammlung [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) ([MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)) und übergeben Sie den Pfad zur Theme‑Datei an die Methode.

Die Methode führt folgende Schritte aus:

1. Erstellt einen neuen Master‑Slide basierend auf dem ausgewählten Master.  
2. Wendet das externe Theme auf den neuen Master an.  
3. Ordnet den neuen Master allen Folien zu, die zuvor vom ausgewählten Master abhingen.  
4. Gibt den neu erstellten [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) zurück.

Das folgende Beispiel wendet ein externes Theme auf die Folien an, die vom ersten Master abhängen, und speichert die Präsentation:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Ein ungültiges, beschädigtes oder nicht unterstütztes Theme kann zu einem [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) oder einer seiner formatbezogenen Unterklassen führen. Validieren Sie von Benutzern übermittelte Pfade, behandeln Sie Zugriffsfehler auf das Dateisystem und speichern Sie die Präsentation erst, nachdem das Theme erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhingen, werden neu zugeordnet. Folien, die anderen Mastern zugeordnet sind, behalten ihre bestehenden Master und Themes. Themenbewusste Farben, Schriftarten, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Theme aufgelöst. Direkt zugewiesene Farben, Schriftarten, Füllungen und andere explizite Formatierungen können unverändert bleiben. Overrides auf Layout‑ und Folien‑Ebene können ebenfalls Vorrang vor Werten haben, die vom neuen Master geerbt wurden.

Das Theme kann Schriftarten referenzieren, die nicht in der Laufzeitumgebung verfügbar sind. Für konsistentes Rendering und Export installieren Sie die erforderlichen Schriftarten, stellen sie über [custom font sources](/slides/de/python-net/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/python-net/font-substitution/).

Dies ist ein direkter Master‑Level‑Workflow: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert kein manuelles Erstellen von Theme‑Overrides auf Folien‑ oder Layout‑Ebene.

### **Verschiedene externe Themes in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master nicht im Voraus bekannt ist, ermitteln Sie ihn über eine repräsentative Folie mit [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) und [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/). Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Themes anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erzeugt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, ermittelt deren Master und wendet jedem Teil ein anderes externes Theme an:

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

Der erste Aufruf betrifft nur Folien, die von `first_group_master` abhingen, der zweite Aufruf nur Folien, die von `second_group_master` abhingen. Folien, die zu anderen Mastern gehören, werden nicht neu gestylt.

### **Ein Quell‑Theme beim Verschieben von Folien erhalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und dabei das ursprüngliche Design beibehalten, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/), dann klonen Sie die Folie zusammen mit dem geklonten Master über [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/). Damit werden der Master, seine Layouts und das zugehörige Theme gemeinsam übertragen.

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

Dies ist der bevorzugte Workflow, wenn die Quell‑Folie im Ziel genauso aussehen soll. Das reine Klonen von Inhalt auf einen nicht zugehörigen Ziel‑Master kann Theme‑gesteuerte Farben, Schriftarten, Hintergründe und Effekte ändern.

### **Theme‑Werte auf einer bestehenden Folie anwenden**

Muss die Ziel‑Folie ihren aktuellen Master und ihr Layout behalten, initialisieren Sie ein Folien‑Level‑Override aus dem Quell‑Theme. Die Methoden [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) und [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) kopieren die drei Haupt‑Theme‑Komponenten in das Override.

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

Damit wird das von dieser Folie verwendete Theme geändert, ohne das von anderen Folien geerbte Theme zu beeinflussen. Um das lokale Override zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/) auf.

### **Ein Theme‑Override auf ein Layout anwenden**

Ein Layout‑Level‑Override gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie nicht ihr eigenes Override besitzt. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/) des Layouts genutzt werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Theme, wenn viele Layouts und Folien dasselbe Grunddesign teilen sollen, ein Layout‑Override, wenn eine Layout‑Familie ein abweichendes Styling benötigt, und ein Folien‑Override nur für wahre Ausnahmen. Übermäßige Folien‑Overrides erschweren später die Vorhersagbarkeit globaler Theme‑Änderungen.

## **Theme‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themes werden in [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) gespeichert. PowerPoint kann in seiner Benutzeroberfläche mehr Hintergrund‑Optionen anzeigen, als tatsächlich in dieser Sammlung definiert sind, weil die UI Theme‑Füllungen mit Theme‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrund‑Stil‑Galerie für ein Präsentations‑Theme](presentation-design_8.png)

Bevor Sie einen Hintergrund‑Stil verwenden, untersuchen Sie die gespeicherte Sammlung und den aktuellen [Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/). `style_index` verwendet `0` für keine themenbasierte Füllung; positive Werte sind Referenzen auf Theme‑Hintergrund‑Stile. Das unterscheidet sich von der Indexierung einer Python‑Sammlung, bei der `[0]` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl von Hintergrund‑Füll‑Stilen enthält.

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

Das sichtbare Ergebnis hängt vom Theme‑Eintrag ab, auf den der Master verweist, sowie von etwaigen Hintergrund‑Overrides auf Layout‑ oder Folien‑Ebene. Verwendet eine Folie ihren eigenen Hintergrund, ändert das Ändern des Master‑Hintergrunds diese Folie möglicherweise nicht. Nutzen Sie [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/), wenn Sie das endgültige Hintergrund‑Ergebnis nach Anwendung der Vererbung wissen müssen.

{{% alert color="warning" title="Warning" %}}
Behandeln Sie `style_index` nicht als nullbasierten Sammlungsindex. Vermeiden Sie außerdem, eine Stil‑Nummer aus einer Datei hart zu codieren und anzunehmen, dass sie in einer anderen Datei dasselbe Aussehen hat; Theme‑Stil‑Definitionen sind präsentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Für direkte Hintergrund‑Formatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/python-net/presentation-background/).
{{% /alert %}}

## **Theme‑Effekte aktualisieren**

Ein Theme‑Format‑Schema enthält separate Sammlungen für [FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/) und [FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/). Typische Office‑Themes enthalten oft drei Haupt‑Stileinträge, die visuell subtil, moderat und intensiv formatiert sind, aber der Code sollte jede Sammlung prüfen, anstatt eine feste Anzahl anzunehmen.

![Subtile, moderate und intensive Theme‑Effekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Greifen Sie in Python auf diese Sammlungen zu, ist der Index nullbasiert: `[0]` ist der erste gespeicherte Stil, `[2]` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/) bereitgestellt wird. Das Ändern eines Theme‑Stils wirkt sich auf Formen aus, die diesen Theme‑Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die erforderlichen Stileinträge vorhanden sind, ändert den ersten Linien‑Stil, den dritten Füll‑Stil, aktiviert einen äußeren Schatten im dritten Effekt‑Stil und speichert das Ergebnis:

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

Für Formen, die diese Slots referenzieren, wird der erste Theme‑Linienstil Rot, der dritte Theme‑Füllstil zu einem soliden Waldgrün, und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einem Abstand von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Slots jede Form referenziert und ob direkte Formatierung den Theme‑Wert überschreibt.

![Theme‑Effekt‑Stile nach Änderung von Linie, Füllung und Schatten‑Einstellungen](presentation-design_11.png)

## **Theme‑Füll‑ und Linien‑Stile für eine Form auswählen**

Eine Form kann ihre Füllung und Kontur unabhängig voneinander über [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) bzw. [ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/) auswählen. Für beide Eigenschaften wählt Index `1` den ersten Eintrag in der jeweiligen Theme‑Sammlung (`fill_styles[0]` bzw. `line_styles[0]`), Index `2` den zweiten Eintrag.

Das folgende Beispiel definiert zwei Füllungen (Gold und Himmelblau) und zwei Konturen (dunkelblau 6 pt und dunkelrot 12 pt) im Standard‑Theme einer neuen Präsentation. Es speichert die Folie in drei Schritten, sodass Sie die Ergebnisse in PowerPoint vergleichen können:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    styles = presentation.master_theme.format_scheme

    gold_fill = styles.fill_styles[0]
    gold_fill.fill_type = slides.FillType.SOLID
    gold_fill.solid_fill_color.preset_color = slides.PresetColor.GOLD
    blue_fill = styles.fill_styles[1]
    blue_fill.fill_type = slides.FillType.SOLID
    blue_fill.solid_fill_color.preset_color = slides.PresetColor.SKY_BLUE

    thin_line = styles.line_styles[0]
    thin_line.fill_format.fill_type = slides.FillType.SOLID
    thin_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
    thin_line.width = 6
    thick_line = styles.line_styles[1]
    thick_line.fill_format.fill_type = slides.FillType.SOLID
    thick_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_RED
    thick_line.width = 12

    shapes = presentation.slides[0].shapes
    left = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 205, 200, 130)
    right = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 420, 205, 200, 130)
    left.shape_style.fill_style_index = 1
    right.shape_style.fill_style_index = 2
    left.shape_style.line_style_index = 1
    right.shape_style.line_style_index = 1
    presentation.save("01-initial.pptx", slides.export.SaveFormat.PPTX)

    right.shape_style.line_style_index = 2
    presentation.save("02-line-changed.pptx", slides.export.SaveFormat.PPTX)

    gold_fill.solid_fill_color.preset_color = slides.PresetColor.SEA_GREEN
    presentation.save("03-theme-changed.pptx", slides.export.SaveFormat.PPTX)
```

| Anfangsstile | Rechte Kontur ändern | Ersten Theme‑Füllstil bearbeiten |
|:---:|:---:|:---:|
| ![Gold‑ und himmelblaue Rechtecke mit passenden dünnen dunkelblauen Konturen](theme-style-initial.png) | ![Das himmelblaue Rechteck hat jetzt eine dicke dunkelrote Kontur](theme-style-line-changed.png) | ![Das linke Rechteck ist jetzt grün, beide Konturen unverändert](theme-style-fill-changed.png) |

Das Auswählen einer anderen Linien‑Stil‑Nummer ändert nur die Kontur des rechten Rechtecks. Das Bearbeiten des ersten Theme‑Füllstils aktualisiert jede Form, die ihn verwendet. Hier wird nur das linke Rechteck grün.

Bei einer bestehenden Form kann eine lokale Füllfarbe, Linienfarbe oder Linienstärke diesen Teil des Theme‑Stils überschreiben. Hat das Ändern eines Stil‑Indexes keine sichtbare Auswirkung, prüfen Sie die [direct formatting](/slides/de/python-net/shape-formatting/) der Form.

## **Ermitteln, ob eine effektive einfarbige Füllung eine Theme‑Farbe verwendet**

Eine Füllung kann direkt auf einem Objekt gespeichert sein oder von einem Absatz, Layout, Master, Theme‑Stil oder einer anderen Formatierungsebene geerbt werden. Rufen Sie [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) auf, um diese Hierarchie in ein unveränderliches [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) aufzulösen. Prüfen Sie zuerst [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/). Nur wenn es `FillType.SOLID` ist, sollten Sie die Eigenschaften einer einfarbigen Füllung lesen.

Für eine einfarbige Füllung liefert [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) den finalen gerenderten RGB‑Wert nach Vererbung, Theme‑Lookup und Farbtransformationen. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) gibt das zugehörige logische [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/)-Slot zurück, etwa `TEXT1` oder `ACCENT6`. Der Wert `SchemeColor.NOT_DEFINED` bedeutet, dass die effektive einfarbige Füllung nicht auf einer Scheme‑Color basiert. In einem Workflow, in dem Füllungen entweder Theme‑Farben oder direkte RGB‑Farben sind, identifiziert dieser Wert eine direkte RGB‑Füllung.

Verwenden Sie nicht allein den lokalen Wert [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/), um eine Füllung zu klassifizieren. Beispielsweise kann ein Textabschnitt keine lokal definierte Scheme‑Color haben, sodass sein lokaler Wert `NOT_DEFINED` ist, während seine effektive Füllung eine Theme‑Farbe erbt und zu `TEXT1` oder `ACCENT6` aufgelöst wird. Im Gegensatz dazu sagt Ihnen `solid_fill_scheme_color`, welches logische Theme‑Slot die effektive Farbe erzeugt hat, jedoch nicht, von welcher Ebene (Objekt, Absatz, Layout, Master usw.) dieses Slot stammt.

Das folgende Beispiel lädt eine Präsentation, prüft sowohl Form‑Füllungen als auch Text‑Abschnitt‑Füllungen, gibt jeden finalen RGB‑Wert und das zugehörige Scheme‑Color aus und markiert einfarbige Füllungen, die Theme‑Farb‑Änderungen nicht verfolgen:

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

Der `NOT_DEFINED`‑Zweig liefert eine Prüfliste einfarbiger Füllungen, die nicht auf Theme‑Farben reagieren. Überprüfen Sie diese Objekte, wenn eine Präsentation einem neuen Marken‑Farbschema folgen muss. Der gemeldete RGB‑Wert zeigt weiterhin das aktuelle Aussehen, während der Scheme‑Wert erklärt, ob dieses Aussehen mit dem Theme verbunden ist.

Effektive Format‑Objekte sind Momentaufnahmen. Nach einer Änderung des Präsentations‑Themes, eines Theme‑Overrides oder einer anderen geerbten Formatierung rufen Sie erneut `get_effective` auf und lesen ein neues `IFillFormatEffectiveData`‑Objekt, bevor Sie Farben vergleichen oder berichten.

## **Effektive Theme‑Werte auslesen**

Roh‑Theme‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich nach Vererbung und lokalen Overrides verwendet. Für eine Folie rufen Sie [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) auf. Für einen Hintergrund verwenden Sie [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/), und für eine Füllung [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/).

Das folgende Beispiel liest das effektive Theme, den Hintergrund und die erste Form‑Füllung einer Folie aus:

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

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) untersuchen, können Sie einen Master‑, Layout‑, Folien‑ oder Form‑Override übersehen, der das endgültige Erscheinungsbild ändert.

## **FAQ**

**Wirkt das Anwenden eines externen Themes auf jede Folie der Präsentation?**

Nein. [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) ordnet nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master verwenden, behalten ihre bestehenden Themes.

**Kann ich ein Theme auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) der Folie und initialisieren Sie dessen Override‑Theme. Die Änderung bleibt lokal für diese Folie; andere Folien erben weiterhin ihre bestehenden Themes.

**Was ist der sicherste Weg, ein Theme von einer Präsentation in eine andere zu übertragen?**

Beim Verschieben einer Folie und dem Erhalt ihres Quell‑Designs klonen Sie den Quell‑Master in das Ziel und klonen die Folie mit diesem Master über [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) und [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/). Dadurch bleiben Master, Layouts und Theme zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Overrides sehen?**

Verwenden Sie [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) für ein Folien‑ oder Layout‑Theme und die entsprechenden Effective‑Data‑Methoden für Format‑Objekte wie [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) und [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/). Diese APIs geben die aufgelösten Werte nach Vererbung und Overrides zurück.