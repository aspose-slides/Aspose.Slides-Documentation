---
title: Presentaties openen in PHP
linktitle: Presentatie openen
type: docs
weight: 20
url: /nl/php-java/open-presentation/
keywords:
- PowerPoint openen
- presentatie openen
- PPTX openen
- PPT openen
- ODP openen
- presentatie laden
- PPTX laden
- PPT laden
- ODP laden
- beveiligde presentatie
- grote presentatie
- externe bron
- binaire object
- PHP
- Aspose.Slides
description: "Leer hoe u PowerPoint en OpenDocument presentaties in PHP kunt openen, openingswachtwoorden kunt opgeven, het laden van bronnen kunt beheersen en het geheugenverbruik kunt verminderen met Aspose.Slides voor PHP via Java."
---
## **Inleiding**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/nl/php-java/) kan PowerPoint‑ en OpenDocument‑presentaties laden vanuit bestanden en streams. Nadat een presentatie is geladen, kunt u de structuur inspecteren, dia's bewerken, bronnen beheren en deze opslaan in het originele of een ander ondersteund formaat.

Het laadgedrag kan worden aangepast via de [LoadOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/)‑klasse. U kunt bijvoorbeeld een openingswachtwoord opgeven, grote binaire objecten buiten het Java‑heap‑geheugen houden, externe bronnen controleren of ingebedde binaire gegevens weglaten.

## **Presentaties openen**

Om een bestaande presentatie te openen, geeft u het bestandspad door aan de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑constructor. Maak de presentatie na gebruik vrij zodat bestands‑handles, tijdelijke gegevens en andere middelen tijdig worden vrijgegeven.

De volgende PHP‑voorbeeld toont hoe een presentatie te openen en het aantal dia's op te vragen:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Wachtwoord‑beveiligde presentaties openen**

Een openingswachtwoord versleutelt de inhoud van de presentatie. Om de volledige presentatie te laden, geeft u het correcte wachtwoord door aan [LoadOptions::setPassword](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setPassword) en levert u de opties aan de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑constructor. Het laden mislukt wanneer het wachtwoord ontbreekt of onjuist is.

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

Voor wachtwoorddetectie, validatie en versleutelingsworkflows, zie [Password‑Protect Presentations](/slides/nl/php-java/password-protected-presentation/). Als een versleutelde presentatie bewust is opgeslagen met openbare documenteigenschappen, kunnen die eigenschappen worden gelezen zonder wachtwoord; zie [Manage Presentation Properties](/slides/nl/php-java/presentation-properties/).

## **Grote presentaties openen**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) retourneert opties die bepalen hoe Aspose.Slides grote binaire objecten zoals afbeeldingen, audio en video behandelt. U kunt het bronbestand vergrendeld houden, tijdelijke bestanden toestaan en de hoeveelheid BLOB‑gegevens die in het geheugen worden bewaard beperken.

De volgende PHP‑code toont het laden van een grote presentatie (bijvoorbeeld 2 GB):

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

{{% alert color="info" title="Opmerking" %}}
Met [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked) blijft het bronbestand vergrendeld totdat de presentatie‑instance wordt vrijgegeven. Verplaats, overschrijf of verwijder het bronbestand niet terwijl die instantie leeft.

Aspose.Slides kan de inhoud van een invoerstroom kopiëren tijdens het laden. Voor grote presentaties is een bestandspad doorgaans efficiënter dan een stream. Zie [Manage BLOBs](/slides/nl/php-java/manage-blob/) voor extra opslag‑ en geheugengebruikopties.
{{% /alert %}}

## **Externe bronnen beheren**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) accepteert een implementatie van de Java‑[IResourceLoadingCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iresourceloadingcallback/)‑interface via PHP/Java Bridge. De callback kan vervangende gegevens leveren, een bron omleiden, de standaardloader gebruiken of de bron overslaan. Dit is handig wanneer presentaties externe afbeeldingen bevatten die moeten worden opgelost volgens toepassingsspecifieke beveiligings‑ of opslagregels.

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

## **Presentaties laden zonder ingebedde binaire objecten**

Een presentatie kan ingebedde binaire gegevens bevatten die een toepassing niet nodig heeft of niet wil behouden. Voorbeelden zijn:

- VBA‑projecten, toegankelijk via [Presentation::getVbaProject](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getVbaProject);
- ingebedde OLE‑gegevens, toegankelijk via [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/nl/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ActiveX‑controlegegevens, toegankelijk via [Control::getActiveXControlBinary](https://reference.aspose.com/slides/nl/php-java/aspose.slides/control/#getActiveXControlBinary).

Stel [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) in op `true` om deze binaire gegevens tijdens het laden te verwijderen. Sla de geladen presentatie vervolgens op om het opgeschoonde resultaat te behouden.

Deze optie verkleint de blootstelling aan ongewenste ingebedde payloads, maar vormt geen volledige malware‑detectie‑ of content‑sanitiseringsoplossing.

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

**Hoe kan ik bepalen dat een bestand corrupt is en niet kan worden geopend?**

Aspose.Slides gooit tijdens het laden een parse‑ of formaat‑exceptie. Verwerk deze fout apart van een onjuist‑wachtwoord‑fout zodat de applicatie de oorzaak nauwkeurig kan melden.

**Wat gebeurt er als vereiste lettertypen ontbreken?**

De presentatie kan nog steeds worden geladen, maar weergave en export kunnen lettertypen vervangen. U kunt [lettertype‑substitutie configureren](/slides/nl/php-java/font-substitution/) of [aangepaste lettertypen leveren](/slides/nl/php-java/custom-font/) om de output voorspelbaarder te maken.

**Laadt het laden van een presentatie ook de ingebedde media?**

Ingebedde audio en video worden beschikbaar via het presentatiemodel. Externe bronnen worden opgelost volgens het geconfigureerde resource‑loading‑gedrag en kunnen onbeschikbaar zijn als hun locaties niet toegankelijk zijn.