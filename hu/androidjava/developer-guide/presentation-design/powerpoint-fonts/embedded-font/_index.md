---
title: Betűtípusok beágyazása prezentációkba Androidon
linktitle: Betűtípus beágyazása
type: docs
weight: 40
url: /hu/androidjava/embedded-font/
keywords:
- betűtípus hozzáadása
- betűtípus beágyazása
- betűtípus beágyazás
- beágyazott betűtípus lekérdezése
- beágyazott betűtípus hozzáadása
- beágyazott betűtípus eltávolítása
- beágyazott betűtípus tömörítése
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "TrueType betűtípusok beágyazása PowerPoint és OpenDocument prezentációkba az Androidra készült Aspose.Slides Java használatával, biztosítva a pontos megjelenítést minden platformon."
---
## **Bevezetés**

**Beágyazott betűtípusok a PowerPointban** hasznosak, ha azt szeretné, hogy a bemutatója minden rendszeren vagy eszközön helyesen jelenjen meg. Ha harmadik féltől származó vagy nem szabványos betűtípust használt, mert kreatív volt a munkájában, akkor még több oka van a betűtípus beágyazására. Ellenkező esetben (beágyazott betűtípusok nélkül) a diákon lévő szövegek vagy számok, az elrendezés, a stílus stb. megváltozhatnak vagy zavaró téglalapokká alakulhatnak. 

A [FontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontsManager) osztály, a [FontData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontdata/) osztály, a [Compress](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/) osztály és azok interfészei tartalmazzák a legtöbb tulajdonságot és metódust, amelyekre a PowerPoint‑bemutatók beágyazott betűtípusaival való munka során szüksége van.

## **Beágyazott betűtípusok lekérése és eltávolítása**

Az Aspose.Slides a [getEmbeddedFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) metódust (a [FontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontsManager) osztály által biztosítva) kínálja, amely lehetővé teszi a bemutatóban beágyazott betűtípusok lekérését (vagy megtudását). A betűtípusok eltávolításához a [removeEmbeddedFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) metódust (ugyanazon osztály által) használják.

Ez a Java kód bemutatja, hogyan lehet beágyazott betűtípusokat lekérni és eltávolítani egy bemutatóból:

```java
// Egy Presentation objektumot hoz létre, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Renderel egy diát, amely szövegkeretet tartalmaz, ami beágyazott "FunSized" betűtípust használ
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //A képet JPEG formátumban menti le a lemezre
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

    // Rendereli a prezentációt; a "Calibri" betűtípus helyettesítve van egy meglévővel
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //A képet JPEG formátumban menti le a lemezre
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Mentse a prezentációt a beágyazott "Calibri" betűtípus nélkül a lemezre
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Beágyazott betűtípusok hozzáadása**

Az [EmbedFontCharacters](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/embedfontcharacters/) felsorolt típus és a [addEmbeddedFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) metódus két túlterhelése segítségével kiválaszthatja a kívánt (beágyazási) szabályt a betűtípusok bemutatóba való beágyazásához. Ez a Java kód bemutatja, hogyan lehet betűtípusokat beágyazni és hozzáadni egy bemutatóhoz:

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

    // Mentse a prezentációt a lemezre
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Beágyazott betűtípusok tömörítése**

Annak érdekében, hogy a bemutatóban beágyazott betűtípusokat tömöríthesse és csökkentse a fájlméretét, az Aspose.Slides a [compressEmbeddedFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) metódust (a [Compress](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/) osztály által) biztosítja.

Ez a Java kód bemutatja, hogyan lehet beágyazott PowerPoint betűtípusokat tömöríteni:

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

**Hogyan tudom megállapítani, hogy a bemutató egy adott betűtípusa a renderelés során továbbra is helyettesítésre kerül a beágyazás ellenére?**

Ellenőrizze a [helyettesítési információkat](/slides/hu/androidjava/font-substitution/) a betűtípus‑kezelőben, valamint a [visszaesési/helyettesítési szabályokat](/slides/hu/androidjava/fallback-font/): ha a betűtípus nem érhető el vagy korlátozott, egy helyettesítő kerül felhasználásra.

**Érdemes „rendszer” betűtípusokat, például az Arial‑t vagy a Calibri‑t beágyazni?**

Általában nem – ezek szinte mindig rendelkezésre állnak. Azonban „sovány” környezetekben (Docker, előre telepített betűtípusok nélküli Linux‑szerver) a rendszer‑betűtípusok beágyazása kiküszöbölheti a váratlan helyettesítések kockázatát.