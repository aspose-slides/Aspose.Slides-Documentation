---
title: Jelszóval védett bemutatók C++-ban
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/cpp/password-protected-presentation/
keywords:
- PowerPoint zárolása
- bemutató zárolása
- PowerPoint feloldása
- bemutató feloldása
- PowerPoint védelme
- bemutató védelme
- jelszó beállítása
- jelszó hozzáadása
- PowerPoint titkosítása
- bemutató titkosítása
- PowerPoint visszafejtése
- bemutató visszafejtése
- írásvédelem
- PowerPoint biztonság
- bemutató biztonsága
- jelszó eltávolítása
- védelem eltávolítása
- titkosítás eltávolítása
- jelszó letiltása
- védelem letiltása
- írásvédelem eltávolítása
- PowerPoint
- OpenDocument
- bemutató
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan zárhatja és nyithatja fel könnyedén a jelszóval védett PowerPoint és OpenDocument bemutatókat az Aspose.Slides C++-hoz. Biztonságosítsa bemutatóit."
---
## **Bevezetés**

Amikor jelszóval védesz egy bemutatót, egy olyan jelszót állítasz be, amely bizonyos korlátozásokat érvényesít a bemutatón. A korlátozások eltávolításához a jelszót meg kell adni. A jelszóval védett bemutató zárolt bemutatónak minősül.

Általában beállíthatsz egy jelszót, hogy ezeket a korlátozásokat a bemutatón érvényesítsd:

- **Módosítás**

  Ha csak bizonyos felhasználók módosíthassák a bemutatót, beállíthat egy módosítási korlátozást. Ez a korlátozás megakadályozza, hogy a felhasználók módosítsák, változtassák vagy másolják a bemutató tartalmát (kivéve, ha megadják a jelszót).

  Azonban ebben az esetben a jelszó nélkül is a felhasználó hozzáférhet a dokumentumhoz és megnyithatja azt. Ebben a csak olvasás mód lehetővé teszi a felhasználó számára a tartalom, például a hiperhivatkozások, animációk, effektusok és egyéb elemek megtekintését, de nem másolhat vagy menthet a bemutatót.

- **Megnyitás**

  Ha csak bizonyos felhasználók nyithassák meg a bemutatót, beállíthat egy megnyitási korlátozást. Ez a korlátozás megakadályozza, hogy a felhasználók még csak a bemutató tartalmát is megtekinthessék (kivéve, ha megadják a jelszót).

  Technikailag a megnyitási korlátozás megakadályozza a felhasználókat a bemutató módosításában is: ha a felhasználó nem tudja megnyitni a bemutatót, nem tud módosítani vagy változtatni rajta.  

  **Megjegyzés**: ha jelszóval véd fel egy bemutatót a megnyitás megakadályozására, a bemutató fájl titkosítva lesz.

## **Hogyan védhet jelszóvel egy bemutatót online**

1. Nyissa meg a [**Aspose.Slides Lock**](https://products.aspose.app/slides/hu/lock) oldalt. 

   ![todo:image_alt_text](slides-lock.png)

2. Kattintson a **Húzza vagy töltse fel fájljait** gombra.

3. Válassza ki a számítógépén azt a fájlt, amelyet jelszóval szeretne védeni.

4. Adja meg a kívánt jelszót a szerkesztési védelemhez; adja meg a kívánt jelszót a megtekintési védelemhez.

5. Ha azt szeretné, hogy a felhasználók a végleges másolatként lássák a bemutatót, jelölje be a **Mark as final** jelölőnégyzetet.

6. Kattintson a **PROTECT NOW.** gombra.

7. Kattintson a **DOWNLOAD NOW.** gombra.

## **Jelszóvédelem bemutatókhoz az Aspose.Slides-ban**
**Támogatott formátumok**

Aspose.Slides támogatja a jelszóvédelmet, a titkosítást és a hasonló műveleteket a következő formátumú bemutatók esetén:

- PPTX és PPT – Microsoft PowerPoint Presentation 
- ODP – OpenDocument Presentation 
- OTP – OpenDocument Presentation Template 

**Támogatott műveletek**

Aspose.Slides lehetővé teszi a jelszóvédelem használatát a bemutatók módosításának megakadályozására a következő módon:

- Bemutató titkosítása
- Írásvédettség beállítása egy bemutatóhoz

**Egyéb műveletek**

Aspose.Slides lehetővé teszi az egyéb jelszóvédelmi és titkosítási feladatok elvégzését a következő módon:

- Bemutató feloldása; titkosított bemutató megnyitása
- Titkosítás eltávolítása; jelszóvédelem letiltása
- Írásvédettség eltávolítása egy bemutatóból
- Titkosított bemutató tulajdonságainak lekérése
- Annak ellenőrzése, hogy a bemutató titkosított-e
- Annak ellenőrzése, hogy a bemutató jelszóval védett-e.

## **Bemutató titkosítása**

Titkosíthat egy bemutatót jelszó beállításával. Ezután a zárolt bemutató módosításához a felhasználónak meg kell adnia a jelszót.

A bemutató titkosításához vagy jelszóval való védelméhez a **encrypt** metódust (a [ProtectionManager](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager)‑ból) kell használni, amely a bemutatóhoz jelszót állít be. A jelszót átadja az **encrypt** metódusnak, majd a **save** metódussal menti a most már titkosított bemutatót.

Ez a példakód bemutatja, hogyan titkosíthat egy bemutatót:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Írásvédettség beállítása egy bemutatóhoz** 

Hozzáadhat egy „Ne módosítsa” jelzést a bemutatóhoz. Ezzel jelezheti a felhasználóknak, hogy nem szeretné, ha módosítanák a bemutatót.  

**Megjegyzés**: az írásvédettség folyamat nem titkosítja a bemutatót. Ezért a felhasználók – ha akarják – módosíthatják a bemutatót, de a változtatások mentéséhez másik néven kell menteniük.

Az írásvédettség beállításához a **setWriteProtection** metódust kell használni. Ez a példakód bemutatja, hogyan állíthat be írásvédettséget egy bemutatóhoz:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Titkosított bemutató betöltése**

Az Aspose.Slides lehetővé teszi titkosított fájl betöltését a jelszó megadásával. A bemutató feloldásához a [RemoveEncryption](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) metódust paraméterek nélkül kell meghívni. Ezután a bemutató betöltéséhez meg kell adnia a helyes jelszót. 

Ez a példakód bemutatja, hogyan oldhatja fel a titkosítást egy bemutatón: 

``` cpp
#include <DOM/LoadOptions.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// munka a feloldott bemutatóval
```

## **Titkosítás eltávolítása egy bemutatóból**

Eltávolíthatja a bemutató titkosítását vagy jelszóvédelmét. Így a felhasználók korlátozás nélkül férhetnek hozzá a bemutatóhoz vagy módosíthatják azt.

A titkosítás vagy jelszóvédelem eltávolításához a [RemoveEncryption](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) metódust kell meghívni. Ez a példakód bemutatja, hogyan távolíthatja el a titkosítást egy bemutatóból:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Írásvédettség eltávolítása egy bemutatóból**

Az Aspose.Slides segítségével eltávolíthatja a bemutató fájlra alkalmazott írásvédettséget. Így a felhasználók kedveltük módon módosíthatják a prezentációt, és nem kapnak figyelmeztetést a feladatok végrehajtása során.

Az írásvédettség eltávolítható a [RemoveWriteProtection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) metódus használatával. Ez a példakód bemutatja, hogyan távolítható el az írásvédettség egy bemutatóból:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Titkosított bemutató tulajdonságainak lekérése**

Általában a felhasználók nehezen jutnak hozzá a titkosított vagy jelszóval védett bemutató dokumentum tulajdonságaihoz. Az Aspose.Slides azonban olyan mechanizmust biztosít, amely lehetővé teszi a bemutató jelszóval való védelmét, miközben a dokumentum tulajdonságai elérhetők maradnak.

**Megjegyzés**: alapértelmezés szerint az Aspose.Slides titkosítja a bemutató dokumentum tulajdonságait is. Ha a titkosítás után is elérhetővé szeretné tenni a dokumentum tulajdonságokat, az Aspose.Slides ezt lehetővé teszi.

Ha azt szeretné, hogy a felhasználók a titkosított bemutató tulajdonságait továbbra is elérhessék, adja át a `false` értéket a `set_EncryptDocumentProperties` metódusnak az [IProtectionManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprotectionmanager/)‑ban. Ez a példakód bemutatja, hogyan titkosíthat egy bemutatót, miközben a felhasználók továbbra is hozzáférhetnek a dokumentum tulajdonságaihoz:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Csak a dokumentum tulajdonságainak betöltése titkosított bemutatóból**

A titkosított bemutató metaadatainak vizsgálatához a diák vagy egyéb tartalom betöltése nélkül hozza létre a [LoadOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/) objektumot, és állítsa a [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) értékét `true`‑ra. Ebben a módban az Aspose.Slides figyelmen kívül hagyja a jelszót, és csak a nyilvánosan elérhető dokumentum tulajdonságokat tölti be.

Az alábbi kódrészlet a beépített és egyéni dokumentum tulajdonságok beolvasását mutatja a [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_documentproperties/) használatával:

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

Ez a munkafolyamat csak akkor működik, ha a dokumentum tulajdonságok titkosítás nélkül (nyilvános) maradtak a bemutató titkosítása során. Ha a dokumentum tulajdonságok titkosítottak, a `LoadOptions::set_OnlyLoadDocumentProperties` érték `true`‑ra állítása kivételt eredményez, mivel ebben a módban a jelszó figyelmen kívül marad. Titkosított dokumentum tulajdonságok eléréséhez vagy a teljes bemutató (diák és egyéb tartalom) betöltéséhez adja meg a helyes jelszót a `LoadOptions::set_Password` paraméterrel a [LoadOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/)-ban.

## **Ellenőrizze, hogy a bemutató jelszóval van-e védve**

Mielőtt betöltene egy bemutatót, előfordulhat, hogy ellenőrizni és megerősíteni szeretné, hogy a bemutató nincs jelszóval védve. Így elkerülheti a hibákat és hasonló problémákat, amelyek akkor merülnek fel, ha jelszóval védett bemutatót jelszó nélkül próbál megnyitni.

Ez a C++ kód bemutatja, hogyan vizsgálhat meg egy bemutatót annak megállapítására, hogy jelszóval védett-e (anélkül, hogy maga a bemutató betöltődne):

```c++
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Ellenőrizze, hogy a bemutató titkosított‑e**

Az Aspose.Slides lehetővé teszi annak ellenőrzését, hogy egy bemutató titkosított‑e. A feladat elvégzéséhez használhatja a [get_IsEncrypted()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) metódust, amely `true`‑t ad vissza, ha a bemutató titkosított, vagy `false`‑t, ha nem titkosított.

Ez a példakód bemutatja, hogyan ellenőrizheti, hogy a bemutató titkosított‑e:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Ellenőrizze, hogy a bemutató írásvédett‑e**

Az Aspose.Slides lehetővé teszi annak ellenőrzését, hogy egy bemutató írásvédett‑e. A feladat elvégzéséhez használhatja a [get_IsWriteProtected()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) metódust, amely `true`‑t ad vissza, ha a bemutató írásvédett, vagy `false`‑t, ha nem írásvédett.

Ez a példakód bemutatja, hogyan ellenőrizheti, hogy egy bemutató írásvédett‑e:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Ellenőrizze a bemutató jelszó használatát**

Lehet, hogy ellenőrizni és megerősíteni szeretné, hogy egy adott jelszót használtak-e a bemutató dokumentum védelmére. Az Aspose.Slides biztosítja az eszközt a jelszó validálásához.

Ez a példakód bemutatja, hogyan validálhat egy jelszót:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// ellenőrizze, hogy a "pass" megfelel-e
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

`true`‑t ad vissza, ha a bemutató a megadott jelszóval lett titkosítva. Egyébként `false`‑t ad vissza. 

{{% alert color="info" title="Lásd még" %}} 
- [Digitális aláírás PowerPointban](/slides/hu/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Milyen titkosítási módszerek támogatottak az Aspose.Slides-ban?**

Az Aspose.Slides modern titkosítási módszereket támogat, beleértve az AES‑alapú algoritmusokat, ezzel magas szintű adatbiztonságot biztosítva a bemutatók számára.

**Mi történik, ha helytelen jelszót adnak meg a bemutató megnyitásakor?**

Kivétel keletkezik, ha helytelen jelszót használnak, ami jelzi, hogy a bemutatóhoz való hozzáférés megtagadva. Ez segít megakadályozni a jogosulatlan hozzáférést és védi a bemutató tartalmát.

**Vannak-e teljesítménybeli következmények a jelszóval védett bemutatók használatakor?**

A titkosítási és feloldási folyamat némi plusz terhet jelenthet a megnyitási és mentési műveletek során. A legtöbb esetben ez a teljesítményhatás minimális, és nem befolyásolja jelentősen a bemutatók feldolgozási idejét.