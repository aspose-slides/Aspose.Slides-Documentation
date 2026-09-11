---
title: "Abrufen effektiver Formeigenschaften aus Präsentationen in Python via Java"
linktitle: "Effektive Eigenschaften"
type: docs
weight: 50
url: /de/python-java/shape-effective-properties/
keywords:
  - "Formeigenschaften"
  - "Kameraeigenschaften"
  - "Beleuchtungssystem"
  - "Fasenform"
  - "Textrahmen"
  - "Textstil"
  - "Schriftgröße"
  - "Füllformat"
  - "PowerPoint"
  - "Präsentation"
  - "Python"
  - "Java"
  - "Aspose.Slides"
description: "Erfahren Sie, wie Sie Aspose.Slides für Python via Java verwenden, um lokale, geerbte und effektive Formformatierungen in PowerPoint-Präsentationen zu unterscheiden."
---
## **Lokale, geerbte und effektive Eigenschaften verstehen**

PowerPoint-Formatierungen können aus mehreren Quellen stammen. Der direkt auf einem Objekt gespeicherte Wert ist sein **lokaler Wert**. Ist dieser Wert nicht gesetzt, prüft PowerPoint die übergeordneten Formatierungsquellen, wie einen Absatzstandard, einen Textstil, ein Layout‑ oder Master‑Folie, ein Design oder Präsentations‑Standardwerte. Diese Werte sind **geerbte Werte**. Der Wert, der nach Auflösung der gesamten Hierarchie verbleibt, ist der **effektive Wert** — der zum Rendern des Objekts verwendete Wert.

Zum Beispiel definiert ein Textabschnitt möglicherweise keine eigene Schriftgröße. Sein lokaler [getFontHeight](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#getFontHeight)-Wert ist dann `float("nan")`, was „hier nicht festgelegt“ bedeutet. Der Abschnitt kann eine Höhe von seinem Absatz, dem Standard‑Textstil der Präsentation oder einer anderen zutreffenden Quelle erben. Aufrufen von [getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/#getEffective) auf dem Abschnittsformat liefert die endgültig aufgelöste Höhe.

- Lesen oder ändern Sie ein lokales Formatobjekt, z. B. [PortionFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/), wenn Sie steuern müssen, wo ein Wert definiert ist.
- Lesen Sie ein effektives Datenobjekt, z. B. `PortionFormatEffectiveData`, wenn Sie das endgültige, gerenderte Ergebnis benötigen. Effektive Daten sind schreibgeschützt.

## **Lokale, geerbte und effektive Werte vergleichen**

Das folgende vollständige Beispiel erstellt eine Form und wendet Schriftgrößen auf Präsentations‑, Absatz‑ und Abschnittsebene an. Jeder Schritt gibt die auf diesen Ebenen definierten Werte sowie den resultierenden effektiven Wert für denselben Textabschnitt aus. Es zeigt außerdem, warum effektive Daten nach Formatierungsänderungen erneut gelesen werden müssen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # Effektive Daten nach den vorherigen Änderungen lesen.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # Geerbte Werte auf zwei verschiedenen Ebenen festlegen.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Ein lokaler Wert im Abschnitt überschreibt beide geerbten Werte.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Das Ändern eines geerbten Wertes überschreibt keinen bestehenden lokalen Wert.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Den lokalen Wert löschen. Der Abschnitt erbt nun wieder vom Absatz.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Den Absatzwert löschen. Der Präsentationsstandard liefert nun das Ergebnis.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Priorität in diesem Beispiel liegt auf der lokalen Formatierung des Abschnitts, danach auf der Absatzformatierung und schließlich auf dem Präsentationsstandard. Andere Objekte können unterschiedliche Vererbungsketten haben, aber das Prinzip ist dasselbe: ein spezifischerer expliziter Wert gewinnt, und [getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/#getEffective) liefert das Endergebnis.

## **Effektive Texteigenschaften abrufen**

Die Textformatierung ist auf mehrere Objekte verteilt:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#getEffective) löst Textrahmen‑Eigenschaften wie Ränder, Verankerung, AutoFit und vertikale Textausrichtung auf.
- [TextStyle.getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/textstyle/#getEffective) löst Absatzformatierungen für jede Textstil‑Ebene auf.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#getEffective) löst Absatzeigenschaften wie Ausrichtung, Einrückung und Aufzählungszeichen auf.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/#getEffective) löst Zeichen­eigenschaften wie Schriftgröße, Schriftart, Farbe, Fett und Kursiv auf.

Für das nächste Beispiel muss `text-formatting.pptx` mindestens eine Folie und eine [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) mit einem nicht leeren Textfeld enthalten. Die AutoShape kann an beliebiger Stelle in der Formen­sammlung stehen; der Code sucht nach einem geeigneten Objekt und prüft es, bevor es verwendet wird.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **Effektive 3D‑Eigenschaften abrufen**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getEffective) gibt ein `ThreeDFormatEffectiveData`‑Objekt zurück, das alle aufgelösten 3D‑Einstellungen gruppiert. Seine Methoden `getCamera`, `getLightRig`, `getBevelTop` und `getBevelBottom` stellen die entsprechenden effektiven Daten bereit. Das gleichzeitige Lesen dieser zusammengehörigen Einstellungen erleichtert das Verständnis des endgültigen 3D‑Erscheinungsbilds einer Form.

Für dieses Beispiel muss `shape-3d.pptx` mindestens eine Form auf der ersten Folie enthalten. Wenden Sie 3D‑Kamera-, Beleuchtungs‑ oder Schräge‑Einstellungen auf diese Form an, wenn die Ausgabe Werte enthalten soll, die von den Vorgabewerten abweichen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **Effektive Tabellenformatierung abrufen**

Die Tabellenformatierung kann aus dem Tabellenstil und aus Formaten stammen, die auf die gesamte Tabelle, eine Spalte, eine Zeile oder eine einzelne Zelle angewendet werden. Bei Konflikten zwischen explizit definierten Füllungen ist die Priorität: Zelle, Zeile, Spalte und dann gesamte Tabelle. Das effektive Format einer Zelle ist das endgültige Format, das zum Zeichnen dieser Zelle verwendet wird.

Für dieses Beispiel muss `table-formatting.pptx` mindestens eine Tabelle auf der ersten Folie enthalten. Die Tabelle muss mindestens eine Zeile und eine Spalte haben. Der Code sucht nach einer [Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/), anstatt anzunehmen, dass `getShapes().get_Item(0)` eine Tabelle ist.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

Wenn Sie die Farbe benötigen und nicht nur den Fülltyp, prüfen Sie zuerst den effektiven `getFillType` und lesen dann die Methode, die für diesen Typ gilt — z. B. `getSolidFillColor` für eine einfarbige Füllung.

## **Effektive Daten nach Änderungen erneut lesen**

Effektive Daten beschreiben die Formatierungshierarchie zum Zeitpunkt ihrer Auflösung. Rufen Sie [getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/#getEffective) erneut auf, nachdem Sie irgendetwas geändert haben, das an dieser Hierarchie teilnehmen kann, einschließlich:

- der lokalen Formatierung des Objekts;
- Absatz‑ oder Text‑Rahmen‑Standardwerte;
- einem Tabellenstil, einer Tabelle, einer Spalte, Zeile oder Zellenformat;
- Layout‑ oder Master‑Folien‑Formatierung;
- Design‑Daten oder Präsentations‑Standardwerte;
- dem Layout oder Master, das einer Folie zugewiesen ist.

Bewahren Sie kein effektives Datenobjekt als permanente Momentaufnahme auf. Aspose.Slides kann einige effektive Daten intern zwischenspeichern, und ein späterer Aufruf von [getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/#getEffective) kann diese Daten aktualisieren. Wenn Sie Werte vor und nach einer Änderung vergleichen müssen, kopieren Sie die benötigten Skalare — z. B. eine Schriftgröße, Farbe, Ausrichtung oder Schräge‑Breite — in eigene Variablen, bevor Sie die Änderung vornehmen.

Um einen Wert zu ändern, aktualisieren Sie das entsprechende lokale Formatobjekt und rufen dann [getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/#getEffective) auf, um das Ergebnis zu überprüfen. Effektive Datenobjekte selbst sind schreibgeschützt.

## **FAQ**

**Wie kann ich feststellen, welche Ebene einen effektiven Wert bereitgestellt hat?**

Effektive Daten enthalten den endgültigen Wert, nicht dessen Quelle. Untersuchen Sie die zutreffenden lokalen Objekte von der spezifischsten Ebene nach außen. Für Text kann dies den Abschnitt, Absatz, Textrahmen, Layout, Master, Design und die Präsentations‑Standardwerte umfassen. Nicht definierte Werte wie `float("nan")` oder `None` zeigen an, dass die Suche auf eine andere Ebene fortgesetzt wird.

**Was passiert, wenn keine Ebene eine Eigenschaft definiert?**

Aspose.Slides ermittelt den entsprechenden PowerPoint‑ oder Bibliotheksstandard. Dieser aufgelöste Wert erscheint in den effektiven Daten, obwohl kein lokales Objekt ihn explizit definiert.

**Warum entspricht ein effektiver Wert manchmal dem lokalen Wert?**

Der lokale Wert hat die Vererbungsberechnung gewonnen. Das ist zu erwarten, wenn die Eigenschaft explizit am Objekt gesetzt ist und keine spezifischere Regel sie überschreibt.

**Wann sollte ich lokale Daten anstelle von effektiven Daten verwenden?**

Verwenden Sie lokale Daten, um ein bestimmtes Formatierungsebene zu prüfen oder zu bearbeiten. Verwenden Sie effektive Daten, wenn Sie das endgültige Erscheinungsbild nach Vererbung, Designregeln und angewendeten Stilen benötigen. Das [komplette Vergleichsbeispiel](#compare-local-inherited-and-effective-values) demonstriert beides im selben Arbeitsablauf.