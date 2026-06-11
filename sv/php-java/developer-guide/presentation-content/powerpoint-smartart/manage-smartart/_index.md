---
title: Hantera SmartArt i PowerPoint-presentationer med PHP
linktitle: Hantera SmartArt
type: docs
weight: 10
url: /sv/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt-text
- layouttyp
- dold egenskap
- organisationsdiagram
- bildorganisationsdiagram
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: Lär dig att skapa och redigera PowerPoint SmartArt med Aspose.Slides för PHP via Java med tydliga kodexempel som snabbar på bilddesign och automatisering.
---
## **Översikt**

SmartArt är ett PowerPoint-diagram som består av noder, nodformer och en layout. Med Aspose.Slides för PHP via Java kan du skapa SmartArt, läsa text från dess noder, ändra dess layout, undersöka dolda noder, konfigurera organisationsdiagramlayoutar och skapa bildorganisationsdiagram.

## **Hämta text från ett SmartArt-objekt**

En SmartArt-nod kan innehålla en eller flera former. För att läsa den synliga texten, iterera genom [SmartArt::getAllNodes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartart/#getAllNodes), och läs sedan [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) som returneras av [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartshape/#getTextFrame).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Ändra layouttyp för ett SmartArt-objekt**

SmartArt-layouten styr hur noder ordnas och kopplas ihop. Följande exempel skapar ett SmartArt-objekt med [SmartArtLayoutType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`-värdet, byter det till `BasicProcess`-värdet och sparar presentationen.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kontrollera om en SmartArt-nod är dold**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartnode/ishidden/) visar om noden är dold i SmartArt-datamodellen. Dolda noder kan finnas i strukturen även när den valda layouten inte visar dem som synliga diagramelement.

Följande exempel lägger till en nod i ett SmartArt-objekt som använder [SmartArtLayoutType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartlayouttype/) `RadialCycle`-värdet och kontrollerar nodens dolda tillstånd.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Hämta eller ange organisationsdiagramlayout**

För SmartArt-diagram som använder en organisationsdiagramlayout definierar [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) och [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) hur undernoder placeras under en föräldranod. Till exempel kan du ange att undernoder hänger från vänster, höger eller båda sidor, beroende på den valda [OrganizationChartLayoutType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/organizationchartlayouttype/).

Följande exempel skapar ett organisationsdiagram och anger layouten för den första noden till [OrganizationChartLayoutType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`-värdet.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Skapa ett bildorganisationsdiagram**

Ett bildorganisationsdiagram är en SmartArt-layout avsedd för hierarkidiagram som innehåller bildplatshållare. Använd [SmartArtLayoutType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`-värdet när du lägger till SmartArt-objektet på en bild.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Stöder SmartArt spegling eller omvändning för RTL-språk?**

Ja. Metoden [SmartArt::setReversed](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartart/setreversed/) växlar diagramriktningen från vänster-till-höger till höger-till-vänster, eller tillbaka, när den valda SmartArt-layouten stödjer omvändning.

**Hur kan jag kopiera SmartArt till samma bild eller till en annan presentation samtidigt som formateringen bevaras?**

Du kan [klona SmartArt-formen](/slides/sv/php-java/shape-manipulations/) med [ShapeCollection::addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addclone/) eller [klona hela bilden](/slides/sv/php-java/clone-slides/) som innehåller SmartArt. Båda tillvägagångssätten bevarar storlek, position och formatering.

**Hur renderar jag SmartArt till en rasterbild för förhandsgranskning eller webexport?**

[Rendera bilden](/slides/sv/php-java/convert-powerpoint-to-png/) eller hela presentationen till PNG eller JPEG. SmartArt renderas som en del av bilden.

**Hur kan jag hitta ett specifikt SmartArt-objekt på en bild om det finns flera?**

Ange ett tydligt [Shape::getAlternativeText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getalternativetext/) eller [Shape::getName](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getname/) värde på SmartArt-formen, sök efter det värdet i [BaseSlide::getShapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslide/#getShapes), och kontrollera sedan att den matchande formen är en [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartart/).