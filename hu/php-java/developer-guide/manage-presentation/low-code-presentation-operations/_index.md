---
title: Alacsony kódú prezentációs műveletek PHP-ben
linktitle: Alacsony kódú API
type: docs
weight: 50
url: /hu/php-java/low-code-presentation-operations/
keywords:
- alacsony kódú prezentáció API
- prezentáció konvertálása
- prezentációk egyesítése
- diák bejárása
- alakzatok bejárása
- szöveg bejárása
- alakzatok összegyűjtése
- prezentáció tömörítése
- nem használt mesterdiák eltávolítása
- nem használt elrendezési diák eltávolítása
- beágyazott betűkészletek tömörítése
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Használja az Aspose.Slides alacsony kódú API-t PHP-ben a prezentációk konvertálásához és egyesítéséhez, a tartalom bejárásához, alakzatok összegyűjtéséhez és a prezentáció méretének csökkentéséhez."
---
## **Áttekintés**

A [aspose.slides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/) névtér statikus segédosztályokat biztosít a gyakori prezentációs műveletekhez. Ezek a segédek a gyakran használt objektummodell munkafolyamatokat fókuszált metódusokba csomagolják, így kevesebb kóddal konvertálhat vagy egyesíthet fájlokat, feldolgozhatja a prezentáció elemeit, összegyűjtheti az alakzatokat, és eltávolíthatja a nem használt tartalmat.

Az alacsony kódú segédek akkor a leghasznosabbak, amikor a művelet egy teljes fájlra vagy prezentációra vonatkozik, és az alapértelmezett munkafolyamat megfelel az igényeinek. Használja a teljes [Aspose.Slides objektummodellt], ha finomhangolt vezérlésre van szüksége egyedi diák, mesteroldalak, elrendezések, alakzatok, exportbeállítások vagy a prezentációelemek közötti kapcsolatok felett.

Az alábbi táblázat összefoglalja a rendelkezésre álló segédeket:

| Segéd | Mire használható |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hu/php-java/aspose.slides/convert/) | Prezentáció konvertálása másik formátumba közvetlen fájl‑fájl hívással. |
| [Merger](https://reference.aspose.com/slides/hu/php-java/aspose.slides/merger/) | Ugyanazon formátumú teljes prezentációfájlok egyesítése. |
| [ForEach_](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/) | Visszahívás futtatása minden diára, alakzatra, bekezdésre vagy szövegrészre. |
| [Collect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/collect/) | Alakzatok lekérdezése a teljes prezentációból ismételt feldolgozás vagy elemzés céljából. |
| [Compress](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/) | Nem használt mesterelemek és elrendezések eltávolítása, valamint a beágyazott betűkészlet adatainak csökkentése. |

## **Prezentáció konvertálása**

Használja a [Convert::autoByExtension](https://reference.aspose.com/slides/hu/php-java/aspose.slides/convert/#autoByExtension) metódust, ha a kimeneti fájlkiterjesztés elegendő az export formátum kiválasztásához. A metódus megnyitja a forrás prezentációt, meghatározza a szükséges formátumot a kimeneti útvonal alapján, és kiírja az eredményt.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

A [Convert](https://reference.aspose.com/slides/hu/php-java/aspose.slides/convert/) osztály további dedikált metódusokat kínál a PDF, SVG, JPEG, PNG és TIFF kimenethez. Használja a teljes objektummodellt, ha export előtt meg kell vizsgálnia vagy módosítania a prezentációt, vagy olyan exportbeállítást kell konfigurálnia, amelyet a kiválasztott segéd nem biztosít. Lásd a [Convert Presentation](/slides/hu/php-java/convert-presentation/) oldalt a formátumspecifikus munkafolyamatokért és beállításokért.

## **Prezentációk egyesítése**

Használja a [Merger::process](https://reference.aspose.com/slides/hu/php-java/aspose.slides/merger/#process) metódust, hogy egy hívással egyesítsen teljes prezentációfájlokat. A bemeneti prezentációknak ugyanazzal a fájlformátummal kell rendelkezniük.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

Ez a segéd akkor megfelelő, ha minden diát egyetlen eredményhez kell hozzáfűzni anélkül, hogy egyenként kiválasztaná vagy újraképezné őket. Használja a teljes objektummodellt, ha kiválasztott diákat kell egyesíteni, célmesteroldalt vagy elrendezést kell alkalmazni, szekciókat kifejezetten megőrizni, vagy különböző diaméreteket egyeztetni. Lásd a [Merge Presentations](/slides/hu/php-java/merge-presentation/) oldalt ezekhez a forgatókönyvekhez.

## **Prezentációelemek bejárása**

A [ForEach_](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/) osztály visszahívást hív meg minden kért típusú prezentációelemre. Elkerüli a beágyazott gyűjteményciklusokat, és kényelmes a teljes prezentációs vizsgálathoz vagy formázási módosításokhoz.

Az alábbi példa a [ForEach_::slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#slide), a [ForEach_::shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#shape), a [ForEach_::paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#paragraph) és a [ForEach_::portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#portion) metódusokat használja a megfelelő elemek ellenőrzésére:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

Alapértelmezés szerint a teljes prezentáción belüli alakzat és szöveg bejárás magában foglalja a normál, mester és elrendezési diát is. Az `includeNotes` paraméterrel rendelkező túlterhelések a jegyzetdia feldolgozását is lehetővé teszik. Használjon közvetlen gyűjteményciklusokat, ha a bejárási sorrend, a korai kilépés, a visszahívás előtti szűrés vagy a részletes szülő‑gyermek vezérlés fontos.

## **Alakzatok összegyűjtése**

Használja a [Collect::shapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/collect/#shapes) metódust, ha a prezentáció összes alakzatának gyűjteményére van szüksége, ahelyett hogy minden alakzatra visszahívást kapna. Ez akkor hasznos, ha ugyanazt a halmazt többször szűrni, számolni vagy feldolgozni kívánja.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Használja inkább a [ForEach_::shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#shape) metódust, ha az egyes alakzatok azonnal kezelhetők, és nincs szükség az összegyűjtött eredmény megtartására.

## **Prezentáció tartalmának tömörítése**

A [Compress](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/) osztály eltávolíthatja a nem használt szerkezeti elemeket és csökkentheti a beágyazott betűkészlet adatait:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) eltávolítja azokat az elrendezési diát, amelyeket egyetlen normál dia sem hivatkozik.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/#removeUnusedMasterSlides) eltávolítja a már nem használt mesterdiákat.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/#compressEmbeddedFonts) eltávolítja a beágyazott betűkészletekből a nem használt karaktereket.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Először távolítsa el a nem használt elrendezéseket, majd a nem használt mesterelemeket, hogy az elrendezés tisztítása után hivatkozás nélkül maradt mester is eltávolítható legyen. Mentse az optimalizált prezentációt új fájlba, ha később szüksége lehet az eredeti mesterelemekre, elrendezésekre vagy a teljes beágyazott betűkészlet adatra. További részletekért lásd a [Slide Master](/slides/hu/php-java/slide-master/) és [Embedded Font](/slides/hu/php-java/embedded-font/) oldalakat.

## **FAQ**

**Mikor kell az alacsony kódú API-t használni a teljes objektummodell helyett?**

Használjon alacsony kódú segédeket, ha egy szabványos művelet egy teljes fájlra vagy prezentációra vonatkozik, és nem igényel részletes vezérlést az egyedi elemek felett. Használja a teljes objektummodellt, ha konkrét diákat kell kiválasztania, a mester‑ és elrendezés‑kapcsolatokat kell irányítania, közbenső állapotot kell ellenőriznie, vagy olyan viselkedést kell beállítania, amelyet a segéd nem biztosít.

**Össze tudja-e a Merger különböző fájlformátumú prezentációkat?**

Nem. A [Merger::process](https://reference.aspose.com/slides/hu/php-java/aspose.slides/merger/#process) megköveteli, hogy a bemeneti prezentációk ugyanabban a formátumban legyenek. Először konvertálja a bemeneti fájlokat közös formátumba, például a [Convert::autoByExtension](https://reference.aspose.com/slides/hu/php-java/aspose.slides/convert/#autoByExtension) segítségével, majd egyesítse a konvertált fájlokat.

**A ForEach_ feldolgozza a mester, elrendezés és jegyzet diákat?**

A [ForEach_::slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#slide) a normál prezentációs diákon iterál. A teljes prezentációra kiterjedő [ForEach_::shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#paragraph) és [ForEach_::portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#portion) műveletek alapértelmezés szerint a normál, mester és elrendezési diákot is tartalmazzák. Használja a túlterheléseiket, ahol az `includeNotes` paraméter `true` értékre van állítva, hogy a jegyzetdiák is bekerüljenek.

**Mi a különbség a ForEach_::shape és a Collect::shapes között?**

A [ForEach_::shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#shape)-t használja, ha minden alakzatot azonnal egy visszahívásban kíván feldolgozni. A [Collect::shapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/collect/#shapes)-t akkor használja, ha egy iterálható eredményre van szüksége, amely megtartható, szűrhető, számlálható vagy többször bejárható.

**A Compress mindig kisebbre csökkenti a prezentáció fájlját?**

Nem feltétlenül. Az eredmény attól függ, hogy a prezentáció tartalmaz‑e nem használt elrendezéseket, nem használt mesterelemeket vagy beágyazott betűket nem használt karakterekkel. Ha ezek egyike sem található, a megfelelő [Compress](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/) műveletek nem feltétlenül csökkentik a fájlméretet.

**A ForEach_ vagy a Compress által végrehajtott módosítások automatikusan mentésre kerülnek?**

Nem. Ezek a segédek a betöltött [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) objektumon memóriában dolgoznak. A [ForEach_] visszahívásban végzett módosítások vagy a [Compress](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/) futtatása után hívja meg a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) metódust az eredmény írásához.

## **Kapcsolódó cikkek**

- [Prezentáció konvertálása](/slides/hu/php-java/convert-presentation/)
- [Prezentációk egyesítése](/slides/hu/php-java/merge-presentation/)
- [Slide Master](/slides/hu/php-java/slide-master/)
- [Manage Text Box](/slides/hu/php-java/manage-textbox/)
- [Embedded Font](/slides/hu/php-java/embedded-font/)