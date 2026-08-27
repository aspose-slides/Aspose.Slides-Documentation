---
title: "Szövegdobozok kezelése prezentációkban JavaScript használatával"
linktitle: "Szövegdoboz kezelése"
type: docs
weight: 20
url: /hu/nodejs-java/manage-textbox/
keywords:
- szövegdoboz
- szövegkeret
- szöveg hozzáadása
- szöveg frissítése
- szövegdoboz létrehozása
- szövegdoboz ellenőrzése
- oszlop hozzáadása a szöveghez
- hiperhivatkozás hozzáadása
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Az Aspose.Slides for Node.js egyszerűvé teszi a szövegdobozok létrehozását, szerkesztését és klónozását PowerPoint és OpenDocument fájlokban, ezáltal javítva a prezentáció automatizálását."
---
## **Bevezetés**

A diákon lévő szövegek általában szövegdobozokban vagy alakzatokban találhatók. Ezért a diára szöveget hozzáadni egy szövegdobozt kell létrehozni, majd szöveget helyezni a dobozba. Az Aspose.Slides for Node.js via Java a [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape) osztályt biztosítja, amely lehetővé teszi szöveget tartalmazó alakzat hozzáadását.

{{% alert title="Info" color="info" %}}
Az Aspose.Slides emellett a [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape) osztályt is biztosítja, amely lehetővé teszi alakzatok hozzáadását a diákhoz. Azonban nem minden, a `Shape` osztályon keresztül hozzáadott alakzat képes szöveget tárolni. A [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape) osztályon keresztül hozzáadott alakzatok viszont tartalmazhatnak szöveget.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Ezért, amikor olyan alakzattal dolgozunk, amelyhez szöveget szeretnénk hozzáadni, érdemes ellenőrizni és megerősíteni, hogy a `AutoShape` osztályon keresztül lett létrehozva. csak ekkor használhatjuk a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrame) tulajdonságot, amely a `AutoShape` része. Tekintse meg a [Update Text](https://docs.aspose.com/slides/hu/nodejs-java/manage-textbox/#update-text) szakaszt ezen az oldalon.
{{% /alert %}}

## **Szövegdoboz létrehozása a dián**

A szövegdoboz létrehozásához a dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezzen referenciát az újonnan létrehozott prezentáció első diájához.  
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape) objektumot, amelynél a [ShapeType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) `Rectangle` értékre van állítva, a dián egy megadott pozícióban, és szerezze meg az újonnan hozzáadott `AutoShape` objektum referenciáját.  
4. Adjon hozzá egy `TextFrame` tulajdonságot az `AutoShape` objektumhoz, amely szöveget fog tartalmazni. Az alábbi példában ezt a szöveget adtuk hozzá: *Aspose TextBox*  
5. Végül írja ki a PPTX fájlt a `Presentation` objektumon keresztül.  

Ez a JavaScript‑kód – a fenti lépések megvalósítása – megmutatja, hogyan adjon szöveget egy diához:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Példányosítja a prezentációt
var pres = new aspose.slides.Presentation();
try {
    // Lekéri a prezentáció első diáját
    var sld = pres.getSlides().get_Item(0);
    // Hozzáad egy AutoShape-ot, amelynek típusa Téglalap
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Hozzáad egy TextFrame-et a téglalaphoz
    ashp.addTextFrame(" ");
    // Hozzáfér a szövegkerethez
    var txtFrame = ashp.getTextFrame();
    // Létrehozza a bekezdés objektumot a szövegkerethez
    var para = txtFrame.getParagraphs().get_Item(0);
    // Létrehozza a Portion objektumot a bekezdéshez
    var portion = para.getPortions().get_Item(0);
    // Beállítja a szöveget
    portion.setText("Aspose TextBox");
    // Elmenti a prezentációt a lemezre
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Szövegdoboz alakzat ellenőrzése**

Az Aspose.Slides a [isTextBox](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/#isTextBox) metódust biztosítja az [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) osztályból, amely lehetővé teszi az alakzatok vizsgálatát és a szövegdobozok azonosítását.

![Szövegdoboz és alakzat](istextbox.png)

Ez a JavaScript‑kód megmutatja, hogyan ellenőrizze, hogy egy alakzat szövegdobozként készült‑e:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Vegye figyelembe, hogy ha egyszerűen csak egy autoshape‑et ad hozzá a [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/) osztály `addAutoShape` metódusával, az autoshape `isTextBox` metódusa `false` értéket ad vissza. Azonban miután szöveget ad hozzá az autoshape‑hez a `addTextFrame` vagy a `setText` metódussal, a `isTextBox` tulajdonság `true` értéket ad vissza.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() hamis értéket ad vissza
shape1.addTextFrame("shape 1");
// shape1.isTextBox() igaz értéket ad vissza

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() hamis értéket ad vissza
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() igaz értéket ad vissza

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() hamis értéket ad vissza
shape3.addTextFrame("");
// shape3.isTextBox() hamis értéket ad vissza

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() hamis értéket ad vissza
shape4.getTextFrame().setText("");
// shape4.isTextBox() hamis értéket ad vissza
```

## **Az a alakzat megtalálása, amelyik a szövegkeretet birtokolja**

Általános szövegfeldolgozó kódban előfordulhat, hogy egy [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) objektumot kap, anélkül, hogy tudná, melyik prezentációs objektum tartalmazza. Használja a [TextFrame.getParentShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getParentShape--) metódust, hogy visszalépjen a tulajdonos [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) objektumhoz.

Egy olyan szövegkerethez, amely egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) vagy más szöveget tartalmazó alakzat része, a [TextFrame.getParentShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getParentShape--) visszaadja a tulajdonost, míg a [TextFrame.getParentCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getParentCell--) `null`‑t ad. Mindkét metódus csak olvasási navigációt biztosít, ezért a meghívásuk nem változtatja meg a tulajdonjogot. Mindig ellenőrizze a visszatérő értéket `null`‑ra, mielőtt hozzáférne az alakzathoz.

A teljes példáért, amely az alakzat‑ és táblacella‑tulajdonosokat, valamint a SmartArt‑csomópontokhoz kapcsolódó alakzatokat azonosítja, lásd a [Search and Replace Text](/slides/hu/nodejs-java/search-and-replace-text/) oldalt.

## **Oszlop hozzáadása szövegdobozban**

Az Aspose.Slides a [setColumnCount](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) és a [setColumnSpacing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) metódusokat biztosítja a [TextFrameFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat) osztályból, amelyek lehetővé teszik oszlopok hozzáadását a szövegdobozokhoz. Megadhatja az oszlopok számát a szövegdobozban, valamint a pontban kifejezett oszloptávolságot.

Ez a JavaScript‑kód bemutatja a leírt műveletet:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Lekéri a prezentáció első diáját
    var slide = pres.getSlides().get_Item(0);
    // Hozzáad egy AutoShape-ot, amelynek típusa Téglalap
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Hozzáad egy TextFrame-et a téglalaphoz
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // Lekéri a TextFrame szövegformátumát
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Megadja az oszlopok számát a TextFrame-ben
    format.setColumnCount(3);
    // Megadja az oszlopok közötti távolságot
    format.setColumnSpacing(10);
    // Elmenti a prezentációt
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Oszlop hozzáadása szövegkeretben**

Az Aspose.Slides for Node.js via Java a [setColumnCount](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) metódust biztosítja a [TextFrameFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat) osztályból, amely lehetővé teszi oszlopok hozzáadását a szövegkeretekhez. Ezzel a tulajdonsággal megadhatja a kívánt oszlopszámot a szövegkeretben.

Ez a JavaScript‑kód megmutatja, hogyan adjon oszlopot egy szövegkerethez:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // Az oszloptávolságot soha nem állították be, ezért NaN‑ként jelentődik.
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Szöveg frissítése**

Az Aspose.Slides lehetővé teszi a szövegdobozban vagy a teljes prezentációban található szövegek módosítását vagy frissítését.

Ez a JavaScript‑kód egy olyan műveletet demonstrál, amely a prezentáció összes szövegét frissíti vagy megváltoztatja:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Ellenőrzi, hogy az alakzat támogatja-e a szövegkeretet (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Végigmegy a szövegkeret bekezdésein
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Végigmegy a bekezdés minden részletén
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Módosítja a szöveget
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Módosítja a formázást
                    }
                }
            }
        }
    }
    // Elmenti a módosított prezentációt
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Szövegdoboz hozzáadása hiperhivatkozással** 

Hiperhivatkozást illeszthet be egy szövegdobozba. Amikor a szövegdobozra kattintanak, a felhasználó a hivatkozásra navigál.

A hiperhivatkozást tartalmazó szövegdoboz hozzáadásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a `Presentation` osztályból.  
2. Szerezzen referenciát az újonnan létrehozott prezentáció első diájához.  
3. Adjon hozzá egy `AutoShape` objektumot, amelynél a `ShapeType` `Rectangle` értékre van állítva, egy megadott pozícióban a dián, és szerezze meg az újonnan hozzáadott AutoShape objektum referenciáját.  
4. Adjon egy `TextFrame`‑et az `AutoShape` objektumhoz, és állítsa be az első részlet szövegét. Az alábbi példában ezt a szöveget használtuk: *Aspose.Slides*  
5. Szerezze meg ennek a részletnek a `HyperlinkManager`‑ét a `PortionFormat`‑on keresztül.  
6. Hívja meg a `setExternalHyperlinkClick`‑et a `HyperlinkManager`‑en, hogy a hivatkozást a részlethez csatolja.  
7. Végül írja ki a PPTX fájlt a `Presentation` objektumon keresztül.  

Ez a JavaScript‑kód – a fenti lépések megvalósítása – megmutatja, hogyan adjon hiperhivatkozással ellátott szövegdobozt egy diához:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Példányosít egy Presentation osztályt, amely PPTX-et képvisel
var pres = new aspose.slides.Presentation();
try {
    // Lekéri a prezentáció első diáját
    var slide = pres.getSlides().get_Item(0);
    // Hozzáad egy AutoShape objektumot, amelynek típusa Téglalap
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Átkasztja az alakzatot AutoShape típusra
    var pptxAutoShape = shape;
    // Eléri az AutoShape-hez kapcsolódó ITextFrame tulajdonságot
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Hozzáad némi szöveget a kerethez
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Beállítja a hiperhivatkozást a részlet szövegéhez
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Elmenti a PPTX prezentációt
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Mi a különbség a szövegdoboz és a szöveghelytartó között, amikor master diákon dolgozunk?**

A [helytartó](/slides/hu/nodejs-java/manage-placeholder/) örökli a [master](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/) stílusát/pozícióját, és a [layoutok](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/) felülírhatók, míg egy hagyományos szövegdoboz egy önálló objektum egy adott dián, amely nem változik a layoutok váltásakor.

**Hogyan hajthatok végre tömeges szövegcserét a teljes prezentáción anélkül, hogy a diagramok, táblázatok és SmartArt szövegét módosítanám?**

Korlátozza az iterációt csak azokra az auto‑alakzatokra, amelyek rendelkeznek szövegkerettel, és hagyja ki a beágyazott objektumokat ([diagramok](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/), [táblázatok](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartart/)) úgy, hogy gyűjteményeiket külön bejárja, vagy kihagyja ezeket az objektumtípusokat.