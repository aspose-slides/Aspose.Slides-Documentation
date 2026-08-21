---
title: Alacsony kódú előadásműveletek C++-ban
linktitle: Alacsony kódú API
type: docs
weight: 50
url: /hu/cpp/low-code-presentation-operations/
keywords:
- alacsony kódú előadás API
- előadás konvertálása
- előadások egyesítése
- diák bejárása
- alakzatok bejárása
- szöveg bejárása
- alakzatok gyűjtése
- előadás tömörítése
- nem használt master diák eltávolítása
- nem használt layout diák eltávolítása
- beágyazott betűkészletek tömörítése
- PowerPoint
- OpenDocument
- előadás
- C++
- Aspose.Slides
description: "Használja az Aspose.Slides alacsony kódú API‑t C++‑ban az előadások konvertálásához és egyesítéséhez, a tartalom bejárásához, alakzatok gyűjtéséhez, valamint az előadás méretének csökkentéséhez."
---
## **Áttekintés**

Az [Aspose::Slides::LowCode](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/) névtér statikus segítőosztályokat biztosít a gyakori előadásműveletekhez. Ezek a segítők a gyakran használt objektummodell-munkafolyamatokat fókuszált metódusokba csomagolják, így kevesebb kóddal konvertálhat vagy egyesíthet fájlokat, feldolgozhatja az előadás elemeit, gyűjthet alakzatokat, és eltávolíthatja a nem használt tartalmat.

A low-code segítők a leghasznosabbak, ha a művelet egy teljes fájlra vagy előadásra vonatkozik, és az alapértelmezett munkafolyamat megfelel az igényeinek. Használja a teljes [Aspose.Slides object model](https://reference.aspose.com/slides/hu/cpp/aspose.slides/) modellt, ha finomhangolt vezérlésre van szüksége az egyes diák, masterek, elrendezések, alakzatok, exportbeállítások vagy az előadás elemei közötti kapcsolatok felett.

Az alábbi táblázat összegzi a rendelkezésre álló segítőket:

| Segítő | Használat célja |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/convert/) | Előadás konvertálása egy másik formátumba közvetlen fájl‑fájl hívással. |
| [Merger](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/merger/) | Az azonos formátumú teljes előadásfájlok egyesítése. |
| [ForEach](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/) | Művelet végrehajtása minden diára, alakzatra, bekezdésre vagy szövegrészre. |
| [Collect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/collect/) | Alakzatok lekérése az egész előadásból ismételt feldolgozás vagy elemzés céljából. |
| [Compress](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/) | Nem használt masterek és elrendezések eltávolítása, valamint a beágyazott betűkészlet-adatok csökkentése. |

## **Előadás konvertálása**

Használja a [Convert::AutoByExtension](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/convert/autobyextension/) módszert, ha a kimeneti fájl kiterjesztése elegendő az exportformátum kiválasztásához. A metódus megnyitja a forrás előadást, meghatározza a szükséges formátumot a kimeneti útvonalból, és kiírja az eredményt.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

A [Convert](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/convert/) osztály dedikált metódusokat is kínál PDF, SVG, JPEG, PNG és TIFF kimenethez. Használja a teljes objektummodellt, ha a exportálás előtt meg kell vizsgálnia vagy módosítania kell az előadást, vagy olyan exportbeállítást kell konfigurálnia, amelyet a kiválasztott segítő nem tesz elérhetővé. Lásd a [Convert Presentation](/cpp/convert-presentation/) oldalt a formátumspecifikus munkafolyamatokért és beállításokért.

## **Előadások egyesítése**

Használja a [Merger::Process](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/merger/process/) metódust a teljes előadásfájlok egyetlen hívással történő egyesítésére. A bemeneti előadásoknak azonos fájlformátummal kell rendelkezniük.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

A segítő akkor megfelelő, ha az összes diát egy eredményhez kell hozzáfűzni anélkül, hogy egyenként ki kellene választani vagy átmappelni őket. Használja a teljes objektummodellt, ha kiválasztott diákat kell egyesíteni, célmastert vagy elrendezést kell alkalmazni, szakaszokat kifejezetten meg kell őrizni, vagy különböző diaméreteket kell egységesíteni. Lásd a [Merge Presentations](/cpp/merge-presentation/) oldalt az ilyen esetekhez.

## **Az előadás elemeinek bejárása**

A [ForEach](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/) osztály minden kért előadáselemtípushoz meghív egy visszahívást. Elkerüli a beágyazott gyűjteményciklusokat, és kényelmes az egész előadásra kiterjedő ellenőrzéshez vagy formázási módosításokhoz.

Az alábbi példa a [ForEach::Slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/paragraph/), és [ForEach::Portion](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/portion/) használatával ellenőrzi a megfelelő elemeket:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

Alapértelmezés szerint az egész előadásra kiterjedő alakzat- és szövegbejárás magában foglalja a normál, master és layout diát. Az `includeNotes` paraméterrel rendelkező túlterhelések a jegyzetdiákat is feldolgozhatják. Használjon közvetlen gyűjteményciklusokat, ha a bejárási sorrend, a korai kilépés, a visszahívás előtti szűrés vagy a részletes szülő‑gyermek vezérlés fontos.

## **Alakzatok gyűjtése**

Használja a [Collect::Shapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/collect/shapes/) metódust, ha az előadás összes alakzatának gyűjteményére van szükség egyedi visszahívás helyett. Ez akkor hasznos, ha ugyanazt a halmazt többször szűrni, számolni vagy feldolgozni kell.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Használja inkább a [ForEach::Shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/shape/) metódust, ha minden alakzatot azonnal kezelni lehet, és nincs szükség a gyűjtött eredmény megtartására.

## **Az előadás tartalmának tömörítése**

A [Compress](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/) osztály eltávolíthatja a nem használt szerkezeti elemeket, és csökkentheti a beágyazott betűkészlet-adatokat:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) eltávolítja azokat a elrendezés diát, amelyeket egyetlen normál dia sem hivatkozik.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) eltávolítja azokat a master diát, amelyeket már nem használnak.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) eltávolítja a beágyazott betűkészletekből a nem használt karaktereket.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Először távolítsa el a nem használt elrendezéseket, majd a nem használt mastereket, így a layout tisztítása után a már hivatkozás nélküli master is eltávolítható. Mentse az optimalizált előadást egy új fájlba, ha később szüksége lehet az eredeti masterekre, elrendezésekre vagy a teljes beágyazott betűkészlet-adatra. További részletekért lásd a [Slide Master](/cpp/slide-master/) és az [Embedded Font](/cpp/embedded-font/) oldalakat.

## **GYIK**

**Mikor érdemes a low-code API-t használni a teljes objektummodell helyett?**

Használja a low-code segítőket, ha egy szabványos művelet teljes fájlra vagy előadásra vonatkozik, és nem igényel részletes vezérlést az egyes elemek felett. Használja a teljes objektummodellt, ha konkrét diákat kell kiválasztania, master és elrendezés kapcsolatait kell irányítania, köztes állapotot kell ellenőriznie, vagy olyan viselkedést kell konfigurálnia, amelyet a segítő nem tesz elérhetővé.

**A Merger különböző fájlformátumú előadásokat is képes egyesíteni?**

Nem. A [Merger::Process](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/merger/process/) csak azonos formátumú bemeneti előadásokat igényel. Először konvertálja a bemeneti fájlokat egy közös formátumba, például a [Convert::AutoByExtension](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/convert/autobyextension/) használatával, majd egyesítse a konvertált fájlokat.

**A ForEach feldolgozza a master, layout és jegyzetdiákat?**

[ForEach::Slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/slide/) a normál előadásdiákon iterál. Az egész előadásra kiterjedő [ForEach::Shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/paragraph/) és [ForEach::Portion](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/portion/) műveletek alapértelmezés szerint a normál, master és layout diákot is tartalmazzák. Használja a `includeNotes` paraméter `true` értékkel ellátott túlterheléseiket a jegyzetdiák bevonásához.

**Mi a különbség a ForEach::Shape és a Collect::Shapes között?**

Használja a [ForEach::Shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/shape/) metódust, ha minden alakzatot azonnal egy visszahíváson keresztül kell feldolgozni. Használja a [Collect::Shapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/collect/shapes/) metódust, ha egy enumerálható eredményre van szükség, amely megtartható, szűrhető, számolható vagy többször bejárható.

**A Compress mindig kisebbre csökkenti az előadás fájlját?**

Nem feltétlenül. Az eredmény attól függ, hogy az előadás tartalmaz-e nem használt elrendezéseket, nem használt mastereket vagy beágyazott betűkészleteket nem használt karakterekkel. Ha egyik sem áll fenn, a megfelelő [Compress] műveletek nem csökkenthetik a fájlméretet.

**A ForEach vagy a Compress által végzett változtatások automatikusan mentésre kerülnek?**

Nem. Ezek a segítők a betöltött [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumon memóriában dolgoznak. A [ForEach] visszahívásban vagy a [Compress] futtatása után hívja meg a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódust a módosítások kiírásához.

## **Kapcsolódó cikkek**

- [Előadás konvertálása](/cpp/convert-presentation/)
- [Előadások egyesítése](/cpp/merge-presentation/)
- [Dia master](/cpp/slide-master/)
- [Szövegdoboz kezelése](/cpp/manage-textbox/)
- [Beágyazott betűkészlet](/cpp/embedded-font/)