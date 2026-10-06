---
title: SmartArt kezelése PowerPoint prezentációkban Java segítségével
linktitle: SmartArt kezelése
type: docs
weight: 10
url: /hu/java/manage-smartart/
keywords:
- SmartArt
- SmartArt szöveg
- elrendezés típusa
- rejtett tulajdonság
- szervezeti diagram
- képes szervezeti diagram
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet létrehozni és szerkeszteni PowerPoint SmartArt-ot az Aspose.Slides for Java segítségével, egyértelmű kódmintákkal, amelyek felgyorsítják a dia tervezését és az automatizálást."
---
## **Áttekintés**

A SmartArt egy PowerPoint diagram, amely csomópontokból, csomópont alakzatokból és elrendezésből áll. Az Aspose.Slides for Java-val létrehozhat SmartArt-ot, beolvashatja a szöveget a csomópontokból, módosíthatja az elrendezését, ellenőrizheti a rejtett csomópontokat, konfigurálhatja a szervezeti diagram elrendezéseket, és létrehozhat képes szervezeti diagramokat.

## **Szöveg lekérése SmartArt objektumból**

Egy SmartArt csomópont egy vagy több alakzatot tartalmazhat. A csomópont alakzatok szövegének beolvasásához iteráljon a [ISmartArt.getAllNodes](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#getAllNodes--) végén, majd olvassa el a [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) objektumot, amelyet a [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartshape/#getTextFrame--) visszaad.

A példához egy prezentációra van szükség, amely legalább egy diát és egy SmartArt objektumot tartalmaz első alakzatként azon a dián. Kiírja a konzolra az összes elérhető szövegkeretet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **A SmartArt objektum elrendezés típusának módosítása**

A SmartArt elrendezés szabályozza, hogyan helyezkednek el és kapcsolódnak a csomópontok. A következő példa egy SmartArt objektumot hoz létre a [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `BasicBlockList` értékkel, átváltja a `BasicProcess` értékre, és elmenti a prezentációt. A [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-)‑nek átadott pozíció és méret pontban van megadva. Az elrendezés módosításához használja az [ISmartArt.setLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setLayout-int-) metódust.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ellenőrizze, hogy egy SmartArt csomópont rejtett-e**

Az [ISmartArtNode.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) azt jelzi, hogy a csomópont rejtett-e a SmartArt adatmodellben. A rejtett csomópontok létezhetnek a struktúrában akkor is, ha a kiválasztott elrendezés nem jeleníti meg őket látható diagram elemekként.

A következő példa egy csomópontot ad egy SmartArt objektumhoz, amely a [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `RadialCycle` értéket használ, és ellenőrzi a hozzáadott csomópont rejtett állapotát. Ha a csomópont rejtett, üzenetet ír ki, és elmenti a diagramot.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A szervezeti diagram elrendezésének lekérdezése vagy beállítása**

A szervezeti diagram elrendezést használó SmartArt diagramok esetén az [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) és az [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) határozzák meg, hogy a gyermek csomópontok hogyan helyezkednek el egy szülőcsomópont alatt. Például a gyermek csomópontokat felállíthatja balról, jobbról vagy mindkét oldalról függően a kiválasztott [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) értéktől.

A következő példa létrehoz egy szervezeti diagramot, és az első csomópont elrendezését a [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) `LeftHanging` értékre állítja. A nullártól kezdődő index `0` az első felső szintű csomópontot választja; annak gyermek csomópontjai a kiválasztott elrendezést használják. Ezután a módosított prezentációt elmenti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Képes szervezeti diagram létrehozása**

A képes szervezeti diagram egy SmartArt elrendezés, amely hierarchikus diagramokhoz készült, és képre helyettesítőket tartalmaz. A [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` értéket használja, amikor a SmartArt objektumot egy diára helyezi. Ez a példa egy diagramot ment képlehelyekkel; a helyettesítőket nem tölti fel képekkel.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Régi diagramok átalakítása alakzatcsoportokká**

A meglévő prezentáció modernizálásakor előfordulhat, hogy frissíteni kell egy eredetileg PowerPoint 97–2003-ban létrehozott szervezeti diagramot. Az Aspose.Slides ezeket a régi diagramokat [ILegacyDiagram](https://reference.aspose.com/slides/java/com.aspose.slides/ilegacydiagram/) objektumokként reprezentálja. Használja a [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/#convertToGroupShape--) metódust, hogy a diagramot alakzatcsoporttá alakítsa, így egyedi vizuális elemeket szerkeszthet. A részletekért tekintse meg a [LegacyDiagram API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/) dokumentációt.

Az átalakítás új csoportot ad a alakzatgyűjteményhez az eredeti diagram eltávolítása nélkül. Sikeres átalakítás után távolítsa el az eredetit az [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) segítségével, hogy elkerülje a duplikált tartalmat. A régi diagramokat gyűjtse össze egy listába az átalakítás előtt, hogy az alakzatok hozzáadása és eltávolítása ne szakítsa meg az iterációt.

A következő példa megnyit egy prezentációt, minden diát átvizsgál, a diagramokat alakzatcsoportokká alakítja, és elmenti a frissített prezentációt PPTX formátumban.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az elmentett prezentáció szerkeszthető alakzatcsoportokat tartalmaz a konvertált régi diagramok helyett, az eredeti diagramok már nem maradtak bennük. Nyissa meg a PPTX-et a PowerPointban, hogy szerkessze az egyes csoportok elemeit, például a szöveget, kitöltést vagy pozíciót.

## **FAQ**

**Támogatja a SmartArt a tükrözést vagy a fordítást jobb‑bal (RTL) nyelvekhez?**

Igen. Az [ISmartArt.setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setReversed-boolean-) metódus a diagram irányát balról jobbra és jobbról balra (vagy vissza) váltja, ha a kiválasztott SmartArt elrendezés támogatja a fordítást.

**Hogyan másolhatom a SmartArt-ot ugyanarra a diára vagy egy másik prezentációba, miközben megőrzöm a formázást?**

A [SmartArt alakzat klónozásával](/slides/hu/java/shape-manipulations/) a [ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) vagy a SmartArt-ot tartalmazó teljes dia [klónozásával](/slides/hu/java/clone-slides/) tudja. Mindkét módszer megőrzi a méretet, a pozíciót és a formázást.

**Hogyan jeleníthetem meg a SmartArt-ot raszteres képként előnézethez vagy webes exporthoz?**

[A diát renderelheti](/slides/hu/java/convert-powerpoint-to-png/) vagy a teljes prezentációt PNG vagy JPEG formátumba. A SmartArt a dia részeként kerül renderelésre.

**Hogyan találhatok meg egy konkrét SmartArt objektumot egy dián, ha több is van?**

Használja a [Shape.setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) vagy a [Shape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setName-java.lang.String-) metódust, hogy egyedi alternatív szöveget vagy nevet rendeljék a SmartArt alakzathoz, keresse meg ezt az értéket a [BaseSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) között, majd ellenőrizze, hogy a megtalált alakzat egy [ISmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/).