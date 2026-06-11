---
title: Publiczne API oraz niekompatybilne wstecz zmiany w Aspose.Slides for Java 15.1.0
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- migracja
- starszy kod
- nowoczesny kod
- starsze podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API oraz zmiany łamiące w Aspose.Slides for Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie dodane klasy, metody, właściwości itp., wszelkie nowe ograniczenia oraz inne zmiany wprowadzone w API Aspose.Slides for Java 15.1.0.

{{% /alert %}} {{% alert color="primary" %}} 

Istnieją znane problemy z niektórymi punktami graficznymi i obiektami WordArt, które zostaną naprawione w Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Zmiany API publicznego**
### **Dodano funkcjonalność podstawiania czcionek**
Dodano możliwość zastępowania czcionek globalnie w całej prezentacji oraz tymczasowo podczas renderowania.

Wprowadzono nową metodę getFontsManager() klasy Presentation. Klasa FontsManager posiada następujące elementy:

**IFontSubstRuleCollection getFontSubstRuleList()** metoda

Jest to kolekcja instancji IFontSubstRule używanych do podstawiania czcionek podczas renderowania. IFontSubstRule posiada metody getSourceFont() i getDestFont() implementujące interfejs IFontData oraz metodę getReplaceFontCondition() umożliwiającą wybór warunku zastąpienia („WhenInaccessible” lub „Always”).

**IFontData[] getFonts()** metoda może być użyta do pobrania wszystkich czcionek użytych w bieżącej prezentacji.

**replaceFont(...)** metody mogą być użyte do trwałego zastąpienia czcionki w prezentacji.  

Poniższy przykład pokazuje, jak zastąpić czcionkę w prezentacji:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Inny przykład pokazuje podstawianie czcionki podczas renderowania, gdy jest niedostępna:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// Czcionka Arial będzie użyta zamiast SomeRareFont, gdy będzie niedostępna

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```