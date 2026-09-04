---
title: "Jelszóval védett prezentációk PHP-ben"
linktitle: "Jelszóvédelem"
type: docs
weight: 20
url: /hu/php-java/password-protected-presentation/
keywords:
- jelszóval védett prezentáció
- nyitó jelszó
- PowerPoint titkosítása
- PowerPoint visszafejtése
- prezentáció jelszó ellenőrzése
- prezentáció jelszó ellenőrzése
- titkosított prezentáció megnyitása
- titkosítás eltávolítása
- PowerPoint
- PPT
- PPTX
- prezentáció
- PHP
- Aspose.Slides
description: "Titkosítsa, detektálja, ellenőrizze, nyissa meg, és fejtsen vissza jelszóval védett PowerPoint PPT és PPTX prezentációkat PHP-ben az Aspose.Slides segítségével."
---
## **Áttekintés**

A nyitó jelszó titkosítja a prezentációt. A helyes jelszó szükséges a prezentáció tartalmának betöltéséhez és megtekintéséhez, így ez a védelem titkosságot biztosít.

A nyitó jelszó eltér a írásvédelmi jelszótól. Az írásvédelem korlátozza a módosítást, de nem titkosítja a tartalmat, és nem akadályozza a prezentáció betöltését. A prezentációk módosításához használt jelszavak kezeléséhez lásd a [Write-Protect Presentations](/slides/hu/php-java/write-protected-presentation/).

Az alábbi munkafolyamatok mind a PPT, mind a PPTX prezentációkra vonatkoznak. A példák mindkét formátumot használják, ahol a fájl‑alapú és a stream‑alapú viselkedés fontos.

## **Prezentáció titkosítása nyitó jelszóval**

Használd a [ProtectionManager::encrypt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#encrypt) metódust a nyitó jelszó hozzárendeléséhez. Ezután a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) segítségével tárold a titkosított prezentációt.

Az alábbi példa egy PPTX prezentációt titkosít:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Dokumentum tulajdonságok nyilvánosak tartása**

Alapértelmezés szerint az Aspose.Slides a dokumentum tulajdonságokat is belefoglalja a prezentáció titkosításába. A [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) metódus e viselkedést a dia tartalmának titkosításától függetlenül szabályozza. `false` értéket add meg a [ProtectionManager::encrypt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#encrypt) hívása előtt, ha egy indexelő, osztályozó, kereső vagy dokumentumkezelő rendszernek a nyitó jelszó nélkül kell a metaadatokat olvasnia.

Az alábbi példa egy titkosított PPTX prezentációt hoz létre, miközben a beépített dokumentum tulajdonságok nyilvánosak maradnak:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`false` átadása a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) metódusnak nem teszi nyilvánossá a diákat, master‑sablonokat, elrendezéseket, alakzatokat, médiát vagy a prezentáció egyéb tartalmát. Csak a dokumentum tulajdonságokra van hatással. Ezeknek a tulajdonságoknak a titkosított tartalom betöltése nélkül történő olvasásához lásd a [Manage Presentation Properties](/slides/hu/php-java/presentation-properties/).

## **Titkosított prezentáció betöltése**

Állítsd be a [LoadOptions::setPassword](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setPassword) értékét a nyitó jelszóra, és add meg az opciókat a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) számára a fájl betöltésekor. A betöltés sikertelen, ha nyitó jelszó szükséges, de a megadott jelszó hiányzik vagy hibás.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Dolgozz a visszafejtett prezentációval.
} finally {
    $presentation->dispose();
}
```

## **Titkosítás eltávolítása egy prezentációból**

Töltsd be a prezentációt a nyitó jelszóval, hívd meg a [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#removeEncryption) metódust, és mentsd el az eredményt. A mentett prezentáció ezután jelszó nélkül betölthető.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nyitó jelszó ellenőrzése betöltés előtt**

Használd a [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust a [PresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/) megszerzéséhez anélkül, hogy teljes prezentációs példányt hoznál létre. Ellenőrizd a [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#isPasswordProtected) értéket a jelszó lekérése vagy ellenőrzése előtt. Ha védelem van, ellenőrizd a megadott értéket a [PresentationInfo::checkPassword](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#checkPassword) segítségével.

### **Fájlútvonal munkafolyamat**

Az alábbi példa ellenőrzi a nyitó jelszót egy PPTX fájlhoz, a validált értéket átadja a [LoadOptions::setPassword](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setPassword) metódusnak, majd betölti a teljes prezentációt:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **Stream munkafolyamat**

A [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/#getPresentationInfo) streames túlterhelése ugyanazt a munkafolyamatot biztosítja. A teljes prezentáció streamből való betöltése előtt állítsd vissza egy kereshető stream pozícióját.

Az alábbi példa egy PPT fájlt használ:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **checkPassword visszatérési értékek**

A [PresentationInfo::checkPassword](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#checkPassword) csak akkor ad vissza `true` értéket, ha a prezentációnak nyitó jelszója van, és a megadott jelszó helyes. `false` értéket ad a következő esetekben:

- A jelszó helytelen.
- A prezentációnak nincs nyitó jelszava.
- A megadott jelszó `null` vagy üres.

A viselkedés PPT és PPTX prezentációk esetén is ugyanaz.

## **Ellenőrizze, hogy a betöltött prezentáció titkosított‑e**

A megfelelő jelszóval betöltött prezentáció után vizsgáld meg a [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#isEncrypted) értéket, hogy megerősítsd, hogy a forrás prezentáció titkosítva volt. A nyitó jelszavas védelem betöltés előtti felderítéséhez használd a [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#isPasswordProtected) metódust, ahogy fentebb is látható.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **Biztonsági ajánlások**

{{% alert color="warning" title="Biztonság" %}}
Ne naplózd a nyitó jelszavakat, és ne helyezd őket diagnosztikai üzenetekbe. Kerüld a felesleges, ismételt ellenőrzési kísérleteket, tartsd a jelszavakat a memóriában csak a szükséges időtartamig, és egy sikeres ellenőrzés eredményét használd fel a prezentáció azonnali betöltésekor.

A nyilvános dokumentum tulajdonságok felfedhetik a szerzők nevét, címeket, témákat, kulcsszavakat, céginformációkat, megjegyzéseket és egyedi értékeket, még akkor is, ha a prezentáció tartalma titkosított. Titkosítsd a bizalmas metaadatokat a prezentációval együtt. A tulajdonságok nyilvánosan hagyása csak akkor legyen szándékos döntés, amikor a rendszereknek a fájlt nyitó jelszó nélkül kell indexelni, osztályozni, keresni vagy kezelni.
{{% /alert %}}

## **Prezentáció jelszóval való védelme online**

1. Nyisd meg az [Aspose.Slides Lock](https://products.aspose.app/slides/hu/lock) alkalmazást.
1. Válaszd ki vagy töltsd fel a prezentációt.
1. Adj meg egy jelszót a megtekintési védelemhez.
1. Opcionálisan adj meg egy külön jelszót a szerkesztési védelemhez.
1. Alkalmazd a védelmet, és töltsd le a kapott fájlt.

{{% alert color="info" title="Lásd még" %}}
- [Write-Protect Presentations](/slides/hu/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/hu/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a nyitó jelszó és az írásvédelmi jelszó között?**

A nyitó jelszó titkosítja a prezentációt, és a tartalom betöltéséhez szükséges. Az írásvédelmi jelszó a módosítást korlátozza anélkül, hogy a tartalmat titkosítaná.

**Ellenőrizhetek egy nyitó jelszót anélkül, hogy az összes diát betölteném?**

Igen. Szerezd meg a prezentáció információit, ellenőrizd, hogy van‑e nyitó jelszavas védelem, és validáld a jelszót a teljes prezentációs példány létrehozása előtt.

**Olvashat‑e egy alkalmazás metaadatokat a nyitó jelszó nélkül?**

Igen, de csak akkor, ha a prezentációt úgy titkosították, hogy a dokumentumtulajdonságok titkosítása ki van kapcsolva. Ebben az esetben az alkalmazásnak a csak dokumentumtulajdonságokra korlátozott betöltési módot kell használnia, amelyet a [Manage Presentation Properties](/slides/hu/php-java/presentation-properties/) leír.

**Támogatják‑e a jelszó‑ellenőrzési munkafolyamatok mind a PPT, mind a PPTX formátumot?**

Igen. A fájlútvonal és a stream‑alapú jelszó‑észlelés és –ellenőrzés ugyanúgy működik PPT és PPTX prezentációk esetén.