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
- přidat sloupec textu
- přidat hyperodkaz
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvářejte, identifikujte, formátujte a aktualizujte textová pole v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET."
---
## **Úvod**

V Aspose.Slides pro .NET je text snímku uložen v textových rámcích, které patří k obrazcům. Rozhraní [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) představuje nejběžnější obrazec nesoucí text a zpřístupňuje jeho text prostřednictvím vlastnosti [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Note" %}}
Každý automatický obrazec implementuje [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), ale ne každý obrazec je automatický obrazec nebo podporuje textový rámec. Při zpracování existující prezentace zkontrolujte, že obrazec implementuje `IAutoShape` před přístupem k jeho textu.
{{% /alert %}}

## **Vytvořit textové pole na snímku**

Pro vytvoření textového pole přidejte na snímek automatický obrazec, přidejte text do jeho textového rámce a uložte prezentaci. Následující příklad vytvoří obdélníkový textový rámec:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Souřadnice a rozměry předávané metodě [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) jsou měřeny v bodech. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) inicializuje textový rámec poskytnutým textem.

## **Zkontrolovat, zda jde o tvar textového pole**

Použijte vlastnost [AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) k určení, zda je automatický obrazec považován za textové pole. To je užitečné, když prezentace obsahuje jak obrazce nesoucí text, tak čistě grafické automatické obrazce.

![Textové pole a obrazec](istextbox.png)

Následující příklad kontroluje každý automatický obrazec v prezentaci:

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

Nově přidaný automatický obrazec není považován za textové pole, dokud neobsahuje ne‑prázdný text. Text můžete poskytnout pomocí [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) nebo [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/). Přidání nebo přiřazení prázdného řetězce ponechává `IsTextBox` nastaven na `false`:

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

První dva volání vypíší `True`; poslední dva vypíší `False`.

## **Najít tvar, který vlastní textový rámec**

Obecný kód pro zpracování textu může přijímat [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) bez informace, který objekt prezentace jej obsahuje. Použijte jen‑čtenou vlastnost [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) k navázání zpět na vlastníka [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/).

Pro textový rámec vlastněný automatickým obrazcem nebo jiným obrazcem nesoucím text obsahuje `ParentShape` vlastníka a [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) je `null`. Zkontrolujte vrácenou hodnotu před jejím použitím. Pro identifikaci vlastníků jak tvaru, tak buňky tabulky, včetně tvarů spojených s uzly SmartArt, viz [Vyhledat a nahradit text](/slides/cs/net/search-and-replace-text/).

## **Získat textový obdélník tvaru**

Od verze Aspose.Slides pro .NET 26.11 metoda [ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) vrací oblast textu definovanou geometrií nadřazeného tvaru. Jeho souřadnice a rozměry jsou v bodech, relativně k levému hornímu rohu tvaru. Například elipsa má menší textový obdélník než své vnější ohraničení.

Tento obdélník popisuje tvar, nikoli vykreslené znaky. Změna textu nebo okrajů textového rámce z něj nedělá měřítko obsazeného textu. Pro měření vykresleného textu použijte [hranice odstavce](/slides/cs/net/paragraph-bounds/) nebo [hranice úseku](/slides/cs/net/portion-bounds/).

Po [instalaci Aspose.Slides pro .NET](/slides/cs/net/installation/) 26.11 nebo novější spusťte tento příklad, který vykreslí geometrický textový obdélník červeně. Tvary jsou neotočené a nezkupené, takže přičtení jejich pozice X/Y stačí k umístění překrytí na snímek.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

U 200 × 100 bodových tvarů výše metoda vrátí `(0, 0, 200, 100)`; elipsa přibližně `(29.289, 14.645, 141.421, 70.711)`. Metoda také čte deklarovaný textový obdélník vlastní geometrie. Nepoužívá rotaci v prostoru snímku ani transformace skupiny; ty je třeba zohlednit samostatně při umisťování překrytí. Textový rámec bez geometrického tvaru, například textový rámec buňky tabulky, může vyvolat `InvalidOperationException`.

## **Přidat sloupce do textového pole**

Vlastnost [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) dělí textový rámec do sloupců, zatímco [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) stanovuje mezeru mezi sloupci v bodech. Obě nastavení patří do [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) a lze je měnit přes textový rámec existujícího textového pole. Text se přizpůsobuje mezi sloupci uvnitř stejného tvaru; nepřechází do jiného tvaru.

Následující příklad vytvoří třísloupcové textové pole se 10 body mezi sloupci, uloží prezentaci a načte zpět uložená nastavení z výstupního souboru:

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

## **Extrahovat text z jednotlivých sloupců**

Použijte [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/) k získání textu přiřazeného každému vizuálnímu sloupci v existujícím textovém rámci. Metoda vrací jeden řetězec pro každý sloupec ve sloupcovém pořadí čtení. Jednosloupcový textový rámec vytvoří pole s jedním prvkem a prázdný sloupec je reprezentován prázdným řetězcem. Řetězce obsahují pouze prostý text; formátování na úrovni úseku není zachováno.

To je užitečné, když potřebujete:

- Extrahovat text při zachování jeho sloupcového pořadí čtení.
- Indexovat nebo porovnat obsah více sloupcových snímků.
- Exportovat každý sloupec do samostatného souboru, databázového pole nebo jiného cíle.
- Prozkoumat, jak se text redistribuuje po změně [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/), písma nebo velikosti textového rámce.

Metoda hlásí text rozdělený v aktuálním [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/); automaticky neprotéká text mezi oddělenými tvary nebo textovými poli. Rozdělení sloupců může záviset na dostupných písmech a dalších nastaveních rozložení textu, proto zajistěte, že požadovaná písma jsou dostupná, když jsou konzistentní výsledky důležité.

Následující příklad načte prezentaci, najde první více‑sloupcový automatický obrazec s textovým rámcem, přečte jeho nastavený počet sloupců a zapíše text z každého sloupce do samostatného souboru. Tvary, které neposkytují textový rámec, jsou přeskočeny.

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

## **Aktualizovat text**

Pro aktualizaci textu v celé prezentaci procházejte snímky a tvary, vybírejte automatické obrazce a následně upravujte jejich textové úseky. Práce na úrovni úseku vám umožní měnit jak text, tak formátování znaků.

Následující příklad nahradí každý výskyt `years` řetězcem `months` v textu automatických obrazců a učiní každý ovlivněný úsek tučným:

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

Toto procházení aktualizuje text pouze v automatických obrazcích. Text uložený v tabulkách, grafech, SmartArt nebo seskupených tvarech vyžaduje procházení kolekcí těchto objektů.

## **Přidat textové pole s hyperodkazem**

Hyperodkaz můžete přiřadit konkrétnímu úseku textu, takže pouze tento text funguje jako klikací odkaz. Použijte [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) k propojení úseku s externí URL.

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

## **Často kladené otázky**

**Jaký je rozdíl mezi textovým polem a textovým zástupcem na hlavním nebo rozložení snímku?**

[placeholder](/slides/cs/net/manage-placeholder/) může zdědit svou pozici a formátování z [master slide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) nebo [layout slide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/). Běžné textové pole je nezávislý tvar na snímku, kde bylo vytvořeno, a nezíská chování zástupce při změně rozložení.

**Jak mohu nahradit text bez změny textu v grafech, tabulkách nebo SmartArt?**

Omezte procházení na tvary, které implementují [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), jak je ukázáno v příkladu Aktualizovat text. Grafy, tabulky a SmartArt ukládají text ve svých vlastních modelových objektech, takže nejsou tímto cyklem upraveny.