---
title: Prezentációk renderelése helyettesítő betűtípusokkal Java-ban
linktitle: Prezentációk renderelése
type: docs
weight: 30
url: /hu/java/render-presentation-with-fallback-font/
keywords:
- helyettesítő betűtípus
- PowerPoint renderelése
- prezentáció renderelése
- dia renderelése
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Prezentációk renderelése helyettesítő betűtípusokkal az Aspose.Slides for Java-ban – biztosítsa a szöveg egységességét a PPT, PPTX és ODP formátumok között lépésről lépésre bemutatott Java kódmintákkal."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a prezentációk megjelenítését helyettesítő betűtípus szabályok használatával. Ez a cikk bemutatja, hogyan hozhat létre egy helyettesítő betűtípus szabálygyűjteményt, módosíthatja annak szabályait helyettesítő betűtípusok eltávolításával vagy hozzáadásával, és hogyan rendeli hozzá a gyűjteményt a `FontsManager.setFontFallBackRulesCollection` metódussal.

Miután a helyettesítő betűtípus szabálygyűjteményt hozzárendelték a prezentáció `FontsManager`‑éhez, a szabályok alkalmazásra kerülnek a mentés, megjelenítés és a prezentáció konvertálása során. A példa bemutatja, hogyan használhatók a beállított szabályok egy diakép bélyegkép megjelenítésekor és JPEG képként való mentésekor.

## **Dia megjelenítése helyettesítő betűtípus szabályokkal**

1. [helyettesítő betűtípus szabálygyűjteményt hozunk létre](/slides/hu/java/create-fallback-fonts-collection/).
2. [Eltávolít](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) egy helyettesítő betűtípus szabályt és [addFallBackFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) egy másik szabályhoz.
3. Állítsa be a szabálygyűjteményt a [getFontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) metódusra.
4. A [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#save-java.lang.String-int-) metódussal menthetjük a prezentációt ugyanabban a formátumban, vagy egy másikban. Miután a helyettesítő betűtípus szabálygyűjteményt beállítottuk a [FontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsManager) számára, ezek a szabályok minden prezentáción végzett műveletnél alkalmazásra kerülnek: mentés, megjelenítés, konvertálás stb.

```java
import com.aspose.slides.*;

// Hozzon létre egy új szabálygyűjtemény példányt
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // A betöltött szabályokból megpróbálja eltávolítani a "Tahoma" helyettesítő betűtípust
    fallBackRule.remove("Tahoma");

    // És frissíti a szabályokat a megadott tartományra
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// Ezenkívül eltávolíthatunk bármilyen meglévő szabályt a listáról, legalább egy szabályt megőrizve a rendereléshez
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // A felhasználandó előkészített szabálylistát rendeli hozzá
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Miniatűr renderelése az inicializált szabálygyűjtemény használatával és mentése JPEG formátumban
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Kép mentése lemezen JPEG formátumban
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
További információk arról, hogyan [konvertálhatja a PPT és PPTX fájlokat JPG-re Java-ban](/slides/hu/java/convert-powerpoint-to-jpg/).
{{% /alert %}}