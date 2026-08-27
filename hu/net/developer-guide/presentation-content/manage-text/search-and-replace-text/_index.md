---
title: Szöveg keresése és cseréje PowerPoint-prezentációkban .NET-ben
linktitle: Keresés és csere szöveg
type: docs
weight: 55
url: /hu/net/search-and-replace-text/
keywords:
- szöveg keresése
- szöveg kiemelése
- szöveg cseréje
- reguláris kifejezés
- eredmény visszahívás
- szövegkeret
- audit jelentés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Szöveg keresése, kiemelése és cseréje PowerPoint-prezentációkban, miközben minden találatot összegyűjt az Aspose.Slides for .NET."
---
## **Áttekintés**

Az Aspose.Slides for .NET képes keresni, kiemelni és helyettesíteni a szöveget egy egyedi szövegkeretben vagy egy teljes prezentációban. Minden művelet értesítheti az alkalmazást minden egyes találatról egy eredmény‑visszahíváson keresztül. Ez lehetővé teszi a prezentáció frissítését, miközben egy audit nyomvonalat épít a megtalált szövegről, annak környezetéről, pozíciójáról, szövegkeretről és diaszámról.

Ezek a képességek hasznosak felülvizsgálathoz, szerkesztéshez, terminológiai ellenőrzésekhez, sablonok tisztításához és automatizált jelentéskészítési munkafolyamatokhoz.

Az alábbi első példákban egy "sample.pptx" nevű fájlt használunk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

## **A keresési hatókör kiválasztása**

Használja a [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) metódusait egy művelet egyetlen szövegkeretre korlátozásához. Használja a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) metódusait a prezentációban található összes alkalmazható szöveg feldolgozásához.

| Művelet | Egy szövegkeret | Teljes prezentáció |
|---|---|---|
| Literális szöveg kiemelése | [ITextFrame.HighlightText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/highlighttext/) |
| Reguláris kifejezés egyezéseinek kiemelése | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/highlightregex/) |
| Literális szöveg helyettesítése | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/replacetext/) |
| Reguláris kifejezés egyezéseinek helyettesítése | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/replaceregex/) |

## **Szövegillesztés beállítása**

Literal szöveg műveletekhez használja a [TextSearchOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/)‑t a keresés szabályozásához:

- Az [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/wholewordsonly/) csak teljes szavakra korlátozza a találatokat.
- Az [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/casesensitive/) szabályozza, hogy a karakterek nagybetű‑érzékenysége kötelező legyen-e.
- Az [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/includenotes/) a diák jegyzeteit is belefoglalja a prezentáció szintű keresésbe, helyettesítésbe és kiemelésbe.

A reguláris kifejezéseket használó műveletek egy .NET `Regex`‑et használnak, ezért a nagybetű‑érzékenység és a szóhatárok szabályait a kifejezés és annak beállításai határozzák meg.

## **A szövegkeret tulajdonosának azonosítása**

Az általános szövegfeldolgozó munkafolyamatok gyakran egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumot kapnak a keresés, helyettesítés, érvényesítés vagy exportálás során. Használja az [ITextFrame.ParentShape](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/parentshape/) és az [ITextFrame.ParentCell](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/parentcell/) hivatkozásokat annak meghatározásához, hogy melyik prezentációs objektum a szövegkeret tulajdonosa.

Az elvárt értékek a tulajdonostól függnek:

| Szövegkeret tulajdonosa | `ParentShape` | `ParentCell` |
|---|---|---|
| AutoShape vagy egy másik szöveget tartalmazó alakzat | A tulajdonos [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) | `null` |
| Táblázat cella | `null` | A tulajdonos [ICell](https://reference.aspose.com/slides/hu/net/aspose.slides/icell/) |

Mindkét tulajdonság csak olvasható navigációs tulajdonság. Olvasásuk nem mozgatja a szövegkeretet, és nem változtatja meg a tulajdonost. Az általános kódban ellenőrizni kell mindkét értéket `null`‑ra, és kezelni kell azt a lehetőséget, hogy egyik tulajdonos sem érhető el.

Az alábbi példa a [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/getalltextframes/)‑t használja a prezentáció szövegkereteinek bejárásához. Alakzatok esetén jelenti az alakzat nevét, típusát és a tartalmazó diát. Táblázat cellák esetén jelenti a nullától kezdődő oszlop- és sorkoordinátákat valamint a tartalmazó diát.

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

SmartArt tartalom esetén járja be az alakzatokat a [ISmartArtNode.Shapes](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/ismartartnode/shapes/)‑ben, és érje el minden [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/ismartartshape/textframe/)‑t. A szövegkeret a kapcsolódó alakzatra visszakövethető az [ITextFrame.ParentShape](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/parentshape/) segítségével, míg az [ITextFrame.ParentCell](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/parentcell/) `null`. Ezért a példában szereplő alakzatág szintén kezeli a SmartArt csomópontok szövegét.

## **Találati információk gyűjtése visszahívással**

Implementálja a [IFindResultCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/ifindresultcallback/) interfélt, hogy minden találatról értesítést kapjon. Az [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/hu/net/aspose.slides/ifindresultcallback/foundresult/) metódusa a kapcsolódó szövegkeretet, a forrás szöveget, a megtalált szöveget és a találat pozícióját adja.

A visszahívás nem kap közvetlenül diaszámot. Az alábbi implementáció a szülő diából származtatja azt, és kezeli a diák jegyzeteiben található szöveget is. A nullable (nullázható) diaszám lehetővé teszi, hogy ugyanaz a eredménymodell a többi diatípushoz tartozó szöveget is ábrázolja.

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

Helyettesítési műveleteknél a `FoundText` tartalmazza az eredeti megtalált szöveget, így a visszahívás pontosan rögzítheti, mely kifejezéseket cserélték le.

## **Szöveg kiemelése**

Használja az [ITextFrame.HighlightText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/highlighttext/) metódust a literális szöveg egyezéseinek kiemelésére egy szövegkeretben. Adjon át [TextSearchOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/) beállításokat a keresés vezérléséhez, valamint egy visszahívást a találati részletek gyűjtéséhez.

Az alábbi kódrészlet kiemeli a **"try"** összes előfordulását, majd csak a teljes **"to"** szót. Mindkét keresés a találatokat ugyanarra a visszahívásra jelenti.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Az első dián lévő első alakzat lekérése.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Kiemeli a szövegkeretben a "try" minden előfordulását.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Kiemeli csak a "to" teljes szót.
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

Az [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/highlightregex/) metódus kiemeli egy reguláris kifejezés által talált szövegegyezéseket egy szövegkeretben.

Az alábbi kód kiemeli a hét vagy több karaktert tartalmazó összes szót, és összegyűjti az egyes találatokat:

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

Használja a [Presentation.HighlightText](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/highlighttext/) és a [Presentation.HighlightRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/highlightregex/) metódusokat a prezentációban található összes alkalmazható szövegkeret keresésére. Az alábbi példa kiemeli egy literális kifejezést és az összes e‑mail címet, miközben külön eredménygyűjteményeket tart a két kereséshez.

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

## **Szöveg cseréje egy szövegkeretben**

Használja az [ITextFrame.ReplaceText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/replacetext/) metódust literális szöveghez és az [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/replaceregex/) metódust mintára alapozott helyettesítéshez. Ezek a metódusok a meglévő szövegkereten belül frissítik a megtalált szöveget, megőrizve a környező rész formázását ahelyett, hogy egy egyszerű karakterláncból újjáépítenék a szövegkeretet.

Az alábbi példa egységesíti egy helyesírási változatot, majd lecseréli a verziócímkéket. Az ugyanaz a visszahívás rögzíti mindkét művelet által megtalált eredeti kifejezéseket.

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

Ha egy találat több, eltérő formázású részt ölel fel, ellenőrizze a kimenetet, hogy melyik formázás legyen érvényes a helyettesített szövegre.

## **Szöveg cseréje a teljes prezentációban**

Használja a [Presentation.ReplaceText](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/replacetext/) és a [Presentation.ReplaceRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/replaceregex/) metódusokat a prezentáció egészére kiterjedő műveletekhez. Ez hasznos sablonok tisztításához, terminológiai frissítésekhez és szerkesztéshez.

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

## **Találatok csoportosítása jelentéshez**

Mivel minden eredmény tárolja a diaszámát és a szövegkeretét, az alkalmazások csoportosíthatják a találatokat audit, jelentés vagy felülvizsgálati munkafolyamatok céljából. Az alábbi példa a gyűjtött eredményeket először diánként, majd szövegkeretként csoportosítja:

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

**Hogyan kereshetek csak egy szövegdobozban a teljes prezentáció helyett?**

Szerezze meg az alakzat szövegkeretét, és hívja meg a [ITextFrame.HighlightText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/replacetext/) vagy a [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/replaceregex/) metódusokat azon a szövegkereten. A prezentációszintű metódusok minden alkalmazható szövegkeretet feldolgoznak.

**Hogyan illeszthetek teljes szavakat a helyes nagybetű‑érzékenységgel?**

Állítsa a [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/wholewordsonly/) és a [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/casesensitive/) értékét `true`‑ra, és adja át ezeket a beállításokat egy literális szöveg kiemelő vagy helyettesítő metódusnak. Reguláris kifejezéseknél a szóhatárokat és a nagybetű‑érzékenységet a .NET `Regex` maga határozza meg.

**A keresés és helyettesítés tartalmazhat szöveget a diák jegyzeteiben?**

Igen. Állítsa a [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/hu/net/aspose.slides/textsearchoptions/includenotes/) értékét `true`‑ra, amikor prezentációszintű literális szöveg műveletet használ. A fent bemutatott visszahívás-implementáció a jegyzetdián található találatot visszakapcsolja a szülődiára.

**Hogyan készíthetek jelentést a prezentáció újbóli beolvasása nélkül?**

Adjon át egy [IFindResultCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/ifindresultcallback/) implementációt a kiemeléshez vagy helyettesítéshez. A visszahívás minden találatot megkap a művelet futása során, így az alkalmazás tárolhatja a forrás szöveget, a megtalált szöveget, a pozíciót, a szövegkeretet és a származtatott diaszámot későbbi csoportosításhoz vagy exportáláshoz.

**Megőrzi-e a szöveg cseréje a formázását?**

Az [ITextFrame.ReplaceText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/replacetext/) és az [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/replaceregex/) a meglévő szövegkereten belül módosítják a megtalált szöveget, és megtartják a környező rész formázását. Ha egy találat több, különböző formázású részt foglal magába, ellenőrizze az eredményt, hogy a helyettesítés a kívánt stílust használja.