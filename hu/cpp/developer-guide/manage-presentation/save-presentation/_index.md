---
title: Prezentációk mentése C++-ban
linktitle: Prezentáció mentése
type: docs
weight: 80
url: /hu/cpp/save-presentation/
keywords:
- PowerPoint mentése
- OpenDocument mentése
- prezentáció mentése
- dia mentése
- PPT mentése
- PPTX mentése
- ODP mentése
- prezentáció fájlba
- prezentáció adatfolyamba
- előre definiált nézet típus
- szigorú Office Open XML formátum
- Zip64 mód
- bélyegkép frissítése
- mentés folyamata
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan menthet prezentációkat C++-ban az Aspose.Slides használatával — exportálás PowerPoint vagy OpenDocument formátumba, miközben megőrizheti a elrendezéseket, betűtípusokat és hatásokat."
---
## **Áttekintés**

[Nyisd meg a prezentációkat C++-ban](/slides/hu/cpp/open-presentation/) leírja, hogyan kell használni a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályt egy prezentáció megnyitásához. Ez a cikk bemutatja, hogyan hozhatsz létre és menthetsz prezentációkat. A [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály a prezentáció tartalmát tartalmazza. Akár egy új prezentációt hozol létre, akár egy meglévőt módosítasz, a befejezés után menteni szeretnéd. Az Aspose.Slides for C++ segítségével **fájlba** vagy **adatfolyamban** menthetsz. Ez a cikk a különböző mentési módokat ismerteti.

## **Prezentációk mentése fájlokba**

A prezentációt fájlba mentheted a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály `Save` metódusának meghívásával. Add át a fájlnevet és a mentési formátumot a metódusnak. Az alábbi példa megmutatja, hogyan menthetünk egy prezentációt az Aspose.Slides segítségével.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt reprezentál.
auto presentation = MakeObject<Presentation>();

// Végezzen némi munkát itt...
// Mentse a prezentációt egy fájlba.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Prezentációk mentése adatfolyamokba**

A prezentációt adatfolyamba mentheted, ha egy kimeneti adatfolyamot adsz át a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály `Save` metódusának. A prezentáció számos adatfolyam típusba írható. Az alábbi példában egy új prezentációt hozunk létre, és egy fájl adatfolyamra mentjük.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Mentse a prezentációt az adatfolyamba.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Prezentációk mentése előre definiált nézet típussal**

Az Aspose.Slides lehetővé teszi, hogy beállítsd a kezdeti nézetet, amelyet a PowerPoint használ, amikor a generált prezentáció megnyílik, a [ViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/) osztályon keresztül. Használd a [set_LastView](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/set_lastview/) metódust a [ViewType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewtype/) felsorolt értékével.

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Prezentációk mentése a szigorú Office Open XML formátumban**

Az Aspose.Slides lehetővé teszi, hogy egy prezentációt a Strict Office Open XML formátumban mentsünk. Használd a [PptxOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pptxoptions/) osztályt, és állítsd be a megfelelőségi (conformance) tulajdonságát mentéskor. Ha a `Conformance.Iso29500_2008_Strict` értéket állítod be, a kimeneti fájl a Strict Office Open XML formátumban kerül mentésre.

Az alábbi példa egy prezentációt hoz létre, és a Strict Office Open XML formátumban menti el.

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt reprezentál.
auto presentation = MakeObject<Presentation>();

// Mentse a prezentációt a szigorú Office Open XML formátumban.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Prezentációk mentése Office Open XML formátumban Zip64 módon**

Az Office Open XML fájl egy ZIP archívum, amely 4 GB (2^32 bájt) korlátot szab az egyes fájlok kitömörített méretére, a fájlok tömörített méretére és az archívum teljes méretére, valamint legfeljebb 65 535 (2^16‑1) fájlra korlátozza az archívumot. A ZIP64 formátum kiterjesztések ezeket a korlátokat 2^64‑re emelik.

Az [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) metódus lehetővé teszi, hogy kiválaszd, mikor használj ZIP64 formátum kiterjesztéseket Office Open XML fájl mentésekor.

Ez a metódus a következő módokkal használható:

- `IfNecessary` csak akkor használja a ZIP64 kiterjesztéseket, ha a prezentáció meghaladja a fenti korlátokat. Ez az alapértelmezett mód.
- `Never` soha nem használja a ZIP64 kiterjesztéseket.
- `Always` mindig használja a ZIP64 kiterjesztéseket.

Az alábbi kód bemutatja, hogyan menthetünk egy prezentációt PPTX fájlként a ZIP64 kiterjesztésekkel engedélyezve:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Amikor `Zip64Mode.Never` értékkel mentünk, egy [PptxException](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pptxexception/) kerül dobásra, ha a prezentációt ZIP32 formátumban nem lehet menteni.
{{% /alert %}}

## **Prezentációk mentése Office Open XML formátumban tömörítési szintekkel**

Nagy prezentációk esetén a tömörítési szint beállításával egyensúlyba hozhatod a fájlméretet és a feldolgozási időt. Az igényeidtől függően a gyorsabb feldolgozást vagy a kisebb kimeneti fájlokat részesítheted előnyben.

Az Aspose.Slides biztosítja a [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) metódust, amellyel megadhatod a Office Open XML formátumban történő mentéskor alkalmazott tömörítési szintet.

A következő tömörítési szintek érhetők el:

- **None**: Nem alkalmaz tömörítést. A fájlok változatlanul tárolódnak.
- **Level1**: A leggyorsabb tömörítés a legalacsonyabb tömörítési aránnyal.
- **Level2**: Gyorsabb tömörítés, kissé jobb arány **Level1**‑hez képest.
- **Level3**: Jobb tömörítés **Level2**‑nél, közepes hatással a feldolgozási időre.
- **Level4**: Jobb tömörítés **Level3**‑nál.
- **Level5**: Javított tömörítés **Level4**‑hez képest, további feldolgozási idővel.
- **Level6**: Szabványos tömörítés, amely jó egyensúlyt kínál a feldolgozási sebesség és a fájlméret között. Ez a *alapértelmezett tömörítési szint*.
- **Level7**: Jobb tömörítés **Level6**‑nál, lassabb feldolgozással.
- **Level8**: Jobb tömörítés **Level7**‑nél.
- **Level9**: Maximális tömörítés. A legkisebb fájlméretet érheti el, de a leghosszabb feldolgozási időt igényli.

Az alábbi példa bemutatja, hogyan menthetünk egy prezentációt PPTX fájlként *tömörítés nélkül*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

Ez a példa megmutatja, hogyan menthetünk egy prezentációt PPTX fájlként *maximális tömörítéssel*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **Prezentációk mentése a bélyegkép frissítése nélkül**

A [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) metódus szabályozza a bélyegkép generálását PPTX formátumba mentéskor:

- Ha `true` értékre van állítva, a bélyegkép a mentés során frissül. Ez az alapértelmezett.
- Ha `false` értékre van állítva, a jelenlegi bélyegkép megmarad. Ha a prezentációnak nincs bélyegképe, az nem kerül generálásra.

Az alábbi kódban a prezentációt PPTX‑ként mentjük anélkül, hogy a bélyegképet frissítenénk.

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Ez az opció segít csökkenteni a PPTX formátumba történő mentés idejét.
{{% /alert %}}

## **Mentés előrehaladásának frissítése százalékban**

Az [IProgressCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprogresscallback/) interfészt a [ISaveOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/isaveoptions/) interfész által kitetts `set_ProgressCallback` metódus, illetve az absztrakt [SaveOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveoptions/) osztály használja. Adj meg egy [IProgressCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprogresscallback/) megvalósítást a `set_ProgressCallback`‑el, hogy a mentés előrehaladását százalékban kapd meg.

Az alábbi kódrészletek bemutatják, hogyan használhatod az `IProgressCallback`‑ot.

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // Használja a folyamat százalékos értékét itt.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// A fent definiált előrehaladás visszahívási osztály.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Az Aspose egy [free PowerPoint Splitter app](https://products.aspose.app/slides/hu/splitter) alkalmazást fejlesztett saját API-jával. Az app lehetővé teszi, hogy egy prezentációt több fájlra ossz, a kiválasztott diák új PPTX vagy PPT fájlokként történő mentésével.
{{% /alert %}}

## **GYIK**

**Támogatott a „gyors mentés” (inkrementális mentés), amely csak a változásokat írja?**

Nem. A mentés minden alkalommal a teljes célfájlt hozza létre; az inkrementális „gyors mentés” nem támogatott.

**Szálbiztos-e ugyanazon Presentation példány mentése több szálról?**

Nem. A [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példány [nem szálbiztos](/slides/hu/cpp/multithreading/); csak egy szálról mentse.

**Mi történik a hiperhivatkozásokkal és a külsőleg linkelt fájlokkal mentéskor?**

[Hiperhivatkozások](/slides/hu/cpp/manage-hyperlinks/) megmaradnak. A külsőleg linkelt fájlok (például relatív útvonalú videók) nem másolódnak automatikusan – győződjön meg arról, hogy a hivatkozott útvonalak elérhetők maradnak.

**Beállíthatom/menthetem a dokumentum metaadatait (Szerző, Cím, Cég, Dátum)?**

Igen. A szabványos [dokumentum tulajdonságok](/slides/hu/cpp/presentation-properties/) támogatottak, és mentéskor a fájlba kerülnek.