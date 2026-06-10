---
title: Publikus API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 15.1.0-ban
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for Java nyilvános API frissítéseit és törő változásait, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) osztályt, metódust, tulajdonságot és így tovább, valamint az új korlátozásokat és egyéb [változásokat](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) a Aspose.Slides for Java 15.1.0 API-val kapcsolatban.

{{% /alert %}} {{% alert color="primary" %}} 

Ismertek a problémák néhány képes felsorolástjel és WordArt objektummal kapcsolatban, amelyek javításra kerülnek az Aspose.Slides for Java 15.2.0-ban.

{{% /alert %}} 
## **Publikus API Változások**
### **A betűtípus-helyettesítési funkcionalitás hozzáadva**
Lehetőség került hozzáadásra a betűtípusok globális helyettesítésére a teljes prezentációban, illetve ideiglenesen a rendereléshez.

Új **getFontsManager()** metódust vezettek be a **Presentation** osztályban. A **FontsManager** osztálynak a következő tagjai vannak:

**IFontSubstRuleCollection getFontSubstRuleList**() metódus  

Ez a gyűjtemény IFontSubstRule példányokból áll, amelyeket a renderelés során a betűtípusok helyettesítésére használnak. Az IFontSubstRule rendelkezik **getSourceFont()** és **getDestFont()** metódusokkal, amelyek az IFontData interfészt valósítják meg, valamint **getReplaceFontCondition()** metódussal, amely lehetővé teszi a helyettesítés feltételének kiválasztását ("WhenInaccessible" vagy "Always").

**IFontData[] getFonts()** metódus használható a jelenlegi prezentációban használt összes betűtípus lekérdezésére.

**replaceFont(...)** metódusok használhatók egy betűtípus állandó helyettesítésére egy prezentációban.  

Az alábbi példa bemutatja, hogyan lehet egy betűtípust helyettesíteni egy prezentációban:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Egy másik példa a betűtípus helyettesítést mutatja a renderelés során, ha az nem elérhető:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// Az Arial betűtípust a SomeRareFont helyett fogja használni, ha nem érhető el

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```