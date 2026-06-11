---
title: Hantera anslutare i presentationer med Java
linktitle: Anslutare
type: docs
weight: 10
url: /sv/java/connector/
keywords:
- anslutare
- anslutartyp
- anslutningspunkt
- anslutningslinje
- anslutningsvinkel
- koppla former
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Ge Java-applikationer möjlighet att rita, ansluta och automatiskt rutta linjer i PowerPoint‑bilder—få full kontroll över raka, armbågs‑ och kurviga anslutare."
---
## **Introduktion**

En PowerPoint‑anslutare är en speciell linje som kopplar ihop två former och förblir fäst vid formerna även när de flyttas eller repositioneras på en given bild.  

Anslutare är vanligtvis anslutna till *anslutningspunkter* (gröna prickar), som finns på alla former som standard. Anslutningspunkter visas när en markör kommer nära dem.  

*Justeringpunkter* (orange prickar), som endast finns på vissa anslutare, används för att ändra anslutarnas positioner och former.  

## **Typer av anslutare**

I PowerPoint kan du använda raka, armbågs‑ (vinklade) och kurviga anslutare.  

Aspose.Slides tillhandahåller följande anslutare:

| Anslutare                      | Bild                                                        | Antal justeringspunkter |
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

## **Koppla former med anslutare**

1. Skapa en instans av klassen [Presentation](https://apireference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till två [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/AutoShape) på bilden med metoden `addAutoShape` som exponeras av `Shapes`‑objektet.
1. Lägg till en anslutare med metoden `addConnector` som exponeras av `Shapes`‑objektet genom att definiera anslutartypen.
1. Koppla ihop formerna med anslutaren. 
1. Anropa metoden `reroute` för att tillämpa den kortaste förbindelsevägen.
1. Spara presentationen. 

Denna Java‑kod visar hur du lägger till en anslutare (en böjd anslutare) mellan två former (en ellips och en rektangel):

```Java
// Instansierar en presentationsklass som representerar PPTX-filen
Presentation pres = new Presentation();
try {
    // Hämtar samlingen av former för en specifik bild
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Lägger till en ellips-autoshape
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Lägger till en rektangel-autoshape
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Lägger till en anslutningsform till bildens samling av former
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Kopplar ihop formerna med hjälp av anslutaren
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Anropar reroute som sätter den automatiska kortaste vägen mellan former
    connector.reroute();
    
    // Sparar presentationen
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.reroute`‑metoden omdirigerar en anslutare och tvingar den att ta den kortaste möjliga vägen mellan former. För att uppnå detta kan metoden ändra punkterna `setStartShapeConnectionSiteIndex` och `setEndShapeConnectionSiteIndex`. 
{{% /alert %}} 

## **Ange en anslutningspunkt**

Om du vill att en anslutare ska länka två former med specifika punkter på formerna, måste du ange dina föredragna anslutningspunkter på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till två [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/AutoShape) på bilden med metoden `addAutoShape` som exponeras av `Shapes`‑objektet.
1. Lägg till en anslutare med metoden `addConnector` som exponeras av `Shapes`‑objektet genom att definiera anslutartypen.
1. Koppla ihop formerna med anslutaren. 
1. Ställ in dina föredragna anslutningspunkter på formerna. 
1. Spara presentationen.

Denna Java‑kod demonstrerar en operation där en föredragen anslutningspunkt specificeras:

```java
// Instansierar en presentationsklass som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Hämtar samlingen av former för en specifik bild
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Lägger till en ellips-autoshape
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Lägger till en rektangel-autoshape
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Lägger till en anslutningsform i bildens samling av former
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Ansluter formerna med hjälp av anslutaren
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Ställer in önskat index för anslutningspunkt på ellipsformen
    int wantedIndex = 6;

    // Kontrollerar om det önskade indexet är mindre än det maximala antalet anslutningsställen
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Ställer in den föredragna anslutningspunkten på ellips-autoshapen
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Sparar presentationen
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Justera en anslutarpunkt**

Du kan justera en befintlig anslutare via dess justeringspunkter. Endast anslutare med justeringspunkter kan ändras på detta sätt. Se tabellen under **[Typer av anslutare.](/slides/sv/java/connector/#types-of-connectors)** 

### **Enkelt fall**

Tänk dig ett fall där en anslutare mellan två former (A och B) passerar genom en tredje form (C):

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

För att undvika eller gå runt den tredje formen kan vi justera anslutaren genom att flytta dess vertikala linje åt vänster på följande sätt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Komplexa fall** 

För att utföra mer komplicerade justeringar måste du ta hänsyn till följande:

* En anslutares justerbara punkt är starkt knuten till en formel som beräknar och bestämmer dess position. Så förändringar av punktens placering kan ändra anslutarens form.
* En anslutares justeringspunkter definieras i en strikt ordning i en array. Justeringspunkterna numreras från anslutarens startpunkt till dess slut.
* Värdena för justeringspunkterna reflekterar procenten av en anslutningsforms bredd/höjd. 
  * Formen avgränsas av anslutarens start- och slutpunkter multiplicerade med 1000. 
  * Den första punkten, andra punkten och tredje punkten definierar procenten från bredden, procenten från höjden och procenten från bredden (igen) respektive.
* För beräkningar som bestämmer koordinaterna för en anslutares justeringspunkter måste du ta hänsyn till anslutarens rotation och dess reflektion. **Obs!** att rotationsvinkeln för alla anslutare som visas under **[Typer av anslutare](/slides/sv/java/connector/#types-of-connectors)** är 0.

#### **Fall 1**

Tänk dig ett fall där två textramhänvisningar är länkade tillsammans genom en anslutare:

![connector-shape-complex](connector-shape-complex.png)

```java
// Instansierar en presentationsklass som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden i presentationen
    ISlide sld = pres.getSlides().get_Item(0);
    // Lägger till former som kommer att kopplas samman med en anslutare
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Lägger till en anslutare
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Anger anslutarens riktning
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Anger anslutarens färg
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Anger tjockleken på anslutarens linje
    connector.getLineFormat().setWidth(3);
    
    // Kopplar ihop formerna med anslutaren
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Hämtar justeringspunkter för anslutaren
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Justering**

Vi kan ändra anslutarens justeringspunktsvärden genom att öka den motsvarande bredd- och höjdp procenten med 20% respektive 200%:

```java
// Ändrar värdena för justeringspunkterna
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Resultatet:

![connector-adjusted-1](connector-adjusted-1.png)

För att definiera en modell som låter oss bestämma koordinaterna och formen för enskilda delar av anslutaren, låt oss skapa en form som motsvarar den horisontella komponenten av anslutaren vid punkten connector.getAdjustments().get_Item(0):

```java
// Rita den vertikala komponenten av anslutaren
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Resultatet:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

I **Fall 1** demonstrerade vi en enkel anslutarjusteringsoperation med grundläggande principer. I normala situationer måste du ta hänsyn till anslutarens rotation och dess visning (som sätts av connector.getRotation(), connector.getFrame().getFlipH() och connector.getFrame().getFlipV()). Vi kommer nu att demonstrera processen.

Först, låt oss lägga till ett nytt textramhänvisningsobjekt (**To 1**) på bilden (för anslutningsändamål) och skapa en ny (grön) anslutare som kopplar den till de objekt vi redan skapat.

```java
// Skapar ett nytt bindningsobjekt
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Skapar en ny anslutare
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Kopplar ihop objekt med den nyss skapade anslutaren
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Hämtar anslutarets justeringspunkter
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Ändrar värdena för justeringspunkterna
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Resultatet:

![connector-adjusted-3](connector-adjusted-3.png)

För det andra, låt oss skapa en form som motsvarar den horisontella komponenten av anslutaren som passerar genom den nya anslutarens justeringspunkt connector.getAdjustments().get_Item(0). Vi kommer att använda värdena från anslutardatan för connector.getRotation(), connector.getFrame().getFlipH() och connector.getFrame().getFlipV() och tillämpa den vanliga koordinatkonverteringsformeln för rotation kring en given punkt x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

I vårt fall är objektets rotationsvinkel 90 grader och anslutaren visas vertikalt, så detta är motsvarande kod:

```java
// Sparar anslutningskoordinaterna
x = connector.getX();
y = connector.getY();
// Korrigerar anslutningskoordinaterna om den visas
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Använder justeringspunktens värde som koordinat
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Omvandlar koordinaterna eftersom Sin(90) = 1 och Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Bestämmer bredden på den horisontella komponenten med värdet för den andra justeringspunkten
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Resultatet:

![connector-adjusted-4](connector-adjusted-4.png)

Vi demonstrerade beräkningar som involverar enkla justeringar och komplicerade justeringspunkter (justeringspunkter med rotationsvinklar). Med den förvärvade kunskapen kan du utveckla din egen modell (eller skriva kod) för att få ett `GraphicsPath`‑objekt eller till och med sätta en anslutares justeringspunktsvärden baserat på specifika bildkoordinater.

## **Hitta vinkeln på anslutarlinjer**

1. Skapa en instans av klassen.
1. Hämta en bilds referens via dess index.
1. Kom åt anslutarlinjens form.
1. Använd linjens bredd, höjd, formens ramhöjd och rambredd för att beräkna vinkeln.

Denna Java‑kod demonstrerar en operation där vi beräknade vinkeln för en anslutarlinjens form:

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

**Hur kan jag avgöra om en anslutare kan "limmas" till en specifik form?**

Kontrollera att formen exponerar [anslutningsställen](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getConnectionSiteCount--). Om det inte finns några eller antalet är noll, är limning inte tillgänglig; i så fall använder du fria ändpunkter och placerar dem manuellt. Det är förnuftigt att kontrollera antalet ställen innan du fäster.

**Vad händer med en anslutare om jag tar bort en av de anslutna formerna?**

Dess ändar kommer att lossna; anslutaren förblir på bilden som en vanlig linje med fria start/slut. Du kan antingen radera den eller omdefiniera anslutningarna och, om behövs, [reroute](https://reference.aspose.com/slides/sv/java/com.aspose.slides/connector/#reroute--).

**Behålls anslutningsbindningar när en bild kopieras till en annan presentation?**

Generellt ja, förutsatt att de målformade också kopieras. Om bilden infogas i en annan fil utan de anslutna formerna blir ändarna fria och du måste återfästa dem.