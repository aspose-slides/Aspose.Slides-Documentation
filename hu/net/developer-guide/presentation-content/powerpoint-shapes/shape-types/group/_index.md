---
title: Csoportosított prezentációs alakzatok .NET-ben
linktitle: Alakzatcsoport
type: docs
weight: 40
url: /hu/net/group/
keywords:
- csoport alakzat
- alakzatcsoport
- csoport hozzáadása
- alternatív szöveg
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan csoportosíthat és bont csoportba a PowerPoint prezentációkban lévő alakzatokat az Aspose.Slides for .NET használatával—gyors, lépésről-lépésre útmutató ingyenes C# kóddal."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan dolgozhatunk csoport alakzatokkal az Aspose.Slides-ben. Bemutatja, hogyan adhatunk egy csoport alakzatot egy diára, hogyan helyezhetünk el benne alakzatokat, és hogyan menthetjük a frissített bemutatót. Emellett bemutatja, hogyan érhetjük el a csoporton belül tárolt alakzatokat, és olvashatjuk azok `AlternativeText` értékét. Továbbá a cikk röviden kitér a kapcsolódó csoport‑alakzat lehetőségekre, mint a beágyazott csoportok, a z‑sorrend és a zárolási beállítások.

## **Csoport alakzat hozzáadása**
Az Aspose.Slides támogatja a csoport alakzatok kezelését a diákon. Ez a funkció segít a fejlesztőknek gazdagabb bemutatókat készíteni. Az Aspose.Slides for .NET lehetővé teszi a csoport alakzatok hozzáadását vagy elérését. Lehetőség van alakzatokat hozzáadni egy már létrehozott csoport alakzathoz, hogy feltöltsük azt, vagy a csoport alakzat bármely tulajdonságát elérjük. Csoport alakzat hozzáadásához egy diára az Aspose.Slides for .NET használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezze meg egy dia hivatkozását az Indexének használatával
1. Adjon hozzá egy csoport alakzatot a diához.
1. Adja hozzá az alakzatokat a hozzáadott csoport alakzathoz.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi példa egy csoport alakzatot ad hozzá egy diához.

```c#
 // Példányosítsa a Presentation osztályt 
 using (Presentation pres = new Presentation())
 {
     // Szerezze meg az első diát 
     ISlide sld = pres.Slides[0];

     // A diák alakzatgyűjteményének elérése 
     IShapeCollection slideShapes = sld.Shapes;

     // Csoport alakzat hozzáadása a diára 
     IGroupShape groupShape = slideShapes.AddGroupShape();

     // Alakzatok hozzáadása a hozzáadott csoport alakzathoz 
     groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
     groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
     groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
     groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

     // Csoport alakzat keret hozzáadása 
     groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

     // A PPTX fájl írása lemezre 
     pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
 }
```



## **Az AltText tulajdonság elérése**
Ez a téma egyszerű lépéseket mutat be, kódrészletekkel együtt, egy csoport alakzat hozzáadásához és a csoport alakzatok AltText tulajdonságának eléréséhez a diákon. Az AltText eléréséhez egy csoport alakzatban egy dián az Aspose.Slides for .NET használatával:

1. Példányosítsa a `Presentation` osztályt, amely PPTX fájlt képvisel.
1. Szerezze meg egy dia hivatkozását az Indexének használatával.
1. A diák alakzatgyűjteményének elérése.
1. A csoport alakzat elérése.
1. Az AltText tulajdonság elérése.

Az alábbi példa a csoport alakzat alternatív szövegét éri el.

```c#
// Példányosítsa a Presentation osztályt, amely PPTX fájlt képvisel
Presentation pres = new Presentation("AltText.pptx");

// Szerezze meg az első diát
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // A diák alakzatgyűjteményének elérése
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // A csoport alakzat elérése.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // Az AltText (alternatív szöveg) tulajdonság elérése
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

## **GYIK**

**Támogatott a beágyazott csoportosítás (csoport egy másik csoporton belül)?**

Igen. A [GroupShape](https://reference.aspose.com/slides/hu/net/aspose.slides/groupshape/) rendelkezik egy [ParentGroup](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/parentgroup/) tulajdonsággal, amely közvetlenül jelzi a hierarchia támogatását (egy csoport lehet egy másik csoport gyermeke).

**Hogyan szabályozhatom a csoport z‑sorrendjét a dián lévő egyéb objektumokhoz képest?**

Használja a [GroupShape](https://reference.aspose.com/slides/hu/net/aspose.slides/groupshape/) [ZOrderPosition](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/zorderposition/) tulajdonságát a megjelenítési veremben elfoglalt helyének ellenőrzéséhez.

**Megakadályozhatom a mozgatást/szerkesztést/csoportbontást?**

Igen. A csoport zárolási szekciója a [GroupShapeLock](https://reference.aspose.com/slides/hu/net/aspose.slides/groupshape/groupshapelock/) révén érhető el, amely lehetővé teszi a műveletek korlátozását az objektumon.