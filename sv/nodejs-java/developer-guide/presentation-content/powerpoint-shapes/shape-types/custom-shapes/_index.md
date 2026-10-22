---
title: Anpassa presentationsformer i JavaScript
linktitle: Anpassad form
type: docs
weight: 20
url: /sv/nodejs-java/custom-shape/
keywords:
- anpassad form
- lägg till form
- skapa form
- ändra form
- formgeometri
- geometrisk bana
- banpunkter
- redigera punkter
- lägg till punkt
- ta bort punkt
- redigeringsoperation
- böjt hörn
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa och anpassa former i PowerPoint-presentationer med JavaScript och Aspose.Slides för Node.js: geometriska banor, böjda hörn, sammansatta former."
---
## **Översikt**

Den här artikeln förklarar hur man anpassar presentationsformer i Aspose.Slides genom att redigera formgeometri via redigeringspunkter och geometriska banor. Den visar hur man arbetar med [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) för att ändra befintliga former, utföra grundläggande redigeringsoperationer, lägga till eller ta bort punkter och tillämpa uppdaterad geometri på en form.

Den visar också hur man skapar anpassade och sammansatta former, bygger former med böjda hörn, avgör huruvida en formgeometri är sluten, inspekterar formelement och konverterar Java AWT-textkonturer till geometriska banor.

## **Ändra en form med redigeringspunkter**

I PowerPoint kan du använda **Edit Points** för att ändra en fyrkant:

* Flytta ett hörn inåt eller utåt.
* Justera krökningen på en punkt.
* Lägg till nya punkter.

Att redigera punkter låter dig förändra en formes kontur eller använda en befintlig form som grund för en ny.

## **Tips för formredigering**

![overview_image](custom_shape_0.png)

När du redigerar PowerPoint‑former, håll dessa begrepp i åtanke:

* En form (eller dess bana) kan antingen vara sluten eller öppen.
* En formens bana består av ankarpunkter som är kopplade med segment.
* Ett segment kan vara rakt eller kurvat. Ankarpunkter och kontrollhandtag bestämmer dess form.
* Ankarpunkter finns som hörnpunkter, raka punkter eller släta punkter:
  * Vid en hörnpunkt kan intilliggande segment mötas i en vinkel.
  * Vid en slät punkt är de två kontrollhandtagen i linje och lika långt från ankpunkten.
  * Vid en rak punkt är de två kontrollhandtagen i linje men kan ha olika avstånd från ankpunkten.
* Att flytta ankarpunkter eller justera deras handtag förändrar formens kontur.

För att redigera PowerPoint‑former via redigeringspunkter tillhandahåller **Aspose.Slides** klassen [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

* En [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)‑instans representerar en geometrisk bana för objektet [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/).
* För att hämta [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) från [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/)‑instansen kan du använda metoden [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths).
* För att ställa in [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) för en form kan du använda dessa metoder: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) för former med en enkel bana och [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) för former med flera banor.
* För att lägga till segment kan du använda metoderna under [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).
* Genom att använda metoderna [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) och [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) kan du ange utseendet för en geometrisk bana.
* Genom att använda metoden [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) kan du hämta geometrisk bana för en [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) som en array av segment.
* För att komma åt ytterligare anpassningsalternativ för formgeometri kan du läsa ett [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) via dess [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) och återge segmenten på en [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **Enkla redigeringsoperationer**

Använd följande metoder för att redigera en geometrisk bana. Överlagringar som tar emot ett index infogar ett segment på den nollbaserade positionen i bana‑segmentarrayen.

| Operation | Metod |
| --- | --- |
| Lägg till eller infoga en rak linje. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Lägg till eller infoga en kubisk Bézier-kurva med två kontrollpunkter och en slutpunkt. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Lägg till eller infoga en kvadratisk Bézier-kurva med en kontrollpunkt och en slutpunkt. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Lägg till en elliptisk båge med angivna dimensioner och vinklar i grader. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Stäng den aktuella figuren genom att ansluta dess slutpunkt till startpunkten. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Ange startpunkten för en figur. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Ta bort ett segment vid ett nollbaserat index. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Lägg till anpassade punkter till en form**

Detta exempel infogar två punkter i en rektangulär form med hjälp av [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) och tillämpar den redigerade banan med [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). Koordinaterna är lokala för formen: båda nya punkterna ligger i dess centrum, 100 punkter från vänster och 50 punkter från toppen. Segmentindex 1 och 4 placerar dem på övre och nedre kanterna och drar dessa kanter inåt.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Ta bort punkter från en form**

Detta exempel ändrar en hjärtformad kontur genom att ta bort segmentet vid nollbaserat index 2 med [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). Att tillämpa den modifierade banan med [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) uppdaterar formens kontur.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Skapa en anpassad form**

Detta exempel bygger en femspetsig stjärna med [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). Växlande yttre och inre radier på 100 respektive 50 punkter definierar spetsarna och indragningarna; ett steg på 72 grader placerar de fem spetsarna jämnt. Banen stängs med [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) och tillämpas på en rektangulär form med [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), vilket ersätter dess kontur.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Skapa en sammansatt anpassad form**

Detta exempel definierar två stängda [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)‑objekt för den övre och nedre tredjedelen av en form. Att tillämpa båda banorna med [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) skapar en enda sammansatt form med ett mellanrum över dess mittersta tredjedel.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Skapa en anpassad form med böjda hörn**

Detta exempel kombinerar raka segment med [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) för att skapa en form med inåtböjda hörn. Varje hörnstorlek sätter bågens bredd och höjd i punkter, och -90‑gradssvepet ritar en moturs kvarts‑ellips. Den färdiga banan tillämpas med [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) och presentationen sparas i PPTX‑format.

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ta reda på om en formgeometri är sluten**

Följande hjälpfunktion kontrollerar om varje icke‑tom geometrisk bana avslutas med ett avslutningssegment. Den läser [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) och jämför det sista segmentets [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) med [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). Den returnerar falskt när det inte finns några icke‑tomma banor. Detta kontrollerar det sista kommandot för varje bana; den inspekterar inte varje underfigur inom en bana. Exemplet skriver ut `true` för en rektangel.

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **Extrahera och inspektera formelement**

Använd [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) för att inspektera en befintlig form som element som innehåller banpunkter och punkttyper. Använd varje returnerad [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) för att hämta punkt‑ och typ‑arrayerna via metoderna [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) och [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes). Denna representation är användbar för konturanalys eller för att vidarebefordra geometri till anpassade ritverktyg.

Exemplet öppnar input.pptx, hittar den första geometriska formen direkt på den första bilden och skriver ut dess bansegment. Använd en presentation som innehåller en form med raka och kurvade segment för att se båda typerna av resultat. Det söker inte inuti grupper.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // Behåll segmenttypen, exklusive flaggor.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Arrayerna motsvarar varandra via index: `points[i]` är en punkt och `types[i]` beskriver dess roll. Typ `0` startar en figur, och typ `1` ritar en linje från föregående punkt till den aktuella punkten. Ett kubiskt Bézier‑segment startar vid föregående slutpunkt och använder tre på varandra följande typ‑`3`‑poster: två kontrollpunkter följda av den nya slutpunkten. Loopen konsumerar dessa tre poster tillsammans och kontrollerar slutpunkten för stängning.

Punkttyper innehåller också flaggor. Maskera med `0x07` för att identifiera segmenttypen och testa `0x80` separat för att upptäcka en sluten delbana. Till exempel betyder `129` (`0x81`) en linjeslutpunkt som stänger en delbana, och `131` (`0x83`) betyder en Bézier‑slutpunkt som stänger en sådan. Java lagrar dessa flaggor i signerade byte; maskning bevarar de avsedda bitvärdena. Att bara jämföra det råa värdet med `1` eller `3` skulle missa dessa fall. Andra flaggor, såsom streck (`0x10`) och markör (`0x20`), förändrar inte bassegmenttypen.

**Koordinater och transformationer.** Punkter mäts i punkter (1/72 tum), där X ökar åt höger och Y ökar nedåt. För en icke‑grupperad form inkluderar de extraherade koordinaterna redan positionen som returneras av [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) och [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) och speglar dess aktuella bredd och höjd. Till exempel har en icke‑roterad rektangel på `(100, 200)` med storleken `120 × 80` konturboundaries `(100, 200)`–`(220, 280)`. Lägg inte till formens position igen. Subtrahera dess X och Y för att få koordinater relativt dess icke‑roterade ram.

De extraherade punkterna tar inte hänsyn till formens rotation, som returneras av [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation), eller horisontella och vertikala speglingar. För att reproducera den visade konturen, applicera dessa transformationer kring formens centrum. För grupperade former, ta också hänsyn till gruppens koordinatavbildning och transformationer; anta inte att de extraherade punkterna är de slutgiltiga renderade bildpunkterna eller applicera en förskjutning eller skalning två gånger om den redan återspeglas i barnets ram.

**Inspektion kontra redigering.** Extraherade arrayer beskriver konturen; att ändra dem uppdaterar inte den ursprungliga formen. Välj detta tillvägagångssätt när din analys‑ eller ritkod behöver punkt‑/typ‑arrayer. Använd [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) när du behöver geometrikommando i formens lokala koordinatsystem eller vill redigera dess geometri. Tillämpa redigerade banor via [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) eller [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Konvertera en Java AWT-form till GeometryPath**

Detta exempel kombinerar en rektangulär kontur med text konverterad till geometri. Konturens [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode)‑metod inaktiverar dess fyllning. En [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) skapar textkonturen i en [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Dess [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) levererar flytt, linje, kvadratisk, kubisk och avslutningssegment, vilka exemplet återspelar på en [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

Java‑bron använder explicita float‑ och byte‑värden för motsvarande Java‑parametrar. Iteratören skriver koordinater i en Java‑float‑array; reflektion läser tillbaka de uppdaterade värdena till JavaScript. Texten använder ett 40‑punkt Arial‑typsnitt. Konturen är förskjuten 20 punkter horisontellt och placerad med sin visuella topp 10 punkter under formens övre kant. Textbanan är fylld, medan den ursprungliga rektangeln förblir en kontur. Att tillämpa båda banorna med [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) skapar en enda form som innehåller rektangeln och texten.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // Flytta till.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // Linje till.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // Kvadratisk Bézier-kurva.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Kubisk Bézier-kurva.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // Stäng figur.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Vad händer med fyllning och kontur efter att geometrin har ersatts?**

Stilen förblir på formen; endast konturen förändras. Fyllning och kontur tillämpas automatiskt på den nya geometrin.

**Hur roterar jag en anpassad form korrekt tillsammans med dess geometri?**

Använd formens [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation)‑metod; geometrin roterar med formen eftersom den är bunden till formens eget koordinatsystem.

**Kan jag konvertera en anpassad form till en bild för att "låsa" resultatet?**

Ja. Exportera det önskade [slide](/slides/sv/nodejs-java/convert-powerpoint-to-png/)‑området eller själva [shape](/slides/sv/nodejs-java/create-shape-thumbnails/) till ett rasterformat; detta förenklar vidare arbete med komplexa geometrier.