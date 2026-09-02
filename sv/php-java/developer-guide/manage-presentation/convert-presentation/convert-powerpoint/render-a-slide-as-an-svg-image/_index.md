---
title: Rendera presentationsbilder som SVG-bilder i PHP
linktitle: Bild till SVG
type: docs
weight: 50
url: /sv/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint till SVG
- presentation till SVG
- bild till SVG
- PPT till SVG
- PPTX till SVG
- SVG-exportalternativ
- interaktiv SVG
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Exportera PowerPoint-bilder som SVG-bilder i PHP och kontrollera teckensnitt, text, bilder, ID:n och händelser med Aspose.Slides."
---
## **Översikt**

SVG är ett skalbart XML-baserat bildformat som fungerar bra för webbpublicering, bildspelsvisare, tillgänglighetsflöden och automatiserad efterbehandling. Aspose.Slides exporterar varje bild till en separat SVG-fil och låter dig styra hur text, teckensnitt, bilder och SVG-element skrivs.

Använd [SVGOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgoptions/) när den exporterade SVG:n måste vara kompakt, förutsägbar i olika webbläsare eller klar för interaktiv användning.

## **Exportera en bild som SVG**

Skapa en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/), välj en bild och skriv den till en ström med [Slide.writeAsSvg](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#writeAsSvg). Följande exempel exporterar varje bild i en presentation som en separat SVG-fil.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Filnamnet använder [Slide.getSlideNumber](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getSlideNumber) istället för slingan index. Du kan också exportera en enskild form med [Shape.writeAsSvg](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#writeAsSvg) när en bildvisare eller webbsida bara behöver den formen.

## **Konfigurera SVG-utmatning**

[SVGOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgoptions/) styr SVG-renderingen. För textramar inkluderar [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgoptions/#setUseFrameSize) textramen i renderingsområdet, och [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgoptions/#setUseFrameRotation) bestämmer om ramens rotation tillämpas. Ställ in [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) till `true` när texten måste renderas utan ligaturer.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Styr text och teckensnitt**

### **Vektorisera all text**

Ställ in [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgoptions/#setVectorizeText) till `true` för att skriva all bildtext som vektorgrafik. Detta eliminerar beroenden av teckensnitt och gör det visuella resultatet mer konsistent i olika webbläsare, men texten kan inte längre markeras eller sökas som SVG-text.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **Välj hur externa teckensnitt hanteras**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) använder ett [SvgExternalFontsHandling](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgexternalfontshandling/)‑värde för teckensnitt som läses in externt. Välj `AddLinksToFontFiles` för att referera till separata teckensnittsfiler, `Embed` för att inkludera teckensnittsdata i SVG:n, eller `Vectorize` för att rendera endast text som använder externa teckensnitt som grafik. Verifiera teckensnittslicenser innan du bäddar in teckensnitt.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Minska inbäddad bildstorlek**

Använd [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgoptions/#setPicturesCompression) för att minska upplösningen på inbäddade bilder, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) för att utelämna beskurna källområden, och [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgoptions/#setJpegQuality) för att styra JPEG‑kodningskvaliteten. Dessa inställningar minskar filstorleken på bekostnad av bildkvalitet eller bevarade bilddata.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Tilldela stabila ID:n till former och text**

Tillhandahåll en formateringscallback till [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgoptions/#setShapeFormattingController) för att sätta [SvgShape.setId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgshape/#setId) för varje SVG-form. Callbacken kan också sätta [SvgTSpan.setId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgtspan/#setId)‑värden på text‑`tspan`‑element.

PhpJavaBridge kan inte anropa ett PHP‑callback från `writeAsSvg` när den kör i strömläge. Placera formateringslogiken i en liten Java‑hjälparklass, kompilera den och lägg till den resulterande JAR‑filen i bryggans klassökväg. Hjälparen kan använda [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getOfficeInteropShapeId), som är stabil under formens livstid, samt en återupprepningsbar räknare för dess text‑spans. Se [Java‑implementation av `StableSvgIdController`](/slides/sv/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) för hjälparkoden.

Efter att ha lagt till den kompilerade `com.example.slides.StableSvgIdController`‑klassen i bryggans klassökväg, skapa en instans av den från PHP och tilldela den till `SVGOptions`:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Lägg till SVG‑händelsehanterare**

I en formateringscallback, anropa [SvgShape.setEventHandler](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgshape/#setEventHandler) med ett [SvgEvent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgevent/)‑värde för att lägga till en JavaScript‑händelsehanterare till en exporterad form. Tilldela callbacken med [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgoptions/#setShapeFormattingController) och definiera JavaScript‑funktionen på sidan eller i SVG‑dokumentet som innehåller resultatet.

På samma sätt som med stabila ID:n, implementera callbacken i en Java‑hjälpare när PhpJavaBridge använder strömläge. [Java‑implementation av `SvgEventController`](/slides/sv/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) tilldelar ett ID och en `OnClick`‑handler till en form med namnet `ActionButton`. Kompilera den hjälparen, lägg till den i bryggans klassökväg som `com.example.slides.SvgEventController`, och använd den från PHP enligt följande:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

Värdsidan kan definiera JavaScript‑funktionen som refereras av handlern. Tilldelning av ID:n och händelsehanterare möjliggör bildvisare, förbättrad tillgänglighet och andra interaktiva SVG‑arbetsflöden.

## **FAQ**

**När bör jag använda [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgoptions/#setVectorizeText) istället för [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgexternalfontshandling/)?**

Använd [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgoptions/#setVectorizeText) när all text måste vara oberoende av teckensnitt. Använd [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgexternalfontshandling/) när endast text som använder externa teckensnitt ska konverteras till grafik.

**Vad är det bästa sättet att göra en SVG mindre?**

Börja med att komprimera inbäddade bilder, ta bort beskurna bildområden och välja länkade teckensnittsfiler när målmiljön kan leverera dem. Testa resultatet eftersom lägre bildupplösning, lägre JPEG‑kvalitet och vektorisering av text alla har olika kompromisser mellan kvalitet och storlek.

**Kan jag ändra exporterade SVG‑element efter export?**

Ja. Tilldela ID:n via en formateringscallback och välj sedan de matchande SVG‑elementen i ditt efterbehandlingsverktyg eller browserskript.