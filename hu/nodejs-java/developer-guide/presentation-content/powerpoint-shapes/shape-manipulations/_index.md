---
title: Prezentáció alakzatok kezelése JavaScriptben
linktitle: Alakzatkezelés
type: docs
weight: 40
url: /hu/nodejs-java/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentáció alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat ID lekérése
- alakzat alternatív szövege
- alakzat elrendezési formátumok
- alakzat SVG-ként
- alakzat SVG-be
- alakzat igazítása
- alakzat tükrözése
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Tanulja meg, hogyan azonosíthatja, klónozhatja, eltávolíthatja, elrejtheti, újrarendezheti, exportálhatja, igazíthatja és tükrözheti a prezentáció alakzatokat az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Node.js via Java a dia alakzatait egy rendezett [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/)‑ként ábrázolja. A gyűjtemény egyszerre hely, ahol az alakzatokat megtalálja és módosíthatja, és a rétegezési sorrend forrása: a `0` indeks a hátsó alakzat, míg az utolsó index az előre legközelebbi alakzat.

Ez a cikk ezt a modellt követi. Először elmagyarázza, hogyan azonosítható megbízhatóan egy alakzat, majd bemutatja, hogyan klónozhat, távolíthat el, rejthet el és rendezhet újra alakzatokat. Az utolsó szakaszok a layout‑szintű formázást, az SVG exportot, az igazítást és a tükrözési beállításokat fedik le. Minden példa önálló, így csak a munkafolyamatához szükséges műveleteket használhatja.

## **Az alakzatok azonosítása és keresése**

A gyűjtemény indexei kényelmesek egy ismert fájl feldolgozása során, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy újrarendezése megváltoztathatja az indexét. Válasszon azonosítót attól függően, hogyan készült és karbantartott a prezentáció:

- [Name](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getname/) hasznos fejlesztő által ellenőrzött sablonoknál, és könnyen megtekinthető a PowerPoint Kijelölő ablaktáblájában. A neveket szerkeszthető, és nem garantált a egyediségük, ezért definiáljon elnevezési konvenciót, ha a kód rájuk támaszkodik.
- [AlternativeText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getalternativetext/) hasznos, ha egy hozzáférhetőségi leírás vagy szerző által megadott címke már azonosítja az alakzatot. A felhasználók számára látható, lokalizálható vagy átírható a hozzáférhetőség érdekében, és nem garantált az egyedisége. Ne használja csendben értelemszerűen a jelentős hozzáférhetőségi szöveget adatbáziskezettként.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) egy csak olvasható azonosító, amely egy dián belül egyedi, és megfelel a PowerPoint interop által használt alakzat ID‑nek. Használja, ha PowerPoint integrációról van szó, vagy ha egyértelmű hivatkozásra van szükség az alakzat élettartama alatt. A klónozott vagy újra létrehozott alakzat másik alakzat, és saját ID‑t kap.

A kapcsolódó [getUniqueId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getuniqueid/) metódus egy prezentáció‑szintű azonosítót ad vissza, de ez az azonosító kiegészítőknek szánt, és újra hozzárendelhető. Nem szabad állandó külső kulcsként kezelni. Ha hosszú távú azonosításra van szükség, tárolja a leképezést az alkalmazás adataiban, és ellenőrizze, hogy a várt alakzat még létezik‑e.

A következő példa név szerint keres pontos összehasonlítással, és a dia‑szintű interop ID‑t jelenti. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt az eredményt jelzi, ahelyett, hogy a rossz objektummal folytatná.

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

Ha egy művelet alakzat típusra specifikus, ellenőrizze a futási osztályt, mielőtt típus‑specifikus tagokat használna. Ez a példa csak akkor frissíti a szöveget és az alternatív szöveget, ha a megnevezett objektum egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/).

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

## **Az alakzategyűjtemény módosítása**

Az add, clone, remove és reorder metódusok azonnal a gyűjmentényen dolgoznak. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne támaszkodjon a korábban rögzített indexekre.

### **Alakzat klónozása**

[addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/addclone/) független másolatot hoz létre, és a célgyűjtemény végére fűzi. [insertClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/insertclone/) szintén másolatot készít, de egy megadott z‑rend indexnél helyezi el. A koordinátákat elfogadó túlterhelések a klónt áthelyezik méretváltoztatás nélkül; a szélességet és magasságot meghatározó túlterhelések átméretezhetik is.

A példa egy cél diát hoz létre, egy címkézett téglalapot klónoz az előre, és egy második klónt illeszt be a háttérbe. Bármelyik klón változtatása nem módosítja a forrás alakzatot.

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

A klónozás másolja az alakzat tartalmát és formázását, beleértve a nevét és az alternatív szöveget is. Adjon új logikai azonosítókat a klónnak, ha ezeknek az értékeknek egyedinek kell lenniük. A komplex alakzatok által használt erőforrásokat a prezentáció kezeli, de a klón új gyűjteményelemként jelenik meg egy új alakzatidentitással.

### **Alakzatok eltávolítása**

[remove](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/remove/) egy adott alakzatot töröl a gyűjteményéből. Több egyező eltávolítása indexelt iteráció során, járjon a végéről, hogy minden maradó index érvényes maradjon.

Ez a példa minden olyan alakzatot eltávolít, amelynek meghatározott neve van. Az aktuális indexnél olvassa az alakzatot, és nem feltételez konkrét alakzattípust.

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

Eltávolítás után az alakzatszám és a későbbi alakzatok indexei változnak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak a mentett indexeknél. Emellett vegye figyelembe a csatlakozókat, animációkat és egyéb prezentációs elemeket, amelyek a törölt objektumra hivatkozhatnak; egy látható alakzat eltávolítása több mint csak a dia megjelenését változtathatja meg.

### **Alakzat elrejtése**

[A Hidden](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/sethidden/) `true` értékre állítása megtartja az alakzatot a gyűjteményben, de megakadályozza, hogy megjelenjen a normál diavetítésben. Indexe, formázása és tartalma továbbra is elérhető a kód számára, így az elrejtés megfelelő opcionális elemeknél, amelyeket később vissza lehet állítani.

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

Az elrejtés nem törlés vagy biztonság. Az objektum továbbra is felfedezhető és visszafejthető felhasználó vagy kód által, és része marad a prezentáció fájlnak.

### **Z‑sorrend módosítása**

A átfedő alakzatok a gyűjtemény sorrendjében kerülnek lerajzolásra. A [reorder](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/reorder/) egy meglévő alakzatot egy cél indexre mozgat klónozás nélkül. A `0` index a hátul; a `size() - 1` az elülső.

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

A téglalap először kerül létrehozásra, és kezdetben a ellipszis mögött helyezkedik el. Ha a végső indexre mozgatjuk, elöl kerül. Z‑sorrendet a kapcsolódó alakzatok hozzáadása vagy klónozása után kell befejezni, mert ezek a műveletek új gyűjteményelemeket fűznek hozzá vagy illesztenek be, és megváltoztathatják a kívánt réteget.

## **Alakzatok ellenőrzése elrendezési diákon**

A normál diák, az elrendezési diák és a mesterdiák külön alakzategyűjteménnyel rendelkeznek. Egy elrendezési gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonló pozíciójú alakzat a normál dián. Vizsgálja meg az elrendezési alakzatokat, ha meg kell érteni vagy módosítani kell egy elrendezés által biztosított formázást.

A következő példa beolvassa minden elrendezési alakzat [FillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getfillformat/) és [LineFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getlineformat/) tulajdonságait anélkül, hogy feltételezné, hogy minden alakzat egy `AutoShape`.

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

Egy elrendezés szerkesztése több diára is hatással lehet, amely használja azt. A layout alakzat módosítása előtt határozza meg, hogy egy normál dia örökölte‑e az objektumot vagy tartalmaz‑e helyi felülírást, és tesztelje minden olyan diát, amely az elrendezést használja.

## **Alakzat exportálása SVG‑be**

[writeAsSvg](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/writeassvg/) egy alakzat renderelt tartalmát írja egy stream‑be. Az eredmény az alakzatot tartalmazza, nem a teljes dia háttérét vagy a szomszédos alakzatokat.

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

Tartsa nyitva a prezentációt a renderelés közben. A kimenet az alakzat formázásától és olyan erőforrásoktól, mint betűtípusok és képek, függ. Ha az egész kompozícióra van szükség, exportálja a diát az egyes alakzat helyett. A hívó birtokolja a stream‑et, és le kell zárnia.

## **Alakzatok igazítása**

A [SlideUtil.alignShapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideutil/alignshapes/) túlterhelései akár az összes alakzatot, akár a kiválasztott gyűjtemény indexeket igazítják. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapesalignmenttype/) meghatározza az él, a középvonal vagy az elosztási módot. `alignToSlide` `true` értékre állítása a dia széleit használja; `false` esetén a kiválasztott alakzatok egymáshoz viszonyított igazítása.

Ez a példa három alakzatot a dia felső éléhez igazít. A visszakapott alakzatreferenciákat az igazítás előtt azonnal az aktuális indexeikre konvertálja.

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

Az igazítás a pozíciókat változtatja, nem a z‑sorrendet. Relatív igazításhoz általában legalább két alakzat szükséges, míg a vízszintes vagy függőleges elosztáshoz elegendő alakzat kell a távolság meghatározásához. Számolja újra az indexeket, ha a gyűjteményt módosítja a metódus hívása előtt.

## **Alakzat tükrözése**

A [ShapeFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapeframe/) osztály tárolja a pozíciót, méretet, vízszintes és függőleges tükrözési beállításokat, valamint a forgást. A `getFlipH` és `getFlipV` értékek a [NullableBool](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/nullablebool/) használják: a `True` engedélyezi a tükrözést, a `False` letiltja, a `NotDefined` megőrzi a nem meghatározott/alapértelmezett állapotot.

Az alábbi bemeneti prezentáció egy nem tükrözött alakzatot tartalmaz.

![Az alakzat a tükrözés előtt](shape_to_be_flipped.png)

A példa minden egyéb keretértéket megtart, és csak a két tükrözési beállítást cseréli le. Ez fontos, mert egy új [Frame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/setframe/) hozzárendelése a teljes keretet felülírja.

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

A mentett alakzat vízszintesen és függőlegesen tükröződik, miközben megtartja a pozícióját, méretét és forgását.

![Az alakzat a tükrözés után](flipped_shape.png)

## **GYIK**

**Használjak gyűjtemény indexet alakzatazonosítóként?**

Csak rövid életű feldolgozáshoz, amikor a gyűjtemény nem változik az index használata előtt. Előnyben részesítsen egy ellenőrzött `Name` vagy `AlternativeText` konvenciót a szerkesztett sablonoknál, vagy `OfficeInteropShapeId`‑t a dia‑szintű interop munkához.

**Eltávolítja‑e egy elrejtett alakzat a z‑sorrendből?**

Nem. Egy elrejtett alakzat a gyűjteményben marad ugyanazon az indexen. Megtalálható, újrarendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik alakzat előtt?**

Az `addClone` a klónt a gyűjtemény végére fűzi, ami a z‑sorrend eleje. Használja az `insertClone`‑t a kezdeti index kiválasztásához, vagy a `reorder`‑t az összes alakzat hozzáadása után.