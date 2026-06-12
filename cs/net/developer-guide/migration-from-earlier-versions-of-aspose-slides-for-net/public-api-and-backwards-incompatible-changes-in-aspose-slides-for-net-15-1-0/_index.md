---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 15.1.0
linktitle: Aspose.Slides pro .NET 15.1.0
type: docs
weight: 130
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- migrace
- zastaralý kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zkontrolujte aktualizace veřejného API a breaking changes v Aspose.Slides pro .NET, abyste hladce migrovali své řešení pro prezentace PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 

Tato stránka uvádí všechny [přidáno](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) nebo [odebráno](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) třídy, metody, vlastnosti a tak dále a další změny zavedené v API Aspose.Slides pro .NET 15.1.0.

{{% /alert %}} 
## **Veřejné změny API**
#### **Funkčnost nahrazování písem byla přidána**
Možnost nahradit písmo globálně v celé prezentaci i dočasně pro vykreslování byla přidána.

Byla zavedena nová vlastnost "FontsManager" třídy Presentation. Třída FontsManager má následující členy:

**IFontSubstRuleCollection FontSubstRuleList** Property

Tato kolekce instancí IFontSubstRule se používá k nahrazování písem během vykreslování. IFontSubstRule má vlastnosti SourceFont a DestFont implementující rozhraní IFontData a vlastnost ReplaceFontCondition, která umožňuje zvolit podmínku nahrazení ("WhenInaccessible" nebo "Always").

**IFontData[] GetFonts()** Method

Používá se k získání všech písem použitých v aktuální prezentaci.

**ReplaceFont** Methods

Používá se k trvalému nahrazení písma v prezentaci. 

Následující příklad ukazuje, jak nahradit písmo v prezentaci:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Další příklad ukazuje nahrazení písma pro vykreslování, když je nedostupné:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Písmo Arial bude použito místo SomeRareFont, když je nedostupné

            pres.Slides[0].GetThumbnail();

```