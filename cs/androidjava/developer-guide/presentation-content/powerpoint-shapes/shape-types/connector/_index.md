---
title: Správa konektorů v prezentacích na Androidu
linktitle: Konektor
type: docs
weight: 10
url: /cs/androidjava/connector/
keywords:
- konektor
- typ konektoru
- bod konektoru
- čára konektoru
- úhel konektoru
- místo připojení
- bod úpravy
- spojit tvary
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Zjistěte, jak pomocí Aspose.Slides pro Android a Java přidávat, připojovat, přesměrovávat, upravovat a kontrolovat přímé, ohnuté a zakřivené konektory PowerPointu."
---
## **Přehled**

Konektor je čára, která může zůstat připojena ke dvěma objekty, i když se kterýkoli z objektů pohybuje. Jeho konce se připojují k místům připojení, která jsou v PowerPointu zobrazena zelenými tečkami. Některé ohnuté a zakřivené konektory také nabízejí úpravové body, zobrazované oranžovými tečkami, které řídí polohu jednotlivých segmentů konektoru.

Aspose.Slides představuje konektory prostřednictvím rozhraní [IConnector](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iconnector/) . Můžete je vytvářet, připojovat jejich konce k objektům, vybírat místa připojení, přeplánovat je a upravovat geometrii konektorů, které mají úpravové body.

## **Typy konektorů**

Třída [ShapeType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shapetype/) obsahuje předvolby přímých, ohnutých a zakřivených konektorů. Následující tabulka zobrazuje dostupné geometrie konektorů a počet úpravových bodů definovaných každou předvolbou.

| Konektor | Obrázek | Počet úpravových bodů |
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

Počet a význam úpravových bodů jsou součástí vybrané předvolby konektoru. Nepředpokládejte, že dva různé typy konektorů mají stejnou strukturu kolekce.

## **Připojení dvou objektů**

Pro přidání konektoru použijte [IShapeCollection.addConnector](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-), a pro připojení jeho konců použijte [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) a [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-). Po připojení obou konců se pomocí [IConnector.reroute](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iconnector/#reroute--) vybere krátká trasa mezi objekty.

Následující příklad spojuje elipsu a obdélník pomocí ohnutého konektoru:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Volání `reroute` může změnit hodnoty [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) a [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-). Přiřaďte specifická místa připojení po přepočtu, pokud musí tato místa zůstat pevná.
{{% /alert %}}

## **Výběr místa připojení**

Každý připojitelný objekt udává svůj počet míst přes [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--). Ověřte preferovaný nulový index místa před jeho přiřazením ke konektoru; počet míst se liší podle geometrie objektu.

Tento příklad připojuje konektor k určitému místu na elipse, pokud toto místo existuje:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    long preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        System.out.println("The ellipse has only " + ellipse.getConnectionSiteCount() + " connection sites.");
    }

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Úprava bodu konektoru**

Konektory s úpravovými body je zpřístupňuje [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--). Prohlédněte každý [IAdjustValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iadjustvalue/) a před změnou zkontrolujte jeho hodnotu [getType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iadjustvalue/#getType--) pomocí [setRawValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-). Obecná pravidla pro identifikaci úprav předdefinovaných tvarů jsou popsána v [Shape Manipulation](/slides/cs/androidjava/shape-manipulations/).

Počet, pořadí, význam a platný rozsah hodnot úprav konektoru závisí na předvolbě konektoru. Typ úpravy je pouze pro čtení, zatímco hodnota úpravy je zapisovatelná. Metoda pouze pro čtení [getName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iadjustvalue/#getName--) poskytuje další identifikaci, když konektor obsahuje více úprav stejného sémantického typu.

### **Obejít překážku**

V následujícím uspořádání prochází konektor `BentConnector5` mezi dvěma objekty třetím objektem:

![connector-obstruction](connector-obstruction.png)

Tento kód vytvoří překážkou blokovaný konektor:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Posunutím svislého ohybu se změní trasa tak, že konektor obehne překážku:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Místo předpokladu, že index kolekce `1` vždy představuje svislý ohyb, tento příklad hledá `ConnectorBendPositionY` a mění jej pouze tehdy, když je přítomen očekávaný sémantický typ:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend == null) {
        System.out.println("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

`BentConnector5` má dvě úpravy `ConnectorBendPositionX` a jednu úpravu `ConnectorBendPositionY`. Pokud potřebný typ výskytuje vícekrát, prozkoumejte `getName` a známou geometrii předvolby, než vyberete konkrétní výskyt. Pokud úprava vrací `ShapeAdjustmentType.Custom`, považujte její význam a rozsah za specifické pro předvolbu a neměňte ji, dokud nebudete znát příslušnou smlouvu.

## **Vztah hodnot úprav k geometrii konektoru**

U ohnutých konektorů lze hodnoty úprav použít k odhadu polohy jednotlivých segmentů. Výpočty jsou specifické pro konkrétní předvolbu konektoru:

- `BentConnector4` běžně zpřístupňuje jednu úpravu `ConnectorBendPositionX` a jednu úpravu `ConnectorBendPositionY`.
- Pro tyto pozice ohybu vydělením hodnoty vrácené metodou `getRawValue` číslem `100000f` získáte zlomek šířky nebo výšky rámce konektoru, který se používá v následujících příkladech.
- Rámec konektoru může být otočen nebo převrácen, takže souřadnice rámce je třeba transformovat před jejich porovnáním se souřadnicemi snímku.

Následující příklady nejprve používají `getType` k identifikaci úprav. Nepoužívají indexy kolekce jako přenosné identifikátory.

### **Nepootočený konektor**

Počáteční uspořádání obsahuje dva textové objekty spojené `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Tento příklad prozkoumá konektor a získá jeho horizontální a vertikální úpravy ohybu:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
    }
} finally {
    presentation.dispose();
}
```

Pro změnu obou ohybů najděte každý očekávaný typ a upravte hodnoty až po nalezení obou:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Výsledkem je konektor, jehož horizontální a vertikální segmenty se posunuly:

![connector-adjusted-1](connector-adjusted-1.png)

Jakmile jsou sémantické typy známy, lze jejich hodnoty převést na souřadnice rámce konektoru. Tento příklad nakreslí tenký obdélník přes vertikální segment řízený oběma úpravami ohybu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        float x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float y = connector.getY();
        float height = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height);
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Vodící tvar označuje vypočítaný segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Otočený nebo převrácený konektor**

Když je stejná geometrii konektoru orientována svisle, hodnoty [IShape.getFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shapeframe/#getFlipH--) a [ShapeFrame.getFlipV](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shapeframe/#getFlipV--) ovlivňují převod ze souřadnic rámce konektoru na souřadnice snímku.

Tento příklad vytvoří a upraví svisle orientovaný konektor:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    int connectorColor = Color.rgb(102, 205, 170);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Upravený konektor se zobrazí svisle mezi objekty:

![connector-adjusted-3](connector-adjusted-3.png)

Pro libovolný úhel otáčení `alpha` otáčejte bod rámce konektoru `(x, y)` kolem středu rámce `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Následující kód zpracuje orientaci o 90 stupňů použitou v tomto příkladu a nakreslí červenou vodítko přes odpovídající segment konektoru:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        float x = connector.getX();
        float y = connector.getY();
        if (connector.getFrame().getFlipH() == NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() == NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        float rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        float segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Červená vodítko označuje vypočítaný segment po transformaci souřadnic:

![connector-adjusted-4](connector-adjusted-4.png)

Tyto vzorce popisují předvolby použité v příkladech, ne univerzální model konektoru. Před použitím stejného výpočtu pro jinou předvolbu ověřte typy úprav, orientaci rámce a rozsahy hodnot.

## **Najděte úhel směru konektoru**

Směr přímého konektoru lze vypočítat z jeho šířky a výšky s ohledem na horizontální a vertikální převrácení. Následující příklad uvádí úhel ve směru hodinových ručiček od kladné vodorovné osy ve souřadnicích snímku:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

    boolean flipH = connector.getFrame().getFlipH() == NullableBool.True;
    boolean flipV = connector.getFrame().getFlipV() == NullableBool.True;
    float deltaX = connector.getWidth() * (flipH ? -1 : 1);
    float deltaY = connector.getHeight() * (flipV ? -1 : 1);
    double angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    System.out.printf("Connector direction: %.2f degrees%n", angle);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jak zjistím, zda se konektor může připojit k objektu?**

Zkontrolujte hodnotu [getConnectionSiteCount](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--) u objektu. Kladný počet znamená, že objekt nabízí místa připojení. Ověřte vybraný index místa před jeho přiřazením ke konci konektoru.

**Mohu identifikovat úpravu konektoru podle jejího indexu v kolekci?**

Index má smysl pouze pro známou předvolbu konektoru a uspořádání kolekce. Před úpravou hodnoty zkontrolujte [IAdjustValue.getType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iadjustvalue/#getType--), a použijte [IAdjustValue.getName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iadjustvalue/#getName--) jako doplňující informaci, když se stejný sémantický typ vyskytuje vícekrát.

**Co se stane, když je připojený objekt smazán?**

Příslušný konec konektoru se odpojí. Konektor zůstane na snímku a může být smazán, umístěn jako volná čára nebo připojen k jinému objektu.

**Zůstávají vazby konektoru zachovány při kopírování snímku?**

Vazby jsou obecně zachovány, pokud jsou připojené objekty kopírovány spolu se snímkem. Pokud je konektor zkopírován bez jednoho ze svých cílových objektů, musíte dotýkaný konec připojit znovu.