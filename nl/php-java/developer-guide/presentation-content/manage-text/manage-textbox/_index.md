---
title: Beheer tekstvakken in presentaties met PHP
linktitle: Beheer tekstvak
type: docs
weight: 20
url: /nl/php-java/manage-textbox/
keywords:
- tekstvak
- tekstframe
- tekst toevoegen
- tekst bijwerken
- tekstvak aanmaken
- tekstvak controleren
- tekstkolom toevoegen
- hyperlink toevoegen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Aspose.Slides voor PHP maakt het eenvoudig om tekstvakken te maken, bewerken en te klonen in PowerPoint- en OpenDocument-bestanden, waardoor uw presentatiesautomatisering wordt verbeterd."
---
## **Inleiding**

Teksten op dia's staan doorgaans in tekstvakken of vormen. Daarom moet je, om tekst aan een dia toe te voegen, een tekstvak toevoegen en vervolgens tekst in dat vak plaatsen. Aspose.Slides for PHP via Java biedt de [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/)‑klasse waarmee je een vorm met tekst kunt toevoegen.

{{% alert title="Info" color="info" %}}

Aspose.Slides biedt ook de [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/)‑klasse waarmee je vormen aan dia’s kunt toevoegen. Niet alle vormen die via de `Shape`‑klasse worden toegevoegd, kunnen echter tekst bevatten. Vormen die via de [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/)‑klasse worden toegevoegd, kunnen tekst bevatten.

{{% /alert %}}

{{% alert title="Opmerking" color="warning" %}} 

Wanneer je met een vorm werkt waaraan je tekst wilt toevoegen, moet je controleren of deze is aangemaakt via de `AutoShape`‑klasse. Alleen dan kun je werken met [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/), een eigenschap van `AutoShape`. Zie de sectie [Update Text](/slides/nl/php-java/manage-textbox/#update-text) op deze pagina.

{{% /alert %}}

## **Een tekstvak op een dia maken**

Volg deze stappen om een tekstvak op een dia te maken:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
2. Verkrijg een verwijzing naar de eerste dia in de nieuw aangemaakte presentatie. 
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/)‑object toe met als `ShapeType` [Rectangle](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapetype/#Rectangle) op een opgegeven positie op de dia en krijg de referentie naar het zojuist toegevoegde `AutoShape`‑object.
4. Voeg een `TextFrame` toe aan het `AutoShape`‑object dat de tekst zal bevatten. In het voorbeeld hieronder hebben we de tekst *Aspose TextBox* toegevoegd.
5. Schrijf ten slotte het PPTX‑bestand via het `Presentation`‑object. 

Deze PHP‑code – een implementatie van de bovenstaande stappen – laat zien hoe je tekst aan een dia kunt toevoegen:

```php
  # Maakt een instantie van Presentation
  $pres = new Presentation();
  try {
    # Haalt de eerste dia in de presentatie op
    $sld = $pres->getSlides()->get_Item(0);
    # Voegt een AutoShape toe met type ingesteld op Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Voegt TextFrame toe aan de rechthoek
    $ashp->addTextFrame(" ");
    # Toegang tot het tekstframe
    $txtFrame = $ashp->getTextFrame();
    # Maakt het Paragraph‑object voor het tekstframe
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Maakt een Portion‑object voor de alinea
    $portion = $para->getPortions()->get_Item(0);
    # Stelt tekst in
    $portion->setText("Aspose TextBox");
    # Slaat de presentatie op naar schijf
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Controleren of een vorm een tekstvak is**

Aspose.Slides biedt de [isTextBox](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/istextbox/)‑methode van de [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/)‑klasse, waarmee je vormen kunt onderzoeken en tekstvakken kunt identificeren.

![Tekstvak en vorm](istextbox.png)

Deze PHP‑code laat zien hoe je controleert of een vorm als tekstvak is aangemaakt:

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

Let op: als je simpelweg een autoshape toevoegt met de `addAutoShape`‑methode van de [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/)‑klasse, geeft de `isTextBox`‑methode van die autoshape `false` terug. Nadat je echter tekst aan de autoshape hebt toegevoegd via de `addTextFrame`‑methode of de `setText`‑methode, geeft de `isTextBox`‑eigenschap `true` terug.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() geeft false terug
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() geeft true terug

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() geeft false terug
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() geeft true terug

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() geeft false terug
$shape3->addTextFrame("");
// shape3->isTextBox() geeft false terug

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() geeft false terug
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() geeft false terug
```

## **Kolommen aan een tekstvak toevoegen**

Aspose.Slides biedt de [setColumnCount](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/setcolumncount/)‑ en [setColumnSpacing](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/setcolumnspacing/)‑methoden van de [TextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/)‑klasse, waarmee je kolommen aan tekstvakken kunt toevoegen. Je kunt het aantal kolommen in een tekstvak opgeven en de afstand tussen kolommen (in points) instellen.

Deze code demonstreert de beschreven bewerking:

```php
  $pres = new Presentation();
  try {
    # Krijgt de eerste dia in de presentatie
    $slide = $pres->getSlides()->get_Item(0);
    # Voegt een AutoShape toe met type ingesteld op Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Voegt TextFrame toe aan de rechthoek
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Haalt het tekstformaat van TextFrame op
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Specificeert het aantal kolommen in TextFrame
    $format->setColumnCount(3);
    # Specificeert de afstand tussen kolommen
    $format->setColumnSpacing(10);
    # Slaat de presentatie op
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kolommen aan een tekstframe toevoegen**

Aspose.Slides for PHP via Java biedt de [setColumnCount](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/setcolumncount/)‑methode van de [TextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/)‑klasse, waarmee je kolommen in tekstframes kunt toevoegen. Met deze eigenschap kun je het gewenste aantal kolommen in een tekstframe opgeven.

Deze PHP‑code laat zien hoe je een kolom toevoegt aan een tekstframe:

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

## **Tekst bijwerken**

Aspose.Slides stelt je in staat de tekst in een tekstvak of alle teksten in een presentatie te wijzigen of bij te werken. 

Deze PHP‑code demonstreert een bewerking waarbij alle teksten in een presentatie worden bijgewerkt:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Controleert of de vorm een tekstframe ondersteunt (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Doorloopt de alinea's in het tekstframe
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Doorloopt elk deel (portion) in de alinea
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Wijzigt de tekst

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Wijzigt de opmaak

            }
          }
        }
      }
    }
    # Slaat de gewijzigde presentatie op
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Een tekstvak met hyperlink toevoegen** 

Je kunt een koppeling in een tekstvak invoegen. Wanneer op het tekstvak wordt geklikt, wordt de link geopend. 

Om een tekstvak met een koppeling toe te voegen, doorloop je de volgende stappen:

1. Maak een instantie van de `Presentation`‑klasse. 
2. Verkrijg een verwijzing naar de eerste dia in de nieuw aangemaakte presentatie. 
3. Voeg een `AutoShape`‑object toe met `ShapeType` `Rectangle` op een opgegeven positie op de dia en krijg een referentie naar het zojuist toegevoegde `AutoShape`‑object.
4. Voeg een `TextFrame` toe aan het `AutoShape`‑object met *Aspose TextBox* als standaardtekst. 
5. Instantieer de `HyperlinkManager`‑klasse. 
6. Wijs een hyperlink toe met de [setExternalHyperlinkClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/)‑methode voor het gewenste gedeelte van het `TextFrame`.
7. Schrijf ten slotte het PPTX‑bestand via het `Presentation`‑object. 

Deze PHP‑code – een implementatie van de bovenstaande stappen – laat zien hoe je een tekstvak met hyperlink aan een dia toevoegt:

```php
  # Instantieert een Presentation‑klasse die een PPTX representeert
  $pres = new Presentation();
  try {
    # Haalt de eerste dia in de presentatie op
    $slide = $pres->getSlides()->get_Item(0);
    # Voegt een AutoShape‑object toe met type ingesteld op Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Cast de vorm naar AutoShape
    $pptxAutoShape = $shape;
    # Benadert de ITextFrame‑eigenschap die bij de AutoShape hoort
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Voegt tekst toe aan het frame
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Stelt de hyperlink in voor de portion‑tekst
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Slaat de PPTX‑presentatie op
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Wat is het verschil tussen een tekstvak en een tekst‑placeholder bij het werken met masterslides?**

Een [placeholder](/slides/nl/php-java/manage-placeholder/) erft stijl/positie van de [master](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/) en kan worden overschreven op [lay-outs](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/), terwijl een regulier tekstvak een onafhankelijk object op een specifieke dia is en niet verandert wanneer je van lay‑out wisselt.

**Hoe kan ik een bulk‑tekstvervanging uitvoeren in de hele presentatie zonder tekst in diagrammen, tabellen en SmartArt aan te passen?**

Beperk je iteratie tot auto‑shapes die tekstframes bevatten en sluit ingesloten objecten ([charts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/nl/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/)) uit door hun collecties apart te doorlopen of deze objecttypen over te slaan.