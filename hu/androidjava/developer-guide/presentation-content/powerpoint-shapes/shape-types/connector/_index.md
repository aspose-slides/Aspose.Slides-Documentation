---
title: "Csatlakozók kezelése Android prezentációkban"
linktitle: "Csatlakozó"
type: docs
weight: 10
url: /hu/androidjava/connector/
keywords:
- csatlakozó
- csatlakozó típus
- csatlakozó pont
- csatlakozó vonal
- csatlakozó szög
- csatlakozási hely
- igazítási pont
- alakzatok csatlakoztatása
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet hozzáadni, csatlakoztatni, újraírni, igazítani és ellenőrizni egyenes, hajlított és ívelt PowerPoint csatlakozókat az Aspose.Slides for Android segítségével Java nyelven."
---
## **Áttekintés**

A csatlakozó egy vonal, amely a két alakzat egyikének mozgatásakor is csatlakoztatva maradhat. Végpontjai csatlakozási helyekhez (connection sites) kapcsolódnak, amelyeket a PowerPoint zöld pontok ábrázolnak. Néhány hajlított és ívelt csatlakozó továbbá orange pontokkal jelölt igazítási pontokat (adjustment points) is tartalmaz, amelyek az egyes csatlakozó szegmensek pozícióját szabályozzák.

Az Aspose.Slides a csatlakozókat az [IConnector](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iconnector/) interfésszel reprezentálja. Létrehozhatja őket, csatlakoztathatja a végpontjaikat alakzatokhoz, kiválaszthatja a csatlakozási helyeket, újrairányíthatja őket, és módosíthatja azok geometriáját, ha igazítási pontokkal rendelkeznek.

## **Csatlakozótípusok**

A [ShapeType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapetype/) osztály tartalmaz egyenes, hajlított és ívelt csatlakozó előbeállításokat. Az alábbi táblázat mutatja a rendelkezésre álló csatlakozó geometriákat és az egyes előbeállítások által definiált igazítási pontok számát.

| Csatlakozó | Kép | Az igazítási pontok száma |
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

Az igazítási pontok száma és jelentése a kiválasztott csatlakozó előbeállítás részét képezi. Ne feltételezze, hogy két különböző csatlakozótípus ugyanazt a gyűjteményelrendezést használja.

## **Két alakzat összekapcsolása**

Használja az [IShapeCollection.addConnector](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) metódust a csatlakozó hozzáadásához, majd a [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) és [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) metódusokat a végpontok csatlakoztatásához. Miután mindkét végpont csatlakoztatva van, az [IConnector.reroute](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iconnector/#reroute--) rövid útvonalat választ a két alakzat között.

Az alábbi példa egy ellipszist és egy téglalapot köt össze egy hajlított csatlakozóval:

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

{{% alert color="warning" title="Figyelmeztetés" %}}
A `reroute` hívás megváltoztathatja a [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) és [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-) értékeket. Az újrairányítás után állítson be konkrét csatlakozási helyeket, ha azoknak rögzítve kell maradniuk.
{{% /alert %}}

## **Csatlakozási hely kiválasztása**

Minden kapcsolódó alakzat a [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--) metódussal adja vissza a helyek számát. Ellenőrizze a kívánt, nullától indexelt helyet, mielőtt a csatlakozó végéhez rendeli; a helyek száma alakzat geometriától függ.

Ez a példa egy adott helyhez csatlakoztatja a csatlakozót az ellipszisön, ha az a hely létezik:

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

## **Csatlakozó pont igazítása**

Az igazítási pontokkal rendelkező csatlakozók ezeket a [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) metóduson keresztül teszik elérhetővé. Minden [IAdjustValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iadjustvalue/) vizsgálata előtt ellenőrizze annak [getType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iadjustvalue/#getType--) értékét, majd módosítsa a [setRawValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) metódussal. Az előre beállított alakzat igazítások azonosításának általános szabályait a [Shape Manipulation](/slides/hu/androidjava/shape-manipulations/) leírása tartalmazza.

Az igazítási pontok száma, sorrendje, jelentése és érvényes értéktartománya a csatlakozó előbeállításától függ. Az igazítás típusa csak olvasható, míg az értéke írásra is alkalmas. A csak olvasható [getName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iadjustvalue/#getName--) metódus további azonosítást nyújt, ha a csatlakozó több azonos szemantikai típusú igazítást tartalmaz.

### **Útvonal akadály körül**

Az alábbi elrendezésben egy `BentConnector5` csatlakozó két alakzat között egy harmadik alakzaton keresztül halad:

![connector-obstruction](connector-obstruction.png)

Ez a kód hozza létre az akadályoztatott csatlakozót:

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

A függőleges hajlítás mozgatása megváltoztatja az útvonalat, így a csatlakozó megkerüli az akadályt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Ahelyett, hogy azt feltételezné, hogy a `1` indexű elem mindig a függőleges hajlítás, ez a példa a `ConnectorBendPositionY` elemet keresi, és csak akkor módosítja, ha a várt szemantikai típus jelen van:

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

Egy `BentConnector5` két `ConnectorBendPositionX` és egy `ConnectorBendPositionY` igazítással rendelkezik. Ha a szükséges típust többször találja, ellenőrizze a `getName` értékét és az adott előbeállítás ismert geometriáját, mielőtt kiválasztaná. Ha egy igazítás `ShapeAdjustmentType.Custom` értéket ad vissza, tekintse jelentését és tartományát az előre beállított specifikusnak, és ne változtassa meg, amíg a szerződés nem ismert.

## **Igazítási értékek kapcsolása a csatlakozó geometriához**

A hajlított csatlakozók esetén az igazítási értékek felhasználhatók az egyes szegmensek pozíciójának becslésére. Ezek a számítások a csatlakozó előbeállításához kötöttek:

- A `BentConnector4` általában egy `ConnectorBendPositionX` és egy `ConnectorBendPositionY` igazítást tesz láthatóvá.
- Ezekhez a hajlítási pozíciókhoz az `getRawValue` által visszaadott értéket `100000f`‑el elosztva kapjuk meg a csatlakozó keret szélességének vagy magasságának tört részét, ahogyan az alábbi példákban látható.
- A csatlakozó kerete elforgatható vagy tükrözhető, ezért a keret koordinátákat át kell alakítani, mielőtt a diakordinátákkal összehasonlítanánk őket.

Az alábbi példák először a `getType` segítségével azonosítják az igazításokat. Nem tekintik a gyűjtemény indexeket hordozható azonosítóknak.

### **Nem forgatott csatlakozó**

A kezdeti elrendezés két szöveges alakzatot kapcsol össze egy `BentConnector4`‑el:

![connector-shape-complex](connector-shape-complex.png)

Ez a példa megvizsgálja a csatlakozót, és lekéri a vízszintes és függőleges hajlítási igazításokat:

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

A két hajlítás módosításához keresse meg a várt típust, majd csak akkor módosítsa az értékeket, ha mindkettőt megtalálta:

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

Az eredmény egy olyan csatlakozó, amelynek vízszintes és függőleges szegmensei elmozdultak:

![connector-adjusted-1](connector-adjusted-1.png)

Miután a szemantikai típusok ismertté váltak, az értékek átalakíthatók csatlakozó‑keret koordinátákká. Ez a példa egy vékony téglalapot rajzol a két hajlítás által vezérelt függőleges szegmens fölé:

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

A segédalakzat az számított szegmenst jelöli:

![connector-adjusted-2](connector-adjusted-2.png)

### **Forgatott vagy tükrözött csatlakozó**

Ha ugyanez a csatlakozó geometriája függőlegesen van orientálva, az [IShape.getFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getFrame--), a [ShapeFrame.getFlipH](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapeframe/#getFlipH--) és a [ShapeFrame.getFlipV](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapeframe/#getFlipV--) értékek befolyásolják a csatlakozó‑keret koordináták diakordinátákká történő átalakítását.

Ez a példa létrehozza és módosítja a függőlegesen orientált csatlakozót:

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

Az igazított csatlakozó függőlegesen jelenik meg az alakzatok között:

![connector-adjusted-3](connector-adjusted-3.png)

Tetszőleges `alpha` fordulatszög esetén egy csatlakozó‑keret pontot `(x, y)` a keret középpontja `(x0, y0)` körül a következőképpen forgatjuk:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Az alábbi kód kezeli a példában használt 90‑fokos orientációt, és egy piros segédvonalat rajzol a megfelelő csatlakozó szegmens fölé:

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

A piros segédvonal a koordináta-átalakítás után számított szegmenst jelöli:

![connector-adjusted-4](connector-adjusted-4.png)

Ezek a képletek a példákban használt előbeállításokat írják le, nem egy általános csatlakozó modellt. Mielőtt ugyanazt a számítást más előbeállításra alkalmazná, ellenőrizze az igazítási típusokat, a keret orientációját és az értéktartományokat.

## **Csatlakozó irányszög meghatározása**

Egy egyenes csatlakozó irányát a szélesség és magasság alapján lehet kiszámítani, figyelembe véve a vízszintes és függőleges tükrözéseket. Az alábbi példa a percenkénti óramutató járásával megegyező szöget adja meg a diakordináták pozitív vízszintes tengelyétől:

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

**Hogyan tudom megállapítani, hogy egy csatlakozó csatlakoztatható-e egy alakzathoz?**

Ellenőrizze az alakzat [getConnectionSiteCount](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--) értékét. A pozitív szám azt jelzi, hogy az alakzat rendelkezik csatlakozási helyekkel. A kiválasztott hely indexét ellenőrizze, mielőtt bármelyik csatlakozó végéhez rendeli.

**Azonosíthatom-e a csatlakozó igazítását a gyűjtemény indexe alapján?**

Az index csak egy ismert csatlakozó előbeállítás és gyűjteményelrendezés esetén értelmezhető. Módosítás előtt ellenőrizze a [IAdjustValue.getType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iadjustvalue/#getType--) értékét, és ha ugyanaz a szemantikai típus többször is előfordul, használja a [IAdjustValue.getName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iadjustvalue/#getName--) információt.

**Mi történik, ha egy csatlakoztatott alakzatot törölnek?**

Az érintett csatlakozó végpontja leválik. A csatlakozó a dián marad, és törölhető, szabad vonalként pozicionálható, illetve másik alakzathoz csatolható.

**Megmaradnak a csatlakozások, ha egy diát másolnak?**

A csatlakozások általában megmaradnak, ha a kapcsolódó alakzatokkal együtt másolják a diát. Ha egy csatlakozót másolnak anélkül, hogy a célalakzat egyike meg lenne, a érintett végpontot újra csatlakoztatni kell.