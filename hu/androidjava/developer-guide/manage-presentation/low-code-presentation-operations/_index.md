---
title: Alacsony kódú prezentációs műveletek Androidon
linktitle: Alacsony kódú API
type: docs
weight: 50
url: /hu/androidjava/low-code-presentation-operations/
keywords:
- alacsony kódú prezentációs API
- prezentáció konvertálása
- prezentációk egyesítése
- diák bejárása
- alakzatok bejárása
- szöveg bejárása
- alakzatok gyűjtése
- prezentáció tömörítése
- nem használt mesterdiák eltávolítása
- nem használt elrendezésdiákok eltávolítása
- beágyazott betűkészletek tömörítése
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Használja az Aspose.Slides alacsony kódú API-t Androidon a prezentációk konvertálásához és egyesítéséhez, a tartalom bejárásához, alakzatok gyűjtéséhez és a prezentáció méretének csökkentéséhez."
---
## **Áttekintés**

A [com.aspose.slides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/) csomag statikus segédosztályokat biztosít a gyakori prezentációs műveletekhez. Ezek a segédek a gyakran használt objektummodell-munkafolyamatokat fókuszált metódusokba csomagolják, így kevesebb kóddal konvertálhat vagy egyesíthet fájlokat, feldolgozhatja a prezentáció elemeit, gyűjtheti az alakzatokat, és eltávolíthatja a nem használt tartalmat.

Az alacsony kódolású segédek a leghasznosabbak, ha a művelet egy teljes fájlra vagy prezentációra vonatkozik, és az alapértelmezett munkafolyamat megfelel az igényeinek. Használja a teljes [Aspose.Slides objektummodellt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/), ha finomhangolt vezérlésre van szüksége az egyes diák, mesteroldalak, elrendezések, alakzatok, exportálási beállítások vagy a prezentáció elemei közötti kapcsolatok felett.

Az alábbi táblázat összefoglalja a rendelkezésre álló segédeket:

| Segédprogram | Mire használható |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/convert/) | Prezentáció konvertálása másik formátumba közvetlen fájl‑fájl hívással. |
| [Merger](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/merger/) | Azonos formátumú teljes prezentációs fájlok egyesítése. |
| [ForEach](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/) | Művelet végrehajtása minden dia, alakzat, bekezdés vagy szövegrészlet esetén. |
| [Collect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/collect/) | Alakzatok lekérése az egész prezentációból ismételt feldolgozás vagy elemzés céljából. |
| [Compress](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/) | Nem használt mesterek és elrendezések eltávolítása, illetve beágyazott betűkészlet-adatok csökkentése. |

## **Prezentáció konvertálása**

Használja a [Convert.autoByExtension](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) metódust, ha a kimeneti fájlkiterjesztés elegendő az exportformátum kiválasztásához. A metódus megnyitja a forrásprezentációt, meghatározza a szükséges formátumot a kimeneti útvonalból, és kiírja az eredményt.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

A [Convert](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/convert/) osztály dedikált metódusokat is kínál PDF, SVG, JPEG, PNG és TIFF kimenethez. Használja a teljes objektummodellt, ha exportálás előtt ellenőrizni vagy módosítani kell a prezentációt, vagy olyan exportálási beállítást kell konfigurálni, amelyet a kiválasztott segéd nem tesz elérhetővé. Tekintse meg a [Convert Presentation](/slides/hu/androidjava/convert-presentation/) oldalt a formátumspecifikus munkafolyamatokért és beállításokért.

## **Prezentációk egyesítése**

Használja a [Merger.process](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) metódust a teljes prezentációs fájlok egy hívással történő egyesítéséhez. A bemeneti prezentációknak azonos fájlformátummal kell rendelkezniük.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

A segéd megfelelő, ha az összes diát egyetlen eredményhez kell hozzáfűzni egyéni kiválasztás vagy átképzés nélkül. Használja a teljes objektummodellt, ha kijelölt diákat szeretne egyesíteni, célmesteroldalt vagy -elrendezést alkalmazni, szakaszokat explicit módon megőrizni, vagy különböző diaméreteket egyeztetni. Tekintse meg a [Merge Presentations](/slides/hu/androidjava/merge-presentation/) oldalt ezekhez a forgatókönyvekhez.

## **Prezentációelemek bejárása**

A [ForEach](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/) osztály visszahívást indít az adott típusú prezentációelem minden egyes példányára. Elkerüli a beágyazott gyűjteményciklusokat, és kényelmes a prezentációszintű ellenőrzéshez vagy formázásváltozásokhoz.

A következő példa a [ForEach.slide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), és [ForEach.portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) használatával vizsgálja meg a megfelelő elemeket:

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

Alapértelmezés szerint a prezentációszintű alakzat- és szövegbejárás magában foglalja a normál, mester és elrendezés diákat is. Az `includeNotes` paraméterrel rendelkező túlterhelések a jegyzetdiákat is feldolgozhatják. Használjon közvetlen gyűjteményciklusokat, ha a bejárási sorrend, a korai kilépés, a visszahívás előtti szűrés vagy a részletes szülő‑gyermek vezérlés fontos.

## **Alakzatok gyűjtése**

Használja a [Collect.shapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) metódust, ha a prezentáció összes alakzatának gyűjteményére van szükség, nem pedig egyenkénti visszahívásra. Ez akkor hasznos, ha ugyanazt a halmazt többször szűrni, számolni vagy feldolgozni kívánja.

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

Használja a [ForEach.shape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) metódust, ha minden alakzatot azonnal kezelhet, és nincs szükség a gyűjtött eredmény megtartására.

## **Prezentációtartalom tömörítése**

Az [Compress](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/) osztály képes eltávolítani a nem használt strukturális elemeket és csökkenteni a beágyazott betűkészlet-adatokat:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) eltávolítja azokat az elrendezés diákat, amelyeket egyetlen normál dia sem hivatkozik.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) eltávolítja a már nem használt mesterdiákat.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) eltávolítja a beágyazott betűkészletekből a nem használt karaktereket.

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

Először távolítsa el a nem használt elrendezéseket, majd a nem használt mestereket, hogy egy elrendezés‑tisztítás után hivatkozás nélkül maradt mester is eltávolítható legyen. Mentse az optimalizált prezentációt egy új fájlba, ha később szüksége lehet az eredeti mesterekre, elrendezésekre vagy a teljes beágyazott betűkészlet-adatra. További részletekért tekintse meg a [Slide Master](/slides/hu/androidjava/slide-master/) és az [Embedded Font](/slides/hu/androidjava/embedded-font/) oldalakat.

## **GYIK**

**Mikor kell az alacsony kódolású API-t használni a teljes objektummodell helyett?**

Alacsony kódolású segédeket használjon, ha egy szabványos művelet egy teljes fájlra vagy prezentációra vonatkozik, és nem igényel részletes vezérlést az egyes elemek felett. A teljes objektummodellt akkor használja, ha speciális diákat kell kiválasztani, a mester‑és‑elrendezés kapcsolatokat szabályozni, köztes állapotot ellenőrizni, vagy olyan viselkedést konfigurálni szeretne, amelyet a segéd nem biztosít.

**Kombinálhatja-e a Merger különböző fájlformátumú prezentációkat?**

Nem. A [Merger.process](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) ugyanazon formátumú bemeneti prezentációkat igényel. Először konvertálja a bemeneti fájlokat közös formátumba, például a [Convert.autoByExtension](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) segítségével, majd egyesítse a konvertált fájlokat.

**A ForEach feldolgozza-e a mester, elrendezés és jegyzet diákat?**

A [ForEach.slide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) a normál prezentációs diákat járja be. A prezentációszintű [ForEach.shape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), és [ForEach.portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) műveletek alapértelmezés szerint a normál, mester és elrendezés diákat is tartalmazzák. Használja az `includeNotes` paraméterrel ellátott túlterheléseket, és állítsa `true`‑ra, ha a jegyzetdiák is szerepeljenek.

**Mi a különbség a ForEach.shape és a Collect.shapes között?**

Használja a [ForEach.shape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) metódust, ha minden alakzatot azonnal egy visszahívásban kell feldolgozni. Használja a [Collect.shapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) metódust, ha egy iterálható eredményre van szükség, amelyet megtarthat, szűrhet, számolhat vagy többször bejárhat.

**Mindig csökkenti a Compress a prezentáció fájlméretét?**

Nem feltétlenül. Az eredmény attól függ, hogy a prezentáció tartalmaz‑e nem használt elrendezéseket, nem használt mestereket vagy beágyazott betűkészleteket nem használt karakterekkel. Ha egyik sem áll fenn, akkor a megfelelő [Compress](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/) műveletek nem csökkenthetik a fájlméretet.

**A ForEach vagy a Compress által végzett módosítások automatikusan mentődnek?**

Nem. Ezek a segédek a betöltött [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) objektum memóriában történő példányán dolgoznak. A [ForEach](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/) visszahívásban vagy a [Compress](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/) futtatása után hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust az eredmény kiírásához.

## **Kapcsolódó cikkek**

- [Prezentáció konvertálása](/slides/hu/androidjava/convert-presentation/)
- [Prezentációk egyesítése](/slides/hu/androidjava/merge-presentation/)
- [Slide Master](/slides/hu/androidjava/slide-master/)
- [Szövegdoboz kezelése](/slides/hu/androidjava/manage-textbox/)
- [Beágyazott betűkészlet](/slides/hu/androidjava/embedded-font/)