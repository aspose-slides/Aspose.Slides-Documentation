---
title: SmartArt alakzat csomópontok kezelése prezentációkban Java használatával
linktitle: SmartArt alakzat csomópont
type: docs
weight: 30
url: /hu/java/manage-smartart-shape-node/
keywords:
- SmartArt csomópont
- gyermekcsomópont
- csomópont hozzáadása
- csomópont pozíció
- csomópont elérése
- csomópont eltávolítása
- egyéni pozíció
- asszisztens csomópont
- kitöltési formátum
- csomópont renderelése
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "SmartArt alakzat csomópontok kezelése PPT és PPTX fájlokban az Aspose.Slides for Java segítségével. Szerezzen világos kódpéldákat és tippeket a prezentációk hatékonyabbá tételéhez."
---
## **Áttekintés**

A PowerPoint‑prezentációkban a SmartArt grafikonok csomópontokkal vannak szervezve, amelyek szöveget tartalmaznak, és meghatározzák a diagram felépítését. Az Aspose.Slides lehetővé teszi ezen SmartArt csomópontok programozott kezelését: új csomópontok és gyermekcsomópontok hozzáadása, gyermekcsomópontok beszúrása meghatározott pozícióba, létező csomópontok elérése, valamint a szöveg, szint és pozíció kiolvasása.

Ez a cikk bemutatja, hogyan kezelhetők a SmartArt alakzat csomópontjai. Megmutatja, hogyan távolíthatók el a csomópontok, hogyan dolgozhatunk a gyermekcsomópontokkal index vagy pozíció alapján, hogyan alakítható egy asszisztens csomópont normál csomóponttá, hogyan állítható be a SmartArt csomópont alakzatok pozíciója, mérete és forgatása, hogyan állítható be a csomópont kitöltési formátuma, illetve hogyan generálható bélyegkép egy SmartArt gyermekcsomópontról.

## **SmartArt csomópont hozzáadása**
Az Aspose.Slides for Java a legegyszerűbb API‑t biztosítja a SmartArt alakzatok kezeléséhez. Az alábbi mintakód segít csomópont és gyermekcsomópont hozzáadásában egy SmartArt alakzatba.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, és töltse be a prezentációt SmartArt alakzattal.
1. Szerezze meg az első dia hivatkozását az indexe alapján.
1. Járja be az első diában lévő összes alakzatot.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusú‑e, és ha igen, típuskonvertálja a kijelölt alakzatot [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusra.
1. [Add a new Node](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) a SmartArt alakzat [**NodeCollection**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt#getAllNodes--)‑be, és állítsa be a szöveget a TextFrame‑ben.
1. Most, [Add](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) egy [**Child Node**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNode#getChildNodes--) az újonnan hozzáadott [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) csomópontban, és állítsa be a szöveget a TextFrame‑ben.
1. Mentse a prezentációt.

```java
// Betölti a kívánt prezentációt
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Bejárja az első dián belüli összes alakzatot
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ellenőrzi, hogy az alakzat SmartArt típusú-e
        if (shape instanceof SmartArt) 
        {
            // Átalakítja az alakzatot SmartArt típusra
            SmartArt smart = (SmartArt) shape;
    
            // Új SmartArt csomópont hozzáadása
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Szöveg hozzáadása
            TemNode.getTextFrame().setText("Test");
    
            // Új gyermekcsomópont hozzáadása a szülőcsomóponthoz. A gyűjtemény végére kerül.
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

## **SmartArt csomópont hozzáadása meghatározott pozícióban**
Az alábbi mintakódban ismertetjük, hogyan adhatók hozzá a megfelelő SmartArt csomópontok gyermekcsomópontjai egy konkrét pozícióban.

1. Hozzon létre egy Presentation osztálypéldányt.
1. Szerezze meg az első dia hivatkozását az indexe alapján.
1. Adjon hozzá egy [**StackedList**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtLayoutType#StackedList) típusú [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArt) alakzatot a megnyitott dián.
1. Érje el az első csomópontot a hozzáadott SmartArt alakzatban.
1. Most, adja hozzá a [**Child Node**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNode#getChildNodes--) elemet a kiválasztott [**Node**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtNode) 2. pozíciójába, és állítsa be a szöveget.
1. Mentse a prezentációt.

```java
// Prezentáció példány létrehozása
Presentation pres = new Presentation();
try {
    // A prezentáció dia elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape hozzáadása
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // A 0 indexű SmartArt csomópont elérése
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Új gyermekcsomópont hozzáadása a szülőcsomópontban 2. pozícióban
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Szöveg hozzáadása
    chNode.getTextFrame().setText("Sample Text Added");

    // Prezentáció mentése
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt csomópont elérése**
Az alábbi mintakód segít a SmartArt alakzatban lévő csomópontok elérésében. Vegye figyelembe, hogy a SmartArt LayoutType‑ja csak olvasható, és csak a SmartArt alakzat hozzáadása során állítható be.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt, és töltse be a prezentációt SmartArt alakzattal.
1. Szerezze meg az első dia hivatkozását az indexe alapján.
1. Járja be az első diában lévő összes alakzatot.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusú‑e, és ha igen, típuskonvertálja a kijelölt alakzatot [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusra.
1. Járja be az összes [**Nodes**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArt#getAllNodes--) elemet a SmartArt alakzatban.
1. Érje el és jelenítse meg a SmartArt csomópont pozícióját, szintjét és szövegét.

```java
// Presentation osztály példányosítása
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Az első dia lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Bejárja az első dián belüli összes alakzatot
    for (IShape shape : slide.getShapes()) 
    {
        // Ellenőrzi, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Átalakítja az alakzatot SmartArt típusra
            ISmartArt smart = (ISmartArt) shape;
    
            // Bejárja a SmartArt összes csomópontját
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // A SmartArt csomópont elérése i indexen
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

## **SmartArt gyermekcsomópont elérése**
Az alábbi mintakód segít a SmartArt alakzat megfelelő csomópontjainak gyermekcsomópontjainak elérésében.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt, és töltse be a prezentációt SmartArt alakzattal.
1. Szerezze meg a második dia hivatkozását az indexe alapján.
1. Járja be az első diában lévő összes alakzatot.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusú‑e, és ha igen, típuskonvertálja a kijelölt alakzatot [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusra.
1. Járja be az összes [**Nodes**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArt#getAllNodes--) elemet a SmartArt alakzatban.
1. Minden kiválasztott SmartArt [**Node**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtNode) esetén járja be az adott csomópont összes [**Child Nodes**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtNode#getChildNodes--) elemét.
1. Érje el és jelenítse meg a [**Child Node**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNode#getChildNodes--) pozícióját, szintjét és szövegét.

```java
// Presentation osztály példányosítása
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Az első dia lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Bejárja az első dián belüli összes alakzatot
    for (IShape shape : slide.getShapes()) 
    {
        // Ellenőrzi, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Átalakítja az alakzatot SmartArt típusra
            ISmartArt smart = (ISmartArt) shape;
    
            // Bejárja a SmartArt összes csomópontját
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // A SmartArt csomópont elérése i indexen
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // A SmartArt csomópont i indexű gyermekcsomópontjainak bejárása
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // A SmartArt csomópont gyermekcsomópontjának elérése
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

## **SmartArt gyermekcsomópont elérése meghatározott pozícióban**
Ebben a példában megtanuljuk, hogyan érhetők el a gyermekcsomópontok egy adott pozícióban a SmartArt megfelelő csomópontjainál.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt.
1. Szerezze meg az első dia hivatkozását az indexe alapján.
1. Adjon hozzá egy [**StackedList**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtLayoutType#StackedList) típusú SmartArt alakzatot.
1. Érje el a hozzáadott SmartArt alakzatot.
1. Érje el a 0. indexű csomópontot a kiválasztott SmartArt alakzatban.
1. Most, a **get_Item()** metódussal érje el a 1. pozícióban lévő [**Child Node**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNode#getChildNodes--) elemet.
1. Érje el és jelenítse meg a [**Child Node**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNode#getChildNodes--) pozícióját, szintjét és szövegét.

```java
// A prezentáció példányosítása
Presentation pres = new Presentation();
try {
    // Az első dia elérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt alakzat hozzáadása az első diára
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // A SmartArt csomópont elérése 0 indexen
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // A gyermekcsomópont elérése 1 pozíción a szülőcsomópontban
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // A SmartArt gyermekcsomópont paramétereinek kiírása
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt csomópont eltávolítása**
Ebben a példában megtanuljuk, hogyan távolíthatók el a SmartArt alakzat csomópontjai.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt, és töltse be a prezentációt SmartArt alakzattal.
1. Szerezze meg az első dia hivatkozását az indexe alapján.
1. Járja be az első diában lévő összes alakzatot.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusú‑e, és ha igen, típuskonvertálja a kijelölt alakzatot [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusra.
1. Ellenőrizze, hogy a [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) több mint 0 csomópontot tartalmaz‑e.
1. Válassza ki a törlendő SmartArt csomópontot.
1. Most, távolítsa el a kiválasztott csomópontot a [**RemoveNode**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) metódussal.
1. Mentse a prezentációt.

```java
// Betölti a kívánt prezentációt
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Bejárja az első dián belüli összes alakzatot
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ellenőrzi, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Átalakítja az alakzatot SmartArt típusra
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // A SmartArt csomópont elérése 0 indexen
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

## **SmartArt csomópont eltávolítása meghatározott pozícióból**
Ebben a példában megtanuljuk, hogyan távolíthatók el a SmartArt alakzat csomópontjai egy adott pozícióból.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt, és töltse be a prezentációt SmartArt alakzattal.
1. Szerezze meg az első dia hivatkozását az indexe alapján.
1. Járja be az első diában lévő összes alakzatot.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusú‑e, és ha igen, típuskonvertálja a kijelölt alakzatot [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusra.
1. Válassza ki a SmartArt alakzat 0. indexű csomópontját.
1. Ellenőrizze, hogy a kiválasztott SmartArt csomópont több mint 2 gyermekcsomópontot tartalmaz‑e.
1. Most, a **RemoveNode** metódussal ( [**RemoveNode**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) ) távolítsa el az 1. **Position**‑ban lévő csomópontot.
1. Mentse a prezentációt.

```java
// Betölti a kívánt prezentációt
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Bejárja az első dián belüli összes alakzatot
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ellenőrzi, hogy az alakzat SmartArt típusú-e
        if (shape instanceof SmartArt) 
        {
            // Átalakítja az alakzatot SmartArt típusra
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // A SmartArt csomópont elérése 0 indexen
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // A gyermekcsomópont eltávolítása 1 pozíción
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

## **Egy gyermekcsomópont egyéni pozíciójának beállítása SmartArt objektumban**
Az Aspose.Slides for Java mostantól támogatja a [SmartArtShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#setX-float-) és [Y](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#setY-float-) tulajdonságok beállítását. Az alábbi kódrészlet megmutatja, hogyan állítható be egyéni SmartArtShape pozíció, méret és forgatás; vegye figyelembe, hogy új csomópontok hozzáadása az összes csomópont pozíciójának és méretének újraszámítását eredményezi. Egyéni pozícióbeállításokkal a felhasználó a csomópontokat igényei szerint helyezheti el.

```java
// Presentation osztály példányosítása
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // SmartArt alakzat áthelyezése új pozícióba
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // SmartArt alakzat szélességének módosítása
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // SmartArt alakzat magasságának módosítása
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // SmartArt alakzat forgatásának módosítása
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Asszisztens csomópont ellenőrzése**
{{% alert color="primary" %}} 

Ebben a cikkben tovább vizsgáljuk a prezentációs diákba programozottan hozzáadott SmartArt alakzatok funkcióit az Aspose.Slides for Java használatával.

{{% /alert %}} 

Az alábbi forrás‑SmartArt alakzatot használjuk majd a cikk különböző részeiben.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Ábra: Forrás‑SmartArt alakzat a dián**|

A következő mintakódban megvizsgáljuk, hogyan azonosíthatók a **Assistant Nodes** a SmartArt csomópontgyűjteményben, valamint hogyan módosíthatók.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt, és töltse be a prezentációt SmartArt alakzattal.
1. Szerezze meg a második dia hivatkozását az indexe alapján.
1. Járja be az első diában lévő összes alakzatot.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusú‑e, és ha igen, típuskonvertálja a kijelölt alakzatot [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusra.
1. Járja be a SmartArt alakzat összes csomópontját, és ellenőrizze, hogy [**Assistant Nodes**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtNode#isAssistant--)‑ek‑e.
1. Módosítsa az Assistant Node állapotát normál csomóponttá.
1. Mentse a prezentációt.

```java
// Prezentáció példány létrehozása
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Bejárja az első dián belüli összes alakzatot
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ellenőrzi, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Átalakítja az alakzatot SmartArt típusra
            ISmartArt smart = (SmartArt) shape;
    
            // Bejárja a SmartArt alakzat összes csomópontját
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Ellenőrzi, hogy a csomópont Assistant csomópont-e
                if (node.isAssistant()) 
                {
                    // Az Assistant csomópont állapotát false-ra állítja, így normál csomópont lesz
                    node.isAssistant();
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
|**Ábra: Assistant Node‑ok módosítva a SmartArt alakzatban a dián**|

## **Csomópont kitöltési formátumának beállítása**
Az Aspose.Slides for Java lehetővé teszi egyedi SmartArt alakzatok hozzáadását és kitöltési formátumuk beállítását. Ez a cikk bemutatja, hogyan hozhatók létre és érhetők el a SmartArt alakzatok, valamint hogyan állítható be a csomópontok kitöltési formátuma az Aspose.Slides for Java‑val.

Kérjük, kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt.
1. Szerezze meg egy dia hivatkozását az indexe alapján.
1. Adjon hozzá egy [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) alakzatot a [**LayoutType**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) beállításával.
1. Állítsa be a [**FillFormat**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#getFillFormat--) formátumot a SmartArt alakzat csomópontjaihoz.
1. Írja ki a módosított prezentációt PPTX fájlként.

```java
// A prezentáció példányosítása
Presentation pres = new Presentation();
try {
    // Diának elérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt alakzat és csomópontok hozzáadása
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Csomópont kitöltési színének beállítása
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

## **SmartArt gyermekcsomópont bélyegképének generálása**
A fejlesztők az alábbi lépések követésével generálhatnak bélyegképet egy SmartArt gyermekcsomópontról:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt.
1. [Add SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. Szerezze meg egy csomópont hivatkozását az indexe alapján.
1. Szerezze meg a bélyegkép‑képet.
1. Mentse a bélyegkép‑képet a kívánt képformátumban.

```java
// PPTX fájlt reprezentáló Presentation osztály példányosítása
Presentation pres = new Presentation();
try {
    // SmartArt hozzáadása
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Egy csomópont hivatkozásának megszerzése az indexe alapján
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

**Támogatott-e a SmartArt animáció?**

Igen. A SmartArt‑ot normál alakzatként kezelik, ezért [alkalmazhat standard animációkat](/slides/hu/java/shape-animation/) (belépés, kilépés, hangsúly, mozgási útvonal) és beállíthatja az időzítést. Szükség esetén a SmartArt csomópontok belsejében lévő alakzatokat is animálhatja.

**Hogyan találhatom meg megbízhatóan egy adott SmartArt‑ot a dián, ha a belső azonosítója ismeretlen?**

Keressen [alternatív szöveg](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getAlternativeText--) alapján. Egy egyedi AltText beállítása a SmartArt‑on lehetővé teszi, hogy programkódból megtalálja anélkül, hogy belső azonosítókra támaszkodna.

**Megmarad-e a SmartArt megjelenése a prezentáció PDF‑re konvertálásakor?**

Igen. Az Aspose.Slides a [PDF export](/slides/hu/java/convert-powerpoint-to-pdf/) során magas vizuális pontossággal rendereli a SmartArt‑ot, megőrizve a elrendezést, színeket és effektusokat.

**Kivonhatok‑e képet az egész SmartArt‑ról (előnézetekhez vagy jelentésekhez)?**

Igen. A SmartArt alakzatot renderelheti [raszteres formátumokba](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getImage-int-float-float-) vagy [SVG‑be](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) a skálázható vektorkimenethez, ami alkalmas bélyegképekhez, jelentésekhez vagy webes használathoz.