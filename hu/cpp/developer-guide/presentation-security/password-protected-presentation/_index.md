---
title: "Prezentációk védelme jelszóval C++-ban"
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
description: "Ismerje meg, hogyan tudja egyszerűen zárolni és feloldani a jelszóval védett PowerPoint és OpenDocument prezentációkat az Aspose.Slides for C++ segítségével. Tegye biztonságossá prezentációit."
---
## **Bevezetés**

Amikor jelszóval véd egy bemutatót, azt jelenti, hogy egy jelszót állít be, amely bizonyos korlátozásokat érvényesít a bemutatóra vonatkozóan. A korlátozások eltávolításához meg kell adni a jelszót. A jelszóval védett bemutatót lezárt bemutatónak tekintik.

Általában jelszóval szabályozhatja a bemutatóhoz kapcsolódó korlátozásokat:

- **Módosítás**

  Ha csak bizonyos felhasználók számára szeretné engedélyezni a bemutató módosítását, beállíthat egy módosítási korlátozást. Ez a korlátozás megakadályozza, hogy az emberek módosítsák, változtassák vagy másolják a bemutató tartalmát (kivéve, ha megadják a jelszót).

  Ennek ellenére, jelszó nélkül a felhasználó hozzáférhet a dokumentumhoz és megnyithatja azt. Olvasási módban a felhasználó megtekintheti a tartalmat – például a hiperhivatkozásokat, animációkat, effektusokat és egyebeket – de nem másolhat elemeket, illetve nem mentheti a bemutatót.

- **Megnyitás**

  Ha csak bizonyos felhasználók számára szeretné engedélyezni a bemutató megnyitását, beállíthat egy megnyitási korlátozást. Ez a korlátozás megakadályozza, hogy bárki megtekintse a bemutató tartalmát (kivéve, ha megadják a jelszót).

  Technikai szempontból a megnyitási korlátozás egyúttal megakadályozza a bemutató módosítását is: ha a felhasználó nem tudja megnyitni a bemutatót, nem tud változtatásokat végezni rajta.

  **Megjegyzés**: ha jelszóval védi a bemutatót a megnyitás megakadályozására, a bemutató fájl titkosítva lesz.

## **Hogyan védhető jelszóval egy bemutató online**

1. Látogassa meg az **[Aspose.Slides Lock](https://products.aspose.app/slides/hu/lock)** oldalt.  

   ![todo:image_alt_text](slides-lock.png)

2. Kattintson a **Drop or upload your files** gombra.

3. Válassza ki a számítógépéről a jelszóval védendő fájlt.

4. Adja meg a kívánt jelszót a szerkesztés védelméhez; adja meg a kívánt jelszót a megtekintés védelméhez.

5. Ha azt szeretné, hogy a felhasználók a bemutatót végleges példánynak tekintsék, jelölje be a **Mark as final** jelölőnégyzetet.

6. Kattintson a **PROTECT NOW.** gombra.

7. Kattintson a **DOWNLOAD NOW.** gombra.

## **Jelszóvédelem a bemutatókhoz az Aspose.Slides-ban**
**Támogatott formátumok**

Az Aspose.Slides jelszóvédelmet, titkosítást és hasonló műveleteket támogat a következő formátumokban:

- PPTX és PPT – Microsoft PowerPoint bemutató
- ODP – OpenDocument bemutató
- OTP – OpenDocument bemutató sablon

**Támogatott műveletek**

Az Aspose.Slides a következő módokon teszi lehetővé a jelszóvédelmet a bemutatókon, hogy megelőzze a módosításokat:

- Bemutató titkosítása
- Írásvédettség beállítása a bemutatóhoz

**Egyéb műveletek**

Az Aspose.Slides a következő módokon segít más, jelszóvédelmet és titkosítást érintő feladatok elvégzésében:

- Bemutató visszafejtése; titkosított bemutató megnyitása
- Titkosítás eltávolítása; jelszóvédelem letiltása
- Írásvédelem eltávolítása a bemutatóból
- Titkosított bemutató tulajdonságainak lekérdezése
- Annak ellenőrzése, hogy a bemutató titkosított-e
- Annak ellenőrzése, hogy a bemutató jelszóval védett-e.

## **Bemutató titkosítása**

A bemutató titkosítható jelszó beállításával. Ezután a lezárt bemutató módosításához a felhasználónak meg kell adnia a jelszót.

A bemutató titkosításához vagy jelszóval való védelméhez a [ProtectionManager](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager) **encrypt** metódusát kell használni, amellyel jelszót állíthat be a bemutatóhoz. A jelszót átadja az **encrypt** metódusnak, majd a **save** metódussal menti a most titkosított bemutatót.

Ez a példakód bemutatja, hogyan titkosíthatja a bemutatót:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Írásvédelem beállítása a bemutatóhoz**

Hozzáadhat egy „Ne módosítsa” feliratot a bemutatóhoz. Így a felhasználók tudni fogják, hogy nem kívánja, hogy módosítsák a bemutatót.

**Megjegyzés**: az írásvédelmi folyamat nem titkosítja a bemutatót. Ezért a felhasználók – ha akarják – módosíthatják a bemutatót, de a változtatások mentéséhez másik néven kell elmenteniük a fájlt.

Az írásvédelem beállításához a **setWriteProtection** metódust kell használni. Ez a példakód bemutatja, hogyan állíthat be írásvédelmet a bemutatóhoz:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Titkosított bemutató betöltése**

Az Aspose.Slides lehetővé teszi egy titkosított fájl betöltését, ha megadja a jelszavát. A bemutató visszafejtéséhez hívja meg a [RemoveEncryption](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) metódust paraméterek nélkül, majd adja meg a helyes jelszót a bemutató betöltéséhez.

Ez a példakód bemutatja, hogyan fejtse vissza a titkosítást:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// dolgozz a visszafejtett prezentációval
```

## **Titkosítás eltávolítása a bemutatóból**

Eltávolíthatja a titkosítást vagy a jelszóvédelmet egy bemutatóról. Így a felhasználók korlátozás nélkül férnek hozzá vagy módosítják a bemutatót.

A titkosítás vagy jelszóvédelem eltávolításához hívja meg a [RemoveEncryption](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) metódust. Ez a példakód mutatja, hogyan távolítható el a titkosítás a bemutatóból:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Írásvédelem eltávolítása a bemutatóból**

Az Aspose.Slides segítségével eltávolíthatja a bemutató fájlon beállított írásvédelmet. Így a felhasználók szabadon módosíthatják, és nem kapnak figyelmeztetést a feladat végrehajtásakor.

Az írásvédelem eltávolításához használja a [RemoveWriteProtection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) metódust. Ez a példakód mutatja, hogyan távolítható el az írásvédelem:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Titkosított bemutató tulajdonságainak lekérdezése**

Általában a felhasználók nehezen jutnak hozzá egy titkosított vagy jelszóval védett bemutató dokumentumtulajdonságaihoz. Az Aspose.Slides azonban olyan mechanizmust kínál, amely lehetővé teszi a bemutató jelszóval való védelmét, miközben a felhasználók hozzáférhetnek a bemutató tulajdonságaihoz.

**Megjegyzés**: amikor az Aspose.Slides titkosít egy bemutatót, a bemutató dokumentumtulajdonságai is alapértelmezés szerint jelszóval védettek lesznek. Ha azonban a bemutató tulajdonságait a titkosítás után is hozzáférhetővé szeretné tenni, az Aspose.Slides lehetővé teszi ezt.

Ha azt szeretné, hogy a felhasználók a titkosított bemutató tulajdonságait is elérjék, adja át a **true** értéket a [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d) metódusnak. Ez a példakód bemutatja, hogyan titkosíthatja a bemutatót, miközben a felhasználók hozzáférhetnek a dokumentumtulajdonságokhoz:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **Annálás, hogy a bemutató jelszóval van-e védve**

Mielőtt betöltene egy bemutatót, ellenőrizheti, hogy a bemutató nincs-e jelszóval védve. Így elkerülheti a hibákat és a hasonló problémákat, amelyek akkor jelentkeznek, amikor jelszóval védett bemutatót jelszó nélkül próbálnak betölteni.

Ez a C++ kód megmutatja, hogyan vizsgálhatja meg egy bemutatót, hogy jelszóval védett‑e (a bemutató tényleges betöltése nélkül):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Annálás, hogy a bemutató titkosított‑e**

Az Aspose.Slides lehetővé teszi annak ellenőrzését, hogy egy bemutató titkosított‑e. Ehhez használja a [get_IsEncrypted()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) metódust, amely **true** értéket ad vissza, ha a bemutató titkosított, különben **false**‑t.

Ez a példakód megmutatja, hogyan ellenőrizheti, hogy egy bemutató titkosított‑e:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Annálás, hogy a bemutató írásvédett‑e**

Az Aspose.Slides lehetővé teszi annak ellenőrzését, hogy egy bemutató írásvédett‑e. Ehhez használja a [get_IsWriteProtected()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) metódust, amely **true** értéket ad vissza, ha a bemutató írásvédett, különben **false**‑t.

Ez a példakód megmutatja, hogyan ellenőrizheti, hogy egy bemutató írásvédett‑e:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Bemutató jelszóhasználatának ellenőrzése**

Lehet, hogy ellenőrizni szeretné, hogy egy adott jelszót használtak‑e a bemutató dokumentumának védelmére. Az Aspose.Slides lehetőséget biztosít a jelszó validálására.

Ez a példakód megmutatja, hogyan validálhat egy jelszót:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// ellenőrizze, hogy a "pass" egyezik-e
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Az eredmény **true**, ha a bemutató a megadott jelszóval lett titkosítva; egyébként **false**.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/hu/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Milyen titkosítási módszereket támogat az Aspose.Slides?**

Az Aspose.Slides modern, AES‑alapú titkosítási algoritmusokat támogat, biztosítva a bemutatók adataiban a magas szintű biztonságot.

**Mi történik, ha helytelen jelszót adnak meg a bemutató megnyitásakor?**

Kivétel keletkezik, ha hibás jelszót használnak, jelezve, hogy a hozzáférés megtagadva. Ez megakadályozza a jogosulatlan hozzáférést és védi a bemutató tartalmát.

**Vannak-e teljesítménybeli hatások a jelszóval védett bemutatókkal való munka során?**

A titkosítási és visszafejtési folyamatok enyhe overhead‑et eredményezhetnek a megnyitás és mentés során. A legtöbb esetben ez a hatás minimális, és nem befolyásolja jelentősen a bemutatók feldolgozási idejét.