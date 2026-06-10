---
title: Betűtípusok beágyazása prezentációkba JavaScript használatával
linktitle: Betűtípus beágyazása
type: docs
weight: 40
url: /hu/nodejs-java/embedded-font/
keywords:
- betűtípus hozzáadása
- betűtípus beágyazása
- betűtípus beágyazás
- beágyazott betűtípus lekérése
- beágyazott betűtípus hozzáadása
- beágyazott betűtípus eltávolítása
- beágyazott betűtípus tömörítése
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "TrueType betűtípusok beágyazása PowerPoint és OpenDocument prezentációkba az Aspose.Slides for Node.js Java használatával, biztosítva a pontos megjelenítést minden platformon."
---
## **Bevezetés**

**A PowerPoint-be beágyazott betűtípusok** hasznosak, ha azt szeretné, hogy a prezentációja minden rendszerben vagy eszközön helyesen jelenjen meg. Ha egy külső vagy nem szabványos betűtípust használt, mert kreatív volt a munkájában, akkor még több oka van a betűtípus beágyazására. Ellenkező esetben (beágyazott betűtípusok nélkül) a diákon lévő szövegek vagy számok, az elrendezés, a stílus stb. megváltozhatnak, vagy zavaró téglalapokká alakulhatnak.  

A [FontsManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontsManager) osztály, a [FontData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontdata/) osztály, a [Compress](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/) osztály és azok osztályai a legtöbb tulajdonságot és metódust tartalmazzák, amelyekre a PowerPoint‑prezentációkban beágyazott betűtípusok kezeléséhez szüksége van.

## **Beágyazott betűtípusok lekérése vagy eltávolítása a prezentációból**

Az Aspose.Slides a [getEmbeddedFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) metódust (amelyet a [FontsManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontsManager) osztály biztosít) kínálja, hogy lekérdezhesse (vagy megtudja), mely betűtípusok vannak beágyazva egy prezentációban. A betűtípusok eltávolításához a [removeEmbeddedFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) metódus (ugyanazon osztályból) használható.

Ez a JavaScript‑kód megmutatja, hogyan kérhetők le és távolíthatók el a beágyazott betűtípusok egy prezentációból:

```javascript
// Egy Presentation objektumot hoz létre, amely egy prezentációs fájlt képvisel
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // Megjelenít egy diát, amely szövegdobozban tartalmazza a beágyazott "FunSized" betűtípust
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Mentse a képet a lemezen JPEG formátumban
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // Lekéri az összes beágyazott betűtípust
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // Megkeresi a "Calibri" betűtípust
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // Eltávolítja a "Calibri" betűtípust
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // Megjeleníti a prezentációt; "Calibri" betűtípus egy meglévő betűtípussal lesz helyettesítve
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Mentse a képet a lemezen JPEG formátumban
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Elmenti a prezentációt beágyazott "Calibri" betűtípus nélkül a lemezen
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Beágyazott betűtípusok hozzáadása a prezentációhoz**

Az [EmbedFontCharacters](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/embedfontcharacters/) enumeráció és a [addEmbeddedFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-) metódus két túlterhelése használatával kiválaszthatja a kívánt (beágyazási) szabályt a betűtípusok prezentációba történő beágyazásához. Ez a JavaScript‑kód megmutatja, hogyan ágyazhatók be és adhatók hozzá betűtípusok egy prezentációhoz:

```javascript
// Betölti a prezentációt
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // Elmenti a prezentációt a lemezen
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Beágyazott betűtípusok tömörítése**

Az Aspose.Slides a [compressEmbeddedFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) metódust (amelyet a [Compress](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/) osztály biztosít) kínálja, hogy lehetővé tegye a prezentációba beágyazott betűtípusok tömörítését és ezzel a fájlméret csökkentését.

Ez a JavaScript‑kód megmutatja, hogyan tömöríthetőek a beágyazott PowerPoint‑betűtípusok:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Hogyan ellenőrizhetem, hogy egy adott betűtípus a prezentációban a beágyazás ellenére is helyettesítésre kerül-e a renderelés során?**

Ellenőrizze a [substitution information](/slides/hu/nodejs-java/font-substitution/) pontot a betűtípus‑kezelőben és a [fallback/substitution rules](/slides/hu/nodejs-java/fallback-font/) szakaszt: ha a betűtípus nem érhető el vagy korlátozott, akkor tartalék betűtípust fognak használni.

**Érdemes beágyazni a „rendszer” betűtípusokat, mint például az Arial/Calibri?**

Általában nem – szinte mindig elérhetők. De „sovány” környezetekben (Docker, egy előre telepített betűtípusok nélküli Linux‑szerver) a rendszer‑betűtípusok beágyazása kiküszöbölheti a nem várt helyettesítések kockázatát.