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
- szervezeti ábra
- képes szervezeti ábra
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan építsen és szerkesszen PowerPoint SmartArt-ot az Aspose.Slides for Android segítségével, világos Java kódrészletekkel, amelyek felgyorsítják a dia tervezését és az automatizálást."
---
## **Áttekintés**

A SmartArt egy PowerPoint-diagram, amely csomópontokból, csomópont alakzatokból és egy elrendezésből áll. Az Aspose.Slides for Android via Java‑val létrehozhat SmartArt‑ot, beolvashat szöveget a csomópontjaiból, módosíthatja az elrendezését, ellenőrizheti a rejtett csomópontokat, konfigurálhatja a szervezeti ábra elrendezéseket, és létrehozhat képes szervezeti ábrákat.

## **Szöveg lekérése egy SmartArt objektumból**

Egy SmartArt csomópont egy vagy több alakzatot tartalmazhat. A csomópont alakzatok szövegének beolvasásához iteráljon a [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--) listán, majd olvassa el az [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) objektumot, amelyet az [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) visszaad.

A példához egy prezentációra van szükség, amely legalább egy diát és a dián az első alakzatként elhelyezett SmartArt objektumot tartalmaz. Kiírja az elérhető szövegkereteket a konzolra.

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

## **Az SmartArt objektum elrendezéstípusának módosítása**

A SmartArt elrendezése határozza meg, hogyan vannak a csomópontok elrendezve és összekapcsolva. A következő példa egy SmartArt objektumot hoz létre a [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `BasicBlockList` értékkel, átállítja `BasicProcess` értékre, és elmenti a prezentációt. A [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-)‑ba átadott pozíciót és méretet pontban mérik. Használja az [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-) metódust az elrendezés módosításához.

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

## **Ellenőrzés, hogy a SmartArt csomópont rejtett-e**

Az [ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) azt jelzi, hogy a csomópont rejtett-e a SmartArt adatmodellben. A rejtett csomópontok létezhetnek a struktúrában akkor is, ha a kiválasztott elrendezés nem jeleníti meg őket látható diagramelemként.

A következő példa egy csomópontot ad egy SmartArt objektumhoz, amely a [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `RadialCycle` értéket használja, és ellenőrzi a hozzáadott csomópont rejtett állapotát. Ha a csomópont rejtett, üzenetet ír ki, majd elmenti a diagramot.

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

## **A szervezeti ábra elrendezés lekérése vagy beállítása**

Azoknál a SmartArt diagramoknál, amelyek szervezeti ábra elrendezést használnak, az [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) és az [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) határozzák meg, hogyan rendeződnek a gyermekcsomópontok egy szülőcsomópont alatt. Például a gyermekcsomópontokat a balra, jobbra vagy mindkét oldalra függesztheti, a kiválasztott [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) attól függően.

A következő példa létrehoz egy szervezeti ábrát, és az első csomópont elrendezését a [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) `LeftHanging` értékre állítja. A nulláról kezdődő index `0` az első felső szintű csomópontot választja; annak gyermekcsomópontjai a kiválasztott elrendezést használják. Ezután a módosított prezentációt elmenti.

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

## **Képes szervezeti ábra létrehozása**

A képes szervezeti ábra egy SmartArt elrendezés, amely hierarchiai diagramokhoz készült, és képhelyeket tartalmaz. A [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` értéket kell használni a SmartArt objektum diára való hozzáadásakor. Ez a példa egy diagramot ment képhelyekkel; a helyfoglalókat nem tölti ki képekkel.

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

## **Örökölt diagramok átalakítása alakzatcsoportokká**

Egy meglévő prezentáció modernizálásakor előfordulhat, hogy frissíteni kell egy 1997–2003-as PowerPoint‑ban létrehozott szervezeti ábrát. Az Aspose.Slides ezeket az örökölt diagramokat [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/) objektumokként reprezentálja. Használja a [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--) metódust a diagram alakzatcsoportba alakításához, hogy egyedi vizuális elemeket szerkeszthessen. A részletekért tekintse meg a [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/) dokumentációt.

A konverzió egy új csoportot ad az alakzatgyűjteményhez az eredeti diagram eltávolítása nélkül. A sikeres konverzió után távolítsa el az eredetit az [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) segítségével, hogy elkerülje a duplikált tartalmat. Konvertálás előtt gyűjtse össze az örökölt diagramokat egy listába, hogy a alakzatok hozzáadása és eltávolítása ne szakítsa meg az iterációt.

A következő példa megnyit egy prezentációt, minden diát átvizsgál, a diagramokat alakzatcsoportokká konvertálja, és az frissített prezentációt PPTX‑ként elmenti.

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

Az elmentett prezentáció szerkeszthető alakzatcsoportokat tartalmaz a konvertált örökölt diagramok helyén, az eredeti diagramok már nem szerepelnek. Nyissa meg a PPTX‑et a PowerPointban, hogy szerkessze a csoportok egyes elemeit, például a szöveget, kitöltést vagy pozíciót.

## **GYIK**

**Támogatja a SmartArt a tükrözést vagy fordítást jobbról balra nyelvek esetén?**

Igen. Az [ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) metódus átváltja a diagram irányát balról jobbra és jobbról balra, vagy vissza, ha a kiválasztott SmartArt elrendezés támogatja a fordítást.

**Hogyan másolhatom a SmartArt-ot ugyanarra a diára vagy egy másik prezentációba a formázás megőrzése mellett?**

A [SmartArt alakzat klónozásával](/slides/hu/androidjava/shape-manipulations/) a [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) vagy a SmartArt‑ot tartalmazó teljes dia [klónozásával](/slides/hu/androidjava/clone-slides/) másolhatja. Mindkét módszer megőrzi a méretet, pozíciót és a formázást.

**Hogyan renderelhetem a SmartArt-ot raszteres képpé előnézethez vagy webes exporthoz?**

[Renderelje a diát](/slides/hu/androidjava/convert-powerpoint-to-png/) vagy a teljes prezentációt PNG‑re vagy JPEG‑re. A SmartArt a dia részeként kerül renderelésre.

**Hogyan találhatok meg egy konkrét SmartArt objektumot egy dián, ha több is van?**

Használja a [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) vagy a [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) metódust, hogy egyedi alternatív szöveget vagy nevet rendeljön a SmartArt alakzathoz, keresse meg ezt az értéket a [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--)‑ben, majd ellenőrizze, hogy a megtalált alakzat egy [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/).