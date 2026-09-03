---
title: Správa textových polí v prezentacích v .NET
linktitle: Správa textového pole
type: docs
weight: 20
url: /cs/net/manage-textbox/
keywords:
- textové pole
- textový rámec
- přidat text
- aktualizovat text
- vytvořit textové pole
- zkontrolovat textové pole
- přidat textový sloupec
- přidat hyperodkaz
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvořit, identifikovat, formátovat a aktualizovat textová pole v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET."
---
## **Úvod**

V Aspose.Slides for .NET je text snímku uložen v textových rámečcích, které patří k objektům. Rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) představuje nejběžnější tvar nesoucí text a zpřístupňuje jeho text pomocí vlastnosti [IAutoShape.TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Note" %}}
Každý automatický tvar implementuje [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/), ale ne každý tvar je automatický tvar nebo podporuje textový rámec. Při zpracování existující prezentace zkontrolujte, zda objekt implementuje `IAutoShape`, než přistoupíte k jeho textu.
{{% /alert %}}

## **Vytvoření textového pole na snímku**

Chcete‑li vytvořit textové pole, přidejte automatický tvar na snímek, přidejte text do jeho textového rámce a uložte prezentaci. Následující příklad vytvoří obdélníkové textové pole:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Souřadnice a rozměry předávané metodě [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addautoshape/) jsou měřeny v bodech. Metoda [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/addtextframe/) inicializuje textový rámec dodaným textem.

## **Kontrola, zda jde o tvar textového pole**

Použijte vlastnost [AutoShape.IsTextBox](https://reference.aspose.com/slides/cs/net/aspose.slides/autoshape/istextbox/) k určení, zda je automatický tvar považován za textové pole. To je užitečné, když prezentace obsahuje jak tvary nesoucí text, tak čistě grafické automatické tvary.

![Textové pole a tvar](istextbox.png)

Následující příklad prozkoumá každý automatický tvar v prezentaci:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

Nově přidaný automatický tvar není považován za textové pole, dokud neobsahuje ne‑prázdný text. Text můžete dodat pomocí [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/addtextframe/) nebo [ITextFrame.Text](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/text/). Přidání nebo přiřazení prázdného řetězce ponechá `IsTextBox` nastaven na `false`:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

První dvě volání vypíšou `True`; poslední dvě `False`.

## **Nalezení tvaru, který vlastní textový rámec**

Obecný kód pro zpracování textu může získat [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) aniž by věděl, který objekt prezentace jej obsahuje. Použijte jen‑pro‑čtení vlastnost [ITextFrame.ParentShape](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/parentshape/) pro návrat k jeho vlastnímu [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/).

U textového rámce vlastněného automatickým tvarem nebo jiným tvarem nesoucím text obsahuje `ParentShape` vlastníka a [ITextFrame.ParentCell](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/parentcell/) je `null`. Zkontrolujte vrácenou hodnotu před přístupem. Pro identifikaci jak vlastníků tvarů, tak buněk tabulek, včetně tvarů spojených s uzly SmartArt, viz [Search and Replace Text](/slides/cs/net/search-and-replace-text/).

## **Přidání sloupců do textového pole**

Vlastnost [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/columncount/) dělí textový rámec na sloupce, zatímco [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/columnspacing/) nastavuje mezeru mezi sloupci v bodech. Obě nastavení patří do [ITextFrameFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/) a lze je změnit přes textový rámec existujícího textového pole. Text se přetéká mezi sloupci uvnitř stejného tvaru; nepřechází do jiného tvaru.

Následující příklad vytvoří třísloupcové textové pole s 10 bodi mezi sloupci, uloží prezentaci a načte uložená nastavení z výstupního souboru:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **Extrahování textu z jednotlivých sloupců**

Použijte [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/cs/net/aspose.slides/textframe/splittextbycolumns/) k získání textu přiřazeného ke každému vizuálnímu sloupci v existujícím textovém rámci. Metoda vrací jeden řetězec pro každý sloupec v pořadí čtení sloupců. Textový rámec s jedním sloupcem vrátí pole s jedním prvkem a prázdný sloupec je reprezentován prázdným řetězcem. Řetězce obsahují pouze prostý text; formátování na úrovni částí není zachováno.

To je užitečné, když potřebujete:

- Extrahovat text při zachování pořadí čtení založeného na sloupcích.
- Indexovat nebo porovnávat obsah snímků s více sloupci.
- Exportovat každý sloupec do samostatného souboru, databázového pole nebo jiného cíle.
- Prozkoumat, jak se text přerozdělí po změně [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/columnspacing/), písma nebo velikosti textového rámce.

Metoda hlásí text rozdělený v aktuálním [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/); automaticky nepřesouvá text mezi samostatnými tvary nebo textovými poli. Distribuce sloupců může záviset na dostupných písmech a dalších nastaveních rozvržení textu, takže zajistěte, aby požadovaná písma byla k dispozici, pokud jsou důsledné výsledky podstatné.

Následující příklad načte prezentaci, najde první automatický tvar s více sloupci a textovým rámcem, přečte jeho nastavený počet sloupců a zapíše text z každého sloupce do samostatného souboru. Tvary, které neposkytují textový rámec, jsou přeskočeny.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **Aktualizace textu**

Chcete‑li aktualizovat text v celé prezentaci, projděte snímky a tvary, vyberte automatické tvary a upravte jejich textové části. Práce na úrovni částí vám umožní měnit jak text, tak formátování znaků.

Následující příklad nahradí každé výskyt `years` řetězcem `months` v textu automatických tvarů a každou zasaženou část zvýrazní tučným písmem:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

Tento průchod aktualizuje text pouze v automatických tvarech. Text uložený v tabulkách, grafech, SmartArt nebo seskupených tvarech vyžaduje procházení jejich vlastních kolekcí.

## **Přidání textového pole s hyperodkazem**

Hyperodkaz může být přiřazen konkrétní textové části, takže jen tato část funguje jako kliknutelný odkaz. Použijte [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) k propojení části s externí URL.

Následující příklad vytvoří propojený text a uloží jej do prezentace:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Jaký je rozdíl mezi textovým polem a textovým zástupcem na hlavním snímku nebo rozvržení?**

[Placeholder](/slides/cs/net/manage-placeholder/) může zdědit svou pozici a formátování z [master slide](https://reference.aspose.com/slides/cs/net/aspose.slides/masterslide/) nebo [layout slide](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutslide/). Běžné textové pole je samostatný tvar na snímku, kde bylo vytvořeno, a nezíská chování zástupce při změně rozvržení.

**Jak mohu nahradit text, aniž bych změnil text v grafech, tabulkách nebo SmartArt?**

Omezte procházení na tvary, které implementují [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/), jak je ukázáno v příkladu Aktualizace textu. Grafy, tabulky a SmartArt ukládají text ve svých vlastních objektových modelech, takže nejsou tímto cyklem upraveny.