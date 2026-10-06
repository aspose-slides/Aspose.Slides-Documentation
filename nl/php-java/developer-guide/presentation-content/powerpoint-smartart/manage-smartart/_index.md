---
title: Beheer SmartArt in PowerPoint-presentaties met PHP
linktitle: Beheer SmartArt
type: docs
weight: 10
url: /nl/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt-tekst
- lay-outtype
- verborgen eigenschap
- organigram
- afbeeldings-organigram
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u PowerPoint‑SmartArt kunt bouwen en bewerken met Aspose.Slides voor PHP via Java, met duidelijke code‑voorbeelden die het ontwerpen en automatiseren van dia's versnellen."
---
## **Overzicht**

SmartArt is een PowerPoint‑diagram bestaande uit knooppunten, knooppuntvormen en een indeling. Met Aspose.Slides voor PHP via Java kun je SmartArt maken, tekst lezen uit de knooppunten, de indeling wijzigen, verborgen knooppunten inspecteren, organisatie‑diagramindelingen configureren en afbeeldings‑organisatie‑diagrammen maken.

## **Tekst ophalen uit een SmartArt‑object**

Een SmartArt‑knooppunt kan één of meer vormen bevatten. Om tekst uit de knooppuntvormen te lezen, doorloop je [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/), vervolgens lees je het [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) dat wordt geretourneerd door [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/).

Het voorbeeld vereist een presentatie met minstens één dia en een SmartArt‑object als de eerste vorm op die dia. Het drukt elk beschikbaar tekstframe af naar de console.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Lay‑outtype van een SmartArt‑object wijzigen**

De SmartArt‑lay‑out bepaalt hoe knooppunten worden gerangschikt en verbonden. Het volgende voorbeeld maakt een SmartArt‑object met de [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`‑waarde, wijzigt deze naar de `BasicProcess`‑waarde en slaat de presentatie op. De positie en grootte die aan [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) worden doorgegeven, worden gemeten in points. Gebruik [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) om de lay‑out te wijzigen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Controleren of een SmartArt‑knooppunt verborgen is**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) geeft aan of het knooppunt verborgen is in het SmartArt‑datamodel. Verborgen knooppunten kunnen in de structuur bestaan, zelfs wanneer de geselecteerde lay‑out ze niet toont als zichtbare diagramonderdelen.

Het volgende voorbeeld voegt een knooppunt toe aan een SmartArt‑object dat de [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `RadialCycle`‑waarde gebruikt en controleert de verborgen status van het toegevoegde knooppunt. Het drukt een bericht af als het knooppunt verborgen is en slaat het diagram op.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **De lay‑out van een organigram ophalen of instellen**

Voor SmartArt‑diagrammen die een organigram‑lay‑out gebruiken, definiëren [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) en [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) hoe kindknooppunten onder een ouderknooppunt worden gerangschikt. Je kunt bijvoorbeeld kindknooppunten laten hangen aan de linker-, rechter- of beide zijden, afhankelijk van het geselecteerde [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/).

Het volgende voorbeeld maakt een organigram en stelt de lay‑out van het eerste knooppunt in op de [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`‑waarde. De nul‑gebaseerde index `0` selecteert het eerste top‑niveau knooppunt; de kindknooppunten gebruiken de geselecteerde rangschikking. De aangepaste presentatie wordt vervolgens opgeslagen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Een afbeeldings‑organigram maken**

Een afbeeldings‑organigram is een SmartArt‑lay‑out ontworpen voor hiërarchische diagrammen die afbeeldings‑plaatsvervullingen bevatten. Gebruik de [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`‑waarde bij het toevoegen van het SmartArt‑object aan een dia. Dit voorbeeld slaat een diagram op met afbeelding‑plaatsvervullingen; het vult de plaatsvervullingen niet met afbeeldingen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Legacy‑diagrammen omzetten naar groepen vormen**

Bij het moderniseren van een bestaande presentatie moet je mogelijk een organigram dat oorspronkelijk is gemaakt in PowerPoint 97–2003 bijwerken. Aspose.Slides vertegenwoordigt deze legacy‑diagrammen als [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/)‑objecten. Gebruik [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/) om een diagram om te zetten in een groep vormen zodat je individuele visuele elementen kunt bewerken. Zie de [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) voor details.

Conversie voegt een nieuwe groep toe aan de vormverzameling zonder het oorspronkelijke diagram te verwijderen. Na een succesvolle conversie verwijder je het origineel met [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) om dubbele inhoud te vermijden. Verzamel de legacy‑diagrammen in een lijst voordat je ze converteert, zodat het toevoegen en verwijderen van vormen de iteratie niet verstoort.

Het volgende voorbeeld opent een presentatie, doorzoekt elke dia, zet de diagrammen om naar groepen vormen en slaat de bijgewerkte presentatie op als PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De opgeslagen presentatie bevat bewerkbare groepen vormen op de plaats van de geconverteerde legacy‑diagrammen, zonder dat de oorspronkelijke diagrammen behouden blijven. Open het PPTX‑bestand in PowerPoint om individuele elementen binnen elke groep te bewerken, zoals hun tekst, opvulling of positie.

## **FAQ**

**Ondersteunt SmartArt spiegelen of omkeren voor RTL‑talen?**

Ja. De [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/)‑methode schakelt de diagramrichting van links‑naar‑rechts naar rechts‑naar‑links, of terug, wanneer de geselecteerde SmartArt‑lay‑out omkering ondersteunt.

**Hoe kan ik SmartArt naar dezelfde dia of naar een andere presentatie kopiëren terwijl ik de opmaak behoud?**

Je kunt de [kloon de SmartArt‑vorm](/slides/nl/php-java/shape-manipulations/) met [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) klonen of de [kloon de hele dia](/slides/nl/php-java/clone-slides/) die de SmartArt bevat klonen. Beide benaderingen behouden grootte, positie en opmaak.

**Hoe render ik SmartArt naar een raster‑afbeelding voor voorbeeld of web‑export?**

[Render de dia](/slides/nl/php-java/convert-powerpoint-to-png/) of de hele presentatie naar PNG of JPEG. SmartArt wordt gerenderd als onderdeel van de dia.

**Hoe kan ik een specifiek SmartArt‑object op een dia vinden als er meerdere zijn?**

Gebruik [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) of [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) om een onderscheidende alternatieve tekst of naam toe te wijzen aan de SmartArt‑vorm, zoek vervolgens die waarde in [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) en controleer daarna dat de overeenkomstige vorm een [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) is.