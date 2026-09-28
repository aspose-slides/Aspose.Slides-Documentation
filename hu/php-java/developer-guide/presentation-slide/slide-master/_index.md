---
title: "Prezentáció diák master-ek kezelése PHP-ben"
linktitle: "Dia master"
type: docs
weight: 70
url: /hu/php-java/slide-master/
keywords:
- "dia master"
- "master dia"
- "PPT master dia"
- "több master dia"
- "master diák összehasonlítása"
- "háttér"
- "helyőrző"
- "master dia klónozása"
- "master dia másolása"
- "master dia duplikálása"
- "nem használt master dia"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "PHP"
- "Aspose.Slides"
description: "Diák master-ek kezelése az Aspose.Slides for PHP via Java segítségével: a master diák elérése, szerkesztése, klónozása, összehasonlítása és eltávolítása PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

A **slide master** közös tervezési beállításokat határoz meg egy diacsoport számára. Tartalmazhat általános alakzatokat, logókat, háttereket, szövegstílusokat, témabeállításokat és láblécbeállításokat. A PowerPointban a slide master szerkesztése a szokásos módja annak, hogy a bemutató egységes maradjon anélkül, hogy minden dián meg kellene ismételni ugyanazt a formázást.

Aspose.Slides for PHP via Java támogatja ugyanazt a modellt. Egy bemutató egy vagy több master slidet tartalmazhat, és minden master slide több layout slidet tartalmazhat. A normál diák általában nem hivatkoznak közvetlenül egy master slide-re. Ehelyett egy normál dia egy layout slide-et használ, és ez a layout slide egy master slide-hez tartozik.

A hierarchia a következő:

1. **Slide master** – meghatározza a közös tervezést és témát.
1. **Layout slide** – meghatároz egy adott elrendezést a helyőrzőkkel és az elrendezési szintű formázással.
1. **Normal slide** – tartalmazza a tényleges bemutató tartalmat, és egy layout slide-et használ.

![A master slide-ek, layout slide-ek és normál slide-ek hierarchiája](slide-master_2.jpg)

Az Aspose.Slides-ban a slide master-t a [MasterSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/) osztály képviseli. A bemutató összes master slide-je a [Presentation.getMasters](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getMasters) metóduson keresztül érhető el, amely egy [MasterSlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslidecollection/) objektumot ad vissza.

{{% alert color="info" title="Inheritance" %}}
Amikor ugyanaz a tulajdonság több szinten is definiálva van, a specifikusabb szint felülírja a többit. Például, ha egy master slide és egy layout slide is meghatároz egy hátteret, akkor az azon a layouton alapuló diák a layout háttérét használja. További információért a layout slide-okról lásd a [Apply or Change Slide Layouts](/slides/hu/php-java/slide-layout/).
{{% /alert %}}

## **Slide master-ek elérése**

PowerPointban megnyithatja a Slide Master nézetet a **View** > **Slide Master** menüpontból.

![A Slide Master parancs a PowerPoint Nézet (View) lapon](slide-master_3.jpg)

Az Aspose.Slides-ban használja a `getMasters` metódust a master slide-ek eléréséhez:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

A normál dia által használt master slide-et a saját layout-ján keresztül is lekérheti:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Mit tartalmaz egy Slide Master**

A master slide egy diához hasonló objektum. Kiterjed a [BaseSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/) osztályra, így számos olyan dia‑tulajdonságot is elérhetővé tesz, amelyet a normál és layout diák is használnak. A master‑specifikus tagok a [MasterSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/) API oldalán találhatók.

Gyakran használt master slide tagok:

| Tag | Cél |
| --- | --- |
| `getBackground` | Beállítja a master‑szintű dia hátterét. |
| `getShapes` | Tárolja a masterre helyezett alakzatokat, például logókat, képkockákat és megosztott szöveget. |
| `getLayoutSlides` | Tárolja a masterhez tartozó layout slide-eket. |
| `getThemeManager` | Hozzáférést biztosít a master téma API-khoz. |
| `getHeaderFooterManager` | Kezeli a fejléceket, lábléceket, dátumokat és dia‑számokat a master és annak alatti layouok számára. |
| `getDependingSlides` | Visszaadja a normál diák listáját, amelyek a master‑layoutjaikon keresztül függnek tőle. |

## **Kép hozzáadása a Slide Master-hez**

Amikor egy képet ad hozzá egy master slide-hez, az a masterhez tartozó layoukat használó diákon is megjelenik. Ez hasznos logók, vízjelek, díszszalagok és egyéb ismétlődő vizuális elemek esetén.

A következő példa egy logót ad az első master slide-hez:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

További információért a képkockákról lásd a [Picture Frame](/slides/hu/php-java/picture-frame/).

## **A master grafika láthatóságának vezérlése**

Használja a [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/#setShowMasterShapes) metódust a örökölt master grafika (például logók vagy díszalakzatok) elrejtéséhez anélkül, hogy törölné őket a masterből. A [Slide::setShowMasterShapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#setShowMasterShapes) metódusnál adja meg `false`‑t azon a dián, amelyiknek el kell rejteni a grafikai elemeket, és `true`‑t azoknál a diákon, amelyeknek láthatónak kell maradniuk.

A következő önálló példa kék díszszalagot hoz létre egy masteren, és két diát, amely ugyanazt az üres layouthoz használ. A szalag az első dián látható, a másodikon el van rejtve. Bemeneti bemutató vagy kép nem szükséges.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A példa a **Blank** layout‑et használja, amely egy új bemutatóval érkezik, és eltávolítja az első dia saját helyőrzőit.

### **A beállítás hatókörének kiválasztása**

Egy normál dia a masterét a [Slide::getLayoutSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#getLayoutSlide) és a [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/#getMasterSlide) segítségével éri el. A tulajdonság egyedi dián való beállítása csak arra a diára van hatással. A [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/#setShowMasterShapes) `false` értékre állítása elrejti a master grafikai elemeit az adott közös layouthoz tartozó diákon is, még akkor is, ha saját beállításuk `true`. Egyetlen dia grafikai elemeinek elrejtéséhez módosítsa a dia tulajdonságát, és hagyja a közös layount változatlanul.

A beállítás nem támogatott láthatósági vezérlőként a master slide-en magán. A masteren a [getShowMasterShapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/#getShowMasterShapes) mindig `false`‑t ad vissza, és a [setShowMasterShapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/#setShowMasterShapes) `true`‑ra állítása kivételt dob. Alkalmazza normál dián vagy layouten.

### **Grafika és háttér megkülönböztetése**

| Művelet | Hatás |
| --- | --- |
| Master grafika elrejtése | A örökölt master alakzatok láthatóságát vezérli anélkül, hogy törölné őket vagy megváltoztatná a dia saját alakzatait. |
| Dia háttér kitöltésének módosítása | A háttér színét, színátmenetét vagy képét változtatja. A master grafika különálló alakzat, amely a háttér felett látható maradhat. Lásd a [Presentation Background](/slides/hu/php-java/presentation-background/). |
| Alakzat törlése a masterből | Eltávolítja a megosztott forrásalakzatot, így már nem lesz elérhető a master‑t használó diák számára. |

## **Helyőrzők kezelése**

A helyőrzőket általában a layout slide-eken definiálják. A master slide biztosítja a közös stílust és témát, amelyet a layouok örökölnek, míg minden layout dönti el, hogy mely helyőrzők állnak rendelkezésre és hol helyezkednek el.

PowerPointban a helyőrzőparancsok a Slide Master nézetben érhetők el.

![A Helyőrző beszúrása parancs a PowerPoint Slide Master nézetben](slide-master_5.png)

Új helyőrzők hozzáadásához az Aspose.Slides-ban dolgozzon a masterhez tartozó layout slide‑del:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Már meglévő helyőrző alakzatok formázása is lehetséges egy master slide-en. A következő példa megtalálja a cím helyőrzőt és lineáris színátmenetet alkalmaz rá:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![Formázott címmász helyőrző, ami a normál diákra öröklődik](slide-master_8.png)

További helyőrző‑ és szöveges formázási lehetőségekért lásd a [Set Prompt Text in Placeholder](/slides/hu/php-java/manage-placeholder/) és a [Text Formatting](/slides/hu/php-java/text-formatting/) oldalakat.

## **Slide Master háttér módosítása**

A master háttér öröklődik a layoukon és a diákon, amelyek nem írják felül azt. A következő példa egy egységes háttérszínt állít be az első master slide-re:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kapcsolódó témák: [Presentation Background](/slides/hu/php-java/presentation-background/) és [Presentation Theme](/slides/hu/php-java/presentation-theme/).

## **Slide Master klónozása egy másik bemutatóba**

Használja a `addClone` metódust a [MasterSlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslidecollection/)‑ból, hogy egy master slide‑t egy másik bemutatóba másoljon. A másolt master aztán felhasználható a célbemutató layoujaiban és diáin.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

Ha normál diákot is klónozni szeretne a masterrel együtt, lásd a [Clone Slides](/slides/hu/php-java/clone-slides/).

## **Több Slide Master hozzáadása**

Egy bemutató tartalmazhat több master slide-et. Ez hasznos, ha különböző szekciók különböző márkázást, oldalszerkezetet vagy téma‑beállításokat igényelnek.

![PowerPoint parancsok a master slide-ek beszúrásához és kezeléséhez](slide-master_9.jpg)

A következő példa klónozza az alapértelmezett mastert, más háttérrel látja el a klónt, létrehoz egy layoutot a klónozott master alatt, és egy új diát ad hozzá azzal a layouttal:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Slide Master-ek összehasonlítása**

A master slide-ek összehasonlíthatók a [BaseSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/)‑ből örökölt `equals` metódussal. Az összehasonlítás a szerkezetet és a statikus tartalmat vizsgálja, például alakzatokat, szöveget, formázást, animációkat és egyéb dia‑beállításokat. Nem hasonlítja össze az egyedi azonosítókat, például a dia‑ID‑kat, vagy a dinamikus helyőrző‑értékeket, mint a aktuális dátum.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

További információért lásd a [Compare Presentation Slides](/slides/hu/php-java/compare-slides/).

## **Slide Master nézet beállítása alapértelmezett nézetként**

Használja a `setLastView` metódust a [ViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/)‑n, hogy a PowerPoint által elsőként megnyitott nézetet szabályozza. A következő példa a bemutatót Slide Master nézetben nyitja meg:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

További nézetbeállításokért lásd a [Save Presentation](/slides/hu/php-java/save-presentation/).

## **Nem használt Master Slide-ek eltávolítása**

A bemutatók néha tartalmaznak master slide-eket, amelyeket már egyetlen normál dia sem használ. A nem használt master‑ok eltávolítása csökkentheti a fájlméretet és egyszerűsítheti a sablonkarbantartást.

Használja a `removeUnused` metódust a [MasterSlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslidecollection/)‑ból, hogy eltávolítsa a nem használt master‑okat a `getMasters` gyűjteményből:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Alacsony kódszintű megoldásként használhatja a [Compress](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/) osztály `removeUnusedMasterSlides` metódusát is:

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Mi a különbség egy slide master és egy layout slide között?**

A slide master közös tervezési beállításokat (téma, háttér, közös alakzatok, szövegstílusok) definiál. A layout slide egy masterhez tartozik, és egy adott helyőrző‑elrendezést határoz meg. Egy normál dia egy layout slide-et használ, így mind a layout, mind a master beállításait örökli.

**Tartalmazhat egy bemutató több slide master‑t?**

Igen. Egy bemutató több slide master‑t is tartalmazhat. Használjon több master‑t, ha különböző szekcióknak különböző vizuális rendszerekre vagy márkázásra van szükségük.

**Hová tegyek helyőrzőket, a master slide‑re vagy a layout slide‑re?**

A legtöbb esetben a helyőrzőket a layout slide-eken kell elhelyezni. A megosztott vizuális elemeket és formázásokat a master slide-re helyezze, majd a tartalmi helyőrzőket a normál diák által használt layoutra.

**Törölhetek egy még használt master slide-et?**

Nem. Egy master slide, amelynek vannak függő diái, nem távolítható el biztonságosan. Előbb mozgassa át ezeket a diákat egy másik master alatti layoutokra, vagy használjon olyan tisztító módszert, amely csak a nem használt master‑okat távolítja el.