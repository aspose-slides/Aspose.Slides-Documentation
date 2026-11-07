---
title: Propojit grafy s externími sešity
description: Propojit data grafu s externím sešitem a aktualizovat je.
type: docs
url: /cs/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **Přehled**

Nasměrujte graf na externí sešit místo toho, abyste v prezentaci uchovávali všechna jeho zdrojová data. Můžete nastavit cestu k sešitu a zvolit, zda aktualizovat graf z tohoto souboru. Uložený graf může také obsahovat uložená zobrazovací data.

## **Příklad použití**

Tento příklad v C# používá Aspose.Slides pro .NET. Vytvořte platný sešit prodeje s hodnotami North = 55 a South = 40 a uložte jej jako sales.xlsx vedle výstupu. Resetujte hodnotu North v grafu na 20, poté propojte graf s absolutní cestou k sešitu a obnovte: North se opět stane 55. Výslovný rozsah zahrnuje záhlaví a dva řádky dat. Udržujte soubor sales.xlsx dostupný při opětovném otevření nebo aktualizaci propojeného grafu; prezentace tento externí soubor nevestavuje. Vstupní soubor není potřeba. Uloží se *external-chart-workbook.pptx* a *external-chart-workbook.png*. Knihovnu nainstalujte podle [průvodce instalací](/slides/cs/net/installation/).

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

## **Často kladené otázky**

### **Mohu načíst všechny uložené hodnoty, když chybí odkazovaný soubor?**

Aspose.Slides pro .NET 26.11 může [přímo načíst uložené hodnoty grafu](/slides/cs/net/chart-workbook/#read-cached-chart-values-without-a-workbook) bez otevření propojeného sešitu. To zahrnuje běžné hodnoty, X/Y hodnoty, velikosti bublin a hodnoty kategorií, pokud tyto cache existují. Uložená data mohou chybět nebo být zastaralá; nejde o kompletní sešit. Aktualizace ze zdroje stále vyžaduje dostupný podporovaný sešit. Pro další SDK a verze si prohlédněte jejich odpovídající průvodce grafy.

### **Co se stane, když je externí sešit přesunut?**

Aktualizujte cestu k externímu sešitu grafu na jeho nové umístění a zajistěte, aby byl tento soubor dostupný všude, kde se prezentace zpracovává. Nespoléhejte se na uložená data pro operace vyžadující úplný přístup k datům, pokud chybí.

### **Mohu zvolit, zda se mají při propojení aktualizovat uložená data grafu?**

Ano. Zvolte, zda chcete při nastavení odkazu aktualizovat data grafu. Aktualizace vyžaduje dostupný podporovaný sešit; přeskočením aktualizace se odkaz zaznamená bez načtení nových hodnot z tohoto souboru.

## **Průvodci**

- [Spravovat sešity grafů v prezentacích v .NET](/slides/cs/net/chart-workbook/)

Související funkce: [Vyplnit editovatelné grafy daty](/slides/cs/features/chart-data-binding/).