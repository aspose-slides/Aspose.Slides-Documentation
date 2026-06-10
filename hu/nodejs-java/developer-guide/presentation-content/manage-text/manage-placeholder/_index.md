---
title: Prezentációhelykitöltők kezelése JavaScript-ben
linktitle: Helykitöltők kezelése
type: docs
weight: 10
url: /hu/nodejs-java/manage-placeholder/
keywords:
- helykitöltő
- szöveghelykitöltő
- képhelykitöltő
- diagramhelykitöltő
- felszólító szöveg
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Könnyedén kezelheti a helykitöltőket az Aspose.Slides for Node.js via Java-ban: cserélje a szöveget, testreszabja a felszólításokat, és állítsa be a képek átlátszóságát PowerPoint és OpenDocument formátumokban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy programozott módon kezelje a prezentáció helykitöltőit. Ez a cikk bemutatja, hogyan lehet megtalálni a helykitöltőket a diákon, módosítani a szövegüket, egyéni felszólító szöveget beállítani a helykitöltő elrendezésekhez, valamint a helykitöltő háttérként használt kép átlátszóságát szabályozni. Tartalmaz egy rövid GYIK-ot is, amely tisztázza az alaptervű helykitöltők és a helyi alakzatok közti különbséget, elmagyarázza, hogyan lehet a helykitöltő változtatásokat elrendezéseken vagy mestereken keresztül alkalmazni, és hivatkozik a fejléc és lábléc helykitöltők kezelésére.

## **Szöveg módosítása a helykitöltőben**

A [Aspose.Slides for Node.js via Java](/slides/hu/nodejs-java/) használatával megtalálhatja és módosíthatja a helykitöltőket a prezentációk diáin. Az Aspose.Slides lehetővé teszi a helykitöltő szövegének módosítását.

**Előfeltétel**: Szüksége van egy olyan prezentációra, amely helykitöltőt tartalmaz. Ilyen prezentációt a szabványos Microsoft PowerPoint alkalmazással hozhat létre.

Így használhatja az Aspose.Slides-t a helykitöltő szövegének cseréjéhez ebben a prezentációban:

1. Hozza létre a [`Presentation`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztály egy példányát, és adja át a prezentációt argumentumként.  
2. Szerezzen be egy dias referenciát az indexe alapján.  
3. Iteráljon végig az alakzatokon, hogy megtalálja a helykitöltőt.  
4. Castolja a helykitöltő alakzatot egy [`AutoShape`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape) típusra, és a hozzá tartozó [`TextFrame`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrame) segítségével módosítsa a szöveget.  
5. Mentse el a módosított prezentációt.

Ez a JavaScript kód bemutatja, hogyan módosíthatja a szöveget egy helykitöltőben:

```javascript
// Létrehozza a Presentation osztály példányát
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // Eléri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Végigiterál a alakzatokon, hogy megtalálja a helykitöltőt
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // Módosítja az egyes helykitöltők szövegét
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // Elmenti a prezentációt a lemezre
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Felszólító szöveg beállítása a helykitöltőben**

Az alap és előre létrehozott elrendezések helykitöltő felszólító szövegeket tartalmaznak, például ***Click to add a title*** vagy ***Click to add a subtitle***. Az Aspose.Slides segítségével saját felszólító szövegeket szúrhat be a helykitöltő elrendezésekbe.

Ez a JavaScript kód megmutatja, hogyan állítható be a felszólító szöveg egy helykitöltőben:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Iterál a dián
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // A PowerPoint megjeleníti a "Click to add title" szöveget
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // Alcím hozzáadása
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Helykitöltő kép átlátszóságának beállítása**

Az Aspose.Slides lehetővé teszi a szöveghelykitöltő háttérképének átlátszóságának beállítását. A kép átlátszóságának szabályozásával kiemelhető a szöveg vagy a kép (a szöveg és a kép színétől függően).

Ez a JavaScript kód bemutatja, hogyan állítható be egy kép háttér (alakzat) átlátszósága:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **GYIK**

**Mi az alaptervű helykitöltő, és miben különbözik egy helyi alakzattól a dián?**

Az alaptervű helykitöltő a layout vagy mester eredeti alakzata, amelyből a dia alakzata örököl – típusa, pozíciója és egyes formázásai innen származnak. A helyi alakzat önálló; ha nincs alaptervű helykitöltő, az öröklődés nem alkalmazható.

**Hogyan frissíthetem az összes címet vagy feliratot egy prezentációban anélkül, hogy minden dián iterálnék?**

Szerkessze a megfelelő helykitöltőt a layout vagy a mester szintjén. Az azok alapján létrehozott diák automatikusan öröklik a változást.

**Hogyan vezérelhetem a szabványos fejléc/lábléc helykitöltőket – dátum és idő, dia sorszám, és lábléc szöveg?**

Használja a HeaderFooter kezelőket a megfelelő hatókörben (normál diák, layoutok, mester, jegyzetek/kézbesítők), hogy be‑ vagy kikapcsolja ezeket a helykitöltőket, és beállítsa a tartalmukat.