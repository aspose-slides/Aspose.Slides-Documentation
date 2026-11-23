---
title: Text in Präsentationen mit Python formatieren
linktitle: Textformatierung
type: docs
weight: 50
url: /de/python-net/text-formatting/
keywords:
- Absatz ausrichten
- Textstil
- Text-Hintergrund
- Texttransparenz
- Zeichenabstand
- Schrifteigenschaften
- Schriftfamilie
- Textrotation
- Drehwinkel
- Textrahmen
- Zeilenabstand
- Autofit‑Eigenschaft
- Textrahmen‑Anker
- Text-Tabulation
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Formatieren und gestalten Sie Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET. Passen Sie Schriftarten, Farben, Ausrichtung und mehr an."
---
## **Übersicht**

Dieser Artikel zeigt, wie man Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET formatiert. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schrifteigenschaften, Drehung, Absatzabstand, Autofit‑Verhalten, Textverankerung, Tabstopps und Spracheinstellungen.

Wenn nicht anders angegeben, verwenden die Beispiele [sample.pptx](sample.pptx). Die erste Form auf ihrer ersten Folie ist ein Textfeld, und ihr erster Absatz enthält den unten gezeigten Text. Sowohl Folien‑ als auch Form‑Indizes beginnen bei Null. Beispiele, die fett formatierte Bereiche auswählen, verwenden effektive Formatierung, einschließlich geerbter Fettformatierung:

![Beispieltext](sample_text.png)

Um wörtlichen Text oder reguläre Ausdruck‑Übereinstimmungen zu finden und zu markieren, siehe [Search and Replace Text](/slides/de/python-net/search-and-replace-text/).

## **Text‑Hintergrundfarbe festlegen**

Verwenden Sie [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/), um die Standard‑Hervorhebungsfarbe für einen Absatz festzulegen, oder verwenden Sie [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) für einzelne Textbereiche.

Das folgende Beispiel setzt eine hellgraue Hervorhebung als Standard für den ersten Absatz. Explizite Hervorhebungsfarben in einzelnen Bereichen haben Vorrang vor diesem Standard:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Setzen Sie die Hervorhebungsfarbe für den gesamten Absatz.
    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der graue Absatz](gray_paragraph.png)

Das nachstehende Codebeispiel zeigt, wie man die Hintergrundfarbe für **Textbereiche mit einer fetten Schrift** festlegt:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Setzen Sie die Hervorhebungsfarbe für den Textbereich.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die grauen Textbereiche](gray_text_portions.png)

## **Textabsätze ausrichten**

Verwenden Sie [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), um die Absatzausrichtung innerhalb eines Textrahmens festzulegen. Der Wert kann zentriert, linksbündig, rechtsbündig, Block‑satz usw. sein.

Das folgende Codebeispiel zeigt, wie man den Absatz **zentriert** ausrichtet:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Setzen Sie die Ausrichtung des Absatzes auf Zentriert.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der ausgerichtete Absatz](aligned_paragraph.png)

## **Schriftarten innerhalb einer Zeile ausrichten**

Verwenden Sie [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/), um Textbereiche mit unterschiedlichen Schriftgrößen innerhalb einer Zeile vertikal auszurichten. Diese Einstellung gilt für den gesamten Absatz und steuert die Ausrichtung in jeder seiner Zeilen.

Das folgende eigenständige Beispiel erstellt vier beschriftete Textfelder auf einer Folie. Jeder Absatz enthält denselben Text in 18, 36 und 54 Punkten mit unterschiedlicher Schrift‑ausrichtung. Es verwendet Arial, deaktiviert Autofit und Zeilenumbruch und lässt die Textrahmen groß genug für eine einzelne Zeile.

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

![Vergleich von Grundlinie, Oben, Mitte und Unten Schrift­ausrichtung bei gemischten Schriftgrößen](font_alignment.png)

Die Schrift­ausrichtung verwendet Schriftmetriken, sodass die sichtbaren Kanten einzelner Buchstaben nicht unbedingt exakt übereinstimmen. Das Beispiel enthält sowohl einen Großbuchstaben als auch einen Tieffall, um den Unterschied zwischen Grundlinien‑ und Unter‑Ausrichtung zu verdeutlichen. Verfügbarkeit und Ersetzung von Schriften, die verwendeten Zeichen und die unterschiedlichen Schriftgrößen beeinflussen das Ergebnis. Rahmenabmessungen, Ränder, Zeilenabstand, Zeilenumbruch und Autofit wirken sich ebenfalls auf das Layout aus; verwenden Sie für den Vergleich dieselben Schriften und Layout‑Einstellungen.

Diese Einstellung unterscheidet sich von [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), die die horizontale Absatz‑ausrichtung steuert, und von [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), die den Textblock vertikal innerhalb seiner Form positioniert. Hoch‑ und Tiefstellung über [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) verschiebt einzelne Bereiche relativ zur Grundlinie, anstatt die Schrift­ausrichtung für die Zeilen des Absatzes festzulegen.

## **Transparenz für Text festlegen**

Die Texttransparenz wird über die Alpha‑Komponente der Farbe gesteuert, die [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) zugewiesen ist. In den nachstehenden Beispielen ist `alpha = 50` ein ARGB‑Alpha‑Kanalwert im Bereich 0‑255 und kein Transparenz­prozentsatz.

Das nachstehende Codebeispiel zeigt, wie man Transparenz auf den **gesamten Absatz** anwendet:

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

Das folgende Codebeispiel zeigt, wie man Transparenz auf **Textbereiche mit fetter Schrift** anwendet:

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
            # Setzen Sie die Transparenz des Textbereichs.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die transparenten Textbereiche](transparent_text_portions.png)

## **Zeichenabstand für Text festlegen**

Verwenden Sie [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/), um den Abstand zwischen Zeichen in einem Textfeld zu vergrößern oder zu verkleinern. Die Beispiele fügen 3 Punkte Abstand hinzu; negative Werte verkleinern den Text.

Der folgende Python‑Code zeigt, wie man den Zeichenabstand im **gesamten Absatz** vergrößert:

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

Das untenstehende Codebeispiel zeigt, wie man den Zeichenabstand in **Textbereichen mit fetter Schrift** vergrößert:

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

![Der Zeichenabstand in den Textbereichen](character_spacing_in_text_portions.png)

### **Kerning für bestimmte Schriften deaktivieren**

In manchen Fällen kann von Aspose.Slides gerenderter Text leicht enger wirken als derselbe Text in PowerPoint. Das kann passieren, weil PowerPoint Kerning‑Daten für bestimmte Schriften ignorieren kann, selbst wenn die Schrift gültige Kerning‑Informationen enthält und Kerning in den PowerPoint‑Einstellungen aktiviert ist.

Um die gerenderte Ausgabe in solchen Fällen PowerPoint anzunähern, können Sie das Kerning für Textbereiche deaktivieren, die die betroffene Schrift verwenden. Setzen Sie [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) auf einen Wert, der größer ist als die tatsächliche Schriftgröße. Dieses Beispiel benötigt "presentation.pptx" mit einem Textfeld als erstes Objekt auf der ersten Folie. Es prüft die effektiven Schriftarten, einschließlich geerbter Schriften, und legt einen Schwellenwert von 100 Punkten für Bereiche fest, die Roboto verwenden. Dadurch wird das Kerning für passende Bereiche mit einer Schriftgröße unter 100 Punkten deaktiviert:

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

Für passende Texte unterhalb des Schwellenwerts verhindert diese Einstellung das Kerning und kann dabei helfen, die Darstellung von Aspose.Slides mit der visuellen Ausgabe von PowerPoint für von diesem PowerPoint‑spezifischen Verhalten betroffene Schriften abzustimmen.

## **Schrifteigenschaften für Text verwalten**

Schrifteigenschaften können auf Absatzebene über [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) oder für einzelne Bereiche über [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) festgelegt werden.

Das folgende Beispiel setzt die Standardschrift des ersten Absatzes auf 12‑Punkt Times New Roman mit Fett‑, Kursiv‑ und gepunkteter Unterstreichung. Explizite Formatierung einzelner Bereiche hat Vorrang vor diesen Vorgaben:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Setzen Sie die Schrifteigenschaften für den Absatz.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

![Die Schrifteigenschaften für den Absatz](font_properties_for_paragraph.png)

Das folgende Beispiel wendet 13‑Punkt Times New Roman, Kursiv-Formatierung und eine gepunktete Unterstreichung auf Bereiche an, deren effektive Formatierung fett ist:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Setzen Sie die Schrifteigenschaften für den Textbereich.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

![Die Schrifteigenschaften für Textbereiche](font_properties_for_text_portions.png)

## **Text‑Höhen‑Normalisierung steuern**

Verwenden Sie [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/), wenn Sie Vorlagentypografie reproduzieren oder Unterschiede in der Zeichenhöhe untersuchen. In PowerPoint streckt oder komprimiert das Aktivieren der Normalisierung einzelne Zeichen vertikal, um ihnen innerhalb des Textbereichs eine einheitliche sichtbare Höhe zu geben. Es garantiert keine gleichen Text‑höhen bei unterschiedlichen Schriften.

Setzen Sie die Eigenschaft auf [NullableBool.TRUE or FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) , um Normalisierung explizit zu aktivieren bzw. zu deaktivieren. `NullableBool.NOT_DEFINED` lässt die lokale Einstellung undefiniert, sodass der Bereich seinen Wert z. B. vom Absatz‑[default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) erbt. Das bedeutet nicht `False`. Verwenden Sie [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) und lesen Sie [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) , um den aufgelösten booleschen Wert zu erhalten.

Das folgende eigenständige Beispiel erfordert, dass **Arial** installiert ist. Es erstellt zwei Textblöcke mit denselben Großbuchstaben, Kleinbuchstaben, Tieffällen und Zeichen mit Akzenten in 54 Punkten. Beide Absätze aktivieren die Normalisierung standardmäßig. Der obere Bereich deaktiviert sie explizit; der untere Bereich erbt sie. Rahmen‑Größe, Ränder und Absatzabstand sind identisch, Zeilenumbruch und Autofit sind deaktiviert, um den Vergleich konsistent zu halten. Das Beispiel gibt `FALSE: False` und `NOT_DEFINED: True` aus und speichert anschließend „text_height_normalization.pptx“.

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

Der nachstehende Vergleich stammt aus der gespeicherten Präsentation. Die obere Zeile hat die Normalisierung deaktiviert (`FALSE`); die untere Zeile erbt die aktivierte Einstellung (`NOT_DEFINED` → `True`). Stellen Sie sicher, dass Arial installiert ist, um dieses Aussehen zu reproduzieren.

![Arial‑Text mit 54 Punkt, oben mit deaktivierter Normalisierung und unten mit geerbter aktivierter Normalisierung](text_height_normalization.png)

Normalisierung ändert die Zeichenhöhe, ohne den zugewiesenen [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/)‑Wert zu ändern, der die Schriftgröße in Punkten angibt. Der Absatz‑[space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) steuert den Zeilenabstand, während das Text‑Rahmen‑[autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) bestimmt, wie Text oder sein Container angepasst wird. Diese Einstellungen dienen unterschiedlichen Zwecken und können das Gesamtlayout unabhängig beeinflussen. Weitere Informationen zur Absatzformatierung und Vererbung finden Sie unter [Manage Paragraph](/slides/de/python-net/manage-paragraph/).

## **Durchgestrichenen Text anwenden und entfernen**

Verwenden Sie [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) für einen Textbereich, um Korrekturen, gestrichene Begriffe oder frühere Preise anzuzeigen, ohne den Originaltext zu löschen. Setzen Sie ihn auf [TextStrikethroughType.SINGLE or DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) , um eine bzw. zwei Durchstreichungen im Text zu erzeugen.

Um Durchstreichungen zu entfernen, weisen Sie `TextStrikethroughType.NONE` zu. Dies deaktiviert den Effekt explizit, selbst wenn die umgebende Formatierung Durchstreichungen vorsieht. Im Gegensatz dazu lässt `TextStrikethroughType.NOT_DEFINED` die lokale Einstellung undefiniert, sodass der Bereich die Formatierung vererben kann, z. B. vom Absatz. Das garantiert nicht, dass die Durchstreichung entfernt wird. Verwenden Sie [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) , um die resultierende Formatierung, einschließlich geerbter Werte, zu lesen.

Das folgende eigenständige Beispiel erstellt drei Preisvergleiche. Jeder Absatz enthält separate Bereiche für die Bezeichnung, den vorherigen Preis und den aktuellen Preis, sodass nur der vorherige Preis betroffen ist. Die erste Zeile wendet Durchstreichungen an und entfernt sie dann wieder; die anderen Zeilen behalten einzelne bzw. doppelte Durchstreichungen bei. Das Ändern dieser Eigenschaft bewahrt den Text und seine übrige Formatierung, einschließlich des fetten vorherigen Preises.

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

Das Ergebnis von oben nach unten: keine Durchstreichung, einzelne Durchstreichung und doppelte Durchstreichung.

![Vorherige Preise ohne Durchstreichung, mit einzelner Durchstreichung und mit doppelter Durchstreichung](strikethrough.png)

## **Text‑Drehung festlegen**

Verwenden Sie [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) , um eine vordefinierte Textausrichtung innerhalb einer Form festzulegen.

Das folgende Codebeispiel setzt die Textausrichtung in der Form auf [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) , wodurch der Text **90 Grad gegen den Uhrzeigersinn** gedreht wird:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![Die Text‑Drehung](text_rotation.png)

## **Ziffern nebeneinander im vertikalen Text anzeigen**

Um eine zweistellige Zahl in einem vertikalen japanischen Etikett zusammenzuhalten, setzen Sie beide Ziffern in einen Textbereich und legen Sie [BasePortionFormat.kumimoji](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kumimoji/) für diesen Bereich fest. Das Beispiel erstellt zwei Etiketten in einer neuen Präsentation mit [TextVerticalType.EAST_ASIAN_VERTICAL](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) und 40‑Punkt MS Gothic. Nur der dem numerischen Bereich zugewiesene [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/)‑Wert unterscheidet sich:

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

In PowerPoint zeigt das linke Etikett (`TRUE`) die Ziffern aufrecht und nebeneinander zwischen 和 und 年. Im rechten Etikett (`FALSE`) ist das Paar um 90 Grad im Uhrzeigersinn gedreht. Die umgebenden japanischen Zeichen bleiben in beiden Etiketten aufrecht.

![PowerPoint‑Vergleich von vertikalen Datums‑Etiketten mit aufrechten Ziffern links und gedrehten Ziffern rechts.](vertical_date.png)

## **Benutzerdefinierte Drehung für Textrahmen festlegen**

Verwenden Sie [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) , um einen benutzerdefinierten Drehwinkel für einen [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) festzulegen.

Das nachstehende Codebeispiel dreht den Textrahmen um 3 Grad im Uhrzeigersinn innerhalb der Form:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![Die benutzerdefinierte Text‑Drehung](custom_text_rotation.png)

## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides stellt [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/) , [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) und [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) bereit, um den Absatzabstand zu steuern. Diese Eigenschaften werden wie folgt verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhöhe anzugeben.
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkten anzugeben.

Das folgende Beispiel setzt den Abstand innerhalb des ersten Absatzes auf 200 % der Zeilenhöhe (doppelter Zeilenabstand):

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

![Der Zeilenabstand im Absatz](line_spacing.png)

## **Zeilenumbruch steuern**

Absatz‑Zeilenumbruch‑Regeln sind nützlich in schmalen Textblöcken und Präsentationen, die lateinischen und ostasiatischen Text mischen. Die folgenden Eigenschaften gehören zu [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) , sodass sie für einen gesamten Absatz gelten:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) steuert die Zeilenumbruch‑Regeln für lateinischen Text. Bei gemischtem Text kann eine Änderung auch die Stelle beeinflussen, an der benachbarter ostasiatischer Text und Interpunktion umbrochen werden.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) steuert die Zeilenumbruch‑Regeln für ostasiatischen Text, einschließlich Beschränkungen für Zeichen am Anfang und Ende einer Zeile.

Diese Regeln ersetzen nicht [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) , das automatischen Zeilenumbruch innerhalb eines Textrahmens aktiviert. Sie beeinflussen das Layout, wenn ein Zeilenumbruch auftritt; sie fügen keine Zeilenumbruch‑Zeichen ein. Ein expliziter Zeilenumbruch erzwingt eine neue Zeile im Absatz, unabhängig von der verfügbaren Breite.

Das folgende eigenständige Beispiel erstellt einen schmalen Textblock mit chinesischem und lateinischem Text. Es setzt beide Zeilenumbruch‑Eigenschaften explizit und speichert „line_breaking.pptx“. Um mit einer der Regeln zu experimentieren, ändern Sie den Wert dieser Eigenschaft, während die anderen Einstellungen unverändert bleiben. Das Beispiel verwendet 24‑Punkt Arial und SimSun bei einer Rahmenbreite von 160 Punkt und horizontalen Text‑Rahmen‑Rändern von 0. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) ist auf [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) gesetzt, damit Textgröße und Rahmenabmessungen fest bleiben.

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

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) ermöglicht es zulässiger Interpunktion, über den rechten Rand der Textzeile hinauszuragen, anstatt die nächste Zeile zu belegen. Sie gilt für den gesamten Absatz und unterscheidet sich von einem hängenden Einzug.

Das folgende eigenständige Beispiel aktiviert hängende Interpunktion in einem 100‑Punkt breiten Textrahmen und speichert „hanging_punctuation.pptx“. Mit 24‑Punkt Arial und horizontalen Text‑Rahmen‑Rändern von 0 bleibt der abschließende Punkt nach „sentence“ und ragt über den rechten Textrand hinaus. Setzen Sie die Eigenschaft auf [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) , um zu vergleichen: Mit diesen Einstellungen befindet sich der Punkt in einer eigenen Zeile. Zeilenumbruch ist aktiviert und Autofit deaktiviert, um die verfügbare Breite festzuhalten.

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

Nicht jedes Interpunktionszeichen kann hängen. Das sichtbare Ergebnis hängt von [Schrift‑ und Layout‑Bedingungen](#control-line-breaking) ab: Das Ändern der Schrift, der verfügbaren Breite, der Ränder oder der Autofit‑Einstellungen kann den sichtbaren Unterschied entfernen.

## **Autofit‑Typ für Textrahmen festlegen**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Containers überschreitet. Verwenden Sie es, um zu steuern, ob der Text schrumpft, überläuft oder die Form automatisch anpasst. Das folgende Beispiel konfiguriert die Form so, dass sie ihre Größe an den Text anpasst und speichert das Ergebnis in „autofit_type.pptx“.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Um Zeilen nach automatischem Zeilenumbruch zu zählen und zu sehen, wie Text‑ oder Formbreite das Ergebnis verändern, siehe [Count Rendered Lines](/slides/de/python-net/manage-paragraph/). Die reine Zeilenzahl sagt nicht aus, ob Text seinen Container überläuft.

## **Anker von Textrahmen festlegen**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) definiert, wie Text vertikal innerhalb einer Form positioniert wird, z. B. oben, mittig oder unten. Das folgende Beispiel verankert den Text am unteren Rand der ersten Form und speichert das Ergebnis in „text_anchor.pptx“.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Text‑Tabulation festlegen**

Verwenden Sie [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) und [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) , um Tabstopps in einem Absatz zu konfigurieren. Das folgende Beispiel setzt das Standard‑Tab‑Intervall auf 100 Punkte und fügt einen linksbündigen Tab‑Stopp bei 30 Punkten hinzu. Diese Einstellungen betreffen Text, der Tab‑Zeichen enthält.

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

![Die Absatz‑Tabstopps](paragraph_tabs.png)

## **Korrektursprache festlegen**

Aspose.Slides bietet [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) , mit dem Sie die Korrektursprache für einen Textbereich festlegen können. Die Korrektursprache bestimmt die Sprache, die für Rechtschreib‑ und Grammatikprüfungen in PowerPoint verwendet wird.

Das folgende Beispiel benötigt „presentation.pptx“ mit einem Textfeld als erstes Objekt auf der ersten Folie und mindestens einen Absatz. Es ersetzt den Inhalt des ersten Absatzes durch „1。“, setzt SimSun als Schrift und weist die vereinfachte chinesische Korrektursprache (`zh-CN`) zu. Es speichert das Ergebnis in „proofing_language.pptx“:

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

### **Sprach‑Metadaten kopieren**

Beim Kopieren mehrsprachigen Textes aus einer Vorlage sollten sowohl [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) als auch [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/) erhalten bleiben. Das folgende eigenständige Beispiel erzeugt einen Quell‑Bereich mit US‑Englisch als Sprache und Französisch als alternativer Sprache und kopiert den Text sowie die Identifikatoren in einen Bereich einer neuen Präsentation.

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

Um eine Quelle ohne alternative Sprache zu testen, lassen Sie die Zuweisung von "fr-FR" weg. Der alternative Bezeichner ist dann `None`, und dieselbe Kopier‑Anweisung bewahrt dessen Fehlen, ohne einen Standardwert einzufügen, selbst wenn das Ziel zuvor eine alternative Sprache zugewiesen hatte.

Diese Bezeichner werden als Sprach‑Metadaten gespeichert. Das Bewahren dieser Daten legt nicht fest, welches Wörterbuch PowerPoint für Rechtschreib‑ oder Grammatikprüfungen verwendet.

## **Standard‑Sprache festlegen**

Verwenden Sie [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) , um die Standardsprache für Text festzulegen, der beim Laden oder Erstellen einer Präsentation erzeugt wird. Das folgende Beispiel erstellt eine Präsentation mit US‑Englisch als Standard‑Textsprache, fügt ein Textfeld hinzu und gibt `en-US` für dessen ersten Textbereich aus.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Füge eine neue Rechteckform mit Text hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Prüfe die Sprache des ersten Textbereichs.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Standard‑Textstil festlegen**

Um standardmäßige Textformatierung auf Präsentationsebene anzuwenden, verwenden Sie [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Das folgende Beispiel setzt eine 14‑Punkt fette Schrift als Standard für Absatz‑Erste‑Ebene in einer neuen Präsentation und speichert sie in „default_text_style.pptx“. Text kann diese Vorgaben erben, sofern keine spezifischere Formatierung sie überschreibt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Holen Sie das Absatzformat der obersten Ebene.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Text mit All‑Caps‑Effekt extrahieren**

In PowerPoint sorgt die Anwendung des **All‑Caps**‑Schrifteffekts dafür, dass Text auf der Folie in Großbuchstaben erscheint, selbst wenn er ursprünglich in Kleinbuchstaben eingegeben wurde. Wenn Sie einen solchen Textbereich mit Aspose.Slides abrufen, gibt die Bibliothek den Text exakt so zurück, wie er eingegeben wurde. Um den angezeigten Text zu erhalten, prüfen Sie [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) , und wandeln Sie die zurückgegebene Zeichenkette in Großbuchstaben um, wenn der Wert `ALL` ist.

Dieses Beispiel benötigt „sample2.pptx“ mit einem Textfeld als erstes Objekt auf der ersten Folie. Der erste Textbereich des ersten Absatzes enthält "Hello, Aspose!" mit angewendetem All‑Caps‑Effekt, wie unten gezeigt.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Das nachstehende Codebeispiel zeigt, wie man den Text mit angewendetem **All‑Caps**‑Effekt extrahiert:

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

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Wie ändere ich Text in einer Tabelle auf einer Folie?**

Um Text in einer Tabelle auf einer Folie zu ändern, verwenden Sie [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Durchlaufen Sie die Zellen und aktualisieren Sie jede Zelle über [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) , sowie die Absatzformatierung über [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Wie wende ich einen Farbverlauf auf Text einer PowerPoint‑Folie an?**

Um einen Farbverlauf auf Text anzuwenden, verwenden Sie [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Setzen Sie [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) auf [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) und konfigurieren Sie die Farbverlauf‑Stopps, Richtung und Transparenz.

Verwandte Funktion: [Format text within slides](/slides/de/features/text-formatting/).