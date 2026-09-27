---
title: "Prezentáció szövegének kezelése Node.js-en keresztül .NET"
linktitle: "Szöveg kezelése"
type: docs
weight: 50
url: /hu/nodejs-net/manage-text/
keywords:
- szöveg
- szövegdoboz
- szöveg hozzáadása
- szöveg módosítása
- szöveg formázása
- betűméret
- félkövér szöveg
- szövegkeret
- bekezdés
- rész
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Szövegdobozt ad egy diára, majd módosítja annak szövegét, betűméretét és félkövér stílusát JavaScriptben az Aspose.Slides for Node.js via .NET használatával."
---
## **Áttekintés**

Az Aspose.Slides-ben a dián lévő szöveg egy alakzathoz tartozik. Egy automatikus alakzat, például egy téglalap, rendelkezik szövegkerettel; a szövegkeret bekezdéseket tartalmaz, és minden bekezdés szakaszokból áll, amelyek azonos formázású szövegrészek. A szöveget a szövegkereten keresztül, a betűtípust pedig egy szakasz formátumán keresztül módosíthatja.

Ez a cikk egy szövegdobozt ad egy diához, elmenti a bemutatót, majd megnyitja a mentett fájlt, és módosítja a szövegdoboz szövegét, betűméretét és félkövér stílusát.

A példákhoz egy olyan projektre van szükség, ahogy a [Installation](/slides/hu/nodejs-net/installation/) oldal leírja. Minden példát mentse `.js` fájlként a projekt mappájába, és futtassa a mappából a `node` paranccsal.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for Node.js via .NET nem rendelkezik saját API‑referenciával. Az Aspose.Slides for .NET API-t camelCase elnevezésekkel tükrözi, ezért a cikkben szereplő API‑linkek a megfelelő osztályokhoz és tagokhoz vezetnek a [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/hu/net/) oldalon.
{{% /alert %}}

## **Szövegdoboz hozzáadása**

Egy szövegdoboz hozzáadásához egy automatikus alakzatot kell a diára helyezni a [addAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/shapecollection/addautoshape/) metódussal, és szöveget adni neki az [addTextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/addtextframe/) metódussal. Az alábbi példa egy téglalapot ad az új bemutató első diájához, majd a bemutatót `text-box.pptx` néven menti:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // A pozíció (x, y) és a méret (szélesség, magasság) pontokban van megadva.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

A `text-box.pptx` diájában egy 500 pont széles és 80 pont magas téglalap található, amelyben az alapértelmezett betűtípussal és mérettel a „Quarterly report” szöveg jelenik meg. A következő példa ezt a szövegdobozt módosítja.

## **A szöveg és formázásának módosítása**

Az alábbi példa megnyitja a `text-box.pptx` fájlt, amelyet az előző példa hozott létre, és lekéri az első dián az első alakzatot. Képek és táblázatok például nem rendelkeznek szövegkerettel, ezért a példa ellenőrzi, hogy az alakzat egy [AutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/)‑e, mielőtt a shape [textFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/textframe/)‑t használja. Ezután a következőket hajtja végre:

1. A szövegkeret [text](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/text/) tulajdonságán keresztül cseréli a szöveget. Ezután a szövegkeret egy bekezdést és egy szakaszt tartalmaz.
2. A [paragraphs](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/paragraphs/) és [portions](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/portions/) gyűjteményekből lekéri azt a szakaszt, és elolvassa a [portionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/portion/portionformat/)‑ját.
3. Beállítja a [fontHeight](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/fontheight/)‑t (a betűméret pontban) és a [fontBold](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/fontbold/)‑t, amely egy [NullableBool](https://reference.aspose.com/slides/hu/net/aspose.slides/nullablebool/) értéket vesz fel.

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

A `text-box-updated.pptx` fájlban a szövegdoboz a „Quarterly report: third quarter” szöveget mutatja félkövér, 32 pontos betűmérettel. Mivel az új szöveg egyetlen szakaszból áll, a két formázási tulajdonság az egész szövegre vonatkozik. Licenc nélkül minden mentés értékelési vízjelet ad hozzá. Mivel a `text-box.pptx` is értékelési módban lett mentve, a `text-box-updated.pptx` két vízjelet tartalmaz; lásd a [Evaluate Aspose.Slides](/slides/hu/nodejs-net/evaluate-aspose-slides/) oldalt.

## **GYIK**

**Miért vesz fel a `fontBold` egy `NullableBool` értéket a `true` vagy `false` helyett?**

Egy szakasz egy tulajdonságot undefined állapotban hagyhat, és örökölheti azt a bekezdéstől, az alakzattól vagy a dia elrendezésétől és mesterétől. A `NullableBool.NotDefined` azt jelenti, hogy „örököl”, míg a `NullableBool.True` és `NullableBool.False` felülírja az örökölt értéket. A `true` vagy `false` értékek hozzárendelése hibát okoz. Ugyanez az ok, amiért a `fontHeight` `NaN`‑t ad vissza, ha a szakasz a betűméretet örökli.

**Hogyan változtathatom meg a szöveg színét?**

Állítsa be a szakasz formátumának kitöltését: rendelje a `FillType.Solid` értéket a `portionFormat.fillFormat.fillType`‑hoz, majd adjunk egy színt, például `"#FF0000"` a `portionFormat.fillFormat.solidFillColor.color`‑nek. Importálja a `FillType`‑ot a csomagból.

**Hogyan formázzak csak a szöveg egy részét?**

A formázás a szakaszokhoz tartozik, ezért helyezze a szöveg azon részét egy saját szakaszába. Hozza létre a szakaszt a `Portion.CreatePortionFromText`‑el, fűzze hozzá egy bekezdéshez a bekezdés `portions` gyűjteményének `add` metódusával, majd állítsa be az új szakasz `portionFormat`‑ját. Importálja a `Portion`‑t a csomagból.

**Miért adja vissza a szöveg olvasása, hogy “… text has been truncated due to evaluation version limitation”?**

Licenc nélkül az Aspose.Slides csak a hosszabb szövegek első öt karakterét adja vissza, például a `textFrame.text` esetén, majd ezt a megjegyzést fűzi hozzá. A megírt szöveg teljes mértékben el van mentve. A teljes szöveg olvasásához alkalmazzon licencet a [Licensing](/slides/hu/nodejs-net/licensing/) útmutató szerint.