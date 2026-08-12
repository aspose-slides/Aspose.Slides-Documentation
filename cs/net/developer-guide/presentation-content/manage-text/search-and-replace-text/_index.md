---
title: Vyhledávat a nahrazovat text v prezentacích PowerPoint v .NET
linktitle: Vyhledávat a nahrazovat text
type: docs
weight: 55
url: /cs/net/search-and-replace-text/
keywords:
- vyhledávat text
- zvýrazňovat text
- nahrazovat text
- regulární výraz
- zpětné volání výsledku
- textový rámec
- auditní zpráva
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vyhledávejte, zvýrazňujte a nahrazujte text v prezentacích PowerPoint a současně shromažďujte každou shodu pomocí Aspose.Slides for .NET."
---
## **Přehled**

Aspose.Slides pro .NET může vyhledávat, zvýrazňovat a nahrazovat text v jednotlivém textovém rámečku nebo v celé prezentaci. Každá operace může také upozornit aplikaci na každý výskyt pomocí zpětného volání s výsledkem. To umožňuje aktualizovat prezentaci a současně vytvořit auditní stopu obsahující nalezený text, jeho kontext, pozici, textový rámec a číslo snímku.

Tyto možnosti jsou užitečné pro revizi, redakci, kontrolu terminologie, úklid šablon a automatizované pracovní postupy pro reportování.

V prvních níže uvedených příkladech používáme soubor s názvem „sample.pptx“, který obsahuje jediný textový rámeček na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

## **Zvolte rozsah vyhledávání**

Použijte metody na [ITextFrame] pro omezení operace na jeden textový rámeček. Použijte metody na [Presentation] pro zpracování veškerého relevantního textu v prezentaci.

| Operace | Jeden textový rámec | Celá prezentace |
|---|---|---|
| Z​výraznit doslovný text | [ITextFrame.HighlightText](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/highlighttext/) |
| Z​výraznit shody regulárního výrazu | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/highlightregex/) |
| Nahradit doslovný text | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/replacetext/) |
| Nahradit shody regulárního výrazu | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/replaceregex/) |

## **Nastavení vyhledávání textu**

Pro operace s doslovným textem použijte [TextSearchOptions] k nastavení shody:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/cs/net/aspose.slides/textsearchoptions/wholewordsonly/) omezuje shody na celá slova.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/cs/net/aspose.slides/textsearchoptions/casesensitive/) určuje, zda se musí shodovat velikost písmen.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/cs/net/aspose.slides/textsearchoptions/includenotes/) zahrnuje poznámky ke snímkům při vyhledávání, nahrazování a zvýrazňování na úrovni celé prezentace.

Operace s regulárním výrazem používají .NET `Regex`, takže pravidla shody jako citlivost na velikost písmen a hranice slov jsou definována výrazem a jeho možnostmi.

## **Sběr informací o shodách pomocí zpětného volání**

Implementujte [IFindResultCallback] pro získání oznámení o každé shodě. Jeho metoda [IFindResultCallback.FoundResult] poskytuje související textový rámec, zdrojový text, nalezený text a pozici shody.

Zpětné volání nedostává číslo snímku přímo. Níže uvedená implementace ho získá z nadřazeného snímku a také zpracovává text nalezený v poznámkách ke snímkům. Číslo snímku může být nullable, což umožňuje stejný model výsledku reprezentovat text spojený s jinými typy snímků.

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
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

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

U operací nahrazování `FoundText` obsahuje původní nalezený text, takže zpětné volání může přesně zaznamenat, které výrazy byly nahrazeny.

## **Zvýraznit text**

Použijte metodu [ITextFrame.HighlightText] k zvýraznění shod doslovného textu v textovém rámečku. Předávejte [TextSearchOptions] pro nastavení vyhledávání a zpětné volání pro sběr podrobností o shodách.

Níže uvedený ukázkový kód zvýrazní všechny výskyty znaků **"try"** a poté zvýrazní pouze celé slovo **"to"**. Obě vyhledávání hlásí své shody stejnému zpětnému volání.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Získejte první tvar z prvního snímku.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Zvýrazněte každý výskyt "try" v textovém rámci.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Zvýrazněte pouze celé slovo "to".
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

Metoda [ITextFrame.HighlightRegex] zvýrazňuje shody textu nalezené regulárním výrazem v textovém rámečku.

Následující kód zvýrazní všechna slova obsahující sedm nebo více znaků a sbírá každou shodu:

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

Použijte [Presentation.HighlightText] a [Presentation.HighlightRegex] pro prohledání všech relevantních textových rámců v prezentaci. Následující příklad zvýrazní doslovný výraz a všechny e‑mailové adresy a zároveň vede samostatné kolekce výsledků pro obě vyhledávání.

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

## **Nahradit text v textovém rámci**

Použijte [ITextFrame.ReplaceText] pro doslovný text a [ITextFrame.ReplaceRegex] pro nahrazování na základě vzoru. Tyto metody aktualizují nalezený text v existujícím textovém rámci, přičemž zachovávají formátování okolních částí místo přestavby rámce z prostého řetězce.

Následující příklad standardizuje variantu pravopisu a poté nahradí označení verzí. Stejné zpětné volání zaznamenává původní výrazy nalezené oběma operacemi.

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

Pokud jedna shoda zahrnuje části s odlišným formátováním, zkontrolujte výstup, abyste potvrdili, které formátování má být použito pro nahrazený text.

## **Nahradit text v celé prezentaci**

Použijte [Presentation.ReplaceText] a [Presentation.ReplaceRegex] pro provedení stejných operací napříč prezentací. To je užitečné pro úklid šablon, aktualizaci terminologie a redakci.

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

Protože každý výsledek ukládá číslo snímku a textový rámec, aplikace mohou shody seskupovat pro audit, reportování nebo revizní pracovní postupy. Následující příklad seskupuje získané výsledky nejprve podle snímku a poté podle textového rámce:

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

Získejte textový rámec tvaru a zavolejte na něm [ITextFrame.HighlightText], [ITextFrame.HighlightRegex], [ITextFrame.ReplaceText] nebo [ITextFrame.ReplaceRegex]. Metody na úrovni prezentace zpracovávají všechny relevantní textové rámečky.

**Jak mohu vyhledávat úplná slova s správnou kapitalizací?**

Nastavte [TextSearchOptions.WholeWordsOnly] a [TextSearchOptions.CaseSensitive] na `true` a předávejte tyto možnosti metodě pro zvýraznění nebo nahrazení doslovného textu. Pro regulární výrazy definujte hranice slov a citlivost na velikost písmen přímo v .NET `Regex`.

**Může vyhledávání a nahrazování zahrnovat text v poznámkách ke snímkům?**

Ano. Nastavte [TextSearchOptions.IncludeNotes] na `true` při použití operace doslovného textu na úrovni prezentace. Ukázaná implementace zpětného volání mapuje shodu v poznámkách snímku zpět na číslo nadřazeného snímku.

**Jak mohu vytvořit zprávu, aniž bych procházel prezentaci podruhé?**

Předávejte implementaci [IFindResultCallback] operaci zvýraznění nebo nahrazování. Zpětné volání přijímá každou shodu během běhu operace, takže aplikace může uložit zdrojový text, nalezený text, pozici, textový rámec a odvozené číslo snímku pro pozdější seskupování nebo export.

**Zachovává nahrazování textu jeho formátování?**

[ITextFrame.ReplaceText] a [ITextFrame.ReplaceRegex] upravují nalezený text uvnitř existujícího textového rámce a zachovávají formátování okolních částí. Pokud shoda zahrnuje části s různým formátováním, zkontrolujte výsledek, abyste se ujistili, že nahrazení používá požadovaný styl.