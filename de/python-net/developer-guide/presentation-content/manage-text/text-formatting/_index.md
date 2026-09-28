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
- Autofit-Eigenschaft
- Textfeldverankerung
- Texttabulatoren
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET formatieren und gestalten. Schriftarten, Farben, Ausrichtung und mehr anpassen."
---
## **Übersicht**

Dieser Artikel zeigt, wie Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET formatiert wird. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schriftarteigenschaften, Drehung, Absatzabstaende, Autofit-Verhalten, Textverankerung, Tabstopps und Spracheinstellungen.

Sofern nicht anders angegeben, verwenden die Beispiele [sample.pptx](sample.pptx). Die erste Form auf der ersten Folie ist ein Textfeld, und ihr erster Absatz enthaelt den unten gezeigten Text. Sowohl Folien- als auch Form-Indizes sind nullbasiert. Beispiele, die fette Textstellen auswaehlen, verwenden die effektive Formatierung, einschließlich vererbter Fettschrift:

![Beispieltext](sample_text.png)

Um wortlichen Text oder regulaere Ausdruck-Uebereinstimmungen zu finden und hervorzuheben, siehe [Search and Replace Text](/slides/de/python-net/search-and-replace-text/).

## **Hintergrundfarbe für Text festlegen**

Verwenden Sie [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/default_portion_format/) , um die Standard-Hervorhebungsfarbe fuer einen Absatz festzulegen, oder verwenden Sie [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/highlight_color/) , um einzelne Textstellen zu formatieren.

Das folgende Beispiel legt eine hellgraue Hervorhebung als Standard fuer den ersten Absatz fest. Explizite Hervorhebungsfarben fuer einzelne Textstellen haben Vorrang vor diesem Standard:

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

Das nachstehende Codebeispiel zeigt, wie die Hintergrundfarbe fuer **Textstellen mit fetter Schrift** festgelegt wird:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Setze die Hervorhebungsfarbe für die Textstelle.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die grauen Textstellen](gray_text_portions.png)

## **Textabsatz ausrichten**

Verwenden Sie [ParagraphFormat.alignment](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/alignment/) , um die Absatzausrichtung innerhalb eines Textfelds festzulegen. Der Wert kann zentriert, linksbuendig, rechtsbuendig, Blocksatz usw. sein.

Das folgende Codebeispiel zeigt, wie der Absatz **zentriert** ausgerichtet wird:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Setze die Ausrichtung des Absatzes auf Mitte.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der ausgerichtete Absatz](aligned_paragraph.png)

## **Transparenz fuer Text festlegen**

Die Texttransparenz wird ueber die Alpha-Komponente der Farbe gesteuert, die [BasePortionFormat.fill_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/fill_format/) zugewiesen wird. In den nachstehenden Beispielen ist `alpha = 50` ein ARGB-Alpha-Wert im Bereich 0-255 und keine Transparenz-Prozentsatz.

Das folgende Codebeispiel zeigt, wie Transparenz auf den **gesamten Absatz** angewendet wird:

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

Das folgende Codebeispiel zeigt, wie Transparenz auf **Textstellen mit fetter Schrift** angewendet wird:

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
            # Setze die Transparenz der Textstelle.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die transparenten Textstellen](transparent_text_portions.png)

## **Zeichenabstand fuer Text festlegen**

Verwenden Sie [BasePortionFormat.spacing](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/spacing/) , um den Abstand zwischen Zeichen in einem Textfeld zu vergroessern oder zu verringern. Die Beispiele fuegen einen Abstand von 3 Punkten hinzu; negative Werte verdichten den Text.

Der folgende Python-Code zeigt, wie der Zeichenabstand im **gesamten Absatz** vergroessert wird:

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

Das folgende Codebeispiel zeigt, wie der Zeichenabstand in **Textstellen mit fetter Schrift** vergroessert wird:

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

![Der Zeichenabstand in den Textstellen](character_spacing_in_text_portions.png)

### **Kerning fuer bestimmte Schriften deaktivieren**

In manchen Faellen kann Text, der von Aspose.Slides gerendert wird, etwas enger aussehen als derselbe Text in PowerPoint. Das kann passieren, weil PowerPoint Kerning-Daten fuer bestimmte Schriften ignorieren kann, selbst wenn die Schrift gueltige Kerning-Informationen enthält und Kerning in den PowerPoint-Einstellungen aktiviert ist.

Um die gerenderte Ausgabe in solchen Faellen PowerPoint anzunaehren, koennen Sie das Kerning fuer Textstellen deaktivieren, die die betroffene Schrift verwenden. Setzen Sie [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) , auf einen Wert, der groesser ist als die tatsaechliche Schriftgroesse. Dieses Beispiel benoetigt "presentation.pptx" mit einem Textfeld als erste Form auf der ersten Folie. Es prueft die effektiven Schriftnamen, einschließlich vererbter Schriften, und legt einen Schwellenwert von 100 Punkten fuer Textstellen fest, die Roboto verwenden. Damit wird das Kerning fuer passende Textstellen mit einer Schriftgroesse unter 100 Punkten deaktiviert:

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

Fuer passende Texte unterhalb des Schwellenwerts verhindert diese Einstellung das Kerning und kann dazu beitragen, dass das Rendering von Aspose.Slides bei diesen PowerPoint-spezifischen Schriften dem visuellen Ergebnis von PowerPoint entspricht.

## **Textschrift-Eigenschaften verwalten**

Schrifteigenschaften koennen auf Absatz-Ebene ueber [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/default_portion_format/) oder fuer einzelne Textstellen ueber [PortionFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/portionformat/) festgelegt werden.

Das folgende Beispiel legt die Standardschrift des ersten Absatzes auf 12 Punkt Times New Roman mit fett, kursiv und gepunkteter Unterstreichung fest. Explizite Formatierung für einzelne Textstellen hat Vorrang vor diesen Vorgaben.

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

![Die Schrifteigenschaften fuer den Absatz](font_properties_for_paragraph.png)

Das folgende Beispiel wendet 13 Punkt Times New Roman, kursive Formatierung und eine gepunktete Unterstreichung auf Textstellen an, deren effektive Formatierung fett ist:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Setze die Schriftarteigenschaften für die Textstelle.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Schrifteigenschaften fuer Textstellen](font_properties_for_text_portions.png)

## **Textrotation festlegen**

Verwenden Sie [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/text_vertical_type/) , um eine vordefinierte Textausrichtung innerhalb einer Form festzulegen.

Das folgende Codebeispiel setzt die Textausrichtung in der Form auf [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/de/python-net/aspose.slides/textverticaltype/), wodurch der Text **90 Grad gegen den Uhrzeigersinn** rotiert wird:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Textrotation](text_rotation.png)

## **Benutzerdefinierte Drehung fuer Textfelder festlegen**

Verwenden Sie [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/rotation_angle/) , um einen benutzerdefinierten Drehwinkel fuer ein [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) festzulegen.

Das nachstehende Codebeispiel rotiert das Textfeld um 3 Grad im Uhrzeigersinn innerhalb der Form:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die benutzerdefinierte Textrotation](custom_text_rotation.png)

## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides stellt [ParagraphFormat.space_after](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/space_before/), und [ParagraphFormat.space_within](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/space_within/) zur Verfuegung, um den Absatzabstand zu steuern. Diese Eigenschaften werden wie folgt verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhoehe anzugeben.
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkten anzugeben.

Das folgende Beispiel setzt den Abstand innerhalb des ersten Absatzes auf 200% der Zeilenhoehe (doppelter Zeilenabstand):

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

Regeln fuer den Absatz-Zeilenumbruch sind nuetzlich in schmalen Textblaecken und Praesentationenen, die lateinischen und ostasiatischen Text mischen. Die folgenden Eigenschaften gehoeren zu [ParagraphFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/), sodass sie auf einen gesamten Absatz angewendet werden:

- [latin_line_break](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/latin_line_break/) steuert die Zeilenumbruch-Regeln fuer lateinischen Text. In gemischtem Text kann eine Aenderung auch beeinflussen, wo benachbarter ostasiatischer Text und Interpunktion umbrochen werden.
- [east_asian_line_break](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/east_asian_line_break/) steuert die Zeilenumbruch-Regeln fuer ostasiatischen Text, einschliesslich Beschraenkungen fuer Zeichen am Anfang und am Ende einer Zeile.

Diese Regeln ersetzen nicht [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/wrap_text/), das automatisches Umbrechen innerhalb eines Textfeldes aktiviert. Sie beeinflussen das Layout, wenn ein Umbrechen erfolgt; sie fuegen keine Zeilenumbruch-Zeichen ein. Ein expliziter Zeilenumbruch erzaehlt eine neue Zeile im Absatz, unabhaengig von der verfuegbaren Breite.

Das folgende eigenstaendige Beispiel erstellt einen schmalen Textblock, der chinesischen und lateinischen Text enthaelt. Es setzt beide Zeilenumbruch-Eigenschaften explizit und speichert "line_breaking.pptx". Um mit einer der Regeln zu experimentieren, aendern Sie den Wert dieser Eigenschaft, waehrend die andere Einstellung unveraendert bleibt. Das Beispiel verwendet 24 Punkt Arial und SimSun bei einer Rahmenbreite von 160 Punkten und null horizontalen Textfeld-Rand. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/autofit_type/) ist auf [TextAutofitType.NONE](https://reference.aspose.com/slides/de/python-net/aspose.slides/textautofittype/) gesetzt, sodass Textgroesse und Rahmenabmessungen fixiert bleiben.

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

## **haengende Interpunktion steuern**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/hanging_punctuation/) ermoeglicht es geeigneter Interpunktion, ueber den rechten Rand der Textzeile hinaus zu reichen, anstatt die naechste Zeile zu belegen. Sie gilt fuer den gesamten Absatz und unterscheidet sich von einem haengenden Einzug.

Das folgende eigenstaendige Beispiel aktiviert haengende Interpunktion in einem 100-Punkte-breiten Textfeld und speichert "hanging_punctuation.pptx". Mit 24 Punkt Arial und null horizontalen Textfeld-Rand bleibt der abschliessende Punkt nach "sentence" und reicht ueber den rechten Textrand hinaus. Setzen Sie die Eigenschaft auf [NullableBool.FALSE](https://reference.aspose.com/slides/de/python-net/aspose.slides/nullablebool/) um zu vergleichen: mit diesen Einstellungen nimmt der Punkt eine separate Zeile ein. Umbrechen ist aktiviert und Autofit deaktiviert, um die verfuegbare Breite fest zu halten.

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

Nicht jedes Satzzeichen kann haengen. Das sichtbare Ergebnis haengt von Schriftart und Layout-Bedingungen ab: Aendern Sie die Schriftart, verfuegbare Breite, Rand oder Autofit-Einstellungen, kann den sichtbaren Unterschied entfernen.

## **Autofit-Typ fuer Textfelder festlegen**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/autofit_type/) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Containers ueberschreitet. Verwenden Sie es, um zu steuern, ob der Text schrumpft, ueberlaeuft oder die Form automatisch in der Groesse anpasst. Das folgende Beispiel konfiguriert die Form so, dass sie sich an den Text anpasst und speichert das Ergebnis in "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Um Zeilen nach automatischem Umbrechen zu zaehlen und zu sehen, wie sich Text- oder Form-Breite auf das Ergebnis auswirkt, siehe [Count Rendered Lines](/slides/de/python-net/manage-paragraph/). Die reine Zeilenzahl zeigt nicht an, ob Text seinen Container ueberlauft.

## **Verankerung von Textfeldern festlegen**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/anchoring_type/) definiert, wie Text vertikal innerhalb einer Form positioniert wird, zum Beispiel oben, mittig oder unten. Das folgende Beispiel verankert den Text am unteren Rand der ersten Form und speichert das Ergebnis in "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Texttabulation festlegen**

Verwenden Sie [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/default_tab_size/) und [ParagraphFormat.tabs](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/tabs/) , um Tabulatoren in einem Absatz zu konfigurieren. Das folgende Beispiel setzt den Standard-Tabulatorabstand auf 100 Punkte und fuegt einen linksbuendigen Tab-Stopp bei 30 Punkten hinzu. Diese Einstellungen wirken sich auf Text mit Tabulatorzeichen aus.

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

![Die Absatz-Tabulatoren](paragraph_tabs.png)

## **Korrektursprache festlegen**

Aspose.Slides stellt [BasePortionFormat.language_id](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/language_id/) bereit, mit dem Sie die Korrektursprache fuer eine Textstelle festlegen koennen. Die Korrektursprache bestimmt die Sprache, die fuer Rechtschreib- und Grammatikpruefungen in PowerPoint verwendet wird.

Das folgende Beispiel benoetigt "presentation.pptx" mit einem Textfeld als erste Form auf der ersten Folie und mindestens einen Absatz. Es ersetzt den Inhalt des ersten Absatzes durch "1。", setzt SimSun als Schrift und weist die vereinfachte chinesische Korrektursprache (`zh-CN`) zu. Das Ergebnis wird in "proofing_language.pptx" gespeichert:

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

## **Standard-Sprache festlegen**

Verwenden Sie [LoadOptions.default_text_language](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/default_text_language/) , um die Standardsprache fuer Text festzulegen, der beim Laden oder Erstellen einer Praesentation erzeugt wird. Das folgende Beispiel erstellt eine Praesentation mit US-Englisch als Standard-Textsprache, fuegt ein Textfeld hinzu und gibt `en-US` fuer seine erste Textstelle aus.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Füge eine neue Rechteckform mit Text hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Prüfe die Sprache des ersten Textteils.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Standard-Textstil festlegen**

Um die Standard-Textformatierung auf Praesentationsebene anzuwenden, verwenden Sie [Presentation.default_text_style](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/default_text_style/).

Das folgende Beispiel legt eine 14-Punkt fette Schrift als Standard fuer Hauptabsätze in einer neuen Praesentation fest und speichert sie in "default_text_style.pptx". Text kann diese Vorgaben erben, sofern nicht spezifischere Formatierungen sie ueberschreiben.

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

## **Text mit All-Caps-Effekt extrahieren**

In PowerPoint bewirkt die Anwendung des **All Caps**-Schrifteffekts, dass Text auf der Folie in Grossbuchstaben angezeigt wird, obwohl er urspruenglich in Kleinschreibung eingegeben wurde. Wenn Sie eine solche Textstelle mit Aspose.Slides abrufen, gibt die Bibliothek den Text exakt so zurueck, wie er eingegeben wurde. Um den angezeigten Text zu erhalten, pruefen Sie [TextCapType](https://reference.aspose.com/slides/de/python-net/aspose.slides/textcaptype/) und konvertieren Sie die zurueckgegebene Zeichenkette in Grossbuchstaben, wenn der Wert `ALL` ist.

Dieses Beispiel benoetigt "sample2.pptx" mit einem Textfeld als erste Form auf der ersten Folie. Die erste Textstelle des ersten Absatzes enthaelt "Hello, Aspose!" mit dem angewendeten All Caps-Effekt, wie unten gezeigt.

![Der All Caps-Effekt](all_caps_effect.png)

Das folgende Codebeispiel zeigt, wie der Text mit dem **All Caps**-Effekt extrahiert wird:

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

**Wie aendere ich Text in einer Tabelle auf einer Folie?**

Um Text in einer Tabelle auf einer Folie zu aendern, verwenden Sie [Table](https://reference.aspose.com/slides/de/python-net/aspose.slides/table/). Durchlaufen Sie die Zellen und aktualisieren Sie jede Zelle ueber [Cell.text_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/cell/text_frame/) sowie die Absatzformatierung ueber [Paragraph.paragraph_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/paragraph_format/).

**Wie wende ich einen Farbverlauf auf Text in einer PowerPoint-Folie an?**

Um einen Farbverlauf auf Text anzuwenden, verwenden Sie [BasePortionFormat.fill_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/fill_format/). Setzen Sie [FillFormat.fill_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/fillformat/fill_type/) auf [FillType.GRADIENT](https://reference.aspose.com/slides/de/python-net/aspose.slides/filltype/) und konfigurieren Sie die Verlaufspunkte, Richtung und Transparenz.