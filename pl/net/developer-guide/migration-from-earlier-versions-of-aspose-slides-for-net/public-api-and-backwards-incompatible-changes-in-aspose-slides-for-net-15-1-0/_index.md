---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 15.1.0
linktitle: Aspose.Slides dla .NET 15.1.0
type: docs
weight: 130
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- migracja
- stary kod
- nowoczesny kod
- stare podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API oraz zmiany łamiące kompatybilność w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) klasy, metody, właściwości i inne zmiany wprowadzone w API Aspose.Slides dla .NET 15.1.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
#### **Dodano funkcjonalność zastępowania czcionek**
Dodano możliwość globalnej zamiany czcionki w całej prezentacji oraz tymczasowej podczas renderowania.

Wprowadzono nową właściwość „FontsManager” klasy Presentation. Klasa FontsManager zawiera następujących członków:

**IFontSubstRuleCollection FontSubstRuleList** Property

Ta kolekcja instancji IFontSubstRule używana do zastępowania czcionek podczas renderowania. IFontSubstRule posiada właściwości SourceFont i DestFont implementujące interfejs IFontData oraz właściwość ReplaceFontCondition pozwalającą wybrać warunek zastąpienia („WhenInaccessible” lub „Always”).

**IFontData[] GetFonts()** Method

Używana do pobrania wszystkich czcionek używanych w bieżącej prezentacji.

**ReplaceFont** Methods

Używana do trwałego zastąpienia czcionki w prezentacji.

Poniższy przykład pokazuje, jak zastąpić czcionkę w prezentacji:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Kolejny przykład demonstruje zastępowanie czcionki podczas renderowania, gdy jest ona niedostępna:

``` csharp
using Aspose.Slides;


             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Czcionka Arial zostanie użyta zamiast SomeRareFont, gdy jest niedostępna

            pres.Slides[0].GetImage();

```