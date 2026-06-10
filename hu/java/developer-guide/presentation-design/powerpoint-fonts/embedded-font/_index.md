---
title: Betűtípusok beágyazása prezentációkba Java-val
linktitle: Betűtípus beágyazása
type: docs
weight: 40
url: /hu/java/embedded-font/
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
- Java
- Aspose.Slides
description: "Betűtípusok beágyazása TrueType formátumban PowerPoint és OpenDocument prezentációkba az Aspose.Slides for Java segítségével, biztosítva a pontos megjelenítést minden platformon."
---
## **Bevezetés**

**Beágyazott betűtípusok a PowerPoint‑ben** akkor hasznosak, ha azt szeretnéd, hogy a prezentációd minden rendszerben vagy eszközön helyesen jelenjen meg. Ha egy harmadik fél vagy nem szabványos betűtípust használtál, mert kreatívan dolgoztál, akkor még több okod van a betűtípus beágyazására. Ellenkező esetben (beágyazott betűtípusok nélkül) a diákon lévő szövegek vagy számok, az elrendezés, a stílus stb. megváltozhatnak, vagy zavaró téglalapokká alakulhatnak.  

A [FontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsManager) osztály, a [FontData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontdata/) osztály, a [Compress](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/) osztály és azok interfészei tartalmazzák a beágyazott betűtípusokkal való munka során szükséges legtöbb tulajdonságot és metódust a PowerPoint‑prezentációkban. 

## **Beágyazott betűtípusok lekérése és eltávolítása**

Az Aspose.Slides biztosítja a [getEmbeddedFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) metódust (a FontsManager osztály által kiadott), hogy lekérdezd (vagy megtudd), mely betűtípusok vannak beágyazva egy prezentációban. A betűtípusok eltávolításához a [removeEmbeddedFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) metódust (ugyanazzal az osztállyal) használjuk.

Ez a Java kód megmutatja, hogyan kérheted le és távolíthatod el a beágyazott betűtípusokat egy prezentációból:

```java
// Létrehoz egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Megjelenít egy diát, amely szövegkeretet tartalmaz, és beágyazott "FunSized" betűtípust használ
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //A képet JPEG formátumban menti a lemezen
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Lekéri az összes beágyazott betűtípust
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Megkeresi a "Calibri" betűtípust
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Eltávolítja a "Calibri" betűtípust
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Megjeleníti a prezentációt; a "Calibri" betűtípust egy meglévőre cseréli
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //A képet JPEG formátumban menti a lemezen
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // A prezentációt a beágyazott "Calibri" betűtípus nélkül menti a lemezen
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Beágyazott betűtípusok hozzáadása**

Az [EmbedFontCharacters](https://reference.aspose.com/slides/hu/java/com.aspose.slides/embedfontcharacters/) enum és az [addEmbeddedFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) metódus két túlterhelése segítségével kiválaszthatod a kívánt (beágyazási) szabályt a betűtípusok prezentációba való beágyazásához. Ez a Java kód megmutatja, hogyan ágyazhatod be és adhatod hozzá a betűtípusokat egy prezentációhoz:

```java
// Betölti a prezentációt
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // A prezentációt a lemezen menti
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Beágyazott betűtípusok tömörítése**

A prezentációba beágyazott betűtípusok tömörítéséhez és a fájlméret csökkentéséhez az Aspose.Slides biztosítja a [compressEmbeddedFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) metódust (a Compress osztály által kiadott).

Ez a Java kód megmutatja, hogyan tömörítheted a beágyazott PowerPoint betűtípusokat:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Hogyan tudom megállapítani, hogy egy adott betűtípus a prezentációban a beágyazás ellenére is helyettesítésre kerül a megjelenítés során?**

Ellenőrizd a [substitution information](/slides/hu/java/font-substitution/) a betűtípus‑kezelőben és a [fallback/substitution rules](/slides/hu/java/fallback-font/)‑t: ha a betűtípus nem érhető el vagy korlátozott, egy visszaeső betűtípus lesz használva.

**Megéri a "rendszer" betűtípusokat, például az Arialt/Calibrit beágyazni?**

Általában nem — ezek szinte mindig elérhetők. De a teljes hordozhatóság érdekében „vékony” környezetekben (Docker, egy előre telepített betűtípusok nélküli Linux szerver), a rendszerbetűtípusok beágyazása kiküszöbölheti a váratlan helyettesítések kockázatát.