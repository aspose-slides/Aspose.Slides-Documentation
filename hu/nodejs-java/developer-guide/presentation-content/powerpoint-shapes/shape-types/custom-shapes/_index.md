---
title: Prezentációs alakzatok testreszabása JavaScriptben
linktitle: Egyedi alakzat
type: docs
weight: 20
url: /hu/nodejs-java/custom-shape/
keywords:
- egyedi alakzat
- alakzat hozzáadása
- alakzat létrehozása
- alakzat módosítása
- alakzat geometria
- geometriai útvonal
- útvonal pontok
- szerkesztési pontok
- pont hozzáadása
- pont eltávolítása
- szerkesztési művelet
- íves sarok
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Alakzatok létrehozása és testreszabása PowerPoint prezentációkban JavaScript és Aspose.Slides for Node.js használatával: geometriai útvonalak, íves sarkok, összetett alakzatok."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a prezentáció alakzatokat az Aspose.Slides-ban a forma geometriájának szerkesztésével szerkesztési pontok és geometriai útvonalak segítségével. Megmutatja, hogyan használható a [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) a meglévő alakzatok módosításához, alapvető útvonal-szerkesztési műveletek végrehajtásához, pontok hozzáadásához vagy eltávolításához, valamint a frissített geometria visszaalkalmazásához egy alakzatra.

Továbbá bemutatja, hogyan hozhatunk létre egyedi és összetett alakzatokat, alakzatokat íves sarkokkal, hogyan határozhatjuk meg, hogy egy forma geometria zárt‑e, hogyan vizsgálhatjuk meg az alakzat elemeit, és hogyan konvertálhatók a Java AWT szövegkontúrok geometriai útvonalakká.

## **Alakzat módosítása szerkesztési pontokkal**

PowerPointban a **Szerkesztési pontok** használatával módosíthat egy négyzetet:

* Egy sarkot befelé vagy kifelé mozgathat.
* A pont görbületét állíthatja.
* Új pontokat vehet fel.

A pontok szerkesztése lehetővé teszi, hogy módosítsa egy alakzat körvonalát, vagy egy meglévő alakzatot újként használja fel.

## **Alakzat szerkesztési tippek**

![overview_image](custom_shape_0.png)

PowerPoint‑alkotzatok szerkesztésekor tartsa szem előtt ezeket a fogalmakat:

* Egy alakzat (vagy annak útvonala) lehet zárt vagy nyitott.
* Egy alakzat útvonala horgonypontokból áll, amelyeket szegmensek kapcsolnak össze.
* Egy szegmens lehet egyenes vagy íves. A horgonypontok és a vezérlőkarok határozzák meg alakját.
* A horgonypontok lehetnek sarokpontok, egyenes pontok vagy sima pontok:
  * Sarokpontnál a szomszédos szegmensek szöggel találkozhatnak.
  * Simapontnál a két vezérlőkar egy vonalban van, és egyenlő távolságra helyezkednek el a horgonyponttól.
  * Egyenes pontnál a két vezérlőkar szintén egy vonalban van, de távolságuk eltérhet a horgonyponttól.
* Horgonypontok mozgatása vagy a karok módosítása megváltoztatja az alakzat körvonalát.

A PowerPoint‑alakzatok szerkesztéséhez **Aspose.Slides** a [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) osztályt biztosítja.

* Egy [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) példány a [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) objektum geometriai útvonalát reprezentálja.
* A [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) lekéréséhez a [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) példányból használhatja a [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) metódust.
* Egy alakzat [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) beállításához használhatja ezeket a metódusokat: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) egyetlen útvonallal rendelkező alakzatokhoz és [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) több útvonallal rendelkező alakzatokhoz.
* Szegmensek hozzáadásához használhatja a [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) alatti metódusokat.
* A [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) és a [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) metódusokkal beállíthatja egy geometriai útvonal megjelenését.
* A [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) metódussal egy [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) geometriai útvonalát tömbként (útvonal‑szegmensek) kaphatja meg.
* További alakzat‑geometria testreszabási lehetőségekhez olvashat egy [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)-t a saját [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)‑jén keresztül, és a szegmenseket újra lejátszhatja egy [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)‑on.

## **Egyszerű szerkesztési műveletek**

Az alábbi metódusokkal szerkeszthet egy geometriai útvonalat. Az indexet elfogadó túlterhelések egy szegmenst a megadott, nullától induló pozícióba szúrnak be a szegmens‑tömbben.

| Művelet | Metódus |
| --- | --- |
| Egyenes vonal hozzáadása vagy beszúrása. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Két vezérlőponttal és egy végponttal rendelkező köb‑Bézier‑görbe hozzáadása vagy beszúrása. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Egy vezérlőponttal és egy végponttal rendelkező kvadratikus Bézier‑görbe hozzáadása vagy beszúrása. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Elliptikus ív hozzáadása a megadott méretekkel és fokokban kifejezett szögekkel. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Az aktuális ábra lezárása úgy, hogy a végpontját összeköti a kezdőponttal. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Egy ábra kiindulási pontjának beállítása. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Egy szegmens eltávolítása nullától induló index alapján. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Egyéni pontok hozzáadása egy alakzathoz**

Ez a példa két pontot szúr be egy téglalap alakzatba a [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) segítségével, majd a szerkesztett útvonalat a [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) alkalmazza. A koordináták az alakzathoz relatívak: mindkét új pont a középpontjában helyezkedik el, 100 pontbalra és 50 pont lejjebb a bal és felső szélről. Az 1‑es és 4‑es szegmensindexek a felső és alsó élre helyezik őket, így azok befelé húzódnak.

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

## **Pontok eltávolítása egy alakzatról**

Ez a példa egy szív alakú kontúrt módosít azzal, hogy a [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) metódussal eltávolítja a 2‑es nullától induló indexű szegmenst. A módosított útvonal alkalmazása a [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) metódussal frissíti az alakzat körvonalát.

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

## **Egyéni alakzat létrehozása**

Ez a példa egy ötágú csillagot épít a [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) segítségével. Az 100 és 50 pont közötti váltakozó külső‑ és belső‑sugár definiálja a csúcsokat és a bemélyüléseket; a 72‑fokos lépés egyenletesen elosztja az öt csúcsot. Az útvonalat a [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) metódussal zárja le, és egy téglalap alakzatra alkalmazza a [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) segítségével, felváltva az eredeti körvonalat.

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

## **Összetett egyéni alakzat létrehozása**

Ez a példa két zárt [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) objektumot definiál egy alakzat felső és alsó harmadjához. Mindkét útvonal alkalmazása a [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) metódussal egyetlen összetett alakzatot hoz létre, amelynek középső harmadja üresen marad.

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

## **Egyéni alakzat íves sarkokkal**

Ez a példa egyenes szegmenseket kombinál a [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) metódussal, hogy egy befelé ívelt sarkokkal rendelkező alakzatot hozzon létre. Minden sarkméret a ív szélességét és magasságát pontokban adja meg, a -90‑fokos ív pedig egy óramutató járásával ellentétes negyed‑ellipszist rajzol. A kész útvonalat a [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) alkalmazza, majd a prezentációt PPTX formátumban menti.

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

## **Megállapítás, hogy a forma geometria zárt‑e**

Az alábbi segédprogram ellenőrzi, hogy minden nem üres geometriai útvonal záró szegmenssel végződik‑e. A [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) segítségével beolvassa az adatot, és a végső szegmens [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) értékét összehasonlítja a [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/) típussal. Ha nincs nem üres útvonal, hamis értékkel tér vissza. Ez az egyes útvonalak végső parancsát vizsgálja; nem elemzi a belső alábrákat. A példa a `true` értéket írja ki egy téglalap esetén.

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

## **Alakzat elemeinek kinyerése és vizsgálata**

Használja a [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) metódust, hogy egy meglévő alakzatot elemekként vizsgáljon, melyek útvonal‑pontokat és ponttípusokat tartalmaznak. Az egyes visszaadott [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) objektumokkal a [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) és a [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes) metódusokkal nyerheti ki a pont‑ és típus‑tömböket. Ez a reprezentáció hasznos kontúrelemzéshez vagy a geometria egyedi rajzolóeszközöknek való átadásához.

A példa megnyitja az input.pptx‑et, megtalálja az első geometriai alakzatot az első diáron, és kiírja annak szegmens‑adatait. Használjon egy prezentációt, amelynek alakzata egyenes és íves szegmenseket is tartalmaz, hogy mindkét típusú kimenetet lássa. A csoportokon belül nem keres.

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
                const pointType = types[i] & 0x07; // Tartsa meg a szegmens típusát, a jelzők nélkül.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Fogyassza el mindkét vezérlőpontot és a végpontot.
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

A tömbök index szerint egyeznek: a `points[i]` egy pont, a `types[i]` pedig annak szerepét írja le. Az `0` típus egy ábra kezdete, az `1` típus egy vonalat rajzol az előző pontból az aktuálisba. Egy köb‑Bézier‑szegmens a korábbi végpontból indul, és három egymást követő `3`‑as típusú bejegyzést használ: két vezérlőpontot és az új végpontot. A ciklus ezeket a három bejegyzést együtt fogyasztja, és a végpontot ellenőrzi a lezárásra.

A ponttípusokban flag‑ek is vannak. Maszkoljon `0x07`‑el a szegmens‑típus azonosításához, és a `0x80`‑at külön tesztelje a zárt alútvonal felismeréséhez. Például a `129` (`0x81`) egy vonalvégpont, amely lezár egy alútvonalat, a `131` (`0x83`) pedig egy Bézier‑végpont, amely szintén lezár. A Java ezeket a flag‑eket előjeles bájtokként tárolja; a maszkolás megőrzi a kívánt bitértékeket. Ha csak a nyers értékkel (`1` vagy `3`) hasonlítjuk össze, ezek a esetek kimaradnak. Egyéb flag‑ek, mint a szaggatás (`0x10`) és a marker (`0x20`), nem változtatják az alap szegmens‑típust.

**Koordináták és transzformációk.** A pontok pontban (1/72 hüvelyk) vannak mérve, az X jobbra, a Y lefelé növekszik. Egy nem csoportosított alakzat esetén a kinyert koordináták már tartalmazzák a [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) és [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) által visszaadott pozíciót, és tükrözik a jelenlegi szélességet és magasságot. Például egy `(100, 200)` bal‑felső sarokkal és `120 × 80` mérettel rendelkező, nem elforgatott téglalap körvonalának határa `(100, 200)`–`(220, 280)`. Ne adja hozzá újra az alakzat pozícióját. Vonja le az X‑et és Y‑t, hogy a koordinátákat az elforgatás nélküli kerethez viszonyítsa.

A kinyert pontok nem alkalmazzák az alakzat [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation) által visszaadott forgását, illetve a vízszintes és függőleges tükrözéseket. A megjelenített kontúr reprodukálásához ezeket a transzformációkat az alakzat középpontja körül kell alkalmazni. Csoportos alakzatok esetén vegye figyelembe a csoport koordinátatérképét és transzformációit; ne tételezze, hogy a kinyert pontok már a végleges renderelt diákoordináták, és ne alkalmazzon kétszeres eltolást vagy méretezést, ha már a gyermek keretben tükrözve vannak.

**Vizsgálat vs. szerkesztés.** A kinyert tömbök a kontúrt írják le; azok módosítása nem frissíti az eredeti alakzatot. Ezt a megközelítést akkor válassza, ha elemzési vagy rajzoló kódjának pont/típus tömbökre van szüksége. Használja a [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) metódust, ha a geometriai parancsokra van szüksége az alakzat helyi koordináta‑rendszerében, vagy ha a geometria szerkesztése a cél. A szerkesztett útvonalakat alkalmazza a [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) vagy a [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) segítségével.

## **Java AWT Shape konvertálása GeometryPath‑ré**

Ez a példa egy téglalap körvonalát kombinálja a geometriává konvertált szöveggel. A körvonal [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) metódusa letiltja a kitöltést. Egy [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) hozza létre a szöveg kontúrját egy [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) objektumban. A [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) mozgás, vonal, kvadratikus, köb és záró szegmenseket ad, amelyeket a példa újra lejátszik egy [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)‑on.

A Java‑kapu explicit float és byte értékeket használ a megfelelő Java‑paraméterekhez. Az iterátor koordinátákat ír egy Java float tömbbe; a reflexió visszaolvassa a frissített értékeket JavaScript‑be. A szöveg 40‑pontos Arial betűtípussal van. A körvonal 20 ponttal vízszintesen el van tolva, és a vizuális teteje 10 ponttal a forma felső szélétől helyezkedik el. A szöveg útvonala ki van töltve, míg az eredeti téglalap csak körvonal marad. Mindkét útvonal alkalmazása a [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) segítségével egyetlen alakzatot hoz létre, amely a téglalapot és a szöveget is tartalmazza.

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
            case 0: // Mozgatás.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // Vonal ide.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // Quadratikus Bézier görbe.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Köbös Bézier görbe.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // Ábra lezárása.
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

## **GYIK**

**Mi történik a kitöltéssel és a körvonallal, miután a geometriát lecserélik?**

A stílus megmarad az alakzaton; csak a kontúr változik. A kitöltés és a körvonal automatikusan az új geometriára kerül alkalmazásra.

**Hogyan lehet helyesen elforgatni egy egyéni alakzatot a geometriájával együtt?**

Használja az alakzat [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) metódusát; a geometria az alakzattal együtt forog, mivel az az alakzat saját koordináta‑rendszeréhez van kötve.

**Átkonvertálhatom a saját alakzatot képpé, hogy „lezárom” az eredményt?**

Igen. Exportálja a szükséges [slide](/slides/hu/nodejs-java/convert-powerpoint-to-png/) területet vagy maga a [shape](/slides/hu/nodejs-java/create-shape-thumbnails/) képként raszteres formátumba; ez egyszerűsíti a komplex geometriákkal való további munkát.