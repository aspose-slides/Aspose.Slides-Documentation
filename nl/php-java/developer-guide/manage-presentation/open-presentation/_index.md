---
title: Presentaties openen in PHP
linktitle: Open Presentatie
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
- binair object
- PHP
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties kunt openen in PHP, openingswachtwoorden kunt opgeven, het laden van bronnen kunt beheren en het geheugenverbruik kunt verminderen met Aspose.Slides voor PHP via Java."
---
## **Introductie**

[Aspose.Slides voor PHP via Java](https://products.aspose.com/slides/nl/php-java/) kan PowerPoint- en OpenDocument-presentaties laden vanuit bestanden en streams. Nadat een presentatie is geladen, kun je de structuur inspecteren, dia's bewerken, bronnen beheren en deze opslaan in het oorspronkelijke of een ander ondersteund formaat.

Het laadgedrag kan worden aangepast via de LoadOptions-klasse. Je kunt bijvoorbeeld een openings-wachtwoord opgeven, grote binaire objecten buiten het Java-heapgeheugen houden, externe bronnen beheren of ingebedde binaire gegevens weglaten.

## **Presentaties openen**

Nadat je een bestand of stream hebt geladen, kun je het oorspronkelijke presentatieformaat bepalen om te kiezen hoe je applicatie het verwerkt.

Om een bestaande presentatie te openen, geef je het bestandspad door aan de Presentation-constructor. Dispose de presentatie na gebruik zodat bestands-handles, tijdelijke gegevens en andere bronnen snel worden vrijgegeven.

Het volgende PHP-voorbeeld laat zien hoe je een presentatie opent en het aantal dia's ophaalt:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Wachtwoordbeveiligde presentaties openen**

Een openings-wachtwoord versleutelt de inhoud van de presentatie. Om de volledige presentatie te laden, geef je het juiste wachtwoord door aan LoadOptions::setPassword en lever je de opties aan de Presentation-constructor. Het laden mislukt wanneer het wachtwoord ontbreekt of onjuist is.

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

Voor wachtwoorddetectie, -validatie en -versleutelings-workflows, zie [Presentaties met wachtwoord beveiligen](/slides/nl/php-java/password-protected-presentation/). Als een versleutelde presentatie opzettelijk is opgeslagen met openbare documenteigenschappen, kunnen die eigenschappen gelezen worden zonder wachtwoord; zie [Presentatie-eigenschappen beheren](/slides/nl/php-java/presentation-properties/).

## **Grote presentaties openen**

LoadOptions::getBlobManagementOptions retourneert opties die bepalen hoe Aspose.Slides grote binaire objecten (BLOB's) zoals afbeeldingen, audio en video verwerkt. Je kunt het bronbestand vergrendeld houden, tijdelijke bestanden toestaan en de hoeveelheid BLOB-gegevens die in het geheugen worden bewaard beperken.

De volgende PHP-code toont het laden van een grote presentatie (bijvoorbeeld 2 GB):

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

Met PresentationLockingBehavior::KeepLocked blijft het bronbestand vergrendeld totdat de presentatie‑instantie wordt disposed. Verplaats, overschrijf of verwijder het bronbestand niet terwijl die instantie actief is.

Aspose.Slides kan bij het laden de inhoud van een invoer-stream kopiëren. Voor grote presentaties is een bestandspad over het algemeen efficiënter dan een stream. Zie [BLOB’s beheren](/slides/nl/php-java/manage-blob/) voor extra opslag- en geheugemanagement-opties.

{{% /alert %}}

## **Externe bronnen beheren**

LoadOptions::setResourceLoadingCallback accepteert een implementatie van de Java-interface IResourceLoadingCallback via PHP/Java Bridge. De callback kan vervangende gegevens leveren, een bron omleiden, de standaardloader gebruiken of de bron overslaan. Dit is nuttig wanneer presentaties externe afbeeldingen bevatten die volgens toepassingsspecifieke beveiligings- of opslagregels moeten worden opgelost.

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

Een presentatie kan ingebedde binaire gegevens bevatten die een applicatie niet nodig heeft of niet wil behouden. Voorbeelden zijn:

- VBA-projecten, beschikbaar via Presentation::getVbaProject;
- ingebedde OLE-gegevens, beschikbaar via OleEmbeddedDataInfo::getEmbeddedFileData;
- ActiveX-controlegegevens, beschikbaar via Control::getActiveXControlBinary.

Stel LoadOptions::setDeleteEmbeddedBinaryObjects in op `true` om deze binaire gegevens tijdens het laden te verwijderen. Sla de geladen presentatie op om het opgeschoonde resultaat te behouden.

Deze optie vermindert de blootstelling aan ongewenste ingebedde payloads, maar is geen volledige malware-detectie- of inhoudssanitisatiesysteem.

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

**Hoe kan ik zien dat een bestand corrupt is en niet geopend kan worden?**

Aspose.Slides geeft tijdens het laden een parse- of formaat-exception. Verwerk deze fout apart van een onjuiste-wachtwoord-fout zodat de applicatie de oorzaak nauwkeurig kan melden.

**Wat gebeurt er als vereiste lettertypen ontbreken?**

De presentatie kan nog steeds worden geladen, maar weergave en export kunnen lettertypen vervangen. Je kunt [lettertype-substitutie configureren](/slides/nl/php-java/font-substitution/) of [aangepaste lettertypen leveren](/slides/nl/php-java/custom-font/) om de output voorspelbaarder te maken.

**Laadt het laden van een presentatie ook de ingebedde media?**

Ingebedde audio en video worden beschikbaar via het presentatiemodel. Externe bronnen worden opgelost volgens het geconfigureerde resource-laadgedrag en kunnen onbeschikbaar zijn als hun locaties niet toegankelijk zijn.