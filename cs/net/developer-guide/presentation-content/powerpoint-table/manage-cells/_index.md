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
description: "Jednoduše spravujte buňky tabulky v PowerPointu pomocí Aspose.Slides pro .NET. Ovládněte rychlý přístup, úpravy a stylování buněk pro bezproblémovou automatizaci snímků."
---
## **Přehled**

Aspose.Slides umožňuje přistupovat k buňkám tabulky v prezentacích PowerPoint a upravovat je. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit okraje buněk, pracovat s číslováním buněk po sloučení nebo rozdělení buněk, změnit barvu pozadí buňky a přidat obrázek uvnitř buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buňky pomocí vlastností buňky a uložit upravenou prezentaci jako soubor PPTX.

## **Identifikace sloučené buňky tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte tabulku z první snímku. 
3. Procházejte řádky a sloupce tabulky a vyhledejte sloučené buňky.
4. Vypište zprávu, když jsou nalezeny sloučené buňky.

Tento C# kód ukazuje, jak v prezentaci identifikovat sloučené buňky tabulky:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // předpokládá se, že Slide#0.Shape#0 je tabulka
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **Odstranění okrajů buněk tabulky**
1. Vytvořte instanci třídy `Presentation`.
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Definujte pole sloupců s šířkou.
4. Definujte pole řádků s výškou.
5. Přidejte tabulku do snímku pomocí metody `AddTable`.
6. Projděte všechny buňky a vymažte horní, spodní, pravý a levý okraj.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak odstranit okraje z buněk tabulky:

```c#
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
using (Presentation pres = new Presentation())
{
   // Přistupuje k prvnímu snímku
    Slide sld = (Slide)pres.Slides[0];

    // Definuje sloupce s šířkami a řádky s výškami
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Přidá tvar tabulky do snímku
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Nastaví formát okrajů pro každou buňku
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // Zapíše soubor PPTX na disk
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Číslování ve sloučených buňkách**
Pokud sloučíme 2 páry buněk (1, 1) × (2, 1) a (1, 2) × (2, 2), vzniklá tabulka bude číslovaná. Tento C# kód demonstruje postup:

```c#
// Instanciace třídy Presentation, která představuje soubor PPTX
using (Presentation presentation = new Presentation())
{
    // Přistupuje k prvnímu snímku
    ISlide sld = presentation.Slides[0];

    // Definuje sloupce s šířkami a řádky s výškami
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Přidá tvar tabulky do snímku
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Nastaví formát okrajů pro každou buňku
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Sloučí buňky (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Sloučí buňky (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

Poté buňky dále sloučíme sloučením (1, 1) a (1, 2). Výsledkem je tabulka obsahující velkou sloučenou buňku uprostřed:

```c#
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
using (Presentation presentation = new Presentation())
{
    // Přistupuje k prvnímu snímku
    ISlide slide = presentation.Slides[0];

    // Definuje sloupce s šířkami a řádky s výškami
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Přidá tvar tabulky do snímku
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Nastaví formát okrajů pro každou buňku
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // Sloučí buňky (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Sloučí buňky (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Sloučí buňky (1, 2) x (2, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    //Zapíše soubor PPTX na disk
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **Číslování v rozdělené buňce**
V předchozích příkladech, když byly buňky tabulky sloučeny, číslování nebo číselný systém v ostatních buňkách se nezměnil. 

Tentokrát vezmeme běžnou tabulku (tabulku bez sloučených buněk) a pak se pokusíme rozdělit buňku (1,1) a získat zvláštní tabulku. Můžete si všimnout číslování této tabulky, které může působit podivně. Přesto je to způsob, jakým Microsoft PowerPoint čísluje buňky tabulky, a Aspose.Slides dělá totéž. 

Tento C# kód demonstruje popsaný postup:

```c#
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
using (Presentation presentation = new Presentation())
{
    // Přistupuje k prvnímu snímku
    ISlide slide = presentation.Slides[0];

    // Definuje sloupce s šířkami a řádky s výškami
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Přidá tvar tabulky do snímku
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Nastaví formát okrajů pro každou buňku
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // Sloučí buňky (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Sloučí buňky (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Rozdělí buňku (1, 1). 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    //Zapíše soubor PPTX na disk
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **Změna barvy pozadí buňky tabulky**

Tento C# kód ukazuje, jak změnit barvu pozadí buňky tabulky:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // vytvoří novou tabulku
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // nastaví barvu pozadí buňky 
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **Přidání obrázku do buňky tabulky**

1. Vytvořte instanci třídy `Presentation`.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Definujte pole sloupců s šířkou.
4. Definujte pole řádků s výškou.
5. Přidejte tabulku do snímku pomocí metody `AddTable`. 
6. Vytvořte objekt `Bitmap` pro uchování souboru obrázku.
7. Přidejte bitmapový obrázek do objektu `IPPImage`.
8. Nastavte `FillFormat` buňky tabulky na `Picture`.
9. Přidejte obrázek do první buňky tabulky.
10. Uložte upravenou prezentaci jako soubor PPTX

Tento C# kód ukazuje, jak při vytváření tabulky umístit obrázek do buňky tabulky:

```c#
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
using (Presentation presentation = new Presentation())
{
    // Přistupuje k prvnímu snímku
    ISlide slide = presentation.Slides[0];

    // Definuje sloupce s šířkami a řádky s výškami
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Přidá tvar tabulky do snímku
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Načte obrázek ze souboru a přidá jej do zdrojů prezentace
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Přidá obrázek do první buňky tabulky
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Uloží soubor PPTX na disk
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```

## **Časté dotazy**

**Mohu nastavit různé tloušťky čar a styly pro různé strany jedné buňky?**

Ano. Okraje [nahoře](https://reference.aspose.com/slides/cs/net/aspose.slides/cellformat/bordertop/), [dole](https://reference.aspose.com/slides/cs/net/aspose.slides/cellformat/borderbottom/), [vlevo](https://reference.aspose.com/slides/cs/net/aspose.slides/cellformat/borderleft/) a [vpravo](https://reference.aspose.com/slides/cs/net/aspose.slides/cellformat/borderright/) mají samostatné vlastnosti, takže tloušťka a styl každé strany se mohou lišit. To logicky vyplývá ze řízení okrajů po stranách buňky, jak je ukázáno v článku.

**Co se stane s obrázkem, pokud změním velikost sloupce/řádku po nastavení obrázku jako pozadí buňky?**

Chování závisí na [režimu výplně](https://reference.aspose.com/slides/cs/net/aspose.slides/picturefillmode/) (stretch/tile). Při roztažení se obrázek přizpůsobí nové buňce; při dlaždicování se dlaždice přepočítají. Článek zmiňuje režimy zobrazení obrázku v buňce.

**Mohu přiřadit hypertextový odkaz ke všemu obsahu buňky?**

[Hyperlinky](/slides/cs/net/manage-hyperlinks/) jsou nastaveny na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/tvaru. V praxi přiřadíte odkaz buď k části, nebo ke všemu textu v buňce.

**Mohu nastavit různé písma v jedné buňce?**

Ano. Textový rámec buňky podporuje [části](https://reference.aspose.com/slides/cs/net/aspose.slides/portion/) (běhy) s nezávislým formátováním – rodinu písma, styl, velikost a barvu.