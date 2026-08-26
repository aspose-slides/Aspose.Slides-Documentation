---
title: Jelszóval védett bemutatók PHP-ben
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/php-java/password-protected-presentation/
keywords:
- jelszóval védett bemutató
- nyitó jelszó
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
- PHP
- Aspose.Slides
description: "Titkosíts, detektálj, ellenőriz, nyisd meg, és fejtsd vissza a jelszóval védett PowerPoint PPT és PPTX bemutatókat PHP-ben az Aspose.Slides használatával."
---
## **Áttekintés**

A nyitó jelszó titkosítja a bemutatót. A helyes jelszó szükséges a bemutató tartalmának betöltéséhez és megtekintéséhez, így ez a védelem titoktartást biztosít.

A nyitó jelszó különbözik az írásvédelmi jelszótól. Az írásvédelem korlátozza a módosítást, de nem titkosítja a tartalmat, és nem akadályozza meg a bemutató betöltését. A bemutatók módosításához használt jelszavak kezelése érdekében lásd a [Írásvédett bemutatók](/slides/hu/php-java/write-protected-presentation/).

Az alábbi munkafolyamatok PPT és PPTX bemutatókra egyaránt vonatkoznak. A példák mindkét formátumot használják, ahol a fájl- és adatfolyam-alapú viselkedés fontos.

## **Bemutató titkosítása nyitó jelszóval**

Használd a [ProtectionManager::encrypt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#encrypt) metódust a nyitó jelszó megadásához. Ezután a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) metódussal mentheted a titkosított bemutatót.

A következő példa egy PPTX bemutatót titkosít:

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

## **Titkosított bemutató betöltése**

Állítsd be a [LoadOptions::setPassword](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setPassword) metódust a nyitó jelszóra, és add át a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) betöltésekor. A betöltés sikertelen, ha nyitó jelszó szükséges, de a megadott jelszó hiányzik vagy helytelen.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Dolgozz a visszafejtett bemutatóval.
} finally {
    $presentation->dispose();
}
```

## **Titkosítás eltávolítása a bemutatóból**

Töltsd be a bemutatót a nyitó jelszavával, hívd meg a [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#removeEncryption) metódust, majd mentsd el az eredményt. A mentett bemutató azt követően jelszó nélkül is betölthető.

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

Használd a [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust a [PresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/) beszerzéséhez anélkül, hogy teljes bemutató példányt hoznál létre. Ellenőrizd a [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#isPasswordProtected) állapotát, mielőtt jelszót kérnél vagy validálnál. Ha védelem van, ellenőrizd a megadott értéket a [PresentationInfo::checkPassword](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#checkPassword) metódussal.

### **Fájlútvonal munkafolyamat**

A következő példa egy PPTX fájl nyitó jelszavát ellenőrzi, a validált értéket átadja a [LoadOptions::setPassword](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setPassword) metódusnak, majd betölti a teljes bemutatót:

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

### **Adatfolyam munkafolyamat**

A [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/#getPresentationInfo) adatfolyam túlterhelése ugyanazt a munkafolyamatot biztosítja. Állítsd vissza a kereshető adatfolyam pozícióját, mielőtt a teljes bemutatót betöltenéd ebből az adatfolyamból.

A következő példa egy PPT fájlt használ:

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

A [PresentationInfo::checkPassword](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#checkPassword) csak akkor ad `true` értéket, ha a bemutató nyitó jelszóval védett és a megadott jelszó helyes. Minden alábbi esetben `false` értéket ad:

- A jelszó helytelen.
- A bemutató nem rendelkezik nyitó jelszóval.
- A megadott jelszó `null` vagy üres.

A viselkedés PPT és PPTX bemutatókra egyaránt ugyanaz.

## **Ellenőrizd, hogy a betöltött bemutató titkosított-e**

A megfelelő jelszóval betöltött bemutató után vizsgáld meg a [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#isEncrypted) metódust, hogy megerősítsd a forrásbemutató titkosítását. A nyitó jelszóval való védelem betöltés előtt történő felismeréséhez használd a [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#isPasswordProtected) metódust, ahogy fentebb is bemutattuk.

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
Ne naplózd a nyitó jelszavakat, és ne szerepeltessük őket diagnosztikai üzenetekben. Kerüld a szükségtelen ismételt ellenőrzési kísérleteket, tartsd a jelszavakat a memóriában csak a szükséges ideig, és ismételd fel a sikeres ellenőrzés eredményét, ha a bemutatót azonnal betöltöd.
{{% /alert %}}

## **Bemutató jelszóval való védelme online**

1. Nyisd meg az [Aspose.Slides Lock](https://products.aspose.app/slides/hu/lock) alkalmazást.
1. Válaszd ki vagy töltsd fel a bemutatót.
1. Adj meg egy jelszót a megtekintési védelemhez.
1. Opcionálisan adj meg egy külön jelszót a szerkesztési védelemhez.
1. Alkalmazd a védelmet, és töltsd le a kapott fájlt.

{{% alert color="info" title="Lásd még" %}}
- [Írásvédett bemutatók](/slides/hu/php-java/write-protected-presentation/)
- [Digitális aláírás a PowerPointban](/slides/hu/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a nyitó jelszó és az írásvédelmi jelszó között?**

A nyitó jelszó titkosítja a bemutatót, és szükséges a tartalom betöltéséhez. Az írásvédelmi jelszó a módosítást korlátozza anélkül, hogy a tartalmat titkosítaná.

**Ellenőrizhetem a nyitó jelszót a diák teljes betöltése nélkül?**

Igen. Szerezd meg a bemutató információit, ellenőrizd, hogy nyitó jelszóval védett-e, és validáld a jelszót, mielőtt teljes bemutató példányt hoznál létre.

**A jelszó-ellenőrző munkafolyamatok támogatják a PPT és PPTX formátumot is?**

Igen. A fájlútvonal és adatfolyam‑alapú jelszó‑detektálás és validálás ugyanúgy működik PPT és PPTX bemutatók esetén.