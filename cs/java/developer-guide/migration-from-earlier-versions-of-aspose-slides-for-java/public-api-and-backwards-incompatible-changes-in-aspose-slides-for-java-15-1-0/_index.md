---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro Java 15.1.0
linktitle: Aspose.Slides pro Java 15.1.0
type: docs
weight: 100
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
  - migrace
  - starý kód
  - moderní kód
  - starý přístup
  - moderní přístup
  - PowerPoint
  - OpenDocument
  - prezentace
  - Java
  - Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a průlomové změny v Aspose.Slides pro Java, abyste mohli hladce migrovat své řešení pro prezentace PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 

Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) třídy, metody, vlastnosti a podobně, jakékoli nové omezení a další [změny](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) zavedené v API Aspose.Slides pro Java 15.1.0.

{{% /alert %}} {{% alert color="primary" %}} 

Existují známé problémy s některými obrázkovými odrážkami a objekty WordArt, které budou opraveny v Aspose.Slides pro Java 15.2.0.

{{% /alert %}} 
## **Změny veřejného API**
### **Funkčnost substituce fontů byla přidána**
Byla přidána možnost nahrazovat fonty globálně v celé prezentaci i dočasně při renderování.

Nová metoda getFontsManager() třídy Presentation byla zavedena. Třída FontsManager má následující členy:

**IFontSubstRuleCollection getFontSubstRuleList**() method

Jedná se o kolekci instancí IFontSubstRule používaných k substituci fontů během renderování. IFontSubstRule má metody getSourceFont() a getDestFont() implementující rozhraní IFontData a metodu getReplaceFontCondition() umožňující zvolit podmínku nahrazení ("WhenInaccessible" nebo "Always").

**IFontData[] getFonts()** method can be used to retrieve all fonts used in the current presentation.

**replaceFont(...)** methods can be used to persistently replace a font in a presentation. 

Následující příklad ukazuje, jak nahradit font v prezentaci:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Další příklad ukazuje substituci fontu při renderování, když je font nedostupný:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// Písmo Arial bude použito místo SomeRareFont, když je nedostupné

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```