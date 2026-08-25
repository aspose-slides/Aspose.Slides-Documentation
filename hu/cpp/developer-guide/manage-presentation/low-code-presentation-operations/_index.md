---
title: Alacsony kódkódú prezentációs műveletek C++-ban
linktitle: Alacsony kódkódú API
type: docs
weight: 50
url: /hu/cpp/low-code-presentation-operations/
keywords:
- alacsony kódkódú prezentáció API
- prezentáció átalakítása
- prezentációk egyesítése
- diák bejárása
- alakzatok bejárása
- szöveg bejárása
- alakzatok összegyűjtése
- prezentáció tömörítése
- nem használt master diák eltávolítása
- nem használt elrendezés diák eltávolítása
- beágyazott betűkészletek tömörítése
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Használja az Aspose.Slides alacsony kódkódú API-t C++-ban prezentációk átalakításához és egyesítéséhez, a tartalom bejárásához, alakzatok összegyűjtéséhez, valamint a prezentáció méretének csökkentéséhez."
---
## **Áttekintés**

Az [Aspose::Slides::LowCode](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/) névtér statikus segédosztályokat biztosít a gyakori prezentációs műveletekhez. Ezek a segítők a gyakran használt objektummodell-munkafolyamatokat fókuszált metódusokba csomagolják, így kevesebb kóddal konvertálhat vagy egyesíthet fájlokat, feldolgozhatja a prezentáció elemeit, összegyűjtheti az alakzatokat, és eltávolíthatja a nem használt tartalmat.

Az alacsony kódszintű segítők akkor a leghasznosabbak, ha a művelet egy teljes fájlra vagy prezentációra vonatkozik, és az alapértelmezett munkafolyamat megfelel az igényeinek. Használja a teljes [Aspose.Slides objektummodellt](https://reference.aspose.com/slides/hu/cpp/aspose.slides/), ha finomabb irányítást igényel egyes diák, masterek, elrendezések, alakzatok, exportbeállítások vagy a prezentációs elemek közötti kapcsolatok felett.

Az alábbi táblázat összefoglalja a rendelkezésre álló segítőket:

| Segédprogram | Használat célja |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/convert/) | Prezentáció konvertálása más formátumba közvetlen fájl‑fájl hívással. |
| [Merger](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/merger/) | Ugyanazon formátumú teljes prezentációs fájlok egyesítése. |
| [ForEach](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/) | Művelet végrehajtása minden diára, alakzatra, bekezdésre vagy szövegrészre. |
| [Collect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/collect/) | Alakzatok lekérdezése a teljes prezentációból ismételt feldolgozás vagy elemzés céljából. |
| [Compress](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/) | Nem használt masterek és elrendezések eltávolítása, valamint a beágyazott betűkészlet-adatok csökkentése. |

## **Prezentáció konvertálása**

Használja a [Convert::AutoByExtension](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/convert/autobyextension/) metódust, ha a kimeneti fájl kiterjesztése elegendő az exportformátum kiválasztásához. A metódus megnyitja a forrásprezentációt, a kimeneti útvonal alapján meghatározza a szükséges formátumot, és kiírja az eredményt.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

A [Convert](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/convert/) osztály dedikált metódusokat is biztosít PDF, SVG, JPEG, PNG és TIFF kimenethez. Használja a teljes objektummodellt, ha a konvertálás előtt meg kell vizsgálnia vagy módosítania a prezentációt, vagy olyan exportbeállítást kell konfigurálnia, amelyet a kiválasztott segédprogram nem tesz elérhetővé. Lásd a [Convert Presentation](/slides/hu/cpp/convert-presentation/) oldalt a formátumspecifikus munkafolyamatokért és beállításokért.

## **Prezentációk egyesítése**

Használja a [Merger::Process](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/merger/process/) metódust a teljes prezentációs fájlok egy hívással történő egyesítéséhez. A bemeneti prezentációknak azonos fájlformátummal kell rendelkezniük.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

Ez a segédprogram akkor megfelelő, ha minden diát egy eredményfájlba kell hozzáfűzni anélkül, hogy egyenként választaná vagy térképezné őket. Használja a teljes objektummodellt, ha kiválasztott diák egyesítésére, célmaster vagy -elrendezés alkalmazására, szekciók kifejezett megőrzésére vagy különböző diaméretek egyeztetésére van szükség. Lásd a [Merge Presentations](/slides/hu/cpp/merge-presentation/) oldalt ezekhez a forgatókönyvekhez.

## **Prezentációs elemek bejárása**

A [ForEach](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/) osztály minden kért típusú prezentációs elemhez meghív egy visszahívást. Elkerüli a beágyazott gyűjteményhurok használatát, és kényelmes a prezentáció egészére kiterjedő ellenőrzéshez vagy formázási módosításokhoz.

Az alábbi példa a [ForEach::Slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/paragraph/) és [ForEach::Portion](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/portion/) használatával szemlélteti a megfelelő elemek ellenőrzését:

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

Alapértelmezés szerint a prezentációs szintű alakzat‑ és szövegbejárás a normál, master és layout diákot is tartalmazza. Az `includeNotes` paraméterrel ellátott túltöltések lehetővé teszik a jegyzetdiák feldolgozását is. Használjon közvetlen gyűjteményhurok‑iterációt, ha a bejárási sorrend, korai kilépés, a visszahívás előtti szűrés vagy a részletes szülő‑gyermek vezérlés fontos.

## **Alakzatok összegyűjtése**

Használja a [Collect::Shapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/collect/shapes/) metódust, ha a prezentáció összes alakzatra kíván gyűjteményt, nem pedig egy visszahívást minden egyes alakzatra. Ez akkor hasznos, ha ugyanazt a halmazt többször kell szűrni, számlálni vagy feldolgozni.

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

Használja a [ForEach::Shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/shape/) metódust, ha minden alakzatot azonnal kezelhet, és nincs szükség a begyűjtött eredmény megtartására.

## **Prezentáció tartalmának tömörítése**

A [Compress](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/) osztály képes eltávolítani a nem használt szerkezeti elemeket és csökkenteni a beágyazott betűkészlet-adatokat:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) eltávolítja az olyan elrendezésdiákat, amelyekre egyetlen normál dia sem hivatkozik.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) eltávolítja a már nem használt masterdiákat.
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

Először távolítsa el a nem használt elrendezéseket, majd a nem használt mastereket, hogy a layout‑tisztítás után referálatlanná váló master is eltávolítható legyen. Mentse az optimalizált prezentációt új fájlba, ha később szüksége lehet az eredeti masterekre, elrendezésekre vagy a teljes beágyazott betűkészletre. További részletekért lásd a [Slide Master](/slides/hu/cpp/slide-master/) és az [Embedded Font](/slides/hu/cpp/embedded-font/) oldalakat.

## **GYIK**

**Mikor használjam a low‑code API‑t a teljes objektummodell helyett?**

Használja az alacsony kódszintű segítőket, ha egy szabványos művelet egy teljes fájlra vagy prezentációra vonatkozik, és nem igényel részletes irányítást az egyedi elemek felett. Használja a teljes objektummodellt, ha konkrét diák kiválasztására, master‑ és layout‑kapcsolatok vezérlésére, köztes állapot ellenőrzésére vagy olyan viselkedés konfigurálására van szükség, amelyet a segédprogram nem biztosít.

**A Merger össze tud-e kapcsolni különböző fájlformátumú prezentációkat?**

Nem. A [Merger::Process](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/merger/process/) csak azonos formátumú bemeneti prezentációkat fogad el. Először konvertálja a bemeneti fájlokat közös formátumba, például a [Convert::AutoByExtension](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/convert/autobyextension/) segítségével, majd egyesítse a konvertált fájlokat.

**A ForEach feldolgozza a master, layout és jegyzetdiákat?**

A [ForEach::Slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/slide/) a normál prezentációs diákon iterál. A prezentáció egészére kiterjedő [ForEach::Shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/paragraph/) és [ForEach::Portion](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/portion/) műveletek alapértelmezés szerint a normál, master és layout diákot is tartalmazzák. Használja a `includeNotes` paramétert `true`‑ra állítva, ha a jegyzetdiákat is bele akarja vonni.

**Mi a különbség a ForEach::Shape és a Collect::Shapes között?**

Használja a [ForEach::Shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/shape/) metódust, ha minden alakzatot azonnal egy visszahíváson keresztül szeretne feldolgozni. Használja a [Collect::Shapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/collect/shapes/) metódust, ha egy olyan enumerálható eredményre van szüksége, amelyet megőriz, szűr, számol vagy többször bejárhat.

**A Compress mindig kisebbé teszi a prezentáció fájlt?**

Nem feltétlenül. Az eredmény attól függ, hogy a prezentáció tartalmaz‑e nem használt elrendezéseket, mastereket vagy beágyazott betűkészleteket nem használt karakterekkel. Ha ezek egyike sincs jelen, a megfelelő [Compress](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/) műveletek nem feltétlenül csökkentik a fájl méretét.

**A ForEach vagy a Compress által végrehajtott változtatások automatikusan mentődnek?**

Nem. Ezek a segítők a memóriában betöltött [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumon dolgoznak. A [ForEach](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/foreach/) visszahívásban vagy a [Compress](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/) futtatása után hívja meg a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódust a változtatások kiírásához.

## **Kapcsolódó cikkek**

- [Convert Presentation](/slides/hu/cpp/convert-presentation/)
- [Merge Presentations](/slides/hu/cpp/merge-presentation/)
- [Slide Master](/slides/hu/cpp/slide-master/)
- [Manage Text Box](/slides/hu/cpp/manage-textbox/)
- [Embedded Font](/slides/hu/cpp/embedded-font/)