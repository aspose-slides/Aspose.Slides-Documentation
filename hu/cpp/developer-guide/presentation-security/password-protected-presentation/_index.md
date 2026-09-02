---
title: "Jelszóval védett prezentációk C++-ban"
linktitle: "Jelszóvédelem"
type: docs
weight: 20
url: /hu/cpp/password-protected-presentation/
keywords:
- "PowerPoint zárolása"
- "prezentáció zárolása"
- "PowerPoint feloldása"
- "prezentáció feloldása"
- "PowerPoint védelme"
- "prezentáció védelme"
- "jelszó beállítása"
- "jelszó hozzáadása"
- "PowerPoint titkosítása"
- "prezentáció titkosítása"
- "PowerPoint visszafejtése"
- "prezentáció visszafejtése"
- "írásvédelem"
- "PowerPoint biztonság"
- "prezentáció biztonság"
- "jelszó eltávolítása"
- "védelem eltávolítása"
- "titkosítás eltávolítása"
- "jelszó letiltása"
- "védelem letiltása"
- "írásvédelem eltávolítása"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "C++"
- "Aspose.Slides"
description: "Ismerje meg, hogyan lehet egyszerűen zárolni és feloldani a jelszóval védett PowerPoint és OpenDocument prezentációkat az Aspose.Slides C++-hoz. Biztosítsa prezentációit."
---
## **Bevezetés**

Amikor egy prezentációt jelszóval védesz, akkor egy jelszót állítasz be, amely bizonyos korlátozásokat érvényesít a prezentáción. A korlátozások eltávolításához a jelszót meg kell adni. A jelszóval védett prezentációt zárt prezentációnak tekintik.

Általában beállíthatsz egy jelszót, hogy érvényesítse ezeket a korlátozásokat egy prezentáción:

- **Módosítás**

  Ha csak bizonyos felhasználóknak szeretnéd engedélyezni a prezentációd módosítását, beállíthatsz egy módosítási korlátozást. Ez a korlátozás megakadályozza, hogy az emberek módosítsák, változtassák vagy másolják a prezentáció tartalmát (kivéve, ha megadják a jelszót).

  Azonban ebben az esetben, jelszó nélkül is a felhasználó hozzáférhet a dokumentumodhoz és megnyithatja azt. Ebben a csak-olvasás módjában a felhasználó megtekintheti a prezentáció tartalmát, például a hiperhivatkozásokat, animációkat, effektusokat és egyebeket, de nem másolhat elemeket, és nem mentheti a prezentációt.

- **Megnyitás**

  Ha csak bizonyos felhasználóknak szeretnéd engedélyezni a prezentációd megnyitását, beállíthatsz egy megnyitási korlátozást. Ez a korlátozás megakadályozza, hogy az emberek még csak a prezentáció tartalmát is megtekintsék (kivéve, ha megadják a jelszót).

  Technikai szempontból a megnyitási korlátozás megakadályozza a felhasználókat a prezentációk módosításában is: ha valaki nem tudja megnyitni a prezentációt, nem tud változtatni rajta.  

  **Megjegyzés** hogy amikor egy prezentációt jelszóval védesz a megnyitás megakadályozására, a prezentáció fájlja titkosítva lesz.

## **Hogyan védjünk jelszóvel egy prezentációt online**

1. Látogasd meg a [**Aspose.Slides Lock**](https://products.aspose.app/slides/hu/lock) oldalunkat. 

   ![todo:image_alt_text](slides-lock.png)

2. Kattints a **Drop or upload your files** gombra.

3. Válaszd ki a számítógépeden azt a fájlt, amelyet jelszóval szeretnél védeni.

4. Add meg a kívánt jelszót a szerkesztés védelméhez; Add meg a kívánt jelszót a megtekintés védelméhez. 

5. Ha azt szeretnéd, hogy a felhasználók a prezentációt végleges példányként lássák, jelöld be a **Mark as final** jelölőnégyzetet.

6. Kattints a **PROTECT NOW.** gombra.

7. Kattints a **DOWNLOAD NOW.** gombra.

## **Jelszóvédelem a prezentációkhoz az Aspose.Slides-ban**
**Támogatott formátumok**

Aspose.Slides támogatja a jelszóvédelmet, a titkosítást és hasonló műveleteket a következő formátumú prezentációk esetén: 

- PPTX és PPT – Microsoft PowerPoint prezentáció 
- ODP – OpenDocument prezentáció 
- OTP – OpenDocument prezentációs sablon 

**Támogatott műveletek**

Aspose.Slides lehetővé teszi a jelszóvédelem használatát a prezentációkon, hogy megakadályozza a módosításokat a következő módon:

- A prezentáció titkosítása
- Írásvédettség beállítása a prezentációhoz

**Egyéb műveletek**

Aspose.Slides lehetővé teszi egyéb feladatok végrehajtását, amelyek jelszóvédelmet és titkosítást érintenek, a következő módon:

- Egy prezentáció visszafejtése; titkosított prezentáció megnyitása
- Titkosítás eltávolítása; jelszóvédelem letiltása
- Írásvédelem eltávolítása egy prezentációból
- Egy titkosított prezentáció tulajdonságainak lekérése
- Annél ellenőrzése, hogy a prezentáció titkosított-e
- Annél ellenőrzése, hogy a prezentáció jelszóval védett-e.

## **Prezentáció titkosítása**

Titkosíthatsz egy prezentációt jelszó beállításával. Ezután a zárt prezentáció módosításához a felhasználónak meg kell adnia a jelszót. 

A prezentáció titkosításához vagy jelszóvédelemhez a encrypt metódust (a [ProtectionManager](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager))‑ből kell használnod, hogy jelszót állíts be a prezentációnak. A jelszót átadod az encrypt metódusnak, majd a save metódussal mented a most titkosított prezentációt. 

Ez a példakód megmutatja, hogyan kell titkosítani egy prezentációt:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Írásvédelem beállítása a prezentációhoz** 

Hozzáadhatsz egy „Ne módosítsa” feliratot a prezentációhoz. Így tájékoztatod a felhasználókat, hogy nem szeretnéd, ha módosítanák a prezentációt.  

**Megjegyzés** hogy az írásvédelmi folyamat nem titkosítja a prezentációt. Ezért a felhasználók – ha akarják – módosíthatják a prezentációt, de a változások mentéséhez másik néven kell menteniük a prezentációt. 

Az írásvédelem beállításához a setWriteProtection metódust kell használnod. Ez a példakód megmutatja, hogyan kell írásvédelmet beállítani egy prezentációhoz:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Titkosított prezentáció betöltése**

Az Aspose.Slides lehetővé teszi egy titkosított fájl betöltését a jelszó megadásával. Egy prezentáció visszafejtéséhez a [RemoveEncryption](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) metódust kell meghívnod paraméterek nélkül. Ezután meg kell adnod a helyes jelszót a prezentáció betöltéséhez. 

Ez a példakód megmutatja, hogyan lehet visszafejteni egy prezentációt: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// munkavégzés a visszafejtett prezentációval
```

## **Titkosítás eltávolítása egy prezentációból**

Eltávolíthatod a prezentáció titkosítását vagy jelszóvédelmét. Így a felhasználók korlátozás nélkül hozzáférhetnek vagy módosíthatják a prezentációt. 

A titkosítás vagy jelszóvédelem eltávolításához a [RemoveEncryption](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) metódust kell meghívnod. Ez a példakód megmutatja, hogyan távolítható el a titkosítás egy prezentációból:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Írásvédelem eltávolítása egy prezentációból**

Az Aspose.Slides segítségével eltávolíthatod a prezentáció fájlon alkalmazott írásvédelmet. Így a felhasználók tetszés szerint módosíthatnak, és nem kapnak figyelmeztetést a feladatok végrehajtásakor.

A [RemoveWriteProtection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) metódus használatával eltávolíthatod az írásvédelmet egy prezentációról. Ez a példakód megmutatja, hogyan távolítható el az írásvédelem egy prezentációból:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Titkosított prezentáció tulajdonságainak lekérése**

Általában a felhasználók nehezen jutnak hozzá egy titkosított vagy jelszóval védett prezentáció dokumentumtulajdonságaihoz. Az Aspose.Slides azonban olyan mechanizmust biztosít, amely lehetővé teszi a prezentáció jelszóval való védelmét, miközben a dokumentumtulajdonságokhoz is hozzáférést enged.

**Megjegyzés:** Alapértelmezés szerint, amikor az Aspose.Slides titkosít egy prezentációt, a prezentáció dokumentumtulajdonságai is jelszóval védettek. Ha a dokumentumtulajdonságokat a titkosítás után is elérhetővé szeretnéd tenni, az Aspose.Slides lehetővé teszi ezt.

Ha azt szeretnéd, hogy a felhasználók továbbra is hozzáférjenek egy titkosított prezentáció tulajdonságaihoz, add át a `false` értéket a `set_EncryptDocumentProperties` metódusnak az [IProtectionManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprotectionmanager/)-ben. Ez a példakód megmutatja, hogyan titkosíthatsz egy prezentációt, miközben a felhasználók továbbra is hozzáférnek a dokumentumtulajdonságokhoz:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Csak a dokumentumtulajdonságok betöltése egy titkosított prezentációból**

A titkosított prezentáció metaadatainak, a diák vagy egyéb tartalom betöltése nélkül történő ellenőrzéséhez hozz létre egy [LoadOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/) objektumot, és állítsd a [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) értékét `true`‑ra. Ebben a módban az Aspose.Slides figyelmen kívül hagyja a jelszót, és csak a nyilvánosan elérhető dokumentumtulajdonságokat tölti be.

A következő kódrészlet beolvassa a beépített és egyedi dokumentumtulajdonságokat a [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_documentproperties/) segítségével:

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

Ez a munkafolyamat csak akkor működik, ha a dokumentumtulajdonságok a prezentáció titkosításakor titkosítatlanul (nyilvánosan) maradtak. Ha a dokumentumtulajdonságok titkosítottak, a `LoadOptions::set_OnlyLoadDocumentProperties` `true`‑ra állítása kivételt eredményez, mert ebben a módban a jelszó figyelmen kívül marad. A titkosított dokumentumtulajdonságok eléréséhez vagy a teljes prezentáció, beleértve a diákat és egyéb tartalmat, betöltéséhez add meg a helyes jelszót a `LoadOptions::set_Password` használatával a [LoadOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/)-ben.

## **Ellenőrzés, hogy a prezentáció jelszóval védett-e**

Mielőtt betöltenéd a prezentációt, érdemes ellenőrizned, hogy a prezentáció nincs‑e jelszóval védve. Így elkerülheted a hibákat és hasonló problémákat, amelyek akkor jelentkeznek, amikor egy jelszóval védett prezentációt a jelszó megadása nélkül próbálják betölteni.

Ez a C++ kód megmutatja, hogyan vizsgálhatod meg egy prezentációt, hogy jelszóval van‑e védve (a prezentáció tényleges betöltése nélkül):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Ellenőrzés, hogy a prezentáció titkosított-e**

Az Aspose.Slides lehetővé teszi, hogy ellenőrizd, titkosított‑e egy prezentáció. Ehhez használhatod a [get_IsEncrypted()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) metódust, amely `true`‑t ad vissza, ha a prezentáció titkosított, vagy `false`‑t, ha nem titkosított.

Ez a példakód megmutatja, hogyan ellenőrizheted, hogy egy prezentáció titkosított‑e:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Ellenőrzés, hogy a prezentáció írásvédett-e**

Az Aspose.Slides lehetővé teszi, hogy ellenőrizd, írásvédett‑e egy prezentáció. Ehhez használhatod a [get_IsWriteProtected()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) metódust, amely `true`‑t ad vissza, ha a prezentáció írásvédett, vagy `false`‑t, ha nincs írásvédve.

Ez a példakód megmutatja, hogyan ellenőrizheted, hogy egy prezentáció írásvédett‑e:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **A prezentáció jelszóhasználatának ellenőrzése**

Lehet, hogy ellenőrizni és megerősíteni szeretnéd, hogy egy adott jelszót használtak‑e egy prezentáció dokumentumának védelmére. Az Aspose.Slides biztosítja a lehetőséget a jelszó érvényesítésére. 

Ez a példakód megmutatja, hogyan kell érvényesíteni egy jelszót:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// ellenőrizze, hogy a "pass" megegyezik-e
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

`true`‑t ad vissza, ha a prezentációt a megadott jelszóval titkosították. Ellenkező esetben `false`‑t ad vissza. 

{{% alert color="primary" title="Lásd még" %}} 
- [Digitális aláírás PowerPointban](/slides/hu/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Milyen titkosítási módszereket támogat az Aspose.Slides?**

Az Aspose.Slides modern titkosítási módszereket támogat, beleértve az AES‑alapú algoritmusokat, amelyek magas szintű adatbiztonságot biztosítanak a prezentációid számára.

**Mi történik, ha helytelen jelszót adnak meg a prezentáció megnyitásakor?**

Hibát dob, ha helytelen jelszót használnak, jelezve, hogy a prezentációhoz nem biztosított a hozzáférés. Ez segít megakadályozni az illetéktelen hozzáférést és védi a prezentáció tartalmát.

**Vannak-e teljesítménybeli hatások jelszóval védett prezentációk kezelésekor?**

A titkosítási és visszafejtési folyamat enyhe késleltetést okozhat a megnyitás és mentés műveletei során. A legtöbb esetben ez a teljesítménybeli hatás minimális, és nem befolyásolja jelentősen a prezentációs feladatok teljes feldolgozási idejét.