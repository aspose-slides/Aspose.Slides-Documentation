---
title: SmartArt alakzati csomópontok kezelése prezentációkban JavaScript használatával
linktitle: SmartArt alakzat csomópont
type: docs
weight: 30
url: /hu/nodejs-java/manage-smartart-shape-node/
keywords:
- SmartArt csomópont
- gyermekcsomópont
- csomópont hozzáadása
- csomópont pozíció
- csomópont elérése
- csomópont eltávolítása
- egyéni pozíció
- asszisztens csomópont
- kitöltési formátum
- csomópont renderelése
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "SmartArt alakzati csomópontok kezelése PPT és PPTX fájlokban az Aspose.Slides for Node.js segítségével. Szerezzen érthető JavaScript kódrészleteket és tippeket a prezentációk optimalizálásához."
---
## **Áttekintés**

A PowerPoint‑prezentációk SmartArt‑grafikáit olyan csomópontok rendezik, amelyek szöveget tartalmaznak és meghatározzák a diagram szerkezetét. Az Aspose.Slides lehetővé teszi ezen SmartArt‑csomópontok programozott kezelését: új csomópontok és gyermekcsomópontok hozzáadása, gyermekcsomópontok beillesztése meghatározott pozícióban, meglévő csomópontok elérése, valamint a szövegük, szintjük és pozíciójuk kiolvasása.

Ez a cikk bemutatja a SmartArt‑alak csomópontok kezelését. Megmutatja, hogyan távolítsuk el a csomópontokat, hogyan dolgozzunk gyermekcsomópontokkal index vagy pozíció alapján, hogyan alakítsunk át egy asszisztens csomópontot normál csomóponttá, hogyan állítsuk be a SmartArt‑csomópont alakzatok pozícióját, méretét és forgását, hogyan állítsunk be csomópont kitöltési formátumot, és hogyan generáljunk bélyegképet egy SmartArt‑gyermekcsomópontról.

## **SmartArt‑csomópont hozzáadása PowerPoint‑prezentációhoz JavaScript használatával**
Az Aspose.Slides for Node.js via Java a legegyszerűbb API‑t biztosítja a SmartArt‑alakok kezeléséhez. Az alábbi mintakód segít csomópont és gyermekcsomópont hozzáadásában egy SmartArt‑alakba.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) példányt, és töltse be a prezentációt SmartArt‑alakkal.
1. Szerezze meg az első dia hivatkozását az indexe alapján.
1. Járja be a dián lévő összes alakzatot.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) típusú‑e, és ha igen, alakítsa át [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) típusúvá.
1. [Add a new Node](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) a SmartArt‑alak [**NodeCollection**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt#getAllNodes--)‑be, és állítsa be a szöveget a TextFrame‑ben.
1. Most [Add](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) egy [**Child Node**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) az újonnan hozzáadott [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) csomópontba, és állítsa be a szöveget a TextFrame‑ben.
1. Mentse a prezentációt.

```javascript
// A kívánt prezentáció betöltése
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Az első dián belül lévő összes alakzat bejárása
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Az alakzat típuskonvertálása SmartArt-re
            var smart = shape;
            // Új SmartArt csomópont hozzáadása
            var TemNode = smart.getAllNodes().addNode();
            // Szöveg hozzáadása
            TemNode.getTextFrame().setText("Test");
            // Új gyermekcsomópont hozzáadása a szülőcsomóponthoz. A gyűjtemény végére kerül hozzáadásra
            var newNode = TemNode.getChildNodes().addNode();
            // Szöveg hozzáadása
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // Prezentáció mentése
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt‑csomópont hozzáadása meghatározott pozícióban**
Az alábbi mintakódban bemutatjuk, hogyan adhatók hozzá a SmartArt‑alak megfelelő csomópontjaihoz tartozó gyermekcsomópontok adott pozícióban.

1. Hozzon létre egy Presentation példányt.
1. Szerezze meg az első dia hivatkozását az indexe alapján.
1. Adjon hozzá egy [**StackedList**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) típusú [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) alakzatot a kiválasztott diára.
1. Hozzáférés az első csomóponthoz a hozzáadott SmartArt‑alakban.
1. Most adjon hozzá egy [**Child Node**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) a kiválasztott [**Node**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtNode) pozíció 2‑nél, és állítsa be a szöveget.
1. Mentse a prezentációt.

```javascript
// Prezentáció példány létrehozása
var pres = new aspose.slides.Presentation();
try {
    // A prezentáció dia elérése
    var slide = pres.getSlides().get_Item(0);
    // Smart Art IShape hozzáadása
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // SmartArt csomópont elérése az 0 indexen
    var node = smart.getAllNodes().get_Item(0);
    // Új gyermekcsomópont hozzáadása a szülőcsomópont 2. pozíciójában
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // Szöveg hozzáadása
    chNode.getTextFrame().setText("Sample Text Added");
    // Prezentáció mentése
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt‑csomópont elérése PowerPoint‑prezentációban JavaScript használatával**
Az alábbi mintakód segít a SmartArt‑alakban lévő csomópontok elérésében. Vegye figyelembe, hogy a SmartArt LayoutType attribútuma csak olvasható, és csak a SmartArt‑alak hozzáadása során állítható be.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) példányt, és töltse be a prezentációt SmartArt‑alakokkal.
1. Szerezze meg az első dia hivatkozását az indexe alapján.
1. Járja be a dián lévő összes alakzatot.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) típusú‑e, és ha igen, alakítsa át [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) típusúvá.
1. Járja be az összes [**Nodes**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt#getAllNodes--) elemet a SmartArt‑alakban.
1. Hozzáférés és információ megjelenítése, például a SmartArt csomópont pozíciója, szintje és szövege.

```javascript
// Prezentáció osztály példányosítása
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // Első dia lekérése
    var slide = pres.getSlides().get_Item(0);
    // Az első dián belül lévő összes alakzat bejárása
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Az alakzat típuskonvertálása SmartArt-re
            var smart = shape;
            // Az SmartArt belüli összes csomópont bejárása
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // SmartArt csomópont elérése i indexen
                var node = smart.getAllNodes().get_Item(j);
                // A SmartArt csomópont paramétereinek kiírása
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt‑gyermekcsomópont elérése**
Az alábbi mintakód segít a SmartArt‑alak megfelelő csomópontjaihoz tartozó gyermekcsomópontok elérésében.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) példányt, és töltse be a prezentációt SmartArt‑alakokkal.
1. Szerezze meg a második dia hivatkozását az indexe alapján.
1. Járja be a dián lévő összes alakzatot.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) típusú‑e, és ha igen, alakítsa át [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) típusúvá.
1. Járja be az összes [**Nodes**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt#getAllNodes--) elemet a SmartArt‑alakban.
1. Minden kiválasztott SmartArt‑alak [**Node**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtNode) esetén járja be az összes [**Child Nodes**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) elemet az adott csomópontban.
1. Hozzáférés és információ megjelenítése, például a [**Child Node**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) pozíciója, szintje és szövege.

```javascript
// Prezentáció osztály példányosítása
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // Első dia lekérése
    var slide = pres.getSlides().get_Item(0);
    // Az első dián belül lévő összes alakzat bejárása
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Az alakzat típuskonvertálása SmartArt-re
            var smart = shape;
            // Az SmartArt belüli összes csomópont bejárása
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // SmartArt csomópont elérése i indexen
                var node0 = smart.getAllNodes().get_Item(i);
                // Az i indexű SmartArt csomópont gyermekcsomópontjainak bejárása
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // Gyermekcsomópont elérése a SmartArt csomópontban
                    var node = node0.getChildNodes().get_Item(j);
                    // A SmartArt gyermekcsomópont paramétereinek kiírása
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt‑gyermekcsomópont elérése meghatározott pozícióban**
Ebben a példában megtanuljuk, hogyan érhetjük el a gyermekcsomópontokat egy adott pozícióban, a SmartArt‑alak megfelelő csomópontjaihoz tartozóan.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) példányt.
1. Szerezze meg a második dia hivatkozását az indexe alapján.
1. Adjon hozzá egy [**StackedList**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) típusú SmartArt alakzatot.
1. Hozzáférés a hozzáadott SmartArt‑alakhoz.
1. Hozzáférés a 0 indexű csomóponthoz a kiválasztott SmartArt‑alakban.
1. Most a **get_Item()** metódussal érje el a [**Child Node**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) 1 pozícióban lévő gyermekcsomópontot.
1. Hozzáférés és információ megjelenítése, például a [**Child Node**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) pozíciója, szintje és szövege.

```javascript
// A prezentáció példányosítása
var pres = new aspose.slides.Presentation();
try {
    // Az első dia elérése
    var slide = pres.getSlides().get_Item(0);
    // SmartArt alakzat hozzáadása az első diára
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // SmartArt csomópont elérése 0 indexen
    var node = smart.getAllNodes().get_Item(0);
    // Gyermekcsomópont elérése 1 pozícióban a szülőcsomópontban
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // A SmartArt gyermekcsomópont paramétereinek kiírása
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt‑csomópont eltávolítása PowerPoint‑prezentációban JavaScript használatával**
Ebben a példában megtanuljuk, hogyan távolítsuk el a SmartArt‑alakban lévő csomópontokat.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) példányt, és töltse be a prezentációt SmartArt alakzattal.
1. Szerezze meg az első dia hivatkozását az indexe alapján.
1. Járja be a dián lévő összes alakzatot.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) típusú‑e, és ha igen, alakítsa át [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) típusúvá.
1. Ellenőrizze, hogy a [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) több mint 0 csomópontot tartalmaz.
1. Válassza ki a törlendő SmartArt‑csomópontot.
1. Most távolítsa el a kiválasztott csomópontot a [**RemoveNode**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-) metódussal.
1. Mentse a prezentációt.

```javascript
// A kívánt prezentáció betöltése
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Az első dián belül lévő összes alakzat bejárása
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Az alakzat típuskonvertálása SmartArt-re
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // SmartArt csomópont elérése 0 indexen
                var node = smart.getAllNodes().get_Item(0);
                // A kiválasztott csomópont eltávolítása
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // Prezentáció mentése
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt‑csomópont eltávolítása meghatározott pozícióban**
Ebben a példában megtanuljuk, hogyan távolítsuk el a SmartArt‑alakban lévő csomópontokat egy adott pozícióban.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) példányt, és töltse be a prezentációt SmartArt alakzattal.
1. Szerezze meg az első dia hivatkozását az indexe alapján.
1. Járja be a dián lévő összes alakzatot.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) típusú‑e, és ha igen, alakítsa át [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) típusúvá.
1. Válassza ki a SmartArt‑alak 0 indexű csomópontját.
1. Most ellenőrizze, hogy a kiválasztott SmartArt‑csomópont több mint 2 gyermekcsomópontot tartalmaz.
1. Ezután a **Position 1**‑es csomópontot távolítsa el a [**RemoveNode**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-) metódussal.
1. Mentse a prezentációt.

```javascript
// A kívánt prezentáció betöltése
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Az első dián belül lévő összes alakzat bejárása
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Az alakzat típuskonvertálása SmartArt-re
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // SmartArt csomópont elérése 0 indexen
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // A 1. pozícióban lévő gyermekcsomópont eltávolítása
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // Prezentáció mentése
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Egyéni pozíció beállítása gyermekcsomópontban a SmartArt‑ban**
Az Aspose.Slides for Node.js via Java most már támogatja a [SmartArtShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#setX-float-) és [Y](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#setY-float-) tulajdonságok beállítását. Az alábbi kódrészlet megmutatja, hogyan állítható be egy egyéni SmartArtShape pozíció, méret és forgatás; vegye figyelembe, hogy új csomópontok hozzáadása az összes csomópont pozíciójának és méretének újraszámítását eredményezi. Az egyéni pozícióbeállításokkal a felhasználó a csomópontokat a saját igényei szerint helyezheti el.

```javascript
// Prezentáció osztály példányosítása
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // SmartArt alakzat áthelyezése új pozícióba
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // SmartArt alakzat szélességének módosítása
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // SmartArt alakzat magasságának módosítása
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // SmartArt alakzat forgatásának módosítása
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Asszisztens csomópont ellenőrzése**
{{% alert color="primary" %}} 

Ebben a cikkben tovább vizsgáljuk a SmartArt‑alakok funkcióit, amelyeket programozott módon adtunk hozzá a bemutatódiákhoz az Aspose.Slides for Node.js via Java segítségével.

{{% /alert %}} 

A következő forrás‑SmartArt‑alakot használjuk az egyes szakaszokban végzett vizsgálatokhoz.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Ábra: Forrás‑SmartArt‑alak a dián**|

Az alábbi mintakódban azt vizsgáljuk, hogyan azonosíthatóak a **Assistant Nodes** a SmartArt‑csomópontgyűjteményben, és hogyan módosíthatók.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) példányt, és töltse be a prezentációt SmartArt‑alakzattal.
1. Szerezze meg a második dia hivatkozását az indexe alapján.
1. Járja be a dián lévő összes alakzatot.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) típusú‑e, és ha igen, alakítsa át [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) típusúvá.
1. Járja be az összes csomópontot a SmartArt‑alakban, és ellenőrizze, hogy [**Assistant Nodes**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtNode#isAssistant--)‑ek‑e.
1. Módosítsa az Assistant Node állapotát normál csomóponttá.
1. Mentse a prezentációt.

```javascript
// Prezentáció példány létrehozása
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // Az első dián belül lévő összes alakzat bejárása
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Az alakzat típuskonvertálása SmartArt-re
            var smart = shape;
            // Az SmartArt alakzat összes csomópontjának bejárása
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // Ellenőrizze, hogy a csomópont Assistant csomópont-e
                if (node.isAssistant()) {
                    // Az Assistant csomópont beállítása false értékre és normál csomóponttá alakítása
                    node.isAssistant();
                }
            }
        }
    }
    // Prezentáció mentése
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Ábra: Assistant Node‑ok módosítva a SmartArt‑alakban a dián**|

## **Csomópont kitöltési formátumának beállítása**
Az Aspose.Slides for Node.js via Java lehetővé teszi egyedi SmartArt‑alakok hozzáadását és azok kitöltési formátumának beállítását. Ez a cikk ismerteti, hogyan hozhatók létre és érhetők el a SmartArt‑alakok, valamint hogyan állítható be a kitöltési formátum a Aspose.Slides for Node.js via Java segítségével.

Kérjük, kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) példányt.
1. Szerezze meg egy dia hivatkozását az indexe alapján.
1. Adjon hozzá egy [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArt) alakzatot a [**LayoutType**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) beállításával.
1. Állítsa be a [**FillFormat**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getFillFormat--)‑t a SmartArt‑alak csomópontjaihoz.
1. Írja ki a módosított prezentációt PPTX fájlként.

```javascript
// A prezentáció példányosítása
var pres = new aspose.slides.Presentation();
try {
    // Dia elérése
    var slide = pres.getSlides().get_Item(0);
    // SmartArt alakzat és csomópontok hozzáadása
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // Csomópont kitöltőszínének beállítása
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // A prezentáció mentése
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt‑gyermekcsomópont bélyegképének generálása**
A fejlesztők a következő lépésekkel generálhatnak bélyegképet egy SmartArt‑gyermekcsomópontról:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) példányt.
1. [Add SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--).
1. Szerezze meg egy csomópont hivatkozását az indexe alapján.
1. Kapja meg a bélyegkép‑képet.
1. Mentse a bélyegkép‑képet a kívánt képtformátumban.

```javascript
// Példányosítja a Presentation osztályt, amely a PPTX fájlt képviseli
var pres = new aspose.slides.Presentation();
try {
    // SmartArt hozzáadása
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // Csomópont hivatkozásának lekérése az index használatával
    var node = smart.getNodes().get_Item(1);
    // Bélyegkép lekérése
    var slideImage = node.getShapes().get_Item(0).getImage();
    // Bélyegkép mentése
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Támogatott-e a SmartArt animáció?**

Igen. A SmartArt‑ot a rendszer egy szokásos alakzatként kezeli, így alkalmazhat [szabványos animációkat](/slides/hu/nodejs-java/shape-animation/) (belépés, kilépés, hangsúly, mozgási útvonal), és beállíthatja az időzítést. Szükség esetén a SmartArt‑csomópontokba ágyazott alakzatok is animálhatók.

**Hogyan találhatom meg megbízhatóan egy adott SmartArt‑ot a dián, ha a belső azonosítója ismeretlen?**

Keressen és állítson be [alternatív szöveget](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getalternativetext/). Egy jellegzetes AltText megadásával a SmartArt megtalálható anélkül, hogy a belső azonosítókra támaszkodna.

**Megmarad-e a SmartArt megjelenése a prezentáció PDF‑re konvertálásakor?**

Igen. Az Aspose.Slides a SmartArt‑ot nagy vizuális pontossággal rendereli a [PDF‑export](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) során, megőrizve a elrendezést, színeket és hatásokat.

**Kivonhatok‑e egy képet az egész SmartArt‑ról (előnézetekhez vagy jelentésekhez)?**

Igen. A SmartArt‑alakot renderelheti [raszteres formátumokba](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getImage) vagy [SVG‑be](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/writeassvg/) vektoros kimenetként, ami alkalmas bélyegképek, jelentések vagy webes felhasználás céljára.