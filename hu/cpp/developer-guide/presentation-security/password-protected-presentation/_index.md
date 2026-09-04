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
- bemutató jelszó ellenőrzése
- bemutató jelszó ellenőrzése
- titkosított bemutató megnyitása
- titkosítás eltávolítása
- PowerPoint
- PPT
- PPTX
- bemutató
- C++
- Aspose.Slides
description: "Titkosítsa, detektálja, ellenőrizze, nyissa meg, és fejtsen vissza jelszóval védett PowerPoint PPT és PPTX bemutatókat C++-ban az Aspose.Slides segítségével."
---
## **Áttekintés**

A megnyitási jelszó titkosítja a bemutatót. A helyes jelszó szükséges a bemutató tartalmának betöltéséhez és megtekintéséhez, így ez a védelem adatvédelmet biztosít.

A megnyitási jelszó eltér a írásvédelmi jelszótól. Az írásvédelem korlátozza a módosítást, de nem titkosítja a tartalmat, és nem akadályozza meg a bemutató betöltését. A bemutatók módosításához használt jelszavak kezelésével kapcsolatban lásd a [Write-Protect Presentations](/slides/hu/cpp/write-protected-presentation/) oldalt.

Az alábbi munkafolyamatok PPT és PPTX bemutatókra egyaránt vonatkoznak. A példák mindkét formátumot használják, ahol a fájl‑alapú és az adatfolyam‑alapú viselkedés fontos.

## **A bemutató titkosítása megnyitási jelszóval**

Használd az [IProtectionManager::Encrypt](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprotectionmanager/encrypt/) metódust a megnyitási jelszó megadásához. Ezután használd az [IPresentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/save/) metódust a titkosított bemutató mentéséhez.

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

## **A dokumentum tulajdonságok nyilvánosak maradnak**

Alapértelmezés szerint az Aspose.Slides a dokumentumtulajdonságokat is belefoglalja a bemutató titkosításába. Az [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) metódus e viselkedést a diatartalom titkosításától függetlenül szabályozza. Add meg a `false` értéket ennek a metódusnak, mielőtt meghívnád az [IProtectionManager::Encrypt](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprotectionmanager/encrypt/) metódust, ha egy indexelő, osztályozó, kereső vagy dokumentumkezelő rendszernek a jelszó nélkül kell elérnie a metaadatokat.

Az alábbi példa egy titkosított PPTX bemutatót hoz létre, miközben a beépített dokumentumtulajdonságokat nyilvánosan hagyja:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

A `set_EncryptDocumentProperties` metódusnak a `false` érték átadása nem teszi nyilvánossá a diák, vázlatok, elrendezések, alakzatok, média vagy egyéb bemutatótartalmakat. Csak a dokumentumtulajdonságokra van hatással. Ezeknek a tulajdonságoknak a titkosított tartalom betöltése nélküli olvasásához lásd a [Manage Presentation Properties](/slides/hu/cpp/presentation-properties/) oldalt.

## **Titkosított bemutató betöltése**

Állítsd be a [LoadOptions::set_Password](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_password/) értékét a megnyitási jelszóra, és add át ezeket a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztálynak a fájl betöltésekor. A betöltés sikertelen, ha a megnyitási jelszó szükséges, de a megadott jelszó hiányzik vagy hibás.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Dolgozz a visszafejtett bemutatóval.
```

## **Titkosítás eltávolítása egy bemutatóból**

Töltsd be a bemutatót a megnyitási jelszavával, hívd meg az [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprotectionmanager/removeencryption/) metódust, és mentsd el az eredményt. A mentett bemutató ezután jelszó nélkül is betölthető.

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

Használd az [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) metódust, hogy a [IPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/) objektust megszerezd anélkül, hogy teljes bemutató példányt hoznál létre. Ellenőrizd az [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) metódust, mielőtt jelszót kérnél vagy validálnál. Ha védelem van jelen, validáld a megadott értéket az [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/checkpassword/) metódussal.

### **Fájlútvonal munkafolyamat**

Az alábbi példa egy PPTX fájl megnyitási jelszavát validálja, átadja a validált értéket a [LoadOptions::set_Password](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_password/) metódusnak, majd betölti a teljes bemutatót:

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

Az [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) adatfolyam‑túlterhelése ugyanazt a munkafolyamatot biztosítja. Állítsd vissza egy kereshető adatfolyam pozícióját, mielőtt betöltenéd a teljes bemutatót az adatfolyamból.

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

Az [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/checkpassword/) csak akkor ad vissza `true` értéket, ha a bemutató megnyitási jelszóval rendelkezik, és a megadott jelszó helyes. `false` értéket ad minden alábbi esetben:
- A jelszó helytelen.
- A bemutató nem rendelkezik megnyitási jelszóval.
- A megadott jelszó null vagy üres.

A viselkedés PPT és PPTX bemutatókra egyaránt ugyanaz.

## **Ellenőrizze, hogy egy betöltött bemutató titkosított-e**

A bemutató helyes jelszóval történő betöltése után ellenőrizd az [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) értékét, hogy megerősítsd, a forrásbemutató titkosított volt-e. A megnyitási jelszavas védelem betöltés előtti észleléséhez használd a `IPresentationInfo::get_IsPasswordProtected` metódust, ahogyan fent látható.

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

{{% alert color="warning" title="Security" %}}
Ne naplózd a megnyitási jelszavakat, és ne szerepeltessed őket diagnosztikai üzenetekben. Kerüld a szükségtelen ismételt validálási kísérleteket, tartsd a jelszavakat a memóriában csak a szükséges ideig, és használd újra a sikeres validálási eredményt, amikor azonnal betöltöd a bemutatót.

A nyilvános dokumentumtulajdonságok felfedhetnek szerzői neveket, címeket, tárgyakat, kulcsszavakat, cégadatokat, megjegyzéseket és egyedi értékeket, még akkor is, ha a bemutató tartalma titkosított. Titkosítsd az érzékeny metaadatokat együtt a bemutatóval. A tulajdonságok nyilvánosan hagyása csak akkor legyen szándékos döntés, ha a rendszereknek a fájlt megnyitási jelszó nélkül kell indexelni, osztályozni, keresni vagy kezelni.
{{% /alert %}}

## **Bemutató jelszóval védése online**

1. Nyisd meg az [Aspose.Slides Lock](https://products.aspose.app/slides/hu/lock) alkalmazást.
2. Válaszd ki vagy töltsd fel a bemutatót.
3. Adj meg egy jelszót a megtekintési védelemhez.
4. Opcionálisan adj meg egy külön jelszót a szerkesztési védelemhez.
5. Alkalmazd a védelmet, és töltsd le a kapott fájlt.

{{% alert color="info" title="See also" %}}
- [Írásvédett bemutatók](/slides/hu/cpp/write-protected-presentation/)
- [Digitális aláírás PowerPointban](/slides/hu/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a megnyitási jelszó és az írásvédelmi jelszó között?**

A megnyitási jelszó titkosítja a bemutatót, és szükséges a tartalom betöltéséhez. Az írásvédelmi jelszó korlátozza a módosítást anélkül, hogy titkosítaná a tartalmat.

**Validálhatok megnyitási jelszót anélkül, hogy az összes diát betölteném?**

Igen. Szerezd meg a bemutató információit, ellenőrizd, hogy megnyitási jelszavas védelem van-e, és validáld a jelszót, mielőtt teljes bemutató példányt hoznál létre.

**Olvashat egy alkalmazás metaadatokat a megnyitási jelszó nélkül?**

Igen, de csak akkor, ha a bemutató a `set_EncryptDocumentProperties(false)` beállítással lett titkosítva. Ebben az esetben az alkalmazásnak a [Manage Presentation Properties](/slides/hu/cpp/presentation-properties/) leírásában található, csak a dokumentumtulajdonságok betöltését biztosító módot kell használnia.

**A jelszó-ellenőrző munkafolyamatok támogatják mind a PPT, mind a PPTX formátumot?**

Igen. A fájlútvonal és az adatfolyam alapú jelszódetektálás és validálás ugyanúgy működik PPT és PPTX bemutatók esetén.