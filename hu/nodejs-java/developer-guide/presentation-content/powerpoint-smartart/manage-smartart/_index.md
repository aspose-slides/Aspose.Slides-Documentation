---
title: SmartArt kezelése PowerPoint prezentációkban JavaScript használatával
linktitle: SmartArt kezelése
type: docs
weight: 10
url: /hu/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt szöveg
- elrendezés típusa
- rejtett tulajdonság
- szervezeti diagram
- kép szervezeti diagram
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Tanulja meg felépíteni és szerkeszteni a PowerPoint SmartArt-ot az Aspose.Slides for Node.js segítségével, egyértelmű JavaScript kódminták használatával, amelyek felgyorsítják a dia tervezését és az automatizálást."
---
## **Áttekintés**

A SmartArt egy PowerPoint diagram, amely csomópontokból, csomópont alakzatokból és egy elrendezésből áll. Az Aspose.Slides a Node.js számára Java-on keresztül segítségével létrehozhat SmartArt-ot, olvashat szöveget a csomópontjaiból, megváltoztathatja az elrendezését, ellenőrizheti a rejtett csomópontokat, konfigurálhatja a szervezeti diagram elrendezéseket, és létrehozhat kép szervezeti diagramokat.

## **Szöveg lekérése egy SmartArt objektumból**

Egy SmartArt csomópont egy vagy több alakzatot tartalmazhat. A csomópont alakzatokból való szöveg olvasásához iteráljon a [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/), majd olvassa el a [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) által visszaadott [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/).  
A példához legalább egy diával és egy SmartArt objektummal rendelkező prezentációra van szükség, ahol a SmartArt az első alakzat a dián. Kiírja az összes elérhető szövegkeretet a konzolra.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **A SmartArt objektum elrendezéstípusának módosítása**

A SmartArt elrendezés szabályozza, hogy a csomópontok hogyan vannak elhelyezve és összekapcsolva. A következő példa egy SmartArt objektumot hoz létre a [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList` értékkel, átváltja `BasicProcess` értékre, és elmenti a prezentációt. A [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/)‑nak átadott pozíciót és méretet pontban mérik. Használja a [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/)‑t az elrendezés módosításához.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ellenőrizze, hogy egy SmartArt csomópont rejtett-e**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) jelzi, hogy a csomópont rejtett-e a SmartArt adatmodellben. A rejtett csomópontok létezhetnek a struktúrában akkor is, ha a kiválasztott elrendezés nem jeleníti meg őket látható diagram elemekként.  
A következő példa egy csomópontot ad egy SmartArt objektumhoz, amely a [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` értéket használ, és ellenőrzi a hozzáadott csomópont rejtett állapotát. Üzenetet ír ki, ha a csomópont rejtett, és elmenti a diagramot.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A szervezeti diagram elrendezésének lekérdezése vagy beállítása**

A szervezeti diagram elrendezést használó SmartArt diagramok esetén a [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) és a [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) határozza meg, hogy a gyermekcsomópontok hogyan helyezkednek el egy szülőcsomópont alatt. Például beállíthatja, hogy a gyermekcsomópontok balról, jobbról vagy mindkét oldalról függjenek, a kiválasztott [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) függvényében.  
A következő példa létrehoz egy szervezeti diagramot, és az első csomópont elrendezését a [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` értékre állítja. A 0‑al kezdődő index `0` az első felső szintű csomópontot választja ki; annak gyermekcsomópontjai a kiválasztott elrendezést használják. A módosított prezentációt ezután elmenti.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kép szervezeti diagram létrehozása**

A kép szervezeti diagram egy olyan SmartArt elrendezés, amely hierarchikus diagramokhoz készült, és képhelyeket tartalmaz. Használja a [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` értéket a SmartArt objektum diára való hozzáadásakor. Ez a példa egy diagramot ment el képhelyekkel; a helyőrzőket nem tölti fel képekkel.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Örökölt diagramok átalakítása alakzatcsoportokká**

Egy meglévő prezentáció modernizálásakor szükség lehet egy eredetileg PowerPoint 97–2003-ban létrehozott szervezeti diagram frissítésére. Az Aspose.Slides ezeket az örökölt diagramokat [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) objektumokként jeleníti meg. Használja a [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/)‑t a diagram alakzatcsoportba konvertálásához, hogy egyes vizuális elemeket szerkeszthessen. A részletekért tekintse meg a [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/).  
A konverzió egy új csoportot ad az alakzateloszláshoz anélkül, hogy eltávolítaná az eredeti diagramot. Sikeres konverzió után távolítsa el az eredetit a [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) segítségével, hogy elkerülje a duplikált tartalmat. Gyűjtse össze az örökölt diagramokat egy listába a konvertálás előtt, hogy az alakzatok hozzáadása és eltávolítása ne szakítsa meg az iterációt.  
A következő példa megnyit egy prezentációt, minden diát keres, a diagramokat alakzatcsoportokká konvertálja, és elmenti a frissített prezentációt PPTX formátumban.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az elmentett prezentáció szerkeszthető alakzatcsoportokat tartalmaz az átalakított örökölt diagramok helyén, az eredeti diagramok már nem maradnak mellettük. Nyissa meg a PPTX-et a PowerPointban, hogy szerkessze az egyes csoportok elemeit, például a szöveget, a kitöltést vagy a pozíciót.

## **GYIK**

**Támogatja a SmartArt a tükrözést vagy a visszafordítást RTL nyelvek esetén?**  
Igen. A [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) metódus megfordítja a diagram irányát balról jobbra és jobbról balra, vagy vissza, ha a kiválasztott SmartArt elrendezés támogatja a visszafordítást.

**Hogyan másolhatom a SmartArt-ot ugyanarra a diára vagy egy másik prezentációba, miközben megőrzöm a formázást?**  
A [SmartArt alakzat klónozásával](/slides/hu/nodejs-java/shape-manipulations/) a [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) vagy a [SmartArt-ot tartalmazó egész dia klónozásával](/slides/hu/nodejs-java/clone-slides/) másolhatja. Mindkét módszer megőrzi a méretet, a pozíciót és a formázást.

**Hogyan renderelhetem a SmartArt-ot raszteres képre előnézethez vagy webes exporthoz?**  
[A dia renderelésével](/slides/hu/nodejs-java/convert-powerpoint-to-png/) vagy a teljes prezentáció PNG vagy JPEG formátumba. A SmartArt a dia részeként kerül renderelésre.

**Hogyan találhatok meg egy konkrét SmartArt objektumot egy diáron, ha több is van?**  
Használja a [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) vagy a [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) módszert, hogy egy egyedi alternatív szöveget vagy nevet adjon a SmartArt alakzatnak, keresse meg ezt az értéket a [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes)‑ben, majd ellenőrizze, hogy a megtalált alakzat egy [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)‑e.