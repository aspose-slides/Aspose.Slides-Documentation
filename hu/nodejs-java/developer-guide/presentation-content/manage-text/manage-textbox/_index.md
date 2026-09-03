---
title: Szövegdobozok kezelése prezentációkban JavaScript segítségével
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
description: "Szövegdobozok létrehozása, azonosítása, formázása és frissítése PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Node.js via Java használatával."
---
## **Bevezetés**

Az Aspose.Slides for Node.js via Java esetében a diák szövege szövegkeretekben tárolódik, amelyek alakzatokhoz tartoznak. Az [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) osztály a leggyakoribb szöveget tartalmazó alakzatot képviseli, és a szövegét a [AutoShape.getTextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/#getTextFrame) metóduson keresztül teszi elérhetővé.

{{% alert color="info" title="Megjegyzés" %}}

Minden automatikus alakzat a [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) osztályból származik, de nem minden alakzat automatikus alakzat, vagy támogat szövegkeretet. Egy meglévő bemutató feldolgozásakor ellenőrizze, hogy az alakzat egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) példány-e, mielőtt hozzáférne a szövegéhez.

{{% /alert %}}

## **Szövegdoboz létrehozása egy dián**

Szövegdoboz létrehozásához adjon egy automatikus alakzatot a diára, szöveget a szövegkeretéhez, majd mentse a prezentációt. Az alábbi példa egy téglalap alakú szövegdobozt hoz létre:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/#addAutoShape) metódusnak átadott koordinátákat és méreteket pontban mérik. Az [AutoShape.addTextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/#addTextFrame) a megadott szöveggel inicializálja a szövegkeretet.

## **Szövegdoboz alakzat ellenőrzése**

Használja az [AutoShape.isTextBox](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/#isTextBox) metódust annak meghatározására, hogy egy automatikus alakzat szövegdoboznak tekintendő-e. Ez akkor hasznos, ha a bemutató mind szöveget tartalmazó, mind csak grafikus automatikus alakzatokat tartalmaz.

![Egy szövegdoboz és egy alakzat](istextbox.png)

Az alábbi példa minden automatikus alakzatot vizsgál meg egy bemutatóban:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Egy újból hozzáadott automatikus alakzat csak akkor tekinthető szövegdoboznak, ha nem üres szöveget tartalmaz. A szöveget megadhatja az [AutoShape.addTextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/#addTextFrame) vagy a [TextFrame.setText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#setText) segítségével. Üres karakterlánc hozzáadása vagy hozzárendelése azt eredményezi, hogy az [AutoShape.isTextBox](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/#isTextBox) `false` értékkel tér vissza:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Az első két hívás `true`-t, az utolsó két hívás `false`-t nyomtat.

## **Az a alakzat megtalálása, amelyik a szövegkeretet birtokolja**

Általános szövegfeldolgozó kód kaphat egy [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) objektumot anélkül, hogy tudná, melyik bemutatóelemhez tartozik. Használja a csak olvasható [TextFrame.getParentShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getParentShape) metódust, hogy visszalépjen a tulajdonos [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) elemhez.

Egy szövegkeret, amely automatikus alakzat vagy más, szöveget tartalmazó alakzat tulajdonában van, a [TextFrame.getParentShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getParentShape) a tulajdonost adja vissza, a [TextFrame.getParentCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getParentCell) pedig `null`-t. Mindig ellenőrizze a visszakapott értéket, mielőtt hozzáférne. A forma- és táblacellatulajdonosok, köztük a SmartArt csomópontokhoz kapcsolódó alakzatok azonosításához lásd a [Keresés és csere szöveg](/slides/hu/nodejs-java/search-and-replace-text/) oldalt.

## **Oszlopok hozzáadása egy szövegdobozhoz**

A [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setColumnCount) metódus oszlopokra osztja a szövegkeretet, míg a [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) a pontban mért oszloptérközöt állítja be. Mindkét beállítás a [TextFrameFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/) része, és megváltoztatható egy meglévő szövegdoboz szövegkeretén keresztül. A szöveg az oszlopok között áramlik ugyanabban az alakzatban; nem folytatódik egy másik alakzatra.

Az alábbi példa háromoszlopos szövegdobozt hoz létre 10 pont oszloptérközzel, elmenti a prezentációt, és visszaolvassa a mentett beállításokat a kimeneti fájlból:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Szöveg kinyerése az egyes oszlopokból**

Használja a [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#splitTextByColumns) metódust, hogy lekérje az egyes vizuális oszlopokhoz rendelt szöveget egy meglévő szövegkeretben. A metódus minden oszlophoz egy karakterláncot ad vissza, oszlopalapú olvasási sorrendben. Egyetlen oszlopos szövegkeret egy elemű tömböt eredményez, az üres oszlopot üres karakterlánc képviseli. A karakterláncok csak egyszerű szöveget tartalmaznak; a részlet‑szintű formázás nem őrződik meg.

Ez akkor hasznos, ha:

- A szöveget ki akarja nyerni, miközben megőrződik az oszlop‑alapú olvasási sorrend.
- Többoszlopos diák tartalmát indexelni vagy összehasonlítani szeretné.
- Minden oszlopot külön fájlba, adatbázismezőbe vagy más célhelyre szeretné exportálni.
- Szeretné ellenőrizni, hogy a szöveg hogyan oszlik újra a [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setColumnCount), a [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing), a betűtípus vagy a szövegkeret méretének módosítása után.

A metódus az aktuális [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) keretben elosztott szöveget jelenti; nem áramlik automatikusan a szöveg külön alakzatok vagy szövegdobozok között. Az oszlopok eloszlása függhet a rendelkezésre álló betűtípusoktól és egyéb szöveg‑elrendezési beállításoktól, ezért győződjön meg róla, hogy a szükséges betűtípusok elérhetők, ha konzisztens eredményekre van szükség.

Az alábbi példa egy prezentációt betölt, megtalálja az első többoszlopos automatikus alakzatot szövegkerettel, kiolvassa a beállított oszlopszámot, és minden oszlop szövegét egy külön fájlba írja. Azok az alakzatok, amelyek nem biztosítanak szövegkeretet, átugrásra kerülnek.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Szöveg frissítése**

A szöveg frissítéséhez egy prezentációban iteráljon a diák és alakzatok között, válassza ki az automatikus alakzatokat, majd szerkessze a szövegrészeiket. A részegységszintű munka lehetővé teszi a szöveg és a karakterformázás egyidejű módosítását.

Az alábbi példa minden `years` előfordulást `months`‑ra cserél az automatikus alakzatok szövegében, és minden érintett részt félkövérre állít:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ez a bejárás csak az automatikus alakzatok szövegét módosítja. A táblákban, diagramokban, SmartArt‑ban vagy csoportos alakzatokban tárolt szöveg módosításához az azok saját gyűjteményeinek bejárása szükséges.

## **Szövegdoboz hozzáadása hiperhivatkozással**

Egy hiperhivatkozás hozzárendelhető egy adott szövegrészlethez, így csak az a szöveg lesz kattintható link. Használja a [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) metódust a részlet külső URL‑hez való társításához.

Az alábbi példa kapcsolt szöveget hoz létre és ment egy prezentációba:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mi a különbség egy szövegdoboz és egy szöveghelytartó között egy mester‑ vagy elrendezésdia esetén?**

A [placeholder](/slides/hu/nodejs-java/manage-placeholder/) örökölheti a pozícióját és formázását egy [master slide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/) vagy [layout slide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/) elemtől. Egy normál szövegdoboz egy önálló alakzat a dián, ahol létrehozták, és nem veszi át a helytartó viselkedését, ha az elrendezés megváltozik.

**Hogyan cserélhetem le a szöveget anélkül, hogy a diagramokban, táblázatokban vagy SmartArt‑ban lévő szöveget módosítanám?**

Korlátozza a bejárást csak azokra az alakzatokra, amelyek a [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) példányai, ahogy az a Szöveg frissítése példában látható. A diagramok, táblázatok és SmartArt a saját objektummodelljükben tárolják a szöveget, ezért azzal a ciklussal nem módosulnak.