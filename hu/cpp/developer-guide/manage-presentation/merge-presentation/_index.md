---
title: Hatékony prezentációk egyesítése C++-ban
linktitle: Prezentációk egyesítése
type: docs
weight: 40
url: /hu/cpp/merge-presentation/
keywords:
- PowerPoint összevonása
- prezentációk összevonása
- diák összevonása
- PPT összevonása
- PPTX összevonása
- ODP összevonása
- PowerPoint egyesítése
- prezentációk egyesítése
- diák egyesítése
- PPT egyesítése
- PPTX egyesítése
- ODP egyesítése
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan lehet C++-ban PowerPoint és OpenDocument prezentációkat egyesíteni diák klónozásával, a mesterek és elrendezések irányításával, a dia tartalom átméretezésével, a szekciók megőrzésével, valamint a védett vagy nagy fájlok kezelésével."
---
## **Áttekintés**

Az Aspose.Slides for C++ prezentációkat egyesíti a diák klónozásával az egyik [Prezentáció](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/)ból a másikba. A fő művelet a [ISlideCollection::AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/), amely megőrizheti a forrás dia formázását, vagy a klónozott diát egy mesterhez vagy elrendezéshez csatolhatja a cél prezentációban.

Ez a cikk a leggyakoribb egyesítési munkafolyamatokat mutatja be:

- az összes dia egyesítése a forrás formázásának megtartásával;
- kiválasztott diák egyesítése;
- egy mester alkalmazása a cél prezentációból;
- egy adott elrendezés alkalmazása a cél prezentációból;
- a különböző dia méretek normalizálása egyesítés előtt;
- klónozott diák hozzáadása egy szekcióhoz;
- több prezentáció egyesítése egy végponttól végpontig tartó munkafolyamatban;
- mesterek, erőforrások, jegyzetek, megjegyzések, média, betűkészletek, jelszavak, nagy fájlok és több szálas problémák kezelése.

## **Hogyan befolyásolja a dia klónozása a mestereket és elrendezéseket**

Egy dia megjelenésének nagy része az elrendezéséből és a mesteréből örököl. Emiatt a választott klónozási túlterhelés határozza meg, hogy a egyesített dia hogyan integrálódik a cél prezentációba.

Használja az [ISlideCollection::AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) egyik következő változatát:

- `AddClone(sourceSlide)` — megőrzi a forrás dia elrendezését és formázását. Szükség esetén a forrás mester automatikusan klónozható a cél prezentációba. Az Aspose.Slides nyomon követi az automatikusan klónozott mestereket, így a ugyanazt a mestert használó ismételt diák nem eredményeznek többszöri klónozást.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — a klónozott diát egy adott cél [IMasterSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/)hez csatolja. Az Aspose.Slides a megadott mester alatt a layout típus vagy név alapján keresi a megfelelő elrendezést.
- `AddClone(sourceSlide, destinationLayout)` — a klónozott diát közvetlenül egy adott cél [ILayoutSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/)hez csatolja.

A `AddClone` túlterhelésnek átadott mesternek vagy elrendezésnek a **cél** prezentációhoz kell tartoznia, nem a forrás prezentációhoz.

## **Teljes prezentációk egyesítése és a forrás formázásának megőrzése**

A legegyszerűbb egyesítés minden diát lemásol a forrás prezentációból a cél prezentációba. Ez a megfelelő választás, ha a importált diáknak meg kell tartaniuk eredeti témájukat, mesterüket és elrendezéskapcsolataikat.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

Az eredményül kapott prezentáció több mestert is tartalmazhat, ha a forrás és a cél különböző dizájnt használ. Ez akkor várható, ha a forrás formázását szándékosan meg akarjuk őrizni.

## **Kiválasztott diák egyesítése**

Nem szükséges minden diát klónozni. Az alábbi példa csak a kiválasztott diaindexeket importálja a forrás prezentációból.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

Érvényesítse a diaindexeket a klónozás előtt, ha azok felhasználói bemenetből vagy külső konfigurációból származnak.

## **Diák egyesítése célmesterrel**

Használja a [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) túlterhelést, ha az importált diáknak egy már a cél prezentációhoz tartozó mester szerint kell elrendeződniük.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Az Aspose.Slides a megadott mester alatt a forrás elrendezés típusa vagy neve alapján választ ki egy megfelelő elrendezést. Ha nincs megfelelő elrendezés, és az `allowCloneMissingLayout` értéke `true`, a forrás elrendezés klónozásra kerül, így a dia hozzáadható. Ha `false`, akkor egy [PptxEditException](https://reference.aspose.com/slides/hu/cpp/aspose.slides/details_pptxeditexception/) kerül dobásra.

Használja a `false` értéket, ha azt szeretné, hogy az egyesítés hibával lehessen befejezve, ahelyett, hogy további elrendezést vezetne be a célmesterbe.

## **Diák egyesítése egy adott cél elrendezés használatával**

Használja a [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) túlterhelést, ha pontosan tudja, melyik cél elrendezést kell használniuk az importált diáknak.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

Egy cél elrendezés alkalmazása módosítja az örökölt elrendezési kapcsolatot; a forrás dia tartalmát nem tervezi újra. Ha a forrás és a cél elrendezések különböző helyőrző struktúrával rendelkeznek, ellenőrizze az eredményt, hogy megbizonyosodjon a megfelelő örökölt formázásról és helyőrző viselkedésről.

## **Prezentációk egyesítése különböző dia méretekkel**

Különböző dia méretekkel rendelkező prezentációk egyesíthetők, de egy dia klónozása egy másik méretű prezentációba nem tervezi át automatikusan a tartalmat az új vászonhoz. Így az alakzatok elmozdulhatnak, váratlanul átméreteződhetnek, vagy a látható dia területén kívülre kerülhetnek.

Gyakorlati megközelítés a forrás prezentáció átméretezése a klónozás előtt. A [SlideSize::SetSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slidesize/setsize/) metódus méretezheti a meglévő tartalmat, miközben megváltoztatja a dia méreteit. A [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slidesizescaletype/) a tartalmat a kért mérethez igazítja.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

Az átméretezés módosítja a forrás prezentáció objektumát a memóriában. Ha az eredeti forrás prezentációt más műveletekhez változatlanul szeretné megtartani, nyisson egy külön példányt az egyesítéshez.

## **Diák egyesítése egy prezentáció szekcióba**

Az alapvető dia-klónozási ciklus nem hozza létre a forrás prezentáció szekcióhierarchiáját. Ha a szekciók fontosak a kimenetben, hozzon létre vagy válasszon ki szekciókat a cél prezentációban, és a diák klónozását kifejezetten a [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) segítségével végezze el.

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

A klónozott diák a megadott cél szekcióhoz lesznek hozzáadva. Több forrás szekció megőrzéséhez enumerálja a [Presentation::get_Sections](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_sections/) elemet, szerezze be minden forrás szekció aktuális diáit az [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isection/getslideslistofsection/) segítségével, hozza létre a szekciókat a célban, és klónozza az egyes visszaadott diát a megfelelő cél szekcióba. Lásd a [Dia szakaszok kezelése](/slides/hu/cpp/slide-section/) oldalt egy teljes szekció‑enumerációs példáért, beleértve az üres szekciókat és strukturális változásokat.

## **Több prezentáció biztonságos egyesítése**

Az alábbi végponttól végpontig tartó példa az első prezentációt használja célként, normalizálja minden további forrás dia méretét, csak amíg a forrás nyitva van, másolja, majd egyszer menti a végleges fájlt.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

Ez egy hasznos kiindulási alap a forrás formázásának megőrzéséhez az importált diák esetében. Ha a kimenetnek egyetlen cél témát kell használnia, cserélje le az egyszerű `AddClone(slide)` hívást a korábban bemutatott megfelelő cél‑mester vagy cél‑elrendezés túlterhelésére.

## **Gyakorlati megfontolások**

### **Mesterek, elrendezések és a formázás hűsége**

Az alapértelmezett dia‑klónozás automatikusan behozhat egy szükséges forrás mestert a cél prezentációba. Az Aspose.Slides egy belső nyilvántartást vezet az automatikusan klónozott mesterek nyomon követésére, hogy ugyanazt a mestert ne klónozza többször. A kézi klónozott mestereket ez a nyilvántartás nem követi, ezért kerüljük el a mesterek előzetes klónozását, hacsak nem szükséges a mester struktúrájának kifejezett irányítása.

Ne feltételezzük, hogy két azonos nevű mester vagy elrendezés vizuálisan egyenértékű. Ha egy vállalati sablonnak kell szabályoznia a végső megjelenést, válasszon egy cél mestert vagy elrendezést kifejezetten, és ellenőrizze az eredményt az egyesítés után.

### **Jegyzetek és megjegyzések**

A beszélői jegyzetek és dia‑megjegyzések a dia tartalmához vannak kapcsolva, és a dia klónozása során másolódnak. Az Aspose.Slides dedikált API‑kat is kínál a [prezentációs jegyzetek](/slides/hu/cpp/presentation-notes/) és a [prezentációs megjegyzések](/slides/hu/cpp/presentation-comments/) kezelésére.

Ha a jegyzet‑oldal formázása fontos, ellenőrizze az egyesített prezentációt, mivel a jegyzet‑mesterek prezentáció‑szintű objektumok, és a forrásfájlok között eltérhetnek. Felülvizsgálati munkafolyamatoknál ellenőrizze a megjegyzés szerzőit és a szálas megjegyzéseket is, miután különböző szerzők vagy sablonok fájljait kombinálta.

### **Képek, hang, videó, OLE objektumok és külső hivatkozások**

A diák hivatkozhat prezentáció‑szintű erőforrásokra, például képekre, beágyazott hangra, beágyazott videóra és OLE adatokra. Klónozza a diát magát, ne csak a látható alakzatokat, hogy az Aspose.Slides megőrizhesse a dia erőforráskapcsolatait.

A beágyazott és a hivatkozott erőforrásokat külön kell kezelni. Egy hivatkozott hang, videó, OLE objektum vagy hiperhivatkozás továbbra is külső célra támaszkodik; a dia klónozása nem alakítja át a külső hivatkozást beágyazott tartalommá. Tesztelje a hivatkozott erőforrás útvonalait és URL-jeit abban a környezetben, ahol az egyesített prezentációt megnyitják.

Az Aspose.Slides nyilvánvalóan nyomon követi az automatikusan klónozott mestereket, de ezt ne tekintse általános garanciának arra, hogy a különböző forrás prezentációkból származó azonos bináris erőforrások mindig deduplikálódnak. Ha a kimeneti fájl mérete fontos, ellenőrizze az egyesített csomagot és mérje meg az eredményt ahelyett, hogy az implicit deduplikálásra támaszkodna.

### **Beágyazott betűk és betűkészletek elérhetősége**

A betűkészletek a prezentáció szintjén kezelhetők. Ha a tipográfiának gépek között konzisztensnek kell maradnia, ne feltételezze, hogy a diák klónozása önmagában garantálja, hogy minden szükséges betűkészlet elérhető legyen a cél környezetben. A beágyazott betűket megtekintheti a [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/getembeddedfonts/) segítségével, és a [Betűk beágyazása a prezentációkba](/slides/hu/cpp/embedded-font/) leírása szerint kezelheti a beágyazást.

Ellenőrizze továbbá, hogy engedélyezett‑e a forrásfájlokban használt betűkészletek beágyazása. A betűlicencek korlátozhatják a beágyazást.

### **Jelszóval védett prezentációk**

Egy jelszóval védett forrást csak sikeres megnyitás után lehet klónozni. Adja meg a jelszót a [LoadOptions::set_Password](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_password/) segítségével.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

A titkosított forrás megnyitása nem alkalmaz automatikusan ugyanazt a védelemet a cél prezentációra. A kimeneti védelem konfigurálása külön kell, ha szükséges.

### **Nagy prezentációk és memóriahasználat**

Nagy prezentációk, amelyek magas felbontású képeket, hangot, videót vagy más nagy bináris objektumokat tartalmaznak, jelentős memóriát fogyaszthatnak. A [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) lehetővé teszi a BLOB‑kezelés és a temp‑fájlok használatának szabályozását. Lásd a [Prezentáció BLOB‑kezelése](/slides/hu/cpp/manage-blob/) oldalt nagy fájlok stratégiáiért.

Nagy fájlok esetén részesítse előnyben a fájlútvonalakról történő betöltést, amennyiben lehetséges, azonnal szabadítsa fel a forrás prezentációkat az egyesítés befejezése után, és kerülje a köztes eredmények ismételt mentését, hacsak a munkafolyamat nem igényel ellenőrző pontokat.

### **Szálbiztonság**

Ne töltsön be, módosítson, mentse vagy klónozza ugyanazt a [Prezentáció](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt párhuzamosan több szálról. Tartsa minden prezentációs példányt egy egyesítési művelethez korlátozva. Ha független feladatokat párhuzamosít, használjon független prezentációs példányokat, és kövesse az [Aspose.Slides több szálas irányelveit](/slides/hu/cpp/multithreading/).

## **GYIK**

**Hogyan őrizhetem meg minden forrás prezentáció eredeti tervezését?**

Használja az [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódust cél‑mester vagy -elrendezés megadása nélkül. Az Aspose.Slides automatikusan klónozhatja a forrás mestert, ha a importált diának szüksége van rá.

**Hogyan tehetem úgy, hogy az importált diák a cél témát használják?**

Használja azt a túlterhelést, amely egy cél mestert fogad el. Adjon meg egy mestert a cél prezentációból, ne a forrásból. Az Aspose.Slides megpróbálja minden forrás diát a megfelelő elrendezéshez társítani az adott mester alatt.

**Mikor érdemes konkrét cél elrendezést használni a cél mester helyett?**

Használjon konkrét elrendezést, ha minden importált diának egy ismert elrendezést kell használnia. Használjon mestert, ha azt szeretné, hogy az Aspose.Slides a forrás elrendezés típusa vagy neve alapján válasszon a mester elrendezései közül.

**Egyesíthetők-e a különböző dia méretekkel rendelkező prezentációk?**

Igen, de a dia tartalma nem kerül automatikusan újratervezésre a cél méretekhez. Először méretezze át a forrás prezentációt, ha kiszámítható elhelyezésre van szükség, például a [SlideSize::SetSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slidesize/setsize/) és a [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slidesizescaletype/) segítségével.

**Egyesíthetek PPT, PPTX és ODP prezentációkat egy fájlba?**

Igen. Töltse be minden forrás prezentációt, klónozza a szükséges diákat egyetlen célba, és mentse a célt egy támogatott kimeneti formátumban. Mivel a prezentációs formátumok nem támogatják pontosan ugyanazt a funkciókészletet, ellenőrizze a komplex tartalmat a formátumok közötti egyesítés után. Lásd a [Támogatott fájlformátumok](/slides/hu/cpp/supported-file-formats/) oldalt.

**Megmaradnak-e automatikusan a forrás szekciók?**

Nem egy alap ciklus, amely csak diák klónozását végzi. Hozza létre a szükséges szekciókat a célban, és használja a [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) szekció‑túlterhelését, ha a szekció struktúrát meg kell őrizni.

**Megmaradnak-e a beszélői jegyzetek és megjegyzések?**

Másolásra kerülnek a klónozott diákkal együtt. Azoknál a munkafolyamatoknál, amelyek a jegyzet‑mester stílusát, a megjegyzés szerzőit vagy a szálas felülvizsgálati adatokat igénylik, ellenőrizze az egyesített eredményt, mivel ezek a helyzetek prezentáció‑szintű struktúrákat is érintenek a dia‑szintű tartalom mellett.

**Mi történik a hanggal, videóval, OLE objektumokkal és hiperhivatkozásokkal?**

A beágyazott tartalom a klónozott dia erőforráskapcsolatai részeként kerül továbbításra. A külső hivatkozások külsőek maradnak, ezért a célra való megnyitáskor a célfájloknak vagy URL‑eknek továbbra is elérhetőnek kell lenniük.

**Garantált-e, hogy minden forrásból származó beágyazott betű elérhető lesz az egyesített prezentációban?**

Ne támaszkodjon kizárólag a dia klónozására a betűk telepítéséhez. Vizsgálja meg a cél beágyazott betűit, és kezelje kifejezetten a betűbeágyazást vagy a külső betűk elérhetőségét, ha a tipográfia fontos.

**Hogyan egyesíthetem a jelszóval védett fájlt?**

Nyissa meg a megfelelő [LoadOptions::set_Password](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_password/) használatával, majd klónozza a diákot a szokásos módon. A kimeneti védelem külön konfigurálandó.

**Hogyan kezeljem a nagyon nagy prezentációkat?**

Használja a BLOB‑kezelést, ha nagy bináris objektumok dominálják a memóriahasználatot, részesítse előnyben a fájlútvonal‑betöltést nagyon nagy fájlok esetén, szabadítsa fel a forrás prezentációkat gyorsan, és csak akkor mentse a végleges eredményt, amikor szükséges.

**Klónozhatok-e diákot több szálból?**

Ne használjon egy [Prezentáció](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt egyszerre több szálról. Tartsa minden egyes egyesítési műveletet elkülönítve a saját prezentációs példányai között.