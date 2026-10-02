---
title: Präsentationstext in Python formatieren
linktitle: Textformatierung
type: docs
weight: 50
url: /de/python-net/text-formatting/
keywords:
- Absatz ausrichten
- Textstil
- Texthintergrund
- Texttransparenz
- Zeichenabstand
- Schrifteigenschaften
- Schriftfamilie
- Textdrehung
- Drehwinkel
- Textrahmen
- Zeilenabstand
- Autofit-Eigenschaft
- Textrahmen-Anker
- Text-Tabulatoren
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Formatieren und Gestalten von Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET. Schriftarten, Farben, Ausrichtung und mehr anpassen."
---
## **Übersicht**

Dieser Artikel zeigt, wie man Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET formatiert. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schriftarteigenschaften, Drehung, Absatzabstand, Autofit‑Verhalten, Textverankerung, Tabulatoren und Spracheinstellungen.

Falls nicht anders angegeben, verwenden die Beispiele [sample.pptx](sample.pptx). Die erste Form auf der ersten Folie ist ein Textfeld, und ihr erster Absatz enthält den unten gezeigten Text. Sowohl Folien- als auch Formindizes beginnen bei Null. Beispiele, die fette Textteile auswählen, verwenden effektive Formatierung, einschließlich geerbter Fettschrift:

![Beispieltext](sample_text.png)

Um wörtlichen Text oder reguläre Ausdruck‑Treffer zu finden und zu markieren, siehe [Suche und Ersetze Text](/slides/de/python-net/search-and-replace-text/).

## **Text-Hintergrundfarbe festlegen**

Verwenden Sie [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) um die Standard‑Hervorhebungsfarbe für einen Absatz festzulegen, oder verwenden Sie [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) für einzelne Textabschnitte.

Das folgende Beispiel legt eine hellgraue Hervorhebung als Standard für den ersten Absatz fest. Explizite Hervorhebungsfarben für einzelne Abschnitte haben Vorrang vor diesem Standard:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Setzen Sie die Hervorhebungsfarbe für den gesamten Absatz.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der graue Absatz](gray_paragraph.png)

Das nachstehende Codebeispiel zeigt, wie die Hintergrundfarbe für **Textabschnitte mit fetter Schrift** festgelegt wird:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Setzen Sie die Hervorhebungsfarbe für den Textabschnitt.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die grauen Textabschnitte](gray_text_portions.png)

## **Textabsätze ausrichten**

Verwenden Sie [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) , um die Absatzausrichtung innerhalb eines Textrahmens festzulegen. Der Wert kann zentriert, linksbündig, rechtsbündig, Blocksatz usw. sein.

Das folgende Codebeispiel zeigt, wie der Absatz **zentriert** ausgerichtet wird:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Setzen Sie die Ausrichtung des Absatzes auf zentriert.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der ausgerichtete Absatz](aligned_paragraph.png)

## **Schriften innerhalb einer Zeile ausrichten**

Verwenden Sie [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) , um Textabschnitte mit verschiedenen Schriftgrößen innerhalb einer Zeile vertikal auszurichten. Diese Einstellung gilt für den gesamten Absatz und steuert die Ausrichtung innerhalb jeder seiner Zeilen.

Das folgende eigenständige Beispiel erstellt vier beschriftete Textfelder auf einer Folie. Jeder Absatz enthält denselben Text in 18, 36 und 54 Punkt mit unterschiedlicher Schriftalignierung. Es verwendet Arial, deaktiviert Autofit und Zeilenumbruch und sorgt dafür, dass die Textrahmen groß genug für eine einzelne Zeile sind.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Vergleich von Grundlinie, Oben, Mitte und Unten Schriftausrichtung bei gemischten Schriftgrößen](font_alignment.png)

Die Schrift­ausrichtung verwendet Schrift­metriken, sodass die sichtbaren Kanten einzelner Buchstaben nicht unbedingt exakt übereinstimmen. Das Beispiel enthält sowohl einen Großbuchstaben als auch einen Abstieg, um den Unterschied zwischen Grundlinien‑ und Unter‑Ausrichtung zu verdeutlichen. Schriftverfügbarkeit und -ersatz, die verwendeten Zeichen und die unterschiedliche Schriftgröße beeinflussen das Ergebnis. Rahmen‑Abmessungen, Ränder, Zeilenabstand, Zeilenumbruch und Autofit wirken sich ebenfalls auf das Layout aus; verwenden Sie dieselben Schriften und Layout‑Einstellungen beim Vergleich der Modi.

Diese Einstellung unterscheidet sich von [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), die die horizontale Absatzausrichtung steuert, und von [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), die den Textblock vertikal innerhalb seiner Form positioniert. Hoch‑ und Tiefstellung über [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) verschiebt einzelne Abschnitte relativ zur Grundlinie, anstatt die Schrift­ausrichtung für die Zeilen des Absatzes festzulegen.

## **Transparenz für Text festlegen**

Die Texttransparenz wird über die Alpha‑Komponente der Farbe gesteuert, die [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) zugewiesen wird. In den nachstehenden Beispielen ist `alpha = 50` ein ARGB‑Alpha‑Kanalwert im Bereich 0–255 und keine Transparenz‑Prozentangabe.

Das nachstehende Codebeispiel zeigt, wie Transparenz auf den **gesamten Absatz** angewendet wird:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Setzen Sie eine halbtransparente schwarze Füllung für den Text.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der transparente Absatz](transparent_paragraph.png)

Das folgende Codebeispiel zeigt, wie Transparenz auf **Textabschnitte mit fetter Schrift** angewendet wird:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Setzen Sie die Transparenz des Textabschnitts.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die transparenten Textabschnitte](transparent_text_portions.png)

## **Zeichenabstand für Text festlegen**

Verwenden Sie [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) , um den Abstand zwischen Zeichen in einem Textfeld zu vergrößern oder zu verringern. Die Beispiele fügen 3 Punkte Abstand hinzu; negative Werte komprimieren den Text.

Der folgende Python‑Code zeigt, wie der Zeichenabstand im **gesamten Absatz** erweitert wird:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Zeichenabstand vergrößern.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der Zeichenabstand im Absatz](character_spacing_in_paragraph.png)

Das nachstehende Codebeispiel zeigt, wie der Zeichenabstand in **Textabschnitten mit fetter Schrift** erweitert wird:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
            portion.portion_format.spacing = 3  # Zeichenabstand vergrößern.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der Zeichenabstand in den Textabschnitten](character_spacing_in_text_portions.png)

### **Kerning für bestimmte Schriften deaktivieren**

In einigen Fällen kann der von Aspose.Slides gerenderte Text etwas dichter wirken als derselbe Text in PowerPoint. Das kann passieren, weil PowerPoint Kerning‑Daten für bestimmte Schriften ignoriert, selbst wenn die Schrift gültige Kerning‑Informationen enthält und Kerning in den PowerPoint‑Einstellungen aktiviert ist.

Um die gerenderte Ausgabe in solchen Fällen PowerPoint anzunähern, können Sie Kerning für Textabschnitte, die die betroffene Schrift verwenden, deaktivieren. Setzen Sie [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) auf einen Wert, der größer ist als die tatsächliche Schriftgröße. Dieses Beispiel benötigt "presentation.pptx" mit einem Textfeld als erste Form auf der ersten Folie. Es prüft die effektiven Schriftarten, einschließlich geerbter Schriften, und legt einen Schwellenwert von 100 Punkt für Abschnitte fest, die Roboto verwenden. Damit wird Kerning für passende Abschnitte mit einer Schriftgröße unter 100 Punkt deaktiviert:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Für passende Texte unterhalb des Schwellenwerts verhindert diese Einstellung Kerning und kann dabei helfen, das Rendering von Aspose.Slides mit der visuellen Ausgabe von PowerPoint für von diesem PowerPoint‑spezifischen Verhalten betroffene Schriften abzugleichen.

## **Schriftart-Eigenschaften für Text verwalten**

Schriftart‑Eigenschaften können auf Ebene des Absatzes über [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) oder für einzelne Abschnitte über [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) festgelegt werden.

Das folgende Beispiel legt die Standardschrift des ersten Absatzes auf 12 Punkt Times New Roman mit fetter, kursiver und punktierter Unterstreichung fest. Explizite Formatierung einzelner Abschnitte hat Vorrang vor diesen Vorgaben.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Setzen Sie die Schriftarteigenschaften für den Absatz.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Schriftart‑Eigenschaften für den Absatz](font_properties_for_paragraph.png)

Das folgende Beispiel wendet 13 Punkt Times New Roman, kursive Formatierung und eine punktierte Unterstreichung auf Abschnitte an, deren effektive Formatierung fett ist:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Setzen Sie die Schriftarteigenschaften für den Textabschnitt.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Schriftart‑Eigenschaften für Textabschnitte](font_properties_for_text_portions.png)

## **Textdrehung festlegen**

Verwenden Sie [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) , um eine vordefinierte Textausrichtung innerhalb einer Form festzulegen.

Das folgende Codebeispiel setzt die Textausrichtung in der Form auf [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), was den Text **um 90 Grad gegen den Uhrzeigersinn** dreht:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Textdrehung](text_rotation.png)

## **Benutzerdefinierte Drehung für Textrahmen festlegen**

Verwenden Sie [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) , um einen benutzerdefinierten Drehwinkel für einen [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) festzulegen.

Das nachstehende Codebeispiel dreht den Textrahmen innerhalb der Form um 3 Grad im Uhrzeigersinn:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die benutzerdefinierte Textdrehung](custom_text_rotation.png)

## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides bietet [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/), und [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) zur Steuerung des Absatzabstands. Diese Eigenschaften werden wie folgt verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhöhe anzugeben.
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkten anzugeben.

Das folgende Beispiel setzt den Abstand innerhalb des ersten Absatzes auf 200 % der Zeilenhöhe (doppelter Abstand):

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der Zeilenabstand innerhalb des Absatzes](line_spacing.png)

## **Zeilenumbruch steuern**

Regeln für den Absatz‑Zeilenumbruch sind nützlich in schmalen Textblöcken und Präsentationen, die lateinischen und ostasiatischen Text mischen. Die folgenden Eigenschaften gehören zu [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), sodass sie auf einen gesamten Absatz angewendet werden:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) steuert die Zeilenumbruchregeln für Lateinisch. In gemischtem Text kann eine Änderung auch den Umbruch benachbarten ostasiatischen Textes und der Interpunktion beeinflussen.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) steuert die Zeilenumbruchregeln für Ostasien, einschließlich Beschränkungen für Zeichen am Anfang und Ende einer Zeile.

Diese Regeln ersetzen nicht [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), das automatischen Zeilenumbruch innerhalb eines Textrahmens ermöglicht. Sie beeinflussen das Layout, wenn ein Umbruch stattfindet; sie fügen keine Zeilenumbruch‑Zeichen ein. Ein expliziter Zeilenumbruch erzeugt eine neue Zeile im Absatz, unabhängig von der verfügbaren Breite.

Das folgende eigenständige Beispiel erstellt einen schmalen Textblock mit chinesischem und lateinischem Text. Es setzt beide Zeilenumbruch‑Eigenschaften explizit und speichert „line_breaking.pptx“. Um mit einer Regel zu experimentieren, ändern Sie den Wert dieser Eigenschaft, während die andere Einstellung unverändert bleibt. Das Beispiel verwendet 24 Punkt Arial und SimSun bei einer Rahmenbreite von 160 Punkt und null horizontalen Text‑Rahmen‑Rändern. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) ist auf [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) gesetzt, sodass Textgröße und Rahmenabmessungen fest bleiben.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **Hängende Interpunktion steuern**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) ermöglicht es zulässiger Interpunktion, über die rechte Kante der Textzeile hinauszuragen, anstatt die nächste Zeile zu belegen. Sie gilt für den gesamten Absatz und unterscheidet sich von einem hängenden Einzug.

Das folgende eigenständige Beispiel aktiviert hängende Interpunktion in einem 100 Punkt breiten Textrahmen und speichert „hanging_punctuation.pptx“. Mit 24 Punkt Arial und null horizontalen Textrahmen‑Rändern bleibt der abschließende Punkt nach „Satz“ und ragt über die rechte Textkante hinaus. Setzen Sie die Eigenschaft auf [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) , um zu vergleichen: Mit diesen Einstellungen belegt der Punkt eine eigene Zeile. Zeilenumbruch ist aktiviert und Autofit deaktiviert, um die verfügbare Breite festzuhalten.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

Nicht jedes Satzzeichen kann hängen. Das sichtbare Ergebnis hängt von [Schrift‑ und Layout‑Bedingungen](#control-line-breaking) ab: Durch Ändern der Schrift, der verfügbaren Breite, der Ränder oder der Autofit‑Einstellungen kann der sichtbare Unterschied verschwinden.

## **Autofit‑Typ für Textrahmen festlegen**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Containers überschreitet. Verwenden Sie es, um zu steuern, ob der Text schrumpft, überläuft oder die Form automatisch anpasst. Das folgende Beispiel konfiguriert die Form so, dass sie sich an den Text anpasst, und speichert das Ergebnis in „autofit_type.pptx“.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Um nach automatischem Umbruch Zeilen zu zählen und zu sehen, wie sich Text‑ oder Formbreite auf das Ergebnis auswirken, siehe [Count Rendered Lines](/slides/de/python-net/manage-paragraph/). Die Zeilenzahl allein zeigt nicht an, ob Text den Container überläuft.

## **Anker von Textrahmen festlegen**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) definiert, wie Text vertikal innerhalb einer Form positioniert wird, z. B. oben, in der Mitte oder unten. Das folgende Beispiel verankert den Text am unteren Rand der ersten Form und speichert das Ergebnis in „text_anchor.pptx“.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Tabulatoren für Text festlegen**

Verwenden Sie [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) und [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) , um Tabstopps in einem Absatz zu konfigurieren. Das folgende Beispiel setzt das Standard‑Tabintervall auf 100 Punkt und fügt einen linksbündigen Tabstopp bei 30 Punkt hinzu. Diese Einstellungen beeinflussen Text, der Tabulator‑Zeichen enthält.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Absatz‑Tabstopps](paragraph_tabs.png)

## **Korrektursprache festlegen**

Aspose.Slides stellt [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) zur Verfügung, mit dem Sie die Korrektursprache für einen Textabschnitt festlegen können. Die Korrektursprache bestimmt die Sprache, die für Rechtschreib‑ und Grammatikprüfungen in PowerPoint verwendet wird.

Das folgende Beispiel benötigt „presentation.pptx“ mit einem Textfeld als erste Form auf der ersten Folie und mindestens einen Absatz. Es ersetzt den Inhalt des ersten Absatzes durch „1。“, setzt SimSun als Schriftart und weist die vereinfachte chinesische Korrektursprache (`zh-CN`) zu. Das Ergebnis wird in „proofing_language.pptx“ gespeichert:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Setzen Sie die Korrektursprache auf vereinfachtes Chinesisch.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Standard‑Sprache festlegen**

Verwenden Sie [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) , um die Standardsprache für Text festzulegen, der beim Laden oder Erstellen einer Präsentation erzeugt wird. Das folgende Beispiel erstellt eine Präsentation mit US‑Englisch als Standardsprache für Text, fügt ein Textfeld hinzu und gibt `en-US` für den ersten Textabschnitt aus.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Fügen Sie eine neue Rechteckform mit Text hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Überprüfen Sie die Sprache des ersten Abschnitts.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Standard‑Textstil festlegen**

Um die Standard‑Textformatierung auf Präsentationsebene anzuwenden, verwenden Sie [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Das folgende Beispiel legt für die obersten Absätze in einer neuen Präsentation eine 14 Punkt fette Schrift als Standard fest und speichert sie in „default_text_style.pptx“. Text kann diese Vorgaben erben, sofern keine spezifischere Formatierung sie überschreibt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Hole das Absatzformat der obersten Ebene.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Text mit dem Alle‑Großbuchstaben‑Effekt extrahieren**

In PowerPoint bewirkt die Anwendung des **All Caps**‑Schrifteffekts, dass Text auf der Folie in Großbuchstaben angezeigt wird, selbst wenn er ursprünglich in Kleinbuchstaben eingegeben wurde. Wenn Sie einen solchen Textabschnitt mit Aspose.Slides abrufen, gibt die Bibliothek den Text exakt so zurück, wie er eingegeben wurde. Um den angezeigten Text zu erhalten, prüfen Sie [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) und wandeln die zurückgegebene Zeichenkette in Großbuchstaben um, wenn der Wert `ALL` ist.

Dieses Beispiel benötigt „sample2.pptx“ mit einem Textfeld als erste Form auf der ersten Folie. Der erste Abschnitt des ersten Absatzes enthält „Hello, Aspose!“ mit angewendetem All Caps‑Effekt, wie unten gezeigt.

![Der All Caps‑Effekt](all_caps_effect.png)

Das nachstehende Codebeispiel zeigt, wie der Text mit angewendetem **All Caps**‑Effekt extrahiert wird:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

Ausgabe:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Wie ändere ich Text in einer Tabelle auf einer Folie?**

Um Text in einer Tabelle auf einer Folie zu ändern, verwenden Sie [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Durchlaufen Sie die Zellen und aktualisieren Sie jede Zelle über [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) sowie die Absatzformatierung über [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Wie wende ich einen Farbverlauf auf Text in einer PowerPoint‑Folie an?**

Um einen Farbverlauf auf Text anzuwenden, verwenden Sie [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Setzen Sie [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) auf [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) und konfigurieren Sie die Verlaufspunkte, Richtung und Transparenz.