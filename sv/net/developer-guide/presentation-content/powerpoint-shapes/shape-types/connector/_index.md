---
title: Hantera kopplingar i presentationer i .NET
linktitle: Koppling
type: docs
weight: 10
url: /sv/net/connector/
keywords:
- koppling
- kopplingstyp
- kopplingspunkt
- kopplingslinje
- kopplingsvinkel
- anslut former
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Ge .NET-appar möjlighet att rita, ansluta och automatiskt leda linjer i PowerPoint-bilder—få full kontroll över raka, armbågs- och kurviga kopplingar."
---
## **Introduktion**

En PowerPoint‑koppling är en speciell linje som förbinder två former och förblir fäst vid formerna även när de flyttas eller omplaceras på en given bild. 

Kopplingar är vanligtvis anslutna till *anslutningspunkter* (gröna prickar), som finns på alla former som standard. Anslutningspunkter visas när en muspekare kommer nära dem.

*Justeringpunkter* (orange prickar), som bara finns på vissa kopplingar, används för att ändra kopplingarnas positioner och former.

## **Typer av kopplingar**

I PowerPoint kan du använda raka, armbåg (vinklade) och kurviga kopplingar. 

Aspose.Slides tillhandahåller dessa kopplingar:

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

## **Anslut former med kopplingar**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) .
1. Hämta en bilds referens via dess index.
1. Lägg till två [AutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/autoshape/) på bilden med metoden `AddAutoShape` som exponeras av `Shapes`‑objektet.
1. Lägg till en koppling med metoden `AddConnector` som exponeras av `Shapes`‑objektet genom att ange kopplingstyp.
1. Anslut formerna med kopplingen. 
1. Anropa metoden `Reroute` för att tillämpa den kortaste anslutningsvägen.
1. Spara presentationen. 

Denna C#‑kod visar hur du lägger till en koppling (en böjd koppling) mellan två former (en ellips och en rektangel):

```c#
// Instansierar en presentationsklass som representerar en PPTX-fil
using (Presentation input = new Presentation())
{                
    // Hämtar samlingen av former för en specifik bild
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Lägger till en Ellipse-autoshape
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Lägger till en rektangel-autoshape
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Lägger till en kopplingsform till bildens formssamling
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Ansluter formerna med kopplingen
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Anropar Reroute som sätter den automatiska kortaste vägen mellan formerna
    connector.Reroute();

    // Sparar presentationen
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Metoden `Connector.Reroute` omdirigerar en koppling och tvingar den att ta den kortaste möjliga vägen mellan former. För att uppnå detta kan metoden ändra punkterna `StartShapeConnectionSiteIndex` och `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Specificera en anslutningspunkt**

Om du vill att en koppling ska länka två former med specifika punkter på formerna måste du ange dina föredragna anslutningspunkter på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) .
1. Hämta en bilds referens via dess index.
1. Lägg till två [AutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/autoshape/) på bilden med metoden `AddAutoShape` som exponeras av `Shapes`‑objektet.
1. Lägg till en koppling med metoden `AddConnector` som exponeras av `Shapes`‑objektet genom att ange kopplingstyp.
1. Anslut formerna med kopplingen. 
1. Ställ in dina föredragna anslutningspunkter på formerna. 
1. Spara presentationen.

Denna C#‑kod demonstrerar en operation där en föredragen anslutningspunkt specificeras:

```c#
// Instansierar en presentationsklass som representerar en PPTX-fil
using (Presentation presentation = new Presentation())
{
    // Hämtar samlingen av former för en specifik bild
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Lägger till en kopplingsform i bildens formssamling
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Lägger till en Ellipse-autoshape
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Lägger till en rektangel-autoshape
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Ansluter formerna med kopplingen
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Anger önskat anslutningspunktindex på Ellipse‑formen
    uint wantedIndex = 6;

    // Kontrollerar om det önskade indexet är mindre än det maximala antalet anslutningsplatser
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Anger den önskade anslutningspunkten på Ellipse‑autoshapen
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Sparar presentationen
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **Justera en kopplingspunkt**

Du kan justera en befintlig koppling via dess justeringspunkter. Endast kopplingar med justeringspunkter kan ändras på detta sätt. Se tabellen under **[Typer av kopplingar](/slides/sv/net/connector/#types-of-connectors)** 

### **Enkelt fall**

Tänk dig ett scenario där en koppling mellan två former (A och B) passerar genom en tredje form (C):

![connector-obstruction](connector-obstruction.png)

Kod:

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

För att undvika eller gå förbi den tredje formen kan vi justera kopplingen genom att flytta dess vertikala linje åt vänster på följande sätt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **Komplexa fall** 

För att utföra mer komplicerade justeringar måste du ta hänsyn till följande:

* En justeringspunkts placering är starkt kopplad till en formel som beräknar och bestämmer dess position. Så förändringar av punktens läge kan förändra kopplingens form.
* Justeringspunkterna definieras i en strikt ordning i en array. De är numrerade från kopplingens startpunkt till dess slutpunkt.
* Justeringspunktsvärdena avspeglar procenten av kopplingens bredd/höjd. 
  * Formen avgränsas av kopplingens start‑ och slutpunkter multiplicerat med 1000. 
  * Den första, andra och tredje punkten anger respektive procenten från bredden, procenten från höjden och procenten från bredden (återigen).
* Vid beräkning av koordinaterna för en kopplings justeringspunkter måste du ta hänsyn till kopplingens rotation och dess reflektion. **Obs** att rotationsvinkeln för alla kopplingar som visas under **[Typer av kopplingar](/slides/sv/net/connector/#types-of-connectors)** är 0.

#### **Fall 1**

Tänk dig ett fall där två text‑ram‑objekt länkas ihop via en koppling:

![connector-shape-complex](connector-shape-complex.png)

Kod:

```c#
// Instansierar en presentationsklass som representerar en PPTX-fil
Presentation pres = new Presentation();
// Hämtar den första bilden i presentationen
ISlide sld = pres.Slides[0];
// Lägger till former som kommer att kopplas ihop via en koppling
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// Lägger till en koppling
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Anger kopplingens riktning
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Anger kopplingens färg
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Anger tjockleken på kopplingens linje
connector.LineFormat.Width = 3;

// Kopplar ihop formerna med kopplingen
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Hämtar justeringspunkter för kopplingen
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**Justering**

Vi kan ändra värdena för kopplingens justeringspunkter genom att öka de motsvarande procenten av bredd och höjd med 20 % respektive 200 %:

```c#
// Ändrar värdena för justeringspunkterna
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Resultatet:

![connector-adjusted-1](connector-adjusted-1.png)

För att definiera en modell som låter oss bestämma koordinaterna och formen för enskilda delar av kopplingen skapar vi en form som motsvarar den horisontella komponenten av kopplingen vid punkten `connector.Adjustments[0]`:

```c#
// Rita den vertikala komponenten av kopplingen

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Resultatet:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

I **Fall 1** visade vi en enkel justeringsoperation med grundläggande principer. I normala situationer måste du ta hänsyn till kopplingens rotation och dess visning (som sätts av `connector.Rotation`, `connector.Frame.FlipH` och `connector.Frame.FlipV`). Vi demonstrerar nu processen.

Först lägger vi till ett nytt text‑ram‑objekt (**To 1**) på bilden (för anslutningsändamål) och skapar en ny (grön) koppling som länkar den till de objekt vi redan har skapat.

```c#
// Skapar ett nytt bindningsobjekt
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// Skapar en ny koppling
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Kopplar objekt med den nyskapade kopplingen
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// Hämtar kopplingens justeringspunkter
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Ändrar värdena för justeringspunkterna 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Resultatet:

![connector-adjusted-3](connector-adjusted-3.png)

Sedan skapar vi en form som motsvarar den horisontella komponenten av kopplingen som passerar genom den nya kopplingens justeringspunkt `connector.Adjustments[0]`. Vi använder värdena från kopplingsdata för `connector.Rotation`, `connector.Frame.FlipH` och `connector.Frame.FlipV` och tillämpar den populära koordinatkonverteringsformeln för rotation kring en given punkt x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

I vårt fall är objektets rotationsvinkel 90 grader och kopplingen visas vertikalt, så koden blir:

```c#
// Sparar kopplingens koordinater
x = connector.X;
y = connector.Y;
// Korrigerar kopplingens koordinater om den visas
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// Tar justeringspunktsvärdet som koordinat
x += connector.Width * adjValue_0.RawValue / 100000;
//  Omvandlar koordinaterna eftersom Sin(90) = 1 och Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// Bestämmer bredden på den horisontella komponenten med hjälp av det andra justeringspunktsvärdet
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
```

Resultatet:

![connector-adjusted-4](connector-adjusted-4.png)

Vi har demonstrerat beräkningar som involverar både enkla justeringar och komplicerade justeringspunkter (justeringspunkter med rotationsvinklar). Med den kunskap du nu har kan du utveckla din egen modell (eller skriva kod) för att få ett `GraphicsPath`‑objekt eller till och med sätta värden för en kopplings justeringspunkter baserat på specifika bildkoordinater.

## **Hitta vinkeln på kopplingslinjer**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) .
1. Hämta en bilds referens via dess index.
1. Åtkomst till kopplingslinjeformen. 
1. Använd linjens bredd, höjd, formens ramhöjd och rambredd för att beräkna vinkeln.

Denna C#‑kod demonstrerar en operation där vi beräknade vinkeln för en kopplingslinjeform:

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **Vanliga frågor**

**Hur kan jag avgöra om en koppling kan "limmas" på en specifik form?**

Kontrollera att formen exponerar [connection sites](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/connectionsitecount/). Om det inte finns några eller antalet är noll, är limning inte tillgänglig; i så fall använder du fria ändpunkter och placerar dem manuellt. Det är klokt att kontrollera antalet innan du fäster.

**Vad händer med en koppling om jag tar bort en av de anslutna formerna?**

Dess ändar blir frikopplade; kopplingen kvarstår på bilden som en vanlig linje med fria start‑/slutpunkter. Du kan antingen radera den eller återansluta och, om behövs, [reroute](https://reference.aspose.com/slides/sv/net/aspose.slides/connector/reroute/).

**Behålls kopplingsbindningar när en bild kopieras till en annan presentation?**

I allmänhet ja, förutsatt att de målformer som kopplas också kopieras. Om bilden infogas i en annan fil utan de anslutna formerna blir ändarna fria och du måste återansluta dem.