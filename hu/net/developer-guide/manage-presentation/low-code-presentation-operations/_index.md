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
- nem használt master diák eltávolítása
- nem használt elrendezési diák eltávolítása
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

Az [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) névtér statikus segédosztályokat biztosít a gyakori prezentációs műveletekhez. Ezek a segédek a gyakran használt objektummodell munkafolyamatokat fókuszált módszerekbe csomagolják, így kevesebb kóddal konvertálhat vagy egyesíthet fájlokat, feldolgozhat prezentációelemeket, gyűjthet alakzatokat, és eltávolíthatja a nem használt tartalmat.

Az alacsony kódú segédek akkor a leghasznosabbak, ha a művelet egy teljes fájlra vagy prezentációra vonatkozik, és az alapértelmezett munkafolyamat megfelel az igényeinek. Használja a teljes [Aspose.Slides objektummodellt](https://reference.aspose.com/slides/net/aspose.slides/) amikor finomhangolt irányítást kell gyakorolnia az egyes diák, masterek, elrendezések, alakzatok, exportbeállítások vagy a prezentációelemek közötti kapcsolatok felett.

Az alábbi táblázat összegzi az elérhető segédprogramokat:

| Segédfunkció | Mire használható |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | Prezentáció átalakítása egy másik formátumba közvetlen fájl‑fájl hívással. |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | Az azonos formátumú teljes prezentációs fájlok egyesítése. |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | Művelet végrehajtása minden diára, alakzatra, bekezdésre vagy szövegrészre. |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | Alakzatok lekérése a teljes prezentációból ismételt feldolgozás vagy elemzés céljából. |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | Nem használt masterek/elrendezések eltávolítása, a beágyazott betűkészlet adatok csökkentése és képek tömörítése. |

## **Prezentáció konvertálása**

Használja a [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/)‑t akkor, amikor a kimeneti fájl kiterjesztése elegendő az exportformátum kiválasztásához. A metódus megnyitja a forrásprezentációt, meghatározza a szükséges formátumot a kimeneti útvonalból, és írja az eredményt.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

A [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) osztály további dedikált metódusokat kínál PDF, SVG, JPEG, PNG és TIFF kimenethez. Használja a teljes objektummodellt, ha a prezentációt exportálás előtt vizsgálni vagy módosítani kell, vagy olyan exportbeállítást kell konfigurálni, amelyet a kiválasztott segéd nem kínál. Lásd a [Convert Presentation](/slides/hu/net/convert-presentation/) oldalt a formátumspecifikus munkafolyamatokért és beállításokért.

## **Prezentációk egyesítése**

Használja a [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/)‑t a teljes prezentációs fájlok egy hívással történő egyesítéséhez. A bemeneti prezentációknak azonos fájlformátummal kell rendelkezniük.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

A segéd akkor megfelelő, ha minden diát egy eredménybe szeretne hozzáfűzni anélkül, hogy egyenként kiválasztaná vagy átképezi őket. Használja a teljes objektummodellt, ha kiválasztott diák egyesítésére, célmaster vagy -elrendezés alkalmazására, szekciók kifejezett megtartására, vagy különböző diaméretek összehangolására van szükség. Lásd a [Merge Presentations](/slides/hu/net/merge-presentation/) oldalt ezekhez a forgatókönyvekhez.

## **Prezentációelemek bejárása**

A [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) osztály visszahívást hív meg a kért típusú prezentációelem minden egyes példányára. Elkerüli a beágyazott gyűjteményciklusokat, és kényelmes a teljes prezentáció átfogó ellenőrzéséhez vagy formázási változtatásokhoz.

Az alábbi példa a [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), és [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) használatával vizsgálja a megfelelő elemeket:

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

Alapértelmezés szerint a teljes prezentáció alakzat- és szövegbejárása a normál, master és layout diákat is tartalmazza. Az `includeNotes` paraméterrel ellátott túlterhelések a jegyzetdiakat is feldolgozhatják. Használjon közvetlen gyűjteményciklusokat, ha a bejárási sorrend, a korai kilépés, a visszahívás előtt történő szűrés vagy a részletes szülő‑gyermek vezérlés fontos.

## **Alakzatok gyűjtése**

Használja a [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/)‑t, ha az összes alakzat gyűjteményére van szükség a prezentációban, ahelyett, hogy minden alakzat esetén visszahívást használná. Ez akkor hasznos, amikor ugyanazt a halmazt többször szűrni, számolni vagy feldolgozni kell.

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

Használja a [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/)‑t helyette, ha minden alakzatot azonnal kezelhet, és nincs szükség a gyűjtött eredmény megtartására.

## **Prezentáció tartalmának tömörítése**

A [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) osztály képes eltávolítani a nem használt szerkezeti elemeket és csökkenteni a beágyazott betűkészlet adatokat:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) eltávolítja azokat a layout diákat, amelyeket egyetlen normál dia sem hivatkozik.  
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) eltávolítja a már nem használt master diákat.  
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) eltávolítja a beágyazott betűkészletekből a nem használt karaktereket.

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

Először távolítsa el a nem használt elrendezéseket, majd a nem használt mastereket, hogy a layout tisztítása után hivatkozás nélküli master is eltávolítható legyen. Mentse az optimalizált prezentációt új fájlba, ha később szüksége lehet az eredeti masterekre, elrendezésekre vagy a teljes beágyazott betűkészlet adatokra. További részletekért lásd a [Slide Master](/slides/hu/net/slide-master/) és a [Embedded Font](/slides/hu/net/embedded-font/) oldalt.

### **A teljes prezentáció tömörítése**

Az Aspose.Slides for .NET 26.11 hozzáadja a [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/)‑t. Ez kombinálja a nem használt layout/master diák eltávolítását, a beágyazott betűkészletek csak a használt karakterekre való részhalmazát, és a képek 150 DPI‑os tömörítését. Használja a fentiekben leírt egyedi műveleteket, ha pontosan szabályozni szeretné, mely változtatások alkalmazásra kerülnek.

Telepítse az [Aspose.Slides for .NET](/slides/hu/net/installation/) 26.11 vagy későbbi verziót, és adja meg a `input.pptx` fájlt. Mentse külön fájlba: a eltávolított elrendezések, betűkarakterek és a levágott képpontok későbbi szerkesztéshez szükségesek lehetnek.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **Képek tömörítése a kívánt felbontásban**

Használja a [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/)‑t a megfelelő képek feldolgozásához anélkül, hogy az elrendezéseket eltávolítaná vagy a betűkészleteket részhalmazra szűrné. Ez a példa 96 DPI‑ot használ; válasszon másik [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) értéket a kívánt kimenethez.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Mindkét segéd a következő képfeldolgozási hatókört használja:

| Tartalom | Kezelés |
| --- | --- |
| Raster képek és alakzat képkitöltések normál, master és layout diákon, beleértve a csoportosított alakzatokat | Kompresszióra jogosult. |
| Már a kért felbontásnál alacsonyabb vagy egyenlő felbontású képek | Nincs feljavítva. A levágott területek még mindig eltávolíthatók. |
| Levágott képközeg | A rejtett pixelek véglegesen eltávolításra kerülnek, a vágás eltolásai visszaállnak. |
| Dia hátterek és táblázatcellák kitöltése | Ezek a segédek nem dolgozzák fel. |
| Diagram/SmartArt belső elemei, GIF és vektor formátumok, mint az SVG, EMF és WMF | A dokumentált kép‑tömörítési hatáskörön kívül. |

A 26.11‑ben a [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) elkerüli a nem levágott kép felbontás‑alapú lecsökkentését, de **nem őrzi meg a levágott pixeleket**. Egy levágott képet még mindig újraírhat a rejtett területek eltávolításával. Egyik segéd sem kínál megőrzés‑vágás opciót. Egyedi vezérléshez lásd a [per-picture compression example](/slides/hu/net/examples/optimization-batch/compression/) példát.

Hasonlítsa össze a kimenet megjelenését és fájlméretét, mielőtt lecserélné az eredetit. A megtakarítások a forrásképektől, azok megjelenített méretétől és a nem használt tartalomtól függenek; a tömörítés nem garantálja a kisebb fájlt. Lásd a [Embedded Fonts](/slides/hu/net/embedded-font/) oldalt a betűkészlet részhalmazolás következményeiről.

## **GYIK**

**Mikor kell az alacsony kódú API‑t használni a teljes objektummodell helyett?**

Használjon alacsony kódú segédprogramokat, ha egy szabványos művelet egy teljes fájlra vagy prezentációra vonatkozik, és nem igényel részletes irányítást az egyes elemek felett. Használja a teljes objektummodellt, ha konkrét diák kiválasztására, a master és layout kapcsolatok vezérlésére, a köztes állapot ellenőrzésére vagy olyan viselkedés konfigurálására van szükség, amelyet a segéd nem tesz elérhetővé.

**Tud-e a Merger különböző fájlformátumú prezentációkat egyesíteni?**

Nincs. A [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) megköveteli, hogy a bemeneti prezentációk azonos formátumban legyenek. Először konvertálja a bemeneti fájlokat egy közös formátumba, például a [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) segítségével, majd egyesítse a konvertált fájlokat.

**A ForEach feldolgozza a master, layout és jegyzet diákat?**

A [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) a normál prezentációs diákon iterál. A teljes prezentációra kiterjedő [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) és [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) műveletek alapértelmezés szerint a normál, master és layout diákat is tartalmazzák. Használja azok túlterheléseit `includeNotes` = `true` értékkel a jegyzetdiák belefoglalásához.

**Mi a különbség a ForEach.Shape és a Collect.Shapes között?**

Használja a [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/)‑t, ha minden alakzatot azonnal egy visszahíváson keresztül akar feldolgozni. Használja a [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/)‑t, ha egy olyan enumerálható eredményre van szüksége, amelyet megtarthat, szűrhet, számolhat vagy többször bejárhat.

**A Compress mindig kisebbé teszi a prezentációs fájlt?**

Nem feltétlenül. A megtakarítások a nem használt elrendezések/masterek, a nem használt karaktereket tartalmazó beágyazott betűkészletek és a tömörítésből profitáló képek függvényei. A [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) segédprogramok bizonyos bemenetek esetén a méretet változatlanul hagyhatják vagy nagyobb fájlt is eredményezhetnek. Hasonlítsa össze a méretet és a megjelenített minőséget, és tartsa meg az eredetit.

**A ForEach vagy Compress által végzett változtatások automatikusan mentődnek?**

Nincs. Ezek a segédprogramok a memóriában betöltött [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) objektumon dolgoznak. A [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) visszahívásban vagy a [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) futtatása után hívja meg a [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)‑t az eredmény írásához.

## **Kapcsolódó cikkek**

- [Prezentáció konvertálása](/slides/hu/net/convert-presentation/)
- [Prezentációk egyesítése](/slides/hu/net/merge-presentation/)
- [Dia master](/slides/hu/net/slide-master/)
- [Szövegdoboz kezelése](/slides/hu/net/manage-textbox/)
- [Beágyazott betűkészlet](/slides/hu/net/embedded-font/)