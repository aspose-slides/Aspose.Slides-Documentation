---
title: Alacsony kódú prezentációs műveletek .NET-ben
linktitle: Alacsony kódú API
type: docs
weight: 50
url: /hu/net/low-code-presentation-operations/
keywords:
- alacsony kódú prezentációs API
- prezentáció konvertálása
- prezentációk egyesítése
- diák bejárása
- alakzatok bejárása
- szöveg bejárása
- alakzatok gyűjtése
- prezentáció tömörítése
- nem használt master diák eltávolítása
- nem használt elrendezés diák eltávolítása
- beágyazott betűtípusok tömörítése
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Használja az Aspose.Slides alacsony kódú API-t .NET-ben a prezentációk konvertálásához és egyesítéséhez, a tartalom bejárásához, alakzatok gyűjtéséhez, és a prezentáció méretének csökkentéséhez."
---
## **Áttekintés**

Az [Aspose.Slides.LowCode](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/) névtér statikus segédosztályokat biztosít a gyakori prezentációs műveletekhez. Ezek a segédeszközök a gyakran használt objektummodell‑munkafolyamatokat fókuszált metódusokba csomagolják, így fájlokat konvertálhat vagy egyesíthet, feldolgozhatja a prezentáció elemeit, gyűjthet alakzatokat, és kevesebb kóddal eltávolíthatja a nem használt tartalmat.

Az alacsony kódú segédeszközök akkor a leghasznosabbak, ha a művelet egy teljes fájlra vagy prezentációra vonatkozik, és az alapértelmezett munkafolyamat megfelel az igényeinek. Használja a teljes [Aspose.Slides objektummodellt](https://reference.aspose.com/slides/hu/net/aspose.slides/), ha finomhangolt vezérlésre van szüksége az egyes diák, masterek, elrendezések, alakzatok, exportbeállítások vagy a prezentációs elemek közötti kapcsolatok felett.

Az alábbi táblázat összefoglalja a rendelkezésre álló segédeszközöket:

| Segédeszköz | Mire használja |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/convert/) | Prezentáció egy másik formátumba konvertálása közvetlen fájl‑fájl hívással. |
| [Merger](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/merger/) | Ugyanazon formátumú teljes prezentációs fájlok egyesítése. |
| [ForEach](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/) | Művelet végrehajtása minden dián, alakzaton, bekezdésen vagy szövegrészen. |
| [Collect](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/collect/) | Alakzatok lekérése a teljes prezentációból ismételt feldolgozás vagy elemzés céljából. |
| [Compress](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/) | Nem használt masterek és elrendezések eltávolítása, valamint a beágyazott betűtípus‑adatok csökkentése. |

## **Prezentáció konvertálása**

Használja a [Convert.AutoByExtension](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/convert/autobyextension/) módszert, ha a kimeneti fájlkiterjesztés elegendő az exportformátum kiválasztásához. A metódus megnyitja a forrásprezentációt, a kimeneti útvonal alapján meghatározza a szükséges formátumot, és kiírja az eredményt.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

A [Convert](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/convert/) osztály továbbá dedikált metódusokat biztosít a PDF, SVG, JPEG, PNG és TIFF kimenetekhez. Használja a teljes objektummodellt, ha a prezentációt export előtt ellenőrizni vagy módosítani kell, vagy olyan exportbeállítást kell konfigurálni, amelyet a kiválasztott segédeszköz nem biztosít. Tekintse meg a [Convert Presentation](/net/convert-presentation/) oldalt a formátumspecifikus munkafolyamatokért és beállításokért.

## **Prezentációk egyesítése**

Használja a [Merger.Process](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/merger/process/) metódust a teljes prezentációs fájlok egy hívással történő egyesítéséhez. A bemeneti prezentációknak ugyanazzal a fájlformátummal kell rendelkezniük.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

A segédeszköz akkor alkalmas, ha minden diát egy eredménybe kell fűzni anélkül, hogy egyenként kiválasztaná vagy átköpezné őket. Használja a teljes objektummodellt, ha kiválasztott diák egyesítésére, célmaster vagy –elrendezés alkalmazására, szekciók kifejezett megtartására vagy különböző diaméretek egyeztetésére van szükség. Tekintse meg a [Merge Presentations](/net/merge-presentation/) oldalt ezekhez az esetekhez.

## **Prezentációs elemek bejárása**

A [ForEach](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/) osztály visszahívást hajt végre a kért típusú prezentációs elem minden egyes példányára. Elkerüli a belső gyűjteményciklusok használatát, és kényelmes a prezentációt átfogó ellenőrzéshez vagy formázási módosításokhoz.

Az alábbi példa a [ForEach.Slide](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/paragraph/), és a [ForEach.Portion](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/portion/) használatával vizsgálja meg a megfelelő elemeket:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

Alapértelmezés szerint a prezentációt átfogó alakzat‑ és szövegbejárás magában foglalja a normál, master és elrendezés diákat. Az `includeNotes` paraméterrel ellátott túlterhelések a jegyzetdiákat is feldolgozhatják. Használjon közvetlen gyűjteményciklusokat, ha a bejárási sorrend, a korai kilépés, a visszahívás előtti szűrés vagy a részletes szülő‑gyermek vezérlés fontos.

## **Alakzatok gyűjtése**

Használja a [Collect.Shapes](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/collect/shapes/) metódust, ha a prezentáció összes alakzatának gyűjteményére van szükség egy‑egyik alakzatra vonatkozó visszahívás helyett. Ez akkor hasznos, ha ugyanazt a halmazt többször kell szűrni, számolni vagy feldolgozni.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Használja inkább a [ForEach.Shape](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/shape/) metódust, ha minden alakzatot azonnal lehet kezelni, és nincs szükség a gyűjtött eredmény megőrzésére.

## **Prezentáció tartalmának tömörítése**

A [Compress](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/) osztály képes eltávolítani a nem használt szerkezeti elemeket és csökkenteni a beágyazott betűtípus‑adatokat:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) eltávolítja azokat az elrendezés diákat, amelyekre egy normál dia sem hivatkozik.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) eltávolítja a már nem használt master diákat.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/compressembeddedfonts/) eltávolítja a beágyazott betűtípusokból a nem használt karaktereket.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Először távolítsa el a nem használt elrendezéseket a nem használt masterek előtt, hogy az elrendezés tisztítása után hivatkozás nélküli master is eltávolítható legyen. Mentse az optimalizált prezentációt új fájlba, ha később szükség lehet az eredeti masterekre, elrendezésekre vagy a teljes beágyazott betűtípus‑adatokra. További részletekért tekintse meg a [Slide Master](/net/slide-master/) és [Embedded Font](/net/embedded-font/) oldalakat.

## **GYIK**

**Mikor kell az alacsony kódú API-t használni a teljes objektummodell helyett?**

Az alacsony kódú segédeszközöket akkor használja, ha egy szabványos művelet egy teljes fájlra vagy prezentációra vonatkozik, és nincs szükség az egyes elemek részletes vezérlésére. A teljes objektummodellt akkor használja, ha konkrét diák kiválasztására, a master és elrendezés közötti kapcsolatok szabályozására, a köztes állapot ellenőrzésére vagy olyan viselkedés beállítására van szükség, amelyet a segédeszköz nem tesz lehetővé.

**Kombinálhatja a Merger különböző fájlformátumú prezentációkat?**

Nem. A [Merger.Process](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/merger/process/) egyforma formátumú bemeneti prezentációkat igényel. Először konvertálja a bemeneti fájlokat közös formátumba, például a [Convert.AutoByExtension](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/convert/autobyextension/) segítségével, majd egyesítse a konvertált fájlokat.

**A ForEach feldolgozza a master, elrendezés és jegyzet diákat?**

A [ForEach.Slide](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/slide/) a normál prezentációs diákat járja be. A prezentációt átfogó [ForEach.Shape](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/paragraph/), és [ForEach.Portion](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/portion/) műveletek alapértelmezés szerint a normál, master és elrendezés diákat is belefoglalják. Használja azok túlterheléseit, ahol az `includeNotes` értéke `true`, a jegyzetdiák belefoglalásához.

**Mi a különbség a ForEach.Shape és a Collect.Shapes között?**

Használja a [ForEach.Shape](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/shape/) metódust, ha minden alakzatot azonnal egy visszahíváson keresztül szeretne feldolgozni. Használja a [Collect.Shapes](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/collect/shapes/) metódust, ha egy olyan enumerálható eredményre van szüksége, amelyet megőrizhet, szűrhet, számolhat vagy többször bejárhat.

**A Compress mindig kisebbre csökkenti a prezentáció fájlját?**

Nem feltétlenül. Az eredmény attól függ, hogy a prezentáció tartalmaz‑e nem használt elrendezéseket, nem használt mastereket vagy beágyazott betűtípusokat nem használt karakterekkel. Ha ezek egyike sem jelenik meg, a megfelelő [Compress](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/) műveletek nem csökkenthetik a fájl méretét.

**A ForEach vagy a Compress által végzett módosítások automatikusan mentésre kerülnek?**

Nem. Ezek a segédeszközök a betöltött [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) objektumon működnek a memóriában. Az elemek módosítása után egy [ForEach](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/) visszahívásban vagy a [Compress](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/) futtatása után hívja meg a [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódust az eredmény kiírásához.

## **Kapcsolódó cikkek**

- [Prezentáció konvertálása](/net/convert-presentation/)
- [Prezentációk egyesítése](/net/merge-presentation/)
- [Dia master](/net/slide-master/)
- [Szövegdoboz kezelése](/net/manage-textbox/)
- [Beágyazott betűtípus](/net/embedded-font/)