---
title: Aangepaste presentatievormen in Java
linktitle: Aangepaste Vorm
type: docs
weight: 20
url: /nl/java/custom-shape/
keywords:
- aangepaste vorm
- vorm toevoegen
- vorm maken
- vorm wijzigen
- vormgeometrie
- geometriepad
- padpunten
- bewerkingspunten
- punt toevoegen
- punt verwijderen
- bewerkingsoperatie
- afgeronde hoek
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Maak en pas vormen aan in PowerPoint-presentaties met Aspose.Slides voor Java: geometriepaden, afgeronde hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe je presentatie‑vormen in Aspose.Slides kunt aanpassen door de vormgeometrie te bewerken via bewerkingspunten en geometrische paden. Het laat zien hoe je werkt met [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) en [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) om bestaande vormen te wijzigen, basale padbewerkingsbewerkingen uit te voeren, punten toe te voegen of te verwijderen, en de bijgewerkte geometrie terug op een vorm toe te passen.

Het laat ook zien hoe je aangepaste en samengestelde vormen maakt, vormen met afgeronde hoeken bouwt, bepaalt of een vormgeometrie gesloten is, vorm‑elementen inspecteert en Java AWT‑tekstopgaven omzet naar geometrische paden.

## **Vorm wijzigen met bewerkingspunten**

In PowerPoint kun je **Edit Points** gebruiken om een vierkant te wijzigen:

* Een hoek naar binnen of naar buiten verplaatsen.
* De kromming op een punt aanpassen.
* Nieuwe punten toevoegen.

Bewerkingspunten laten je de omtrek van een vorm aanpassen of een bestaande vorm als basis voor een nieuwe gebruiken.

## **Tips voor vormbewerking**

![overview_image](custom_shape_0.png)

Houd bij het bewerken van PowerPoint‑vormen de volgende concepten in gedachten:

* Een vorm (of zijn pad) kan gesloten of open zijn.
* Een vorm‑pad bestaat uit ankerpunten die door segmenten met elkaar verbonden zijn.
* Een segment kan recht of gekromd zijn. Ankerpunten en controle‑handvatten bepalen de vorm.
* Ankerpunten bestaan als hoekpunten, rechte punten of vloeiende punten:
  * Bij een hoekpunt kunnen aangrenzende segmenten onder een hoek samenkomen.
  * Bij een vloeiend punt zijn de twee controle‑handvatten op één lijn en even ver van het ankerpunt.
  * Bij een recht punt zijn de twee controle‑handvatten op één lijn maar kunnen ze verschillende afstanden tot het ankerpunt hebben.
* Het verplaatsen van ankerpunten of het aanpassen van hun handvatten wijzigt de omtrek van de vorm.

Om PowerPoint‑vormen via bewerkingspunten te wijzigen, biedt **Aspose.Slides** de [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)‑klasse en de [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/)‑interface.

* Een [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)‑instantie vertegenwoordigt een geometrisch pad van het [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/)‑object.
* Om de [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) op te halen uit een [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/)-instantie, kun je de methode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) gebruiken.
* Om de [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) voor een vorm in te stellen, kun je deze methoden gebruiken: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) voor vormen met één pad en [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) voor vormen met meerdere paden.
* Om segmenten toe te voegen, kun je de methoden onder [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) gebruiken.
* Met de methoden [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) en [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) kun je het uiterlijk van een geometrisch pad instellen.
* Met de methode [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) kun je de geometrische pad van een [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) ophalen als een array van padsegmenten.
* Om extra opties voor vormgeometrie‑aanpassing te benaderen, kun je een [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) uitlezen via zijn [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) en de segmenten opnieuw afspelen op een [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

## **Eenvoudige bewerkingsbewerkingen**

Gebruik de volgende methoden om een geometrisch pad te bewerken. Overbelasting die een index accepteert, voegt een segment in op die nul‑gebaseerde positie in de segmentarray van het pad.

| Operatie | Methode |
| --- | --- |
| Een rechte lijn toevoegen of invoegen. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Een kubieke Bézier‑curve met twee controlepunten en een eindpunt toevoegen of invoegen. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Een kwadratische Bézier‑curve met één controlepunt en een eindpunt toevoegen of invoegen. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Een ellipsvormige boog toevoegen met de opgegeven afmetingen en hoeken in graden. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Het huidige figuur sluiten door het eindpunt met het startpunt te verbinden. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Het startpunt van een figuur instellen. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Een segment verwijderen op een nul‑gebaseerde index. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Aangepaste punten aan een vorm toevoegen**

Dit voorbeeld voegt twee punten toe aan een rechthoekige vorm met [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) en past het bewerkte pad toe via [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). De coördinaten zijn lokaal ten opzichte van de vorm: beide nieuwe punten liggen in het midden, 100 points van links en 50 points van boven. Segmentindices 1 en 4 plaatsen ze respectievelijk op de boven‑ en onderrand, waardoor die randen naar binnen worden getrokken.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Punten uit een vorm verwijderen**

Dit voorbeeld wijzigt de omtrek van een hartvorm door het segment op nul‑gebaseerde index 2 te verwijderen met [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-). Het aangepaste pad toepassen met [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) werkt de contour van de vorm bij.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Aangepaste vorm maken**

Dit voorbeeld bouwt een vijfpuntige ster met [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/). Afwisselend uiterlijke en innere stralen van 100 en 50 points bepalen de punten en inkepingen; een stap van 72 graden verdeelt de vijf punten gelijkmatig. Het pad wordt gesloten met [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) en toegepast op een rechthoekige vorm via [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), waardoor de oorspronkelijke omtrek wordt vervangen.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Samengestelde aangepaste vorm maken**

Dit voorbeeld definieert twee gesloten [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)‑objecten voor respectievelijk het boven‑ en onderste derde deel van een vorm. Beide paden toepassen met [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) creëert één samengestelde vorm met een gat over het middelste derde deel.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Aangepaste vorm met afgeronde hoeken maken**

Dit voorbeeld combineert rechte segmenten met [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) om een vorm met naar binnen gekromde hoeken te maken. Elke hoekgrootte stelt de breedte en hoogte van de boog in points, en de -90‑graden sweep tekent een tegen‑de‑klok kwart‑ellips. Het voltooide pad wordt toegepast met [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), en de presentatie wordt opgeslagen in PPTX‑formaat.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controleren of een vormgeometrie gesloten is**

De volgende helper controleert of elke niet‑lege geometrische pad eindigt met een sluitsegment. Hij leest [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) en vergelijkt het laatste segment’s [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) met [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/). Hij retourneert false wanneer er geen niet‑lege paden bestaan. Deze controle kijkt alleen naar het laatste commando van elk pad; hij inspecteert niet elk sub‑figuur binnen een pad. Het voorbeeld print `true` voor een rechthoek.

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **Inspectie van geometrische pad‑commando’s**

Download [contour.pptx](contour.pptx) en plaats het in de werkmap van de applicatie. De eerste vorm op de eerste dia heeft een rechte bovenrand, een kubieke Bézier‑curve en een rechte sluitrand. Gebruik [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) om de paden van de vorm te lezen en [getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) om de segmenten van elk pad in tekenvolgorde uit te lezen. Voor elk segment identificeert [getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) het commando en bepaalt hoe de waarden van [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--) geïnterpreteerd moeten worden.

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

De vorm bevindt zich op (200, 100) points op de dia. De gerapporteerde coördinaten zijn lokaal ten opzichte van de vorm, met (0, 0) in de linkerbovenhoek, x neemt toe naar rechts, en y neemt toe naar beneden. Het sluitsegment keert terug naar het startpunt zonder extra coördinaten.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Extractie en inspectie van vorm‑elementen**

Gebruik [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) om een bestaande vorm te inspecteren als elementen die padpunten en punt‑typen bevatten. Cast elk geretourneerd [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) naar [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) om de punt‑ en type‑arrays op te halen via [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) en [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) methoden. Deze representatie is handig voor contouranalyse of voor het doorgeven van geometrie aan aangepaste teken‑tools.

Het voorbeeld opent input.pptx, vindt de eerste geometrische vorm direct op de eerste dia, en print de padsegmenten. Gebruik een presentatie die een vorm met rechte en kromme segmenten bevat om beide soorten output te zien. Het zoekt niet binnen groepen.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Behoud het segmenttype, exclusief vlaggen.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

De arrays corresponderen per index: `points[i]` is een punt en `types[i]` beschrijft zijn rol. Type `0` start een figuur, en type `1` tekent een lijn van het vorige punt naar het huidige punt. Een kubieke Bézier‑segment start bij het vorige eindpunt en gebruikt drie opeenvolgende type‑`3`‑items: twee controlepunten gevolgd door het nieuwe eindpunt. De lus consumeert deze drie items samen en controleert het eindpunt op sluiting.

Punt‑typen bevatten ook vlaggen. Maskeer met `0x07` om het segmenttype te identificeren, en test `0x80` apart om een gesloten subpad te detecteren. Bijvoorbeeld, `129` (`0x81`) betekent een lijn‑eindpunt dat een subpad sluit, en `131` (`0x83`) betekent een Bézier‑eindpunt dat een subpad sluit. Java slaat deze vlaggen op in signed bytes; maskeren behoudt de bedoelde bitwaarden. Alleen de ruwe waarde vergelijken met `1` of `3` zou deze gevallen missen. Andere vlaggen, zoals dash (`0x10`) en marker (`0x20`), wijzigen het basissegmenttype niet.

**Coördinaten en transformaties.** Punten worden gemeten in points (1/72 inch), met X die toeneemt naar rechts en Y die toeneemt naar beneden. Voor een niet‑gegroepeerde vorm omvatten de geëxtraheerde coördinaten al de positie die wordt geretourneerd door [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) en [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) en weerspiegelen ze de huidige breedte en hoogte. Bijvoorbeeld, een niet‑geroteerde rechthoek op `(100, 200)` met grootte `120 × 80` heeft contourgrenzen `(100, 200)`–`(220, 280)`. Voeg de positie van de vorm niet opnieuw toe. Trek X en Y af om coördinaten te krijgen relatief ten opzichte van het ongeroteerde kader.

De geëxtraheerde punten houden geen rekening met de rotatie van de vorm, geretourneerd door [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--), of horizontale en verticale spiegels. Om de weergegeven contour te reproduceren, pas die transformaties toe rond het middelpunt van de vorm. Voor gegroepeerde vormen moet ook de groeps‑coördinatenmapping en transformaties in aanmerking worden genomen; ga er niet van uit dat de geëxtraheerde punten de uiteindelijke getekende dia‑coördinaten zijn of dat je een translatie of schaal twee keer toepast als dit al in het kindkader is verwerkt.

**Inspectie versus bewerking.** Geëxtraheerde arrays beschrijven de contour; wijzigen ervan past de oorspronkelijke vorm niet aan. Kies deze aanpak wanneer je analyse‑ of teken‑code punt‑/type‑arrays nodig heeft. Gebruik [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) wanneer je geometri‑commando’s in het lokale coördinatensysteem van de vorm nodig hebt of de geometrie wilt bewerken. Pas bewerkte paden toe via [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) of [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **Een Java AWT‑vorm omzetten naar GeometryPath**

Dit voorbeeld combineert een rechthoekige omtrek met tekst die wordt omgezet naar geometrie. De [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-)‑methode van de omtrek schakelt de vulling uit. Een [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) creëert de tekstomtrek in een [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Zijn [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) levert bewegingen, lijnen, kwadratische, kubieke en sluit‑segmenten, die het voorbeeld opnieuw afspeelt op een [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

De tekst gebruikt een 40‑point Arial‑lettertype. De omtrek wordt 20 points horizontaal verschoven en verticaal geplaatst zodat de visuele bovenkant 10 points onder de bovenrand van de vorm ligt. Het tekstpad wordt gevuld, terwijl de oorspronkelijke rechthoek een omtrek blijft. Beide paden toepassen met [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) produceert één vorm die de rechthoek en de tekst bevat.

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // Nieuwe vorm maken
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Geometrisch pad van de vorm ophalen
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Nieuwe graphics‑pad met tekst maken
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // Graphics‑pad omzetten naar geometrisch pad
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // Combinatie van nieuw geometrisch pad en origineel geometrisch pad instellen op de vorm
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Wat gebeurt er met de vulling en omtrek na het vervangen van de geometrie?**

De stijl blijft behouden bij de vorm; alleen de contour verandert. De vulling en omtrek worden automatisch op de nieuwe geometrie toegepast.

**Hoe roteer ik een aangepaste vorm correct samen met zijn geometrie?**

Gebruik de [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-)‑methode van de vorm; de geometrie roteert mee omdat deze gekoppeld is aan het eigen coördinatensysteem van de vorm.

**Kan ik een aangepaste vorm omzetten naar een afbeelding om het resultaat te “vergrendelen”?**

Ja. Exporteer het gewenste [slide](/slides/nl/java/convert-powerpoint-to-png/)‑gebied of de [shape](/slides/nl/java/create-shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt verder werken met complexe geometrieën.