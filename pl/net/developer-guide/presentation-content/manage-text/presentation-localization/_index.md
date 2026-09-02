---
title: Automatyzuj lokalizację prezentacji w .NET
linktitle: Lokalizacja prezentacji
type: docs
weight: 100
url: /pl/net/presentation-localization/
keywords:
- zmiana języka
- sprawdzanie pisowni
- wyłączenie sprawdzania pisowni
- język korekty
- identyfikator języka
- tekst wielojęzyczny
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Ustaw języki korekty dla tekstu prezentacji PowerPoint i OpenDocument w .NET przy użyciu Aspose.Slides, w tym wartości domyślne i akapity wielojęzyczne."
---
## **Omówienie**

Aspose.Slides for .NET umożliwia konfigurowanie metadanych korekty dla pojedynczych fragmentów tekstu. Użyj [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseportionformat/languageid/) aby określić język korekty, [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/pl/net/aspose.slides/baseportionformat/spellcheck/) aby zezwolić lub zablokować sprawdzanie pisowni oraz [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/pl/net/aspose.slides/baseportionformat/proofdisabled/) aby kontrolować szerszy stan „brak korekty”. Ponieważ te ustawienia są stosowane na poziomie fragmentu, jeden akapit może zawierać wiele języków i różnych reguł korekty.

Ten artykuł wyjaśnia, jak przypisać język do określonego tekstu, ustawić domyślny język dla nowego tekstu przy użyciu [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/defaulttextlanguage/), tworzyć wielojęzyczne akapity, wybierać pomiędzy `SpellCheck` a `ProofDisabled` oraz zachować zamierzone ustawienia przy użyciu [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/joinportionswithsameformatting/). Właściwości te przechowują metadane dla aplikacji prezentacyjnych; nie tłumaczą tekstu, nie wykonują sprawdzania pisowni opartego na słowniku ani nie zwracają niepoprawnych słów.

## **Ustaw język korekty dla tekstu**

Utwórz lub wczytaj [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/), uzyskaj dostęp do wymaganego fragmentu tekstu poprzez [IPortion.PortionFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/portionformat/) i przypisz jego identyfikator języka. Poniższy przykład tworzy kształt, ustawia brytyjski angielski jako język korekty i zapisuje wynik przy użyciu [Presentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/):

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

## **Ustaw domyślny język dla nowego tekstu**

Użyj [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/defaulttextlanguage/) aby określić język korekty, który Aspose.Slides przypisuje nowo tworzonemu tekstowi. To ustawienie jest przydatne, gdy większość lub cały nowy tekst w prezentacji używa tego samego języka. Nie zmienia ono metadanych językowych tekstu, który już ma wyraźnie określony język.

Poniższy przykład tworzy prezentację, w której nowy tekst używa zasad korekty dla języka niemieckiego:

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

## **Użyj wielu języków w jednym akapicie**

[IParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/) zawiera kolekcję fragmentów tekstu. Utwórz osobny [Portion](https://reference.aspose.com/slides/pl/net/aspose.slides/portion/) dla każdego języka i niezależnie ustaw jego `LanguageId`.

Ten przykład tworzy jeden akapit z fragmentami po angielsku i francusku:

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

## **Włącz lub wyłącz sprawdzanie pisowni dla poszczególnych fragmentów**

[IPortionFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/iportionformat/) dziedziczy wspólne właściwości tekstu zdefiniowane przez [IBasePortionFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseportionformat/). Uzyskaj dostęp do formatu fragmentu poprzez [IPortion.PortionFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/portionformat/) i ustaw [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/pl/net/aspose.slides/baseportionformat/spellcheck/), aby kontrolować, czy aplikacja prezentacyjna może sprawdzać pisownię tego fragmentu. Wartość domyślna to `false`: `true` zezwala na sprawdzanie, natomiast `false` je blokuje.

Ustawienie dotyczy pojedynczych fragmentów tekstu. Różne fragmenty w tym samym akapicie mogą więc mieć różne wartości. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/pl/net/aspose.slides/baseportionformat/languageid/) i `SpellCheck` pełnią uzupełniające się role: `LanguageId` identyfikuje język korekty, a `SpellCheck` określa, czy sprawdzanie pisowni jest dozwolone dla fragmentu.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/pl/net/aspose.slides/baseportionformat/proofdisabled/) również kontroluje korektę, ale reprezentuje szerszy stan „nie koryguj” jako [NullableBool](https://reference.aspose.com/slides/pl/net/aspose.slides/nullablebool/). Używaj `SpellCheck`, gdy potrzebujesz bezpośredniego przełącznika Boolean dla sprawdzania pisowni. Używaj `ProofDisabled`, gdy musisz zachować lub wyraźnie kontrolować metadane „brak korekty” prezentacji, w tym stan `NotDefined`. Jeśli ustawisz obie właściwości, zachowaj ich spójność; nie łącz `SpellCheck = true` z `ProofDisabled = NullableBool.True`.

Te właściwości konfigurowują metadane korekty używane przez PowerPoint i inne aplikacje prezentacyjne. Aspose.Slides nie wykorzystuje ich do uruchamiania sprawdzania pisowni opartego na słowniku ani do zwracania listy niepoprawnych wyrazów.

Poniższy pełny przykład tworzy prezentację wejściową, wczytuje ją, przypisuje różne ustawienia sprawdzania pisowni i języki korekty dwóm fragmentom w tym samym akapicie, zapisuje wynik, otwiera go ponownie i weryfikuje zapisane wartości:

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

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/joinportionswithsameformatting/) łączy sąsiadujące fragmenty o identycznym formatowaniu. Różnica jedynie w `SpellCheck` nie zapobiega połączeniu takich fragmentów; po ich połączeniu wynikowy fragment zachowuje wartość `SpellCheck` pierwszego fragmentu. Jeśli fragmenty wymagają odmiennych ustawień sprawdzania pisowni, wywołaj `JoinPortionsWithSameFormatting` przed ich ustawieniem lub sprawdź granice wynikowego fragmentu i ponownie zastosuj ustawienia. Fragmenty z różnymi wartościami `LanguageId` pozostają oddzielne, ponieważ ich formatowanie języka korekty się różni.

## **FAQ**

**Czy identyfikator języka tłumaczy tekst?**

Nie. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseportionformat/languageid/) przechowuje metadane korekty dla pisowni i gramatyki; nie zmienia treści tekstu. Przetłumacz tekst osobno, a następnie ustaw odpowiedni identyfikator języka dla każdego przetłumaczonego fragmentu.

**Czy język korekty kontroluje czcionki, dzielenie wyrazów lub zawijanie wierszy?**

Nie. Identyfikator języka służy wyłącznie do korekty. Renderowanie i układ tekstu zależą głównie od dostępnych [fonts](/slides/pl/net/powerpoint-fonts/), systemu pisma oraz ustawień ramki tekstowej. Aby zapewnić prawidłowe renderowanie, dostarcz wymagane czcionki, skonfiguruj [font substitution](/slides/pl/net/font-substitution/) lub [embed fonts](/slides/pl/net/embedded-font/) w prezentacji.

**Czy jeden akapit może używać kilku języków korekty?**

Tak. Przypisz każdy język do osobnego fragmentu, jak pokazano w przykładzie wielojęzycznego akapitu.

**Czy powinienem używać `DefaultTextLanguage` czy `LanguageId`?**

Użyj [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/defaulttextlanguage/), gdy chcesz ustawić domyślny język dla nowo tworzonego tekstu. Użyj [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseportionformat/languageid/), gdy konkretny fragment wymaga wyraźnego języka korekty lub gdy akapit zawiera wiele języków.