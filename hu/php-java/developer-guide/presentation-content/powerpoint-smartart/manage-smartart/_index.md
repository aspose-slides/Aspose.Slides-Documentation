---
title: PowerPoint-prezentációk SmartArt kezelése PHP használatával
linktitle: SmartArt kezelése
type: docs
weight: 10
url: /hu/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt szöveg
- elrendezéstípus
- rejtett tulajdonság
- szervezeti diagram
- képes szervezeti diagram
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Tanulja meg, hogyan építsen és szerkesszen PowerPoint SmartArt-ot az Aspose.Slides for PHP via Java segítségével, világos kódpéldákkal, amelyek felgyorsítják a dia tervezését és automatizálását."
---
## **Áttekintés**

SmartArt egy PowerPoint-diagram, amely csomópontokból, csomópont alakzatokból és egy elrendezésből áll. Az Aspose.Slides for PHP via Java segítségével létrehozhat SmartArt-ot, kiolvashatja a szöveget a csomópontjaiból, megváltoztathatja az elrendezését, ellenőrizheti a rejtett csomópontokat, konfigurálhatja a szervezeti diagram elrendezéseket, és létrehozhat képes szervezeti diagramokat.

## **Szöveg lekérése egy SmartArt objektumból**

Egy SmartArt csomópont egy vagy több alakzatot tartalmazhat. A csomópont alakzatok szövegének olvasásához iteráljon a [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/), majd olvassa el a [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/) által visszaadott [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).

A példához egy olyan prezentáció szükséges, amelynek legalább egy diája van, és a dián az első alakzat egy SmartArt objektum. A program minden elérhető szövegkeretet kiírja a konzolra.

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

## **SmartArt objektum elrendezéstípusának módosítása**

A SmartArt elrendezés szabályozza, hogyan vannak elrendezve és összekapcsolva a csomópontok. A következő példa egy SmartArt objektumot hoz létre a [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList` értékkel, átállítja `BasicProcess` értékre, és elmenti a prezentációt. A [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/)‑nak átadott pozíciót és méretet pontban mérik. Az elrendezés módosításához használja a [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/)‑t.

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

## **Ellenőrizze, hogy egy SmartArt csomópont rejtett-e**

A [SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) jelzi, hogy a csomópont rejtett-e a SmartArt adatmodellben. A rejtett csomópontok létezhetnek a struktúrában, még akkor is, ha a kiválasztott elrendezés nem jeleníti meg őket látható diagramelemként.

A következő példa egy csomópontot ad hozzá egy SmartArt objektumhoz, amely a [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` értéket használ, és ellenőrzi a hozzáadott csomópont rejtett állapotát. Ha a csomópont rejtett, egy üzenetet ír ki, majd elmenti a diagramot.

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

## **Szervezeti diagram elrendezés lekérése vagy beállítása**

Az olyan SmartArt diagramoknál, amelyek szervezeti diagram elrendezést használnak, a [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) és a [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) határozzák meg, hogyan vannak elrendezve a gyermekcsomópontok a szülőcsomópont alatt. Például beállíthatja, hogy a gyermekcsomópontok balról, jobbról vagy mindkét oldalról függjenek, a kiválasztott [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) függvényében.

A következő példa létrehoz egy szervezeti diagramot, és beállítja az első csomópont elrendezését a [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` értékre. A nulláról indított index `0` kiválasztja az első felső szintű csomópontot; annak gyermekcsomópontjai az ekkor kiválasztott elrendezést használják. Ezután a módosított prezentációt elmenti.

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

## **Képes szervezeti diagram létrehozása**

A képes szervezeti diagram egy olyan SmartArt elrendezés, amely hierarchikus diagramokhoz készült, és képhelyeket tartalmaz. A [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` értéket használja, amikor a SmartArt objektumot egy diára adja. Ez a példa egy diagramot ment el képhelyekkel; a helyek nincsenek képekkel feltöltve.

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

## **Régi diagramok alakzatcsoportokká konvertálása**

Egy meglévő prezentáció modernizálásakor előfordulhat, hogy frissíteni kell egy eredetileg PowerPoint 97–2003-ban készült szervezeti diagramot. Az Aspose.Slides ezeket a régi diagramokat [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) objektumokként jeleníti meg. Használja a [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/)‑t, hogy egy diagramot alakzatcsoporttá konvertáljon, így szerkesztheti az egyedi vizuális elemeket. A részletekért tekintse meg a [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) dokumentációt.

A konvertálás egy új csoportot ad az alakzatgyűjteményhez az eredeti diagram eltávolítása nélkül. Sikeres konvertálás után távolítsa el az eredetit a [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) használatával, hogy elkerülje a duplikált tartalmat. A konvertálás előtt gyűjtse össze a régi diagramokat egy listába, hogy az alakzatok hozzáadása és eltávolítása ne szakítsa meg az iterációt.

A következő példa megnyit egy prezentációt, minden diát keres, a diagramokat alakzatcsoportokká konvertálja, és elmenti a frissített prezentációt PPTX formátumban.

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

Az elmentett prezentáció szerkeszthető alakzatcsoportokat tartalmaz a konvertált régi diagramok helyett, az eredeti diagramok már nem szerepelnek. Nyissa meg a PPTX-et a PowerPointban, hogy szerkessze az egyes csoportok elemeit, például a szöveget, kitöltést vagy pozíciót.

## **GYIK**

**Támogatja a SmartArt a tükrözést vagy fordítást RTL nyelvekhez?**

Igen. A [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) metódus megfordítja a diagram irányát balról jobbra és vissza, ha a kiválasztott SmartArt elrendezés támogatja a fordítást.

**Hogyan másolhatom a SmartArt-ot ugyanarra a diára vagy egy másik prezentációba, miközben megőrzöm a formázást?**

Klónozhatja a [SmartArt alakzatot](/slides/hu/php-java/shape-manipulations/) a [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) segítségével, vagy [klónozhatja az egész diát](/slides/hu/php-java/clone-slides/) , amely a SmartArt-ot tartalmazza. Mindkét megközelítés megőrzi a méretet, a pozíciót és a formázást.

**Hogyan renderelhetem a SmartArt-ot raszteres képre előnézethez vagy webes exporthoz?**

[A diát renderelni](/slides/hu/php-java/convert-powerpoint-to-png/) vagy az egész prezentációt PNG vagy JPEG formátumba. A SmartArt a dián belül renderelődik.

**Hogyan találhatok meg egy konkrét SmartArt objektumot egy dián, ha több is van?**

Használja a [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) vagy a [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) metódust, hogy egy megkülönböztető alternatív szöveget vagy nevet adjon a SmartArt alakzatnak, keresse meg ezt az értéket a [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes)‑ben, majd ellenőrizze, hogy a megtalált alakzat egy [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)‑e.