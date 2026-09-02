---
title: Prezentációinformációk lekérdezése és frissítése C++-ban
linktitle: Prezentációinformációk
type: docs
weight: 30
url: /hu/cpp/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentumtulajdonságok
- tulajdonságok lekérése
- tulajdonságok olvasása
- tulajdonságok módosítása
- tulajdonságok átalakítása
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel a diaképeket, a felépítést és a metaadatokat PowerPoint és OpenDocument prezentációkban C++ használatával, hogy gyorsabb betekintést és intelligensebb tartalom-ellenőrzést kapjon."
---
## **Áttekintés**

Az Aspose.Slides képes azonosítani egy prezentáció formátumát, és elolvasni a dokumentum metaadatait anélkül, hogy teljes prezentáció objektummodellt hozna létre. Ez akkor hasznos, ha fájlokat kell kategorizálni, leltárt készíteni, vagy a tulajdonságokat ellenőrizni kell, mielőtt eldöntenénk, betöltjük-e és feldolgozzuk-e a prezentáció tartalmát.

Ez a cikk bemutatja a könnyű ellenőrzést a [PresentationFactory](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentationfactory/) és [IPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/) segítségével, valamint a célzott frissítéseket a [IDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/) használatával.

## **Prezentáció formátumának ellenőrzése**

Használja az [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) metódust egy fájl ellenőrzésére anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt hozna létre. Az [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/get_loadformat/) metódus jelzi a felismert formátumot, például PPTX, PPT vagy ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **Könnyű prezentáció leltár összeállítása**

Ha sok prezentációfájlt dolgoz fel, szüksége lehet egy kompakt leltárra validáláshoz, indexeléshez vagy dokumentumkezelő rendszerhez. Ebben a helyzetben használja az [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) metódust egy [IPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/) objektum megszerzéséhez, majd hívja az [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) metódust a dokumentum metaadatok beolvasásához. Ez a megközelítés nem hoz létre [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt, és nem igényli a teljes prezentáció objektummodell bejárását.

Az [IDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/) által biztosított kibővített tulajdonságok a következő leltárértékeket adják meg:

| Metódus | Leltárérték |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_slides/) | A diák teljes száma. |
| [get_HiddenSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | A rejtett diák száma. |
| [get_Notes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_notes/) | Azokra a diákra vonatkozó jegyzetek száma. |
| [get_Paragraphs](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | A bekezdések összes száma, ha elérhető. |
| [get_Words](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_words/) | A szavak összes száma. |
| [get_MultimediaClips](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Az audió- és videóklippek összes száma. |

Az alábbi példa beolvassa ezeket az értékeket anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumot hozna létre, és egy kompakt leltárt nyomtat ki. Emellett kombinálja az [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_headingpairs/) és az [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) értékeket a tartalomcsoportok (például betűtípusok, témák, diacímek) megjelenítéséhez.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

Minden [IHeadingPair](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iheadingpair/) egy csoportnevet ad az [IHeadingPair::get_Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iheadingpair/get_name/) metódussal, és a csoportban lévő elemek számát az [IHeadingPair::get_Count](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iheadingpair/get_count/) metódussal. Az [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) egy lapos, rendezett tömböt ad vissza, ezért a felsorolt címek számát a megfelelő fejezetpárok által meghatározott mennyiségben kell felhasználni.

### **Tárolt metaadatok és formátumkorlátozások**

Az [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) által visszaadott leltártulajdonságok a forrásdokumentumban elérhető metaadatokat tükrözik. Az Aspose.Slides nem tölti be és nem járja be a prezentáció objektummodelljét, hogy újraszámolja ezeket az értékeket ebben a hívásban. Hiányzó tulajdonságok alapértelmezett értékekkel jelennek meg, és a tárolt értékek elavulhatnak, ha a legutóbb mentő alkalmazás nem frissítette a dokumentumtulajdonságokat.

- **PPTX:** A formátum kiterjesztett dokumentumtulajdonságokat biztosít a diák, jegyzetek, rejtett diák, bekezdések, szavak és multimédia számlálásához, valamint a fejlécpárokhoz és a részcímekhez. Az elérhetőség attól függ, hogy a dokumentumelőállító melyik tulajdonságot írta be.
- **PPT:** A bináris formátum tárolhatja a megfelelő dokumentumösszegző tulajdonságokat. Ha egy tulajdonság hiányzik vagy a dokumentumelőállító nem frissítette, az Aspose.Slides a tárolt vagy alapértelmezett értéket adja vissza ahelyett, hogy a diák alapján számolná ki.
- **ODP:** Az OpenDocument metaadatok általános dokumentumstatisztikákat biztosítanak, például oldal-, bekezdés- és szószámlálást, de ezek az értékek nem térnek le minden PowerPoint-specifikus kiterjesztett tulajdonságra. A rejtett diák, jegyzetdiák, multimédia, fejlécpár és részcím metaadatai hiányozhatnak, és a leltártulajdonságok alapértelmezett értékkel térhetnek vissza. Ne tekintse a nullás értéket vagy az üres tömböt végleges bizonyítéknak arra, hogy a megfelelő tartalom hiányzik.

Használja a könnyű metaadat-megközelítést leltárakhoz és előzetes ellenőrzésekhez. Töltse be a prezentációt és ellenőrizze a futó objektummodellt, ha az eredménynek tükröznie kell a memóriában történt változásokat, vagy ha a tényleges prezentációtartalmat kell ellenőrizni.

## **Prezentáció tulajdonságainak frissítése**

Az [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) által visszaadott tulajdonságok módosíthatók anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt hoznánk létre. Alkalmazza a változtatásokat az [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/) segítségével, majd írja vissza a kötött prezentációt az [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/) metódussal.

Az alábbi kép a dokumentum eredeti tulajdonságait mutatja.

![A PowerPoint prezentáció eredeti dokumentumtulajdonságai](input_properties.png)

Az alábbi példában módosítja a címet és az utolsó mentés időpontját, majd az eredményt egy új fájlba írja:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

Az alábbi kép a módosított dokumentumtulajdonságokat mutatja.

![A PowerPoint prezentáció módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

Kapcsolódó biztonsági ellenőrzések és védelmi beállítások tekintetében lásd az alábbi cikkeket:

- [Password-Protect Presentations](/slides/hu/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hu/cpp/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűtípusok be vannak-e ágyazva, és melyek azok?**

Töltse be a prezentációt, és használja a [Presentation::get_FontsManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_fontsmanager/) metódust. Hívja a [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/getembeddedfonts/) függvényt a beágyazott betűtípusok lekéréséhez, valamint a [FontsManager::GetFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/getfonts/) függvényt a prezentáció által használt betűtípusokhoz. Hasonlítsa össze a két eredményt, hogy megtalálja a rendereléshez szükséges, de nem beágyazott betűtípusokat.

**Hogyan tudom gyorsan megállapítani, hogy a fájl rejtett diákot tartalmaz-e, és hány darabot?**

Ha a tárolt dokumentummetaadat elegendő, olvassa a [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) értéket az [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) és az [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) segítségével. Ez alkalmas könnyű leltárhoz. Ha a prezentáció memóriában módosult, a tárolt metaadat hiányozhat vagy elavult lehet, vagy ha élő értékek ellenőrzése szükséges, iteráljon a [Presentation::get_Slides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_slides/) gyűjteményen, és ellenőrizze minden dia [Slide::get_Hidden](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/get_hidden/) metódusát.

**Felismerhető-e, hogy egyedi dia méret és tájolás van-e használatban, és eltérnek-e az alapértékektől?**

Igen. Töltse be a prezentációt, és olvassa a [Presentation::get_SlideSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_slidesize/) értéket. Ellenőrizze az [ISlideSize::get_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidesize/get_size/) és [ISlideSize::get_Orientation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidesize/get_orientation/) metódusokat, hogy összehasonlítsa a jelenlegi beállításokat az elvárt előre beállított értékekkel és méretekkel.

**Van-e gyors módja annak, hogy lássam, a diagramok külső adatforrásokra hivatkoznak-e?**

Igen. Keresse meg minden [Chart](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chart/) objektumot, és ellenőrizze a [ChartData::get_DataSourceType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) értékét. Külső munkafüzet esetén olvassa a [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) értéket. Az adatforrás típusa és az útvonal jelzi a külső hivatkozást, de annak elérhetősége külön erőforrás-ellenőrzést igényel.

**Hogyan értékelhetem a „nehéz” diákot, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Nincs egyetlen komplexitásra vonatkozó tulajdonság. Járja be a [Presentation::get_Slides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_slides/) és minden dia [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslide/get_shapes/) gyűjteményét. Használjon alakzat-számokat, nagy képek, effektusok, animációk vagy multimédia jelenlétét szűrőjelzésként, és mérjen egy reprezentatív renderelést vagy exportálást, mielőtt egy diát végleges teljesítménybottlenecknek tekintene.