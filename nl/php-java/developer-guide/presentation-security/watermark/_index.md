---
title: Voeg watermerken toe aan presentaties in PHP
linktitle: Watermerk
type: docs
weight: 40
url: /nl/php-java/watermark/
keywords:
- watermerk
- tekstwatermerk
- afbeeldingswatermerk
- watermerk toevoegen
- watermerk wijzigen
- watermerk verwijderen
- watermerk wissen
- watermerk toevoegen aan PPT
- watermerk toevoegen aan PPTX
- watermerk toevoegen aan ODP
- watermerk verwijderen van PPT
- watermerk verwijderen van PPTX
- watermerk verwijderen van ODP
- watermerk wissen van PPT
- watermerk wissen van PPTX
- watermerk wissen van ODP
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer tekst- en afbeeldingwatermerken in PowerPoint- en OpenDocument-presentaties in PHP om een concept, vertrouwelijke informatie, auteursrecht en meer aan te geven."
---
## **Introductie**

Een watermerk in een presentatie is een tekst‑ of afbeeldingstempel die op een dia of op alle dia's van de presentatie wordt gebruikt. Meestal wordt een watermerk gebruikt om aan te geven dat de presentatie een concept is (bijv. een “Concept” watermerk), dat deze vertrouwelijke informatie bevat (bijv. een “Vertrouwelijk” watermerk), om te specificeren bij welk bedrijf het hoort (bijv. een “Bedrijfsnaam” watermerk), om de auteur van de presentatie te identificeren, enzovoort. Een watermerk helpt auteursrechtinbreuken te voorkomen door aan te geven dat de presentatie niet gekopieerd mag worden. Watermerken worden gebruikt in zowel PowerPoint‑ als OpenOffice‑presentatieformaten. In Aspose.Slides kunt u een watermerk toevoegen aan PowerPoint‑PPT, PPTX en OpenOffice‑ODP‑bestandsformaten.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/php-java/) zijn er verschillende manieren om watermerken in PowerPoint‑ of OpenOffice‑documenten te maken en hun ontwerp en gedrag aan te passen. Het gemeenschappelijke aspect is dat u voor het toevoegen van tekstwatermerken de klasse [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) moet gebruiken, en om afbeeldingwatermerken toe te voegen, gebruik u de klasse [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) of vul u een watermerk‑vorm met een afbeelding. `PictureFrame` implementeert de klasse [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/), waardoor u alle flexibele instellingen van het vormobject kunt gebruiken. Omdat `ITextFrame` geen vorm is en de instellingen beperkt zijn, wordt deze ingepakt in een [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/)‑object.

Er zijn twee manieren waarop een watermerk kan worden toegepast: op één enkele dia of op alle dia's van de presentatie. De Slide Master wordt gebruikt om een watermerk op alle dia's van de presentatie toe te passen — het watermerk wordt aan de Slide Master toegevoegd, daar volledig vormgegeven, en op alle dia's toegepast zonder de mogelijkheid om het watermerk op individuele dia's te wijzigen.

Een watermerk wordt meestal beschouwd als niet bewerkbaar voor andere gebruikers. Om te voorkomen dat het watermerk (of beter gezegd de bovenliggende vorm van het watermerk) wordt bewerkt, biedt Aspose.Slides functionaliteit voor vormvergrendeling. Een specifieke vorm kan vergrendeld worden op een gewone dia of op een Slide Master. Wanneer de watermerk‑vorm op de Slide Master vergrendeld is, is deze op alle presentatiedia's vergrendeld.

U kunt een naam aan het watermerk toewijzen zodat u het later, wanneer u het wilt verwijderen, kunt vinden in de vormen van de dia op basis van die naam.

U kunt het watermerk op elke gewenste manier vormgeven; er zijn echter meestal gemeenschappelijke kenmerken in watermerken, zoals centrering, rotatie, voorste positie, enzovoort. We zullen hieronder laten zien hoe u deze kunt gebruiken in de voorbeelden.

## **Tekstwatermerk**

### **Een tekstwatermerk aan een dia toevoegen**

Om een tekstwatermerk toe te voegen in PPT, PPTX of ODP, kunt u eerst een vorm aan de dia toevoegen, vervolgens een tekstframe aan die vorm. Het tekstframe wordt vertegenwoordigd door de klasse [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/). Dit type erft niet van [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/), die een brede set eigenschappen heeft om het watermerk flexibel te positioneren. Daarom wordt het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/)‑object ingepakt in een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/)‑object. Om watermerktekst aan de vorm toe te voegen, gebruikt u de methode [addTextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/#addTextFrame) zoals hieronder weergegeven.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Zie ook" %}} 
- [Hoe de TextFrame‑klasse te gebruiken](/slides/nl/php-java/text-formatting/)
{{% /alert %}}

### **Een tekstwatermerk aan een presentatie toevoegen**

Als u een tekstwatermerk wilt toevoegen aan de volledige presentatie (dus aan alle dia's tegelijk), voeg het dan toe aan de [MasterSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/). De rest van de logica is hetzelfde als bij het toevoegen van een watermerk aan één dia — maak een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) object aan en voeg vervolgens het watermerk toe met de methode [addTextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/#addTextFrame).

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Zie ook" %}} 
- [Hoe de Slide Master te gebruiken](/slides/nl/php-java/slide-master/)
{{% /alert %}}

### **Transparantie van de watermerkvorm instellen**

Standaard wordt de rechthoekvorm opgemaakt met vul‑ en lijng kleuren. De volgende regels code maken de vorm transparant.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **Lettertype van een tekstwatermerk instellen**

U kunt het lettertype van het tekstwatermerk wijzigen zoals hieronder getoond.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **Kleur van het watermerktekst instellen**

Om de kleur van de watermerktekst in te stellen, gebruikt u deze code:

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **Een tekstwatermerk centreren**

Het is mogelijk om het watermerk op een dia te centreren; daarvoor kunt u het volgende doen:

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

De afbeelding hieronder toont het eindresultaat.

![Het tekstwatermerk](text_watermark.png)

## **Afbeeldingswatermerk**

### **Een afbeeldingswatermerk aan een presentatie toevoegen**

Om een afbeeldingswatermerk aan een presentatiedia toe te voegen, kunt u het volgende doen:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **Een watermerk vergrendelen tegen bewerken**

Indien het nodig is om een watermerk tegen bewerken te beschermen, gebruikt u de methode [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/#getAutoShapeLock) op de vorm. Met deze eigenschap kunt u de vorm beschermen tegen selecteren, schalen, verplaatsen, groeperen met andere elementen, de tekst vergrendelen tegen bewerken, en meer:

```php
// Vergrendel de watermerkvorm tegen bewerken
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **Een watermerk naar voren brengen**

In Aspose.Slides kan de Z‑volgorde van vormen worden ingesteld via de methode [ShapeCollection.reorder](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#reorder). Hiervoor roept u deze methode aan vanuit de lijst van presentatiedia's en geeft u de referentie naar de vorm en het volgnummer door. Op deze manier kunt u een vorm naar de voorgrond brengen of naar de achtergrond van de dia sturen. Deze functionaliteit is vooral handig wanneer u een watermerk vóór de presentatie‑inhoud wilt plaatsen:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **Rotatie van het watermerk instellen**

Hier is een code‑voorbeeld van hoe u de rotatie van het watermerk kunt aanpassen zodat het diagonaal over de dia ligt:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **Een naam aan een watermerk toewijzen**

Aspose.Slides maakt het mogelijk om de naam van een vorm in te stellen. Door de vormnaam te gebruiken, kunt u later de vorm benaderen om deze aan te passen of te verwijderen. Om de naam van de watermerkvorm in te stellen, kent u deze toe via de methode [AutoShape.setName](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#setName):

```php
$watermarkShape->setName("watermark");
```

### **Een watermerk verwijderen**

Om de watermerkvorm te verwijderen, gebruikt u de methode [AutoShape.getName](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getName) om deze te vinden in de vormen van de dia. Vervolgens geeft u de watermerkvorm door aan de methode [ShapeCollection.remove](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#remove):

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **FAQ**

**Wat is een watermerk en waarom zou ik het gebruiken?**

Een watermerk is een tekst‑ of afbeeldingsoverlay die op dia's wordt aangebracht en helpt intellectueel eigendom te beschermen, de merkherkenning te vergroten of ongeautoriseerd gebruik van presentaties te voorkomen.

**Kan ik een watermerk aan alle dia's in een presentatie toevoegen?**

Ja, Aspose.Slides biedt de mogelijkheid om programmatisch een watermerk aan elke dia in een presentatie toe te voegen. U kunt door alle dia's itereren en de watermerk‑instellingen per dia toepassen.

**Hoe kan ik de transparantie van het watermerk aanpassen?**

U kunt de transparantie van het watermerk aanpassen door de vulinstellingen ([getFillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getfillformat/)) van de vorm te wijzigen. Hierdoor blijft het watermerk subtiel en stoort het de inhoud van de dia niet.

**Welke afbeeldingsformaten worden ondersteund voor watermerken?**

Aspose.Slides ondersteunt diverse afbeeldingsformaten zoals PNG, JPEG, GIF, BMP, SVG en meer.

**Kan ik het lettertype en de stijl van een tekstwatermerk aanpassen?**

Ja, u kunt elk lettertype, grootte en stijl kiezen om aan te sluiten bij het ontwerp van uw presentatie en de merkconsistentie te behouden.

**Hoe wijzig ik de positie of oriëntatie van een watermerk?**

U kunt de positie en oriëntatie van het watermerk programmatisch aanpassen door de coördinaten, afmetingen en rotatie‑eigenschappen van de vorm te wijzigen.