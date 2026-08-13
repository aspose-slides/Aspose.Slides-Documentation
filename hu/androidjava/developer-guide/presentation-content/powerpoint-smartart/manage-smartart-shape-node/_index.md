---
title: SmartArt alakzat csomópontok kezelése Android prezentációkban
linktitle: SmartArt alakzat csomópont
type: docs
weight: 30
url: /hu/androidjava/manage-smartart-shape-node/
keywords:
- SmartArt csomópont
- gyermekcsomópont
- csomópont hozzáadása
- csomópont pozíció
- csomópont elérése
- csomópont eltávolítása
- egyedi pozíció
- asszisztens csomópont
- kitöltési formátum
- csomópont renderelése
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Kezelje a SmartArt alakzat csomópontokat PPT és PPTX formátumban az Aspose.Slides for Android segítségével. Szerezzen tiszta Java kódmintákat és tippeket a prezentációk egyszerűsítéséhez."
---
## **Áttekintés**

A PowerPoint‑prezentációk SmartArt‑grafikái csomópontokkal vannak szervezve, amelyek szöveget tartalmaznak, és meghatározzák a diagram szerkezetét. Az Aspose.Slides lehetővé teszi, hogy programozottan dolgozzon ezekkel a SmartArt‑csomópontokkal: új csomópontokat és gyermekcsomópontokat adjon hozzá, gyermekcsomópontokat szúrjon be egy adott pozícióban, érjen el meglévő csomópontokat, és olvassa ki a szövegüket, szintjüket és pozíciójukat.

Ez a cikk bemutatja, hogyan kezelje a SmartArt‑alak csomópontjait. Megmutatja, hogyan távolítson el csomópontokat, hogyan dolgozzon gyermekcsomópontokkal index vagy pozíció alapján, hogyan változtasson asszisztens csomópontot normál csomópontra, hogyan állítsa be a SmartArt‑csomópont alakzatok pozícióját, méretét és forgását, hogyan állítson be kitöltési formátumot a csomópontokhoz, és hogyan generáljon egy bélyegképet egy SmartArt‑csomóponthoz.

## **SmartArt‑csomópont hozzáadása**
Az Aspose.Slides for Android via Java a legegyszerűbb API‑t biztosítja a SmartArt‑alakok kezeléséhez a legegyszerűbb módon. Az alábbi példa kód segít csomópont és gyermekcsomópont hozzáadásában egy SmartArt‑alakban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, és töltse be a prezentációt SmartArt‑alakval.
2. Szerezze meg az első dia hivatkozását az Indexe segítségével.
3. Járja be az első dián lévő összes alakzatot.
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusú‑e, és alakítsa át a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusra, ha az SmartArt.
5. [Add a new Node](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) a SmartArt alakzat [**NodeCollection**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt#getAllNodes--)‑be, és állítsa be a szöveget a TextFrame‑ben.
6. Most [Add](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) egy [**Child Node**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) az újonnan hozzáadott [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) csomóponthoz, és állítsa be a szöveget a TextFrame‑ben.
7. Mentse el a prezentációt.

```java
import com.aspose.slides.*;

// Töltsd be a kívánt prezentációt
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Járd be az első dián lévő összes alakzatot
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ellenőrizd, hogy az alakzat SmartArt típusú-e
        if (shape instanceof SmartArt) 
        {
            // Alakítsd át az alakzatot SmartArt típusra
            SmartArt smart = (SmartArt) shape;
    
            // Új SmartArt csomópont hozzáadása
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Szöveg hozzáadása
            TemNode.getTextFrame().setText("Test");
    
            // Új gyermekcsomópont hozzáadása a szülőcsomóponthoz. A gyűjtemény végére kerül hozzáadásra
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Szöveg hozzáadása
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Prezentáció mentése
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt‑csomópont hozzáadása meghatározott pozícióban**
Az alábbi minta kódban bemutatjuk, hogyan adhatunk hozzá gyermekcsomópontokat a SmartArt‑alak megfelelő csomópontjaihoz egy adott pozícióban.

1. Hozzon létre egy Presentation osztálypéldányt.
2. Szerezze meg az első dia hivatkozását az Indexe segítségével.
3. Adjon hozzá egy [**StackedList**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) típusú [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArt) alakzatot a kiválasztott diára.
4. Érje el az első csomópontot a hozzáadott SmartArt alakzatban.
5. Most adja hozzá a [**Child Node**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) a kiválasztott [**Node**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtNode)‑hez a 2. pozíción, és állítsa be a szövegét.
6. Mentse el a prezentációt.

```java
import com.aspose.slides.*;

// Prezentáció példány létrehozása
Presentation pres = new Presentation();
try {
    // Prezentáció dia elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape hozzáadása
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // SmartArt csomópont elérése a 0. indexen
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Új gyermekcsomópont hozzáadása a szülőcsomópontban a 2. pozícióban
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Szöveg hozzáadása
    chNode.getTextFrame().setText("Sample Text Added");

    // Prezentáció mentése
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt‑csomópont elérése**
Az alábbi minta kód segít a SmartArt‑alakban lévő csomópontok elérésében. Vegye figyelembe, hogy a SmartArt LayoutType‑ját a alakzat hozzáadásakor kell kiválasztani; későbbi **setLayout** hívás újraépíti az egész diagramot, így a korábban beállított csomópontpozíciók és méretek újraszámításra kerülnek.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztálypéldányt, és töltse be a prezentációt SmartArt‑alakval.
2. Szerezze meg az első dia hivatkozását az Indexe segítségével.
3. Járja be az első dián lévő összes alakzatot.
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusú‑e, és alakítsa át a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusra, ha az SmartArt.
5. Járja be az összes [**Nodes**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArt#getAllNodes--) elemet a SmartArt alakzatban.
6. Érje el és jelenítse meg a SmartArt csomópont pozícióját, szintjét és szövegét.

```java
import com.aspose.slides.*;

// Prezentáció osztály példányosítása
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Első dia lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Az első dián belüli összes alakzat bejárása
    for (IShape shape : slide.getShapes()) 
    {
        // Ellenőrizd, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Alakítsd át az alakzatot SmartArt típusra
            ISmartArt smart = (ISmartArt) shape;
    
            // Az összes csomópont bejárása a SmartArt-on belül
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // SmartArt csomópont elérése az i indexen
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // A SmartArt csomópont paramétereinek kiírása
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt‑gyermekcsomópont elérése**
Az alábbi minta kód segít a SmartArt‑alak egyes csomópontjainak gyermekcsomópontjaihoz való hozzáférésben.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztálypéldányt, és töltse be a prezentációt SmartArt‑alakval.
2. Szerezze meg az első dia hivatkozását az Indexe segítségével.
3. Járja be az első dián lévő összes alakzatot.
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusú‑e, és alakítsa át a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusra, ha az SmartArt.
5. Járja be az összes [**Nodes**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArt#getAllNodes--) elemet a SmartArt alakzatban.
6. Minden kiválasztott SmartArt alakzat [**Node**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtNode)‑nél járja be az adott csomópont összes [**Child Nodes**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) elemét.
7. Érje el és jelenítse meg a [**Child Node**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) pozícióját, szintjét és szövegét.

```java
import com.aspose.slides.*;

// Prezentáció osztály példányosítása
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Első dia lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Az első dián belüli összes alakzat bejárása
    for (IShape shape : slide.getShapes()) 
    {
        // Ellenőrizd, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Alakítsd át az alakzatot SmartArt típusra
            ISmartArt smart = (ISmartArt) shape;
    
            // Az összes csomópont bejárása a SmartArt-on belül
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // SmartArt csomópont elérése az i indexen
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Gyermekcsomópontok bejárása a SmartArt csomópontban az i indexen
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Gyermekcsomópont elérése a SmartArt csomópontban
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // A SmartArt gyermekcsomópont paramétereinek kiírása
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt‑gyermekcsomópont elérése meghatározott pozícióban**
Ebben a példában megtanuljuk, hogyan érhetjük el a gyermekcsomópontokat egy adott pozícióban, a megfelelő SmartArt‑alak csomópontjaihoz tartozóan.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztálypéldányt.
2. Szerezze meg az első dia hivatkozását az Indexe segítségével.
3. Adjon hozzá egy [**StackedList**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) típusú SmartArt alakzatot.
4. Érje el a hozzáadott SmartArt alakzatot.
5. Érje el a csomópontot a 0. indexen a kiválasztott SmartArt alakzatban.
6. Most lépjen a [**Child Node**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) 1. pozíciójához a kiválasztott SmartArt csomópontra a **get_Item()** metódussal.
7. Érje el és jelenítse meg a [**Child Node**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) pozícióját, szintjét és szövegét.

```java
import com.aspose.slides.*;

// A prezentáció példányosítása
Presentation pres = new Presentation();
try {
    // Az első dia elérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt alakzat hozzáadása az első dián
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // SmartArt csomópont elérése a 0. indexen
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Gyermekcsomópont elérése az 1. pozícióban a szülőcsomópontban
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // A SmartArt gyermekcsomópont paramétereinek kiírása
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt‑csomópont eltávolítása**
Ebben a példában megtanuljuk, hogyan távolítsuk el a csomópontokat a SmartArt‑alakból.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztálypéldányt, és töltse be a prezentációt SmartArt‑alakval.
2. Szerezze meg az első dia hivatkozását az Indexe segítségével.
3. Járja be az első dián lévő összes alakzatot.
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusú‑e, és alakítsa át a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusra, ha az SmartArt.
5. Ellenőrizze, hogy a [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) rendelkezik-e több mint 0 csomóponttal.
6. Válassza ki a törlendő SmartArt csomópontot.
7. Most távolítsa el a kiválasztott csomópontot a [**RemoveNode**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) metódussal.
8. Mentse el a prezentációt.

```java
import com.aspose.slides.*;

// Töltsd be a kívánt prezentációt
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Bejárja az első dián lévő összes alakzatot
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Alakítsa át az alakzatot SmartArt típusra
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // SmartArt csomópont elérése a 0. indexen
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // A kiválasztott csomópont eltávolítása
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Prezentáció mentése
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt‑csomópont eltávolítása meghatározott pozícióból**
Ebben a példában megtanuljuk, hogyan távolítsuk el a csomópontokat a SmartArt‑alakból egy adott pozícióban.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztálypéldányt, és töltse be a prezentációt SmartArt‑alakval.
2. Szerezze meg az első dia hivatkozását az Indexe segítségével.
3. Járja be az első dián lévő összes alakzatot.
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusú‑e, és alakítsa át a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusra, ha az SmartArt.
5. Válassza ki a SmartArt alakzat csomópontját a 0. indexen.
6. Most ellenőrizze, hogy a kiválasztott SmartArt csomópont több mint 2 gyermekcsomóponttal rendelkezik‑e.
7. Most távolítsa el a **Position 1**‑en lévő csomópontot a [**RemoveNode**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) metódussal.
8. Mentse el a prezentációt.

```java
import com.aspose.slides.*;

// Töltsd be a kívánt prezentációt
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Bejárja az első dián lévő összes alakzatot
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape instanceof SmartArt) 
        {
            // Alakítsa át az alakzatot SmartArt típusra
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // SmartArt csomópont elérése a 0. indexen
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // A 1. pozícióban lévő gyermekcsomópont eltávolítása
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Prezentáció mentése
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Egyedi pozíció beállítása gyermekcsomópont számára egy SmartArt objektumban**
Az Aspose.Slides for Android via Java most már támogatja a [SmartArtShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#setX-float-) és [Y](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#setY-float-) tulajdonságok beállítását. Az alábbi kódrészlet megmutatja, hogyan állíthatunk be egyedi SmartArtShape pozíciót, méretet és forgást; vegye figyelembe, hogy új csomópontok hozzáadása újraszámítja az összes csomópont pozícióját és méretét. Az egyedi pozíció beállításával a felhasználó a csomópontokat igényei szerint helyezheti el.

```java
import com.aspose.slides.*;

// Prezentáció osztály példányosítása
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // A SmartArt alakzat mozgatása új pozícióba
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // A SmartArt alakzat szélességének módosítása
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // A SmartArt alakzat magasságának módosítása
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // A SmartArt alakzat forgatásának módosítása
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Asszisztens csomópont ellenőrzése**
{{% alert color="info" %}} 

Ebben a cikkben tovább vizsgáljuk a SmartArt‑alakzatok funkcióit, amelyeket programozottan adunk hozzá a prezentációs diákhoz az Aspose.Slides for Android via Java segítségével.

{{% /alert %}} 

Az alábbi forrás SmartArt alakzatot fogjuk használni a cikk különböző részeiben.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Ábra: Forrás SmartArt alakzat a dián**|

A következő minta kódban azt vizsgáljuk, hogyan azonosíthatók a **Assistant Nodes** a SmartArt‑csomópontgyűjteményben és hogyan változtathatók meg.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztálypéldányt, és töltse be a prezentációt SmartArt‑alakval.
2. Szerezze meg az első dia hivatkozását az Indexe segítségével.
3. Járja be az első dián lévő összes alakzatot.
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusú‑e, és alakítsa át a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusra, ha az SmartArt.
5. Járja be a SmartArt alakzat összes csomópontját, és ellenőrizze, hogy azok [**Assistant Nodes**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtNode#isAssistant--)‑e.
6. Módosítsa az asszisztens csomópont állapotát normál csomópontra.
7. Mentse el a prezentációt.

```java
import com.aspose.slides.*;

// Prezentáció példány létrehozása
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Bejárja az első dián lévő összes alakzatot
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Alakítsa át az alakzatot SmartArt típusra
            ISmartArt smart = (SmartArt) shape;
    
            // Az összes csomópont bejárása a SmartArt alakzatban
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Ellenőrizze, hogy a csomópont asszisztens csomópont-e
                if (node.isAssistant()) 
                {
                    // Az asszisztens csomópont állapotának false-ra állítása, így normál csomópont lesz
                    node.setAssistant(false);
                }
            }
        }
    }
    
    // Prezentáció mentése
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Ábra: Asszisztens csomópontok módosítva a SmartArt alakzatban a dián**|

## **Csomópont kitöltési formátumának beállítása**
Az Aspose.Slides for Android via Java lehetővé teszi egyedi SmartArt alakzatok hozzáadását és a kitöltési formátumuk beállítását. Ez a cikk bemutatja, hogyan hozhatók létre és érhetők el SmartArt alakzatok, valamint hogyan állítható be a csomópontok kitöltési formátuma az Aspose.Slides for Android via Java segítségével.

Kérjük, kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztálypéldányt.
2. Szerezze meg egy dia hivatkozását az indexe alapján.
3. Adj hozzá egy [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) alakzatot a [**LayoutType**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) beállításával.
4. Állítsa be a [**FillFormat**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#getFillFormat--)‑t a SmartArt alakzat csomópontjaihoz.
5. Írja ki a módosított prezentációt PPTX fájlként.

```java
import com.aspose.slides.*;
import java.awt.Color;

// A prezentáció példányosítása
Presentation pres = new Presentation();
try {
    // Dia elérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt alakzat és csomópontok hozzáadása
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Csomópont kitöltőszín beállítása
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Prezentáció mentése
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt‑csomópont bélyegképének generálása**
A fejlesztők az alábbi lépések követésével generálhatnak bélyegképet egy SmartArt‑csomópontról:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztálypéldányt.
2. [Add SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).
3. Szerezze meg egy csomópont hivatkozását az Indexe alapján.
4. Szerezze be a bélyegkép képet.
5. Mentse el a bélyegképet a kívánt képf formátumban.

```java
import com.aspose.slides.*;

// PPTX fájlt képviselő Presentation osztály példányosítása
Presentation pres = new Presentation();
try {
    // SmartArt hozzáadása
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Csomópont hivatkozásának lekérése az Indexe alapján
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Bélyegkép lekérése
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Bélyegkép mentése
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

### Támogatott-e a SmartArt animáció?

Igen. A SmartArt‑ot egy szabályos alakzatként kezelik, így alkalmazhat [szabványos animációkat](/slides/hu/androidjava/shape-animation/) (belépés, kilépés, hangsúly, mozgáspályák) és módosíthatja az időzítést. Szükség esetén animálhatja a SmartArt‑csomópontok belső alakzatait is.

### Hogyan találhatom meg megbízhatóan egy adott SmartArt‑ot a dián, ha a belső ID-ja ismeretlen?

Keressen és használjon [alternatív szöveget](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getAlternativeText--). Egy megkülönböztethető AltText beállítása a SmartArt‑on lehetővé teszi, hogy programozottan megtalálja anélkül, hogy a belső azonosítókra támaszkodna.

### Megmarad-e a SmartArt megjelenése a prezentáció PDF‑re történő konvertálásakor?

Igen. Az Aspose.Slides magas vizuális pontossággal rendereli a SmartArt‑ot a [PDF exportálás](/slides/hu/androidjava/convert-powerpoint-to-pdf/) során, megőrizve a elrendezést, színeket és hatásokat.

### Kinyerhetők-e a teljes SmartArt képei (előnézetekhez vagy jelentésekhez)?

Igen. A SmartArt alakzatot renderelheti [raszter formátumokba](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) vagy [SVG‑be](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) a méretezhető vektoros kimenethez, ami alkalmas bélyegképek, jelentések vagy webes felhasználás esetén.