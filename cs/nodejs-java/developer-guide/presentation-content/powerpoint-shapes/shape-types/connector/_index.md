---
title: Správa konektorů v prezentacích pomocí JavaScriptu
linktitle: Konektor
type: docs
weight: 10
url: /cs/nodejs-java/connector/
keywords:
- konektor
- typ konektoru
- bod konektoru
- čára konektoru
- úhel konektoru
- místo připojení
- bod úpravy
- propojit tvary
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro Node.js a Java přidávat, připojovat, přepočítávat, upravovat a zkoumat rovné, ohnuté a zakřivené konektory v PowerPointu."
---
## **Přehled**

Konektor je čára, která může zůstat připojena ke dvěma tvarem, když se kterýkoli z tvarů pohybuje. Jeho konce jsou připojeny k místům připojení, která jsou v PowerPointu zobrazena zelenými tečkami. Některé ohnuté a zakřivené konektory také zobrazují body úpravy, které jsou reprezentovány oranžovými tečkami a řídí polohu jednotlivých úseků konektoru.

Aspose.Slides představuje konektory pomocí třídy [Connector](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/connector/). Můžete je vytvářet, připojovat jejich konce k tvarům, vybírat místa připojení, přepočítávat je a upravovat geometrii konektorů, které mají body úpravy.

## **Typy konektorů**

Třída [ShapeType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapetype/) obsahuje předvolby pro rovné, ohnuté a zakřivené konektory. Následující tabulka ukazuje dostupné geometrie konektorů a počet bodů úpravy definovaných pro každou předvolbu.

| Konektor | Obrázek | Počet bodů úpravy |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Počet a význam bodů úpravy jsou součástí vybrané předvolby konektoru. Nepředpokládejte, že dva různé typy konektorů zobrazují stejnou strukturu kolekce.

## **Propojení dvou tvarů**

Pro přidání konektoru použijte [ShapeCollection.addConnector](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/addconnector/) a pro připojení jeho konců použijte [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) a [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/connector/setendshapeconnectedto/). Po připojení obou konců [Connector.reroute](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/connector/reroute/) vybere nejkratší trasu mezi tvary.

Následující příklad spojuje elipsu a obdélník pomocí ohnutého konektoru:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}

Volání `reroute` může změnit hodnoty [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) a [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Po přepočítání přiřaďte konkrétní místa připojení, pokud mají zůstat pevná.

{{% /alert %}}

## **Výběr místa připojení**

Každý propojitelný tvar uvádí svůj počet míst pomocí [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Ověřte preferovaný index místa (nula‑založený) před jeho přiřazením ke konci konektoru; počet míst se liší podle geometrie tvaru.

Tento příklad připojuje konektor k určitému místu na elipse, pokud toto místo existuje:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    const preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        console.log(`The ellipse has only ${ellipse.getConnectionSiteCount()} connection sites.`);
    }

    presentation.save("specific-connection-site.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Úprava bodu konektoru**

Konektory s body úpravy je odhalují pomocí [GeometryShape.getAdjustments](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/geometryshape/). Prohlédněte si každou [AdjustValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/adjustvalue/) a před změnou zkontrolujte její hodnotu [getType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/adjustvalue/). Obecná pravidla pro rozpoznání předvoleb úprav tvarů jsou popsána v článku [Shape Manipulation](/slides/cs/nodejs-java/shape-manipulations/).

Počet, pořadí, význam a platný rozsah hodnot úprav konektoru závisí na předvolbě konektoru. Typ úpravy je jen pro čtení, zatímco hodnota úpravy je zapisovatelná. Metoda jen pro čtení [getName](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/adjustvalue/getname/) poskytuje dodatečnou identifikaci, když konektor obsahuje více úprav stejného sémantického typu.

### **Obcházení překážky**

V následujícím uspořádání prochází konektor `BentConnector5` mezi dvěma tvary třetím tvarem:

![connector-obstruction](connector-obstruction.png)

Tento kód vytvoří omezený konektor:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Posunutí svislého ohybu změní trasu tak, že konektor obejde překážku:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Místo předpokládání, že index kolekce `1` vždy představuje svislý ohyb, tento příklad hledá `ConnectorBendPositionY` a mění jej jen tehdy, když je přítomen očekávaný sémantický typ:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend === null) {
        console.log("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Konektor `BentConnector5` má dva nastavení `ConnectorBendPositionX` a jedno nastavení `ConnectorBendPositionY`. Pokud typ, který potřebujete, se vyskytuje vícekrát, prozkoumejte `getName` a známou geometrii této předvolby, než jeden vyberete. Pokud úprava hlásí `ShapeAdjustmentType.Custom`, považujte její význam a rozsah za specifické pro předvolbu a neměňte ji, dokud není tento kontrakt znám.

## **Vztah hodnot úprav k geometrii konektoru**

U ohnutých konektorů lze hodnoty úprav použít k odhadu polohy jednotlivých úseků. Tyto výpočty jsou specifické pro konkrétní předvolbu konektoru:

- `BentConnector4` normálně odhaluje jednu úpravu `ConnectorBendPositionX` a jednu `ConnectorBendPositionY`.
- Pro tyto pozice ohybu vydělením hodnoty vrácené metodou `getRawValue` číslem `100000` získáte zlomek šířky nebo výšky rámce konektoru, jak ukazují níže uvedené příklady.
- Rámec konektoru může být otočen nebo převrácen, takže souřadnice rámce je třeba transformovat před porovnáním se souřadnicemi snímku.

Následující příklady nejprve používají `getType` k identifikaci úprav. Nepoužívají indexy kolekce jako přenositelné identifikátory.

### **Neotočený konektor**

Úvodní uspořádání obsahuje dva textové tvary spojené `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Tento příklad prozkoumává konektor a získává jeho horizontální a vertikální úpravy ohybu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
    }
} finally {
    presentation.dispose();
}
```

Pro změnu obou ohybů najděte každý očekávaný typ a upravte hodnoty až po jejich nalezení:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Výsledkem je konektor, jehož horizontální a vertikální úseky se posunuly:

![connector-adjusted-1](connector-adjusted-1.png)

Jakmile jsou známé sémantické typy, lze jejich hodnoty převést na souřadnice rámce konektoru. Tento příklad nakreslí úzký obdélník přes vertikální úsek řízený dvěma ohyby:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        const x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const y = connector.getY();
        const height = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(x);
        const guideY = java.newFloat(y);
        const guideWidth = java.newFloat(1);
        const guideHeight = java.newFloat(height);
        slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        presentation.save("connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Pomocný tvar označuje vypočítaný úsek:

![connector-adjusted-2](connector-adjusted-2.png)

### **Otočený nebo převrácený konektor**

Když je stejná geometrie konektoru orientována svisle, její hodnoty [Shape.getFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getframe/), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapeframe/getfliph/), a [ShapeFrame.getFlipV](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapeframe/getflipv/) ovlivňují převod ze souřadnic rámce konektoru na souřadnice snímku.

Tento příklad vytváří a upravuje svisle orientovaný konektor:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const connectorColor = java.newInstanceSync("java.awt.Color", 102, 205, 170);
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Upravený konektor se zobrazí svisle mezi tvary:

![connector-adjusted-3](connector-adjusted-3.png)

Pro libovolný úhel otočení `alpha` otočte bod rámce konektoru `(x, y)` kolem středu rámce `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Následující kód řeší orientaci o 90 stupňů použité v tomto příkladu a nakreslí červenou vodítko přes odpovídající úsek konektoru:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        let x = connector.getX();
        let y = connector.getY();
        if (connector.getFrame().getFlipH() === aspose.slides.NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() === aspose.slides.NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        const rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        const segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(rotatedX);
        const guideY = java.newFloat(rotatedY);
        const guideWidth = java.newFloat(segmentWidth);
        const guideHeight = java.newFloat(1);
        const guide = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        const red = java.getStaticFieldValue("java.awt.Color", "RED");
        const solidFillType = java.newByte(aspose.slides.FillType.Solid);
        guide.getLineFormat().getFillFormat().setFillType(solidFillType);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

        presentation.save("rotated-connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Červená vodítko označuje vypočítaný úsek po transformaci souřadnic:

![connector-adjusted-4](connector-adjusted-4.png)

Tyto vzorce popisují předvolby použité v příkladech, ne univerzální model konektoru. Ověřte typy úprav, orientaci rámce a rozsahy hodnot před aplikací stejných výpočtů na jinou předvolbu.

## **Nalezení úhlu směru konektoru**

Směr rovného konektoru lze vypočítat ze šířky a výšky s aplikovanými horizontálními a vertikálními převráceními. Následující příklad uvádí úhel po směru hodinových ručiček od kladné vodorovné osy ve snímkových souřadnicích:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 100, 100, 200, 100);

    const flipH = connector.getFrame().getFlipH() === aspose.slides.NullableBool.True;
    const flipV = connector.getFrame().getFlipV() === aspose.slides.NullableBool.True;
    const deltaX = connector.getWidth() * (flipH ? -1 : 1);
    const deltaY = connector.getHeight() * (flipV ? -1 : 1);
    let angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    console.log(`Connector direction: ${angle.toFixed(2)} degrees`);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Jak zjistit, zda se konektor může připojit k tvaru?**

Zkontrolujte hodnotu [getConnectionSiteCount](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getconnectionsitecount/) tvaru. Kladný počet znamená, že tvar vystavuje místa připojení. Ověřte vybraný index místa před jeho přiřazením ke kterémukoli konci konektoru.

**Mohu identifikovat úpravu konektoru podle jejího indexu v kolekci?**

Index má smysl pouze pro známou předvolbu konektoru a uspořádání kolekce. Před modifikací hodnoty zkontrolujte [AdjustValue.getType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/adjustvalue/) a použijte [AdjustValue.getName](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/adjustvalue/getname/) jako doplňující informaci, když se stejný sémantický typ vyskytuje vícekrát.

**Co se stane, když je připojený tvar smazán?**

Příslušný konec konektoru se odpojí. Konektor zůstane na snímku a může být smazán, umístěn jako volná čára nebo připojen k jinému tvaru.

**Zůstávají vazby konektorů zachovány při kopírování snímku?**

Vazby jsou obecně zachovány, když jsou připojené tvary kopírovány spolu se snímkem. Pokud je konektor zkopírován bez jednoho ze svých cílových tvarů, je třeba postižený konec znovu připojit.