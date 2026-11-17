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
description: "Spravujte buňky tabulky PowerPoint v C#: identifikujte sloučené buňky, odstraňte okraje, rozdělte buňky a nastavte barvy pozadí a obrázky pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Aspose.Slides vám umožňuje přistupovat k buňkám tabulky v prezentacích PowerPoint a upravovat je. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit okraje buněk, pracovat s číslováním buněk po sloučení nebo rozdělení buněk, změnit barvu pozadí buňky a přidat obrázek do buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buňky prostřednictvím vlastností buňky a uložit upravenou prezentaci jako soubor PPTX.

Aspose.Slides používá nulové indexy pro přístup k buňkám tabulky v pořadí `(sloupec, řádek)`.

## **Identifikace sloučené buňky tabulky**

Příklad otevře existující prezentaci a přistoupí k prvnímu tvaru na první snímku jako k tabulce. Předpokládá, že snímek a tvar existují a že tvar je tabulkou. Poté prochází všechny řádky a sloupce a používá [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) k identifikaci buněk ve sloučených oblastech. Pro každý výskyt vytiskne souřadnice buňky v pořadí `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), a počáteční souřadnice oblasti, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) a [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

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

## **Odstranit okraje buňky tabulky**

Vytvořte [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) a přidejte tabulku do jeho první snímku pomocí [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Šířky sloupců, výšky řádků a pozice tabulky jsou zadány v bodech. Příklad nastaví všechny čtyři okraje buňky na [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), čímž je učiní neviditelnými.

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

## **Přidat úhlopříčné okraje buňky**

Použijte [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) k vykreslení čáry od levého horního rohu k pravému dolnímu a [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) k vykreslení čáry od levého dolního rohu k pravému hornímu. Úhlopříčka může označit záhlaví rohu; obě úhlopříčky mohou vytvořit X pro označení buňky jako neaplikovatelné.

Každá úhlopříčka je [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/). V jeho [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) nastavte [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) na [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) a vyberte [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/). Nastavte [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) čáry v bodech.

Příklad vytvoří tři buňky v jednom řádku: červenou úhlopříčku směrem dolů, modrou úhlopříčku směrem nahoru a obě úhlopříčky. Horní, dolní, levý a pravý okraj buňky ponechá nezměněny.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

Úhlopříčka je vlastnost formátování, nikoli rozdělení buňky. Každá buňka zachovává jediný [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/); oblasti na obou stranách úhlopříčky nelze upravovat samostatně.

Uložená tabulka vykreslená v Microsoft PowerPoint:

![Tři buňky tabulky zobrazující červenou úhlopříčku z levého horního rohu do pravého dolního, modrou úhlopříčku z levého dolního rohu do pravého horního a obě úhlopříčky tvořící X.](diagonal-cell-borders.png)

*Zleva doprava: úhlopříčka dolů (červená, 3 pt), úhlopříčka nahoru (modrá, 5 pt) a obě úhlopříčky.*

## **Sloučit buňky tabulky**

Použijte [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) k sloučení obdélníkového rozsahu buněk tabulky do jedné buňky. Určete buňky v levém horním a pravém dolním rohu rozsahu. Poslední argument určuje, zda sloučení může zahrnovat buňky mimo zadaný rozsah; `false` udržuje sloučení v rámci tohoto rozsahu.

Příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů, poté sloučí čtyři střední buňky od `(1, 1)` do `(2, 2)`. Výsledná buňka zabírá dva sloupce a dva řádky, zatímco základní mřížka tabulky si ponechává čtyři sloupce a čtyři řádky. Pro přístup k obsahu nebo formátování sloučené buňky použijte její pozici v levém horním rohu: `table[1, 1]` v tomto příkladu. Ostatní pozice ve sloučeném rozsahu zůstávají součástí mřížky tabulky, takže indexy buněk mimo rozsah se nemění.

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

## **Rozdělit buňky tabulky**

Sloučení buněk v předchozím příkladu zachovává mřížku tabulky. Rozdělení buňky může zavést nový sloupec v mřížce a změnit indexy sloupců buněk napravo. Aspose.Slides se řídí modelem mřížky tabulky PowerPointu.

Příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů a zavolá [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) na buňce `(1, 1)`. Polovina šířky buňky 70 bodů se použije k vytvoření dvou buněk stejné šířky.

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

### **Rozdělit sloučené buňky podle řádkového nebo sloupcového rozsahu**

Aby bylo možné připravit sloučené buňky šablony pro doplnění dat, použijte [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) k rozdělení podél existující hranice řádku nebo [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) k rozdělení podél hranice sloupce.

Argument `index` počítá řádky v horní části nebo sloupce v levé části rozdělení; je relativní k sloučené oblasti:

- Rozdělení řádku: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Rozdělení sloupce: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Příklad předpokládá, že prezentace má tabulku jako první tvar na prvním snímku, přičemž buňky `(1, 2)` a `(1, 3)` jsou sloučeny vertikálně. Začínaje od spodní pozice, používá [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) a [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) k určení počátku a kontroluje oba rozsahy. `SplitByRowSpan(1)` pak oddělí řádky 2 a 3 pro názvy produktů. Pro horizontální sloučení dvou sloupců použijte místo toho `SplitByColSpan(1)`.

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

    // Získejte výsledné buňky z tabulky po rozdělení.
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

Mřížka tabulky a okolní indexy buněk zůstávají nezměněny. Získejte výsledné buňky podle jejich souřadnic; zde mají obě rozsah 1 a [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) vypíše `False`. Větší oblasti mohou po jednom rozdělení zůstat částečně sloučené.

Původní text a jeho formátování zůstávají v horní (nebo levé) buňce; nová buňka je prázdná, ale dědí formátování buňky, jako je výplň, okraje a okraje. Po rozdělení buňky vyplňte a nastavte jakékoli požadované formátování textu explicitně.

Uložená prezentace obsahuje samostatné buňky „Product A“ a „Product B“ s zachovaným formátováním buňky ze šablony. Viz [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) for details.

<!-- visual-explanation:manage-cells:start -->
[![Sloučená buňka ve sloupci 1, řádky 2 a 3 se rozdělí na Product A a Product B se stejnými indexy mřížky.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*Rozdělení podle řádkového rozsahu používá existující hranici. Product A a Product B zabírají (1, 2) a (1, 3) odpovídajícím způsobem.*
<!-- visual-explanation:manage-cells:end -->

### **Rozdělit buňku na konkrétní výšku**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) přijímá výšku horní části v bodech. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) přijímá počet existujících řádků mřížky v horní části. Pro vycentrování 40‑bodové buňky ve pravém sloupci odečtěte 40 od skutečné výšky buňky a zbývající prostor rozdělte rovnoměrně nahoře i dole.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

První rozdělení přidá řádek do mřížky, zanechávajíc spodních 90 bodů na `[1, 1]`. Druhé rozdělení cílí na tuto buňku a přidá další řádek pod ní. Pravý sloupec nyní obsahuje `[1, 0]` na 50 bodů (`margin`), `[1, 1]` na 40 bodů a `[1, 2]` na 50 bodů (`margin`). Levá buňka zabírá všechny tři řádky při původní výšce 140 bodů.

![Levá buňka zabírá celou výšku tabulky vedle tří buněk se středovým textem uprostřed.](split-by-height.png)

## **Změnit barvu pozadí buňky tabulky**

Příklad vytvoří tabulku se sloupci o šířce 150 bodů a řádky o výšce 50 bodů. Nastaví [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) na pevnou a [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) na červenou pro buňku `(2, 3)`, ve třetím sloupci a čtvrtém řádku.

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

## **Přidat obrázek do buňky tabulky**

Umístěte vstupní obrázek do pracovního adresáře před spuštěním tohoto příkladu. Načte obrázek pomocí [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) a přidá jej do kolekce obrázků prezentace pomocí [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Pak přiřadí obrázek k výplni obrázkem buňky `(0, 0)`, první buňky v tabulce.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) roztáhne obrázek tak, aby vyplnil buňku, což může změnit poměr stran. Šířky sloupců a výšky řádků jsou v bodech. Načtený obrázek je automaticky uvolněn díky použití příkazu using.

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

## **FAQ**

**Mohu nastavit různé tloušťky a styly čar pro různé strany jedné buňky?**

Ano. Okraje [horní](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[spodní](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[levý](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[pravý](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) mají samostatné vlastnosti, takže tloušťka a styl každé strany se mohou lišit.

**Co se stane s obrázkem, pokud po nastavení obrázku jako pozadí buňky změníme velikost sloupce/řádku?**

Chování závisí na [režim výplně](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Při roztahování se obrázek přizpůsobí nové buňce; při dlaždicování se dlaždice přepočítají.

**Mohu přiřadit hypertextový odkaz všemu obsahu buňky?**

[Hyperlinky](/slides/cs/net/manage-hyperlinks/) jsou nastaveny na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/shape. V praxi přiřadíte odkaz části nebo celému textu v buňce.

**Mohu nastavit různé písma v jedné buňky?**

Ano. Textový rámec buňky podporuje [části](https://reference.aspose.com/slides/net/aspose.slides/portion/) (runs) s nezávislým formátováním—rodina písma, styl, velikost a barva.