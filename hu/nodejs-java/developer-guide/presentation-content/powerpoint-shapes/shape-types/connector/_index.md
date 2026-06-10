---
title: Csatlakozók kezelése prezentációkban JavaScript használatával
linktitle: Csatlakozó
type: docs
weight: 10
url: /hu/nodejs-java/connector/
keywords:
- csatlakozó
- csatlakozó típus
- csatlakozó pont
- csatlakozó vonal
- csatlakozó szög
- alakzatok összekapcsolása
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Engedélyezze a JavaScript alkalmazásoknak, hogy vonalakat rajzoljanak, összekapcsoljanak és automatikusan útvonalat állítsanak be a PowerPoint diákon—teljes irányítást kapjon az egyenes, könyök és íves csatlakozók felett."
---
## **Bevezetés**

A PowerPoint csatlakozó egy speciális vonal, amely összekapcsol vagy összeköt két alakzatot, és a alakzatokhoz rögzítve marad akkor is, amikor azok elmozdulnak vagy áthelyeződnek egy adott dián.  

A csatlakozók általában *kapcsolódási pontokhoz* (zöld pontok) kapcsolódnak, amelyek alapértelmezés szerint minden alakzaton megtalálhatók. A kapcsolódási pontok akkor jelennek meg, amikor a kurzor közel kerül hozzájuk.  

*Igazítási pontok* (narancssárga pontok), amelyek csak bizonyos csatlakozókon léteznek, a csatlakozók helyzetének és alakjának módosítására szolgálnak.  

## **Csatlakozók típusai**

A PowerPointban használhat egyenes, könyök (szögelt) és íves csatlakozókat.  

Az Aspose.Slides ezeket a csatlakozókat biztosítja:

| Csatlakozó                      | Image                                                        | Igazítási pontok száma |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Alakzatok összekapcsolása csatlakozókkal**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
1. Szerezze meg egy dia referenciaját az indexén keresztül.  
1. Adjon hozzá két [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape) elemet a diára a `Shapes` objektum által biztosított `addAutoShape` metódus használatával.  
1. Adjon hozzá egy csatlakozót a `Shapes` objektum által biztosított `addConnector` metódus segítségével, megadva a csatlakozó típusát.  
1. Kapcsolja össze az alakzatokat a csatlakozóval.  
1. Hívja meg a `reroute` metódust, hogy alkalmazza a legrövidebb kapcsolat útvonalát.  
1. Mentse a prezentációt.  

Ez a JavaScript kód megmutatja, hogyan adjon hozzá egy csatlakozót (egy ferdén ívelt csatlakozót) két alakzat (egy ellipszis és egy téglalap) között:

```javascript
// Példányosít egy prezentáció osztályt, amely a PPTX fájlt képviseli
var pres = new aspose.slides.Presentation();
try {
    // Eléri egy adott dia alakzatgyűjteményét
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Hozzáad egy ellipszis autoalakzatot
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Hozzáad egy téglalap autoalakzatot
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Hozzáad egy csatlakozó alakzatot a dia alakzatgyűjteményéhez
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Összekapcsolja az alakzatokat a csatlakozóval
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Meghívja a reroute metódust, amely az alakzatok közötti automatikus legrövidebb útvonalat állítja be
    connector.reroute();
    // Elmenti a prezentációt
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
A `Connector.reroute` metódus átirányít egy csatlakozót, és arra kényszeríti, hogy a legrövidebb lehetséges útvonalat kövesse az alakzatok között. Ennek eléréséhez a metódus módosíthatja a `setStartShapeConnectionSiteIndex` és a `setEndShapeConnectionSiteIndex` pontokat. 
{{% /alert %}} 

## **Kapcsolódási pont megadása**

Ha azt szeretné, hogy egy csatlakozó két alakzatot összekapcsoljon a alakzatokon lévő konkrét pontok használatával, akkor a következő módon kell megadnia a kívánt kapcsolódási pontokat:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
1. Szerezze meg egy dia referenciaját az indexén keresztül.  
1. Adjon hozzá két [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape) elemet a diára a `Shapes` objektum által biztosított `addAutoShape` metódus használatával.  
1. Adjon hozzá egy csatlakozót a `Shapes` objektum által biztosított `addConnector` metódus segítségével, megadva a csatlakozó típusát.  
1. Kapcsolja össze az alakzatokat a csatlakozóval.  
1. Állítsa be a kívánt kapcsolódási pontokat az alakzatokon.  
1. Mentse a prezentációt.  

Ez a JavaScript kód bemutat egy műveletet, ahol egy preferált kapcsolódási pont van megadva:

```javascript
// Példányosít egy prezentáció osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Eléri egy adott dia alakzatgyűjteményét
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Hozzáad egy ellipszis autoalakzatot
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Hozzáad egy téglalap autoalakzatot
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Hozzáad egy csatlakozó alakzatot a dia alakzatgyűjteményéhez
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Összekapcsolja az alakzatokat a csatlakozóval
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Beállítja a kívánt kapcsolódási pont indexet az ellipszis alakzaton
    var wantedIndex = 6;
    // Ellenőrzi, hogy a kívánt index kisebb-e a maximális hely index számnál
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // Beállítja a kívánt kapcsolódási pontot az ellipszis autoalakzaton
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // Elmenti a prezentációt
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Csatlakozó pontjának beállítása**

A meglévő csatlakozót a hozzá tartozó igazítási pontok segítségével módosíthatja. Csak azok a csatlakozók, amelyek rendelkeznek igazítási pontokkal, módosíthatók ilyen módon. Lásd a táblázatot a **[Csatlakozók típusai](/slides/hu/nodejs-java/connector/#types-of-connectors)** alatt.

### **Egyszerű eset**

Tekintsen egy olyan esetet, ahol egy csatlakozó két alakzat (A és B) között egy harmadik alakzaton (C) halad át:

![connector-obstruction](connector-obstruction.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

A harmadik alakzat elkerülése vagy megkerülése érdekében a csatlakozót úgy állíthatjuk be, hogy a függőleges vonalát balra mozgatjuk:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Összetett esetek** 

Összetettebb beállítások elvégzéséhez figyelembe kell venni a következőket:

* Egy csatlakozó állítható pontja szorosan kapcsolódik egy olyan képlethez, amely kiszámítja és meghatározza a pozícióját. Így a pont helyzetének változtatása megváltoztathatja a csatlakozó alakját.  
* A csatlakozó igazítási pontjai egy tömbben szigorú sorrendben vannak definiálva. Az igazítási pontok számozása a csatlakozó kezdőpontjától a végpontig történik.  
* Az igazítási pontértékek a csatlakozó alakzat szélességének/magasságának százalékát tükrözik.  
  * Az alakzat a csatlakozó kezdő és végpontja 1000‑szeres szorzatával határolt.  
  * Az első pont a szélesség százalékát, a második pont a magasság százalékát, a harmadik pont pedig ismét a szélesség százalékát határozza meg.  
* Azokhoz a számításokhoz, amelyek meghatározzák egy csatlakozó igazítási pontjainak koordinátáit, figyelembe kell venni a csatlakozó forgását és tükröződését. **Megjegyzés**: az összes, a **[Csatlakozók típusai](/slides/hu/nodejs-java/connector/#types-of-connectors)** alatt látható csatlakozó forgásszöge 0.

#### **Eset 1**

Tekintsen egy olyan esetre, ahol két szövegkeret objektum egy csatlakozóval van összekapcsolva:

![connector-shape-complex](connector-shape-complex.png)

```javascript
// Példányosít egy prezentáció osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Lekéri a prezentáció első diáját
    var sld = pres.getSlides().get_Item(0);
    // Hozzáadja az alakzatokat, amelyeket egy csatlakozóval összekapcsolunk
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Hozzáad egy csatlakozót
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // Megadja a csatlakozó irányát
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // Megadja a csatlakozó színét
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Megadja a csatlakozó vonal vastagságát
    connector.getLineFormat().setWidth(3);
    // Összekapcsolja az alakzatokat a csatlakozóval
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // Lekéri a csatlakozó igazítási pontjait
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Igazítás**

Megváltoztathatjuk a csatlakozó igazítási pontértékeit, ha a megfelelő szélesség- és magasság-százalékot rendre 20%-kal és 200%-kal növeljük:

```javascript
// Módosítja az igazítási pontok értékeit
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Az eredmény:

![connector-adjusted-1](connector-adjusted-1.png)

Az egyes csatlakozó részek koordinátáit és alakját meghatározó modell létrehozásához hozzunk létre egy alakzatot, amely a connector.getAdjustments().get_Item(0) pontnál a csatlakozó vízszintes komponensének felel meg:

```javascript
// Rajzolja a csatlakozó függőleges komponensét
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```

Az eredmény:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Eset 2**

Az **Eset 1**-ben bemutattunk egy egyszerű csatlakozó igazítási műveletet alapelvek felhasználásával. Normál helyzetekben figyelembe kell venni a csatlakozó forgását és megjelenését (amelyeket a connector.getRotation(), connector.getFrame().getFlipH() és a connector.getFrame().getFlipV() állít be). Most bemutatjuk a folyamatot.

Először adjunk hozzá egy új szövegkeret objektumot (**To 1**) a diához (kapcsolódási célból), és hozzunk létre egy új (zöld) csatlakozót, amely összeköti a már létrehozott objektumokkal.

```javascript
// Létrehoz egy új kötő objektumot
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Létrehoz egy új csatlakozót
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
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

Másodszor hozzunk létre egy alakzatot, amely a csatlakozó vízszintes komponensének felel meg, ami a új csatlakozó igazítási pontján, a connector.getAdjustments().get_Item(0)-n keresztül halad. A connector.getRotation(), connector.getFrame().getFlipH() és connector.getFrame().getFlipV() adataiból származó értékeket fogjuk használni, és alkalmazzuk a gyakori koordináta-átalakító képletet a forgatáshoz egy adott x0 pont körül:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Mi esetünkben az objektum forgásszöge 90 fok, és a csatlakozó függőlegesen jelenik meg, ezért ez a megfelelő kód:

```javascript
// Elmenti a csatlakozó koordinátáit
x = connector.getX();
y = connector.getY();
// Javítja a csatlakozó koordinátáit, ha megjelenik
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// Az igazítási pont értékét koordinátaként veszi
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// Átalakítja a koordinátákat, mivel Sin(90) = 1 és Cos(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// Meghatározza a vízszintes komponens szélességét a második igazítási pont értékével
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Az eredmény:

![connector-adjusted-4](connector-adjusted-4.png)

Bemutattuk az egyszerű igazítások és a bonyolultabb, forgásszögekkel rendelkező igazítási pontok számításait. A megszerzett tudással saját modellt fejleszthet (vagy kódot írhat), amellyel `GraphicsPath` objektumot kaphat, vagy akár a csatlakozó igazítási pontértékeit konkrét dias koordináták alapján beállíthatja.

## **A csatlakozó vonalak szögének meghatározása**

1. Hozzon létre egy példányt az osztályból.  
1. Szerezze meg egy dia referenciaját az indexén keresztül.  
1. Érje el a csatlakozó vonal alakzatot.  
1. Használja a vonal szélességét, magasságát, az alakzat keretmagasságát és keretszélességét a szög kiszámításához.  

Ez a JavaScript kód bemutat egy olyan műveletet, ahol egy csatlakozó vonal alakzat szögét számoltuk ki:

```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```

## **GYIK**

**Hogyan tudhatom, hogy egy csatlakozó "ragasztható"-e egy adott alakzathoz?**

Ellenőrizze, hogy az alakzat [kapcsolódási pontokat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getconnectionsitecount/) biztosít-e. Ha nincsenek, vagy a számláló nulla, akkor a ragasztás nem lehetséges; ebben az esetben használjon szabad végpontokat, és helyezze el őket manuálisan. Célszerű a pontok számát ellenőrizni a csatlakoztatás előtt.

**Mi történik egy csatlakozóval, ha törlök egy a kapcsolt alakzatot?**

A végei leválasztódnak; a csatlakozó a dián egy szabad véggel rendelkező egyszerű vonalként marad. Törölheti, vagy újra hozzárendelheti a kapcsolatokat, és szükség esetén [újra irányíthatja](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/connector/reroute/).

**Megmaradnak-e a csatlakozó kötések, ha egy diát egy másik prezentációba másolunk?**

Általában igen, ha a célnak megfelelő alakzatok is másolásra kerülnek. Ha a diát egy másik fájlba illeszti be a kapcsolt alakzatok nélkül, a végek szabadokká válnak, és újra kell csatolni őket.