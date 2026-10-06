---
title: Správa SmartArt v prezentacích PowerPoint na Androidu
linktitle: Správa SmartArt
type: docs
weight: 10
url: /cs/androidjava/manage-smartart/
keywords:
- SmartArt
- text SmartArt
- typ rozvržení
- skrytá vlastnost
- organizační schéma
- obrázkové organizační schéma
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se vytvářet a upravovat PowerPoint SmartArt pomocí Aspose.Slides pro Android s přehlednými ukázkami Java kódu, které urychlují design a automatizaci snímků."
---
## **Přehled**

SmartArt je diagram PowerPointu vytvořený z uzlů, tvarů uzlů a rozvržení. S Aspose.Slides pro Android pomocí Java můžete vytvářet SmartArt, číst text z jeho uzlů, měnit jeho rozvržení, prohlížet skryté uzly, konfigurovat rozvržení organizačních schémat a vytvářet obrázkové organizační schémata.

## **Získání textu ze SmartArt objektu**

Uzel SmartArt může obsahovat jeden nebo více tvarů. Pro čtení textu z tvarů uzlu iterujte přes [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--), poté si přečtěte [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) vrácený metodou [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

Příklad vyžaduje prezentaci alespoň s jedním snímkem a objekt SmartArt jako první tvar na tomto snímku. Vypíše každý dostupný textový rámec do konzole.

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

Rozvržení SmartArt určuje, jak jsou uzly uspořádány a propojeny. Následující příklad vytvoří objekt SmartArt s hodnotou [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `BasicBlockList`, změní jej na hodnotu `BasicProcess` a uloží prezentaci. Pozice a velikost předávané metodě [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) jsou měřeny v bodech. K změně rozvržení použijte [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-).

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

## **Kontrola, zda je uzel SmartArt skrytý**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) udává, zda je uzel ve SmartArt datovém modelu skrytý. Skryté uzly mohou existovat ve struktuře, i když vybrané rozvržení je nezobrazuje jako viditelné diagramové prvky.

Následující příklad přidá uzel do objektu SmartArt, který používá hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `RadialCycle`, a zkontroluje stav skrytí přidaného uzlu. Vypíše zprávu, pokud je uzel skrytý, a uloží diagram.

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

U diagramů SmartArt, které používají rozvržení organizačního diagramu, definují [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) a [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) způsob uspořádání podřízených uzlů pod nadřazeným uzlem. Například můžete nastavit podřízené uzly, aby visely vlevo, vpravo nebo na obou stranách, podle vybraného [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/).

Následující příklad vytvoří organizační diagram a nastaví rozvržení pro první uzel na hodnotu [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) `LeftHanging`. Index založený na nule `0` vybírá první uzel nejvyšší úrovně; jeho podřízené uzly použijí vybrané uspořádání. Upravená prezentace je pak uložena.

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

Obrázkový organizační diagram je rozvržení SmartArt určené pro hierarchické diagramy, které obsahují zástupné obrázky. Při přidávání objektu SmartArt na snímek použijte hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart`. Tento příklad uloží diagram se zástupnými obrázky; nezaplní zástupce obrázky.

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

Při modernizaci existující prezentace můžete potřebovat aktualizovat organizační diagram původně vytvořený v PowerPoint 97–2003. Aspose.Slides představuje tyto staré diagramy jako objekty [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/). K převodu diagramu na skupinu tvarů použijte [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--), abyste mohli upravovat jednotlivé vizuální prvky. Podrobnosti najdete v [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/).

Převod přidá novou skupinu do kolekce tvarů, aniž by odstranil původní diagram. Po úspěšném převodu odstraňte originál pomocí [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) a zabráníte duplicitnímu obsahu. Před konverzí shromážděte staré diagramy do seznamu, aby přidávání a odstraňování tvarů neporušovalo iteraci.

Následující příklad otevře prezentaci, prohledá všechny snímky, převádí diagramy na skupiny tvarů a uloží aktualizovanou prezentaci jako PPTX.

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

Uložená prezentace obsahuje editovatelné skupiny tvarů místo převedených starých diagramů, přičemž žádné původní diagramy nezůstávají. Otevřete PPTX v PowerPointu a upravujte jednotlivé prvky v každé skupině, například jejich text, výplň nebo pozici.

## **Často kladené otázky**

**Podporuje SmartArt zrcadlení nebo obrácení pro jazyky RTL?**

Ano. Metoda [ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) přepíná směr diagramu z levého na pravý a zpět, pokud vybrané rozvržení SmartArt podporuje obrácení.

**Jak mohu zkopírovat SmartArt na stejný snímek nebo do jiné prezentace při zachování formátování?**

Můžete [klonovat tvar SmartArt](/slides/cs/androidjava/shape-manipulations/) pomocí [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) nebo [klonovat celý snímek](/slides/cs/androidjava/clone-slides/) obsahující SmartArt. Oba přístupy zachovají velikost, pozici i formátování.

**Jak mohu vykreslit SmartArt do rastrového obrazu pro náhled nebo export na web?**

[Renderovat snímek](/slides/cs/androidjava/convert-powerpoint-to-png/) nebo celou prezentaci do PNG nebo JPEG. SmartArt je vykreslen jako součást snímku.

**Jak mohu najít konkrétní objekt SmartArt na snímku, pokud jich je několik?**

Použijte [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) nebo [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) k přiřazení význačného alternativního textu či názvu tvaru SmartArt, vyhledejte tuto hodnotu v [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--), a poté ověřte, že odpovídající tvar je [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/).