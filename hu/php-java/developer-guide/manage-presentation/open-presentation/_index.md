---
title: PowerPoint bemutatók megnyitása PHP-ben
linktitle: Bemutató megnyitása
type: docs
weight: 20
url: /hu/php-java/open-presentation/
keywords:
- PowerPoint megnyitása
- OpenDocument megnyitása
- bemutató megnyitása
- PPTX megnyitása
- PPT megnyitása
- ODP megnyitása
- bemutató betöltése
- PPTX betöltése
- PPT betöltése
- ODP betöltése
- védett bemutató
- nagy bemutató
- külső erőforrás
- bináris objektum
- PHP
- Aspose.Slides
description: "PowerPoint (.pptx, .ppt) és OpenDocument (.odp) bemutatók könnyed megnyitása az Aspose.Slides for PHP via Java segítségével — gyors, megbízható, teljes funkcionalitású."
---
## **Bevezetés**

A PowerPoint bemutatók önmagukban történő létrehozása mellett az Aspose.Slides lehetővé teszi meglévő bemutatók megnyitását is. A bemutató betöltése után információkat kérhet le róla, szerkesztheti a dia tartalmát, új diát adhat hozzá, eltávolíthat meglévő diákat, és még sok mást.

## **Bemutatók megnyitása**

Egy meglévő bemutató megnyitásához hozza létre a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztály példányát, és adja át a fájl elérési útját a konstruktorának.

Az alábbi PHP példa bemutatja, hogyan nyithat meg egy bemutatót, és hogyan kérdezheti le a diák számát:

```php
// Példányosítsa a Presentation osztályt, és adja át a fájl elérési útját a konstruktorának.
$presentation = new Presentation("Sample.pptx");
try {
    // Írassa ki a bemutató diáinak összes számát.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```

## **Jelszóval védett bemutatók megnyitása**

Amikor jelszóval védett bemutatót kell megnyitni, adja át a jelszót a [LoadOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/) osztály [setPassword](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setPassword) metódusával a titkosítás feloldásához és betöltéséhez. Az alábbi PHP kód ezt a műveletet mutatja be:

```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // Végrehajtja a műveleteket a visszafejtett bemutatón.
} finally {
    $presentation->dispose();
}
```

## **Nagy bemutatók megnyitása**

Az Aspose.Slides lehetőségeket biztosít – különösen a [LoadOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/) osztály [getBlobManagementOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) metódusát – a nagy bemutatók betöltéséhez.

Az alábbi PHP kód egy nagy bemutató betöltését mutatja (például 2 GB):

```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of
// the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // The large presentation has been loaded and can be used, while memory consumption remains low.

    // Make changes to the presentation.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // Save the presentation to another file. Memory consumption remains low during this operation.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// It is OK to do it here. The source file is no longer locked by the presentation object.
unlink($filePath);
```

{{% alert color="info" title="Info" %}}
A stream-ekkel kapcsolatos bizonyos korlátozások megkerülése érdekében az Aspose.Slides másolhatja a stream tartalmát. Egy nagy bemutató stream‑ből történő betöltése a bemutató másolását eredményezi, és lassíthatja a betöltést. Ezért, ha nagy bemutatót kell betölteni, erősen javasoljuk a bemutató fájl elérési útjának használatát a stream helyett.

Amikor olyan bemutatót hoz létre, amely nagy objektumokat (videó, hang, nagy felbontású képek stb.) tartalmaz, a [BLOB kezelés](/slides/hu/php-java/manage-blob/) segítségével csökkentheti a memóriahasználatot.
{{%/alert %}}

## **Külső erőforrások vezérlése**

Az Aspose.Slides biztosítja az [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iresourceloadingcallback/) interfészt, amely lehetővé teszi a külső erőforrások kezelését. Az alábbi PHP kód bemutatja, hogyan használhatja az `IResourceLoadingCallback` interfészt:

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // Töltsön be egy helyettesítő képet.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // Állítson be egy helyettesítő URL-t.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // Hagyja ki az összes többi képet.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```

## **Beágyazott bináris objektumok nélkül történő betöltés**

Egy PowerPoint bemutató a következő típusú beágyazott bináris objektumokat tartalmazhatja:

- VBA projekt ([Presentation.getVbaProject](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getVbaProject));
- OLE objektum beágyazott adat ([OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- ActiveX vezérlő bináris adata ([Control.getActiveXControlBinary](https://reference.aspose.com/slides/hu/php-java/aspose.slides/control/#getActiveXControlBinary)).

A [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) metódus használatával betölthet egy bemutatót minden beágyazott bináris objektum nélkül.

Ez a módszer hasznos a potenciálisan rosszindulatú bináris tartalom eltávolításához. Az alábbi PHP kód bemutatja, hogyan tölthet be egy bemutatót beágyazott bináris tartalom nélkül:

```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // Végezze el a műveleteket a bemutatón.
} finally {
    $presentation->dispose();
}
```

## **GYIK**

**Hogyan tudom megmondani, hogy egy fájl sérült és nem nyitható meg?**  
A betöltés során parsing/formátum ellenőrzési kivételt kap. Az ilyen hibák gyakran egy érvénytelen ZIP struktúrára vagy törött PowerPoint rekordokra utalnak.

**Mi történik, ha a megnyitáskor hiányoznak a szükséges betűkészletek?**  
A fájl megnyílik, de a későbbi [renderelés/export](/slides/hu/php-java/convert-presentation/) helyettesítheti a betűtípusokat. A [betűtípushelyettesítések beállítása](/slides/hu/php-java/font-substitution/) vagy a [szükséges betűkészletek hozzáadása](/slides/hu/php-java/custom-font/) a futási környezethez segíthet.

**Mi a helyzet a beágyazott médiával (videó/hang) a megnyitáskor?**  
A média a bemutató erőforrásaként lesz elérhető. Ha a médiát külső útvonalakon hivatkozzák, győződjön meg arról, hogy ezek az útvonalak hozzáférhetők a környezetben; ellenkező esetben a [renderelés/export](/slides/hu/php-java/convert-presentation/) kihagyhatja a médiát.