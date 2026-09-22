---
title: Prezentációs információk lekérése és frissítése C++-ban
linktitle: Prezentációs információk
type: docs
weight: 30
url: /hu/cpp/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságai
- dokumentum tulajdonságai
- tulajdonságok lekérése
- tulajdonságok olvasása
- tulajdonságok módosítása
- tulajdonságok módosítása
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel a diák, struktúrák és metaadatok világát PowerPoint és OpenDocument prezentációkban C++ használatával a gyorsabb betekintés és az intelligensebb tartalomelemzés érdekében."
---
## **Áttekintés**

Az Aspose.Slides képes azonosítani egy prezentáció formátumát és elolvasni a dokumentum metaadatait anélkül, hogy teljes prezentációs objektummodellt hozna létre. Ez akkor hasznos, ha fájlokat kell osztályozni, leltárt építeni, vagy tulajdonságokat ellenőrizni kell, mielőtt eldöntené, hogy betölti és feldolgozza a prezentáció tartalmát.

Ez a cikk a könnyű ellenőrzést mutatja be a [PresentationFactory](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentationfactory/) és az [IPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/) használatával, valamint a célzott frissítéseket az [IDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/) segítségével.

## **Ellenőrizze a prezentáció formátumát**

Ha már betöltött egy prezentációt, tekintse meg a [Determine the Original Presentation Format](/slides/hu/cpp/detect-presentation-source-format/) cikket a betöltés utáni felismeréshez és a régi PPT, PPS és POT adatfolyamok korlátaival kapcsolatban.

Használja az [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) metódust egy fájl ellenőrzéséhez anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt hozna létre. Az [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/get_loadformat/) metódus jelzi a detektált formátumot, például PPTX, PPT vagy ODP.

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

## **Készítsen könnyű prezentációs leltárt**

Ha sok prezentációs fájlt dolgoz fel, szüksége lehet egy kompakt leltárra az ellenőrzéshez, indexeléshez vagy egy dokumentumkezelő rendszerhez. Ebben a helyzetben használja az [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) metódust egy [IPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/) objektum megszerzéséhez, majd hívja meg az [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) metódust a dokumentum metaadatok elolvasásához. Ez a megközelítés nem hoz létre [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt, és nem igényli a teljes prezentációs objektummodell bejárását.

Az [IDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/) által biztosított kiterjesztett tulajdonságok a következő leltárértékeket adják meg:

| Metódus | Leltárérték |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_slides/) | A diák összes száma. |
| [get_HiddenSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | A rejtett diák száma. |
| [get_Notes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_notes/) | Azon diák száma, amelyek jegyzeteket tartalmaznak. |
| [get_Paragraphs](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | A rendelkezésre álló bekezdések összes száma. |
| [get_Words](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_words/) | A szavak összes száma. |
| [get_MultimediaClips](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | A hang- és videoklipek összes száma. |

Az alábbi példa ezeket az értékeket olvassa be anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumot hozna létre, és egy kompakt leltárt nyomtat. Emellett az [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_headingpairs/) metódust kombinálja az [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) metódussal a tartalmi csoportok, például betűkészletek, témák és dia címek megjelenítéséhez.

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

Minden [IHeadingPair](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iheadingpair/) egy csoportnevet biztosít a [IHeadingPair::get_Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iheadingpair/get_name/) metódussal, valamint a csoport elemeinek számát a [IHeadingPair::get_Count](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iheadingpair/get_count/) metódussal. Az [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) egy lapos, rendezett tömböt ad vissza, ezért a csoportonként megadott egymást követő címek számát kell felhasználni.

### **Tárolt metaadatok és formátumkorlátok**

A [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) által visszaadott leltártulajdonságok a forrásdokumentumban elérhető metaadatokat tükrözik. Az Aspose.Slides nem tölti be és nem járja be a prezentációs objektummodellt, hogy újraszámolja ezeket az értékeket ebben a hívásban. Hiányzó tulajdonságok alapértelmezett értékekkel jelennek meg, és a tárolt értékek elavulhatnak, ha az utoljára fájlt mentő alkalmazás nem frissítette a dokumentum tulajdonságait.

- **PPTX:** A formátum kiterjesztett dokumentumtulajdonságokat biztosít a diák, jegyzetek, rejtett diák, bekezdések, szavak és multimédia számához, valamint a heading párokhoz és részcímekhez. Az elérhetőség attól függ, mely tulajdonságokat írta a dokumentum előállítója.
- **PPT:** A bináris formátum képes tárolni a megfelelő dokumentum-összegző tulajdonságokat. Ha egy tulajdonság hiányzik vagy nem frissült a dokumentum előállítója által, az Aspose.Slides a tárolt vagy alapértelmezett értéket adja vissza, ahelyett, hogy a diák alapján számolná ki.
- **ODP:** Az OpenDocument metaadatok általános dokumentumstatisztikákat biztosítanak, például oldalak, bekezdések és szavak számát, de ezek az értékek nem felelnek meg minden PowerPoint-specifikus kiterjesztett tulajdonságnak. A rejtett-dia, jegyzet-dia, multimédia, heading-pár, és részcím metaadatok hiányozhatnak, és a leltártulajdonságok alapértelmezett értékeket adhatnak vissza. Ne kezelje a null értéket vagy a üres tömböt mint meghatározó bizonyítékot arra, hogy a megfelelő tartalom hiányzik.

Használja a könnyű metaadat‑megközelítést leltárak és előzetes ellenőrzések esetén. Töltse be a prezentációt, és ellenőrizze annak élő objektummodelljét, amikor az eredménynek a memóriában történt változásokat kell tükröznie, vagy amikor a tényleges prezentációs tartalmat kell ellenőrizni.

## **Prezentációs tulajdonságok frissítése**

A [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) által visszaadott tulajdonságok szintén módosíthatók anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt hoznánk létre. Alkalmazza a módosításokat az [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/) segítségével, majd írja ki a kötött prezentációt az [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/) metódussal.

Az alábbi kép az eredeti dokumentumtulajdonságokat mutatja:

![A PowerPoint prezentáció eredeti dokumentumtulajdonságai](input_properties.png)

Az alábbi példa megváltoztatja a címet és az utolsó mentés időpontját, és az eredményt egy új fájlba írja:

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

Az alábbi kép a frissített dokumentumtulajdonságokat mutatja:

![A PowerPoint prezentáció módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

Kapcsolódó biztonsági ellenőrzések és védelmi beállítások tekintetében lásd a következő cikkeket:

- [Jelszóval védett prezentációk](/slides/hu/cpp/password-protected-presentation/)
- [Írásvédett prezentációk](/slides/hu/cpp/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűkészletek be vannak-e ágyazva és melyek azok?**

Töltse be a prezentációt, és használja a [Presentation::get_FontsManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_fontsmanager/) metódust. Hívja meg a [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/getembeddedfonts/) metódust az ágyazott betűkészletek lekéréséhez, és a [FontsManager::GetFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/getfonts/) metódust a prezentáció által használt betűkészletek lekéréséhez. Hasonlítsa össze a két eredményt, hogy megtalálja azokat a betűkészleteket, amelyek a megjelenítéshez szükségesek, de nincsenek beágyazva.

**Hogyan tudom gyorsan megállapítani, hogy a fájl tartalmaz-e rejtett diákot, és ha igen, hány darabot?**

Ha a tárolt dokumentum metaadatok elegendőek, olvassa a [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) értéket az [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) és az [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) használatával. Ez alkalmas egy könnyű leltárhoz. Ha a prezentáció memóriában módosult, a tárolt metaadatok hiányozhatnak vagy elavultak lehetnek, vagy ha élő értékeket kell ellenőrizni, akkor iteráljon a [Presentation::get_Slides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_slides/) elemein, és vizsgálja meg minden dia [Slide::get_Hidden](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/get_hidden/) metódusát.

**Felderíthetem-e, hogy egyedi diamegméret és tájolás van-e használatban, és hogy ezek eltérnek-e az alapértelmezettektől?**

Igen. Töltse be a prezentációt, és olvassa a [Presentation::get_SlideSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_slidesize/) értéket. Vizsgálja meg az [ISlideSize::get_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidesize/get_type/), az [ISlideSize::get_Size](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidesize/get_size/), és az [ISlideSize::get_Orientation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidesize/get_orientation/) metódusokat, hogy összehasonlítsa a jelenlegi beállításokat a várt előre beállított értékekkel és méretekkel.

**Van gyors módja annak, hogy megállapítsam, a diagramok külső adatforrásokra hivatkoznak-e?**

Igen. Keresse meg az egyes [Chart](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chart/) objektumokat, és vizsgálja meg a [ChartData::get_DataSourceType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) metódust. Külső munkafüzet esetén olvassa a [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) értéket. Az adatforrás típusa és az útvonal azonosítja a külső hivatkozást, de annak elérhetőségének ellenőrzése külön erőforrás-ellenőrzést igényel.

**Hogyan értékelhetem a „nehéz” diákokat, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Nincs egyetlen komplexitási tulajdonság. Járja be a [Presentation::get_Slides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_slides/) elemeit és minden dia [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslide/get_shapes/) gyűjteményét. Használja a formák számát, valamint a nagy méretű képek, effektusok, animációk vagy multimédia jelenlétét szűrőjelzőként, és végezzen mérési renderelést vagy exportot, mielőtt egy diát megerősített teljesítménybottként kezelne.