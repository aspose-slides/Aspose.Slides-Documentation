---
title: Alacsony kódszintű prezentációs műveletek Java-ban
linktitle: Alacsony kódszintű API
type: docs
weight: 50
url: /hu/java/low-code-presentation-operations/
keywords:
- alacsony kódszintű prezentáció API
- prezentáció konvertálása
- prezentációk egyesítése
- diák bejárása
- alakzatok bejárása
- szöveg bejárása
- alakzatok összegyűjtése
- prezentáció tömörítése
- fel nem használt master diák eltávolítása
- fel nem használt elrendezés diák eltávolítása
- beágyazott betűtípusok tömörítése
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Használja az Aspose.Slides alacsony kódszintű API-t Java-ban a prezentációk konvertálásához és egyesítéséhez, a tartalom bejárásához, az alakzatok összegyűjtéséhez, valamint a prezentáció méretének csökkentéséhez."
---
## **Áttekintés**

A [com.aspose.slides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/) csomag statikus segédosztályokat biztosít a gyakori prezentációs műveletekhez. Ezek a segítők a gyakran használt objektummodell-munkafolyamatokat fókuszált metódusokba csomagolják, így kevesebb kóddal konvertálhat vagy összevonhat fájlokat, feldolgozhatja a prezentáció elemeit, összegyűjtheti az alakzatokat, és eltávolíthatja a fel nem használt tartalmat.

Az alacsony kódszintű segítők a leghasznosabbak, ha a művelet egy teljes fájlra vagy prezentációra vonatkozik, és az alapértelmezett munkafolyamat megfelel az igényeinek. Használja a teljes [Aspose.Slides objektummodellt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/), ha finomhangolt vezérlésre van szüksége egyes diák, masterek, elrendezések, alakzatok, exportbeállítások vagy a prezentáció elemei közötti kapcsolatok felett.

Az alábbi táblázat összegzi a rendelkezésre álló segítőket:

| Segítő | Használat célja |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hu/java/com.aspose.slides/convert/) | A prezentáció másik formátumba konvertálása közvetlen fájl‑fájl hívással. |
| [Merger](https://reference.aspose.com/slides/hu/java/com.aspose.slides/merger/) | Az azonos formátumú teljes prezentációs fájlok egyesítése. |
| [ForEach](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/) | Művelet végrehajtása minden dián, alakzaton, bekezdésen vagy szövegrészen. |
| [Collect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/collect/) | Alakzatok lekérése a teljes prezentációból ismételt feldolgozáshoz vagy elemzéshez. |
| [Compress](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/) | Fel nem használt masterek és elrendezések eltávolítása, valamint a beágyazott betűtípusok adatainak csökkentése. |

## **Prezentáció konvertálása**

Használja a [Convert.autoByExtension](https://reference.aspose.com/slides/hu/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) metódust, ha a kimeneti fájl kiterjesztése elegendő az exportformátum kiválasztásához. A metódus megnyitja a forrás prezentációt, meghatározza a szükséges formátumot a kimeneti útvonal alapján, és felírja az eredményt.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

A [Convert](https://reference.aspose.com/slides/hu/java/com.aspose.slides/convert/) osztály további dedikált metódusokat is biztosít a PDF, SVG, JPEG, PNG és TIFF kimenetekhez. Használja a teljes objektummodellt, ha a prezentációt exportálás előtt meg kell vizsgálnia vagy módosítania, vagy ha olyan exportbeállítást kell konfigurálnia, amelyet a kiválasztott segítő nem tesz közzé. Tekintse meg a [Convert Presentation](/java/convert-presentation/) oldalt a formátum‑specifikus munkafolyamatokért és beállításokért.

## **Prezentációk összevonása**

Használja a [Merger.process](https://reference.aspose.com/slides/hu/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) metódust a teljes prezentációs fájlok egy hívással történő egyesítéséhez. A bemeneti prezentációknak azonos fájlformátummal kell rendelkezniük.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Ez a segítő akkor megfelelő, ha minden diát egyetlen eredményhez kell hozzáfűzni, anélkül, hogy egyenként kiválasztaná vagy átmappálná őket. Használja a teljes objektummodellt, ha kiválasztott diákat kell egyesítenie, egy célmastert vagy elrendezést alkalmazni, szekciókat kifejezetten megőrizni, vagy különböző dia méreteket egyeztetni szeretne. Tekintse meg a [Merge Presentations](/java/merge-presentation/) oldalt az ilyen esetekhez.

## **Prezentációelemek bejárása**

A [ForEach](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/) osztály egy visszahívást indít el minden kért típusú prezentációs elemhez. Elkerüli a beágyazott gyűjtemény‑hurok használatát, és kényelmes a prezentáció egészére kiterjedő ellenőrzéshez vagy formázási módosításokhoz.

Az alábbi példa a [ForEach.slide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), és a [ForEach.portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) használatával vizsgálja meg a megfelelő elemeket:

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

Alapértelmezés szerint a prezentáció egészére kiterjedő alakzat- és szövegbejárás magában foglalja a normál, master és elrendezés diát is. Az `includeNotes` paraméterrel rendelkező túlterhelések a jegyzetdiákat is feldolgozhatják. Használjon közvetlen gyűjtemény‑hurokokat, ha a bejárás sorrendje, a korai kilépés, a visszahívás előtti szűrés vagy a részletes szülő‑gyermek vezérlés fontos.

## **Alakzatok összegyűjtése**

Használja a [Collect.shapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) metódust, ha a prezentáció összes alakzatának gyűjteményére van szüksége egy-egy alakzatra vonatkozó visszahívás helyett. Ez akkor hasznos, ha ugyanazt a halmazt többször szeretné szűrni, megszámolni vagy feldolgozni.

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

Használja inkább a [ForEach.shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) metódust, ha az egyes alakzatok azonnal kezelhetők, és nincs szükség a gyűjtött eredmény megtartására.

## **Prezentáció tartalmának tömörítése**

A [Compress](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/) osztály képes eltávolítani a fel nem használt szerkezeti elemeket és csökkenteni a beágyazott betűtípus adatokat:

- A [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) eltávolítja azokat az elrendezés diákot, amelyeket egyetlen normál dia sem hivatkozik.
- A [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) eltávolítja a már nem használt master diákat.
- A [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) eltávolítja a beágyazott betűtípusok fel nem használt karaktereit.

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

Először távolítsa el a fel nem használt elrendezéseket, majd a fel nem használt mastereket, így egy elrendezés tisztítása után a már hivatkozás nélküli master is eltávolítható. Mentse az optimalizált prezentációt egy új fájlba, ha később szüksége lehet az eredeti masterekre, elrendezésekre vagy a teljes beágyazott betűtípus adatokra. További részletekért tekintse meg a [Slide Master](/java/slide-master/) és az [Embedded Font](/java/embedded-font/) oldalakat.

## **FAQ**

**Mikor érdemes az alacsony kódszintű API-t használni a teljes objektummodell helyett?**

Használjon alacsony kódszintű segítőket, ha egy szabványos művelet egy teljes fájlra vagy prezentációra vonatkozik, és nem igényel részletes vezérlést az egyes elemek felett. Használja a teljes objektummodellt, ha konkrét diákat kell kiválasztania, a master és elrendezés kapcsolatait kell irányítania, köztes állapotot kell ellenőriznie, vagy olyan viselkedést kell konfigurálnia, amelyet a segítő nem tesz közzé.

**Kombinálhatja a Merger különböző fájlformátumú prezentációkat?**

Nem. A [Merger.process](https://reference.aspose.com/slides/hu/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) ugyanazon formátumú bemeneti prezentációkat igényel. Először konvertálja a bemeneti fájlokat egységes formátumba, például a [Convert.autoByExtension](https://reference.aspose.com/slides/hu/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) használatával, majd egyesítse a konvertált fájlokat.

**Feldolgozza a ForEach a master, elrendezés és jegyzet diákot?**

A [ForEach.slide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) a normál prezentációs diákon iterál. A prezentáció egészére kiterjedő [ForEach.shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), és [ForEach.portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) műveletek alapértelmezés szerint tartalmazzák a normál, master és elrendezés diákot. Használja azok túlterheléseit az `includeNotes` paraméter `true` értékre állításával, ha a jegyzet diakat is bele szeretné foglalni.

**Mi a különbség a ForEach.shape és a Collect.shapes között?**

Használja a [ForEach.shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) metódust, ha minden alakzatot azonnal egy visszahíváson keresztül kíván feldolgozni. Használja a [Collect.shapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) metódust, ha egy iterálható eredményre van szüksége, amelyet megtarthat, szűrhet, megszámolhat vagy többször bejárhat.

**Mindig kisebbre csökkenti a Compress a prezentáció fájlt?**

Nem feltétlenül. Az eredmény attól függ, hogy a prezentáció tartalmaz-e fel nem használt elrendezéseket, fel nem használt mastereket vagy beágyazott betűtípusokat fel nem használt karakterekkel. Ha ezek közül egyik sem van jelen, a megfelelő [Compress](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/) műveletek nem csökkenthetik a fájl méretét.

**A ForEach vagy Compress által végrehajtott változtatások automatikusan mentődnek?**

Nem. Ezek a segítők a memóriában betöltött [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) objektumon dolgoznak. A [ForEach](https://reference.aspose.com/slides/hu/java/com.aspose.slides/foreach/) visszahíváson belüli elem módosítása vagy a [Compress](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compress/) futtatása után hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust az eredmény írásához.

## **Kapcsolódó cikkek**

- [Convert Presentation](/java/convert-presentation/)
- [Merge Presentations](/java/merge-presentation/)
- [Slide Master](/java/slide-master/)
- [Manage Text Box](/java/manage-textbox/)
- [Embedded Font](/java/embedded-font/)