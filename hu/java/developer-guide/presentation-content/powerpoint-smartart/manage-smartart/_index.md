---
title: SmartArt kezelése PowerPoint prezentációkban Java használatával
linktitle: SmartArt kezelése
type: docs
weight: 10
url: /hu/java/manage-smartart/
keywords:
- SmartArt
- SmartArt szöveg
- elrendezéstípus
- rejtett tulajdonság
- szervezeti diagram
- kép szervezeti diagram
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan hozhat létre és szerkeszthet PowerPoint SmartArt-ot az Aspose.Slides for Java segítségével, világos kódmintákkal, amelyek felgyorsítják a diatervezést és az automatizálást."
---
## **Áttekintés**

A SmartArt egy PowerPoint diagram, amely csomópontokból, csomópont alakzatokból és egy elrendezésből áll. Az Aspose.Slides for Java-val létrehozhat SmartArt-ot, beolvashatja a csomópontok szövegét, módosíthatja az elrendezést, ellenőrizheti a rejtett csomópontokat, konfigurálhatja a szervezeti diagram elrendezéseket, és létrehozhat kép szervezeti diagramokat.

## **Szöveg lekérése egy SmartArt objektumból**

Egy SmartArt csomópont egy vagy több alakzatot tartalmazhat. A látható szöveg beolvasásához iteráljon a [ISmartArt.getAllNodes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ismartart/#getAllNodes--) elemein, majd olvassa el a [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ismartartshape/#getTextFrame--) által visszaadott [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/).

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

## **A SmartArt objektum elrendezéstípusának módosítása**

A SmartArt elrendezés szabályozza, hogyan vannak elrendezve és összekapcsolva a csomópontok. A következő példa egy SmartArt objektumot hoz létre a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtLayoutType) `BasicBlockList` értékkel, majd módosítja azt a `BasicProcess` értékre, és elmenti a prezentációt.

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

Az [ISmartArtNode.isHidden](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ismartartnode/#isHidden--) azt jelzi, hogy a csomópont rejtett-e a SmartArt adatmodellben. A rejtett csomópontok létezhetnek a struktúrában még akkor is, ha a kiválasztott elrendezés nem jeleníti meg őket látható diagramelemként.

A következő példa egy csomópontot ad egy SmartArt objektumhoz, amely a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtLayoutType) `RadialCycle` értéket használja, és ellenőrzi a csomópont rejtett állapotát.

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

## **A szervezeti diagram elrendezésének lekérése vagy beállítása**

Azoknál a SmartArt diagramoknál, amelyek szervezeti diagram elrendezést használnak, az [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) és az [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) meghatározzák, hogyan rendeződnek el a gyermekcsomópontok egy szülőcsomópont alatt. Például beállíthatja, hogy a gyermekcsomópontok balról, jobbról vagy mindkét oldalról függjenek, a kiválasztott [OrganizationChartLayoutType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/OrganizationChartLayoutType) függvényében.

A következő példa egy szervezeti diagramot hoz létre, és az első csomópont elrendezését a [OrganizationChartLayoutType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging` értékre állítja.

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

## **Kép szervezeti diagram létrehozása**

A kép szervezeti diagram egy SmartArt elrendezés, amely hierarchiai diagramokhoz készült, és képhelyeket tartalmaz. Használja a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` értéket a SmartArt objektum diára való hozzáadásakor.

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

## **GYIK**

**Támogatja a SmartArt a tükörképezést vagy a fordítást jobbról balra (RTL) nyelvek esetén?**

Igen. Az [ISmartArt.setReversed](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ismartart/#setReversed-boolean-) metódus a diagram irányát balról jobbra helyett jobbról balra (vagy vissza) állítja, ha a kiválasztott SmartArt elrendezés támogatja a fordítást.

**Hogyan másolhatom át a SmartArt-ot ugyanarra a diára vagy egy másik prezentációba a formázás megtartásával?**

A [SmartArt alakzat klónozásával](/slides/hu/java/shape-manipulations/) a [ShapeCollection.addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) vagy a SmartArt-ot tartalmazó teljes dia [klónozásával](/slides/hu/java/clone-slides/) másolhatja. Mindkét módszer megőrzi a méretet, a pozíciót és a formázást.

**Hogyan renderelhetem a SmartArt-ot raszteres képre előnézet vagy webes export céljából?**

A [dia renderelése](/slides/hu/java/convert-powerpoint-to-png/) vagy a teljes prezentáció PNG vagy JPEG formátumba. A SmartArt a dia részeként kerül renderelésre.

**Hogyan találhatok meg egy adott SmartArt objektumot egy dián, ha több is van?**

Állítson be egy megkülönböztető [Shape.getAlternativeText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getAlternativeText--) vagy [Shape.getName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getName--) értéket a SmartArt alakzaton, keresse meg ezt az értéket a [BaseSlide.getShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseslide/#getShapes--) segítségével, majd ellenőrizze, hogy a megtalált alakzat egy [ISmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ismartart/).