---
title: Csatlakozók kezelése prezentációkban Java használatával
linktitle: Csatlakozó
type: docs
weight: 10
url: /hu/java/connector/
keywords:
- csatlakozó
- csatlakozó típus
- csatlakozó pont
- csatlakozó vonal
- csatlakozó szög
- alakzatok összekapcsolása
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Lehetővé teszi a Java alkalmazások számára, hogy vonalakat rajzoljanak, összekapcsoljanak és automatikusan útvonalat állítsanak a PowerPoint diákon - teljes irányítást biztosít az egyenes, könyök és ívelt csatlakozók felett."
---
## **Bevezetés**

A PowerPoint csatlakozó egy speciális vonal, amely két alakzatot köt össze, és a alakzatokhoz rögzítve marad, még akkor is, ha azok mozognak vagy áthelyeződnek egy adott dián.  

A csatlakozók általában *kapcsolódási pontokkal* (zöld pontok) vannak összekötve, amelyek alapértelmezés szerint minden alakzaton léteznek. A kapcsolódási pontok akkor jelennek meg, amikor a kurzor közel kerül hozzájuk.  

*Állítási pontok* (narancssárga pontok), amelyek csak bizonyos csatlakozókon léteznek, a csatlakozók helyzetének és alakjának módosítására szolgálnak.  

## **A csatlakozók típusai**

A PowerPointban használhat egyenes, könyök (szögelt) és ívelt csatlakozókat.  

Az Aspose.Slides ezeket a csatlakozókat biztosítja:

| Csatlakozó                     | Kép                                                          | Állítási pontok száma |
| ------------------------------ | ------------------------------------------------------------ | --------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                     |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                     |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                     |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                     |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                     |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                     |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                     |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                     |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                     |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                     |

## **Alakzatok összekapcsolása csatlakozókkal**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
1. Szerezze meg egy dia hivatkozását az indexe alapján.  
1. Adjon hozzá két [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/AutoShape) elemet a diához a `Shapes` objektum által nyújtott `addAutoShape` metódus használatával.  
1. Adjon hozzá egy csatlakozót a `Shapes` objektum által nyújtott `addConnector` metódus segítségével a csatlakozó típusának meghatározásával.  
1. Kapcsolja össze az alakzatokat a csatlakozóval.  
1. Hívja meg a `reroute` metódust a legrövidebb kapcsolati út alkalmazásához.  
1. Mentse el a prezentációt.  

Ez a Java kód megmutatja, hogyan adjon hozzá egy csatlakozót (egy megtört csatlakozót) két alakzat (ellipszis és téglalap) között:

```Java
// Példányosít egy prezentáció osztályt, amely a PPTX fájlt képviseli
Presentation pres = new Presentation();
try {
    // Eléri egy adott dia alakzatgyűjteményét
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Hozzáad egy ellipszis autóalakzatot
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Hozzáad egy téglalap autóalakzatot
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Hozzáad egy csatlakozó alakzatot a dia alakzatgyűjteményéhez
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Összekapcsolja az alakzatokat a csatlakozóval
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Meghívja a reroute metódust, amely beállítja az automatikus legrövidebb útvonalat az alakzatok között
    connector.reroute();
    
    // Mentse a prezentációt
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.reroute` metódus átirányít egy csatlakozót, és arra kényszeríti, hogy a legrövidebb lehetséges útvonalat vegye a alakzatok között. Ennek érdekében a metódus megváltoztathatja a `setStartShapeConnectionSiteIndex` és a `setEndShapeConnectionSiteIndex` pontokat. 
{{% /alert %}} 

## **Kapcsolódási pont megadása**

Ha azt szeretné, hogy egy csatlakozó két alakzatot a alakzatokon lévő meghatározott pontokkal kössön, az alábbi módon kell megadnia a kívánt kapcsolódási pontokat:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
1. Szerezze meg egy dia hivatkozását az indexe alapján.  
1. Adjon hozzá két [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/AutoShape) elemet a diához a `Shapes` objektum által nyújtott `addAutoShape` metódus használatával.  
1. Adjon hozzá egy csatlakozót a `Shapes` objektum által nyújtott `addConnector` metódus segítségével a csatlakozó típusának meghatározásával.  
1. Kapcsolja össze az alakzatokat a csatlakozóval.  
1. Állítsa be a kívánt kapcsolódási pontokat az alakzatokon.  
1. Mentse el a prezentációt.  

Ez a Java kód egy olyan műveletet mutat be, amelyben egy kívánt kapcsolódási pontot adunk meg:

```java
// Példányosít egy prezentáció osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri egy adott dia alakzatgyűjteményét
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Hozzáad egy ellipszis autóalakzatot
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Hozzáad egy téglalap autóalakzatot
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Hozzáad egy csatlakozó alakzatot a dia alakzatgyűjteményéhez
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Összekapcsolja az alakzatokat a csatlakozóval
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Beállítja a kívánt kapcsolódási pont indexet az ellipszis alakzaton
    int wantedIndex = 6;

    // Ellenőrzi, hogy a kívánt index kisebb-e a maximális kapcsolódási pont számnál
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Beállítja a kívánt kapcsolódási pontot az ellipszis autóalakzaton
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Mentse a prezentációt
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Csalakozó pont beállítása**

Egy meglévő csatlakozót a beállítási pontjain keresztül állíthatja. Csak azok a csatlakozók, amelyek rendelkeznek beállítási pontokkal, módosíthatók ilyen módon. Lásd a táblázatot a **[Csatlakozók típusai](/slides/hu/java/connector/#types-of-connectors)** alatt.  

### **Egyszerű eset**

Tekintsünk egy olyan esetet, ahol egy csatlakozó két alakzat (A és B) között áthalad egy harmadik alakzaton (C):

![connector-obstruction](connector-obstruction.png)

```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

Az harmadik alakzat elkerülése vagy megkerülése érdekében a csatlakozót úgy állíthatjuk be, hogy a függőleges vonalát balra mozdítjuk:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Összetett esetek** 

Összetettebb beállítások végrehajtásához figyelembe kell venni a következőket:

* Egy csatlakozó állítható pontja szorosan kapcsolódik egy olyan képlethez, amely kiszámítja és meghatározza a pozícióját. Így a pont helyzetének módosítása megváltoztathatja a csatlakozó alakját.  
* A csatlakozó beállítási pontjai egy tömbben szigorú sorrendben vannak definiálva. A beállítási pontok számozása a csatlakozó kezdőpontjától a végéig történik.  
* A beállítási pontok értékei a csatlakozó alakjának szélességének/magasságának százalékát tükrözik.  
  * Az alakzatot a csatlakozó kezdő- és végpontjainak 1000-szeresével határolja.  
  * Az első pont, a második pont és a harmadik pont rendre a szélesség, a magasság és ismét a szélesség százalékát határozza meg.  
* A csatlakozó beállítási pontjainak koordinátáit meghatározó számításoknál figyelembe kell venni a csatlakozó forgását és tükröződését. **Megjegyzés**, hogy az összes, a **[Csatlakozók típusai](/slides/hu/java/connector/#types-of-connectors)** alatt látható csatlakozó forgatási szöge 0.  

#### **Eset 1**

Tekintsünk egy olyan esetet, ahol két szövegkeret objektumot egy csatlakozó köt össze:

![connector-shape-complex](connector-shape-complex.png)

```java
// Példányosít egy prezentáció osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Lekéri a prezentáció első diáját
    ISlide sld = pres.getSlides().get_Item(0);
    // Hozzáadja az alakzatokat, amelyek egy csatlakozóval lesznek összekapcsolva
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Hozzáad egy csatlakozót
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Megadja a csatlakozó irányát
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Megadja a csatlakozó színét
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Megadja a csatlakozó vonal vastagságát
    connector.getLineFormat().setWidth(3);
    
    // Összekapcsolja az alakzatokat a csatlakozóval
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Lekéri a csatlakozó állítási pontjait
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Állítás**

Megváltoztathatjuk a csatlakozó beállítási pontjainak értékeit úgy, hogy a megfelelő szélesség- és magasság-százalékot rendre 20%-kal és 200%-kal növeljük:

```java
// Megváltoztatja az állítási pontok értékeit
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Az eredmény:

![connector-adjusted-1](connector-adjusted-1.png)

Egy olyan modell definiálásához, amely lehetővé teszi, hogy meghatározzuk a csatlakozó egyes részeinek koordinátáit és alakját, hozzunk létre egy alakzatot, amely a csatlakozó vízszintes komponensének felel meg a connector.getAdjustments().get_Item(0) pontnál:

```java
// Rajzolja a csatlakozó függőleges komponensét
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Az eredmény:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Eset 2**

Az **Eset 1**‑ben bemutattuk egy egyszerű csatlakozó beállítási műveletet alapelvek segítségével. Normál helyzetekben figyelembe kell venni a csatlakozó forgását és megjelenítését (amelyet a connector.getRotation(), a connector.getFrame().getFlipH() és a connector.getFrame().getFlipV() állít be). Most bemutatjuk a folyamatot.

Először adjunk hozzá egy új szövegkeret objektumot (**To 1**) a diához (kapcsolódási célból), és hozzunk létre egy új (zöld) csatlakozót, amely összeköti azt a már létrehozott objektumokkal.

```java
// Létrehoz egy új kötési objektumot
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Létrehoz egy új csatlakozót
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Összekapcsolja az objektumokat az újonnan létrehozott csatlakozóval
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Lekéri a csatlakozó állítási pontjait
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Megváltoztatja az állítási pontok értékeit
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Az eredmény:

![connector-adjusted-3](connector-adjusted-3.png)

Másodszor hozzunk létre egy alakzatot, amely a csatlakozó vízszintes komponensének felel meg, és áthalad az új csatlakozó beállítási pontján (connector.getAdjustments().get_Item(0)). A connector.getRotation(), a connector.getFrame().getFlipH() és a connector.getFrame().getFlipV() értékeit fogjuk felhasználni, és alkalmazzuk a népszerű koordináta-átalakító képletet a forgatáshoz egy adott x0 pont körül:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Esetünkben az objektum forgásszöge 90 fok, és a csatlakozó függőlegesen jelenik meg, ezért a megfelelő kód a következő:

```java
// Elmenti a csatlakozó koordinátáit
x = connector.getX();
y = connector.getY();
// Korrigálja a csatlakozó koordinátáit, ha megjelenik
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Az állítási pont értékét veszi koordinátaként
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Átalakítja a koordinátákat, mivel Sin(90) = 1 és Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Meghatározza a vízszintes komponens szélességét a második állítási pont értékével
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Az eredmény:

![connector-adjusted-4](connector-adjusted-4.png)

Bemutattuk a egyszerű beállításokkal és összetett beállítási pontokkal (forgásszögekkel rendelkező beállítási pontok) kapcsolatos számításokat. A megszerzett tudással saját modellt fejleszthet (vagy kódot írhat), amely segítségével `GraphicsPath` objektumot kaphat, vagy akár a csatlakozó beállítási pontjainak értékeit meghatározott dia koordináták alapján állíthatja be.

## **A csatlakozó vonalak szögének meghatározása**

1. Hozzon létre egy példányt az osztályból.  
1. Szerezze meg egy dia hivatkozását az indexe alapján.  
1. Hozzáférés a csatlakozó vonal alakzathoz.  
1. Használja a vonal szélességét, magasságát, az alakzat keret magasságát és szélességét a szög kiszámításához.  

Ez a Java kód egy olyan műveletet mutat be, amelyben a csatlakozó vonal alakzat szögét számoltuk ki:

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **GYIK**

**Hogyan deríthetem ki, hogy egy csatlakozó "ragasztható"-e egy adott alakzatra?**

Ellenőrizze, hogy az alakzat rendelkezik-e [kapcsolódási pontokkal](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getConnectionSiteCount--). Ha nincs, vagy a számláló nulla, a ragasztás nem lehetséges; ebben az esetben használjon szabad végpontokat, és helyezze őket manuálisan. Érdemes a csatlakozó pontok számát ellenőrizni a csatolás előtt.

**Mi történik egy csatlakozóval, ha törlöm a csatlakoztatott alakzatok egyikét?**

A végei leválnak; a csatlakozó a dián egy szabad kezdő/végpontú egyszerű vonalként marad. Törölheti, vagy újra hozzárendelheti a kapcsolódásokat, és szükség esetén [újra irányíthatja](https://reference.aspose.com/slides/hu/java/com.aspose.slides/connector/#reroute--) a csatlakozót.

**Megmaradnak a csatlakozók összekapcsolásai, amikor egy diát egy másik prezentációba másolunk?**

Általában igen, amennyiben a cél alakzatok is másolva vannak. Ha a diát egy másik fájlba illesztik be anélkül, hogy a csatlakoztatott alakzatok is jelen lennének, a végek szabadok lesznek, és újra kell csatlakoztatni őket.