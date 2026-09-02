---
title: Automatizace lokalizace prezentace v .NET
linktitle: Lokalizace prezentace
type: docs
weight: 100
url: /cs/net/presentation-localization/
keywords:
- změna jazyka
- kontrola pravopisu
- potlačení kontroly pravopisu
- jazyk korektury
- identifikátor jazyka
- vícejazyčný text
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Nastavte jazyky korektury pro texty prezentací PowerPoint a OpenDocument v .NET pomocí Aspose.Slides, včetně výchozích nastavení a vícejazyčných odstavců."
---
## **Přehled**

Aspose.Slides pro .NET vám umožňuje konfigurovat metadata korektury pro jednotlivé textové úseky. Použijte [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/languageid/) k určení jazyka korektury, [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/cs/net/aspose.slides/baseportionformat/spellcheck/) k povolení či potlačení kontrol pravopisu a [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/cs/net/aspose.slides/baseportionformat/proofdisabled/) k řízení širšího stavu bez korektury. Protože jsou tato nastavení aplikována na úroveň úseku, může jeden odstavec obsahovat více jazyků a různá pravidla korektury.

Tento článek popisuje, jak přiřadit jazyk konkrétnímu textu, nastavit výchozí jazyk pro nový text pomocí [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/defaulttextlanguage/), vytvořit vícejazyčné odstavce, zvolit mezi `SpellCheck` a `ProofDisabled` a zachovat požadovaná nastavení při použití [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/joinportionswithsameformatting/). Tyto vlastnosti ukládají metadata pro prezentační aplikace; nepřekládejí text, neprovádějí kontrolu pravopisu na základě slovníku ani nevracejí nesprávně napsaná slova.

## **Nastavení jazyka korektury pro text**

Vytvořte nebo načtěte [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/), přistupte k požadovanému textovému úseku pomocí [IPortion.PortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/portionformat/), a přiřaďte mu identifikátor jazyka. Následující příklad vytvoří tvar, nastaví britskou angličtinu jako jazyk korektury a výsledek uloží pomocí [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Nastavení výchozího jazyka pro nový text**

Použijte [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/defaulttextlanguage/) k určení jazyka korektury, který Aspose.Slides přiřadí nově vytvořenému textu. Toto nastavení je užitečné, když většina nebo veškerý nový text v prezentaci používá stejný jazyk. Nemění metadata jazyka textu, který již má explicitně nastavený jazyk.

Následující příklad vytvoří prezentaci, jejíž nový text používá německá pravidla korektury:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **Použití více jazyků v jednom odstavci**

Rozhraní [IParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/) obsahuje kolekci textových úseků. Vytvořte samostatný [Portion](https://reference.aspose.com/slides/cs/net/aspose.slides/portion/) pro každý jazyk a nastavte jeho `LanguageId` nezávisle.

Tento příklad vytvoří jeden odstavec s úseky v angličtině a francouzštině:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **Povolení nebo potlačení kontroly pravopisu pro jednotlivé úseky**

[IPortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iportionformat/) dědí společné textové vlastnosti definované v [IBasePortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/). Přistupte k formátu úseku přes [IPortion.PortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/portionformat/) a nastavte [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/cs/net/aspose.slides/baseportionformat/spellcheck/), abyste řídili, zda prezentační aplikace může provádět kontrolu pravopisu pro tento úsek. Výchozí hodnota je `false`: `true` povoluje kontrolu pravopisu, zatímco `false` ji potlačuje.

Toto nastavení se vztahuje na jednotlivé textové úseky. Různé úseky ve stejném odstavci mohou proto používat odlišné hodnoty. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/cs/net/aspose.slides/baseportionformat/languageid/) a `SpellCheck` slouží doplňujícím účelům: `LanguageId` určuje jazyk korektury, zatímco `SpellCheck` určuje, zda jsou povoleny kontroly pravopisu pro úsek.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/cs/net/aspose.slides/baseportionformat/proofdisabled/) také řídí korekturu, ale představuje širší stav „neprovádět korekturu“ jako [NullableBool](https://reference.aspose.com/slides/cs/net/aspose.slides/nullablebool/). Použijte `SpellCheck`, když potřebujete přímý Booleovský přepínač specificky pro kontroly pravopisu. Použijte `ProofDisabled`, když potřebujete zachovat nebo explicitně ovládat metadata prezentace o neprovádění korektury, včetně jejího stavu `NotDefined`. Pokud nastavíte oba vlastnosti, udržujte jejich hodnoty konzistentní; nekombinujte `SpellCheck = true` s `ProofDisabled = NullableBool.True`.

Tyto vlastnosti konfigurují metadata korektury používaná PowerPointem a dalšími prezentačními aplikacemi. Aspose.Slides je nepoužívá k provádění kontroly pravopisu na základě slovníku ani nevrací seznam nesprávně napsaných slov.

Následující kompletní příklad vytvoří vstupní prezentaci, načte ji, přiřadí různá nastavení kontroly pravopisu a jazyky korektury dvěma úsekům ve stejném odstavci, uloží výsledek, znovu jej otevře a ověří uložené hodnoty:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/joinportionswithsameformatting/) sloučí sousední úseky, které mají stejné formátování. Pouze rozdíl v `SpellCheck` nezabrání sloučení takových úseků; po sloučení si výsledný úsek zachová hodnotu `SpellCheck` prvního úseku. Pokud úseky vyžadují odlišná nastavení kontroly pravopisu, volejte `JoinPortionsWithSameFormatting` před přiřazením těchto nastavení, nebo prozkoumejte hranice výsledného úseku a po sloučení nastavení znovu aplikujte. Úseky s různými hodnotami `LanguageId` zůstávají oddělené, protože se liší jejich formátování pro jazyk korektury.

## **FAQ**

**Překládá jazykové ID text?**

Ne. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/languageid/) ukládá metadata korektury pro pravopis a gramatiku; nemění obsah textu. Text přeložte samostatně a poté pro každý přeložený úsek nastavte odpovídající identifikátor jazyka.

**Řídí jazyk korektury písma, dělení slov nebo zalamování řádků?**

Ne. Identifikátor jazyka slouží k úpravě korektury. Vykreslování a rozvržení textu závisí převážně na dostupných [fonts](/slides/cs/net/powerpoint-fonts/), psacím systému a nastaveních textového rámce. Pro spolehlivé vykreslení poskytněte potřebná písma, nakonfigurujte [font substitution](/slides/cs/net/font-substitution/) nebo [embed fonts](/slides/cs/net/embedded-font/) v prezentaci.

**Může jeden odstavec použít několik jazyků korektury?**

Ano. Přiřaďte každý jazyk samostatnému úseku, jak je ukázáno v příkladu vícejazyčného odstavce.

**Mám použít `DefaultTextLanguage` nebo `LanguageId`?**

Použijte [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/defaulttextlanguage/), když chcete výchozí nastavení pro nově vytvořený text. Použijte [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/languageid/), když konkrétní úsek vyžaduje explicitní jazyk korektury nebo když odstavec obsahuje více jazyků.