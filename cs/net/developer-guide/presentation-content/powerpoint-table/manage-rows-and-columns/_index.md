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
- hlavička tabulky
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
description: "Spravujte řádky a sloupce tabulky v PowerPointu pomocí Aspose.Slides pro .NET a zrychlete úpravu prezentací a aktualizaci dat."
---
## **Úvod**

Aspose.Slides pro .NET vám umožňuje spravovat strukturu tabulky a formátování v prezentacích PowerPoint pomocí třídy [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) a rozhraní [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Můžete označit řádek hlavičky, klonovat nebo odstraňovat řádky a sloupce a aplikovat formátování textu na celý řádek nebo sloupec.

Tento článek vysvětluje tyto operace pomocí příkladů v C#. Také ukazuje, jak získat přednastavený styl tabulky, abyste jej mohli znovu použít. Indexy řádků a sloupců tabulky jsou založeny na nule.

## **Ovládání výšky řádku**

Použijte [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) k nastavení minimální výšky řádku v bodech. Jedná se o spodní mez, nikoli pevnou výšku. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) vrací skutečnou výšku a je pouze pro čtení. Přístup k řádku získáte přes [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/).

Příklad načte soubor [row-height-input.pptx](row-height-input.pptx), který má tabulku jako první tvar na první snímku. Jeho první řádek začíná ve výšce 70 bodů. Buňky používají text Arial o velikosti 18 bodů, zalamování a horní a dolní okraje po 6 bodech; delší text ve druhém sloupci se zalamuje do několika řádků. Příklad zvýší minimum na 100 bodů, poté jej sníží na 20 bodů, po každé změně vytiskne skutečnou výšku a uloží oba výsledky.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

U poskytnuté prezentace zvýšení minima přidá řádku místo. Jeho snížení toto dodatečné místo odstraní, ale skutečná výška zůstane větší než 20 bodů, protože text a okraje buněk vyžadují více prostoru. Pouhé snížení minima nemůže řádek nutit pod úroveň prostoru požadovaného jeho obsahem.

Několik faktorů ovlivňuje skutečnou výšku:

- **Text a velikost písma:** delší text, explicitní zalomení řádků nebo větší písmo mohou vyžadovat více svislého prostoru.
- **Zalamování a šířka sloupce:** při zapnutém zalamování může užší [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) vytvořit více řádků. Širší sloupec může snížit požadovaný svislý prostor.
- **Okraje buněk:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) a [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) přidávají svislý prostor. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) a [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) snižují šířku dostupnou pro text a mohou způsobit další zalamování.

Pro tuto tabulku bez sloučených buněk určuje buňka, která potřebuje nejvíce svislého prostoru, dolní limit celé řádky řízený obsahem. Pokud chcete řádek zkrátit, možná bude potřeba zkrátit text, snížit velikost písma nebo okraje, nebo rozšířit sloupec.

Obrázky níže ukazují stejnou tabulku ve stejném měřítku. V tomto běhu byly skutečné výšky 70, 100 a 55,2 bodu: poslední řádek zůstal vyšší než jeho 20bodové minimum. Přesná měření textu se mohou lišit podle dostupných písem ve vašem prostředí. Stáhněte si uložené výsledky: [zvýšené minimum](row-height-increased.pptx) a [snížené minimum](row-height-decreased.pptx).

| Původní: minimum 70 pt, aktuální 70 pt | Zvýšené: minimum 100 pt, aktuální 100 pt | Snížené: minimum 20 pt, aktuální 55.2 pt |
| --- | --- | --- |
| ![Původní tabulka s prvním řádkem 70 bodů.](row-height-before.png) | ![Tabulka po zvýšení minimální výšky prvního řádku na 100 bodů.](row-height-increased.png) | ![Tabulka po snížení minimální výšky prvního řádku na 20 bodů; zalomený text udržuje řádek vyšší než minimum.](row-height-decreased.png) |

## **Nastavit první řádek jako hlavičku**

Použijte vlastnost [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) k označení prvního řádku pro formátování hlavičky. Jeho vzhled závisí na stylu tabulky použitém na tabulce.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Získejte první snímek.
3. Získejte tabulku uloženou jako první tvar na snímku.
4. Povolte formátování hlavičky pro její první řádek.
5. Uložte upravenou prezentaci.

Příklad vyžaduje `table.pptx` s tabulkou jako první tvar na první snímku. Povolením formátování hlavičky pro první řádek uloží soubor `First_row_header.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Klonování řádku nebo sloupce tabulky**

Klonujte řádky nebo sloupce, abyste znovu použili jejich obsah a formátování. Můžete kopii připojit na konec tabulky nebo vložit na konkrétní pozici.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Získejte první snímek.
3. Definujte šířky sloupců a výšky řádků.
4. Přidejte tabulku pomocí metody [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Klonujte požadované řádky.
6. Klonujte požadované sloupce.
7. Uložte upravenou prezentaci.

Příklad vyžaduje `Test.pptx` s alespoň jedním snímkem. Vytvoří tabulku se třemi sloupci a pěti řádky, s rozměry uvedenými v bodech. Připojí kopie prvního řádku a sloupce, poté vloží kopie druhého řádku a sloupce na index 3 (čtvrtá pozice). Výsledná tabulka má sedm řádků a pět sloupců. Argument `false` zakazuje klonování do sousedních sloučených řádků nebo sloupců; tato tabulka nemá sloučené buňky.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **Odstranění řádku nebo sloupce z tabulky**

Odstraňte řádky nebo sloupce, které v tabulce již nejsou potřeba. Odstranění položky posune indexy řádků nebo sloupců, které po ní následují.

1. Vytvořte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Získejte první snímek.
3. Definujte šířky sloupců a výšky řádků.
4. Přidejte tabulku pomocí metody [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Odstraňte druhý řádek a druhý sloupec.
6. Uložte upravenou prezentaci.

Tento příklad vytvoří tabulku 3 × 3 a odstraní řádek a sloupec na indexu 1, což v souboru `TestTable_out.pptx` zanechá tabulku 2 × 2. Rozměry jsou v bodech. Argument `false` zakazuje odstraňování sousedních sloučených řádků nebo sloupců; tato tabulka nemá sloučené buňky.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **Nastavení formátování textu na úrovni řádku tabulky**

Aplikujte formátování textu na celý řádek, aby buňky byly konzistentní. Můžete nastavit vlastnosti písma, formátování odstavců a směr textu, aniž byste formátovali každou buňku zvlášť.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Získejte tabulku na první snímku.
3. Nastavte [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) pro první řádek.
4. Nastavte [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) a [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) pro první řádek.
5. Nastavte [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) pro druhý řádek.
6. Uložte upravenou prezentaci.

Příklad vyžaduje `table.pptx` s tabulkou jako první tvar na první snímku a alespoň dva řádky. Na první řádek aplikuje text o velikosti 25 bodů, pravé zarovnání a pravý okraj odstavce 20 bodů, poté nastaví svislý text ve druhém řádku.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **Nastavení formátování textu na úrovni sloupce tabulky**

Aplikujte formátování textu na celý sloupec, aby buňky byly konzistentní. Můžete nastavit vlastnosti písma, formátování odstavců a směr textu, aniž byste formátovali každou buňku zvlášť.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Získejte tabulku na první snímku.
3. Nastavte [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) pro první sloupec.
4. Nastavte [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) a [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) pro první sloupec.
5. Nastavte [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) pro druhý sloupec.
6. Uložte upravenou prezentaci.

Příklad vyžaduje `table.pptx` s tabulkou jako první tvar na první snímku a alespoň dva sloupce. Na první sloupec aplikuje text o velikosti 25 bodů, pravé zarovnání a pravý okraj odstavce 20 bodů, poté nastaví svislý text ve druhém sloupci.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **Získání vlastností stylu tabulky**

Použijte vlastnost [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) k získání přednastaveného stylu použitého na tabulku a jeho opětovnému použití na jiné tabulce. Toto identifikuje přednastavení místo jednotlivých přepsání formátování buněk.

Příklad vytvoří tabulku, použije [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/), a načte přednastavení zpět. Vytiskne `DarkStyle1` a uloží tabulku do souboru `table.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Často kladené otázky**

**Mohu na již vytvořenou tabulku aplikovat motivy/styly PowerPointu?**

Ano. Tabulka dědí motiv snímku/podkladu/hlavního motivu a stále můžete přepisovat výplně, ohraničení a barvy textu nad tímto motivem.

**Mohu řadit řádky tabulky podobně jako v Excelu?**

Ne, tabulky Aspose.Slides nemají vestavěné řazení ani filtry. Seřaďte svá data v paměti nejprve a poté znovu naplňte řádky tabulky v tomto pořadí.

**Mohu mít pruhované (proužky) sloupce a zároveň zachovat vlastní barvy v konkrétních buňkách?**

Ano. Zapněte pruhované sloupce a poté přepište konkrétní buňky lokálním formátováním; formátování na úrovni buňky má přednost před stylem tabulky.