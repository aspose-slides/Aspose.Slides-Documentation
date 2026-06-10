---
title: Prezentációk renderelése tartalék betűtípusokkal Java-ban
linktitle: Prezentációk renderelése
type: docs
weight: 30
url: /hu/java/render-presentation-with-fallback-font/
keywords:
- tartalék betűtípus
- PowerPoint renderelése
- prezentáció renderelése
- dia renderelése
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Prezentációk renderelése tartalék betűtípusokkal az Aspose.Slides for Java-ban – a szöveg egységességének biztosítása PPT, PPTX és ODP formátumok között lépésről lépésre bemutatott Java kódrészletekkel."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy a prezentációkat tartalék betűtípus szabályokkal renderelje. Ez a cikk bemutatja, hogyan hozhat létre egy tartalék betűtípus szabályok gyűjteményét, hogyan módosíthatja a szabályokat tartalék betűtípusok eltávolításával vagy hozzáadásával, és hogyan rendelheti hozzá a gyűjteményt a `FontsManager.setFontFallBackRulesCollection` metódus segítségével.

Miután a tartalék betűtípus szabályok gyűjteménye hozzá lett rendelve a prezentáció `FontsManager`-éhez, a szabályok alkalmazásra kerülnek olyan műveletek során, mint a mentés, a renderelés és a prezentáció konvertálása. A példa bemutatja, hogyan használhatók a konfigurált szabályok egy dia bélyegkép renderelésekor és PNG képként való mentésekor.

## **Dia renderelése tartalék betűtípus szabályok használatával**

1. Létrehozzuk a [tartalék betűtípus szabályok gyűjteményét](/slides/hu/java/create-fallback-fonts-collection/).
1. [Eltávolít](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) egy tartalék betűtípus szabályt és [addFallBackFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) egy másik szabályhoz.
1. Állítsuk be a szabályok gyűjteményét a [getFontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) metódusra.
1. A [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#save-java.lang.String-int-) metódussal menthetjük a prezentációt ugyanabban a formátumban, vagy egy másikban. Miután a tartalék betűtípus szabályok gyűjteménye be lett állítva a [FontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsManager) objektumban, ezek a szabályok minden prezentáció művelet során alkalmazásra kerülnek: mentés, renderelés, konvertálás stb.

```java
// Új példány létrehozása egy szabálygyűjteményből
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// szabályok létrehozása
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // A betöltött szabályok közül a "Tahoma" tartalék betűtípust próbáljuk eltávolítani
    fallBackRule.remove("Tahoma");

    // És a szabályok frissítése a megadott tartományra
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Továbbá bármely létező szabályt eltávolíthatunk a listából
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Előkészített szabálykészlet hozzárendelése használatra
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Bélyegkép renderelése az inicializált szabálykészlet használatával és mentése JPEG-be
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Kép mentése lemezre JPEG formátumban
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
További információk arról, hogyan [PPT és PPTX konvertálása JPG-re Java-ban](/slides/hu/java/convert-powerpoint-to-jpg/).
{{% /alert %}}