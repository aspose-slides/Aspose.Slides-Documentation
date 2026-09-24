---
title: Präsentationstext formatieren in Python über Java
linktitle: Textformatierung
type: docs
weight: 50
url: /de/python-java/text-formatting/
keywords:
- Absatz ausrichten
- Textstil
- Texthintergrund
- Texttransparenz
- Zeichenabstand
- Schrifteigenschaften
- Schriftfamilie
- Textrotation
- Rotationswinkel
- Textfeld
- Zeilenabstand
- Autofit‑Eigenschaft
- Textfeld‑Verankerung
- Texttabulation
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Formatieren und Gestalten von Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python über Java. Schriftarten, Farben, Ausrichtung und mehr anpassen."
---
## **Übersicht**

Dieser Artikel zeigt, wie man Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python über Java formatiert. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schriftarteigenschaften, Drehung, Absatzabstand, Autofit‑Verhalten, Textverankerung, Tabulatoren und Spracheinstellungen.

In den nachfolgenden Beispielen verwenden wir eine Datei namens "sample.pptx", die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Beispieltext](sample_text.png)

Um wörtlichen Text oder reguläre Ausdruck‑Übereinstimmungen zu finden und zu markieren, siehe [Suche und Ersetze Text](/slides/de/python-java/search-and-replace-text/).

## **Text-Hintergrundfarbe festlegen**

Verwenden Sie [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat), um die Standard‑Hervorhebungsfarbe für einen Absatz festzulegen, oder verwenden Sie [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/) für einzelne Textabschnitte.

Das folgende Codebeispiel zeigt, wie man die Hintergrundfarbe für den **gesamten Absatz** festlegt:

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

    # Setze die Hervorhebungsfarbe für den gesamten Absatz.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Der graue Absatz](gray_paragraph.png)

Das nachfolgende Codebeispiel demonstriert, wie man die Hintergrundfarbe für **Textabschnitte mit fetter Schrift** festlegt:

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
            # Setze die Hervorhebungsfarbe für den Textabschnitt.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die grauen Textabschnitte](gray_text_portions.png)

## **Absätze ausrichten**

Verwenden Sie [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#setAlignment), um die Absatzausrichtung innerhalb eines Textfelds festzulegen. Der Wert kann z. B. zentriert, linksbündig, rechtsbündig, block‑justiert usw. sein.

Das folgende Codebeispiel zeigt, wie man den Absatz **zentriert** ausrichtet:

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

    # Setze die Ausrichtung des Absatzes auf zentriert.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Der ausgerichtete Absatz](aligned_paragraph.png)

## **Transparenz für Text festlegen**

Die Texttransparenz wird über die Alpha‑Komponente der Farbe gesteuert, die [PortionFormat.getFillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/) zugewiesen wird. In den nachfolgenden Beispielen ist `alpha = 50` ein ARGB‑Alpha‑Wert im Bereich 0–255, nicht ein Transparenz‑Prozentsatz.

Das folgende Codebeispiel zeigt, wie man Transparenz für den **gesamten Absatz** anwendet:

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

    # Setze die Füllfarbe des Textes auf transparente Farbe.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Der transparente Absatz](transparent_paragraph.png)

Das folgende Codebeispiel zeigt, wie man Transparenz für **Textabschnitte mit fetter Schrift** anwendet:

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
            # Setze die Transparenz des Textabschnitts.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die transparenten Textabschnitte](transparent_text_portions.png)

## **Zeichenabstand für Text festlegen**

Verwenden Sie [PortionFormat.setSpacing](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/), um den Abstand zwischen Zeichen in einem Textfeld zu vergrößern oder zu verkleinern.

Der folgende Python‑Code zeigt, wie man den Zeichenabstand im **gesamten Absatz** erweitert:

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

Das nachfolgende Codebeispiel zeigt, wie man den Zeichenabstand in **Textabschnitten mit fetter Schrift** erweitert:

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

![Der Zeichenabstand in den Textabschnitten](character_spacing_in_text_portions.png)

### **Kerning für bestimmte Schriftarten deaktivieren**

In einigen Fällen kann der von Aspose.Slides gerenderte Text etwas enger wirken als derselbe Text in PowerPoint. Das kann auftreten, weil PowerPoint Kerning‑Daten für bestimmte Schriftarten ignoriert, selbst wenn die Schriftart gültige Kerning‑Informationen enthält und Kerning in den PowerPoint‑Einstellungen aktiviert ist.

Um das gerenderte Ergebnis in solchen Fällen PowerPoint‑ähnlicher zu machen, können Sie Kerning für Textabschnitte deaktivieren, die die betroffene Schriftart verwenden. Setzen Sie [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/) auf einen Wert, der deutlich größer ist als die tatsächliche Schriftgröße:

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
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Diese Einstellung verhindert, dass Kerning auf passende Textabschnitte angewendet wird, und kann dazu beitragen, dass das Rendering von Aspose.Slides dem visuellen Ergebnis von PowerPoint für von diesem PowerPoint‑spezifischen Verhalten betroffene Schriftarten näher kommt.

## **Schrifteigenschaften verwalten**

Schrifteigenschaften können auf Absatzebene über [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) oder für einzelne Abschnitte über [PortionFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/) festgelegt werden.

Der folgende Code legt die Schriftart und den Textstil für den gesamten Absatz fest: Er wendet Schriftgröße, Fett, Kursiv, gepunktete Unterstreichung und die Schriftart Times New Roman auf alle Abschnitte im Absatz an.

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

    # Setze die Schriftarteigenschaften für den Absatz.
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

![Die Schrifteigenschaften für den Absatz](font_properties_for_paragraph.png)

Das nachfolgende Codebeispiel wendet ähnliche Eigenschaften auf **Textabschnitte mit fetter Schrift** an:

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
            # Setze die Schriftarteigenschaften für den Textabschnitt.
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

![Die Schrifteigenschaften für Textabschnitte](font_properties_for_text_portions.png)

## **Textrotation festlegen**

Verwenden Sie [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setTextVerticalType), um eine vordefinierte Textorientierung innerhalb einer Form festzulegen.

Der folgende Code legt die Textorientierung in der Form auf `Vertical270` fest, wodurch der Text **90 Grad gegen den Uhrzeigersinn** rotiert wird:

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

![Die Textrotation](text_rotation.png)

## **Benutzerdefinierte Rotation für Textfelder festlegen**

Verwenden Sie [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setRotationAngle), um einen benutzerdefinierten Rotationswinkel für ein [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) festzulegen.

Das folgende Codebeispiel dreht das Textfeld um 3 Grad im Uhrzeigersinn innerhalb der Form:

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

![Die benutzerdefinierte Textrotation](custom_text_rotation.png)

## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides bietet [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#setSpaceBefore) und [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#setSpaceWithin) zur Steuerung des Absatzabstands. Diese Eigenschaften werden wie folgt verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhöhe anzugeben.
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkten anzugeben.

Das folgende Codebeispiel zeigt, wie man den Zeilenabstand innerhalb des Absatzes festlegt:

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

## **Autofit‑Typ für Textfelder festlegen**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setAutofitType) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Containers überschreitet. Verwenden Sie es, um zu steuern, ob der Text schrumpft, überläuft oder die Form automatisch anpasst.

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

Um Zeilen nach automatischem Umbruch zu zählen und zu sehen, wie sich Text‑ oder Formbreite auf das Ergebnis auswirkt, siehe [Zeilen zählen](/slides/de/python-java/manage-paragraph/). Die bloße Zeilenzahl gibt nicht an, ob Text seinen Container überläuft.

## **Verankerung von Textfeldern festlegen**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setAnchoringType) definiert, wie Text vertikal innerhalb einer Form positioniert wird, z. B. oben, mittig oder unten.

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

Verwenden Sie [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) und [ParagraphFormat.getTabs](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#getTabs), um Tabulatoren in einem Absatz zu konfigurieren.

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

![Die Absatz‑Tabulatoren](paragraph_tabs.png)

## **Korrektursprache festlegen**

Aspose.Slides stellt [PortionFormat.setLanguageId](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/) bereit, mit dem Sie die Korrektursprache für einen Textabschnitt festlegen können. Die Korrektursprache bestimmt, welche Sprache für Rechtschreib‑ und Grammatikprüfungen in PowerPoint verwendet wird.

Das folgende Codebeispiel zeigt, wie man die Korrektursprache für einen Textabschnitt festlegt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

    # Setze die Id einer Korrektursprache.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Standard‑Sprache festlegen**

Verwenden Sie [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), um die Standardsprache für Text, der beim Laden oder Erstellen einer Präsentation erzeugt wird, zu definieren.

```python
import jpide
import asposeslides

if not jpide.isJVMStarted():
    jpide.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # Füge eine Rechteckform mit Text hinzu.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Prüfe die Sprache des ersten Textabschnitts.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Standard‑Textstil festlegen**

Um die Standard‑Textformatierung auf Präsentationsebene anzuwenden, verwenden Sie [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Das folgende Codebeispiel zeigt, wie man für alle Texte in einer neuen Präsentation eine Standardschrift mit Fettdruck und einer Größe von 14 pt festlegt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Holen Sie das Absatzformat der höchsten Ebene.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Text mit All‑Caps‑Effekt extrahieren**

In PowerPoint bewirkt das Anwenden des **All Caps**‑Schrifteffekts, dass Text auf der Folie in Großbuchstaben angezeigt wird, selbst wenn er ursprünglich in Kleinbuchstaben eingegeben wurde. Wenn Sie einen solchen Textabschnitt mit Aspose.Slides abrufen, gibt die Bibliothek den Text exakt so zurück, wie er eingegeben wurde. Um den angezeigten Text zu erhalten, prüfen Sie [TextCapType](https://reference.aspose.com/slides/de/python-java/aspose.slides/textcaptype/) und konvertieren Sie die zurückgegebene Zeichenfolge in Großbuchstaben, wenn der Wert `All` ist.

Angenommen, wir haben das folgende Textfeld auf der ersten Folie der Datei sample2.pptx.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Das nachfolgende Codebeispiel zeigt, wie man den Text mit angewendetem **All Caps**‑Effekt extrahiert:

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

**Wie ändere ich Text in einer Tabelle auf einer Folie?**

Um Text in einer Tabelle auf einer Folie zu ändern, verwenden Sie [Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/). Durchlaufen Sie die Zellen und aktualisieren Sie jede Zelle über [Cell.getTextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/cell/#getTextFrame) sowie die Absatzformatierung über [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Wie wende ich einen Verlauf auf Text in einer PowerPoint‑Folie an?**

Um einen Farbverlauf auf Text anzuwenden, verwenden Sie [PortionFormat.getFillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/). Setzen Sie [FillFormat.setFillType](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/#setFillType) auf [FillType.Gradient](https://reference.aspose.com/slides/de/python-java/aspose.slides/filltype/#Gradient) und konfigurieren Sie die Verlaufspunkte, Richtung und Transparenz.