---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides for .NET 15.1.0
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- migracja
- kod legacy
- kod nowoczesny
- podejście legacy
- podejście nowoczesne
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API oraz zmiany niekompatybilne w Aspose.Slides for .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint (PPT, PPTX) i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) klasy, metody, właściwości itp., oraz inne zmiany wprowadzone w API Aspose.Slides for .NET 15.1.0.

{{% /alert %}} 
## **Zmiany publicznego API**
#### **Dodano funkcjonalność podstawiania czcionek**
Możliwość globalnej zamiany czcionki w całej prezentacji oraz tymczasowej dla renderowania została dodana.

Wprowadzono nową właściwość „FontsManager” klasy Presentation. Klasa FontsManager posiada następujące elementy:

**IFontSubstRuleCollection FontSubstRuleList** Property

Ta kolekcja instancji IFontSubstRule używana jest do podstawiania czcionek podczas renderowania. IFontSubstRule posiada właściwości SourceFont i DestFont implementujące interfejs IFontData oraz właściwość ReplaceFontCondition umożliwiającą wybór warunku zamiany („WhenInaccessible” lub „Always”).

**IFontData[] GetFonts()** Method

Służy do pobierania wszystkich czcionek używanych w bieżącej prezentacji.

**ReplaceFont** Methods

Służy do trwałej zamiany czcionki w prezentacji. 

Poniższy przykład pokazuje, jak zamienić czcionkę w prezentacji:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Inny przykład demonstruje podstawianie czcionki podczas renderowania, gdy jest niedostępna:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Czcionka Arial zostanie użyta zamiast SomeRareFont, gdy będzie niedostępna

            pres.Slides[0].GetThumbnail();

```