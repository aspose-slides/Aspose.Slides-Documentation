---
title: Öppna presentationer i PHP
linktitle: Öppna presentation
type: docs
weight: 20
url: /sv/php-java/open-presentation/
keywords:
- öppna PowerPoint
- öppna presentation
- öppna PPTX
- öppna PPT
- öppna ODP
- ladda presentation
- ladda PPTX
- ladda PPT
- ladda ODP
- skyddad presentation
- stor presentation
- extern resurs
- binärt objekt
- PHP
- Aspose.Slides
description: "Lär dig hur du öppnar PowerPoint- och OpenDocument-presentationer i PHP, anger öppningslösenord, styr resursladdning och minskar minnesanvändning med Aspose.Slides för PHP via Java."
---
## **Introduktion**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/sv/php-java/) kan läsa in PowerPoint- och OpenDocument-presentationer från filer och strömmar. Efter att en presentation har lästs in kan du undersöka dess struktur, redigera bilder, hantera resurser och spara den i det ursprungliga eller ett annat stödt format.

Inläsningsbeteendet kan anpassas via klassen [LoadOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/). Till exempel kan du ange ett öppningslösenord, hålla stora binära objekt utanför Java-heapminnet, kontrollera externa resurser eller utelämna inbäddade binära data.

## **Öppna presentationer**

För att öppna en befintlig presentation, skicka dess filsökväg till konstruktorn [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/). Avsluta presentationen efter användning så att filhandtag, temporära data och andra resurser frigörs omedelbart.

Följande PHP-exempel visar hur du öppnar en presentation och hämtar antalet bilder:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Öppna lösenordsskyddade presentationer**

Ett öppningslösenord krypterar presentationsinnehållet. För att läsa in hela presentationen, skicka det korrekta lösenordet till [LoadOptions::setPassword](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setPassword) och ge alternativen till konstruktorn [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/). Inläsning misslyckas när lösenordet saknas eller är felaktigt.

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

För lösenorddetektering, validering och krypteringsarbetsflöden, se [Password-Protect Presentations](/slides/sv/php-java/password-protected-presentation/). Om en krypterad presentation medvetet sparats med offentliga dokumentegenskaper, kan dessa egenskaper läsas utan lösenord; se [Manage Presentation Properties](/slides/sv/php-java/presentation-properties/).

## **Öppna stora presentationer**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) returnerar alternativ som styr hur Aspose.Slides hanterar stora binära objekt såsom bilder, ljud och video. Du kan behålla källfilen låst, tillåta temporära filer och begränsa mängden BLOB-data som behålls i minnet.

Följande PHP-kod demonstrerar inläsning av en stor presentation (t.ex. 2 GB):

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

{{% alert color="info" title="Obs" %}}
Med [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked) förblir källfilen låst tills presentation‑instansen avskrivs. Flytta, skriv över eller ta inte bort källfilen medan den instansen är aktiv.

Aspose.Slides kan kopiera innehållet i en inmatningsström under inläsning. För stora presentationer är en filsökväg därför generellt mer effektiv än en ström. Se [Manage BLOBs](/slides/sv/php-java/manage-blob/) för ytterligare lagrings‑ och minneshanteringsalternativ.
{{% /alert %}}

## **Styr externa resurser**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) accepterar en implementation av Java‑gränssnittet [IResourceLoadingCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iresourceloadingcallback/) via PHP/Java Bridge. Återanropet kan tillhandahålla ersättningsdata, omdirigera en resurs, använda standardladdaren eller hoppa över resursen. Detta är användbart när presentationer innehåller externa bilder som måste lösas enligt applikationsspecifika säkerhets‑ eller lagringsregler.

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

## **Läs in presentationer utan inbäddade binära objekt**

En presentation kan innehålla inbäddade binära data som en applikation varken behöver eller vill behålla. Exempel inkluderar:

- VBA‑projekt, tillgängliga via [Presentation::getVbaProject](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getVbaProject);
- inbäddade OLE‑data, tillgängliga via [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/sv/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ActiveX‑kontrolldata, tillgängliga via [Control::getActiveXControlBinary](https://reference.aspose.com/slides/sv/php-java/aspose.slides/control/#getActiveXControlBinary).

Ställ in [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) till `true` för att ta bort dessa binära data vid inläsning. Spara den inlästa presentationen för att behålla det sanerade resultatet.

Detta alternativ minskar exponeringen för oönskade inbäddade data, men det är inte ett fullständigt system för malware‑detektering eller innehållssanering.

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

**Hur kan jag avgöra att en fil är skadad och inte kan öppnas?**

Aspose.Slides kastar ett pars‑ eller formatfel vid inläsning. Hantera detta fel separat från ett felmeddelande om fel lösenord så att applikationen kan rapportera orsaken korrekt.

**Vad händer om nödvändiga teckensnitt saknas?**

Presentationen kan fortfarande läsas in, men rendering och export kan ersätta teckensnitt. Du kan [configure font substitution](/slides/sv/php-java/font-substitution/) eller [provide custom fonts](/slides/sv/php-java/custom-font/) för att göra resultatet mer förutsägbart.

**Laddas en presentation också med dess inbäddade media?**

Inbäddat ljud och video blir tillgängliga via presentationens objektmodell. Externa resurser löses upp enligt den konfigurerade resursladdningsbeteendet och kan vara otillgängliga om deras platser inte kan nås.