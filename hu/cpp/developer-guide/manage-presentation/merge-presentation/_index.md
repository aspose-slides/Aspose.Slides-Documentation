---
title: Prezentációk hatékony egyesítése C++-ban
linktitle: Prezentációk egyesítése
type: docs
weight: 40
url: /hu/cpp/merge-presentation/
keywords:
- PowerPoint egyesítése
- prezentációk egyesítése
- diák egyesítése
- PPT egyesítése
- PPTX egyesítése
- ODP egyesítése
- PowerPoint kombinálása
- prezentációk kombinálása
- diák kombinálása
- PPT kombinálása
- PPTX kombinálása
- ODP kombinálása
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan lehet PowerPoint és OpenDocument prezentációkat egyesíteni C++-ban diák klónozásával, a mesterek és elrendezések irányításával, a dia tartalom átméretezésével, a szakaszok megőrzésével, valamint védett vagy nagy fájlok kezelésével."
---
## **Áttekintés**

Az Aspose.Slides for C++ prezentációkat egyesíti úgy, hogy diákat klónoz az egyik [Prezentáció](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/)-ból a másikba. A fő művelet az [ISlideCollection::AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/), amely megőrizheti a forrásdia formázását, vagy a klónozott diát egy mesterhez vagy elrendezéshez csatolhatja a célnyilatkozatban.

Ez a cikk a leggyakoribb egyesítési munkafolyamatokat tárgyalja:

- az összes dia egyesítése a forrásformázás megőrzésével;
- kiválasztott diák egyesítése;
- egy mester alkalmazása a célnyilatkozatból;
- egy adott elrendezés alkalmazása a célnyilatkozatból;
- a különböző dia méretek normalizálása egyesítés előtt;
- klónozott diák hozzáadása egy szakaszhoz;
- több prezentáció egyesítése egy végponttól végpontig tartó munkafolyamatban;
- mesterek, erőforrások, jegyzetek, megjegyzések, médiák, betűk, jelszavak, nagy fájlok és többszálú megfontolások kezelése.

## **Hogyan befolyásolja a dia klónozása a mestereket és elrendezéseket**

Egy dia megjelenésének nagy részét az elrendezése és a mestere adja. Emiatt a választott klónozási túlterhelés meghatározza, hogyan integrálódik a egyesített dia a célnyilatkozatba.

Használja az [ISlideCollection::AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódust az alábbi módokon:

- `AddClone(sourceSlide)` — megőrzi a forrásdia elrendezését és formázását. Szükség esetén a forrás mester automatikusan klónozható a célnyilatkozatba. Az Aspose.Slides automatikusan klónozott mestereket követ, így az ugyanazt a forrás mestert használó ismétlődő diák nem okozzák a mester többszöri klónozását.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — a klónozott diát egy adott célnyilatkozat [IMasterSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/)-hez csatolja. Az Aspose.Slides a megadott mester alatt elrendezést keres elrendezés típus vagy név alapján.
- `AddClone(sourceSlide, destinationLayout)` — a klónozott diát közvetlenül egy adott célnyilatkozat [ILayoutSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/)-hez csatolja.

Az `AddClone` túlterhelésnek átadott mesternek vagy elrendezésnek a **cél** prezentációhoz kell tartoznia, nem a forráshoz.

## **Teljes prezentációk egyesítése és a forrásformázás megőrzése**

A legegyszerűbb egyesítés minden diát átmásol a forrás prezentációból a célnyilatkozatba. Ez a megfelelő választás, ha az importált diáknak megtartaniuk kell eredeti témájukat, mesterüket és elrendezéskapcsolataikat.

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

A létrejövő prezentáció több mestert tartalmazhat, ha a forrás és a cél különböző dizájnokat használ. Ez akkor várható, ha a forrásformázást szándékosan megőrzik.

## **Kiválasztott diák egyesítése**

Nem kell minden diát klónozni. Az alábbi példa csak a forrás prezentációból kiválasztott diaindexeket importálja.

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

## **Diák egyesítése egy cél mesteren keresztül**

Használja a [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) túlterhelést, ha az importált diáknak egy már a célnyilatkozatban lévő mesterhez kell illeszkedniük.

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

Az Aspose.Slides a megadott mester alatt a forrás elrendezés típus vagy név szerinti egyezésével választ megfelelő elrendezést. Ha nincs megfelelő elrendezés, és az `allowCloneMissingLayout` értéke `true`, a forrás elrendezés klónozódik, így a dia hozzáadható. Ha `false`, egy [PptxEditException](https://reference.aspose.com/slides/hu/cpp/aspose.slides/details_pptxeditexception/) keletkezik.

Használja a `false` értéket, ha azt szeretné, hogy az egyesítés hibával érjen véget ahelyett, hogy egy további elrendezést hozna létre a célmesterben.

## **Diák egyesítése egy meghatározott cél elrendezéssel**

Használja a [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) túlterhelést, ha pontosan tudja, melyik cél elrendezést kell az importált diáknak használniuk.

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

A cél elrendezés alkalmazása megváltoztatja az örökölt elrendezési kapcsolatot; a forrás dia tartalmát nem alakítja át. Ha a forrás és a cél elrendezések különböző helyőrző struktúrával rendelkeznek, ellenőrizze az eredményt, hogy az örökölt formázás és a helyőrző viselkedés megfelelő legyen.

## **Prezentációk egyesítése különböző dia méretekkel**

Különböző dia méretekkel rendelkező prezentációk egyesíthetők, de egy dia klónozása egy másik dia mérettel rendelkező prezentációba nem alakítja át automatikusan a tartalmat az új vászonhoz. Emiatt alakzatok elhelyezkedhetnek eltolva, váratlanul méretezve vagy a látható dia területén kívül.

Gyakorlati megoldás, hogy a forrás prezentációt a klónozás előtt átméretezzük. A [SlideSize::SetSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slidesize/setsize/) metódus képes a meglévő tartalmat a dia méretének módosítása közben átméretezni. A [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slidesizescaletype/) a tartalmat a kért mérethez igazítja.

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

Az átméretezés módosítja a forrás prezentáció objektumát a memóriában. Ha az eredeti forrás prezentációt változatlanul szeretné más műveletekhez, nyisson egy külön példányt az egyesítéshez.

## **Diák egyesítése egy prezentáció szakaszába**

Az alapvető dia-klónozó ciklus nem hozza létre a forrás prezentáció szekcióhierarchiáját. Ha a szekciók fontosak a kimenetben, hozzon létre vagy válasszon ki szekciókat a célnyilatkozatban, és klónozza a diákot explicit módon a [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódussal.

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

A klónozott diák a megadott célszakcióhoz lesz hozzáfűzve. Több forrás szekció megőrzéséhez hozza létre ezeket a szekciókat a cél prezentációban, és térképezze le minden forrás diát a megfelelő célszakcióra.

## **Több prezentáció biztonságos egyesítése**

Az alábbi végponttól végpontig tartó példa az első prezentációt használja célként, normalizálja az egyes további források dia méretét, csak amíg másolás alatt áll nyitva tartja a forrást, és egyszer menti a végleges fájlt.

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

Ez egy hasznos alapvonal a forrásformázás megőrzéséhez az importált diák esetében. Ha a kimenetnek egyetlen cél téma használatára van szüksége, cserélje le az egyszerű `AddClone(slide)` hívást a korábban bemutatott megfelelő cél-mester vagy cél-elrendezés túlterhelésre.

## **Gyakorlati megfontolások**

### **Mesterek, elrendezések és formázási hűség**

Az alapértelmezett dia-klónozás automatikusan behozhat egy szükséges forrás mestert a célnyilatkozatba. Az Aspose.Slides belső regisztert vezet az automatikusan klónozott mesterek nyomon követésére, hogy elkerülje ugyanazon mester többszöri klónozását. A manuálisan klónozott mestereket ez a regiszter nem követi, ezért kerüld a mesterek előzetes klónozását, hacsak nem szükséges a mester struktúrájának kifejezett irányítása.

Ne feltételezd, hogy két ugyanolyan nevű mester vagy elrendezés vizuálisan ekvivalens. Ha egy vállalati sablonnak kell irányítania a végső megjelenést, válassz kifejezetten egy célnyilatkozat mestert vagy elrendezést, és ellenőrizd az egyesítés utáni eredményt.

### **Jegyzetek és megjegyzések**

Az előadói jegyzetek és dia megjegyzések a dia tartalmához kapcsolódnak, és másolásra kerülnek egy dia klónozásakor. Az Aspose.Slides külön API-kat is kínál a [prezentáció jegyzetekhez](https://docs.aspose.com/slides/hu/cpp/presentation-notes/) és a [prezentáció megjegyzésekhez](https://docs.aspose.com/slides/hu/cpp/presentation-comments/).

Ha a notes-page formázás fontos, ellenőrizd az egyesített prezentációt, mert a notes mesterek prezentációszintű objektumok, és eltérhetnek a forrásfájlok között. Felülvizsgálati munkafolyamatok esetén ellenőrizd a megjegyzés szerzőit és a szálas megjegyzéseket is, ha különböző szerzők vagy sablonok fájljait kombinálod.

### **Képek, hang, videó, OLE objektumok és külső hivatkozások**

A diák hivatkozhat prezentációszintű erőforrásokra, például képekre, beágyazott hangra, beágyazott videóra és OLE adatokra. Klónozd a diát magát, ne csak a látható alakzatokat, hogy az Aspose.Slides fenntartsa a dia erőforráskapcsolatait.

A beágyazott és a hivatkozott erőforrásokat külön kell kezelni. Egy hivatkozott hang, videó, OLE objektum vagy hiperhivatkozás továbbra is külső célra támaszkodik; a dia klónozása nem alakítja át a külső hivatkozást beágyazott tartalommal. Teszteld a hivatkozott erőforrás útvonalait és URL-jeit abban a környezetben, ahol az egyesített prezentációt megnyitják.

Az Aspose.Slides automatikusan klónozott mestereket nyomon követ, de ez nem jelent általános garanciát arra, hogy a különböző forrás prezentációkból származó azonos bináris erőforrások mindig deduplikálódnak. Ha a kimeneti fájlméret fontos, vizsgáld meg az egyesített csomagot és mérd az eredményt, ahelyett, hogy implicit deduplikációra támaszkodnál.

### **Beágyazott betűtípusok és betűtípus rendelkezésre állás**

A betűtípusok prezentációszinten vannak kezelve. Ha a tipográfiát gépek között konzisztensnek kell tartani, ne feltételezd, hogy csak a diák klónozása garantálja, hogy minden szükséges betűtípus elérhető a cél környezetben. A beágyazott betűtípusok ellenőrzéséhez használd a [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/getembeddedfonts/) metódust, és kezeld a beágyazást kifejezetten az [Betűtípusok beágyazása a prezentációkba](https://docs.aspose.com/slides/hu/cpp/embedded-font/) leírás szerint.

Ellenőrizd továbbá, hogy jogosult vagy-e a forrásfájlokban használt betűtípusok beágyazására. A betűtípus licencek korlátozhatják a beágyazást.

### **Jelszóval védett prezentációk**

Egy jelszóval védett forrást sikeresen meg kell nyitni, mielőtt a diái klónozhatók. A jelszót a [LoadOptions::set_Password](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_password/) segítségével add meg.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Egy titkosított forrás megnyitása nem alkalmaz automatikusan ugyanazt a védelmet a célnyilatkozatra. Szükség esetén külön konfiguráld a kimeneti védelmet.

### **Nagy prezentációk és memóriahasználat**

Nagy prezentációk, amelyek nagy felbontású képeket, hangot, videót vagy más nagy bináris objektumokat tartalmaznak, jelentős memóriát fogyaszthatnak. A [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) vezérli a BLOB kezelését és az ideiglenes fájlok használatát. Lásd a [Prezentáció BLOB-ok kezelése](https://docs.aspose.com/slides/hu/cpp/manage-blob/) útmutatót nagy fájl stratégiákhoz.

Nagy fájlok esetén előnyösebb fájlúton betölteni, ha lehetséges, a forrás prezentációkat a egyesítés után azonnal eldobni, és elkerülni az ismételt köztes mentéseket, hacsak a munkafolyamat nem igényel ellenőrzőpontokat.

### **Szálbiztonság**

Ne tölts be, módosíts, ments vagy klónozz ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt párhuzamosan több szálról. Tartsa minden prezentáció példányt egyetlen egyesítési művelethez. Ha független feladatokat párhuzamosít, használjon független prezentáció példányokat, és kövesse az [Aspose.Slides többszálas útmutatóját](https://docs.aspose.com/slides/hu/cpp/multithreading/).

## **GYIK**

**Hogyan tarthatom meg minden forrás prezentáció eredeti dizájnját?**

Használja a [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódust anélkül, hogy cél mestert vagy elrendezést adna meg. Az Aspose.Slides automatikusan klónozhatja a forrás mestert, ha az importált dia számára szükséges.

**Hogyan tehetem, hogy az importált diák a cél témát használják?**

Használja azt a túlterhelést, amely cél mestert fogad el. Adj át egy mestert a célnyilatkozatból, nem a forrásból. Az Aspose.Slides megpróbálja minden forrás diát a megfelelő elrendezéshez társítani a megadott mester alatt.

**Mikor használjak konkrét cél elrendezést a cél mester helyett?**

Használjon konkrét elrendezést, ha minden importált dianak egy ismert elrendezést kell használnia. Használjon mestert, amikor azt szeretné, hogy az Aspose.Slides a forrás elrendezés típusa vagy neve alapján válasszon a mester elrendezései közül.

**Egyesíthetők-e különböző dia méretű prezentációk?**

Igen, de a dia tartalma nem lesz automatikusan áttervezve a cél méretekhez. Először változtassa meg a forrás prezentáció méretét, ha kiszámítható elhelyezést igényel, például a [SlideSize::SetSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slidesize/setsize/) és a [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slidesizescaletype/) segítségével.

**Egyesíthetek PPT, PPTX és ODP prezentációkat egy fájlba?**

Igen. Tölts be minden forrás prezentációt, klónozd a szükséges diákat egy célba, és mentse a célt a támogatott kimeneti formátumban. Mivel a prezentáció formátumok nem támogatják pontosan ugyanazt a funkciókészletet, ellenőrizze a komplex tartalmat a formátumok közti egyesítések után. Lásd a [Támogatott fájlformátumok](https://docs.aspose.com/slides/hu/cpp/supported-file-formats/) oldalt.

**Megmaradnak-e automatikusan a forrás szekciók?**

Nem egy egyszerű ciklus esetén, amely csak a diák klónozását végzi. Hozza létre a szükséges szekciókat a célban, és használja a [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) szekció túlterhelést, ha a szekció struktúrát meg kell őrizni.

**Megmaradnak-e az előadói jegyzetek és megjegyzések?**

Átmásolódnak a klónozott diával. Olyan munkafolyamatok esetén, amelyek a notes-mester stílusra, a megjegyzés szerzőkre vagy a szálas átnézési adatokra támaszkodnak, ellenőrizze az egyesített eredményt, mert ezek a forgatókönyvek prezentációszintű struktúrákat és dia szintű tartalmat egyaránt érintenek.

**Mi történik a hanggal, videóval, OLE objektumokkal és hiperhivatkozásokkal?**

A beágyazott tartalom a klónozott dia erőforráskapcsolataiként kerül át. A külső hivatkozások továbbra is külsőek maradnak, így a célfájlok vagy URL-eknek elérhetőnek kell maradniuk az egyesítés után.

**Garantált-e, hogy minden forrásból származó beágyazott betűtípus elérhető lesz az egyesített prezentációban?**

Ne támaszkodjon csak a diaklónozásra a betűtípusok terjesztéséhez. Ellenőrizze a cél beágyazott betűtípusait, és kezelje kifejezetten a betűtípus beágyazást vagy a külső betűtípus elérhetőséget, ha a tipográfia fontos.

**Hogyan egyesíthetek jelszóval védett fájlt?**

Nyissa meg a megfelelő [LoadOptions::set_Password](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_password/) használatával, majd klónozza a diákat a szokásos módon. A kimeneti védelem külön konfigurálható.

**Hogyan kezeljem a nagyon nagy prezentációkat?**

Használja a BLOB kezelést, ha a nagy bináris objektumok dominálják a memóriahasználatot, előnyben részesítse a fájlútvonalas betöltést nagyon nagy fájlok esetén, gyorsan dobja el a forrás prezentációkat a egyesítés után, és csak akkor mentse a végső eredményt, amikor szükséges.

**Klónozhatom-e a diákat több szálról?**

Ne használjon egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt egyszerre több szálról. Tartsa minden egyes egyesítési műveletet egy saját prezentáció példányon belül.