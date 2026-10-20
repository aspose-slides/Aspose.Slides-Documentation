---
title: Pracovní řešení pro změnu velikosti grafu v PPTX
type: docs
weight: 60
url: /cs/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- změna velikosti grafu
- graf Excel
- OLE objekt
- vložit graf
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Opravte neočekávanou změnu velikosti grafu v PPTX při použití vložených OLE objektů Excel s Aspose.Slides pro .NET. Nastavte pevné rozměry grafu, aby byly velikosti grafu a OLE rámce konzistentní."
---
## **Pozadí**

Grafy Excel vložené jako OLE objekty v prezentacích PowerPoint za použití komponent Aspose mohou po prvním aktivování změnit velikost. To může způsobit znatelný rozdíl ve vzhledu grafu před a po aktivaci. Tento článek vysvětluje, proč dochází ke změně velikosti, a ukazuje, jak tomu předejít nastavením pevných rozměrů grafu tak, aby odpovídaly OLE rámci.

V [Vytvořit grafy Excel a vložit je jako OLE objekty do prezentací](/slides/cs/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) jsme vysvětlili, jak vytvořit graf Excel pomocí Aspose.Cells pro .NET a vložit jej do prezentace PowerPoint pomocí Aspose.Slides pro .NET. Pro řešení [problému s náhledem objektu](/slides/cs/net/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek grafu k OLE objektovému rámci grafu. Ve výstupní prezentaci, když dvojkliknete na OLE objektový rámec zobrazující obrázek grafu, aktivuje se graf Excel. Uživatelé mohou upravovat vložený sešit Excel a poté se vrátit na snímek kliknutím mimo aktivovaný sešit. Velikost OLE objektového rámce se změní, když se uživatel vrátí na snímek, a faktor změny velikosti se liší v závislosti na původních rozměrech jak OLE objektového rámce, tak vloženého sešitu Excel.

## **Příčina změny velikosti**

Vložený sešit Excel má vlastní rozměry okna, které se Excel snaží zachovat při první aktivaci objektu. OLE rámec na snímku má nezávisle definované rozměry. Když je sešit Excel aktivován, Excel a PowerPoint vyjednávají velikost objektu tak, aby zachovaly proporce jako součást procesu vkládání. Rozdíly mezi oknem sešitu a OLE rámcem tak mohou způsobit změnu velikosti objektu.

## **Funkční řešení**

Nastavte velikost grafu tak, aby odpovídala OLE rámci na snímku, a udržujte rozměry grafu nezávislé na okně sešitu. Toto řešení funguje jak pro novou prezentaci, tak pro existující šablonu.

Příklad vyžaduje Aspose.Cells pro .NET a Aspose.Slides pro .NET. Vytvoří jednoduchý sloupcový graf na aktivním listu grafu a vloží sešit ve formátu XLS. Nevkládá se žádný obrázek náhledu grafu; graf se zobrazí, když je OLE objekt v PowerPointu aktivován.

Příklad vytvoří novou prezentaci s OLE rámcem o rozměrech 9,5 × 4 palce umístěným 0,5 palce od levého okraje a 1 palec od horního okraje. Souřadnice a rozměry snímku jsou v bodech (72 bodů na palec). Pro existující prezentaci viz [Použít šablonu](#use-a-template).

## **Nastavit pevnou velikost grafu**

Nastavte [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) na false, aby byly rozměry grafu nezávislé na okně sešitu. Nastavte rozměry [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) pomocí [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) a [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/), přičemž převádíte body na pixely při 96 pixelech na palec: rámec o rozměrech 684 × 288 bodů odpovídá grafu o rozměrech 912 × 384 pixelů. Nastavte [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) na vlastní hodnotu [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/). Příklad vloží sešit pomocí [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) a uloží prezentaci s OLE rámcem o rozměrech 9,5 × 4 palce.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Souřadnice a rozměry snímku jsou v bodech (72 bodů na palec).
var width = 684f; // 9,5 palce.
var height = 288f; // 4 palce.

chart.SizeWithWindow = false;
// Convert points to chart pixels using 96 pixels per inch.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Použít šablonu**

Logika určování velikosti je stejná pro existující prezentaci. Pro úpravu příkladu:

1. Načtěte prezentaci ze šablony místo vytváření prázdné prezentace.  
2. Zkontrolujte, že první snímek obsahuje alespoň tři tvary, a poté použijte tvar s indexem 2 jako zástupný znak.  
3. Získejte šířku a výšku rámce z tohoto tvaru místo pevných hodnot 684 a 288. Nechte výpočty velikosti beze změny.  
4. Přidejte OLE rámec na pozici zástupného znaku místo pevných souřadnic 36 a 72.  
5. Odstraňte zástupný znak před uložením prezentace.

## **Často kladené dotazy**

**Proč se můj vložený graf Excel mění po aktivaci v PowerPointu?**  
Stane se to, protože Excel se při první aktivaci snaží obnovit původní velikost okna, zatímco OLE objektový rámec v PowerPointu má své vlastní rozměry. PowerPoint a Excel pak vyjednávají velikost tak, aby zachovaly poměr stran, což může vést ke změně velikosti.

**Jak mohu udržet konzistentní velikosti grafu a OLE rámce?**  
Nastavte pevné rozměry grafu, které odpovídají OLE rámci, a použijte vlastní velikost tisku grafu před vložením sešitu. Výše uvedený příklad ukazuje požadovaná nastavení a převody jednotek.

**Je přizpůsobení velikosti okna sešitu dostatečné?**  
Pouze přizpůsobení velikosti okna sešitu spolehlivě nechrání OLE rámec před změnou velikosti po aktivaci. Použijte pevné rozměry grafu, jak je ukázáno v příkladu.

**Funguje toto řešení jak pro prezentace založené na šabloně, tak pro nové prezentace?**  
Ano. Pro šablonu použijte rozměry a pozici zástupného znaku. Pro novou prezentaci specifikujte rozměry a pozici rámce přímo.

**Mohu použít tento příklad s grafy vytvořenými v jiných tabulkových programech?**  
Příklad používá sešit Excel vytvořený pomocí Aspose.Cells. Neukazuje chování aktivace pro jiné tabulkové programy.

## **Související sekce**

- [Vytvořit grafy Excel a vložit je jako OLE objekty do prezentací](/slides/cs/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Automaticky aktualizovat OLE objekty pomocí PowerPoint add-inu](/slides/cs/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)