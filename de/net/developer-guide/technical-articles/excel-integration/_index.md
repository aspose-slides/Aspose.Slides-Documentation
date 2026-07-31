---
title: Excel-Daten in PowerPoint-Präsentationen integrieren
linktitle: Excel-Integration
type: docs
weight: 330
url: /de/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
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
description: "Daten aus Excel-Arbeitsmappen in Aspose.Slides mithilfe der ExcelDataWorkbook-API lesen. Arbeitsblätter und Zellen laden und die Werte verwenden, um datengesteuerte PowerPoint-Präsentationen zu erstellen."
---
## **Einleitung**

PowerPoint-Präsentationen sind ein leistungsstarkes Mittel, um Informationen darzustellen und zu kommunizieren. Sie werden häufig in Verbindung mit Excel-Arbeitsmappen verwendet, wobei Excel eine ausgezeichnete Quelle strukturierter Daten ist und PowerPoint diese Daten für ein Publikum visualisiert.

Es gibt viele praktische Szenarien, in denen die Kombination von Excel und PowerPoint unerlässlich ist: Seriendruck, Befüllen von Datentabellen, Erzeugen einer Folie pro Datenrecord (Stapel‑Folien‑Generierung), Erstellen von Schulungsmaterialien und Konsolidieren mehrerer Excel-Berichte zu einer einzigen Präsentation, um nur einige zu nennen.

Bisher erforderte die Implementierung solcher Funktionen mit der Aspose.Slides‑API die Nutzung von Drittanbieter‑Lösungen wie Aspose.Cells. Obwohl diese Werkzeuge robust sind, können sie für Anwender, die nur grundlegende Datenintegrationsfunktionen benötigen, zu komplex und teuer sein.

## **So funktioniert es**

Um die Arbeit mit Excel‑Daten zu vereinfachen und zu straffen, hat Aspose.Slides neue Klassen zum Lesen von Daten aus Excel‑Arbeitsmappen und zum Importieren von Inhalten in eine Präsentation eingeführt. Diese Funktion eröffnet API‑Benutzern leistungsstarke neue Möglichkeiten, Excel als Datenquelle in ihren Präsentations‑Workflows zu nutzen.

Die neue Funktionalität ist für den allgemein­zweckigen Datenzugriff konzipiert und ist nicht in das Presentation Document Object Model (DOM) integriert. Das bedeutet, *sie erlaubt weder das Bearbeiten noch das Speichern von Excel‑Dateien* – ihr einziger Zweck besteht darin, Arbeitsmappen zu öffnen und deren Inhalt zu durchsuchen, um Zellwerte abzurufen.

Im Kern dieser Funktion steht die neue [ExcelDataWorkbook](https://reference.aspose.com/slides/de/net/aspose.slides.excel/exceldataworkbook/)‑Klasse. Diese Klasse ermöglicht das Laden einer Excel‑Arbeitsmappe aus einer lokalen Datei oder einem Stream. Nach dem Laden stellt sie mehrere Überladungen der [GetCell](https://reference.aspose.com/slides/de/net/aspose.slides.excel/exceldataworkbook/getcell/)‑Methode bereit, mit denen Sie bestimmte Zellen anhand ihrer Position (z. B. Zeilen‑ und Spaltenindizes oder benannte Bereiche) abrufen können.

Jeder Aufruf von [GetCell](https://reference.aspose.com/slides/de/net/aspose.slides.excel/exceldataworkbook/getcell/) liefert eine Instanz der [ExcelDataCell](https://reference.aspose.com/slides/de/net/aspose.slides.excel/exceldatacell/)‑Klasse. Dieses Objekt repräsentiert eine einzelne Zelle in der Excel‑Arbeitsmappe und gibt Ihnen einfachen und intuitiven Zugriff auf deren Wert.

#### **Ein Excel‑Diagramm importieren**

Der nächste Schritt zur Erweiterung der Funktionalität ist die [ExcelWorkbookImporter](https://reference.aspose.com/slides/de/net/aspose.slides.import/excelworkbookimporter/)‑Klasse. Diese Hilfsklasse bietet Funktionen zum Importieren von Inhalten aus einer Excel‑Arbeitsmappe in eine Präsentation. Sie enthält mehrere Überladungen der [AddChartFromWorkbook](https://reference.aspose.com/slides/de/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/)‑Methode, die Ihnen hilft, das ausgewählte Diagramm aus der angegebenen Excel‑Arbeitsmappe abzurufen und am angegebenen Ort an das Ende der angegebenen Shape‑Collection anzufügen.

#### **Eine Excel‑Tabelle importieren**

Die [ExcelWorkbookImporter](https://reference.aspose.com/slides/de/net/aspose.slides.import/excelworkbookimporter/)‑Klasse enthält außerdem mehrere Überladungen der [AddTableFromWorkbook](https://reference.aspose.com/slides/de/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/)‑Methode. Mit diesen Methoden können Sie einen angegebenen Zellenbereich aus einem angegebenen Arbeitsblatt importieren und als Tabelle an das Ende der angegebenen Shape‑Collection an den festgelegten Koordinaten hinzufügen.

Kurz gesagt, es ist eine schlanke und unkomplizierte API zum Lesen von Excel‑Daten – genau das, was viele Entwickler benötigen, ohne den Overhead einer kompletten Tabellenkalkulationsbibliothek.

## **Lass uns programmieren**

### **Beispiel für Seriendruck‑Szenario**

Im folgenden Beispiel implementieren wir ein einfaches Seriendruck‑Szenario, indem wir mehrere Präsentationen auf Basis der in einer Excel‑Arbeitsmappe gespeicherten Daten erzeugen.

Um loszulegen, benötigen wir zwei Dinge:
1. Eine Excel‑Arbeitsmappe, die die Daten enthält

![Excel data example](example1_image0.png)

2. PowerPoint‑Präsentationsvorlage

![PowerPoint template example](example1_image1.png)

```csharp
// Laden der Excel-Arbeitsmappe mit Mitarbeiterdaten.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Präsentationsvorlage laden.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Durchlaufen der Excel‑Zeilen (Kopfzeile in Zeile 0 ausgenommen).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Für jeden Mitarbeitereintrag eine neue Präsentation erstellen.
    using Presentation employeePresentation = new Presentation();

    // Die standardmäßige leere Folie entfernen.
    employeePresentation.Slides.RemoveAt(0);

    // Die Vorlagenfolie in die neue Präsentation klonen.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Absätze aus dem Ziel‑Shape holen (es wird davon ausgegangen, dass Shape‑Index 1 verwendet wird).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Platzhalter durch Daten aus Excel ersetzen.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Die personalisierte Präsentation in einer separaten Datei speichern.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Result](example1_image2.png)

### **Beispiel für Excel‑Tabelle**

Im zweiten Beispiel kopieren wir einfach Daten aus einer Excel‑Tabelle und zeigen sie auf einer PowerPoint‑Folien in einem optisch ansprechenderen Format an.

In diesem Beispiel verwenden wir dieselbe Excel‑Arbeitsmappe wie im ersten Beispiel, die eine einfache Mitarbeitertabelle enthält.

```csharp
// Lade die Excel-Arbeitsmappe mit den Mitarbeiterdaten.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Erstelle eine neue PowerPoint-Präsentation.
using Presentation presentation = new Presentation();

// Füge dem ersten Folie eine Tabellengrafik hinzu.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Fülle die PowerPoint-Tabelle mit Daten aus der Excel-Arbeitsmappe.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Speichere die erstellte Präsentation in einer Datei.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Result](example2_image0.png)

### **Beispiel für das Importieren eines Excel‑Diagramms**

In diesem Beispiel importieren wir ein Diagramm aus dem ersten Arbeitsblatt der Excel‑Arbeitsmappe, die im vorherigen Beispiel verwendet wurde. Das Diagramm wird im resultierenden Dokument mit der externen Arbeitsmappe verknüpft.

Zunächst fügen wir der Excel‑Arbeitsmappe basierend auf der Mitarbeitertabelle ein Kreisdiagramm hinzu.

![Excel Chart example](example3_image0.png)

```csharp
// Erstelle eine neue PowerPoint-Präsentation.
using Presentation presentation = new Presentation();

// Hole die Shape-Sammlung der ersten Folie.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importiere das Diagramm mit dem Namen "Chart 1" aus dem ersten Arbeitsblatt der Arbeitsmappe und füge es der Shape-Sammlung hinzu.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Speichere die erstellte Präsentation in einer Datei.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Result](example3_image1.png)

### **Beispiel für das Importieren aller Excel‑Diagramme**

Stellen Sie sich vor, Sie haben eine Excel‑Arbeitsmappe voller Diagramme und müssen sie alle in eine Präsentation importieren. Jedes Diagramm soll auf einer neuen Folie platziert werden.

Der folgende Code iteriert über alle Arbeitsblätter in der Quell‑Excel‑Datei, extrahiert die Diagramme aus jedem Arbeitsblatt und fügt jedes Diagramm mit einem leeren Folienlayout zu einer eigenen Folie hinzu. In der resultierenden Präsentation werden nur die Diagrammdaten eingebettet, nicht die gesamte Arbeitsmappe.

```csharp
// Lade die Excel-Arbeitsmappe mit den Mitarbeiterdaten.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Erstelle eine neue PowerPoint-Präsentation.
using Presentation presentation = new Presentation();

// Hole das leere Folienlayout.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Erhalte die Namen aller Arbeitsblätter in der Excel-Arbeitsmappe.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Hole ein Wörterbuch, das Diagrammindizes den Diagrammnamen des Arbeitsblatts zuordnet.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Füge eine neue Folie mit dem leeren Layout hinzu.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importiere das angegebene Diagramm aus der Excel-Arbeitsmappe in die Shape-Sammlung der Folie.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Speichere die erstellte Präsentation in einer Datei.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Beispiel für das Importieren einer Excel‑Tabelle**

In diesem Beispiel importieren wir eine formatierte Tabelle aus einem Excel‑Arbeitsblatt direkt in eine PowerPoint‑Präsentation.

Das Quell‑Excel‑Arbeitsblatt enthält eine formatierte Tabelle mit Mitarbeiterdaten:

![Excel Table example](example4_image0.png)

```csharp
// Erstelle eine neue PowerPoint-Präsentation.
using Presentation presentation = new Presentation();

// Hole die Shape-Sammlung der ersten Folie.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importiere die Tabelle aus dem ersten Arbeitsblatt der Arbeitsmappe und füge sie der Shape-Sammlung hinzu.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Speichere die erstellte Präsentation in einer Datei.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![Result](example4_image1.png)

## **Zusammenfassung**

Dieser Mechanismus, der direkt in Aspose.Slides verfügbar ist, kombiniert die Arbeit mit Excel‑Daten und Präsentationen an einem Ort. Er ermöglicht das Erstellen von Folien mit visuellen Diagrammen und als Excel‑Tabellen dargestellten Daten – ganz ohne zusätzliche Bibliotheken oder komplexe Integrationen.