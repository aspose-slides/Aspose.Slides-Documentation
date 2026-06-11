---
title: Lägg till vattenstämplar i presentationer i PHP
linktitle: Vattenstämpel
type: docs
weight: 40
url: /sv/php-java/watermark/
keywords:
- vattenstämpel
- textvattenstämpel
- bildvattenstämpel
- lägg till vattenstämpel
- ändra vattenstämpel
- ta bort vattenstämpel
- radera vattenstämpel
- lägg till vattenstämpel i PPT
- lägg till vattenstämpel i PPTX
- lägg till vattenstämpel i ODP
- ta bort vattenstämpel från PPT
- ta bort vattenstämpel från PPTX
- ta bort vattenstämpel från ODP
- radera vattenstämpel från PPT
- radera vattenstämpel från PPTX
- radera vattenstämpel från ODP
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Hantera text- och bildvattenstämplar i PowerPoint- och OpenDocument-presentationer i PHP för att indikera ett utkast, konfidentiell information, upphovsrätt och mer."
---
## **Introduktion**

**Ett vattenstämpel** i en presentation är ett text‑ eller bildstempel som används på en bild eller på alla bilder i presentationen. Vanligtvis används ett vattenstämpel för att ange att presentationen är ett utkast (t.ex. ett ”Utkast”-vattenstämpel), att den innehåller konfidentiell information (t.ex. ett ”Konfidentiellt”-vattenstämpel), för att ange vilket företag den tillhör (t.ex. ett ”Företagsnamn”-vattenstämpel), för att identifiera författaren till presentationen osv. Ett vattenstämpel hjälper till att förhindra upphovsrättsintrång genom att indikera att presentationen inte får kopieras. Vattenstämplar används både i PowerPoint‑ och OpenOffice‑presentationsformat. I Aspose.Slides kan du lägga till ett vattenstämpel i PowerPoint‑PPT, PPTX och OpenOffice‑ODP‑filformat.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/php-java/) finns olika sätt att skapa vattenstämplar i PowerPoint‑ eller OpenOffice‑dokument och att ändra deras utformning och beteende. Det gemensamma är att för att lägga till textvattenstämplar bör du använda klassen [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/), och för att lägga till bildvattenstämplar, använd klassen [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/) eller fyll en vattenstämpel‑form med en bild. `PictureFrame` implementerar klassen [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/), vilket gör att du kan använda alla flexibla inställningar för formobjektet. Eftersom `ITextFrame` inte är en form och dess inställningar är begränsade, omsluts den i ett [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/)-objekt.

Det finns två sätt att applicera ett vattenstämpel: på en enskild bild eller på alla bilder i presentationen. Slide Master används för att applicera ett vattenstämpel på alla bilder — vattenstämpeln läggs till i Slide Master, designas helt där och appliceras på alla bilder utan att påverka möjligheten att redigera vattenstämpeln på enskilda bilder.

Ett vattenstämpel anses vanligtvis vara otillgängligt för redigering av andra användare. För att förhindra att vattenstämpeln (eller snarare dess överordnade form) redigeras, erbjuder Aspose.Slides låsning av former. En specifik form kan låsas på en normal bild eller på en Slide Master. När vattenstämpelformen låses på Slide Master, låses den på alla bilder i presentationen.

Du kan ange ett namn för vattenstämpeln så att du i framtiden, om du vill ta bort den, kan hitta den i bildens former efter namn.

Du kan designa vattenstämpeln på valfritt sätt; men det finns vanligtvis gemensamma drag i vattenstämplar, såsom centrering, rotation, framre position osv. Vi kommer att titta på hur man använder dessa i exemplen nedan.

## **Textvattenstämpel**

### **Lägg till ett textvattenstämpel på en bild**

För att lägga till ett textvattenstämpel i PPT, PPTX eller ODP kan du först lägga till en form på bilden, sedan lägga till en textram i den formen. Textramen representeras av klassen [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/). Denna typ är inteärvd från [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/), som har ett brett urval av egenskaper för att positionera vattenstämpeln på ett flexibelt sätt. Därför omsluts [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/)-objektet i ett [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/)-objekt. För att lägga till vattenstämpeltext i formen, använd metoden [addTextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/#addTextFrame) enligt nedan.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Se också" %}} 
- [Hur du använder TextFrame‑klassen](/slides/sv/php-java/text-formatting/)
{{% /alert %}}

### **Lägg till ett textvattenstämpel i en presentation**

Om du vill lägga till ett textvattenstämpel i hela presentationen (dvs. alla bilder på en gång), lägg till det i [MasterSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/). Resten av logiken är densamma som när du lägger till ett vattenstämpel på en enskild bild — skapa ett [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/)-objekt och lägg sedan till vattenstämpeln i det med hjälp av metoden [addTextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/#addTextFrame).

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Se också" %}} 
- [Hur du använder Slide Master](/slides/sv/php-java/slide-master/)
{{% /alert %}}

### **Ställ in transparens för vattenstämpelform**

Som standard är rektangelformen stylad med fyllnings‑ och linjefärger. Följande kodrad gör formen transparent.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **Ställ in typsnitt för ett textvattenstämpel**

Du kan ändra typsnittet för textvattenstämpeln enligt nedan.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **Ställ in färg för vattenstämpeltext**

För att ange färg på vattenstämpeltexten, använd denna kod:

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

### **Centrera ett textvattenstämpel**

Det är möjligt att centrera vattenstämpeln på en bild, och för att göra det kan du göra följande:

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

Bilden nedan visar slutresultatet.

![The text watermark](text_watermark.png)

## **Bildvattenstämpel**

### **Lägg till ett bildvattenstämpel i en presentation**

För att lägga till ett bildvattenstämpel i en presentationsbild kan du göra följande:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **Lås ett vattenstämpel från redigering**

Om det är nödvändigt att förhindra att ett vattenstämpel redigeras, använd metoden [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/#getAutoShapeLock) på formen. Med denna egenskap kan du skydda formen från att väljas, ändras i storlek, flyttas, grupperas med andra element, låsa dess text från redigering med mera:

```php
// Lås vattenstämpelformen från att ändras
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **Flytta ett vattenstämpel framåt**

I Aspose.Slides kan Z‑ordningen för former ställas in via metoden [ShapeCollection.reorder](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/#reorder). För att göra detta måste du anropa metoden från listan med presentationsbilder och skicka referensen till formen samt dess ordningsnummer till metoden. På så sätt är det möjligt att flytta en form framåt eller skicka den bakåt på bilden. Denna funktion är särskilt användbar om du behöver placera ett vattenstämpel framför presentationen:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **Ställ in rotation för vattenstämpel**

Här är ett kodexempel på hur du justerar rotationen av vattenstämpeln så att den placeras diagonalt över bilden:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **Ställ in ett namn för ett vattenstämpel**

Aspose.Slides låter dig ange ett namn för en form. Genom att använda formulärnamnet kan du i framtiden nå den för att modifiera eller ta bort den. För att ange namn på vattenstämpelformen, tilldela den till metoden [AutoShape.setName](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#setName):

```php
$watermarkShape->setName("watermark");
```

### **Ta bort ett vattenstämpel**

För att ta bort vattenstämpelformen, använd metoden [AutoShape.getName](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getName) för att hitta den i bildens former. Skicka sedan vattenstämpelformen till metoden [ShapeCollection.remove](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/#remove):

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **FAQ**

**Vad är ett vattenstämpel och varför ska jag använda det?**

Ett vattenstämpel är ett text‑ eller bildöverlägg som appliceras på bilder för att skydda immateriella rättigheter, stärka varumärkesigenkänning eller förhindra obehörig användning av presentationer.

**Kan jag lägga till ett vattenstämpel på alla bilder i en presentation?**

Ja, Aspose.Slides låter dig programatiskt lägga till ett vattenstämpel på varje bild i en presentation. Du kan iterera genom alla bilder och applicera vattenstämpelinställningarna individuellt.

**Hur kan jag justera transparensen för vattenstämpeln?**

Du kan justera transparensen för vattenstämpeln genom att modifiera fyllningsinställningarna ([getFillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getfillformat/)) för formen. Detta säkerställer att vattenstämpeln är subtil och inte distraherar från bildens innehåll.

**Vilka bildformat stöds för vattenstämplar?**

Aspose.Slides stöder olika bildformat såsom PNG, JPEG, GIF, BMP, SVG med mera.

**Kan jag anpassa typsnitt och stil för ett textvattenstämpel?**

Ja, du kan välja vilket typsnitt, storlek och stil som helst för att matcha designen av din presentation och upprätthålla varumärkeskonsistens.

**Hur ändrar jag position eller orientering för ett vattenstämpel?**

Du kan programatiskt justera position och orientering för vattenstämpeln genom att modifiera formens koordinater, storlek och rotationsegenskaper.