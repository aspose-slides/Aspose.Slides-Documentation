---
title: Správa SmartArt v PowerPoint prezentacích pomocí Javy
linktitle: Správa SmartArt
type: docs
weight: 10
url: /cs/java/manage-smartart/
keywords:
- SmartArt
- Text SmartArt
- typ rozvržení
- skrytá vlastnost
- organizační diagram
- obrázkový organizační diagram
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se vytvářet a upravovat SmartArt v PowerPointu pomocí Aspose.Slides pro Javu srozumitelnými ukázkami kódu, které urychlí návrh snímků a automatizaci."
---
## **Přehled**

SmartArt je diagram PowerPointu složený z uzlů, tvarů uzlů a rozvržení. S Aspose.Slides pro Java můžete vytvářet SmartArt, číst text z jeho uzlů, měnit jeho rozvržení, zkoumat skryté uzly, konfigurovat rozvržení organizačních diagramů a vytvářet obrázkové organizační diagramy.

## **Získání textu z objektu SmartArt**

Uzel SmartArt může obsahovat jeden nebo více tvarů. Chcete‑li číst text ze tvarů uzlu, iterujte přes [ISmartArt.getAllNodes](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#getAllNodes--), poté přečtěte [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) vrácený metodou [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartshape/#getTextFrame--).

Příklad vyžaduje prezentaci s alespoň jedním snímkem a objektem SmartArt jako prvním tvarem na tomto snímku. Vypíše každé dostupné textové políčko do konzole.

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

## **Změna typu rozvržení objektu SmartArt**

Rozvržení SmartArt řídí, jak jsou uzly uspořádány a propojeny. Následující příklad vytváří objekt SmartArt s hodnotou [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `BasicBlockList`, změní ji na hodnotu `BasicProcess` a uloží prezentaci. Pozice a velikost předávaná metodě [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) jsou měřeny v bodech. Pro změnu rozvržení použijte [ISmartArt.setLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setLayout-int-).

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

## **Zjištění, zda je uzel SmartArt skrytý**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) udává, zda je uzel skrytý v datovém modelu SmartArt. Skryté uzly mohou v struktuře existovat, i když vybrané rozvržení nezobrazuje je jako viditelné diagramové prvky.

Následující příklad přidá uzel do objektu SmartArt, který používá hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `RadialCycle`, a zkontroluje stav skrytí přidaného uzlu. Vypíše zprávu, pokud je uzel skrytý, a uloží diagram.

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

## **Získání nebo nastavení rozvržení organizačního diagramu**

U diagramů SmartArt, které používají rozvržení organizačního diagramu, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) a [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) určují, jak jsou podřízené uzly uspořádány pod nadřazeným uzlem. Například můžete nastavit podřízené uzly, aby visely vlevo, vpravo nebo na obou stranách, v závislosti na vybraném [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/).

Následující příklad vytvoří organizační diagram a nastaví rozvržení pro první uzel na hodnotu [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) `LeftHanging`. Index začínající od nuly `0` vybírá první uzel nejvyšší úrovně; jeho podřízené uzly používají vybrané uspořádání. Upravená prezentace je následně uložena.

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

## **Vytvoření obrázkového organizačního diagramu**

Obrázkový organizační diagram je rozvržení SmartArt určené pro hierarchické diagramy, které obsahují zástupné obrázky. Použijte hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` při přidávání objektu SmartArt na snímek. Tento příklad uloží diagram se zástupnými obrázky; nezaplní však zástupné obrázky skutečnými obrázky.

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

## **Převod starých diagramů na skupiny tvarů**

Při modernizaci existující prezentace můžete potřebovat aktualizovat organizační diagram původně vytvořený v PowerPointu 97–2003. Aspose.Slides představuje tyto staré diagramy jako objekty [ILegacyDiagram](https://reference.aspose.com/slides/java/com.aspose.slides/ilegacydiagram/). Použijte [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/#convertToGroupShape--) k převodu diagramu na skupinu tvarů, abyste mohli upravovat jednotlivé vizuální prvky. Podrobnosti najdete v [LegacyDiagram API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/).

Převod přidá novou skupinu do kolekce tvarů, aniž by odstranil původní diagram. Po úspěšném převodu odstraňte originál metodou [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) , abyste se vyhnuli duplicitnímu obsahu. Shromážděte staré diagramy do seznamu před jejich převodem, aby přidávání a odstraňování tvarů neporušilo iteraci.

Následující příklad otevře prezentaci, prohledá všechny snímky, převede diagramy na skupiny tvarů a uloží aktualizovanou prezentaci jako PPTX.

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

Uložená prezentace obsahuje editovatelné skupiny tvarů místo převedených starých diagramů, přičemž žádné původní diagramy nezůstávají. Otevřete PPTX v PowerPointu a upravte jednotlivé prvky v každé skupině, například jejich text, výplň nebo pozici.

## **Často kladené otázky**

**Podporuje SmartArt zrcadlení nebo obrácení pro RTL jazyky?**

Ano. Metoda [ISmartArt.setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setReversed-boolean-) mění směr diagramu z zleva‑doprava na zprava‑doleva, nebo zpět, pokud vybrané rozvržení SmartArt podporuje obrácení.

**Jak mohu zkopírovat SmartArt na stejný snímek nebo do jiné prezentace při zachování formátování?**

Můžete [klonovat tvar SmartArt](/slides/cs/java/shape-manipulations/) pomocí [ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) nebo [klonovat celý snímek](/slides/cs/java/clone-slides/) obsahující SmartArt. Oba přístupy zachovají velikost, pozici a formátování.

**Jak mohu vykreslit SmartArt do rastrového obrázku pro náhled nebo export na web?**

[Vykreslete snímek](/slides/cs/java/convert-powerpoint-to-png/) nebo celou prezentaci do PNG nebo JPEG. SmartArt je vykreslen jako součást snímku.

**Jak mohu najít konkrétní objekt SmartArt na snímku, pokud jich je několik?**

Použijte [Shape.setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) nebo [Shape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setName-java.lang.String-) k přiřazení jedinečného alternativního textu nebo názvu tvaru SmartArt, vyhledejte tuto hodnotu v [BaseSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) a poté ověřte, že odpovídající tvar je [ISmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/).