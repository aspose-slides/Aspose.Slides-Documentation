---
title: Pracovní řešení pro změnu velikosti listu
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
description: "Opravte změnu velikosti OLE listu Excel v prezentacích: dva způsoby, jak zachovat konzistentní rámečky objektů – měřítko rámce nebo listu – napříč formáty PPT a PPTX."
---
{{% alert color="info" %}} 

Bylo zaznamenáno, že listy Excelu vložené jako OLE objekty v prezentaci PowerPoint pomocí komponent Aspose jsou po první aktivaci přepočítány na neidentifikovanou měřítko. Toto chování vytváří patrný vizuální rozdíl v prezentaci mezi stavem OLE objektu před a po aktivaci. Problém jsme podrobně prozkoumali a poskytli řešení, které je popsáno v tomto článku.

{{% /alert %}} 

## **Background**

V článku [Manage OLE](/slides/cs/net/manage-ole/) jsme vysvětlili, jak pomocí Aspose.Slides for .NET přidat OLE rámeček do prezentace PowerPoint. Pro řešení [object preview issue](/slides/cs/net/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek vybrané oblasti listu k OLE rámečku. V výstupní prezentaci, když dvakrát kliknete na OLE rámeček zobrazující obrázek listu, aktivuje se sešit Excelu. Uživatelé mohou provádět libovolné úpravy skutečného sešitu a poté se vrátit na snímek kliknutím mimo aktivovaný sešit Excelu. Velikost OLE rámečku se změní, když se uživatel vrátí na snímek. Faktor změny velikosti se bude lišit v závislosti na velikosti OLE rámečku a vloženém sešitu Excelu. 

## **Cause of Resizing**

Protože má sešit Excelu vlastní velikost okna, snaží se po první aktivaci zachovat původní rozměry. OLE rámeček má naopak svou vlastní velikost. Podle Microsoftu, když je sešit Excelu aktivován, Excel a PowerPoint si navzájem dohodnou velikost tak, aby zachovaly správné proporce jako součást procesu vkládání. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excelu a velikostí a polohou OLE rámečku.

## **Working Solution**

Existují dva možná řešení, jak předejít efektu změny velikosti.

- Změřítko velikosti OLE rámečku v prezentaci PowerPoint tak, aby odpovídalo výšce a šířce požadovaného počtu řádků a sloupců v OLE rámečku.
- Zachovat konstantní velikost OLE rámečku a měřítko velikosti zapojených řádků a sloupců tak, aby se vešly do vybrané velikosti OLE rámečku.

### **Scale the OLE Frame Size**

V tomto přístupu se naučíme, jak nastavit velikost OLE rámečku vloženého sešitu Excel tak, aby odpovídala kumulativní velikosti zapojených řádků a sloupců v listu Excelu.

Předpokládejme, že máme šablonu listu Excel a chceme ji přidat do prezentace jako OLE rámeček. V tomto scénáři bude velikost OLE objektu nejprve vypočítána na základě kumulativních výšek řádků a šířek sloupců zapojených do sešitu. Pak nastavíme velikost OLE rámečku na tuto vypočítanou hodnotu. Abychom v PowerPointu odstranili červenou zprávu „EMBEDDED OLE OBJECT“ u OLE rámečku, také zachytíme obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámečku.

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

// Vytvořte OLE objektový rámec.
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

### **Scale the Cell Range Size**

V tomto přístupu se naučíme, jak měřítkovat výšky zapojených řádků a šířku zapojených sloupců tak, aby odpovídaly vlastní velikosti OLE rámečku.

Předpokládejme, že máme šablonu listu Excel a chceme ji přidat do prezentace jako OLE rámeček. V tomto scénáři nastavíme velikost OLE rámečku a měřítko velikosti řádků a sloupců, které se podílejí na oblasti OLE rámečku. Poté uložíme sešit do proudu, aby se změny aplikovaly, a převedeme jej na pole bajtů pro přidání do OLE rámečku. Abychom v PowerPointu odstranili červenou zprávu „EMBEDDED OLE OBJECT“ u OLE rámečku, také zachytíme obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámečku.

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

// Změřte oblast buněk tak, aby odpovídala velikosti rámce.
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

// Vytvořte OLE objektový rámec.
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

## **Conclusion**

{{% alert color="info" %}}

Existují dva přístupy k opravení problému změny velikosti listu. Výběr vhodného přístupu závisí na konkrétních požadavcích a použití. Oba přístupy fungují stejným způsobem, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Navíc v tomto řešení neexistuje žádný limit velikosti OLE objektu.

{{% /alert %}}

## **FAQ**

### Proč se vložený list Excelu po první aktivaci v PowerPointu zvětší nebo zmenší?
Stane se to, protože Excel se snaží zachovat původní velikost okna při aktivaci, zatímco OLE rámeček v PowerPointu má své vlastní rozměry. PowerPoint a Excel si dohodnou velikost tak, aby zachovaly poměr stran, což může způsobit změnu velikosti.

### Je možné zcela zabránit tomuto problému se změnou velikosti?
Ano. Měřítkováním OLE rámečku tak, aby odpovídal velikosti oblasti buněk Excelu, nebo měřítkováním oblasti buněk tak, aby odpovídala požadované velikosti OLE rámečku, můžete zabránit nechtěné změně velikosti.

### Kterou metodu měřítkování mám použít, měřítkování OLE rámečku nebo měřítkování oblasti buněk?
Zvolte **OLE frame scaling**, pokud chcete zachovat původní velikosti řádků a sloupců v Excelu. Zvolte **cell range scaling**, pokud chcete mít v prezentaci pevnou velikost OLE rámečku.

### Budou tato řešení fungovat, pokud je moje prezentace založena na šabloně?
Ano. Obě řešení fungují pro prezentace vytvořené ze šablon i od nuly.

### Existuje limit velikosti OLE rámečku při použití těchto metod?
Ne. OLE objekt můžete nastavit na libovolnou velikost, pokud nastavíte měřítko odpovídajícím způsobem.

### Je nějaký způsob, jak se vyhnout textu „EMBEDDED OLE OBJECT“ v PowerPointu?
Ano. Pořízením snímku cílové oblasti buněk v Excelu a nastavením tohoto snímku jako zástupného obrázku OLE rámečku můžete zobrazit vlastní náhled místo výchozího placeholderu.

## **Related Articles**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/cs/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/cs/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)