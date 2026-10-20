---
title: Řešení problému se změnou velikosti listu
type: docs
weight: 40
url: /cs/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- náhledový obrázek
- změna velikosti obrázku
- Excel
- list
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Opravte změnu velikosti OLE listu Excel v prezentacích: dva způsoby, jak udržet rámce objektů konzistentní—škálovat rámec nebo list—napříč formáty PPT a PPTX."
---
{{% alert color="info" title="Note" %}}
Listy Excel vložené jako OLE objekty v prezentaci PowerPoint pomocí komponent Aspose se mohou po první aktivaci neočekávaně změnit velikost. Toto chování vytváří znatelný vizuální rozdíl mezi OLE objektem před a po aktivaci. Tento článek popisuje problém a uvádí dva způsoby, jak jej vyřešit.
{{% /alert %}} 

## **Pozadí**

V článku [Spravovat OLE](/slides/cs/net/manage-ole/) jsme vysvětlili, jak pomocí Aspose.Slides pro .NET přidat OLE rámec do prezentace PowerPoint. Pro řešení [problému s náhledem objektu](/slides/cs/net/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek vybraného oblasti listu do OLE rámce. V výstupní prezentaci, když dvakrát kliknete na OLE rámec zobrazující obrázek listu, aktivuje se sešit Excel. Koncoví uživatelé mohou provést libovolné požadované změny ve skutečném sešitu Excel a poté se vrátit na snímek kliknutím mimo aktivovaný sešit Excel. Velikost OLE rámce se změní, když se uživatel vrátí na snímek. Faktor změny velikosti se bude lišit v závislosti na velikosti OLE rámce a vloženého sešitu Excel.

## **Příčina změny velikosti**

Protože má sešit Excel vlastní velikost okna, snaží se při první aktivaci zachovat původní velikost. Na druhé straně má OLE rámec svou vlastní velikost. Podle Microsoftu, když je sešit Excel aktivován, Excel a PowerPoint vyjednávají velikost tak, aby zachovaly správné proporce v rámci procesu vkládání. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excel a velikostí a polohou OLE rámce.

## **Řešení**

Existují dva možné způsoby, jak se vyhnout efektu změny velikosti.

- Změňte měřítko OLE rámce v prezentaci PowerPoint tak, aby odpovídal celkové výšce a šířce vybraných řádků a sloupců.
- Udržujte velikost OLE rámce konstantní a přizpůsobte měřítko vybraných řádků a sloupců tak, aby do něj vešly.

### **Změnit měřítko velikosti OLE rámce**

Tento přístup nastaví velikost OLE rámce tak, aby odpovídala celkové výšce a šířce vybraných řádků a sloupců v vloženém listu Excel.

Příklad načte existující sešit Excel a pomocí nulových indexů vybere prvních 10 řádků a 13 sloupců jeho prvního listu. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) definuje zobrazovaný rozsah. Náhled je vykreslen při 96 DPI a jeho rozměry v pixelech jsou převedeny na body pomocí 72 bodů na palec. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) vloží upravený sešit do rámce s těmito rozměry. Náhled je přiřazen prostřednictvím [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) pro nahrazení zástupného textu "EMBEDDED OLE OBJECT" v uložené prezentaci.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Nastavte zobrazovanou velikost, když je soubor sešitu použit jako OLE objekt v PowerPointu.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Získejte šířku a výšku OLE obrázku v bodech.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Musíme použít upravený sešit.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Přidejte OLE obrázek do zdrojů prezentace.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Vytvořte rámec OLE objektu.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Pomocná funkce pro náhled nastaví [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) na vybraný rozsah a odstraní okraje, záhlaví a zápatí. S povoleným [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) vykreslí rozsah jako PNG obrázek. Pomocná funkce přetočí proud obrázku zpět před jeho vrácením pro použití v prezentaci.

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **Změnit měřítko velikosti rozsahu buněk**

Tento přístup měří výšky vybraných řádků a šířky vybraných sloupců tak, aby odpovídaly vlastní velikosti OLE rámečku.

Příklad načte existující sešit Excel a pomocí nulových indexů vybere prvních 10 řádků a 13 sloupců jeho prvního listu. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) definuje zobrazovaný rozsah a níže uvedená pomocná funkce měří tento rozsah tak, aby se vešel do rámce širokého 400 bodů a vysokého 100 bodů. Po uložení upraveného sešitu do proudu, [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) vloží jej v určené velikosti. Náhled vykreslený při 96 DPI je přiřazen prostřednictvím [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/), takže uložená prezentace zobrazuje vybrané buňky místo výchozího zástupného textu.

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Nastavte zobrazovanou velikost, když je soubor sešitu použit jako OLE objekt v PowerPointu.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Změřte rozsah buněk tak, aby odpovídal velikosti rámce.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Musíme použít upravený sešit.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Přidejte OLE obrázek do zdrojů prezentace.
var oleImage = presentation.Images.AddImage(imageStream);

// Vytvořte rámec OLE objektu.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Pomocná funkce pro měřítko vypočítá samostatné poměry šířky a výšky pro vybraný rozsah, přičemž zachovává relativní šířky jeho sloupců a relativní výšky jeho řádků. Před jejich použitím s [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) a [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/) převádí vypočtené rozměry z bodů na palce. Vybraný rozsah musí mít nenulovou šířku i výšku.

```cs
/// <param name="width">Očekávaná šířka rozsahu buněk v bodech.</param>
/// <param name="height">Očekávaná výška rozsahu buněk v bodech.</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

Tato pomocná funkce pro náhled vykreslí změněný rozsah pomocí [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/). Omezí [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) na tento rozsah, odstraní okraje, záhlaví a zápatí a vrátí PNG proud nastavený na jeho začátek.

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **Závěr**
{{% alert color="info" title="Note" %}}
Existují dva přístupy k vyřešení problému se změnou velikosti listu. Vyberte přístup, který nejlépe vyhovuje vašim požadavkům a scénáři použití. Oba přístupy fungují stejně, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Navíc neexistuje žádný limit velikosti OLE rámce v tomto řešení.
{{% /alert %}}

## **Často kladené otázky**

**Proč se vložený list Excel změní velikost při první aktivaci v PowerPointu?**  
K tomu dochází, protože se Excel při aktivaci snaží zachovat původní velikost okna, zatímco OLE rámec v PowerPointu má vlastní rozměry. PowerPoint a Excel vyjednávají velikost tak, aby zachovaly poměr stran, což může způsobit změnu velikosti.

**Je možné tento problém se změnou velikosti zcela zabránit?**  
Ano. Změněním měřítka OLE rámce tak, aby odpovídal velikosti rozsahu buněk Excel, nebo změněním měřítka rozsahu buněk tak, aby odpovídal požadované velikosti OLE rámce, můžete zabránit nechtěné změně velikosti.

**Kterou metodu měřítka mám použít, měřítko OLE rámce nebo měřítko rozsahu buněk?**  
Zvolte **měřítko OLE rámce**, pokud chcete zachovat původní velikosti řádků a sloupců v Excelu. Zvolte **měřítko rozsahu buněk**, pokud chcete mít v prezentaci pevnou velikost OLE rámce.

**Budou tato řešení fungovat, pokud je moje prezentace založena na šabloně?**  
Ano. Obě řešení fungují pro prezentace vytvořené ze šablon i od nuly.

**Existuje limit velikosti OLE rámce při použití těchto metod?**  
Ne. Můžete nastavit OLE rámec na jakoukoli velikost, pokud nastavíte měřítko vhodně.

**Existuje způsob, jak se vyhnout textu zástupného symbolu „EMBEDDED OLE OBJECT“ v PowerPointu?**  
Ano. Po pořízení snímku cílového rozsahu buněk v Excelu a nastavení tohoto snímku jako obrázku zástupného symbolu OLE rámce můžete zobrazit vlastní obrázek náhledu místo výchozího zástupného symbolu.

## **Související články**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/cs/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/cs/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)