---
title: Správa tabulek v prezentacích v .NET
linktitle: Spravovat tabulku
type: docs
weight: 10
url: /cs/net/manage-table/
keywords:
- přidat tabulku
- vytvořit tabulku
- přístup k tabulce
- poměr stran
- zarovnat text
- formátování textu
- styl tabulky
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvářejte a upravujte tabulky v snímcích PowerPoint pomocí Aspose.Slides pro .NET. Objevte jednoduché příklady C# kódu, které zjednoduší vaše pracovní postupy s tabulkami."
---
## **Úvod**

Tabulka v PowerPointu je efektivní způsob, jak zobrazit a znázornit informace. Informace v mřížce buněk (uspořádaných v řádcích a sloupcích) jsou přehledné a snadno pochopitelné.

Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/cs/net/aspose.slides/table/) , rozhraní [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) , třídu [Cell](https://reference.aspose.com/slides/cs/net/aspose.slides/cell/) , rozhraní [ICell](https://reference.aspose.com/slides/cs/net/aspose.slides/icell/) a další typy, které vám umožní vytvářet, aktualizovat a spravovat tabulky ve všech druzích prezentací. 

## **Vytvoření tabulky od nuly**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Definujte pole `columnWidth`.
4. Definujte pole `rowHeight`.
5. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) na snímek pomocí metody [AddTable](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addtable/) .
6. Procházejte každou [ICell](https://reference.aspose.com/slides/cs/net/aspose.slides/icell/) , abyste použili formátování na horní, spodní, pravý a levý okraj.
7. Sloučte první dvě buňky v první řadě tabulky. 
8. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/textframe/) buňky [ICell](https://reference.aspose.com/slides/cs/net/aspose.slides/icell/) .
9. Přidejte text do [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/textframe/) .
10. Uložte upravenou prezentaci.

```c#
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();

// Přistupuje k prvnímu snímku
ISlide sld = pres.Slides[0];

// Definuje sloupce s šířkami a řádky s výškami
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Přidá tvar tabulky na snímek
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Nastaví formát okrajů pro každou buňku
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
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

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

Tento C# kód vám ukazuje, jak zadat číslování buněk v tabulce:

```c#
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
using (Presentation pres = new Presentation())
{

    // Přistupuje k prvnímu snímku
    ISlide sld = pres.Slides[0];

    // Definuje sloupce s šířkami a řádky s výškami
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Přidá tvar tabulky na snímek
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

    // Uloží prezentaci na disk
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Přístup k existující tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
2. Získejte referenci na snímek obsahující tabulku pomocí jeho indexu. 
3. Vytvořte objekt [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) a nastavte jej na null.
4. Procházejte všechny objekty [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/) , dokud nenajdete tabulku.

   Pokud se domníváte, že snímek, se kterým pracujete, obsahuje jedinou tabulku, můžete jednoduše zkontrolovat všechny tvary, které obsahuje. Když je tvar identifikován jako tabulka, můžete jej převést na objekt [Table](https://reference.aspose.com/slides/cs/net/aspose.slides/table/) . Pokud však snímek obsahuje několik tabulek, je výhodnější vyhledat požadovanou tabulku pomocí jejího [AlternativeText](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/alternativetext/) .
5. Použijte objekt [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) , abyste pracovali s tabulkou. V následujícím příkladu jsme přidali nový řádek do tabulky.
6. Uložte upravenou prezentaci.

```c#
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Přistupuje k prvnímu snímku
    ISlide sld = pres.Slides[0];

    // Inicializuje null TableEx
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

## **Zarovnání textu v tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) na snímek. 
4. Získejte přístup k objektu [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) z tabulky. 
5. Získejte přístup k [IParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/) v [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) .
6. Zarovnejte text vertikálně.
7. Uložte upravenou prezentaci.

```c#
// Creates an instance of the Presentation class
Presentation presentation = new Presentation();

// Gets the first slide 
ISlide slide = presentation.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Adds the table shape to the slide
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Accesses the text frame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Creates the Paragraph object for the text frame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Creates the Portion object for paragraph
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Aligns the text vertically
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Saves the presentation to disk
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Nastavení formátování textu na úrovni tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) .
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Získejte přístup k objektu [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) ze snímku.
4. Nastavte [FontHeight](https://reference.aspose.com/slides/cs/net/aspose.slides/baseportionformat/fontheight/) pro text. 
5. Nastavte [Alignment](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/alignment/) a [MarginRight](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/marginright/) . 
6. Nastavte [TextVerticalType](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat/textverticaltype/) .
7. Uložte upravenou prezentaci. 

```c#
 // Creates an instance of the Presentation class
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Předpokládejme, že první tvar na prvním snímku je tabulka

 // Sets the table cells' font height
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

 // Sets the table cells' text alignment and right margin in one call
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

 // Sets the table cells' text vertical type
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Získání vlastností stylu tabulky**

Aspose.Slides vám umožňuje získat vlastnosti stylu tabulky, abyste je mohli použít pro další tabulku nebo jinde. Tento C# kód vám ukazuje, jak získat vlastnosti stylu z předdefinovaného stylu tabulky: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // změnit výchozí přednastavený styl
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Uzamčení poměru stran tabulky**

Poměr stran geometrického tvaru je poměr jeho velikostí v různých rozměrech. Aspose.Slides poskytuje vlastnost `AspectRatioLocked`, která vám umožní uzamknout nastavení poměru stran pro tabulky a další tvary. 

Tento C# kód vám ukazuje, jak uzamknout poměr stran pro tabulku:

```c#
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

**Mohu povolit směr čtení zprava doleva (RTL) pro celou tabulku i text v jejích buňkách?**

Ano. Tabulka má vlastnost [RightToLeft](https://reference.aspose.com/slides/cs/net/aspose.slides/table/righttoleft/) , a odstavce mají [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraphformat/righttoleft/) . Použití obou zajišťuje správné RTL pořadí a vykreslení uvnitř buněk.

**Jak mohu zabránit uživatelům v přesouvání nebo změně velikosti tabulky v konečném souboru?**

Použijte [shape locks](/slides/cs/net/applying-protection-to-presentation/), abyste zakázali přesouvání, změnu velikosti, výběr a další. Tyto zámky se vztahují také na tabulky.

**Je podporováno vložení obrázku uvnitř buňky jako pozadí?**

Ano. Můžete nastavit [picture fill](https://reference.aspose.com/slides/cs/net/aspose.slides/picturefillformat/) , který vyplní buňku obrázkem; obrázek pokryje oblast buňky podle zvoleného režimu (roztažení nebo dlaždicování).