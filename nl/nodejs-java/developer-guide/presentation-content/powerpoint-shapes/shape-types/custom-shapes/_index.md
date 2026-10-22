---
title: Presentatievormen aanpassen in JavaScript
linktitle: Aangepaste Vorm
type: docs
weight: 20
url: /nl/nodejs-java/custom-shape/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak en pas vormen aan in PowerPoint-presentaties met JavaScript en Aspose.Slides voor Node.js: geometriepaden, afgeronde hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe je presentatiesvormen in Aspose.Slides kunt aanpassen door de vormgeometrie te bewerken via bewerkingspunten en geometriepaden. Het laat zien hoe je werkt met [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) om bestaande vormen te wijzigen, basisbewerkingsbewerkingen uit te voeren, punten toe te voegen of te verwijderen, en de bijgewerkte geometrie terug toe te passen op een vorm.

Het toont ook hoe je aangepaste en samengestelde vormen maakt, vormen met afgeronde hoeken bouwt, bepaalt of een vormgeometrie gesloten is, vormelementen inspecteert, en Java AWT-tekstopmaken converteert naar geometriepaden.

## **Een vorm wijzigen met bewerkingspunten**

In PowerPoint kun je **Bewerkingspunten** gebruiken om een vierkant te wijzigen:

* Verplaats een hoek naar binnen of naar buiten.
* Pas de kromming op een punt aan.
* Voeg nieuwe punten toe.

Door punten te bewerken kun je de omtrek van een vorm aanpassen of een bestaande vorm als basis voor een nieuwe gebruiken.

## **Tips voor het bewerken van vormen**

![overview_image](custom_shape_0.png)

Houd bij het bewerken van PowerPoint‑vormen rekening met de volgende concepten:

* Een vorm (of het pad ervan) kan gesloten of open zijn.
* Het pad van een vorm bestaat uit ankerpunten die verbonden zijn door segmenten.
* Een segment kan recht of gebogen zijn. Ankerpunten en controlehandvatten bepalen de vorm.
* Ankerpunten bestaan als hoekpunten, rechte punten of vloeiende punten:
  * Bij een hoekpunt kunnen aangrenzende segmenten onder een hoek samenkomen.
  * Bij een vloeiend punt zijn de twee controlehandvatten uitgelijnd en even ver van het ankerpunt.
  * Bij een recht punt zijn de twee controlehandvatten uitgelijnd, maar kunnen ze verschillende afstanden tot het ankerpunt hebben.
* Door ankerpunten te verplaatsen of hun handvatten aan te passen, verandert de omtrek van de vorm.

Om PowerPoint‑vormen via bewerkingspunten te bewerken, biedt **Aspose.Slides** de klasse [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) aan.

* Een [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)‑instantie stelt een geometriepad van het [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/)‑object voor.
* Om de [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) op te halen van de [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/)‑instantie, kun je de methode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) gebruiken.
* Om de [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) voor een vorm in te stellen, kun je de volgende methoden gebruiken: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) voor vormen met één enkel pad en [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) voor vormen met meerdere paden.
* Om segmenten toe te voegen, kun je de methoden onder [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) gebruiken.
* Met de methoden [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) en [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) kun je het uiterlijk van een geometriepad instellen.
* Met de methode [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) kun je het geometriepad van een [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) ophalen als een array van padhsegmenten.
* Om extra opties voor het aanpassen van vormgeometrie te benaderen, kun je een [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) lezen via zijn [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) en de segmenten opnieuw afspelen op een [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **Eenvoudige bewerkingsbewerkingen**

Gebruik de volgende methoden om een geometriepad te bewerken. Overloads die een index accepteren, voegen een segment in op die nulgebaseerde positie in de segmentarray van het pad.

| Bewerking | Methode |
| --- | --- |
| Een rechte lijn toevoegen of invoegen. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Een kubieke Bézier‑curve met twee controlepunten en een eindpunt toevoegen of invoegen. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Een kwadratische Bézier‑curve met één controlepunt en een eindpunt toevoegen of invoegen. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Een elliptische boog met de opgegeven afmetingen en hoeken in graden toevoegen. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| De huidige figuur sluiten door het eindpunt met het beginpunt te verbinden. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Het startpunt van een figuur instellen. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Een segment op een nulgebaseerde index verwijderen. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Aangepaste punten aan een vorm toevoegen**

Dit voorbeeld voegt twee punten toe aan een rechthoekige vorm met behulp van [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) en past het bewerkte pad toe met [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). De coördinaten zijn lokaal ten opzichte van de vorm: beide nieuwe punten liggen in het midden, 100 punten vanaf de linkerkant en 50 punten vanaf de bovenkant. Segment‑indexen 1 en 4 plaatsen ze op de boven‑ en onderrand, waardoor die randen naar binnen worden getrokken.

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

## **Punten uit een vorm verwijderen**

Dit voorbeeld wijzigt een hartvormige omtrek door het segment op nulgebaseerde index 2 te verwijderen met [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). Het toepassen van het gewijzigde pad met [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) werkt de contour van de vorm bij.

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

## **Een aangepaste vorm maken**

Dit voorbeeld bouwt een ster met vijf punten met behulp van [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). Afwisselend buiten- en binnenstraal van 100 en 50 punten bepalen de toppen en inkepingen; een stap van 72 graden verdeelt de vijf toppen gelijkmatig. Het pad wordt gesloten met [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) en toegepast op een rechthoekige vorm met [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), waarmee de omtrek wordt vervangen.

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

## **Een samengestelde aangepaste vorm maken**

Dit voorbeeld definieert twee gesloten [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)‑objecten voor het bovenste en onderste derde deel van een vorm. Het toepassen van beide paden met [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) creëert één samengestelde vorm met een opening over het middelste derde deel.

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

## **Een aangepaste vorm met afgeronde hoeken maken**

Dit voorbeeld combineert rechte segmenten met [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) om een vorm met naar binnen gebogen hoeken te maken. Elke hoekgrootte bepaalt de breedte en hoogte van de boog in punten, en de -90‑graden sweep tekent een ellipskwartje tegen de klok in. Het voltooide pad wordt toegepast met [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), en de presentatie wordt opgeslagen in PPTX‑formaat.

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

## **Controleren of een vormgeometrie gesloten is**

De volgende helper controleert of elk niet‑leeg geometriepad eindigt met een sluitssegment. Het leest [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) en vergelijkt het laatste segment‑[PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) met [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). Het geeft false terug wanneer er geen niet‑lege paden zijn. Deze controle kijkt naar het laatste commando van elk pad; het inspecteert niet elke subfiguur binnen een pad. Het voorbeeld geeft `true` weer voor een rechthoek.

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

## **Vormelementen extraheren en inspecteren**

Gebruik [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) om een bestaande vorm te inspecteren als elementen die padpunten en punt‑types bevatten. Gebruik elk geretourneerd [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) om de punt‑ en type‑arrays op te halen via de methoden [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) en [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes). Deze weergave is nuttig voor contouranalyse of het doorgeven van geometrie aan aangepaste tekenhulpmiddelen.

Het voorbeeld opent input.pptx, zoekt de eerste geometrievorm direct op de eerste dia, en drukt de padhsegmenten af. Gebruik een presentatie met een vorm met rechte en gebogen segmenten om beide soorten output te zien. Het zoekt niet binnen groepen.

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
                const pointType = types[i] & 0x07; // Behoud het segmenttype, exclusief vlaggen.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Verwerk beide controlepunten en het eindpunt.
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

De arrays corresponderen per index: `points[i]` is een punt en `types[i]` beschrijft zijn rol. Type `0` start een figuur, en type `1` tekent een lijn van het vorige punt naar het huidige punt. Een kubisch Bézier‑segment start bij het vorige eindpunt en gebruikt drie opeenvolgende type‑`3`‑items: twee controlepunten gevolgd door het nieuwe eindpunt. De lus verwerkt deze drie items samen en controleert of het eindpunt gesloten is.

Punt‑types bevatten ook vlaggen. Masker met `0x07` om het segmenttype te identificeren, en test `0x80` apart om een gesloten subpad te detecteren. Bijvoorbeeld, `129` (`0x81`) betekent een lijn‑eindpunt dat een subpad sluit, en `131` (`0x83`) betekent een Bézier‑eindpunt dat er een sluit. Java slaat deze vlaggen op in signed bytes; maskeren behoudt de bedoelde bitwaarden. Alleen vergelijken met `1` of `3` zou deze gevallen missen. Andere vlaggen, zoals dash (`0x10`) en marker (`0x20`), wijzigen het basissegmenttype niet.

**Coördinaten en transformaties.** Punten worden gemeten in points (1/72 inch), waarbij X naar rechts toeneemt en Y naar beneden. Voor een niet‑gegroepeerde vorm bevatten de geëxtraheerde coördinaten reeds de positie die door [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) en [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) wordt geretourneerd en weerspiegelen de huidige breedte en hoogte. Bijvoorbeeld, een niet‑geroteerde rechthoek op `(100, 200)` met grootte `120 × 80` heeft contourgrenzen `(100, 200)`–`(220, 280)`. Voeg de positie van de vorm niet opnieuw toe. Trek X en Y af om coördinaten te krijgen ten opzichte van het niet‑geroteerde frame.

De geëxtraheerde punten passen de rotatie van de vorm, geretourneerd door [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation), of horizontale en verticale spiegels niet toe. Om de weergegeven contour te reproduceren, pas die transformaties toe rond het midden van de vorm. Voor gegroepeerde vormen, houd ook rekening met de groep‑coördinatenmapping en transformaties; ga er niet van uit dat de geëxtraheerde punten de definitieve gerenderde dia‑coördinaten zijn of pas een translatie of schaal twee keer toe als die al in het kader van het kind is weerspiegeld.

**Inspectie versus bewerking.** Geëxtraheerde arrays beschrijven de contour; wijzigen ervan werkt de oorspronkelijke vorm niet bij. Kies deze aanpak als je analyse‑ of teken‑code punt‑/type‑arrays nodig heeft. Gebruik [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) wanneer je geometrie‑commando’s nodig hebt in het lokale coördinatensysteem van de vorm of de geometrie wilt bewerken. Pas bewerkte paden toe via [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) of [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Een Java AWT‑vorm naar GeometryPath converteren**

Dit voorbeeld combineert een rechthoekige omtrek met tekst die naar geometrie is geconverteerd. De [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode)‑methode van de omtrek schakelt de vulling uit. Een [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) creëert de tekstopmaak in een [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Zijn [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) levert move‑, line‑, quadratic‑, cubic‑ en sluit‑segmenten, die het voorbeeld opnieuw afspeelt op een [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

De Java‑brug gebruikt expliciete float‑ en byte‑waarden voor de overeenkomstige Java‑parameters. De iterator schrijft coördinaten naar een Java‑float‑array; reflectie leest de bijgewerkte waarden terug in JavaScript. De tekst gebruikt een 40‑point Arial‑lettertype. De omtrek is horizontaal 20 punten verschoven en gepositioneerd met de visuele bovenkant 10 punten onder de bovenrand van de vorm. Het tekstpad is gevuld, terwijl de oorspronkelijke rechthoek een omtrek blijft. Het toepassen van beide paden met [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) resulteert in één vorm die zowel de rechthoek als de tekst bevat.

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
            case 0: // Verplaats naar.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // Lijn naar.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // Kwadratische Bézier-curve.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Kubieke Bézier-curve.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // Sluit figuur.
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

**Wat gebeurt er met de vulling en omtrek na het vervangen van de geometrie?**

De stijl blijft bij de vorm; alleen de contour verandert. De vulling en omtrek worden automatisch toegepast op de nieuwe geometrie.

**Hoe roteer ik een aangepaste vorm correct samen met zijn geometrie?**

Gebruik de [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation)‑methode van de vorm; de geometrie roteert mee met de vorm omdat hij gebonden is aan het eigen coördinatensysteem van de vorm.

**Kan ik een aangepaste vorm converteren naar een afbeelding om het resultaat 'vast te leggen'?**

Ja. Exporteer het benodigde [slide](/slides/nl/nodejs-java/convert-powerpoint-to-png/)‑gebied of de [shape](/slides/nl/nodejs-java/create-shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt verdere bewerkingen met complexe geometrieën.