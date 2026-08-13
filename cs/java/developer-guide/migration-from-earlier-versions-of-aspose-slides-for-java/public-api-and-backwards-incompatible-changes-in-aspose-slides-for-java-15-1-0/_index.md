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
description: "Prozkoumejte aktualizace veřejného API a kritické změny v Aspose.Slides pro Java, abyste hladce migrovali vaše řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) třídy, metody, vlastnosti a podobně, jakákoli nová omezení a další [změny](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) zavedené v API Aspose.Slides pro Java 15.1.0.

{{% /alert %}} {{% alert color="info" %}} 

Existují známé problémy s některými obrázkovými odrážkami a objekty WordArt, které budou opraveny v Aspose.Slides pro Java 15.2.0.

{{% /alert %}} 
## **Změny veřejného API**
### **Byla přidána funkčnost substituce písem**
Možnost globálně nahradit písma v celé prezentaci a dočasně pro vykreslování byla přidána.

Byla zavedena nová metoda getFontsManager() třídy Presentation. Třída FontsManager má následující členy:

**IFontSubstRuleCollection getFontSubstRuleList**() metoda

Jedná se o kolekci instancí IFontSubstRule používaných k substituci písem během vykreslování. IFontSubstRule má metody getSourceFont() a getDestFont() implementující rozhraní IFontData a metodu getReplaceFontCondition(), která umožňuje zvolit podmínku nahrazení ("WhenInaccessible" nebo "Always").

**IFontData[] getFonts()** metoda může být použita k získání všech písem použitých v aktuální prezentaci.

**replaceFont(...)** metody mohou být použity k trvalému nahrazení písma v prezentaci. 

Následující příklad ukazuje, jak nahradit písmo v prezentaci:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Další příklad ukazuje substituci písma pro vykreslování, když je nedostupné:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // Písmo Arial bude použito místo SomeRareFont, když je nedostupné.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```