---
title: Hantera presentationsplatshållare i PHP
linktitle: Hantera platshållare
type: docs
weight: 10
url: /sv/php-java/manage-placeholder/
keywords:
- platshållare
- textplatshållare
- bildplatshållare
- diagramplatshållare
- innehållsplatshållare
- förslagstext
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du granskar och redigerar text-, bild-, diagram- och innehållsplatshållare samt förstår platshållarärvning med Aspose.Slides för PHP via Java."
---
## **Översikt**

En platshållare är en form som reserverar en position för en viss typ av innehåll i en presentationsmall. Vanliga exempel är titel, brödtext, bild, diagram och generella innehållsplatshållare. Till skillnad från en vanlig form kan en platshållare ärva sin position, storlek, formatering och andra inställningar från en layout‑bild eller en huvudbild.

Aspose.Slides exponerar platshållarinformation via metoden [Shape::getPlaceholder](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getplaceholder/). Metoden returnerar ett [Placeholder](https://reference.aspose.com/slides/sv/php-java/aspose.slides/placeholder/)‑objekt eller `null` för en normal form. Använd [Placeholder::getType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/placeholder/gettype/) för att avgöra vad platshållaren är avsedd att innehålla.

Formklassen är fortfarande viktig när du känner till platshållartypen:

- En tom text‑, bild‑, diagram‑ eller innehållsplatshållare representeras vanligtvis av en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/).
- En ifylld bildplatshållare kan representeras av en [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/).
- En ifylld diagramplatshållare kan representeras av ett [Chart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/).
- En innehållsplatshållare kan innehålla flera typer av innehåll. Kontrollera både [Placeholder::getType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/placeholder/gettype/) och den faktiska formklassen i stället för att anta att varje platshållare är en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/placeholder/gettype/) beskriver en platshållares roll; den garanterar inte formens körningstidklass. Använd alltid en typkontroll innan du kommer åt text‑, bild‑, diagram‑, tabell‑ eller media‑specifika medlemmar.
{{% /alert %}}

## **Förstå platshållarärvning**

Platshållare bildar en hierarki:

1. En huvudbild definierar återanvändbara stilar och, i vissa fall, huvudnivå‑platshållare.
2. En layout‑bild definierar arrangemanget som används av en eller flera vanliga bilder och kan ärva från huvudbilden.
3. En vanlig bild innehåller platshållarna för den bilden och kan ärva från sin layout.

Anropa [Shape::getBasePlaceholder](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getbaseplaceholder/) för att gå ett nivå upp i hierarkin. En bild‑platshållare returnerar normalt sin layout‑platshållare; en layout‑platshållare kan returnera sin huvud‑platshållare. Metoden returnerar `null` när formen saknar grund‑platshållare.

Följande exempel listar platshållare på den första bilden och rapporterar deras grund‑platshållare:

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

Att redigera en platshållare på en vanlig bild skapar eller ändrar en lokal åsidosättning för den bilden. Att redigera den motsvarande layouten eller huvudbilden kan påverka alla bilder som fortfarande ärver den inställningen. En lokal vanlig form har ingen grund‑platshållare och börjar inte ärva bara för att den upptar samma koordinater.

## **Ändra text i en platshållare**

Titel‑, centrerade‑titel‑, undertext‑, brödtext‑ och text‑platshållare stöder normalt text. Kontrollera att det är en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) innan du använder dess [getTextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/gettextframe/)‑metod.

Detta exempel uppdaterar den första titel‑platshållaren på den första bilden och sparar resultatet:

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

Mönstret undviker att behandla bild‑, diagram‑, tabell‑ eller media‑platshållare som [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/)‑objekt. Det identifierar också platshållaren efter syfte i stället för att förlita sig på ett skört formindex.

## **Ange förslagstext på en layout**

Förslagstext är design‑tidsinstruktionen som visas i en tom platshållare, t.ex. *Klicka för att lägga till titel*. Ange anpassad förslagstext på layout‑platshållaren i stället för att försöka nå den via en vanlig bilds formsamling. Kom åt layouten via [Slide::getLayoutSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getLayoutSlide) och iterera över samlingen som returneras av [BaseSlide::getShapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslide/#getShapes).

Följande exempel ändrar titel‑ och undertext‑förslag på den layout som används av den första bilden:

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

Förslagstext är inte normalt bildinnehåll. Den är avsedd för tomma platshållare i redigeringsprogram som PowerPoint. När en användare eller ett program tillhandahåller riktigt innehåll visas förslaget inte längre. Att ändra ett förslag ersätter inte befintlig text på bilder som använder layouten.

## **Uppdatera en bild‑platshållare**

Det finns två fall att hantera:

- Om bild‑platshållaren redan är ifylld och representeras av en [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/), ersätt bilden via [PictureFillFormat::getPicture](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/getpicture/) och [SlidesPicture::setImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidespicture/setimage/).
- Om den fortfarande är en tom platshållare, lägg till en bildram på platshållarens koordinater med [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addpictureframe/) och ta bort den tomma platshållaren.

Nästa exempel stödjer båda fallen och sparar presentationen:

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

Ersättningen som skapas för en tom platshållare är en lokal bildram, inte en ny platshållare, eftersom [Shape::getPlaceholder](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getplaceholder/) inte har någon setter. Den behåller den reserverade positionen men ärver inte längre platshållarspecifikt beteende. Om det är avgörande att behålla platshållarförhållandet, förbered och fyll i platshållaren i PowerPoint först, och uppdatera sedan den resulterande [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/) med Aspose.Slides.

För bild‑transparens, beskärning och andra bild‑specifika effekter, se [Manage Picture Frames](/slides/sv/php-java/picture-frame/). Dessa operationer tillhör bildramen eller bildfyllningen, inte platshållarmetadata.

## **Arbeta med diagram‑ och innehålls‑platshållare**

En ifylld diagram‑platshållare kan representeras av ett [Chart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/). Detta exempel hittar ett sådant diagram genom både platshållartyp och körningstidklass, ändrar dess titel och sparar filen:

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

En generell innehålls‑platshållare har vanligtvis [PlaceholderType::Object](https://reference.aspose.com/slides/sv/php-java/aspose.slides/placeholdertype/). I PowerPoint fungerar den som en startpunkt för flera innehållstyper, inklusive diagram, tabeller, diagram, bilder och media. Efter att den har fyllts i, inspektera den faktiska formklassen för att ta reda på vad den innehåller. Specialiserade layouter kan också exponera [PlaceholderType::Chart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/sv/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/sv/php-java/aspose.slides/placeholdertype/), eller [PlaceholderType::Diagram](https://reference.aspose.com/slides/sv/php-java/aspose.slides/placeholdertype/).

Aspose.Slides konverterar inte en tom [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/)‑platshållare till ett [Chart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/) enbart genom att ändra [Placeholder::getType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/placeholder/gettype/); typen kan inte ändras via klassen. För att fylla ett tomt diagram‑ eller innehållsområde programatiskt, lägg till det behövda objektet på platshållarens koordinater och ta sedan bort den tomma platshållaren. Följande exempel gör detta för ett diagram:

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

Det tillagda diagrammet är ett vanligt lokalt diagram. Det upptar platshållarens område men ärver inte från layout‑platshållaren. Använd de dedikerade [chart management articles](/slides/sv/php-java/powerpoint-charts/) när du behöver ersätta dess kategorier, serier eller arbetsboksdata.

## **Fullständigt exempel: Uppdatera text‑ eller bildinnehåll**

Följande end‑to‑end‑exempel öppnar en mall, söker på den första bilden efter antingen en titel‑ eller bild‑platshållare, kontrollerar platshållar‑ och formtyper, uppdaterar det lämpliga innehållet och sparar resultatet. Exemplet undviker medvetet att anta ett formindex eller att behandla varje platshållare som samma klass.

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

**Vad är en grund‑platshållare?**

En grund‑platshållare är den motsvarande formen på layouten eller huvudbilden som en annan platshållare ärver från. Använd [Shape::getBasePlaceholder](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getbaseplaceholder/) för att hämta den. En vanlig lokal form returnerar `null` eftersom den inte är en del av platshållar‑hierarkin.

**Kan jag ändra alla bildtitlar genom att redigera en layout‑platshållare?**

Du kan ändra ärvd formatering eller förslagstext via en layout, men befintligt titel­innehåll lagras på de vanliga bilderna. För att ersätta den faktiska titeltexten i en presentation, iterera över bilderna och uppdatera varje titel‑platshållare.

**Hur hanterar jag datum‑, bild‑nummer‑, sidhuvud‑ och sidfot‑platshållare?**

Använd sidhuvuds‑ och sidfotshanterarna på lämplig bild, layout, huvud, anteckningar eller utdelnings‑omfattning. Se [Manage Presentation Header and Footer](/slides/sv/php-java/presentation-header-and-footer/) för kompletta exempel.