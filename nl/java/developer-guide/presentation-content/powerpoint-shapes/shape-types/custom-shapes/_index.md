---
title: Aanpassen van presentatievormen in Java
linktitle: Aangepaste vorm
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
- bewerkingsactie
- afgeronde hoek
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Maak en pas vormen aan in PowerPoint‑presentaties met Aspose.Slides voor Java: geometriepaden, afgeronde hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe u presentaties‑vormen kunt aanpassen in Aspose.Slides door de vormgeometrie te bewerken via bewerkingspunten en geometriepaden. Het laat zien hoe u kunt werken met [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) en [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) om bestaande vormen te wijzigen, basisbewerkingen op paden uit te voeren, punten toe te voegen of te verwijderen, en de bijgewerkte geometrie terug toe te passen op een vorm.

Het demonstreert ook hoe u aangepaste en samengestelde vormen kunt maken, vormen met afgeronde hoeken kunt bouwen, kunt bepalen of een vormgeometrie gesloten is, vormelementen kunt inspecteren, en Java AWT‑tekstuitleggen kunt omzetten naar geometriepaden.

## **Vorm wijzigen met bewerkingspunten**

In PowerPoint kunt u **Bewerkingspunten** gebruiken om een vierkant te wijzigen:

* Een hoek naar binnen of naar buiten verplaatsen.
* De kromming op een punt aanpassen.
* Nieuwe punten toevoegen.

Bewerkingspunten laten u de omtrek van een vorm aanpassen of een bestaande vorm als basis voor een nieuwe gebruiken.

## **Tips voor het bewerken van vormen**

![overview_image](custom_shape_0.png)

Bij het bewerken van PowerPoint‑vormen, houd deze concepten in gedachten:

* Een vorm (of het pad) kan gesloten of open zijn.
* Het pad van een vorm bestaat uit ankerpunten die met segmenten verbonden zijn.
* Een segment kan recht of gebogen zijn. Ankerpunten en controlehandvatten bepalen de vorm.
* Ankerpunten bestaan als hoekpunten, rechte punten of gladde punten:
  * Bij een hoekpunt kunnen aangrenzende segmenten elkaar onder een hoek ontmoeten.
  * Bij een glad punt zijn de twee controlehandvatten uitgelijnd en even ver van het ankerpunt.
  * Bij een recht punt zijn de twee controlehandvatten uitgelijnd maar kunnen ze verschillende afstanden tot het ankerpunt hebben.
* Het verplaatsen van ankerpunten of het aanpassen van hun handvatten verandert de vorm van de omtrek.

Om PowerPoint‑vormen via bewerkingspunten te bewerken, biedt **Aspose.Slides** de [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)‑klasse en de [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/)‑interface.

* Een [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)‑instantie stelt een geometriepad van het [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/)‑object voor.
* Om de [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) op te halen van een [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/)‑instantie, kunt u de methode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) gebruiken.
* Om de [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) voor een vorm in te stellen, kunt u deze methoden gebruiken: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) voor vormen met één pad en [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) voor vormen met meerdere paden.
* Om segmenten toe te voegen, kunt u de methoden onder [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) gebruiken.
* Met de methoden [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) en [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) kunt u het uiterlijk van een geometriepad instellen.
* Met de methode [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) kunt u het geometriepad van een [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) ophalen als een array van padsegmenten.
* Om extra opties voor vormgeometrie‑aanpassing te benaderen, kunt u een [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) via zijn [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) lezen en de segmenten opnieuw afspelen op een [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

## **Eenvoudige bewerkingsbewerkingen**

Gebruik de volgende methoden om een geometriepad te bewerken. Overloads die een index accepteren, voegen een segment in op die nul‑gebaseerde positie in de segment‑array van het pad.

| Bewerking | Method |
| --- | --- |
| Een rechte lijn toevoegen of invoegen. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Een kubieke Bézier‑curve met twee controlepunten en een eindpunt toevoegen of invoegen. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Een kwadratische Bézier‑curve met één controlepunt en een eindpunt toevoegen of invoegen. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Een ellipsvormige boog met de opgegeven afmetingen en hoeken in graden toevoegen. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| De huidige figuur sluiten door het eindpunt met het startpunt te verbinden. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Het startpunt van een figuur instellen. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Een segment verwijderen op een nul‑gebaseerde index. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Aangepaste punten aan een vorm toevoegen**

Dit voorbeeld voegt twee punten toe aan een rechthoekige vorm met behulp van [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) en past het bewerkte pad toe met [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). De coördinaten zijn lokaal ten opzichte van de vorm: beide nieuwe punten liggen in het midden, 100 punten van de linkerkant en 50 punten van de bovenkant. Segment‑indices 1 en 4 plaatsen ze op respectievelijk de boven‑ en onderrand, waardoor die randen naar binnen worden getrokken.

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

## **Punten van een vorm verwijderen**

Dit voorbeeld wijzigt de omtrek van een hartvorm door het segment op nul‑gebaseerde index 2 te verwijderen met [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-). Het toepassen van het aangepaste pad met [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) werkt de contour van de vorm bij.

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

## **Een aangepaste vorm maken**

Dit voorbeeld bouwt een vijfpuntige ster met [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/). Afwisselend buiten- en binnenstraal van 100 en 50 punten definiëren de punten en inkepingen; een stap van 72 graden verdeelt de vijf punten gelijkmatig. Het pad wordt gesloten met [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) en toegepast op een rechthoekige vorm met [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), waardoor de oorspronkelijke omtrek wordt vervangen.

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

## **Een samengestelde aangepaste vorm maken**

Dit voorbeeld definieert twee gesloten [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)‑objecten voor respectievelijk het boven‑ en onderste derde deel van een vorm. Beide paden toepassen met [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) creëert één samengestelde vorm met een opening door het middelste derde deel.

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

## **Een aangepaste vorm met afgeronde hoeken maken**

Dit voorbeeld combineert rechte segmenten met [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) om een vorm met naar binnen gebogen hoeken te creëren. Elke hoekgrootte bepaalt de breedte en hoogte van de boog in punten, en de -90‑graden sweep tekent een tegen de klok in gaande kwart‑ellipse. Het voltooide pad wordt toegepast met [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), en de presentatie wordt opgeslagen in PPTX‑formaat.

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

## **Nagaan of een vormgeometrie gesloten is**

De volgende helper controleert of elke niet‑lege geometriepad eindigt met een sluitsegment. Hij leest [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) en vergelijkt het laatste segment‑[IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) met [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/). Hij geeft *false* terug wanneer er geen niet‑leeg pad bestaat. Deze controle kijkt naar het laatste commando van elk pad; hij inspecteert niet elk sub‑figure binnen een pad. Het voorbeeld print `true` voor een rechthoek.

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

## **Vormelementen extraheren en inspecteren**

Gebruik [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) om een bestaande vorm te inspecteren als elementen die padpunten en punt‑typen bevatten. Cast elk geretourneerd [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) naar [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) om de punt‑ en type‑arrays op te halen via [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) en [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) methoden. Deze representatie is nuttig voor contouranalyse of voor het doorgeven van geometrie aan aangepaste tekengereedschappen.

Het voorbeeld opent *input.pptx*, vindt de eerste geometrievorm direct op de eerste dia, en print zijn padsegmenten. Gebruik een presentatie met een vorm die zowel rechte als gebogen segmenten bevat om beide soorten uitvoer te zien. Het doorzoekt geen groepen.

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
                int pointType = types[i] & 0x07; // Houd het segmenttype, exclusief vlaggen.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Verbruik beide controlepunten en het eindpunt.
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

De arrays corresponderen op index: `points[i]` is een punt en `types[i]` beschrijft de rol. Type `0` start een figure, en type `1` tekent een lijn van het vorige punt naar het huidige punt. Een kubieke Bézier‑segment start bij het vorige eindpunt en gebruikt drie opeenvolgende type‑`3`‑items: twee controlepunten gevolgd door het nieuwe eindpunt. De lus consumeert deze drie items samen en controleert het eindpunt op sluiting.

Punt‑typen bevatten ook vlaggen. Maskeer met `0x07` om het segmenttype te identificeren, en test `0x80` apart om een gesloten subpad te detecteren. Bijvoorbeeld, `129` (`0x81`) betekent een lijneindpunt dat een subpad sluit, en `131` (`0x83`) betekent een Bézier‑eindpunt dat een subpad sluit. Java slaat deze vlaggen op in ondertekende bytes; maskeren behoudt de bedoelde bitwaarden. Alleen vergelijken met `1` of `3` zou deze gevallen missen. Andere vlaggen, zoals dash (`0x10`) en marker (`0x20`), wijzigen het basissegmenttype niet.

**Coördinaten en transformaties.** Punten worden gemeten in points (1/72 inch), waarbij X naar rechts toeneemt en Y naar beneden. Voor een niet‑gegroepeerde vorm omvatten de geëxtraheerde coördinaten al de positie die wordt geretourneerd door [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) en [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) en weerspiegelen ze de huidige breedte en hoogte. Een ongeroteerde rechthoek op `(100, 200)` met afmeting `120 × 80` heeft contourgrenzen `(100, 200)`–`(220, 280)`. Voeg de positie van de vorm niet nogmaals toe. Trek X en Y af om coördinaten te verkrijgen relatief ten opzichte van het ongeroteerde frame.

De geëxtraheerde punten houden geen rekening met de rotatie van de vorm, geretourneerd door [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--), of horizontale en verticale spiegels. Om de weergegeven contour te reproduceren, past u die transformaties toe rond het middelpunt van de vorm. Voor gegroepeerde vormen moet ook de coördinaten‑mapping en transformaties van de groep in aanmerking worden genomen; ga er niet van uit dat de geëxtraheerde punten de definitieve weergave‑dia‑coördinaten zijn, en vermijd een dubbellevertaling of -schaal als dit al in het kinderframe is verwerkt.

**Inspectie versus bewerking.** De geëxtraheerde arrays beschrijven de contour; wijzigen hiervan werkt de oorspronkelijke vorm niet bij. Kies deze aanpak wanneer uw analyse‑ of tekencode punt‑/type‑arrays nodig heeft. Gebruik [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) wanneer u geometrie‑commando’s in het lokale coördinatensysteem van de vorm nodig heeft of de geometrie wilt bewerken. Pas bewerkte paden toe via [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) of [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **Een Java AWT‑vorm converteren naar GeometryPath**

Dit voorbeeld combineert een rechthoekige omtrek met tekst die is omgezet naar geometrie. De [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-)‑methode van de omtrek schakelt de vulling uit. Een [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) creëert de tekstomtrek in een [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). De [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) levert verplaatsings‑, lijn‑, kwadratische, kubieke en sluit‑segmenten, die het voorbeeld opnieuw afspeelt op een [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

De tekst gebruikt een Arial‑lettertype van 40 points. De omtrek wordt horizontaal 20 points verschoven en verticaal zodanig gepositioneerd dat de visuele bovenkant 10 points onder de bovenrand van de vorm ligt. Het tekstpad wordt gevuld, terwijl de oorspronkelijke rechthoek een omtrek blijft. Beide paden toepassen met [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) levert één vorm op die zowel de rechthoek als de tekst bevat.

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

    // Geometriepad van de vorm ophalen
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Nieuw grafisch pad maken met tekst
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

    // Grafisch pad omzetten naar geometriepad
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

    // Combinatie van nieuw geometriepad en origineel geometriepad instellen op de vorm
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Wat gebeurt er met de vulling en omtrek nadat de geometrie is vervangen?**

De stijl blijft bij de vorm; alleen de contour verandert. De vulling en omtrek worden automatisch toegepast op de nieuwe geometrie.

**Hoe roteer ik een aangepaste vorm correct samen met de geometrie?**

Gebruik de [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-)‑methode van de vorm; de geometrie roteert mee omdat deze aan het eigen coördinatensysteem van de vorm is gekoppeld.

**Kan ik een aangepaste vorm naar een afbeelding converteren om het resultaat vast te zetten?**

Ja. Exporteer het gewenste [dia](/slides/nl/java/convert-powerpoint-to-png/)‑gebied of de [vorm](/slides/nl/java/create-shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt later werk met complexe geometrieën.