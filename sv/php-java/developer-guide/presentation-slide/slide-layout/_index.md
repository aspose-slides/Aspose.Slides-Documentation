---
title: Tillämpa eller ändra bildlayouter i PHP
linktitle: Bildlayout
type: docs
weight: 60
url: /sv/php-java/slide-layout/
keywords:
- bildlayout
- innehållslayout
- platshållare
- presentationsdesign
- bilddesign
- oanvänd layout
- sidfotssynlighet
- titelsida
- titel och innehåll
- sektionrubrik
- tvådelat innehåll
- jämförelse
- endast titel
- tom layout
- innehåll med bildtext
- bild med bildtext
- titel och vertikal text
- vertikal titel och text
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Hantera och anpassa bildlayouter i Aspose.Slides för PHP via Java. Utforska layouttyper, kontroll av platshållare och sidfotssynlighet genom kodexempel."
---
## **Introduktion**

En bildlayout definierar arrangemanget av platshållarrutor och formatering för innehållet på en bild. Den styr vilka platshållare som är tillgängliga och var de visas. Bildlayouter hjälper dig att designa presentationer snabbt och konsekvent—oavsett om du skapar något enkelt eller mer komplext. Några av de vanligaste bildlayouterna i PowerPoint är:

**Titelbildslayout** – Inkluderar två textplatshållare: en för titeln och en för undertiteln.

**Titel- och innehållslayout** – Har en mindre titelplats hållare högst upp och en större nedanför för huvudinnehåll (som text, punktlistor, diagram, bilder och mer).

**Tom layout** – Innehåller inga platshållare, vilket ger dig full kontroll att designa bilden från grunden.

Bildlayouter är en del av en bildmaster, som är den översta bilden som definierar layoutstilar för presentationen. Du kan komma åt och modifiera layoutbilder via bildmastern—antingen efter deras typ, namn eller unika ID. Alternativt kan du redigera en specifik layoutbild direkt i presentationen.

För att arbeta med bildlayouter i Aspose.Slides för PHP kan du använda:

- Metoder som [getLayoutSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getLayoutSlides) och [getMasters](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getMasters) under klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) 
- Typer som [LayoutSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/), och [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
För att lära dig mer om att arbeta med masternbilder, se artikeln [Slide Master](/slides/sv/php-java/slide-master/).
{{% /alert %}}

## **Lägg till bildlayouter i presentationer**

För att anpassa utseendet och strukturen på dina bilder kan du behöva lägga till nya layoutbilder i en presentation. Aspose.Slides för PHP låter dig kontrollera om en specifik layout redan finns, lägga till en ny om det behövs och använda den för att infoga bilder baserade på den layouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Åtkomst till [MasterLayoutSlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterlayoutslidecollection/).
3. Kontrollera om den önskade layoutbilden redan finns i samlingen. Om inte, lägg till den layoutbild du behöver.
4. Lägg till en tom bild baserad på den nya layoutbilden.
5. Spara presentationen.

Följande PHP‑kod demonstrerar hur man lägger till en bildlayout i en PowerPoint‑presentation:

```php
// Instansiera Presentation-klassen som representerar en PowerPoint-fil.
$presentation = new Presentation("Sample.pptx");
try {
    // Gå igenom layoutbildtyperna för att välja en layoutbild.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // En situation där presentationen inte innehåller alla layouttyper.
        // Presentationsfilen innehåller endast tomma och anpassade layouttyper.
        // Dock kan layoutbilder med anpassade typer ha igenkännbara namn,
        // såsom "Title", "Title and Content" etc., som kan användas för att välja layoutbild.
        // Du kan också förlita dig på en uppsättning av platshållarformtyper.
        // Till exempel bör en titelsida endast ha titels-platshållartypen, och så vidare.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Lägg till en tom bild med den tillagda layoutbilden.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // Spara presentationen till disk.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ta bort oanvända layoutbilder**

Aspose.Slides tillhandahåller metoden [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) från klassen [Compress](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/) för att låta dig ta bort oönskade och oanvända layoutbilder.

Följande PHP‑kod visar hur man tar bort en layoutbild från en PowerPoint‑presentation:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lägg till platshållare i bildlayouter**

Aspose.Slides tillhandahåller metoden [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/#getPlaceholderManager), som låter dig lägga till nya platshållare i en layoutbild.

Denna manager innehåller metoder för följande platshållartyper:

| PowerPoint‑platshållare | [LayoutPlaceholderManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/) Metod |
| ----------------------- | ------------------------------------------------------------ |
| ![Innehåll](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Innehåll (Vertikal)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertikal)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Bild](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Diagram](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabell](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online‑bild](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Följande PHP‑kod demonstrerar hur man lägger till nya platshållarformer i den tomma layoutbilden:

```php
$presentation = new Presentation();
try {
    // Hämta den tomma layoutbilden.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Hämta platshållarhanteraren för layoutbilden.
    $placeholderManager = $layout->getPlaceholderManager();

    // Lägg till olika platshållare i den tomma layoutbilden.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Lägg till en ny bild med den tomma layouten.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Resultatet:

![Platshållarna på layoutbilden](add_placeholders.png)

## **Ställ in sidfotsynlighet för en layoutbild**

I PowerPoint‑presentationer kan sidfotselement som datum, bildnummer och anpassad text visas eller döljas beroende på bildlayouten. Aspose.Slides för PHP låter dig styra synligheten för dessa sidfot‑platshållare. Detta är användbart när du vill att vissa layouter ska visa sidfotinformation medan andra förblir rena och minimala.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta en referens till en layoutbild via dess index.
3. Ställ in sidfot‑platshållaren för bilden till synlig.
4. Ställ in bildnummer‑platshållaren till synlig.
5. Ställ in datum‑tid‑platshållaren till synlig.
6. Spara presentationen.

Följande PHP‑kod visar hur man ställer in synligheten för en sidfot i en bild och utför relaterade uppgifter:

```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

## **Ställ in barnsidfotsynlighet för en bild**

I PowerPoint‑presentationer kan sidfotselement som datum, bildnummer och anpassad text kontrolleras på masternivå för att säkerställa konsekvens över alla layoutbilder. Aspose.Slides för PHP gör det möjligt att ställa in synlighet och innehåll för dessa sidfot‑platshållare på mastern och sprida dessa inställningar till alla underliggande layoutbilder. Detta tillvägagångssätt säkerställer enhetlig sidfotinformation i hela presentationen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta en referens till mastern via dess index.
3. Ställ in masterns och alla barns sidfot‑platshållare till synliga.
4. Ställ in masterns och alla barns bildnummer‑platshållare till synliga.
5. Ställ in masterns och alla barns datum‑tid‑platshållare till synliga.
6. Spara presentationen.

Följande PHP‑kod demonstrerar denna operation:

```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Vanliga frågor**

**Vad är skillnaden mellan en master‑bild och en layout‑bild?**

En master‑bild definierar det övergripande temat och standardformateringen, medan layout‑bilder definierar specifika arrangemang av platshållare för olika typer av innehåll.

**Kan jag kopiera en layout‑bild från en presentation till en annan?**

Ja, du kan klona en layout‑bild från en presentations layout‑bildsamling, som är åtkomlig via metoden [getLayoutSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getLayoutSlides), och infoga den i en annan presentation med metoden `addClone`.

**Vad händer om jag tar bort en layout‑bild som fortfarande används av en bild?**

Om du försöker ta bort en layout‑bild som fortfarande refereras av minst en bild i presentationen, kommer Aspose.Slides att kasta ett [PptxEditException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxeditexception/). För att undvika detta, använd [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) som säkert tar bort endast de layout‑bilder som inte är i bruk.