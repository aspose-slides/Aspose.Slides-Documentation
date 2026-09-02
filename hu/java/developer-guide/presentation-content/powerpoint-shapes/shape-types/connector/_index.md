---
title: Java prezentációkban a kapcsolók kezelése
linktitle: Kapcsoló
type: docs
weight: 10
url: /hu/java/connector/
keywords:
- kapcsoló
- kapcsolótípus
- kapcsolópont
- kapcsolóvonal
- kapcsolószög
- csatlakozási hely
- igazítási pont
- alakzatok csatlakoztatása
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet hozzáadni, csatlakoztatni, újratervezni, igazítani és ellenőrizni egyenes, hajlított és ívelt PowerPoint-kapcsolókat az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

A kapcsoló egy vonal, amely két alakzatra is csatlakoztatva maradhat, amikor bármelyik alakzat mozog. Végpontjai csatlakozási helyekhez (connection sites) rögzülnek, amelyeket a PowerPointban zöld pontok jelölnek. Néhány hajlított és ívelt kapcsoló is megjeleníti az igazítási pontokat, amelyek narancssárga pontokként láthatók, és az egyes kapcsoló szegmensek pozícióját szabályozzák.

Az Aspose.Slides a kapcsolókat az [IConnector](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iconnector/) interfészen keresztül ábrázolja. Létrehozhatja őket, csatlakoztathatja a végeiket alakzatokhoz, kiválaszthatja a csatlakozási helyeket, újratervezheti őket, és módosíthatja azoknak a kapcsolóknak a geometriáját, amelyek rendelkeznek igazítási pontokkal.

## **Kapcsolótípusok**

A [ShapeType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapetype/) osztály tartalmazza az egyenes, hajlított és ívelt kapcsoló előbeállításokat. Az alábbi táblázat a rendelkezésre álló kapcsológeometriákat és az egyes előbeállítások által definiált igazítási pontok számát mutatja.

| Kapcsoló | Kép | Az igazítási pontok száma |
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

Az igazítási pontok száma és jelentése a kiválasztott kapcsoló előbeállítás része. Ne feltételezze, hogy két különböző kapcsolótípus ugyanazt a gyűjteményelrendezést mutatja.

## **Két alakzat összekapcsolása**

Használja az [IShapeCollection.addConnector](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) metódust egy kapcsoló hozzáadásához, és az [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) valamint az [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) metódusokat a végeinek csatlakoztatásához. Miután mindkét vég csatlakoztatva van, az [IConnector.reroute](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iconnector/#reroute--) egy rövid útvonalat választ ki az alakzatok között.

Az alábbi példa egy ellipszist és egy téglalapot kapcsol össze hajlított kapcsolóval:

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
`reroute` meghívása megváltoztathatja a [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) és a [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-) értékeket. Ha a csatlakozási helyeknek rögzítve kell maradniuk, rendelje hozzá őket a újratervezés után.
{{% /alert %}}

## **Csatlakozási hely kiválasztása**

Az egyes csatlakoztatható alakzatok a csatlakozási helyek számát a [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getConnectionSiteCount--) metódussal adják meg. Ellenőrizze a kívánt, nullával kezdődő helyindexet, mielőtt a kapcsoló végéhez rendeli; a helyek száma alakzat geometriától függ.

Ez a példa a kapcsolatot a megfelelő csatlakozási helyhez rögzíti az ellipszen, ha az a hely létezik:

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

## **Kapcsoló pont igazítása**

Az igazítási pontokkal rendelkező kapcsolók ezeket az [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/hu/java/com.aspose.slides/igeometryshape/#getAdjustments--) metódussal teszik elérhetővé. Vizsgálja meg minden [IAdjustValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iadjustvalue/) objektumot, és ellenőrizze a [getType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iadjustvalue/#getType--) értékét, mielőtt a [setRawValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) metódussal módosítaná. A shape‑manipulációs előbeállítások általános szabályait a [Shape Manipulation](/slides/hu/java/shape-manipulations/) részben találja.

Az igazítási pontok száma, sorrendje, jelentése és az érvényes értéktartomány a kapcsoló előbeállítástól függ. Az igazítás típusa csak olvasható, míg az értéke írható. Az csak‑olvasásra szóló [getName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iadjustvalue/#getName--) metódus további azonosítást biztosít, ha egy kapcsoló ugyanabból a szemantikai típusból több igazítást tartalmaz.

### **Út egy akadály körül**

Az alábbi elrendezésben egy `BentConnector5` kapcsoló két alakzat között egy harmadik alakzaton megy át:

![connector-obstruction](connector-obstruction.png)

Ez a kód létrehozza az akadályt okozó kapcsolatot:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

A függőleges hajlítás mozgatása megváltoztatja az útvonalat, így a kapcsoló megkerüli az akadályt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Anélkül, hogy feltételezné, hogy a `1` index mindig a függőleges hajlítást jelöli, ez a példa a `ConnectorBendPositionY` értéket keresi, és csak akkor módosítja, ha a várt szemantikai típus jelen van:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Egy `BentConnector5` két `ConnectorBendPositionX` és egy `ConnectorBendPositionY` igazítást tartalmaz. Ha a szükséges típus többször is előfordul, vizsgálja meg a `getName` értéket és az adott előbeállítás ismert geometriáját, mielőtt kiválasztaná. Ha egy igazítás `ShapeAdjustmentType.Custom` típusú, kezelje jelentését és tartományát az adott előbeállítás specifikusnak, és ne módosítsa, amíg a szerződés nem ismert.

## **Az igazítási értékek kapcsolása a kapcsoló geometriához**

Hajlított kapcsolók esetén az igazítási értékek felhasználhatók az egyes szegmensek pozíciójának becslésére. Ezek a számítások a kapcsoló előbeállításra specifikusak:

- `BentConnector4` általában egy `ConnectorBendPositionX` és egy `ConnectorBendPositionY` igazítást tesz elérhetővé.
- Ezeknél a hajlítási pozícióknál a `getRawValue` által visszaadott érték `100000f`-el való osztása adja meg a kapcsoló keret szélességének vagy magasságának a hányadát, ahogy az alább látható példákban.
- Egy kapcsolókeret elfordítható vagy tükrözhető, ezért a keret koordinátákat át kell alakítani, mielőtt a diakoordinátákkal összehasonlítaná őket.

Az alábbi példák először a `getType` segítségével azonosítják az igazításokat. Nem tekintik a gyűjtemény indexeket hordozható azonosítóknak.

### **Forgatás nélküli kapcsoló**

A kezdeti elrendezés két szöveges alakzatot tartalmaz, amelyeket egy `BentConnector4` köt össze:

![connector-shape-complex](connector-shape-complex.png)

Ez a példa a kapcsolót vizsgálja, és lekéri a vízszintes és függőleges hajlítási igazításokat:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Mindkét hajlítás módosításához keresse meg a várt típusokat, és csak akkor változtassa meg az értékeket, ha mindkettőt megtalálta:

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

Az eredmény egy olyan kapcsoló, amelynek vízszintes és függőleges szegmensei elmozdultak:

![connector-adjusted-1](connector-adjusted-1.png)

Ha már ismertek a szemantikai típusok, értékeik átalakíthatók a kapcsoló‑keret koordinátákká. Ez a példa egy vékony téglalapot rajzol a két hajlítás által vezérelt függőleges szegmens fölé:

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

Az útmutató alakzat jelöli a kiszámított szegmenst:

![connector-adjusted-2](connector-adjusted-2.png)

### **Forgatott vagy tükrözött kapcsoló**

Ha ugyanaz a kapcsológeometria függőlegesen van elhelyezve, akkor a [IShape.getFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getFrame--), a [ShapeFrame.getFlipH](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapeframe/#getFlipH--) és a [ShapeFrame.getFlipV](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapeframe/#getFlipV--) értékek hatással vannak a kapcsoló‑keret koordináták és a diakoordináták közti átalakításra.

Ez a példa a függőlegesen orientált kapcsolót hozza létre és állítja be:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(102, 205, 170));
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

Az beállított kapcsoló függőlegesen jelenik meg az alakzatok között:

![connector-adjusted-3](connector-adjusted-3.png)

Tetszőleges forgatási szög `alpha` esetén egy `(x, y)` pontot a keretközéppont `(x0, y0)` körül a következőképpen kell elforgatni:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Az alábbi kód kezeli a példában használt 90‑fokos orientációt, és piros útmutatót rajzol a megfelelő kapcsoló szegmens fölé:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

A piros útmutató jelöli a koordináta‑átalakítás után kiszámított szegmenst:

![connector-adjusted-4](connector-adjusted-4.png)

Ezek a képletek a példákban használt előbeállításokat írják le, nem egy általános kapcsoló modellt. Minden egyes előbeállítás használata előtt ellenőrizze az igazítási típusokat, a keret orientációját és az értéktartományokat.

## **Kapcsoló irányszög megtalálása**

Egy egyenes kapcsoló iránya a szélesség és magasság alapján számítható ki, a vízszintes és függőleges tükrözésekkel együtt. Az alábbi példa visszaadja az óramutatóval megegyező szöget a pozitív vízszintes tengelyhez képest a diakoordinátákban:

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

## **GYIK**

**Hogyan tudom megmondani, hogy egy kapcsoló csatlakoztatható-e egy alakzathoz?**

Ellenőrizze az alakzat [getConnectionSiteCount](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getConnectionSiteCount--) értékét. A pozitív szám azt jelenti, hogy az alakzat csatlakozási helyeket biztosít. A választott helyindexet ellenőrizze, mielőtt bármelyik kapcsoló végéhez rendeli.

**Azonosíthatom a kapcsoló igazítását a gyűjtemény indexével?**

Az index csak akkor értelmezhető, ha a kapcsoló előbeállítása és a gyűjteményelrendezés ismert. Módosítás előtt ellenőrizze az [IAdjustValue.getType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iadjustvalue/#getType--) értékét, és ha ugyanaz a szemantikai típus többször előfordul, a [IAdjustValue.getName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iadjustvalue/#getName--) további információt nyújt.

**Mi történik, ha a csatlakoztatott alakzatot törlik?**

A kapcsoló megfelelő vége leválik. A kapcsoló továbbra is a dián marad, törölhető, szabad vonalként pozicionálható vagy egy másik alakzathoz csatlakoztatható.

**Megmaradnak a kapcsolók kötései, ha egy diát másolnak?**

A kötéseket általában megőrzik, ha a csatlakoztatott alakzatokkal együtt másolják a diát. Ha egy kapcsolót másolnak anélkül, hogy a célalakzatok egyike is másolva lenne, az érintett véget újra csatlakoztatni kell.