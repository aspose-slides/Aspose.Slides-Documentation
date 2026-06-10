---
title: SmartArt kezelése PowerPoint prezentációkban JavaScript használatával
linktitle: SmartArt kezelése
type: docs
weight: 10
url: /hu/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt szöveg
- elrendezéstípus
- rejtett tulajdonság
- szervezeti diagram
- képes szervezeti diagram
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Tanulja meg, hogyan építsen és szerkeszthet PowerPoint SmartArt-ot az Aspose.Slides for Node.js segítségével, tiszta JavaScript kódmintákkal, amelyek felgyorsítják a dia tervezést és az automatizálást."
---
## **Áttekintés**

A SmartArt egy PowerPoint-diagram, amely csomópontokból, csomópont alakzatokból és egy elrendezésből áll. Az Aspose.Slides for Node.js Java-n keresztül segítségével létrehozhatsz SmartArt-ot, kiolvashatod a szöveget a csomópontjaiból, módosíthatod az elrendezését, ellenőrizheted a rejtett csomópontokat, konfigurálhatod a szervezeti diagram elrendezéseket, és létrehozhatsz képes szervezeti diagramokat.

## **Szöveg lekérése SmartArt objektumból**

Egy SmartArt csomópont egy vagy több alakzatot tartalmazhat. A látható szöveg beolvasásához iterálj a [SmartArt.getAllNodes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartart/#getAllNodes--) -n, majd olvasd el a [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartartshape/#getTextFrame--) által visszaadott [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) -t.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **SmartArt objektum elrendezéstípusának módosítása**

A SmartArt elrendezés határozza meg, hogyan vannak a csomópontok elrendezve és összekapcsolva. A következő példában egy SmartArt objektumot hozunk létre a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList` értékkel, átállítjuk `BasicProcess` értékre, majd mentjük a prezentációt.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ellenőrizd, hogy a SmartArt csomópont rejtett-e**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartartnode/ishidden/) azt jelzi, hogy a csomópont rejtett-e a SmartArt adatmodellben. A rejtett csomópontok létezhetnek a struktúrában akkor is, ha a kiválasztott elrendezés nem jeleníti meg őket látható diagram elemeként.

A következő példa egy csomópontot ad hozzá egy [SmartArtLayoutType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` értéket használó SmartArt objektumhoz, és ellenőrzi a csomópont rejtett állapotát.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Szervezeti diagram elrendezés lekérése vagy beállítása**

Azoknál a SmartArt diagramoknál, amelyek szervezeti diagram elrendezést használnak, a [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) és a [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) határozzák meg, hogy a gyermek csomópontok hogyan rendeződnek egy szülő csomópont alatt. Például beállíthatod, hogy a gyermek csomópontok balról, jobbról vagy mindkét oldalról lógjanak, a kiválasztott [OrganizationChartLayoutType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/organizationchartlayouttype/) függvényében.

A következő példa egy szervezeti diagramot hoz létre, és az első csomópont elrendezését a [OrganizationChartLayoutType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` értékre állítja.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Képes szervezeti diagram létrehozása**

A képes szervezeti diagram egy olyan SmartArt elrendezés, amely hierarchia diagramokhoz készült, és képpel helyettesítőket tartalmaz. Használd a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` értéket, amikor a SmartArt objektumot egy diára helyezed.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**A SmartArt támogatja a tükrözést vagy a visszafordítást RTL nyelvek esetén?**

Igen. A [SmartArt.setReversed](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartart/setreversed/) metódus a diagram irányát balról jobbra és jobbról balra, vagy vissza, cseréli, ha a kiválasztott SmartArt elrendezés támogatja a visszafordítást.

**Hogyan másolhatom a SmartArt-ot ugyanarra a diára vagy egy másik prezentációba a formázás megőrzésével?**

A [SmartArt alakzat klónozásával](/slides/hu/nodejs-java/shape-manipulations/) a [ShapeCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/addclone/) vagy a [klónozni a teljes diát](/slides/hu/nodejs-java/clone-slides/) klónozhatod a SmartArt-ot tartalmazó diát. Mindkét megközelítés megőrzi a méretet, a pozíciót és a formázást.

**Hogyan renderelhetem a SmartArt-ot raszteres képre előnézet vagy webes export céljából?**

A [diát renderelheted](/slides/hu/nodejs-java/convert-powerpoint-to-png/) vagy a teljes prezentációt PNG vagy JPEG formátumba. A SmartArt a dia részeként kerül renderelésre.

**Hogyan találhatok meg egy konkrét SmartArt objektumot egy dián, ha több is van?**

Állíts be egy jellegzetes [Shape.setAlternativeText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/setalternativetext/) vagy [Shape.setName](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/setname/) értéket a SmartArt alakzaton, keresd meg ezt az értéket a [BaseSlide.getShapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslide/#getShapes) -ban, majd ellenőrizd, hogy a megtalált alakzat egy [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartart/).