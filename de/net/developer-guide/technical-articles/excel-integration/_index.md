---
title: Excel-Daten in PowerPoint-Präsentationen integrieren
linktitle: Excel-Integration
type: docs
weight: 330
url: /de/net/excel-integration/
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
- .NET
- C#
- Aspose.Slides
description: "Daten aus Excel-Arbeitsmappen in Aspose.Slides mit der ExcelDataWorkbook-API lesen. Arbeitsblätter und Zellen laden und Werte verwenden, um datengetriebene PowerPoint-Präsentationen zu erzeugen."
---
## **Einleitung**

PowerPoint‑Präsentationen sind ein leistungsstarkes Mittel, um Informationen darzustellen und zu kommunizieren. Sie werden häufig in Verbindung mit Excel‑Arbeitsmappen verwendet, wobei Excel eine hervorragende Quelle für strukturierte Daten darstellt und PowerPoint sich darauf spezialisiert, diese Daten für ein Publikum zu visualisieren.

Es gibt viele praktische Szenarien, in denen die Kombination von Excel und PowerPoint unerlässlich ist: Seriendrucke, Befüllen von Datentabellen, Erstellung einer Folie pro Datensatz (Batch‑Foliengenerierung), Erstellung von Schulungsmaterialien und Konsolidierung mehrerer Excel‑Berichte zu einer einzigen Präsentation, um nur einige zu nennen.

Bisher erforderte die Implementierung solcher Funktionen mit der Aspose.Slides‑API die Nutzung von Drittanbieterlösungen wie Aspose.Cells. Obwohl diese Werkzeuge robust sind, können sie für Benutzer, die nur grundlegende Datenintegrationsfunktionen benötigen, übermäßig komplex und kostspielig sein.

## **So funktioniert es**

Um die Arbeit mit Excel‑Daten zu erleichtern und zu vereinfachen, hat Aspose.Slides neue Klassen eingeführt, um Daten aus Excel‑Arbeitsmappen zu lesen und Inhalte in eine Präsentation zu importieren. Diese Funktion eröffnet API‑Benutzern leistungsstarke neue Möglichkeiten, Excel als Datenquelle in ihren Präsentations‑Workflows zu nutzen.

Die neue Funktionalität ist für den allgemeinen Datenzugriff konzipiert und nicht in das Presentation Document Object Model (DOM) integriert. Das bedeutet, *dass sie das Bearbeiten oder Speichern von Excel‑Dateien nicht erlaubt* – ihr einziger Zweck besteht darin, Arbeitsmappen zu öffnen und deren Inhalt zu durchlaufen, um Zellenwerte abzurufen.

Im Kern dieser Funktion steht die neue Klasse [ExcelDataWorkbook](https://reference.aspose.com/slides/de/net/aspose.slides.excel/exceldataworkbook/). Diese Klasse ermöglicht das Laden einer Excel‑Arbeitsmappe aus einer lokalen Datei oder einem Stream. Nach dem Laden stellt sie mehrere Überladungen der Methode [GetCell](https://reference.aspose.com/slides/de/net/aspose.slides.excel/exceldataworkbook/getcell/) bereit, mit denen Sie bestimmte Zellen anhand ihrer Position (z. B. Zeilen‑ und Spaltenindizes oder benannte Bereiche) abrufen können.

Jeder Aufruf von [GetCell](https://reference.aspose.com/slides/de/net/aspose.slides.excel/exceldataworkbook/getcell/) gibt eine Instanz der Klasse [ExcelDataCell](https://reference.aspose.com/slides/de/net/aspose.slides.excel/exceldatacell/) zurück. Dieses Objekt repräsentiert eine einzelne Zelle in der Excel‑Arbeitsmappe und bietet Ihnen einen einfachen und intuitiven Zugriff auf deren Wert.

#### **Excel‑Diagramm importieren**

Der nächste Schritt zur Erweiterung der Funktionalität ist die Klasse [ExcelWorkbookImporter](https://reference.aspose.com/slides/de/net/aspose.slides.import/excelworkbookimporter/). Diese Hilfsklasse bietet Funktionen zum Importieren von Inhalten aus einer Excel‑Arbeitsmappe in eine Präsentation. Sie enthält mehrere Überladungen der Methode [AddChartFromWorkbook](https://reference.aspose.com/slides/de/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), die es Ihnen ermöglichen, das ausgewählte Diagramm aus der angegebenen Excel‑Arbeitsmappe abzurufen und am Ende der angegebenen Formensammlung an den angegebenen Koordinaten hinzuzufügen.

#### **Excel‑Tabelle importieren**

Die Klasse [ExcelWorkbookImporter](https://reference.aspose.com/slides/de/net/aspose.slides.import/excelworkbookimporter/) enthält außerdem mehrere Überladungen der Methode [AddTableFromWorkbook](https://reference.aspose.com/slides/de/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/). Mit diesen Methoden können Sie einen angegebenen Zellbereich aus einem angegebenen Arbeitsblatt importieren und als Tabelle am Ende der angegebenen Formensammlung an den angegebenen Koordinaten hinzufügen.

Kurz gesagt, es ist eine leichte und unkomplizierte API zum Lesen von Excel‑Daten – genau das, was viele Entwickler benötigen, ohne den Overhead einer vollständigen Tabellenkalkulations‑Verarbeitungsbibliothek.

## **Lass uns programmieren**

### **Beispiel für Seriendruck‑Szenario**

Im folgenden Beispiel implementieren wir ein einfaches Seriendruck‑Szenario, indem wir mehrere Präsentationen basierend auf Daten aus einer Excel‑Arbeitsmappe erzeugen.

Um zu beginnen, benötigen wir zwei Dinge:
1. Eine Excel‑Arbeitsmappe, die die Daten enthält

![Beispiel für Excel‑Daten](example1_image0.png)

2. PowerPoint‑Präsentationsvorlage

![Beispiel für PowerPoint‑Vorlage](example1_image1.png)

```csharp
// Lade die Excel-Arbeitsmappe mit Mitarbeiterdaten.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Lade die Präsentationsvorlage.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Durchlaufe die Excel‑Zeilen (ohne die Kopfzeile in Zeile 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Erstelle für jeden Mitarbeitereintrag eine neue Präsentation.
    using Presentation employeePresentation = new Presentation();

    // Entferne die standardmäßige leere Folie.
    employeePresentation.Slides.RemoveAt(0);

    // Kopiere die Vorlagenfolie in die neue Präsentation.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Hole Absätze aus der Zielform (es wird angenommen, dass Formindex 1 verwendet wird).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Ersetze die Platzhalter durch Daten aus Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Speichere die personalisierte Präsentation in einer separaten Datei.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Ergebnis](example1_image2.png)

### **Beispiel für Excel‑Tabelle**

Im zweiten Beispiel kopieren wir einfach Daten aus einer Excel‑Tabelle und zeigen sie auf einer PowerPoint‑Folien in einem ansprechenderen visuellen Format an.

In diesem Beispiel verwenden wir erneut dieselbe Excel‑Arbeitsmappe wie im ersten Beispiel, die eine einfache Mitarbeitertabelle enthält.

```csharp
// Lade die Excel-Arbeitsmappe, die die Mitarbeiterdaten enthält.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Erstelle eine neue PowerPoint-Präsentation.
using Presentation presentation = new Presentation();

// Füge der ersten Folie eine Tabellenform hinzu.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Befülle die PowerPoint-Tabelle mit Daten aus der Excel-Arbeitsmappe.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Speichere die resultierende Präsentation in einer Datei.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Ergebnis](example2_image0.png)

### **Beispiel für das Importieren eines Excel‑Diagramms**

In diesem Beispiel importieren wir ein Diagramm aus dem ersten Arbeitsblatt der Excel‑Arbeitsmappe, die im vorherigen Beispiel verwendet wurde. Das Diagramm wird in der resultierenden Präsentation mit der externen Arbeitsmappe verlinkt.

Zuerst fügen wir der Excel‑Arbeitsmappe basierend auf der Mitarbeitertabelle ein Kreisdiagramm hinzu.

![Beispiel für Excel‑Diagramm](example3_image0.png)

```csharp
// Erstelle eine neue PowerPoint-Präsentation.
using Presentation presentation = new Presentation();

// Hole die Formen-Sammlung der ersten Folie.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importiere das Diagramm mit dem Namen "Chart 1" aus dem ersten Blatt der Arbeitsmappe und füge es der Formen-Sammlung hinzu.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Speichere die resultierende Präsentation in einer Datei.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Ergebnis](example3_image1.png)

### **Beispiel für das Importieren aller Excel‑Diagramme**

Stellen Sie sich vor, Sie haben eine Excel‑Arbeitsmappe voller Diagramme und müssen sie alle in eine Präsentation importieren. Jedes Diagramm soll auf einer neuen Folie platziert werden.

Der folgende Code iteriert über alle Arbeitsblätter in der Quell‑Excel‑Datei, extrahiert die Diagramme aus jedem Arbeitsblatt und fügt jedes Diagramm mittels eines leeren Folienlayouts einer separaten Folie hinzu. In der resultierenden Präsentation werden nur die Diagrammdaten eingebettet, nicht die gesamte Arbeitsmappe.

```csharp
// Lade die Excel-Arbeitsmappe, die die Mitarbeiterdaten enthält.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Erstelle eine neue PowerPoint-Präsentation.
using Presentation presentation = new Presentation();

// Rufe das leere Folienlayout ab.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Hole die Namen aller Arbeitsblätter, die in der Excel-Arbeitsmappe enthalten sind.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Rufe ein Wörterbuch ab, das Diagramm-Indizes den Diagrammnamen des Arbeitsblatts zuordnet.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Füge eine neue Folie mit dem leeren Layout hinzu.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importiere das angegebene Diagramm aus der Excel-Arbeitsmappe in die Formen-Sammlung der Folie.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Speichere die resultierende Präsentation in einer Datei.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Beispiel für das Importieren einer Excel‑Tabelle**

In diesem Beispiel importieren wir eine formatierte Tabelle aus einem Excel‑Arbeitsblatt direkt in eine PowerPoint‑Präsentation.

Das Quell‑Excel‑Arbeitsblatt enthält eine formatierte Tabelle mit Mitarbeiterdaten:

![Beispiel für Excel‑Tabelle](example4_image0.png)

```csharp
// Erstelle eine neue PowerPoint-Präsentation.
using Presentation presentation = new Presentation();

// Hole die Formen-Sammlung der ersten Folie.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importiere die Tabelle aus dem ersten Blatt der Arbeitsmappe und füge sie der Formen-Sammlung hinzu.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Speichere die resultierende Präsentation in einer Datei.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![Ergebnis](example4_image1.png)

## **Zusammenfassung**

Dieser Mechanismus, der direkt in Aspose.Slides verfügbar ist, kombiniert die Arbeit mit Excel‑Daten und Präsentationen an einem Ort. Er ermöglicht das Erstellen von Folien mit visuellen Diagrammen und als Excel‑Tabellen dargestellten Daten – ohne zusätzliche Bibliotheken oder komplexe Integrationen.