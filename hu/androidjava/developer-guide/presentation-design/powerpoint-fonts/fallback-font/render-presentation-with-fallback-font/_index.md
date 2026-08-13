---
title: Prezentációk renderelése tartalék betűkészletekkel Androidon
linktitle: Prezentációk renderelése
type: docs
weight: 30
url: /hu/androidjava/render-presentation-with-fallback-font/
keywords:
- tartalék betűkészlet
- PowerPoint renderelése
- prezentáció renderelése
- dia renderelése
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Prezentációk renderelése tartalék betűkészletekkel az Androidra készült Aspose.Slides-ben – biztosítsa a szöveg konzisztenciáját a PPT, PPTX és ODP formátumok között lépésről-lépésre Java kódmintákkal."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy a prezentációkat tartalék betűkészlet szabályok használatával renderelje. Ez a cikk bemutatja, hogyan hozhat létre egy tartalék betűkészlet szabálygyűjteményt, hogyan módosíthatja annak szabályait eltávolítással vagy tartalék betűkészletek hozzáadásával, valamint hogyan rendelheti hozzá a gyűjteményt a `FontsManager.setFontFallBackRulesCollection` metódus segítségével.

Miután a tartalék betűkészlet szabálygyűjteményt a prezentáció `FontsManager`‑ehez rendelték, a szabályok a mentés, a renderelés és a prezentáció konvertálása során kerülnek alkalmazásra. A példa bemutatja, hogyan használható a konfigurált szabályok egy dia bélyegképének renderelésekor és annak JPEG képként való mentésekor.

## **Dia renderelése tartalék betűkészlet szabályokkal**

Az alábbi példa ezeket a lépéseket tartalmazza:

1. Létrehozzuk a [tartalék betűkészlet szabálygyűjtemény](/slides/hu/androidjava/create-fallback-fonts-collection/).
1. [Eltávolítás](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) egy tartalék betűkészlet szabályt, és [addFallBackFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) egy másik szabályhoz.
1. Állítsuk be a szabálygyűjteményt a [getFontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) metódussal.
1. A [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) metódussal elmenthetjük a prezentációt ugyanabban a formátumban, vagy másikban. Miután a tartalék betűkészlet szabálygyűjtemény be van állítva a [FontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontsManager) objektumra, ezek a szabályok minden prezentáción végzett műveletnél alkalmazásra kerülnek: mentés, renderelés, konvertálás stb.

```java
import com.aspose.slides.*;

// Új szabálygyűjtemény példány létrehozása
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// szabályok létrehozása
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // A betöltött szabályokból a "Tahoma" tartalék betűkészlet eltávolítása
    fallBackRule.remove("Tahoma");

    // A megadott tartomány szabályainak frissítése
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// Szintén eltávolíthatunk minden meglévő szabályt a listáról, legalább egy szabályt megtartva a rendereléshez
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // Előre elkészített szabálygyűjtemény hozzárendelése a használathoz
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Bélyegkép renderelése a betöltött szabálygyűjtemény használatával és mentése JPEG formátumban
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

{{% alert color="info" %}} 
További információ a [PPT és PPTX konvertálása JPG-re Androidon](/slides/hu/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}