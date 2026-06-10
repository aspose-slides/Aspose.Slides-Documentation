---
title: Betűtípusok beágyazása prezentációkba .NET-ben
linktitle: Betűtípus beágyazása
type: docs
weight: 40
url: /hu/net/embedded-font/
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
- .NET
- C#
- Aspose.Slides
description: "TrueType betűtípusok beágyazása PowerPoint és OpenDocument prezentációkba az Aspose.Slides for .NET segítségével, biztosítva a pontos megjelenítést minden platformon."
---
## **Bevezetés**

**A betűtípusok beágyazása a PowerPointba** biztosítja, hogy a bemutató megjelenése minden rendszeren változatlan maradjon. Legyen szó kreatív egyedi betűtípusokról vagy szabványosakról, a betűtípusok beágyazása megakadályozza a szöveg és az elrendezés eltorzulását.

Ha egy harmadik féltől származó vagy nem szabványos betűtípust használtál, mert kreatívan dolgoztál, akkor még több oka van a betűtípus beágyazására. Ellenkező esetben (beágyazott betűtípusok nélkül) a diákon lévő szövegek vagy számok, az elrendezés, a stílusok stb. megváltozhatnak vagy zavaró téglalapokká alakulhatnak.

Használd a [FontsManager](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/hu/net/aspose.slides/fontdata/), és [Compress](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/) osztályokat a beágyazott betűtípusok kezeléséhez.

## **Beágyazott betűtípusok lekérése és eltávolítása**

A beágyazott betűtípusok egyszerű lekéréséhez vagy eltávolításához a prezentációból használhatod a [GetEmbeddedFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/getembeddedfonts) és a [RemoveEmbeddedFont](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/removeembeddedfont) metódusokat.

Ez a C# kód megmutatja, hogyan lehet lekérni és eltávolítani a beágyazott betűtípusokat egy prezentációból:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Megjeleníti azt a diát, amely szövegkeretet tartalmaz, és beágyazott "FunSized" betűtípust használ
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Megkeresi a "Calibri" betűtípust
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Eltávolítja a "Calibri" betűtípust
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Megjeleníti a prezentációt; a "Calibri" betűtípust egy létező betűtípus helyettesíti
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Elmenti a prezentációt a beágyazott "Calibri" betűtípus nélkül a lemezre
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Beágyazott betűtípusok hozzáadása**

Az [EmbedFontCharacters](https://reference.aspose.com/slides/hu/net/aspose.slides.export/embedfontcharacters/) enumeráció és a [AddEmbeddedFont](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/addembeddedfont/) metódus két túlterhelése segítségével kiválaszthatod a kívánt (beágyazási) szabályt a betűtípusok prezentációba való beágyazásához. Ez a C# kód megmutatja, hogyan kell beágyazni és hozzáadni a betűtípusokat egy prezentációhoz:

```c#
// Betölti a prezentációt
Presentation presentation = new Presentation("Fonts.pptx");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// Elmenti a prezentációt a lemezre
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **Beágyazott betűtípusok tömörítése**

Optimalizáld a fájlméretet a beágyazott betűtípusok tömörítésével a [CompressEmbeddedFonts](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/compressembeddedfonts/) segítségével.

Példa kód a tömörítéshez:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Hogyan tudom megállapítani, hogy egy adott betűtípust a prezentációban a megjelenítés során még mindig helyettesíti a rendszer a beágyazás ellenére?**

Ellenőrizd a [helyettesítési információ](/slides/hu/net/font-substitution/) a betűtípuskezelőben és a [fallback/helyettesítési szabályok](/slides/hu/net/fallback-font/): ha a betűtípus nem elérhető vagy korlátozott, egy helyettesítő lesz használva.

**Megéri-e a "rendszer" betűtípusok, például az Arial/Calibri beágyazása?**

Általában nem – ezek szinte mindig elérhetők. De egy "vékony" környezetben (Docker, előre telepített betűtípusok nélküli Linux szerver) a rendszerbetűtípusok beágyazása kiküszöbölheti a váratlan helyettesítések kockázatát.