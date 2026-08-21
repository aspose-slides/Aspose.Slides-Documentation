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
- alakzatok gyűjtése
- prezentáció tömörítése
- használaton kívüli master diák eltávolítása
- használaton kívüli elrendezés diák eltávolítása
- beágyazott betűtípusok tömörítése
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Használja az Aspose.Slides alacsony kódú API-t PHP-ben a prezentációk konvertálásához és egyesítéséhez, a tartalom bejárásához, az alakzatok gyűjtéséhez, valamint a prezentáció méretének csökkentéséhez."
---
## **Áttekintés**

A [aspose.slides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/) névtér statikus segédosztályokat biztosít a gyakori bemutató‑műveletekhez. Ezek a segédek a gyakran használt objektummodell munkafolyamatokat összpontosított metódusokba csomagolják, így fájlokat konvertálhat vagy egyesíthet, feldolgozhatja a bemutató elemeit, gyűjtheti az alakzatokat, és kevesebb kóddal eltávolíthatja a nem használt tartalmat.

Az alacsony kódú segédek leginkább akkor hasznosak, ha a művelet egy teljes fájlra vagy bemutatóra vonatkozik, és az alapértelmezett munkafolyamat megfelel az igényeinek. Használja a teljes [Aspose.Slides objektummodellt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/), ha finom vezérlésre van szüksége az egyes diák, masterek, elrendezések, alakzatok, exportbeállítások vagy a bemutatóelemek közötti kapcsolatok felett.

Az alábbi táblázat összegzi a rendelkezésre álló segédeket:

| Segédprogram | Mire használható |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hu/php-java/aspose.slides/convert/) | Prezentáció átalakítása más formátumba közvetlen fájl‑fájl hívással. |
| [Merger](https://reference.aspose.com/slides/hu/php-java/aspose.slides/merger/) | Ugyanazon formátumú teljes bemutatófájlok összevonása. |
| [ForEach_](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/) | Visszahívás végrehajtása minden diára, alakzatra, bekezdésre vagy szövegrészre. |
| [Collect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/collect/) | Alakzatok lekérése a teljes bemutatóból ismételt feldolgozás vagy elemzés céljából. |
| [Compress](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/) | Használaton kívüli masterek és elrendezések eltávolítása, valamint a beágyazott betűadatok csökkentése. |

## **Prezentáció konvertálása**

A [Convert::autoByExtension](https://reference.aspose.com/slides/hu/php-java/aspose.slides/convert/#autoByExtension) használatával, ha a kimeneti fájl kiterjesztése elegendő az exportformátum kiválasztásához. A metódus megnyitja a forrás bemutatót, meghatározza a szükséges formátumot a kimeneti útvonal alapján, és kiírja az eredményt.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

A [Convert](https://reference.aspose.com/slides/hu/php-java/aspose.slides/convert/) osztály dedikált metódusokat is kínál a PDF, SVG, JPEG, PNG és TIFF kimenetekhez. Használja a teljes objektummodellt, ha a exportálás előtt ellenőrizni vagy módosítani kell a bemutatót, vagy ha egy olyan exportbeállítást kell konfigurálni, amely a kiválasztott segédprogramban nincs elérhető. Lásd a [Prezentáció konvertálása](/php-java/convert-presentation/) oldalt a formátumspecifikus munkafolyamatok és beállítások megtekintéséhez.

## **Bemutatók egyesítése**

A [Merger::process](https://reference.aspose.com/slides/hu/php-java/aspose.slides/merger/#process) használatával egy hívással kombinálhatók a teljes bemutatófájlok. A bemenetként megadott bemutatóknak azonos fájlformátummal kell rendelkezniük.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

A segédprogram megfelelő, ha az összes diát egy eredménybe szeretné hozzáfűzni anélkül, hogy egyenként visszaválasztaná vagy újratervezné őket. Használja a teljes objektummodellt, ha kiválasztott diák egyesítésére, célmaster vagy -elrendezés alkalmazására, szekciók kifejezett megőrzésére, vagy különböző diaméretek egyeztetésére van szükség. Lásd a [Bemutatók egyesítése](/php-java/merge-presentation/) oldalt ezekhez a forgatókönyvekhez.

## **Iterálás a bemutatóelemeken**

A [ForEach_](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/) osztály visszahívást hív meg minden kért típusú bemutatóelemre. Elkerüli a beágyazott gyűjteményciklusokat, és kényelmes a bemutató‑szintű ellenőrzéshez vagy formázási módosításokhoz.

Az alábbi példa a [ForEach_::slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#paragraph) és [ForEach_::portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#portion) használatával vizsgálja meg a megfelelő elemeket:

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

Alapértelmezésben a bemutató‑szintű alakzat‑ és szövegvégigjárás a normál, master és layout diákat is tartalmazza. Az `includeNotes` paraméterrel rendelkező túlterhelések a jegyzetdiákat is feldolgozhatják. Használjon közvetlen gyűjteményciklusokat, ha a végigjárás sorrendje, korai kilépés, a visszahívás előtti szűrés vagy a szülő‑gyermek részletes szabályozása fontos.

## **Alakzatok gyűjtése**

Használja a [Collect::shapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/collect/#shapes) metódust, ha a teljes bemutató összes alakzatának gyűjteményére van szüksége, nem pedig egy visszahívásra minden egyes alakzatra. Ez akkor hasznos, ha ugyanazt a halmazt többször kell szűrni, számlálni vagy feldolgozni.

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

Használja helyette a [ForEach_::shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#shape) metódust, ha minden alakzatra azonnal be tud lépni, és nincs szüksége a gyűjtött eredmény megtartására.

## **Bemutató tartalmának tömörítése**

A [Compress](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/) osztály eltávolíthatja a nem használt szerkezeti elemeket, és csökkentheti a beágyazott betűadatokat:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) eltávolítja azokat a layout diákat, amelyeket semmilyen normál dia nem hivatkozik.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/#removeUnusedMasterSlides) eltávolítja azokat a master diákat, amelyek már nem használtak.
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

Távolítsa el előbb a használaton kívüli elrendezéseket, majd a használaton kívüli mastereket, így egy elrendezés tisztítása után fel nem hivatkozott master is eltávolítható lesz. Mentse az optimalizált bemutatót új fájlba, ha később szüksége lehet az eredeti masterekre, elrendezésekre vagy a teljes beágyazott betűadatokra. További részletekért lásd a [Dia master](/php-java/slide-master/) és az [Beágyazott betűtípus](/php-java/embedded-font/) oldalakat.

## **GYIK**

**Mikor kell az alacsony kódú API-t használni a teljes objektummodell helyett?**

Használja az alacsony kódú segédeket, ha egy szabványos művelet egy teljes fájlra vagy bemutatóra vonatkozik, és nem igényel részletes vezérlést az egyes elemek felett. Használja a teljes objektummodellt, ha konkrét diák kiválasztására, master‑ és elrendezés‑kapcsolatok irányítására, köztes állapot ellenőrzésére vagy olyan viselkedés beállítására van szükség, amelyet a segédelem nem biztosít.

**Össze tud-e egyesítő különböző fájlformátumú bemutatókat?**

Nem. A [Merger::process](https://reference.aspose.com/slides/hu/php-java/aspose.slides/merger/#process) megköveteli, hogy a bemeneti bemutatók ugyanabban a formátumban legyenek. Először konvertálja a bemeneti fájlokat közös formátumba, például a [Convert::autoByExtension](https://reference.aspose.com/slides/hu/php-java/aspose.slides/convert/#autoByExtension) használatával, majd egyesítse a konvertált fájlokat.

**A ForEach_ feldolgozza a master, layout és jegyzet diákat?**

A [ForEach_::slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#slide) a normál bemutatódiákon iterál. A bemutató‑szintű [ForEach_::shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#paragraph) és [ForEach_::portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#portion) műveletek alapértelmezésben a normál, master és layout diákot is tartalmazzák. Az `includeNotes` paramétert `true`‑ra állítva a jegyzetdiák is bekerülnek.

**Mi a különbség a ForEach_::shape és a Collect::shapes között?**

Használja a [ForEach_::shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/#shape) metódust, ha minden alakzatot azonnal egy visszahíváson keresztül szeretne feldolgozni. Használja a [Collect::shapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/collect/#shapes) metódust, ha egy iterálható eredményre van szüksége, amelyet megtarthat, szűrhet, számlálhat vagy többször bejárhat.

**A Compress mindig kisebbre teszi a bemutatófájlt?**

Nem feltétlenül. Az eredmény attól függ, hogy a bemutató tartalmaz‑e használaton kívüli elrendezéseket, használaton kívüli mastereket vagy beágyazott betűkészleteket nem használt karakterekkel. Ha egyik sem áll fenn, a megfelelő [Compress](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/) műveletek nem csökkenthetik a fájlméretet.

**A ForEach_ vagy a Compress által végrehajtott módosítások automatikusan mentődnek?**

Nem. Ezek a segédelemek a betöltött [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) objektumon memóriában működnek. A [ForEach_](https://reference.aspose.com/slides/hu/php-java/aspose.slides/foreach_/) visszahívásában vagy a [Compress](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/) futtatása után hívja meg a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) metódust a változtatások kiírásához.

## **Kapcsolódó cikkek**

- [Prezentáció konvertálása](/php-java/convert-presentation/)
- [Bemutatók egyesítése](/php-java/merge-presentation/)
- [Dia master](/php-java/slide-master/)
- [Szövegdoboz kezelése](/php-java/manage-textbox/)
- [Beágyazott betűtípus](/php-java/embedded-font/)