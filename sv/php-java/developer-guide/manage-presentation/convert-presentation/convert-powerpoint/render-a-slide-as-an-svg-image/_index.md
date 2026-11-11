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

SVG är ett skalbart XML-baserat bildformat som fungerar bra för webbutgivning, bildspelvisare, tillgänglighetsarbetsflöden och automatiserad efterbehandling. Aspose.Slides exporterar varje bild till en separat SVG-fil och låter dig kontrollera hur text, teckensnitt, bilder och SVG-element skrivs.

Använd [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) när den exporterade SVG-filen måste vara kompakt, förutsägbar i olika webbläsare eller klar för interaktiv användning.

## **Exportera en bild som SVG**

Skapa en [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), välj en bild och skriv den till en ström med [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg). Följande exempel exporterar varje bild i en presentation som en separat SVG-fil.

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

Filnamnet använder [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) istället för loopindexet. Du kan också exportera en enskild form med [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) när en bildvisare eller webbsida bara behöver den formen.

## **Konfigurera SVG-utdata**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) styr SVG-rendering. För textramar inkluderar [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) textramen i renderingsområdet, och [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) bestämmer om ramrotationen appliceras. Ställ in [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) till `true` när text måste renderas utan ligaturer.

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

## **Kontrollera beskärning i linjeslut vid pilspetsar**

SVG 1.1 har ingen markeringsinställning för att ange var en linje ska stoppas under en pilspets. Som standard förkortar Aspose.Slides den exporterade linjen så att dess streck inte sticker ut genom markören. Anropa [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) med `true` för att rita strecket hela vägen till linjens ursprungliga slutpunkt. Denna inställning påverkar endast SVG-utdata. Linjen behåller sin position och längd på bilden.

Exemplet ritar triangel- och diamantpilspetsar på linjer 2 respektive 10 punkter breda. Det exporterar samma bild två gånger, där endast beskärningsalternativet ändras.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

Jämförelsen visar den triangulära pilspetsen på 10‑punktslinjen. Med beskärning aktiverad är spetsen skarp. Med beskärning inaktiverad sticker strecket ut genom markörens sluttande sidor och lämnar ett platt slut.

![Förstorad 10‑punkts triangel med en skarp spets när beskärning är aktiverad och ett platt slut när beskärning är inaktiverad](line-end-cropping.png)

I de andra linjerna från exemplet är det protruderande strecket mindre synligt på 2‑punkts triangeln. Den fyllda diamanten täcker streckets slut vid båda bredderna.

## **Kontrollera text och teckensnitt**

När du exporterar bilder till SVG kan du kontrollera om text förblir som text eller konverteras till vektorgrafik, och hur externa teckensnitt inkluderas eller refereras. Följande alternativ hjälper dig balansera visuell konsistens, textval och teckensnittsbegrepp i den exporterade SVG:n.

### **Vektorisera all text**

Ställ in [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) till `true` för att skriva all bildtext som vektorgrafik. Detta eliminerar teckensnittsbegrepp och gör det visuella resultatet mer konsistent i olika webbläsare, men texten kan inte längre markeras eller sökas som SVG-text.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) använder ett [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)‑värde för teckensnitt som laddas externt. Välj `AddLinksToFontFiles` för att referera separata teckensnitts filer, `Embed` för att inkludera teckensnittsdata i SVG:n, eller `Vectorize` för att rendera endast text som använder externa teckensnitt som grafik. Verifiera teckensnittslicenser innan du bäddar in teckensnitt.

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

## **Minska storlek på inbäddade bilder**

Använd [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) för att minska upplösningen för inbäddade bilder, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) för att utelämna beskurna källområden, och [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) för att kontrollera JPEG‑kodningskvalitet. Dessa inställningar minskar filstorleken på bekostnad av bildens noggrannhet eller bevarade bilddata.

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

## **Kontrollera rasteriseringsupplösning för metafiler**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) anger den lägre upplösningsgränsen för rasterisering av metafiler under SVG-export. Använd den för att balansera detaljrikedom och filstorlek när en EMF- eller WMF-bild rasteriseras. Den definierar inte en global DPI för SVG:n eller tvingar varje objekt på bilden att bli en rasterbild.

Ladda ner [metafile-rasterization.pptx](metafile-rasterization.pptx), som innehåller en EMF-bild med tätt placerade diagonala linjer. Följande exempel exporterar dess första bild i tre rasteriseringsupplösningar via [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). Alla andra exportinställningar förblir identiska så att resultaten kan jämföras.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

I utdata blev EMF-filen en inbäddad PNG i varje SVG. Följande mått gäller för den medföljande presentationen; de är inte en generell formel för att konvertera DPI till pixelmått.

| Metafil rasteriserings‑DPI | Inbäddade PNG-dimensioner | SVG-filstorlek (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Jämförelsen nedan visar samma område av den inbäddade rasterbilden i samma förstora visningsstorlek. De diagonala linjerna visar synlig pixelering vid 72 DPI och mjukare kanter vid högre upplösningar, samtidigt som SVG-filen växer. Att öka värdet förbättrar inte nödvändigtvis varje detalj eller förändrar varje exporterad bild.

![Förstorad diagonal‑linjedetalj vid 72, 150 och 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) styr minskning av bildupplösning och kan dölja effekten av att ändra rasteriseringsupplösning för metafiler. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) styr JPEG‑kodningskvalitet, inte rasteriseringsupplösning för metafiler.

## **Tilldela stabila ID:n till former och text**

Tillhandahåll en formaterings‑callback till [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) för att sätta [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) för varje SVG-form. Callbacken kan också sätta [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId)‑värden på text‑`tspan`‑element.

PhpJavaBridge kan inte anropa en PHP‑callback från `writeAsSvg` när den körs i strömläge. Placera formateringslogiken i en liten Java‑hjälparklass, kompilera den och lägg till den resulterande JAR‑filen i bryggans classpath. Hjälparklassen kan använda [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId), som är stabil under formens livstid, samt en upprepningsbar räknare för dess text‑spann. Se [Java implementation of `StableSvgIdController`](/slides/sv/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) för hjälparkoden.

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

I en formaterings‑callback anropas [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) med ett [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/)‑värde för att lägga till en JavaScript‑händelsehanterare till en exporterad form. Tilldela callbacken med [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) och definiera JavaScript‑funktionen i sidan eller SVG‑dokumentet som innehåller resultatet.

Precis som med stabila ID:n implementeras callbacken i en Java‑hjälparklass när PhpJavaBridge använder strömläge. [Java implementation of `SvgEventController`](/slides/sv/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) tilldelar ett ID och en `OnClick`‑hanterare till en form med namnet `ActionButton`. Kompilera den hjälparklassen, lägg till den i bryggans classpath som `com.example.slides.SvgEventController` och använd den från PHP enligt följande:

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

Värdsidan kan definiera JavaScript‑funktionen som refereras av hanteraren. Att tilldela ID:n och händelsehanterare möjliggör bildspelsvisare, tillgänglighetsförbättringar och andra interaktiva SVG‑arbetsflöden.

## **Vanliga frågor**

**När bör jag använda [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) istället för [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

Använd [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) när all text måste vara oberoende av teckensnitt. Använd [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) när endast text som använder externa teckensnitt ska konverteras till grafik.

**Vad är det bästa sättet att göra en SVG mindre?**

Börja med att komprimera inbäddade bilder, ta bort beskurna bildområden och välja länkade teckensnittsfiler när målmiljön kan leverera dem. Testa resultatet eftersom lägre bildupplösning, lägre JPEG‑kvalitet och vektoriserad text har olika kompromisser mellan kvalitet och storlek.

**Kan jag ändra exporterade SVG‑element efter export?**

Ja. Tilldela ID:n via en formaterings‑callback och välj sedan de motsvarande SVG‑elementen i ditt efterbehandlingsverktyg eller browserskript.