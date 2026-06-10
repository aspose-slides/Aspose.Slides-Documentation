---
title: SmartArt kezelése PowerPoint prezentációkban PHP használatával
linktitle: SmartArt kezelése
type: docs
weight: 10
url: /hu/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt szöveg
- elrendezés típusa
- rejtett tulajdonság
- szervezeti diagram
- képes szervezeti diagram
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Tanulja meg a PowerPoint SmartArt építését és szerkesztését az Aspose.Slides for PHP via Java segítségével, áttekinthető kódmintákkal, amelyek felgyorsítják a dia tervezését és automatizálását."
---
## **Áttekintés**

A SmartArt egy PowerPoint-diagram, amely csomópontokból, csomópont alakzatokból és egy elrendezésből áll. Az Aspose.Slides for PHP via Java segítségével létrehozhat SmartArt-ot, kiolvashatja a szöveget a csomópontjaiból, módosíthatja az elrendezést, ellenőrizheti a rejtett csomópontokat, konfigurálhatja a szervezeti diagram elrendezéseket, és képes szervezeti diagramokat hozhat létre.

## **Szöveg lekérése egy SmartArt objektumból**

Egy SmartArt csomópont egy vagy több alakzatot is tartalmazhat. A látható szöveg olvasásához iteráljon a [SmartArt::getAllNodes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/#getAllNodes) felett, majd olvassa el a [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartartshape/#getTextFrame) által visszaadott [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) objektumot.

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

## **A SmartArt objektum elrendezéstípusának módosítása**

Az SmartArt elrendezés szabályozza, hogyan helyezkednek el és kapcsolódnak a csomópontok. Az alábbi példában egy SmartArt objektumot hozunk létre a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList` értékével, átállítjuk `BasicProcess` értékre, és elmentjük a prezentációt.

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

## **Ellenőrizze, hogy egy SmartArt csomópont rejtett-e**

A [SmartArtNode::isHidden](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartartnode/ishidden/) jelzi, hogy a csomópont rejtett-e a SmartArt adatmodellben. Rejtett csomópontok létezhetnek a struktúrában akkor is, ha a kiválasztott elrendezés nem jeleníti meg őket látható diagramelemként.

Az alábbi példában egy csomópontot adunk egy SmartArt objektumhoz, amely a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` értéket használja, majd ellenőrizzük a csomópont rejtett állapotát.

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

## **Szervezeti diagram elrendezésének lekérése vagy beállítása**

Az olyan SmartArt diagramok esetén, amelyek szervezeti diagram elrendezést használnak, a [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) és a [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) határozzák meg, hogyan rendeződnek el a gyermekcsomópontok egy szülőcsomópont alatt. Például beállíthatja, hogy a gyermekcsomópontok balról, jobbról vagy mindkét oldalról függjenek, a kiválasztott [OrganizationChartLayoutType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/organizationchartlayouttype/) függvényében.

Az alábbi példában egy szervezeti diagramot hozunk létre, és az első csomópont elrendezését a [OrganizationChartLayoutType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` értékre állítjuk.

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

## **Képes szervezeti diagram létrehozása**

A képes szervezeti diagram egy olyan SmartArt elrendezés, amely hierarchikus diagramokhoz lett tervezve, és képhelyettesítőket tartalmaz. Használja a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` értékét a SmartArt objektum diára történő hozzáadásakor.

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

## **GYIK**

**Támogatja a SmartArt a tükörképezést vagy fordítást jobb‑bal (RTL) nyelvek esetén?**

Igen. A [SmartArt::setReversed](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/setreversed/) metódus bal‑jobb irányú diagramot fordít jobbra‑balra vagy vissza, ha a kiválasztott SmartArt elrendezés támogatja a fordítást.

**Hogyan másolhatom a SmartArt-ot ugyanarra a diára vagy egy másik prezentációba a formázás megőrzésével?**

A SmartArt alakzatot [klónozhatja](/slides/hu/php-java/shape-manipulations/) a [ShapeCollection::addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addclone/) vagy a teljes diát [klónozhatja](/slides/hu/php-java/clone-slides/) amely a SmartArt-ot tartalmazza. Mindkét módszer megőrzi a méretet, a pozíciót és a formázást.

**Hogyan jeleníthetem meg a SmartArt-ot raszterképként előnézet vagy webes export céljából?**

[Renderelje a diát](/slides/hu/php-java/convert-powerpoint-to-png/) vagy a teljes prezentációt PNG vagy JPEG formátumba. A SmartArt a dia részeként kerül renderelésre.

**Hogyan találhatok meg egy adott SmartArt objektumot a dián, ha több is van?**

Állítson be egy egyedi [Shape::getAlternativeText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getalternativetext/) vagy [Shape::getName](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getname/) értéket a SmartArt alakzaton, keresse meg ezt az értéket a [BaseSlide::getShapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/#getShapes) között, majd ellenőrizze, hogy a megtalált alakzat egy [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/).