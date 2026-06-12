---
title: Beheer Presentatie-Zoom in PHP
linktitle: Zoom beheren
type: docs
weight: 60
url: /nl/php-java/manage-zoom/
keywords:
- zoom
- zoomframe
- diazoom
- sectiezoom
- samenvattingzoom
- zoom toevoegen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Maak en pas Zoom aan met Aspose.Slides voor PHP via Java — spring tussen secties, voeg miniaturen en overgangen toe in PPT-, PPTX- en ODP-presentaties."
---
## **Introductie**

Zooms in PowerPoint stellen je in staat om te springen naar en van specifieke dia's, secties en delen van een presentatie. Wanneer je presenteert, kan deze mogelijkheid om snel door de inhoud te navigeren erg handig zijn. 

![overview_image](overview.png)

* Om een volledige presentatie samen te vatten op één dia, gebruik een [Samenvatting Zoom](#Summary-Zoom).
* Om alleen geselecteerde dia's te tonen, gebruik een [Dia Zoom](#Slide-Zoom).
* Om alleen een enkele sectie te tonen, gebruik een [Sectie Zoom](#Section-Zoom).

## **Dia Zoom**
Een dia zoom kan je presentatie dynamischer maken, waardoor je vrij kunt navigeren tussen dia's in elke gewenste volgorde zonder de flow van je presentatie te onderbreken. Dia zooms zijn uitstekend voor korte presentaties zonder veel secties, maar je kunt ze ook in verschillende presentatiescenario’s gebruiken.

Dia zooms helpen je om meerdere stukken informatie te onderzoeken terwijl je het gevoel hebt op één enkel canvas te werken. 

![overview_image](slidezoomsel.png)

Voor dia zoom‑objecten biedt Aspose.Slides de [ZoomImageType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/zoomimagetype/)‑enumeratie, de [ZoomFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/zoomframe/)‑klasse en enkele methoden onder de [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/)‑klasse.

### **Zoom‑frames maken**

Je kunt een zoom‑frame op een dia toevoegen op deze manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
2. Maak nieuwe dia’s aan waaraan je de zoom‑frames wilt koppelen. 
3. Voeg een identificatietekst en een achtergrond toe aan de aangemaakte dia’s.
4. Voeg zoom‑frames (met de verwijzingen naar de aangemaakte dia’s) toe aan de eerste dia.
5. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze PHP‑code laat zien hoe je een zoom‑frame op een dia maakt:

```php
  $pres = new Presentation();
  try {
    # Voegt nieuwe dia's toe aan de presentatie
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Creëert een achtergrond voor de tweede dia
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Creëert een tekstvak voor de tweede dia
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Creëert een achtergrond voor de derde dia
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Creëert een tekstvak voor de derde dia
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Voegt ZoomFrame-objecten toe
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Slaat de presentatie op
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Zoom‑frames maken met aangepaste afbeeldingen**
Met Aspose.Slides for PHP via Java kun je een zoom‑frame met een andere dia‑voorbeeldafbeelding maken op deze manier:
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
2. Maak een nieuwe dia aan waaraan je het zoom‑frame wilt koppelen. 
3. Voeg een identificatietekst en een achtergrond toe aan de dia.
4. Maak een [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/)‑object door een afbeelding toe te voegen aan de Images‑collectie die bij het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑object hoort en die gebruikt zal worden om het frame te vullen.
5. Voeg zoom‑frames (met de verwijzing naar de aangemaakte dia) toe aan de eerste dia.
6. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze PHP‑code laat zien hoe je een zoom‑frame met een andere afbeelding maakt:

```php
  $pres = new Presentation();
  try {
    # Voegt een nieuwe dia toe aan de presentatie
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Creëert een achtergrond voor de tweede dia
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Creëert een tekstvak voor de derde dia
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Creëert een nieuwe afbeelding voor het zoom‑object
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Voegt het ZoomFrame‑object toe
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # Slaat de presentatie op
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Zoom‑frames opmaken**
In de vorige secties hebben we je laten zien hoe je eenvoudige zoom‑frames maakt. Om meer gecompliceerde zoom‑frames te maken, moet je de opmaak van een eenvoudig frame aanpassen. Er zijn verschillende opmaakopties die je kunt toepassen op een zoom‑frame. 

Je kunt de opmaak van een zoom‑frame op een dia als volgt regelen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
2. Maak nieuwe dia’s aan om naar te linken waar je het zoom‑frame wilt koppelen. 
3. Voeg enige identificatietekst en een achtergrond toe aan de aangemaakte dia’s.
4. Voeg zoom‑frames (met de verwijzingen naar de aangemaakte dia’s) toe aan de eerste dia.
5. Maak een [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/)‑object door een afbeelding toe te voegen aan de Images‑collectie die bij het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑object hoort en die gebruikt zal worden om het frame te vullen.
6. Stel een aangepaste afbeelding in voor het eerste zoom‑frame‑object.
7. Verander het lijnformaat voor het tweede zoom‑frame‑object.
8. Verwijder de achtergrond van de afbeelding van het tweede zoom‑frame‑object.
5. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze PHP‑code laat zien hoe je de opmaak van een zoom‑frame op een dia verandert:

```php
  $pres = new Presentation();
  try {
    # Voegt nieuwe dia's toe aan de presentatie
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Creëert een achtergrond voor de tweede dia
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Creëert een tekstvak voor de tweede dia
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Creëert een achtergrond voor de derde dia
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Creëert een tekstvak voor de derde dia
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Voegt ZoomFrame-objecten toe
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Creëert een nieuwe afbeelding voor het zoom‑object
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Stelt een aangepaste afbeelding in voor zoomFrame1-object
    $zoomFrame1->setImage($picture);
    # Stelt een zoom‑frame‑formaat in voor zoomFrame2-object
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # Instelling: geen achtergrond weergeven voor zoomFrame2-object
    $zoomFrame2->setShowBackground(false);
    # Slaat de presentatie op
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Sectie Zoom**

Een sectie zoom is een koppeling naar een sectie in je presentatie. Je kunt sectie‑zooms gebruiken om terug te gaan naar secties die je echt wilt benadrukken. Of je kunt ze gebruiken om te laten zien hoe bepaalde delen van je presentatie met elkaar verbonden zijn. 

![overview_image](seczoomsel.png)

Voor sectie‑zoom‑objecten biedt Aspose.Slides de [SectionZoomFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sectionzoomframe/)‑klasse en enkele methoden onder de [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/)‑klasse.

### **Sectie‑zoom‑frames maken**

Je kunt een sectie‑zoom‑frame aan een dia toevoegen op deze manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
2. Maak een nieuwe dia. 
3. Voeg een identificatie‑achtergrond toe aan de aangemaakte dia.
4. Maak een nieuwe sectie aan waaraan je het zoom‑frame wilt koppelen. 
5. Voeg een sectie‑zoom‑frame (met verwijzingen naar de aangemaakte sectie) toe aan de eerste dia.
6. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze PHP‑code laat zien hoe je een zoom‑frame op een dia maakt:

```php
  $pres = new Presentation();
  try {
    # Voegt een nieuwe dia toe aan de presentatie
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Voegt een nieuwe sectie toe aan de presentatie
    $pres->getSections()->addSection("Section 1", $slide);
    # Voegt een SectionZoomFrame-object toe
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Slaat de presentatie op
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Sectie‑zoom‑frames maken met aangepaste afbeeldingen**

Met Aspose.Slides for PHP via Java kun je een sectie‑zoom‑frame met een andere dia‑voorbeeldafbeelding maken op deze manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
2. Maak een nieuwe dia.
3. Voeg een identificatie‑achtergrond toe aan de aangemaakte dia.
4. Maak een nieuwe sectie aan waaraan je het zoom‑frame wilt koppelen. 
5. Maak een [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/)‑object door een afbeelding toe te voegen aan de Images‑collectie die bij het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑object hoort en die gebruikt zal worden om het frame te vullen.
5. Voeg een sectie‑zoom‑frame (met een verwijzing naar de aangemaakte sectie) toe aan de eerste dia.
6. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze PHP‑code laat zien hoe je een zoom‑frame met een andere afbeelding maakt:

```php
  $pres = new Presentation();
  try {
    # Voegt een nieuwe dia toe aan de presentatie
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Voegt een nieuwe sectie toe aan de presentatie
    $pres->getSections()->addSection("Section 1", $slide);
    # Creëert een nieuwe afbeelding voor het zoom‑object
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Voegt SectionZoomFrame-object toe
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # Slaat de presentatie op
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Sectie‑zoom‑frames opmaken**

Om meer gecompliceerde sectie‑zoom‑frames te maken, moet je de opmaak van een eenvoudig frame aanpassen. Er zijn verschillende opmaakopties die je kunt toepassen op een sectie‑zoom‑frame. 

Je kunt de opmaak van een sectie‑zoom‑frame op een dia als volgt regelen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
2. Maak een nieuwe dia.
3. Voeg identificatie‑achtergrond toe aan de aangemaakte dia.
4. Maak een nieuwe sectie aan waaraan je het zoom‑frame wilt koppelen. 
5. Voeg een sectie‑zoom‑frame (met verwijzingen naar de aangemaakte sectie) toe aan de eerste dia.
6. Verander de grootte en positie van het aangemaakte sectie‑zoom‑object.
7. Maak een [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/)‑object door een afbeelding toe te voegen aan de Images‑collectie die bij het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑object hoort en die gebruikt zal worden om het frame te vullen.
8. Stel een aangepaste afbeelding in voor het aangemaakte sectie‑zoom‑frame‑object.
9. Schakel de *terugkeer naar de originele dia vanuit de gekoppelde sectie* in. 
10. Verwijder de achtergrond van de afbeelding van het sectie‑zoom‑frame‑object.
11. Verander het lijnformaat voor het tweede zoom‑frame‑object.
12. Verander de overgangsduur.
13. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze PHP‑code laat zien hoe je de opmaak van een sectie‑zoom‑frame verandert:

```php
  $pres = new Presentation();
  try {
    # Voegt een nieuwe dia toe aan de presentatie
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Voegt een nieuwe sectie toe aan de presentatie
    $pres->getSections()->addSection("Section 1", $slide);
    # Voegt SectionZoomFrame-object toe
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Opmaak voor SectionZoomFrame
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $sectionZoomFrame->setImage($picture);
    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);
    $sectionZoomFrame->setTransitionDuration(1.5);
    # Slaat de presentatie op
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Samenvatting Zoom**

Een samenvatting zoom is als een landingspagina waarop alle onderdelen van je presentatie in één keer worden getoond. Wanneer je presenteert, kun je de zoom gebruiken om van de ene plek in je presentatie naar een andere te gaan in elke gewenste volgorde. Je kunt creatief zijn, vooruit springen, of delen van je diavoorstelling opnieuw bekijken zonder de flow van je presentatie te onderbreken.

![overview_image](sumzoomsel.png)

Voor samenvatting‑zoom‑objecten biedt Aspose.Slides de [SummaryZoomFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/summaryzoomsection/) en [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/summaryzoomsectioncollection/) klassen en enkele methoden onder de [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/) klasse.

### **Een Samenvatting Zoom maken**

Je kunt een samenvatting‑zoom‑frame aan een dia toevoegen op deze manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
2. Maak nieuwe dia’s met identificatie‑achtergrond en nieuwe secties voor de aangemaakte dia’s.
3. Voeg het samenvatting‑zoom‑frame toe aan de eerste dia.
4. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze PHP‑code laat zien hoe je een samenvatting‑zoom‑frame op een dia maakt:

```php
  $pres = new Presentation();
  try {
    # Voegt een nieuwe dia toe aan de presentatie
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Voegt een nieuwe sectie toe aan de presentatie
    $pres->getSections()->addSection("Section 1", $slide);
    # Voegt een nieuwe dia toe aan de presentatie
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Voegt een nieuwe sectie toe aan de presentatie
    $pres->getSections()->addSection("Section 2", $slide);
    # Voegt een nieuwe dia toe aan de presentatie
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Voegt een nieuwe sectie toe aan de presentatie
    $pres->getSections()->addSection("Section 3", $slide);
    # Voegt een nieuwe dia toe aan de presentatie
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Voegt een nieuwe sectie toe aan de presentatie
    $pres->getSections()->addSection("Section 4", $slide);
    # Voegt een SummaryZoomFrame-object toe
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Slaat de presentatie op
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Een Samenvatting Zoom‑sectie toevoegen en verwijderen**

Alle secties in een samenvatting‑zoom‑frame worden weergegeven door [SummaryZoomSection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/summaryzoomsection/)‑objecten, die worden opgeslagen in het [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/summaryzoomsectioncollection/)‑object. Je kunt een samenvatting‑zoom‑sectie‑object toevoegen of verwijderen via de [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/summaryzoomsectioncollection/)‑klasse op deze manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
2. Maak nieuwe dia’s met identificatie‑achtergrond en nieuwe secties voor de aangemaakte dia’s.
3. Voeg een samenvatting‑zoom‑frame toe aan de eerste dia.
4. Voeg een nieuwe dia en sectie toe aan de presentatie.
5. Voeg de aangemaakte sectie toe aan het samenvatting‑zoom‑frame.
6. Verwijder de eerste sectie uit het samenvatting‑zoom‑frame.
7. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze PHP‑code laat zien hoe je secties in een samenvatting‑zoom‑frame toevoegt en verwijdert:

```php
  $pres = new Presentation();
  try {
    # Voegt een nieuwe dia toe aan de presentatie
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Voegt een nieuwe sectie toe aan de presentatie
    $pres->getSections()->addSection("Section 1", $slide);
    # Voegt een nieuwe dia toe aan de presentatie
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Voegt een nieuwe sectie toe aan de presentatie
    $pres->getSections()->addSection("Section 2", $slide);
    # Voegt SummaryZoomFrame-object toe
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Voegt een nieuwe dia toe aan de presentatie
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Voegt een nieuwe sectie toe aan de presentatie
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # Voegt een sectie toe aan de Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Verwijdert een sectie uit de Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # Slaat de presentatie op
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Samenvatting Zoom‑secties opmaken**

Om meer gecompliceerde samenvatting‑zoom‑sectie‑objecten te maken, moet je de opmaak van een eenvoudig frame aanpassen. Er zijn verschillende opmaakopties die je kunt toepassen op een samenvatting‑zoom‑sectie‑object. 

Je kunt de opmaak van een samenvatting‑zoom‑sectie‑object in een samenvatting‑zoom‑frame als volgt regelen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
2. Maak nieuwe dia’s met identificatie‑achtergrond en nieuwe secties voor de aangemaakte dia’s.
3. Voeg een samenvatting‑zoom‑frame toe aan de eerste dia.
4. Haal een samenvatting‑zoom‑sectie‑object op voor het eerste object uit de `SummaryZoomSectionCollection`.
7. Maak een [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/)‑object door een afbeelding toe te voegen aan de images‑collectie die bij het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑object hoort en die gebruikt zal worden om het frame te vullen.
8. Stel een aangepaste afbeelding in voor het aangemaakte sectie‑zoom‑frame‑object.
9. Schakel de *terugkeer naar de originele dia vanuit de gekoppelde sectie* in. 
11. Verander het lijnformaat voor het tweede zoom‑frame‑object.
12. Verander de overgangsduur.
13. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze PHP‑code laat zien hoe je de opmaak van een samenvatting‑zoom‑sectie‑object verandert:

```php
  $pres = new Presentation();
  try {
    # Voegt een nieuwe dia toe aan de presentatie
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Voegt een nieuwe sectie toe aan de presentatie
    $pres->getSections()->addSection("Section 1", $slide);
    # Voegt een nieuwe dia toe aan de presentatie
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Voegt een nieuwe sectie toe aan de presentatie
    $pres->getSections()->addSection("Section 2", $slide);
    # Voegt een SummaryZoomFrame-object toe
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Haalt het eerste SummaryZoomSection-object op
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # Opmaak voor SummaryZoomSection-object
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $summarySection->setImage($picture);
    $summarySection->setReturnToParent(false);
    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->black);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);
    $summarySection->setTransitionDuration(1.5);
    # Slaat de presentatie op
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan ik het terugkeren naar de ‘ouder’-dia controleren nadat het doel is getoond?**

Ja. Het [Zoom frame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/zoomframe/) of de [sectie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sectionzoomframe/) heeft een `ReturnToParent`‑gedrag dat, wanneer ingeschakeld, kijkers terugstuurt naar de oorspronkelijke dia nadat ze de doelinhoud hebben bezocht.

**Kan ik de ‘snelheid’ of duur van de Zoom‑overgang aanpassen?**

Ja. Zoom ondersteunt het instellen van een `TransitionDuration` zodat je kunt bepalen hoe lang de springanimatie duurt.

**Zijn er limieten voor hoeveel Zoom‑objecten een presentatie kan bevatten?**

Er is geen harde API‑limiet gedocumenteerd. Praktische limieten hangen af van de algehele complexiteit van de presentatie en de prestaties van de viewer. Je kunt veel Zoom‑frames toevoegen, maar houd rekening met bestandsgrootte en renderingtijd.