---
title: Spravovat SmartArt v prezentacích PowerPoint pomocí JavaScriptu
linktitle: Spravovat SmartArt
type: docs
weight: 10
url: /cs/nodejs-java/manage-smartart/
keywords:
- SmartArt
- Text SmartArtu
- Typ rozložení
- Skrytá vlastnost
- Organizační diagram
- Obrázkový organizační diagram
- PowerPoint
- Prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se vytvářet a upravovat PowerPoint SmartArt pomocí Aspose.Slides pro Node.js s přehlednými ukázkami kódu v JavaScriptu, které urychlují návrh snímků a automatizaci."
---
## **Přehled**

SmartArt je diagram v PowerPointu složený z uzlů, tvarů uzlů a rozložení. S Aspose.Slides pro Node.js přes Java můžete vytvářet SmartArt, číst text z jeho uzlů, měnit jeho rozložení, kontrolovat skryté uzly, konfigurovat rozložení organizačních diagramů a vytvářet obrázkové organizační diagramy.

## **Získání textu z objektu SmartArt**

Uzel SmartArt může obsahovat jeden nebo více tvarů. Pro čtení textu z tvarů uzlu projděte [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/), poté přečtěte [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/), který vrací [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/).

Příklad vyžaduje prezentaci s alespoň jedním snímkem a objekt SmartArt jako první tvar na tomto snímku. Vypíše každý dostupný textový rámeček do konzole.

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

## **Změna typu rozložení objektu SmartArt**

Rozložení SmartArt určuje, jak jsou uzly uspořádány a propojeny. Následující příklad vytvoří objekt SmartArt s hodnotou [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, změní ji na hodnotu `BasicProcess` a uloží prezentaci. Pozice a velikost předávané metodě [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) jsou měřeny v bodech. K změně rozložení použijte [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/).

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

## **Kontrola, zda je uzel SmartArt skrytý**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) určuje, zda je uzel skrytý v datovém modelu SmartArt. Skryté uzly mohou ve struktuře existovat i v případě, že vybrané rozložení je nezobrazuje jako viditelné prvky diagramu.

Následující příklad přidá uzel do objektu SmartArt, který používá hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle`, a zkontroluje stav skrytí přidaného uzlu. Vytiskne zprávu, pokud je uzel skrytý, a uloží diagram.

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

## **Získání nebo nastavení rozložení organizačního diagramu**

U diagramů SmartArt, které používají rozložení organizačního diagramu, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) a [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) určují, jak jsou podřízené uzly uspořádány pod nadřazeným uzlem. Například můžete nastavit, aby se podřízené uzly visely zleva, zprava nebo z obou stran, v závislosti na vybraném [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/).

Následující příklad vytvoří organizační diagram a nastaví rozložení prvního uzlu na hodnotu [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. Index založený na nule `0` vybírá první uzel na nejvyšší úrovni; jeho podřízené uzly použijí vybrané uspořádání. Upravená prezentace je poté uložena.

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

## **Vytvoření obrázkového organizačního diagramu**

Obrázkový organizační diagram je rozložení SmartArt určené pro hierarchické diagramy, které obsahují zástupné obrázky. Při přidávání objektu SmartArt na snímek použijte hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`. Tento příklad uloží diagram se zástupnými obrázky; nevyplní však zástupce obrázky.

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

## **Převod starých diagramů na skupiny tvarů**

Při modernizaci existující prezentace můžete potřebovat aktualizovat organizační diagram původně vytvořený v PowerPointu 97–2003. Aspose.Slides představuje tyto staré diagramy jako objekty [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/). Použijte [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/), abyste diagram převedli na skupinu tvarů, což umožní upravovat jednotlivé vizuální prvky. Podrobnosti naleznete v [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/).

Převod přidá novou skupinu do kolekce tvarů, aniž by odstranil původní diagram. Po úspěšném převodu odstraňte původní pomocí [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/), abyste se vyhnuli duplicitnímu obsahu. Před převodem shromážděte staré diagramy do seznamu, aby přidávání a odebírání tvarů neovlivnilo iteraci.

Následující příklad otevře prezentaci, prohledá každý snímek, převede diagramy na skupiny tvarů a uloží aktualizovanou prezentaci jako PPTX.

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

Uložená prezentace obsahuje editovatelné skupiny tvarů místo převedených starých diagramů, bez původních diagramů vedle nich. Otevřete PPTX v PowerPointu a upravujte jednotlivé prvky v každé skupině, jako je jejich text, výplň nebo pozice.

## **Často kladené otázky**

**Podporuje SmartArt zrcadlení nebo obrácení pro RTL jazyky?**

Ano. Metoda [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) přepíná směr diagramu z left‑to‑right na right‑to‑left, nebo zpět, pokud vybrané rozložení SmartArt podporuje obrácení.

**Jak mohu zkopírovat SmartArt na stejný snímek nebo do jiné prezentace při zachování formátování?**

Můžete [klonovat tvar SmartArt](/slides/cs/nodejs-java/shape-manipulations/) pomocí [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) nebo [klonovat celý snímek](/slides/cs/nodejs-java/clone-slides/), který SmartArt obsahuje. Oba přístupy zachovávají velikost, pozici a formátování.

**Jak mohu vykreslit SmartArt do rastrového obrázku pro náhled nebo export na web?**

[Vykreslete snímek](/slides/cs/nodejs-java/convert-powerpoint-to-png/) nebo celou prezentaci do PNG nebo JPEG. SmartArt je vykreslen jako součást snímku.

**Jak mohu najít konkrétní objekt SmartArt na snímku, pokud jich je několik?**

Použijte [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) nebo [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/), abyste přiřadili výrazný alternativní text nebo název tvaru SmartArt, vyhledejte tuto hodnotu v [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), a poté ověřte, že odpovídající tvar je [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/).