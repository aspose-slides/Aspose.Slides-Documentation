---
title: Öppna presentationer i PHP
linktitle: Öppna presentation
type: docs
weight: 20
url: /sv/php-java/open-presentation/
keywords:
- öppna PowerPoint
- öppna OpenDocument
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
description: "Öppna PowerPoint (.pptx, .ppt) och OpenDocument (.odp) presentationer enkelt med Aspose.Slides för PHP via Java - snabbt, pålitligt, fullt utrustat."
---
## **Introduktion**

Förutom att skapa PowerPoint‑presentationer från grunden låter Aspose.Slides dig även öppna befintliga presentationer. När en presentation har lästs in kan du hämta information om den, redigera bildinnehåll, lägga till nya bilder, ta bort befintliga och mycket mer.

## **Öppna presentationer**

För att öppna en befintlig presentation, skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) och skicka filvägen till dess konstruktor.

Följande PHP‑exempel visar hur du öppnar en presentation och får antalet bilder:

```php
// Instansiera Presentation-klassen och skicka en filsökväg till dess konstruktor.
$presentation = new Presentation("Sample.pptx");
try {
    // Skriv ut det totala antalet bilder i presentationen.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```

## **Öppna lösenordsskyddade presentationer**

När du behöver öppna en lösenordsskyddad presentation, ange lösenordet via metoden [setPassword](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setPassword) i klassen [LoadOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/) för att dekryptera och läsa in den. Följande PHP‑kod demonstrerar denna operation:

```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // Utför operationer på den dekrypterade presentationen.
} finally {
    $presentation->dispose();
}
```

## **Öppna stora presentationer**

Aspose.Slides erbjuder alternativ – särskilt metoden [getBlobManagementOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) i klassen [LoadOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/) – för att hjälpa dig läsa in stora presentationer.

Följande PHP‑kod demonstrerar inläsning av en stor presentation (t.ex. 2 GB):

```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Välj KeepLocked-beteendet - presentationsfilen förblir låst under hela
// Presentation-instansen, men den behöver inte läsas in i minnet eller kopieras till en temporär fil.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // Den stora presentationen har lästs in och kan användas, medan minnesförbrukningen förblir låg.

    // Gör ändringar i presentationen.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // Spara presentationen till en annan fil. Minnesförbrukningen förblir låg under denna operation.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// Gör inte detta! Ett I/O-undantag kommer att kastas eftersom filen är låst tills presentationsobjektet har frigjorts.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// Det är okej att göra det här. Källfilen är inte längre låst av presentationsobjektet.
unlink($filePath);
```

{{% alert color="info" title="Info" %}}
För att kringgå vissa begränsningar när du arbetar med strömmar kan Aspose.Slides kopiera en strömms innehåll. Att läsa in en stor presentation från en ström innebär att presentationen kopieras, vilket kan sakta ner inläsningen. Därför rekommenderar vi starkt att du använder presentationsfilens sökväg istället för en ström när du behöver läsa in en stor presentation.

När du skapar en presentation som innehåller stora objekt (video, ljud, högupplösta bilder osv.) kan du använda [BLOB‑hantering](/slides/sv/php-java/manage-blob/) för att minska minnesförbrukningen.
{{%/alert %}}

## **Kontrollera externa resurser**

Aspose.Slides tillhandahåller gränssnittet [IResourceLoadingCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iresourceloadingcallback/) som låter dig hantera externa resurser. Följande PHP‑kod visar hur du använder gränssnittet `IResourceLoadingCallback`:

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // Läs in en ersättningsbild.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // Ange en ersättnings-URL.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // Hoppa över alla andra bilder.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```

## **Läs in presentationer utan inbäddade binära objekt**

En PowerPoint‑presentation kan innehålla följande typer av inbäddade binära objekt:

- VBA‑projekt (åtkomligt via [Presentation.getVbaProject](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getVbaProject));
- OLE‑objekt med inbäddade data (åtkomligt via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/sv/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- ActiveX‑kontroll binär data (åtkomligt via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/sv/php-java/aspose.slides/control/#getActiveXControlBinary)).

Genom att använda metoden [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) kan du läsa in en presentation utan några inbäddade binära objekt.

Denna metod är användbar för att ta bort potentiellt skadligt binärt innehåll. Följande PHP‑kod demonstrerar hur du läser in en presentation utan inbäddat binärt innehåll:

```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // Utför operationer på presentationen.
} finally {
    $presentation->dispose();
}
```

## **Vanliga frågor**

**Hur kan jag avgöra att en fil är korrupt och inte kan öppnas?**

Du får ett undantag för parsning/formatvalidering under inläsning. Sådana fel nämner ofta en ogiltig ZIP‑struktur eller trasiga PowerPoint‑poster.

**Vad händer om nödvändiga teckensnitt saknas vid öppning?**

Filen öppnas, men senare [rendering/export](/slides/sv/php-java/convert-presentation/) kan ersätta teckensnitten. [Konfigurera teckensnittsersättningar](/slides/sv/php-java/font-substitution/) eller [lägg till de nödvändiga teckensnitten](/slides/sv/php-java/custom-font/) i körmiljön.

**Hur hanteras inbäddade medier (video/ljud) vid öppning?**

De blir tillgängliga som presentationsresurser. Om medier refereras via externa sökvägar, se till att dessa sökvägar är åtkomliga i din miljö; annars kan [rendering/export](/slides/sv/php-java/convert-presentation/) utelämna dem.