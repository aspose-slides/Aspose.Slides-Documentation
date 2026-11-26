---
title: Přizpůsobení tvarů prezentace v JavaScriptu
linktitle: Vlastní tvar
type: docs
weight: 20
url: /cs/nodejs-java/custom-shape/
keywords:
- vlastní tvar
- přidat tvar
- vytvořit tvar
- změnit tvar
- geometrie tvaru
- geometrická cesta
- body cesty
- upravit body
- přidat bod
- odebrat bod
- operace úpravy
- zakřivený roh
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte tvary v prezentacích PowerPoint pomocí JavaScriptu a Aspose.Slides pro Node.js: geometrické cesty, zakřivené rohy, složené tvary."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit tvary prezentace v Aspose.Slides úpravou geometrie tvaru pomocí editačních bodů a geometrických cest. Ukazuje, jak pracovat s [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) k úpravě existujících tvarů, provádění základních operací úpravy cest, přidávání nebo odstraňování bodů a aplikaci aktualizované geometrie zpět na tvar.

Také ukazuje, jak vytvořit vlastní a složené tvary, sestavit tvary se zakřivenými rohy, zjistit, zda je geometrie tvaru uzavřená, prozkoumat elementy tvaru a převést obrysy textu Java AWT na geometrické cesty.

## **Změna tvaru pomocí editačních bodů**

V PowerPointu můžete použít **Edit Points** k úpravě čtverce:

* Posunout roh dovnitř nebo ven.
* Upravit zakřivení v bodě.
* Přidat nové body.

Úprava bodů vám umožní změnit obrys tvaru nebo použít existující tvar jako základ pro nový.

## **Tipy pro úpravu tvarů**

![přehled_obrázek](custom_shape_0.png)

Při úpravě tvarů v PowerPointu si pamatujte následující pojmy:

* Tvar (nebo jeho cesta) může být buď uzavřený, nebo otevřený.
* Cesta tvaru se skládá z ukotvených bodů spojených segmenty.
* Segment může být přímý nebo zakřivený. Ukotvené body a ovládací úchyty určují jeho tvar.
* Ukotvené body existují jako rohové body, přímé body nebo hladké body:
  * U rohového bodu se sousední segmenty mohou setkat pod úhlem.
  * U hladkého bodu jsou dva ovládací úchyty zarovnány a stejně vzdálené od ukotveného bodu.
  * U přímého bodu jsou dva ovládací úchyty zarovnány, ale mohou mít různou vzdálenost od ukotveného bodu.
* Přesun ukotvených bodů nebo úprava jejich úchytů mění obrys tvaru.

Pro úpravu tvarů v PowerPointu pomocí editačních bodů poskytuje **Aspose.Slides** třídu [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

* Instance [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) představuje geometrickou cestu objektu [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/).
* Pro získání [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) z instance [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) můžete použít metodu [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths).
* Pro nastavení [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) pro tvar můžete použít tyto metody: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) pro tvary s jednou cestou a [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) pro tvary s více cestami.
* Pro přidání segmentů můžete použít metody pod [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).
* Pomocí metod [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) a [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) můžete nastavit vzhled geometrické cesty.
* Pomocí metody [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) můžete získat geometrickou cestu [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) jako pole segmentů cesty.
* Pro přístup k dalším možnostem přizpůsobení geometrie tvaru můžete číst [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) pomocí jeho [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) a přehrát segmenty na [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **Jednoduché operace úpravy**

Použijte následující metody k úpravě geometrické cesty. Přetížení, která přijímají index, vloží segment na nultou pozici v poli segmentů cesty.

| Operace | Metoda |
| --- | --- |
| Přidat nebo vložit přímou čáru. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Přidat nebo vložit kubickou Bézierovu křivku se dvěma ovládacími body a koncovým bodem. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Přidat nebo vložit kvadratickou Bézierovu křivku s jedním ovládacím bodem a koncovým bodem. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Přidat eliptický oblouk se zadanými rozměry a úhly ve stupních. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Uzavřít aktuální figurku spojením koncového bodu se startovacím bodem. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Nastavit počáteční bod figury. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Odstranit segment na nultém indexu. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Přidání vlastních bodů do tvaru**

Tento příklad vloží dva body do obdélníkového tvaru pomocí [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) a aplikuje upravenou cestu pomocí [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). Souřadnice jsou lokální k tvaru: oba nové body jsou uprostřed, 100 bodů od levého okraje a 50 bodů od horního. Indexy segmentů 1 a 4 je umístí na horní a dolní okraj, čímž tyto okraje stáhnou dovnitř.

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
![příklad1_obrázek](custom_shape_1.png)

## **Odstranění bodů z tvaru**

Tento příklad mění obrys ve tvaru srdce odstraněním segmentu na nultém indexu 2 pomocí [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). Aplikace upravené cesty pomocí [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) aktualizuje konturu tvaru.

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
![příklad2_obrázek](custom_shape_2.png)

## **Vytvoření vlastního tvaru**

Tento příklad vytvoří pětihrotou hvězdu pomocí [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). Střídavé vnější a vnitřní poloměry 100 a 50 bodů definují špičky a zapuštění; krok 72 stupňů rovnoměrně rozmístí pět špiček. Cesta je uzavřena pomocí [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) a aplikována na obdélníkový tvar pomocí [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), čímž nahradí jeho obrys.

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
![příklad3_obrázek](custom_shape_3.png)

## **Vytvoření složeného vlastního tvaru**

Tento příklad definuje dva uzavřené objekty [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) pro horní a dolní třetinu tvaru. Aplikace obou cest pomocí [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) vytvoří jedinečný složený tvar s mezerou přes střední třetinu.

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
![příklad4_obrázek](custom_shape_4.png)

## **Vytvoření vlastního tvaru se zakřivenými rohy**

Tento příklad kombinuje přímé segmenty s [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo), aby vytvořil tvar se zakřivenými rohy dovnitř. Velikost každého rohu určuje šířku a výšku oblouku v bodech a úhel -90 stupňů kreslí proti směru hodinových ručiček čtvrtkruh. Dokončená cesta je aplikována pomocí [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), a prezentace je uložena ve formátu PPTX.

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

## **Zjistit, zda je geometrie tvaru uzavřená**

Následující pomocná funkce kontroluje, zda každá neprázdná geometrická cesta končí uzavíracím segmentem. Načte [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData), a porovná poslední segmentův [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) s [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). Vrátí false, pokud neexistují neprázdné cesty. Tato kontrola zkoumá poslední příkaz každé cesty; neinspektuje každou podfiguru uvnitř cesty. Příklad vypíše `true` pro obdélník.

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

## **Prozkoumání příkazů geometrické cesty**

Stáhněte [contour.pptx](contour.pptx) a umístěte jej do pracovního adresáře aplikace. První tvar na první snímku má rovnou horní hranu, kubickou Bézierovu křivku a rovnou uzavírací hranu. Použijte [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths), abyste načetli cesty tvaru, a [getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData), abyste přečetli segmenty každé cesty ve pořadí kreslení. Pro každý segment [getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) určuje příkaz a stanoví, jak interpretovat hodnoty vrácené metodou [getSegmentData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getSegmentData).

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

Tvar leží na (200, 100) bodech na snímku. Zobrazené souřadnice jsou lokální k tvaru, s (0, 0) v levém horním rohu, x roste doprava a y roste dolů. Uzavírací segment se vrací na počáteční bod bez dalších souřadnic.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```
![PowerPoint tvar s rovnou horní hranou, zakřivenou hranou od pravého horního ke spodnímu levému a rovnou levou hranou](contour.png)

## **Extrahování a prozkoumání elementů tvaru**

Použijte [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements), abyste prozkoumali existující tvar jako elementy obsahující body cesty a typy bodů. Použijte každou vrácenou [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/), k získání polí bodů a typů prostřednictvím metod [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) a [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes). Toto znázornění je užitečné pro analýzu kontury nebo předání geometrie do vlastních kreslicích nástrojů.

Příklad otevírá input.pptx, najde první geometrický tvar přímo na první snímku a vytiskne jeho segmenty cesty. Použijte prezentaci obsahující tvar s přímými i zakřivenými segmenty, abyste viděli oba typy výstupu. Nepřepočítává uvnitř skupin.

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
                const pointType = types[i] & 0x07; // Zachovat typ segmentu, vyjma příznaků.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Spotřebovat oba řídící body i koncový bod.
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

Pole odpovídají podle indexu: `points[i]` je bod a `types[i]` popisuje jeho roli. Typ `0` začíná figurku a typ `1` kreslí čáru od předchozího bodu k aktuálnímu bodu. Kubický Bézier segment začíná na předchozím koncovém bodu a používá tři po sobě jdoucí záznamy typu `3`: dva ovládací body následované novým koncovým bodem. Smyčka spotřebuje těchto tři záznamy najednou a kontroluje koncový bod na uzavření.

Typy bodů také obsahují příznaky. Maskujte s `0x07` k určení typu segmentu a testujte `0x80` samostatně k detekci uzavřené podcesty. Například `129` (`0x81`) znamená koncový bod čáry, který uzavírá podcestu, a `131` (`0x83`) znamená koncový bod Bézieru, který ji uzavírá. Java ukládá tyto příznaky do podepsaných bajtů; maskování zachovává zamýšlené bitové hodnoty. Porovnání surové hodnoty pouze s `1` nebo `3` by tyto případy minulo. Další příznaky, jako pomlčka (`0x10`) a marker (`0x20`), nemění základní typ segmentu.

**Souřadnice a transformace.** Body se měří v bodech (1/72 palce), s X rostoucím doprava a Y rostoucím dolů. Pro negroupovaný tvar již extrahované souřadnice zahrnují pozici vrácenou metodou [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) a [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) a odrážejí jeho aktuální šířku a výšku. Například neotočený obdélník na `(100, 200)` s velikostí `120 × 80` má hranice kontury `(100, 200)`–`(220, 280)`. Nepřidávejte pozici tvaru znovu. Odečtěte jeho X a Y pro získání souřadnic relativních k jeho neotočenému rámci.

Extrahované body neaplikují rotaci tvaru, vrácenou metodou [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation), ani horizontální a vertikální převrácení. Pro reprodukci zobrazené kontury aplikujte tyto transformace kolem středu tvaru. U skupinových tvarů také zohledněte mapování souřadnic skupiny a transformace; nepředpokládejte, že extrahované body jsou finální vykreslené souřadnice snímku nebo nepoužívejte translační či škálovací operaci dvakrát, pokud již je zahrnuta ve rámci dítěte.

**Inspekce vs. úprava.** Extrahovaná pole popisují konturu; jejich změna neaktualizuje původní tvar. Zvolte tento přístup, pokud vaše analýza nebo kreslicí kód potřebuje pole bodů/typů. Použijte [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths), pokud potřebujete geometrické příkazy v lokálním souřadnicovém systému tvaru nebo chcete upravit jeho geometrii. Aplikujte upravené cesty přes [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) nebo [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Převod Java AWT tvaru na GeometryPath**

Tento příklad kombinuje obdélníkový obrys s textem převedeným na geometrii. Metoda [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) obrysu zakáže jeho výplň. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) vytvoří obrys textu v [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Jeho [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) poskytuje příkazy move, line, quadratic, cubic a closing, které příklad přehrává na [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

Java most používá explicitní float a byte hodnoty pro odpovídající Java parametry. Iterátor zapisuje souřadnice do Java float pole; reflexe načte jeho aktualizované hodnoty zpět do JavaScriptu. Text používá 40-bodové písmo Arial. Obrys je posunut o 20 bodů horizontálně a umístěn tak, že jeho vizuální horní část je 10 bodů pod horní hranou tvaru. Textová cesta je vyplněná, zatímco původní obdélník zůstává obrysem. Aplikace obou cest pomocí [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) vytvoří jeden tvar obsahující obdélník a text.

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
            case 0: // Přesunout na.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // Čára k.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // Kvadratická Bézierova křivka.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Kubická Bézierova křivka.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // Uzavřít figuru.
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
![příklad5_obrázek](custom_shape_5.png)

## **Často kladené otázky**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstává u tvaru; mění se jen kontura. Výplň a obrys jsou automaticky aplikovány na novou geometrii.

**Jak správně otočit vlastní tvar společně s jeho geometrií?**

Použijte metodu [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) tvaru; geometrie se otáčí s tvarem, protože je vázána na vlastní souřadnicový systém tvaru.

**Mohu převést vlastní tvar na obrázek, aby byl výsledek „uzamčen“?**

Ano. Exportujte požadovanou oblast [slide](/slides/cs/nodejs-java/convert-powerpoint-to-png/) nebo samotný [shape](/slides/cs/nodejs-java/create-shape-thumbnails/) do rastrového formátu; to zjednoduší další práci se složitými geometriemi.