---
title: Beheer presentatie-placeholders in PHP
linktitle: Beheer placeholders
type: docs
weight: 10
url: /nl/php-java/manage-placeholder/
keywords:
- placeholder
- tekst-placeholder
- afbeelding-placeholder
- diagram-placeholder
- inhoud-placeholder
- prompt-tekst
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u tekst-, afbeelding-, diagram- en inhoud-placeholder kunt inspecteren en bewerken en hoe placeholder-erfenis werkt met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Een placeholder is een vorm die een positie reserveert voor een bepaald type inhoud in een presentatie‑sjabloon. Veelvoorkomende voorbeelden zijn titel, hoofdtekst, afbeelding, diagram en algemene inhouds‑placeholders. In tegenstelling tot een gewone vorm kan een placeholder zijn positie, grootte, opmaak en andere instellingen erven van een layout‑slide of master‑slide.

Aspose.Slides maakt placeholder‑informatie beschikbaar via de [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) methode. De methode geeft een [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) object terug of `null` voor een normale vorm. Gebruik [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) om te bepalen wat de placeholder moet bevatten.

De vormklasse blijft van belang nadat u het placeholder‑type kent:

- Een lege tekst-, afbeelding-, diagram‑ of inhouds‑placeholder wordt doorgaans weergegeven door een [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
- Een ingevulde afbeelding‑placeholder kan worden weergegeven door een [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/).
- Een ingevulde diagram‑placeholder kan worden weergegeven door een [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/).
- Een inhouds‑placeholder kan verschillende soorten inhoud bevatten. Controleer zowel [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) als de runtime‑vormklasse in plaats van aan te nemen dat elke placeholder een [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) is.

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) beschrijft de rol van een placeholder; het garandeert niet de runtime‑klasse van de vorm. Gebruik altijd een type‑check voordat u tekst, afbeelding, diagram, tabel of media‑specifieke leden benadert.
{{% /alert %}}

## **Placeholder‑erfenis begrijpen**

Placeholders vormen een hiërarchie:

1. Een master‑slide definieert herbruikbare stijlen en, in sommige gevallen, master‑niveau placeholders.
2. Een layout‑slide definieert de indeling die door één of meer normale slides wordt gebruikt en kan van de master erven.
3. Een normale slide bevat de placeholders voor die slide en kan van de layout erven.

Roep [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) aan om één niveau hoger in deze hiërarchie te gaan. Een slide‑placeholder geeft normaal gezien zijn layout‑placeholder terug; een layout‑placeholder kan zijn master‑placeholder teruggeven. De methode geeft `null` terug wanneer de vorm geen basis‑placeholder heeft.

Het volgende voorbeeld toont de placeholders op de eerste slide en rapporteert hun basis‑placeholders:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Het bewerken van een placeholder op een normale slide maakt of wijzigt een lokale overschrijving voor die slide. Het bewerken van de bijbehorende layout of master kan alle slides die die instelling nog erven beïnvloeden. Een lokale gewone vorm heeft geen basis‑placeholder en begint niet met erven enkel omdat hij dezelfde coördinaten heeft.

## **Placeholder‑status verwijderen**

Bij het aanpassen van een sjabloon gebruikt u [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) om een bestaand object als een gewone vorm te behouden. Zijn [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) methode geeft `null` terug, maar de vorm blijft in de slide‑collectie. In tegenstelling tot [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) dat de vorm uit die collectie verwijdert.

Het volgende voorbeeld vereist `template.pptx` met minstens één slide en een niet‑lege tekst‑placeholder op de eerste slide. Gebruik een placeholder met opmaak die is geërfd van zijn layout of master om het effect van het verwijderen van die relatie te zien. Het voorbeeld controleert dat dezelfde vorm blijft bestaan, roept de methode opnieuw aan op de nu gewone vorm, en slaat het resultaat op.

{{% alert color="warning" title="Warning" %}}
Het verwijderen van de placeholder‑status behoudt niet automatisch de geërfde weergave‑instellingen. Het onderstaande voorbeeld laat die instellingen opzettelijk onveranderd, waardoor de uitvoer er anders uit kan zien. Een vorm waarvan positie en grootte volledig zijn geërfd kan na de aanroep nul‑coördinaten en afmetingen hebben en onzichtbaar worden, hoewel hij in de collectie blijft.
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // Het aanroepen van de methode op een gewone vorm heeft geen effect.
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Voor een overeenkomende placeholder geven alle drie de controles `true` weer. De tekst blijft behouden, maar geërfde positie, grootte, rotatie, lettertype, alinea‑uitlijning, tekst‑frame‑marges, verticale verankering, vul‑ en lijninstellingen kunnen veranderen wanneer de placeholder‑relatie wordt verwijderd. Bijvoorbeeld kan geërfde titelopmaak terugvallen op gewone tekstopmaak. Zie [Slide Layout](/slides/nl/php-java/slide-layout/) voor meer over layouts.

Om de beoogde weergave te behouden, legt u de berekende positie, grootte en rotatie vast vóór de aanroep, en kopieert u de vereiste effectieve opmaakwaarden naar afzonderlijke variabelen. Haal die waarden op via [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/), [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/), [TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/), [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/), en [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/). Vertrouw niet alleen op de effectieve‑formaatobjecten, omdat hun tekst‑opmaakwaarden kunnen veranderen nadat de relatie is verwijderd. Pas de vastgelegde waarden expliciet toe op de gewone vorm daarna, inclusief lettertype‑familie, grootte, stijl, kleur, alinea‑instellingen, tekst‑frame‑instellingen, vul‑ en lijninstellingen die in uw sjabloon worden gebruikt.

Geërfde vormgeometrie moet mogelijk ook expliciet worden toegewezen via [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType). Voor een rechthoekige tekst‑placeholder betekent dit het toewijzen van [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/); alleen het herstellen van vul‑ en lijninstellingen herstelt mogelijk niet de zichtbare rechthoek. Sjablonen met extra effecten of complexere opmaak vereisen dat die instellingen ook worden behandeld.

## **Tekst wijzigen in een placeholder**

Titel-, gecentreerde‑titel-, ondertitel-, body- en tekst‑placeholders ondersteunen normaal gesproken tekst. Controleer op [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) voordat u de [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/) methode gebruikt.

Dit voorbeeld werkt de eerste titel‑placeholder op de eerste slide bij en slaat het resultaat op:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dit patroon voorkomt dat afbeelding-, diagram-, tabel- of media‑placeholders als [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) objecten worden behandeld. Het identificeert de placeholder bovendien op doel in plaats van te vertrouwen op een kwetsbare vorm‑index.

## **Prompt‑tekst instellen op een layout**

Prompt‑tekst is de ontwerp‑tijdinstructie die in een lege placeholder wordt weergegeven, bijvoorbeeld *Click to add title*. Stel aangepaste prompt‑tekst in op de layout‑placeholder in plaats van te proberen deze via de vorm‑collectie van een normale slide te bereiken. Benader de layout via [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) en iterate over de collectie die wordt geretourneerd door [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes).

Het volgende voorbeeld wijzigt de titel‑ en ondertitel‑prompts op de layout die door de eerste slide wordt gebruikt:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Prompt‑tekst is geen normale slide‑inhoud. Het is bedoeld voor lege placeholders in bewerkingsapplicaties zoals PowerPoint. Zodra een gebruiker of programma echte inhoud toevoegt, wordt de prompt niet meer weergegeven. Het wijzigen van een prompt vervangt ook niet de bestaande tekst op slides die de layout gebruiken.

## **Een afbeelding‑placeholder bijwerken**

Er zijn twee gevallen te behandelen:

- Als de afbeelding‑placeholder al is gevuld en wordt vertegenwoordigd door een [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), vervang dan de afbeelding via [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) en [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage).
- Wanneer het nog een lege placeholder is, voeg een picture‑frame toe op de coördinaten van de placeholder met [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) en verwijder de lege placeholder.

Het volgende voorbeeld ondersteunt beide gevallen en slaat de presentatie op:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De vervanging die voor een lege placeholder wordt aangemaakt, is een lokaal picture‑frame, geen nieuwe placeholder, omdat [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) geen setter biedt. Het behoudt de gereserveerde positie maar erft niet langer placeholder‑specifiek gedrag. Als het behouden van de placeholder‑relatie essentieel is, bereid en vul de placeholder eerst in PowerPoint voor, en werk vervolgens het resulterende [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) bij met Aspose.Slides.

Voor beeld‑transparantie, bijsnijden en andere afbeelding‑specifieke effecten, zie [Manage Picture Frames](/slides/nl/php-java/picture-frame/). Deze bewerkingen behoren tot het picture‑frame of picture‑fill, niet tot placeholder‑metadata.

## **Werken met diagram‑ en inhouds‑placeholders**

Een ingevulde diagram‑placeholder kan worden weergegeven door een [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/). Dit voorbeeld vindt zo'n diagram via zowel placeholder‑type als runtime‑klasse, wijzigt de titel en slaat het bestand op:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Een algemene inhouds‑placeholder heeft meestal [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/). In PowerPoint fungeert deze als een lanceerder voor verschillende inhoudstypen, waaronder diagrammen, tabellen, diagrammen, afbeeldingen en media. Nadat hij is gevuld, inspecteert u de werkelijke vormklasse om te weten wat hij bevat. Gespecialiseerde layouts kunnen ook [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), of [PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) blootleggen.

Aspose.Slides zet een lege [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) placeholder niet om in een [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) louter door het wijzigen van [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/); het type kan niet via de klasse worden gewijzigd. Om een leeg diagram‑ of inhoudsgebied programmatisch te vullen, voegt u het vereiste object toe op de coördinaten van de placeholder en verwijdert vervolgens de lege placeholder. Het volgende voorbeeld doet dit voor een diagram:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het toegevoegde diagram is een gewone lokale chart. Het neemt het gebied van de placeholder in beslag maar erft niet van de layout‑placeholder. Gebruik de speciale [chart management articles](/slides/nl/php-java/powerpoint-charts/) wanneer u de categorieën, series of werkboek‑gegevens moet vervangen.

## **Volledig voorbeeld: tekst‑ of afbeeldingsinhoud bijwerken**

Het volgende end‑to‑end voorbeeld opent een sjabloon, zoekt op de eerste slide naar een titel‑ of afbeelding‑placeholder, controleert de placeholder‑ en vorm‑typen, werkt de juiste inhoud bij, en slaat de uitvoer op. Het voorbeeld vermijdt bewust de veronderstelling van een vorm‑index of het behandelen van elke placeholder als dezelfde klasse.

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Wat is een basis‑placeholder?**

Een basis‑placeholder is de overeenkomstige vorm op de layout of master waarvan een andere placeholder erft. Gebruik [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) om deze op te halen. Een gewone lokale vorm geeft `null` terug omdat hij geen deel uitmaakt van de placeholder‑hiërarchie.

**Kan ik alle slide‑titels wijzigen door een layout‑placeholder te bewerken?**

U kunt geërfde opmaak of prompt‑tekst via een layout wijzigen, maar bestaande titelinhoud wordt opgeslagen op de normale slides. Om de daadwerkelijke titeltekst in een presentatie te vervangen, iterate over de slides en werk elke titel‑placeholder bij.

**Hoe beheer ik datum-, slide‑nummer-, header‑ en footer‑placeholders?**

Gebruik de header‑ en footermanagers op de juiste slide, layout, master, notities of handout‑scope. Zie [Manage Presentation Header and Footer](/slides/nl/php-java/presentation-header-and-footer/) voor volledige voorbeelden.