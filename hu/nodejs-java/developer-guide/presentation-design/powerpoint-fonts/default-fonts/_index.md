---
title: Alapértelmezett prezentációs betűtípusok megadása JavaScriptben
linktitle: Alapértelmezett betűtípus
type: docs
weight: 30
url: /hu/nodejs-java/default-font/
keywords:
- alapértelmezett betűtípus
- normál betűtípus
- szabványos betűtípus
- ázsiai betűtípus
- PDF export
- XPS export
- kép export
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Állítsa be az alapértelmezett betűtípusokat az Aspose.Slides for Node.js‑ben Java segítségével, hogy biztosítsa a PowerPoint (PPT, PPTX) és OpenDocument (ODP) helyes konvertálását PDF‑be, XPS‑be és képekbe."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi alapértelmezett betűtípusok megadását, amelyeket a prezentáció renderelésekor használnak. Ez hasznos diakép‑miniatűrök generálásakor vagy a prezentáció PDF és XPS formátumokra való exportálásakor. Az alapértelmezett betűtípusok a `LoadOptions` segítségével konfigurálhatók, mielőtt a prezentáció betöltésre kerül.

A `setDefaultRegularFont` metódus határozza meg az alapértelmezett betűtípust a normál szöveghez, míg a `setDefaultAsianFont` az ázsiai szöveghez használatos alapértelmezett betűtípust. Ezeknek a beállításoknak a megadása után a prezentáció betölthető és a megadott betűtípusokkal renderelhető.

## **Alapértelmezett betűtípusok használata a prezentáció rendereléséhez**
Az Aspose.Slides lehetővé teszi az alapértelmezett betűtípus beállítását a prezentáció PDF, XPS vagy miniatűrök formátumba történő rendereléséhez. Ez a cikk bemutatja, hogyan definiálhatók a DefaultRegularFont és a DefaultAsianFont alapértelmezett betűtípusokként. Kövesse az alábbi lépéseket a betűtípusok külső könyvtárakból történő betöltéséhez az Aspose.Slides for Node.js via Java API használatával:

1. Hozzon létre egy példányt a [LoadOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/LoadOptions) osztályból.
1. Állítsa be a [DefaultRegularFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) értékét a kívánt betűtípusra. Az alábbi példában a Wingdings-et használtam.
1. Állítsa be a [DefaultAsianFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) értékét a kívánt betűtípusra. A következő mintában szintén a Wingdings-et használtam.
1. Töltse be a prezentációt a Presentation osztállyal és a betöltési beállításokkal.
1. Ezután generálja le a diák miniatűrjét, PDF-et és XPS-et, hogy ellenőrizze az eredményeket.

A fenti megvalósítás alább látható.

```javascript
// Használja a betöltési beállításokat az alapértelmezett normál és ázsiai betűtípusok meghatározásához
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Töltse be a prezentációt
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Generálja a dia miniatűrjét
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // Mentse a képet a lemezen.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Generálja a PDF-et
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // Generálja az XPS-et
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Pontosan milyen kimenetekre hat a DefaultRegularFont és a DefaultAsianFont – csak az exportálásra, vagy a miniatűrökre, PDF‑re, XPS‑re, HTML‑re és SVG‑re is?**

Az összes támogatott kimenet renderelési csővezetékében részt vesznek. Ide tartoznak a diaminatűrök, a [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/), a [XPS](/slides/hu/nodejs-java/convert-powerpoint-to-xps/), a [raszteres képek](/slides/hu/nodejs-java/convert-powerpoint-to-png/), a [HTML](/slides/hu/nodejs-java/convert-powerpoint-to-html/), és az [SVG](/slides/hu/nodejs-java/render-a-slide-as-an-svg-image/), mivel az Aspose.Slides ugyanazt a layout és glif feloldási logikát használja ezekhez a célokhoz.

**Alapértelmezett betűtípusok érvényesülnek, ha csak beolvasunk és elmentünk egy PPTX‑et anélkül, hogy renderelnénk?**

Nem. Az alapértelmezett betűtípusok csak akkor számítanak, amikor a szöveget mérni és rajzolni kell. Egy egyszerű nyitás‑mentés nem módosítja a tárolt betűtípus‑futásokat vagy a fájl struktúráját. Az alapértelmezett betűtípusok olyan műveletek során lépnek életbe, amelyek renderelnek vagy szöveget újraformáznak.

**Ha saját betűtípus‑könyvtárakat adok hozzá vagy memóriából biztosítok betűtípusokat, figyelembe veszik ezeket az alapértelmezett betűtípusok kiválasztásakor?**

Igen. A [Custom font sources](/slides/hu/nodejs-java/custom-font/) kibővítik a rendelkezésre álló családok és glifek katalógusát, amelyet a motor használhat. Az alapértelmezett betűtípusok és a [fallback rules](/slides/hu/nodejs-java/fallback-font/) először ezeken a forrásokon keresztül oldanak meg, így megbízhatóbb lefedettséget biztosítanak szervereken és konténerekben.

**Az alapértelmezett betűtípusok befolyásolják a szövegmetrikákat (kerning, advance) és ezáltal a sortöréseket és a szövegcsomagolást?**

Igen. A betűtípus megváltoztatása módosítja a glif metrikákat, ami befolyásolhatja a sortöréseket, a szövegcsomagolást és a lapozást a renderelés során. A layout stabilitása érdekében [ágyazzuk be az eredeti betűtípusokat](/slides/hu/nodejs-java/embedded-font/) vagy válasszunk metrikailag kompatibilis alapértelmezett és helyettesítő családokat.

**Van értelme alapértelmezett betűtípusokat beállítani, ha a prezentációban használt összes betűtípus be van ágyazva?**

Gyakran nincs rá szükség, mivel a [embedded fonts](/slides/hu/nodejs-java/embedded-font/) már biztosítják a konzisztens megjelenést. Az alapértelmezett betűtípusok továbbra is hasznosak lehetnek biztonsági hálóként azokhoz a karakterekhez, amelyeket a beágyazott alhalmaz nem fed le, vagy ha egy fájl vegyesen tartalmaz beágyazott és nem beágyazott szöveget.