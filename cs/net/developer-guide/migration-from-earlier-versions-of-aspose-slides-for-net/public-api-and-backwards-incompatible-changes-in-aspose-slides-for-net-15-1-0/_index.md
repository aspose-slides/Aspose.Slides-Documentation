---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 15.1.0
linktitle: Aspose.Slides pro .NET 15.1.0
type: docs
weight: 130
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- migrace
- starší kód
- moderní kód
- starší přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte aktualizace veřejného API a rušivé změny v Aspose.Slides pro .NET, abyste hladce migrovali svá řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 
Tato stránka uvádí všechny [přidané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) nebo [odebrané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) třídy, metody, vlastnosti a další položky a další změny zavedené v API Aspose.Slides pro .NET 15.1.0.
{{% /alert %}} 
## **Veřejné změny API**
#### **Byla přidána funkce Nahrazování fontů**
Byla přidána možnost globálně nahradit font v celé prezentaci a dočasně pro vykreslování.

Byla představena nová vlastnost "FontsManager" třídy Presentation. Třída FontsManager má následující členy:

**IFontSubstRuleCollection FontSubstRuleList** Vlastnost
Tato kolekce instancí IFontSubstRule se používá k nahrazování fontů během vykreslování. IFontSubstRule má vlastnosti SourceFont a DestFont implementující rozhraní IFontData a vlastnost ReplaceFontCondition, která umožňuje zvolit podmínku nahrazení ("WhenInaccessible" nebo "Always").

**IFontData[] GetFonts()** Metoda
Používá se k získání všech fontů použitých v aktuální prezentaci.

**ReplaceFont** Metody
Používá se k trvalému nahrazení fontu v prezentaci. 

Následující příklad ukazuje, jak nahradit font v prezentaci:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Další příklad ukazuje nahrazování fontu pro vykreslování, když je font nedostupný:

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

            // Písmo Arial bude použito místo SomeRareFont, když není přístupné

            pres.Slides[0].GetImage();

```