---
title: Open Presentaties in PHP
linktitle: Open Presentatie
type: docs
weight: 20
url: /nl/php-java/open-presentation/
keywords:
- open PowerPoint
- open OpenDocument
- open presentatie
- open PPTX
- open PPT
- open ODP
- laad presentatie
- laad PPTX
- laad PPT
- laad ODP
- beveiligde presentatie
- grote presentatie
- externe bron
- binair object
- PHP
- Aspose.Slides
description: "Open PowerPoint (.pptx, .ppt) en OpenDocument (.odp) presentaties moeiteloos met Aspose.Slides voor PHP via Java — snel, betrouwbaar, volledig uitgerust."
---
## **Inleiding**

Naast het creëren van PowerPoint‑presentaties vanaf nul, stelt Aspose.Slides u ook in staat om bestaande presentaties te openen. Na het laden van een presentatie kunt u informatie erover ophalen, slide‑inhoud bewerken, nieuwe slides toevoegen, bestaande verwijderen, en meer.

## **Presentaties openen**

Om een bestaande presentatie te openen, maakt u een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse en geeft u het bestandspad door aan de constructor.

Het volgende PHP‑voorbeeld laat zien hoe u een presentatie opent en het aantal slides ophaalt:

```php
// Maak een exemplaar van de Presentation‑klasse en geef een bestandspad door aan de constructor.
$presentation = new Presentation("Sample.pptx");
try {
    // Print het totale aantal slides in de presentatie.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```

## **Wachtwoordbeveiligde presentaties openen**

Wanneer u een wachtwoordbeveiligde presentatie moet openen, geeft u het wachtwoord door aan de [setPassword](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setPassword)‑methode van de [LoadOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/)‑klasse om deze te ontsleutelen en te laden. Het volgende PHP‑codefragment demonstreert deze bewerking:

```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // Voer bewerkingen uit op de ontcijferde presentatie.
} finally {
    $presentation->dispose();
}
```

## **Grote presentaties openen**

Aspose.Slides biedt opties—met name de [getBlobManagementOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#getBlobManagementOptions)‑methode in de [LoadOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/)‑klasse—om u te helpen grote presentaties te laden.

De volgende PHP‑code demonstreert het laden van een grote presentatie (bijvoorbeeld 2 GB):

```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Kies het KeepLocked‑gedrag — het presentiebestand blijft vergrendeld gedurende de levensduur van
// het Presentation‑object, maar het hoeft niet in het geheugen geladen te worden of gekopieerd naar een tijdelijk bestand.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // De grote presentatie is geladen en kan worden gebruikt, terwijl het geheugenverbruik laag blijft.

    // Breng wijzigingen aan in de presentatie.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // Sla de presentatie op naar een ander bestand. Het geheugenverbruik blijft laag tijdens deze bewerking.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
    
    // Doe dit niet! Er wordt een I/O‑exception gegooid omdat het bestand vergrendeld blijft tot het Presentation‑object wordt vrijgegeven.
    //unlink($filePath);
} finally {
    $presentation->dispose();
}
// Het is hier wel OK om dit te doen. Het bronbestand is niet langer vergrendeld door het Presentation‑object.
unlink($filePath);
```

{{% alert color="info" title="Info" %}}
Om bepaalde beperkingen bij het werken met streams te omzeilen, kan Aspose.Slides de inhoud van een stream kopiëren. Het laden van een grote presentatie vanuit een stream zorgt ervoor dat de presentatie wordt gekopieerd, wat het laden kan vertragen. Daarom raden wij sterk aan om, wanneer u een grote presentatie moet laden, het bestandspad van de presentatie te gebruiken in plaats van een stream.

Bij het maken van een presentatie met grote objecten (video, audio, afbeeldingen met hoge resolutie, enz.) kunt u [BLOB management](/slides/nl/php-java/manage-blob/) gebruiken om het geheugenverbruik te verminderen.
{{%/alert %}}

## **Externe bronnen beheren**

Aspose.Slides levert de [IResourceLoadingCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iresourceloadingcallback/)‑interface waarmee u externe bronnen kunt beheren. De volgende PHP‑code toont hoe u de `IResourceLoadingCallback`‑interface gebruikt:

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // Laad een vervangende afbeelding.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // Stel een vervangende URL in.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // Sla alle andere afbeeldingen over.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```

## **Presentaties laden zonder ingebedde binaire objecten**

Een PowerPoint‑presentatie kan de volgende typen ingebedde binaire objecten bevatten:

- VBA‑project (toegankelijk via [Presentation.getVbaProject](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getVbaProject));
- OLE‑object ingebedde data (toegankelijk via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nl/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- ActiveX‑besturingselement binaire data (toegankelijk via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/nl/php-java/aspose.slides/control/#getActiveXControlBinary)).

Met behulp van de [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects)‑methode kunt u een presentatie laden zonder enige ingebedde binaire objecten.

Deze methode is handig om potentieel kwaadaardige binaire inhoud te verwijderen. De volgende PHP‑code demonstreert hoe u een presentatie laadt zonder enige ingebedde binaire inhoud:

```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // Voer bewerkingen uit op de presentatie.
} finally {
    $presentation->dispose();
}
```

## **Veelgestelde vragen**

**Hoe kan ik herkennen dat een bestand corrupt is en niet geopend kan worden?**

U krijgt tijdens het laden een parse‑/formaatvalidatie‑exception. Dergelijke fouten wijzen vaak op een ongeldige ZIP‑structuur of beschadigde PowerPoint‑records.

**Wat gebeurt er als vereiste lettertypen ontbreken bij het openen?**

Het bestand wordt geopend, maar later kan [rendering/export](/slides/nl/php-java/convert-presentation/) lettertypen vervangen. [Configure font substitutions](/slides/nl/php-java/font-substitution/) of [add the required fonts](/slides/nl/php-java/custom-font/) aan de runtime‑omgeving.

**Hoe zit het met ingebedde media (video/audio) bij het openen?**

Ze worden beschikbaar als presentatieresources. Als media via externe paden worden weergegeven, zorg er dan voor dat die paden toegankelijk zijn in uw omgeving; anders kan [rendering/export](/slides/nl/php-java/convert-presentation/) de media weglaten.