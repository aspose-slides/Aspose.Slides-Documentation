---
title: Bemutatók mentése C++-ban
linktitle: Bemutató mentése
type: docs
weight: 80
url: /hu/cpp/save-presentation/
keywords:
- PowerPoint mentése
- OpenDocument mentése
- bemutató mentése
- dia mentése
- PPT mentése
- PPTX mentése
- ODP mentése
- bemutató fájlba
- bemutató adatfolyamba
- előre meghatározott nézet típusa
- Szigorú Office Open XML formátum
- Zip64 mód
- bélyegkép frissítése
- mentés előrehaladása
- C++
- Aspose.Slides
description: "PowerPoint és OpenDocument bemutatókat ment egy fájlba vagy adatfolyamba C++-ban az Aspose.Slides használatával, valamint beállítható a PPTX kimenet és a mentés előrehaladásának jelentése."
---
## **Áttekintés**

Miután létrehoz egy bemutatót, vagy [megnyit egy meglévő bemutatót](/slides/hu/cpp/open-presentation/), használja a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódust az eredmény írásához. Az Aspose.Slides for C++ képes egy bemutatót fájlba vagy adatfolyamba menteni PowerPoint, OpenDocument, PDF és más formátumokban. Az alábbi szakaszok a szabványos mentési műveleteket és a PPTX kimenethez elérhető beállításokat tárgyalják.

## **Bemutatók mentése fájlokba**

A bemutató fájlba mentéséhez adja meg a kimeneti útvonalat és egy [SaveFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveformat/) értéket a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódusnak. A formátum érték határozza meg, milyen típusú fájlt hoz létre az Aspose.Slides.

Az alábbi példa egy bemutatót hoz létre, és PPTX fájlként menti el:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// Adjon hozzá vagy módosítson prezentációs tartalmat itt.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Bemutatók mentése az eredeti formátumban**

A fájl- és adatfolyamdetektálási példákért, az újonnan létrehozott bemutatók viselkedéséért, valamint a forrás- és kimeneti formátumok közötti különbségért lásd a [Determine the Original Presentation Format](/slides/hu/cpp/detect-presentation-source-format/) oldalt.

Kötegelt feldolgozó alkalmazásban a bemeneti formátum előre nem ismerhető. Egy fájl betöltése után olvassa ki az eredeti formátumot az [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_sourceformat/) segítségével. A kapott [SourceFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sourceformat/) értéket adja át a [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/tosaveformat/) metódusnak, hogy megkapja a megfelelő [SaveFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveformat/) értéket, majd ezt használja a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódusban a módosított bemutató írásához.

Az alábbi teljes példa minden fájlt feldolgoz egy bemeneti könyvtárban, frissíti a címét, és a betöltéskor használt formátumban menti el egy kimeneti könyvtárba:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/tosaveformat/) a PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP és PowerPoint XML formátumokat a megfelelő prezentáció mentési formátumokra képezi le. Csak a bemeneti prezentáció formátumait térképezi; nem arra szolgál, hogy exportálási formátumokat, például PDF, HTML, TIFF vagy képek legyenek kiválasztva. Nem támogatott vagy érvénytelen [SourceFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sourceformat/) érték átadása [ArgumentException](https://reference.aspose.com/slides/hu/cpp/system/argumentexception/) kivételt eredményez.

A régi PPT, PPS és POT fájlok ugyanazt a bináris konténert használják. Ha egy ilyen bemutatót kiterjesztés nélküli adatfolyamból töltenek be, egy PPS vagy POT fájl ezért PPT‑ként azonosítható. Ha meg kell őrizni ezeket a régi alkategóriákat, tartsa meg az eredeti fájlnevet vagy formátum metaadatokat külön, és használja őket a kimeneti fájlnév és formátum kiválasztásakor.

## **Bemutatók mentése adatfolyamokba**

A bemutató írásához, anélkül, hogy végleges fájlútvonalra támaszkodna, adjon át egy írható [Stream](https://reference.aspose.com/slides/hu/cpp/system.io/stream/) objektumot és egy [SaveFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveformat/) értéket a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódusnak. Ez a megközelítés akkor hasznos, ha a kimenetet egy webszolgáltatásból kell visszaadni, adatbázisban tárolni vagy memóriában feldolgozni.

Az alábbi példa egy új bemutatót fájl adatfolyamba ment:

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

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **Bemutatók mentése előre meghatározott nézet típussal**

Megadhatja azt a nézetet, amelyben a PowerPoint a mentett bemutatót kezdetben megnyitja. Hívja meg a [ViewProperties::set_LastView](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/set_lastview/) metódust egy [ViewType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewtype/) értékkel a mentés előtt.

Az alábbi példa a Dia-művelet-mester nézetet állítja be kezdeti nézetként:

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

## **Bemutatók mentése a szigorú Office Open XML formátumban**

Egy olyan PPTX fájl létrehozásához, amely megfelel az Office Open XML szigorú profiljának, hozza létre a [PptxOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pptxoptions/) példányt, és hívja a [PptxOptions::set_Conformance](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pptxoptions/set_conformance/) metódust a `Conformance::Iso29500_2008_Strict` értékkel. Ezután adja át a beállításokat a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódusnak.

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

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Bemutatók mentése Office Open XML formátumban Zip64 módban**

A szabványos ZIP archívum korlátozza az egyes bejegyzések tömörített és tömörítetlen méretét, a teljes archívum méretét és a bejegyzések számát. Mivel egy PPTX fájl ZIP archívum, egy nagyon nagy bemutató meghaladhatja ezeket a korlátokat. A ZIP64 kiterjesztések megemelik a vonatkozó méret- és bejegyzésszám-korlátokat.

Használja a [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) metódust annak vezérléséhez, hogy az Aspose.Slides írja‑e a ZIP64 kiterjesztéseket:

- `IfNecessary` csak akkor használja a ZIP64-et, ha a bemutató meghaladja a szabványos ZIP korlátokat. Ez az alapértelmezett mód.
- `Never` letiltja a ZIP64 kiterjesztéseket.
- `Always` mindig beírja a ZIP64 kiterjesztéseket.

Az alábbi példa mindig engedélyezi a ZIP64 kiterjesztéseket a kimeneti bemutatóhoz:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
Ha a `Zip64Mode` értéke `Never`, és a bemutató nem fér bele a szabványos ZIP korlátokba, a mentési művelet [PptxException](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pptxexception/) kivételt dob.
{{% /alert %}}

## **Bemutatók mentése Office Open XML formátumban tömörítési szintekkel**

PPTX kimenet esetén a mentési sebesség és a fájlméret közötti egyensúly érdekében hívja a [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) metódust. A [CompressionLevel](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/compressionlevel/) felsorolás a következő értékeket biztosítja:

- `None` adatot tömörítés nélkül tárol.
- `Level1` a leggyorsabb tömörítést és a legnagyobb tömörített kimenetet biztosítja.
- `Level2`‑`Level5` fokozatosan a kisebb kimenetet részesítik előnyben a mentési sebességgel szemben.
- `Level6` egyensúlyt teremt a mentési sebesség és a fájlméret között. Ez az alapértelmezett szint.
- `Level7` és `Level8` tovább a kisebb kimenet felé hajlik a mentési sebességgel szemben.
- `Level9` a legerősebb tömörítést biztosítja, és a legtöbb feldolgozási időt igényli.

Az alábbi példa egy bemutatót tömörítés nélkül ment:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

Az alábbi példa a maximális tömörítési szintet használja:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Bemutatók mentése a bélyegkép frissítése nélkül**

Amikor egy bemutatót PPTX‑ként ment, a [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) szabályozza a dokumentum bélyegképét:

- `true` a bélyegképet a mentés során újragenerálja. Ez az alapértelmezett érték.
- `false` megőrzi a meglévő bélyegképet. Ha a bemutatónak nincs bélyegképe, az Aspose.Slides nem generál újat.

Az alábbi példa egy bemutatót a bélyegkép frissítése nélkül ment:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
A bélyegkép frissítésének letiltása csökkentheti a PPTX fájl mentéséhez szükséges időt.
{{% /alert %}}

## **A mentés előrehaladásának frissítései százalékban**

A mentési művelet nyomon követéséhez valósítsa meg az [IProgressCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprogresscallback/) interfészt, és adja át a megvalósítást az [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/isaveoptions/set_progresscallback/) metódusnak. Az Aspose.Slides ekkor az [IProgressCallback::Reporting](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprogresscallback/reporting/) metóduson keresztül jelenteni fogja a mentés előrehaladását.

Az alábbi példa egy PDF export előrehaladását jeleníti meg a konzolon:

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

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Az Aspose egy ingyenes [PowerPoint Splitter](https://products.aspose.app/slides/hu/splitter) eszközt biztosít, amely az Aspose.Slides API‑val készült. Kiválasztott diák mentése külön PPT vagy PPTX fájlokként.
{{% /alert %}}

## **FAQ**

**Támogatja az Aspose.Slides a részleges vagy „gyors mentést”?**

Nem. Minden mentési művelet a teljes kimeneti fájlt írja, nem csak a módosított részeket.

**Több szál tudja-e menteni ugyanazt a Presentation példányt?**

Nem. A [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példány **nem szálbiztonságos** (/slides/hu/cpp/multithreading/). Egy példányt egyszerre csak egy szál férhet hozzá és mentheti.

**Mi történik a hiperlinkekkel és a külsőleg csatolt fájlokkal, amikor mentek egy bemutatót?**

A [Hyperlinks](/slides/hu/cpp/manage-hyperlinks/) megmarad a bemutatóban. Az Aspose.Slides nem másolja a külsőleg csatolt fájlokat, ezért a mentett bemutatónak továbbra is hozzá kell férnie azok helyéhez.

**Menthetek‑e dokumentum metaadatokat, például szerzőt, címet, céget és létrehozási dátumot?**

Igen. Állítsa be a megfelelő [document properties](/slides/hu/cpp/presentation-properties/) értékeket a mentés előtt, és az Aspose.Slides beleírja őket a kimeneti fájlba.