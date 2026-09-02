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
- tekstvak maken
- tekstvak controleren
- tekstkolom toevoegen
- hyperlink toevoegen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Aspose.Slides voor PHP maakt het eenvoudig om tekstvakken te maken, bewerken en dupliceren in PowerPoint- en OpenDocument-bestanden, waardoor uw presentatiesautomatisering wordt verbeterd."
---
## **Inleiding**

Teksten op dia's staan doorgaans in tekstvakken of vormen. Daarom moet je, om tekst aan een dia toe te voegen, een tekstvak toevoegen en vervolgens wat tekst in dat tekstvak plaatsen. Aspose.Slides voor PHP via Java biedt de [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/)‑klasse die je toestaat een vorm met tekst toe te voegen.

{{% alert title="Info" color="info" %}}

Aspose.Slides biedt ook de [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/)‑klasse die je toestaat vormen toe te voegen aan dia's. Niet alle vormen die via de `Shape`‑klasse worden toegevoegd, kunnen echter tekst bevatten. Vormen die via de [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/)‑klasse worden toegevoegd, kunnen wel tekst bevatten.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Daarom, wanneer je met een vorm werkt waaraan je tekst wilt toevoegen, wil je controleren en bevestigen dat deze via de `AutoShape`‑klasse is gecast. Alleen dan kun je met [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) werken, een eigenschap van `AutoShape`. Zie de sectie [Update Text](/slides/nl/php-java/manage-textbox/#update-text) op deze pagina.

{{% /alert %}}

## **Een tekstvak op een dia maken**

Om een tekstvak op een dia te maken, doorloop je de volgende stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar de eerste dia in de nieuw aangemaakte presentatie. 
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/)‑object toe met als vormtype [Rectangle](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapetype/#Rectangle) op een opgegeven positie op de dia en verkrijg de referentie naar het nieuw toegevoegde `AutoShape`‑object.
4. Voeg een `TextFrame` toe aan het `AutoShape`‑object die tekst zal bevatten. In het onderstaande voorbeeld hebben we deze tekst toegevoegd: *Aspose TextBox*
5. Schrijf tenslotte het PPTX‑bestand via het `Presentation`‑object. 

Deze PHP‑code – een implementatie van de bovenstaande stappen – laat zien hoe je tekst aan een dia toevoegt:

```php
  # Instantieert Presentation
  $pres = new Presentation();
  try {
    # Haalt de eerste dia op in de presentatie
    $sld = $pres->getSlides()->get_Item(0);
    # Voegt een AutoShape toe met type Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Voegt TextFrame toe aan de rechthoek
    $ashp->addTextFrame(" ");
    # Benadert het tekstframe
    $txtFrame = $ashp->getTextFrame();
    # Maakt het Paragraph-object voor het tekstframe
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Maakt een Portion-object voor de alinea
    $portion = $para->getPortions()->get_Item(0);
    # Stelt tekst in
    $portion->setText("Aspose TextBox");
    # Slaat de presentatie op schijf
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
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Merk op dat als je eenvoudig een autoshape toevoegt met de `addAutoShape`‑methode van de [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/)‑klasse, de `isTextBox`‑methode van de autoshape `false` zal teruggeven. Nadat je echter tekst aan de autoshape hebt toegevoegd met de `addTextFrame`‑methode of de `setText`‑methode, geeft de `isTextBox`‑eigenschap `true` terug.

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

## **De vorm vinden die een TextFrame bezit**

In generieke tekstverwerkingscode kun je een [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) ontvangen zonder te weten welk presentatie‑object het bevat. Gebruik de [TextFrame::getParentShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#getParentShape)‑methode om terug te navigeren naar de eigenaar‑[Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/).

Voor een tekstframe dat behoort tot een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) of een andere tekstbehorende vorm, retourneert [TextFrame::getParentShape] de eigenaar en retourneert [TextFrame::getParentCell] `null`. Beide methoden bieden alleen‑lezen navigatie, dus het aanroepen ervan verandert de eigendom niet. Controleer altijd de geretourneerde waarde met `java_is_null` voordat je de vorm benadert.

Voor een volledig voorbeeld dat vorm‑ en tabelcel‑eigenaars identificeert, inclusief vormen gekoppeld aan SmartArt‑knopen, zie [Search and Replace Text](/slides/nl/php-java/search-and-replace-text/).

## **Kolommen toevoegen aan een tekstvak**

Aspose.Slides biedt de [setColumnCount](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/setcolumncount/)‑ en [setColumnSpacing](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/setcolumnspacing/)‑methoden van de [TextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/)‑klasse die je toestaan kolommen aan tekstvakken toe te voegen. Je kunt het aantal kolommen in een tekstvak aangeven en de tussenruimte in punten tussen kolommen instellen.

Deze code demonstreert de beschreven bewerking:

```php
  $pres = new Presentation();
  try {
    # Haalt de eerste dia op in de presentatie
    $slide = $pres->getSlides()->get_Item(0);
    # Voeg een AutoShape toe met type Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Voeg TextFrame toe aan de rechthoek
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Haalt het tekstformaat op van TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Bepaalt het aantal kolommen in TextFrame
    $format->setColumnCount(3);
    # Bepaalt de tussenruimte tussen kolommen
    $format->setColumnSpacing(10);
    # Slaat de presentatie op
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kolommen toevoegen aan een TextFrame**

Aspose.Slides voor PHP via Java biedt de [setColumnCount](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/setcolumncount/)‑methode van de [TextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/)‑klasse die je toestaat kolommen in tekstframes toe te voegen. Via deze eigenschap kun je het gewenste aantal kolommen in een tekstframe opgeven.

Deze PHP‑code laat zien hoe je een kolom toevoegt binnen een tekstframe:

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

Deze PHP‑code demonstreert een bewerking waarbij alle teksten in een presentatie worden bijgewerkt of gewijzigd:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Controleert of vorm een tekstframe ondersteunt (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Doorloopt alinea's in het tekstframe
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Doorloopt elk onderdeel in de alinea
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Wijzigt tekst

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Wijzigt opmaak

            }
          }
        }
      }
    }
    # Slaat gewijzigde presentatie op
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Een tekstvak met een hyperlink toevoegen** 

Je kunt een koppeling in een tekstvak invoegen. Wanneer op het tekstvak wordt geklikt, worden gebruikers doorgestuurd naar de link. 

Om een tekstvak met een link toe te voegen, doorloop je de volgende stappen:

1. Maak een instantie van de `Presentation`‑klasse. 
2. Verkrijg een referentie naar de eerste dia in de nieuw aangemaakte presentatie. 
3. Voeg een `AutoShape`‑object toe met `ShapeType` ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg een referentie naar het nieuw toegevoegde AutoShape‑object.
4. Voeg een `TextFrame` toe aan het `AutoShape`‑object dat *Aspose TextBox* als standaardtekst bevat. 
5. Instantieer de `HyperlinkManager`‑klasse. 
6. Ken een hyperlink toe met de [setExternalHyperlinkClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/)‑methode aan het gewenste gedeelte van het `TextFrame`.
7. Schrijf tenslotte het PPTX‑bestand via het `Presentation`‑object. 

Deze PHP‑code – een implementatie van de bovenstaande stappen – laat zien hoe je een tekstvak met een hyperlink aan een dia toevoegt:

```php
  # Instantieert een Presentation-klasse die een PPTX vertegenwoordigt
  $pres = new Presentation();
  try {
    # Haalt de eerste dia op in de presentatie
    $slide = $pres->getSlides()->get_Item(0);
    # Voegt een AutoShape-object toe met type Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Cast de vorm naar AutoShape
    $pptxAutoShape = $shape;
    # Benadert de ITextFrame-eigenschap die bij de AutoShape hoort
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Voegt wat tekst toe aan het frame
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Stelt de hyperlink in voor de portion-tekst
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Slaat de PPTX-presentatie op
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Wat is het verschil tussen een tekstvak en een tekst‑placeholder bij het werken met masterslides?**

Een [placeholder](/slides/nl/php-java/manage-placeholder/) erft stijl/positie van de [master](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/) en kan worden overschreven op [layouts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/), terwijl een gewoon tekstvak een onafhankelijk object is op een specifieke dia en niet verandert wanneer je van layout wisselt.

**Hoe kan ik een bulk-tekstvervanging uitvoeren over de hele presentatie zonder tekst in grafieken, tabellen en SmartArt aan te pakken?**

Beperk je iteratie tot auto‑shapes die tekstframes hebben en sluit ingesloten objecten ([charts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/nl/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/)) uit door hun collecties apart te doorlopen of die objecttypen over te slaan.