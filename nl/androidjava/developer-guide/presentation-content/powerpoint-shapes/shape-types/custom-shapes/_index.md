---
title: Aangepaste presentatieshape's op Android
linktitle: Aangepaste shape
type: docs
weight: 20
url: /nl/androidjava/custom-shape/
keywords:
- aangepaste shape
- shape toevoegen
- shape maken
- shape wijzigen
- shape geometrie
- geometriepad
- padpunten
- bewerkpunten
- punt toevoegen
- punt verwijderen
- bewerkingsoperatie
- gebogen hoek
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak en pas shapes aan in PowerPoint-presentaties met Aspose.Slides voor Android via Java: geometriepaden, gebogen hoeken, samengestelde shapes."
---
## **Overzicht**

Dit artikel legt uit hoe je presentatieshape’s in Aspose.Slides kunt aanpassen door de vormgeometrie te bewerken via bewerkpunten en geometriepaden. Het laat zien hoe je met [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) en [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) kunt werken om bestaande shape’s te wijzigen, basisbewerkingen op paden uit te voeren, punten toe te voegen of te verwijderen, en de bijgewerkte geometrie terug toe te passen op een shape.

Het demonstreert ook hoe je aangepaste en samengestelde shape’s maakt, shape’s met gebogen hoeken bouwt, bepaalt of een shape‑geometrie gesloten is, en shape‑elementen inspecteert met Android‑puntarrays.

## **Een shape wijzigen met bewerkpunten**

In PowerPoint kun je **Bewerkpunten** gebruiken om een vierkant te wijzigen:

* Een hoek naar binnen of naar buiten verplaatsen.
* De kromming op een punt aanpassen.
* Nieuwe punten toevoegen.

Door punten te bewerken kun je de omtrek van een shape aanpassen of een bestaande shape als basis voor een nieuwe gebruiken.

## **Tips voor het bewerken van shape’s**

![overview_image](custom_shape_0.png)

Wanneer je PowerPoint‑shape’s bewerkt, houd deze concepten in gedachten:

* Een shape (of zijn pad) kan gesloten of open zijn.
* Het pad van een shape bestaat uit ankerpunten die met segmenten verbonden zijn.
* Een segment kan recht of gebogen zijn. Ankerpunten en controlehandvatten bepalen de vorm.
* Ankerpunten bestaan als hoekpunten, rechte punten of vloeiende punten:
  * Bij een hoekpunt kunnen aangrenzende segmenten onder een hoek samenkomen.
  * Bij een vloeiend punt zijn de twee controlehandvatten uitgelijnd en even ver van het ankerpunt.
  * Bij een recht punt zijn de twee controlehandvatten uitgelijnd, maar kunnen ze verschillende afstanden tot het ankerpunt hebben.
* Het verplaatsen van ankerpunten of het aanpassen van hun handvatten verandert de omtrek van de shape.

Om PowerPoint‑shape’s te bewerken via bewerkpunten, biedt **Aspose.Slides** de klasse [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) en de interface [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).

* Een [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)‑instantie vertegenwoordigt een geometriepad van het object [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/).
* Om het [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) van de [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/)‑instantie op te halen, kun je de methode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) gebruiken.
* Om het [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) voor een shape in te stellen, kun je deze methoden gebruiken: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) voor shape’s met één pad en [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) voor shape’s met meerdere paden.
* Om segmenten toe te voegen, kun je de methoden onder [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) gebruiken.
* Met de methoden [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) en [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) kun je het uiterlijk van een geometriepad instellen.
* Met de methode [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) kun je het geometriepad van een [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) ophalen als een array van padsegmenten.

## **Eenvoudige bewerkingsbewerkingen**

Gebruik de volgende methoden om een geometriepad te bewerken. Overloads die een index accepteren, voegen een segment in op die nul‑gebaseerde positie in de segmentarray van het pad.

| Bewerking | Methode |
| --- | --- |
| Een rechte lijn toevoegen of invoegen. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Een kubieke Bézier‑curve met twee controlepunten en een eindpunt toevoegen of invoegen. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Een kwadratische Bézier‑curve met één controlepunt en een eindpunt toevoegen of invoegen. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Een elliptische boog met de opgegeven afmetingen en hoeken in graden toevoegen. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| De huidige figuur sluiten door het eindpunt met het startpunt te verbinden. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Het startpunt van een figuur instellen. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Een segment op een nul‑gebaseerde index verwijderen. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Aangepaste punten aan een shape toevoegen**

Dit voorbeeld voegt twee punten toe aan een rechthoekige shape met behulp van [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) en past het bewerkte pad toe met [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). De coördinaten zijn lokaal ten opzichte van de shape: beide nieuwe punten staan in het midden, 100 punten vanaf de linkerkant en 50 punten vanaf de bovenkant. Segmentindices 1 en 4 plaatsen ze op respectievelijk de boven- en onderkant, waardoor die randen naar binnen worden getrokken.

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

## **Punten van een shape verwijderen**

Dit voorbeeld wijzigt de omtrek van een hartvorm door het segment op nul‑gebaseerde index 2 te verwijderen met [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-). Het toepassen van het aangepaste pad met [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) werkt de contour van de shape bij.

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

## **Een aangepaste shape maken**

Dit voorbeeld bouwt een vijfpuntige ster met [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). Afwisselend buiten- en binnenstralen van respectievelijk 100 en 50 punten definiëren de toppen en inkepingen; een stap van 72 graad verdeelt de vijf toppen gelijkmatig. Het pad wordt gesloten met [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) en toegepast op een rechthoekige shape met [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), waardoor de omtrek wordt vervangen.

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
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

## **Een samengestelde aangepaste shape maken**

Dit voorbeeld definieert twee gesloten [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)‑objecten voor respectievelijk het boven‑ en onderste derde deel van een shape. Het toepassen van beide paden met [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) creëert één samengestelde shape met een opening in het middelste derde deel.

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

## **Een aangepaste shape met gebogen hoeken maken**

Dit voorbeeld combineert rechte segmenten met [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) om een shape te creëren met naar binnen gebogen hoeken. Elke hoekgrootte bepaalt de breedte en hoogte van de boog in punten, en de -90‑graads sweep tekent een tegen‑klokwijde kwart‑ellipse. Het voltooide pad wordt toegepast met [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), en de presentatie wordt opgeslagen in PPTX‑formaat.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

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

## **Controleren of een shape‑geometrie gesloten is**

De volgende helper controleert of elk niet‑lege geometriepad eindigt met een sluitend segment. Het leest [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) en vergelijkt het laatste segment‑[IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) met [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). Het geeft false terug wanneer er geen niet‑lege paden zijn. Deze controle kijkt alleen naar het laatste commando van elk pad; het inspecteert niet elk sub‑figure binnen een pad. Het voorbeeld print `true` voor een rechthoek.

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

## **Geometriepad‑commando’s inspecteren**

Download [contour.pptx](contour.pptx) en vervang de voorbeeld‑bestandsnaam door het pad op het apparaat. De eerste shape op de eerste dia heeft een rechte bovenrand, een kubieke Bézier‑curve en een rechte sluitende rand. Gebruik [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) om de paden van de shape te lezen en [getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) om elk pad‑segment in tekenvolgorde te lezen. Voor elk segment identificeert [getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) het commando en bepaalt hoe de waarden van [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--) geïnterpreteerd moeten worden.

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

De shape staat op (200, 100) punten op de dia. De gerapporteerde coördinaten zijn lokaal ten opzichte van de shape, met (0, 0) in de linkerbovenhoek, x groeit naar rechts en y groeit omlaag. Het sluitende segment keert terug naar het startpunt zonder extra coördinaten.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint‑shape met een rechte bovenkant, een gebogen rand van rechts‑boven naar links‑onder, en een rechte linkerkant](contour.png)

## **Shape‑elementen extraheren en inspecteren**

Gebruik [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) om een bestaande shape te inspecteren als elementen die padpunten en punt‑typen bevatten. Cast elk geretourneerd [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) naar [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) om de punt‑ en type‑arrays op te halen via [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) en [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) methoden. Deze weergave is handig voor contouranalyse of om geometrie door te geven aan aangepaste tekengereedschappen.

Het voorbeeld opent input.pptx, vindt de eerste geometrie‑shape direct op de eerste dia, en print de padsegmenten. Gebruik een presentatie met een shape die zowel rechte als gebogen segmenten bevat om beide soorten uitvoer te zien. Het zoekt niet binnen groepen.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
            PointF[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Beh keep het segmenttype, exclusief vlaggen.
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

De arrays corresponderen per index: `points[i]` is een punt en `types[i]` beschrijft de rol ervan. Type `0` start een figure, en type `1` tekent een lijn van het vorige punt naar het huidige punt. Een kubiek Bézier‑segment start bij het vorige eindpunt en gebruikt drie opeenvolgende type‑`3`‑items: twee controlepunten gevolgd door het nieuwe eindpunt. De lus verwerkt deze drie items samen en controleert of het eindpunt sluit.

Punt‑typen bevatten ook vlaggen. Maskeer met `0x07` om het segmenttype te bepalen, en test `0x80` apart om een gesloten sub‑pad te detecteren. Bijvoorbeeld, `129` (`0x81`) betekent een lijn‑eindpunt dat een sub‑pad sluit, en `131` (`0x83`) betekent een Bézier‑eindpunt dat een sub‑pad sluit. Java slaat deze vlaggen op in signed bytes; maskeer‑operaties behouden de bedoelde bitwaarden. Alleen vergelijken met `1` of `3` zou deze gevallen missen. Andere vlaggen, zoals dash (`0x10`) en marker (`0x20`), wijzigen het basis‑segmenttype niet.

**Coördinaten en transformaties.** Punten worden gemeten in points (1/72 inch), met X groeiend naar rechts en Y groeiend naar beneden. Voor een niet‑gegroepeerde shape omvatten de geëxtraheerde coördinaten al de positie die door [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) en [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) wordt geretourneerd en weerspiegelen ze de huidige breedte en hoogte. Bijvoorbeeld, een ongeroteerde rechthoek op `(100, 200)` met afmeting `120 × 80` heeft contourgrenzen `(100, 200)`–`(220, 280)`. Voeg de positie van de shape niet opnieuw toe. Trek X en Y af om coördinaten te verkrijgen ten opzichte van het ongeroteerde frame.

De geëxtraheerde punten houden geen rekening met de rotatie van de shape, verkregen via [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--), of horizontale en verticale spiegels. Om de weergegeven contour te reproduceren, moet je die transformaties rond het midden van de shape toepassen. Voor gegroepeerde shape’s moet je ook de coördinaten‑mapping en transformaties van de groep meenemen; ga er niet van uit dat de geëxtraheerde punten de uiteindelijke gerenderde dia‑coördinaten zijn of dat je een translatie of schaal twee keer toepast als die al in het kind‑frame is verwerkt.

**Inspectie versus bewerking.** Geëxtraheerde arrays beschrijven de contour; wijzigen ervan werkt de oorspronkelijke shape niet bij. Kies deze aanpak wanneer je analyse‑ of teken‑code punt‑/type‑arrays nodig heeft. Gebruik [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) wanneer je geometrie‑commando’s in het lokale coördinatensysteem van de shape nodig hebt of wanneer je de geometrie wilt bewerken. Pas bewerkte paden toe via [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) of [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **FAQ**

**Wat gebeurt er met de opvulling en de omtrek nadat de geometrie is vervangen?**

De stijl blijft behouden bij de shape; alleen de contour verandert. De opvulling en omtrek worden automatisch op de nieuwe geometrie toegepast.

**Hoe roteer ik een aangepaste shape correct samen met zijn geometrie?**

Gebruik de methode [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) van de shape; de geometrie roteert mee omdat deze is gekoppeld aan het eigen coördinatensysteem van de shape.

**Kan ik een aangepaste shape omzetten naar een afbeelding om het resultaat “vast te leggen”?**

Ja. Exporteer het gewenste [slide](/slides/nl/androidjava/convert-powerpoint-to-png/)‑gebied of de [shape](/slides/nl/androidjava/create-shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt verdere verwerking van complexe geometrieën.