---
title: Aangepaste presentatievormen op Android
linktitle: Aangepaste vorm
type: docs
weight: 20
url: /nl/androidjava/custom-shape/
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
- gebogen hoek
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak en pas vormen aan in PowerPoint-presentaties met Aspose.Slides voor Android via Java: geometrie-paden, gebogen hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe je presentatiesvormen in Aspose.Slides kunt aanpassen door de geometrie van vormen te bewerken via bewerkingspunten en geometriepaden. Het laat zien hoe je werkt met [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) en [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) om bestaande vormen te wijzigen, basisbewerkingsbewerkingen uit te voeren, punten toe te voegen of te verwijderen, en de bijgewerkte geometrie terug op een vorm toe te passen.

Het laat ook zien hoe je aangepaste en samengestelde vormen maakt, vormen met gebogen hoeken bouwt, bepaalt of een vormgeometrie gesloten is, en vormelementen inspecteert met Android‑puntarrays.

## **Verander een Vorm met Bewerkingpunten**

In PowerPoint kun je **Bewerkingpunten** gebruiken om een vierkant te wijzigen:

* Verplaats een hoek naar binnen of naar buiten.
* Pas de kromming op een punt aan.
* Voeg nieuwe punten toe.

Bewerkingpunten laten je de omtrek van een vorm aanpassen of een bestaande vorm als basis voor een nieuwe gebruiken.

## **Tips voor het Bewerken van Vormen**

![overview_image](custom_shape_0.png)

Bij het bewerken van PowerPoint‑vormen, houd deze concepten in gedachten:

* Een vorm (of het pad) kan gesloten of open zijn.
* Het pad van een vorm bestaat uit ankerpunten die verbonden zijn door segmenten.
* Een segment kan recht of gebogen zijn. Ankerpunten en controlehandvatten bepalen de vorm.
* Ankerpunten kunnen hoekpunten, rechte punten of vloeiende punten zijn:
  * Bij een hoekpunt kunnen aangrenzende segmenten onder een hoek samenkomen.
  * Bij een vloeiend punt zijn de twee controlehandvatten op één lijn en even ver van het ankerpunt.
  * Bij een recht punt zijn de twee controlehandvatten op één lijn maar kunnen ze verschillende afstanden hebben van het ankerpunt.
* Het verplaatsen van ankerpunten of het aanpassen van hun handvatten verandert de omtrek van de vorm.

Om PowerPoint‑vormen te bewerken via bewerkingpunten, **Aspose.Slides** biedt de [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)‑klasse en de [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/)‑interface.

* Een [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)‑instantie vertegenwoordigt een geometriepad van het [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/)‑object.
* Om het [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) op te halen uit de [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/)‑instantie, kun je de methode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) gebruiken.
* Om het [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) voor een vorm in te stellen, kun je deze methoden gebruiken: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) voor vormen met één enkel pad en [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) voor vormen met meerdere paden.
* Om segmenten toe te voegen, kun je de methoden onder [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) gebruiken.
* Met de methoden [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) en [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) kun je het uiterlijk van een geometriepad instellen.
* Met de methode [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) kun je het geometriepad van een [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) als een array van padsegmenten ophalen.

## **Eenvoudige Bewerkingbewerkingen**

Gebruik de volgende methoden om een geometriepad te bewerken. Overloads die een index accepteren voegen een segment in op die nulgebaseerde positie in de segmentarray van het pad.

| Bewerking | Methode |
| --- | --- |
| Voeg een rechte lijn toe of voeg deze in. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Voeg een kubieke Bézier‑kromme toe of voeg deze in met twee controlepunten en een eindpunt. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Voeg een kwadratische Bézier‑kromme toe of voeg deze in met één controlepunt en een eindpunt. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Voeg een elliptische boog toe met de opgegeven afmetingen en hoeken in graden. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Sluit de huidige figuur door het eindpunt te verbinden met het startpunt. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Stel het startpunt van een figuur in. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Verwijder een segment op een nulgebaseerde index. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Aangepaste Punten aan een Vorm Toevoegen**

Dit voorbeeld voegt twee punten toe aan een rechthoekige vorm met behulp van [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) en past het bewerkte pad toe met [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). De coördinaten zijn lokaal ten opzichte van de vorm: beide nieuwe punten liggen in het midden, 100 punten van de linkerkant en 50 punten van de bovenkant. Segment‑indices 1 en 4 plaatsen ze op respectievelijk de boven‑ en onderrand, waardoor die randen naar binnen trekken.

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

## **Punten van een Vorm Verwijderen**

Dit voorbeeld wijzigt een hartvormige omtrek door het segment op nulgebaseerde index 2 te verwijderen met [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-). Het toepassen van het aangepaste pad met [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) werkt de contour van de vorm bij.

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

## **Een Aangepaste Vorm Maken**

Dit voorbeeld bouwt een vijfpuntige ster met [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). Afwisselend buiten‑ en binnenstraal van respectievelijk 100 en 50 punten bepalen de punten en inkepingen; een stap van 72 graden verdeelt de vijf punten gelijkmatig. Het pad wordt gesloten met [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) en toegepast op een rechthoekige vorm met [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), waardoor de omtrek wordt vervangen.

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

## **Een Samengestelde Aangepaste Vorm Maken**

Dit voorbeeld definieert twee gesloten [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)‑objecten voor respectievelijk het boven‑ en onderste derde deel van een vorm. Het toepassen van beide paden met [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) maakt één samengestelde vorm met een gat over het middelste derde deel.

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

## **Een Aangepaste Vorm met Gebogen Hoeken Maken**

Dit voorbeeld combineert rechte segmenten met [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) om een vorm met naar binnen gebogen hoeken te creëren. Elke hoekgrootte bepaalt de breedte en hoogte van de boog in points, en de -90‑graden sweep tekent een tegen de klok in kwart‑ellips. Het voltooide pad wordt toegepast met [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), en de presentatie wordt opgeslagen in PPTX‑formaat.

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

## **Nagaan of een Vormgeometrie Gesloten Is**

De volgende helper controleert of elke niet‑lege geometrie‑pad eindigt met een sluitsegment. Hij leest [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) en vergelijkt het laatste segment‑[IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) met [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). Hij retourneert `false` wanneer er geen niet‑lege paden zijn. Deze controle bekijkt het laatste commando van elk pad; hij inspecteert niet elke subfiguur binnen een pad. Het voorbeeld drukt `true` af voor een rechthoek.

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

## **Vormelementen Extraheren en Inspecteren**

Gebruik [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) om een bestaande vorm te inspecteren als elementen die padpunten en punt‑types bevatten. Cast elk geretourneerd [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) naar [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) om de punt‑ en type‑arrays op te halen via de methoden [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) en [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) . Deze representatie is nuttig voor contouranalyse of voor het doorgeven van geometrie aan aangepaste tekengereedschappen.

Het voorbeeld opent `input.pptx`, zoekt de eerste geometrie‑vorm direct op de eerste dia, en drukt de padsegmenten af. Gebruik een presentatie met een vorm die zowel rechte als gebogen segmenten bevat om beide soorten output te zien. Het zoekt niet binnen groepen.

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
                        i += 2; // Verwerk beide controlepunten en het eindpunt.
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

De arrays corresponderen per index: `points[i]` is een punt en `types[i]` beschrijft de rol ervan. Type `0` start een figuur, en type `1` tekent een lijn vanaf het vorige punt naar het huidige punt. Een kubiek Bézier‑segment start bij het vorige eindpunt en gebruikt drie opeenvolgende type‑`3`‑items: twee controlepunten gevolgd door het nieuwe eindpunt. De lus verwerkt deze drie items samen en controleert of het eindpunt gesloten is.

Punt‑types bevatten ook vlaggen. Maskeer met `0x07` om het segmenttype te identificeren, en test `0x80` apart om een gesloten subpad te detecteren. Bijvoorbeeld, `129` (`0x81`) betekent een lijn‑eindpunt dat een subpad sluit, en `131` (`0x83`) betekent een Bézier‑eindpunt dat een subpad sluit. Java slaat deze vlaggen op in signed bytes; maskeren behoudt de bedoelde bitwaarden. Alleen vergelijken met `1` of `3` zou deze gevallen missen. Andere vlaggen, zoals dash (`0x10`) en marker (`0x20`), veranderen het basistype van het segment niet.

**Coördinaten en transformaties.** Punten worden gemeten in points (1/72 inch), waarbij X naar rechts toeneemt en Y naar beneden. Voor een niet‑gegroepeerde vorm bevatten de geëxtraheerde coördinaten al de positie die wordt geretourneerd door [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) en [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) en weerspiegelen ze de huidige breedte en hoogte. Bijvoorbeeld, een niet‑geroteerde rechthoek op `(100, 200)` met grootte `120 × 80` heeft contourgrenzen `(100, 200)`–`(220, 280)`. Voeg de positie van de vorm niet opnieuw toe. Trek X en Y af om coördinaten te krijgen relatief ten opzichte van het niet‑geroteerde frame.

De geëxtraheerde punten houden geen rekening met de rotatie van de vorm, geretourneerd door [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--), of horizontale en verticale spiegels. Om de weergegeven contour te reproduceren, moet je die transformaties rond het midden van de vorm toepassen. Voor gegroepeerde vormen moet je ook rekening houden met de coördinatenmapping en transformaties van de groep; ga er niet van uit dat de geëxtraheerde punten de uiteindelijke weergegeven coördinaten op de dia zijn of dat je een translatie of schaal twee keer toepast als dit al in het kindframe is verwerkt.

**Inspectie versus bewerking.** Geëxtraheerde arrays beschrijven de contour; wijzigen ervan werkt de oorspronkelijke vorm niet bij. Kies deze aanpak wanneer je analyse‑ of teken‑code punt‑/type‑arrays nodig heeft. Gebruik [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) wanneer je geometrie‑commando’s in het lokale coördinatensysteem van de vorm nodig hebt of wanneer je de geometrie wilt bewerken. Pas bewerkte paden toe via [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) of [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **FAQ**

**Wat gebeurt er met de vulling en de omtrek na het vervangen van de geometrie?**

De stijl blijft behouden bij de vorm; alleen de contour verandert. De vulling en de omtrek worden automatisch op de nieuwe geometrie toegepast.

**Hoe roteer ik een aangepaste vorm correct samen met de geometrie?**

Gebruik de [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-)‑methode van de vorm; de geometrie roteert mee omdat deze gebonden is aan het eigen coördinatensysteem van de vorm.

**Kan ik een aangepaste vorm omzetten naar een afbeelding om het resultaat te "vergrendelen"?**

Ja. Exporteer het gewenste [slide](/slides/nl/androidjava/convert-powerpoint-to-png/)‑gebied of de [shape](/slides/nl/androidjava/create-shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt verdere bewerking van complexe geometrieën.