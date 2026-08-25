---
title: Alacsony kódú prezentációs műveletek JavaScript-ben
linktitle: Alacsony kódú API
type: docs
weight: 50
url: /hu/nodejs-java/low-code-presentation-operations/
keywords:
- alacsony kódú prezentáció API
- prezentáció konvertálása
- prezentációk egyesítése
- diák iterálása
- alakzatok iterálása
- szöveg iterálása
- alakzatok gyűjtése
- prezentáció tömörítése
- nem használt mesterségek eltávolítása
- nem használt elrendezések eltávolítása
- beágyazott betűtípusok tömörítése
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Használja az Aspose.Slides alacsony kódú API-t JavaScript-ben a prezentációk konvertálásához és egyesítéséhez, a tartalom bejárásához, alakzatok gyűjtéséhez és a prezentáció méretének csökkentéséhez."
---
## **Áttekintés**

`aspose.slides` névtér statikus segédosztályokat biztosít a gyakori bemutató-műveletekhez. Ezek a segédprogramok a gyakran használt objektummodell munkafolyamatokat fókuszált metódusokba csomagolják, így kevesebb kóddal konvertálhat vagy egyesíthet fájlokat, feldolgozhatja a bemutatóelemeket, gyűjtheti az alakzatokat, és eltávolíthatja a nem használt tartalmat.

Az alacsony kódú segédprogramok a leghasznosabbak, amikor a művelet egy teljes fájlra vagy bemutatóra vonatkozik, és az alapértelmezett munkafolyamat megfelel az igényeinek. Használja a teljes [Aspose.Slides objektummodellt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/) amikor finomhangolt vezérlésre van szükség az egyes diák, mesterdiák, elrendezések, alakzatok, export beállítások vagy a bemutatóelemek közötti kapcsolatok felett.

Az alábbi táblázat összefoglalja a rendelkezésre álló segédprogramokat:

| Segédprogram | Mire használható |
| --- | --- |
| [Átalakítás](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/convert/) | Prezentáció konvertálása más formátumba közvetlen fájl‑fájl hívással. |
| [Egyesítő](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/merger/) | Azonos formátumú teljes prezentációs fájlok egyesítése. |
| [ForEach](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/) | Művelet végrehajtása minden dia, alakzat, bekezdés vagy szövegrész esetén. |
| [Gyűjtés](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/collect/) | Alakzatok lekérdezése a teljes prezentációból ismételt feldolgozás vagy elemzés céljából. |
| [Tömörítés](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/) | Nem használt mesterségek és elrendezések eltávolítása, valamint a beágyazott betűtípus adatok csökkentése. |

## **Prezentáció átalakítása**

Használja a [Convert.autoByExtension](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/convert/#autoByExtension) metódust, ha a kimeneti fájl kiterjesztése elegendő az export formátum kiválasztásához. A metódus megnyitja a forrás prezentációt, meghatározza a szükséges formátumot a kimeneti úttól, és írja az eredményt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

A [Convert](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/convert/) osztály további dedikált metódusokat kínál PDF, SVG, JPEG, PNG és TIFF kimenethez. Használja a teljes objektummodellt, ha a prezentációt exportálás előtt meg kell vizsgálnia vagy módosítania, vagy be kell állítania egy export beállítást, amelyet a kiválasztott segédprogram nem tesz elérhetővé. Lásd a [Prezentáció átalakítása](/slides/hu/nodejs-java/convert-presentation/) oldalt a formátum specifikus munkafolyamatokért és opciókért.

## **Prezentációk egyesítése**

Használja a [Merger.process](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/merger/#process) metódust a teljes prezentációs fájlok egy hívással történő egyesítéséhez. A bemeneti prezentációknak azonos fájlformátumúaknak kell lenniük.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

A segédprogram megfelelő, amikor az összes dia egyetlen eredményhez kell, hogy hozzá legyen fűzve, anélkül, hogy egyenként kellene kiválasztani vagy átmappolni őket. Használja a teljes objektummodellt, ha kiválasztott diasorozatokat szeretne egyesíteni, célmástert vagy elrendezést alkalmazni, a szekciókat kifejezetten megőrizni, vagy különböző diaméreteket egyeztetni. Lásd a [Prezentációk egyesítése](/slides/hu/nodejs-java/merge-presentation/) oldalt ezekhez a forgatókönyvekhez.

## **Iterálás a prezentációelemeneken**

Az [ForEach](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/) osztály visszahívást hív meg minden kért típusú prezentációelem esetén. Elkerüli a beágyazott gyűjtemény ciklusokat, és kényelmes a prezentáció‑szintű ellenőrzéshez vagy formázás módosításhoz. Node.js‑ben a visszahívás interfészek megvalósításához használja a `java.newProxy`‑t.

A következő példa a [ForEach.slide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#paragraph) és [ForEach.portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#portion) használatával ellenőrzi a megfelelő elemeket:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

Alapértelmezés szerint a prezentáció‑szintű alakzat‑ és szövegbejárás a normál, mester és elrendezés diákat is tartalmazza. Az `includeNotes` paraméterrel rendelkező túlterhelések a jegyzetdiákot is feldolgozhatják. Használjon közvetlen gyűjteményciklusokat, ha a bejárási sorrend, a korai kilépés, a visszahívás előtti szűrés vagy a részletes szülő‑gyermek vezérlés fontos.

## **Alakzatok gyűjtése**

Használja a [Collect.shapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/collect/#shapes) metódust, ha egy teljes prezentáció összes alakzata gyűjteményére van szüksége ahelyett, hogy minden alakzatra egy visszahívást kapna. Ez hasznos, ha ugyanazt a halmazt többször szűrni, számolni vagy feldolgozni szeretné.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

Használja a [ForEach.shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#shape) metódust ehelyett, amikor minden alakzatot azonnal kezelhet, és nincs szükség a gyűjtött eredmény megőrzésére.

## **Prezentáció tartalmának tömörítése**

A [Compress](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/) osztály eltávolíthatja a nem használt struktúrákat és csökkentheti a beágyazott betűtípus adatokat:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) eltávolítja azokat a layout diákat, amelyekre nem hivatkozik egyetlen normál dia sem.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) eltávolítja a már nem használt mesterdiákat.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) eltávolítja a nem használt karaktereket a beágyazott betűtípusokból.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Először távolítsa el a nem használt elrendezéseket, majd a nem használt mesterségeket, hogy egy elrendezés‑takarítás után hivatkozás nélküli mester is eltávolítható legyen. Mentse az optimalizált prezentációt egy új fájlba, ha a későbbiekben szüksége lehet az eredeti mesterségekre, elrendezésekre vagy a teljes beágyazott betűtípus adatra. További részletekért lásd a [Diakeret](/slides/hu/nodejs-java/slide-master/) és az [Beágyazott betűtípus](/slides/hu/nodejs-java/embedded-font/) oldalakat.

## **GYIK**

**Mikor kell az alacsony kódú API-t használni a teljes objektummodell helyett?**

Használja az alacsony kódú segédprogramokat, ha egy szabványos művelet egy teljes fájlra vagy prezentációra vonatkozik, és nem igényel részletes vezérlést az egyes elemek felett. Használja a teljes objektummodellt, ha konkrét diákat kell kiválasztania, a mester‑ és elrendezés‑kapcsolatokat kell irányítania, a köztes állapotot meg kell vizsgálnia, vagy olyan viselkedést kell beállítania, amelyet a segédprogram nem tesz elérhetővé.

**Kombinálhatja a Merger a prezentációkat különböző fájlformátumokban?**

Nem. A [Merger.process](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/merger/#process) ugyanabban a formátumban lévő bemeneti prezentációkat igényel. Először konvertálja a bemeneti fájlokat közös formátumba, például a [Convert.autoByExtension](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/convert/#autoByExtension) segítségével, majd egyesítse a konvertált fájlokat.

**Feldolgozza a ForEach a mester, az elrendezés és a jegyzetdiákat?**

A [ForEach.slide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#slide) a normál prezentációs diákon iterál. A prezentáció‑szintű [ForEach.shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#paragraph) és [ForEach.portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#portion) műveletek alapértelmezés szerint a normál, mester és elrendezés diákat is tartalmazzák. Használja a `includeNotes` paraméterrel ellátott túlterheléseket, ha a jegyzetdiákat is bele akarja venni.

**Mi a különbség a ForEach.shape és a Collect.shapes között?**

Használja a [ForEach.shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#shape) metódust, ha minden alakzatot azonnal szeretne feldolgozni egy visszahívásban. Használja a [Collect.shapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/collect/#shapes) metódust, ha egy iterálható eredményre van szüksége, amelyet megőrizhet, szűrhet, számlálhat vagy többször bejárhat.

**Mindig kisebbé teszi a Compress a prezentáció fájlt?**

Nem feltétlenül. Az eredmény attól függ, hogy a prezentáció tartalmaz‑e nem használt elrendezéseket, nem használt mesterségeket vagy beágyazott betűtípusokat nem használt karakterekkel. Ha ezek egyike sem áll fenn, a megfelelő [Compress](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/) műveletek nem feltétlenül csökkentik a fájlméretet.

**A ForEach vagy a Compress által végzett változtatások automatikusan mentődnek?**

Nem. Ezek a segédprogramok a memóriában betöltött [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) objektumon dolgoznak. Miután módosította az elemeket egy [ForEach](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/) visszahívásban vagy futtatta a [Compress](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/) műveletet, hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódust az eredmény írásához.

## **Kapcsolódó cikkek**

- [Prezentáció átalakítása](/slides/hu/nodejs-java/convert-presentation/)
- [Prezentációk egyesítése](/slides/hu/nodejs-java/merge-presentation/)
- [Diakeret](/slides/hu/nodejs-java/slide-master/)
- [Szövegdoboz kezelése](/slides/hu/nodejs-java/manage-textbox/)
- [Beágyazott betűtípus](/slides/hu/nodejs-java/embedded-font/)