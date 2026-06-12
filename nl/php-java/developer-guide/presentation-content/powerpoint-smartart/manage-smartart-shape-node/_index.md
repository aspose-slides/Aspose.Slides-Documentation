---
title: Beheer SmartArt‑vormknooppunten in presentaties met PHP
linktitle: SmartArt‑vormknooppunt
type: docs
weight: 30
url: /nl/php-java/manage-smartart-shape-node/
keywords:
- SmartArt‑knooppunt
- onderknooppunt
- knooppunt toevoegen
- knooppuntpositie
- knooppunt benaderen
- knooppunt verwijderen
- aangepaste positie
- assistent‑knooppunt
- opvulformaat
- knooppunt renderen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Beheer SmartArt‑vormknooppunten in PPT en PPTX met Aspose.Slides voor PHP via Java. Krijg duidelijke codevoorbeelden en tips om uw presentaties te optimaliseren."
---
## **Overzicht**

SmartArt‑grafieken in PowerPoint‑presentaties worden georganiseerd via knooppunten die tekst bevatten en de structuur van het diagram definiëren. Aspose.Slides stelt u in staat om programmatically met deze SmartArt‑knooppunten te werken: nieuwe knooppunten en onderliggende knooppunten toevoegen, onderliggende knooppunten op een specifieke positie invoegen, bestaande knooppunten benaderen en hun tekst, niveau en positie lezen.

Dit artikel legt uit hoe u SmartArt‑vormknooppunten beheert. Het toont hoe u knooppunten verwijdert, werkt met onderliggende knooppunten op basis van index of positie, een assistent‑knooppunt verandert in een normaal knooppunt, de positie, grootte en rotatie van SmartArt‑knooppuntvormen aanpast, knooppunt‑opvulformaten instelt en een miniatuurafbeelding genereert voor een SmartArt‑onderknooppunt.

## **Voeg een SmartArt‑knooppunt toe**
Aspose.Slides for PHP via Java biedt de eenvoudigste API om de SmartArt‑vormen op de gemakkelijkste manier te beheren. De volgende voorbeeldcode helpt bij het toevoegen van een knooppunt en onderliggend knooppunt binnen een SmartArt‑vorm.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse en laad de presentatie met een SmartArt‑vorm.  
1. Verkrijg de referentie van de eerste dia via de Index.  
1. Loop door elke vorm in de eerste dia.  
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/) indien het SmartArt is.  
1. [Add a new Node](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartnodecollection/#addNode) in de SmartArt‑vorm [**NodeCollection**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/#getAllNodes) en zet de tekst in het TextFrame.  
1. Nu, [Add](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartnodecollection/#addNode) een [**Child Node**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartnode/#getChildNodes) in het nieuw toegevoegde [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/)‑knooppunt en zet de tekst in het TextFrame.  
1. Sla de presentatie op.

```php
  # Laad de gewenste presentatie
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Doorloop elke vorm in de eerste dia
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Controleer of de vorm van het type SmartArt is
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Zet de vorm om naar SmartArt
        $smart = $shape;
        # Voeg een nieuw SmartArt-knooppunt toe
        $TemNode = $smart->getAllNodes()->addNode();
        # Voeg tekst toe
        $TemNode->getTextFrame()->setText("Test");
        # Voeg een nieuw onderknooppunt toe in het ouderknooppunt. Het wordt aan het einde van de collectie toegevoegd
        $newNode = $TemNode->getChildNodes()->addNode();
        # Voeg tekst toe
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # Sla de presentatie op
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Voeg een SmartArt‑knooppunt toe op een specifieke positie**
In de onderstaande voorbeeldcode hebben we uitgelegd hoe u de onderliggende knooppunten van respectieve knooppunten van een SmartArt‑vorm op een bepaalde positie kunt toevoegen.

1. Maak een instantie van de Presentation‑klasse.  
1. Verkrijg de referentie van de eerste dia via de Index.  
1. Voeg een [**StackedList**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArtLayoutType#StackedList) type [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArt)‑vorm toe op de geopende dia.  
1. Benader het eerste knooppunt in de toegevoegde SmartArt‑vorm.  
1. Voeg nu de [**Child Node**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartnode/#getChildNodes) toe voor het geselecteerde [**Node**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArtNode) op positie 2 en zet de tekst.  
1. Sla de presentatie op.

```php
  # Creëer een presentatie-instantie
  $pres = new Presentation();
  try {
    # Benader de presentatiedia
    $slide = $pres->getSlides()->get_Item(0);
    # Voeg Smart Art IShape toe
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Benader het SmartArt-knooppunt op index 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Voeg een nieuw onderknooppunt toe op positie 2 in het ouderknooppunt
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Voeg tekst toe
    $chNode->getTextFrame()->setText("Sample Text Added");
    # Sla de presentatie op
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Een SmartArt‑knooppunt benaderen**
De volgende voorbeeldcode helpt om knooppunten binnen een SmartArt‑vorm te benaderen. Let op dat u het LayoutType van de SmartArt niet kunt wijzigen omdat deze alleen-lezen is en alleen wordt ingesteld wanneer de SmartArt‑vorm wordt toegevoegd.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse en laad de presentatie met een SmartArt‑vorm.  
1. Verkrijg de referentie van de eerste dia via de Index.  
1. Loop door elke vorm in de eerste dia.  
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/) indien het SmartArt is.  
1. Loop door alle [**Nodes**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArt#getAllNodes--) binnen de SmartArt‑vorm.  
1. Benader en toon informatie zoals de positie, het niveau en de tekst van het SmartArt‑knooppunt.

```php
  # Instantieer Presentation-klasse
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Haal eerste dia op
    $slide = $pres->getSlides()->get_Item(0);
    # Doorloop elke vorm in de eerste dia
    foreach($slide->getShapes() as $shape) {
      # Controleer of de vorm van het type SmartArt is
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Zet de vorm om naar SmartArt
        $smart = $shape;
        # Doorloop alle knooppunten in SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Benader SmartArt-knooppunt op index i
          $node = $smart->getAllNodes()->get_Item($i);
          # Print de parameters van het SmartArt-knooppunt
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

## **Toegang tot een SmartArt‑onderknooppunt**
De volgende voorbeeldcode helpt om de onderliggende knooppunten van respectieve knooppunten van een SmartArt‑vorm te benaderen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse en laad de presentatie met een SmartArt‑vorm.  
1. Verkrijg de referentie van de eerste dia via de Index.  
1. Loop door elke vorm in de eerste dia.  
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/) indien het SmartArt is.  
1. Loop door alle [**Nodes**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArt#getAllNodes--) binnen de SmartArt‑vorm.  
1. Voor elk geselecteerd SmartArt‑vorm [**Node**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArtNode) loop door alle [**Child Nodes**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArtNode#getChildNodes--) binnen dat specifieke knooppunt.  
1. Benader en toon informatie zoals de positie, het niveau en de tekst van de [**Child Node**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartnode/#getChildNodes).

```php
  # Instantieer Presentation-klasse
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Haal eerste dia op
    $slide = $pres->getSlides()->get_Item(0);
    # Doorloop elke vorm in de eerste dia
    foreach($slide->getShapes() as $shape) {
      # Controleer of de vorm van het type SmartArt is
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Zet de vorm om naar SmartArt
        $smart = $shape;
        # Doorloop alle knooppunten in SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Benader SmartArt-knooppunt op index i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Doorloop de onderliggende knooppunten in SmartArt-knooppunt op index i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Benader het onderliggende knooppunt in SmartArt-knooppunt
            $node = $node0->getChildNodes()->get_Item($j);
            # Print de parameters van het SmartArt-onderknooppunt
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

## **Toegang tot een SmartArt‑onderknooppunt op een specifieke positie**
In dit voorbeeld leren we hoe we de onderliggende knooppunten op een bepaalde positie, behorende tot respectieve knooppunten van een SmartArt‑vorm, kunnen benaderen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse.  
1. Verkrijg de referentie van de eerste dia via de Index.  
1. Voeg een [**StackedList**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArtLayoutType#StackedList) type SmartArt‑vorm toe.  
1. Benader de toegevoegde SmartArt‑vorm.  
1. Benader het knooppunt op index 0 van de benaderde SmartArt‑vorm.  
1. Benader nu de [**Child Node**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartnode/#getChildNodes) op positie 1 voor het benaderde SmartArt‑knooppunt met de **get_Item()**‑methode.  
1. Benader en toon informatie zoals de positie, het niveau en de tekst van de [**Child Node**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartnode/#getChildNodes).

```php
  # Instantieer de presentatie
  $pres = new Presentation();
  try {
    # Benader de eerste dia
    $slide = $pres->getSlides()->get_Item(0);
    # Voeg de SmartArt-vorm toe in de eerste dia
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Benader het SmartArt-knooppunt op index 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Benader het onderliggende knooppunt op positie 1 in het ouderknooppunt
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # Print de parameters van het SmartArt-onderknooppunt
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Verwijder een SmartArt‑knooppunt**
In dit voorbeeld leren we hoe we knooppunten binnen een SmartArt‑vorm kunnen verwijderen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse en laad de presentatie met een SmartArt‑vorm.  
1. Verkrijg de referentie van de eerste dia via de Index.  
1. Loop door elke vorm in de eerste dia.  
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/) indien het SmartArt is.  
1. Controleer of de [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/) meer dan 0 knooppunten bevat.  
1. Selecteer het SmartArt‑knooppunt dat verwijderd moet worden.  
1. Verwijder nu het geselecteerde knooppunt met de [**removeNode**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartnodecollection/#removeNode)‑methode.  
1. Sla de presentatie op.

```php
  # Laad de gewenste presentatie
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Doorloop elke vorm in de eerste dia
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Controleer of de vorm van het type SmartArt is
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Zet de vorm om naar SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Benader SmartArt-knooppunt op index 0
          $node = $smart->getAllNodes()->get_Item(0);
          # Verwijder het geselecteerde knooppunt
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Sla de presentatie op
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Verwijder een SmartArt‑knooppunt vanaf een specifieke positie**
In dit voorbeeld leren we hoe we knooppunten binnen een SmartArt‑vorm op een bepaalde positie kunnen verwijderen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse en laad de presentatie met een SmartArt‑vorm.  
1. Verkrijg de referentie van de eerste dia via de Index.  
1. Loop door elke vorm in de eerste dia.  
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/) indien het SmartArt is.  
1. Selecteer het SmartArt‑vormknooppunt op index 0.  
1. Controleer nu of het geselecteerde SmartArt‑knooppunt meer dan 2 onderliggende knooppunten heeft.  
1. Verwijder nu het knooppunt op **Position 1** met de [**removeNode**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartnodecollection/#removeNode)‑methode.  
1. Sla de presentatie op.

```php
  # Laad de gewenste presentatie
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Doorloop elke vorm in de eerste dia
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Controleer of de vorm van het type SmartArt is
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Zet de vorm om naar SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Benader SmartArt‑knooppunt op index 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Verwijder het onderliggende knooppunt op positie 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # Sla de presentatie op
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Stel een aangepaste positie in voor een onderknooppunt in een SmartArt‑object**
Aspose.Slides for PHP via Java ondersteunt het instellen van [SmartArtShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#setX) en [Y](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#setY) eigenschappen. Het onderstaande codefragment toont hoe u een aangepaste SmartArtShape‑positie, -grootte en -rotatie kunt instellen; let tevens op dat het toevoegen van nieuwe knooppunten een herberekening van de posities en groottes van alle knooppunten veroorzaakt. Met aangepaste positiestellingen kan de gebruiker de knooppunten naar wens plaatsen.

```php
  # Instantieer Presentation-klasse
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Verplaats SmartArt-vorm naar nieuwe positie
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Wijzig de breedtes van de SmartArt-vorm
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # Wijzig de hoogte van de SmartArt-vorm
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # Wijzig de rotatie van de SmartArt-vorm
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Controleer een assistent‑knooppunt**
{{% alert color="primary" %}} 

In dit artikel onderzoeken we verder de mogelijkheden van SmartArt‑vormen die via Aspose.Slides for PHP via Java programmatisch aan presentatiedia’s worden toegevoegd.

{{% /alert %}} 

We zullen de onderstaande bron‑SmartArt‑vorm gebruiken voor onze onderzoeken in de verschillende secties van dit artikel.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figuur: Bron‑SmartArt‑vorm in dia**|

In de volgende voorbeeldcode onderzoeken we hoe we **Assistant Nodes** in de SmartArt‑knooppuntcollectie kunnen identificeren en wijzigen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse en laad de presentatie met een SmartArt‑vorm.  
1. Verkrijg de referentie van de tweede dia via de Index.  
1. Loop door elke vorm in de eerste dia.  
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/) indien het SmartArt is.  
1. Loop door alle knooppunten binnen de SmartArt‑vorm en controleer of ze [**Assistant Nodes**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArtNode#isAssistant--) zijn.  
1. Verander de status van het assistent‑knooppunt naar een normaal knooppunt.  
1. Sla de presentatie op.

```php
  # Een presentatie‑instantie aanmaken
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Doorloop elke vorm in de eerste dia
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Controleer of de vorm van het type SmartArt is
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Zet de vorm om naar SmartArt
        $smart = $shape;
        # Doorloop alle knooppunten van de SmartArt‑vorm
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Controleer of het knooppunt een assistent‑knooppunt is
          if ($node->isAssistant()) {
            # Zet het assistent‑knooppunt op false en maak er een normaal knooppunt van
            $node->isAssistant();
          }
        }
      }
    }
    # Sla de presentatie op
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figuur: Assistent‑knooppunten gewijzigd in SmartArt‑vorm binnen dia**|

## **Stel het opvulformaat van een knooppunt in**
Aspose.Slides for PHP via Java maakt het mogelijk om aangepaste SmartArt‑vormen toe te voegen en hun opvulformaat in te stellen. Dit artikel legt uit hoe u SmartArt‑vormen maakt, benadert en hun opvulformaat instelt met behulp van Aspose.Slides for PHP via Java.

Volg de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse.  
1. Verkrijg de referentie van een dia via de index.  
1. Voeg een [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/)‑vorm toe door het [**LayoutType**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) in te stellen.  
1. Stel het [**Fill Format**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getFillFormat) in voor de SmartArt‑vormknooppunten.  
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```php
  # Instantieer de presentatie
  $pres = new Presentation();
  try {
    # Benader de dia
    $slide = $pres->getSlides()->get_Item(0);
    # SmartArt-vorm en knooppunten toevoegen
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # Kleur van knooppuntvulling instellen
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # Sla de presentatie op
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Genereer een miniatuur van een SmartArt‑onderknooppunt**
Ontwikkelaars kunnen een miniatuur van een onderliggend knooppunt van een SmartArt genereren door de volgende stappen te volgen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse.  
1. [Add SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartnodecollection/#addNode).  
1. Verkrijg de referentie van een knooppunt via de Index.  
1. Haal de miniatuurafbeelding op.  
1. Sla de miniatuurafbeelding op in elk gewenst afbeeldingsformaat.

```php
  # Instantieer Presentation-klasse die het PPTX‑bestand representeert
  $pres = new Presentation();
  try {
    # SmartArt toevoegen
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Verkrijg de referentie van een knooppunt via de Index
    $node = $smart->getNodes()->get_Item(1);
    # Miniatuur ophalen
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Miniatuur opslaan
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

## **FAQ**

**Worden SmartArt‑animaties ondersteund?**

Ja. SmartArt wordt behandeld als een gewone vorm, zodat u [standaardanimaties](/slides/nl/php-java/shape-animation/) (intreden, verlaten, nadruk, bewegingspaden) kunt toepassen en de timing kunt aanpassen. U kunt indien nodig ook vormen binnen SmartArt‑knooppunten animeren.

**Hoe vind ik betrouwbaar een specifiek SmartArt op een dia als de interne ID onbekend is?**

Ken een [alternatieve tekst](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getalternativetext/) toe en zoek daarop. Het instellen van een onderscheidende AltText op de SmartArt laat u het programmatically vinden zonder afhankelijk te zijn van interne identifiers.

**Wordt het uiterlijk van SmartArt bewaard bij het converteren van de presentatie naar PDF?**

Ja. Aspose.Slides render SmartArt met hoge visuele nauwkeurigheid tijdens de [PDF‑export](/slides/nl/php-java/convert-powerpoint-to-pdf/), waardoor lay‑out, kleuren en effecten behouden blijven.

**Kan ik een afbeelding van de volledige SmartArt extraheren (voor voorbeelden of rapporten)?**

Ja. U kunt een SmartArt‑vorm renderen naar [rasterformaten](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getImage) of naar [SVG](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/writeassvg/) voor schaalbare vectoruitvoer, waardoor het geschikt is voor miniaturen, rapporten of webgebruik.