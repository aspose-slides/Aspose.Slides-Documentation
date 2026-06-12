---
title: Beheer SmartArt in PowerPoint-presentaties met PHP
linktitle: SmartArt beheren
type: docs
weight: 10
url: /nl/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt-tekst
- lay-outtype
- verborgen eigenschap
- organigram
- plaatjes-organigram
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer PowerPoint SmartArt maken en bewerken met Aspose.Slides voor PHP via Java met duidelijke codevoorbeelden die het ontwerpen en automatiseren van dia's versnellen."
---
## **Overzicht**

SmartArt is een PowerPoint-diagram dat bestaat uit knooppunten, knooppuntvormen en een lay-out. Met Aspose.Slides voor PHP via Java kunt u SmartArt maken, tekst uit de knooppunten lezen, de lay-out wijzigen, verborgen knooppunten inspecteren, lay-outs voor organigrammen configureren en diagrammen met plaatjesorganigrammen maken.

## **Tekst ophalen uit een SmartArt‑object**

Een SmartArt‑knooppunt kan één of meerdere vormen bevatten. Om de zichtbare tekst te lezen, doorloop u [SmartArt::getAllNodes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/#getAllNodes), en lees vervolgens het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) dat wordt geretourneerd door [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartshape/#getTextFrame).

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

## **Lay-outtype van een SmartArt‑object wijzigen**

De SmartArt‑lay-out bepaalt hoe knooppunten worden gerangschikt en verbonden. Het volgende voorbeeld maakt een SmartArt‑object met de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartlayouttype/)‑waarde `BasicBlockList`, wijzigt deze naar de waarde `BasicProcess` en slaat de presentatie op.

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

## **Controleren of een SmartArt‑knooppunt verborgen is**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartnode/ishidden/) geeft aan of het knooppunt verborgen is in het SmartArt‑datamodel. Verborgen knooppunten kunnen in de structuur bestaan, zelfs wanneer de geselecteerde lay-out ze niet als zichtbare diagramonderdelen weergeeft.

Het volgende voorbeeld voegt een knooppunt toe aan een SmartArt‑object dat de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartlayouttype/)‑waarde `RadialCycle` gebruikt en controleert de verborgen‑status van het knooppunt.

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

## **Organigram‑lay-out ophalen of instellen**

Voor SmartArt‑diagrammen die een organigram‑lay-out gebruiken, definiëren [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) en [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) hoe kindknooppunten onder een bovenliggend knooppunt worden gerangschikt. U kunt bijvoorbeeld kindknooppunten laten hangen aan de linker‑, rechter‑ of beide zijden, afhankelijk van de geselecteerde [OrganizationChartLayoutType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/organizationchartlayouttype/).

Het volgende voorbeeld maakt een organigram en stelt de lay-out van het eerste knooppunt in op de [OrganizationChartLayoutType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/organizationchartlayouttype/)‑waarde `LeftHanging`.

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

## **Een plaatjes‑organigram maken**

Een plaatjes‑organigram is een SmartArt‑lay-out die is bedoeld voor hiërarchiediagrammen met afbeeldings‑plaatsaanduiders. Gebruik de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartlayouttype/)‑waarde `PictureOrganizationChart` wanneer u het SmartArt‑object aan een dia toevoegt.

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

**Ondersteunt SmartArt spiegelen of omkeren voor RTL‑talen?**

Ja. De [SmartArt::setReversed](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/setreversed/)‑methode wisselt de diagramrichting van links‑naar‑rechts naar rechts‑naar‑links, of terug, wanneer de geselecteerde SmartArt‑lay-out omkering ondersteunt.

**Hoe kan ik SmartArt kopiëren naar dezelfde dia of naar een andere presentatie terwijl de opmaak behouden blijft?**

U kunt de SmartArt‑vorm [clonen](/slides/nl/php-java/shape-manipulations/) met [ShapeCollection::addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addclone/) of de hele dia [clonen](/slides/nl/php-java/clone-slides/) die de SmartArt bevat. Beide methoden behouden grootte, positie en opmaak.

**Hoe render ik SmartArt naar een rasterafbeelding voor een voorbeeld of export naar het web?**

[Render de dia](/slides/nl/php-java/convert-powerpoint-to-png/) of de hele presentatie naar PNG of JPEG. SmartArt wordt gerenderd als onderdeel van de dia.

**Hoe kan ik een specifiek SmartArt‑object op een dia vinden als er meerdere zijn?**

Stel een onderscheidende [Shape::getAlternativeText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getalternativetext/)‑ of [Shape::getName](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getname/)‑waarde in op de SmartArt‑vorm, zoek die waarde in [BaseSlide::getShapes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/#getShapes), en controleer vervolgens of de gevonden vorm een [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/).