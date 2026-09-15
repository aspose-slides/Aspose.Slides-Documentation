---
title: Excel-Daten in PowerPoint-Präsentationen integrieren
linktitle: Excel-Integration
type: docs
weight: 330
url: /de/python-java/excel-integration/
keywords:
- Excel
- Arbeitsmappe
- Excel lesen
- Excel integrieren
- Datenquelle
- Seriendruck
- Tabelle importieren
- Excel in PowerPoint
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Lese Daten aus Excel-Arbeitsmappen in Aspose.Slides für Python über Java mithilfe der ExcelDataWorkbook‑API. Lade Tabellenblätter und Zellen und verwende die Werte, um datengetriebene PowerPoint‑Präsentationen zu erstellen."
---
## **Einleitung**

PowerPoint-Präsentationen sind eine leistungsstarke Möglichkeit, Informationen darzustellen und zu kommunizieren. Sie werden häufig in Verbindung mit Excel-Arbeitsmappen verwendet, wobei Excel eine ausgezeichnete Quelle für strukturierte Daten ist und PowerPoint diese Daten für ein Publikum visualisiert.

Es gibt viele praktische Szenarien, in denen die Kombination von Excel und PowerPoint unerlässlich ist: Seriendrucke, das Befüllen von Datentabellen, das Erzeugen einer Folie pro Datensatz (Stapel‑Foliengenerierung), das Erstellen von Schulungsmaterialien und das Konsolidieren mehrerer Excel-Berichte in einer einzigen Präsentation, um nur einige zu nennen.

Bisher erforderte die Implementierung solcher Funktionen mit der Aspose.Slides-API die Verwendung von Drittanbieterlösungen wie Aspose.Cells. Obwohl diese Werkzeuge robust sind, können sie für Benutzer, die nur grundlegende Datenintegrationsfunktionen benötigen, übermäßig komplex und kostspielig sein.

## **Wie es funktioniert**

Um die Arbeit mit Excel-Daten zu vereinfachen und zu rationalisieren, hat Aspose.Slides neue Klassen zum Lesen von Daten aus Excel-Arbeitsmappen und zum Importieren von Inhalten in eine Präsentation eingeführt. Diese Funktion eröffnet API‑Benutzern neue leistungsstarke Möglichkeiten, Excel als Datenquelle innerhalb ihrer Präsentations‑Workflows zu nutzen.

Die neue Funktionalität ist für allgemeine Datenzugriffe konzipiert und ist nicht in das Presentation Document Object Model (DOM) integriert. Das bedeutet, *dass sie kein Bearbeiten oder Speichern von Excel‑Dateien erlaubt* – ihr einziger Zweck besteht darin, Arbeitsmappen zu öffnen und deren Inhalt zu durchlaufen, um Zellwerte abzurufen.

Im Kern dieser Funktion steht die neue [ExcelDataWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/exceldataworkbook/)‑Klasse. Diese Klasse ermöglicht das Laden einer Excel‑Arbeitsmappe aus einer lokalen Datei oder einem Stream. Sobald geladen, bietet sie mehrere Überladungen der [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/de/python-java/aspose.slides/exceldataworkbook/#getCell)‑Methode, mit denen Sie bestimmte Zellen anhand ihrer Position (z. B. Zeilen‑ und Spaltenindizes oder benannte Bereiche) abrufen können.

Jeder Aufruf von [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/de/python-java/aspose.slides/exceldataworkbook/#getCell) gibt ein [ExcelDataCell](https://reference.aspose.com/slides/de/python-java/aspose.slides/exceldatacell/)‑Objekt zurück. Dieses Objekt repräsentiert eine einzelne Zelle in der Excel‑Arbeitsmappe und verschafft Ihnen einen einfachen und intuitiven Zugriff auf deren Wert.

#### **Ein Excel‑Diagramm importieren**

Der nächste Schritt zur Erweiterung der Funktionalität ist die Klasse [ExcelWorkbookImporter](https://reference.aspose.com/slides/de/python-java/aspose.slides/excelworkbookimporter/). Diese Hilfsklasse bietet Funktionen zum Importieren von Inhalten aus einer Excel‑Arbeitsmappe in eine Präsentation. Sie enthält mehrere Überladungen der Methode [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), die Ihnen dabei hilft, das ausgewählte Diagramm aus der angegebenen Excel‑Arbeitsmappe abzurufen und am Ende der angegebenen Shape‑Collection an den angegebenen Koordinaten hinzuzufügen.

#### **Eine Excel‑Tabelle importieren**

Die Klasse [ExcelWorkbookImporter](https://reference.aspose.com/slides/de/python-java/aspose.slides/excelworkbookimporter/) enthält zudem mehrere Überladungen der Methode [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook). Diese Methoden ermöglichen das Importieren eines angegebenen Zellbereichs aus einem bestimmten Arbeitsblatt und das Hinzufügen als Tabelle zum Ende der angegebenen Shape‑Collection an den angegebenen Koordinaten.

Kurz gesagt, es ist eine leichte und unkomplizierte API zum Lesen von Excel‑Daten – genau das, was viele Entwickler benötigen, ohne den Overhead einer kompletten Tabellenkalkulationsbibliothek.

## **Lass uns coden**

### **Beispiel für Seriendruck‑Szenario**

In dem folgenden Beispiel implementieren wir ein einfaches Seriendruck‑Szenario, indem wir mehrere Präsentationen basierend auf Daten erzeugen, die in einer Excel‑Arbeitsmappe gespeichert sind.

Um loszulegen, benötigen wir zwei Dinge:

1. Eine Excel‑Arbeitsmappe, die die Daten enthält

![Beispiel für Excel‑Daten](example1_image0.png)

2. Eine PowerPoint‑Präsentationsvorlage

![Beispiel für PowerPoint‑Vorlage](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Lade die Excel-Arbeitsmappe mit Mitarbeiterdaten.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Lade die Präsentationsvorlage.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # Durchlaufe die Excel-Zeilen (ausgenommen die Kopfzeile in Zeile 0).
    for row_index in range(1, 5):

        # Erstelle eine Präsentation für jeden Mitarbeitereintrag.
        employee_presentation = Presentation()

        try:
            # Entferne die standardmäßige leere Folie.
            employee_presentation.getSlides().removeAt(0)

            # Kopiere die Vorlagenfolie in die Präsentation.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # Hole Absätze aus der Ziel-Form (es wird angenommen, dass Shape-Index 1 verwendet wird).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # Ersetze die Platzhalter durch Daten aus Excel.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # Speichere die personalisierte Präsentation in einer separaten Datei.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Ergebnis](example1_image2.png)

### **Beispiel für Excel‑Tabelle**

Im zweiten Beispiel kopieren wir einfach Daten aus einer Excel‑Tabelle und zeigen sie auf einer PowerPoint‑Folie in einem ansprechenderen Format an.

In diesem Beispiel verwenden wir dieselbe Excel‑Arbeitsmappe wie im ersten Beispiel, die eine einfache Mitarbeitertabelle enthält.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Lade die Excel-Arbeitsmappe mit den Mitarbeiterdaten.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Erstelle eine PowerPoint-Präsentation.
presentation = Presentation()

try:
    # Füge der ersten Folie ein Tabellenelement hinzu.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # Befülle die PowerPoint-Tabelle mit Daten aus der Excel-Arbeitsmappe.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # Speichere die resultierende Präsentation in einer Datei.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Ergebnis](example2_image0.png)

### **Beispiel für das Importieren eines Excel‑Diagramms**

In diesem Beispiel importieren wir ein Diagramm aus dem ersten Arbeitsblatt der Excel‑Arbeitsmappe, die im vorherigen Beispiel verwendet wurde. Das Diagramm wird in der resultierenden Präsentation mit der externen Arbeitsmappe verknüpft.

Zuerst fügen wir der Excel‑Arbeitsmappe basierend auf der Mitarbeitertabelle ein Kreisdiagramm hinzu.

![Beispiel für Excel‑Diagramm](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Erstelle eine PowerPoint-Präsentation.
presentation = Presentation()
try:
    # Hole die Shapes-Sammlung der ersten Folie.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # Importiere das Diagramm mit dem Namen "Chart 1" aus dem ersten Blatt der Arbeitsmappe und füge es zur Shapes-Sammlung hinzu.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Speichere die resultierende Präsentation in einer Datei.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Ergebnis](example3_image1.png)

### **Beispiel für das Importieren aller Excel‑Diagramme**

Stellen Sie sich vor, Sie haben eine Excel‑Arbeitsmappe voller Diagramme und müssen alle in eine Präsentation importieren. Jedes Diagramm soll auf einer neuen Folie platziert werden.

Der folgende Code iteriert über alle Arbeitsblätter in der Quell‑Excel‑Datei, extrahiert die Diagramme aus jedem Arbeitsblatt und fügt jedes Diagramm mithilfe eines leeren Folienlayouts zu einer separaten Folie hinzu. In der resultierenden Präsentation werden nur die Diagrammdaten eingebettet, nicht die gesamte Arbeitsmappe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# Lade die Excel-Arbeitsmappe mit den Mitarbeiterdaten.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Erstelle eine PowerPoint-Präsentation.
presentation = Presentation()
try:
    # Rufe das leere Folienlayout ab.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # Entferne die Standardfolie, damit das Ergebnis eine Folie pro Diagramm enthält.
    presentation.getSlides().removeAt(0)

    # Hole die Namen aller Arbeitsblätter in der Excel-Arbeitsmappe.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # Rufe eine Zuordnung ab, die Diagrammindizes den Diagrammnamen im Arbeitsblatt zuordnet.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # Füge eine Folie mit dem leeren Layout hinzu.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # Importiere das angegebene Diagramm aus der Excel-Arbeitsmappe in die Shapes-Sammlung der Folie.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # Speichere die resultierende Präsentation in einer Datei.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Beispiel für das Importieren einer Excel‑Tabelle**

In diesem Beispiel importieren wir eine formatierte Tabelle aus einem Excel‑Arbeitsblatt direkt in eine PowerPoint‑Präsentation.

Das Quell‑Excel‑Arbeitsblatt enthält eine formatierte Tabelle mit Mitarbeiterdaten:

![Beispiel für Excel‑Tabelle](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Erstelle eine PowerPoint-Präsentation.
presentation = Presentation()
try:
    # Hole die erste Folie und deren Shapes-Sammlung.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # Importiere die Tabelle aus dem ersten Blatt der Arbeitsmappe und füge sie der Shapes-Sammlung hinzu.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # Speichere die resultierende Präsentation in einer Datei.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Ergebnis](example4_image1.png)

## **Zusammenfassung**

Dieser Mechanismus, der direkt in Aspose.Slides verfügbar ist, verbindet die Arbeit mit Excel‑Daten und Präsentationen an einem Ort. Er ermöglicht das Erstellen von Folien mit visuellen Diagrammen und als Excel‑Tabellen dargestellten Daten – ganz ohne zusätzliche Bibliotheken oder komplexe Integrationen.