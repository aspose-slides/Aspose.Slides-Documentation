---
title: Alapértelmezett bemutató betűtípusok megadása Androidon
linktitle: Alapértelmezett betűtípus
type: docs
weight: 30
url: /hu/androidjava/default-font/
keywords:
- alapértelmezett betűtípus
- normál betűtípus
- normál betűtípus
- ázsiai betűtípus
- PDF export
- XPS export
- kép export
- PowerPoint
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "Állítsa be az alapértelmezett betűtípusokat az Aspose.Slides for Android Java használatával, hogy a PowerPoint (PPT, PPTX) és OpenDocument (ODP) megfelelően konvertálódjon PDF‑re, XPS‑re és képekre."
---
## **Overview**

Az Aspose.Slides lehetővé teszi, hogy megadja az alapértelmezett betűtípusokat, amelyeket a bemutató renderelésekor használnak. Ez hasznos diakép előnézetek generálásakor vagy a bemutató exportálásakor olyan formátumokba, mint a PDF és az XPS. Az alapértelmezett betűtípusok a `LoadOptions` segítségével konfigurálhatók, mielőtt a bemutatót betöltenék.

A `setDefaultRegularFont` metódus határozza meg az alapértelmezett betűtípust a szabályos szöveghez, míg a `setDefaultAsianFont` az ázsiai szöveghez. Ezek után a bemutató betölthető és renderelhető a megadott betűtípusokkal.

## **Use Default Fonts for Rendering a Presentation**
Az Aspose.Slides lehetővé teszi, hogy beállítsa az alapértelmezett betűtípust a bemutató PDF, XPS vagy előnézeti képek formátumba történő rendereléséhez. Ez a cikk bemutatja, hogyan definiálhatók a DefaultRegular Font és a DefaultAsian Font alapértelmezett betűtípusokként. Kérjük, kövesse az alábbi lépéseket a betűtípusok külső könyvtárakból történő betöltéséhez az Aspose.Slides for Android Java API-jának használatával:

1. Hozzon létre egy példányt a [LoadOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LoadOptions) osztályból.  
1. [Állítsa be a DefaultRegularFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) a kívánt betűtípusra. Az alábbi példában a Wingdings-et használtam.  
1. [Állítsa be a DefaultAsianFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) a kívánt betűtípusra. Az alábbi példában a Wingdings-et használtam.  
1. Töltsön be egy bemutatót a Presentation osztály és a betöltési beállítások használatával.  
1. Ezután generálja a diakép előnézetet, a PDF-et és az XPS-et az eredmények ellenőrzéséhez.

A fenti megvalósítás alább található.

```java
// Használja a betöltési beállításokat az alapértelmezett szabályos és ázsiai betűtípusok meghatározásához
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Töltse be a bemutatót
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Generálja a dia előnézeti képet
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // mentse a képet a lemezre.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Generálja a PDF-et
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Generálja az XPS-et
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**What exactly do DefaultRegularFont and DefaultAsianFont affect—only export, or also thumbnails, PDF, XPS, HTML, and SVG?**

Részt vesznek a renderelési csővezetékben az összes támogatott kimenetnél. Ez magában foglalja a diakép előnézeteket, a [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/), a [XPS](/slides/hu/androidjava/convert-powerpoint-to-xps/), a [raster images](/slides/hu/androidjava/convert-powerpoint-to-png/), a [HTML](/slides/hu/androidjava/convert-powerpoint-to-html/), és a [SVG](/slides/hu/androidjava/render-a-slide-as-an-svg-image/), mivel az Aspose.Slides ugyanazt a elrendezési és glif feloldási logikát használja ezeken a célokon.

**Are default fonts applied when simply reading and saving a PPTX without any rendering?**

Nem. Az alapértelmezett betűtípusok csak akkor számítanak, ha a szöveget mérni és megrajzolni kell. Egy egyszerű megnyitás‑mentés nem változtatja meg a tárolt betűtípus‑futamokat vagy a fájl szerkezetét. Az alapértelmezett betűtípusok akkor lépnek működésbe, amikor a szöveget renderelik vagy újraoldalazzák.

**If I add my own font folders or supply fonts from memory, will they be considered when choosing default fonts?**

Igen. A [Custom font sources](/slides/hu/androidjava/custom-font/) kibővíti a rendelkezésre álló családok és glifek katalógusát, amelyeket a motor használhat. Az alapértelmezett betűtípusok és minden [fallback rules](/slides/hu/androidjava/fallback-font/) először ezeken a forrásokon keresztül próbálják feloldani, ami megbízhatóbb lefedettséget biztosít a szervereken és konténerekben.

**Will default fonts affect text metrics (kerning, advances) and therefore line breaks and wrapping?**

Igen. A betűtípus megváltoztatása módosítja a glif metrikákat, és befolyásolhatja a sortöréseket, a szövegbefuttatást és a lapozást a renderelés során. A layout stabilitás érdekében [embed the original fonts](/slides/hu/androidjava/embedded-font/) vagy válasszon metrikailag kompatibilis alapértelmezett és fallback családokat.

**Is there any point in setting default fonts if all fonts used in the presentation are embedded?**

Gyakran nincs rá szükség, mivel a [embedded fonts](/slides/hu/androidjava/embedded-font/) már biztosítják a konzisztens megjelenést. Az alapértelmezett betűtípusok továbbra is hasznosak biztonsági hálóként azoknál a karaktereknél, amelyeket a beágyazott részhalmaz nem fed le, vagy ha egy fájl kevert beágyazott és nem beágyazott szöveget tartalmaz.