---
title: Szövegdobozok kezelése prezentációkban JavaScript használatával
linktitle: Szövegdoboz kezelése
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
- szövegoszlop hozzáadása
- hiperhivatkozás hozzáadása
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Az Aspose.Slides for Node.js megkönnyíti a szövegdobozok létrehozását, szerkesztését és klónozását PowerPoint és OpenDocument fájlokban, ezáltal felgyorsítva a prezentáció automatizálását."
---
## **Bevezetés**

A diákon a szövegek általában szövegdobozokban vagy alakzatokban találhatók. Ezért egy szöveg hozzáadásához egy diára szövegdobozt kell hozzáadni, majd szöveget helyezni a szövegdobozba. Az Aspose.Slides for Node.js via Java a [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape) osztályt biztosítja, amely lehetővé teszi, hogy olyan alakzatot adjunk hozzá, amely szöveget tartalmaz.

{{% alert title="Info" color="info" %}}

Az Aspose.Slides emellett a [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape) osztályt is biztosítja, amely lehetővé teszi alakzatok hozzáadását a diákhoz. Azonban nem minden, a `Shape` osztályon keresztül hozzáadott alakzat képes szöveget tárolni. Azonban a [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape) osztályon keresztül hozzáadott alakzatok szöveget tartalmazhatnak.

{{% /alert %}}

{{% alert title="Megjegyzés" color="warning" %}} 

Ezért, amikor egy olyan alakzattal dolgozunk, amelyhez szöveget szeretnénk hozzáadni, ellenőrizni és megerősíteni kell, hogy az a `AutoShape` osztályon keresztül lett létrehozva. Csak ezután tudunk a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrame) segítségével dolgozni, amely a `AutoShape` tulajdonsága. Lásd a [Update Text](https://docs.aspose.com/slides/hu/nodejs-java/manage-textbox/#update-text) szekciót ezen az oldalon.

{{% /alert %}}

## **Szövegdoboz létrehozása a dián**

Szövegdoboz létrehozásához egy dián, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezzen referenciát az újonnan létrehozott prezentáció első diájához.  
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape) objektumot a [ShapeType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) `Rectangle` értékre állítva a dián egy megadott pozícióban, és szerezzen referenciát az újonnan hozzáadott `AutoShape` objektumhoz.  
4. `TextFrame` tulajdonságot adjon hozzá az `AutoShape` objektumhoz, amely szöveget tartalmaz. Az alábbi példában ezt a szöveget adtuk hozzá: *Aspose TextBox*  
5. Végül írja ki a PPTX fájlt a `Presentation` objektumon keresztül.  

Ez a JavaScript kód – amely a fenti lépéseket valósítja meg – megmutatja, hogyan adhat szöveget egy diához:

```javascript
// Létrehozza a Presentation példányt
var pres = new aspose.slides.Presentation();
try {
    // Lekéri a prezentáció első diáját
    var sld = pres.getSlides().get_Item(0);
    // Hozzáad egy AutoShape-et, amelynek típusa Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Hozzáad egy TextFrame-et a Rectangle-hez
    ashp.addTextFrame(" ");
    // Eléri a szövegkeretet
    var txtFrame = ashp.getTextFrame();
    // Létrehozza a Paragraph objektumot a szövegkerethez
    var para = txtFrame.getParagraphs().get_Item(0);
    // Létrehozza a Portion objektumot a bekezdéshez
    var portion = para.getPortions().get_Item(0);
    // Beállítja a szöveget
    portion.setText("Aspose TextBox");
    // Mentés a lemezre
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Szövegdoboz alakzat ellenőrzése**

Az Aspose.Slides a [isTextBox](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/#isTextBox) metódust a [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) osztályból biztosítja, amely lehetővé teszi az alakzatok vizsgálatát és a szövegdobozok azonosítását.

![Szövegdoboz és alakzat](istextbox.png)

Ez a JavaScript kód megmutatja, hogyan ellenőrizze, hogy egy alakzat szövegdobozként lett-e létrehozva:

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Vegye figyelembe, hogy ha egyszerűen egy automatikus alakzatot ad hozzá a `addAutoShape` metódussal a [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/) osztályból, az automatikus alakzat `isTextBox` metódusa `false` értéket ad vissza. Azonban ha szöveget ad hozzá az automatikus alakzathoz a `addTextFrame` vagy a `setText` metódussal, akkor az `isTextBox` tulajdonság `true` értéket ad.

```javascript
var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() false értéket ad vissza
shape1.addTextFrame("shape 1");
// shape1.isTextBox() true értéket ad vissza

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() false értéket ad vissza
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() true értéket ad vissza

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() false értéket ad vissza
shape3.addTextFrame("");
// shape3.isTextBox() false értéket ad vissza

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() false értéket ad vissza
shape4.getTextFrame().setText("");
// shape4.isTextBox() false értéket ad vissza
```

## **Oszlop hozzáadása szövegdobozban**

Az Aspose.Slides a [setColumnCount](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) és a [setColumnSpacing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) metódusokat a [TextFrameFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat) osztályból biztosítja, amelyek lehetővé teszik oszlopok hozzáadását a szövegdobozokhoz. Megadhatja a szövegdobozban lévő oszlopok számát, valamint a pontban megadott oszlopok közötti távolságot.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Lekéri a prezentáció első diáját
    var slide = pres.getSlides().get_Item(0);
    // Hozzáad egy AutoShape-et, amelynek típusa Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Hozzáad egy TextFrame-et a Rectangle-hez
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!"));
    // Lekéri a TextFrame szövegformátumát
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Megadja a oszlopok számát a TextFrame-ben
    format.setColumnCount(3);
    // Megadja az oszlopok közötti távolságot
    format.setColumnSpacing(10);
    // Mentés a prezentációra
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Oszlop hozzáadása szövegkeretben**

Az Aspose.Slides for Node.js via Java a [setColumnCount](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) metódust a [TextFrameFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat) osztályból biztosítja, amely lehetővé teszi oszlopok hozzáadását szövegkeretekhez. Ezen tulajdonság segítségével megadhatja a kívánt oszlopszámot egy szövegkeretben.

```javascript
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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

Az Aspose.Slides lehetővé teszi, hogy megváltoztassa vagy frissítse a szövegdobozban vagy a prezentációban lévő összes szöveget. 

Ez a JavaScript kód bemutat egy műveletet, amelyben a prezentáció összes szövege frissül vagy módosul:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Ellenőrzi, hogy a forma támogatja-e a szövegkeretet (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Végigiterál a szövegkeret bekezdésein
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Végigiterál a bekezdés minden részén
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Módosítja a szöveget
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Módosítja a formázást
                    }
                }
            }
        }
    }
    // Mentse a módosított prezentációt
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Szövegdoboz hozzáadása hiperhivatkozással** 

Linket szúrhat be egy szövegdobozba. Amikor a szövegdobozt rákattintják, a felhasználók a linket nyitják meg. 

Egy linket tartalmazó szövegdoboz hozzáadásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a `Presentation` osztályból.  
2. Szerezzen referenciát az újonnan létrehozott prezentáció első diájához.  
3. `AutoShape` objektumot adjon hozzá, a `ShapeType`-ot `Rectangle` értékre állítva a dián egy megadott pozícióban, és szerezzen referenciát az újonnan hozzáadott AutoShape objektumhoz.  
4. `TextFrame`-et adjon hozzá az `AutoShape` objektumhoz, amely alapértelmezett szövegként *Aspose TextBox*-t tartalmaz.  
5. Példányosítsa a `HyperlinkManager` osztályt.  
6. Rendelje hozzá a `HyperlinkManager` objektumot a [HyperlinkClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) tulajdonsághoz, amely a `TextFrame` kívánt részéhez van társítva.  
7. Végül írja ki a PPTX fájlt a `Presentation` objektumon keresztül.  

Ez a JavaScript kód – amely a fenti lépéseket valósítja meg – megmutatja, hogyan adhat szövegdobozt hiperhivatkozással egy diára:

```javascript
// Létrehozza a Presentation osztály egy példányát, amely PPTX-et jelképez
var pres = new aspose.slides.Presentation();
try {
    // Lekéri a prezentáció első diáját
    var slide = pres.getSlides().get_Item(0);
    // Hozzáad egy AutoShape objektumot, amelynek típusa Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Átkastálja a formát AutoShape-re
    var pptxAutoShape = shape;
    // Eléri az AutoShape-hez kapcsolódó ITextFrame tulajdonságot
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Hozzáad szöveget a kerethez
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Beállítja a hiperhivatkozást a rész szövegéhez
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Mentés a PPTX prezentációt
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Mi a különbség a szövegdoboz és a szöveghelytartó között mesterszláid használatakor?**

A [placeholder](/slides/hu/nodejs-java/manage-placeholder/) örökli a stílust/pozíciót a [master](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/) diáról, és felülírható a [layouts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/) oldalakon, míg egy szabályos szövegdoboz egy önálló objektum egy adott dián, és nem változik, ha elrendezést vált.

**Hogyan hajthatok végre tömeges szövegcserét a teljes prezentációban anélkül, hogy érinteném a diagramok, táblázatok és SmartArt szövegét?**

Korlátozza az iterációt a szövegkerettel rendelkező auto-alakzatokra, és zárja ki a beágyazott objektumokat ([charts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartart/)) úgy, hogy külön bejárja azok gyűjteményeit vagy kihagyja ezeket az objektumtípusokat.