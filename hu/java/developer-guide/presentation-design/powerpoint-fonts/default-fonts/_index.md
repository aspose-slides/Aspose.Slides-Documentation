---
title: Alapértelmezett prezentációs betűtípusok megadása Java-ban
linktitle: Alapértelmezett betűtípus
type: docs
weight: 30
url: /hu/java/default-font/
keywords:
- alapértelmezett betűtípus
- normál betűtípus
- szabványos betűtípus
- ázsiai betűtípus
- PDF exportálás
- XPS exportálás
- kép exportálás
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Állítsa be az alapértelmezett betűtípusokat az Aspose.Slides for Java-ban, hogy a PowerPoint (PPT, PPTX) és OpenDocument (ODP) konverziók PDF-re, XPS-re és képekre megfelelően történjenek."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy megadja az alapértelmezett betűtípusokat, amelyeket a prezentáció renderelésekor használnak. Ez akkor hasznos, amikor diaképminiatűröket generál vagy egy prezentációt exportál PDF vagy XPS formátumokba. Az alapértelmezett betűtípusok a `LoadOptions` segítségével vannak beállítva, mielőtt a prezentáció betöltésre kerül.

A `setDefaultRegularFont` metódus határozza meg az alapértelmezett betűtípust a normál szöveghez, míg a `setDefaultAsianFont` az ázsiai szöveg alapértelmezett betűtípusát definiálja. Ezek beállítása után a prezentáció betölthető és renderelhető a megadott betűtípusokkal.

## **Alapértelmezett betűtípusok használata a prezentáció rendereléséhez**
Az Aspose.Slides lehetővé teszi, hogy beállítsa az alapértelmezett betűtípust a prezentáció PDF, XPS vagy miniatűrök formátumba történő rendereléséhez. Ez a cikk bemutatja, hogyan definiálja a DefaultRegular Font és a DefaultAsian Font értékeket alapértelmezett betűtípusként. Kérjük, kövesse az alábbi lépéseket a betűtípusok külső könyvtárakból való betöltéséhez az Aspose.Slides for Java API használatával:

1. Hozzon létre egy példányt a [LoadOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LoadOptions) osztályból.
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) a kívánt betűtípusra. Az alábbi példában a Wingdings-et használtam.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) a kívánt betűtípusra. A következő mintában a Wingdings-et használtam.
1. Töltse be a prezentációt a Presentation osztály segítségével, és állítsa be a betöltési opciókat.
1. Ezután generálja a dia miniatűröket, PDF-et és XPS-t a eredmények ellenőrzéséhez.

A fentiek megvalósítása alább látható.

```java
// Használja a betöltési beállításokat az alapértelmezett normál és ázsiai betűtípusok meghatározásához
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Töltsük be a prezentációt
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Készítsen diakép-miniatűröt
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // Mentse a képet a lemezre.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Készítsen PDF-et
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Készítsen XPS-t
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Mire hat a DefaultRegularFont és a DefaultAsianFont – csak az exportálásra, vagy a miniatűrökre, PDF-re, XPS-re, HTML-re és SVG-re is?**

Részt vesznek a renderelési folyamatban minden támogatott kimenetnél. Ez magában foglalja a dia miniatűröket, [PDF](/slides/hu/java/convert-powerpoint-to-pdf/), [XPS](/slides/hu/java/convert-powerpoint-to-xps/), [raster images](/slides/hu/java/convert-powerpoint-to-png/), [HTML](/slides/hu/java/convert-powerpoint-to-html/), és [SVG](/slides/hu/java/render-a-slide-as-an-svg-image/) kimeneteket, mivel az Aspose.Slides ugyanazt a layout és glif feloldási logikát használja ezeknél a céloknál.

**Alkalmazódnak az alapértelmezett betűtípusok egyszerűen egy PPTX beolvasásakor és mentésekor, anélkül hogy renderelnénk?**

Nem. Az alapértelmezett betűtípusok csak akkor számítanak, amikor a szöveget mérni és rajzolni kell. Egy egyszerű nyílt‑mentés nem változtatja meg a tárolt betűtípus futamokat vagy a fájl szerkezetét. Az alapértelmezett betűtípusok akkor lépnek életbe, amikor a műveletek renderelnek vagy újra áramolják a szöveget.

**Ha saját betűtípus mappákat adok hozzá vagy memóriából biztosítok betűtípusokat, figyelembe veszik őket az alapértelmezett betűtípusok választásánál?**

Igen. [Egyéni betűtípus források](/slides/hu/java/custom-font/) bővítik a rendelkezésre álló családok és glifek katalógusát, amelyet a motor használhat. Az alapértelmezett betűtípusok és bármely [visszalépési szabályok](/slides/hu/java/fallback-font/) előbb ezekből a forrásokból fognak feloldódni, így megbízhatóbb lefedettséget biztosítva szervereken és konténerekben.

**Befolyásolja-e az alapértelmezett betűtípus a szöveg metrikáit (kerning, advances), és ezáltal a sortöréseket és a tördelést?**

Igen. A betűtípus cseréje megváltoztatja a glif metrikákat, és befolyásolhatja a sortöréseket, a szöveg megtörését és a lapozást renderelés közben. A layout stabilitásáért [ágyazzuk be az eredeti betűtípusokat](/slides/hu/java/embedded-font/) vagy válasszon metrikailag kompatibilis alapértelmezett és visszalépő családokat.

**Van értelme alapértelmezett betűtípusokat beállítani, ha a prezentáció minden betűtípusa be van ágyazva?**

Gyakran nincs rá szükség, mivel a [beágyazott betűtípusok](/slides/hu/java/embedded-font/) már biztosítják a következetes megjelenést. Az alapértelmezett betűtípusok még mindig hasznosak biztonsági hálóként a beágyazott részhalmaz által nem lefedett karakterekhez, vagy amikor egy fájl keveri a beágyazott és nem beágyazott szöveget.