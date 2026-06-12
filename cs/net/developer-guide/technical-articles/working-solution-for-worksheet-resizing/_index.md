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
description: "Opravte změnu velikosti OLE listu Excel v prezentacích: dva způsoby, jak udržet rámce objektů konzistentní – změňte velikost rámce nebo listu – napříč formáty PPT a PPTX."
---
{{% alert color="primary" %}} 

Bylo zaznamenáno, že listy Excelu vložené jako OLE objekty v prezentaci PowerPoint pomocí komponent Aspose se po první aktivaci zvětší na neznámou míru. Toto chování vytváří výrazný vizuální rozdíl v prezentaci mezi před a po aktivaci OLE objektu. Problém jsme podrobně prozkoumali a poskytli řešení, které je popsáno v tomto článku.

{{% /alert %}} 

## **Pozadí**

V článku [Spravovat OLE](/slides/cs/net/manage-ole/) jsme vysvětlili, jak přidat OLE rámec do prezentace PowerPoint pomocí Aspose.Slides for .NET. Pro řešení [problému s náhledem objektu](/slides/cs/net/object-preview-issue-when-adding-oleobjectframe/) jsme OLE objektu přiřadili obrázek vybrané oblasti listu. V výstupní prezentaci, když dvakrát kliknete na OLE rámec zobrazující obrázek listu, aktivuje se sešit Excelu. Uživatelé mohou provést libovolné změny ve skutečném sešitu Excel a poté se vrátit na snímek kliknutím mimo aktivovaný sešit. Velikost OLE rámce se změní, když se uživatel vrátí na snímek. Faktor změny velikosti se bude lišit v závislosti na velikosti OLE rámce a vloženého sešitu Excel.

## **Příčina změny velikosti**

Protože má sešit Excelu vlastní velikost okna, pokouší se při první aktivaci zachovat původní velikost. OLE rámec má naopak vlastní rozměry. Podle Microsoftu, když je sešit Excelu aktivován, Excel a PowerPoint si dohodnou velikost tak, aby zachovaly správné proporce jako součást procesu vkládání. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excelu a rozměry a polohou OLE rámce.

## **Fungující řešení**

Existují dvě možná řešení, jak se vyhnout efektu změny velikosti.

- Změňte měřítko velikosti OLE rámce v prezentaci PowerPoint tak, aby odpovídalo výšce a šířce požadovaného počtu řádků a sloupců v OLE rámci.
- Udržujte velikost OLE rámce konstantní a změňte měřítko velikosti řádků a sloupců tak, aby se vešly do vybrané velikosti OLE rámce.

### **Změna měřítka velikosti rámce OLE**

V tomto přístupu se naučíte, jak nastavit velikost OLE rámce vloženého sešitu Excel tak, aby odpovídala kumulativní velikosti zapojených řádků a sloupců v listu Excel.

Předpokládejme, že máme šablonový list Excel a chceme jej přidat do prezentace jako OLE rámec. V tomto scénáři bude velikost OLE objektu nejprve vypočítána na základě součtu výšek řádků a šířek sloupců zapojených v sešitu. Poté nastavíme velikost OLE rámce na tuto vypočtenou hodnotu. Abychom v PowerPointu odstranili červenou zprávu „EMBEDDED OLE OBJECT“ u OLE rámce, zachytíme také obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámce.

```cs
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

### **Změna měřítka velikosti oblasti buněk**

V tomto přístupu se naučíte, jak změnit měřítko výšek zapojených řádků a šířek zapojených sloupců tak, aby odpovídaly vlastní velikosti OLE rámce.

Předpokládejme, že máme šablonový list Excel a chceme jej přidat do prezentace jako OLE rámec. V tomto scénáři nastavíme velikost OLE rámce a změříme velikost řádků a sloupců, které se podílejí na oblasti OLE rámce. Poté uložíme sešit do proudu, aby se změny použily, a převedeme jej na pole bytů pro přidání do OLE rámce. Abychom v PowerPointu odstranili červenou zprávu „EMBEDDED OLE OBJECT“ u OLE rámce, zachytíme také obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámce.

```cs
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

// Změňte měřítko oblastí buněk tak, aby odpovídaly velikosti rámce.
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

```cs
/// <param name="width">Očekávaná šířka oblasti buněk v bodech.</param>
/// <param name="height">Očekávaná výška oblasti buněk v bodech.</param>
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

{{% alert color="primary" %}}

Existují dva přístupy k vyřešení problému se změnou velikosti listu. Výběr vhodného přístupu závisí na konkrétních požadavcích a použití. Oba přístupy fungují stejně, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Navíc v tomto řešení neexistuje žádné omezení velikosti OLE objektu.

{{% /alert %}}

## **Často kladené otázky**

**Proč se vložený list Excelu změní po první aktivaci v PowerPointu?**  
K tomu dochází, protože Excel se snaží zachovat původní velikost okna při aktivaci, zatímco OLE rámec v PowerPointu má své vlastní rozměry. PowerPoint a Excel si vyjednávají velikost tak, aby zachovaly poměr stran, což může způsobit změnu velikosti.

**Je možné zcela zabránit tomuto problému se změnou velikosti?**  
Ano. Změnou měřítka OLE rámce tak, aby odpovídal velikosti oblasti buněk v Excelu, nebo změnou měřítka oblasti buněk tak, aby odpovídala požadované velikosti OLE rámce, můžete zabránit nechtěné změně velikosti.

**Kterou metodu změny měřítka mám použít, změnu měřítka OLE rámce nebo změnu měřítka oblasti buněk?**  
Zvolte **změnu měřítka OLE rámce**, pokud chcete zachovat původní velikosti řádků a sloupců v Excelu. Zvolte **změnu měřítka oblasti buněk**, pokud chcete mít v prezentaci pevnou velikost OLE rámce.

**Budou tato řešení fungovat, pokud je moje prezentace založena na šabloně?**  
Ano. Obě řešení fungují pro prezentace vytvořené ze šablon i od nuly.

**Existuje limit velikosti OLE rámce při použití těchto metod?**  
Ne. OLE objekt můžete nastavit na libovolnou velikost, pokud nastavíte správné měřítko.

**Existuje způsob, jak se vyhnout textu „EMBEDDED OLE OBJECT“ v PowerPointu?**  
Ano. Pořízením snímku cílové oblasti buněk v Excelu a nastavením tohoto snímku jako placeholder obrázku OLE rámce můžete zobrazit vlastní náhled místo výchozího placeholderu.

## **Související články**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/cs/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/cs/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)