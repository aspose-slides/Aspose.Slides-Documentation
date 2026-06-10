---
title: Csoportos prezentációs alakzatok Java-ban
linktitle: Alakzatcsoport
type: docs
weight: 40
url: /hu/java/group/
keywords:
- csoport alakzat
- alakzatcsoport
- csoport hozzáadása
- alternatív szöveg
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan csoportosítsa és bontsa szét az alakzatokat PowerPoint prezentációkban az Aspose.Slides for Java használatával - gyors, lépésről-lépésre útmutató ingyenes Java kóddal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozzunk csoport alakzatokkal az Aspose.Slides-ben. Megmutatja, hogyan adhatunk csoport alakzatot egy diára, hogyan helyezhetünk alakzatokat bele, és hogyan menthetjük el a módosított prezentációt. Bemutatja továbbá, hogyan érhetők el a csoporton belül tárolt alakzatok, és hogyan olvashatók ki azok `AlternativeText` értékei. Emellett röviden érinti a csoport alakzatokkal kapcsolatos további lehetőségeket, például a beágyazott csoportokat, a z-rendet és a zárolási opciókat.

## **Csoport alakzat hozzáadása**
Az Aspose.Slides támogatja a csoport alakzatok használatát a diákon. Ez a funkció segíti a fejlesztőket, hogy gazdagabb prezentációkat készítsenek. Az Aspose.Slides for Java támogatja a csoport alakzatok hozzáadását vagy elérését. Lehetőség van alakzatokat hozzáadni egy már létrehozott csoport alakzathoz, hogy feltöltsük azt, vagy bármelyik tulajdonságát elérni. Csoport alakzat hozzáadásához egy diára az Aspose.Slides for Java használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia referenciáját az Index használatával  
3. Adjon hozzá egy csoport alakzatot a diához.  
4. Adjon hozzá alakzatokat a hozzáadott csoport alakzathoz.  
5. Mentse a módosított prezentációt PPTX fájlként.  

Az alábbi példa egy csoport alakzatot ad hozzá egy diához.

```java
// Presentation osztály példányosítása
Presentation pres = new Presentation();
try {
    // Az első dia lekérése
    ISlide sld = pres.getSlides().get_Item(0);

    // A diák alakzatgyűjteményének elérése
    IShapeCollection slideShapes = sld.getShapes();

    // Csoport alakzat hozzáadása a diához
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Alakzatok hozzáadása a hozzáadott csoport alakzathoz
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Csoport alakzat keret hozzáadása
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // A PPTX fájl írása a lemezre
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Az AltText tulajdonság elérése**
Ez a téma egyszerű lépéseket mutat be, kódpéldákkal, egy csoport alakzat hozzáadásához és a csoport alakzatok AltText tulajdonságának eléréséhez a diákon. A csoport alakzat AltText értékének eléréséhez egy dián az Aspose.Slides for Java használatával:

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályt, amely egy PPTX fájlt képvisel.  
2. Szerezze meg egy dia referenciáját az Index használatával.  
3. A diák alakzatgyűjteményének elérése.  
4. A csoport alakzat elérése.  
5. A [AlternativeText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#getAlternativeText--) tulajdonság elérése.  

Az alábbi példa a csoport alakzat alternatív szövegét érinti.

```java
// PPTX fájlt képviselő Presentation osztály példányosítása
Presentation pres = new Presentation("AltText.pptx");
try {
    // Az első dia lekérése
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // A diák alakzatgyűjteményének elérése
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

## **Gyakran ismételt kérdések**

**Támogatott a beágyazott csoportosítás (csoport egy másik csoporton belül)?**  
Igen. A [GroupShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/groupshape/) rendelkezik egy [getParentGroup](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getParentGroup--) metódussal, amely közvetlenül jelzi a hierarchia támogatását (egy csoport lehet egy másik csoport gyermeke).

**Hogyan szabályozhatom a csoport z-rendjét a dia többi objektumához képest?**  
Használja a [GroupShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/groupshape/) [getZOrderPosition](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getZOrderPosition--) metódusát a megjelenítési rétegben betöltött pozíciójának megtekintéséhez.

**Megakadályozhatom a mozgatást/szerkesztést/csoport bontását?**  
Igen. A csoport zárolási szekciója a [GroupShapeLock](https://reference.aspose.com/slides/hu/java/com.aspose.slides/groupshape/#getGroupShapeLock--) segítségével érhető el, amely lehetővé teszi a műveletek korlátozását az objektumon.