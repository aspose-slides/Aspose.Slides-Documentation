---
title: Hantera anslutare i presentationer med PHP
linktitle: Anslutare
type: docs
weight: 10
url: /sv/php-java/connector/
keywords:
- anslutare
- anslutartyp
- anslutningspunkt
- anslutningslinje
- anslutningsvinkel
- anslut former
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Ge PHP-appar möjlighet att rita, ansluta och automatiskt leda linjer i PowerPoint-bilder - få full kontroll över raka, armbag- och böjda anslutare."
---
## **Introduktion**

En PowerPoint‑anslutare är en speciell linje som kopplar två former tillsammans och förblir fäst vid formerna även när de flyttas eller omplaceras på en given bild. 

Anslutare är vanligtvis kopplade till *connection dots* (gröna prickar), som finns på alla former som standard. Anslutningsprickar visas när en markör närmar sig dem.

*Adjustment points* (orange prickar), som bara finns på vissa anslutare, används för att ändra anslutarnas positioner och former.

## **Typer av anslutare**

I PowerPoint kan du använda raka, armbågs‑ (vinklade) och böjda anslutare. 

Aspose.Slides tillhandahåller dessa anslutare:

| Anslutare                      | Bild                                                        | Antal justeringspunkter |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Anslut former med anslutare**

1. Skapa en instans av klassen [Presentation](https://apireference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till två [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/AutoShape) på bilden med metoden `addAutoShape` som exponeras av `Shapes`‑objektet.
1. Lägg till en anslutare med metoden `addConnector` som exponeras av `Shapes`‑objektet genom att ange anslutartypen.
1. Anslut formerna med anslutaren. 
1. Anropa metoden `reroute` för att tillämpa den kortaste anslutningsvägen.
1. Spara presentationen. 

Denna PHP‑kod visar hur du lägger till en anslutare (en böjd anslutare) mellan två former (en ellips och en rektangel):

```php
// Instansierar en presentationsklass som representerar PPTX-filen
  $pres = new Presentation();
  try {
    # Hämtar formsamlingen för en specifik bild
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Lägger till en Ellipse-autoshape
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Lägger till en Rectangle-autoshape
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Lägger till en anslutningsform i bildens formsamling
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Ansluter formerna med anslutaren
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Anropar reroute som sätter den automatiska kortaste vägen mellan formerna
    $connector->reroute();
    # Sparar presentationen
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Metoden `Connector.reroute` omdirigerar en anslutare och tvingar den att ta den kortaste möjliga vägen mellan formerna. För att uppnå detta kan metoden ändra punkterna `setStartShapeConnectionSiteIndex` och `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Specificera en anslutningspunkt**

Om du vill att en anslutare ska länka två former med specifika punkter på formerna måste du ange dina föredragna anslutningspunkter på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till två [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/AutoShape) på bilden med metoden `addAutoShape` som exponeras av `Shapes`‑objektet.
1. Lägg till en anslutare med metoden `addConnector` som exponeras av `Shapes`‑objektet genom att ange anslutartypen.
1. Anslut formerna med anslutaren. 
1. Ställ in dina föredragna anslutningspunkter på formerna. 
1. Spara presentationen.

Denna PHP‑kod demonstrerar en operation där en föredragen anslutningspunkt specificeras:

```php
  # Instansierar en presentationsklass som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Hämtar formsamlingen för en specifik bild
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Lägg till en Ellipse-autoshape
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Lägg till en Rectangle-autoshape
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Lägger till en anslutningsform i bildens formsamling
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Ansluter formerna med anslutaren
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Ställer in föredraget anslutningspunktindex på Ellipseformen
    $wantedIndex = 6;
    # Kontrollerar om det föredragna indexet är mindre än det maximala antalet anslutningspunkter
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # Ställer in den föredragna anslutningspunkten på Ellipse-autoshapen
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # Sparar presentationen
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Justera en anslutarpunkt**

Du kan justera en befintlig anslutare via dess justeringspunkter. Endast anslutare med justeringspunkter kan förändras på detta sätt. Se tabellen under **[Typer av anslutare](/slides/sv/php-java/connector/#types-of-connectors)**

### **Enkel fall**

Tänk dig ett scenario där en anslutare mellan två former (A och B) passerar genom en tredje form (C):

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

För att undvika eller kringgå den tredje formen kan vi justera anslutaren genom att flytta dess vertikala linje åt vänster på följande sätt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```

### **Komplexa fall** 

För att utföra mer avancerade justeringar måste du ta hänsyn till följande:

* En anslutares justerbara punkt är starkt kopplad till en formel som beräknar och bestämmer dess position. Så förändringar av punktens placering kan ändra anslutarens form.
* En anslutares justeringspunkter definieras i en strikt ordning i en array. Justeringspunkterna är numrerade från anslutarens startpunkt till dess slutpunkt.
* Värdena för justeringspunkterna speglar procentandelen av anslutningsformens bredd/höjd. 
  * Formen begränsas av anslutarens start‑ och slutpunkter multiplicerat med 1000. 
  * Den första, andra och tredje punkten definierar procentandelen av bredden, procentandelen av höjden respektive procentandelen av bredden (igen).
* För beräkningar som bestämmer koordinaterna för en anslutares justeringspunkter måste du ta hänsyn till anslutarens rotation och dess spegling. **Obs** att rotationsvinkeln för alla anslutare som visas under **[Typer av anslutare](/slides/sv/php-java/connector/#types-of-connectors)** är 0.

#### **Fall 1**

Tänk dig ett scenario där två textramar är länkade genom en anslutare:

![connector-shape-complex](connector-shape-complex.png)

```php
  # Instansierar en presentationsklass som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Hämtar den första bilden i presentationen
    $sld = $pres->getSlides()->get_Item(0);
    # Lägger till former som kommer att slås ihop via en anslutare
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # Lägger till en anslutare
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # Anger anslutarens riktning
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # Anger anslutarens färg
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Anger tjockleken på anslutarens linje
    $connector->getLineFormat()->setWidth(3);
    # Länkar formerna tillsammans med anslutaren
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # Hämtar justeringspunkter för anslutaren
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Justering**

Vi kan ändra anslutarens justeringspunktvärden genom att öka respektive bredd‑ och höjdp procentandel med 20 % respektive 200 %:

```php
  # Ändrar värdena för justeringspunkterna
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

Resultatet:

![connector-adjusted-1](connector-adjusted-1.png)

För att definiera en modell som låter oss bestämma koordinaterna och formen för enskilda delar av anslutaren, skapa en form som motsvarar den horisontella komponenten av anslutaren vid punkten `connector.getAdjustments().get_Item(0)`:

```php
  # Rita den vertikala komponenten av anslutaren
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

Resultatet:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

I **Fall 1** demonstrerade vi en enkel justeringsoperation med grundprinciper. I normala situationer måste du ta hänsyn till anslutarens rotation och dess visning (som sätts av `connector.getRotation()`, `connector.getFrame().getFlipH()` och `connector.getFrame().getFlipV()`). Vi visar nu processen.

Först lägger vi till ett nytt textramelement (**To 1**) på bilden (för anslutningssyfte) och skapar en ny (grön) anslutare som kopplar det till de objekt vi redan har skapat.

```php
  # Skapar ett nytt bindningsobjekt
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # Skapar en ny anslutare
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # Kopplar objekt med den nyss skapade anslutaren
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # Hämtar anslutarnas justeringspunkter
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # Ändrar värdena för justeringspunkterna
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

Resultatet:

![connector-adjusted-3](connector-adjusted-3.png)

Sedan skapar vi en form som motsvarar den horisontella komponenten av anslutaren som passerar genom den nya anslutarens justeringspunkt `connector.getAdjustments().get_Item(0)`. Vi använder värdena från anslutardatan för `connector.getRotation()`, `connector.getFrame().getFlipH()` och `connector.getFrame().getFlipV()` och tillämpar den vanliga koordinatkonverteringsformeln för rotation runt en given punkt x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

I vårt fall är objektets rotationsvinkel 90 grad och anslutaren visas vertikalt, så detta är den motsvarande koden:

```php
  # Sparar anslutarnas koordinater
  $x = $connector->getX();
  $y = $connector->getY();
  # Korrigerar anslutarnas koordinater om den visas
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # Tar justeringspunktens värde som koordinat
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Konverterar koordinaterna då Sin(90) = 1 och Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # Bestämmer bredden på den horisontella komponenten med hjälp av värdet för den andra justeringspunkten
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

Resultatet:

![connector-adjusted-4](connector-adjusted-4.png)

Vi har demonstrerat beräkningar som involverar både enkla justeringar och komplexa justeringspunkter (justeringspunkter med rotationsvinklar). Med den kunskap du nu har kan du utveckla din egen modell (eller skriva kod) för att erhålla ett `GraphicsPath`‑objekt eller till och med ställa in en anslutares justeringspunktvärden baserat på specifika bildkoordinater.

## **Hitta vinkeln på anslutningslinjer**

1. Skapa en instans av klassen.
1. Hämta en bilds referens via dess index.
1. Åtkomst till anslutningslinjeformen.
1. Använd linjens bredd, höjd, formramens höjd och formramens bredd för att beräkna vinkeln.

Denna PHP‑kod demonstrerar en operation där vi beräknade vinkeln för en anslutningslinjeform:

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

**Hur kan jag avgöra om en anslutare kan "limmas" på en specifik form?**

Kontrollera att formen exponerar [connection sites](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getconnectionsitecount/). Om det inte finns några eller antalet är noll, är limning inte tillgänglig; i så fall använder du fria ändpunkter och placerar dem manuellt. Det är klokt att kontrollera antalet platser innan du fäster.

**Vad händer med en anslutare om jag tar bort en av de anslutna formerna?**

Dess ändar blir frikopplade; anslutaren kvarstår på bilden som en vanlig linje med fria start‑/slutpunkter. Du kan antingen ta bort den eller återansluta, och vid behov [reroute](https://reference.aspose.com/slides/sv/php-java/aspose.slides/connector/reroute/).

**Bevaras anslutningsbindningarna när en bild kopieras till en annan presentation?**

Generellt ja, förutsatt att målsformerna också kopieras. Om bilden infogas i en annan fil utan de anslutna formerna blir ändarna fria och du måste fästa dem igen.