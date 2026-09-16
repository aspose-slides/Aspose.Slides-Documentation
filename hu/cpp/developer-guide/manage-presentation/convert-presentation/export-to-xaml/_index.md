---
title: Prezentációk exportálása XAML-be C++-ban
linktitle: Prezentáció XAML-be
type: docs
weight: 30
url: /hu/cpp/export-to-xaml/
keywords:
- PowerPoint exportálása
- OpenDocument exportálása
- prezentáció exportálása
- PowerPoint konvertálása
- OpenDocument konvertálása
- prezentáció konvertálása
- PowerPoint XAML-be
- OpenDocument XAML-be
- prezentáció XAML-be
- PPT XAML-be
- PPTX XAML-be
- ODP XAML-be
- PPT mentése XAML-ként
- PPTX mentése XAML-ként
- ODP mentése XAML-ként
- PPT exportálása XAML-be
- PPTX exportálása XAML-be
- ODP exportálása XAML-be
- C++
- Aspose.Slides
description: "PowerPoint és OpenDocument diák konvertálása XAML-be C++-ban az Aspose.Slides segítségével — gyors, Office-mentes megoldás, amely megőrzi a meglévő elrendezést."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan exportálhatók a PowerPoint‑prezentációk XAML formátumba az Aspose.Slides segítségével. Tartalmaz egy rövid bevezetést az XAML‑ba, megmutatja, hogyan menthető el egy prezentáció XAML‑ba alapértelmezett beállításokkal, és bemutatja, hogyan testre szabható az exportálás a [XamlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/xamloptions/) használatával, beleértve a rejtett diák exportálását is. A cikk válaszol néhány gyakori kérdésre a tartalékbetűtípusokkal, az XAML‑verem kompatibilitással és a rejtett diák exportálásának viselkedésével kapcsolatban.

## **Az XAML‑ról**

Az XAML egy XML‑alapú jelölőnyelv, amelyet felhasználói felületek leírására használnak az olyan keretrendszerekben, mint a WPF (Windows Presentation Foundation), az UWP (Universal Windows Platform) és a Xamarin.Forms.

Az XAML‑fájlokkal dolgozhatsz egy vizuális tervezőben, vagy közvetlenül írhatod és szerkesztheted a jelölést.

## **Prezentációk exportálása XAML‑ba alapértelmezett beállításokkal**

Az alábbi C++ példa bemutatja, hogyan exportálhatunk egy prezentációt XAML‑ba alapértelmezett beállításokkal:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

Alapértelmezés szerint az exportált diák a folyamat aktuális munkakönyvtárának `pres` almappájába mentődnek, ahogy a [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/hu/cpp/system.io/directory/getcurrentdirectory/) visszaadja. A mappa automatikusan létrejön, és a szükséges képek is oda kerülnek.

A kimeneti mappa neve a forrásfájl nevéből, kiterjesztés nélkül származik. A `pres.pptx` esetén a kimeneti fájlok neve `pres/Slide_1.xaml`, `pres/Slide_2.xaml` stb. Még ha abszolút elérési utat adsz is a bemeneti prezentációnak, a kimeneti mappa az aktuális munkakönyvtárhoz képest relatív módon jön létre, nem a bemeneti fájl mellé.

## **Prezentációk exportálása XAML‑ba egyedi beállításokkal**

Használd az [IXamlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/ixamloptions/) interfészt annak szabályozásához, hogyan exportálja az Aspose.Slides a prezentációt XAML‑ba.

A kimenet egy egyedi helyre mentéséhez valósítsd meg az [IXamlOutputSaver](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/ixamloutputsaver/) interfészt, és add át az implementációd egy példányát a [set_OutputSaver](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) metódusnak a [XamlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/xamloptions/) esetén.

A rejtett diák XAML‑kimenetbe való felvételéhez add át a `true` értéket a [set_ExportHiddenSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) metódusnak, ahogy az alábbi C++ példában látható:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **Az összes létrehozott XAML‑műtárgy rögzítése**

Egy XAML export létrehozhat egy XAML dokumentumot minden exportált diára, valamint különálló képeket és támogató erőforrásokat. Adj át egy egyedi [IXamlOutputSaver](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/ixamloutputsaver/) példányt a [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) metódusnak, hogy ezeket a műtárgyakat a szabványos fájlrendszer‑mentő helyett kapd meg. Indítsd az exportálást az XAML‑specifikus [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) túlterheléssel, amely XAML beállításokat fogad.

### **A visszahívás életciklusának megértése**

Az exportáló külön-külön hívja meg az [IXamlOutputSaver::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) metódust minden egyes létrehozott műtárgyra:

- `path` azonosítja a műtárgyat, és tartalmazhat relatív könyvtárakat. Tartsd meg ezt az információt, mivel az XAML relatív útvonalakat használhat az erőforrások hivatkozásához.
- `data` a műtárgy bájtjait tartalmazza. A képeket és egyéb bináris erőforrásokat nem szabad szövegként dekódolni.
- A mentőnek (saver) felelőssége a adatok megtartása vagy perzisztálása visszatérés előtt. A példák minden bájt tömböt az alkalmazás által kezelt memóriába másolnak.
- Az exportálást csak akkor tekintsd sikeresnek, ha a prezentáció mentési művelete visszatér, és minden visszahívás sikeresen befejeződött. Ne nyelj el tárolási hibákat, és ne indíts megfigyelés nélküli háttérírásokat. Ha a perzisztálás később történik, az összesített sikert csak azután jelentsd, ha ez a lépés is sikeres.

[A XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) szintén érvényes egy egyedi mentőre. Az alapértelmezett beállítás, `false`, kizárja a rejtett diák XAML dokumentumait. Ha `true`‑ra állítod, ezek és minden szükséges erőforrás be lesznek vonva. Az erőforrások száma a prezentációtól függ; ne feltételezz egy visszahívást diánként vagy egy rögzített visszahívási sorrendet.

### **Exportálás memóriába és a műtárgyak ellenőrzése**

Ez a teljes példa betölti a `pres.pptx` fájlt, összegyűjti minden műtárgyat egy [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/hu/cpp/system.collections.generic/dictionary/) objektumban, és kiírja a nevét, típusát és bájtszámát. A megadott neveket pontosan megőrzi. A duplikált nevek a gyűjtést hibára kényszerítik, ahelyett, hogy csendben felülírnák a műtárgyat.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // Csak az XAML-t dekódolja, és csak akkor, ha szöveges ellenőrzésre van szükség.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

Hívd meg az `InMemoryXamlExample::Run` metódust az alkalmazásodból. A kiterjesztés‑ellenőrzések hasznosak az ellenőrzéshez; tartsd meg az összes műtárgyat, beleértve a kevésbé ismert erőforrás‑típusokat is. A bájtokat ne módosítsd tárolás vagy továbbítás közben. Használd az [Encoding::GetString](https://reference.aspose.com/slides/hu/cpp/system.text/encoding/getstring/) metódust UTF‑8 kódolással csak akkor, ha az XAML‑nak szöveges feldolgozásra van szüksége.

### **A gyűjtött műtárgyak csomagolása ZIP archívumba**

Ez a független példa összegyűjti az exportot, ellenőri a neveket, és az eredeti bájtokat egy ZIP archívumba írja. Egy egyedi archívumnév elkülöníti az egyidejű exportfeladatokat. A ZIP bejegyzések perjel‑elválasztókat használnak és megtartják a relatív könyvtárakat. A nem biztonságos vagy normalizálás után ütköző neveket a csomag teljes írása előtt elutasítja.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // A Save befejezi a ZIP könyvtárat; a siker jelentése előtt zárja be a fájlt.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

Hívd meg a `ZipXamlExample::Run` metódust az alkalmazásodból. A példa a C++ futtatókörnyezetből származó `Aspose::Zip::ZipFile`‑t használja egy lokális archívum írásához; az exportáló maga nem ír laza XAML vagy kép fájlokat. Távoli tároláshoz cseréld le az archívum‑írási lépést a gyűjtött bájt‑tömbök feltöltésére. Használj egy export‑feladat azonosítót a relatív műtárgy‑névvel együtt blob‑kulcsként, vagy tárold az azonosítót, a relatív nevet és a bináris adatot egy adatbázis‑sorban. A feladatot csak akkor publikáld, ha az összes feltöltés befejeződött vagy a tranzakció commit‑ra került. Ha a perzisztálás meghiúsul, tisztítsd meg a részleges kimenetet.

Nagy prezentációk esetén egy egyedi mentő közvetlenül perzisztálhatja a műtárgyakat az alkalmazás tárolójába, így elkerülve a teljes export másolatának megtartását memóriában. Az exportáló továbbra is összegyűjti az összes generált műtárgyat memóriában, mielőtt meghívná a mentőt. Tartsd a visszahívásokat szinkronban az exportáló szemszögéből: csak akkor térj vissza, amikor a célpont elfogadta a bájtokat, és engedd, hogy a hibák eljussanak a hívóhoz.

### **Erőforrás‑nevek megőrzése és hivatkozások ellenőrzése**

- Normalizáld az elérési útvonal‑elválasztókat, ha a célpont igényli, de tartsd meg a relatív könyvtárakat. Ne használj csak a [Path::GetFileName](https://reference.aspose.com/slides/hu/cpp/system.io/path/getfilename/)‑t, kivéve ha minden generált név egyedi és az erőforrás‑hivatkozások érvényesek maradnak.
- Alkalmazz célpont‑specifikus névvalidálást. Lágy fájlok írásakor utasítsd el a gyökér‑utakat és a traverszálási szegmenseket, oldd fel a célt a [Path::GetFullPath](https://reference.aspose.com/slides/hu/cpp/system.io/path/getfullpath/) segítségével, és győződj meg róla, hogy a megadott út a célkönyvtár alatt marad, beleértve a könyvtár‑elválasztót a tartalmazás‑ellenőrzésben. Használj egy alkalmazás‑vezérelt könyvtárat szimbolikus linkek nélkül, amelyek átirányíthatják a beírásokat.
- Használj külön mentőt és tárolási névtér‑kört minden exportfeladathoz. Detektáld az ütközéseket az elválasztó normalizálása után és a célpont esetleges nagy‑/kis‑betű érzékenysége szerint.
- A publikálás előtt elemezd minden XAML‑dokumentumot XML‑ként, és ellenőrizd a fájl‑alapú erőforrás‑hivatkozásokat, például a kép `Source` vagy `ImageSource` attribútumait. Oldd fel a relatív URI‑kat a tartalmazó XAML‑műtárgy könyvtárához képest, normalizáld a keletkező tárolási nevet, és erősítsd meg, hogy a megfelelő szótár‑kulcs, ZIP‑bejegyzés vagy tárolt objektum létezik. Kezelj külön a külső URI‑kat és az XAML‑markup kifejezéseket a relatív fájlnevektől.

Például, ha a `pres/Slide_1.xaml` a `images/image1.png`‑t hivatkozza, a tárolt erőforrásnak elérhetőnek kell lennie `pres/images/image1.png`‑ként. Csak a `image1.png` megtartása megszakítaná a kapcsolatot. Objektumtárolás esetén tartsd meg ugyanazt a struktúrát a feladat előtag alatt, és biztosítsd, hogy ezek a resource‑URL‑ek elérhetőek legyenek az XAML‑fogyasztó számára. Nyisd meg a kész ZIP‑et, ellenőrizd a bejegyzés‑neveket és az erőforrás‑bájtokat, majd tölts be reprezentatív diákat a cél XAML környezetben, hogy megbizonyosodj a képek helyes feloldásáról.

## **GYIK**

**Hogyan biztosíthatom a kiszámítható betűtípusokat, ha az eredeti betűtípus nem érhető el a gépen?**

Használd a [set_DefaultRegularFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) beállítást a [XamlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/xamloptions/)‑ban – ez kerül felhasználásra tartalékbetűtípusként az exportálás során, ha az eredeti hiányzik. Ez nem garantálja, hogy a generált XAML a tartalékbetűtípust hivatkozza, vagy hogy a betűtípus a célgépen elérhető. Győződj meg róla, hogy az XAML‑ban hivatkozott betűtípusok rendelkezésre állnak a megjelenítő környezetben.

**Az exportált XAML csak WPF‑hez készült, vagy használható más XAML‑veremekben is?**

Az Aspose.Slides a WPF XAML‑t exportálja a nyilvános API‑jával. Más XAML‑veremekkel, például UWP‑vel vagy Xamarin.Forms‑zal való kompatibilitás nem garantált. Teszteld a generált jelölést a cél környezetedben.

**Támogatottak a rejtett diák, és hogyan akadályozhatom meg, hogy alapértelmezés szerint exportálódjanak?**

Alapértelmezés szerint a rejtett diák nincsenek benne. Ezt a viselkedést a [set_ExportHiddenSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) beállítással a [XamlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/xamloptions/)‑ban szabályozhatod – tartsd letiltva, ha nem szeretnéd, hogy exportálásra kerüljenek.