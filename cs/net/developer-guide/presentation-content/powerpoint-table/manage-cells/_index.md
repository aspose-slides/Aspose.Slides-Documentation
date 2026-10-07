---
title: Správa buněk tabulky v prezentacích v .NET
linktitle: Spravovat buňky
type: docs
weight: 30
url: /cs/net/manage-cells/
keywords:
- buňka tabulky
- sloučit buňky
- odstranit okraj
- rozdělit buňku
- obrázek v buňce
- barva pozadí
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Spravujte buňky tabulky v PowerPointu v C#: identifikujte sloučené buňky, odstraňujte okraje, rozdělte buňky a nastavte barvy pozadí a obrázky pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Aspose.Slides vám umožňuje přistupovat k buňkám tabulek a upravovat je v prezentacích PowerPoint. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit ohraničení buněk, pracovat s číslováním buněk po sloučení nebo rozdělení, změnit barvu pozadí buňky a přidat obrázek do buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buňky pomocí vlastností buňky a uložit upravenou prezentaci jako soubor PPTX.

Aspose.Slides používá nulové indexy pro přístup k buňkám tabulky v pořadí `(sloupec, řádek)`.

## **Identifikace sloučené buňky tabulky**

Příklad otevře existující prezentaci a přistoupí k prvnímu tvaru na prvním snímku jako k tabulce. Předpokládá, že snímek a tvar existují a že tvar je tabulka. Poté prochází všechny řádky a sloupce a používá [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) k identifikaci buněk ve sloučených oblastech. Pro každou shodu vytiskne souřadnice buňky v pořadí `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), a počáteční souřadnice oblasti, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) a [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **Odstranění ohraničení buněk tabulky**

Vytvořte [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) a přidejte tabulku na první snímek pomocí [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Šířky sloupců, výšky řádků a pozice tabulky jsou zadány v bodech. Příklad nastaví všechna čtyři ohraničení buněk na [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), čímž je učiní neviditelnými.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Sloučení buněk tabulky**

Použijte [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) k sloučení obdélníkové oblasti buněk tabulky do jedné buňky. Určete buňky v levém horním a pravém dolním rohu oblasti. Poslední argument určuje, zda sloučení může zahrnovat buňky mimo zadaný rozsah; `false` udrží sloučení uvnitř tohoto rozsahu.

Příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů a následně sloučí čtyři centrální buňky od `(1, 1)` po `(2, 2)`. Výsledná buňka zabírá dva sloupce a dva řádky, zatímco podkladová mřížka tabulky si zachová čtyři sloupce a čtyři řádky. Pro přístup k obsahu nebo formátování sloučené buňky použijte její levý horní pozici: `table[1, 1]` v tomto příkladu. Ostatní pozice ve sloučeném rozsahu zůstávají součástí mřížky tabulky, takže indexy buněk mimo rozsah se nemění.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **Rozdělení buněk tabulky**

Sloučení buněk v předchozím příkladu zachovává mřížku tabulky. Rozdělení buňky může zavést nový sloupec mřížky a změnit indexy sloupců buněk napravo. Aspose.Slides se řídí modelem mřížky tabulky PowerPointu.

Tento příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů a zavolá [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) na buňce `(1, 1)`. Polovina šířky buňky (70 bodů) je předána pro vytvoření dvou buněk stejné šířky.

Po tomto rozdělení jsou dvě poloviny přístupné jako `table[1, 1]` a `table[2, 1]`. Mřížka tabulky nyní má pět sloupců: buňky původně ve sloupcích 2 a 3 se přesunou na sloupce 3 a 4. Indexy řádků zůstávají beze změny. Používejte tyto aktualizované indexy sloupců při přístupu k buňkám po rozdělení.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **Rozdělení sloučených buněk podle řádku nebo sloupce**

Pro přípravu sloučených šablonových buněk na naplnění daty použijte [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) k rozdělení podél existující hranice řádku nebo [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) k rozdělení podél hranice sloupce.

Argument `index` počítá řádky v horní části nebo sloupce v levé části rozdělení; je relativní k sloučené oblasti:

- Rozdělení řádku: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Rozdělení sloupce: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Příklad předpokládá, že prezentace má tabulku jako první tvar na prvním snímku, přičemž buňky `(1, 2)` a `(1, 3)` jsou sloučeny vertikálně. Začíná od spodní pozice, používá [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) a [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) k nalezení počátku a kontroluje oba rozsahy. `SplitByRowSpan(1)` pak oddělí řádky 2 a 3 pro názvy produktů. Pro vodorovné sloučení dvou sloupců použijte místo toho `SplitByColSpan(1)`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // Získat výsledné buňky z tabulky po rozdělení.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

Mřížka tabulky a okolní indexy buněk zůstávají beze změny. Výsledné buňky získáte podle jejich souřadnic; zde mají obě rozsah 1 a [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) vrací `False`. Větší oblasti mohou po jednom rozdělení zůstávat částečně sloučené.

Původní text a jeho formátování zůstávají v horní (nebo levé) buňce; nová buňka je prázdná, ale dědí formátování buňky, jako je výplň, ohraničení a okraje. Po rozdělení buňky naplňte textem a nastavením požadovaného formátování textu výslovně.

Uložená prezentace obsahuje samostatné buňky „Product A“ a „Product B“ s zachovaným formátováním šablony. Viz [Reference API buňky](https://reference.aspose.com/slides/net/aspose.slides/cell/) pro podrobnosti.

## **Změna barvy pozadí buňky tabulky**

Tento příklad vytvoří tabulku se sloupci 150 bodů a řádky 50 bodů. Nastaví [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) na pevnou výplň a [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) na červenou pro buňku `(2, 3)`, ve třetím sloupci a čtvrtém řádku.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **Přidání obrázku do buňky tabulky**

Umístěte vstupní obrázek do pracovního adresáře před spuštěním tohoto příkladu. Načte obrázek pomocí [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) a přidá jej do kolekce obrázků prezentace pomocí [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Pak přiřadí obrázek k výplni obrázkem buňky `(0, 0)`, první buňky v tabulce.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) roztáhne obrázek tak, aby vyplnil buňku, což může změnit její poměr stran. Šířky sloupců a výšky řádků jsou v bodech. Načtený obrázek je automaticky uvolněn pomocí příkazu `using`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **Často kladené otázky**

**Mohu nastavit různé tloušťky čar a styly pro různé strany jedné buňky?**

Ano. Ohraničení [horní](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[dolní](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[levý](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[pravý](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) mají samostatné vlastnosti, takže tloušťka a styl každé strany se mohou lišit.

**Co se stane s obrázkem, pokud po nastavení obrázku jako pozadí buňky změníme velikost sloupce/řádku?**

Chování závisí na [režimu výplně](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Při roztahování se obrázek přizpůsobí nové buňce; při dlaždicování se dlaždice přepočítají.

**Mohu přiřadit hyperlinky k veškerému obsahu buňky?**

[hyperlinky](/slides/cs/net/manage-hyperlinks/) jsou nastaveny na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/tvaru. V praxi přiřadíte odkaz k části nebo k veškerému textu v buňce.

**Mohu nastavit různé písma v jedné buňce?**

Ano. Textový rámec buňky podporuje [části](https://reference.aspose.com/slides/net/aspose.slides/portion/) (běhy) s nezávislým formátováním — rodina písma, styl, velikost a barva.