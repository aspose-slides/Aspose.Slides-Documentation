---
title: "Hantera presentationsmasterbilder i PHP"
linktitle: "Mästarbild"
type: docs
weight: 70
url: /sv/php-java/slide-master/
keywords:
- bildmaster
- masterbild
- PPT-masterbild
- flera masterbilder
- jämför masterbilder
- bakgrund
- platshållare
- klona masterbild
- kopiera masterbild
- duplicera masterbild
- oanvänd masterbild
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Hantera slide-masterbilder i Aspose.Slides för PHP via Java: åtkomst, redigering, kloning, jämförelse och borttagning av masterbilder i PowerPoint‑ och OpenDocument‑presentationer."
---
## **Översikt**

En **slide master** definierar delade designinställningar för en grupp bilder. Den kan innehålla vanliga former, logotyper, bakgrunder, textstilar, temainställningar och sidfotsinställningar. I PowerPoint är redigering av en slide master det vanliga sättet att hålla en presentation konsekvent utan att upprepa samma formatering på varje bild.

Aspose.Slides för PHP via Java stöder samma modell. En presentation kan innehålla en eller flera masterbilder, och varje masterbild kan innehålla flera layoutbilder. Vanliga bilder refererar vanligtvis inte direkt till en masterbild. Istället använder en vanlig bild en layoutbild, och den layoutbilden tillhör en masterbild.

Hierarkin är:

1. **Slide master** – definierar den delade designen och temat.  
1. **Layout slide** – definierar en specifik placering av platshållare och layoutnivåformatering.  
1. **Normal slide** – innehåller det faktiska presentationsinnehållet och använder en layoutslide.

![Hierarkin av masterbilder, layoutbilder och vanliga bilder](slide-master_2.jpg)

I Aspose.Slides representeras en slide master av klassen [MasterSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/) . Alla masterbilder i en presentation är tillgängliga via metoden [Presentation.getMasters](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getMasters) , som returnerar ett [MasterSlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslidecollection/)‑objekt.

{{% alert color="info" title="Inheritance" %}}
När samma egenskap är definierad på mer än en nivå, vinner den mer specifika nivån. Till exempel, om en masterbild och en layoutbild båda definierar en bakgrund, använder bilder baserade på den layouten layoutens bakgrund. För mer information om layoutbilder, se [Applicera eller ändra bildlayouter](/slides/sv/php-java/slide-layout/).
{{% /alert %}}

## **Åtkomst till Slide Masters**

I PowerPoint kan du öppna Slide Master‑vyn från **View** > **Slide Master**.

![Slide Master‑kommandot på PowerPoint View‑fliken](slide-master_3.jpg)

I Aspose.Slides, använd metoden `getMasters` för att komma åt masterbilder:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Du kan också hämta masterbilden som en vanlig bild använder via dess layout:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Vad en Slide Master innehåller**

En masterbild är ett bildlikt objekt. Den ärver från [BaseSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslide/) , så den exponerar många av samma bildegenskaper som används av vanliga och layoutbilder. Master‑specifika medlemmar listas på API‑sidan för [MasterSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/) .

Vanligt använda masterbildsmedlemmar inkluderar:

| Medlem | Syfte |
| --- | --- |
| `getBackground` | Ställer in masternivåns bildbakgrund. |
| `getShapes` | Lagrar former placerade på masteren, såsom logotyper, bildramar och delad text. |
| `getLayoutSlides` | Lagrar layoutbilderna som tillhör masteren. |
| `getThemeManager` | Ger åtkomst till master‑temats API:er. |
| `getHeaderFooterManager` | Kontrollerar sidhuvuden, sidfötter, datum och bildnummer för masteren och dess underliggande layouter. |
| `getDependingSlides` | Returnerar vanliga bilder som beror på masteren via sina layouter. |

## **Lägg till en bild på en Slide Master**

När du lägger till en bild på en masterbild visas den på bilder som använder layouter från den masteren. Detta är användbart för logotyper, vattenstämplar, dekorativa band och andra återkommande visuella element.

Följande exempel lägger till en logotyp på den första masterbilden:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

För mer information om bildramar, se [Bildram](/slides/sv/php-java/picture-frame/).

## **Styr synligheten för mastergrafik**

Använd [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslide/#setShowMasterShapes) för att dölja ärvd mastergrafik, såsom logotyper eller dekorativa former, utan att ta bort dem från masteren. Skicka `false` till [Slide::setShowMasterShapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#setShowMasterShapes) på den bild som ska utelämna den grafiken och håll den `true` på bilder som ska visa den.

Följande fristående exempel skapar ett blått dekorativt band på en master och två bilder som använder samma tomma layout. Bandet är synligt på den första bilden och dolt på den andra. Ingen ingångspresentation eller bild krävs.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Exemplet använder layouten **Blank** som medföljer en ny presentation och tar bort den första bildens egna platshållare.

### **Välj omfånget för inställningen**

En vanlig bild använder sin master genom [Slide::getLayoutSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getLayoutSlide) och [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/#getMasterSlide) . Att ställa in egenskapen på en enskild bild påverkar endast den bilden. Att skicka `false` till [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/#setShowMasterShapes) döljer mastergrafik för bilder som använder den delade layouten, även om deras egen inställning är `true`. För att dölja grafik på endast en bild, ändra bildens egenskap och låt den delade layouten vara oförändrad.

Inställningen stöds inte som en synlighetskontroll på masterbilden själv. På en master returnerar [getShowMasterShapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/#getShowMasterShapes) alltid `false`, och att skicka `true` till [setShowMasterShapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/#setShowMasterShapes) kastar ett undantag. Applicera den på en vanlig bild eller en layout istället.

### **Skilj på grafik och bakgrund**

| Åtgärd | Effekt |
| --- | --- |
| Dölj mastergrafik | Styr synligheten för ärvda mastersformer utan att ta bort dem eller ändra bildens egna former. |
| Ändra bildens bakgrundsutfyllnad | Ändrar bakgrundens färg, gradient eller bild. Mastergrafik är separata former och kan förbli synliga över den bakgrunden. Se [Presentation Background](/slides/sv/php-java/presentation-background/). |
| Ta bort en form från masteren | Tar bort den delade källformen, så den inte längre är tillgänglig för någon bild som använder den masteren. |

## **Arbeta med platshållare**

Platshållare definieras normalt på layoutbilder. Masterbilden tillhandahåller den delade stilen och temat som dessa layouter ärver, medan varje layout bestämmer vilka platshållare som är tillgängliga och var de placeras.

I PowerPoint finns platshållarkommandon tillgängliga i Slide Master‑vyn.

![Infoga platshållarkommandot i PowerPoint Slide Master‑vyn](slide-master_5.png)

För att lägga till nya platshållare med Aspose.Slides, arbeta med layoutbilden som tillhör masteren:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Du kan också formatera platshållarformer som redan finns på en masterbild. Följande exempel hittar titel‑platshållaren och applicerar en linjär gradientfyllning:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![Formaterad titelplatshållare ärvd av vanliga bilder](slide-master_8.png)

För fler alternativ för platshållare och textformatering, se [Set Prompt Text in Placeholder](/slides/sv/php-java/manage-placeholder/) och [Text Formatting](/slides/sv/php-java/text-formatting/).

## **Ändra en Slide Master‑bakgrund**

En masterbakgrund ärvs av layouter och bilder som inte åsidosätter den. Följande exempel sätter en solid bakgrundsfärg för den första masterbilden:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

För relaterade ämnen, se [Presentation Background](/slides/sv/php-java/presentation-background/) och [Presentation Theme](/slides/sv/php-java/presentation-theme/).

## **Klona en Slide Master till en annan presentation**

Använd `addClone` från [MasterSlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslidecollection/) för att kopiera en masterbild till en annan presentation. Den kopierade masteren kan sedan användas av layouter och bilder i målpresentationen.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

Om du behöver klona vanliga bilder tillsammans med deras master, se [Clone Slides](/slides/sv/php-java/clone-slides/).

## **Lägg till flera Slide Masters**

En presentation kan innehålla flera masterbilder. Detta är användbart när olika avsnitt kräver olika varumärkesprofil, sidstruktur eller temainställningar.

![PowerPoint‑kommandon för att infoga och hantera masterbilder](slide-master_9.jpg)

Följande exempel klonar standard‑masteren, ger klonen en annan bakgrund, skapar en layout under den klonade masteren och lägger till en ny bild baserad på den layouten:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Jämför Slide Masters**

Masterbilder kan jämföras med `equals`‑metoden som ärvd från [BaseSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslide/) . Jämförelsen kontrollerar struktur och statiskt innehåll, såsom former, text, formatering, animationer och andra bildinställningar. Den jämför inte unika identifierare, såsom bild‑ID:n, eller dynamiska platshållarvärden, såsom aktuellt datum.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

För mer information, se [Compare Presentation Slides](/slides/sv/php-java/compare-slides/).

## **Ställ in Slide Master‑vyn som standardvy**

Använd metoden `setLastView` på [ViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/) för att styra den vy som PowerPoint öppnar först. Följande exempel öppnar presentationen i Slide Master‑vyn:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

För fler vyinställningar, se [Save Presentation](/slides/sv/php-java/save-presentation/).

## **Ta bort oanvända masterbilder**

Presentationer kan ibland innehålla masterbilder som inte längre används av någon vanlig bild. Att ta bort oanvända masterbilder kan minska filstorleken och förenkla underhållet av mallar.

Använd `removeUnused` från [MasterSlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslidecollection/) för att ta bort oanvända masterbilder från `getMasters`‑samlingen:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Du kan också använda den låg‑kodade metoden `removeUnusedMasterSlides` från klassen [Compress](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/) :

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Vad är skillnaden mellan en slide master och en layoutbild?**

En slide master definierar delade designinställningar såsom tema, bakgrund, gemensamma former och textstilar. En layoutbild tillhör en masterbild och definierar en specifik placering av platshållare. En vanlig bild använder en layoutbild, så den ärver både från layouten och masteren.

**Kan en presentation innehålla flera slide masters?**

Ja. En presentation kan innehålla flera slide masters. Använd flera masterbilder när olika avsnitt behöver olika visuella system eller varumärkesprofil.

**Bör jag lägga till platshållare på en masterbild eller en layoutbild?**

I de flesta fall lägger du till platshållare på layoutbilder. Placera delade visuella element och delad formatering på masterbilden, och lägg sedan innehållsplatshållare på de layouter som vanliga bilder kommer att använda.

**Kan jag ta bort en masterbild som fortfarande används?**

Nej. En masterbild som har beroende bilder kan inte säkert tas bort direkt. Flytta först dessa bilder till layouter under en annan master, eller använd en metod för att rensa bort oanvända masterbilder som bara tar bort masterbilder som inte används.