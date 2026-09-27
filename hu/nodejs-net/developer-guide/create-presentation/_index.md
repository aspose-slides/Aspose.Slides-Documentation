---
title: Prezentációk létrehozása Node.js-en keresztül .NET segítségével
linktitle: Prezentáció létrehozása
type: docs
weight: 10
url: /hu/nodejs-net/create-presentation/
keywords:
- prezentáció létrehozása
- új prezentáció
- PowerPoint létrehozása
- PPTX létrehozása
- szövegdoboz hozzáadása
- dia hozzáadása
- dia mérete
- szélesvászon
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint prezentációk létrehozása JavaScript-ben az Aspose.Slides for Node.js via .NET segítségével: szövegdoboz és diák hozzáadása, 16:9-es dia méret beállítása, és az eredmény mentése PPTX formátumban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhatunk létre egy prezentációt az Aspose.Slides for Node.js via .NET segítségével, hogyan adhatunk szövegdobozt az első diára, és hogyan menthetjük el az eredményt PPTX fájlként. Emellett bemutatja, hogyan adhatunk hozzá további diákat, és hogyan állíthatjuk be a prezentációt szélesvásznú (16:9) diákra.

A példákhoz szükséges egy projekt, amelyet a [Installation](/slides/hu/nodejs-net/installation/) oldal leírása szerint kell beállítani. Minden példát mentsen `.js` fájlként a projekt mappájába, és futtassa onnan a `node` paranccsal, például `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for Node.js via .NET nem rendelkezik saját API hivatkozással. Az Aspose.Slides for .NET API-t tükrözi camelCase nevekkel, ezért ebben a cikkben szereplő API hivatkozások a [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/hu/net/) megfelelő osztályaira és tagjaira mutatnak.
{{% /alert %}}

## **Prezentáció létrehozása szövegdobozzal**

Egy prezentáció létrehozásához és szövegdoboz hozzáadásához az első diára kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból. Egy új prezentáció már tartalmaz egy üres diát.
2. Szerezze meg ezt a diát a [slides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slides/hu/) gyűjteményből. A gyűjtemények ebben a csomagban `get(index)`‑el olvashatók, és az indexelés 0‑tól indul.
3. Adjunk hozzá egy téglalapot a [addAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/shapecollection/addautoshape/) metódussal, és állítsuk be a [text](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/text/) értékét a [textFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/textframe/) tulajdonságában.
4. Mentsük el a prezentációt a [save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódussal és a `SaveFormat.Pptx` értékkel.
5. Hívja meg a `dispose`‑t egy `finally` blokkban a prezentációt támogató .NET erőforrások felszabadításához.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // A pozíció (x, y) és a méret (szélesség, magasság) pontokban van megadva.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

A szkript a `new-presentation.pptx` fájlt a projekt mappájába írja. A fájl egy diát tartalmaz, amelyen egy kitöltött téglalap van, melynek bal‑felső sarka 50 pont távolságra van a dia bal‑ és felső szélétől. A téglalap 400 pont széles és 100 pont magas, a szövege középre igazított. Egy pont 1/72 hüvelyk. Licenc nélkül az Aspose.Slides egy értékelő vízjelet is hozzáad a diához; lásd a [Licensing](/slides/hu/nodejs-net/licensing/) oldalt.

## **Diák hozzáadása**

Egy új prezentáció egyetlen diát tartalmaz. További diák hozzáadásához adjon át egy elrendezési diát a `slides` gyűjtemény [addEmptySlide](https://reference.aspose.com/slides/hu/net/aspose.slides/slidecollection/addemptyslide/) metódusának. A [layoutSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/layoutslides/) gyűjtemény [getByType](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutslidecollection/getbytype/) metódusa visszaadja az első olyan elrendezést, amely megfelel a megadott [SlideLayoutType](https://reference.aspose.com/slides/hu/net/aspose.slides/slidelayouttype/) értéknek.

Az alábbi példa két diát ad hozzá a Blank elrendezéssel:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A szkript kiírja, hogy `Slide count: 3`, és létrehozza a `three-slides.pptx` fájlt. Az új diák az első után kerülnek hozzáadásra, és nem tartalmaznak alakzatokat. Egy új prezentáció mindig tartalmaz Blank elrendezést, de egy fájlból megnyitott prezentációnak előfordulhat, hogy nincs a kért típusú elrendezése; ebben az esetben a `getByType` `null`‑t ad vissza, ezért a visszatérési értéket ellenőrizni kell, mielőtt továbbadnánk.

## **Dia méretének beállítása**

Egy új prezentáció 4:3 méretű diát használ, amely 720 × 540 pont (10 × 7,5 hüvelyk). Szélesvásznú diák létrehozásához hívja meg a prezentáció [slideSize](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slidesize/) tulajdonságának a [setSize](https://reference.aspose.com/slides/hu/net/aspose.slides/slidesize/setsize/) metódusát egy [SlideSizeType](https://reference.aspose.com/slides/hu/net/aspose.slides/slidesizetype/) és egy [SlideSizeScaleType](https://reference.aspose.com/slides/hu/net/aspose.slides/slidesizescaletype/) értékkel. A méretezési típus azt határozza meg, hogy az Aspose.Slides mit tegyen a már a diákon lévő alakzatokkal; a `DoNotScale` változat változatlanul hagyja őket, ami a még tartalom nélküli prezentációk esetén a helyes választás.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A szkript kiírja, hogy `Slide size: 960 x 540 points`, ami 13,33 × 7,5 hüvelyk, és létrehozza a `widescreen.pptx` fájlt. A `SlideSizeType.OnScreen16x9` ugyanazzal a 16:9 képaránnyal rendelkezik, de kisebb: 720 × 405 pont.

## **GYIK**

**Milyen egységben mérik a pozíciókat és méreteket?**

Pontban. Egy hüvelyk 72 pont, így az alapértelmezett 4:3 dia 720 × 540 pont, egy 16:9 szélesvásznú dia pedig 960 × 540 pont.

**Milyen formátumokba menthetem el az új prezentációt?**

A [SaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) enumeráció bármely értékét használhatja, például `SaveFormat.Ppt` a PowerPoint 97–2003‑hoz, `SaveFormat.Odp` az OpenDocument-hez, vagy `SaveFormat.Pdf`‑t. A PDF kimenethez lásd a [Convert PowerPoint to PDF](/slides/hu/nodejs-net/convert-powerpoint-to-pdf/) oldalt.

**Miért tartalmaz a mentett prezentáció "Evaluation only" szöveget?**

Licenc nélkül az Aspose.Slides egy értékelő vízjelet ad a mentett diákhoz. A vízjel eltávolításához alkalmazzon licencet a [Licensing](/slides/hu/nodejs-net/licensing/) leírása szerint.

**Miért kell meghívni a `dispose`‑t?**

A `Presentation` objektumot egy .NET objektum támasztja alá, amely memóriát és egyéb erőforrásokat foglal. A `dispose` meghívása felszabadítja ezeket, amint már nincs szükség a prezentációra, és egy `finally` blokkban történő hívás esetén még hiba esetén is felszabadulnak.