---
title: Prezentációk renderelése tartalék betűtípusokkal JavaScriptben
linktitle: Prezentációk renderelése
type: docs
weight: 30
url: /hu/nodejs-java/render-presentation-with-fallback-font/
keywords:
- tartalék betűtípus
- PowerPoint renderelése
- prezentáció renderelése
- dia renderelése
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Renderelje a prezentációkat tartalék betűtípusokkal az Aspose.Slides for Node.js segítségével – tartsa a szöveget konzisztensen a PPT, PPTX és ODP formátumokban lépésről lépésre bemutatott JavaScript kódmintákkal."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy a bemutatókat tartalék betűtípus szabályokkal renderelje. Ez a cikk bemutatja, hogyan hozhat létre egy tartalék betűtípus szabályok gyűjteményét, hogyan módosíthatja annak szabályait a tartalék betűtípusok eltávolításával vagy hozzáadásával, és hogyan rendeli hozzá a gyűjteményt a `FontsManager.setFontFallBackRulesCollection` metódussal.

Miután a tartalék betűtípus szabályok gyűjteményét hozzárendelték a bemutató `FontsManager`-éhez, a szabályok alkalmazva lesznek olyan műveletek során, mint a mentés, a renderelés és a bemutató konvertálása. A példa bemutatja, hogyan használhatók a konfigurált szabályok egy dia bélyegképének renderelésekor és PNG‑képként történő mentésekor.

## **Dia renderelése tartalék betűtípus szabályokkal**

A következő példa ezeket a lépéseket tartalmazza:

1. Létrehozzuk a [tartalék betűtípus szabályok gyűjteményét](/slides/hu/nodejs-java/create-fallback-fonts-collection/).
1. [Eltávolít](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) egy tartalék betűtípus szabályt és [addFallBackFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) egy másik szabályhoz.
1. Állítsuk be a szabályok gyűjteményét a [getFontsManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) metódusra.
1. A [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) metódussal menthetjük a bemutatót ugyanabban a formátumban, vagy másikban. Miután a tartalék betűtípus szabályok gyűjteményét beállítottuk a [FontsManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontsManager) elemhez, ezek a szabályok minden bemutatóval végzett műveletnél alkalmazásra kerülnek: mentés, renderelés, konvertálás stb.

```javascript
// Új példány létrehozása a szabálygyűjteményből
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// számos szabály létrehozása
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // Megpróbáljuk eltávolítani a "Tahoma" tartalék betűtípust a betöltött szabályokból
    fallBackRule.remove("Tahoma");
    // És a szabályok frissítése a megadott tartományra
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// Ezen felül eltávolíthatunk bármely meglévő szabályt a listáról
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Előkészített szabálygyűjtemény hozzárendelése a használathoz
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // Miniatűr renderelése a inicializált szabálygyűjtemény használatával és mentése JPEG-be
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Kép mentése a lemezre JPEG formátumban
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Olvasson tovább arról, hogyan kell [PPT és PPTX konvertálása JPG-be JavaScriptben](/slides/hu/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}