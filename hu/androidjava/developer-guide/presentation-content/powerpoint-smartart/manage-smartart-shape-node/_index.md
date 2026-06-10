---
title: Androidon a SmartArt alakzat csomópontok kezelése prezentációkban
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
description: "SmartArt alakzat csomópontok kezelése PPT és PPTX fájlokban az Aspose.Slides for Android segítségével. Kapjon tiszta Java kódrészleteket és tippeket a prezentációk hatékonyabbá tételéhez."
---
## **Áttekintés**

A PowerPoint prezentációkban a SmartArt grafikákat olyan csomópontok szervezik, amelyek szöveget tartalmaznak, és meghatározzák a diagram felépítését. Az Aspose.Slides lehetővé teszi, hogy programozottan dolgozzon ezekkel a SmartArt csomópontokkal: új csomópontok és gyermekcsomópontok hozzáadása, gyermekcsomópontok beszúrása egy adott pozícióban, meglévő csomópontok elérése, és a szövegük, szintjük és pozíciójuk olvasása.

Ez a cikk bemutatja, hogyan kezelje a SmartArt alakzat csomópontjait. Megmutatja, hogyan távolítson el csomópontokat, hogyan dolgozzon gyermekcsomópontokkal index vagy pozíció szerint, hogyan változtasson egy asszisztens csomópontot normál csomóponttá, hogyan állítsa be a SmartArt csomópont alakzatok pozícióját, méretét és forgását, hogyan állítsa be a csomópont kitöltési formátumát, és hogyan generáljon egy bélyegképet egy SmartArt gyermekcsomópontról.

## **SmartArt csomópont hozzáadása**
Az Aspose.Slides for Android via Java a legegyszerűbb API-t biztosítja a SmartArt alakzatok kezelése érdekében. A következő mintakód segít csomópont és gyermekcsomópont hozzáadásában egy SmartArt alakzatba.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, és töltse be a prezentációt SmartArt alakzattal.
2. Szerezze be az első dia hivatkozását az Indexe használatával.
3. Iteráljon végig az első dián lévő összes alakzaton.
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusú-e, és ha igen, castolja a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusra.
5. [Új csomópont hozzáadása](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) a SmartArt alakzat [**NodeCollection**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt#getAllNodes--)‑ben, és állítsa be a szöveget a TextFrame‑ben.
6. Most, [Adj hozzá](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) egy [**Gyermekcsomópont**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) az újonnan hozzáadott [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) csomópontban, és állítsa be a szöveget a TextFrame‑ben.
7. Mentse a prezentációt.

```java
// Töltsd be a kívánt prezentációt
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Iterálj végig az első diában lévő összes alakzaton
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ellenőrizd, hogy az alakzat SmartArt típusú-e
        if (shape instanceof SmartArt) 
        {
            // Castold az alakzatot SmartArt típusra
            SmartArt smart = (SmartArt) shape;
    
            // Új SmartArt csomópont hozzáadása
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Szöveg hozzáadása
            TemNode.getTextFrame().setText("Test");
    
            // Új gyermekcsomópont hozzáadása a szülő csomóponthoz. A gyűjtemény végére lesz hozzáadva
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
A következő mintakódban bemutatjuk, hogyan adjon hozzá gyermekcsomópontokat a SmartArt alakzat megfelelő csomópontjaihoz egy adott pozícióban.

1. Hozzon létre egy példányt a Presentation osztályból.
2. Szerezze be az első dia hivatkozását az Indexe használatával.
3. Adjon hozzá egy [**StackedList**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) típusú [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArt) alakzatot a megnyitott dián.
4. Érje el az első csomópontot a hozzáadott SmartArt alakzatban.
5. Most, adjon hozzá egy [**Gyermekcsomópont**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) a kiválasztott [**Csomóponthoz**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtNode) a 2‑es pozícióban, és állítsa be a szövegét.
6. Mentse a prezentációt.

```java
// Prezentációpéldány létrehozása
Presentation pres = new Presentation();
try {
    // A prezentáció diájának elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape hozzáadása
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // SmartArt csomópont elérése a 0. indexen
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Új gyermekcsomópont hozzáadása a szülő csomóponton belül a 2. pozícióban
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
A következő mintakód segít a SmartArt alakzatban lévő csomópontok elérésében. Kérjük, vegye figyelembe, hogy a SmartArt LayoutType‑ját nem módosíthatja, mivel csak olvasható, és csak a SmartArt alakzat hozzáadásakor kerül beállításra.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból, és töltse be a prezentációt SmartArt alakzattal.
2. Szerezze be az első dia hivatkozását az Indexe használatával.
3. Iteráljon végig az első dián lévő összes alakzaton.
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusú‑e, és ha igen, castolja a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusra.
5. Iteráljon végig az összes [**Csomópont**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArt#getAllNodes--) a SmartArt alakzatban.
6. Érje el és jelenítse meg a SmartArt csomópont pozíciójával, szintjével és szövegével kapcsolatos információkat.

```java
// Prezentáció osztály példányosítása
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Első dia lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Traversálás az első dián belüli összes alakzaton
    for (IShape shape : slide.getShapes()) 
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Átalakítás SmartArt típusra
            ISmartArt smart = (ISmartArt) shape;
    
            // Traversálás a SmartArt összes csomópontján
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // SmartArt csomópont elérése i indexen
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
A következő mintakód segít a SmartArt alakzat megfelelő csomópontjaihoz tartozó gyermekcsomópontok elérésében.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból, és töltse be a prezentációt SmartArt alakzattal.
2. Szerezze be a második dia hivatkozását az Indexe használatával.
3. Iteráljon végig az első dián lévő összes alakzaton.
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusú‑e, és ha igen, castolja a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusra.
5. Iteráljon végig az összes [**Csomópont**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArt#getAllNodes--) a SmartArt alakzatban.
6. Minden kiválasztott SmartArt [**Csomóponthoz**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtNode) iteráljon végig az összes [**Gyermekcsomópont**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) adott csomópontban.
7. Érje el és jelenítse meg a [**Gyermekcsomópont**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) pozícióját, szintjét és szövegét.

```java
// Prezentáció osztály példányosítása
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Első dia lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Traversálás az első dián belüli összes alakzaton
    for (IShape shape : slide.getShapes()) 
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Átalakítás SmartArt típusra
            ISmartArt smart = (ISmartArt) shape;
    
            // Traversálás a SmartArt összes csomópontján
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // SmartArt csomópont elérése i indexen
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Traversálás a SmartArt csomópont i indexű gyermekcsomópontjain
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

## **SmartArt gyermekcsomópont elérése meghatározott pozícióban**
Ebben a példában megtanuljuk, hogyan érjük el a gyermekcsomópontokat egy adott pozícióban a SmartArt megfelelő csomópontjaihoz tartozóan.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
2. Szerezze be az első dia hivatkozását az Indexe használatával.
3. Adjon hozzá egy [**StackedList**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) típusú SmartArt alakzatot.
4. Érje el a hozzáadott SmartArt alakzatot.
5. Érje el a 0‑s indexű csomópontot a megnyitott SmartArt alakzatban.
6. Most, használja a **get_Item()** metódust a 1‑es pozícióban lévő [**Gyermekcsomópont**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) eléréséhez a megnyitott SmartArt csomópontban.
7. Érje el és jelenítse meg a [**Gyermekcsomópont**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) pozícióját, szintjét és szövegét.

```java
// A prezentáció példányosítása
Presentation pres = new Presentation();
try {
    // Az első dia elérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt alakzat hozzáadása az első diára
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // SmartArt csomópont elérése a 0. indexen
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Gyermekcsomópont elérése az 1. pozícióban a szülő csomópontban
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // A SmartArt gyermekcsomópont paramétereinek kiírása
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt csomópont eltávolítása**
Ebben a példában megtanuljuk, hogyan távolítsuk el a SmartArt alakzatban lévő csomópontokat.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból, és töltse be a prezentációt SmartArt alakzattal.
2. Szerezze be az első dia hivatkozását az Indexe használatával.
3. Iteráljon végig az első dián lévő összes alakzaton.
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusú‑e, és ha igen, castolja a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusra.
5. Ellenőrizze, hogy a [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) több mint 0 csomóponttal rendelkezik‑e.
6. Válassza ki a törlendő SmartArt csomópontot.
7. Most, távolítsa el a kiválasztott csomópontot a [**RemoveNode**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) metódus segítségével.
8. Mentse a prezentációt.

```java
// Töltsd be a kívánt prezentációt
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Traversálás az első diában lévő összes alakzaton
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ellenőrizd, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Átalakítás alakzatot SmartArt típusra
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

## **SmartArt csomópont eltávolítása meghatározott pozícióból**
Ebben a példában megtanuljuk, hogyan távolítsuk el a SmartArt alakzatban lévő csomópontokat egy adott pozícióban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból, és töltse be a prezentációt SmartArt alakzattal.
2. Szerezze be az első dia hivatkozását az Indexe használatával.
3. Iteráljon végig az első dián lévő összes alakzaton.
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusú‑e, és ha igen, castolja a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusra.
5. Válassza ki a SmartArt alakzat 0. indexű csomópontját.
6. Ellenőrizze, hogy a kiválasztott SmartArt csomópontnak több mint 2 gyermekcsomópontja van‑e.
7. Most, távolítsa el az 1‑es **Pozícióban** lévő csomópontot a [**RemoveNode**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) metódus segítségével.
8. Mentse a prezentációt.

```java
// Töltsd be a kívánt prezentációt
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Traversálás az első diában lévő összes alakzaton
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ellenőrizd, hogy az alakzat SmartArt típusú-e
        if (shape instanceof SmartArt) 
        {
            // Átalakítás alakzatot SmartArt típusra
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // SmartArt csomópont elérése a 0. indexen
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // A gyermekcsomópont eltávolítása az 1. pozícióban
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

## **Egyedi pozíció beállítása gyermekcsomópontnak SmartArt objektumban**
Most az Aspose.Slides for Android via Java támogatja a [SmartArtShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#setX-float-) és [Y](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#setY-float-) tulajdonságok beállítását. Az alábbi kódrészlet megmutatja, hogyan állítható be egyedi SmartArtShape pozíció, méret és forgatás; vegye figyelembe, hogy új csomópontok hozzáadása az összes csomópont pozíciójának és méretének újraszámítását eredményezi. Az egyedi pozícióbeállításokkal a felhasználó a csomópontokat a saját igényei szerint állíthatja be.

```java
// Prezentáció osztály példányosítása
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

Ebben a cikkben tovább vizsgáljuk a SmartArt alakzatok jellemzőit, amelyeket programozottan adtunk hozzá a prezentációs diákhoz az Aspose.Slides for Android via Java használatával.

{{% /alert %}} 

A cikk különböző szakaszaiban a következő forrás SmartArt alakzatot fogjuk felhasználni a vizsgálathoz.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Ábra: Forrás SmartArt alakzat a dián**|

A következő mintakódban megvizsgáljuk, hogyan azonosíthatók a **Assistant Nodes** a SmartArt csomópontgyűjteményben, és hogyan módosíthatók.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból, és töltse be a prezentációt SmartArt alakzattal.
2. Szerezze be a második dia hivatkozását az Indexe használatával.
3. Iteráljon végig az első dián lévő összes alakzaton.
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusú‑e, és ha igen, castolja a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) típusra.
5. Iteráljon végig a SmartArt alakzat összes csomópontján, és ellenőrizze, hogy azok **Assistant Nodes**‑e‑k‑e ([SmartArtNode#isAssistant--](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtNode#isAssistant--)).
6. Változtassa meg az Assistant Node állapotát normál csomóponttá.
7. Mentse a prezentációt.

```java
// Prezentációpéldány létrehozása
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Traversálás az első diában lévő összes alakzaton
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ellenőrizd, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Átalakítás alakzatot SmartArt típusra
            ISmartArt smart = (SmartArt) shape;
    
            // Traversálás a SmartArt alakzat összes csomópontján
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Ellenőrizd, hogy a csomópont Assistant csomópont-e
                if (node.isAssistant()) 
                {
                    // Assistant csomópont állapotának false-ra állítása és normál csomópontra alakítása
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
|**Ábra: Assistant Nodes módosítva a SmartArt alakzaton a dián**|

## **Csomópont kitöltési formátumának beállítása**
Az Aspose.Slides for Android via Java lehetővé teszi egyedi SmartArt alakzatok hozzáadását és kitöltési formátumuk beállítását. Ez a cikk azt magyarázza, hogyan hozhatók létre és érhetők el SmartArt alakzatok, valamint hogyan állítható be a kitöltési formátum az Aspose.Slides for Android via Java használatával.

Kérjük, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
2. Szerezze be egy dia hivatkozását az indexe használatával.
3. Adj hozzá egy [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArt) alakzatot a megfelelő [**LayoutType**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) beállításával.
4. Állítsa be a [**FillFormat**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#getFillFormat--) értékét a SmartArt alakzat csomópontjaihoz.
5. Írja ki a módosított prezentációt PPTX fájlként.

```java
// A prezentáció példányosítása
Presentation pres = new Presentation();
try {
    // Dia elérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt alakzat és csomópontok hozzáadása
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Csomópont kitöltőszínének beállítása
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

## **Bélyegkép generálása SmartArt gyermekcsomópontról**
A fejlesztők a következő lépésekkel generálhatnak bélyegképet egy SmartArt gyermekcsomópontról:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
2. [SmartArt hozzáadása](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).
3. Szerezze be egy csomópont hivatkozását az Indexe használatával.
4. Szerezze be a bélyegkép képet.
5. Mentse a bélyegképet a kívánt képméretben.

```java
// Prezentáció osztály példányosítása, amely a PPTX fájlt képviseli 
Presentation pres = new Presentation();
try {
    // SmartArt hozzáadása
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Csomópont hivatkozásának lekérése az Indexe használatával  
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

**Támogatott a SmartArt animáció?**

Igen. A SmartArt‑ot egy szabályos alakzatként kezelik, így használhatja a [szabványos animációk alkalmazását](/slides/hu/androidjava/shape-animation/) (belépés, kilépés, hangsúlyozás, mozgási útvonalak), és beállíthatja az időzítést. Szükség esetén animálhatja a SmartArt csomópontok belsejében lévő alakzatokat is.

**Hogyan találhatok megbízhatóan egy adott SmartArt‑ot egy dián, ha belső azonosítója ismeretlen?**

Rendeljen és keressen [alternatív szöveggel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getAlternativeText--). Az alt‑szöveg egyedi beállítása a SmartArt‑on lehetővé teszi, hogy programozottan megtalálja, anélkül hogy a belső azonosítókra támaszkodna.

**Megmarad a SmartArt megjelenése a prezentáció PDF‑re konvertálásakor?**

Igen. Az Aspose.Slides magas vizuális hűséggel rendereli a SmartArt‑ot a [PDF export](/slides/hu/androidjava/convert-powerpoint-to-pdf/) során, megőrizve a elrendezést, színeket és effekteket.

**Kivonhatok egy képet a teljes SmartArt‑ból (előnézetekhez vagy jelentésekhez)?**

Igen. Renderelhet egy SmartArt alakzatot [raszteres formátumok](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) vagy [SVG](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) formátumba, ami skálázható vektoros kimenetet biztosít, így alkalmas bélyegképekhez, jelentésekhez vagy webes felhasználáshoz.