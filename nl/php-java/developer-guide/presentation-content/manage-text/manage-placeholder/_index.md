---
title: Beheer presentatie‑placeholders in PHP
linktitle: Placeholders beheren
type: docs
weight: 10
url: /nl/php-java/manage-placeholder/
keywords:
- placeholder
- tekst‑placeholder
- afbeeldings‑placeholder
- grafiek‑placeholder
- content‑placeholder
- prompt‑tekst
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u tekst‑, afbeelding‑, grafiek‑ en content‑placeholders kunt inspecteren en bewerken en begrijp de placeholder‑overerving met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Een placeholder is een vorm die een positie reserveert voor een bepaald type inhoud in een presentatiesjabloon. Veelvoorkomende voorbeelden zijn titel-, tekst‑, afbeelding‑, grafiek‑ en algemene content‑placeholders. In tegenstelling tot een gewone vorm kan een placeholder zijn positie, grootte, opmaak en andere instellingen overerven van een layout‑slide of master‑slide.

Aspose.Slides maakt placeholder‑informatie beschikbaar via de [Shape::getPlaceholder](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getplaceholder/) methode. De methode retourneert een [Placeholder](https://reference.aspose.com/slides/nl/php-java/aspose.slides/placeholder/) object of `null` voor een normale vorm. Gebruik [Placeholder::getType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/placeholder/gettype/) om te bepalen welke inhoud de placeholder moet bevatten.

De vormklasse blijft relevant nadat u het placeholder‑type kent:

- Een lege tekst‑, afbeelding‑, grafiek‑ of content‑placeholder wordt vaak weergegeven door een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/).
- Een gevulde afbeelding‑placeholder kan worden weergegeven door een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/).
- Een gevulde grafiek‑placeholder kan worden weergegeven door een [Chart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/).
- Een content‑placeholder kan verschillende soorten inhoud bevatten. Controleer zowel [Placeholder::getType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/placeholder/gettype/) als de runtime‑vormklasse in plaats van aan te nemen dat elke placeholder een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) is.

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType] beschrijft de rol van een placeholder; het garandeert niet de runtime‑klasse van de vorm. Gebruik altijd een type‑check voordat u toegang krijgt tot tekst-, afbeelding-, grafiek-, tabel- of media‑specifieke leden.
{{% /alert %}}

## **Begrijp placeholder‑overerving**

Placeholders vormen een hiërarchie:

1. Een master‑slide definieert herbruikbare stijlen en, in sommige gevallen, master‑level placeholders.
2. Een layout‑slide definieert de indeling die door één of meer normale slides wordt gebruikt en kan van de master overerven.
3. Een normale slide bevat de placeholders voor die slide en kan van zijn layout overerven.

Roep [Shape::getBasePlaceholder](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getbaseplaceholder/) aan om een niveau hoger in deze hiërarchie te gaan. Een slide‑placeholder retourneert normaal gesproken zijn layout‑placeholder; een layout‑placeholder kan zijn master‑placeholder retourneren. De methode retourneert `null` wanneer de vorm geen basis‑placeholder heeft.

Het volgende voorbeeld somt de placeholders op van de eerste slide en geeft hun basis‑placeholders weer:

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

Het bewerken van een placeholder op een normale slide creëert of wijzigt een lokale overschrijving voor die slide. Het bewerken van de bijbehorende layout of master kan alle slides beïnvloeden die die instelling nog overerven. Een lokale gewone vorm heeft geen basis‑placeholder en begint niet met overerven alleen omdat hij dezelfde coördinaten inneemt.

## **Tekst wijzigen in een placeholder**

Titel-, gecentreerde‑titel-, subtitel‑, body‑ en tekst‑placeholders ondersteunen normaal gesproken tekst. Controleer op een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) voordat u de [getTextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/gettextframe/) methode gebruikt.

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

Dit patroon voorkomt dat afbeelding‑, grafiek‑, tabel‑ of media‑placeholders worden behandeld als [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/)‑objecten. Het identificeert ook de placeholder op basis van het doel in plaats van te vertrouwen op een fragiele vorm‑index.

## **Prompt‑tekst instellen op een layout**

Prompt‑tekst is de ontwerp‑tijd instructie die wordt weergegeven in een lege placeholder, bijvoorbeeld *Klik om titel toe te voegen*. Stel aangepaste prompt‑tekst in op de layout‑placeholder in plaats van te proberen deze via de vormcollectie van een normale slide te bereiken. Benader de layout via [Slide::getLayoutSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getLayoutSlide) en doorloop de collectie die wordt geretourneerd door [BaseSlide::getShapes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/#getShapes).

Het volgende voorbeeld wijzigt de titel‑ en subtitel‑prompts op de layout die wordt gebruikt door de eerste slide:

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

Prompt‑tekst is geen gewone slide‑inhoud. Het is bedoeld voor lege placeholders in bewerkingsprogramma’s zoals PowerPoint. Zodra een gebruiker of programma echte inhoud toevoegt, wordt de prompt niet meer weergegeven. Het wijzigen van een prompt vervangt ook niet de bestaande tekst op slides die de layout gebruiken.

## **Afbeelding‑placeholder bijwerken**

Er zijn twee gevallen om af te handelen:

- Als de afbeelding‑placeholder al is gevuld en wordt weergegeven door een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/), vervang dan de afbeelding via [PictureFillFormat::getPicture](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/getpicture/) en [SlidesPicture::setImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidespicture/setimage/).
- Als het nog een lege placeholder is, voeg dan een afbeelding‑frame toe op de coördinaten van de placeholder met [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addpictureframe/) en verwijder de lege placeholder.

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

De vervanging die voor een lege placeholder wordt gemaakt, is een lokaal afbeelding‑frame, geen nieuwe placeholder, omdat [Shape::getPlaceholder](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getplaceholder/) geen setter biedt. Het behoudt de gereserveerde positie, maar erft niet langer placeholder‑specifiek gedrag. Als het behouden van de placeholder‑relatie essentieel is, maak en vul de placeholder eerst in PowerPoint, en werk vervolgens het resulterende [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) bij met Aspose.Slides.

Voor beeld‑transparantie, bijsnijden en andere afbeelding‑specifieke effecten, zie [Manage Picture Frames](/slides/nl/php-java/picture-frame/). Die bewerkingen behoren tot het afbeelding‑frame of de afbeelding‑vulling, niet tot de placeholder‑metadata.

## **Werken met grafiek‑ en content‑placeholders**

Een gevulde grafiek‑placeholder kan worden weergegeven door een [Chart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/). Dit voorbeeld vindt zo’n grafiek zowel op basis van placeholder‑type als runtime‑klasse, wijzigt de titel en slaat het bestand op:

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

Een algemene content‑placeholder heeft meestal [PlaceholderType::Object](https://reference.aspose.com/slides/nl/php-java/aspose.slides/placeholdertype/). In PowerPoint fungeert het als een lanceerder voor verschillende content‑typen, waaronder grafieken, tabellen, diagrammen, afbeeldingen en media. Nadat het is gevuld, inspecteer de werkelijke vormklasse om te ontdekken wat het bevat. Gespecialiseerde layouts kunnen ook [PlaceholderType::Chart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/nl/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/nl/php-java/aspose.slides/placeholdertype/), of [PlaceholderType::Diagram](https://reference.aspose.com/slides/nl/php-java/aspose.slides/placeholdertype/) blootleggen.

Aspose.Slides converteert een lege [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/)‑placeholder niet naar een [Chart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/) alleen door [Placeholder::getType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/placeholder/gettype/) te wijzigen; het type kan niet via de klasse worden veranderd. Om een leeg grafiek‑ of content‑gebied programmatisch te vullen, voeg het vereiste object toe op de coördinaten van de placeholder en verwijder vervolgens de lege placeholder. Het volgende voorbeeld doet dit voor een grafiek:

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

De toegevoegde grafiek is een gewone lokale grafiek. Hij neemt de ruimte van de placeholder in, maar erft niet van de layout‑placeholder. Gebruik de toegewijde [chart management articles](/slides/nl/php-java/powerpoint-charts/) wanneer u de categorieën, reeksen of werkboek‑gegevens moet vervangen.

## **Volledig voorbeeld: tekst‑ of afbeeldingsinhoud bijwerken**

Het volgende end‑to‑end voorbeeld opent een sjabloon, zoekt op de eerste slide naar een titel‑ of afbeelding‑placeholder, controleert de placeholder‑ en vorm‑types, werkt de juiste inhoud bij en slaat de output op. Het voorbeeld vermijdt bewust het aannemen van een vorm‑index of het behandelen van elke placeholder als dezelfde klasse.

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

Een basis‑placeholder is de overeenkomstige vorm op de layout of master waarvan een andere placeholder overerft. Gebruik [Shape::getBasePlaceholder](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getbaseplaceholder/) om deze op te halen. Een gewone lokale vorm retourneert `null` omdat deze niet deel uitmaakt van de placeholder‑hiërarchie.

**Kan ik alle slide‑titels wijzigen door een layout‑placeholder te bewerken?**

U kunt geërfde opmaak of prompt‑tekst wijzigen via een layout, maar bestaande titel‑inhoud staat opgeslagen op de normale slides. Om de daadwerkelijke titel‑tekst in een volledige presentatie te vervangen, moet u over de slides itereren en elke titel‑placeholder bijwerken.

**Hoe beheer ik datum‑, slide‑nummer‑, header‑ en footer‑placeholders?**

Gebruik de header‑ en footer‑managers op het juiste niveau (slide, layout, master, notities of hand‑out). Zie [Manage Presentation Header and Footer](/slides/nl/php-java/presentation-header-and-footer/) voor volledige voorbeelden.