---
title: Prezentációs alakzatok kezelése JavaScriptben
linktitle: Alakzatmanipuláció
type: docs
weight: 40
url: /hu/nodejs-java/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentációs alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat ID lekérése
- alakzat alternatív szövege
- alakzat állítási pont
- előre beállított alakzat állítása
- alakzat geometria
- alakzat elrendezés formátumok
- alakzat SVG-ként
- alakzat SVG-be
- alakzat igazítása
- alakzat tükrözése
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan azonosíthatja, állíthatja, klónozhatja, eltávolíthatja, elrejtheti, átrendezheti, exportálhatja, igazíthatja és tükrözheti a prezentációs alakzatokat az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java a dián lévő alakzatokat egy rendezett [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/) formájában ábrázolja. A gyűjtemény egyaránt a hely, ahol alakzatokat kereshet és módosíthat, valamint a rétegezési sorrend forrása: a `0` indexű alakzat a leghátsó, míg az utolsó indexű a legelöl lévő alakzat.

Ez a cikk ezt a modellt követi. Először bemutatja, hogyan azonosíthat egy alakzatot megbízhatóan és módosíthatja az előre beállított alakzat‑állítási pontokat, majd megmutatja, hogyan klónozhat, távolíthat el, rejthet el és módosíthatja a sorrendet. Az utolsó szakaszok a layout‑szintű formázást, az SVG exportot, a beállítást és a tükrözést fedik le. Minden példa önálló, így csak a munkafolyamatához szükséges műveleteket használhatja.

## **Alakzatok azonosítása és keresése**

A gyűjtemény indexei kényelmesek egy ismert fájl feldolgozásakor, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja az indexét. Válasszon azonosítót a prezentáció írói és karbantartási módja szerint:

- [Name](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getname/) hasznos fejlesztő által vezérelt sablonoknál, és könnyen megtekinthető a PowerPoint Kiválasztási ablaktáblájában. A neveket szerkeszthető, de nem garantált a egyediségük, ezért nevezzük el konvenció szerint, ha a kód rá támaszkodik.
- [AlternativeText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getalternativetext/) akkor hasznos, ha egy hozzáférhetőségi leírás vagy egy szerző által megadott címke már azonosítja az alakzatot. A felhasználók számára látható, lokalizálható vagy hozzáférhetőségi okokból átírható, és nem garantált a egyediség. Ne használja csendben jelentős hozzáférhetőségi szövegként adatbáziskulcsot.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) egy csak‑olvasásos azonosító, amely a dián belül egyedi, és a PowerPoint interop által használt alakzat‑azonosítónak felel meg. Használja, ha PowerPoint‑tel integrál, vagy ha egyértelmű hivatkozásra van szükség az alakzat élettartama alatt. Egy klónozott vagy újra létrehozott alakzat másik alakzat, és saját azonosítót kap.

A kapcsolódó [getUniqueId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getuniqueid/) metódus egy prezentáció‑szintű azonosítót ad vissza, de ez az azonosító bővítmények számára szánt, és átadható. Nem szabad állandó külső kulcsként kezelni. Ha hosszú távú azonosításra van szükség, tárolja a leképezést az alkalmazás adatában, és ellenőrizze, hogy a várt alakzat még létezik‑e.

Az alábbi példa név alapján keres pontos összehasonlítással, és a diára vonatkozó interop‑azonosítót adja vissza. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt az eredményt jelenti ahelyett, hogy a helytelen objektummal folytatná.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Amikor egy művelet alakzat‑típusra vonatkozik, ellenőrizze a futásidejű osztályt, mielőtt típus‑specifikus tagokat használna. Ez a példa csak akkor frissíti a szöveget és az alternatív szöveget, ha a megnevezett objektum egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/).

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Alakzat előre beállított állítások azonosítása és módosítása**

Az előre definiált geometriai alakzatok olyan állítási pontokat fedhetnek fel, amelyek a sarkok méretét, a nyíl arányait vagy az ív szögeit szabályozzák. Ezeket a csak‑olvasásos [GeometryShape.getAdjustments](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/geometryshape/) gyűjteményen keresztül érheti el. Maga a gyűjtemény az alakzattól származik, de minden [AdjustValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/adjustvalue/) egy módosítható értéket tartalmaz.

Ne csak egy rögzített gyűjtemény‑indexre támaszkodjon. Iteráljon végig az állításokon, és vizsgálja meg a csak‑olvasásos [getType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/adjustvalue/) metódust, amelynek [ShapeAdjustmentType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapeadjustmenttype/) értéke leírja, mit szabályoz az állítás. A csak‑olvasásos [getName](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/adjustvalue/getname/) metódus további azonosítási információt nyújt, és különösen hasznos, ha egy előre beállítás több azonos szemantikai típusú állítást tartalmaz.

Használja azt az érték‑módszert, amely megfelel az állítás jelentésének:

| Állítás típusa | Cél | Módosítandó érték |
|---|---|---|
| `CornerSize` | Lekerekített sarkok mérete | [setRawValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Nyílfarok vastagsága | `setRawValue` |
| `ArrowheadLength` | Nyílhegy hossza | `setRawValue` |
| `ArrowheadWidth` | Nyílhegy szélessége | `setRawValue` |
| `StartAngle` | Körív vagy szakasz kezdőszöge | [setAngleValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Körív vagy szakasz végszöge | `setAngleValue` |

A `getType` és a `getName` csak‑olvasásos információt ad. A `getRawValue` és a `setRawValue` egy egész számot használ a preset natív geometriai egységében, míg a `getAngleValue` és a `setAngleValue` fokban megadott szöget használ. Az állítások száma, sorrendje, jelentése és érvényes tartománya a [GeometryShape.getShapeType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/geometryshape/) előre beállítástól függ. Egy presethez érvényes érték egy másiknál érvénytelen vagy más hatást válthat ki.

Amikor a `getType` `ShapeAdjustmentType.Custom`‑t ad vissza, az API nem ismeri fel a szabványos szemantikai jelentést. Vizsgálja meg a `getName`‑t, a preset típusát és a meglévő értéket, és hagyja az állítást változatlanul, hacsak a várt jelentés és tartomány nem ismert. Még felismert típusoknál is ellenőrizze, hogy ugyanaz a típus többször is előfordul‑e, mielőtt értéket választana. A [Connector](/slides/hu/nodejs-java/connector/) cikk bemutatja ezt a helyzetet a csatlakozó ívek állításainál.

Az alábbi teljes példa három előre beállított alakzat alap és módosított változatát hozza létre. A minden egyes állításon végig iterál, jelentést készít a nevéről és típusáról, a `setRawValue`‑val mérettel kapcsolatos értékeket változtat, a `setAngleValue`‑val szögeket módosít, és elmenti az eredményt. A bal oszlop az alap geometriai alakzatot tartja; a jobb oszlop a módosított lekerekített téglalapot, a négyszögletű nyilat és a körívet mutatja.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // Fejléceket ad hozzá az alap és a módosított alakzatoszlopokhoz.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A szemantikai típus ellenőrzése érték módosítása előtt egyértelművé teszi a kód szándékát, és elkerüli, hogy egy adott gyűjtemény‑indexet különböző preset alakzatok között azonos jelentésűnek tekintsen.

## **Alakzatgyűjtemény módosítása**

A hozzáad, klónoz, eltávolít és átrendez metódusok azonnal a gyűjteményen működnek. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne számítson tovább a művelet előtt rögzített indexekre.

### **Alakzat klónozása**

[addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/addclone/) egy független másolatot hoz létre, és a célgyűjtemény végére fűzi. [insertClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/insertclone/) szintén másolatot készít, de egy megadott z‑sorrend‑indexhez helyezi. A koordinátákat elfogadó túlterhelések a méretét változtatás nélkül mozgatják a klónt; a szélességgel és magassággal rendelkező túlterhelések átméretezhetik is.

A példa egy cél diát hoz létre, egy címkézett téglalapot klónoz a frontra, majd egy második klónt szúr be a hát oldalra. A klónok bármelyikének módosítása nem érinti a forrás alakzatot.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A klónozás másolja az alakzat tartalmát és formázását, beleértve a nevét és az alternatív szöveget is. Ha ezeknek az értékeknek egyedinek kell lenniük, adjon új logikai azonosítókat a klónnak. A komplex alakzatok erőforrásait a prezentáció kezeli, de a klón egy új gyűjtemény‑elem, új alakzat‑azonossággal.

### **Alakzatok eltávolítása**

[remove](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/remove/) egy konkrét alakzat‑objektumot töröl a gyűjteményéből. Ha indexelt iteráció során több egyezést távolít el, haladjon a vég felől, hogy a megmaradt indexek érvényben maradjanak.

Ez a példa minden megadott névvel rendelkező alakzatot eltávolít. A jelenlegi indexnél olvassa az alakzatot, és nem feltételez konkrét típusú alakzatot.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Eltávolítás után az alakzatok száma és a későbbi alakzatok indexei megváltoznak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak, mint a mentett indexek. Vegye figyelembe a csatlakozókat, animációkat és egyéb prezentációs elemeket is, amelyek a törölt objektumra hivatkozhatnak; egy látható alakzat eltávolítása több mint a dia megjelenését is módosíthatja.

### **Alakzat elrejtése**

A [Hidden](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/sethidden/) `true`‑ra állítása megtartja az alakzatot a gyűjteményben, de megakadályozza, hogy a normál diavetítésben megjelenjen. Az indexe, formázása és tartalma továbbra is elérhető a kód számára, ezért a rejtés alkalmas opcionális elemekhez, amelyek később visszaállíthatók.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A rejtés nem törlés vagy biztonsági intézkedés. Az objektum továbbra is felfedezhető és feloldható felhasználó vagy kód által, és része marad a prezentáció fájlnak.

### **Z‑sorrend módosítása**

Átfedő alakzatok a gyűjtemény sorrendjében kerülnek festésre. A [reorder](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/reorder/) egy meglévő alakzatot a cél indexre helyez át klónozás nélkül. A `0` index a hátsó, a `size() - 1` az első.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Először a téglalap jön létre, és kezdetben a ellipszis mögött helyezkedik el. Ha a végső indexre mozgatjuk, előre kerül. A z‑sorrendet a kapcsolódó alakzatok hozzáadása vagy klónozása után véglegesítse, mivel ezek a műveletek új gyűjtemény‑elemeket fűznek hozzá vagy illesztenek be, és megváltoztathatják a kívánt rétegsorrendet.

## **Layout‑diákon lévő alakzatok vizsgálata**

A normál diák, a layout‑diákok és a mesterdiák külön alakzatgyűjteménnyel rendelkeznek. Egy layout‑gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonló pozícióban lévő alakzat egy normál dián. Vizsgálja a layout‑alakzatokat, ha a layout által biztosított formázást kell megérteni vagy módosítani.

Az alábbi példa minden layout‑alakzat [FillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getfillformat/) és [LineFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getlineformat/) értékét olvassa be, anélkül, hogy azt feltételezné, hogy minden alakzat `AutoShape`.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Egy layout szerkesztése több, azt használó diát is befolyásolhat. Mielőtt egy layout‑alakzatot módosítaná, határozza meg, hogy egy normál dia örökli‑e az objektumot vagy helyi felülírást tartalmaz‑e, és tesztelje az összes olyan diát, amely az adott layout‑ot használja.

## **Alakzat exportálása SVG‑ként**

A [writeAsSvg](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/writeassvg/) egy alakzat renderelt tartalmát írja egy streame‑be. Az eredmény csak az alakzatot tartalmazza, nem a teljes dia hátterét vagy a szomszédos alakzatokat.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Tartsa nyitva a prezentációt a renderelés közben. A kimenet az alakzat formázásától, valamint a betűtípusok és képek erőforrásaitól függ. Ha a teljes kompozícióra van szüksége, exportálja a diát, ne pedig egy önálló alakzatot. A hívó birtokolja a stream‑et, és azt be kell zárnia.

## **Alakzatok igazítása**

A [SlideUtil.alignShapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideutil/alignshapes/) túlterhelései vagy az összes alakzatot, vagy a kiválasztott gyűjtemény indexeit igazítják. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapesalignmenttype/) meghatározza az él, a középvonal vagy a elosztási módot. Állítsa az `alignToSlide`‑t `true`‑ra a dia széleihez igazításhoz; `false` esetén a kiválasztott alakzatok egymáshoz viszonyított igazítására.

Ez a példa három alakzatot igazít a dia felső éléhez. A visszakapott alakzat‑referenciákat az igazítás előtt az aktuális indexeikre konvertálja.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az igazítás a pozíciókat változtatja, nem a z‑sorrendet. A relatív igazításhoz általában legalább két alakzat szükséges, míg a vízszintes vagy függőleges elosztáshoz elegendő alakzat kell legyen a távolság meghatározásához. Újra kell számolni az indexeket, ha a metódus meghívása előtt módosítja a gyűjteményt.

## **Alakzat tükrözése**

A [ShapeFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapeframe/) osztály tárolja a pozíciót, méretet, a vízszintes és függőleges tükrözés beállításait és a forgatást. A `getFlipH` és `getFlipV` értékei a [NullableBool](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/nullablebool/) típusba tartoznak: `True` engedélyezi a tükrözést, `False` letiltja, a `NotDefined` pedig az nem definiált/ alapértelmezett állapotot tartja meg.

Az alábbi bemeneti prezentáció egy nem tükrözött alakzatot tartalmaz.

![A forma a tükrözés előtt](shape_to_be_flipped.png)

A példa minden más keretértéket megőriz, és csak a két tükrözési beállítást cseréli le. Ez fontos, mert egy új [Frame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/setframe/) hozzárendelése a teljes keretet felülírja.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A mentett forma vízszintesen és függőlegesen tükröződik, miközben megőrzi a pozíciót, méretet és forgást.

![A forma a tükrözés után](flipped_shape.png)

## **GYIK**

**Használjak gyűjtemény‑indexet alakzat‑azonosítóként?**

Csak rövid életű feldolgozáskor, amikor a gyűjtemény nem változik az index használata előtt. A szerzői sablonokhoz inkább ellenőrzött `Name` vagy `AlternativeText` konvenciót használjon, vagy `OfficeInteropShapeId`‑t a diához kötött interop munkához.

**Eltávolítja-e a rejtett alakzat a z‑sorrendet?**

Nem. Egy rejtett alakzat a gyűjteményben marad ugyanazon az indexen. Megtalálható, átrendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik alakzat előtt?**

Az `addClone` a klónt a gyűjtemény végére fűzi, ami a z‑sorrend első helye. Az `insertClone` segítségével választhatja ki a kezdeti indexet, vagy a `reorder`‑t használhatja az összes alakzat hozzáadása után.

**Használhatok rögzített indexet egy előre beállított alakzat‑állítás azonosításához?**

Csak akkor, ha a pontos presetet és a gyűjtemény‑elrendezést előzetesen ellenőrizte. Inkább iteráljon a `GeometryShape.getAdjustments`‑en, és ellenőrizze az `AdjustValue.getType`‑ot; ha ugyanaz a szemantikai típus többször fordul elő, használja az `AdjustValue.getName`‑t további információként.