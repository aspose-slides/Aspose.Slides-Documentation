---
title: Vyhledávání a nahrazování textu v prezentacích PowerPoint v .NET
linktitle: Vyhledávání a nahrazování textu
type: docs
weight: 55
url: /cs/net/search-and-replace-text/
keywords:
- vyhledat text
- zvýraznit text
- nahradit text
- regulární výraz
- zpětné volání výsledku
- textový rámeček
- auditní zpráva
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vyhledávejte, zvýrazňujte a nahrazujte text v prezentacích PowerPoint a sbírejte každou shodu pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Aspose.Slides pro .NET může vyhledávat, zvýrazňovat a nahrazovat text v jednotlivém textovém rámečku nebo v celé prezentaci. Každá operace může také upozornit aplikaci na každou shodu pomocí zpětného volání výsledku. To umožňuje aktualizovat prezentaci a současně vytvářet auditní stopu obsahující nalezený text, jeho kontext, pozici, textový rámeček a číslo snímku.

Tyto možnosti jsou užitečné pro revizi, redigování, kontrolu terminologie, úklid šablon a automatizované workflow reportování.

V prvních příkladech níže používáme soubor s názvem "sample.pptx", který obsahuje jediný textový rámeček na prvním snímku s následujícím textem:

![Ukázkový text](sample_text.png)

## **Zvolte rozsah vyhledávání**

Použijte metody na [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) pro omezení operace na jeden textový rámeček. Použijte metody na [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) pro zpracování veškerého relevantního textu v prezentaci.

| Operace | Jeden textový rámeček | Celá prezentace |
|---|---|---|
| Zvýraznit doslovný text | [ITextFrame.HighlightText](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/highlighttext/) |
| Zvýraznit shody regulárního výrazu | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/highlightregex/) |
| Nahradit doslovný text | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/replacetext/) |
| Nahradit shody regulárního výrazu | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/replaceregex/) |

## **Nastavení shody textu**

Pro operace s doslovným textem použijte [TextSearchOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/textsearchoptions/) pro řízení shody:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/cs/net/aspose.slides/textsearchoptions/wholewordsonly/) omezuje shody na celá slova.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/cs/net/aspose.slides/textsearchoptions/casesensitive/) řídí, zda se musí shodovat velikost písmen.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/cs/net/aspose.slides/textsearchoptions/includenotes/) zahrnuje poznámky k snímkům při vyhledávání, nahrazování a zvýrazňování na úrovni prezentace.

Operace s regulárním výrazem používají .NET `Regex`, takže pravidla shody, jako je rozlišování velkých a malých písmen a hranice slov, jsou definována výrazem a jeho možnostmi.

## **Identifikace vlastníka textového rámečku**

Obecné workflow zpracování textu často získají [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) během vyhledávání, nahrazování, validace nebo exportu textu. Použijte [ITextFrame.ParentShape](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/parentshape/) a [ITextFrame.ParentCell](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/parentcell/) k určení, který objekt prezentace vlastní textový rámeček.

Očekávané hodnoty závisí na vlastníkovi:

| Vlastník textového rámečku | `ParentShape` | `ParentCell` |
|---|---|---|
| AutoShape nebo jiný tvar obsahující text | Vlastní [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/) | `null` |
| Buňka tabulky | `null` | Vlastní [ICell](https://reference.aspose.com/slides/cs/net/aspose.slides/icell/) |

Obě vlastnosti jsou jen pro čtení a slouží k navigaci. Čtení neprovádí žádný přesun textového rámečku ani nezmění jeho vlastníka. Obecný kód by měl zkontrolovat oba hodnoty na `null` a řešit možnost, že žádný vlastník není k dispozici.

Následující příklad používá [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/getalltextframes/) k iteraci přes textové rámečky v prezentaci. Pro tvary vypisuje název tvaru, typ tvaru a příslušný snímek. Pro buňky tabulky vypisuje nulově indexované souřadnice sloupce a řádku a příslušný snímek.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

Pro obsah SmartArt iterujte přes tvary v [ISmartArtNode.Shapes](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/ismartartnode/shapes/) a přistupujte k jednotlivým [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/ismartartshape/textframe/). Textový rámeček lze sledovat k jeho souvisejícímu tvaru pomocí [ITextFrame.ParentShape](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/parentshape/), zatímco [ITextFrame.ParentCell](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/parentcell/) je `null`. Proto větev pro tvary v příkladu také zpracovává text ze SmartArt uzlů.

## **Shromažďování informací o shodách pomocí zpětného volání**

Implementujte [IFindResultCallback](https://reference.aspose.com/slides/cs/net/aspose.slides/ifindresultcallback/) pro získání oznámení o každé shodě. Jeho metoda [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/cs/net/aspose.slides/ifindresultcallback/foundresult/) poskytuje související textový rámeček, zdrojový text, nalezený text a pozici shody.

Zpětné volání nedostává číslo snímku přímo. Implementace níže odvozuje číslo ze snímku rodiče a také zpracovává text nalezený v poznámkách ke snímkům. Číslo snímku může být nullable, aby stejný model výsledku mohl reprezentovat text spojený s jinými typy snímků.

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

Pro operace nahrazování obsahuje `FoundText` původní nalezený text, takže zpětné volání může přesně zaznamenat, které termíny byly nahrazeny.

## **Zvýraznit text**

Použijte metodu [ITextFrame.HighlightText](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/highlighttext/) pro zvýraznění doslovných shod v textovém rámečku. Předejte [TextSearchOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/textsearchoptions/) pro řízení vyhledávání a zpětné volání pro sběr podrobností o shodách.

Následující kód zvýrazní všechny výskyty znaků **"try"** a poté zvýrazní pouze celé slovo **"to"**. Obě vyhledávání odesílají své shody do stejného zpětného volání.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Získat první tvar z prvního snímku.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Zvýraznit každý výskyt "try" v textovém rámečku.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Zvýraznit pouze úplné slovo "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

Výsledek:

![Zvýrazněný text](highlighted_text.png)

## **Zvýraznit text pomocí regulárních výrazů**

Metoda [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/highlightregex/) zvýrazní textové shody nalezené regulárním výrazem v textovém rámečku.

Následující kód zvýrazní všechna slova obsahující alespoň sedm znaků a shromáždí každou shodu:

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

Výsledek:

![Zvýrazněný text pomocí regulárního výrazu](highlighted_text_using_regex.png)

## **Zvýraznit text v celé prezentaci**

Použijte [Presentation.HighlightText](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/highlighttext/) a [Presentation.HighlightRegex](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/highlightregex/) k vyhledání ve všech relevantních textových rámečcích v prezentaci. Následující příklad zvýrazní doslovný termín a všechny e‑mailové adresy při zachování samostatných kolekcí výsledků pro obě vyhledávání.

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **Nahradit text v textovém rámečku**

Použijte [ITextFrame.ReplaceText](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/replacetext/) pro doslovný text a [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/replaceregex/) pro nahrazování na základě vzoru. Tyto metody aktualizují nalezený text v existujícím textovém rámečku, čímž zachovají formátování okolních částí místo přestavby rámečku z prostého řetězce.

Následující příklad standardizuje variantu pravopisu a poté nahradí štítky verzí. Stejné zpětné volání zaznamenává původní termíny nalezené oběma operacemi.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

Pokud jedna shoda zasahuje do částí s různým formátováním, zkontrolujte výstup, abyste potvrdili, které formátování by se mělo použít na nahrazený text.

## **Nahradit text v celé prezentaci**

Použijte [Presentation.ReplaceText](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/replacetext/) a [Presentation.ReplaceRegex](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/replaceregex/) k provedení stejných operací v celé prezentaci. To je užitečné pro úklid šablon, aktualizace terminologie a redigování.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **Seskupení shod pro reportování**

Protože každý výsledek uchovává číslo snímku a textový rámeček, aplikace mohou shody seskupit pro audit, reportování nebo kontrolní workflow. Následující příklad nejprve seskupí shromážděné výsledky podle snímku a poté podle textového rámečku:

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **Často kladené otázky**

**Jak mohu vyhledávat jen v jednom textovém rámečku místo celé prezentace?**

Získejte textový rámeček tvaru a zavolejte [ITextFrame.HighlightText](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/replacetext/) nebo [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/replaceregex/) na tomto rámečku. Metody na úrovni prezentace zpracovávají všechny relevantní textové rámečky.

**Jak mohu vyhledávat celá slova s správnou kapitalizací?**

Nastavte [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/cs/net/aspose.slides/textsearchoptions/wholewordsonly/) a [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/cs/net/aspose.slides/textsearchoptions/casesensitive/) na `true` a předejte možnosti metodě pro zvýraznění nebo nahrazení doslovného textu. Pro regulární výrazy definujte hranice slov a rozlišování velikosti písmen přímo v .NET `Regex`.

**Může vyhledávání a nahrazování zahrnovat text v poznámkách k snímkům?**

Ano. Nastavte [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/cs/net/aspose.slides/textsearchoptions/includenotes/) na `true` při používání operace doslovného textu na úrovni prezentace. Implementace zpětného volání uvedená výše mapuje shodu v poznámce snímku zpět na číslo nadřazeného snímku.

**Jak mohu vytvořit report bez druhého skenování prezentace?**

Předávejte implementaci [IFindResultCallback](https://reference.aspose.com/slides/cs/net/aspose.slides/ifindresultcallback/) do operace zvýraznění nebo nahrazení. Zpětné volání přijímá každou shodu během provádění operace, takže aplikace může uložit zdrojový text, nalezený text, pozici, textový rámeček a odvozené číslo snímku pro pozdější seskupení nebo export.

**Zachovává nahrazování textu jeho formátování?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/replacetext/) a [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/replaceregex/) upravují nalezený text v existujícím textovém rámečku a zachovávají formátování okolních částí. Pokud shoda zasahuje do částí s různým formátováním, zkontrolujte výsledek, abyste se ujistili, že nahrazení používá požadovaný styl.