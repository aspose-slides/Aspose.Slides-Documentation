---
title: Csatlakozók kezelése prezentációkban Androidon
linktitle: Csatlakozó
type: docs
weight: 10
url: /hu/androidjava/connector/
keywords:
- csatlakozó
- csatlakozó típus
- csatlakozó pont
- csatlakozó vonal
- csatlakozó szög
- alakzatok összekapcsolása
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Adjon lehetőséget a Java alkalmazásoknak, hogy vonalakat rajzoljanak, összekapcsoljanak és automatikusan útvonalat számítsanak a PowerPoint diáknál Androidon—teljes irányítást kapjon az egyenes, könyök és ívelt csatlakozók felett."
---
## **Bevezetés**

A PowerPoint csatlakozó egy speciális vonal, amely összekapcsol vagy összeköt két alakzatot, és a alakzatokhoz rögzítve marad még akkor is, ha azok egy adott dián mozognak vagy áthelyeződnek.  

A csatlakozók általában *kapcsolási pontokhoz* (zöld pontok) csatlakoznak, amelyek alapértelmezés szerint minden alakzaton léteznek. A kapcsolási pontok megjelennek, amikor a kurzor közel kerül hozzájuk.  

*Igazítási pontok* (narancssárga pontok), amelyek csak bizonyos csatlakozókon léteznek, a csatlakozók pozíciójának és alakjának módosítására szolgálnak.  

## **Kapcsolók típusai**

PowerPointban használhatunk egyenes, könyök (szögelt) és ívelt csatlakozókat.  

Aspose.Slides ezeket a csatlakozókat kínálja:

| Csatlakozó | Kép | Igazítási pontok száma |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0 |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1 |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2 |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3 |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **Alakzatok összekapcsolása csatlakozókkal**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
1. Szerezze meg egy dia hivatkozását annak indexén keresztül.  
1. Adjon hozzá két [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/AutoShape) alakzatot a diához a `Shapes` objektum által biztosított `addAutoShape` metódus használatával.  
1. Adjon hozzá egy csatlakozót a `addConnector` metódus használatával, amelyet a `Shapes` objektum biztosít, a csatlakozó típusának megadásával.  
1. Csatlakoztassa az alakzatokat a csatlakozóval.  
1. Hívja meg a `reroute` metódust a legrövidebb összekötési útvonal alkalmazásához.  
1. Mentse el a prezentációt.  

Ez a Java kód bemutatja, hogyan adhat hozzá egy csatlakozót (egy hajlított csatlakozót) két alakzat között (egy ellipszist és egy téglalapot):

```Java
// Példányosít egy prezentáció osztályt, amely a PPTX fájlt képviseli
Presentation pres = new Presentation();
try {
    // Eléri egy adott dia alakzatgyűjteményét
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Ellipszis autoalakzatot ad hozzá
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Téglalap autoalakzatot ad hozzá
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Csatlakozó alakzatot ad a dia alakzatgyűjteményéhez
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Az alakzatokat a csatlakozóval összeköti
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Meghívja a reroute metódust, amely beállítja az alakzatok közötti automatikus legrövidebb útvonalat
    connector.reroute();
    
    // Elmenti a prezentációt
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

`Connector.reroute` metódus átirányít egy csatlakozót, és arra kényszeríti, hogy a lehető legrövidebb útvonalat vegye az alakzatok között. A cél elérése érdekében a metódus módosíthatja a `setStartShapeConnectionSiteIndex` és a `setEndShapeConnectionSiteIndex` pontokat. 

{{% /alert %}} 

## **Kapcsolási pont megadása**

Ha azt szeretné, hogy egy csatlakozó a két alakzatot a alakzatokon lévő meghatározott pontok használatával kössön össze, akkor a kívánt kapcsolási pontokat a következő módon kell megadni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
1. Szerezze meg egy dia hivatkozását annak indexén keresztül.  
1. Adjon hozzá két [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/AutoShape) alakzatot a diához a `Shapes` objektum által biztosított `addAutoShape` metódus használatával.  
1. Adjon hozzá egy csatlakozót a `addConnector` metódus használatával, amelyet a `Shapes` objektum biztosít, a csatlakozó típusának megadásával.  
1. Csatlakoztassa az alakzatokat a csatlakozóval.  
1. Állítsa be a kívánt kapcsolási pontokat az alakzatokon.  
1. Mentse el a prezentációt.  

Ez a Java kód bemutat egy olyan műveletet, ahol egy kívánt kapcsolási pont van megadva:

```java
// Példányosít egy prezentáció osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri egy adott dia alakzatgyűjteményét
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Ellipszis autoalakzatot ad hozzá
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Téglalap autoalakzatot ad hozzá
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Csatlakozó alakzatot ad a dia alakzatgyűjteményéhez
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Az alakzatokat a csatlakozóval összeköti
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Beállítja a kívánt kapcsolási pont indexét az Ellipszis alakzaton
    int wantedIndex = 6;

    // Ellenőrzi, hogy a kívánt index kisebb-e a maximális hely index számlálónál
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Beállítja a kívánt kapcsolási pontot az Ellipszis autoalakzaton
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Elmenti a prezentációt
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Csatlakozó pont módosítása**

Egy meglévő csatlakozót az igazítási pontjain keresztül módosíthat. Csak azok a csatlakozók módosíthatók így, amelyek rendelkeznek igazítási pontokkal. Lásd a táblázatot a **[Kapcsolók típusai.](/slides/hu/androidjava/connector/#types-of-connectors)** alatt  

### **Egyszerű eset**

Tekintsünk egy esetet, ahol egy csatlakozó két alakzat (A és B) között áthalad egy harmadik alakzaton (C):

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

A harmadik alakzat elkerüléséhez vagy megkerüléséhez a csatlakozót úgy módosíthatjuk, hogy a függőleges vonalát balra mozgatjuk:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Összetett esetek** 

Összetettebb módosítások végrehajtásához figyelembe kell venni a következőket:

* Egy csatlakozó állítható pontja szorosan egy olyan képlethez kapcsolódik, amely kiszámítja és meghatározza a pozícióját. Így a pont helyzetének módosítása megváltoztathatja a csatlakozó alakját.  
* A csatlakozó igazítási pontjait egy tömbben szigorú sorrendben definiálják. Az igazítási pontok számozása a csatlakozó kezdőpontjától a végpontig terjed.  
* Az igazítási pont értékek a csatlakozó alakzat szélességének/magasságának százalékát tükrözik.  
  * Az alakzat a csatlakozó kezdő- és végpontját 1000‑szörösével határolja.  
  * Az első pont, a második pont és a harmadik pont a szélességből, a magasságból és ismét a szélességből származó százalékot határozza meg.  
* Azoknak a számításoknak, amelyek a csatlakozó igazítási pontjainak koordinátáit határozzák meg, figyelembe kell venni a csatlakozó forgatását és tükröződését. **Megjegyzés**: a **[Kapcsolók típusai](/slides/hu/androidjava/connector/#types-of-connectors)** alatt látható összes csatlakozó forgatási szöge 0.  

#### **1. eset**

Tekintsünk egy esetet, ahol két szövegkeret objektumot egy csatlakozóval kapcsolnak össze:

```java
// Példányosít egy prezentáció osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Lekéri az első diát a prezentációból
    ISlide sld = pres.getSlides().get_Item(0);
    // Hozzáadja az alakzatokat, amelyeket egy csatlakozóval kapcsolunk össze
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
    // Megadja a csatlakozó vonalának vastagságát
    connector.getLineFormat().setWidth(3);
    
    // Összekapcsolja az alakzatokat a csatlakozóval
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Lekéri a csatlakozó igazítási pontjait
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Igazítás**

Módosíthatjuk a csatlakozó igazítási pontjainak értékeit, ha a megfelelő szélesség- és magasság-százalékot rendre 20%-kal és 200%-kal növeljük:

```java
// Módosítja az igazítási pontok értékeit
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Az eredmény:

![connector-adjusted-1](connector-adjusted-1.png)

Egy modell meghatározásához, amely lehetővé teszi a csatlakozó egyes részeinek koordinátáinak és alakjának meghatározását, hozzunk létre egy alakzatot, amely a csatlakozó vízszintes komponensének felel meg a connector.getAdjustments().get_Item(0) pontnál:

```java
// Rajzolja a csatlakozó függőleges komponensét
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Az eredmény:

![connector-adjusted-2](connector-adjusted-2.png)

#### **2. eset**

Az **1. esetben** egyszerű csatlakozó-igazítási műveletet mutattunk be alapelvek használatával. Normál helyzetekben figyelembe kell venni a csatlakozó forgatásait és megjelenítését (amelyeket a connector.getRotation(), a connector.getFrame().getFlipH() és a connector.getFrame().getFlipV() állít be). Most bemutatjuk a folyamatot.

Először adjunk egy új szövegkeret objektumot (**To 1**) a diához (kapcsolási célból), és hozzunk létre egy új (zöld) csatlakozót, amely összeköti a már létrehozott objektumokkal.

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
// Lekéri a csatlakozó igazítási pontjait
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Módosítja az igazítási pontok értékeit
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Az eredmény:

![connector-adjusted-3](connector-adjusted-3.png)

Másodszor hozzunk létre egy alakzatot, amely a csatlakozó vízszintes komponensének felel meg, amely áthalad az új csatlakozó igazítási pontján, a connector.getAdjustments().get_Item(0)-n. A connector.getRotation(), a connector.getFrame().getFlipH() és a connector.getFrame().getFlipV() értékeit fogjuk felhasználni, és alkalmazzuk a gyakori koordináta-transzformációs képletet egy adott x0 pont körüli forgatáshoz:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Mi esetünkben az objektum forgatási szöge 90 fok, és a csatlakozó függőlegesen jelenik meg, ezért ez a megfelelő kód:

```java
// Elmenti a csatlakozó koordinátákat
x = connector.getX();
y = connector.getY();
// Korrigálja a csatlakozó koordinátákat, ha szükséges
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Az igazítási pont értékét koordinátaként használja
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Átalakítja a koordinátákat, mivel Sin(90) = 1 és Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Meghatározza a vízszintes komponens szélességét a második igazítási pont értékével
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Az eredmény:

![connector-adjusted-4](connector-adjusted-4.png)

Bemutattuk az egyszerű igazításokat és a bonyolultabb, forgatási szögekkel rendelkező igazítási pontokat érintő számításokat. A megszerzett tudással saját modellt fejleszthet (vagy kódot írhat), amely segítségével `GraphicsPath` objektumot kap, vagy akár a csatlakozó igazítási pontjainak értékeit meghatározott dia-koordináták alapján is beállíthatja.

## **A csatlakozó vonalak szögének meghatározása**

1. Hozzon létre egy példányt az osztályból.  
1. Szerezze meg egy dia hivatkozását annak indexén keresztül.  
1. Hozzáférés a csatlakozó vonal alakzathoz.  
1. A vonal szélességének, magasságának, az alakzat keretmagasságának és keretszélességének felhasználásával számítsa ki a szöget.  

Ez a Java kód egy olyan műveletet mutat be, amelyben egy csatlakozó vonal alakzat szögét számoltuk ki:

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

**Hogyan tudom megállapítani, hogy egy csatlakozó „ragasztható”-e egy adott alakzatra?**

Ellenőrizze, hogy az alakzat rendelkezik-e [kapcsolási pontokkal](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getConnectionSiteCount--). Ha nincs, vagy a számláló nulla, a ragasztás nem lehetséges; ebben az esetben használjon szabad végeket és helyezze el őket manuálisan. Érdemes a csatlakozási pontok számát ellenőrizni a csatolás előtt.

**Mi történik a csatlakozóval, ha törlök egy csatlakoztatott alakzatot?**

A végei leválnak; a csatlakozó a dián egy szokásos vonalként marad, szabad kezdő/feje véggel. Törölheti, vagy újra hozzárendelheti a kapcsolódásokat, és szükség esetén [reroute](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/connector/#reroute--).

**Megmaradnak a csatlakozók kötései, ha egy diát egy másik prezentációba másolunk?**

Általában igen, amennyiben a célalakzatok is másolásra kerülnek. Ha a dia egy másik fájlba kerül a kapcsolódó alakzatok nélkül, a végek szabadon maradnak, és újra kell csatolni őket.