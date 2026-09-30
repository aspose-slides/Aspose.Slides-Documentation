---
title: Správa tabulek prezentace v .NET
linktitle: Správa tabulky
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
description: "Vytvářejte a upravujte tabulky v PowerPoint slidech pomocí Aspose.Slides pro .NET. Objevte jednoduché příklady kódu v C# pro zefektivnění vašich pracovních postupů s tabulkami."
---
## **Úvod**

Tabulky v PowerPointu uspořádávají informace do řádků a sloupců, což usnadňuje čtení a porovnávání hodnot.

Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/net/aspose.slides/table/), rozhraní [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/), třídu [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/), rozhraní [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) a další typy, které vám umožní vytvářet, aktualizovat a spravovat tabulky v prezentacích.

## **Vytvoření tabulky od nuly**

Vytvořte tabulku zadáním její pozice, šířek sloupců a výšek řádků. Po přidání na snímek můžete formátovat okraje buněk, slučovat buňky a vkládat text.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Definujte pole šířek sloupců v bodech.
4. Definujte pole výšek řádků v bodech.
5. Přidejte objekt [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) na snímek pomocí metody [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. Procházejte každé [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) a použijte formátování horního, dolního, pravého a levého okraje.
7. Sloučte první dvě buňky v první řadě tabulky.
8. Přistupte ke sloučené buňce přes její vlastnost [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/).
9. Nastavte text ve sloučené buňce.
10. Uložte upravenou prezentaci.

Níže uvedený příklad vytvoří tabulku se třemi sloupci a pěti řádky v bodovém umístění (100, 50). Použije červené okraje o šířce 5 bodů, sloučí první dvě buňky v první řadě a výsledek uloží jako `table.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Číslování ve standardní tabulce**

Ve standardní tabulce jsou indexy buněk nulové a používají pořadí (sloupec, řádek). První buňka má index (0, 0).

Například buňky v tabulce se 4 sloupci a 4 řádky jsou očíslovány takto:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Tento příklad vytvoří výše ilustrovanou tabulku 4 × 4, se šířkami sloupců a výškami řádků 70 bodů a červenými okraji buněk o šířce 5 bodů. Souřadnice ukazují indexy buněk; příklad ponechá buňky prázdné a uloží tabulku jako `StandardTables_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **Přístup k existující tabulce**

Tabulky jsou uloženy v kolekci tvarů snímku. Procházejte tvary a najděte tabulku, poté použijte rozhraní [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) pro čtení nebo aktualizaci jejích buněk.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek obsahující tabulku podle jeho indexu.
3. Procházejte objekty [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) a zastavte se, když najdete tabulku. Pokud snímek obsahuje několik tabulek, použijte [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) k identifikaci požadované tabulky.
4. Aktualizujte text v cílové buňce.
5. Uložte upravenou prezentaci.

Níže uvedený příklad otevře `UpdateExistingTable.pptx` a najde první tabulku na prvním snímku. Nastaví buňku ve sloupci 0, řádku 1 na hodnotu `New` a výsledek uloží jako `table1_out.pptx`. Vstup musí obsahovat alespoň jeden snímek a první tabulka na tomto snímku musí mít alespoň jeden sloupec a dva řádky.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

Pro změnu výšky řádku v existující tabulce a pochopení, proč její skutečná výška může překročit požadovanou minimální, viz [Control Row Height](/slides/cs/net/manage-rows-and-columns/#control-row-height).

## **Nalezení buňky, která vlastní textový rámec**

Když obecný kód pro zpracování textu obdrží objekt [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) z tabulky, použijte vlastnost [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) k získání vlastníka – objektu [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/). Pro textový rámec buňky tabulky je [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) nastaven a [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) je `null`, i když samotná tabulka je tvarem.

Souřadnice buňky jsou dostupné přes jen pro čtení vlastnosti [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) a [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/). Vlastnost [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) je také jen pro čtení: umožňuje navigaci k vlastníkovi, ale nemění vlastnictví. Vždy před použitím zkontrolujte, zda vrácená buňka není `null`.

Kompletní příklad, který identifikuje vlastníky buněk tabulky a tvarů, včetně tvarů spojených s uzly SmartArt, naleznete v [Search and Replace Text](/slides/cs/net/search-and-replace-text/).

## **Zarovnání textu v tabulce**

Můžete řídit vertikální ukotvení a směr textu jednotlivých buněk tabulky. Příklad v této sekci zarovná text ve první buňce na střed a otočí jej o 270 stupňů.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte objekt [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) na snímek.
4. Získejte objekt [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) z tabulky.
5. Přistupte k prvnímu [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) a nastavte jeho text a barvu.
6. Nastavte buňce [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) a [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/).
7. Uložte upravenou prezentaci.

Tento příklad vytvoří tabulku 4 × 4 se šířkami sloupců 120 bodů a výškami řádků 100 bodů. Formátuje text v buňce (0, 0), přidá hodnoty do zbývajících buněk v první řadě a výsledek uloží jako `Vertical_Align_Text_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Nastavení formátování textu na úrovni tabulky**

Použijte [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) k aplikaci formátování textu na všechny buňky v tabulce. Jeho přetížení přijímají formátování částí, odstavců i textových rámců, takže můžete nastavit tyto vlastnosti bez iterace přes jednotlivé buňky.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Získejte objekt [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) ze snímku.
4. Nastavte [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) pro text.
5. Nastavte [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) a [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).
6. Nastavte [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. Uložte upravenou prezentaci.

Níže uvedený příklad otevře `table.pptx`, který musí obsahovat alespoň jeden snímek s tabulkou jako jejím prvním tvarem. Nastaví velikost písma na 25 bodů, zarovná odstavce vpravo s pravým okrajem 20 bodů a text nastaví vertikální. Formátovaná prezentace se uloží jako `result.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **Získání vlastností stylu tabulky**

Použijte [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) k načtení nebo přiřazení předdefinovaného stylu tabulky. Tento příklad použije [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) na jedné tabulce, vytiskne název presetu a přiřadí stejný preset druhé tabulce. Obě tabulky jsou uloženy v `table-style.pptx`.

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

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **Uzamčení poměru stran tabulky**

Poměr stran tabulky je poměr její šířky k výšce. Použijte [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) k uzamčení tohoto poměru pro tabulku.

Níže uvedený příklad otevře `pres.pptx`, který musí obsahovat alespoň jeden snímek s tabulkou jako jejím prvním tvarem. Vytiskne aktuální stav uzamčení, aktivuje uzamčení poměru stran, vytiskne aktualizovaný stav (`True`) a výsledek uloží jako `pres-out.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **Často kladené otázky**

**Mohu povolit směr čtení zprava doleva (RTL) pro celou tabulku a text v jejích buňkách?**

Ano. Tabulka má vlastnost [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) a odstavce mají [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/). Použití obou zajišťuje správné RTL pořadí a vykreslení uvnitř buněk.

**Jak mohu zabránit uživatelům přesouvat nebo měnit velikost tabulky v konečném souboru?**

Použijte [shape locks](/slides/cs/net/applying-protection-to-presentation/) k zakázání přesunu, změny velikosti, výběru atd. Tyto zámky platí i pro tabulky.

**Je podporováno vložení obrázku jako pozadí buňky?**

Ano. Můžete nastavit [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) pro buňku; obrázek pokryje oblast buňky podle zvoleného režimu (roztažení nebo dlaždice).