---
title: Jelszóval védett bemutatók C++-ban
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/cpp/password-protected-presentation/
keywords:
- jelszóval védett bemutató
- megnyitási jelszó
- PowerPoint titkosítása
- PowerPoint visszafejtése
- bemutató jelszavának ellenőrzése
- bemutató jelszó ellenőrzése
- titkosított bemutató megnyitása
- titkosítás eltávolítása
- PowerPoint
- PPT
- PPTX
- bemutató
- C++
- Aspose.Slides
description: "Titkosítsa, észlelje, ellenőrizze, nyissa meg és fejtsen vissza jelszóval védett PowerPoint PPT és PPTX bemutatókat C++-ban az Aspose.Slides segítségével."
---
## **Áttekintés**

A megnyitási jelszó titkosítja a bemutatót. A megfelelő jelszó szükséges a bemutató tartalmának betöltéséhez és megtekintéséhez, így ez a védelem megőrzi a titkosságot.

A megnyitási jelszó különbözik az írásvédelmi jelszótól. Az írásvédelem korlátozza a módosítást, de nem titkosítja a tartalmat, és nem akadályozza meg a bemutató betöltését. Az írásvédelmi jelszavak kezeléséhez lásd a [Write-Protect Presentations](/slides/hu/cpp/write-protected-presentation/) oldalt.

Az alábbi munkafolyamatok PPT és PPTX bemutatókra egyaránt vonatkoznak. A példák mindkét formátumot használják, ahol a fájl‑ és adatfolyam‑alapú viselkedés fontos.

## **Titkosítsa a bemutatót megnyitási jelszóval**

Használja az [IProtectionManager::Encrypt](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprotectionmanager/encrypt/) metódust a megnyitási jelszó megadásához. Ezután használja az [IPresentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/save/) metódust a titkosított bemutató mentéséhez.

Az alábbi példa egy PPTX bemutatót titkosít:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Titkosított bemutató betöltése**

Állítsa be a [LoadOptions::set_Password](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_password/) értéket a megnyitási jelszóra, és adja át ezeket a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) konstruktorának a fájl betöltésekor. A betöltés sikertelen, ha a megnyitási jelszó kötelező, de a megadott jelszó hiányzik vagy helytelen.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Dolgozzon a visszafejtett prezentációval.
```

## **Titkosítás eltávolítása a bemutatóból**

Töltse be a bemutatót a megnyitási jelszavával, hívja meg az [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprotectionmanager/removeencryption/) metódust, majd mentse el az eredményt. A mentett bemutató később jelszó nélkül betölthető.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Megnyitási jelszó ellenőrzése betöltés előtt**

Használja az [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) metódust az [IPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/) lekéréséhez anélkül, hogy teljes bemutató‑példányt hozna létre. Ellenőrizze az [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) tulajdonságot, mielőtt jelszót kérne vagy érvényesítene. Ha védelem van jelen, ellenőrizze a megadott értéket az [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/checkpassword/) metódussal.

### **Fájl‑útvonal munkafolyamat**

Az alábbi példa egy PPTX fájl megnyitási jelszavát ellenőrzi, az ellenőrzött értéket átadja a [LoadOptions::set_Password](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_password/) metódusnak, majd betölti a teljes bemutatót:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Adatfolyam munkafolyamat**

Az [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) adatfolyam‑túlterhelése azonos munkafolyamatot biztosít. Állítsa vissza a kereshető adatfolyam pozícióját, mielőtt a teljes bemutatót ebből az adatfolyamból töltené be.

Az alábbi példa egy PPT fájlt használ:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **CheckPassword visszatérési értékek**

Az [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/checkpassword/) `true`‑t ad vissza csak akkor, ha a bemutató megnyitási jelszóval rendelkezik, és a megadott jelszó helyes. `false` értéket ad minden alábbi esetben:

- A jelszó helytelen.
- A bemutató nem rendelkezik megnyitási jelszóval.
- A megadott jelszó null vagy üres.

A viselkedés PPT és PPTX bemutatók esetén egyforma.

## **Ellenőrizze, hogy egy betöltött bemutató titkosított‑e**

A bemutató helyes jelszóval történő betöltése után ellenőrizze az [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) tulajdonságot, hogy megerősítse a forrásbemutató titkosítását. A megnyitási jelszóval védett állapot betöltés előtti észleléséhez használja a `IPresentationInfo::get_IsPasswordProtected` tulajdonságot, ahogy azt fent bemutattuk.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **Biztonsági ajánlások**

{{% alert color="warning" title="Biztonság" %}}
Ne naplózza a megnyitási jelszavakat, és ne helyezze őket diagnosztikai üzenetekbe. Kerülje a szükségtelen ismételt ellenőrzési kísérleteket, tartsák a jelszavakat memóriában csak annyi ideig, amennyi szükséges, és használja újra a sikeres ellenőrzés eredményét, amikor azonnal betölti a bemutatót.
{{% /alert %}}

## **Bemutató jelszóval való védelem online**

1. Nyissa meg az Aspose.Slides Lock alkalmazást.
1. Válassza ki vagy töltse fel a bemutatót.
1. Adjon meg egy jelszót a megtekintési védelemhez.
1. Opcionálisan adjon meg egy külön jelszót a szerkesztési védelemhez.
1. Alkalmazza a védelmet, és töltse le a kapott fájlt.

{{% alert color="info" title="Lásd még" %}}
- [Write-Protect Presentations](/slides/hu/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/hu/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a megnyitási jelszó és az írásvédelmi jelszó között?**

A megnyitási jelszó titkosítja a bemutatót, és szükséges a tartalom betöltéséhez. Az írásvédelmi jelszó a módosítást korlátozza titkosítás nélkül.

**Ellenőrizhetem a megnyitási jelszót anélkül, hogy az összes diát betölteném?**

Igen. Szerezze be a bemutató információit, ellenőrizze, hogy van‑e megnyitási jelszó‑védelem, és validálja a jelszót a teljes bemutató példány létrehozása előtt.

**Támogatják a jelszó‑ellenőrzési munkafolyamatok a PPT és PPTX formátumokat is?**

Igen. A fájl‑útvonalra és adatfolyamra épülő jelszó‑észlelés és -validálás ugyanúgy működik PPT és PPTX bemutatók esetén.