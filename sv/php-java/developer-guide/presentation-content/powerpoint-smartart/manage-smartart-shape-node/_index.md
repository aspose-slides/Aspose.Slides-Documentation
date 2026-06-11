---
title: "Hantera SmartArt-formnoder i presentationer med PHP"
linktitle: "SmartArt-formnod"
type: docs
weight: 30
url: /sv/php-java/manage-smartart-shape-node/
keywords:
- SmartArt-nod
- undernod
- lägg till nod
- nodposition
- åtkomstnod
- ta bort nod
- anpassad position
- assistentnod
- fyllningsformat
- rendera nod
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Hantera SmartArt-formnoder i PPT och PPTX med Aspose.Slides för PHP via Java. Få tydliga kodexempel och tips för att effektivisera dina presentationer."
---
## **Översikt**

SmartArt-grafik i PowerPoint-presentationer organiseras via noder som innehåller text och definierar diagrammets struktur. Aspose.Slides låter dig arbeta med dessa SmartArt‑noder programmässigt: lägga till nya noder och undernoder, infoga undernoder på en specifik position, komma åt befintliga noder och läsa deras text, nivå och position.

Den här artikeln förklarar hur du hanterar SmartArt‑formnoder. Den visar hur du tar bort noder, arbetar med undernoder efter index eller position, ändrar en assistentnod till en normal nod, justerar position, storlek och rotation för SmartArt‑nodformer, anger nodens fyllningsformat och genererar en miniatyrbild för en SmartArt‑undernod.

## **Lägg till en SmartArt‑nod**
Aspose.Slides för PHP via Java har tillhandahållit det enklaste API‑et för att hantera SmartArt‑former på det lättaste sättet. Följande exempel kod hjälper dig att lägga till en nod och en undernod i en SmartArt‑form.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Iterera genom alla former i den första bilden.
4. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartart/) och typkonvertera den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartart/) om den är SmartArt.
5. [Lägg till en ny nod](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartnodecollection/#addNode) i SmartArt‑formen [**NodeCollection**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartart/#getAllNodes) och sätt texten i TextFrame.
6. Nu, [Lägg till](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartnodecollection/#addNode) en [**underordnad nod**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartnode/#getChildNodes) i den nyss tillagda [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartart/) noden och sätt texten i TextFrame.
7. Spara presentationen.

```php
  # Läs in den önskade presentationen
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Iterera genom alla former i den första bilden
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Kontrollera om formen är av typen SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typkonvertera formen till SmartArt
        $smart = $shape;
        # Lägger till en ny SmartArt-nod
        $TemNode = $smart->getAllNodes()->addNode();
        # Lägger till text
        $TemNode->getTextFrame()->setText("Test");
        # Lägger till en ny undernod i föräldranoden. Den kommer att läggas till i slutet av samlingen
        $newNode = $TemNode->getChildNodes()->addNode();
        # Lägger till text
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # Sparar presentationen
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lägg till en SmartArt‑nod på en specifik position**
I följande exempel kod har vi förklarat hur man lägger till undernoder som tillhör respektive noder i SmartArt‑formen på en viss position.

1. Skapa en instans av Presentation‑klassen.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Lägg till en [**StackedList**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArtLayoutType#StackedList)‑typ [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArt) form i den åtkomna bilden.
4. Kom åt den första noden i den tillagda SmartArt‑formen.
5. Nu, lägg till [**underordnad nod**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartnode/#getChildNodes) för den valda [**nod**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArtNode) på position 2 och sätt dess text.
6. Spara presentationen.

```php
  # Skapa en presentationsinstans
  $pres = new Presentation();
  try {
    # Åtkomst till presentationsbilden
    $slide = $pres->getSlides()->get_Item(0);
    # Lägg till Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Åtkomst till SmartArt-nod på index 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Lägg till ny undernod på position 2 i föräldranoden
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Lägg till text
    $chNode->getTextFrame()->setText("Sample Text Added");
    # Spara presentationen
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kom åt en SmartArt‑nod**
Följande exempel kod hjälper dig att komma åt noder i en SmartArt‑form. Observera att du inte kan ändra LayoutType för SmartArt eftersom den är skrivskyddad och endast sätts när SmartArt‑formen läggs till.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation) och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Iterera genom alla former i den första bilden.
4. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartart/) och typkonvertera den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartart/) om den är SmartArt.
5. Iterera genom alla [**noder**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArt#getAllNodes--) i SmartArt‑formen.
6. Kom åt och visa information såsom SmartArt‑nodens position, nivå och text.

```php
  # Instansiera presentationsklass
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Hämta första bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Traversera alla former i den första bilden
    foreach($slide->getShapes() as $shape) {
      # Kontrollera om formen är av typen SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typkonvertera formen till SmartArt
        $smart = $shape;
        # Traversera alla noder i SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Åtkomst till SmartArt-nod på index i
          $node = $smart->getAllNodes()->get_Item($i);
          # Skriver ut SmartArt-nodens parametrar
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kom åt en SmartArt‑underordnad nod**
Följande exempel kod hjälper dig att komma åt undernoder som tillhör respektive noder i SmartArt‑formen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation) och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Iterera genom alla former i den första bilden.
4. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartart/) och typkonvertera den valda formen till [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartart/) om den är SmartArt.
5. Iterera genom alla [**noder**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArt#getAllNodes--) i SmartArt‑formen.
6. För varje vald SmartArt‑form [**nod**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArtNode) iterera genom alla [**underordnade noder**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArtNode#getChildNodes--) i den specifika noden.
7. Kom åt och visa information såsom [**underordnad nod**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartnode/#getChildNodes) position, nivå och text.

```php
  # Instansiera presentationsklass
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Hämta första bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Traversera alla former i den första bilden
    foreach($slide->getShapes() as $shape) {
      # Kontrollera om formen är av typen SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typkonvertera formen till SmartArt
        $smart = $shape;
        # Traversera alla noder i SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Åtkomst till SmartArt-nod på index i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Traversera undernoderna i SmartArt-nod på index i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Åtkomst till undernoden i SmartArt-nod
            $node = $node0->getChildNodes()->get_Item($j);
            # Skriver ut SmartArt-undernodens parametrar
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kom åt en SmartArt‑underordnad nod på en specifik position**
I detta exempel kommer vi att lära oss att komma åt undernoder på en viss position som tillhör respektive noder i SmartArt‑formen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
2. Hämta referensen till den första bilden genom att använda dess index.
3. Lägg till en [**StackedList**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArtLayoutType#StackedList)‑typ SmartArt‑form.
4. Kom åt den tillagda SmartArt‑formen.
5. Kom åt noden på index 0 för den åtkomna SmartArt‑formen.
6. Nu, kom åt [**underordnad nod**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartnode/#getChildNodes) på position 1 för den åtkomna SmartArt‑noden med hjälp av metoden **get_Item()**.
7. Kom åt och visa information såsom [**underordnad nod**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartnode/#getChildNodes) position, nivå och text.

```php
  # Instansiera presentationen
  $pres = new Presentation();
  try {
    # Åtkomst till den första bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Lägger till SmartArt-formen i första bilden
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Åtkomst till SmartArt-nod på index 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Åtkomst till undernoden på position 1 i föräldranoden
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # Skriver ut SmartArt-undernodens parametrar
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ta bort en SmartArt‑nod**
I detta exempel kommer vi att lära oss att ta bort noder i SmartArt‑formen.

1. Skapa en instans av klassen [Presentation] och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Iterera genom alla former i den första bilden.
4. Kontrollera om formen är av typen [SmartArt] och typkonvertera den valda formen till [SmartArt] om den är SmartArt.
5. Kontrollera om [SmartArt] har fler än 0 noder.
6. Välj den SmartArt‑nod som ska tas bort.
7. Nu, ta bort den valda noden med metoden [**removeNode**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartnodecollection/#removeNode).
8. Spara presentationen.

```php
  # Läs in den önskade presentationen
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Traversera alla former i den första bilden
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Kontrollera om formen är av typen SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typkonvertera formen till SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Åtkomst till SmartArt-nod på index 0
          $node = $smart->getAllNodes()->get_Item(0);
          # Tar bort den valda noden
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Spara presentationen
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ta bort en SmartArt‑nod från en specifik position**
I detta exempel kommer vi att lära oss att ta bort noder i SmartArt‑formen på en viss position.

1. Skapa en instans av klassen [Presentation] och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den första bilden genom att använda dess index.
3. Iterera genom alla former i den första bilden.
4. Kontrollera om formen är av typen [SmartArt] och typkonvertera den valda formen till [SmartArt] om den är SmartArt.
5. Välj SmartArt‑formnod på index 0.
6. Kontrollera nu om den valda SmartArt‑nod har fler än 2 undernoder.
7. Ta nu bort noden på **position 1** med hjälp av metoden [**removeNode**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartnodecollection/#removeNode).
8. Spara presentationen.

```php
  # Läs in den önskade presentationen
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Traversera alla former i den första bilden
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Kontrollera om formen är av typen SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typkonvertera formen till SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Åtkomst till SmartArt-nod på index 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Tar bort undernoden på position 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # Spara presentationen
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange en anpassad position för en undernod i ett SmartArt‑objekt**
Aspose.Slides för PHP via Java stödjer att sätta [SmartArtShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#setX) och [Y](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#setY) egenskaper. Kodsnutten nedan visar hur man anger en anpassad position, storlek och rotation för SmartArtShape; observera också att tillägg av nya noder medför en omräkning av positioner och storlekar för alla noder. Med anpassade positionsinställningar kan användaren också ställa in noderna enligt kraven.

```php
  # Instansiera presentationsklass
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Flytta SmartArt-formen till ny position
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Ändra SmartArt-formens bredd
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # Ändra SmartArt-formens höjd
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # Ändra SmartArt-formens rotation
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Kontrollera en assistentnod**
{{% alert color="primary" %}} 

I den här artikeln kommer vi att ytterligare undersöka funktioner i SmartArt‑former som lagts till i presentationsbilder programmässigt med Aspose.Slides för PHP via Java.

{{% /alert %}} 

Vi kommer att använda följande käll‑SmartArt‑form för vår undersökning i olika sektioner av denna artikel.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figur: Käll‑SmartArt‑form i bild**|

I följande exempel kod kommer vi att undersöka hur man identifierar **assistentnoder** i SmartArt‑nodsamlingen och ändrar dem.

1. Skapa en instans av klassen [Presentation] och läs in presentationen med SmartArt‑form.
2. Hämta referensen till den andra bilden genom att använda dess index.
3. Iterera genom alla former i den första bilden.
4. Kontrollera om formen är av typen [SmartArt] och typkonvertera den valda formen till [SmartArt] om den är SmartArt.
5. Iterera genom alla noder i SmartArt‑formen och kontrollera om de är [**assistentnoder**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArtNode#isAssistant--).
6. Ändra statusen för assistentnoden till en normal nod.
7. Spara presentationen.

```php
  # Skapa en presentationsinstans
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Traversera alla former i den första bilden
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Kontrollera om formen är av typen SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typkonvertera formen till SmartArt
        $smart = $shape;
        # Traversera alla noder i SmartArt-formen
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Kontrollera om noden är en assistentnod
          if ($node->isAssistant()) {
            # Sätt assistentnod till falskt och gör den till en normal nod
            $node->isAssistant();
          }
        }
      }
    }
    # Spara presentationen
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figur: Assistentnoder ändrade i SmartArt‑form i bild**|

## **Ange ett nodfyllningsformat**
Aspose.Slides för PHP via Java möjliggör att lägga till anpassade SmartArt‑former och ange deras fyllningsformat. Denna artikel förklarar hur man skapar och får åtkomst till SmartArt‑former och anger deras fyllningsformat med Aspose.Slides för PHP via Java.

1. Skapa en instans av klassen [Presentation].
2. Hämta referensen till en bild med hjälp av dess index.
3. Lägg till en [SmartArt]‑form genom att sätta dess [**LayoutType**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
4. Ange [**Fill Format**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getFillFormat) för SmartArt‑formens noder.
5. Skriv den modifierade presentationen som en PPTX‑fil.

```php
  # Instansiera presentationen
  $pres = new Presentation();
  try {
    # Åtkomst till bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Lägger till SmartArt-form och noder
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # Ställer in nodens fyllningsfärg
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # Spara presentationen
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Generera en miniatyrbild av en SmartArt‑underordnad nod**
Utvecklare kan generera en miniatyrbild av en underordnad nod i ett SmartArt genom att följa stegen nedan:

1. Skapa en instans av klassen [Presentation].
2. [Lägg till SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartnodecollection/#addNode).
3. Hämta referensen till en nod genom att använda dess index.
4. Hämta miniatyrbilden.
5. Spara miniatyrbilden i önskat bildformat.

```php
  # Instansiera Presentation-klass som representerar PPTX-filen
  $pres = new Presentation();
  try {
    # Lägg till SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Hämta referensen till en nod genom att använda dess index
    $node = $smart->getNodes()->get_Item(1);
    # Hämta miniatyrbild
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Spara miniatyrbild
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vanliga frågor**

**Stöds SmartArt‑animation?**

Ja. SmartArt behandlas som en vanlig form, så du kan [tillämpa standardanimationer](/slides/sv/php-java/shape-animation/) (ingång, utgång, betoning, rörelsebanor) och justera tidsinställningar. Du kan också animera former inom SmartArt‑noder vid behov.

**Hur kan jag på ett tillförlitligt sätt hitta ett specifikt SmartArt på en bild om dess interna ID är okänt?**

Tilldela och sök efter [alternativ text](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getalternativetext/). Genom att ange en distinkt AltText på SmartArt kan du hitta den programmässigt utan att förlita dig på interna identifierare.

**Kommer SmartArt‑utseendet att bevaras vid konvertering av presentationen till PDF?**

Ja. Aspose.Slides renderar SmartArt med hög visuell noggrannhet vid [PDF‑export](/slides/sv/php-java/convert-powerpoint-to-pdf/), vilket bevarar layout, färger och effekter.

**Kan jag extrahera en bild av hela SmartArt (för förhandsgranskningar eller rapporter)?**

Ja. Du kan rendera en SmartArt‑form till [rasterformat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getImage) eller till [SVG](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/writeassvg/) för skalbar vektorutdata, vilket gör den lämplig för miniatyrer, rapporter eller webbbruk.