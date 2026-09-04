---
title: Otevření prezentací v PHP
linktitle: Otevřít prezentaci
type: docs
weight: 20
url: /cs/php-java/open-presentation/
keywords:
- otevřít PowerPoint
- otevřít prezentaci
- otevřít PPTX
- otevřít PPT
- otevřít ODP
- načíst prezentaci
- načíst PPTX
- načíst PPT
- načíst ODP
- chráněná prezentace
- velká prezentace
- externí zdroj
- binární objekt
- PHP
- Aspose.Slides
description: "Naučte se, jak v PHP otevírat prezentace PowerPoint a OpenDocument, zadávat otevírací hesla, řídit načítání zdrojů a snižovat využití paměti pomocí Aspose.Slides pro PHP via Java."
---
## **Úvod**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/cs/php-java/) může načítat prezentace PowerPoint a OpenDocument ze souborů a streamů. Po načtení prezentace můžete prozkoumat její strukturu, upravovat snímky, spravovat zdroje a uložit ji v původním nebo jiném podporovaném formátu.

Chování načítání lze přizpůsobit pomocí třídy [LoadOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/) . Například můžete zadat otevírací heslo, uchovávat velké binární objekty mimo paměť haldy Java, řídit externí zdroje nebo vynechat vložená binární data.

## **Otevření prezentací**

Chcete-li otevřít existující prezentaci, předáte její cestu k souboru konstruktoru [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) . Po použití prezentaci uvolněte, aby byly souborové handly, dočasná data a další zdroje rychle uvolněny.

Následující příklad v PHP ukazuje, jak otevřít prezentaci a získat počet snímků:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Otevření heslem chráněných prezentací**

Otevírací heslo šifruje obsah prezentace. Pro načtení celé prezentace předáte správné heslo metodě [LoadOptions::setPassword](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setPassword) a poskytnete možnosti konstruktoru [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) . Načtení selže, pokud heslo chybí nebo je nesprávné.

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

Pro detekci hesla, ověřování a šifrovací pracovní postupy viz [Password-Protect Presentations](/slides/cs/php-java/password-protected-presentation/). Pokud byla šifrovaná prezentace úmyslně uložena s veřejnými vlastnostmi dokumentu, lze tyto vlastnosti číst bez hesla; viz [Manage Presentation Properties](/slides/cs/php-java/presentation-properties/).

## **Otevření velkých prezentací**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) vrací možnosti, které řídí, jak Aspose.Slides zachází s velkými binárními objekty, jako jsou obrázky, audio a video. Můžete nechat zdrojový soubor zamčený, povolit dočasné soubory a omezit množství BLOB dat uchovávaných v paměti.

Následující kód v PHP demonstruje načtení velké prezentace (například 2 GB):

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
S [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked) zůstane zdrojový soubor zamčený, dokud není instance prezentace uvolněna. Nepřesouvejte, nepřepisujte ani neodstraňujte zdrojový soubor, dokud je tato instance aktivní.

Aspose.Slides může během načítání kopírovat obsah vstupního streamu. U velkých prezentací je proto cesta k souboru obecně efektivnější než stream. Viz [Manage BLOBs](/slides/cs/php-java/manage-blob/) pro další možnosti úložiště a správy paměti.
{{% /alert %}}

## **Řízení externích zdrojů**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) přijímá implementaci rozhraní Java [IResourceLoadingCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iresourceloadingcallback/) prostřednictvím PHP/Java Bridge. Callback může poskytnout náhradní data, přesměrovat zdroj, použít výchozí načítač nebo zdroj přeskočit. To je užitečné, když prezentace obsahují externí obrázky, které je třeba vyřešit podle specifických bezpečnostních nebo úložných pravidel aplikace.

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

## **Načtení prezentací bez vložených binárních objektů**

Prezentace může obsahovat vložená binární data, která aplikace nepotřebuje nebo si nepřeje zachovat. Příklady zahrnují:

- projekty VBA, dostupné prostřednictvím [Presentation::getVbaProject](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getVbaProject);
- vložená data OLE, dostupná prostřednictvím [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- data ovládacích prvků ActiveX, dostupná prostřednictvím [Control::getActiveXControlBinary](https://reference.aspose.com/slides/cs/php-java/aspose.slides/control/#getActiveXControlBinary).

Nastavte [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) na `true`, aby se během načítání odstranila tato binární data. Uložte načtenou prezentaci, aby se zachoval sanitovaný výsledek.

Tato možnost snižuje vystavení nežádoucím vloženým nákladům, ale nejedná se o kompletní systém detekce škodlivého softwaru nebo sanitace obsahu.

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

## **FAQ**

**Jak mohu poznat, že soubor je poškozený a nelze jej otevřít?**

Aspose.Slides během načítání vyhodí výjimku při parsování nebo formátu. Ošetřete toto selhání samostatně od chyby nesprávného hesla, aby aplikace mohla přesně nahlásit příčinu.

**Co se stane, pokud chybí požadovaná písma?**

Prezentace se může stále načíst, ale při vykreslování a exportu může dojít k nahrazení písem. Můžete [configure font substitution](/slides/cs/php-java/font-substitution/) nebo [provide custom fonts](/slides/cs/php-java/custom-font/) pro zajištění předvídatelnějšího výstupu.

**Načítá se při načítání prezentace také její vložená média?**

Vložené audio a video jsou dostupné prostřednictvím objektového modelu prezentace. Externí zdroje jsou řešeny podle nakonfigurovaného chování načítání zdrojů a mohou být nedostupné, pokud jejich umístění není přístupné.