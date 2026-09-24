---
title: Formatieren von Präsentationstext in Python
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
- Texttabulation
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Formatieren und Gestalten von Text in PowerPoint- und OpenDocument-Präsentationen mithilfe von Aspose.Slides für Python via .NET. Schriftarten, Farben, Ausrichtung und mehr anpassen."
---
## **Übersicht**

Dieser Artikel zeigt, wie Text in PowerPoint- und OpenDocument‑Präsentationen mit Aspose.Slides für Python via .NET formatiert wird. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schrifteigenschaften, Drehung, Absatzabstand, Autofit‑Verhalten, Textverankerung, Tabulatoren und Spracheinstellungen.

In den nachfolgenden Beispielen verwenden wir die Datei „sample.pptx“, die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Sample text](sample_text.png)

Um wörtlichen Text bzw. reguläre Ausdrücke zu finden und zu markieren, siehe [Suchen und Ersetzen von Text](/slides/de/python-net/search-and-replace-text/).

## **Text‑Hintergrundfarbe festlegen**

Verwenden Sie [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/default_portion_format/), um die Standard‑Highlight‑Farbe für einen Absatz festzulegen, oder [PortionFormat.highlight_color](https://reference.aspose.com/slides/de/python-net/aspose.slides/portionformat/highlight_color/) für einzelne Textabschnitte.

Der folgende Code zeigt, wie die Hintergrundfarbe für den **gesamten Absatz** gesetzt wird:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Legt die Hervorhebungsfarbe für den gesamten Absatz fest.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The gray paragraph](gray_paragraph.png)

Der nachstehende Code demonstriert, wie die Hintergrundfarbe für **Textabschnitte mit fetter Schrift** gesetzt wird:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Legt die Hervorhebungsfarbe für den Textabschnitt fest.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The gray text portions](gray_text_portions.png)

## **Absatztext ausrichten**

Verwenden Sie [ParagraphFormat.alignment](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/alignment/), um die Absatzausrichtung innerhalb eines Textfelds festzulegen. Der Wert kann z. B. zentriert, linksbündig, rechtsbündig, Blocksatz usw. sein.

Der folgende Code zeigt, wie der Absatz **zentriert** ausgerichtet wird:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Legt die Ausrichtung des Absatzes auf die Mitte fest.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The aligned paragraph](aligned_paragraph.png)

## **Transparenz für Text festlegen**

Die Texttransparenz wird über die Alpha‑Komponente der Farbe gesteuert, die [PortionFormat.fill_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/portionformat/fill_format/) zugewiesen wird. In den nachfolgenden Beispielen ist `alpha = 50` ein ARGB‑Alpha‑Wert im Bereich 0‑255, nicht ein Transparenz‑Prozentsatz.

Der folgende Code zeigt, wie Transparenz für den **gesamten Absatz** angewendet wird:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Setze die Füllfarbe des Textes auf eine transparente Farbe.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The transparent paragraph](transparent_paragraph.png)

Der nachstehende Code zeigt, wie Transparenz für **Textabschnitte mit fetter Schrift** angewendet wird:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Setze die Transparenz des Textabschnitts.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The transparent text portions](transparent_text_portions.png)

## **Zeichenabstand für Text festlegen**

Verwenden Sie [BasePortionFormat.spacing](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/spacing/), um den Abstand zwischen Zeichen in einem Textfeld zu vergrößern oder zu verringern.

Der folgende Python‑Code zeigt, wie der Zeichenabstand im **gesamten Absatz** vergrößert wird:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu verringern.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Zeichenabstand vergrößern.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Der nachstehende Code zeigt, wie der Zeichenabstand in **Textabschnitten mit fetter Schrift** vergrößert wird:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu verringern.
            portion.portion_format.spacing = 3  # Zeichenabstand vergrößern.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Kerning für bestimmte Schriftarten deaktivieren**

In manchen Fällen kann der von Aspose.Slides gerenderte Text etwas enger erscheinen als derselbe Text in PowerPoint. Das kann passieren, weil PowerPoint Kerning‑Daten für bestimmte Schriftarten ignoriert, selbst wenn die Schriftart gültige Kerning‑Informationen enthält und Kerning in den PowerPoint‑Einstellungen aktiviert ist.

Um die gerenderte Ausgabe in solchen Fällen PowerPoint‑ähnlicher zu machen, können Sie Kerning für Textabschnitte deaktivieren, die die betroffene Schriftart verwenden. Setzen Sie [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) auf einen Wert, der deutlich größer ist als die tatsächliche Schriftgröße:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Diese Einstellung verhindert, dass Kerning auf passende Textabschnitte angewendet wird, und kann dazu beitragen, dass das Rendering von Aspose.Slides dem visuellen Ergebnis von PowerPoint für betroffene Schriftarten näher kommt.

## **Schrifteigenschaften von Text verwalten**

Schrifteigenschaften können auf Absatzebene über [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/default_portion_format/) oder für einzelne Abschnitte über [PortionFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/portionformat/) festgelegt werden.

Der folgende Code setzt Schrift und Textstil für den gesamten Absatz: Er wendet Schriftgröße, fett, kursiv, gepunktete Unterstreichung und die Schriftart Times New Roman auf alle Abschnitte im Absatz an.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Setzt die Schrifteigenschaften für den Absatz.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The font properties for the paragraph](font_properties_for_paragraph.png)

Der nachstehende Code wendet ähnliche Eigenschaften auf **Textabschnitte mit fetter Schrift** an:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Setzt die Schrifteigenschaften für den Textabschnitt.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Textdrehung festlegen**

Verwenden Sie [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/text_vertical_type/), um eine vordefinierte Textausrichtung innerhalb einer Form festzulegen.

Der folgende Code setzt die Textausrichtung in der Form auf `VERTICAL270`, wodurch der Text **90 Grad gegen den Uhrzeigersinn** gedreht wird:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The text rotation](text_rotation.png)

## **Benutzerdefinierte Drehung für Textfelder festlegen**

Verwenden Sie [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/rotation_angle/), um einen benutzerdefinierten Drehwinkel für ein [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) festzulegen.

Der nachstehende Code dreht das Textfeld um 3 Grad im Uhrzeigersinn innerhalb der Form:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The custom text rotation](custom_text_rotation.png)

## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides bietet [ParagraphFormat.space_after](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/space_before/) und [ParagraphFormat.space_within](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/space_within/) zur Steuerung des Absatzabstandes. Diese Eigenschaften werden folgendermaßen verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhöhe anzugeben.
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkten anzugeben.

Der folgende Code zeigt, wie der Zeilenabstand innerhalb des Absatzes spezifiziert wird:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The line spacing within the paragraph](line_spacing.png)

## **Autofit‑Typ für Textfelder festlegen**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/autofit_type/) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Containers überschreitet. Verwenden Sie es, um zu steuern, ob der Text verkleinert, überläuft oder die Form automatisch anpasst.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Um Zeilen nach automatischem Umbruch zu zählen und zu sehen, wie sich Text‑ bzw. Formbreite auf das Ergebnis auswirkt, siehe [Count Rendered Lines](/slides/de/python-net/manage-paragraph/). Die reine Zeilenzahl sagt nicht aus, ob Text den Container überläuft.

## **Anker von Textfeldern festlegen**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/anchoring_type/) definiert, wie Text vertikal innerhalb einer Form positioniert wird, z. B. oben, mittig oder unten.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Tabulation für Text festlegen**

Verwenden Sie [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/default_tab_size/) und [ParagraphFormat.tabs](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/tabs/), um Tabulatorstopps in einem Absatz zu konfigurieren.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The paragraph tabs](paragraph_tabs.png)

## **Korrektursprache festlegen**

Aspose.Slides bietet [PortionFormat.language_id](https://reference.aspose.com/slides/de/python-net/aspose.slides/portionformat/language_id/), mit dem Sie die Korrektursprache für einen Textabschnitt festlegen können. Die Korrektursprache bestimmt, welche Sprache für Rechtschreib‑ und Grammatikprüfung in PowerPoint verwendet wird.

Der folgende Code zeigt, wie die Korrektursprache für einen Textabschnitt gesetzt wird:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Setze die ID einer Korrektursprache.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Standard‑Sprache festlegen**

Verwenden Sie [LoadOptions.default_text_language](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/default_text_language/), um die Standardsprache für beim Laden oder Erstellen einer Präsentation erzeugten Text zu definieren.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Füge eine neue Rechteckform mit Text hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Überprüfe die Sprache des ersten Textabschnitts.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Standard‑Textstil festlegen**

Um standardmäßige Textformatierung auf Präsentationsebene anzuwenden, verwenden Sie [Presentation.default_text_style](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/default_text_style/).

Der folgende Code zeigt, wie ein fetter Standardschriftzug mit 14 pt Größe für sämtlichen Text über alle Folien hinweg in einer neuen Präsentation festgelegt wird.

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

In PowerPoint bewirkt der Font‑Effekt **All Caps**, dass Text auf der Folie in Großbuchstaben angezeigt wird, obwohl er ursprünglich klein geschrieben wurde. Wenn Sie einen solchen Textabschnitt mit Aspose.Slides auslesen, liefert die Bibliothek den ursprünglich eingegebenen Text zurück. Um den angezeigten Text zu erhalten, prüfen Sie [TextCapType](https://reference.aspose.com/slides/de/python-net/aspose.slides/textcaptype/) und wandeln Sie die zurückgegebene Zeichenkette in Großbuchstaben um, wenn der Wert `ALL` ist.

Angenommen, wir haben das folgende Textfeld auf der ersten Folie der Datei sample2.pptx.

![The All Caps effect](all_caps_effect.png)

Der nachstehende Code zeigt, wie der Text mit angewendetem **All Caps**‑Effekt extrahiert wird:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

**Wie kann Text in einer Tabelle auf einer Folie geändert werden?**

Verwenden Sie [Table](https://reference.aspose.com/slides/de/python-net/aspose.slides/table/). Durchlaufen Sie die Zellen und aktualisieren Sie jede Zelle über [Cell.text_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/cell/text_frame/) und die Absatzformatierung über [Paragraph.paragraph_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/paragraph_format/).

**Wie kann ich einen Farbverlauf auf Text in einer PowerPoint‑Folien anwenden?**

Verwenden Sie [PortionFormat.fill_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/portionformat/fill_format/). Setzen Sie [FillFormat.fill_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/fillformat/fill_type/) auf [FillType.GRADIENT](https://reference.aspose.com/slides/de/python-net/aspose.slides/filltype/) und konfigurieren Sie die Verlaufsstopps, Richtung und Transparenz.