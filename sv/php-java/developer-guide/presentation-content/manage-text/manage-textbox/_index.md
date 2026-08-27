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

Texter på bilder finns vanligtvis i textrutor eller former. Därför, för att lägga till text på en bild, måste du lägga till en textruta och sedan placera någon text i textrutan. Aspose.Slides för PHP via Java tillhandahåller klassen [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) som låter dig lägga till en form som innehåller någon text.

{{% alert title="Info" color="info" %}}
Aspose.Slides tillhandahåller också klassen [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/) som låter dig lägga till former på bilder. Dock kan inte alla former som läggs till via `Shape`-klassen hålla text. Men former som läggs till via klassen [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) kan innehålla text.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Därför, när du arbetar med en form till vilken du vill lägga till text, kan du vilja kontrollera och bekräfta att den har kastats genom `AutoShape`-klassen. Endast då kommer du kunna arbeta med [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/), som är en egenskap under `AutoShape`. Se avsnittet [Update Text](/slides/sv/php-java/manage-textbox/#update-text) på den här sidan.
{{% /alert %}}

## **Skapa en textruta på en bild**

För att skapa en textruta på en bild, gå igenom dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta en referens till den första bilden i den nyskapade presentationen. 
3. Lägg till ett [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/)-objekt med formtypen satt till [Rectangle](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapetype/#Rectangle) på en specificerad position på bilden och hämta referensen till det nyss tillagda `AutoShape`-objektet.
4. Lägg till ett `TextFrame` till `AutoShape`-objektet som kommer att innehålla text. I exemplet nedan lade vi till följande text: *Aspose TextBox*
5. Slutligen, skriv PPTX-filen via `Presentation`-objektet. 

Denna PHP-kod—en implementation av stegen ovan—visar hur du lägger till text på en bild:

```php
  # Instansierar Presentation
  $pres = new Presentation();
  try {
    # Hämtar den första bilden i presentationen
    $sld = $pres->getSlides()->get_Item(0);
    # Lägger till en AutoShape med typen satt till Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Lägger till TextFrame till rektangeln
    $ashp->addTextFrame(" ");
    # Kommer åt textramen
    $txtFrame = $ashp->getTextFrame();
    # Skapar Paragraph-objektet för textramen
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Skapar ett Portion-objekt för paragrafen
    $portion = $para->getPortions()->get_Item(0);
    # Anger text
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

Aspose.Slides tillhandahåller metoden [isTextBox](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/istextbox/) från klassen [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/), vilket låter dig undersöka former och identifiera textrutor.

![Text box and shape](istextbox.png)

Denna PHP-kod visar hur du kontrollerar om en form skapades som en textruta:

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
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Observera att om du helt enkelt lägger till en autoshape med metoden `addAutoShape` från klassen [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/), kommer `isTextBox`-metoden på autoshapen att returnera `false`. Däremot, efter att du har lagt till text till autoshapen med metoden `addTextFrame` eller `setText`, kommer `isTextBox`-egenskapen att returnera `true`.

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

## **Hitta formen som äger ett TextFrame**

I generell textbehandlingskod kan du få ett [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) utan att redan veta vilket presentationsobjekt som innehåller det. Använd metoden [TextFrame::getParentShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#getParentShape) för att navigera tillbaka till den ägande [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/).

För ett textområde som tillhör en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) eller en annan form som innehåller text, returnerar [TextFrame::getParentShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#getParentShape) ägaren och [TextFrame::getParentCell](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#getParentCell) returnerar `null`. Båda metoderna ger läs‑endast navigering, så att anropa dem ändrar inte ägandet. Kontrollera alltid det returnerade värdet med `java_is_null` innan du får åtkomst till formen.

För ett komplett exempel som identifierar ägare till former och tabellceller, inklusive former kopplade till SmartArt‑noder, se [Search and Replace Text](/slides/sv/php-java/search-and-replace-text/).

## **Lägg till kolumner i en textruta**

Aspose.Slides tillhandahåller metoderna [setColumnCount](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/setcolumncount/) och [setColumnSpacing](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/setcolumnspacing/) från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/) som låter dig lägga till kolumner i textrutor. Du kan ange antalet kolumner i en textruta och ställa in avståndet i punkter mellan kolumnerna.

Denna kod demonstrerar den beskrivna operationen:

```php
  $pres = new Presentation();
  try {
    # Hämtar den första bilden i presentationen
    $slide = $pres->getSlides()->get_Item(0);
    # Lägger till en AutoShape med typen satt till Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Lägger till TextFrame till rektangeln
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Hämtar textformatet för TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Anger antalet kolumner i TextFrame
    $format->setColumnCount(3);
    # Anger avståndet mellan kolumner
    $format->setColumnSpacing(10);
    # Sparar presentationen
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lägg till kolumner i ett TextFrame**

Aspose.Slides för PHP via Java tillhandahåller metoden [setColumnCount](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/setcolumncount/) från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/) som låter dig lägga till kolumner i textramar. Via denna egenskap kan du ange önskat antal kolumner i en textram.

Denna PHP-kod visar hur du lägger till en kolumn i en textram:

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

Aspose.Slides låter dig ändra eller uppdatera texten i en textruta eller all text som finns i en presentation.

Denna PHP-kod demonstrerar en operation där all text i en presentation uppdateras eller ändras:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Kontrollerar om formen stödjer textram (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Itererar genom stycken i textramen
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
    # Sparar modifierad presentation
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lägg till en textruta med en hyperlänk**

Du kan infoga en länk i en textruta. När textrutan klickas på dirigeras användarna till att öppna länken.

För att lägga till en textruta som innehåller en länk, gå igenom dessa steg:

1. Skapa en instans av `Presentation`-klassen. 
2. Hämta en referens till den första bilden i den nyskapade presentationen. 
3. Lägg till ett `AutoShape`-objekt med `ShapeType` satt till `Rectangle` på en specificerad position på bilden och hämta en referens till det nyss tillagda AutoShape-objektet.
4. Lägg till ett `TextFrame` till `AutoShape`-objektet som innehåller *Aspose TextBox* som standardtext. 
5. Instansiera `HyperlinkManager`-klassen. 
6. Tilldela en hyperlänk med metoden [setExternalHyperlinkClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) som är kopplad till den del av `TextFrame` du föredrar.
7. Slutligen, skriv PPTX-filen via `Presentation`-objektet. 

Denna PHP-kod—en implementation av stegen ovan—visar hur du lägger till en textruta med en hyperlänk på en bild:

```php
  # Instansierar en Presentation-klass som representerar en PPTX
  $pres = new Presentation();
  try {
    # Hämtar den första bilden i presentationen
    $slide = $pres->getSlides()->get_Item(0);
    # Lägger till ett AutoShape-objekt med typen satt till Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Kastar formen till AutoShape
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

**Vad är skillnaden mellan en textruta och en textplatshållare när du arbetar med master‑bilder?**

En [placeholder](/slides/sv/php-java/manage-placeholder/) ärver stil/position från [master](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/) och kan åsidosättas på [layouts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/), medan en vanlig textruta är ett självständigt objekt på en specifik bild och förändras inte när du byter layout.

**Hur kan jag utföra en massersättning av text i hela presentationen utan att påverka text i diagram, tabeller och SmartArt?**

Begränsa din iteration till auto‑shapes som har textramar och exkludera inbäddade objekt ([charts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/sv/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartart/)) genom att traversera deras samlingar separat eller hoppa över dessa objekttyper.