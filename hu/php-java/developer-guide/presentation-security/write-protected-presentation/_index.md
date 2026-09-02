---
title: Prezentációk írásvédelme PHP-ben
linktitle: Írásvédelem
type: docs
weight: 25
url: /hu/php-java/write-protected-presentation/
keywords:
- írásvédelem
- PowerPoint írásvédelem
- jelszó a módosításhoz
- prezentáció szerkesztésének korlátozása
- írásvédelem eltávolítása
- módosítási jelszó ellenőrzése
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Írásvédelmi jelszavak beállítása, észlelése, ellenőrzése és eltávolítása PowerPoint PPT és PPTX prezentációkban az Aspose.Slides for PHP segítségével."
---
## **Bevezetés**

A write-protection jelszó korlátozza a prezentáció módosítását, de nem titkosítja annak tartalmát. A felhasználók a write-protected prezentációt jelszó nélkül betölthetik és megtekinthetik. Az alkalmazástól függően előfordulhat, hogy szerkeszthetik a tartalmat és más néven menthetik, így a write protection-et nem szabad titoktartási mechanizmusnak tekinteni.

Az opening jelszó más célra szolgál: titkosítja a prezentációt, és szükséges a tartalom betöltéséhez. A prezentáció titkosításához vagy egy opening jelszó ellenőrzéséhez lásd [Jelszóval védett prezentációk](/slides/hu/php-java/password-protected-presentation/).

A cikkben bemutatott munkafolyamatok PPT és PPTX prezentációkra egyaránt alkalmazhatók. A példák PPTX fájlokat használnak; PPT mentésnél használja a `.ppt` kiterjesztést és a megfelelő PPT mentési formátumot.

## **Write Protection beállítása a prezentáción**

Használja a [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#setWriteProtection) metódust egy jelszó hozzárendeléséhez a prezentáció módosításához. A prezentáció mentése menti a védelmi beállítást.

A következő példa write protection-t állít be egy PPTX prezentáción:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Write-protected prezentáció betöltése**

Mivel a write protection nem titkosítja a prezentáció tartalmát, nincs szükség jelszóra a prezentáció betöltéséhez. A jelszó csak akkor releváns, amikor a védett prezentáció módosításához szükséges engedély ellenőrzése történik.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

Ne adja át a write-protection jelszót a [LoadOptions::setPassword](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setPassword) metódusnak. Ez a metódus egy opening jelszót vár a titkosított tartalomhoz. Ha egy prezentáció mindkét típusú védelmet tartalmaz, adja meg az opening jelszót a betöltéshez, és külön kezelje a write-protection jelszót.

## **Write Protection eltávolítása a prezentációból**

Használja a [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#removeWriteProtection) metódust a módosítási korlátozás eltávolításához, majd mentse a prezentációt.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ellenőrizze, hogy a prezentáció write protected-e**

A fájl megvizsgálásához anélkül, hogy teljes [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt hozna létre, hívja a [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust, és ellenőrizze a [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#isWriteProtected) értékét. A metódus a [NullableBool](https://reference.aspose.com/slides/hu/php-java/aspose.slides/nullablebool/) típust használja, és `NullableBool::True` értéket ad vissza, ha write protection észlelhető.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

A [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/#getPresentationInfo) stream túlterhelése ugyanazt az információt adja egy streamként megadott prezentációhoz.

## **Write-protection jelszó ellenőrzése**

Használja a [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#checkWriteProtection) metódust a módosítási jelszó ellenőrzéséhez anélkül, hogy a teljes prezentációt betöltené. Először ellenőrizze a [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#isWriteProtected) értékét, hogy az alkalmazás csak akkor kérjen vagy ellenőrizzen jelszót, ha a write protection jelen van.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#checkWriteProtection) csak a write-protection jelszót ellenőrzi. Nem ellenőrzi az opening jelszót, és nem határozza meg, hogy a titkosított tartalom betölthető-e. Ezzel szemben a [PresentationInfo::checkPassword](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#checkPassword) csak az opening jelszót ellenőrzi. Ha egy teljes prezentáció már be van töltve, a [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/#checkWriteProtection) a megfelelő write-protection ellenőrzést kínál a protection managerén keresztül.

Éles alkalmazásokban ne naplózza a jelszavakat, és ne legyenek azok diagnostikai üzenetekben. Kerülje a szükségtelen ismételt ellenőrzéseket, és a jelszavakat csak annyi ideig tartsa memóriában, ameddig szükséges.

{{% alert color="info" title="Lásd még" %}}
- [Jelszóval védett prezentációk](/slides/hu/php-java/password-protected-presentation/)
- [Csak olvasható prezentációk](/slides/hu/php-java/read-only-presentation/)
- [Digitális aláírás a PowerPointban](/slides/hu/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Titkosítja-e a write protection a prezentációt?**

Nem. A módosítást korlátozza, de a prezentáció tartalma továbbra is betölthető és megtekinthető.

**A write-protection jelszó szükséges a prezentáció megnyitásához?**

Nem. Csak egy opening jelszó szükséges a titkosított prezentáció tartalmának betöltéséhez.

**Lehet egy prezentációnak egyszerre opening és write-protection jelszava?**

Igen. Az opening jelszót a betöltési beállításokban adja meg a titkosított prezentáció megnyitásához, a write-protection jelszót pedig külön validálja, ha a módosítási engedély szükséges.