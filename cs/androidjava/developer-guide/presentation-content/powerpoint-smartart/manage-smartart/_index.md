---
title: Správa SmartArt v prezentacích PowerPoint na Androidu
linktitle: Spravovat SmartArt
type: docs
weight: 10
url: /cs/androidjava/manage-smartart/
keywords:
- SmartArt
- Text SmartArt
- typ rozvržení
- skrytá vlastnost
- organizační diagram
- obrázkový organizační diagram
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se vytvářet a upravovat SmartArt v PowerPointu pomocí Aspose.Slides pro Android s využitím přehledných ukázek Java kódu, které urychlují návrh snímků a automatizaci."
---
## **Přehled**

SmartArt je diagram PowerPointu vytvořený z uzlů, tvarů uzlů a rozvržení. S Aspose.Slides for Android via Java můžete vytvářet SmartArt, číst text z jeho uzlů, měnit jeho rozvržení, prohlížet skryté uzly, konfigurovat rozvržení organizačních diagramů a vytvářet obrázkové organizační diagramy.

## **Získání textu ze SmartArt objektu**

SmartArt uzel může obsahovat jeden nebo více tvarů. Pro přečtení viditelného textu projděte [ISmartArt.getAllNodes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ismartart/#getAllNodes--) a poté přečtěte [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) vrácený metodou [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

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

## **Změna typu rozvržení SmartArt objektu**

Rozvržení SmartArt určuje, jak jsou uzly uspořádány a propojeny. Následující příklad vytvoří SmartArt objekt s hodnotou [SmartArtLayoutType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`, změní jej na hodnotu `BasicProcess` a uloží prezentaci.

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

## **Kontrola, zda je SmartArt uzel skrytý**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ismartartnode/#isHidden--) udává, zda je uzel skrytý v datovém modelu SmartArt. Skryté uzly mohou existovat ve struktuře, i když vybrané rozvržení nezobrazí jako viditelné diagramové prvky.

Následující příklad přidá uzel k SmartArt objektu, který používá hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtLayoutType) `RadialCycle`, a zkontroluje stav skrytí uzlu.

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

## **Získání nebo nastavení rozvržení organizačního diagramu**

Pro SmartArt diagramy, které používají rozvržení organizačního diagramu, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) a [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) určují, jak jsou podřazené uzly uspořádány pod nadřazeným uzlem. Například můžete nastavit podřazené uzly, aby visely vlevo, vpravo nebo na obou stranách, podle vybraného [OrganizationChartLayoutType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/OrganizationChartLayoutType).

Následující příklad vytvoří organizační diagram a nastaví rozvržení pro první uzel na hodnotu [OrganizationChartLayoutType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

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

## **Vytvoření obrázkového organizačního diagramu**

Obrázkový organizační diagram je rozvržení SmartArt určené pro hierarchické diagramy zahrnující zástupce obrázků. Při přidávání SmartArt objektu na snímek použijte hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart`.

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

**Podporuje SmartArt zrcadlení nebo obrácení pro jazyky RTL?**

Ano. Metoda [ISmartArt.setReversed](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) přepíná směr diagramu z zleva doprava na zprava doleva nebo zpět, pokud vybrané rozvržení SmartArt podporuje obrácení.

**Jak mohu zkopírovat SmartArt na ten samý snímek nebo do jiné prezentace a zachovat formátování?**

Můžete [klonovat tvar SmartArt](/slides/cs/androidjava/shape-manipulations/) metodou [ShapeCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) nebo [klonovat celý snímek](/slides/cs/androidjava/clone-slides/) obsahující SmartArt. Oba přístupy zachovají velikost, pozici i formátování.

**Jak vyrenderovat SmartArt do rastrového obrázku pro náhled nebo export na web?**

[Renderujte snímek](/slides/cs/androidjava/convert-powerpoint-to-png/) nebo celou prezentaci do PNG nebo JPEG. SmartArt je renderován jako součást snímku.

**Jak najít konkrétní SmartArt objekt na snímku, pokud jich je několik?**

Nastavte jedinečný atribut [Shape.getAlternativeText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getAlternativeText--) nebo [Shape.getName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getName--) na tvar SmartArt, vyhledejte tuto hodnotu v [BaseSlide.getShapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseslide/#getShapes--), a poté ověřte, že nalezený tvar je [ISmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ismartart/).