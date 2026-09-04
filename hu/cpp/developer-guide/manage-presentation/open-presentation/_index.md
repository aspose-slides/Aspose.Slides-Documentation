---
title: Prezentációk megnyitása C++-ban
linktitle: Prezentáció megnyitása
type: docs
weight: 20
url: /hu/cpp/open-presentation/
keywords:
- PowerPoint megnyitása
- OpenDocument megnyitása
- prezentáció megnyitása
- PPTX megnyitása
- PPT megnyitása
- ODP megnyitása
- prezentáció betöltése
- PPTX betöltése
- PPT betöltése
- ODP betöltése
- védett prezentáció
- nagy prezentáció
- külső erőforrás
- bináris objektum
- C++
- Aspose.Slides
description: "Tanulja meg, hogyan nyithat meg PowerPoint és OpenDocument prezentációkat C++-ban, adhat meg nyitási jelszavakat, szabályozhatja az erőforrás betöltését, és csökkentheti a memóriahasználatot az Aspose.Slides for C++ segítségével."
---
## **Bevezetés**

[Aspose.Slides for C++](https://products.aspose.com/slides/hu/cpp/) betöltheti a PowerPoint és OpenDocument prezentációkat fájlokból és adatfolyamokból. Miután egy prezentáció betöltődött, ellenőrizheti a felépítését, szerkesztheti a diákat, kezelheti az erőforrásokat, és mentheti az eredeti vagy egy másik támogatott formátumban.

A betöltés viselkedését testreszabhatja a [LoadOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/) osztály segítségével. Például megadhat egy nyitási jelszót, a nagy bináris objektumokat a memória kívül tarthatja, szabályozhatja a külső erőforrásokat, vagy kihagyhatja a beágyazott bináris adatokat.

## **Prezentációk megnyitása**

Egy meglévő prezentáció megnyitásához adja át az elérési útját a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) konstruktorának. A használat után szabadítsa fel a prezentációt, hogy a fájlkezelők, ideiglenes adatok és egyéb erőforrások gyorsan felszabaduljanak.

Az alábbi C++ példa megmutatja, hogyan nyisson meg egy prezentációt és kérdezze le a diák számát:

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

A nyitási jelszó titkosítja a prezentáció tartalmát. A teljes prezentáció betöltéséhez adja át a helyes jelszót a [LoadOptions::set_Password](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_password/) metódusnak, majd adja át az opciókat a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) konstruktorának. A betöltés sikertelen, ha a jelszó hiányzik vagy helytelen.

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

Jelszóészlelés, validáció és titkosítási munkafolyamatok leírását lásd a [Password-Protect Presentations](/slides/hu/cpp/password-protected-presentation/) oldalon. Ha egy titkosított prezentációt szándékosan nyilvános dokumentumtulajdonságokkal mentettek, ezek a tulajdonságok jelszó nélkül is olvashatók; lásd a [Manage Presentation Properties](/slides/hu/cpp/presentation-properties/) részt.

## **Nagy prezentációk megnyitása**

A [LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) szabályozza, hogy az Aspose.Slides hogyan kezeli a bináris nagy objektumokat, például képeket, hangot és videót. A forrásfájlt zárolhatja, engedélyezheti az ideiglenes fájlokat, és korlátozhatja a memóriában megtartott BLOB adatok mennyiségét.

Az alábbi C++ kód egy nagy prezentáció betöltését mutatja be (például 2 GB):

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
A `PresentationLockingBehavior::KeepLocked` beállítással a forrásfájl zárolva marad, amíg a `Presentation` objektum nincs felszabadítva. Ne mozgassa, írja felül vagy törölje a forrásfájlt, amíg az objektum él.
Az Aspose.Slides betöltés közben másolhatja egy bemeneti adatfolyam tartalmát. Nagy prezentációk esetén az adatfolyam helyett az elérési út általában hatékonyabb. További tárolási és memória-kezelési lehetőségekért lásd a [Manage BLOBs](/slides/hu/cpp/manage-blob/) oldalt.
{{% /alert %}}

## **Külső erőforrások vezérlése**

A [LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) egy [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iresourceloadingcallback/) megvalósítást fogad el. A visszahívás helyettesítő adatot adhat, átirányíthat egy erőforrást, használhatja az alapértelmezett betöltőt, vagy kihagyhatja az erőforrást. Ez akkor hasznos, ha a prezentációk külső képeket tartalmaznak, amelyeket alkalmazás‑specifikus biztonsági vagy tárolási szabályok szerint kell feloldani.

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

Egy prezentáció tartalmazhat beágyazott bináris adatokat, amelyekre az alkalmazásnak nincs szüksége, vagy amelyeket nem kíván megtartani. Példák:

- VBA projektek, elérhetők a [IPresentation::get_VbaProject](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_vbaproject/) segítségével;
- beágyazott OLE adatok, elérhetők a [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/) segítségével;
- ActiveX vezérlő adat, elérhető a [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icontrol/get_activexcontrolbinary/) segítségével.

Adja át a `true` értéket a [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) metódusnak a bináris adatok betöltés közbeni eltávolításához. Mentse a betöltött prezentációt a tisztított eredmény megőrzéséhez.

Ez az opció csökkenti a nem kívánt beágyazott payloadok kitettségét, de nem tekinthető teljes körű malware‑detektáló vagy tartalomszűrő rendszernek.

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

**Hogyan tudom megállapítani, hogy egy fájl sérült és nem nyitható meg?**

Az Aspose.Slides betöltés közben parse‑ vagy formátum‑kivételt dob. Kezelje ezt a hibát külön a helytelen jelszó hibájától, hogy az alkalmazás pontosan tudja jelenteni az okot.

**Mi történik, ha a szükséges betűtípusok hiányoznak?**

A prezentáció még betölthető, de a megjelenítés és export helyettesítő betűtípusokat használhat. A [configure font substitution](/slides/hu/cpp/font-substitution/) vagy a [provide custom fonts](/slides/hu/cpp/custom-font/) segítségével tehet a kimenet előrejelezhetőbbé.

**Betölti-e a prezentáció betöltése a beágyazott médiát is?**

A beágyazott hang és videó elérhetővé válik a prezentáció objektummodellen keresztül. A külső erőforrások a beállított erőforrás‑betöltési viselkedés szerint kerülnek feloldásra, és előfordulhat, hogy nem érhetők el, ha a helyeikhez nem lehet hozzáférni.