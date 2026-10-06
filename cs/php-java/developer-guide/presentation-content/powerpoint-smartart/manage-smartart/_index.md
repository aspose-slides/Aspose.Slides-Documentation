---
title: Správa SmartArt v prezentacích PowerPoint pomocí PHP
linktitle: Správa SmartArt
type: docs
weight: 10
url: /cs/php-java/manage-smartart/
keywords:
- SmartArt
- text SmartArtu
- typ rozvržení
- skrytá vlastnost
- organizační diagram
- obrázkový organizační diagram
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se vytvářet a upravovat SmartArt v PowerPointu pomocí Aspose.Slides pro PHP přes Java s přehlednými ukázkami kódu, které urychlují návrh snímků a automatizaci."
---
## **Přehled**

SmartArt je diagram PowerPointu vytvořený z uzlů, tvarů uzlů a rozvržení. S Aspose.Slides pro PHP přes Java můžete vytvářet SmartArt, číst text z jeho uzlů, měnit rozvržení, prohlížet skryté uzly, konfigurovat rozvržení organizačních diagramů a vytvářet obrázkové organizační diagramy.

## **Získání textu z objektu SmartArt**

Uzel SmartArt může obsahovat jeden nebo více tvarů. Pro načtení textu z tvarů uzlu iterujte přes [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/), poté přečtěte [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) vrácený metodou [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/).

Příklad vyžaduje prezentaci s alespoň jedním snímkem a objektem SmartArt jako prvním tvarem na tomto snímku. Vypíše každý dostupný textový rámec do konzoly.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Změna typu rozvržení objektu SmartArt**

Rozvržení SmartArt určuje, jak jsou uzly uspořádány a propojeny. Následující příklad vytvoří objekt SmartArt s hodnotou [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, změní jej na hodnotu `BasicProcess` a uloží prezentaci. Pozice a velikost předávané metodě [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) jsou měřeny v bodech. K změně rozvržení použijte [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kontrola, zda je uzel SmartArt skrytý**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) udává, zda je uzel skrytý v datovém modelu SmartArt. Skryté uzly mohou existovat ve struktuře, i když vybrané rozvržení je nezobrazí jako viditelné diagramové prvky.

Následující příklad přidá uzel do objektu SmartArt, který používá hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `RadialCycle`, a zkontroluje skrytý stav přidaného uzlu. Vypíše zprávu, pokud je uzel skrytý, a uloží diagram.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Získání nebo nastavení rozvržení organizačního diagramu**

U diagramů SmartArt, které používají rozvržení organizačního diagramu, definují [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) a [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) způsob, jakým jsou podřízené uzly uspořádány pod rodičovským uzlem. Například můžete nastavit, aby podřízené uzly visely vlevo, vpravo nebo na obou stranách, podle vybraného [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/).

Následující příklad vytvoří organizační diagram a nastaví rozvržení pro první uzel na hodnotu [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. Index založený na nule `0` vybírá první uzel nejvyšší úrovně; jeho podřízené uzly použijí vybrané uspořádání. Upravená prezentace se následně uloží.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Vytvoření obrázkového organizačního diagramu**

Obrázkový organizační diagram je rozvržení SmartArt určené pro hierarchické diagramy, které obsahují zástupce obrázků. Při přidávání objektu SmartArt na snímek použijte hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`. Tento příklad uloží diagram se zástupci obrázků; nezaplní je však obrázky.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Převod starších diagramů na skupiny tvarů**

Při modernizaci existující prezentace může být nutné aktualizovat organizační diagram vytvořený v PowerPointu 97–2003. Aspose.Slides představuje tyto starší diagramy jako objekty [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/). K převodu diagramu na skupinu tvarů použijte [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/), abyste mohli upravovat jednotlivé vizuální prvky. Podrobnosti najdete v [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/).

Převod přidá novou skupinu do kolekce tvarů, aniž by odstranil původní diagram. Po úspěšném převodu odstraňte originál pomocí [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/), aby nedošlo k duplicitnímu obsahu. Před převodem shromážděte staré diagramy do seznamu, aby přidávání a odebírání tvarů nerušilo iteraci.

Následující příklad otevře prezentaci, prohledá každý snímek, převede diagramy na skupiny tvarů a uloží aktualizovanou prezentaci jako PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Uložená prezentace obsahuje editovatelné skupiny tvarů místo převedených starých diagramů a žádné původní diagramy už v ní neexistují. Otevřete PPTX v PowerPointu a upravujte jednotlivé prvky v každé skupině, například jejich text, výplň nebo polohu.

## **Často kladené otázky**

**Podporuje SmartArt zrcadlení nebo obrácení pro jazyky RTL?**

Ano. Metoda [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) přepíná směr diagramu z zleva‑doprava na zprava‑dolava nebo zpět, pokud vybrané rozvržení SmartArt podporuje obrácení.

**Jak mohu zkopírovat SmartArt na stejný snímek nebo do jiné prezentace a zachovat formátování?**

Můžete [klonovat tvar SmartArt](/slides/cs/php-java/shape-manipulations/) pomocí [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) nebo [klonovat celý snímek](/slides/cs/php-java/clone-slides/) obsahující SmartArt. Oba přístupy zachovají velikost, pozici i formátování.

**Jak mohu vykreslit SmartArt jako rastrový obrázek pro náhled nebo export na web?**

[Renderujte snímek](/slides/cs/php-java/convert-powerpoint-to-png/) nebo celou prezentaci do PNG nebo JPEG. SmartArt je součástí vykresleného snímku.

**Jak najdu konkrétní objekt SmartArt na snímku, pokud jich je několik?**

Použijte [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) nebo [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) k přiřazení jedinečného alternativního textu či názvu tvaru SmartArt, vyhledejte tuto hodnotu v [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) a poté ověřte, že odpovídající tvar je [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/).