---
title: Alacsony kódú bemutató műveletek Java nyelven
linktitle: Alacsony kódú API
type: docs
weight: 50
url: /hu/java/low-code-presentation-operations/
keywords:
- alacsony kódú bemutató API
- bemutató konvertálása
- bemutatók egyesítése
- diák bejárása
- alakzatok bejárása
- szöveg bejárása
- alakzatok összegyűjtése
- bemutató tömörítése
- fel nem használt mesterdiák eltávolítása
- fel nem használt elrendezési diák eltávolítása
- beágyazott betűtípusok tömörítése
- PowerPoint
- OpenDocument
- bemutató
- Java
- Aspose.Slides
description: "Használja az Aspose.Slides alacsony kódú API-t Java-ban a bemutatók konvertálásához és egyesítéséhez, a tartalom bejárásához, alakzatok összegyűjtéséhez, valamint a bemutató méretének csökkentéséhez."
---
## **Áttekintés**

A [com.aspose.slides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/) csomag statikus segédosztályokat biztosít a gyakori bemutató műveletekhez. Ezek a segédek a gyakran használt objektummodell munkafolyamatokat fókuszált metódusokba csomagolják, így fájlokat konvertálhat vagy egyesíthet, feldolgozhatja a bemutató elemeit, összegyűjtheti az alakzatokat, és kevesebb kóddal eltávolíthatja a fel nem használt tartalmat.

Az alacsony kódolású segédek leginkább akkor hasznosak, amikor a művelet egy teljes fájlra vagy bemutatóra vonatkozik, és az alapértelmezett munkafolyamat megfelel az igényeinek. Használja a teljes [Aspose.Slides object model](https://reference.aspose.com/slides/hu/java/com.aspose.slides/)‑t, ha finomhangolt vezérlésre van szükség egyes diák, mesterlapok, elrendezések, alakzatok, exportbeállítások vagy a bemutató elemei közötti kapcsolatok felett.

Az alábbi táblázat összegzi a rendelkezésre álló segédeszközöket:

| Segédeszköz | Használat célja |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hu/java/com.aspose.slides/convert/) | Bemutató konvertálása egy másik formátumra közvetlen fájl‑fájl hívással. |
| [Merger](https://reference.aspose.com/slides/hu/java/com.aspose.slides/merger/) | Azonos formátumú teljes bemutató fájlok egyesítése. |
| [ForEach](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/) | Művelet végrehajtása minden diára, alakzatra, bekezdésre vagy szövegrészre. |
| [Collect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/collect/) | Alakzatok lekérése a teljes bemutatóból ismételt feldolgozás vagy elemzés céljából. |
| [Compress](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/) | A fel nem használt mesterlapok és elrendezések eltávolítása, valamint a beágyazott betűtípusadatok csökkentése. |

## **Bemutató konvertálása**

Használja a [Convert.autoByExtension](https://reference.aspose.com/slides/hu/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) metódust, ha a kimeneti fájl kiterjesztése elegendő az exportformátum kiválasztásához. A metódus megnyitja a forrásbemutatót, a kimeneti útvonalból meghatározza a szükséges formátumot, és kiírja az eredményt.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

A [Convert](https://reference.aspose.com/slides/hu/java/com.aspose.slides/convert/) osztály dedikált metódusokat is biztosít PDF, SVG, JPEG, PNG és TIFF kimenethez. Használja a teljes objektummodellt, ha a export előtt inspect vagy módosítani kell a bemutatót, vagy ha olyan exportopciót kell beállítani, amelyet a kiválasztott segédeszköz nem tesz elérhetővé. Lásd a [Convert Presentation](/slides/hu/java/convert-presentation/) oldalt a formátumspecifikus munkafolyamatokért és beállításokért.

## **Bemutatók egyesítése**

Használja a [Merger.process](https://reference.aspose.com/slides/hu/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) metódust a teljes bemutató fájlok egyesítéséhez egy hívással. A bemeneti bemutatóknak azonos fájlformátummal kell rendelkezniük.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

A segéd akkor megfelelő, ha minden diát egy eredményfájlba kell fűzni anélkül, hogy egyenként kiválasztanánk vagy újra leképeznénk őket. Használja a teljes objektummodellt, ha kiválasztott diákat kell egyesíteni, célmesterlapot vagy elrendezést kell alkalmazni, szakaszokat kell kifejezetten megőrizni, vagy különböző diaméreteket kell egységesíteni. Lásd a [Merge Presentations](/slides/hu/java/merge-presentation/) oldalt ezekre a forgatókönyvekre.

## **Bemutató elemeinek bejárása**

A [ForEach](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/) osztály callback‑et hív meg minden kért típusú bemutatóelemre. Elkerüli a beágyazott gyűjteményciklusokat, és kényelmes a teljes bemutató szintű ellenőrzéshez vagy formázási módosításokhoz.

Az alábbi példa a [ForEach.slide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), és [ForEach.portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) használatával vizsgálja meg a megfelelő elemeket:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

Alapértelmezés szerint a teljes bemutató alakzat‑ és szövegbejárás magában foglalja a normál, mester és elrendezés diákat. Az `includeNotes` paraméterrel rendelkező túlterhelések a jegyzet diakat is feldolgozhatják. Használjon közvetlen gyűjteményciklusokat, ha a bejárás sorrendje, korai kilépés, szűrés a callback meghívása előtt vagy a részletes szülő‑gyermek vezérlés fontos.

## **Alakzatok összegyűjtése**

Használja a [Collect.shapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) metódust, ha a teljes bemutatóban lévő összes alakzatra szüksége van egy gyűjteményre, ahelyett, hogy minden alakzatra külön callback‑et kapna. Ez hasznos, ha ugyanazt a halmazt többször kell szűrni, számolni vagy feldolgozni.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Használja helyette a [ForEach.shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) metódust, ha minden alakzatot azonnal kezel, és nincs szükség a gyűjtött eredmény megőrzésére.

## **Bemutató tartalom tömörítése**

A [Compress](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/) osztály a következőkkel tud segíteni:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) eltávolítja azokat az elrendezés diákat, amelyekre nincs normál dia hivatkozás.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) eltávolítja a már nem használt mesterlapokat.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) eltávolítja a beágyazott betűtípusokból a nem használt karaktereket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Először távolítsa el a fel nem használt elrendezéseket, majd a fel nem használt mesterlapokat, így egy a layout takarítás után már fel nem hivatkozott mesterlap is eltávolítható. Mentse az optimalizált bemutatót egy új fájlba, ha később szüksége lehet az eredeti mesterlapokra, elrendezésekre vagy a teljes beágyazott betűtípusra. További részletekért lásd a [Slide Master](/slides/hu/java/slide-master/) és az [Embedded Font](/slides/hu/java/embedded-font/) oldalakat.

## **GYIK**

**Mikor kellene az alacsony‑kódú API‑t használni a teljes objektummodell helyett?**

Használja az alacsony kódolású segédeszközöket, ha egy szabványos művelet egy teljes fájlra vagy bemutatóra vonatkozik, és nem igényel részletes vezérlést az egyes elemek felett. Használja a teljes objektummodellt, ha konkrét diák kiválasztására, a mester‑ és elrendezéskapcsolatok irányítására, köztes állapot ellenőrzésére vagy olyan viselkedés konfigurálására van szükség, amelyet a segédeszköz nem biztosít.

**Kombinálhat-e a Merger különböző fájlformátumú bemutatókat?**

Nem. A [Merger.process](https://reference.aspose.com/slides/hu/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) ugyanabban a formátumban lévő bemutatókat igényel. Először konvertálja a bemeneti fájlokat közös formátumba, például a [Convert.autoByExtension](https://reference.aspose.com/slides/hu/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) metódussal, majd egyesítse a konvertált fájlokat.

**Feldolgozza-e a ForEach a mester, layout és jegyzet diákat?**

A [ForEach.slide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) csak a normál bemutatódiákat járja be. A teljes bemutatóra kiterjedő [ForEach.shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), és [ForEach.portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) műveletek alapértelmezés szerint a normál, mester és layout diákat is tartalmazzák. Az `includeNotes` paramétert `true`‑ra állítva a jegyzet diák is be lesz vonva.

**Mi a különbség a ForEach.shape és a Collect.shapes között?**

Használja a [ForEach.shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) metódust, ha minden alakzatot azonnal szeretne feldolgozni egy callback‑en keresztül. Használja a [Collect.shapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) metódust, ha egy iterálható eredményre van szüksége, amelyet megőrizhet, szűrhet, megszámolhat vagy többször bejárhat.

**Mindig kisebbre csökkenti-e a Compress a bemutató fájlt?**

Nem feltétlenül. Az eredmény attól függ, hogy a bemutató tartalmaz‑e fel nem használt elrendezéseket, fel nem használt mestereket vagy beágyazott betűtípusokat nem használt karakterekkel. Ha egyik sem áll fenn, a megfelelő [Compress](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/) művelet nem feltétlenül csökkenti a fájlméretet.

**Mentésre kerülnek-e automatikusan a ForEach vagy a Compress által végrehajtott módosítások?**

Nem. Ezek a segédeszközök a memóriában lévő [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) objektumot módosítják. A [ForEach](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/) callback‑ben vagy a [Compress](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/) futtatása után hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust a végeredmény kiírásához.

## **Kapcsolódó cikkek**

- [Bemutató konvertálása](/slides/hu/java/convert-presentation/)
- [Bemutatók egyesítése](/slides/hu/java/merge-presentation/)
- [Dia mesterlap](/slides/hu/java/slide-master/)
- [Szövegdoboz kezelése](/slides/hu/java/manage-textbox/)
- [Beágyazott betűtípus](/slides/hu/java/embedded-font/)