---
title: Otevření prezentací v PHP
linktitle: Otevřít prezentaci
type: docs
weight: 20
url: /cs/php-java/open-presentation/
keywords:
- otevřít PowerPoint
- otevřít OpenDocument
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
description: "Jednoduše otevřete prezentace PowerPoint (.pptx, .ppt) a OpenDocument (.odp) pomocí Aspose.Slides pro PHP přes Java — rychlé, spolehlivé, plně vybavené."
---
## **Úvod**

Kromě vytváření prezentací PowerPoint od nuly umožňuje Aspose.Slides také otevírat existující prezentace. Po načtení prezentace můžete získat o ní informace, upravit obsah snímků, přidat nové snímky, odebrat existující a další.

## **Otevření prezentací**

Chcete-li otevřít existující prezentaci, vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a jako argument předávejte cestu k souboru.

Následující příklad v PHP ukazuje, jak otevřít prezentaci a získat počet snímků:

```php
// Vytvořte instanci třídy Presentation a předávejte cestu k souboru do jejího konstruktoru.
$presentation = new Presentation("Sample.pptx");
try {
    // Zobrazte celkový počet snímků v prezentaci.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```

## **Otevření prezentací chráněných heslem**

Když potřebujete otevřít prezentaci chráněnou heslem, předejte heslo metodou [setPassword](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setPassword) třídy [LoadOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/). Tím prezentaci dešifrujete a načtete. Následující kód v PHP demonstruje tuto operaci:

```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // Proveďte operace na dešifrované prezentaci.
} finally {
    $presentation->dispose();
}
```

## **Otevření velkých prezentací**

Aspose.Slides poskytuje možnosti — zejména metodu [getBlobManagementOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) ve třídě [LoadOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/) — které vám pomohou načíst velké prezentace.

Následující kód v PHP ukazuje načtení velké prezentace (například 2 GB):

```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Vyberte chování KeepLocked — soubor prezentace zůstane uzamčen po celou dobu
// instance Presentation, ale není nutné ji načítat do paměti ani kopírovat do dočasného souboru.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // Velká prezentace byla načtena a může být použita, přičemž spotřeba paměti zůstává nízká.

    // Proveďte změny v prezentaci.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // Uložte prezentaci do jiného souboru. Spotřeba paměti zůstává nízká během této operace.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// Nedo dělejte to! Bude vyvolána I/O výjimka, protože soubor je uzamčen, dokud není objekt prezentace uvolněn.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// Je v pořádku to udělat zde. Zdrojový soubor již není uzamčen objektem prezentace.
unlink($filePath);
```

{{% alert color="info" title="Info" %}}
Pro obejití některých omezení při práci se streamy může Aspose.Slides kopírovat obsah streamu. Načtení velké prezentace ze streamu způsobí kopírování prezentace a může zpomalit načítání. Proto, když potřebujete načíst velkou prezentaci, důrazně doporučujeme použít cestu k souboru prezentace místo streamu.

Při vytváření prezentace, která obsahuje velké objekty (video, audio, obrázky ve vysokém rozlišení atd.), můžete použít [BLOB management](/slides/cs/php-java/manage-blob/) ke snížení spotřeby paměti.
{{%/alert %}}

## **Řízení externích zdrojů**

Aspose.Slides poskytuje rozhraní [IResourceLoadingCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iresourceloadingcallback/), které vám umožňuje spravovat externí zdroje. Následující kód v PHP ukazuje, jak použít rozhraní `IResourceLoadingCallback`:

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // Načíst náhradní obrázek.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // Nastavit náhradní URL.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // Přeskočit všechny ostatní obrázky.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```

## **Načtení prezentací bez vložených binárních objektů**

Prezentace PowerPoint může obsahovat následující typy vložených binárních objektů:

- VBA projekt (přístupný přes [Presentation.getVbaProject](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getVbaProject));
- Data vložená v OLE objektu (přístupná přes [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- Binární data ovládacího prvku ActiveX (přístupná přes [Control.getActiveXControlBinary](https://reference.aspose.com/slides/cs/php-java/aspose.slides/control/#getActiveXControlBinary)).

Pomocí metody [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) můžete načíst prezentaci bez jakýchkoli vložených binárních objektů.

Tato metoda je užitečná pro odstranění potenciálně škodlivého binárního obsahu. Následující kód v PHP demonstruje, jak načíst prezentaci bez jakéhokoli vloženého binárního obsahu:

```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // Proveďte operace na prezentaci.
} finally {
    $presentation->dispose();
}
```

## **Často kladené otázky**

**Jak zjistím, že soubor je poškozený a nelze jej otevřít?**

Během načítání získáte výjimku při parsování/validaci formátu. Takové chyby často uvádějí neplatnou strukturu ZIP nebo poškozené záznamy PowerPointu.

**Co se stane, pokud při otevírání chybí požadovaná písma?**

Soubor se otevře, ale později může při [renderování/exportu](/slides/cs/php-java/convert-presentation/) dojít k náhradě písem. [Nakonfigurujte náhrady písem](/slides/cs/php-java/font-substitution/) nebo [přidejte požadovaná písma](/slides/cs/php-java/custom-font/) do běhového prostředí.

**Jak je to s vloženými médii (video/audio) při otevírání?**

Stanou se dostupnými jako zdroje prezentace. Pokud jsou média odkazována přes externí cesty, zajistěte, aby tyto cesty byly přístupné ve vašem prostředí; jinak může [renderování/export](/slides/cs/php-java/convert-presentation/) média vynechat.