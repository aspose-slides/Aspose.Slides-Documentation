---
title: Hantera anslutningar i presentationer på Android
linktitle: Anslutning
type: docs
weight: 10
url: /sv/androidjava/connector/
keywords:
- anslutning
- anslutningstyp
- anslutningspunkt
- anslutningslinje
- anslutningsvinkel
- koppla former
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Ge Java-appar möjlighet att rita, ansluta och automatiskt rikta linjer i PowerPoint-bilder på Android--få full kontroll över raka, armbågs- och böjda anslutningar."
---
## **Introduktion**

En PowerPoint-anslutning är en speciell linje som kopplar eller länkar två former tillsammans och förblir fäst vid former även när de flyttas eller omplaceras på en given bild. 

Anslutningar är vanligtvis anslutna till *anslutningspunkter* (gröna prickar), som finns på alla former som standard. Anslutningspunkter visas när en markör kommer nära dem.

*Justeringpunkter* (orange prickar), som bara finns på vissa anslutningar, används för att ändra anslutningarnas positioner och former.

## **Typer av anslutningar**

I PowerPoint kan du använda raka, armbågs‑ (vinklade) och böjda anslutningar. 

Aspose.Slides tillhandahåller dessa anslutningar:

| Anslutning                      | Bild                                                          | Antal justeringspunkter |
| ------------------------------ | ------------------------------------------------------------- | ----------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                       |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                       |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                       |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                       |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                       |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                       |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                       |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                       |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                       |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                       |

## **Koppla former med anslutningar**

1. Skapa en instans av klassen [Presentation](https://apireference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till två [AutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/AutoShape) på bilden med `addAutoShape`‑metoden som exponeras av `Shapes`‑objektet.
1. Lägg till en anslutning med `addConnector`‑metoden som exponeras av `Shapes`‑objektet genom att ange anslutningstypen.
1. Koppla formerna med anslutningen. 
1. Anropa `reroute`‑metoden för att använda den kortaste anslutningsvägen.
1. Spara presentationen. 

Den här Java‑koden visar hur du lägger till en anslutning (en böjd anslutning) mellan två former (en ellips och en rektangel):

```Java
// Skapar en presentation-klass som representerar PPTX-filen
Presentation pres = new Presentation();
try {
    // Kommer åt formsamlingen för en specifik bild
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Lägger till en ellips-autoshape
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Lägger till en rektangel-autoshape
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Lägger till en anslutningsform i bildens formsamling
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Ansluter formerna med anslutningen
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Anropar reroute som ställer in den automatiska kortaste vägen mellan former
    connector.reroute();
    
    // Sparar presentationen
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

`Connector.reroute`‑metoden omdirigerar en anslutning och tvingar den att ta den kortaste möjliga vägen mellan former. För att uppnå detta kan metoden ändra punkterna `setStartShapeConnectionSiteIndex` och `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Specificera en anslutningspunkt**

Om du vill att en anslutning ska länka två former med specifika prickar på formerna, måste du specificera dina föredragna anslutningspunkter på detta sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till två [AutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/AutoShape) på bilden med `addAutoShape`‑metoden som exponeras av `Shapes`‑objektet.
1. Lägg till en anslutning med `addConnector`‑metoden som exponeras av `Shapes`‑objektet genom att ange anslutningstypen.
1. Koppla formerna med anslutningen. 
1. Ställ in dina föredragna anslutningspunkter på formerna. 
1. Spara presentationen.

Den här Java‑koden demonstrerar en operation där en föredragen anslutningspunkt specificeras:

```java
// Skapar en presentation-klass som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Kommer åt formsamlingen för en specifik bild
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Lägg till en ellips-autoshape
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Lägg till en rektangel-autoshape
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Lägger till en anslutningsform i bildens formsamling
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Ansluter formerna med anslutningen
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Anger önskat index för anslutningspunkt på ellipsformen
    int wantedIndex = 6;

    // Kontrollerar om det önskade indexet är mindre än det maximala antalet anslutningsställen
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Anger den föredragna anslutningspunkten på ellips-autoshapen
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Sparar presentationen
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Justera en anslutningspunkt**

Du kan justera en befintlig anslutning via dess justeringspunkter. Endast anslutningar med justeringspunkter kan ändras på detta sätt. Se tabellen under **[Typer av anslutningar.](/slides/sv/androidjava/connector/#types-of-connectors)**

### **Enkelt fall**

Betrakta ett fall där en anslutning mellan två former (A och B) passerar genom en tredje form (C):

![connector-obstruction](connector-obstruction.png)

```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

För att undvika eller gå förbi den tredje formen kan vi justera anslutningen genom att flytta dess vertikala linje åt vänster på detta sätt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Komplexa fall** 

För att utföra mer komplicerade justeringar måste du ta hänsyn till följande:

* En anslutnings justerbara punkt är starkt kopplad till en formel som beräknar och bestämmer dess position. Så förändringar av punktens placering kan ändra anslutningens form.
* En anslutnings justeringspunkter definieras i en strikt ordning i en array. Justeringspunkterna numreras från anslutningens startpunkt till dess slut.
* Värdena för justeringspunkterna speglar procentandelen av en anslutnings formbredd/höjd. 
  * Formen begränsas av anslutningens start- och slutpunkter multiplicerade med 1000. 
  * Den första, andra och tredje punkten definierar procentandelarna från bredden, höjden respektive bredden (igen) .
* För beräkningar som bestämmer koordinaterna för en anslutnings justeringspunkter måste du ta hänsyn till anslutningens rotation och dess spegling. **Obs** att rotationsvinkeln för alla anslutningar som visas under **[Typer av anslutningar](/slides/sv/androidjava/connector/#types-of-connectors)** är 0.

#### **Fall 1**

Betrakta ett fall där två textramar är länkade tillsammans via en anslutning:

![connector-shape-complex](connector-shape-complex.png)

```java
// Skapar en presentation-klass som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden i presentationen
    ISlide sld = pres.getSlides().get_Item(0);
    // Lägger till former som kommer att förenas via en anslutning
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Lägger till en anslutning
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Anger anslutningens riktning
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Anger anslutningens färg
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Anger tjockleken på anslutningens linje
    connector.getLineFormat().setWidth(3);
    
    // Länkar samman formerna med anslutningen
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Hämtar justeringspunkterna för anslutningen
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Justering**

Vi kan ändra anslutningens justeringspunktvärden genom att öka den motsvarande bredd‑ och höjdpctandelarna med 20 % respektive 200 %:

```java
// Ändrar värdena på justeringspunkterna
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Resultatet:

![connector-adjusted-1](connector-adjusted-1.png)

För att definiera en modell som låter oss bestämma koordinaterna och formen för enskilda delar av anslutningen, låt oss skapa en form som motsvarar den horisontella komponenten av anslutningen vid punkten `connector.getAdjustments().get_Item(0)`:

```java
// Rita den vertikala komponenten av anslutningen
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Resultatet:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

I **Fall 1** demonstrerade vi en enkel anslutningsjustering med grundläggande principer. I vanliga situationer måste du ta hänsyn till anslutningens rotation och dess visning (som sätts av `connector.getRotation()`, `connector.getFrame().getFlipH()` och `connector.getFrame().getFlipV()`). Vi kommer nu att demonstrera processen.

Först, låt oss lägga till ett nytt textramobjekt (**To 1**) på bilden (för anslutningsändamål) och skapa en ny (grön) anslutning som länkar den till objekten vi redan skapat.

```java
// Skapar ett nytt bindningsobjekt
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Skapar en ny anslutning
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Kopplar ihop objekt med den nyss skapade anslutningen
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Hämtar anslutningens justeringspunkter
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Ändrar värdena på justeringspunkterna
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Resultatet:

![connector-adjusted-3](connector-adjusted-3.png)

Sedan, låt oss skapa en form som motsvarar den horisontella komponenten av anslutningen som passerar genom den nya anslutningens justeringspunkt `connector.getAdjustments().get_Item(0)`. Vi kommer att använda värdena från anslutningsdata för `connector.getRotation()`, `connector.getFrame().getFlipH()` och `connector.getFrame().getFlipV()` och tillämpa den vanliga koordinatkonverteringsformeln för rotation runt en given punkt x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

I vårt fall är objektets rotationsvinkel 90 grader och anslutningen visas vertikalt, så detta är motsvarande kod:

```java
// Sparar anslutningens koordinater
x = connector.getX();
y = connector.getY();
// Korrigerar anslutningens koordinater om den visas
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Tar in justeringspunktsvärdet som koordinat
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Omvandlar koordinaterna eftersom Sin(90) = 1 och Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Bestämmer bredden på den horisontella komponenten med hjälp av det andra justeringspunktsvärdet
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Resultatet:

![connector-adjusted-4](connector-adjusted-4.png)

Vi demonstrerade beräkningar som involverar enkla justeringar och komplicerade justeringspunkter (justeringspunkter med rotationsvinklar). Med den kunskap du har fått kan du utveckla din egen modell (eller skriva kod) för att få ett `GraphicsPath`‑objekt eller till och med sätta en anslutnings justeringspunktvärden baserat på specifika bildkoordinater.

## **Hitta vinkeln på anslutningslinjer**

1. Skapa en instans av klassen.
1. Hämta en bilds referens via dess index.
1. Få åtkomst till anslutningslinjens form.
1. Använd linjens bredd, höjd, formens ramhöjd och rambredd för att beräkna vinkeln.

Den här Java‑koden demonstrerar en operation där vi beräknade vinkeln för en anslutningslinjeform:

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**Hur kan jag avgöra om en anslutning kan ”limmas” till en specifik form?**

Kontrollera att formen exponerar [anslutningsställen](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getConnectionSiteCount--). Om det inte finns några eller antalet är noll, är limning inte tillgänglig; i så fall använder du fria ändpunkter och placerar dem manuellt. Det är klokt att kontrollera antalet ställen innan du fäster.

**Vad händer med en anslutning om jag tar bort en av de anslutna formerna?**

Dess ändar blir frikopplade; anslutningen förblir på bilden som en vanlig linje med fri start/slut. Du kan antingen radera den eller omfördela anslutningarna och, om behövs, [reroute](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/connector/#reroute--).

**Behålls anslutningsbindningarna när en bild kopieras till en annan presentation?**

Generellt ja, förutsatt att målformerna också kopieras. Om bilden infogas i en annan fil utan de anslutna formerna blir ändarna fria och du måste fästa dem igen.