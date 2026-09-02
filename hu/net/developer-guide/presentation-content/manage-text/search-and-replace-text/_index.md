---
title: Keresés és helyettesítés a PowerPoint prezentációk szövegében .NET környezetben
linktitle: Keresés és helyettesítés
type: docs
weight: 55
url: /hu/net/search-and-replace-text/
keywords:
- szöveg keresése
- szöveg kiemelése
- szöveg helyettesítése
- reguláris kifejezés
- eredmény visszahívás
- szövegdoboz
- audit jelentés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Keresés, kiemelés és szöveg helyettesítés PowerPoint prezentációkban, miközben az összes egyezést az Aspose.Slides for .NET segítségével gyűjti."
---
## **Áttekintés**

Az Aspose.Slides for .NET képes keresni, kiemelni és helyettesíteni a szöveget egy egyedi szövegdobozban vagy egy teljes prezentációban. Minden művelet értesítheti az alkalmazást minden egyezésről egy eredményvisszahíváson keresztül. Ez lehetővé teszi, hogy frissítsünk egy prezentációt, és egyidejűleg audit nyomvonalat építsünk, amely tartalmazza a megtalált szöveget, annak környezetét, pozícióját, szövegdobozt és a dia számát.

Ezek a lehetőségek hasznosak felülvizsgálathoz, sötétítéshez, terminológiai ellenőrzésekhez, sablon tisztításhoz és automatizált jelentéskészítési munkafolyamatokhoz.

Az alábbi első példákban egy “sample.pptx” nevű fájlt használunk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

## **Válassza ki a keresési tartományt**

Használja az [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) metódusait egy művelet korlátozásához egyetlen szövegdobozra. Használja a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) metódusait a prezentációban található minden alkalmazható szöveg feldolgozásához.

| Művelet | Egy szövegdoboz | Teljes prezentáció |
|---|---|---|
| Szó szerinti szöveg kiemelése | [ITextFrame.HighlightText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/highlighttext/) |
| Reguláris kifejezés egyezéseinek kiemelése | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/highlightregex/) |
| Szó szerinti szöveg helyettesítése | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/replacetext/) |
| Reguláris kifejezés egyezéseinek helyettesítése | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/replaceregex/) |

## **Szövegillesztés beállítása**

Szó szerinti szöveg műveletekhez használja a [TextSearchOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/) elemet a keresés szabályozásához:

- A [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/wholewordsonly/) csak teljes szavakra korlátozza az egyezéseket.
- A [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/casesensitive/) szabályozza, hogy a karakterek kis- és nagybetűje egyezzen-e.
- A [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/includenotes/) a diáknotákba is belefoglalja a prezentáció-szintű keresés, helyettesítés és kiemelés műveleteket.

A reguláris kifejezéssel végzett műveletek .NET `Regex`-et használnak, ezért az olyan szabályok, mint a kis- és nagybetű érzékenység vagy a szóhatárok, a kifejezésben és annak beállításaiban vannak meghatározva.

## **Egyezésinformációk gyűjtése visszahívással**

Implementálja a [IFindResultCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/ifindresultcallback/) interfészt, hogy minden egyezésről értesítést kapjon. A [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/hu/net/aspose.slides/ifindresultcallback/foundresult/) metódusa a kapcsolódó szövegdobozt, a forrás szöveget, a megtalált szöveget és az egyezés pozícióját adja vissza.

A visszahívás nem kap közvetlenül dia számot. Az alábbi implementáció a szülő diából származtatja azt, és kezeli a diák jegyzetében talált szöveget is. Egy nullable (null értékű) dia szám lehetővé teszi, hogy ugyanaz a eredménymodell más diatípusokhoz kapcsolódó szöveget is képviseljen.

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

A helyettesítési műveleteknél a `FoundText` a eredeti megtalált szöveget tartalmazza, így a visszahívás pontosan rögzítheti, mely kifejezéseket cserélték le.

## **Szöveg kiemelése**

Használja az [ITextFrame.HighlightText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/highlighttext/) metódust a szó szerinti szöveg egyezéseinek kiemelésére egy szövegdobozban. Adjon át [TextSearchOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/) objektumot a keresés szabályozásához, és egy visszahívást az egyezés részleteinek gyűjtéséhez.

Az alábbi kódrészlet minden **"try"** karakter előfordulását kiemeli, majd csak a teljes **"to"** szót emeli ki. Mindkét keresés ugyanarra a visszahívásra jelenti az egyezéseket.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Szerezze meg az első alakzatot az első diáról.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Emelje ki a "try" minden előfordulását a szövegdobozban.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Emelje ki csak a teljes "to" szót.
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A kiemelt szöveg](highlighted_text.png)

## **Szöveg kiemelése reguláris kifejezésekkel**

Az [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/highlightregex/) metódus a reguláris kifejezéssel talált szöveg egyezéseket emeli ki egy szövegdobozban.

Az alábbi kód minden, legalább hét karaktert tartalmazó szót kiemeli és minden egyezést rögzít:

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

Az eredmény:

![A reguláris kifejezéssel kiemelt szöveg](highlighted_text_using_regex.png)

## **Szöveg kiemelése a teljes prezentációban**

Használja a [Presentation.HighlightText](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/highlighttext/) és a [Presentation.HighlightRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/highlightregex/) metódusokat a prezentáció összes alkalmazható szövegdobozának kereséséhez. Az alábbi példa egy szó szerinti kifejezést és az összes e-mail címet emeli ki, miközben külön eredménygyűjteményeket tart fenn a két kereséshez.

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

## **Szöveg helyettesítése egy szövegdobozban**

Használja az [ITextFrame.ReplaceText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/replacetext/) metódust szó szerinti szöveghez és az [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/replaceregex/) metódust mintára alapozott helyettesítéshez. Ezek a metódusok a meglévő szövegdobozon belül frissítik a megtalált szöveget, megtartva a környező részformázást ahelyett, hogy a szövegdobozt egy egyszerű karakterláncból újjáépítenék.

Az alábbi példa egy helyesírási változatot szabványosít, majd verziócímkéket helyettesít. Ugyanaz a visszahívás rögzíti mindkét művelet által megtalált eredeti kifejezéseket.

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

Ha egy egyezés több, különböző formázású részt érint, ellenőrizze a kimenetet, hogy megerősítse, mely formázás legyen alkalmazva a helyettesítő szövegre.

## **Szöveg helyettesítése a teljes prezentációban**

Használja a [Presentation.ReplaceText](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/replacetext/) és a [Presentation.ReplaceRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/replaceregex/) metódusokat a teljes prezentáción belüli ugyanazon műveletek alkalmazásához. Ez hasznos sablon tisztításához, terminológiai frissítésekhez és sötétítéshez.

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

## **Egyezések csoportosítása jelentéshez**

Mivel minden eredmény tárolja a dia számát és a szövegdobozt, az alkalmazások csoportosíthatják az egyezéseket audit, jelentés vagy felülvizsgálati munkafolyamatok céljából. Az alábbi példa a gyűjtött eredményeket először diánként, majd szövegdobozonként csoportosítja:

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

## **GYIK**

**Hogyan kereshetek csak egy szövegdobozt a teljes prezentáció helyett?**

Szerezze meg az alakzat szövegdobozát, és hívja meg a [ITextFrame.HighlightText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/replacetext/) vagy a [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/replaceregex/) metódust azon a szövegdobozon. A prezentáció-szintű metódusok minden alkalmazható szövegdobozt feldolgoznak helyette.

**Hogyan egyeztessek teljes szavakat a megfelelő nagybetűkkel?**

Állítsa a [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/wholewordsonly/) és a [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/casesensitive/) értékét `true`‑ra, majd adja át ezeket a beállításokat egy szó szerinti szöveg kiemelés vagy helyettesítés metódusának. Reguláris kifejezéseknél a szóhatárokat és a kis- és nagybetű érzékenységet a .NET `Regex` maga definiálja.

**Tartalmazhatja a keresés és helyettesítés a diák jegyzeteiben lévő szöveget?**

Igen. Állítsa a [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/includenotes/) értékét `true`‑ra, amikor prezentáció-szintű szó szerinti szöveg műveletet használ. A fent bemutatott visszahívás-implementáció a jegyzetben talált egyezést a szülő diák számmá képezi le.

**Hogyan készíthetek jelentést anélkül, hogy a prezentációt újra beolvasnám?**

Adjon át egy [IFindResultCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/ifindresultcallback/) implementációt a kiemelés vagy helyettesítés műveletnek. A visszahívás minden egyezést megkap a művelet futása közben, így az alkalmazás el tudja tárolni a forrás szöveget, a megtalált szöveget, a pozíciót, a szövegdobozt és a származtatott dia számot a későbbi csoportosításhoz vagy exportáláshoz.

**Megőrzi a szöveg helyettesítése annak formázását?**

Az [ITextFrame.ReplaceText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/replacetext/) és az [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/replaceregex/) módosítják a megtalált szöveget a meglévő szövegdobozon belül, és megtartják a környező rész formázását. Ha egy egyezés több, különböző formázású részt érint, ellenőrizze az eredményt, hogy a helyettesítés a kívánt stílust alkalmazza.