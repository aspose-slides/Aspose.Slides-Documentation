---
title: Collegare i grafici a cartelle di lavoro esterne
description: Collegare i dati del grafico a una cartella di lavoro esterna e aggiornarli.
type: docs
url: /it/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: grafici
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **Panoramica**

Indirizza un grafico a una cartella di lavoro esterna invece di mantenere tutti i dati di origine incorporati nella presentazione. Puoi impostare il percorso della cartella di lavoro e scegliere se aggiornare il grafico da quel file. Il grafico salvato può anche contenere dati di visualizzazione memorizzati nella cache.

## **Esempio di utilizzo**

Questo esempio C# utilizza Aspose.Slides per .NET. Crea una cartella di lavoro di vendite valida con Nord = 55 e Sud = 40 e salvala come sales.xlsx accanto all'output. Reimposta il valore Nord del grafico a 20, quindi collega il grafico al percorso assoluto della cartella di lavoro e aggiorna: Nord torna a 55. L'intervallo esplicito copre l'intestazione e due righe di dati. Mantieni sales.xlsx disponibile quando riapri o aggiorni il grafico collegato; la presentazione non incorpora questo file esterno. Non è necessario alcun file di input. Salva *external-chart-workbook.pptx* e *external-chart-workbook.png*. Installa la libreria usando la [guida all'installazione](/slides/it/net/installation/).

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

### **Posso leggere tutti i valori memorizzati nella cache quando il file collegato è mancante?**

Aspose.Slides per .NET 26.11 può [leggere i valori del grafico memorizzati direttamente](/slides/it/net/chart-workbook/#read-cached-chart-values-without-a-workbook) senza aprire la cartella di lavoro collegata. Questo include valori ordinari, valori X/Y, dimensioni delle bolle e valori di categoria quando tali cache esistono. I dati nella cache possono essere assenti o obsoleti; non rappresentano una cartella di lavoro completa. L'aggiornamento dalla fonte richiede comunque una cartella di lavoro supportata disponibile. Per altri SDK e versioni, consulta la relativa guida al grafico.

### **Cosa succede se la cartella di lavoro esterna viene spostata?**

Aggiorna il percorso della cartella di lavoro esterna del grafico al nuovo percorso e rendi quel file disponibile ovunque la presentazione venga elaborata. Non fare affidamento sui dati nella cache per operazioni di accesso completo ai dati quando è assente.

### **Posso scegliere se aggiornare i dati del grafico nella cache durante il collegamento?**

Sì. Scegli se aggiornare i dati del grafico quando imposti il collegamento. L'aggiornamento richiede una cartella di lavoro supportata disponibile; saltare l'aggiornamento registra il collegamento senza leggere nuovi valori da quel file.

## **Guide**

- [Gestire le cartelle di lavoro dei grafici nelle presentazioni in .NET](/slides/it/net/chart-workbook/)

Related feature: [Compilare grafici modificabili con i dati](/slides/it/features/chart-data-binding/).