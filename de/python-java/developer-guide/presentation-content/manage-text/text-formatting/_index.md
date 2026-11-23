---
title: Präsentationstext in Python via Java formatieren
linktitle: Textformatierung
type: docs
weight: 50
url: /de/python-java/text-formatting/
keywords:
- Absatz ausrichten
- Textstil
- Text-Hintergrund
- Text-Transparenz
- Zeichenabstand
- Schrifteigenschaften
- Schriftfamilie
- Textrotation
- Rotationswinkel
- Textfeld
- Zeilenabstand
- AutoFit-Eigenschaft
- Textfeld-Anker
- Tabulatoren
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via Java formatieren und gestalten. Schriftarten, Farben, Ausrichtung und mehr anpassen."
---
## **Übersicht**

Dieser Artikel zeigt, wie man Text in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Python via Java formatiert. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schrift‑Eigenschaften, Drehung, Absatzabstand, AutoFit‑Verhalten, Textverankerung, Tabstopps und Spracheinstellungen.

Sofern nicht anders angegeben, verwenden die Beispiele [sample.pptx](sample.pptx). Die erste Form auf der ersten Folie ist ein Textfeld, und ihr erster Absatz enthält den unten gezeigten Text. Sowohl Folien‑ als auch Form‑Indizes beginnen bei 0. Beispiele, die fette Textanteile auswählen, verwenden effektive Formatierung, einschließlich vererbter Fett­formatierung:

![Beispieltext](sample_text.png)

Um wörtlichen Text bzw. Übereinstimmungen per regulärem Ausdruck zu finden und hervorzuheben, siehe [Suchen und Ersetzen von Text](/slides/de/python-java/search-and-replace-text/).

## **Hintergrundfarbe für Text festlegen**

Verwenden Sie [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat), um die Standard‑Hervorhebungsfarbe für einen Absatz festzulegen, oder [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) für einzelne Textanteile.

Das folgende Beispiel setzt eine hellgraue Hervorhebung als Standard für den ersten Absatz. Explizite Hervorhebungsfarben bei einzelnen Anteilen haben Vorrang vor diesem Standard:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Legen Sie die Hervorhebungsfarbe für den gesamten Absatz fest.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Der graue Absatz](gray_paragraph.png)

Das Code‑Beispiel unten zeigt, wie man die Hintergrundfarbe für **Textanteile mit fetter Schrift** festlegt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Legen Sie die Hervorhebungsfarbe für den Textanteil fest.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die grauen Textanteile](gray_text_portions.png)

## **Textabsätze ausrichten**

Verwenden Sie [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment), um die Absatz‑Ausrichtung innerhalb eines Textfeldes festzulegen. Der Wert kann z. B. centered, left‑aligned, right‑aligned, justified usw. sein.

Das folgende Code‑Beispiel zeigt, wie man den Absatz **zentriert** ausrichtet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Setzen Sie die Ausrichtung des Absatzes auf die Mitte.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Der ausgerichtete Absatz](aligned_paragraph.png)

## **Schriftarten innerhalb einer Zeile ausrichten**

Verwenden Sie [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment), um Textanteile unterschiedlicher Schriftgrößen innerhalb einer Zeile vertikal auszurichten. Diese Einstellung gilt für den gesamten Absatz und steuert die Ausrichtung jeder Zeile.

Das folgende eigenständige Beispiel erzeugt vier beschriftete Textfelder auf einer Folie. Jeder Absatz enthält denselben Text in 18, 36 und 54 Punkten mit unterschiedlicher Schrift‑Ausrichtung. Es verwendet Arial, deaktiviert AutoFit und Zeilenumbruch und lässt die Textfelder groß genug für eine einzelne Zeile bleiben.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Vergleich von Baseline, Top, Center und Bottom Schrift‑Ausrichtung bei gemischten Schriftgrößen](font_alignment.png)

Die Schrift‑Ausrichtung verwendet Schrift‑Metriken, sodass die sichtbaren Kanten einzelner Buchstaben nicht exakt übereinstimmen müssen. Das Beispiel enthält sowohl einen Großbuchstaben als auch einen Tiefzeichen‑Buchstaben, um den Unterschied zwischen Baseline‑ und Bottom‑Ausrichtung zu verdeutlichen. Verfügbarkeit und Ersetzung von Schriften, die verwendeten Zeichen und die unterschiedlichen Schriftgrößen beeinflussen das Ergebnis. Rahmen‑Abmessungen, Ränder, Zeilenabstand, Zeilenumbruch und AutoFit wirken sich ebenfalls auf das Layout aus; verwenden Sie beim Vergleich dieselben Schriften und Layouteinstellungen.

Diese Einstellung unterscheidet sich von [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment), die die horizontale Absatz‑Ausrichtung steuert, und von [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType), die den Textblock vertikal innerhalb seiner Form positioniert. Hoch‑ und Tiefgestellt‑Formatierung über [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) verschiebt einzelne Anteile relativ zur Basislinie, anstatt die Schrift‑Ausrichtung für die Zeilen des Absatzes zu setzen.

## **Transparenz für Text festlegen**

Die Transparenz von Text wird über die Alpha‑Komponente der Farbe gesteuert, die [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) zugewiesen wird. In den nachfolgenden Beispielen bedeutet `alpha = 50` einen ARGB‑Alpha‑Wert auf der Skala 0‑255, nicht einen Transparenz‑Prozentsatz.

Das folgende Code‑Beispiel zeigt, wie man Transparenz auf den **gesamten Absatz** anwendet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Setzen Sie die Füllfarbe des Textes auf eine transparente Farbe.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Der transparente Absatz](transparent_paragraph.png)

Das folgende Code‑Beispiel zeigt, wie man Transparenz auf **Textanteile mit fetter Schrift** anwendet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Setzen Sie die Transparenz des Textanteils.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die transparenten Textanteile](transparent_text_portions.png)

## **Zeichenabstand für Text festlegen**

Verwenden Sie [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing), um den Abstand zwischen Zeichen in einem Textfeld zu vergrößern oder zu verkleinern. Die Beispiele fügen 3 Punkte Abstand hinzu; negative Werte verdichten den Text.

Der folgende Python‑Code zeigt, wie man den Zeichenabstand im **gesamten Absatz** vergrößert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Zeichenabstand erweitern.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Der Zeichenabstand im Absatz](character_spacing_in_paragraph.png)

Das nachfolgende Code‑Beispiel erweitert den Zeichenabstand in **Textanteilen mit fetter Schrift**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
            portion.getPortionFormat().setSpacing(3) # Zeichenabstand erweitern.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Der Zeichenabstand in den Textanteilen](character_spacing_in_text_portions.png)

### **Kerning für bestimmte Schriften deaktivieren**

In manchen Fällen kann Text, der von Aspose.Slides gerendert wird, etwas enger erscheinen als derselbe Text in PowerPoint. Das kann passieren, weil PowerPoint Kerning‑Daten für bestimmte Schriften ignoriert, selbst wenn die Schrift gültige Kerning‑Informationen enthält und Kerning in den PowerPoint‑Einstellungen aktiviert ist.

Um die gerenderte Ausgabe diesem Verhalten anzupassen, können Sie Kerning für Textanteile deaktivieren, die die betroffene Schrift verwenden. Setzen Sie [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) auf einen Wert, der größer ist als die tatsächliche Schriftgröße. Dieses Beispiel benötigt “presentation.pptx” mit einem Textfeld als erste Form auf der ersten Folie. Es prüft effektive Schrift‑Namen, einschließlich vererbter Schriften, und legt eine Schwelle von 100 Punkten für Anteile fest, die Roboto verwenden. Damit wird Kerning für passende Anteile mit einer Schriftgröße unter 100 Punkten deaktiviert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Für passende Texte unterhalb der Schwelle verhindert diese Einstellung Kerning und kann helfen, das Rendering von Aspose.Slides an die visuelle Ausgabe von PowerPoint für von diesem PowerPoint‑Verhalten betroffene Schriften anzupassen.

## **Schrift‑Eigenschaften von Text verwalten**

Schrift‑Eigenschaften können über [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) auf Absatz‑Ebene oder über [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) für einzelne Anteile festgelegt werden.

Das folgende Beispiel setzt die Standard‑Schrift des ersten Absatzes auf Times New Roman 12 pt mit Fett‑, Kursiv‑ und gepunkteter Unterstreichung. Explizite Formatierung einzelner Anteile hat Vorrang vor diesen Vorgaben:

```python
import jpapi
import asposeslides

if not jpapi.isJVMStarted():
    jpapi.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Setzen Sie die Schrift‑Eigenschaften für den Absatz.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die Schrift‑Eigenschaften für den Absatz](font_properties_for_paragraph.png)

Das folgende Beispiel wendet Times New Roman 13 pt, Kursiv‑Formatierung und gepunktete Unterstreichung auf Anteile an, deren effektive Formatierung fett ist:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Setzen Sie die Schrift‑Eigenschaften für den Textanteil.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die Schrift‑Eigenschaften für Textanteile](font_properties_for_text_portions.png)

## **Normalisierung der Text‑Höhe steuern**

Verwenden Sie [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight), wenn Sie Vorlagen‑Typografie reproduzieren oder Unterschiede in der Zeichenhöhe untersuchen. In PowerPoint streckt oder komprimiert das Aktivieren der Normalisierung einzelne Zeichen vertikal, sodass sie innerhalb des Textanteils eine einheitliche sichtbare Höhe besitzen. Es garantiert nicht gleiche Text‑Höhen über unterschiedliche Schriften hinweg.

Setzen Sie die Eigenschaft auf [NullableBool.True_ oder False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/), um Normalisierung explizit zu aktivieren bzw. zu deaktivieren. `NullableBool.NotDefined` lässt die lokale Einstellung ungesetzt, sodass der Anteil den Wert aus dem Absatz‑[getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) erben kann. Das bedeutet nicht `False`. Verwenden Sie [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) und lesen Sie `getNormaliseHeight` aus der zurückgegebenen effektiven Formatierung, um den aufgelösten booleschen Wert zu erhalten.

Das folgende eigenständige Beispiel erfordert **Arial**. Es erzeugt zwei Textblöcke mit denselben Groß‑, Kleinbuchstaben, Tiefzeichen und Sonderzeichen bei 54 pt. Beide Absätze aktivieren Normalisierung standardmäßig. Der obere Anteil deaktiviert sie explizit; der untere erbt sie. Rahmen‑Größen, Ränder und Absatz‑Abstand sind identisch, Zeilenumbruch und AutoFit sind deaktiviert, um den Vergleich konsistent zu halten. Das Beispiel gibt `False: False` und `NotDefined: True` aus und speichert “text_height_normalization.pptx”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Der untenstehende Vergleich stammt aus der gespeicherten Präsentation. Die obere Zeile hat Normalisierung deaktiviert (`False`); die untere Zeile erbt die aktivierte Einstellung (`NotDefined` → `True`). Arial muss installiert sein, um dieses Aussehen zu reproduzieren.

![Arial‑Text 54 pt mit deaktivierter Normalisierung oben und geerbter Normalisierung unten](text_height_normalization.png)

Normalisierung ändert die Zeichen‑Höhe, ohne den zugewiesenen Wert von [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight) zu verändern, der die Schriftgröße in Punkten angibt. Absatz‑[setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) steuert den Zeilenabstand, während Text‑Frame‑[setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) festlegt, wie Text oder dessen Container sich anpasst. Diese Einstellungen dienen unterschiedlichen Zwecken und können das Gesamtlayout unabhängig voneinander beeinflussen. Weitere Informationen zu Absatz‑Formatierung und Vererbung finden Sie unter [Absatz verwalten](/slides/de/python-java/manage-paragraph/).

## **Durchgestrichenen Text anwenden und entfernen**

Verwenden Sie [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) auf einem Textanteil, um Korrekturen, durchgestrichene Begriffe oder alte Preise darzustellen, ohne den Originaltext zu löschen. Setzen Sie ihn auf [TextStrikethroughType.Single oder Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) für eine bzw. zwei Linien durch den Text.

Um Durchstreichen zu entfernen, übergeben Sie [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None). Dadurch wird der Effekt ausdrücklich deaktiviert, selbst wenn das umgebende Formatting Durchstreichen angibt. Im Gegensatz dazu lässt [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) die lokale Einstellung undefiniert, sodass der Anteil das Formatting erben kann, etwa vom Absatz. Das garantiert nicht, dass Durchstreichen entfernt wird. Verwenden Sie [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), um das resultierende Formatting, einschließlich geerbter Werte, auszulesen.

Das folgende eigenständige Beispiel erstellt drei Preis‑Vergleiche. Jeder Absatz besitzt separate Anteile für Bezeichnung, alten Preis und aktuellen Preis, sodass nur der alte Preis betroffen ist. Die erste Zeile wendet Durchstreichen an und entfernt es anschließend; die anderen Zeilen behalten einfaches bzw. doppeltes Durchstreichen bei. Das Ändern dieser Einstellung bewahrt den Text und dessen übrige Formatierung, einschließlich des fetten alten Preises.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # Durchstreichen anwenden, dann explizit vom ersten vorherigen Preis entfernen.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis von oben nach unten: kein Durchstreichen, einfaches Durchstreichen und doppeltes Durchstreichen.

![Frühere Preise ohne Durchstreichen, mit einfachem Durchstreichen und mit doppeltem Durchstreichen](strikethrough.png)

## **Text‑Rotation festlegen**

Verwenden Sie [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType), um eine vordefinierte Text‑Ausrichtung innerhalb einer Form festzulegen.

Das folgende Code‑Beispiel setzt die Text‑Ausrichtung der Form auf [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/), wodurch der Text **90 Grad gegen den Uhrzeigersinn** rotiert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die Text‑Rotation](text_rotation.png)

## **Ziffern im vertikalen Text nebeneinander anzeigen**

Um die Ziffern einer zweistelligen Zahl nebeneinander im vertikalen japanischen Label zu halten, setzen Sie beide Ziffern in einen Textanteil und rufen [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKumimoji) für diesen Anteil auf. Beide Labels in diesem Beispiel verwenden [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/#EastAsianVertical) und 40‑pt MS Gothic. Nur die [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/)-Einstellung für die Ziffern unterscheidet sich.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Portion, Presentation, SaveFormat, ShapeType, TextVerticalType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    font = FontData("MS Gothic")

    for x, kumimoji in [(120, NullableBool.True_), (360, NullableBool.False_)]:
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        frame = label.addTextFrame("")
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical)

        paragraph = frame.getParagraphs().get_Item(0)
        default_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        default_format.setLatinFont(font)
        default_format.setEastAsianFont(font)
        default_format.setFontHeight(40)
        default_format.getFillFormat().setFillType(FillType.Solid)
        default_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        digits = Portion("12")
        digits.getPortionFormat().setKumimoji(kumimoji)
        
        portions = paragraph.getPortions()
        portions.clear()
        portions.add(Portion("令和"))
        portions.add(digits)
        portions.add(Portion("年"))

    presentation.save("vertical_date.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In PowerPoint zeigt das linke Label (`True`) die Ziffern aufrecht und nebeneinander zwischen 和 und 年. Im rechten Label (`False`) ist das Paar um 90 Grad im Uhrzeigersinn gedreht. Die umgebenden japanischen Zeichen bleiben in beiden Labels aufrecht.

![PowerPoint‑Vergleich vertikaler Datums‑Labels mit aufrechten Ziffern links und gedrehten Ziffern rechts.](vertical_date.png)

## **Benutzerdefinierte Rotation für Text‑Frames festlegen**

Verwenden Sie [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle), um einen benutzerdefinierten Rotationswinkel für einen [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) festzulegen.

Das folgende Code‑Beispiel dreht den Text‑Frame um 3 Grad im Uhrzeigersinn innerhalb der Form:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die benutzerdefinierte Text‑Rotation](custom_text_rotation.png)

## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides bietet [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) und [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) zur Steuerung des Absatz‑Abstands. Diese Eigenschaften werden wie folgt verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhöhe anzugeben.
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkten anzugeben.

Das folgende Beispiel setzt den Abstand innerhalb des ersten Absatzes auf 200 % der Zeilenhöhe (doppelter Zeilenabstand):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Der Zeilenabstand innerhalb des Absatzes](line_spacing.png)

## **Zeilenumbruch steuern**

Absatz‑Zeilenumbruch‑Regeln sind bei schmalen Textblöcken und Präsentationen, die lateinischen und ostasiatischen Text mischen, nützlich. Die folgenden Methoden gehören zu [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/) und gelten daher für einen gesamten Absatz:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) steuert die Zeilenumbruch‑Regeln für lateinischen Text. Beim gemischten Text kann eine Änderung auch das Umbrechen angrenzenden ostasiatischen Textes und der Interpunktion beeinflussen.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) steuert die Zeilenumbruch‑Regeln für ostasiatischen Text, einschließlich Beschränkungen für Zeichen am Anfang und Ende einer Zeile.

Diese Regeln ersetzen nicht [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText), das automatischen Zeilenumbruch innerhalb eines Text‑Frames aktiviert. Sie beeinflussen das Layout, wenn ein Umbruch stattfindet; sie fügen keine Zeilenumbruch‑Zeichen ein. Ein expliziter Zeilenumbruch erzwingt eine neue Zeile im Absatz unabhängig von der verfügbaren Breite.

Das folgende eigenständige Beispiel erzeugt einen schmalen Textblock mit chinesischem und lateinischem Text. Es setzt beide Zeilenumbruch‑Optionen explizit und speichert “line_breaking.pptx”. Um eine der Regeln zu testen, ändern Sie den entsprechenden Wert, während die andere Einstellung unverändert bleibt. Das Beispiel verwendet Arial 24 pt und SimSun, einen Rahmen von 160 pt Breite und horizontale Text‑Frame‑Ränder von 0. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) wird mit [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) aufgerufen, sodass Textgröße und Rahmen‑Abmessungen fix bleiben.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hängende Interpunktion steuern**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) ermöglicht es zulässiger Interpunktion, über den rechten Rand der Textzeile hinauszuragen, anstatt die nächste Zeile zu besetzen. Sie gilt für den gesamten Absatz und unterscheidet sich von einem hängenden Einzug.

Das folgende eigenständige Beispiel aktiviert hängende Interpunktion in einem 100‑pt‑breiten Text‑Frame und speichert “hanging_punctuation.pptx”. Mit Arial 24 pt und horizontalen Text‑Frame‑Rändern von 0 bleibt der abschließende Punkt nach “sentence” und ragt über den rechten Textrand hinaus. Setzen Sie die Eigenschaft auf [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/), um zu vergleichen: Mit diesen Einstellungen belegt der Punkt eine eigene Zeile. Zeilenumbruch ist aktiviert und AutoFit deaktiviert, um die verfügbare Breite fest zu halten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nicht jedes Satzzeichen kann hängen. Die [oben beschriebenen Schrift‑ und Layout‑Bedingungen](#control-line-breaking) gelten ebenfalls für diesen Vergleich: Änderungen an Schrift, verfügbarer Breite, Rändern oder AutoFit‑Einstellungen können den sichtbaren Unterschied entfernen.

## **AutoFit‑Typ für Text‑Frames festlegen**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Containers überschreitet. Verwenden Sie es, um zu steuern, ob der Text schrumpft, überläuft oder die Form automatisch an die Textgröße anpasst. Das folgende Beispiel konfiguriert die Form so, dass sie sich an den Text anpasst, und speichert das Ergebnis unter “autofit_type.pptx”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Um nach automatischem Zeilenumbruch die Zeilen zu zählen und zu sehen, wie Text‑ bzw. Form‑Breite das Ergebnis verändern, siehe [Gerenderte Zeilen zählen](/slides/de/python-java/manage-paragraph/). Die Zeilen‑Anzahl allein sagt nicht, ob Text seinen Container überläuft.

## **Verankerung von Text‑Frames festlegen**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) definiert, wie Text vertikal innerhalb einer Form positioniert wird, z. B. oben, mittig oder unten. Das folgende Beispiel verankert den Text am unteren Rand der ersten Form und speichert das Ergebnis unter “text_anchor.pptx”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tabulatoren für Text festlegen**

Verwenden Sie [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) und [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs), um Tabstopps in einem Absatz zu konfigurieren. Das folgende Beispiel setzt das Standard‑Tabintervall auf 100 pt und fügt einen linksbündigen Tabstopp bei 30 pt hinzu. Diese Einstellungen wirken sich auf Text mit Tab‑Zeichen aus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die Absatz‑Tabs](paragraph_tabs.png)

## **Rechtschreib‑Sprache festlegen**

Aspose.Slides bietet [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId), mit dem Sie die Rechtschreib‑Sprache für einen Textanteil festlegen können. Die Rechtschreib‑Sprache bestimmt, welche Sprache für Rechtschreib‑ und Grammatik‑Prüfungen in PowerPoint verwendet wird.

Das folgende Beispiel benötigt “presentation.pptx” mit einem Textfeld als erste Form auf der ersten Folie und mindestens einen Absatz. Es ersetzt den Inhalt des ersten Absatzes durch “1。”, setzt SimSun als Schrift und weist die vereinfachte chinesische Rechtschreib‑Sprache (`zh-CN`) zu. Das Ergebnis wird unter “proofing_language.pptx” gespeichert:

```python
import jpype
import asposeslides

if not jpapi.isJVMStarted():
    jpapi.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # Setzen Sie die Id einer Korrektursprache.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Sprach‑Metadaten kopieren**

Beim Kopieren mehrsprachigen Textes aus einer Vorlage sollten sowohl [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId) als auch [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) erhalten bleiben. Das folgende eigenständige Beispiel erstellt einen Quell‑Teil mit US‑Englisch als Sprache und Französisch als alternativer Sprache und kopiert Text sowie Identifier in einen Teil einer neuen Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # Wenn die Quelle keine alternative Sprache hat, löscht None den Zielwert.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Um eine Quelle ohne alternative Sprache zu testen, lassen Sie die Zuweisung von `"fr-FR"` weg. Der alternative Identifier ist dann `None`, und dieselbe Kopieranweisung bewahrt dessen Fehlen, ohne einen Standardwert einzuführen, selbst wenn das Ziel zuvor eine alternative Sprache zugewiesen hatte.

Diese Identifier speichern Sprach‑Metadaten. Das Bewahren beeinflusst nicht, welches Wörterbuch PowerPoint für Rechtschreibung oder Grammatik auswählt.

## **Standard‑Sprache festlegen**

Verwenden Sie [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), um die Standardsprache für Text festzulegen, der beim Laden oder Erstellen einer Präsentation erzeugt wird. Das folgende Beispiel erstellt eine Präsentation mit US‑Englisch als Standard‑Text‑Sprache, fügt ein Textfeld hinzu und gibt `en-US` für dessen ersten Textanteil aus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # Füge ein Rechteck-Shape mit Text hinzu.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Prüfe die Sprache des ersten Textanteils.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Standard‑Text‑Stil festlegen**

Um standardmäßige Text‑Formatierung auf Präsentations‑Ebene anzuwenden, verwenden Sie [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Das folgende Beispiel setzt eine 14‑pt fette Schrift als Standard für Absätze der obersten Ebene in einer neuen Präsentation und speichert sie unter “default_text_style.pptx”. Text kann diese Vorgaben erben, sofern keine spezifischere Formatierung sie überschreibt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpape.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Holen Sie das Absatzformat der obersten Ebene.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Text mit All‑Caps‑Effekt extrahieren**

In PowerPoint lässt der **All Caps**‑Schrifteffekt Text in Großbuchstaben erscheinen, obwohl er ursprünglich in Kleinbuchstaben eingegeben wurde. Wenn Sie einen solchen Textanteil mit Aspose.Slides abrufen, liefert die Bibliothek den Text exakt so, wie er eingegeben wurde. Um den angezeigten Text zu erhalten, prüfen Sie [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) und konvertieren Sie die zurückgegebene Zeichenkette in Großbuchstaben, wenn der Wert `All` ist.

Dieses Beispiel benötigt “sample2.pptx” mit einem Textfeld als erste Form auf der ersten Folie. Der erste Absatz‑erste Teil enthält “Hello, Aspose!” mit aktivierter All‑Caps‑Effekt, wie unten gezeigt.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Das folgende Code‑Beispiel zeigt, wie man den Text mit aktivierter **All Caps**‑Effekt extrahiert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

Ausgabe:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Wie kann ich Text in einer Tabelle auf einer Folie ändern?**

Um Text in einer Tabelle auf einer Folie zu ändern, verwenden Sie [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Durchlaufen Sie die Zellen und aktualisieren Sie jede Zelle über [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) und die Absatz‑Formatierung über [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Wie kann ich einem Text in einer PowerPoint‑Folie einen Farbverlauf zuweisen?**

Um einem Text einen Farbverlauf zuzuweisen, verwenden Sie [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Setzen Sie [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) auf [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) und konfigurieren Sie die Gradient‑Stops, Richtung und Transparenz.