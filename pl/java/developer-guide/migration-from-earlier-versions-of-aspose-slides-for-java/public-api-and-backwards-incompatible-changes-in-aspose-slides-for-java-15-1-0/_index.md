---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides for Java 15.1.0
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- migracja
- kod starszy
- nowoczesny kod
- starsze podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API oraz zmiany łamiące w Aspose.Slides for Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) klasy, metody, właściwości itd., wszelkie nowe ograniczenia oraz inne [zmiany](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) wprowadzone w API Aspose.Slides for Java 15.1.0.

{{% /alert %}} {{% alert color="info" %}} 

Istnieją znane problemy z niektórymi punktorami‑obrazami i obiektami WordArt, które zostaną naprawione w Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Zmiany publicznego API**
### **Dodano funkcjonalność podstawiania czcionek**
Dodano możliwość globalnej wymiany czcionek w całej prezentacji oraz tymczasowej wymiany podczas renderowania.

Wprowadzono nową metodę getFontsManager() klasy Presentation. Klasa FontsManager posiada następujące elementy:

metoda **IFontSubstRuleCollection getFontSubstRuleList**()

Jest to kolekcja obiektów IFontSubstRule używanych do podstawiania czcionek podczas renderowania. IFontSubstRule posiada metody getSourceFont() i getDestFont() implementujące interfejs IFontData oraz metodę getReplaceFontCondition(), umożliwiającą wybór warunku zastąpienia ("WhenInaccessible" lub "Always").

metodę **IFontData[] getFonts()** można użyć do pobrania wszystkich czcionek użytych w bieżącej prezentacji.

metod **replaceFont(...)** można użyć do trwałej wymiany czcionki w prezentacji. 

Poniższy przykład pokazuje, jak wymienić czcionkę w prezentacji:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Kolejny przykład pokazuje podstawianie czcionki podczas renderowania, gdy jest ona niedostępna:

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

    // Czcionka Arial zostanie użyta zamiast SomeRareFont, gdy będzie niedostępna.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```