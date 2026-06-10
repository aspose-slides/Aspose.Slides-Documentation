---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 15.1.0-ban
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át a nyilvános API frissítéseket és a töréspontokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) osztályt, metódust, tulajdonságot stb., valamint a Aspose.Slides for .NET 15.1.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Nyilvános API Változások**
#### **A betűtípus helyettesítés funkciója hozzá lett adva**
Lehetőség került hozzáadásra a betűtípus globális cseréjére az egész prezentációban és ideiglenesen a rendereléshez.

Új "FontsManager" tulajdonság került bevezetésre a Presentation osztályban. A FontsManager osztálynak a következő tagjai vannak:

**IFontSubstRuleCollection FontSubstRuleList** tulajdonság

Ez az IFontSubstRule példányok gyűjteménye, amely a betűtípusok helyettesítésére szolgál renderelés közben. Az IFontSubstRule rendelkezik a SourceFont és a DestFont tulajdonságokkal, amelyek az IFontData interfészt valósítják meg, valamint a ReplaceFontCondition tulajdonsággal, amely lehetővé teszi a csere feltételének kiválasztását („WhenInaccessible” vagy „Always”).

**IFontData[] GetFonts()** metódus

A jelenlegi prezentációban használt összes betűtípus lekérésére szolgál.

**ReplaceFont** metódusok

A prezentációban a betűtípus tartós cseréjére szolgál.  

A következő példa bemutatja, hogyan cserélhető a betűtípus a prezentációban:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Egy másik példa a betűtípus helyettesítést mutatja be rendereléskor, ha elérhetetlen:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Az Arial betűtípus lesz használva a SomeRareFont helyett, ha nem érhető el

            pres.Slides[0].GetThumbnail();

```