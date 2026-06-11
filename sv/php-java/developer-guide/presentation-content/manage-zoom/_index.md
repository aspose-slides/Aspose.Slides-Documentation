---
title: Hantera Presentation Zoom i PHP
linktitle: Hantera Zoom
type: docs
weight: 60
url: /sv/php-java/manage-zoom/
keywords:
- zoom
- zoomram
- bildzoom
- avsnittszoom
- sammanfattningszoom
- lägg till zoom
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Skapa och anpassa Zoom med Aspose.Slides för PHP via Java — hoppa mellan avsnitt, lägg till miniatyrer och övergångar i PPT, PPTX och ODP-presentationer."
---
## **Introduktion**

Zoom-funktionen i PowerPoint låter dig hoppa till och från specifika bilder, avsnitt och delar av en presentation. När du presenterar kan denna förmåga att snabbt navigera genom innehållet vara mycket användbar. 

![overview_image](overview.png)

* För att sammanfatta en hel presentation på en enda bild, använd en [Summary Zoom](#Summary-Zoom).
* För att endast visa utvalda bilder, använd en [Slide Zoom](#Slide-Zoom).
* För att endast visa ett avsnitt, använd en [Section Zoom](#Section-Zoom).

## **Bildzoom**
En bildzoom kan göra din presentation mer dynamisk och låter dig navigera fritt mellan bilder i vilken ordning du önskar utan att avbryta flödet i din presentation. Bildzoomer är utmärkta för korta presentationer utan många avsnitt, men du kan fortfarande använda dem i olika presentationsscenario.

Bildzoomer hjälper dig att gräva ner i flera informationsbitar samtidigt som du känner dig på en enda duk. 

![overview_image](slidezoomsel.png)

För bildzoom-objekt tillhandahåller Aspose.Slides enumerationen [ZoomImageType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/zoomimagetype/), klassen [ZoomFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/zoomframe/) och några metoder under klassen [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/).

### **Skapa zoomramar**

Du kan lägga till en zoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Skapa nya bilder som du avser att länka zoomramarna till. 
3. Lägg till en identifieringstext och bakgrund till de skapade bilderna.
4. Lägg till zoomramar (som innehåller referenser till de skapade bilderna) på den första bilden.
5. Skriv den modifierade presentationen som en PPTX-fil.

```php
  $pres = new Presentation();
  try {
    # Lägger till nya bilder i presentationen
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Skapar en bakgrund för den andra bilden
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Skapar en textruta för den andra bilden
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Skapar en bakgrund för den tredje bilden
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Skapar en textruta för den tredje bilden
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Lägger till ZoomFrame-objekt
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Sparar presentationen
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Skapa zoomramar med anpassade bilder**
Med Aspose.Slides för PHP via Java kan du skapa en zoomram med en annan förhandsgranskningsbild på följande sätt:
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Skapa en ny bild som du avser att länka zoomramen till. 
3. Lägg till en identifieringstext och bakgrund till bilden.
4. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)-objekt genom att lägga till en bild i Images-samlingen som är associerad med [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)-objektet och som ska fylla ramen.
5. Lägg till zoomramar (som innehåller referensen till den skapade bilden) på den första bilden.
6. Skriv den modifierade presentationen som en PPTX-fil.

```php
  $pres = new Presentation();
  try {
    # Lägger till en ny bild i presentationen
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Skapar en bakgrund för den andra bilden
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Skapar en textruta för den tredje bilden
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Skapar en ny bild för zoom‑objektet
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Lägger till ZoomFrame‑objektet
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # Sparar presentationen
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Formatera zoomramar**
I föregående avsnitt visade vi hur du skapar enkla zoomramar. För att skapa mer komplicerade zoomramar måste du ändra formateringen för en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på en zoomram. 

Du kan kontrollera en zoomramss formatering på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Skapa nya bilder att länka till som du avser att länka zoomramen till. 
3. Lägg till någon identifieringstext och bakgrund till de skapade bilderna.
4. Lägg till zoomramar (som innehåller referenser till de skapade bilderna) på den första bilden.
5. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)-objekt genom att lägga till en bild i Images-samlingen som är associerad med [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)-objektet och som ska fylla ramen.
6. Ange en anpassad bild för det första zoomram-objektet.
7. Ändra linjeformatet för det andra zoomram-objektet.
8. Ta bort bakgrunden från bilden i det andra zoomram-objektet.
5. Skriv den modifierade presentationen som en PPTX-fil.

```php
  $pres = new Presentation();
  try {
    # Lägger till nya bilder i presentationen
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Skapar en bakgrund för den andra bilden
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Skapar en textruta för den andra bilden
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Skapar en bakgrund för den tredje bilden
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Skapar en textruta för den tredje bilden
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Lägger till ZoomFrame-objekt
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Skapar en ny bild för zoom-objektet
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Anger anpassad bild för zoomFrame1-objektet
    $zoomFrame1->setImage($picture);
    # Anger ett zoomramformat för zoomFrame2-objektet
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # Inställning för att inte visa bakgrund för zoomFrame2-objektet
    $zoomFrame2->setShowBackground(false);
    # Sparar presentationen
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Avsnittszoom**

En avsnittszoom är en länk till ett avsnitt i din presentation. Du kan använda avsnittszoomer för att gå tillbaka till avsnitt du verkligen vill betona. Eller så kan du använda dem för att visa hur vissa delar av din presentation hänger ihop. 

![overview_image](seczoomsel.png)

För avsnittszoom-objekt tillhandahåller Aspose.Slides klassen [SectionZoomFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sectionzoomframe/) och några metoder under klassen [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/).

### **Skapa avsnittszoomramar**

Du kan lägga till en avsnittszoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Skapa en ny bild. 
3. Lägg till en identifieringsbakgrund till den skapade bilden.
4. Skapa ett nytt avsnitt som du avser att länka zoomramen till. 
5. Lägg till en avsnittszoomram (som innehåller referenser till det skapade avsnittet) på den första bilden.
6. Skriv den modifierade presentationen som en PPTX-fil.

```php
  $pres = new Presentation();
  try {
    # Lägger till en ny bild i presentationen
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Lägger till ett nytt avsnitt i presentationen
    $pres->getSections()->addSection("Section 1", $slide);
    # Lägger till ett SectionZoomFrame-objekt
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Sparar presentationen
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Skapa avsnittszoomramar med anpassade bilder**

Med Aspose.Slides för PHP via Java kan du skapa en avsnittszoomram med en annan förhandsgranskningsbild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Skapa en ny bild.
3. Lägg till en identifieringsbakgrund till den skapade bilden.
4. Skapa ett nytt avsnitt som du avser att länka zoomramen till. 
5. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)-objekt genom att lägga till en bild i Images-samlingen som är associerad med [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)-objektet och som ska fylla ramen.
5. Lägg till en avsnittszoomram (som innehåller en referens till det skapade avsnittet) på den första bilden.
6. Skriv den modifierade presentationen som en PPTX-fil.

```php
  $pres = new Presentation();
  try {
    # Lägger till en ny bild i presentationen
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Lägger till ett nytt avsnitt i presentationen
    $pres->getSections()->addSection("Section 1", $slide);
    # Skapar en ny bild för zoom-objektet
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Lägger till SectionZoomFrame-objekt
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # Sparar presentationen
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Formatera avsnittszoomramar**

För att skapa mer komplicerade avsnittszoomramar måste du ändra formateringen för en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på en avsnittszoomram. 

Du kan kontrollera en avsnittszoomramss formatering på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Skapa en ny bild.
3. Lägg till identifieringsbakgrund till den skapade bilden.
4. Skapa ett nytt avsnitt som du avser att länka zoomramen till. 
5. Lägg till en avsnittszoomram (som innehåller referenser till det skapade avsnittet) på den första bilden.
6. Ändra storlek och position för det skapade avsnittszoom-objektet.
7. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)-objekt genom att lägga till en bild i Images-samlingen som är associerad med [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)-objektet och som ska fylla ramen.
8. Ange en anpassad bild för det skapade avsnittszoom-objektet.
9. Ställ in *återgång till den ursprungliga bilden från det länkade avsnittet*.
10. Ta bort bakgrunden från bilden i avsnittszoom-objektet.
11. Ändra linjeformatet för det andra zoomram-objektet.
12. Ändra övergångens varaktighet.
13. Skriv den modifierade presentationen som en PPTX-fil.

```php
  $pres = new Presentation();
  try {
    # Lägger till en ny bild i presentationen
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Lägger till ett nytt avsnitt i presentationen
    $pres->getSections()->addSection("Section 1", $slide);
    # Lägg till SectionZoomFrame-objekt
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Formatering för SectionZoomFrame
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
    # Sparar presentationen
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Sammanfattningszoom**

En sammanfattningszoom är som en landningssida där alla delar av din presentation visas på en gång. När du presenterar kan du använda zoomen för att gå från en plats i presentationen till en annan i valfri ordning. Du kan vara kreativ, hoppa fram eller återvända till delar av ditt bildspel utan att avbryta flödet i din presentation.

![overview_image](sumzoomsel.png)

För sammanfattningszoom-objekt tillhandahåller Aspose.Slides klasserna [SummaryZoomFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/summaryzoomsection/) och [SummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/summaryzoomsectioncollection/) samt några metoder under klassen [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/).

### **Skapa en sammanfattningszoom**

Du kan lägga till en sammanfattningszoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Skapa nya bilder med identifieringsbakgrund och nya avsnitt för de skapade bilderna.
3. Lägg till sammanfattningszoomramen på den första bilden.
4. Skriv den modifierade presentationen som en PPTX-fil.

```php
  $pres = new Presentation();
  try {
    # Lägger till en ny bild i presentationen
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Lägger till ett nytt avsnitt i presentationen
    $pres->getSections()->addSection("Section 1", $slide);
    # Lägger till en ny bild i presentationen
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Lägger till ett nytt avsnitt i presentationen
    $pres->getSections()->addSection("Section 2", $slide);
    # Lägger till en ny bild i presentationen
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Lägger till ett nytt avsnitt i presentationen
    $pres->getSections()->addSection("Section 3", $slide);
    # Lägger till en ny bild i presentationen
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Lägger till ett nytt avsnitt i presentationen
    $pres->getSections()->addSection("Section 4", $slide);
    # Lägger till ett SummaryZoomFrame-objekt
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Sparar presentationen
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Lägg till och ta bort ett sammanfattningszoomavsnitt**

Alla avsnitt i en sammanfattningszoomram representeras av [SummaryZoomSection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/summaryzoomsection/)-objekt, som lagras i [SummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/summaryzoomsectioncollection/)-objektet. Du kan lägga till eller ta bort ett sammanfattningszoomavsnitt via [SummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/summaryzoomsectioncollection/)-klassen på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Skapa nya bilder med identifieringsbakgrund och nya avsnitt för de skapade bilderna.
3. Lägg till en sammanfattningszoomram i den första bilden.
4. Lägg till en ny bild och ett nytt avsnitt i presentationen.
5. Lägg till det skapade avsnittet i sammanfattningszoomramen.
6. Ta bort det första avsnittet från sammanfattningszoomramen.
7. Skriv den modifierade presentationen som en PPTX-fil.

```php
  $pres = new Presentation();
  try {
    # Lägger till en ny bild i presentationen
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Lägger till ett nytt avsnitt i presentationen
    $pres->getSections()->addSection("Section 1", $slide);
    # Lägger till en ny bild i presentationen
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Lägger till ett nytt avsnitt i presentationen
    $pres->getSections()->addSection("Section 2", $slide);
    # Lägger till ett SummaryZoomFrame-objekt
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Lägger till en ny bild i presentationen
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Lägger till ett nytt avsnitt i presentationen
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # Lägger till ett avsnitt i Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Tar bort avsnitt från Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # Sparar presentationen
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Formatera sammanfattningszoomavsnitt**

För att skapa mer komplicerade sammanfattningszoomavsnitt måste du ändra formateringen för en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på ett sammanfattningszoomavsnitt. 

Du kan kontrollera formateringen för ett sammanfattningszoomavsnitt i en sammanfattningszoomram på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Skapa nya bilder med identifieringsbakgrund och nya avsnitt för de skapade bilderna.
3. Lägg till en sammanfattningszoomram på den första bilden.
4. Hämta ett sammanfattningszoomavsnitt för det första objektet från `SummaryZoomSectionCollection`.
7. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)-objekt genom att lägga till en bild i images-samlingen som är associerad med [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)-objektet och som ska fylla ramen.
8. Ange en anpassad bild för det skapade avsnittszoom-objektet.
9. Ställ in *återgång till den ursprungliga bilden från det länkade avsnittet*. 
11. Ändra linjeformatet för det andra zoomram-objektet.
12. Ändra övergångens varaktighet.
13. Skriv den modifierade presentationen som en PPTX-fil.

```php
  $pres = new Presentation();
  try {
    # Lägger till en ny bild i presentationen
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Lägger till ett nytt avsnitt i presentationen
    $pres->getSections()->addSection("Section 1", $slide);
    # Lägger till en ny bild i presentationen
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Lägger till ett nytt avsnitt i presentationen
    $pres->getSections()->addSection("Section 2", $slide);
    # Lägger till ett SummaryZoomFrame-objekt
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Hämtar det första SummaryZoomSection-objektet
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # Formatering för SummaryZoomSection-objektet
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
    # Sparar presentationen
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan jag styra återgång till 'föräldra' bilden efter att målbilden har visats?**

Ja. Zoom‑ramen eller [section](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sectionzoomframe/) har ett `ReturnToParent`‑beteende som, när det är aktiverat, skickar tittaren tillbaka till den ursprungliga bilden efter att de har besökt mål‑innehållet.

**Kan jag justera 'hastigheten' eller varaktigheten för Zoom‑övergången?**

Ja. Zoom stöder att sätta en `TransitionDuration` så att du kan kontrollera hur lång hopphandlingsanimationen tar.

**Finns det begränsningar för hur många Zoom‑objekt en presentation kan innehålla?**

Det finns ingen hård API‑gräns dokumenterad. Praktiska begränsningar beror på presentationens totala komplexitet och tittarens prestanda. Du kan lägga till många Zoom‑ramar, men tänk på filstorlek och renderingtid.