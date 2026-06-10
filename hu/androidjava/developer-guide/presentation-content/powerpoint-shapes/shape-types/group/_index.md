---
title: Csoportos bemutató alakzatok Androidon
linktitle: Alakzatcsoport
type: docs
weight: 40
url: /hu/androidjava/group/
keywords:
- csoport alakzat
- alakzatcsoport
- csoport hozzáadása
- alternatív szöveg
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Tanulja meg csoportosítani és felbontani az alakzatokat PowerPoint prezentációkban az Aspose.Slides for Android segítségével – gyors, lépésről‑lépésre útmutató ingyenes Java kóddal."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhat a csoport alakzatokkal az Aspose.Slides-ban. Bemutatja, hogyan adhatunk csoport alakzatot egy diára, helyezhetünk el benne alakzatokat, és menthetjük a frissített prezentációt. Azt is megmutatja, hogyan érhetők el a csoportban tárolt alakzatok és hogyan olvashatók ki a `AlternativeText` értékeik. Emellett a cikk röviden érinti a kapcsolódó csoport‑alakzat funkciókat, mint a beágyazott csoportok, z‑rend és zárolási beállítások.

## **Csoport alakzat hozzáadása**
Aspose.Slides támogatja a csoport alakzatok használatát a diákon. Ez a funkció segíti a fejlesztőket, hogy gazdagabb prezentációkat készítsenek. Az Aspose.Slides for Android via Java támogatja a csoport alakzatok hozzáadását és elérését. Lehetőség van alakzatokat hozzáadni egy hozzáadott csoport alakzathoz, hogy feltöltsük azt, vagy elérni a csoport alakzat bármely tulajdonságát. Ahhoz, hogy csoport alakzatot adjunk egy diára az Aspose.Slides for Android via Java használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2. Szerezze meg egy dia referenciáját az Indexének használatával.
3. Adjon hozzá egy csoport alakzatot a diához.
4. Adja hozzá az alakzatokat a hozzáadott csoport alakzathoz.
5. Mentse a módosított prezentációt PPTX fájlként.

```java
// Presentation osztály példányosítása
Presentation pres = new Presentation();
try {
    // Első dia lekérése
    ISlide sld = pres.getSlides().get_Item(0);

    // A diák alakzatgyűjteményéhez való hozzáférés
    IShapeCollection slideShapes = sld.getShapes();

    // Csoport alakzat hozzáadása a diára
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Alakzatok hozzáadása a hozzáadott csoport alakzathoz
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Csoport alakzat keret hozzáadása
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // PPTX fájl írása lemezre
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Az AltText tulajdonság elérése**
Ez a téma egyszerű lépéseket mutat be, kódrészletekkel, a csoport alakzat hozzáadásához és a csoport alakzatok AltText tulajdonságának eléréséhez a diákon. Az AltText eléréséhez egy csoport alakzatban egy dián az Aspose.Slides for Android via Java használatával:

1. Példányosítson egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályt, amely egy PPTX fájlt képvisel.
2. Szerezze meg egy dia referenciáját az Indexének használatával.
3. A diák alakzatgyűjteményéhez való hozzáférés.
4. A csoport alakzat elérése.
5. A [AlternativeText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#getAlternativeText--) tulajdonság elérése.

```java
// PPTX fájlt képviselő Presentation osztály példányosítása
Presentation pres = new Presentation("AltText.pptx");
try {
    // Az első dia lekérése
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // A diák alakzatgyűjteményéhez való hozzáférés
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // A csoport alakzat elérése.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // Az AltText tulajdonság elérése
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Támogatott-e a beágyazott csoportosítás (csoport egy csoporton belül)?**

Igen. A [GroupShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/groupshape/) rendelkezik egy [getParentGroup](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getParentGroup--) metódussal, amely közvetlenül jelzi a hierarchia támogatását (egy csoport gyermekként szerepelhet egy másik csoportban).

**Hogyan szabályozhatom a csoport z‑rendjét a dia egyéb objektumaihoz képest?**

Használja a [GroupShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/groupshape/) [getZOrderPosition](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getZOrderPosition--) metódusát a megjelenítési veremben betöltött pozíciójának ellenőrzéséhez.

**Megakadályozhatom a mozgatást/szerkesztést/csoport felbontását?**

Igen. A csoport zárolási szakasza a [getGroupShapeLock](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--) segítségével érhető el, amely lehetővé teszi, hogy korlátozza a műveleteket az objektumon.