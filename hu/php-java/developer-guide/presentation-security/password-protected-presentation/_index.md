---
title: Jelszóval védett bemutatók PHP-ben
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/php-java/password-protected-presentation/
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
- bemutató biztonság
- jelszó eltávolítása
- védelem eltávolítása
- titkosítás eltávolítása
- jelszó letiltása
- védelem letiltása
- írásvédelem eltávolítása
- PowerPoint
- OpenDocument
- bemutató
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan lehet egyszerűen zárolni és feloldani jelszóval védett PowerPoint és OpenDocument bemutatókat az Aspose.Slides PHP-hez. Biztonságosan védje bemutatóit."
---
## **Bevezetés**

Amikor jelszóval véd egy bemutatót, akkor egy olyan jelszót állít be, amely meghatározott korlátozásokat érvényesít a bemutatón. A korlátozások eltávolításához meg kell adni a jelszót. A jelszóval védett bemutatót zárt bemutatónak tekintik.

Általában beállíthat egy jelszót, hogy ezeket a korlátozásokat érvényesítse egy bemutatón:

- **Módosítás**

  Ha csak bizonyos felhasználókat szeretne engedélyezni a bemutató módosítására, beállíthat egy módosítási korlátozást. Ez a korlátozás megakadályozza, hogy az emberek módosítsák, megváltoztassák vagy átmásolják a bemutató tartalmát (kivéve, ha megadják a jelszót).  

  Azonban ebben az esetben, a jelszó nélkül is a felhasználó hozzáférhet a dokumentumhoz és megnyithatja azt. Olvasás‑csak módban a felhasználó megtekintheti a tartalmat vagy elemeket – hiperhivatkozásokat, animációkat, effektusokat és egyebeket – a bemutatóban, de nem másolhat elemeket, és nem mentheti a bemutatót.  

- **Megnyitás**

  Ha csak bizonyos felhasználókat szeretne engedélyezni a bemutató megnyitására, beállíthat egy megnyitási korlátozást. Ez a korlátozás megakadályozza, hogy az emberek még csak a bemutató tartalmát is megtekintsék (kivéve, ha megadják a jelszót).

  Technikailag a megnyitási korlátozás megakadályozza a felhasználók bemutató módosítását is: Ha valaki nem nyithatja meg a bemutatót, akkor nem is módosíthatja azt.  

  **Megjegyzés** hogy amikor egy bemutatót jelszóval véd, hogy megakadályozza a megnyitást, a bemutató fájl titkosítottá válik.

## **Hogyan védjünk jelszóvel egy bemutatót online**

1. Látogasson el a [**Aspose.Slides Zárolás**](https://products.aspose.app/slides/hu/lock) oldalra.  

   ![todo:image_alt_text](slides-lock.png)

2. Kattintson a **Fájlok áthúzása vagy feltöltése** gombra.

3. Válassza ki a számítógépén a jelszóval védeni kívánt fájlt.

4. Adja meg a kívánt jelszót a szerkesztési védelemhez; Adja meg a kívánt jelszót a megtekintési védelemhez.

5. Ha azt szeretné, hogy a felhasználók a bemutatót a végleges változatként lássák, jelölje be a **Megjelölés véglegesnek** jelölőnégyzetet.

6. Kattintson a **VÉDELEM MOST** gombra.

7. Kattintson a **LETÖLTÉS MOST** gombra.

## **Jelszóvédelem a bemutatókhoz az Aspose.Slides‑ben**
**Támogatott formátumok**

Az Aspose.Slides jelszóvédelmet, titkosítást és hasonló műveleteket támogat a következő formátumokban:

- PPTX és PPT – Microsoft PowerPoint bemutató
- ODP – OpenDocument bemutató
- OTP – OpenDocument bemutató sablon

**Támogatott műveletek**

Az Aspose.Slides lehetővé teszi, hogy jelszóvédelmet alkalmazzon a bemutatókra a módosítások megakadályozására az alábbi módon:

- Bemutató titkosítása
- Írásvédettség beállítása a bemutatóhoz

**Egyéb műveletek**

Az Aspose.Slides lehetővé teszi, hogy egyéb feladatokat végezzen a jelszóvédelem és titkosítás körülményeiben:

- Bemutató visszafejtése; titkosított bemutató megnyitása
- Titkosítás eltávolítása; jelszóvédelem letiltása
- Írásvédelem eltávolítása a bemutatóból
- Titkosított bemutató tulajdonságainak lekérése
- Annál ellenőrzése, hogy a bemutató titkosított-e
- Annál ellenőrzése, hogy a bemutató jelszóval védett-e.

## **Bemutató titkosítása**

A bemutatót jelszó beállításával titkosíthatja. A zárt bemutató módosításához a felhasználónak meg kell adnia a jelszót.

A bemutató titkosításához vagy jelszóval való védelméhez a encrypt metódust kell használnia (a [ProtectionManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/)ból), hogy jelszót állítson be a bemutatón. A jelszót átadja a encrypt metódusnak, majd a save metódussal menti a most titkosított bemutatót.

Ez a példa kód megmutatja, hogyan titkosíthatja a bemutatót:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Írásvédelem beállítása a bemutatóhoz**

A bemutatóhoz hozzáadhat egy „Ne módosítsa” feliratot. Így a felhasználók tudni fogják, hogy nem szeretné, ha módosítanák a bemutatót.  

**Megjegyzés** hogy az írásvédettség folyamata nem titkosítja a bemutatót. Ezért a felhasználók – ha tényleg akarják – módosíthatják a bemutatót, de a változtatások mentéséhez más néven kell elmenteniük a bemutatót.

Az írásvédettség beállításához a [setWriteProtection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#setWriteProtection) metódust kell használnia. Ez a példa kód megmutatja, hogyan állíthat be írásvédettséget a bemutatóhoz:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Titkosított bemutató betöltése**

Az Aspose.Slides lehetővé teszi, hogy egy titkosított fájlt a jelszó megadásával töltse be. A bemutató visszafejtéséhez a [removeEncryption](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#removeEncryption) metódust kell meghívnia paraméterek nélkül. Ezután meg kell adnia a helyes jelszót a bemutató betöltéséhez.

Ez a példa kód megmutatja, hogyan fejtheti vissza a bemutatót:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # munka a visszafejtett bemutatóval
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Titkosítás eltávolítása a bemutatóból**

Eltávolíthatja a bemutató titkosítását vagy jelszóvédelmét. Így a felhasználók korlátozások nélkül férhetnek hozzá vagy módosíthatják a bemutatót.

A titkosítás vagy jelszóvédelem eltávolításához a [removeEncryption](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#removeEncryption) metódust kell meghívnia. Ez a példa kód megmutatja, hogyan távolíthatja el a titkosítást a bemutatóból:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Írásvédelem eltávolítása a bemutatóból**

Az Aspose.Slides segítségével eltávolíthatja a bemutatófájlra alkalmazott írásvédettséget. Így a felhasználók szabadon módosíthatnak – és nem kapnak figyelmeztetést ilyen műveletek során.

A bemutató írásvédettségét a [removeWriteProtection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#removeWriteProtection) metódus használatával távolíthatja el. Ez a példa kód megmutatja, hogyan távolíthatja el az írásvédettséget a bemutatóból:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Titkosított bemutató tulajdonságainak lekérése**

Általában a felhasználók nehezen tudják lekérni egy titkosított vagy jelszóval védett bemutató dokumentumtulajdonságait. Az Aspose.Slides azonban olyan megoldást kínál, amely lehetővé teszi a bemutató jelszóval való védelmét, miközben biztosítja a felhasználók számára a hozzáférést a bemutató tulajdonságaihoz.

**Megjegyzés** hogy amikor az Aspose.Slides titkosít egy bemutatót, a bemutató dokumentumtulajdonságai is alapértelmezés szerint jelszóval védettek lesznek. Ha azonban a bemutató tulajdonságait elérhetővé szeretné tenni (még a titkosítás után is), az Aspose.Slides pontosan ezt teszi lehetővé.

Ha azt szeretné, hogy a felhasználók megőrizzék a hozzáférést egy általa titkosított bemutató tulajdonságaihoz, használja a [encryptDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#getEncryptDocumentProperties) metódust `true` értékkel. Ez a példa kód megmutatja, hogyan titkosíthatja a bemutatót, miközben biztosítja a felhasználók számára a dokumentumtulajdonságok elérését:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ellenőrizze, hogy a bemutató jelszóval védett-e**

Mielőtt betöltene egy bemutatót, ellenőrizni és megerősíteni szeretheti, hogy a bemutató nincs jelszóval védve. Így elkerülheti a hibákat és hasonló problémákat, amelyek akkor merülnek fel, ha egy jelszóval védett bemutatót a jelszó nélkül próbálják betölteni.

Ez a PHP kód megmutatja, hogyan vizsgálhat egy bemutatót annak megállapítására, hogy jelszóval van-e védve (a bemutató tényleges betöltése nélkül):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Ellenőrizze, hogy a bemutató titkosított-e**

Az Aspose.Slides lehetővé teszi, hogy ellenőrizze, egy bemutató titkosított-e. Ennek elvégzéséhez használhatja az [isEncrypted](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#isEncrypted) metódust, amely `true` értékkel tér vissza, ha a bemutató titkosított, vagy `false` értékkel, ha nem titkosított.

Ez a példa kód megmutatja, hogyan ellenőrizheti, hogy egy bemutató titkosított-e:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ellenőrizze, hogy a bemutató írásvédett-e**

Az Aspose.Slides lehetővé teszi, hogy ellenőrizze, egy bemutató írásvédett‑e. Ennek elvégzéséhez használhatja az [isWriteProtected](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#isWriteProtected) metódust, amely `true` értékkel tér vissza, ha a bemutató titkosított, vagy `false` értékkel, ha nem titkosított.

Ez a példa kód megmutatja, hogyan ellenőrizheti, hogy egy bemutató írásvédett‑e:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ellenőrizze vagy erősítse meg, hogy egy adott jelszót használtak**

Lehet, hogy szeretné ellenőrizni és megerősíteni, hogy egy konkrét jelszót használtak egy bemutató dokumentum védelmére. Az Aspose.Slides biztosítja a lehetőséget a jelszó érvényesítésére.

Ez a példa kód megmutatja, hogyan ellenőrizhet egy jelszót:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # ellenőrizze, hogy a "pass" egyezik-e
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

`true` értékkel tér vissza, ha a bemutatót a megadott jelszóval titkosították. Ellenkező esetben `false` értékkel tér vissza.

{{% alert color="primary" title="Lásd még" %}} 
- [Digitális aláírás PowerPointban](/slides/hu/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Milyen titkosítási módszereket támogat az Aspose.Slides?**

Az Aspose.Slides modern titkosítási módszereket támogat, köztük AES‑alapú algoritmusokat, amelyek magas szintű adatbiztonságot biztosítanak a bemutatói számára.

**Mi történik, ha helytelen jelszót adnak meg a bemutató megnyitásakor?**

Kivétel keletkezik, ha hibás jelszót adnak meg a bemutató megnyitásakor, jelezve, hogy a hozzáférés megtagadva. Ez megakadályozza a jogosulatlan hozzáférést és védi a bemutató tartalmát.

**Vannak-e teljesítménybeli következmények a jelszóval védett bemutatókkal való munkavégzés során?**

A titkosítási és visszafejtési folyamat enyhe teljesítménycsökkenést okozhat a megnyitási és mentési műveletek során. A legtöbb esetben ez a hatás minimális, és nem befolyásolja jelentősen a bemutató feladatai általános feldolgozási idejét.