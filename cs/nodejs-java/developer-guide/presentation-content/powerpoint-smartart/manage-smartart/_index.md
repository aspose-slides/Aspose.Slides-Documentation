---
title: Správa SmartArt v prezentacích PowerPoint pomocí JavaScriptu
linktitle: Správa SmartArt
type: docs
weight: 10
url: /cs/nodejs-java/manage-smartart/
keywords:
- SmartArt
- Text SmartArt
- typ rozvržení
- skrytá vlastnost
- organizační diagram
- obrázkový organizační diagram
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se vytvářet a upravovat SmartArt v PowerPointu pomocí Aspose.Slides pro Node.js s přehlednými ukázkami kódu v JavaScriptu, které urychlí návrh snímků a automatizaci."
---
## **Přehled**

SmartArt je diagram PowerPointu složený z uzlů, tvarů uzlů a rozvržení. S Aspose.Slides pro Node.js přes Java můžete vytvářet SmartArt, číst text z jeho uzlů, měnit jeho rozvržení, prohlížet skryté uzly, konfigurovat rozvržení organizačních diagramů a vytvářet obrázkové organizační diagramy.

## **Získání textu z objektu SmartArt**

Uzel SmartArt může obsahovat jeden nebo více tvarů. Pro přečtení viditelného textu iterujte přes [SmartArt.getAllNodes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartart/#getAllNodes--), poté přečtěte [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) který vrací [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartartshape/#getTextFrame--).

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

## **Změna typu rozvržení objektu SmartArt**

Rozvržení SmartArt určuje, jak jsou uzly uspořádány a propojeny. Následující příklad vytvoří objekt SmartArt s hodnotou [SmartArtLayoutType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, změní ji na hodnotu `BasicProcess` a uloží prezentaci.

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

## **Kontrola, zda je uzel SmartArt skrytý**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartartnode/ishidden/) udává, zda je uzel skrytý v datovém modelu SmartArt. Skryté uzly mohou existovat ve struktuře i v případě, že vybrané rozvržení je nezobrazuje jako viditelné prvky diagramu.

Následující příklad přidá uzel do objektu SmartArt, který používá hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle`, a zkontroluje stav skrytí uzlu.

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

## **Získání nebo nastavení rozvržení organizačního diagramu**

U diagramů SmartArt, které používají rozvržení organizačního diagramu, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) a [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) určují, jak jsou podřazené uzly uspořádány pod nadřazeným uzlem. Například můžete nastavit, aby podřazené uzly visely zleva, zprava nebo z obou stran, v závislosti na vybraném [OrganizationChartLayoutType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/organizationchartlayouttype/).

Následující příklad vytvoří organizační diagram a nastaví rozvržení pro první uzel na hodnotu [OrganizationChartLayoutType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

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

## **Vytvoření obrázkového organizačního diagramu**

Obrázkový organizační diagram je rozvržení SmartArt určené pro hierarchické diagramy, které obsahují zástupce obrázků. Při přidávání objektu SmartArt na snímek použijte hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`.

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

## **Často kladené otázky**

**Podporuje SmartArt zrcadlení nebo obrácení pro jazyky RTL?**

Ano. Metoda [SmartArt.setReversed](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartart/setreversed/) přepíná směr diagramu z levého na pravý na pravý na levý, nebo zpět, pokud vybrané rozvržení SmartArt podporuje obrácení.

**Jak mohu zkopírovat SmartArt na stejný snímek nebo do jiné prezentace při zachování formátování?**

Můžete [klonovat tvar SmartArt](/slides/cs/nodejs-java/shape-manipulations/) pomocí [ShapeCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/addclone/) nebo [klonovat celý snímek](/slides/cs/nodejs-java/clone-slides/) který SmartArt obsahuje. Oba přístupy zachovávají velikost, umístění i formátování.

**Jak mohu vykreslit SmartArt do rastrového obrázku pro náhled nebo export na web?**

[Vykreslete snímek](/slides/cs/nodejs-java/convert-powerpoint-to-png/) nebo celou prezentaci do PNG nebo JPEG. SmartArt je vykreslen jako součást snímku.

**Jak mohu najít konkrétní objekt SmartArt na snímku, pokud jich je několik?**

Nastavte výraznou hodnotu [Shape.setAlternativeText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/setalternativetext/) nebo [Shape.setName](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/setname/) na tvar SmartArt, vyhledejte tuto hodnotu v [BaseSlide.getShapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/#getShapes), a následně ověřte, že odpovídající tvar je [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartart/).