---
title: Nyilvános API és visszafelé inkompatibilis változások az Aspose.Slides for .NET 15.1.0-ban
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át a nyilvános API frissítéseket és a tör breaking változásokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 
Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) osztályt, metódust, tulajdonságot stb., valamint az Aspose.Slides for .NET 15.1.0 API‑val bevezetett egyéb változásokat.
{{% /alert %}} 
## **Nyilvános API változások**
#### **Betűtípus-helyettesítési funkció hozzáadva**
Lehetőség lett hozzáadva a betűtípus globális cseréjére az egész prezentációban, valamint ideiglenes cserére a renderelés során.

Új, a Presentation osztályhoz tartozó "FontsManager" tulajdonság került bevezetésre. A FontsManager osztálynak a következő tagjai vannak:

**IFontSubstRuleCollection FontSubstRuleList** Tulajdonság

Ez az IFontSubstRule példányok gyűjteménye, amelyet a betűtípusok renderelés közbeni helyettesítésére használnak. Az IFontSubstRule rendelkezik a SourceFont és DestFont tulajdonságokkal, amelyek az IFontData interfészt valósítják meg, valamint a ReplaceFontCondition tulajdonsággal, amely lehetővé teszi a csere feltételének kiválasztását („WhenInaccessible” vagy „Always”).

**IFontData[] GetFonts()** Metódus

A jelenlegi prezentációban használt összes betűtípus lekérésére használható.

**ReplaceFont** Metódusok

A prezentációban a betűtípus tartós cseréjére használható. 

Az alábbi példa bemutatja, hogyan cserélhető a betűtípus a prezentációban:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Egy másik példa a betűtípus helyettesítést mutatja be rendereléskor, amikor a betűtípus nem érhető el:

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

            // Az Arial betűtípust a SomeRareFont helyett használják, amikor elérhetetlen

            pres.Slides[0].GetImage();

```