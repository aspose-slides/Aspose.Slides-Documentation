---
title: Beheer connectors in presentaties met PHP
linktitle: Connector
type: docs
weight: 10
url: /nl/php-java/connector/
keywords:
- connector
- connectortype
- connectorpunt
- connectorlijn
- connectorhoek
- vormen verbinden
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Sta PHP-applicaties toe om lijnen te tekenen, verbinden en automatisch te routeren in PowerPoint-dia's - krijg volledige controle over rechte, hoek- en kromme connectors."
---
## **Introductie**

Een PowerPoint‑connector is een speciale lijn die twee vormen met elkaar verbindt en aan de vormen blijft bevestigd, zelfs wanneer ze verplaatst of opnieuw gepositioneerd worden op een bepaalde dia.  

Connectors worden doorgaans verbonden met *verbindingstipjes* (groene stipjes), die standaard op alle vormen aanwezig zijn. Verbindingstipjes verschijnen wanneer de cursor er dichtbij komt.

*Aanpassingspunten* (oranje stipjes), die alleen op bepaalde connectors bestaan, worden gebruikt om de positie en vorm van connectors te wijzigen.

## **Typen connectors**

In PowerPoint kun je rechte, hoek‑ (gebogen) en kromme connectors gebruiken.  

Aspose.Slides biedt de volgende connectors:

| Connector | Afbeelding | Aantal aanpassingspunten |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **Vormen verbinden met connectors**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse.
1. Verkrijg een referentie naar een dia via de index.
1. Voeg twee [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/AutoShape) toe aan de dia met de `addAutoShape`‑methode van het `Shapes`‑object.
1. Voeg een connector toe met de `addConnector`‑methode van het `Shapes`‑object door het type connector te definiëren.
1. Verbind de vormen met de connector. 
1. Roep de `reroute`‑methode aan om het kortste verbindingspad toe te passen.
1. Sla de presentatie op. 

Deze PHP‑code laat zien hoe je een connector (een gebogen connector) tussen twee vormen (een ellips en een rechthoek) toevoegt:

```php
// Instancieert een presentatieklasse die het PPTX‑bestand vertegenwoordigt
  $pres = new Presentation();
  try {
    # Toegang tot de shape‑collectie voor een specifieke dia
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Voegt een ellips‑autoshape toe
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Voegt een rechthoek‑autoshape toe
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Voegt een connector‑shape toe aan de shape‑collectie van de dia
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Verbindt de vormen met de connector
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Roept reroute aan die het automatische kortste pad tussen vormen instelt
    $connector->reroute();
    # Slaat de presentatie op
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

De `Connector.reroute`‑methode herschakelt een connector en dwingt deze het kortst mogelijke pad tussen vormen te volgen. Om dit te bereiken, kan de methode de punten `setStartShapeConnectionSiteIndex` en `setEndShapeConnectionSiteIndex` aanpassen. 

{{% /alert %}} 

## **Een verbindingstip specificeren**

Wil je een connector twee vormen laten koppelen via specifieke stipjes op die vormen, dan geef je je voorkeurstipjes als volgt op:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse.
1. Verkrijg een referentie naar een dia via de index.
1. Voeg twee [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/AutoShape) toe aan de dia met de `addAutoShape`‑methode van het `Shapes`‑object.
1. Voeg een connector toe met de `addConnector`‑methode van het `Shapes`‑object door het type connector te definiëren.
1. Verbind de vormen met de connector. 
1. Stel je voorkeurstipjes op de vormen in. 
1. Sla de presentatie op.

Deze PHP‑code demonstreert een bewerking waarbij een voorkeurs‑verbindingstip wordt opgegeven:

```php
  # Instantieert een presentatieklasse die een PPTX‑bestand vertegenwoordigt
  $pres = new Presentation();
  try {
    # Toegang tot de shape‑collectie voor een specifieke dia
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Voeg een ellips‑autoshape toe
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Voeg een rechthoek‑autoshape toe
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Voegt een connector‑shape toe aan de shape‑collectie van de dia
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Verbindt de vormen met de connector
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Stelt de index van het gewenste verbindingstipje in op de ellips‑shape
    $wantedIndex = 6;
    # Controleert of de gewenste index kleiner is dan het maximale aantal verbindingstippen
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # Stelt het gewenste verbindingstipje in op de ellips‑autoshape
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # Slaat de presentatie op
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Een connectorpunt aanpassen**

Je kunt een bestaande connector aanpassen via zijn aanpassingspunten. Alleen connectors met aanpassingspunten kunnen op deze manier worden gewijzigd. Zie de tabel onder **[Typen connectors.](/slides/nl/php-java/connector/#types-of-connectors)**

### **Eenvoudig voorbeeld**

Beschouw een situatie waarin een connector tussen twee vormen (A en B) door een derde vorm (C) loopt:

![connector-obstruction](connector-obstruction.png)

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Om de derde vorm te vermijden, kunnen we de connector aanpassen door zijn verticale lijn naar links te verplaatsen:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```

### **Complexe voorbeelden** 

Voor meer gecompliceerde aanpassingen moet je het volgende in acht nemen:

* Een aanpasbaar punt van een connector is nauw verbonden met een formule die de positie berekent. Een wijziging van dit punt kan de vorm van de connector veranderen.
* Aanpassingspunten van een connector staan in een vaste volgorde in een array. De punten worden genummerd van het startpunt naar het eindpunt van de connector.
* De waarden van aanpassingspunten geven een percentage van de breedte/hoogte van de connectorvorm weer.  
  * De vorm wordt begrensd door het start‑ en eindpunt van de connector vermenigvuldigd met 1000.  
  * Het eerste, tweede en derde punt definiëren respectievelijk het percentage van de breedte, het percentage van de hoogte en opnieuw het percentage van de breedte.
* Bij berekeningen van de coördinaten van aanpassingspunten moet je rekening houden met de rotatie en eventuele spiegeling van de connector. **Opmerking** dat de rotatiehoek voor alle connectors die onder **[Typen connectors](/slides/nl/php-java/connector/#types-of-connectors)** worden getoond, 0 is.

#### **Voorbeeld 1**

Beschouw een geval waarin twee tekstkader‑objecten via een connector met elkaar verbonden zijn:

![connector-shape-complex](connector-shape-complex.png)

```php
  # Instantieert een presentatie‑klasse die een PPTX‑bestand vertegenwoordigt
  $pres = new Presentation();
  try {
    # Verkrijgt de eerste dia van de presentatie
    $sld = $pres->getSlides()->get_Item(0);
    # Voegt vormen toe die via een connector met elkaar worden verbonden
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # Voegt een connector toe
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # Specificeert de richting van de connector
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # Specificeert de kleur van de connector
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Specificeert de dikte van de connectorlijn
    $connector->getLineFormat()->setWidth(3);
    # Verbindt de vormen met de connector
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # Verkrijgt de aanpassingspunten van de connector
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Aanpassing**

We kunnen de waarden van de aanpassingspunten van de connector wijzigen door respectievelijk 20 % en 200 % toe te voegen aan de breedte‑ en hoogte‑percentages:

```php
  # Wijzigt de waarden van de aanpassingspunten
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

Resultaat:

![connector-adjusted-1](connector-adjusted-1.png)

Om een model te definiëren waarmee we de coördinaten en de vorm van afzonderlijke delen van de connector kunnen bepalen, creëren we een vorm die overeenkomt met het horizontale component van de connector op het punt `connector.getAdjustments().get_Item(0)`:

```php
  # Teken het verticale component van de connector
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

Resultaat:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Voorbeeld 2**

In **Voorbeeld 1** hebben we een eenvoudige connector‑aanpassing getoond met basale principes. In normale situaties moet je de rotatie van de connector en de weergave (die worden ingesteld via `connector.getRotation()`, `connector.getFrame().getFlipH()` en `connector.getFrame().getFlipV()`) in beschouwing nemen. We demonstreren nu het proces.

Eerst voegen we een nieuw tekstkader‑object (**To 1**) toe aan de dia (voor verbinding) en maken we een nieuwe (groene) connector die dit object met de reeds gemaakte objecten verbindt.

```php
  # Creëert een nieuw bindingobject
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # Creëert een nieuwe connector
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # Verbindt objecten met de nieuw aangemaakte connector
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # Haalt de aanpassingspunten van de connector op
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # Wijzigt de waarden van de aanpassingspunten
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

Resultaat:

![connector-adjusted-3](connector-adjusted-3.png)

Vervolgens creëren we een vorm die overeenkomt met het horizontale component van de connector dat door het nieuwe aanpassingspunt `connector.getAdjustments().get_Item(0)` loopt. We gebruiken de waarden uit de connector‑data voor `connector.getRotation()`, `connector.getFrame().getFlipH()` en `connector.getFrame().getFlipV()` en passen de bekende coördinaten‑conversieformule voor rotatie rond een gegeven punt x₀ toe:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In ons geval is de rotatiehoek van het object 90 graden en wordt de connector verticaal weergegeven, zodat de code als volgt is:

```php
  # Slaat de coördinaten van de connector op
  $x = $connector->getX();
  $y = $connector->getY();
  # Corrigeert de connectorcoördinaten voor het geval dat deze verschijnt
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # Neemt de waarde van het aanpassingspunt als coördinaat
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Converteert de coördinaten aangezien Sin(90) = 1 en Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # Bepaalt de breedte van het horizontale component met behulp van de tweede aanpassingspuntwaarde
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

Resultaat:

![connector-adjusted-4](connector-adjusted-4.png)

We hebben berekeningen getoond met zowel eenvoudige als gecompliceerde aanpassingspunten (aanpassingspunten met rotatiehoeken). Met deze kennis kun je jouw eigen model ontwikkelen (of code schrijven) om een `GraphicsPath`‑object te verkrijgen of zelfs de waarden van een connector‑aanpassingspunt in te stellen op basis van specifieke dia‑coördinaten.

## **De hoek van connectorlijnen bepalen**

1. Maak een instantie van de klasse.
1. Verkrijg een referentie naar een dia via de index.
1. Toegang tot de connector‑lijnvorm.
1. Gebruik de breedte, hoogte, vorm‑frame‑hoogte en vorm‑frame‑breedte om de hoek te berekenen.

Deze PHP‑code demonstreert een bewerking waarin we de hoek van een connector‑lijnvorm berekenen:

```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Hoe kan ik zien of een connector “gelijmd” kan worden aan een specifieke vorm?**

Controleer of de vorm [connection sites](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getconnectionsitecount/) exposeert. Als er geen zijn of de teller nul is, is lijmen niet beschikbaar; gebruik in dat geval losse eindpunten en positioneer ze handmatig. Het is verstandig de teller te controleren voordat je koppelt.

**Wat gebeurt er met een connector als ik een van de verbonden vormen verwijder?**

De uiteinden worden losgekoppeld; de connector blijft op de dia als een gewone lijn met vrije start‑/eindpunten. Je kunt hem vervolgens verwijderen of de verbindingen opnieuw toewijzen en, indien nodig, [reroute](https://reference.aspose.com/slides/nl/php-java/aspose.slides/connector/reroute/) aanroepen.

**Worden connectorverbindingen behouden bij het kopiëren van een dia naar een andere presentatie?**

Meestal wel, op voorwaarde dat de doel­vormen ook worden gekopieerd. Als de dia in een ander bestand wordt ingevoegd zonder de verbonden vormen, worden de uiteinden vrij en moet je ze opnieuw koppelen.