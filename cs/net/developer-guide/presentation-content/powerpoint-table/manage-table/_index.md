---
title: Správa tabulek prezentací v .NET
linktitle: Spravovat tabulku
type: docs
weight: 10
url: /cs/net/manage-table/
keywords:
- přidat tabulku
- vytvořit tabulku
- přístup k tabulce
- poměr stran
- zarovnání textu
- formátování textu
- styl tabulky
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvářejte a upravujte tabulky v PowerPoint slidech pomocí Aspose.Slides pro .NET. Objevte jednoduché ukázky kódu v C#, které zjednoduší vaše pracovní postupy s tabulkami."
---
## **Úvod**

Tabulka v PowerPointu je efektivní způsob, jak zobrazit a vyjádřit informace. Informace v mřížce buněk (uspořádaných do řádků a sloupců) jsou přehledné a snadno pochopitelné.

Aspose.Slides poskytuje třídu [Tabulka](https://reference.aspose.com/slides/cs/net/aspose.slides/table/) , rozhraní [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) , třídu [Buňka](https://reference.aspose.com/slides/cs/net/aspose.slides/cell/) , rozhraní [ICell](https://reference.aspose.com/slides/cs/net/aspose.slides/icell/) a další typy, které vám umožní vytvářet, aktualizovat a spravovat tabulky ve všech druzích prezentací. 

## **Vytvoření tabulky od nuly**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).  
2. Získejte referenci na snímek přes jeho index.  
3. Definujte pole `columnWidth`.  
4. Definujte pole `rowHeight`.  
5. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) na snímek pomocí metody [AddTable](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addtable/).  
6. Projděte každou [ICell](https://reference.aspose.com/slides/cs/net/aspose.slides/icell/) a aplikujte formátování na horní, dolní, pravý a levý okraj.  
7. Sloučte první dvě buňky prvního řádku tabulky.  
8. Získejte [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/textframe/) buňky [ICell](https://reference.aspose.com/slides/cs/net/aspose.slides/icell/).  
9. Přidejte do [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/textframe/) nějaký text.  
10. Uložte upravenou prezentaci.

Tento C# kód ukazuje, jak vytvořit tabulku v prezentaci:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();

// Accesses the first slide
ISlide sld = pres.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Adds a table shape to the slide
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Sets the border format for each cell
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// Sloučí buňky 1 a 2 v řádku 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[0][1], false);

// Přidá text do sloučené buňky
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Uloží prezentaci na disk
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Číslování ve standardní tabulce**

Ve standardní tabulce je číslování buněk jednoduché a začíná od nuly. První buňka v tabulce má index 0,0 (sloupec 0, řádek 0). 

Například buňky v tabulce se 4 sloupci a 4 řádky jsou číslovány takto:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Tento C# kód vytvoří výše číslovanou standardní tabulku 4 × 4 a nastaví formát okrajů pro každou její buňku:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
using (Presentation pres = new Presentation())
{

    // Získá první snímek
    ISlide sld = pres.Slides[0];

    // Definuje sloupce s šířkami a řádky s výškami
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Přidá tvar tabulky na snímek
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Nastaví formát okraje pro každou buňku
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

    // Uloží prezentaci na disk
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Přístup k existující tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).  

2. Získejte referenci na snímek obsahující tabulku přes jeho index.  

3. Vytvořte objekt [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) a přiřaďte mu hodnotu null.  

4. Procházejte všechny objekty [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/) až do nalezení tabulky.  

   Pokud předpokládáte, že snímek, se kterým pracujete, obsahuje jedinou tabulku, můžete jednoduše prověřit všechny tvary, které obsahuje. Když je tvar identifikován jako tabulka, můžete jej přetypovat na objekt [Tabulka](https://reference.aspose.com/slides/cs/net/aspose.slides/table/). Pokud však snímek obsahuje několik tabulek, je lepší hledat požadovanou tabulku pomocí jejího [AlternativeText](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/alternativetext/).  

5. Použijte objekt [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) k práci s tabulkou. V níže uvedeném příkladu jsme přidali nový řádek do tabulky.  

6. Uložte upravenou prezentaci.

Tento C# kód ukazuje, jak získat přístup k existující tabulce a s ní pracovat:

```c#
using Aspose.Slides;

// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Získá první snímek
    ISlide sld = pres.Slides[0];

    // Inicializuje nulovou proměnnou TableEx
    ITable tbl = null;

    // Prochází tvary a nastaví referenci na nalezenou tabulku
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Nastaví text pro první sloupec druhého řádku
    tbl[0, 1].TextFrame.Text = "New";

    // Uloží upravenou prezentaci na disk
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Najít buňku, která vlastní textový rámec**

Když obecný kód pro zpracování textu získá objekt [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) z tabulky, použijte vlastnost [ITextFrame.ParentCell](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/parentcell/) k získání vlastní [ICell](https://reference.aspose.com/slides/cs/net/aspose.slides/icell/). U textového rámce buňky tabulky je [ITextFrame.ParentCell](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/parentcell/) nastaven a [ITextFrame.ParentShape](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/parentshape/) je `null`, i když samotná tabulka je tvar.

Souřadnice buňky jsou dostupné přes jen ke čtení vlastnosti [ICell.FirstColumnIndex](https://reference.aspose.com/slides/cs/net/aspose.slides/icell/firstcolumnindex/) a [ICell.FirstRowIndex](https://reference.aspose.com/slides/cs/net/aspose.slides/icell/firstrowindex/). [ITextFrame.ParentCell](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/parentcell/) je také jen ke čtení: poskytuje navigaci k vlastníkovi, ale nemění vlastnictví. Vždy před použitím zkontrolujte, zda vrácená buňka není `null`.

Kompletní příklad, který identifikuje vlastníky buňky tabulky i tvaru, včetně tvarů spojených s uzly SmartArt, najdete v [Search and Replace Text](/slides/cs/net/search-and-replace-text/).

## **Zarovnání textu v tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).  
2. Získejte referenci na snímek přes jeho index.  
3. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) na snímek.  
4. Získejte objekt [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) z tabulky.  
5. Získejte [IParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/) z [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/).  
6. Zarovnejte text vertikálně.  
7. Uložte upravenou prezentaci.

Tento C# kód ukazuje, jak zarovnat text v tabulce:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvoří instanci třídy Presentation
Presentation presentation = new Presentation();

// Získá první snímek
ISlide slide = presentation.Slides[0];

// Definuje sloupce s šířkami a řádky s výškami
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Přidá tvar tabulky na snímek
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Získá textový rámec
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Vytvoří objekt Paragraph pro textový rámec
IParagraph paragraph = txtFrame.Paragraphs[0];

// Vytvoří objekt Portion pro odstavec
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Zarovná text vertikálně
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Uloží prezentaci na disk
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Nastavení formátování textu na úrovni tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).  
2. Získejte referenci na snímek přes jeho index.  
3. Získejte objekt [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) ze snímku.  
4. Nastavte [FontHeight](https://reference.aspose.com/slides/cs/net/aspose.slides/baseportionformat/fontheight/) pro text.  
5. Nastavte [Alignment](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/alignment/) a [MarginRight](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/marginright/).  
6. Nastavte [TextVerticalType](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat/textverticaltype/).  
7. Uložte upravenou prezentaci. 

Tento C# kód ukazuje, jak aplikovat požadované možnosti formátování na text v tabulce:

```c#
using Aspose.Slides;

// Vytvoří instanci třídy Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Předpokládejme, že první tvar na prvním snímku je tabulka

// Nastaví výšku písma buněk tabulky
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Nastaví zarovnání textu buněk tabulky a pravý okraj v jednom volání
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Nastaví vertikální typ textu buněk tabulky
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Získání vlastností stylu tabulky**

Aspose.Slides vám umožňuje načíst vlastnosti stylu tabulky, abyste je mohli použít pro jinou tabulku nebo jinde. Tento C# kód ukazuje, jak získat vlastnosti stylu z předdefinovaného stylu tabulky: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // změnit výchozí motiv předvolby stylu 

    // Získat předvolbu stylu tabulky.
    TableStylePreset stylePreset = table.StylePreset;
    Console.WriteLine($"Table style preset: {stylePreset}");

    // Použít získanou předvolbu stylu na jinou tabulku.
    ITable anotherTable = pres.Slides[0].Shapes.AddTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.StylePreset = stylePreset;

    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Uzamčení poměru stran tabulky**

Poměr stran geometrického tvaru je poměr jeho rozměrů v různých dimenzích. Aspose.Slides poskytuje vlastnost `AspectRatioLocked`, která vám umožní uzamknout nastavení poměru stran pro tabulky i další tvary. 

Tento C# kód ukazuje, jak uzamknout poměr stran tabulky:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // invertovat

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Mohu povolit čtení zprava doleva (RTL) pro celou tabulku a text v jejích buňkách?**

Ano. Tabulka má vlastnost [RightToLeft](https://reference.aspose.com/slides/cs/net/aspose.slides/table/righttoleft/), a odstavce mají [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraphformat/righttoleft/). Použití obou zajišťuje správné pořadí RTL a vykreslení uvnitř buněk.

**Jak mohu zabránit uživatelům přesouvat nebo měnit velikost tabulky v konečném souboru?**

Použijte [zámky tvarů](/slides/cs/net/applying-protection-to-presentation/), které zakážou přesouvání, změnu velikosti, výběr atd. Tyto zámky platí i pro tabulky.

**Je podporováno vložení obrázku do buňky jako pozadí?**

Ano. Můžete nastavit [picture fill](https://reference.aspose.com/slides/cs/net/aspose.slides/picturefillformat/) pro buňku; obrázek pokryje oblast buňky podle zvoleného režimu (roztahování nebo dlaždice).