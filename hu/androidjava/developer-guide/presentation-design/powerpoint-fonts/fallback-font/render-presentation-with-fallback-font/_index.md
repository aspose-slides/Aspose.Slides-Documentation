---
title: Prezentációk renderelése tartalék betűtípusokkal Androidon
linktitle: Prezentációk renderelése
type: docs
weight: 30
url: /hu/androidjava/render-presentation-with-fallback-font/
keywords:
- tartalék betűtípus
- PowerPoint renderelése
- prezentáció renderelése
- dia renderelése
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Prezentációk renderelése tartalék betűtípusokkal az Aspose.Slides for Android-ban – a szöveg konzisztens marad a PPT, PPTX és ODP fájlok között, részletes Java kódmintákkal."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a prezentációk renderelését tartalék betűtípus szabályok használatával. Ez a cikk bemutatja, hogyan hozhatunk létre egy tartalék betűtípus szabályok gyűjteményt, hogyan módosíthatjuk a szabályokat tartalék betűtípusok eltávolításával vagy hozzáadásával, és hogyan rendeljük hozzá a gyűjteményt a `FontsManager.setFontFallBackRulesCollection` metódussal.

Miután a tartalék betűtípus szabályok gyűjteménye hozzárendelésre került a prezentáció `FontsManager`‑éhez, a szabályok a mentés, renderelés és a prezentáció konvertálása során érvényesülnek. A példa azt mutatja be, hogyan használhatók a konfigurált szabályok egy diasorozat bélyegképének renderelésekor, és annak PNG képként történő mentésekor.

## **Dia renderelése tartalék betűtípus szabályokkal**

Az alábbi példában a következő lépések szerepelnek:

1. Létrehozzuk a [tartalék betűtípus szabályok gyűjteményét](/slides/hu/androidjava/create-fallback-fonts-collection/).
1. [Eltávolítunk](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) egy tartalék betűtípus szabályt és hozzáadunk [addFallBackFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) egy másik szabályhoz.
1. Beállítjuk a szabályok gyűjteményét a [getFontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) módszerrel.
1. A [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) metódussal menthetjük a prezentációt ugyanabban a formátumban, vagy egy másikban. Miután a tartalék betűtípus szabályok gyűjteménye be lett állítva a [FontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontsManager)-ben, ezek a szabályok minden prezentációval végzett művelet során alkalmazásra kerülnek: mentés, renderelés, konvertálás stb.

```java
// Új szabálykötet példányának létrehozása
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// több szabály létrehozása
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Megpróbáljuk eltávolítani a "Tahoma" tartalék betűtípust a betöltött szabályokból
    fallBackRule.remove("Tahoma");

    // És a megadott tartomány szabályainak frissítése
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Ezenkívül eltávolíthatunk bármely létező szabályt a listáról
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Előkészített szabálykészlet hozzárendelése használathoz
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Bélyegkép renderelése a inicializált szabálykötet használatával, és mentése JPEG formátumban
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
További információ a [PPT és PPTX konvertálásáról JPG-re Androidon](/slides/hu/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}