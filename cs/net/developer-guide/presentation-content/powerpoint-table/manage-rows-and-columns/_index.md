---
title: Správa řádků a sloupců v tabulkách PowerPointu v .NET
linktitle: Řádky a sloupce
type: docs
weight: 20
url: /cs/net/manage-rows-and-columns/
keywords:
- řádek tabulky
- sloupec tabulky
- první řádek
- záhlaví tabulky
- klonovat řádek
- klonovat sloupec
- kopírovat řádek
- kopírovat sloupec
- odstranit řádek
- odstranit sloupec
- formátování textu řádku
- formátování textu sloupce
- styl tabulky
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Spravujte řádky a sloupce tabulky v PowerPointu pomocí Aspose.Slides pro .NET a urychlete úpravy prezentací a aktualizace dat."
---
## **Úvod**

Aby vám umožnil spravovat řádky a sloupce tabulky v prezentaci PowerPoint, Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/cs/net/aspose.slides/table/) , rozhraní [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) a mnoho dalších typů. 

## **Nastavit první řádek jako záhlaví**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) a načtěte prezentaci. 
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Vytvořte objekt [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) a přiřaďte mu hodnotu null. 
4. Projděte všechny objekty [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/) a vyhledejte požadovanou tabulku. 
5. Nastavte první řádek tabulky jako její záhlaví. 

Tento C# kód ukazuje, jak nastavit první řádek tabulky jako její záhlaví:

```c#
// Vytvoří instanci třídy Presentation
Presentation pres = new Presentation("table.pptx");

// Přistoupí k prvnímu snímku
ISlide sld = pres.Slides[0];

// Inicializuje nulovou TableEx
ITable tbl = null;

// Prochází tvary a nastaví odkaz na tabulku
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Nastaví první řádek tabulky jako záhlaví
tbl.FirstRow = true;

// Uloží prezentaci na disk
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```


## **Klonovat řádek nebo sloupec tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) a načtěte prezentaci, 
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Definujte pole `columnWidth`. 
4. Definujte pole `rowHeight`. 
5. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) na snímek pomocí metody [AddTable](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addtable/). 
6. Naklonujte řádek tabulky. 
7. Naklonujte sloupec tabulky. 
8. Uložte upravenou prezentaci. 

Tento C# kód ukazuje, jak klonovat řádek nebo sloupec tabulky v PowerPointu:

```c#
 // Vytvoří instanci třídy Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Přistoupí k prvnímu snímku
    ISlide sld = presentation.Slides[0];

    // Definuje sloupce s šířkami a řádky s výškami
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Přidá tvar tabulky na snímek
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Přidá text do buňky řádku 1, sloupce 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Přidá text do buňky řádku 1, sloupce 2
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Zklonuje řádek 1 na konec tabulky
    table.Rows.AddClone(table.Rows[0], false);

    // Přidá text do buňky řádku 2, sloupce 1
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Přidá text do buňky řádku 2, sloupce 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Zklonuje řádek 2 jako čtvrtý řádek tabulky
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Zklonuje první sloupec na konec
    table.Columns.AddClone(table.Columns[0], false);

    // Zklonuje druhý sloupec na index čtvrtého sloupce
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Uloží prezentaci na disk 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Odstranit řádek nebo sloupec z tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) a načtěte prezentaci, 
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Definujte pole `columnWidth`. 
4. Definujte pole `rowHeight`. 
5. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) na snímek pomocí metody [AddTable](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addtable/). 
6. Odeberte řádek tabulky. 
7. Odeberte sloupec tabulky. 
8. Uložte upravenou prezentaci. 

Tento C# kód ukazuje, jak odstranit řádek nebo sloupec z tabulky:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Nastavit formátování textu na úrovni řádku tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) a načtěte prezentaci, 
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Získejte požadovaný objekt [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) ze snímku. 
4. Nastavte buňkám v prvním řádku [FontHeight](https://reference.aspose.com/slides/cs/net/aspose.slides/baseportionformat/fontheight/). 
5. Nastavte buňkám v prvním řádku [Alignment](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/alignment/) a [MarginRight](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/marginright/). 
6. Nastavte buňkám ve druhém řádku [TextVerticalType](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat/textverticaltype/). 
7. Uložte upravenou prezentaci. 

Tento C# kód demonstrativně provádí operaci.

```c#
// Vytvoří instanci třídy Presentation
Presentation presentation = new Presentation();
           
           ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Předpokládejme, že první tvar na prvním snímku je tabulka

// Nastaví výšku písma buněk v prvním řádku
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Nastaví zarovnání textu a pravý okraj buněk v prvním řádku
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Nastaví svislý typ textu buněk ve druhém řádku
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Uloží prezentaci na disk
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Nastavit formátování textu na úrovni sloupce tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) a načtěte prezentaci, 
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Získejte požadovaný objekt [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) ze snímku. 
4. Nastavte buňkám v prvním sloupci [FontHeight](https://reference.aspose.com/slides/cs/net/aspose.slides/baseportionformat/fontheight/). 
5. Nastavte buňkám v prvním sloupci [Alignment](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/alignment/) a [MarginRight](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/marginright/). 
6. Nastavte buňkám ve druhém sloupci [TextVerticalType](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat/textverticaltype/). 
7. Uložte upravenou prezentaci. 

Tento C# kód demonstrativně provádí operaci: 

```c#
// Vytvoří instanci třídy Presentation
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Předpokládejme, že první tvar na prvním snímku je tabulka

// Nastaví výšku písma buněk v prvním sloupci
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Nastaví zarovnání textu a pravý okraj buněk v prvním sloupci jedním voláním
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Nastaví svislý typ textu buněk ve druhém sloupci
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Uloží prezentaci na disk
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

## **Získat vlastnosti stylu tabulky**

Aspose.Slides vám umožňuje získat vlastnosti stylu tabulky, abyste je mohli použít u jiné tabulky nebo kdekoliv jinde. Tento C# kód ukazuje, jak získat vlastnosti stylu z předdefinovaného stylu tabulky: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // změnit výchozí přednastavený motiv stylu 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Mohu použít motivy/styly PowerPoint na již vytvořenou tabulku?**

Ano. Tabulka dědí motiv snímku/podkladu/mistra a stále můžete přepsat výplně, okraje a barvy textu nad tímto motivem.

**Mohu řadit řádky tabulky jako v Excelu?**

Ne, tabulky Aspose.Slides nemají vestavěné řazení ani filtry. Nejprve seřaďte data v paměti a poté znovu naplňte řádky tabulky v tomto pořadí.

**Mohu mít proužkované (pruhované) sloupce při zachování vlastních barev v konkrétních buňkách?**

Ano. Zapněte proužkované sloupce a poté přepište konkrétní buňky místním formátováním; formátování na úrovni buňky má přednost před stylem tabulky.