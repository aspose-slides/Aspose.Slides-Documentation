---
title: Abrufen effektiver Shape-Eigenschaften aus Präsentationen in Python
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/python-net/shape-effective-properties/
keywords:
- Shape-Eigenschaften
- Kameraeigenschaften
- Lichtrig
- Bevel-Form
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aspose.Slides für Python über .NET verwenden, um lokale, geerbte und effektive Shape-Formatierungen in PowerPoint-Präsentationen zu unterscheiden."
---
## **Lokale, geerbte und effektive Eigenschaften verstehen**

PowerPoint‑Formatierungen können von mehreren Stellen stammen. Der direkt an einem Objekt gespeicherte Wert ist sein **lokaler Wert**. Wenn dieser Wert nicht gesetzt ist, prüft PowerPoint die übergeordneten Formatierungsquellen, wie z. B. den Absatz‑Standard, einen Textstil, ein Layout‑ oder Master‑Folie, ein Design oder Präsentations‑Standardwerte. Diese Werte sind **geerbte Werte**. Der Wert, der nach Auflösung der gesamten Hierarchie verbleibt, ist der **effektive Wert**, der zum Rendern des Objekts verwendet wird.

Zum Beispiel definiert ein Textabschnitt möglicherweise nicht seine eigene Schriftgröße. Sein lokaler [font_height](https://reference.aspose.com/slides/de/python-net/aspose.slides/ibaseportionformat/font_height/) ist dann `float("nan")`, was „hier nicht gesetzt“ bedeutet. Der Abschnitt kann eine Größe vom Absatz, dem Standard‑Textstil der Präsentation oder einer anderen zutreffenden Quelle erben. Der Aufruf von [get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/iportionformat/get_effective/) auf das Abschnittsformat liefert die endgültig aufgelöste Größe.

Verwenden Sie die beiden Arten von Formatierungsdaten für unterschiedliche Zwecke:

- Lesen oder ändern Sie ein lokales Formatobjekt, z. B. [IPortionFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/iportionformat/), wenn Sie steuern möchten, wo ein Wert definiert ist.
- Lesen Sie ein effektives Datenobjekt, z. B. [IPortionFormatEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/iportionformateffectivedata/), wenn Sie das endgültige, gerenderte Ergebnis benötigen. Effektive Daten sind schreibgeschützt.

## **Lokale, geerbte und effektive Werte vergleichen**

Das folgende vollständige Beispiel erstellt eine Form und wendet Schriftgrößen auf Präsentations‑, Absatz‑ und Abschnittsebene an. Jeder Schritt gibt die auf den jeweiligen Ebenen definierten Werte und den resultierenden effektiven Wert für denselben Textabschnitt aus. Es zeigt auch, warum effektive Daten nach Formatierungsänderungen erneut gelesen werden müssen.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # Effektive Daten nach den vorherigen Änderungen lesen.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # Geerbte Werte auf zwei verschiedenen Ebenen definieren.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Ein lokaler Wert im Abschnitt überschreibt beide geerbten Werte.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Das Ändern eines geerbten Werts überschreibt keinen vorhandenen lokalen Wert.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Den lokalen Wert löschen. Der Abschnitt erbt nun wieder vom Absatz.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Den Absatzwert löschen. Der Präsentationsstandard liefert nun das Ergebnis.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

Die Priorität in diesem Beispiel liegt bei der lokalen Formatierung des Abschnitts, dann der Absatzformatierung und zuletzt dem Präsentations‑Standard. Andere Objekte können unterschiedliche Vererbungsketten haben, aber das Prinzip ist dasselbe: Ein spezifischer, expliziter Wert gewinnt, und [get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides/iportionformat/get_effective/) liefert das Endergebnis.

## **Effektive Texteigenschaften abrufen**

Textformatierung ist auf mehrere Objekte verteilt:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/de/python-net/aspose.slides/itextframeformat/get_effective/) löst Text‑Frame‑Eigenschaften wie Ränder, Anker, Autofit und vertikale Textrichtung auf.
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/de/python-net/aspose.slides/itextstyle/get_effective/) löst Absatzformatierung für jede Textstil‑Ebene auf.
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/de/python-net/aspose.slides/iparagraphformat/get_effective/) löst Absatz‑Eigenschaften wie Ausrichtung, Einrückung und Aufzählungszeichen auf.
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/de/python-net/aspose.slides/iportionformat/get_effective/) löst Zeichen‑Eigenschaften wie Schriftgröße, Schriftart, Farbe, Fett und Kursiv auf.

Für das nächste Beispiel muss `text-formatting.pptx` mindestens eine Folie und ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) mit einem nicht leeren Text‑Frame enthalten. Das AutoShape kann an beliebiger Position in der Form‑Sammlung stehen; der Code sucht nach einem passenden Objekt und validiert es vor der Verwendung.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **Effektive 3D‑Eigenschaften abrufen**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/de/python-net/aspose.slides/ithreedformat/get_effective/) gibt ein [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/de/python-net/aspose.slides/ithreedformateffectivedata/)‑Objekt zurück, das alle aufgelösten 3D‑Einstellungen bündelt. Seine [camera](https://reference.aspose.com/slides/de/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/de/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/de/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/) und [bevel_bottom](https://reference.aspose.com/slides/de/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) Eigenschaften stellen die entsprechenden effektiven Daten bereit. Das gleichzeitige Lesen dieser zusammengehörigen Einstellungen erleichtert das Verständnis des endgültigen 3D‑Erscheinungsbildes einer Form.

Für dieses Beispiel muss `shape-3d.pptx` mindestens eine Form auf seiner ersten Folie enthalten. Wenden Sie dieser Form 3D‑Kamera-, Beleuchtungs‑ oder Abschrägungs‑Einstellungen an, wenn die Ausgabe Werte enthalten soll, die von den Vorgaben abweichen.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **Effektive Tabellenformatierung abrufen**

Tabellenformatierung kann aus dem Tabellenstil und aus Formaten stammen, die auf die gesamte Tabelle, eine Spalte, eine Zeile oder eine einzelne Zelle angewendet werden. Bei Konflikten zwischen explizit definierten Füllungen hat die Priorität Zelle, Zeile, Spalte und dann Gesamttabelle. Das effektive Format einer Zelle ist das endgültige Format, das zum Zeichnen dieser Zelle verwendet wird.

Für dieses Beispiel muss `table-formatting.pptx` mindestens eine Tabelle auf seiner ersten Folie enthalten. Die Tabelle muss mindestens eine Zeile und eine Spalte haben. Der Code sucht nach einem [Table](https://reference.aspose.com/slides/de/python-net/aspose.slides/table/)‑Objekt, statt anzunehmen, dass `shapes[0]` eine Tabelle ist.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

Wenn Sie die Farbe benötigen und nicht nur den Fülltyp, prüfen Sie zuerst den effektiven [fill_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/ifillformateffectivedata/fill_type/), und lesen Sie dann die für diesen Typ geltende Eigenschaft, z. B. [solid_fill_color](https://reference.aspose.com/slides/de/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) für eine einfarbige Füllung.

## **Effektive Daten nach Änderungen erneut lesen**

Effektive Daten beschreiben die Formatierungshierarchie zum Zeitpunkt ihrer Auflösung. Rufen Sie `get_effective` erneut auf, nachdem Sie etwas geändert haben, das an dieser Hierarchie teilnehmen kann, einschließlich:

- der lokalen Formatierung des Objekts;
- Absatz‑ oder Text‑Frame‑Standardeinstellungen;
- eines Tabellenstils, einer Tabelle, Spalte, Zeile oder Zellenformatierung;
- Layout‑ oder Master‑Folien‑Formatierung;
- Design‑Daten oder Präsentations‑Standardwerte;
- des Layouts oder Masters, das einer Folie zugewiesen ist.

Bewahren Sie kein effektives Datenobjekt als permanentes Snapshot‑Objekt auf. Aspose.Slides kann einige effektive Daten intern zwischenspeichern, und ein späterer Aufruf von `get_effective` kann diese Daten aktualisieren. Wenn Sie Werte vor und nach einer Änderung vergleichen müssen, kopieren Sie die skalaren Werte, die Sie benötigen (z. B. Schriftgröße, Farbe, Ausrichtung oder Abschrägungsbreite), in eigene Variablen, bevor Sie die Änderung vornehmen.

Um einen Wert zu ändern, aktualisieren Sie das entsprechende lokale Formatobjekt und rufen Sie anschließend `get_effective` auf, um das Ergebnis zu prüfen. Effektive Datenobjekte selbst sind schreibgeschützt.

## **FAQ**

**Wie kann ich feststellen, welche Ebene einen effektiven Wert geliefert hat?**

Effektive Daten enthalten den endgültigen Wert, nicht dessen Quelle. Untersuchen Sie die zutreffenden lokalen Objekte von der spezifischsten Ebene nach außen. Für Text kann das den Abschnitt, Absatz, Text‑Frame, Layout, Master, Design und Präsentations‑Standard umfassen. Nicht definierte Werte wie `float("nan")` oder `None` weisen darauf hin, dass die Suche zu einer weiteren Ebene fortgesetzt wird.

**Was passiert, wenn keine Ebene eine Eigenschaft definiert?**

Aspose.Slides löst den entsprechenden PowerPoint‑ oder Bibliotheks‑Standardwert auf. Dieser aufgelöste Wert erscheint in den effektiven Daten, auch wenn kein lokales Objekt ihn explizit definiert.

**Warum entspricht ein effektiver Wert manchmal dem lokalen Wert?**

Der lokale Wert hat die Vererbungsberechnung gewonnen. Dies ist zu erwarten, wenn die Eigenschaft am Objekt explizit gesetzt ist und keine spezifischere Regel ihr entgegenwirkt.

**Wann sollte ich lokale Daten statt effektiver Daten verwenden?**

Verwenden Sie lokale Daten, um ein bestimmtes Formatierungsebenen‑Objekt zu inspizieren oder zu bearbeiten. Verwenden Sie effektive Daten, wenn Sie das endgültige Erscheinungsbild nach Vererbung, Design‑Regeln und angewendeten Stilen benötigen. Das [complete comparison example](#compare-local-inherited-and-effective-values) demonstriert beides im selben Arbeitsablauf.