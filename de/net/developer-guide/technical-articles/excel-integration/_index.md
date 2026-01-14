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
description: "Lesen Sie Daten aus Excel-Arbeitsmappen in Aspose.Slides mithilfe der ExcelDataWorkbook-API. Laden Sie Arbeitsblätter und Zellen und verwenden Sie die Werte, um datengetriebene PowerPoint-Präsentationen zu erstellen."
---

## **Einleitung**

PowerPoint‑Präsentationen sind ein leistungsstarkes Mittel, um Informationen darzustellen und zu vermitteln. Sie werden häufig zusammen mit Excel‑Arbeitsmappen verwendet, wobei Excel eine hervorragende Quelle für strukturierte Daten liefert und PowerPoint diese Daten für ein Publikum visualisiert.

Es gibt viele praxisnahe Szenarien, in denen die Kombination von Excel und PowerPoint unverzichtbar ist: Seriendrucke, Befüllung von Datentabellen, Erzeugen einer Folie pro Datensatz (Batch‑Foliengenerierung), Erstellung von Schulungsunterlagen und Konsolidierung mehrerer Excel‑Berichte zu einer einzigen Präsentation, um nur einige zu nennen.

Bisher erforderte die Implementierung solcher Funktionen mit der Aspose.Slides‑API die Nutzung von Drittanbieter‑Lösungen wie Aspose.Cells. Obwohl diese Werkzeuge robust sind, können sie für Anwender, die nur grundlegende Datenintegrations‑Funktionalität benötigen, übermäßig komplex und kostspielig sein.

## **Wie es funktioniert**

Um die Arbeit mit Excel‑Daten einfacher und effizienter zu gestalten, hat Aspose.Slides neue Klassen eingeführt, die Daten aus Excel‑Arbeitsmappen lesen und Inhalte in eine Präsentation importieren können. Diese Funktion eröffnet API‑Nutzern leistungsstarke neue Möglichkeiten, Excel als Datenquelle in ihren Präsentations‑Workflows zu nutzen.

Die neue Funktionalität ist für den allgemeinen Datenzugriff konzipiert und ist nicht in das Presentation Document Object Model (DOM) integriert. Das bedeutet, *sie erlaubt weder das Bearbeiten noch das Speichern von Excel‑Dateien* – ihr einziger Zweck besteht darin, Arbeitsmappen zu öffnen und deren Inhalt zu durchsuchen, um Zellenwerte abzurufen.

Im Kern dieser Funktion steht die neue [ExcelDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.excel/exceldataworkbook/)‑Klasse. Mit dieser Klasse können Sie eine Excel‑Arbeitsmappe aus einer lokalen Datei oder einem Stream laden. Nach dem Laden bietet sie mehrere Überladungen der [GetCell](https://reference.aspose.com/slides/net/aspose.slides.excel/exceldataworkbook/getcell/)‑Methode, mit denen Sie bestimmte Zellen anhand ihrer Position (z. B. Zeilen‑ und Spaltenindizes oder benannte Bereiche) abrufen können.

Jeder Aufruf von [GetCell](https://reference.aspose.com/slides/net/aspose.slides.excel/exceldataworkbook/getcell/) liefert eine Instanz der [ExcelDataCell](https://reference.aspose.com/slides/net/aspose.slides.excel/exceldatacell/)‑Klasse. Dieses Objekt stellt eine einzelne Zelle in der Excel‑Arbeitsmappe dar und ermöglicht Ihnen den Zugriff auf ihren Wert auf einfache und intuitive Weise.

#### **Excel‑Diagramm importieren**

Der nächste Schritt zur Erweiterung der Funktionalität ist die [ExcelWorkbookImporter](https://reference.aspose.com/slides/net/aspose.slides.import/excelworkbookimporter/)‑Klasse. Diese Hilfsklasse bietet Funktionen zum Importieren von Inhalten aus einer Excel‑Arbeitsmappe in eine Präsentation. Sie enthält mehrere Überladungen der [AddChartFromWorkbook](https://reference.aspose.com/slides/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/)‑Methode, die Ihnen hilft, das ausgewählte Diagramm aus der angegebenen Excel‑Arbeitsmappe zu holen und es am Ende der angegebenen Shape‑Collection an den gewünschten Koordinaten einzufügen.

Kurz gesagt, es handelt sich um eine leichte und unkomplizierte API zum Lesen von Excel‑Daten – genau das, was viele Entwickler benötigen, ohne den Aufwand einer kompletten Tabellenkalkulations‑Verarbeitungsbibliothek.

## **Lass uns coden**

### **Beispiel für Mail‑Merge‑Szenario**

Im folgenden Beispiel implementieren wir ein einfaches Mail‑Merge‑Szenario, indem wir mehrere Präsentationen basierend auf den in einer Excel‑Arbeitsmappe gespeicherten Daten erzeugen.

Um zu beginnen, benötigen wir zwei Dinge:
1. Eine Excel‑Arbeitsmappe mit den Daten

![Beispiel für Excel‑Daten](example1_image0.png)

2. PowerPoint‑Vorlagendatei

![Beispiel für PowerPoint‑Vorlage](example1_image1.png)
```csharp
// Laden Sie die Excel-Arbeitsmappe mit den Mitarbeiterdaten.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Laden Sie die Präsentationsvorlage.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Durchlaufen Sie die Excel-Zeilen (ohne die Kopfzeile in Zeile 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Erstellen Sie für jeden Mitarbeitereintrag eine neue Präsentation.
    using Presentation employeePresentation = new Presentation();

    // Entfernen Sie die standardmäßige leere Folie.
    employeePresentation.Slides.RemoveAt(0);

    // Klonen Sie die Vorlagefolie in die neue Präsentation.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Holen Sie die Absätze aus der Zielform (es wird angenommen, dass Shape-Index 1 verwendet wird).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Ersetzen Sie die Platzhalter durch Daten aus Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Speichern Sie die personalisierte Präsentation in einer separaten Datei.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```


![Ergebnis](example1_image2.png)

### **Beispiel für Excel‑Tabelle**

Im zweiten Beispiel kopieren wir einfach Daten aus einer Excel‑Tabelle und zeigen sie auf einer PowerPoint‑Folie in einem ansprechenderen Format an.

In diesem Beispiel verwenden wir wieder dieselbe Excel‑Arbeitsmappe aus dem ersten Beispiel, die eine einfache Mitarbeitertabelle enthält.
```csharp
// Laden Sie die Excel-Arbeitsmappe mit den Mitarbeiterdaten.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Erstellen Sie eine neue PowerPoint-Präsentation.
using Presentation presentation = new Presentation();

// Fügen Sie der ersten Folie ein Tabellenelement hinzu.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Füllen Sie die PowerPoint-Tabelle mit Daten aus der Excel-Arbeitsmappe.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Speichern Sie die resultierende Präsentation in einer Datei.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```


![Ergebnis](example2_image0.png)

### **Beispiel für das Importieren eines Excel‑Diagramms**

In diesem Beispiel importieren wir ein Diagramm aus dem ersten Arbeitsblatt der Excel‑Arbeitsmappe, die im vorherigen Beispiel verwendet wurde. Das Diagramm wird in der resultierenden Präsentation mit der externen Arbeitsmappe verknüpft.

Zuerst fügen wir der Excel‑Arbeitsmappe basierend auf der Mitarbeitertabelle ein Kreisdiagramm hinzu.

![Beispiel für Excel‑Diagramm](example3_image0.png)
```csharp
// Erstellen Sie eine neue PowerPoint-Präsentation.
using Presentation presentation = new Presentation();

// Rufen Sie die Formensammlung der ersten Folie ab.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importieren Sie das Diagramm mit dem Namen "Chart 1" aus dem ersten Blatt der Arbeitsmappe und fügen Sie es der Formensammlung hinzu.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Speichern Sie die resultierende Präsentation in einer Datei.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```

![Ergebnis](example3_image1.png)

### **Beispiel für das Importieren aller Excel‑Diagramme**

Stellen Sie sich vor, Sie besitzen eine Excel‑Arbeitsmappe voller Diagramme und müssen alle in eine Präsentation importieren. Jedes Diagramm soll auf einer neuen Folie platziert werden.

Der folgende Code iteriert über alle Arbeitsblätter in der Quell‑Excel‑Datei, extrahiert die Diagramme jedes Arbeitsblatts und fügt jedes Diagramm einer separaten Folie mit einem leeren Folienlayout hinzu. In der resultierenden Präsentation werden nur die Diagrammdaten eingebettet, nicht die gesamte Arbeitsmappe.
```csharp
// Laden Sie die Excel-Arbeitsmappe mit den Mitarbeiterdaten.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Erstellen Sie eine neue PowerPoint-Präsentation.
using Presentation presentation = new Presentation();

// Rufen Sie das leere Folienlayout ab.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Holen Sie die Namen aller im Excel-Arbeitsbuch enthaltenen Arbeitsblätter.
IList<string> worksheetNames = workbook.GetWorksheetNames();
foreach (var name in worksheetNames)
{
    // Rufen Sie ein Wörterbuch ab, das Diagramm-Indizes den Diagramm‑Namen im Arbeitsblatt zuordnet.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Fügen Sie eine neue Folie mit dem leeren Layout hinzu.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importieren Sie das angegebene Diagramm aus der Excel-Arbeitsmappe in die Formensammlung der Folie.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Speichern Sie die resultierende Präsentation in einer Datei.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```


## **Zusammenfassung**

Dieser Mechanismus, der direkt in Aspose.Slides verfügbar ist, kombiniert die Arbeit mit Excel‑Daten und Präsentationen an einem Ort. Er ermöglicht das Erstellen von Folien mit visuellen Diagrammen und als Excel‑Tabellen dargestellten Daten – ohne zusätzliche Bibliotheken oder komplexe Integrationen.