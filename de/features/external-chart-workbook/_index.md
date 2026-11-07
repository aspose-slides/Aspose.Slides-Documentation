---
title: Diagramme mit externen Arbeitsmappen verknüpfen
description: Diagrammdaten mit einer externen Arbeitsmappe verknüpfen und aktualisieren.
type: docs
url: /de/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: Diagramme
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **Übersicht**

Verknüpfen Sie ein Diagramm mit einer externen Arbeitsmappe, anstatt alle Quelldaten in der Präsentation einzubetten. Sie können den Pfad der Arbeitsmappe festlegen und wählen, ob das Diagramm aus dieser Datei aktualisiert werden soll. Das gespeicherte Diagramm kann außerdem zwischengespeicherte Anzeigedaten enthalten.

## **Verwendungsbeispiel**

Dieses C#‑Beispiel verwendet Aspose.Slides für .NET. Erstellen Sie eine gültige Verkaufsarbeitsmappe mit North = 55 und South = 40 und schreiben Sie sie als sales.xlsx neben die Ausgabedatei. Setzen Sie den North‑Wert des Diagramms auf 20 zurück, verknüpfen Sie dann das Diagramm mit dem absoluten Pfad der Arbeitsmappe und aktualisieren Sie es: North wird wieder 55. Der explizite Bereich umfasst die Kopfzeile und zwei Datenzeilen. Halten Sie sales.xlsx verfügbar, wenn Sie das verknüpfte Diagramm erneut öffnen oder aktualisieren; die Präsentation bettet diese externe Datei nicht ein. Es wird keine Eingabedatei benötigt. Es speichert *external-chart-workbook.pptx* und *external-chart-workbook.png*. Installieren Sie die Bibliothek mit dem [Installationsanleitung](/slides/de/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **FAQ**

### **Kann ich jeden zwischengespeicherten Wert lesen, wenn die verknüpfte Datei fehlt?**

Aspose.Slides für .NET 26.11 kann [gespeicherte Diagrammwerte direkt lesen](/slides/de/net/chart-workbook/#read-cached-chart-values-without-a-workbook) ohne die verknüpfte Arbeitsmappe zu öffnen. Dies umfasst normale Werte, X/Y‑Werte, Blasengrößen und Kategoriewerte, wenn diese Caches vorhanden sind. Zwischengespeicherte Daten können fehlen oder veraltet sein; sie stellen keine vollständige Arbeitsmappe dar. Das Aktualisieren aus der Quelle erfordert weiterhin eine verfügbare unterstützte Arbeitsmappe. Für andere SDKs und Versionen prüfen Sie deren entsprechende Diagramm‑Leitfaden.

### **Was passiert, wenn die externe Arbeitsmappe verschoben wird?**

Aktualisieren Sie den Pfad der externen Arbeitsmappe des Diagramms auf den neuen Speicherort und stellen Sie sicher, dass diese Datei überall dort verfügbar ist, wo die Präsentation verarbeitet wird. Verlassen Sie sich nicht auf zwischengespeicherte Daten für vollständige Datenzugriffs‑Operationen, wenn sie fehlen.

### **Kann ich wählen, ob zwischengespeicherte Diagrammdaten beim Verknüpfen aktualisiert werden sollen?**

Ja. Wählen Sie, ob Diagrammdaten beim Setzen der Verknüpfung aktualisiert werden sollen. Das Aktualisieren erfordert eine verfügbare unterstützte Arbeitsmappe; das Überspringen der Aktualisierung speichert die Verknüpfung, ohne neue Werte aus dieser Datei zu lesen.

## **Guides**

- [Verwalten von Diagrammarbeitsmappen in Präsentationen in .NET](/slides/de/net/chart-workbook/)

Related feature: [Diagramme editierbar mit Daten füllen](/slides/de/features/chart-data-binding/).