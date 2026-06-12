---
title: Connectoren beheren in presentaties met JavaScript
linktitle: Connector
type: docs
weight: 10
url: /nl/nodejs-java/connector/
keywords:
- connector
- type connector
- connectorpunt
- connectorlijn
- connectorhoek
- vormen verbinden
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Geef JavaScript-apps de mogelijkheid om lijnen te tekenen, verbinden en automatisch te routeren in PowerPoint-dia's - krijg volledige controle over rechte, elleboog- en gebogen connectoren."
---
## **Inleiding**

Een PowerPoint‑connector is een speciale lijn die twee vormen met elkaar verbindt of koppelt en aan de vormen blijft bevestigd, zelfs wanneer ze worden verplaatst of opnieuw gepositioneerd op een bepaalde dia. 

Connectoren worden doorgaans verbonden met *verbindingstippen* (groene stippen), die standaard op alle vormen aanwezig zijn. Verbindingstippen verschijnen wanneer de cursor er dichtbij komt.

*Aanpassingpunten* (oranje stippen), die alleen op bepaalde connectoren bestaan, worden gebruikt om de posities en vormen van connectoren aan te passen.

## **Soorten connectoren**

In PowerPoint kun je rechte, elleboog‑ (hoekige) en gebogen connectoren gebruiken. 

Aspose.Slides levert deze connectoren:

| Connector | Afbeelding | Aantal aanpassingspunten |
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

## **Vormen verbinden met connectoren**

1. Maak een instantie van de [Presentatie](https://apireference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.  
1. Haal een verwijzing naar een dia op via de index.  
1. Voeg twee [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape) toe aan de dia met de `addAutoShape`‑methode die beschikbaar wordt gesteld door het `Shapes`‑object.  
1. Voeg een connector toe met de `addConnector`‑methode die beschikbaar wordt gesteld door het `Shapes`‑object, door het type connector te definiëren.  
1. Verbind de vormen met de connector.  
1. Roep de `reroute`‑methode aan om het kortste verbindingspad toe te passen.  
1. Sla de presentatie op.  

Deze JavaScript‑code laat zien hoe je een connector (een gebogen connector) tussen twee vormen (een ellips en een rechthoek) kunt toevoegen:

```javascript
// Instantieert een presentatieklasse die het PPTX bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de shapes collectie voor een specifieke dia
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Voegt een Ellipse autoshape toe
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Voegt een Rectangle autoshape toe
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Voegt een connector shape toe aan de slide shape collectie
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Verbindt de shapes met de connector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Roept reroute aan die het automatische kortste pad tussen shapes instelt
    connector.reroute();
    // Slaat de presentatie op
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="OPMERKING"  color="warning"   %}} 

De `Connector.reroute`‑methode herrouteert een connector en dwingt deze het kortst mogelijke pad tussen vormen te volgen. Om dit te bereiken kan de methode de punten `setStartShapeConnectionSiteIndex` en `setEndShapeConnectionSiteIndex` aanpassen. 

{{% /alert %}} 

## **Verbindingstip specificeren**

Als je een connector twee vormen wilt laten verbinden via specifieke punten op de vormen, moet je de gewenste verbindingstippen op deze manier aangeven:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.  
1. Haal een verwijzing naar een dia op via de index.  
1. Voeg twee [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape) toe aan de dia met de `addAutoShape`‑methode die beschikbaar wordt gesteld door het `Shapes`‑object.  
1. Voeg een connector toe met de `addConnector`‑methode die beschikbaar wordt gesteld door het `Shapes`‑object, door het type connector te definiëren.  
1. Verbind de vormen met de connector.  
1. Stel de gewenste verbindingstippen op de vormen in.  
1. Sla de presentatie op.  

Deze JavaScript‑code toont een bewerking waarbij een gewenste verbindingstip wordt gespecificeerd:

```javascript
// Instantieert een presentatieklasse die een PPTX-bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de shapes-collectie voor een specifieke dia
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Voeg een Ellipse-autoshape toe
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Voeg een Rectangle-autoshape toe
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Voegt een connector-shape toe aan de shape-collectie van de dia
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Verbindt de shapes met de connector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Stelt de gewenste index van het verbindingstip in op de Ellipse-shape
    var wantedIndex = 6;
    // Controleert of de gewenste index kleiner is dan het maximale aantal site-indexen
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // Stelt het gewenste verbindingstip in op de Ellipse-autoshape
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // Slaat de presentatie op
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Connectorpunt aanpassen**

Je kunt een bestaande connector via zijn aanpassingpunten aanpassen. Alleen connectoren met aanpassingpunten kunnen op deze manier worden gewijzigd. Zie de tabel onder **[Soorten connectoren.](/slides/nl/nodejs-java/connector/#types-of-connectors)**

### **Eenvoudig geval**

Beschouw een geval waarbij een connector tussen twee vormen (A en B) door een derde vorm (C) loopt:

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

Om de derde vorm te vermijden of te omzeilen, kunnen we de connector aanpassen door de verticale lijn naar links te verplaatsen:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Complexe gevallen** 

Om meer ingewikkelde aanpassingen uit te voeren, moet je rekening houden met de volgende zaken:

* Het verstelbare punt van een connector is sterk gekoppeld aan een formule die zijn positie berekent en bepaalt. Wijzigingen in de locatie van het punt kunnen daarom de vorm van de connector veranderen.  
* De aanpassingpunten van een connector worden in een strikte volgorde in een array gedefinieerd. De aanpassingpunten worden genummerd vanaf het startpunt van de connector tot het eindpunt.  
* De waarden van aanpassingpunten geven het percentage van de breedte/hoogte van de connectorvorm weer.  
  * De vorm wordt begrensd door de start‑ en eindpunten van de connector vermenigvuldigd met 1000.  
  * Het eerste punt, tweede punt en derde punt definiëren respectievelijk het percentage van de breedte, het percentage van de hoogte en opnieuw het percentage van de breedte.  
* Voor berekeningen die de coördinaten van de aanpassingpunten van een connector bepalen, moet je rekening houden met de rotatie van de connector en de spiegeling. **Opmerking** dat de rotatiehoek voor alle connectoren weergegeven onder **[Soorten connectoren](/slides/nl/nodejs-java/connector/#types-of-connectors)** 0 is.

#### **Geval 1**

Beschouw een geval waarbij twee tekstkaderobjecten via een connector met elkaar verbonden zijn:

![connector-shape-complex](connector-shape-complex.png)

```javascript
// Instantieert een presentatieklasse die een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Haalt de eerste dia in de presentatie op
    var sld = pres.getSlides().get_Item(0);
    // Voegt vormen toe die via een connector aan elkaar worden gekoppeld
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Voegt een connector toe
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // Bepaalt de richting van de connector
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // Bepaalt de kleur van de connector
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Bepaalt de dikte van de connectorlijn
    connector.getLineFormat().setWidth(3);
    // Verbindt de vormen met de connector
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // Haalt de aanpassingpunten op voor de connector
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Aanpassing**

We kunnen de waarden van de aanpassingpunten van de connector wijzigen door respectievelijk het overeenkomstige breedte‑ en hoogtepuntpercentage met 20 % en 200 % te verhogen:

```javascript
// Wijzigt de waarden van de aanpassingpunten
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Het resultaat:

![connector-adjusted-1](connector-adjusted-1.png)

Om een model te definiëren waarmee we de coördinaten en de vorm van individuele delen van de connector kunnen bepalen, laten we een vorm maken die overeenkomt met het horizontale component van de connector op het punt `connector.getAdjustments().get_Item(0)`:

```javascript
// Teken het verticale component van de connector
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```

Het resultaat:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Geval 2**

In **Geval 1** hebben we een eenvoudige connector‑aanpassingsbewerking gedemonstreerd met basisprincipes. In normale situaties moet je rekening houden met de rotatie van de connector en de weergave (die worden ingesteld door `connector.getRotation()`, `connector.getFrame().getFlipH()` en `connector.getFrame().getFlipV()`). We zullen nu het proces demonstreren.

Eerst voegen we een nieuw tekstkaderobject (**To 1**) toe aan de dia (voor verbindingsdoeleinden) en maken we een nieuwe (groene) connector die dit verbindt met de objecten die we al hebben aangemaakt.

```javascript
// Creëert een nieuw bindobject
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Creëert een nieuwe connector
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// Verbindt objecten met de nieuw aangemaakte connector
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Haalt de aanpassingpunten van de connector op
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Wijzigt de waarden van de aanpassingpunten
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Het resultaat:

![connector-adjusted-3](connector-adjusted-3.png)

Ten tweede maken we een vorm die overeenkomt met het horizontale component van de connector dat door het nieuwe aanpassingspunt van de connector `connector.getAdjustments().get_Item(0)` loopt. We gebruiken de waarden uit de connector‑data voor `connector.getRotation()`, `connector.getFrame().getFlipH()` en `connector.getFrame().getFlipV()` en passen de bekende coördinatenconversie‑formule voor rotatie rond een gegeven punt x0 toe:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In ons geval is de hoeksrotatie van het object 90 graden en wordt de connector verticaal weergegeven, dus dit is de bijbehorende code:

```javascript
// Slaat de coördinaten van de connector op
x = connector.getX();
y = connector.getY();
// Corrigeert de connector‑coördinaten indien nodig
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// Neemt de waarde van het aanpassingpunt als coördinaat
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// Converteert de coördinaten aangezien Sin(90)=1 en Cos(90)=0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// Bepaalt de breedte van het horizontale component met de waarde van het tweede aanpassingpunt
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Het resultaat:

![connector-adjusted-4](connector-adjusted-4.png)

We hebben berekeningen getoond die zowel eenvoudige aanpassingen als ingewikkelde aanpassingpunten (aanpassingpunten met rotatiehoeken) omvatten. Met de verworven kennis kun je je eigen model ontwikkelen (of code schrijven) om een `GraphicsPath`‑object te verkrijgen of zelfs de aanpassingpuntwaarden van een connector in te stellen op basis van specifieke dia‑coördinaten.

## **Hoek van connectorlijnen bepalen**

1. Maak een instantie van de klasse.  
1. Haal een verwijzing naar een dia op via de index.  
1. Toegang tot de connectorlijnvorm.  
1. Gebruik de breedte, hoogte, frame‑hoogte en frame‑breedte van de vorm om de hoek te berekenen.  

Deze JavaScript‑code toont een bewerking waarin we de hoek van een connectorlijnvorm berekenden:

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

**Hoe kan ik zien of een connector "aan een specifieke vorm kan worden geplakt"?**

Controleer of de vorm [verbindingstippen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getconnectionsitecount/) exposeert. Als er geen zijn of het aantal nul is, is plakken niet beschikbaar; gebruik in dat geval vrije eindpunten en positioneer ze handmatig. Het is verstandig het aantal verbindingstippen te controleren voordat je verbindt.

**Wat gebeurt er met een connector als ik een van de verbonden vormen verwijder?**

De uiteinden worden losgekoppeld; de connector blijft op de dia als een gewone lijn met vrije start/eind. Je kunt hem verwijderen of de verbindingen opnieuw toewijzen en, indien nodig, [herrouteren](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/connector/reroute/).

**Worden connectorbindingen behouden bij het kopiëren van een dia naar een andere presentatie?**

Over het algemeen ja, mits de doelvormen ook worden gekopieerd. Als de dia in een ander bestand wordt ingevoegd zonder de verbonden vormen, worden de uiteinden vrij en moet je ze opnieuw koppelen.