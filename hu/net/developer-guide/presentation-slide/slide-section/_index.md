---
title: Dia szekciók kezelése bemutatókban .NET-ben
linktitle: Dia szekció
type: docs
weight: 100
url: /hu/net/slide-section/
keywords:
- szekció létrehozása
- szekció hozzáadása
- szekció szerkesztése
- szekció módosítása
- szekció neve
- szekció diák lekérése
- szekció diák feldolgozása
- PowerPoint
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Dia szekciók kezelése az Aspose.Slides for .NET segítségével: szekciók létrehozása, átnevezése, átrendezése, lekérése és a szekció diák feldolgozása PPTX bemutatókban."
---
## **Bevezetés**

A szekciók egymást követő diákot szerveznek névvel ellátott csoportokba anélkül, hogy megváltoztatnák a dia tartalmát. Az Aspose.Slides for .NET segítségével szekciókat hozhat létre, átrendezhet, átnevezhet, ellenőrizhet és eltávolíthat a [Presentation.Sections](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/sections/) tulajdonságon keresztül.

A szekciók különösen hasznosak, ha:

- nagy bemutatót logikai témákra vagy fejezetekre kell felosztani;
- a diák különböző csoportjait különböző együttműködőkhöz kell rendelni;
- a diákat csoportokként kell feldolgozni, áthelyezni vagy egyesíteni.

Válasszon rövid szekciónéveket, amelyek leírják a csoportosított diák célját. Mivel a szekciók a bemutató struktúrájának részei, használja a szekció API-kat a tagság meghatározásához ahelyett, hogy a diahelyzetekből következtetne.

## **Szekciók létrehozása és kezelése**

Használja az [ISectionCollection.AddSection](https://reference.aspose.com/slides/hu/net/aspose.slides/sectioncollection/addsection/) metódust szekció létrehozásához a név és a kezdő dia megadásával. Az Aspose.Slides meghatározza, hogy mely diák tartoznak a szekcióhoz a bemutató aktuális szekciószerkezetéből.

Az azonos [ISectionCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/isectioncollection/) emellett lehetővé teszi, hogy:

- áthelyezze a szekciót diái együtt az [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/sectioncollection/reordersectionwithslides/) használatával;
- eltávolítsa csak a szekciódefiníciót a [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/hu/net/aspose.slides/sectioncollection/removesection/) segítségével, amely megtartja a diákat;
- eltávolítson egy szekciót a diáival a [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/sectioncollection/removesectionwithslides/) használatával;
- adj egy üres szekciót a végén a [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/hu/net/aspose.slides/sectioncollection/appendemptysection/) segítségével.

A következő példa két szekciót hoz létre, áthelyezi az egyiket, eltávolítja azt a diáival együtt, és egy üres szekciót fűz hozzá:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

Ezen műveletek után a bemutató tartalmazza az `Introduction` szekciót a diái­val és egy üres `Appendix` szekciót. A `Results` szekció és a diája el lett távolítva.

## **Szekciók átnevezése**

Egy szekció átnevezéséhez állítsa be a [ISection.Name](https://reference.aspose.com/slides/hu/net/aspose.slides/isection/name/) tulajdonságát. A szekció diái és pozíciója változatlan marad.

A következő példa létrehoz egy szekciót és megváltoztatja a nevét:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **Diák lekérése szekciókból**

A [Presentation.Sections](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/sections/) tulajdonság egy [ISectionCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/isectioncollection/) objektumot ad vissza, amelyet felsorolhat. Minden egyes [ISection](https://reference.aspose.com/slides/hu/net/aspose.slides/isection/) esetén hívja meg a [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/hu/net/aspose.slides/isection/getslideslistofsection/) metódust, hogy megkapja a jelenleg hozzá tartozó diákat. A metódus egy [ISectionSlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/isectionslidecollection/) objektumot ad vissza, amely számlálót, indexelt hozzáférést és felsorolást biztosít.

A következő példa két feltöltött szekciót és egy üres szekciót hoz létre, majd kiírja minden szekció [név](https://reference.aspose.com/slides/hu/net/aspose.slides/isection/name/), [azonosító](https://reference.aspose.com/slides/hu/net/aspose.slides/isection/sectionid/), [kezdő dia](https://reference.aspose.com/slides/hu/net/aspose.slides/isection/startedfromslide/), dia számát és diák számaát. A gyűjtemény indexerét használja az első dia olvasásához, és a `foreach` ciklust minden dia feldolgozásához. Az üres szekció esetén a visszakapott gyűjtemény számlálója nulla, az indexer nem kerül elérésre, és a felsorolás nem hajt végre iterációkat.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

A szekció tagságát a bemutató szekciószerkezete határozza meg. Ne számolja ki kézzel egy szekció tartományát a [ISection.StartedFromSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/isection/startedfromslide/) diák indexeiből és a következő szekció kezdő diájából.

A strukturális szerkesztések megváltoztathatják egy szekcióhoz visszaadott diák számát és azok diaszámát is. Ez magában foglalja a diák átrendezését, egy dia klónozását egy szekcióba, a szekció áthelyezését diái együtt, diák eltávolítását és szekciók eltávolítását. A következő példa minden ilyen változtatás után meghívja a [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/hu/net/aspose.slides/isection/getslideslistofsection/) metódust, ahelyett, hogy a szekció korábbi határait feltételezné.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

Hívja újra a [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/hu/net/aspose.slides/isection/getslideslistofsection/) metódust, amikor a diák vagy szekciók átrendezésre, klónozásra, áthelyezésre vagy eltávolításra kerülnek. Ez biztosítja, hogy a további feldolgozás a jelenlegi bemutatószerkezettel összhangban legyen.

A PPT (PowerPoint 97–2003) formátum nem őrzi meg a szekció metaadatait. Használja ezt a munkafolyamatot olyan formátummal, amely támogatja a szekciókat, például PPTX; a PPT-re konvertálás eltávolítja a későbbi felsoroláshoz szükséges szekciószerkezetet.

## **GYIK**

**Megmaradnak-e a szekciók a PPT (PowerPoint 97–2003) formátumba mentéskor?**

Nem. A PPT formátum nem támogatja a szekció metaadatait, ezért a szekciócsoportosítás elveszik, amikor .ppt formátumba ment.

**Lehetséges egy egész szekciót „elrejteni”?**

Nem. A szekciónak nincs láthatósági állapota. A tartalma elrejtéséhez állítsa be az [ISlide.Hidden](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/hidden/) tulajdonságot a szekció minden egyes diájánál.

**Hogyan találom meg azt a szekciót, amelyik egy diát tartalmaz?**

Sorolja fel a [Presentation.Sections](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/sections/) elemeket, hívja meg a [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/hu/net/aspose.slides/isection/getslideslistofsection/) metódust minden szekciónál, és hasonlítsa össze a visszaadott diákat a céldiallel. Egy nem üres szekció esetén a [ISection.StartedFromSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/isection/startedfromslide/) visszaadja az első diát; egy üres szekció esetén `null`-t ad vissza.