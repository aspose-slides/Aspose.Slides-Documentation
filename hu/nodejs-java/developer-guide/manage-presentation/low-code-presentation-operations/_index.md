---
title: Alacsony-kódú prezentációs műveletek JavaScriptben
linktitle: Alacsony-kódú API
type: docs
weight: 50
url: /hu/nodejs-java/low-code-presentation-operations/
keywords:
- alacsony-kódú prezentációs API
- prezentáció konvertálása
- prezentációk egyesítése
- diák bejárása
- alakzatok bejárása
- szöveg bejárása
- alakzatok gyűjtése
- prezentáció tömörítése
- nem használt master diák eltávolítása
- nem használt layout diák eltávolítása
- beágyazott betűtípusok tömörítése
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Használja az Aspose.Slides alacsony-kódú API-t JavaScript-ben a prezentációk konvertálásához és egyesítéséhez, a tartalom bejárásához, alakzatok gyűjtéséhez, valamint a prezentáció méretének csökkentéséhez."
---
## **Áttekintés**

Az `aspose.slides` névtér statikus segédosztályokat biztosít a gyakori prezentációs műveletekhez. Ezek a segítők a gyakran használt objektummodell‑folyamatokat fókuszált metódusokba csomagolják, így kevesebb kóddal konvertálhat vagy egyesíthet fájlokat, feldolgozhatja a prezentáció elemeit, gyűjthet alakzatokat, és eltávolíthatja a nem használt tartalmakat.

Az alacsony‑kódú segítők akkor a leghasznosabbak, amikor a művelet egy teljes fájlra vagy prezentációra vonatkozik, és az alapértelmezett munkafolyamat megfelel az igényeinek. Használja a teljes [Aspose.Slides objektummodellt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/), ha finomhangolt vezérlésre van szüksége egyedi diák, masterek, elrendezések, alakzatok, exportbeállítások vagy a prezentáció elemei közötti kapcsolatok felett.

Az alábbi táblázat összegzi a rendelkezésre álló segítőket:

| Segédprogram | Mire használható |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/convert/) | Prezentáció konvertálása más formátumba közvetlen fájl‑fájl hívással. |
| [Merger](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/merger/) | Ugyanazon formátumú teljes prezentációs fájlok egyesítése. |
| [ForEach](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/) | Művelet végrehajtása minden diára, alakzatra, bekezdésre vagy szövegrészre. |
| [Collect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/collect/) | Alakzatok lekérése a teljes prezentációból ismételt feldolgozás vagy elemzés céljából. |
| [Compress](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/) | Nem használt masterek és elrendezések eltávolítása, beágyazott betűtípus‑adatok csökkentése. |

## **Prezentáció konvertálása**

Használja a [Convert.autoByExtension](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/convert/#autoByExtension) metódust, ha a kimeneti fájl kiterjesztése elegendő az exportformátum kiválasztásához. A metódus megnyitja a forrás‑prezentációt, meghatározza a szükséges formátumot a kimeneti útvonal alapján, és beírja az eredményt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

A [Convert](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/convert/) osztály további dedikált metódusokat kínál PDF, SVG, JPEG, PNG és TIFF kimenetekhez. Használja a teljes objektummodellt, ha a konvertálás előtt meg kell vizsgálnia vagy módosítania a prezentációt, vagy olyan exportbeállítást kell konfigurálnia, amelyet a kiválasztott segítő nem biztosít. Lásd a [Convert Presentation](/nodejs-java/convert-presentation/) oldalt a formátumspecifikus munkafolyamatokért és beállításokért.

## **Prezentációk egyesítése**

Használja a [Merger.process](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/merger/#process) metódust a teljes prezentációs fájlok egyetlen hívással történő egyesítéséhez. A bemeneti prezentációknak azonos fájlformátumúaknak kell lenniük.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Ez a segédprogram akkor megfelelő, amikor az összes dia egy eredménybe kell, hogy legyen fűzve, anélkül, hogy egyenként kellene kiválasztani vagy átkönyvelni őket. Használja a teljes objektummodellt, ha kiválasztott diákat szeretne egyesíteni, cél‑mastert vagy -elrendezést alkalmazni, szekciókat kifejezetten megőrizni, vagy különböző dia‑méreteket egyeztetni. Lásd a [Merge Presentations](/nodejs-java/merge-presentation/) oldalt ezekhez a forgatókönyvekhez.

## **Prezentációs elemek bejárása**

A [ForEach](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/) osztály visszahívást hív meg minden kért típusú prezentációs elemre. Elkerüli a beágyazott gyűjtemény‑ciklusokat, és kényelmes a prezentáció‑szintű ellenőrzéshez vagy formázási módosításokhoz. Node.js‑ben a visszahívási interfészeket a `java.newProxy` segítségével valósíthatja meg.

Az alábbi példa a [ForEach.slide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#paragraph) és [ForEach.portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#portion) metódusokat használja a megfelelő elemek bejárásához:

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

Alapértelmezés szerint a prezentáció‑szintű alakzat‑ és szövegböngészés a normál, master és layout diákat is tartalmazza. Az `includeNotes` paraméterrel ellátott túlterhelések a jegyzet‑diákat is feldolgozhatják. Használjon közvetlen gyűjtemény‑ciklusokat, ha a bejárási sorrend, korai kilépés, szűrés a visszahívás előtt vagy a részletes szülő‑gyermek vezérlés fontos.

## **Alakzatok gyűjtése**

Használja a [Collect.shapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/collect/#shapes) metódust, ha a prezentáció összes alakzatának gyűjteménye szükséges, ahelyett, hogy minden alakzatra külön visszahívást kapna. Ez akkor hasznos, ha ugyanazt a halmazt többször kell szűrni, számlálni vagy feldolgozni.

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

Használja helyette a [ForEach.shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#shape) metódust, ha minden alakzatot azonnal kezelni tud, és nincs szükség a gyűjtött eredmény megtartására.

## **Prezentáció tartalmának tömörítése**

A [Compress](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/) osztály képes eltávolítani a nem használt strukturális elemeket és csökkenteni a beágyazott betűtípus‑adatokat:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) eltávolítja azokat az elrendezés‑diákat, amelyeket nem hivatkozik semmilyen normál dia.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) eltávolítja a már nem használt master‑diákat.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) eltávolítja a beágyazott betűtípusokból a nem használt karaktereket.

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

Először távolítsa el a nem használt elrendezéseket, majd a nem használt master‑diákat, hogy a layout‑takarítás után feleslegessé váló master is eltávolítható legyen. Mentse az optimalizált prezentációt egy új fájlba, ha később szüksége lehet az eredeti master‑, layout‑ vagy teljes beágyazott betűtípus‑adatokra. További részletekért lásd a [Slide Master](/nodejs-java/slide-master/) és az [Embedded Font](/nodejs-java/embedded-font/) oldalakat.

## **GYIK**

**Mikor érdemes az alacsony‑kódú API‑t használni a teljes objektummodell helyett?**

Használja az alacsony‑kódú segítőket, ha egy szabványos művelet egy teljes fájlra vagy prezentációra vonatkozik, és nem igényel részletes vezérlést az egyedi elemek felett. Használja a teljes objektummodellt, ha konkrét diákat kell kiválasztania, master‑ és layout‑kapcsolatokat kell irányítania, köztes állapotot kell ellenőriznie, vagy olyan viselkedést kell beállítania, amelyet a segítő nem tesz elérhetővé.

**A Merger képes különböző fájlformátumú prezentációkat egyesíteni?**

Nem. A [Merger.process](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/merger/#process) ugyanabban a formátumban lévő bemeneti prezentációkat igényel. Először konvertálja a bemeneti fájlokat egy közös formátumba, például a [Convert.autoByExtension](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/convert/#autoByExtension) használatával, majd egyesítse a konvertált fájlokat.

**A ForEach feldolgozza a master, layout és notes diákat?**

A [ForEach.slide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#slide) a normál prezentációs diákat járja be. A prezentáció‑szintű [ForEach.shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#paragraph) és [ForEach.portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#portion) műveletek alapértelmezés szerint a normál, master és layout diákat tartalmazzák. Használja a `includeNotes` paraméterrel ellátott túlterheléseket, hogy a notes diákat is belefoglalja.

**Mi a különbség a ForEach.shape és a Collect.shapes között?**

Használja a [ForEach.shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/#shape) metódust, ha minden alakzatot azonnal egy visszahíváson keresztül szeretne feldolgozni. Használja a [Collect.shapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/collect/#shapes) metódust, ha egy iterálható eredményre van szüksége, amelyet megtarthat, szűrhet, számlálhat vagy többször bejárhat.

**A Compress mindig kisebbé teszi a prezentációs fájlt?**

Nem feltétlenül. Az eredmény attól függ, hogy a prezentáció tartalmaz‑e nem használt elrendezéseket, nem használt master‑diákat vagy beágyazott betűtípusokat nem használt karakterekkel. Ha egyik sem áll fenn, a megfelelő [Compress](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/) művelet nem csökkenti a fájlméretet.

**A ForEach vagy a Compress által végzett módosítások automatikusan mentődnek?**

Nem. Ezek a segítőprogramok a memóriában betöltött [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) objektumon dolgoznak. A [ForEach](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/foreach/) visszahívásban vagy a [Compress](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compress/) futtatása után hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódust a végeredmény írásához.

## **Kapcsolódó cikkek**

- [Convert Presentation](/nodejs-java/convert-presentation/)
- [Merge Presentations](/nodejs-java/merge-presentation/)
- [Slide Master](/nodejs-java/slide-master/)
- [Manage Text Box](/nodejs-java/manage-textbox/)
- [Embedded Font](/nodejs-java/embedded-font/)