---
title: Beheer connectors in presentaties in .NET
linktitle: Connector
type: docs
weight: 10
url: /nl/net/connector/
keywords:
- connector
- connector-type
- connectorpunt
- connectorlijn
- connectorhoek
- vormen verbinden
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Geef .NET-apps de mogelijkheid om lijnen te tekenen, te verbinden en automatisch te routeren in PowerPoint-dia's - krijg volledige controle over rechte, elleboog- en gebogen connectors."
---
## **Introductie**

Een PowerPoint‑connector is een speciale lijn die twee vormen met elkaar verbindt of koppelt en aan de vormen blijft bevestigd, zelfs wanneer ze worden verplaatst of opnieuw gepositioneerd op een dia. 

Connectors worden meestal verbonden met *verbindingstippen* (groene stippen), die standaard op alle vormen aanwezig zijn. Verbindingstippen verschijnen wanneer de cursor er dichtbij komt.

*Aanpassingspunten* (oranje stippen), die alleen op bepaalde connectors bestaan, worden gebruikt om de positie en vorm van connectors te wijzigen.

## **Soorten connectors**

In PowerPoint kun je rechte, elleboog‑ (hoekige) en gebogen connectors gebruiken. 

Aspose.Slides biedt de volgende connectors:

| Connector | Afbeelding | Aantal aanpassingspunten |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **Vormen verbinden met connectors**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.  
1. Haal de referentie van een dia op via de index.  
1. Voeg twee [AutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/) toe aan de dia met de `AddAutoShape`‑methode van het `Shapes`‑object.  
1. Voeg een connector toe met de `AddConnector`‑methode van het `Shapes`‑object door het connector‑type te definiëren.  
1. Verbind de vormen met de connector.  
1. Roep de `Reroute`‑methode aan om het kortste verbindingspad toe te passen.  
1. Sla de presentatie op.  

Deze C#‑code laat zien hoe je een connector (een gebogen connector) toevoegt tussen twee vormen (een ellips en een rechthoek):

```c#
 // Instantieert een presentatieklasse die een PPTX‑bestand representeert
using (Presentation input = new Presentation())
{                
    // Toegang tot de vormverzameling voor een specifieke dia
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Voegt een ellips‑autovorm toe
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Voegt een rechthoek‑autovorm toe
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Voegt een connectorvorm toe aan de vormverzameling van de dia
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Verbindt de vormen met de connector
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Roept reroute aan die het automatisch kortste pad tussen vormen instelt
    connector.Reroute();

    // Slaat de presentatie op
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

De `Connector.Reroute`‑methode herleidt een connector en dwingt deze om het kortst mogelijke pad tussen vormen te volgen. Om dit te bereiken, kan de methode de punten `StartShapeConnectionSiteIndex` en `EndShapeConnectionSiteIndex` wijzigen. 

{{% /alert %}} 

## **Specificeer een verbindingstip**

Als je wilt dat een connector twee vormen met specifieke stippen op de vormen verbindt, moet je de gewenste verbindingstippen als volgt opgeven:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.  
1. Haal de referentie van een dia op via de index.  
1. Voeg twee [AutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/) toe aan de dia met de `AddAutoShape`‑methode van het `Shapes`‑object.  
1. Voeg een connector toe met de `AddConnector`‑methode van het `Shapes`‑object door het connector‑type te definiëren.  
1. Verbind de vormen met de connector.  
1. Stel je gewenste verbindingstippen op de vormen in.  
1. Sla de presentatie op.  

Deze C#‑code toont een bewerking waarbij een voorkeurs‑verbindingstip wordt gespecificeerd:

```c#
// Instantieert een presentatieklasse die een PPTX‑bestand representeert
using (Presentation presentation = new Presentation())
{
    // Toegang tot de vormenverzameling voor een specifieke dia
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Voegt een connectorvorm toe aan de vormenverzameling van de dia
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Voegt een ellips autovorm toe
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Voegt een rechthoek autovorm toe
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Verbindt de vormen met de connector
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Stelt de gewenste verbindingstip‑index in op de ellipsvorm
    uint wantedIndex = 6;

    // Controleert of de gewenste index kleiner is dan het maximale aantal verbindingssites
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Stelt de gewenste verbindingstip in op de ellips‑autovorm
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Slaat de presentatie op
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **Een connectorpunt aanpassen**

Je kunt een bestaande connector aanpassen via zijn aanpassingspunten. Alleen connectors met aanpassingspunten kunnen op deze manier worden gewijzigd. Zie de tabel onder **[Types of connectors.](/slides/nl/net/connector/#types-of-connectors)** 

### **Eenvoudig geval**

Beschouw een situatie waarin een connector tussen twee vormen (A en B) door een derde vorm (C) loopt:

![connector-obstruction](connector-obstruction.png)

Code:

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

Om de derde vorm te vermijden of er omheen te gaan, kunnen we de connector aanpassen door de verticale lijn naar links te verplaatsen:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **Complexe gevallen** 

Voor meer ingewikkelde aanpassingen moet je rekening houden met het volgende:

* Het aanpasbare punt van een connector is sterk verbonden met een formule die de positie berekent en bepaalt. Wijzigingen in de locatie van het punt kunnen de vorm van de connector beïnvloeden.  
* De aanpassingspunten van een connector worden in een strikte volgorde in een array gedefinieerd. De punten worden genummerd van het startpunt van de connector tot het eindpunt.  
* Waarden van aanpassingspunten geven het percentage van de breedte/hoogte van de connectorvorm weer.  
  * De vorm wordt begrensd door het start‑ en eindpunt van de connector vermenigvuldigd met 1000.  
  * Het eerste punt, tweede punt en derde punt geven respectievelijk het percentage van de breedte, het percentage van de hoogte en opnieuw het percentage van de breedte weer.  
* Voor berekeningen die de coördinaten van de aanpassingspunten van een connector bepalen, moet je rekening houden met de rotatie van de connector en zijn spiegeling. **Let op** dat de rotatiehoek voor alle connectors die onder **[Types of connectors](/slides/nl/net/connector/#types-of-connectors)** worden getoond, 0 is.

#### **Geval 1**

Beschouw een situatie waarin twee tekstvakobjecten via een connector met elkaar zijn verbonden:

![connector-shape-complex](connector-shape-complex.png)

Code:

```c#
// Instantieert een presentatieklasse die een PPTX‑bestand representeert
Presentation pres = new Presentation();
// Haalt de eerste dia in de presentatie op
ISlide sld = pres.Slides[0];
// Voegt vormen toe die via een connector met elkaar verbonden zullen worden
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// Voegt een connector toe
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Specificeert de richting van de connector
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Specificeert de kleur van de connector
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Specificeert de dikte van de connectorlijn
connector.LineFormat.Width = 3;

// Verbindt de vormen met de connector
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Haalt de aanpassingspunten op voor de connector
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**Aanpassing**

We kunnen de waarden van de aanpassingspunten van de connector wijzigen door respectievelijk 20 % en 200 % van het bijbehorende breedte‑ en hoogtepercentage toe te voegen:

```c#
// Wijzigt de waarden van de aanpassingspunten
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Het resultaat:

![connector-adjusted-1](connector-adjusted-1.png)

Om een model te definiëren waarmee we de coördinaten en de vorm van individuele delen van de connector kunnen bepalen, maken we een vorm die overeenkomt met het horizontale onderdeel van de connector op het punt `connector.Adjustments[0]`:

```c#
// Teken het verticale component van de connector

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Het resultaat:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Geval 2**

In **Geval 1** hebben we een eenvoudige connectoraanpassing getoond op basis van basisprincipes. In normale situaties moet je de rotatie van de connector en de weergave (die worden ingesteld via `connector.Rotation`, `connector.Frame.FlipH` en `connector.Frame.FlipV`) in overweging nemen. We laten nu het proces zien.

Eerst voegen we een nieuw tekstvakobject (**To 1**) toe aan de dia (voor verbindingsdoeleinden) en maken we een nieuwe (groene) connector die dit koppelt aan de reeds gemaakte objecten.

```c#
// Maakt een nieuw bindingobject aan
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// Maakt een nieuwe connector
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Verbindt objecten met de zojuist aangemaakte connector
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// Haalt de aanpassingspunten van de connector op
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Wijzigt de waarden van de aanpassingspunten
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Het resultaat:

![connector-adjusted-3](connector-adjusted-3.png)

Vervolgens maken we een vorm die correspondeert met het horizontale onderdeel van de connector dat door het nieuwe aanpassingspunt `connector.Adjustments[0]` loopt. We gebruiken de waarden uit de connector‑data voor `connector.Rotation`, `connector.Frame.FlipH` en `connector.Frame.FlipV` en passen de bekende coördinatenconversieformule voor rotatie rond een gegeven punt x0 toe:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;  

In ons geval is de rotatiehoek van het object 90 graden en wordt de connector verticaal weergegeven, dus dit is de bijbehorende code:

```c#
// Slaat de connectorcoördinaten op
x = connector.X;
y = connector.Y;
// Corrigeert de connectorcoördinaten indien nodig
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// Neemt de waarde van het aanpassingspunt als coördinaat
x += connector.Width * adjValue_0.RawValue / 100000;
//  Converteert de coördinaten aangezien Sin(90) = 1 en Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// Bepaalt de breedte van het horizontale component met behulp van de waarde van het tweede aanpassingspunt
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```

Het resultaat:

![connector-adjusted-4](connector-adjusted-4.png)

We hebben berekeningen getoond die zowel eenvoudige aanpassingen als complexe aanpassingspunten (aanpassingspunten met rotatiehoeken) omvatten. Met de verkregen kennis kun je je eigen model ontwikkelen (of code schrijven) om een `GraphicsPath`‑object te verkrijgen of zelfs de waarden van een connector‑aanpassingspunt in te stellen op basis van specifieke dia‑coördinaten.

## **De hoek van connectorlijnen bepalen**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.  
1. Haal de referentie van een dia op via de index.  
1. Open de connector‑lijnvorm.  
1. Gebruik de breedte, hoogte, vorm‑frame‑hoogte en vorm‑frame‑breedte om de hoek te berekenen.  

Deze C#‑code toont een bewerking waarbij we de hoek voor een connector‑lijnvorm berekenden:

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

## **FAQ**

**Hoe kan ik zien of een connector aan een specifieke vorm kan worden “geplakt”?**

Controleer of de vorm [connection sites](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/connectionsitecount/) exposeert. Als er geen zijn of de telling nul is, is plakken niet beschikbaar; gebruik in dat geval vrije eindpunten en positioneer ze handmatig. Het is verstandig de teller van de sites te controleren voordat je koppelt.

**Wat gebeurt er met een connector als ik een van de gekoppelde vormen verwijder?**

De uiteinden worden losgekoppeld; de connector blijft op de dia staan als een gewone lijn met vrije start/eind. Je kunt hem verwijderen of de verbindingen opnieuw toewijzen en, indien nodig, [reroute](https://reference.aspose.com/slides/nl/net/aspose.slides/connector/reroute/).

**Worden connector‑koppelingen bewaard bij het kopiëren van een dia naar een andere presentatie?**

Over het algemeen wel, mits de doelvormen ook worden gekopieerd. Als de dia wordt ingevoegd in een ander bestand zonder de gekoppelde vormen, worden de uiteinden vrij en moet je ze opnieuw koppelen.