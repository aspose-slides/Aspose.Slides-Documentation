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
- Textrotation
- Drehwinkel
- Textfeld
- Zeilenabstand
- AutoFit-Eigenschaft
- Textfeld-Anker
- Texttabulator
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Formatieren und gestalten Sie Text in PowerPoint- und OpenDocument‑Präsentationen mit Aspose.Slides für Python über .NET. Passen Sie Schriftarten, Farben, Ausrichtung und mehr an."
---
## **Übersicht**

Dieser Artikel zeigt, wie Text in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Python über .NET formatiert wird. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schriftarteigenschaften, Drehung, Absatzabstände, AutoFit‑Verhalten, Textausrichtung, Tabstopps und Spracheinstellungen.

Sofern nicht anders angegeben, verwenden die Beispiele [sample.pptx](sample.pptx). Die erste Form auf der ersten Folie ist ein Textfeld, und ihr erster Absatz enthält den unten gezeigten Text. Sowohl Folien‑ als auch Form‑Indizes beginnen bei Null. Beispiele, die fette Abschnitte auswählen, verwenden effektive Formatierung, einschließlich geerbter Fettdarstellung:

![Beispieltext](sample_text.png)

Um literalen Text bzw. reguläre Ausdrücke zu finden und zu markieren, siehe [Suchen und Ersetzen von Text](/slides/de/python-net/search-and-replace-text/).

## **Text‑Hintergrundfarbe festlegen**

Verwenden Sie [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/), um die Standard‑Hervorhebungsfarbe für einen Absatz festzulegen, oder [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) für einzelne Textabschnitte.

Das folgende Beispiel legt eine hellgraue Hervorhebung als Standard für den ersten Absatz fest. Explizite Hervorhebungsfarben für einzelne Abschnitte haben Vorrang vor diesem Standard:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Setze die Hervorhebungsfarbe für den gesamten Absatz.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der graue Absatz](gray_paragraph.png)

Das nachstehende Codebeispiel zeigt, wie die Hintergrundfarbe für **Textabschnitte mit fetter Schrift** gesetzt wird:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Setze die Hervorhebungsfarbe für den Textabschnitt.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die grauen Textabschnitte](gray_text_portions.png)

## **Textabsätze ausrichten**

Verwenden Sie [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), um die Absatzausrichtung innerhalb eines Textfelds festzulegen. Der Wert kann z. B. zentriert, linksbündig, rechtsbündig, Blocksatz usw. sein.

Das folgende Codebeispiel zeigt, wie der Absatz **zentriert** ausgerichtet wird:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Setze die Ausrichtung des Absatzes auf zentriert.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der ausgerichtete Absatz](aligned_paragraph.png)

## **Schriften innerhalb einer Zeile ausrichten**

Verwenden Sie [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/), um Textabschnitte unterschiedlicher Schriftgrößen vertikal innerhalb einer Zeile auszurichten. Diese Einstellung gilt für den gesamten Absatz und steuert die Ausrichtung in jeder Zeile.

Das folgende eigenständige Beispiel erstellt vier beschriftete Textfelder auf einer Folie. Jeder Absatz enthält denselben Text in 18, 36 und 54 Punkten mit unterschiedlicher Schrift­ausrichtung. Es verwendet Arial, deaktiviert AutoFit und Zeilenumbruch und hält die Textfelder groß genug für eine einzelne Zeile.

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

![Vergleich von Grundlinie, Oberkante, Mittelpunkt und Unterkante bei gemischten Schriftgrößen](font_alignment.png)

Die Schrift­ausrichtung verwendet Schrift­metriken, sodass die sichtbaren Kanten einzelner Buchstaben nicht unbedingt exakt übereinstimmen. Das Beispiel enthält sowohl einen Großbuchstaben als auch einen Tiefstecker, um den Unterschied zwischen Grundlinie und Unterkante zu verdeutlichen. Verfügbarkeit und Ersetzung von Schriften, die verwendeten Zeichen sowie die unterschiedlichen Schriftgrößen beeinflussen das Ergebnis. Rahmen­größen, Ränder, Zeilenabstand, Zeilenumbruch und AutoFit wirken sich ebenfalls auf das Layout aus; verwenden Sie dieselben Schriften und Layout‑Einstellungen beim Vergleich der Modi.

Diese Einstellung unterscheidet sich von [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), das die horizontale Absatzausrichtung steuert, und von [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), das den Textblock vertikal innerhalb seiner Form positioniert. Hoch‑ und Tiefstellung mittels [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) verschiebt einzelne Abschnitte relativ zur Grundlinie, anstatt die Schrift­ausrichtung für die Zeilen des Absatzes festzulegen.

## **Transparenz für Text festlegen**

Die Texttransparenz wird über die Alpha‑Komponente der Farbe gesteuert, die [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) zugewiesen wird. In den nachfolgenden Beispielen ist `alpha = 50` ein ARGB‑Alpha‑Wert im Bereich 0‑255, nicht ein Transparenz‑Prozentsatz.

Das folgende Codebeispiel zeigt, wie Transparenz für den **gesamten Absatz** angewendet wird:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Setze eine halbtransparente schwarze Füllung für den Text.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der transparente Absatz](transparent_paragraph.png)

Das folgende Codebeispiel zeigt, wie Transparenz für **Textabschnitte mit fetter Schrift** angewendet wird:

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
            # Setze die Transparenz des Textabschnitts.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die transparenten Textabschnitte](transparent_text_portions.png)

## **Zeichenabstand für Text festlegen**

Verwenden Sie [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/), um den Abstand zwischen Zeichen in einem Textfeld zu vergrößern oder zu verringern. Die Beispiele fügen einen Abstand von 3 Punkten hinzu; negative Werte verkleinern den Text.

Der folgende Python‑Code zeigt, wie der Zeichenabstand im **gesamten Absatz** erweitert wird:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Zeichenabstand erweitern.

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
            portion.portion_format.spacing = 3  # Zeichenabstand erweitern.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der Zeichenabstand in den Textabschnitten](character_spacing_in_text_portions.png)

### **Kerning für bestimmte Schriften deaktivieren**

In manchen Fällen kann der von Aspose.Slides gerenderte Text leicht enger wirken als derselbe Text in PowerPoint. Das kann passieren, weil PowerPoint Kerning‑Daten für bestimmte Schriften ignoriert, selbst wenn die Schrift gültige Kerning‑Informationen enthält und Kerning in den PowerPoint‑Einstellungen aktiviert ist.

Um die Darstellung in solchen Fällen PowerPoint anzunähern, können Sie Kerning für Textabschnitte deaktivieren, die die betroffene Schrift verwenden. Setzen Sie [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) auf einen Wert, der größer ist als die tatsächliche Schriftgröße. Dieses Beispiel benötigt „presentation.pptx“ mit einem Textfeld als erster Form auf der ersten Folie. Es prüft die effektiven Schrift­namen, einschließlich geerbter Schriften, und legt eine Schwelle von 100 Punkten für Abschnitte fest, die Roboto verwenden. Damit wird Kerning für passende Abschnitte mit einer Schriftgröße unter 100 Punkten deaktiviert:

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

Für Text unterhalb der Schwelle verhindert diese Einstellung Kerning und kann helfen, die Darstellung von Aspose.Slides an das visuelle Ergebnis von PowerPoint für von diesem Verhalten betroffene Schriften anzupassen.

## **Schrifteigenschaften von Text verwalten**

Schrifteigenschaften können auf Absatz‑Ebene über [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) oder auf einzelne Abschnitte über [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) gesetzt werden.

Das folgende Beispiel setzt die Standardschrift des ersten Absatzes auf Times New Roman 12 Punkt mit fett, kursiv und gepunkteter Unterstreichung. Explizite Formatierungen einzelner Abschnitte haben Vorrang vor diesen Vorgaben.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Setze die Schriftarteigenschaften für den Absatz.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Schrifteigenschaften für den Absatz](font_properties_for_paragraph.png)

Das folgende Beispiel wendet Times New Roman 13 Punkt, kursive Formatierung und gepunktete Unterstreichung auf Abschnitte an, deren effektive Formatierung fett ist:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Setze die Schriftarteigenschaften für den Textabschnitt.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Schrifteigenschaften für Textabschnitte](font_properties_for_text_portions.png)

## **Text‑Höhen‑Normalisierung steuern**

Verwenden Sie [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/), wenn Sie Vorlagen‑Typografie reproduzieren oder Unterschiede in der Zeichenhöhe untersuchen. In PowerPoint bewirkt das Aktivieren der Normalisierung, dass einzelne Zeichen vertikal gedehnt oder gestaucht werden, um innerhalb des Textabschnitts eine einheitliche sichtbare Höhe zu erhalten. Es garantiert jedoch keine gleichen Text‑Höhen über verschiedene Schriften hinweg.

Setzen Sie die Eigenschaft auf [NullableBool.TRUE oder FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/), um Normalisierung explizit zu aktivieren bzw. zu deaktivieren. `NullableBool.NOT_DEFINED` lässt die lokale Einstellung unbestimmt, sodass der Abschnitt den Wert von z. B. [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) erbt. Es bedeutet nicht `False`. Verwenden Sie [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) und lesen Sie [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/), um den aufgelösten booleschen Wert zu erhalten.

Das nachstehende eigenständige Beispiel erfordert **Arial**. Es erzeugt zwei Textblöcke mit denselben Groß‑ und Kleinbuchstaben, Tiefsteckern und Zeichen mit Akzenten bei 54 Punkt. Beide Absätze aktivieren Normalisierung standardmäßig. Der obere Abschnitt deaktiviert sie explizit; der untere erbt die Einstellung. Rahmen‑Größen, Ränder und Absatzabstände sind identisch, Zeilenumbruch und AutoFit sind deaktiviert, um den Vergleich konsistent zu halten. Das Beispiel gibt `FALSE: False` und `NOT_DEFINED: True` aus und speichert „text_height_normalization.pptx“.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

Der unten gezeigte Vergleich wurde aus der gespeicherten Präsentation exportiert. Die obere Zeile hat Normalisierung deaktiviert (`FALSE`); die untere Zeile erbt die aktivierte Einstellung (`NOT_DEFINED` → `True`). Arial muss installiert sein, um das Aussehen zu reproduzieren.

![Arial‑Text mit 54 Punkt, Normalisierung deaktiviert oben und geerbte Normalisierung aktiviert unten](text_height_normalization.png)

Normalisierung ändert die Zeichenhöhe, ohne den zugewiesenen [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/)‑Wert zu verändern, der die Schriftgröße in Punkten angibt. Das Absatz‑[space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) steuert den Zeilenabstand, während das Text‑Frame‑[autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) festlegt, wie Text oder dessen Container sich anpassen. Diese Einstellungen dienen unterschiedlichen Zwecken und können das Gesamtlayout unabhängig voneinander beeinflussen. Weitere Informationen zu Absatz‑Formatierung und Vererbung finden Sie unter [Absatz verwalten](/slides/de/python-net/manage-paragraph/).

## **Durchgestrichenen Text anwenden und entfernen**

Verwenden Sie [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) für einen Textabschnitt, um Korrekturen, gestrichene Begriffe oder frühere Preise anzuzeigen, ohne den Originaltext zu löschen. Setzen Sie ihn auf [TextStrikethroughType.SINGLE oder DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/), um eine bzw. zwei Linien durch den Text zu legen.

Um Durchstreichen zu entfernen, weisen Sie `TextStrikethroughType.NONE` zu. Dadurch wird der Effekt explizit deaktiviert, selbst wenn die umgebende Formatierung Durchstreichen vorsieht. Im Gegensatz dazu lässt `TextStrikethroughType.NOT_DEFINED` die lokale Einstellung undefiniert, sodass der Abschnitt die Formatierung von z. B. dem Absatz erben kann. Das garantiert nicht, dass Durchstreichen entfernt wird. Verwenden Sie [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), um die resultierende Formatierung inklusive geerbter Werte zu lesen.

Das folgende eigenständige Beispiel erzeugt drei Preisvergleiche. Jeder Absatz enthält separate Abschnitte für Bezeichnung, alten Preis und neuen Preis, sodass nur der alte Preis betroffen ist. Die erste Zeile wendet Durchstreichen an und entfernt es anschließend; die anderen Zeilen behalten ein‑ bzw. doppelt durchgestrichenen Text bei. Das Ändern dieser Eigenschaft bewahrt den Text und seine übrige Formatierung, einschließlich des fetten alten Preises.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # Durchstreichen anwenden, dann explizit vom ersten vorherigen Preis entfernen.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis von oben nach unten: kein Durchstreichen, einfaches Durchstreichen und doppeltes Durchstreichen.

![Vorherige Preise ohne Durchstreichen, mit einfachem Durchstreichen und mit doppeltem Durchstreichen](strikethrough.png)

## **Text‑Drehung festlegen**

Verwenden Sie [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/), um eine vordefinierte Textausrichtung innerhalb einer Form festzulegen.

Das folgende Codebeispiel setzt die Textausrichtung in der Form auf [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), wodurch der Text **90 Grad gegen den Uhrzeigersinn** rotiert wird:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Text‑Drehung](text_rotation.png)

## **Benutzerdefinierte Drehung für Text‑Frames festlegen**

Verwenden Sie [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/), um einen benutzerdefinierten Drehwinkel für einen [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) festzulegen.

Das nachstehende Codebeispiel dreht den Text‑Frame innerhalb der Form um 3 Grad im Uhrzeigersinn:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die benutzerdefinierte Text‑Drehung](custom_text_rotation.png)

## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides stellt [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) und [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) zur Verfügung, um den Absatzabstand zu steuern. Diese Eigenschaften werden wie folgt verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhöhe anzugeben.
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkten anzugeben.

Das folgende Beispiel setzt den Abstand innerhalb des ersten Absatzes auf 200 % der Zeilenhöhe (doppelte Zeilenabstand):

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

Regeln für den Absatz‑Zeilenumbruch sind nützlich in schmalen Textblöcken und Präsentationen, die lateinischen und ostasiatischen Text mischen. Die folgenden Eigenschaften gehören zu [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), sodass sie für einen gesamten Absatz gelten:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) steuert die Zeilenumbruch‑Regeln für Lateinisch. In gemischtem Text kann die Änderung auch beeinflussen, wo benachbarter ostasiatischer Text und Interpunktion umbrechen.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) steuert die Zeilenumbruch‑Regeln für Ostasien, einschließlich Beschränkungen für Zeichen am Anfang bzw. Ende einer Zeile.

Diese Regeln ersetzen nicht [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), das automatischen Zeilenumbruch innerhalb eines Text‑Frames ermöglicht. Sie beeinflussen das Layout, wenn ein Umbruch erfolgt; sie fügen keine Zeilenumbruch‑Zeichen ein. Ein expliziter Zeilenumbruch erzwingt eine neue Zeile im Absatz, unabhängig von der verfügbaren Breite.

Das nachstehende eigenständige Beispiel erstellt einen schmalen Textblock mit chinesischem und lateinischem Text. Es setzt beide Zeilenumbruch‑Eigenschaften explizit und speichert „line_breaking.pptx“. Um eine der Regeln zu testen, ändern Sie deren Wert, während Sie die andere Einstellung unverändert lassen. Das Beispiel verwendet Arial 24 Punkt und SimSun bei einer Rahmenbreite von 160 Punkt und horizontalen Text‑Frame‑Rändern von 0. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) ist auf [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) gesetzt, sodass Textgröße und Rahmenabmessungen fix bleiben.

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

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) ermöglicht es zulässiger Interpunktion, über den rechten Rand der Textzeile hinauszuragen, anstatt in die nächste Zeile zu rücken. Sie gilt für den gesamten Absatz und unterscheidet sich von einem hängenden Einzug.

Das folgende eigenständige Beispiel aktiviert hängende Interpunktion in einem 100‑Punkt‑breiten Text‑Frame und speichert „hanging_punctuation.pptx“. Mit Arial 24 Punkt und horizontalen Text‑Frame‑Rändern von 0 bleibt der abschließende Punkt nach „sentence“ und ragt über den rechten Textrand hinaus. Setzen Sie die Eigenschaft auf [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/), um zu vergleichen: Mit diesen Einstellungen belegt der Punkt eine eigene Zeile. Zeilenumbruch ist aktiviert und AutoFit deaktiviert, um die verfügbare Breite festzuhalten.

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

Nicht jedes Satzzeichen kann hängen. Das sichtbare Ergebnis hängt von [Schrift‑ und Layout‑Bedingungen](#control-line-breaking) ab: Änderungen von Schrift, verfügbarer Breite, Rändern oder AutoFit‑Einstellungen können den Unterschied entfernen.

## **AutoFit‑Typ für Text‑Frames festlegen**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Containers überschreitet. Verwenden Sie ihn, um zu steuern, ob der Text schrumpft, überläuft oder die Form automatisch anpasst. Das folgende Beispiel konfiguriert die Form so, dass sie sich an den Text anpasst, und speichert das Ergebnis unter „autofit_type.pptx“.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Um nach automatischem Zeilenumbruch die Zeilen zu zählen und zu sehen, wie sich Text‑ oder Formbreite auf das Ergebnis auswirken, siehe [Rendered‑Zeilen zählen](/slides/de/python-net/manage-paragraph/). Die reine Zeilenzahl gibt keinen Hinweis darauf, ob Text seinen Container überläuft.

## **Verankerung von Text‑Frames festlegen**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) definiert, wie Text vertikal innerhalb einer Form positioniert wird, z. B. oben, mittig oder unten. Das folgende Beispiel verankert den Text am unteren Rand der ersten Form und speichert das Ergebnis unter „text_anchor.pptx“.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Tabulatoren für Text festlegen**

Verwenden Sie [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) und [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/), um Tabstopps in einem Absatz zu konfigurieren. Das folgende Beispiel setzt das Standard‑Tabintervall auf 100 Punkte und fügt einen linksbündigen Tab‑Stopp bei 30 Punkten hinzu. Diese Einstellungen wirken sich auf Text mit Tab‑Zeichen aus.

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

![Die Absatz‑Tabulatoren](paragraph_tabs.png)

## **Korrektursprache festlegen**

Aspose.Slides stellt [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) bereit, mit dem Sie die Korrektursprache für einen Textabschnitt festlegen können. Die Korrektursprache bestimmt die Sprache für Rechtschreib‑ und Grammatikprüfung in PowerPoint.

Das folgende Beispiel erfordert „presentation.pptx“ mit einem Textfeld als erster Form auf der ersten Folie und mindestens einem Absatz. Es ersetzt den Inhalt des ersten Absatzes durch „1。“, setzt SimSun als Schrift und weist die vereinfachte chinesische Korrektursprache (`zh-CN`) zu. Das Ergebnis wird unter „proofing_language.pptx“ gespeichert:

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

    # Setze die Korrektursprache auf vereinfachtes Chinesisch.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **Sprach‑Metadaten kopieren**

Wenn Sie mehrsprachigen Text aus einer Vorlage kopieren, erhalten Sie sowohl [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) als auch [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/) erhalten. Das folgende eigenständige Beispiel erzeugt einen Quell‑Abschnitt mit US‑Englisch als Sprache und Französisch als alternativer Sprache und kopiert Text und Kennungen in einen Abschnitt einer neuen Präsentation.

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # Wenn die Quelle keine alternative Sprache hat, löscht None den Zielwert.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

Um eine Quelle ohne alternative Sprache zu testen, lassen Sie die Zuweisung von `"fr-FR"` weg. Der alternative Kennwert ist dann `None` und dieselbe Kopieranweisung bewahrt dessen Fehlen, ohne einen Standardwert einzufügen, selbst wenn das Ziel zuvor eine alternative Sprache hatte.

Diese Kennungen speichern Sprach‑Metadaten. Das Beibehalten beeinflusst nicht, welches Wörterbuch PowerPoint für Rechtschreibung oder Grammatik verwendet.

## **Standard‑Sprache festlegen**

Verwenden Sie [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/), um die Standardsprache für Text festzulegen, der beim Laden oder Erstellen einer Präsentation erzeugt wird. Das folgende Beispiel erstellt eine Präsentation mit US‑Englisch als Standard‑Textsprache, fügt ein Textfeld hinzu und gibt `en-US` für den ersten Textabschnitt aus.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Füge eine neue Rechteckform mit Text hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Prüfe die Sprache des ersten Abschnitts.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Standard‑Textstil festlegen**

Um Standard‑Textformatierung auf Präsentationsebene anzuwenden, verwenden Sie [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Das folgende Beispiel legt eine fette Schrift von 14 Punkt als Standard für Absätze der obersten Ebene in einer neuen Präsentation fest und speichert sie unter „default_text_style.pptx“. Text kann diese Vorgaben erben, sofern nicht spezifischere Formatierungen sie überschreiben.

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

## **Text mit All‑Caps‑Effekt extrahieren**

In PowerPoint macht der Font‑Effekt **All Caps** den Text auf der Folie in Großbuchstaben sichtbar, selbst wenn er ursprünglich in Kleinbuchstaben eingegeben wurde. Wenn Sie einen solchen Textabschnitt mit Aspose.Slides auslesen, liefert die Bibliothek den Text exakt so, wie er eingegeben wurde. Um den angezeigten Text zu erhalten, prüfen Sie [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) und wandeln die zurückgegebene Zeichenkette in Großbuchstaben um, wenn der Wert `ALL` ist.

Dieses Beispiel erfordert „sample2.pptx“ mit einem Textfeld als erster Form auf der ersten Folie. Der erste Absatz‑erste Abschnitt enthält „Hello, Aspose!“ mit angewendetem All‑Caps‑Effekt, wie unten gezeigt.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Der folgende Code zeigt, wie der Text mit angewendetem **All Caps**‑Effekt extrahiert wird:

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

**Wie kann ich Text in einer Tabelle auf einer Folie ändern?**

Verwenden Sie [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Durchlaufen Sie die Zellen und aktualisieren Sie jede Zelle über [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) und die Absatz‑Formatierung über [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Wie kann ich einem Text auf einer PowerPoint‑Folie einen Farbverlauf zuweisen?**

Verwenden Sie [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Setzen Sie [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) auf [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) und konfigurieren Sie die Gradient‑Stops, Richtung und Transparenz.

Verwandtes Feature: [Text in Folien formatieren](/slides/de/features/text-formatting/).