---
title: PowerPoint tintaobjektumok kezelése JavaScriptben
linktitle: Tinta kezelése
type: docs
weight: 95
url: /hu/nodejs-java/manage-ink/
keywords:
- tinta
- tintaobjektum
- tinta nyomvonal
- tinta kezelése
- tinta rajzolása
- rajzolás
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint tintaobjektumok kezelése — létrehozni, szerkeszteni és formázni a digitális tintát az Aspose.Slides for Node.js segítségével. JavaScript kódmintákat kap a nyomvonalakhoz, az ecset színéhez és méretéhez."
---
## **Bevezetés**

A PowerPoint az ink funkciót biztosítja, amely lehetővé teszi nem szabványos alakzatok rajzolását, ezeket fel lehet használni más objektumok kiemelésére, kapcsolatok és folyamatok megjelenítésére, valamint a dián lévő konkrét elemek figyelemfelkeltésére.

Az Aspose.Slides minden Ink típust biztosít (például az [Ink](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ink/) osztályt), amelyre szüksége van az ink objektumok létrehozásához és kezeléséhez.

## **Különbségek a normál objektumok és az ink objektumok között**

A PowerPoint dia objektumai általában shape objektumokkal vannak reprezentálva. Egy shape objektum legegyszerűbben egy tároló, amely meghatározza magának az objektumnak a területét (a keretét) a tulajdonságai mellett. Az utóbbi tartalmazza a tároló területméretét, a tároló alakját, a tároló háttérszínét stb. További információkért lásd a [Shape Layout Format](https://docs.aspose.com/slides/hu/nodejs-java/shape-manipulations/#access-layout-formats-for-shape) részt.

Azonban amikor a PowerPoint egy ink objektummal dolgozik, figyelmen kívül hagyja az objektum keretének (tárolójának) minden tulajdonságát, kivéve a méretét. A tároló terület mérete a szabványos `width` és `height` értékek alapján kerül meghatározásra:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape nyomvonalak**

A nyomvonal egy alapvető elem vagy szabvány, amely a toll mozgását rögzíti, amikor a felhasználó digitális tintát ír. A nyomvonalak olyan felvételek, amelyek kapcsolt pontok sorozatát írják le.

A legegyszerűbb kódolás minden mintapont X és Y koordinátáját adja meg. Amikor az összes kapcsolt pont megjelenítésre kerül, a következő kép jön létre:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ecset tulajdonságok rajzoláshoz**

Ecsettel vonalakat lehet húzni a nyomvonal elemek pontjai között. Az ecsetnek saját színe és mérete van, ami a `Brush.setColor` és `Brush.setSize` metódusoknak felel meg.

### **Ink ecset színének beállítása**

Ez a JavaScript kód megmutatja, hogyan kell beállítani egy ecset színét:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ink ecset méretének beállítása**

Ez a JavaScript kód megmutatja, hogyan kell beállítani egy ecset méretét:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Általában egy ecset szélessége és magassága nem egyezik, ezért a PowerPoint nem jeleníti meg az ecset méretét (az adat szekció szürkén jelenik meg). Ha azonban az ecset szélessége és magassága megegyezik, a PowerPoint a méretet így jeleníti meg:

![ink_powerpoint3](ink_powerpoint3.png)

A tisztánlátás kedvéért növeljük meg az ink objektum magasságát, és tekintsük át a fontos méreteket:

![ink_powerpoint4](ink_powerpoint4.png)

A tároló (keret) nem veszi figyelembe az ecsetek méretét – mindig úgy gondolja, hogy a vonal vastagsága nulla (lásd az utolsó képet).

Ezért a teljes ink objektum látható területének meghatározásához figyelembe kell venni a nyomvonal objektumok ecsetméretét. Itt a céleszköz (a kézírásos szöveg nyomvonal objektuma) a tároló (keret) méretéhez lett skálázva. Amikor a tároló (keret) mérete változik, az ecset mérete állandó marad, és fordítva.

![ink_powerpoint5](ink_powerpoint5.png)

A PowerPoint ugyanezt a viselkedést mutatja a szövegek esetén:

![ink_powerpoint6](ink_powerpoint6.png)

**További olvasnivaló**

* A formákról általánosságban a [PowerPoint Shapes](https://docs.aspose.com/slides/hu/nodejs-java/powerpoint-shapes/) szakaszban olvashat.
* A hatékony értékekről a [Shape Effective Properties](https://docs.aspose.com/slides/hu/nodejs-java/shape-effective-properties/#getting-effective-font-height-value) részben tájékozódhat.