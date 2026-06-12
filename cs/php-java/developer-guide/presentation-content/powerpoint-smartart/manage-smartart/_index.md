---
title: Správa SmartArt v prezentacích PowerPoint pomocí PHP
linktitle: Správa SmartArt
type: docs
weight: 10
url: /cs/php-java/manage-smartart/
keywords:
- SmartArt
- text SmartArt
- typ rozvržení
- skrytá vlastnost
- organizační diagram
- obrázkový organizační diagram
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se vytvářet a upravovat PowerPoint SmartArt pomocí Aspose.Slides pro PHP přes Java s jasnými ukázkovými kódy, které urychlí návrh snímků a automatizaci."
---
## **Přehled**

SmartArt je diagram PowerPointu složený z uzlů, tvarů uzlů a rozvržení. S Aspose.Slides pro PHP přes Java můžete vytvářet SmartArt, číst text z jeho uzlů, měnit jeho rozvržení, kontrolovat skryté uzly, konfigurovat rozvržení organizačních diagramů a vytvářet obrázkové organizační diagramy.

## **Získání textu ze SmartArt objektu**

Uzlu SmartArt může obsahovat jeden nebo více tvarů. Pro načtení viditelného textu iterujte přes [SmartArt::getAllNodes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/#getAllNodes), poté přečtěte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) vrácený metodou [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartartshape/#getTextFrame).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Změna typu rozvržení SmartArt objektu**

Rozvržení SmartArt určuje, jak jsou uzly uspořádány a propojeny. Následující příklad vytváří SmartArt objekt s hodnotou [SmartArtLayoutType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, mění jej na hodnotu `BasicProcess` a ukládá prezentaci.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kontrola, zda je uzel SmartArt skrytý**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartartnode/ishidden/) ukazuje, zda je uzel skrytý v datovém modelu SmartArt. Skryté uzly mohou existovat ve struktuře, i když vybrané rozvržení nezobrazuje je jako viditelné diagramové prvky.

Následující příklad přidá uzel do SmartArt objektu, který používá hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartartlayouttype/) `RadialCycle`, a kontroluje stav skrytí uzlu.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Získání nebo nastavení rozvržení organizačního diagramu**

Pro diagramy SmartArt, které používají rozvržení organizačního diagramu, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) a [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) určují, jak jsou podřízené uzly uspořádány pod nadřazeným uzlem. Například můžete nastavit podřízené uzly, aby visely zleva, zprava nebo z obou stran, v závislosti na vybraném [OrganizationChartLayoutType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/organizationchartlayouttype/).

Následující příklad vytvoří organizační diagram a nastaví rozvržení pro první uzel na hodnotu [OrganizationChartLayoutType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Vytvoření obrázkového organizačního diagramu**

Obrázkový organizační diagram je rozvržení SmartArt určené pro hierarchické diagramy, které obsahují zástupce obrázků. Použijte hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` při přidávání SmartArt objektu na snímek.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Podporuje SmartArt zrcadlení nebo obracení pro RTL jazyky?**

Ano. Metoda [SmartArt::setReversed](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/setreversed/) přepíná směr diagramu z left-to-right na right-to-left nebo zpět, pokud vybrané rozvržení SmartArt podporuje obrácení.

**Jak mohu zkopírovat SmartArt na stejný snímek nebo do jiné prezentace při zachování formátování?**

Můžete [klonovat tvar SmartArt](/slides/cs/php-java/shape-manipulations/) pomocí [ShapeCollection::addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addclone/) nebo [klonovat celý snímek](/slides/cs/php-java/clone-slides/) který SmartArt obsahuje. Oba přístupy zachovávají velikost, umístění a formátování.

**Jak vykreslím SmartArt do rastrového obrázku pro náhled nebo webový export?**

[Vykreslete snímek](/slides/cs/php-java/convert-powerpoint-to-png/) nebo celou prezentaci do PNG nebo JPEG. SmartArt je vykreslen jako součást snímku.

**Jak mohu najít konkrétní SmartArt objekt na snímku, pokud jich je několik?**

Nastavte jedinečnou hodnotu [Shape::getAlternativeText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getalternativetext/) nebo [Shape::getName](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getname/) na tvar SmartArt, vyhledejte tuto hodnotu v [BaseSlide::getShapes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/#getShapes), a poté ověřte, že odpovídající tvar je [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/).