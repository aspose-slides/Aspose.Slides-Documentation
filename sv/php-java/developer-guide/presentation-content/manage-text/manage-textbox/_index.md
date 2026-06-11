---
title: Hantera textrutor i presentationer med PHP
linktitle: Hantera textruta
type: docs
weight: 20
url: /sv/php-java/manage-textbox/
keywords:
- textruta
- textram
- lägga till text
- uppdatera text
- skapa textruta
- kontrollera textruta
- lägga till textkolumn
- lägga till hyperlänk
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Aspose.Slides för PHP gör det enkelt att skapa, redigera och klona textrutor i PowerPoint- och OpenDocument-filer, vilket förbättrar din presentationsautomatisering."
---
## **Introduktion**

Texter på bildspel finns vanligtvis i textrutor eller former. Därför måste du, för att lägga till text på en bild, lägga till en textruta och sedan placera lite text i textrutan. Aspose.Slides för PHP via Java tillhandahåller klassen AutoShape som låter dig lägga till en form som innehåller text.

{{% alert title="Info" color="info" %}}
Aspose.Slides tillhandahåller även klassen Shape som låter dig lägga till former på bildspel. Dock kan inte alla former som läggs till via `Shape`-klassen hålla text. Formen som läggs till via AutoShape-klassen kan däremot innehålla text.
{{% /alert %}}

{{% alert title="Obs" color="warning" %}} 
Därför, när du arbetar med en form som du vill lägga till text i, bör du kontrollera och bekräfta att den skapades via `AutoShape`-klassen. Endast då kan du arbeta med TextFrame, som är en egenskap under `AutoShape`. Se avsnittet Uppdatera text på den här sidan.
{{% /alert %}}

## **Skapa en textruta på en bild**

1. Skapa en instans av klassen Presentation.  
2. Hämta en referens till den första bilden i den nyss skapade presentationen.  
3. Lägg till ett AutoShape-objekt med formtypen Rectangle på en angiven position på bilden och hämta referensen till det nyss tillagda `AutoShape`-objektet.  
4. Lägg till ett `TextFrame` i `AutoShape`-objektet som kommer att innehålla text. I exemplen nedan lade vi till följande text: *Aspose TextBox*  
5. Till sist skriv PPTX-filen via `Presentation`-objektet.  

Denna PHP‑kod – en implementering av stegen ovan – visar hur du lägger till text på en bild:

```php
  # Skapar en instans av Presentation
  $pres = new Presentation();
  try {
    # Hämtar den första bilden i presentationen
    $sld = $pres->getSlides()->get_Item(0);
    # Lägger till en AutoShape med typen Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Lägger till ett TextFrame i rektangeln
    $ashp->addTextFrame(" ");
    # Kommer åt textramen
    $txtFrame = $ashp->getTextFrame();
    # Skapar Paragraph-objektet för textramen
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Skapar ett Portion-objekt för paragrafen
    $portion = $para->getPortions()->get_Item(0);
    # Ställer in texten
    $portion->setText("Aspose TextBox");
    # Sparar presentationen till disk
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kontrollera om en form är en textruta**

Aspose.Slides tillhandahåller metoden isTextBox från AutoShape-klassen, som låter dig undersöka former och identifiera textrutor.

![Textruta och form](istextbox.png)

Denna PHP‑kod visar hur du kontrollerar om en form skapades som en textruta:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Observera att om du bara lägger till en autoshape med `addAutoShape`‑metoden från ShapeCollection‑klassen, kommer `isTextBox`‑metoden för autoshapen att returnera `false`. När du däremot har lagt till text i autoshapen med `addTextFrame`‑metoden eller `setText`‑metoden, returnerar `isTextBox`‑egenskapen `true`.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() returnerar false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() returnerar true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() returnerar false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() returnerar true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() returnerar false
$shape3->addTextFrame("");
// shape3->isTextBox() returnerar false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() returnerar false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() returnerar false
```

## **Lägg till kolumner i en textruta**

Aspose.Slides tillhandahåller metoderna setColumnCount och setColumnSpacing från TextFrameFormat‑klassen som låter dig lägga till kolumner i textrutor. Du kan ange antalet kolumner i en textruta och sätta avståndet i punkter mellan kolumnerna.

Denna kod demonstrerar den beskrivna operationen:

```php
  $pres = new Presentation();
  try {
    # Hämtar den första bilden i presentationen
    $slide = $pres->getSlides()->get_Item(0);
    # Lägger till en AutoShape med typen Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Lägger till ett TextFrame i rektangeln
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Hämtar textformatet för TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Anger antalet kolumner i TextFrame
    $format->setColumnCount(3);
    # Anger avståndet mellan kolumnerna
    $format->setColumnSpacing(10);
    # Sparar presentationen
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lägg till kolumner i ett textfält**

Aspose.Slides för PHP via Java tillhandahåller metoden setColumnCount från TextFrameFormat‑klassen som låter dig lägga till kolumner i textfält. Med denna egenskap kan du ange önskat antal kolumner i ett textfält.

Denna PHP‑kod visar hur du lägger till en kolumn i ett textfält:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Uppdatera text**

Aspose.Slides låter dig ändra eller uppdatera texten som finns i en textruta eller all text som finns i en presentation.

Denna PHP‑kod demonstrerar en operation där all text i en presentation uppdateras eller ändras:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Kontrollerar om formen stödjer textram (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Itererar genom stycken i textram
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Itererar genom varje del i stycket
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Ändrar text

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Ändrar formatering

            }
          }
        }
      }
    }
    # Sparar den ändrade presentationen
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lägg till en textruta med hyperlänk** 

Du kan infoga en länk i en textruta. När textrutan klickas så öppnas länken för användaren. 

För att lägga till en textruta som innehåller en länk, gå igenom följande steg:

1. Skapa en instans av `Presentation`‑klassen.  
2. Hämta en referens till den första bilden i den nyss skapade presentationen.  
3. Lägg till ett `AutoShape`‑objekt med `ShapeType` satt till `Rectangle` på en angiven position på bilden och hämta referensen till det nyss tillagda AutoShape‑objektet.  
4. Lägg till ett `TextFrame` i `AutoShape`‑objektet som innehåller *Aspose TextBox* som standardtext.  
5. Instansiera `HyperlinkManager`‑klassen.  
6. Tilldela en hyperlänk med hjälp av metoden setExternalHyperlinkClick som är kopplad till den önskade delen av `TextFrame`.  
7. Till sist skriv PPTX-filen via `Presentation`‑objektet.  

Denna PHP‑kod – en implementering av stegen ovan – visar hur du lägger till en textruta med en hyperlänk på en bild:

```php
  # Instansierar en Presentation-klass som representerar en PPTX
  $pres = new Presentation();
  try {
    # Hämtar den första bilden i presentationen
    $slide = $pres->getSlides()->get_Item(0);
    # Lägger till ett AutoShape-objekt med typen Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Omvandlar formen till AutoShape
    $pptxAutoShape = $shape;
    # Kommer åt ITextFrame-egenskapen som är kopplad till AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Lägger till lite text i ramen
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Ställer in hyperlänken för deltexten
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Sparar PPTX-presentationen
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Vad är skillnaden mellan en textruta och en textplatshållare när man arbetar med mastersidor?**

En platshållare ärver stil/position från master‑sidan och kan åsidosättas på layouter, medan en vanlig textruta är ett självständigt objekt på en specifik bild och förändras inte när du byter layout.

**Hur kan jag utföra en massbytesoperation av text i hela presentationen utan att röra text i diagram, tabeller och SmartArt?**

Begränsa din iteration till auto‑former som har textramar och uteslut inbäddade objekt (diagram, tabeller, SmartArt) genom att traversera deras samlingar separat eller hoppa över dessa objekttyper.