---
title: Alacsony kódú prezentációs műveletek .NET-ben
linktitle: Alacsony kódú API
type: docs
weight: 50
url: /hu/net/low-code-presentation-operations/
keywords:
- alacsony kódú prezentáció API
- prezentáció konvertálása
- prezentációk egyesítése
- diák bejárása
- alakzatok bejárása
- szöveg bejárása
- alakzatok gyűjtése
- prezentáció tömörítése
- nem használt mesterdiák eltávolítása
- nem használt elrendezésdiák eltávolítása
- beágyazott betűkészletek tömörítése
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Használja az Aspose.Slides alacsony kódú API-t .NET-ben a prezentációk konvertálásához és egyesítéséhez, a tartalom bejárásához, az alakzatok gyűjtéséhez, valamint a prezentáció méretének csökkentéséhez."
---
## **Áttekintés**

Az [Aspose.Slides.LowCode](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/) névtér statikus segédosztályokat biztosít a gyakori prezentációs műveletekhez. Ezek a segédek a gyakran használt objektummodell‑munkafolyamatokat fókuszált metódusokba vonják, így kevesebb kóddal konvertálhat vagy egyesíthet fájlokat, feldolgozhatja a prezentációelemeket, gyűjtheti az alakzatokat, és eltávolíthatja a nem használt tartalmat.

A low‑code segédek a leghasznosabbak, ha a művelet egy teljes fájlra vagy prezentációra vonatkozik, és az alapértelmezett munkafolyamat megfelel az igényeinek. Használja a teljes [Aspose.Slides objektummodellt](https://reference.aspose.com/slides/hu/net/aspose.slides/), ha finomhangolt vezérlésre van szüksége egyedi diák, mester‑, elrendezés‑, alakzat‑, export‑beállítások vagy a prezentációelemek közötti kapcsolatok tekintetében.

Az alábbi táblázat összefoglalja a rendelkezésre álló segédeket:

| Segédprogram | Mire használható |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/convert/) | Prezentáció konvertálása másik formátumba egy közvetlen fájl‑fájl hívással. |
| [Merger](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/merger/) | Azonos formátumú teljes prezentációfájlok egyesítése. |
| [ForEach](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/) | Művelet végrehajtása minden dia, alakzat, bekezdés vagy szövegrész esetén. |
| [Collect](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/collect/) | Alakzatok lekérdezése a teljes prezentációból ismételt feldolgozás vagy elemzés céljából. |
| [Compress](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/) | Nem használt mesterek és elrendezések eltávolítása, valamint a beágyazott betűkészlet‑adatok csökkentése. |

## **Prezentáció konvertálása**

Használja a [Convert.AutoByExtension](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/convert/autobyextension/) metódust, ha a kimeneti fájlkiterjesztés elegendő az export formátum kiválasztásához. A metódus megnyitja a forrás‑prezentációt, meghatározza a szükséges formátumot a kimeneti útvonal alapján, és kiírja az eredményt.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

A [Convert](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/convert/) osztály dedikált metódusokat is biztosít PDF, SVG, JPEG, PNG és TIFF kimenethez. Használja a teljes objektummodellt, ha a konvertálás előtt vizsgálni vagy módosítani kell a prezentációt, vagy ha olyan export‑opciót kell beállítani, amelyet a kiválasztott segéd nem tesz elérhetővé. Lásd a [Convert Presentation](/slides/hu/net/convert-presentation/) oldalt a formátumspecifikus munkafolyamatokért és beállításokért.

## **Prezentációk egyesítése**

Használja a [Merger.Process](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/merger/process/) metódust a teljes prezentációfájlok egy hívással történő egyesítéséhez. A bemeneti prezentációknak azonos fájlformátummal kell rendelkezniük.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Ez a segéd akkor megfelelő, ha minden diát egy eredménybe kell fűzni anélkül, hogy azokat egyenként kellene kiválasztani vagy újratervezni. Használja a teljes objektummodellt, ha kiválasztott diák egyesítésére, cél‑mester vagy elrendezés alkalmazására, szekciók explicitt megtartására vagy eltérő diaméretek egyeztetésére van szükség. Lásd a [Merge Presentations](/slides/hu/net/merge-presentation/) oldalt az ilyen forgatókönyvekhez.

## **Prezentációelemek bejárása**

A [ForEach](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/) osztály visszahívást hív meg minden kért típusú prezentációelem esetén. Elkerüli a beágyazott gyűjtés‑ciklusokat, és kényelmes a prezentációszintű ellenőrzéshez vagy formázási változtatásokhoz.

Az alábbi példa a [ForEach.Slide](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/paragraph/) és a [ForEach.Portion](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/portion/) használatát mutatja a megfelelő elemek bejárásához:

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

Alapértelmezés szerint a prezentációszintű alakzat‑ és szövegvégigjárás a normál, mester‑ és elrendezés‑diákat is tartalmazza. Az `includeNotes` paraméterrel rendelkező túlterhelések a jegyzetdiákat is feldolgozhatják. Használjon közvetlen gyűjtés‑ciklusokat, ha a bejárási sorrend, korai kilépés, visszahívás előtti szűrés vagy a részletes szülő‑gyermek ellenőrzés fontos.

## **Alakzatok gyűjtése**

Használja a [Collect.Shapes](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/collect/shapes/) metódust, ha a prezentáció összes alakzatának gyűjteményére van szüksége, ahelyett, hogy minden alakzat esetén visszahívást kapna. Ez akkor hasznos, ha ugyanazt a halmazt többször kell szűrni, számolni vagy feldolgozni.

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

Használja a [ForEach.Shape](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/shape/) metódust, ha minden alakzatot azonnal kezelni tud, és nincs szükség a gyűjtött eredmény megtartására.

## **Prezentáció tartalmának tömörítése**

A [Compress](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/) osztály képes eltávolítani a nem használt struktúralelemeket és csökkenteni a beágyazott betűkészlet‑adatokat:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) eltávolítja az olyan elrendezési diákat, amelyekre egyetlen normál dia sem hivatkozik.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) eltávolítja a már nem használt mester‑diákat.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/compressembeddedfonts/) eltávolítja a beágyazott betűkészletekből a nem használt karaktereket.

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

Először távolítsa el a nem használt elrendezéseket, majd a nem használt mestereket, hogy a layout‑takarítás után keletkező referenciamentes mester is eltávolítható legyen. Mentse az optimalizált prezentációt egy új fájlba, ha később szüksége lehet az eredeti mesterekre, elrendezésekre vagy a teljes beágyazott betűkészlet‑adatra. További részletekért lásd a [Slide Master](/slides/hu/net/slide-master/) és [Embedded Font](/slides/hu/net/embedded-font/) oldalakat.

## **GYIK**

**Mikor kellene a low‑code API‑t használni a teljes objektummodell helyett?**

Használja a low‑code segédeket, ha egy szabványos művelet egy teljes fájlra vagy prezentációra vonatkozik, és nem igényel részletes vezérlést az egyedi elemek felett. Használja a teljes objektummodellt, ha specifikus diák kiválasztására, a mester‑ és elrendezés‑kapcsolatok szabályozására, köztes állapot ellenőrzésére vagy olyan viselkedés konfigurálására van szükség, amelyet a segéd nem tesz elérhetővé.

**Kombinálhatja-e a Merger a különböző fájlformátumú prezentációkat?**

Nem. A [Merger.Process](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/merger/process/) ugyanolyan formátumú bemeneti prezentációkat igényel. Először konvertálja a bemeneti fájlokat egy közös formátumba, például a [Convert.AutoByExtension](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/convert/autobyextension/) segítségével, majd egyesítse a konvertált fájlokat.

**A ForEach feldolgozza a mester, elrendezés és jegyzet diákat?**

A [ForEach.Slide](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/slide/) a normál prezentációs diákon iterál. A prezentációszintű [ForEach.Shape](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/paragraph/) és [ForEach.Portion](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/portion/) műveletek alapértelmezés szerint a normál, mester‑ és elrendezés‑diákat is tartalmazzák. Használja a `includeNotes` paramétert `true`‑ra állítva a jegyzetdiák bevonásához.

**Mi a különbség a ForEach.Shape és a Collect.Shapes között?**

Használja a [ForEach.Shape](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/shape/) metódust, ha minden alakzatot azonnal egy visszahívásban akar feldolgozni. Használja a [Collect.Shapes](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/collect/shapes/) metódust, ha egy enumerálható eredményre van szükség, amelyet megtarthat, szűrhet, számolhat vagy többször bejárhat.

**A Compress mindig kisebbé teszi a prezentáció fájlt?**

Nem feltétlenül. Az eredmény attól függ, hogy a prezentáció tartalmaz‑e nem használt elrendezéseket, nem használt mestereket vagy beágyazott betűkészletet nem használt karakterekkel. Ha ezek egyike sem áll fenn, a megfelelő [Compress](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/) művelet nem csökkenti a fájlméretet.

**A ForEach vagy a Compress által végzett módosítások automatikusan mentődnek?**

Nem. Ezek a segédek a memóriában betöltött [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) objektumon dolgoznak. A [ForEach](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/foreach/) visszahívásában vagy a [Compress](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/) futtatása után hívja meg a [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódust az eredmény kiírásához.

## **Kapcsolódó cikkek**

- [Convert Presentation](/slides/hu/net/convert-presentation/)
- [Merge Presentations](/slides/hu/net/merge-presentation/)
- [Slide Master](/slides/hu/net/slide-master/)
- [Manage Text Box](/slides/hu/net/manage-textbox/)
- [Embedded Font](/slides/hu/net/embedded-font/)