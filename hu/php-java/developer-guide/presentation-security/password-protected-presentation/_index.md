---
title: Jelszóval védett bemutatók biztosítása PHP-ben
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
description: Ismerje meg, hogyan lehet könnyedén zárolni és feloldani jelszóval védett PowerPoint és OpenDocument bemutatókat az Aspose.Slides PHP verzióval. Tegye biztonságossá bemutatóit.
---
## **Bevezetés**

Amikor jelszóval védi a bemutatót, azt jelenti, hogy egy jelszót állít be, amely bizonyos korlátozásokat alkalmaz a bemutatóra. A korlátozások eltávolításához a jelszót be kell írni. A jelszóval védett bemutatót lezárt bemutatónak tekintik.

Általában beállíthat jelszót, hogy ezeket a korlátozásokat a bemutatón alkalmazza:

- **Módosítás**

  Ha csak bizonyos felhasználókat szeretne engedélyezni a bemutató módosítására, beállíthat egy módosítási korlátozást. Ez a korlátozás megakadályozza, hogy valaki módosítsa, változtassa vagy másolja a bemutató tartalmát (kivéve ha megadja a jelszót).  

  Azonban ebben az esetben a felhasználó a jelszó nélkül is hozzáférhet a dokumentumhoz és megnyithatja azt. Olvasási módban a felhasználó megtekintheti a bemutató tartalmát, például a hiperhivatkozásokat, animációkat, effektusokat stb., de nem másolhat elemeket, és nem mentheti a bemutatót. 

- **Megnyitás**

  Ha csak bizonyos felhasználók nyithassák meg a bemutatót, beállíthat egy megnyitási korlátozást. Ez a korlátozás megakadályozza, hogy bárki megtekintse a bemutató tartalmát (kivéve ha megadja a jelszót).

  Technikai szempontból a megnyitási korlátozás megakadályozza a bemutató módosítását is: Ha valaki nem tudja megnyitni a bemutatót, nem tudja módosítani vagy változtatni azt.  
  
  **Megjegyzés** hogy amikor jelszóval védi a bemutatót a megnyitás megakadályozásához, a bemutató fájl titkosítva lesz.

## **Hogyan védje jelszóval a bemutatót online**

1. Látogassa meg a [**Aspose.Slides Lock**](https://products.aspose.app/slides/hu/lock) oldalt. 

   ![todo:image_alt_text](slides-lock.png)

2. Kattintson a **Drop or upload your files** gombra.

3. Válassza ki a számítógépén lévő, jelszóval védeni kívánt fájlt. 

4. Adja meg a kívánt jelszót a szerkesztési védelemhez; adja meg a kívánt jelszót a megtekintési védelemhez. 

5. Ha azt szeretné, hogy a felhasználók a bemutatót végleges példányként lássák, jelölje be a **Mark as final** jelölőnégyzetet.

6. Kattintson a **PROTECT NOW.** gombra. 

7. Kattintson a **DOWNLOAD NOW.** gombra.

## **Jelszóvédelem a bemutatókhoz az Aspose.Slides-ben**
**Támogatott formátumok**

Az Aspose.Slides jelszóvédelem, titkosítás és hasonló műveletek támogatását biztosítja a következő formátumokban:

- PPTX és PPT – Microsoft PowerPoint bemutató 
- ODP – OpenDocument bemutató 
- OTP – OpenDocument bemutató sablon 

**Támogatott műveletek**

Az Aspose.Slides lehetővé teszi, hogy jelszóvédelem használatával megakadályozza a bemutatók módosítását a következő módokon:

- Bemutató titkosítása
- Írásvédettség beállítása a bemutatóhoz

**Egyéb műveletek**

Az Aspose.Slides lehetővé teszi, hogy egyéb jelszóvédelemmel és titkosítással kapcsolatos feladatokat hajtson végre a következő módokon:

- Bemutató visszafejtése; titkosított bemutató megnyitása
- Titkosítás eltávolítása; jelszóvédelem letiltása
- Írásvédelem eltávolítása a bemutatóból
- Titkosított bemutató tulajdonságainak lekérése
- Annak ellenőrzése, hogy a bemutató titkosított-e
- Annak ellenőrzése, hogy a bemutató jelszóval védett-e.

## **Bemutató titkosítása**

A bemutatót jelszó beállításával titkosíthatja. A zárolt bemutató módosításához a felhasználónak meg kell adnia a jelszót. 

A bemutató titkosításához vagy jelszóval való védelméhez használni kell az encrypt metódust (a [ProtectionManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/)‑ból) a jelszó beállításához. A jelszót az encrypt metódusnak adja át, majd a save metódussal mentse a most titkosított bemutatót.

Ez a mintakód bemutatja, hogyan titkosítható a bemutató:

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

A bemutatóhoz hozzáadhat egy „Ne módosítsa” feliratot. Így jelezheti a felhasználóknak, hogy nem szeretné, ha módosítanák a bemutatót.  

**Megjegyzés** hogy az írásvédettség nem titkosítja a bemutatót. Ezért a felhasználók – ha akarják – módosíthatják a bemutatót, de a változtatások mentéséhez másik névvel kell menteniük a bemutatót. 

Az írásvédelem beállításához a [setWriteProtection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#setWriteProtection) metódust kell használnia. Ez a mintakód bemutatja, hogyan állíthat be írásvédelmet a bemutatóhoz:

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

Az Aspose.Slides lehetővé teszi, hogy egy titkosított fájlt a jelszó megadásával betöltse. A bemutató visszafejtéséhez hívja meg a [removeEncryption](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#removeEncryption) metódust paraméterek nélkül. Ezután meg kell adnia a helyes jelszót a bemutató betöltéséhez.

Ez a mintakód bemutatja, hogyan fejthető vissza egy bemutató: 

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # dolgozz a visszafejtett bemutatóval
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Titkosítás eltávolítása egy bemutatóból**

Eltávolíthatja a bemutató titkosítását vagy jelszóvédelmét. Így a felhasználók korlátozás nélkül férnek hozzá vagy módosíthatják a bemutatót. 

A titkosítás vagy jelszóvédelem eltávolításához hívja meg a [removeEncryption](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#removeEncryption) metódust. Ez a mintakód bemutatja, hogyan távolítható el a titkosítás egy bemutatóból:

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

## **Írásvédelem eltávolítása egy bemutatóból**

Az Aspose.Slides segítségével eltávolíthatja a bemutató fájlra alkalmazott írásvédelmet. Így a felhasználók szabadon módosíthatnak, és nem kapnak figyelmeztetést ilyen műveletek végrehajtásakor.

Az írásvédelem eltávolítható a [removeWriteProtection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#removeWriteProtection) metódus használatával. Ez a mintakód megmutatja, hogyan távolítható el az írásvédelem egy bemutatóból:

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

Általában a felhasználók nehezen jutnak hozzá egy titkosított vagy jelszóval védett bemutató dokumentumtulajdonságaihoz. Az Aspose.Slides azonban olyan mechanizmust kínál, amely lehetővé teszi a bemutató jelszóval való védelmét, miközben a felhasználók továbbra is hozzáférhetnek a tulajdonságokhoz.  

**Megjegyzés:** Alapértelmezés szerint, amikor az Aspose.Slides titkosít egy bemutatót, a bemutató dokumentumtulajdonságai is jelszóval védettek. Ha a dokumentumtulajdonságok hozzáférhetők maradjanak a titkosítás után is, az Aspose.Slides ezt lehetővé teszi.  

Ha azt szeretné, hogy a felhasználók továbbra is elérhessék egy titkosított bemutató tulajdonságait, adja át a `false` értéket a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) metódusnak. Ez a mintakód bemutatja, hogyan titkosítható egy bemutató, miközben a felhasználók hozzáférhetnek a dokumentumtulajdonságaihoz:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Csak a dokumentumtulajdonságok betöltése egy titkosított bemutatóból**

A titkosított bemutató metaadatait a diák vagy egyéb tartalom betöltése nélkül is megvizsgálhatja, ha létrehoz egy [LoadOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/) objektumot, és `true` értéket ad át a [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) metódusnak. Ebben a módban az Aspose.Slides figyelmen kívül hagyja a jelszót, és csak a nyilvánosan elérhető dokumentumtulajdonságokat tölti be.

Az alábbi kódrészlet beépített és egyéni dokumentumtulajdonságokat olvas a [Presentation::getDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getDocumentProperties) segítségével:

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # Olvassa be a beépített dokumentumtulajdonságokat.
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # Olvassa be az egyéni dokumentumtulajdonságokat.
    $customPropertyCount = java_values($documentProperties->getCountOfCustomProperties());

    for ($propertyIndex = 0; $propertyIndex < $customPropertyCount; $propertyIndex++) {
        $propertyName = $documentProperties->getCustomPropertyName($propertyIndex);
        $propertyValue = java_values($documentProperties->get_Item($propertyName));

        echo($propertyName . ": " . $propertyValue . "\n");
    }
} finally {
    $presentation->dispose();
}
```

Ez a munkafolyamat csak akkor működik, ha a dokumentumtulajdonságokat a bemutató titkosításakor nyilvános (nem titkosított) állapotban hagyták. Ha a dokumentumtulajdonságok titkosítva vannak, a `true` érték átadása a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) metódusnak kivételt okoz, mivel ebben a módban a jelszó figyelmen kívül marad.  

A titkosított dokumentumtulajdonságok eléréséhez vagy a teljes bemutató betöltéséhez, beleértve a diák és egyéb tartalmakat, adja meg a megfelelő jelszót a [LoadOptions::setPassword](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setPassword) metóduson keresztül.

## **Ellenőrizze, hogy a bemutató jelszóval védett-e**

Mielőtt betöltene egy bemutatót, érdemes ellenőrizni, hogy a bemutató nincs-e jelszóval védve. Így elkerülhetők a hibák és hasonló problémák, amelyek akkor merülnek fel, ha jelszóval védett bemutatót jelszó nélkül próbálnak betölteni.  

Ez a PHP kód megmutatja, hogyan vizsgálhatja meg egy bemutatót annak ellenőrzésére, hogy jelszóval védett-e (a bemutató tényleges betöltése nélkül):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Ellenőrizze, hogy a bemutató titkosított-e**

Az Aspose.Slides lehetővé teszi, hogy ellenőrizze, titkosított-e a bemutató. Ehhez használhatja az [isEncrypted](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#isEncrypted) metódust, amely `true` értéket ad vissza, ha a bemutató titkosított, vagy `false` értéket, ha nem titkosított.  

Ez a mintakód bemutatja, hogyan ellenőrizhető, hogy egy bemutató titkosított-e:

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

Az Aspose.Slides lehetővé teszi, hogy ellenőrizze, írásvédett-e a bemutató. Ehhez használhatja az [isWriteProtected](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#isWriteProtected) metódust, amely `true` értéket ad vissza, ha a bemutató írásvédett, vagy `false` értéket, ha nem írásvédett.  

Ez a mintakód bemutatja, hogyan ellenőrizhető, hogy egy bemutató írásvédett-e:

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

Lehet, hogy ellenőrizni és megerősíteni szeretné, hogy egy konkrét jelszót használtak a bemutató dokumentum védelmére. Az Aspose.Slides lehetőséget biztosít a jelszó ellenőrzésére.  

Ez a mintakód bemutatja, hogyan validálhatja a jelszót:

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

A metódus `true` értéket ad vissza, ha a bemutatót a megadott jelszóval titkosították, egyébként `false` értéket. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/hu/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Milyen titkosítási módszereket támogat az Aspose.Slides?**

Az Aspose.Slides modern titkosítási módszereket támogat, köztük az AES-alapú algoritmusokat, ezzel magas szintű adatbiztonságot biztosítva a bemutatói számára.

**Mi történik, ha helytelen jelszót adnak meg a bemutató megnyitásakor?**

Hibát (kivételt) vált ki, ha helytelen jelszót adnak meg, jelezve, hogy a bemutatóhoz való hozzáférés megtagadva. Ez megakadályozza a jogosulatlan hozzáférést és védi a bemutató tartalmát.

**Vannak-e teljesítménybeli hatások a jelszóval védett bemutatók kezelésekor?**

A titkosítási és visszafejtési folyamat kis mértékű overhead-et okozhat a megnyitás és mentés során. A legtöbb esetben ez a teljesítménybeli hatás minimális, és nem befolyásolja jelentősen a bemutatók feldolgozási idejét.