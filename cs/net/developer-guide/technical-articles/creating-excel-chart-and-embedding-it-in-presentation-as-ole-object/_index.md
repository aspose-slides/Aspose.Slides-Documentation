---
title: Vytvořte grafy v Excelu a vložte je do prezentací jako objekty OLE
type: docs
weight: 50
url: /cs/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel graf
- vložit graf
- objekt OLE
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvořte graf v Excelu pomocí Aspose.Cells pro .NET a vložte sešit do prezentace PowerPoint pomocí Aspose.Slides, včetně náhledu grafu."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit sloupcový graf v Excelu pomocí Aspose.Cells pro .NET a vložit jeho sešit do prezentace PowerPoint pomocí Aspose.Slides pro .NET. Vložený sešit obsahuje jak zdrojová data, tak graf. Samostatná náhledová PNG zobrazuje graf na snímku před aktivací objektu OLE.

Výsledkem je vložený objekt Excel, nikoli nativní graf PowerPointu. Úprava sešitu přes OLE vyžaduje stolní aplikaci, která podporuje aktivaci OLE, a kompatibilní instalaci Excelu.

## **Požadavky**

Přidejte odkazy na Aspose.Cells pro .NET a Aspose.Slides pro .NET do svého C# projektu. Příklad používá příkazy na nejvyšší úrovni a vyžaduje C# 9 nebo novější. Microsoft Office není vyžadován pro generování prezentace s těmito knihovnami.

Žádné vstupní soubory nejsou potřeba: příklad vytvoří data a graf v paměti a poté zapíše `OutputChart.pptx` do aktuálního pracovního adresáře. Použijte licence pro oba produkty při běhu mimo evaluační režim.

## **Jak funguje vkládání**

1. Vytvořte sešit s listem dat a listem grafu.  
2. Aktivujte list grafu, aby se sešit otevřel na grafu.  
3. Nastavte OLE zobrazovací oblast sešitu a vykreslete graf do PNG.  
4. Uložte sešit jako XLSX v paměti a vložte tyto bajty do snímku.  
5. Přiřaďte PNG jako náhled objektu OLE a uložte prezentaci jako PPTX.

Oblast zobrazení sešitu a rámeček na snímku mají různé role. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) bere indexy řádků a sloupců počítané od nuly. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) naopak bere horní řádek, levý sloupec, dolní řádek a pravý sloupec. Příklad používá index řádku 55 a index sloupce 25 jako pravé dolní hranice; tyto hodnoty jsou volby rozvržení, nikoli počet řádků nebo sloupců dat.

Rámec snímku používá jednotku point. Příklad jej umístí do snímku a vystředí, přičemž zachová poměr stran PNG, místo aby roztahoval náhled tak, aby vyplnil snímek.

## **Vytvoření a vložení grafu**

Následující kompletní příklad naplní `DataSheet` čtyřmi řádky a pěti sloupci hodnot. Každý řádek se stane sérií grafu. `ChartSheet` je vybrán jako aktivní list před uložením sešitu.

Sešit je explicitně uložen jako XLSX, což odpovídá příponě `xlsx` předávané do [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG se načte přímo ze svého proudu bez mezikroku konverze bitmapy. Přiřazení přes [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) nahradí výchozí OLE zástupný obrázek.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// Vykreslete náhled grafu a samostatně serializujte editovatelný sešit.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Fit the preview within the slide without changing its aspect ratio.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Očekávaný výsledek**

`OutputChart.pptx` obsahuje jeden snímek s vloženým sešitem Excel a náhledem grafu. Sešit obsahuje původní data a sloupcový graf se čtyřmi sériemi. Náhled je vystředěn na snímku a zachovává své proporce.

![Sloupcový graf Excel zobrazený jako náhled vloženého sešitu](excel-chart-ole-preview.png)

V kompatibilním desktopovém prostředí PowerPointu s dostupným Excelem poklikněte na objekt pro aktivaci a úpravu vloženého sešitu. Aktivace a úpravy závisí na podpoře OLE hostitelské aplikace a nastaveních zabezpečení.

## **Často kladené otázky**

**Proč je potřeba náhledový obrázek?**  
Vložený sešit a jeho náhled na snímku jsou samostatný obsah. Poskytněte obrázek grafu, aby snímek zobrazoval graf místo výchozího zástupného textu „EMBEDDED OLE OBJECT“. Viz [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/net/object-preview-issue-when-adding-oleobjectframe/).

**Aktualizuje se náhled automaticky, když v kódu změníme sešit?**  
Považujte náhled za snímek. Při programatické aktualizaci dat sešitu vygenerujte obrázek grafu znovu a nahraďte náhled i data vloženého sešitu.

**Mohu použít XLS místo XLSX?**  
Ano. Uložte sešit ve formátu XLS a použijte `xls` jako příponu vložených dat. Přípona musí odpovídat skutečnému formátu sešitu; pouhá změna přípony data neconvertuje.

**Proč může objekt po aktivaci změnit velikost?**  
Hostitelská aplikace může aktualizovat prezentaci objektu OLE při aktivaci sešitu. Ovlivňují to jak OLE zobrazovací oblast sešitu, tak rozměry rámečku na snímku. Viz [Řešení pro změnu velikosti grafu v PPTX](/slides/cs/net/working-solution-for-chart-resizing-in-pptx/).

## **Související sekce**

- [Řešení pro změnu velikosti grafu v PPTX](/slides/cs/net/working-solution-for-chart-resizing-in-pptx/)
- [Problém s náhledem objektu při přidávání OleObjectFrame](/slides/cs/net/object-preview-issue-when-adding-oleobjectframe/)
- [Automatická aktualizace objektů OLE pomocí doplňku PowerPoint](/slides/cs/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)