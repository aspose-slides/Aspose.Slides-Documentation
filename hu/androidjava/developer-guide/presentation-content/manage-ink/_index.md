---
title: PowerPoint tintobjektumok kezelése Androidon
linktitle: Tint kezelése
type: docs
weight: 95
url: /hu/androidjava/manage-ink/
keywords:
- tinta
- tintaobjektum
- tinta nyoma
- tinta kezelése
- tinta rajzolása
- rajzolás
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "PowerPoint tintobjektumok kezelése - létrehozás, szerkesztés és digitális tinta stílusának beállítása az Aspose.Slides for Android segítségével. Java kódrészletek tintanyomokhoz, ecsetszínhez és mérethez."
---
## **Bevezetés**

A PowerPoint biztosítja a tinta funkciót, amely lehetővé teszi nem szabványos alakzatok rajzolását, amelyeket felhasználhatunk más objektumok kiemelésére, kapcsolatok és folyamatok megjelenítésére, valamint egyes dián lévő elemek figyelemfelkeltésére. 

Az Aspose.Slides minden szükséges Ink típust biztosít (például az [Ink](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ink/) osztályt), amelyekkel tintaobjektumokat hozhat létre és kezelhet.

## **A hagyományos objektumok és a tintaobjektumok közötti különbségek**

A PowerPoint dián található objektumok általában alakzatobjektumokkal vannak ábrázolva. Egy alakzatobjektum legegyszerűbben egy tároló, amely meghatározza az objektum saját területét (a keretét) és a hozzá tartozó tulajdonságokat. Ezek közé tartozik a konténer területmérete, a konténer alakja, a konténer háttérszíne stb. További információért lásd a [Shape Layout Format](https://docs.aspose.com/slides/hu/androidjava/shape-manipulations/#access-layout-formats-for-shape) oldalt. 

Azonban amikor a PowerPoint egy tintaobjektummal dolgozik, a konténer (objektumkeret) minden tulajdonságát figyelmen kívül hagyja, kivéve a méretét. A konténer terület méretét a szabványos `width` és `height` értékek határozzák meg:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tintaformák nyomai**

A nyom (trace) egy alapvető elem vagy szabvány, amely a toll mozgását rögzíti, amikor a felhasználó digitális tintát ír. A nyomok olyan felvételek, amelyek összekapcsolt pontok sorozatát írják le. 

A kódolás legegyszerűbb formája minden mintapont X és Y koordinátáit adja meg. Amikor az összes összekapcsolt pont megjelenik, egy ilyen képet eredményez:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ecset tulajdonságok rajzoláshoz**

Használhat ecsetet a nyom elemek pontjait összekötő vonalak rajzolásához. Az ecsetnek saját színe és mérete van, amelyek a `Brush.Color` és `Brush.Size` tulajdonságoknak felelnek meg. 

### **Tinta ecset szín beállítása**

Ez a Java kód bemutatja, hogyan állíthatja be az ecset színét:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tinta ecset méret beállítása** 

Ez a Java kód bemutatja, hogyan állíthatja be az ecset méretét:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```

Általában egy ecset szélessége és magassága nem egyezik, így a PowerPoint nem jeleníti meg az ecset méretét (az adatszakasz szürkén jelenik meg). Ha azonban az ecset szélessége és magassága megegyezik, a PowerPoint a méretet így jeleníti meg:

![ink_powerpoint3](ink_powerpoint3.png)

Az átláthatóság kedvéért növeljük meg a tintaobjektum magasságát, és tekintsük át a fontos méreteket: 

![ink_powerpoint4](ink_powerpoint4.png)

A konténer (keret) nem veszi figyelembe az ecsetek méretét – mindig úgy feltételezi, hogy a vonal vastagsága nulla (lásd az utolsó képet). 

Ezért az egész tintaobjektum látható területének meghatározásához figyelembe kell venni a nyom objektumok ecsetméretét. Itt a célobjektum (a kézírásos szöveg nyom objektuma) a konténer (keret) méretéhez lett skálázva. Ha a konténer (keret) mérete változik, az ecset mérete állandó marad, és fordítva. 

![ink_powerpoint5](ink_powerpoint5.png)

A PowerPoint hasonló viselkedést mutat szövegek esetén:

![ink_powerpoint6](ink_powerpoint6.png)

**További olvasnivaló**

* Az alakzatokról általánosságban a [PowerPoint Shapes](https://docs.aspose.com/slides/hu/androidjava/powerpoint-shapes/) szakaszban olvashat. 
* A hatékony értékekkel kapcsolatos további információkért lásd a [Shape Effective Properties](https://docs.aspose.com/slides/hu/androidjava/shape-effective-properties/#getting-effective-font-height-value) oldalt.