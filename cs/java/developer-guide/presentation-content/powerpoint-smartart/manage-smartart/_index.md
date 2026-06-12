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
description: "Naučte se vytvářet a upravovat PowerPoint SmartArt pomocí Aspose.Slides pro Javu s jasnými ukázkami kódu, které urychlují návrh snímků a automatizaci."
---
## **Přehled**

SmartArt je diagram PowerPointu vytvořený z uzlů, tvarů uzlů a rozvržení. S knihovnou Aspose.Slides pro Java můžete vytvářet SmartArt, číst text z jeho uzlů, měnit jeho rozvržení, kontrolovat skryté uzly, konfigurovat rozvržení organizačních diagramů a vytvářet obrázkové organizační diagramy.

## **Získat text ze SmartArt objektu**

Uzel SmartArt může obsahovat jeden nebo více tvarů. Pro načtení viditelného textu iterujte přes [ISmartArt.getAllNodes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ismartart/#getAllNodes--), poté přečtěte [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) , který vrací [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ismartartshape/#getTextFrame--).

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

## **Změnit typ rozvržení SmartArt objektu**

Rozvržení SmartArt určuje, jak jsou uzly uspořádány a propojeny. Následující příklad vytvoří SmartArt objekt s hodnotou [SmartArtLayoutType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`, změní ji na hodnotu `BasicProcess` a uloží prezentaci.

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

## **Zkontrolovat, zda je uzel SmartArt skrytý**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ismartartnode/#isHidden--) udává, zda je uzel skrytý v datovém modelu SmartArt. Skryté uzly mohou ve struktuře existovat i když vybrané rozvržení nezobrazuje je jako viditelné diagramové prvky.

Následující příklad přidá uzel do SmartArt objektu, který používá hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArtLayoutType) `RadialCycle`, a zkontroluje stav skrytí uzlu.

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

## **Získat nebo nastavit rozvržení organizačního diagramu**

Pro diagramy SmartArt, které používají rozvržení organizačního diagramu, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) a [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) určují, jak jsou podřízené uzly uspořádány pod nadřazeným uzlem. Například můžete nastavit podřízené uzly, aby visely zleva, zprava nebo z obou stran, v závislosti na vybraném [OrganizationChartLayoutType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/OrganizationChartLayoutType).

Následující příklad vytvoří organizační diagram a nastaví rozvržení pro první uzel na hodnotu [OrganizationChartLayoutType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

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

## **Vytvořit obrázkový organizační diagram**

Obrázkový organizační diagram je rozvržení SmartArt určené pro hierarchické diagramy, které obsahují zástupné obrázky. Při přidávání objektu SmartArt na snímek použijte hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart`.

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

## **Často kladené otázky**

**Podporuje SmartArt zrcadlení nebo převrácení pro RTL jazyky?**

Ano. Metoda [ISmartArt.setReversed](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ismartart/#setReversed-boolean-) přepíná směr diagramu z levého na pravý na pravý na levý, nebo zpět, pokud vybrané rozvržení SmartArt podporuje převrácení.

**Jak mohu zkopírovat SmartArt na stejný snímek nebo do jiné prezentace při zachování formátování?**

Můžete [klonovat tvar SmartArt](/slides/cs/java/shape-manipulations/) pomocí [ShapeCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) nebo [klonovat celý snímek](/slides/cs/java/clone-slides/) , který SmartArt obsahuje. Oba přístupy zachovávají velikost, umístění a formátování.

**Jak mohu vykreslit SmartArt do rastrového obrázku pro náhled nebo webový export?**

[Vykreslete snímek](/slides/cs/java/convert-powerpoint-to-png/) nebo celou prezentaci do formátu PNG nebo JPEG. SmartArt je vykreslen jako součást snímku.

**Jak mohu najít konkrétní SmartArt objekt na snímku, pokud jich je několik?**

Nastavte jedinečnou hodnotu [Shape.getAlternativeText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getAlternativeText--) nebo [Shape.getName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getName--) na tvar SmartArt, vyhledejte tuto hodnotu v [BaseSlide.getShapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseslide/#getShapes--) , a poté zkontrolujte, že odpovídající tvar je [ISmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ismartart/).