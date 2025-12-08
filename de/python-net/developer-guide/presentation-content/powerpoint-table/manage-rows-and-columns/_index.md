---
title: Verwalten von Zeilen und Spalten in PowerPoint-Tabellen mit Python
linktitle: Zeilen und Spalten
type: docs
weight: 20
url: /de/python-net/manage-rows-and-columns/
keywords:
- Tabellenzeile
- Tabellenspalte
- erste Zeile
- Tabellenkopf
- Zeile duplizieren
- Spalte duplizieren
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
description: "Verwalten Sie Tabellenzeilen und -spalten in PowerPoint und OpenDocument mit Aspose.Slides für Python über .NET und beschleunigen Sie die Bearbeitung von Präsentationen sowie Datenaktualisierungen."
---

## **Übersicht**

Dieser Artikel zeigt, wie Sie Zeilen und Spalten von Tabellen in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Python verwalten können. Sie lernen, wie Sie Zeilen oder Spalten hinzufügen, einfügen, duplizieren und löschen, die erste Zeile als Kopfzeile markieren, Größen und Layout anpassen und Text‑ sowie Formatierungsstil auf Zeilen‑ oder Spaltenebene anwenden. Jede Aufgabe wird mit kompakten, eigenständigen Code‑Snippets demonstriert, die auf der [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)‑API basieren, sodass Sie schnell eine Tabelle auf einer Folie finden und deren Struktur an Ihr Design anpassen können.

## **Erste Zeile als Header festlegen**

Markieren Sie die erste Zeile der Tabelle als Kopfzeile, um Spaltentitel eindeutig von den Daten zu unterscheiden. In Aspose.Slides für Python aktivieren Sie einfach die Option *First Row* der Tabelle, um die Header‑Formatierung anzuwenden, die im ausgewählten Tabellenvorlage‑Stil definiert ist.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation.  
1. Greifen Sie über den Index auf die Folie zu.  
1. Durchlaufen Sie alle [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)‑Objekte, um die relevante Tabelle zu finden.  
1. Setzen Sie die erste Zeile der Tabelle als Header.  

Der folgende Python‑Code zeigt, wie Sie die erste Zeile einer Tabelle als Header festlegen:  
```python
import aspose.slides as slides

# Instanziieren der Presentation-Klasse.
with slides.Presentation("table.pptx") as presentation:
    # Zugriff auf die erste Folie.
    slide = presentation.slides[0]

    # Durchlaufen Sie die Shapes und erhalten Sie eine Referenz zur Tabelle.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # Setzen Sie die erste Zeile der Tabelle als Kopfzeile.
    table.first_row = True
    
    # Speichern Sie die Präsentation auf der Festplatte.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Eine Tabellenzeile oder -spalte duplizieren**

Duplizieren Sie eine beliebige Tabellenzeile oder -spalte und fügen Sie die Kopie an der gewünschten Position in die Tabelle ein. Die Kopie übernimmt Zellinhalt, Formatierung und Größen, sodass Sie Layouts schnell und konsistent erweitern können.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation.  
1. Greifen Sie über den Index auf die Folie zu.  
1. Definieren Sie ein Array mit Spaltenbreiten.  
1. Definieren Sie ein Array mit Zeilenhöhen.  
1. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) mit `add_table(x, y, column_widths, row_heights)` hinzu.  
1. Duplizieren Sie eine Tabellenzeile.  
1. Duplizieren Sie eine Tabellenspalte.  
1. Speichern Sie die geänderte Präsentation.  

Der folgende Python‑Code zeigt, wie Sie eine Zeile und eine Spalte einer PowerPoint‑Tabelle duplizieren:  
```python
 import aspose.slides as slides

# Instanziieren der Presentation-Klasse.
with slides.Presentation() as presentation:
    # Zugriff auf die erste Folie.
    slide = presentation.slides[0]

    # Definieren Sie Spaltenbreiten und Zeilenhöhen.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Fügen Sie der Folie eine Tabelle hinzu.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Text zu Zeile 1, Spalte 1 hinzufügen.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Text zu Zeile 2, Spalte 1 hinzufügen.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Zeile 1 am Ende der Tabelle klonen.
    table.rows.add_clone(table.rows[0], False)

    # Text zu Zeile 1, Spalte 2 hinzufügen.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Text zu Zeile 2, Spalte 2 hinzufügen.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Zeile 2 als vierte Zeile der Tabelle klonen.
    table.rows.insert_clone(3,table.rows[1], False)

    # Erste Spalte am Ende klonen.
    table.columns.add_clone(table.columns[0], False)

    # Zweite Spalte an Index 3 (vierte Position) klonen.
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Präsentation auf dem Datenträger speichern.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Eine Zeile oder Spalte aus einer Tabelle entfernen**

Optimieren Sie eine Tabelle, indem Sie eine Zeile oder Spalte anhand ihres Index entfernen – Aspose.Slides für Python passt das Layout automatisch an und behält die Formatierung der verbleibenden Zellen bei. Das ist praktisch, um Datenrastern zu vereinfachen oder Platzhalter zu löschen, ohne die Tabelle neu aufzubauen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation.  
1. Greifen Sie über den Index auf die Folie zu.  
1. Definieren Sie ein Array mit Spaltenbreiten.  
1. Definieren Sie ein Array mit Zeilenhöhen.  
1. Fügen Sie der Folie ein ITable mit `add_table(x, y, column_widths, row_heights)` hinzu.  
1. Entfernen Sie die Tabellenzeile.  
1. Entfernen Sie die Tabellenspalte.  
1. Speichern Sie die geänderte Präsentation.  

Der nachfolgende Python‑Code zeigt, wie Sie eine Zeile und eine Spalte aus einer Tabelle entfernen:  
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

Wenden Sie konsistente Textstile auf eine gesamte Tabellenzeile in einem Schritt an. Mit Aspose.Slides für Python können Sie Schriftfamilie, Größe, Gewicht, Farbe und Ausrichtung für alle Zellen der Zeile gleichzeitig festlegen, um Überschriften oder Datenbänder einheitlich zu halten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation.  
1. Greifen Sie über den Index auf die Folie zu.  
1. Greifen Sie auf das relevante [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)‑Objekt auf der Folie zu.  
1. Setzen Sie die Schriftgröße für die Zellen der ersten Zeile.  
1. Legen Sie die Ausrichtung und den rechten Rand für die Zellen der ersten Zeile fest.  
1. Definieren Sie den vertikalen Texttyp für die Zellen der zweiten Zeile.  
1. Speichern Sie die geänderte Präsentation.  

Der folgende Python‑Code demonstriert die Vorgehensweise.  
```python
import aspose.slides as slides

# Instanz der Presentation-Klasse erstellen.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Schriftgröße für die Zellen der ersten Zeile festlegen.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # Textausrichtung und rechten Rand der Zellen der ersten Zeile festlegen.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # Vertikalen Texttyp der Zellen der zweiten Zeile festlegen.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # Präsentation auf der Festplatte speichern.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```


## **Textformatierung auf Spaltenebene festlegen**

Wenden Sie konsistente Textstile auf eine gesamte Tabellenspalte gleichzeitig an. Mit Aspose.Slides für Python können Sie Schriftfamilie, Größe, Gewicht, Farbe und Ausrichtung für alle Zellen einer Spalte festlegen, um einheitliche vertikale Bänder für Überschriften oder Daten zu erzeugen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation.  
1. Greifen Sie über den Index auf die Folie zu.  
1. Greifen Sie auf das relevante [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)‑Objekt auf der Folie zu.  
1. Setzen Sie die Schriftgröße für die Zellen der ersten Spalte.  
1. Legen Sie die Ausrichtung und den rechten Rand für die Zellen der ersten Spalte fest.  
1. Definieren Sie den vertikalen Texttyp für die Zellen der zweiten Spalte.  
1. Speichern Sie die geänderte Präsentation.  

Der nachfolgende Python‑Code demonstriert die Vorgehensweise:  
```python
import aspose.slides as slides

# Instanz der Presentation-Klasse erstellen.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Schrifthöhe für die Zellen der ersten Spalte festlegen.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # Textausrichtung und rechten Rand für die Zellen der ersten Spalte festlegen.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # Vertikalen Texttyp für die Zellen der zweiten Spalte festlegen.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # Präsentation auf der Festplatte speichern.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```


## **Tabellenstil‑Eigenschaften abrufen**

Aspose.Slides ermöglicht das Abrufen von Stil‑Eigenschaften einer Tabelle, sodass Sie diese für eine andere Tabelle oder an anderer Stelle wiederverwenden können. Der folgende Python‑Code zeigt, wie Sie die Stil‑Eigenschaften aus einem vordefinierten Tabellenvorlagen‑Stil erhalten:  
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Kann ich PowerPoint‑Designs/‑Stile auf eine bereits erstellte Tabelle anwenden?**  
Ja. Die Tabelle erbt das Design der Folie/Layout/Master und Sie können trotzdem Füllungen, Rahmen und Textfarben über diesem Design überschreiben.

**Kann ich Tabell Zeilen wie in Excel sortieren?**  
Nein, Aspose.Slides‑Tabellen besitzen keine integrierte Sortier‑ oder Filterfunktion. Sortieren Sie Ihre Daten zunächst im Speicher und fügen Sie die Tabellenzeilen anschließend in dieser Reihenfolge wieder ein.

**Kann ich gestreifte (banded) Spalten haben und gleichzeitig benutzerdefinierte Farben für einzelne Zellen beibehalten?**  
Ja. Aktivieren Sie gestreifte Spalten und überschreiben Sie dann einzelne Zellen mit lokaler Formatierung; die Formatierung auf Zellenebene hat Vorrang vor dem Tabellenstil.