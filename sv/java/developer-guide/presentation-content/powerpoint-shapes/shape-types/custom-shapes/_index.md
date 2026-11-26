---
title: Anpassa presentationsformer i Java
linktitle: Anpassad form
type: docs
weight: 20
url: /sv/java/custom-shape/
keywords:
- anpassad form
- lägga till form
- skapa form
- ändra form
- formgeometri
- geometriväg
- vägspunkter
- redigera punkter
- lägga till punkt
- ta bort punkt
- redigeringsoperation
- kurvat hörn
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Skapa och anpassa former i PowerPoint‑presentationer med Aspose.Slides för Java: geometrivägar, kurvade hörn, sammansatta former."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar presentationsformer i Aspose.Slides genom att redigera formgeometri via redigeringspunkter och geometrivägar. Den visar hur du arbetar med [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) och [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) för att ändra befintliga former, utföra grundläggande vägredigeringsoperationer, lägga till eller ta bort punkter och tillämpa uppdaterad geometri på en form.

Den visar också hur du skapar anpassade och sammansatta former, bygger former med kurvade hörn, avgör om en formgeometri är sluten, inspekterar formelement och konverterar Java AWT‑textkonturer till geometrivägar.

## **Ändra en form med redigeringspunkter**

* Flytta ett hörn inåt eller utåt.
* Justera krökningen vid en punkt.
* Lägg till nya punkter.

Att redigera punkter låter dig ändra en forms kontur eller använda en befintlig form som grund för en ny.

## **Tips för att redigera former**

![overview_image](custom_shape_0.png)

När du redigerar PowerPoint‑former, tänk på följande koncept:

* En form (eller dess väg) kan antingen vara sluten eller öppen.
* En formas väg består av ankarnpunkter som är sammanlänkade med segment.
* Ett segment kan vara rakt eller kurvat. Ankarnpunkter och kontrollhandtag bestämmer dess form.
* Ankarnpunkter finns som hörnpunkter, raka punkter eller släta punkter:
  * Vid en hörnpunkt kan sammanhängande segment mötas i en vinkel.
  * Vid en slät punkt är de två kontrollhandtagen i linje och lika långt från ankarnpunkten.
  * Vid en rak punkt är de två kontrollhandtagen i linje men kan ha olika avstånd från ankarnpunkten.
* Att flytta ankarnpunkter eller justera deras handtag ändrar formens kontur.

För att redigera PowerPoint‑former via redigeringspunkter, **Aspose.Slides** tillhandahåller klassen [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) och gränssnittet [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).

* En [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)‑instans representerar en geometriväg för [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/)‑objektet.
* För att hämta [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) från en [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/)‑instans kan du använda metoden [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) .
* För att sätta [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) för en form kan du använda dessa metoder: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) för former med en enda väg och [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) för former med flera vägar.
* För att lägga till segment kan du använda metoderna under [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) .
* Med [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) och [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) kan du ange utseendet för en geometriväg.
* Genom att anropa [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) kan du hämta en [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/)‑s geometriväg som en array av segments.
* För att komma åt ytterligare anpassningsalternativ för formgeometri kan du läsa en [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) via dess [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) och åter spela segmenten på en [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) .

## **Enkla redigeringsoperationer**

Använd följande metoder för att redigera en geometriväg. Överlagringar som accepterar ett index infogar ett segment på den nollbaserade positionen i vägens segmentarray.

| Operation | Metod |
| --- | --- |
| Lägg till eller infoga en rak linje. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Lägg till eller infoga en kubisk Bézier‑kurva med två kontrollpunkter och en slutpunkt. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Lägg till eller infoga en kvadratisk Bézier‑kurva med en kontrollpunkt och en slutpunkt. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Lägg till en elliptisk båge med angivna dimensioner och vinklar i grader. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Stäng den aktuella figurens kontur genom att koppla dess slutpunkt till startpunkten. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Sätt startpunkten för en figur. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Ta bort ett segment på en nollbaserad index. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Lägg till anpassade punkter till en form**

Detta exempel infogar två punkter i en rektangulär form med hjälp av [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) och tillämpar den redigerade vägen med [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Koordinaterna är lokala för formen: båda nya punkterna ligger i dess centrum, 100 punkter från vänsterkanten och 50 punkter från toppen. Segmentindex 1 och 4 placerar dem på de övre respektive nedre kanterna och drar dessa kanter inåt.

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

## **Ta bort punkter från en form**

Detta exempel ändrar konturen på en hjärtformad figur genom att ta bort segmentet på nollbaserat index 2 med [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-). Genom att tillämpa den modifierade vägen med [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) uppdateras figurens kontur.

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

## **Skapa en anpassad form**

Detta exempel bygger en femuddig stjärna med [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/). Växlande yttre och inre radier på 100 respektive 50 punkter definierar spetsarna och huggarna; ett steg på 72 grader placerar de fem spetsarna jämnt. Vägen stängs med [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) och appliceras på en rektangulär form med [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), vilket ersätter dess kontur.

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

## **Skapa en sammansatt anpassad form**

Detta exempel definierar två slutna [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)‑objekt för de övre och nedre tredjedelarna av en form. Genom att applicera båda vägarna med [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) skapas en enda sammansatt form med ett tomrum över dess mittersta tredjedel.

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

## **Skapa en anpassad form med kurvade hörn**

Detta exempel kombinerar raka segment med [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) för att skapa en form med inåtvända kurvade hörn. Varje hörnstorlek anger bågens bredd och höjd i punkter, och svepet på –90 grader ritar en moturs kvartellips. Den färdiga vägen appliceras med [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), och presentationen sparas i PPTX‑format.

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

## **Ta reda på om en formgeometri är sluten**

Följande hjälpfunktion kontrollerar om varje icke‑tom geometriväg avslutas med ett slutsegment. Den läser [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) och jämför det sista segmentets [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) med [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/). Den returnerar falskt när det inte finns några icke‑tomma vägar. Denna kontroll tittar på det sista kommandot för varje väg; den inspekterar inte varje delfigur i en väg. Exemplet skriver ut `true` för en rektangel.

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

## **Inspektera geometrivägs‑kommandon**

Ladda ner [contour.pptx](contour.pptx) och placera den i applikationens arbetskatalog. Den första formen på den första bilden har en rak överkant, en kubisk Bézier‑kurva och en rak slutföringskant. Använd [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) för att läsa figurens vägar och [getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) för att läsa varje vägs segment i ritningsordning. För varje segment identifierar [getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) kommandot och bestämmer hur värdena från [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--) ska tolkas.

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

Figuren sitter på (200, 100) punkter på bilden. De rapporterade koordinaterna är lokala för formen, med (0, 0) i dess övre‑vänstra hörn, x ökar mot höger och y ökar nedåt. Slutsegmentet återgår till startpunkten utan extra koordinater.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint-form med en rak överkant, en krökt kant från övre högra till nedre vänstra, och en rak vänsterkant](contour.png)

## **Extrahera och inspektera formelement**

Använd [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) för att inspektera en befintlig form som element som innehåller vägpunkter och puntstyper. Kasta varje returnerad [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) till [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) för att hämta punkt‑ och typ‑arrayerna via [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) och [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--)‑metoderna. Denna representation är användbar för konturanalys eller för att skicka geometri till anpassade ritverktyg.

Exemplet öppnar input.pptx, hittar den första geometriformen direkt på den första bilden och skriver ut dess segments. Använd en presentation som innehåller en form med raka och krökta segment för att se båda typerna av resultat. Det söker inte i grupper.

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
                int pointType = types[i] & 0x07; // Behåll segmenttypen, exkluderande flaggor.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Konsumera både kontrollpunkterna och slutpunkten.
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

Arrayerna korrelerar efter index: `points[i]` är en punkt och `types[i]` beskriver dess roll. Typ `0` startar en figur, och typ `1` ritar en linje från föregående punkt till den aktuella punkten. Ett kubiskt Bézier‑segment startar vid föregående slutpunkt och använder tre på varandra följande typ‑`3`‑poster: två kontrollpunkter följt av den nya slutpunkten. Loopen konsumerar dessa tre poster tillsammans och kontrollerar om slutpunkten stänger.

Punkt‑typer innehåller också flaggor. Maskera med `0x07` för att identifiera segmenttypen och testa `0x80` separat för att upptäcka en sluten delväg. Till exempel betyder `129` (`0x81`) en linje‑slutpunkt som stänger en delväg, och `131` (`0x83`) en Bézier‑slutpunkt som stänger en. Java lagrar dessa flaggor i signerade bytes; maskering bevarar de avsedda bitvärdena. Att bara jämföra med råvärdet `1` eller `3` skulle missa dessa fall. Andra flaggor, såsom streck (`0x10`) och markör (`0x20`), ändrar inte grundsegmenttypen.

**Koordinater och transformationer.** Punkter mäts i punkter (1/72 tum), med X som ökar åt höger och Y som ökar nedåt. För en icke‑grupperad form inkluderar de extraherade koordinaterna redan positionen som returneras av [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) och [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) och speglar dess aktuella bredd och höjd. Till exempel har en icke‑roterad rektangel på `(100, 200)` med storlek `120 × 80` konturbundna `(100, 200)`–`(220, 280)`. Lägg inte till formens position igen. Subtrahera dess X och Y för att få koordinater relativt till dess o‑roterade ram.

De extraherade punkterna tar inte hänsyn till formens rotation, som returneras av [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--), eller horisontella och vertikala speglingar. För att återge den visade konturen, applicera dessa transformationer kring formens centrum. För grupperade former måste du även beakta gruppens koordinatmappning och transformationer; anta inte att de extraherade punkterna är de slutgiltiga renderade bildpunkterna eller att en förflyttning eller skalning ska appliceras två gånger om den redan är reflekterad i barnets ram.

**Inspektion kontra redigering.** Extraherade arrayer beskriver konturen; att ändra dem uppdaterar inte den ursprungliga formen. Välj detta tillvägagångssätt när din analys eller ditt ritkod kräver punkt‑/typ‑arrayer. Använd [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) när du behöver geometrikommandon i figurens lokala koordinatsystem eller vill redigera dess geometri. Tillämpa redigerade vägar via [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) eller [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **Konvertera en Java AWT-form till GeometryPath**

Detta exempel kombinerar en rektangulär kontur med text som konverterats till geometri. Konturets [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-)‑metod inaktiverar dess fyllning. En [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) skapar textkonturen i en [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Dess [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) levererar move, line, quadratic, cubic och closing‑segment, vilka exemplet spelar upp på en [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) .

Texten använder ett 40‑punkts Arial‑typsnitt. Konturen är förskjuten 20 punkter horisontellt och placerad så att dess visuella topp ligger 10 punkter under formens överkant. Textvägen fylls, medan den ursprungliga rektangeln förblir en kontur. Genom att applicera båda vägarna med [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) skapas en enda form som innehåller både rektangeln och texten.

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
    // Skapa ny form
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Hämta geometriväg för formen
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Skapa ny grafisk bana med text
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

    // Konvertera grafisk bana till geometriväg
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

    // Ställ in kombination av ny geometriväg och ursprunglig geometriväg på formen
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Vad händer med fyllning och kontur efter att geometrin ersatts?**

Stilen förblir knuten till formen; endast konturen förändras. Fyllning och kontur appliceras automatiskt på den nya geometrin.

**Hur roterar jag en anpassad form korrekt tillsammans med dess geometri?**

Använd figurens [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-)‑metod; geometrin roterar med figuren eftersom den är bunden till figurens eget koordinatsystem.

**Kan jag konvertera en anpassad form till en bild för att ”låsa” resultatet?**

Ja. Exportera den önskade [slide](/slides/sv/java/convert-powerpoint-to-png/)‑området eller själva [shape](/slides/sv/java/create-shape-thumbnails/) till ett rasterformat; detta förenklar vidare arbete med komplexa geometrier.