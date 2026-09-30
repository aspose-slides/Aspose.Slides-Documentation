---
title: "Verwalten von Zeilen und Spalten in PowerPoint‑Tabellen mit Python"
linktitle: "Zeilen und Spalten"
type: docs
weight: 20
url: /de/python-net/manage-rows-and-columns/
keywords:
- Tabellenzeile
- Tabellenspalte
- erste Zeile
- Tabellenkopfzeile
- Zeile klonen
- Spalte klonen
- Zeile kopieren
- Spalte kopieren
- Zeile entfernen
- Spalte entfernen
- Zeilentextformatierung
- Spaltentextformatierung
- Tabellenstil
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie Tabellenzeilen und -spalten in PowerPoint mit Aspose.Slides für Python via .NET und beschleunigen Sie die Bearbeitung von Präsentationen und Datenaktualisierungen."
---
## **Einleitung**

Aspose.Slides for Python via .NET ermöglicht die Verwaltung von Tabellenstruktur und -formatierung in PowerPoint‑Präsentationen über die [Tabelle](https://reference.aspose.com/slides/python-net/aspose.slides/table/) Klasse. Sie können eine Kopfzeilenzeile festlegen, Zeilen und Spalten klonen oder entfernen und Textformatierung auf eine ganze Zeile oder Spalte anwenden.

Dieser Artikel erklärt diese Vorgänge mit Python‑Beispielen. Er zeigt auch, wie Sie das Stil‑Preset einer Tabelle abrufen können, um es wiederzuverwenden. Tabellen‑Zeilen‑ und Spaltenindizes beginnen bei Null.

## **Zeilenhöhe steuern**

Verwenden Sie [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) um die minimale Höhe einer Zeile in Punkten festzulegen. Es ist eine Untergrenze, keine feste Höhe. [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) gibt die tatsächliche Höhe zurück und ist schreibgeschützt. Greifen Sie über [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/) auf die Zeile zu.

Das Beispiel lädt [row-height-input.pptx](row-height-input.pptx), das in der ersten Folie eine Tabelle als erste Form enthält. Ihre erste Zeile beginnt bei 70 Punkten. Die Zellen verwenden 18‑Punkt‑Arial‑Text, Zeilenumbruch und 6‑Punkt‑Oben‑und‑Unten‑Abstände; der längere Text in der zweiten Spalte wird auf mehrere Zeilen umgebrochen. Das Beispiel erhöht die Mindesthöhe auf 100 Punkte, reduziert sie anschließend auf 20 Punkte, gibt nach jeder Änderung die tatsächliche Höhe aus und speichert beide Ergebnisse.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

Bei der mitgelieferten Präsentation fügt das Erhöhen der Mindesthöhe der Zeile zusätzlichen Raum hinzu. Das Verringern entfernt diesen zusätzlichen Raum, aber die tatsächliche Höhe bleibt größer als 20 Punkte, weil Text und Zellenabstände mehr Platz benötigen. Das alleinige Reduzieren der Mindesthöhe kann die Zeile nicht unter den von ihrem Inhalt benötigten Raum bringen.

Mehrere Faktoren beeinflussen die tatsächliche Höhe:

- **Text und Schriftgröße:** Längerer Text, explizite Zeilenumbrüche oder eine größere Schrift können mehr vertikalen Platz benötigen.
- **Umbruch und Spaltenbreite:** Bei aktiviertem Umbruch kann eine schmalere [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) mehr Zeilen erzeugen. Eine breitere Spalte kann den vertikalen Platzbedarf reduzieren.
- **Zellabstände:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) und [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) fügen vertikalen Raum hinzu. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) und [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) reduzieren die für Text verfügbare Breite und können zusätzlichen Umbruch verursachen.

Für diese Tabelle ohne zusammengeführte Zellen bestimmt die Zelle, die den meisten vertikalen Raum benötigt, die inhaltlich getriebene Untergrenze für die gesamte Zeile. Um die Zeile kürzer zu machen, müssen Sie möglicherweise den Text verkürzen, die Schriftgröße oder Abstände reduzieren oder eine Spalte verbreitern.

Die untenstehenden Bilder zeigen dieselbe Tabelle im gleichen Maßstab. In diesem Durchlauf betrugen die tatsächlichen Höhen 70, 100 und 55.2 Punkte: Die letzte Zeile blieb höher als ihr Mindestwert von 20 Punkten. Genauere Textmessungen können je nach in Ihrer Umgebung verfügbaren Schriftarten variieren. Laden Sie die gespeicherten Ergebnisse herunter: [erhöhter Mindestwert](row-height-increased.pptx) und [reduzierter Mindestwert](row-height-decreased.pptx).

| Original: Minimum 70 pt, tatsächliche 70 pt | Erhöht: Minimum 100 pt, tatsächliche 100 pt | Verringert: Minimum 20 pt, tatsächliche 55.2 pt |
| --- | --- | --- |
| ![Originaltabelle mit einer ersten Zeile von 70 Punkten.](row-height-before.png) | ![Tabelle nach Erhöhung des Mindestwerts der ersten Zeile auf 100 Punkte.](row-height-increased.png) | ![Tabelle nach Verringerung des Mindestwerts der ersten Zeile auf 20 Punkte; umgebrochener Text hält die Zeile höher als das Minimum.](row-height-decreased.png) |

## **Erste Zeile als Kopfzeile festlegen**

Verwenden Sie die Eigenschaft [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/), um die erste Zeile für die Kopfzeilenformatierung zu markieren. Ihr Erscheinungsbild hängt vom auf die Tabelle angewendeten Tabellenstil ab.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Greifen Sie auf die Tabelle zu, die als erste Form auf der Folie gespeichert ist.
4. Aktivieren Sie die Kopfzeilenformatierung für deren erste Zeile.
5. Speichern Sie die geänderte Präsentation.

Das Beispiel benötigt `table.pptx` mit einer Tabelle als erste Form auf der ersten Folie. Es aktiviert die Kopfzeilenformatierung für die erste Zeile und speichert `First_row_header.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **Eine Tabellenzeile oder -spalte klonen**

Klonen Sie Zeilen oder Spalten, um deren Inhalt und Formatierung wiederzuverwenden. Sie können eine Kopie an das Ende der Tabelle anhängen oder an einer bestimmten Position einfügen.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Definieren Sie die Spaltenbreiten und Zeilenhöhen.
4. Fügen Sie eine Tabelle mit der Methode [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) hinzu.
5. Klonen Sie die erforderlichen Zeilen.
6. Klonen Sie die erforderlichen Spalten.
7. Speichern Sie die geänderte Präsentation.

Das Beispiel benötigt `Test.pptx` mit mindestens einer Folie. Es erstellt eine Tabelle mit drei Spalten und fünf Zeilen, deren Abmessungen in Punkten angegeben sind. Es fügt Kopien der ersten Zeile und Spalte hinzu und fügt dann Kopien der zweiten Zeile und Spalte an Index 3 (der vierten Position) ein. Die resultierende Tabelle hat sieben Zeilen und fünf Spalten. Das Argument `False` deaktiviert das Klonen in angrenzende zusammengeführte Zeilen oder Spalten; diese Tabelle hat keine zusammengeführten Zellen.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Eine Zeile oder Spalte aus einer Tabelle entfernen**

Entfernen Sie Zeilen oder Spalten, die in einer Tabelle nicht mehr benötigt werden. Das Entfernen eines Elements verschiebt die Indizes der nachfolgenden Zeilen oder Spalten.

1. Erstellen Sie eine Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Definieren Sie die Spaltenbreiten und Zeilenhöhen.
4. Fügen Sie eine Tabelle mit der Methode [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) hinzu.
5. Entfernen Sie die zweite Zeile und die zweite Spalte.
6. Speichern Sie die geänderte Präsentation.

Dieses Beispiel erstellt eine 3 × 3‑Tabelle und entfernt die Zeile und Spalte bei Index 1, sodass eine 2 × 2‑Tabelle in `TestTable_out.pptx` entsteht. Die Abmessungen sind in Punkten angegeben. Das Argument `False` deaktiviert das Entfernen angrenzender zusammengeführter Zeilen oder Spalten; diese Tabelle hat keine zusammengeführten Zellen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.shapes.add_table(100, 100, column_widths, row_heights)

    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Textformatierung auf Zeilenebene festlegen**

Wenden Sie Textformatierung auf eine gesamte Zeile an, um deren Zellen einheitlich zu halten. Sie können Schriftarteigenschaften, Absatzformatierung und Textausrichtung festlegen, ohne jede Zelle einzeln zu formatieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Greifen Sie auf die Tabelle auf der ersten Folie zu.
3. Setzen Sie [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) für die erste Zeile.
4. Setzen Sie [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) und [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) für die erste Zeile.
5. Setzen Sie [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) für die zweite Zeile.
6. Speichern Sie die geänderte Präsentation.

Das Beispiel benötigt `table.pptx` mit einer Tabelle als erste Form auf der ersten Folie und mindestens zwei Zeilen. Es wendet 25‑Punkt‑Text, rechtsbündige Ausrichtung und einen 20‑Punkt‑Rechts‑Absatzabstand auf die erste Zeile an und setzt dann vertikalen Text in der zweiten Zeile.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Textformatierung auf Spaltenebene festlegen**

Wenden Sie Textformatierung auf eine gesamte Spalte an, um deren Zellen einheitlich zu halten. Sie können Schriftarteigenschaften, Absatzformatierung und Textausrichtung festlegen, ohne jede Zelle einzeln zu formatieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Greifen Sie auf die Tabelle auf der ersten Folie zu.
3. Setzen Sie [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) für die erste Spalte.
4. Setzen Sie [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) und [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) für die erste Spalte.
5. Setzen Sie [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) für die zweite Spalte.
6. Speichern Sie die geänderte Präsentation.

Das Beispiel benötigt `table.pptx` mit einer Tabelle als erste Form auf der ersten Folie und mindestens zwei Spalten. Es wendet 25‑Punkt‑Text, rechtsbündige Ausrichtung und einen 20‑Punkt‑Rechts‑Absatzabstand auf die erste Spalte an und setzt dann vertikalen Text in der zweiten Spalte.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Tabellenstil‑Eigenschaften abrufen**

Verwenden Sie die Eigenschaft [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/), um das auf eine Tabelle angewendete Preset abzurufen und es in einer anderen Tabelle wiederzuverwenden. Dies identifiziert das Preset statt einzelner Zellformat‑Überschreibungen.

Das Beispiel erstellt eine Tabelle, wendet [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) an und liest das Preset wieder aus. Es gibt `True` aus, wenn das abgerufene Preset dem angewendeten entspricht, und speichert die Tabelle in `table.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich PowerPoint‑Themen/‑Stile auf eine bereits erstellte Tabelle anwenden?**

Ja. Die Tabelle erbt das Folien‑/Layout‑/Master‑Thema, und Sie können weiterhin Füllungen, Rahmen und Textfarben über diesem Thema überschreiben.

**Kann ich Tabellenzeilen wie in Excel sortieren?**

Nein, Aspose.Slides‑Tabellen besitzen keine integrierte Sortierung oder Filter. Sortieren Sie Ihre Daten zuerst im Speicher und füllen Sie dann die Tabellenzeilen in dieser Reihenfolge erneut.

**Kann ich gestreifte Spalten haben und gleichzeitig benutzerdefinierte Farben für bestimmte Zellen beibehalten?**

Ja. Aktivieren Sie gestreifte Spalten und überschreiben Sie anschließend bestimmte Zellen mit lokaler Formatierung; die Zellformatierung hat Vorrang vor dem Tabellenstil.