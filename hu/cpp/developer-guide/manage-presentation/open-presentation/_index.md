---
title: "Prezentációk megnyitása C++-ban"
linktitle: "Prezentáció megnyitása"
type: docs
weight: 20
url: /hu/cpp/open-presentation/
keywords:
- "PowerPoint megnyitása"
- "OpenDocument megnyitása"
- "prezentáció megnyitása"
- "PPTX megnyitása"
- "PPT megnyitása"
- "ODP megnyitása"
- "prezentáció betöltése"
- "PPTX betöltése"
- "PPT betöltése"
- "ODP betöltése"
- "védett prezentáció"
- "nagy prezentáció"
- "külső erőforrás"
- "bináris objektum"
- "C++"
- "Aspose.Slides"
description: "Ismerje meg, hogyan nyithat meg PowerPoint és OpenDocument prezentációkat C++-ban, adhat meg nyitó jelszavakat, szabályozhatja az erőforrás betöltését, és csökkentheti a memóriahasználatot az Aspose.Slides for C++ segítségével."
---
## **Bevezetés**

[Aspose.Slides for C++](https://products.aspose.com/slides/hu/cpp/) betöltheti a PowerPoint és az OpenDocument prezentációkat fájlokból és adatfolyamokból. A prezentáció betöltése után ellenőrizheti a felépítését, szerkesztheti a diákot, kezelheti az erőforrásokat, és elmentheti az eredeti vagy egy másik támogatott formátumban.

A betöltési viselkedés testreszabható a [LoadOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/) osztályon keresztül. Például megadhat nyitó jelszót, a nagy bináris objektumokat a memórián kívül tarthatja, szabályozhatja a külső erőforrásokat, vagy kihagyhatja a beágyazott bináris adatokat.

## **Prezentációk megnyitása**

Egy fájl vagy adatfolyam betöltése után [megállapíthatja az eredeti prezentáció formátumát](/slides/hu/cpp/detect-presentation-source-format/), hogy kiválassza, hogyan dolgozza fel az alkalmazás.

Egy meglévő prezentáció megnyitásához adja át a fájl útvonalát a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) konstruktorának. A prezentációt használat után engedje el, hogy a fájlkezelők, ideiglenes adatok és egyéb erőforrások időben felszabaduljanak.

Az alábbi C++ példa bemutatja, hogyan nyitható meg egy prezentáció és hogyan kérhető le a diák száma:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Jelszóval védett prezentációk megnyitása**

A nyitó jelszó titkosítja a prezentáció tartalmát. A teljes prezentáció betöltéséhez adja át a helyes jelszót a [LoadOptions::set_Password](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_password/) metódusnak, majd az opciókat a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) konstruktorának. A betöltés hibát jelez, ha a jelszó hiányzik vagy helytelen.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

A jelszódetektálásról, validálásról és titkosítási munkafolyamatokról lásd a [Password-Protect Presentations](/slides/hu/cpp/password-protected-presentation/) oldalát. Ha egy titkosított prezentációt szándékosan nyilvános dokumentumtulajdonságokkal mentettek, ezek a tulajdonságok jelszó nélkül is olvashatók; lásd a [Manage Presentation Properties](/slides/hu/cpp/presentation-properties/) részt.

## **Nagy prezentációk megnyitása**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) szabályozza, hogyan kezeli az Aspose.Slides a bináris nagy objektumokat, például képeket, hangot és videót. A forrásfájlt lezárhatja, engedélyezheti az ideiglenes fájlok használatát, és korlátozhatja a memóriában megtartott BLOB-adat mennyiségét.

Az alábbi C++ kód bemutatja egy nagy (például 2 GB) prezentáció betöltését:

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
A `PresentationLockingBehavior::KeepLocked` használatával a forrásfájl lezárva marad, amíg a `Presentation` objektumot el nem engedik. Ne mozgassa, írja felül vagy törölje a forrásfájlt, amíg ez az objektum él.

Az Aspose.Slides a betöltés során másolja egy bemeneti adatfolyam tartalmát. Nagy prezentációk esetén a fájlútvonal általában hatékonyabb, mint az adatfolyam. További tárolási és memória-kezelési lehetőségekért lásd a [BLOB-kezelés](/slides/hu/cpp/manage-blob/) oldalt.
{{% /alert %}}

## **Külső erőforrások vezérlése**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) egy [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iresourceloadingcallback/) megvalósítást fogad. A visszahívás helyettesítő adatot adhat meg, átirányíthat egy erőforrást, a alapértelmezett betöltőt használhatja, vagy kihagyhatja az erőforrást. Ez akkor hasznos, ha a prezentációk külső képeket tartalmaznak, amelyeket az alkalmazás-specifikus biztonsági vagy tárolási szabályok szerint kell feloldani.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Prezentációk betöltése beágyazott bináris objektumok nélkül**

Egy prezentáció tartalmazhat beágyazott bináris adatot, amelyre egy alkalmazásnak nincs szüksége vagy nem kívánja megtartani. Példák:

- VBA projektek, elérhetők a [IPresentation::get_VbaProject](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_vbaproject/) segítségével;
- beágyazott OLE adatok, elérhetők a [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/) segítségével;
- ActiveX vezérlő adatok, elérhetők a [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icontrol/get_activexcontrolbinary/) segítségével.

Adja át a `true` értéket a [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) metódusnak, hogy a betöltés során eltávolítsa ezeket a bináris adatokat. Mentse a betöltött prezentációt a tisztított eredmény megőrzéséhez.

Ez a beállítás csökkenti a nemkívánatos beágyazott terhelések kockázatát, de nem helyettesíti a teljes rosszindulatú kód- vagy tartalomszűrő rendszert.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **GYIK**

**Hogyan deríthetem ki, hogy egy fájl sérült és nem nyitható meg?**  
Az Aspose.Slides betöltés közben parsing vagy formátum kivételt dob. Kezelje ezt a hibát külön a hibás jelszó hibától, hogy az alkalmazás pontosan tudja jelenteni az okot.

**Mi történik, ha hiányoznak a szükséges betűtípusok?**  
A prezentáció még betölthető, de a renderelés és az export helyettesítő betűtípusokat használhat. [Konfigurálhatja a betűtípus-helyettesítést](/slides/hu/cpp/font-substitution/) vagy [szállíthat egyedi betűtípusokat](/slides/hu/cpp/custom-font/), hogy a kimenet előre jelezhetőbb legyen.

**Betölt egy prezentáció a beágyazott médiát is?**  
A beágyazott hang és videó elérhető a prezentáció objektummodelljén keresztül. A külső erőforrások a konfigurált erőforrásbetöltési viselkedés szerint kerülnek feloldásra, és előfordulhat, hogy nem elérhetők, ha a helyük nem hozzáférhető.