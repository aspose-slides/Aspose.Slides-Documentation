---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 15.1.0-ban
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- bemutató
- Java
- Aspose.Slides
description: "Tekintse át a nyilvános API frissítéseket és a visszafelé nem kompatibilis változásokat az Aspose.Slides for Java-ban, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP bemutató megoldásait."
---
{{% alert color="info" %}} 

Ez az oldal felsorolja az összes [added](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) osztályt, metódust, tulajdonságot és így tovább, az új korlátozásokat valamint a bevezetett [changes](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) elemeket az Aspose.Slides for Java 15.1.0 API-val.

{{% /alert %}} {{% alert color="info" %}} 

Ismert problémák vannak egyes képes felsorolásjelekkel és WordArt objektumokkal, amelyeket az Aspose.Slides for Java 15.2.0 javítani fog.

{{% /alert %}} 
## **Nyilvános API változások**
### **Betűtípus-helyettesítési funkció hozzáadva**
Lehetőség került bevezetésre a betűtípusok globális cseréjére az egész bemutatóban, illetve ideiglenes cserére a megjelenítés során.

Új **getFontsManager()** metódus került bevezetésre a Presentation osztályban. A FontsManager osztálynak a következő tagjai vannak:

**IFontSubstRuleCollection getFontSubstRuleList**() metódus

Ez a IFontSubstRule példányok gyűjteménye, amelyet a betűtípusok helyettesítésére használnak a megjelenítés során. Az IFontSubstRule rendelkezik **getSourceFont()** és **getDestFont()** metódusokkal, amelyek az IFontData interfészt valósítják meg, valamint **getReplaceFontCondition()** metódussal, amely lehetővé teszi a csere feltételének kiválasztását („WhenInaccessible” vagy „Always”).

**IFontData[] getFonts()** metódus használható az aktuális bemutatóban használt összes betűtípus lekérésére.

**replaceFont(...)** metódusok használhatók egy betűtípus tartós cseréjére egy bemutatóban.  

A következő példa mutatja be, hogyan lehet egy betűtípust kicserélni egy bemutatóban:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Egy másik példa, amely a betűtípus helyettesítést mutatja a megjelenítés során, amikor az nem elérhető:

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

    // Az Arial betűtípus lesz használva a SomeRareFont helyett, ha az nem érhető el.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```