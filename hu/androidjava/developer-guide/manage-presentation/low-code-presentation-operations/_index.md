---
title: Alacsony kódú bemutató műveletek Androidon
linktitle: Alacsony kódú API
type: docs
weight: 50
url: /hu/androidjava/low-code-presentation-operations/
keywords:
- alacsony kódú bemutató API
- bemutató konvertálása
- bemutatók egyesítése
- diák bejárása
- alakzatok bejárása
- szöveg bejárása
- alakzatok gyűjtése
- bemutató tömörítése
- nem használt master diák eltávolítása
- nem használt elrendezés diák eltávolítása
- beágyazott betűkészletek tömörítése
- PowerPoint
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "Az Aspose.Slides alacsony kódú API-t Androidon használva konvertálhat és egyesíthet bemutatókat, bejárhatja a tartalmat, gyűjtheti az alakzatokat, és csökkentheti a bemutató méretét."
---
## **Áttekintés**

A [com.aspose.slides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/) csomag statikus segédosztályokat biztosít a gyakori bemutató műveletekhez. Ezek a segédek a gyakran használt objektummodell-munkafolyamatokat fókuszált metódusokba csomagolják, így kevesebb kóddal konvertálhat vagy egyesíthet fájlokat, feldolgozhatja a bemutató elemeit, gyűjthet alakzatokat, és eltávolíthatja a nem használt tartalmat.

Az alacsony kódú segédek a leghasznosabbak, ha a művelet egy teljes fájlra vagy bemutatóra vonatkozik, és az alapértelmezett munkafolyamat megfelel az igényeinek. Használja a teljes [Aspose.Slides objektummodellt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/) akkor, ha finomhangolt vezérlésre van szükség egyes diák, masterek, elrendezések, alakzatok, exportbeállítások vagy a bemutató elemei közötti kapcsolatok felett.

Az alábbi táblázat összegzi a rendelkezésre álló segédosztályokat:

| Segéd | Mire használható |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/convert/) | Bemutató más formátumba konvertálása közvetlen fájl‑fájl hívással. |
| [Merger](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/merger/) | Ugyanazon formátumú teljes bemutatófájlok egyesítése. |
| [ForEach](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/) | Művelet végrehajtása minden dián, alakzaton, bekezdésen vagy szövegrészen. |
| [Collect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/collect/) | Alakzatok lekérése a teljes bemutatóból ismételt feldolgozáshoz vagy elemzéshez. |
| [Compress](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/) | Nem használt masterek és elrendezések eltávolítása, valamint a beágyazott betűkészlet-adatok csökkentése. |

## **Bemutató konvertálása**

Használja a [Convert.autoByExtension](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) metódust, ha a kimeneti fájl kiterjesztése elegendő az exportformátum kiválasztásához. A módszer megnyitja a forrásbemutatót, meghatározza a formátumot a kimeneti útvonal alapján, majd kiírja az eredményt.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

A [Convert](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/convert/) osztály dedikált metódusokat is biztosít PDF, SVG, JPEG, PNG és TIFF kimenethez. Használja a teljes objektummodellt, ha a konvertálás előtt ellenőrizni vagy módosítani szeretné a bemutatót, vagy olyan exportbeállítást kell konfigurálni, amelyet a kiválasztott segéd nem tesz közzé. Lásd a [Convert Presentation](/androidjava/convert-presentation/) cikket a formátumspecifikus munkafolyamatokért és beállításokért.

## **Bemutatók egyesítése**

Használja a [Merger.process](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) metódust a teljes bemutatófájlok egyesítéséhez egy hívással. A bemeneti bemutatóknak azonos fájlformátummal kell rendelkezniük.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Ez a segéd megfelelő, ha minden diát egyetlen eredménybe szeretne hozzáfűzni anélkül, hogy egyenként kellene kiválasztania vagy újratérképeznie őket. Használja a teljes objektummodellt, ha kiválasztott diák egyesítésére, cél‑master vagy -elrendezés alkalmazására, a szekciók kifejezett megőrzésére vagy a különböző diaméretek egyeztetésére van szükség. Lásd a [Merge Presentations](/androidjava/merge-presentation/) cikket az ilyen forgatókönyvekről.

## **Iterálás a bemutató elemein**

A [ForEach](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/) osztály hív visszahívást minden kért típusú bemutatóelemhez. Elkerüli a beágyazott gyűjtemény‑ciklusokat, és kényelmes a teljes bemutató átfogó vizsgálatához vagy formázási módosításokhoz.

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

Alapértelmezés szerint a teljes bemutatóra kiterjedő alakzat‑ és szövegjárás magában foglalja a normál, master és layout diákot. Az `includeNotes` paraméterrel rendelkező túlterhelések a jegyzetdiákot is feldolgozhatják. Használjon közvetlen gyűjtemény‑ciklusokat, ha a bejárási sorrend, a korai kilépés, a visszahívás előtti szűrés vagy a részletes szülő‑gyermek vezérlés fontos.

## **Alakzatok gyűjtése**

Használja a [Collect.shapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) metódust, ha a bemutató összes alakzatának gyűjteményére van szükség, nem pedig egy visszahívásra minden egyes alakzatra. Ez akkor hasznos, ha ugyanazt a halmazt többször szűrni, megszámolni vagy feldolgozni kívánja.

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

Használja helyette a [ForEach.shape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) metódust, ha minden alakzatot azonnal kezelhet, és nem kell megőriznie a gyűjtött eredményt.

## **Bemutató tartalmának tömörítése**

A [Compress](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/) osztály képes eltávolítani a nem használt strukturális elemeket és csökkenteni a beágyazott betűkészlet‑adatokat:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) eltávolítja azokat az elrendezési diákat, amelyeket egyetlen normál dia sem hivatkozik.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) eltávolítja a már nem használt master diákat.
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

Először távolítsa el a nem használt elrendezéseket, majd a nem használt mastereket, hogy a layout‑tisztítás után referálatlaná váló master is eltávolítható legyen. Mentse a optimalizált bemutatót új fájlba, ha a későbbiekben szüksége lehet az eredeti masterekre, elrendezésekre vagy a teljes beágyazott betűkészlet‑adatokra. További részletekért lásd a [Slide Master](/androidjava/slide-master/) és az [Embedded Font](/androidjava/embedded-font/) cikkeket.

## **GYIK**

**Mikor kell a low-code API-t használni a teljes objektummodell helyett?**

Alacsony kódú segédeket akkor használjon, ha egy szabványos művelet egy teljes fájlra vagy bemutatóra vonatkozik, és nem igényel részletes vezérlést az egyes elemek felett. A teljes objektummodellt akkor használja, ha konkrét diák kiválasztására, a master‑ és layout‑kapcsolatok irányítására, köztes állapotok vizsgálatára vagy olyan viselkedés konfigurálására van szükség, amelyet a segéd nem tesz közzé.

**Kombinálhat-e a Merger különböző fájlformátumú bemutatókat?**

Nem. A [Merger.process](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) ugyanabban a formátumban lévő bemeneti bemutatókat igényel. Először konvertálja a bemeneti fájlokat közös formátumba, például a [Convert.autoByExtension](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) használatával, majd egyesítse a konvertált fájlokat.

**A ForEach feldolgozza a master, layout és jegyzet diákokat?**

A [ForEach.slide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) a normál bemutatódiákat járja be. A teljes bemutatóra kiterjedő [ForEach.shape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), és [ForEach.portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) műveletek alapértelmezés szerint a normál, master és layout diákot is tartalmazzák. A `includeNotes` paraméterrel rendelkező túlterheléseiket `true` értékre állítva a jegyzetdiákok is bevonásra kerülnek.

**Mi a különbség a ForEach.shape és a Collect.shapes között?**

Használja a [ForEach.shape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) metódust, ha minden alakzatot azonnal egy visszahíváson keresztül szeretne feldolgozni. Használja a [Collect.shapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) metódust, ha egy iterálható eredményre van szüksége, amelyet megőrizhet, szűrhet, megszámolhat vagy többször bejárhat.

**A Compress mindig kisebbé teszi a bemutató fájlt?**

Nem feltétlenül. Az eredmény attól függ, hogy a bemutató tartalmaz‑e nem használt elrendezéseket, nem használt mastereket vagy beágyazott betűkészleteket nem használt karakterekkel. Ha egyik sem áll fenn, a megfelelő [Compress](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/) műveletek nem feltétlenül csökkentik a fájlméretet.

**A ForEach vagy a Compress által végrehajtott módosítások automatikusan mentésre kerülnek?**

Nem. Ezek a segédek a memóriában betöltött [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) objektumon dolgoznak. A [ForEach](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/foreach/) visszahívásban vagy a [Compress](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compress/) futtatása után hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust a végeredmény kiírásához.

## **Kapcsolódó cikkek**

- [Bemutató konvertálása](/androidjava/convert-presentation/)
- [Bemutatók egyesítése](/androidjava/merge-presentation/)
- [Dia mester](/androidjava/slide-master/)
- [Szövegdoboz kezelése](/androidjava/manage-textbox/)
- [Beágyazott betűkészlet](/androidjava/embedded-font/)