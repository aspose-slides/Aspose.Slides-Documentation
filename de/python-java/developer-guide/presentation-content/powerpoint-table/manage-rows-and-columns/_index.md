---
title: Verwalten von Zeilen und Spalten in PowerPoint-Tabellen mit Python
linktitle: Zeilen und Spalten
type: docs
weight: 20
url: /de/python-java/manage-rows-and-columns/
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
- Textformatierung der Zeile
- Textformatierung der Spalte
- Tabellenstil
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie Tabellenzeilen und -spalten in PowerPoint mit Aspose.Slides für Python via Java und beschleunigen Sie die Präsentationsbearbeitung sowie Datenaktualisierungen."
---
## **Einleitung**

Um Ihnen das Verwalten von Zeilen und Spalten einer Tabelle in einer PowerPoint‑Präsentation zu ermöglichen, stellt Aspose.Slides die Klasse [Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/) und viele weitere Typen bereit.

## **Erste Zeile als Kopfzeile festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und laden Sie die Präsentation.  
2. Holen Sie eine Referenz zu einer Folie über deren Index.  
3. Erstellen Sie eine Referenz zu einer [Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/) und setzen Sie sie auf `None`.  
4. Iterieren Sie über alle [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/)-Objekte, um die entsprechende Tabelle zu finden.  
5. Setzen Sie die erste Zeile der Tabelle als Kopfzeile.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klonen einer Tabellenzeile oder -spalte**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und laden Sie die Präsentation.  
2. Holen Sie eine Referenz zu einer Folie über deren Index.  
3. Definieren Sie eine Liste von Spaltenbreiten.  
4. Definieren Sie eine Liste von Zeilenhöhen.  
5. Fügen Sie ein [Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/)-Objekt zur Folie über die Methode [addTable](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addTable) hinzu.  
6. Klonen Sie die Tabellenzeile.  
7. Klonen Sie die Tabellenspalte.  
8. Speichern Sie die geänderte Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
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

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).  
2. Holen Sie eine Referenz zu einer Folie über deren Index.  
3. Definieren Sie eine Liste von Spaltenbreiten.  
4. Definieren Sie eine Liste von Zeilenhöhen.  
5. Fügen Sie ein [Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/)-Objekt zur Folie über die Methode [addTable](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addTable) hinzu.  
6. Entfernen Sie die Tabellenzeile.  
7. Entfernen Sie die Tabellenspalte.  
8. Speichern Sie die geänderte Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Textformatierung auf Zeilenebene der Tabelle festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und laden Sie die Präsentation.  
2. Holen Sie eine Referenz zu einer Folie über deren Index.  
3. Greifen Sie auf das entsprechende [Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/)-Objekt der Folie zu.  
4. Setzen Sie die Schriftgröße der Zellen der ersten Zeile mit [setFontHeight](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Setzen Sie die Textausrichtung und den rechten Rand der Zellen der ersten Zeile mit [setAlignment](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#setAlignment) und [setMarginRight](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Setzen Sie den vertikalen Texttyp der Zellen der zweiten Zeile mit [setTextVerticalType](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Speichern Sie die geänderte Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
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
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Textformatierung auf Spaltenebene der Tabelle festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und laden Sie die Präsentation.  
2. Holen Sie eine Referenz zu einer Folie über deren Index.  
3. Greifen Sie auf das entsprechende [Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/)-Objekt der Folie zu.  
4. Setzen Sie die Schriftgröße der Zellen der ersten Spalte mit [setFontHeight](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Setzen Sie die Textausrichtung und den rechten Rand der Zellen der ersten Spalte mit [setAlignment](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#setAlignment) und [setMarginRight](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Setzen Sie den vertikalen Texttyp der Zellen der zweiten Spalte mit [setTextVerticalType](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Speichern Sie die geänderte Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
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
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Abrufen von Tabellendesigneigenschaften**

Aspose.Slides ermöglicht das Abrufen der Stileigenschaften einer Tabelle, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser Python‑Code zeigt, wie Sie die Stileigenschaften aus einem vordefinierten Tabellendesign erhalten:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich bereits erstellten Tabellen PowerPoint‑Designs/‑Stile zuweisen?**

Ja. Die Tabelle erbt das Folien‑/Layout‑/Master‑Design, und Sie können weiterhin Füllungen, Rahmen und Textfarben über diesem Design überschreiben.

**Kann ich Tabellenzeilen wie in Excel sortieren?**

Nein, Tabellen von Aspose.Slides verfügen nicht über integrierte Sortier‑ oder Filterfunktionen. Sortieren Sie Ihre Daten zuerst im Speicher und füllen Sie anschließend die Tabellenzeilen in dieser Reihenfolge neu.

**Kann ich gestreifte (banded) Spalten haben und gleichzeitig benutzerdefinierte Farben für bestimmte Zellen beibehalten?**

Ja. Aktivieren Sie gestreifte Spalten und überschreiben Sie dann einzelne Zellen mit lokaler Formatierung; die Zellen‑formatierung hat Vorrang vor dem Tabellenstil.