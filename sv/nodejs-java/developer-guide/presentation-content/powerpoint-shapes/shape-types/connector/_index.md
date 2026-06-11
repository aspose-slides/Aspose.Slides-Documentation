---
title: Hantera kopplingar i presentationer med JavaScript
linktitle: Koppling
type: docs
weight: 10
url: /sv/nodejs-java/connector/
keywords:
- koppling
- kopplingstyp
- kopplingspunkt
- kopplingslinje
- kopplingsvinkel
- anslut former
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Ge JavaScript‑appar möjlighet att rita, koppla och automatisk rutningslinjer i PowerPoint‑bilder — få full kontroll över raka, armbågs‑ och kurviga kopplingar."
---
## **Introduktion**

En PowerPoint‑koppling är en speciell linje som kopplar eller länkar två former tillsammans och förblir fäst vid formerna även när de flyttas eller omplaceras på en viss bild. 

Kopplingar är vanligtvis anslutna till *anslutningspunkter* (gröna prickar), som finns på alla former som standard. Anslutningspunkter visas när en markör kommer nära dem.

*Justeringpunkter* (orange prickar), som bara finns på vissa kopplingar, används för att ändra kopplingarnas positioner och former.

## **Typer av kopplingar**

I PowerPoint kan du använda raka, armbågs‑ (vinklade) och kurviga kopplingar. 

Aspose.Slides provides these connectors:

| Koppling | Bild | Antal justeringspunkter |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Koppla former med kopplingar**

1. Skapa en instans av klassen [Presentation](https://apireference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till två [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape) på bilden med hjälp av metoden `addAutoShape` som exponeras av `Shapes`‑objektet.
1. Lägg till en koppling med metoden `addConnector` som exponeras av `Shapes`‑objektet genom att definiera kopplingstypen.
1. Koppla formerna med hjälp av kopplingen. 
1. Anropa metoden `reroute` för att tillämpa den kortaste förbindelsevägen.
1. Spara presentationen. 

Denna JavaScript‑kod visar hur du lägger till en koppling (en böjd koppling) mellan två former (en ellips och en rektangel):

```javascript
// Instansierar en presentationsklass som representerar PPTX-filen
var pres = new aspose.slides.Presentation();
try {
    // Hämtar formsamlingen för en specifik bild
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Lägger till en ellips-autoshape
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Lägger till en rektangel-autoshape
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Lägger till en kopplingsform i bildens formsamling
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Kopplar formerna med hjälp av kopplingen
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Anropar reroute som sätter den automatiska kortaste vägen mellan formerna
    connector.reroute();
    // Sparar presentationen
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Metoden `Connector.reroute` omdirigerar en koppling och tvingar den att ta den kortaste möjliga vägen mellan formerna. För att uppnå detta kan metoden ändra punkterna `setStartShapeConnectionSiteIndex` och `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Specificera anslutningspunkt**

Om du vill att en koppling ska länka två former med specifika punkter på formerna måste du ange dina föredragna anslutningspunkter på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till två [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape) på bilden med hjälp av metoden `addAutoShape` som exponeras av `Shapes`‑objektet.
1. Lägg till en koppling med metoden `addConnector` som exponeras av `Shapes`‑objektet genom att definiera kopplingstypen.
1. Koppla formerna med hjälp av kopplingen. 
1. Ange dina föredragna anslutningspunkter på formerna. 
1. Spara presentationen.

Denna JavaScript‑kod demonstrerar en operation där en föredragen anslutningspunkt specificeras:

```javascript
// Instansierar en presentationsklass som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Hämtar formsamlingen för en specifik bild
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Lägger till en Ellipse-autoshape
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Lägger till en Rectangle-autoshape
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Lägger till en kopplingsform i bildens formsamling
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Ansluter formerna med kopplingen
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Anger index för föredragen anslutningspunkt på Ellipse‑formen
    var wantedIndex = 6;
    // Kontrollerar om det föredragna indexet är mindre än det maximala antalet anslutningsplatser
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // Anger föredragen anslutningspunkt på Ellipse‑autoshapen
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // Sparar presentationen
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Justera kopplingspunkt**

Du kan justera en befintlig koppling via dess justeringspunkter. Endast kopplingar med justeringspunkter kan ändras på detta sätt. Se tabellen under **[Typer av kopplingar.](/slides/sv/nodejs-java/connector/#types-of-connectors)**

### **Enkel fall**

Tänk dig ett fall där en koppling mellan två former (A och B) passerar genom en tredje form (C):

![connector-obstruction](connector-obstruction.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

För att undvika eller passera den tredje formen kan vi justera kopplingen genom att flytta dess vertikala linje åt vänster på följande sätt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Komplexa fall** 

För att utföra mer komplicerade justeringar måste du ta hänsyn till följande:

* En kopplings justerbara punkt är starkt knuten till en formel som beräknar och bestämmer dess position. Så förändringar av punktens läge kan förändra kopplingens form.
* En kopplings justeringspunkter definieras i en strikt ordning i en array. Justeringspunkterna numreras från kopplingens startpunkt till dess slut.
* Värdena för justeringspunkterna speglar procentandelen av kopplingsformens bredd/höjd. 
  * Formen avgränsas av kopplingens start‑ och slutpunkter multiplicerade med 1000. 
  * Den första, andra och tredje punkten definierar procentandelen från bredden, procentandelen från höjden respektive procentandelen från bredden (återigen).
* För beräkningar som bestämmer koordinaterna för en kopplings justeringspunkter måste du ta hänsyn till kopplingens rotation och dess spegling. **Note** att rotationsvinkeln för alla kopplingar som visas under **[Typer av kopplingar](/slides/sv/nodejs-java/connector/#types-of-connectors)** är 0.

#### **Fall 1**

Tänk dig ett fall där två text‑ram‑objekt länkas samman genom en koppling:

![connector-shape-complex](connector-shape-complex.png)

```javascript
// Instansierar en presentationsklass som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden i presentationen
    var sld = pres.getSlides().get_Item(0);
    // Lägger till former som kommer att kopplas ihop genom en koppling
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Lägger till en koppling
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // Anger kopplingens riktning
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // Anger kopplingens färg
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Anger tjockleken på kopplingens linje
    connector.getLineFormat().setWidth(3);
    // Kopplar samman formerna med kopplingen
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // Hämtar justeringspunkter för kopplingen
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Justering**

Vi kan ändra värdena för kopplingens justeringspunkter genom att öka motsvarande bredd‑ och höjdp procentandel med 20 % respektive 200 %:

```javascript
// Ändrar värdena för justeringspunkterna
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Resultatet:

![connector-adjusted-1](connector-adjusted-1.png)

För att definiera en modell som låter oss bestämma koordinaterna och formen på enskilda delar av kopplingen, skapa en form som motsvarar den horisontella komponenten av kopplingen vid punkten `connector.getAdjustments().get_Item(0)`:

```javascript
// Rita den vertikala komponenten av kopplingen
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```

Resultatet:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

I **Fall 1** demonstrerade vi en enkel justeringsoperation för en koppling med grundläggande principer. I normala situationer måste du ta hänsyn till kopplingens rotation och dess visning (som sätts av `connector.getRotation()`, `connector.getFrame().getFlipH()` och `connector.getFrame().getFlipV()`). Vi kommer nu att demonstrera processen.

Först lägger vi till ett nytt text‑ram‑objekt (**To 1**) på bilden (för anslutningsändamål) och skapar en ny (grön) koppling som ansluter den till de objekt vi redan har skapat.

```javascript
// Skapar ett nytt bindningsobjekt
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Skapar en ny koppling
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// Ansluter objekt med den nyss skapade kopplingen
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Hämtar kopplingens justeringspunkter
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Ändrar värdena för justeringspunkterna
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Resultatet:

![connector-adjusted-3](connector-adjusted-3.png)

Sedan skapar vi en form som motsvarar den horisontella komponenten av kopplingen som passerar genom den nya kopplingens justeringspunkt `connector.getAdjustments().get_Item(0)`. Vi använder värdena från kopplingsdata för `connector.getRotation()`, `connector.getFrame().getFlipH()` och `connector.getFrame().getFlipV()` och tillämpar den vanliga koordinat‑omvandlingsformeln för rotation kring en given punkt x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

I vårt fall är objektets rotationsvinkel 90 grader och kopplingen visas vertikalt, så koden blir följande:

```javascript
// Sparar kopplingens koordinater
x = connector.getX();
y = connector.getY();
// Korrigerar kopplingens koordinater om den visas
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// Tar in justeringspunktsvärdet som koordinat
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// Omvandlar koordinaterna eftersom Sin(90) = 1 och Cos(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// Bestämmer bredden på den horisontella komponenten med hjälp av det andra justeringspunktsvärdet
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Resultatet:

![connector-adjusted-4](connector-adjusted-4.png)

Vi har demonstrerat beräkningar som involverar både enkla justeringar och komplexa justeringspunkter (justeringspunkter med rotationsvinklar). Med den kunskap du nu har kan du utveckla din egen modell (eller skriva kod) för att få ett `GraphicsPath`‑objekt eller till och med sätta värden för en kopplings justeringspunkter baserat på specifika bildkoordinater.

## **Hitta vinkeln på kopplingslinjer**

1. Skapa en instans av klassen.
1. Hämta en bilds referens via dess index.
1. Åtkomst till kopplingslinjens form.
1. Använd linjens bredd, höjd, formramens höjd och formramens bredd för att beräkna vinkeln.

Denna JavaScript‑kod demonstrerar en operation där vi beräknade vinkeln för en kopplingslinjeform:

```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**Hur kan jag avgöra om en koppling kan "limmas" på en specifik form?**

Kontrollera att formen exponerar [connection sites](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Om det inte finns några eller antalet är noll, är limning inte tillgängligt; i så fall använder du fria ändpunkter och placerar dem manuellt. Det är klokt att kontrollera antalet platser innan du fäster.

**Vad händer med en koppling om jag tar bort en av de anslutna formerna?**

Dess ändar blir frikopplade; kopplingen kvarstår på bilden som en vanlig linje med fria start‑/slutpunkter. Du kan antingen ta bort den eller omfördela anslutningarna och, om så behövs, [reroute](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/connector/reroute/).

**Behålls kopplingsbindningarna när en bild kopieras till en annan presentation?**

Normalt ja, förutsatt att de målformer som kopieras också tas med. Om bilden infogas i en annan fil utan de anslutna formerna blir ändarna fria och du måste återansluta dem.