---
title: Verwalten von Zeilen und Spalten in PowerPoint-Tabellen mit Python
linktitle: Zeilen und Spalten
type: docs
weight: 20
url: /de/python-java/manage-rows-and-columns/
keywords:
- Tabellenzeile
- Tabellenspalte
- Erste Zeile
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
description: Verwalten Sie Tabellenzeilen und -spalten in PowerPoint mit Aspose.Slides für Python via Java und beschleunigen Sie die Bearbeitung von Präsentationen und Datenaktualisierungen.
---
## **Einleitung**

Aspose.Slides for Python via Java ermöglicht das Verwalten von Tabellenstruktur und -formatierung in PowerPoint‑Präsentationen über die [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) Klasse. Sie können eine Kopfzeilenzeile festlegen, Zeilen und Spalten kopieren oder entfernen und Textformatierung auf eine gesamte Zeile oder Spalte anwenden.

Dieser Artikel erklärt diese Vorgänge anhand von Python‑Beispielen. Er zeigt außerdem, wie man ein Tabellen‑Stil‑Preset abruft, um es wiederzuverwenden. Zeilen‑ und Spaltenindizes in Tabellen beginnen bei Null.

## **Steuerung der Zeilenhöhe**

Verwenden Sie [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight), um die minimale Höhe einer Zeile in Punkten festzulegen. Es handelt sich um eine Untergrenze, nicht um eine feste Höhe. [Row.getHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#getHeight) gibt die tatsächliche Höhe zurück. Greifen Sie über [Table.getRows](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getRows) auf die Zeile zu.

Das Beispiel lädt [row-height-input.pptx](row-height-input.pptx), das auf der ersten Folie eine Tabelle als erstes Shape enthält. Die erste Zeile beginnt bei 70 Punkten. Die Zellen verwenden 18‑Punkt‑Arial‑Text, Zeilenumbruch und 6‑Punkt‑Abstände oben und unten; der längere Text in der zweiten Spalte bricht in mehrere Zeilen um. Das Beispiel erhöht das Minimum auf 100 Punkte, reduziert es dann auf 20 Punkte, gibt nach jeder Änderung die tatsächliche Höhe aus und speichert beide Ergebnisse.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("row-height-input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    row = table.getRows().get_Item(0)

    row.setMinimalHeight(100)
    print(f"Increased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx)

    row.setMinimalHeight(20)
    print(f"Decreased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mit der bereitgestellten Präsentation fügt das Erhöhen des Minimums der Zeile zusätzlichen Raum hinzu. Das Verringern entfernt diesen zusätzlichen Raum, aber die tatsächliche Höhe bleibt größer als 20 Punkte, weil Text und Zellabstände mehr Platz benötigen. Das alleinige Verringern des Minimums kann die Zeile nicht unter den vom Inhalt benötigten Raum drücken.

Mehrere Faktoren beeinflussen die tatsächliche Höhe:

- **Text und Schriftgröße:** Längerer Text, explizite Zeilenumbrüche oder eine größere Schrift können mehr vertikalen Raum benötigen.
- **Umbruch und Spaltenbreite:** Bei aktiviertem Umbruch kann das Reduzieren der Spaltenbreite mit [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) zu mehr Zeilen führen. Eine breitere Spalte kann den vertikalen Platzbedarf senken.
- **Zellabstände:** [Cell.setMarginTop](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginTop) und [Cell.setMarginBottom](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginBottom) fügen vertikalen Raum hinzu. [Cell.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginLeft) und [Cell.setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginRight) verringern die für Text verfügbare Breite und können zusätzlichen Umbruch erzeugen.

Für diese Tabelle ohne zusammengeführte Zellen bestimmt die Zelle, die am meisten vertikalen Raum benötigt, die inhaltlich bedingte Untergrenze für die gesamte Zeile. Um die Zeile zu verkürzen, muss ggf. der Text gekürzt, die Schriftgröße oder die Abstände reduziert oder eine Spalte verbreitert werden.

Die Bilder unten zeigen dieselbe Tabelle im selben Maßstab. In den dargestellten Ergebnissen betrugen die tatsächlichen Höhen 70, 100 und 55,2 Punkte: Die letzte Zeile blieb höher als ihr Minimum von 20 Punkten. Exakte Textmessungen können je nach in Ihrer Umgebung verfügbaren Schriften variieren. Laden Sie die gespeicherten Ergebnisse herunter: [increased minimum](row-height-increased.pptx) und [decreased minimum](row-height-decreased.pptx).

| Original: Minimum 70 pt, tatsächlich 70 pt | Erhöht: Minimum 100 pt, tatsächlich 100 pt | Verringert: Minimum 20 pt, tatsächlich 55.2 pt |
| --- | --- | --- |
| ![Originaltabelle mit einer ersten Zeile von 70 Punkten.](row-height-before.png) | ![Tabelle nach Erhöhen des Mindestwerts der ersten Zeile auf 100 Punkte.](row-height-increased.png) | ![Tabelle nach Verringern des Mindestwerts der ersten Zeile auf 20 Punkte; umbrochener Text hält die Zeile höher als das Minimum.](row-height-decreased.png) |

## **Erste Zeile als Kopfzeile festlegen**

Verwenden Sie die Methode [setFirstRow](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setFirstRow), um die erste Zeile als Kopfzeile zu kennzeichnen. Ihr Erscheinungsbild hängt vom auf die Tabelle angewendeten Tabellenstil ab.

1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Greifen Sie auf die Tabelle zu, die als erstes Shape auf der Folie gespeichert ist.
4. Aktivieren Sie die Kopfzeilenformatierung für die erste Zeile.
5. Speichern Sie die geänderte Präsentation.

Das Beispiel benötigt `table.pptx` mit einer Tabelle als erstes Shape auf der ersten Folie. Es aktiviert die Kopfzeilenformatierung für die erste Zeile und speichert `First_row_header.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    table.setFirstRow(True)

    presentation.save("First_row_header.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kopieren einer Tabellenzeile oder -spalte**

Kopieren Sie Zeilen oder Spalten, um deren Inhalt und Formatierung wiederzuverwenden. Sie können eine Kopie am Ende der Tabelle anhängen oder an einer bestimmten Position einfügen.

1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Definieren Sie die Spaltenbreiten und Zeilenhöhen.
4. Fügen Sie eine Tabelle mit der [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) Methode hinzu.
5. Kopieren Sie die gewünschten Zeilen.
6. Kopieren Sie die gewünschten Spalten.
7. Speichern Sie die geänderte Präsentation.

Das Beispiel benötigt `Test.pptx` mit mindestens einer Folie. Es erstellt eine Tabelle mit drei Spalten und fünf Zeilen, wobei die Abmessungen in Punkten angegeben sind. Es hängt Kopien der ersten Zeile und ersten Spalte an und fügt Kopien der zweiten Zeile und zweiten Spalte an Index 3 (der vierten Position) ein. Die resultierende Tabelle hat sieben Zeilen und fünf Spalten. Das Argument `False` deaktiviert das Kopieren in benachbarte zusammengeführte Zeilen oder Spalten; diese Tabelle enthält keine zusammengeführten Zellen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([50, 50, 50])
    row_heights = jpype.JArray(jpype.JDouble)([50, 30, 30, 30, 30])
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)

    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)

    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Entfernen einer Zeile oder Spalte aus einer Tabelle**

Entfernen Sie Zeilen oder Spalten, die in einer Tabelle nicht mehr benötigt werden. Das Entfernen eines Elements verschiebt die Indizes der nachfolgenden Zeilen bzw. Spalten.

1. Erstellen Sie eine Präsentation mit der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Definieren Sie die Spaltenbreiten und Zeilenhöhen.
4. Fügen Sie eine Tabelle mit der [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) Methode hinzu.
5. Entfernen Sie die zweite Zeile und die zweite Spalte.
6. Speichern Sie die geänderte Präsentation.

Dieses Beispiel erstellt eine 3 × 3‑Tabelle und entfernt die Zeile und Spalte an Index 1, sodass eine 2 × 2‑Tabelle in `TestTable_out.pptx` verbleibt. Die Abmessungen sind in Punkten angegeben. Das Argument `False` deaktiviert das Entfernen benachbarter zusammengeführter Zeilen oder Spalten; diese Tabelle enthält keine zusammengeführten Zellen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 50, 30])
    row_heights = jpype.JArray(jpype.JDouble)([30, 50, 30])
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)

    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Textformatierung auf Zeilenebene festlegen**

Wenden Sie Textformatierung auf eine gesamte Zeile an, um die Zellen konsistent zu halten. Sie können Schriftarteigenschaften, Absatzformatierung und Textausrichtung festlegen, ohne jede Zelle einzeln zu formatieren.

1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die Tabelle auf der ersten Folie zu.
3. Verwenden Sie [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) für die erste Zeile.
4. Verwenden Sie [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) und [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) für die erste Zeile.
5. Verwenden Sie [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) für die zweite Zeile.
6. Speichern Sie die geänderte Präsentation.

Das Beispiel benötigt `table.pptx` mit einer Tabelle als erstes Shape auf der ersten Folie und mindestens zwei Zeilen. Es wendet 25‑Punkt‑Text, rechtsbündige Ausrichtung und einen rechten Absatzabstand von 20 Punkten auf die erste Zeile an und setzt dann vertikalen Text in der zweiten Zeile.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getRows().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getRows().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getRows().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("row_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Textformatierung auf Spaltenebene festlegen**

Wenden Sie Textformatierung auf eine gesamte Spalte an, um die Zellen konsistent zu halten. Sie können Schriftarteigenschaften, Absatzformatierung und Textausrichtung festlegen, ohne jede Zelle einzeln zu formatieren.

1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die Tabelle auf der ersten Folie zu.
3. Verwenden Sie [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) für die erste Spalte.
4. Verwenden Sie [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) und [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) für die erste Spalte.
5. Verwenden Sie [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) für die zweite Spalte.
6. Speichern Sie die geänderte Präsentation.

Das Beispiel benötigt `table.pptx` mit einer Tabelle als erstes Shape auf der ersten Folie und mindestens zwei Spalten. Es wendet 25‑Punkt‑Text, rechtsbündige Ausrichtung und einen rechten Absatzabstand von 20 Punkten auf die erste Spalte an und setzt dann vertikalen Text in der zweiten Spalte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getColumns().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getColumns().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getColumns().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("column_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tabellenstil‑Eigenschaften abrufen**

Verwenden Sie die Methode [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset), um das auf eine Tabelle angewandte Preset abzurufen und auf einer anderen Tabelle wiederzuverwenden. Damit wird das Preset identifiziert, nicht die einzelnen zellenspezifischen Formatierungsüberschreibungen.

Das Beispiel erstellt eine Tabelle, wendet [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/#DarkStyle1) an und liest das Preset wieder aus. Es gibt den ganzzahligen Wert für `DarkStyle1` aus und speichert die Tabelle in `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 150])
    row_heights = jpype.JArray(jpype.JDouble)([5, 5, 5])
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print(style_preset)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I apply PowerPoint themes/styles to a table that's already created?**  
Ja. Die Tabelle übernimmt das Folien‑/Layout‑/Master‑Design, und Sie können dennoch Füllungen, Rahmen und Textfarben über diesem Design überschreiben.

**Can I sort table rows like in Excel?**  
Nein, Aspose.Slides‑Tabellen besitzen keine integrierte Sortier‑ oder Filterfunktion. Sortieren Sie Ihre Daten zunächst im Arbeitsspeicher und befüllen Sie anschließend die Tabellenzeilen in dieser Reihenfolge neu.

**Can I have banded (striped) columns while keeping custom colors on specific cells?**  
Ja. Aktivieren Sie gestreifte Spalten und überschreiben Sie dann bestimmte Zellen mit lokaler Formatierung; die Formatierung auf Zellebene hat Vorrang vor dem Tabellenstil.