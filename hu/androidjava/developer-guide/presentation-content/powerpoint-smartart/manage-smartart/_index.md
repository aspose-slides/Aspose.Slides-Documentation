---
title: SmartArt kezelése PowerPoint prezentációkban Androidon
linktitle: SmartArt kezelése
type: docs
weight: 10
url: /hu/androidjava/manage-smartart/
keywords:
- SmartArt
- SmartArt szöveg
- elrendezés típusa
- rejtett tulajdonság
- szervezeti diagram
- képes szervezeti diagram
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Tanulja meg PowerPoint SmartArt építését és szerkesztését az Aspose.Slides for Android segítségével, világos Java kódfelvételekkel, amelyek felgyorsítják a diatervezést és az automatizálást."
---
## **Áttekintés**

A SmartArt egy PowerPoint-diagram, amely csomópontokból, csomópont alakzatokból és egy elrendezésből áll. Az Aspose.Slides for Android via Java segítségével létrehozhat SmartArt-ot, kiolvashatja a szöveget a csomópontjaiból, megváltoztathatja az elrendezését, ellenőrizheti a rejtett csomópontokat, konfigurálhatja a szervezeti diagram elrendezéseket, és képes képes szervezeti diagramokat létrehozni.

## **Szöveg lekérése egy SmartArt objektumból**

Egy SmartArt csomópont egy vagy több alakzatot tartalmazhat. A látható szöveg beolvasásához iteráljon a [ISmartArt.getAllNodes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ismartart/#getAllNodes--) végig, majd olvassa el a [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) által visszaadott [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **SmartArt objektum elrendezéstípusának módosítása**

A SmartArt elrendezés szabályozza, hogyan vannak a csomópontok elrendezve és összekapcsolva. Az alábbi példa létrehoz egy SmartArt objektumot a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtLayoutType) `BasicBlockList` értékkel, átállítja a `BasicProcess` értékre, és elmenti a bemutatót.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ellenőrizze, hogy egy SmartArt csomópont rejtett-e**

Az [ISmartArtNode.isHidden](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ismartartnode/#isHidden--) azt jelzi, hogy a csomópont rejtett-e a SmartArt adatmodellben. A rejtett csomópontok létezhetnek a struktúrában akkor is, ha a kiválasztott elrendezés nem jeleníti meg őket látható diagramelemként.

Az alábbi példa egy csomópontot ad egy SmartArt objektumhoz, amely a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtLayoutType) `RadialCycle` értéket használja, és ellenőrzi a csomópont rejtett állapotát.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A szervezeti diagram elrendezésének lekérdezése vagy beállítása**

Azoknál a SmartArt diagramoknál, amelyek szervezeti diagram elrendezést használnak, az [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) és az [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) határozzák meg, hogyan vannak elrendezve a gyermekcsomópontok egy szülőcsomópont alatt. Például beállíthatja a gyermekcsomópontokat, hogy balról, jobbról vagy mindkét oldalról függően függjenek, a kiválasztott [OrganizationChartLayoutType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/OrganizationChartLayoutType) alapján.

Az alábbi példa egy szervezeti diagramot hoz létre, és az első csomópont elrendezését a [OrganizationChartLayoutType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging` értékre állítja be.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Képes szervezeti diagram létrehozása**

A képes szervezeti diagram egy SmartArt elrendezés, amely hierarchia diagramokhoz készült, és képtartóhelyeket tartalmaz. Használja a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` értéket, amikor a SmartArt objektumot a diára adja.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**A SmartArt támogatja a tükrözést vagy a fordítást jobb‑bal (RTL) nyelvek esetén?**

Igen. Az [ISmartArt.setReversed](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) metódus átváltja a diagram irányát balról jobbra → jobbról balra, vagy vissza, ha a kiválasztott SmartArt elrendezés támogatja a fordítást.

**Hogyan másolhatom a SmartArt-ot ugyanarra a diára vagy egy másik prezentációba, miközben megőrzöm a formázást?**

Klónozhatja a SmartArt alakzatát a [clone the SmartArt shape](/slides/hu/androidjava/shape-manipulations/) segítségével a [ShapeCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) metódussal, vagy klónozhatja az egész diát a [clone the whole slide](/slides/hu/androidjava/clone-slides/) linkkel, amely tartalmazza a SmartArt-ot. Mindkét megközelítés megőrzi a méretet, pozíciót és a formázást.

**Hogyan renderelhetem a SmartArt-ot raszteres képre előnézethez vagy webes exporthoz?**

Renderelje a diát a [Render the slide](/slides/hu/androidjava/convert-powerpoint-to-png/) vagy az egész bemutatót PNG vagy JPEG formátumba. A SmartArt a dia részeként kerül renderelésre.

**Hogyan találhatok egy adott SmartArt objektumot a dián, ha több is van?**

Állítson be egy egyedi [Shape.getAlternativeText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getAlternativeText--) vagy [Shape.getName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getName--) értéket a SmartArt alakzatra, keresse meg ezt az értéket a [BaseSlide.getShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseslide/#getShapes--) segítségével, majd ellenőrizze, hogy a megtalált alakzat egy [ISmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ismartart/) legyen.