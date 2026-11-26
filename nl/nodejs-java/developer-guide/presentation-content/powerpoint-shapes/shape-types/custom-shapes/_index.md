---
title: Aangepaste presentatievormen in JavaScript
linktitle: Aangepaste vorm
type: docs
weight: 20
url: /nl/nodejs-java/custom-shape/
keywords:
- aangepaste vorm
- vorm toevoegen
- vorm maken
- vorm wijzigen
- vorm geometrie
- geometriepad
- padpunten
- bewerkingspunten
- punt toevoegen
- punt verwijderen
- bewerkingsoperatie
- gebogen hoek
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak en pas vormen aan in PowerPoint‑presentaties met JavaScript en Aspose.Slides voor Node.js: geometrie‑paden, gebogen hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe je presentatieshapes in Aspose.Slides kunt aanpassen door de vormgeometrie te bewerken via bewerkingspunten en geometriepaden. Het laat zien hoe je werkt met [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) om bestaande shapes te wijzigen, basisbewerkingsbewerkingen uit te voeren, punten toe te voegen of te verwijderen, en de bijgewerkte geometrie terug toe te passen op een shape.

Het laat bovendien zien hoe je aangepaste en samengestelde shapes maakt, shapes bouwt met gebogen hoeken, bepaalt of een shape-geometrie gesloten is, shape‑elementen inspecteert, en Java‑AWT‑tekstopmaken omzet naar geometriepaden.

## **Vorm wijzigen met bewerkingspunten**

* Verplaats een hoek naar binnen of naar buiten.
* Pas de kromming op een punt aan.
* Voeg nieuwe punten toe.

Bewerkingspunten laten je de omtrek van een shape wijzigen of een bestaande shape als basis voor een nieuwe shape gebruiken.

## **Tips voor vormbewerking**

![overview_image](custom_shape_0.png)

Wanneer je PowerPoint‑shapes bewerkt, houd dan rekening met de volgende concepten:

* Een shape (of het pad) kan zowel gesloten als open zijn.
* Het pad van een shape bestaat uit ankerpunten verbonden door segmenten.
* Een segment kan recht of gebogen zijn. Ankerpunten en controlehandvatten bepalen de vorm.
* Ankerpunten bestaan als hoekpunten, rechte punten of vloeiende punten:
  * Bij een hoekpunt kunnen aangrenzende segmenten onder een hoek samenkomen.
  * Bij een vloeiend punt zijn de twee controlehandvatten uitgelijnd en even ver van het ankerpunt.
  * Bij een recht punt zijn de twee controlehandvatten uitgelijnd maar kunnen ze verschillende afstanden van het ankerpunt hebben.
* Het verplaatsen van ankerpunten of het aanpassen van hun handvatten verandert de omtrek van de shape.

Om PowerPoint‑shapes te bewerken via bewerkingspunten, levert **Aspose.Slides** de [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)‑klasse.

* Een [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)‑instantie vertegenwoordigt een geometriepad van het [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/)‑object.
* Om het [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) van een [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/)‑instantie op te halen, kun je de methode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) gebruiken.
* Om het [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) voor een shape in te stellen, kun je deze methoden gebruiken: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) voor shapes met één pad en [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) voor shapes met meerdere paden.
* Om segmenten toe te voegen, kun je de methoden onder [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) gebruiken.
* Met behulp van de methoden [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) en [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) kun je het uiterlijk van een geometriepad definiëren.
* Met de methode [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) kun je het geometriepad van een [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) als een array van padsegmenten ophalen.
* Voor extra opties voor shape‑geometrie‑aanpassing kun je een [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) via zijn [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) uitlezen en de segmenten opnieuw afspelen op een [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **Simple Editing Operations**

Gebruik de volgende methoden om een geometriepad te bewerken. Overloads die een index accepteren voegen een segment in op die nul‑gebaseerde positie in de segmentarray van het pad.

| Operatie | Methode |
| --- | --- |
| Een rechte lijn toevoegen of invoegen. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Een kubieke Bézier‑curve met twee controlepunten en een eindpunt toevoegen of invoegen. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Een kwadratische Bézier‑curve met één controlepunt en een eindpunt toevoegen of invoegen. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Een elliptische boog met de opgegeven afmetingen en hoeken (in graden) toevoegen. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| De huidige figuur sluiten door het eindpunt met het startpunt te verbinden. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Het startpunt van een figuur instellen. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Een segment verwijderen op een nul‑gebaseerde index. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Aangepaste punten aan een shape toevoegen**

Dit voorbeeld voegt twee punten toe aan een rechthoekige shape met behulp van [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) en past het bewerkte pad toe met [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). De coördinaten zijn lokaal voor de shape: beide nieuwe punten liggen in het midden, 100 punten van de linkerkant en 50 punten van de bovenkant. Segmentindices 1 en 4 plaatsen ze respectievelijk op de boven‑ en onderrand, waardoor die randen naar binnen worden getrokken.

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

## **Punten van een shape verwijderen**

Dit voorbeeld wijzigt een hartvormige omtrek door het segment op nul‑gebaseerde index 2 te verwijderen met [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). Het toepassen van het aangepaste pad met [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) werkt de contour van de shape bij.

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

## **Aangepaste shape maken**

Dit voorbeeld bouwt een vijfpuntige ster met [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). Afwisselend buiten‑ en binnenstraal van respectievelijk 100 en 50 punten bepalen de toppen en inkepingen; een stap van 72 graden verdeelt de vijf toppen gelijkmatig. Het pad wordt gesloten met [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) en toegepast op een rechthoekige shape via [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), waardoor de bestaande omtrek wordt vervangen.

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

## **Samengestelde aangepaste shape maken**

Dit voorbeeld definieert twee gesloten [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)-objecten voor respectievelijk het boven‑ en onderste derde deel van een shape. Het toepassen van beide paden met [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) creëert één samengestelde shape met een opening over het middelste derde deel.

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

## **Aangepaste shape met gebogen hoeken maken**

Dit voorbeeld combineert rechte segmenten met [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) om een shape met naar binnen gebogen hoeken te maken. Elke hoekgrootte bepaalt de breedte en hoogte van de boog in punten, en de -90‑graden sweep tekent een tegen de klok in gerichte kwart‑ellips. Het voltooide pad wordt toegepast met [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), en de presentatie wordt opgeslagen in PPTX‑formaat.

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

## **Controleren of een shape-geometrie gesloten is**

De volgende helper controleert of elk niet‑lege geometriepad eindigt met een sluit‑segment. Hij leest [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) en vergelijkt het commando van het laatste segment ([PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand)) met [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). Hij geeft **false** terug wanneer er geen niet‑lege paden zijn. Deze controle kijkt alleen naar het laatste commando van elk pad; hij inspecteert niet elke sub‑figuur binnen een pad. Het voorbeeld print `true` voor een rechthoek.

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

## **Geometriepad‑commando's inspecteren**

Download [contour.pptx](contour.pptx) en plaats het in de werkmap van de applicatie. De eerste shape op de eerste dia heeft een rechte bovenrand, een kubieke Bézier‑curve en een rechte sluitrand. Gebruik [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) om de paden van de shape te lezen en [getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) om elk pad‑segment in tekenvolgorde uit te lezen. Voor elk segment identificeert [getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) het commando en bepaalt het hoe de waarden van [getSegmentData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getSegmentData) geïnterpreteerd moeten worden.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("contour.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paths = shape.getGeometryPaths();
    for (const [i, path] of paths.entries()) {
        const segments = path.getPathData();
        for (const [j, segment] of segments.entries()) {
            const command = segment.getPathCommand();
            const data = segment.getSegmentData();
            let detail;
            switch (command) {
                case slides.PathCommandType.MoveTo:
                case slides.PathCommandType.LineTo:
                    const name = command === slides.PathCommandType.MoveTo ? "MoveTo" : "LineTo";
                    detail = `${name} destination=(${data[0]}, ${data[1]})`;
                    break;
                case slides.PathCommandType.CubicBezierTo:
                    detail = `CubicBezierTo control1=(${data[0]}, ${data[1]}) control2=(${data[2]}, ${data[3]}) end=(${data[4]}, ${data[5]})`;
                    break;
                case slides.PathCommandType.Close:
                    detail = "Close no coordinates";
                    break;
                default:
                    detail = `command=${command} raw=[${data.join(", ")}]`;
            }
            console.log(`Path ${i}, segment ${j}: ${detail}`);
        }
    }
} finally {
    presentation.dispose();
}
```

De shape bevindt zich op (200, 100) punten op de dia. De gerapporteerde coördinaten zijn lokaal voor de shape, met (0, 0) links‑boven, x stijgt naar rechts en y naar beneden. Het sluit‑segment keert terug naar het startpunt zonder extra coördinaten.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint‑shape met een rechte bovenrand, een gebogen rand van rechts‑boven naar links‑onder, en een rechte linker rand](contour.png)

## **Shape‑elementen extraheren en inspecteren**

Gebruik [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) om een bestaande shape te inspecteren als elementen die padpunten en punt‑typen bevatten. Gebruik elk teruggegeven [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) om via [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) en [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes) de punten‑ en type‑arrays op te halen. Deze weergave is nuttig voor contouranalyse of om geometrie door te geven aan aangepaste teken‑tools.

Het voorbeeld opent **input.pptx**, vindt de eerste geometrische shape direct op de eerste dia, en print diens padsegmenten. Gebruik een presentatie met een shape die rechte en gebogen segmenten bevat om beide soorten output te zien. Het doorzoekt geen groepen.

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
                        i += 2; // Verbruik beide controlepunten en het eindpunt.
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

De arrays correleren op index: `points[i]` is een punt en `types[i]` beschrijft de rol. Type `0` start een figuur, type `1` tekent een lijn van het vorige punt naar het huidig punt. Een kubieke Bézier‑segment start bij het vorige eindpunt en gebruikt drie opeenvolgende type‑`3`‑items: twee controlepunten gevolgd door het nieuwe eindpunt. De lus verwerkt deze drie items samen en controleert of het eindpunt sluit.

Punt‑typen kunnen ook vlaggen bevatten. Maskeer met `0x07` om het segmenttype te bepalen, en test `0x80` afzonderlijk om een gesloten sub‑pad te detecteren. Bijvoorbeeld, `129` (`0x81`) betekent een lijn‑eindpunt dat een sub‑pad sluit, en `131` (`0x83`) betekent een Bézier‑eindpunt dat sluit. Java slaat deze vlaggen op in signed bytes; maskeren behoudt de bedoelde bits. Alleen vergelijken met `1` of `3` zou deze gevallen missen. Andere vlaggen, zoals dash (`0x10`) en marker (`0x20`), wijzigen het basistype niet.

**Coördinaten en transformaties.** Punten worden gemeten in points (1/72 inch), waarbij X naar rechts en Y naar beneden groeit. Voor een niet‑gegroepeerde shape bevatten de geëxtraheerde coördinaten reeds de positie die je krijgt via [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) en [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) en weerspiegelen ze de huidige breedte en hoogte. Een ongeroteerde rechthoek op `(100, 200)` met afmeting `120 × 80` heeft contourgrenzen `(100, 200)`–`(220, 280)`. Voeg de positie van de shape **niet** opnieuw toe. Trek X en Y af om coördinaten te krijgen relatief ten opzichte van het ongeroteerde kader.

De geëxtraheerde punten houden geen rekening met de rotatie van de shape die je krijgt via [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation), noch met horizontale of verticale flips. Om de getoonde contour te reproduceren, moet je die transformaties rond het middelpunt van de shape toepassen. Voor gegroepeerde shapes moet je bovendien rekening houden met de coördinatenmapping en transformaties van de groep; ga er niet van uit dat de geëxtraheerde punten de uiteindelijke render‑coördinaten op de dia zijn of dat je een translatie‑ of schaaltransformatie twee keer toepast.

**Inspectie versus bewerking.** Geëxtraheerde arrays beschrijven de contour; wijzigen ervan werkt de oorspronkelijke shape niet bij. Kies deze aanpak wanneer je analyse‑ of teken‑code punt‑/type‑arrays nodig heeft. Gebruik [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) wanneer je geometrie‑commando’s in het lokale coördinatensysteem van de shape wilt of wanneer je de geometrie wilt bewerken. Pas bewerkte paden toe via [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) of [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Java AWT‑shape omzetten naar GeometryPath**

Dit voorbeeld combineert een rechthoekige omtrek met tekst die is omgezet naar geometrie. De omtrek‑methode [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) schakelt de vulling uit. Een [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) maakt de tekstomtrek in een [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). De bijbehorende [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) levert verplaatsings‑, lijn‑, kwadratische, kubieke en sluit‑segmenten, die het voorbeeld opnieuw afspeelt op een [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

De Java‑brug gebruikt expliciete float‑ en byte‑waarden voor de overeenkomstige Java‑parameters. De iterator schrijft coördinaten naar een Java‑float‑array; reflectie leest de bijgewerkte waarden terug in JavaScript. De tekst gebruikt een Arial‑lettertype van 40 points. De omtrek wordt horizontaal 20 points verschoven en geplaatst met de visuele bovenkant 10 points onder de bovenrand van de shape. Het tekstpad wordt gevuld, terwijl de oorspronkelijke rechthoek een omtrek blijft. Het toepassen van beide paden met [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) levert één shape op die de rechthoek en de tekst bevat.

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

**Wat gebeurt er met de vulling en de omlijning nadat de geometrie is vervangen?**

De stijl blijft behouden bij de shape; alleen de contour verandert. De vulling en omlijning worden automatisch op de nieuwe geometrie toegepast.

**Hoe roteer ik een aangepaste shape correct samen met zijn geometrie?**

Gebruik de methode [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) van de shape; de geometrie draait mee omdat deze gekoppeld is aan het eigen coördinatensysteem van de shape.

**Kan ik een aangepaste shape omzetten naar een afbeelding om het resultaat vast te zetten?**

Ja. Exporteer het gewenste [dia](/slides/nl/nodejs-java/convert-powerpoint-to-png/) of de [shape](/slides/nl/nodejs-java/create-shape-thumbnails/) zelf naar een rasterformaat; dit maakt verdere verwerking van complexe geometrieën eenvoudiger.