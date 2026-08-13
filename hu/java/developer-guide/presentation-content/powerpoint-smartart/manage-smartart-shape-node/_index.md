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
- csomópont pozíciója
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
description: "Kezelje a SmartArt alakzat csomópontjait PPT és PPTX fájlokban az Aspose.Slides for Java segítségével. Kapjon világos kódrészleteket és tippeket a prezentációk hatékonyabbá tételéhez."
---
## **Áttekintés**

PowerPoint‑prezentációk SmartArt‑grafikái csomópontok segítségével vannak szervezve, amelyek szöveget tartalmaznak és meghatározzák a diagram felépítését. Az Aspose.Slides lehetővé teszi, hogy programozott módon kezelje ezeket a SmartArt‑csomópontokat: új csomópontok és gyermekcsomópontok hozzáadása, gyermekcsomópontok beszúrása adott pozícióban, meglévő csomópontok elérése, valamint szövegük, szintjük és pozíciójuk olvasása.

Ez a cikk bemutatja a SmartArt‑alak csomópontok kezelését. Megmutatja, hogyan lehet csomópontokat eltávolítani, gyermekcsomópontokkal index vagy pozíció szerint dolgozni, egy asszisztens csomópontot normál csomópontra változtatni, a SmartArt‑csomópont alakzatok pozícióját, méretét és forgását beállítani, a csomópont kitöltési formátumát megadni, valamint előnézeti képet (thumbnail) generálni egy SmartArt‑gyermekcsomópontról.

## **SmartArt csomópont hozzáadása**
Az Aspose.Slides for Java a legegyszerűbb API‑t biztosítja a SmartArt alakzatok kezeléséhez a legegyszerűbb módon. Az alábbi mintakód segít csomópont és gyermekcsomópont hozzáadásában egy SmartArt alakzaton belül.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztálypéldányt, és töltse be a prezentációt a SmartArt alakzattal.
1. Szerezze meg az első dia hivatkozását az Index használatával.
1. Iteráljon végig az első dián található összes alakzaton.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusú-e, és ha igen, tüntesse át a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusra.
1. [Add a new Node](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) a SmartArt alakzat [**NodeCollection**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt#getAllNodes--)‑be, és állítsa be a szöveget a TextFrame‑ben.
1. Ezután [Add](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) egy [**Child Node**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNode#getChildNodes--) az újonnan hozzáadott [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) csomópontba, és állítsa be a szöveget a TextFrame‑ben
1. Mentse a prezentációt.

```java
import com.aspose.slides.*;

// Töltsük be a kívánt prezentációt
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Iteráljon végig az első dia minden alakzaton
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape instanceof SmartArt) 
        {
            // Típuskonvertálja az alakzatot SmartArt-ra
            SmartArt smart = (SmartArt) shape;
    
            // Új SmartArt csomópont hozzáadása
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Szöveg hozzáadása
            TemNode.getTextFrame().setText("Test");
    
            // Új gyermekcsomópont hozzáadása a szülőcsomóponthoz. A gyűjtemény végén lesz hozzáadva
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

## **SmartArt csomópont hozzáadása adott pozícióban**
Az alábbi mintakódban bemutattuk, hogyan adhatjuk hozzá a SmartArt alakzat megfelelő csomópontjaihoz tartozó gyermekcsomópontokat egy meghatározott pozícióban.

1. Hozzon létre egy Presentation osztálypéldányt.
1. Szerezze meg az első dia hivatkozását az Index használatával.
1. Adjon hozzá egy [**StackedList**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtLayoutType#StackedList) típusú [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArt) alakzatot a lekért dián.
1. Szerezze meg az első csomópontot a hozzáadott SmartArt alakzatban.
1. Ezután adja hozzá a [**Child Node**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNode#getChildNodes--) a kiválasztott [**Node**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtNode) számára a 2. pozícióban, és állítsa be a szövegét.
1. Mentse a prezentációt.

```java
import com.aspose.slides.*;

// Prezentáció példány létrehozása
Presentation pres = new Presentation();
try {
    // A prezentáció dia elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape hozzáadása
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // A SmartArt csomópont elérése 0 indexen
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Új gyermekcsomópont hozzáadása a szülőcsomópontban a 2. pozíción
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
Az alábbi mintakód segít a SmartArt alakzaton belüli csomópontok elérésében. Kérjük, vegye figyelembe, hogy a SmartArt LayoutType‑ját nem lehet módosítani, mivel csak olvasható, és csak a SmartArt alakzat hozzáadása során állítható be.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt, és töltse be a prezentációt a SmartArt alakzattal.
1. Szerezze meg az első dia hivatkozását az Index használatával.
1. Iteráljon végig az első dián található összes alakzaton.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusú-e, és ha igen, tüntesse át a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusra.
1. Iteráljon végig az összes [**Nodes**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArt#getAllNodes--) a SmartArt alakzaton belül.
1. Érje el és jelenítse meg az információkat, például a SmartArt csomópont pozícióját, szintjét és szövegét.

```java
import com.aspose.slides.*;

// Prezentáció osztály példányosítása
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Első dia lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Az első dián található összes alakzat bejárása
    for (IShape shape : slide.getShapes()) 
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Típuskonvertálja az alakzatot SmartArt-ra
            ISmartArt smart = (ISmartArt) shape;
    
            // Az összes csomópont bejárása a SmartArt-ban
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
Az alábbi mintakód segít a SmartArt alakzat megfelelő csomópontjaihoz tartozó gyermekcsomópontok elérésében.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt, és töltse be a prezentációt a SmartArt alakzattal.
1. Szerezze meg az első dia hivatkozását az Index használatával.
1. Iteráljon végig az első dián található összes alakzaton.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusú-e, és ha igen, tüntesse át a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusra.
1. Iteráljon végig az összes [**Nodes**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArt#getAllNodes--) a SmartArt alakzaton belül.
1. Minden kiválasztott SmartArt alakzat [**Node**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtNode) esetén iteráljon végig az adott csomóponton belüli összes [**Child Nodes**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtNode#getChildNodes--) elemen.
1. Érje el és jelenítse meg az információkat, például a [**Child Node**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNode#getChildNodes--) pozícióját, szintjét és szövegét.

```java
import com.aspose.slides.*;

// Prezentáció osztály példányosítása
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Első dia lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Az első dián található minden alakzat bejárása
    for (IShape shape : slide.getShapes()) 
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Típuskonvertálja az alakzatot SmartArt-ra
            ISmartArt smart = (ISmartArt) shape;
    
            // Az összes csomópont bejárása a SmartArt-ban
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

## **SmartArt gyermekcsomópont elérése adott pozícióban**
Ebben a példában megtanuljuk, hogyan érhetjük el a SmartArt alakzat megfelelő csomópontjaihoz tartozó gyermekcsomópontokat egy adott pozícióban.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt.
1. Szerezze meg a második dia hivatkozását az Index használatával.
1. Adjunk hozzá egy [**StackedList**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtLayoutType#StackedList) típusú SmartArt alakzatot.
1. Érje el a hozzáadott SmartArt alakzatot.
1. Érje el a 0. indexű csomópontot a lekért SmartArt alakzatban.
1. Ezután érje el a [**Child Node**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNode#getChildNodes--) csomópontot az 1. pozícióban a lekért SmartArt csomópontnál a **get_Item()** metódussal.
1. Érje el és jelenítse meg az információkat, például a [**Child Node**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNode#getChildNodes--) pozícióját, szintjét és szövegét.

```java
import com.aspose.slides.*;

// Prezentáció példányosítása
Presentation pres = new Presentation();
try {
    // Az első dia elérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt alakzat hozzáadása az első diára
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // A SmartArt csomópont elérése 0 indexen
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // A szülőcsomópont 1. pozíciójában lévő gyermekcsomópont elérése
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // A SmartArt gyermekcsomópont paramétereinek kiírása
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt csomópont eltávolítása**
Ebben a példában megtanuljuk, hogyan távolítsuk el a SmartArt alakzaton belüli csomópontokat.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt, és töltse be a prezentációt a SmartArt alakzattal.
1. Szerezze meg az első dia hivatkozását az Index használatával.
1. Iteráljon végig az első dián található összes alakzaton.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusú-e, és ha igen, tüntesse át a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusra.
1. Ellenőrizze, hogy a [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) több mint 0 csomóponttal rendelkezik-e.
1. Válassza ki a törlendő SmartArt csomópontot.
1. Ezután távolítsa el a kiválasztott csomópontot a [**RemoveNode**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) metódus használatával.
1. Mentse a prezentációt.

```java
import com.aspose.slides.*;

// A kívánt prezentáció betöltése
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Az első dián található minden alakzat bejárása
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Típuskonvertálja az alakzatot SmartArt-ra
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

## **SmartArt csomópont eltávolítása adott pozícióból**
Ebben a példában megtanuljuk, hogyan távolítsuk el a SmartArt alakzaton belüli csomópontokat egy adott pozícióból.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt, és töltse be a prezentációt a SmartArt alakzattal.
1. Szerezze meg az első dia hivatkozását az Index használatával.
1. Iteráljon végig az első dián található összes alakzaton.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusú-e, és ha igen, tüntesse át a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusra.
1. Válassza ki a 0. indexű SmartArt alakzat csomópontot.
1. Ezután ellenőrizze, hogy a kiválasztott SmartArt csomópont több mint 2 gyermekcsomóponttal rendelkezik-e.
1. Ezután távolítsa el az **1. Position**‑ban lévő csomópontot a [**RemoveNode**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) metódus használatával.
1. Mentse a prezentációt.

```java
import com.aspose.slides.*;

// A kívánt prezentáció betöltése
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Az első dián található minden alakzat bejárása
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape instanceof SmartArt) 
        {
            // Típuskonvertálja az alakzatot SmartArt-ra
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // A SmartArt csomópont elérése 0 indexen
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // A gyermekcsomópont eltávolítása az 1. pozíción
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

## **Egyéni pozíció beállítása gyermekcsomópont számára egy SmartArt objektumban**
Az Aspose.Slides for Java most támogatja a [SmartArtShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#setX-float-) és [Y](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#setY-float-) tulajdonságok beállítását. Az alábbi kódrészlet bemutatja, hogyan állítható be egyéni SmartArtShape pozíció, méret és forgatás, továbbá vegye figyelembe, hogy új csomópontok hozzáadása az összes csomópont pozíciójának és méretének újraszámítását eredményezi. Az egyéni pozícióbeállításokkal a felhasználó a csomópontokat a követelményeknek megfelelően állíthatja.

```java
import com.aspose.slides.*;

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
{{% alert color="info" %}} 
Ebben a cikkben tovább vizsgáljuk a programozottan, az Aspose.Slides for Java segítségével a prezentációs diákhoz hozzáadott SmartArt alakzatok funkcióit.
{{% /alert %}} 

A cikk különböző részeiben a következő forrás SmartArt alakzatot fogjuk felhasználni a vizsgálathoz.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Ábra: Forrás SmartArt alakzat a dián**|

Az alábbi mintakódban megvizsgáljuk, hogyan azonosítsuk a **Assistant Nodes** (asszisztens csomópontokat) a SmartArt csomópontgyűjteményben, és hogyan módosíthatjuk őket.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt, és töltse be a prezentációt a SmartArt alakzattal.
1. Szerezze meg a második dia hivatkozását az Index használatával.
1. Iteráljon végig az első dián található összes alakzaton.
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusú-e, és ha igen, tüntesse át a kiválasztott alakzatot [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) típusra.
1. Iteráljon végig a SmartArt alakzaton belüli összes csomóponton, és ellenőrizze, hogy [**Assistant Nodes**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtNode#isAssistant--) vannak-e.
1. Módosítsa az asszisztens csomópont állapotát normál csomóponttá.
1. Mentse a prezentációt.

```java
import com.aspose.slides.*;

// Prezentáció példány létrehozása
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Az első dián található minden alakzat bejárása
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape instanceof ISmartArt) 
        {
            // Típuskonvertálja az alakzatot SmartArt-ra
            ISmartArt smart = (SmartArt) shape;
    
            // Az összes csomópont bejárása a SmartArt alakzaton
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Ellenőrizze, hogy a csomópont asszisztens-e
                if (node.isAssistant()) 
                {
                    // Az asszisztens csomópont beállítása false értékre, normál csomópontra alakítva
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
|**Ábra: Asszisztens csomópontok módosítva a SmartArt alakzaton a dián belül**|

## **Csomópont kitöltési formátumának beállítása**
Az Aspose.Slides for Java lehetővé teszi egyéni SmartArt alakzatok hozzáadását és azok kitöltési formátumának beállítását. Ez a cikk bemutatja, hogyan hozhatók létre és érhetők el a SmartArt alakzatok, valamint hogyan állítható be a kitöltési formátum az Aspose.Slides for Java segítségével.

Kérjük, kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt.
1. Szerezze meg egy dia hivatkozását az indexe alapján.
1. Adjon hozzá egy [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArt) alakzatot a [**LayoutType**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) beállításával.
1. Állítsa be a [**FillFormat**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#getFillFormat--) értékét a SmartArt alakzat csomópontjaihoz.
1. Írja ki a módosított prezentációt PPTX fájlként.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Prezentáció példányosítása
Presentation pres = new Presentation();
try {
    // Diának a lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt alakzat és csomópontok hozzáadása
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Csomópont kitöltő színének beállítása
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

## **SmartArt gyermekcsomópont előnézeti képének generálása**
A fejlesztők a következő lépéseket követve generálhatnak előnézeti képet egy SmartArt gyermekcsomópontjáról:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztálypéldányt.
1. [Add SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. Szerezze meg egy csomópont hivatkozását az Index használatával
1. Szerezze meg az előnézeti képet.
1. Mentse az előnézeti képet tetszőleges képformátumban.

```java
import com.aspose.slides.*;

// PPTX fájlt képviselő Presentation osztály példányosítása 
Presentation pres = new Presentation();
try {
    // SmartArt hozzáadása 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Csomópont hivatkozásának lekérése az Index használatával  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Előnézeti kép lekérése
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Előnézeti kép mentése
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Támogatott-e a SmartArt animáció?
Igen. A SmartArt-ot szabályos alakzatként kezelik, így [alkalmazhat standard animációkat](/slides/hu/java/shape-animation/) (belépés, kilépés, hangsúlyozás, mozgáspályák) és beállíthatja az időzítést. Szükség esetén a SmartArt csomópontok belsejében lévő alakzatokat is animálhatja.

### Hogyan találhatom meg megbízhatóan egy adott SmartArt-ot egy dián, ha annak belső azonosítója ismeretlen?
Rendeljen hozzá és keressen az [alternatív szöveg](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getAlternativeText--) alapján. Egy megkülönböztető AltText beállítása a SmartArt-hoz lehetővé teszi, hogy programozottan megtalálja anélkül, hogy a belső azonosítókra támaszkodna.

### Megmarad-e a SmartArt megjelenése a prezentáció PDF-re konvertálásakor?
Igen. Az Aspose.Slides magas vizuális hűséggel rendereli a SmartArt-ot a [PDF export](/slides/hu/java/convert-powerpoint-to-pdf/) során, megőrizve a elrendezést, színeket és hatásokat.

### Kinyerhetek-e a teljes SmartArt képet (előnézetekhez vagy jelentésekhez)?
Igen. A SmartArt alakzatot renderelheti [raszteres formátumokba](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getImage-int-float-float-) vagy [SVG](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) formátumba, amely skálázható vektorkimenetet biztosít, így alkalmas előnézetekhez, jelentésekhez vagy webes használatra.