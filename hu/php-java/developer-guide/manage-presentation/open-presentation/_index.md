---
title: Prezentációk megnyitása PHP-ben
linktitle: Prezentáció megnyitása
type: docs
weight: 20
url: /hu/php-java/open-presentation/
keywords:
- PowerPoint megnyitása
- prezentáció megnyitása
- PPTX megnyitása
- PPT megnyitása
- ODP megnyitása
- prezentáció betöltése
- PPTX betöltése
- PPT betöltése
- ODP betöltése
- védett prezentáció
- nagy prezentáció
- külső erőforrás
- bináris objektum
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan nyithat meg PowerPoint és OpenDocument prezentációkat PHP-ben, adhat meg nyitó jelszavakat, szabályozhatja az erőforrásbetöltést, és csökkentheti a memóriahasználatot az Aspose.Slides for PHP via Java segítségével."
---
## **Bevezetés**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/hu/php-java/) képes PowerPoint és OpenDocument prezentációkat betölteni fájlokból és adatfolyamokból. Miután egy prezentációt betöltöttél, vizsgálhatod a szerkezetét, szerkesztheted a diát, kezelheted az erőforrásokat, és elmentheted az eredeti vagy egy másik támogatott formátumban.

A betöltés viselkedését a [LoadOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/) osztályon keresztül testre szabhatod. Például megadhatsz egy nyitó jelszót, nagy bináris objektumokat tarthatsz a Java halommemórián kívül, szabályozhatod a külső erőforrásokat, vagy kihagyhatod a beágyazott bináris adatokat.

## **Prezentációk megnyitása**

Fájl vagy adatfolyam betöltése után meghatározhatod az eredeti prezentációformátumot, hogy kiválaszthasd, hogyan dolgozza fel az alkalmazásod.

Egy meglévő prezentáció megnyitásához add át a fájl útvonalát a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) konstruktorának. A használat után szabadítsd fel a prezentációt, hogy a fájlkezelők, ideiglenes adatok és egyéb erőforrások gyorsan felszabaduljanak.

Az alábbi PHP példa bemutatja, hogyan nyithatsz meg egy prezentációt és hogyan kérheted le a diák számát:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Jelszóval védett prezentációk megnyitása**

A nyitó jelszó titkosítja a prezentáció tartalmát. A teljes prezentáció betöltéséhez add át a helyes jelszót a [LoadOptions::setPassword](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setPassword) metódusnak, és add meg a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) konstruktorának. A betöltés meghiúsul, ha a jelszó hiányzik vagy helytelen.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

A jelszó felismerésével, ellenőrzésével és titkosítási munkafolyamatokkal kapcsolatban lásd a [Password-Protect Presentations](/slides/hu/php-java/password-protected-presentation/) oldalt. Ha egy titkosított prezentációt szándékosan nyilvános dokumentumtulajdonságokkal mentették, ezek a tulajdonságok jelszó nélkül is olvashatók; lásd a [Manage Presentation Properties](/slides/hu/php-java/presentation-properties/) oldalt.

## **Nagy méretű prezentációk megnyitása**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) visszaadja azokat a beállításokat, amelyek szabályozzák, hogyan kezeli az Aspose.Slides a nagy bináris objektumokat, például képeket, hangot és videót. A forrásfájlt zárolhatod, engedélyezheted az ideiglenes fájlokat, és korlátozhatod a memóriában megtartott BLOB adatok mennyiségét.

Az alábbi PHP kód bemutatja egy nagy prezentáció betöltését (például 2 GB):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
A [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked) használatával a forrásfájl zárolva marad, amíg a prezentáció példány ki nem kerülől. Ne mozdítsd el, írd felül vagy töröld a forrásfájlt, amíg ez a példány él.

Az Aspose.Slides betöltéskor másolhatja a bemeneti adatfolyam tartalmát. Nagy prezentációk esetén ezért általában a fájlútvonal hatékonyabb, mint egy adatfolyam. További tárolási és memória-kezelési lehetőségekért lásd a [Manage BLOBs](/slides/hu/php-java/manage-blob/) oldalt.
{{% /alert %}}

## **Külső erőforrások szabályozása**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) a PHP/Java Bridge-en keresztül egy Java [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iresourceloadingcallback/) interfész megvalósítását fogadja el. A visszahívás helyettesítő adatot adhat, átirányíthat egy erőforrást, használhatja az alapértelmezett betöltőt, vagy kihagyhatja az erőforrást. Ez akkor hasznos, ha a prezentációk külső képeket tartalmaznak, amelyeket az alkalmazás-specifikus biztonsági vagy tárolási szabályok szerint kell feloldani.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Prezentációk betöltése beágyazott bináris objektumok nélkül**

Egy prezentáció beágyazott bináris adatokat tartalmazhat, amelyeket egy alkalmazás nem igényel vagy nem akar megtartani. Példák:

- VBA projektek, a [Presentation::getVbaProject](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getVbaProject) segítségével elérhetők;
- beágyazott OLE adatok, az [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) segítségével elérhetők;
- ActiveX vezérlő adatok, a [Control::getActiveXControlBinary](https://reference.aspose.com/slides/hu/php-java/aspose.slides/control/#getActiveXControlBinary) segítségével elérhetők.

Állítsd a [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) értékét `true`‑ra, hogy a betöltés során eltávolítsd ezt a bináris adatot. Mentsd el a betöltött prezentációt, hogy a tisztított eredményt megőrizd.

Ez a beállítás csökkenti a nem kívánt beágyazott terhek kitettségét, de nem tekinthető teljes vírusfelismerő vagy tartalomszűrő rendszernek.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **GYIK**

**Hogyan deríthetem ki, hogy egy fájl sérült és nem nyitható meg?**

Az Aspose.Slides betöltés közben elemzési vagy formátum kivételt dob. Kezeld ezt a hibát külön a helytelen jelszó hibájától, hogy az alkalmazás pontosan jelenteni tudja az okot.

**Mi történik, ha a szükséges betűtípusok hiányoznak?**

A prezentáció továbbra is betölthető, de a megjelenítés és exportálás betűtípus helyettesítéseket alkalmazhat. A betűtípus helyettesítés beállítható, vagy megadhatsz egyedi betűtípusokat, hogy az eredmény kiszámíthatóbb legyen.

**Betölti a rendszer a prezentáció beágyazott médiáját is?**

A beágyazott hang és videó a prezentáció objektummodelljén keresztül érhető el. A külső erőforrások a beállított erőforrásbetöltési viselkedés szerint kerülnek feloldásra, és előfordulhat, hogy nem érhetők el, ha a helyeikhez nem férnek hozzá.