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
description: "Tanulja meg, hogyan nyithat meg PowerPoint és OpenDocument prezentációkat PHP-ben, adjon meg nyitó jelszavakat, szabályozza az erőforrások betöltését, és csökkentse a memóriahasználatot az Aspose.Slides for PHP via Java segítségével."
---
## **Bevezetés**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/hu/php-java/) képes PowerPoint és OpenDocument prezentációkat betölteni fájlokból és adatfolyamokból. Miután egy prezentáció betöltésre kerül, ellenőrizheti annak felépítését, szerkesztheti a diákot, kezelheti az erőforrásokat, és mentheti az eredeti vagy egy másik támogatott formátumban.  
A betöltési viselkedést testreszabhatja a [LoadOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/) osztályon keresztül. Például megadhat egy nyitó jelszót, a nagy bináris objektumokat a Java heap memóriáján kívül tarthatja, szabályozhatja a külső erőforrásokat, vagy kihagyhatja a beágyazott bináris adatokat.

## **Prezentációk megnyitása**

Egy meglévő prezentáció megnyitásához adja át a fájl útvonalát a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) konstruktorának. Használat után dobja el a prezentációt, hogy a fájlkezelők, ideiglenes adatok és egyéb erőforrások gyorsan felszabaduljanak.

Az alábbi PHP példa bemutatja, hogyan nyithat meg egy prezentációt és kaphatja meg a diák számát:

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

A nyitó jelszó titkosítja a prezentáció tartalmát. A teljes prezentáció betöltéséhez adja át a helyes jelszót a [LoadOptions::setPassword](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setPassword) metódusnak, és adja meg a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) konstruktorának. A betöltés sikertelen, ha a jelszó hiányzik vagy helytelen.

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

A jelszó észlelésével, ellenőrzésével és titkosítási munkafolyamataival kapcsolatban lásd a [Password-Protect Presentations](/slides/hu/php-java/password-protected-presentation/) oldalt. Ha egy titkosított prezentációt szándékosan nyilvános dokumentumtulajdonságokkal mentettek, azok a jelszó nélkül is olvashatóak; lásd a [Manage Presentation Properties](/slides/hu/php-java/presentation-properties/) oldalt.

## **Nagy prezentációk megnyitása**

A [LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) visszaadja azokat a beállításokat, amelyek szabályozzák, hogyan kezeli az Aspose.Slides a bináris nagy objektumokat, például képeket, hangot és videót. A forrásfájlt lezárva tarthatja, engedélyezheti az ideiglenes fájlokat, és korlátozhatja a memóriában megtartott BLOB adatok mennyiségét.

Az alábbi PHP kód bemutatja egy nagy prezentáció (például 2 GB) betöltését:

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
A [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked) használatával a forrásfájl zárolva marad, amíg a prezentáció példány el nem kerül. Ne mozgassa, felülírja vagy törölje a forrásfájlt, amíg ez a példány él.

Az Aspose.Slides betöltés közben másolhatja egy bemeneti adatfolyam tartalmát. Nagy prezentációk esetén a fájl útvonal általában hatékonyabb, mint egy adatfolyam. További tárolási és memória-kezelési lehetőségekért lásd a [Manage BLOBs](/slides/hu/php-java/manage-blob/) oldalt.
{{% /alert %}}

## **Külső erőforrások kezelése**

A [LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) a PHP/Java Bridge-en keresztül fogadja a Java [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iresourceloadingcallback/) interfész implementációját. A visszahívás biztosíthat helyettesítő adatot, átirányíthat egy erőforrást, használhatja az alapértelmezett betöltőt, vagy kihagyhatja az erőforrást. Ez akkor hasznos, ha a prezentációk külső képeket tartalmaznak, amelyeket az alkalmazás-specifikus biztonsági vagy tárolási szabályok szerint kell feloldani.

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

Egy prezentáció tartalmazhat beágyazott bináris adatot, amelyre egy alkalmazásnak nincs szüksége, vagy amit nem kíván megtartani. Példák:

- VBA projektek, a [Presentation::getVbaProject](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getVbaProject) segítségével érhetők el;
- beágyazott OLE adatok, a [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) segítségével érhetők el;
- ActiveX vezérlő adat, a [Control::getActiveXControlBinary](https://reference.aspose.com/slides/hu/php-java/aspose.slides/control/#getActiveXControlBinary) segítségével érhető el.

Állítsa a [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) értékét `true`-ra, hogy a betöltés során eltávolítsa ezeket a bináris adatokat. Mentse a betöltött prezentációt, hogy megőrizze a megtisztított eredményt.

Ez a beállítás csökkenti a nem kívánt beágyazott terhek kitettségét, de nem egy teljes rosszindulatú szoftver- és tartalomtisztító rendszer.

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

**Hogyan állapíthatom meg, hogy egy fájl sérült és nem nyitható meg?**  
Az Aspose.Slides betöltés közben elemzési vagy formátumkivételt dob. Kezelje ezt a hibát külön a helytelen jelszó hibától, hogy az alkalmazás pontosan jelenteni tudja az okot.

**Mi történik, ha a szükséges betűkészletek hiányoznak?**  
A prezentáció továbbra is betölthető, de a megjelenítés és az export esetleg helyettesítő betűkészleteket használ. A kimenet jobban megszacsoltá tételéhez [Betűkészlet helyettesítés beállítása](/slides/hu/php-java/font-substitution/) vagy [Egyedi betűkészletek biztosítása](/slides/hu/php-java/custom-font/) lehetőséget használhat.

**A prezentáció betöltése betölti-e a beágyazott médiát is?**  
A beágyazott hang és videó a prezentáció objektummodelljén keresztül lesz elérhető. A külső erőforrások a beállított erőforrásbetöltési viselkedés szerint kerülnek feloldásra, és előfordulhat, hogy nem érhetők el, ha a helyük nem hozzáférhető.