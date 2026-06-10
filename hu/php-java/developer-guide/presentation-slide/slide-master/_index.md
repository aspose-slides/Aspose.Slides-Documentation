---
title: Dia mester kezelése PHP-ben
linktitle: Dia mester
type: docs
weight: 70
url: /hu/php-java/slide-master/
keywords:
- dia mester
- mester dia
- PPT mester dia
- több mester dia
- mester diák összehasonlítása
- háttér
- helyőrző
- mester dia klónozása
- mester dia másolása
- mester dia megkettőzése
- használaton kívüli mester dia
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Dia mesterek kezelése az Aspose.Slides for PHP via Java segítségével: a mester diák elérése, szerkesztése, klónozása, összehasonlítása és eltávolítása PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

A **slide master** egy csoportra vonatkozó közös tervezési beállításokat határoz meg. Tartalmazhat közös alakzatokat, logókat, háttérképeket, szövegstílusokat, téma beállításokat és lábléc beállításokat. PowerPointban a slide master szerkesztése a szokásos módja annak, hogy a bemutató egységes maradjon anélkül, hogy minden dián megismételnénk a formázást.

Az Aspose.Slides for PHP via Java támogatja ugyanazt a modellt. Egy prezentáció egy vagy több master slide-ot tartalmazhat, és minden master slide több layout slide-ot tartalmazhat. A normál diák általában nem hivatkoznak közvetlenül egy master slide-ra. Ehelyett egy normál dia egy layout slide-ot használ, és ez az layout slide egy master slide-hez tartozik.

A hierarchia:

1. **Slide master** – meghatározza a közös tervezést és a témát.
1. **Layout slide** – meghatároz egy adott elrendezést a helyőrzőkkel és a szintű formázással.
1. **Normal slide** – tartalmazza a tényleges prezentációs tartalmat, és egy layout slide-ot használ.

![A mester diák, elrendezési diák és normál diák hierarchiája](slide-master_2.jpg)

Az Aspose.Slides-ban egy slide master-t a [MasterSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/) osztály képviseli. A prezentációban lévő összes mester dia elérhető a [Presentation.getMasters](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getMasters) metódussal, amely egy [MasterSlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslidecollection/) objektumot ad vissza.

{{% alert color="info" title="Inheritance" %}}
Ha ugyanaz a tulajdonság több szinten is definiálva van, a specifikusabb szint nyer. Például, ha egy master slide és egy layout slide is meghatároz egy háttérszínt, akkor az arra az elrendezésre épülő diák az elrendezés háttérszínét használják. További információért az elrendezési diákról lásd a [Apply or Change Slide Layouts](/slides/hu/php-java/slide-layout/) oldalt.
{{% /alert %}}

## **Slide Masterok elérése**

PowerPointban a Slide Master nézetet a **View** > **Slide Master** menüből nyithatod meg.

![A Slide Master parancs a PowerPoint Nézet fülön](slide-master_3.jpg)

Az Aspose.Slides-ban a `getMasters` metódust kell használni a master diák eléréséhez:

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

A normál dia által használt master diát is lekérheted az elrendezésén keresztül:

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

## **A Slide Master tartalma**

Az master slide egy diához hasonló objektum. Kiterjeszti a [BaseSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/) osztályt, így sok olyan diatulajdonságot is elérhetővé tesz, amelyeket a normál és layout diák használnak. A master-specifikus tagok a [MasterSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/) API oldalon vannak felsorolva.

A gyakran használt master slide tagok közé tartoznak:

| Member | Purpose |
| --- | --- |
| `getBackground` | Beállítja a master szintű dia hátterét. |
| `getShapes` | Tárolja a master-re helyezett alakzatokat, például logókat, képkockákat és közös szöveget. |
| `getLayoutSlides` | Tárolja a master-hez tartozó elrendezési diákat. |
| `getThemeManager` | Hozzáférést biztosít a master téma API-khoz. |
| `getHeaderFooterManager` | Kezeli a fejlécet, láblécet, dátumot és diaszámot a master és gyermek elrendezései számára. |
| `getDependingSlides` | Visszaadja azokat a normál diákokat, amelyek a master-re hivatkoznak elrendezéseiken keresztül. |

## **Kép hozzáadása a Slide Masterhez**

A master slide-hez kép hozzáadásával az a diákon megjelenik, amely az adott master elrendezéseit használja. Ez hasznos logók, vízjelek, díszszalagok és más ismétlődő vizuális elemek esetén.

A következő példa egy logót ad az első master diához:

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

További információkért a képkockákról lásd a [Picture Frame](/slides/hu/php-java/picture-frame/) oldalt.

## **Helyőrzőkkel való munka**

A helyőrzőket általában az elrendezési diák definiálják. A master slide biztosítja a közös stílust és témát, amelyet az elrendezések örökölnek, míg minden elrendezés eldönti, hogy mely helyőrzők állnak rendelkezésre és hol helyezkednek el.

PowerPointban a helyőrző parancsok a Slide Master nézetben érhetők el.

![A Insert Placeholder parancs a PowerPoint Slide Master nézetben](slide-master_5.png)

Új helyőrzők hozzáadásához az Aspose.Slides-ban dolgozz a master-hez tartozó layout slide-dal:

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

Formázhatsz már létező helyőrző alakzatokat is egy master slide-on. A következő példa megtalálja a cím helyőrzőt és lineáris gradienst alkalmaz rá:

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

![Formázott cím helyőrző, amelyet a normál diák örökölnek](slide-master_8.png)

További helyőrző és szövegformázási lehetőségekért lásd a [Set Prompt Text in Placeholder](/slides/hu/php-java/manage-placeholder/) és a [Text Formatting](/slides/hu/php-java/text-formatting/) oldalakat.

## **Slide Master háttér módosítása**

A master háttér öröklődik az elrendezések és diák által, amelyek nem írják felül. A következő példa egy szilárd háttérszínt állít be az első master diára:

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

Kapcsolódó témákért lásd a [Presentation Background](/slides/hu/php-java/presentation-background/) és a [Presentation Theme](/slides/hu/php-java/presentation-theme/) oldalakat.

## **Slide Master klónozása egy másik prezentációba**

Használd a `addClone` metódust a [MasterSlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslidecollection/)‑ból, hogy egy master slide-ot másik prezentációba másolj. A másolt master ezután használható az elrendezések és diák számára a célprezentációban.

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

Ha a normál diákot a masterrel együtt kell klónozni, lásd a [Clone Slides](/slides/hu/php-java/clone-slides/) oldalt.

## **Több Slide Master hozzáadása**

Egy prezentáció több master diát is tartalmazhat. Ez hasznos, ha a különböző szakaszok különböző márkázást, oldalstruktúrát vagy téma beállításokat igényelnek.

![PowerPoint parancsok master diák beszúrásához és kezeléséhez](slide-master_9.jpg)

A következő példa klónozza az alapértelmezett master-t, más háttérrel látja el a klónt, létrehoz egy elrendezést a klónozott master alatt, és egy új diát ad hozzá az elrendezés alapján:

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

## **Slide Masterok összehasonlítása**

A master slide-okat össze lehet hasonlítani a [BaseSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/)‑ből örökölt `equals` metódussal. Az összehasonlítás ellenőrzi a struktúrát és a statikus tartalmat, mint például az alakzatok, szöveg, formázás, animációk és egyéb dia beállítások. Nem hasonlítja össze az egyedi azonosítókat, mint a dia ID-k, vagy a dinamikus helyőrző értékeket, mint a jelenlegi dátum.

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

További információért lásd a [Compare Presentation Slides](/slides/hu/php-java/compare-slides/) oldalt.

## **Slide Master nézet beállítása alapértelmezett nézetként**

Használd a `setLastView` metódust a [ViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/)‑on, hogy szabályozd, melyik nézetet nyissa meg a PowerPoint először. A következő példa a prezentációt Slide Master nézetben nyitja meg:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

További nézetbeállításokért lásd a [Save Presentation](/slides/hu/php-java/save-presentation/) oldalt.

## **Használaton kívüli Master diák eltávolítása**

Egyes prezentációk tartalmazhatnak olyan master diákokat, amelyeket már egyetlen normál dia sem használ. A használaton kívüli master diák eltávolítása csökkentheti a fájlméretet és egyszerűsítheti a sablon karbantartását.

Használd a `removeUnused` metódust a [MasterSlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslidecollection/)‑ból, hogy eltávolítsd a használaton kívüli master‑eket a `getMasters` gyűjteményből:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Alacsony kódszintű `removeUnusedMasterSlides` metódust is használhatsz a [Compress](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/) osztályból:

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

**Mi a különbség a slide master és a layout slide között?**

Az slide master meghatározza a közös tervezési beállításokat, mint például a téma, háttér, közös alakzatok és szövegstílusok. A layout slide egy master slide-hoz tartozik, és egy adott helyőrző elrendezést definiál. A normál dia egy layout slide-ot használ, így mind az elrendezés, mind a master beállításait örökli.

**Tartalmazhat egy prezentáció több slide master-t?**

Igen. Egy prezentáció több slide master-t is tartalmazhat. Használj több master-t, ha a különböző szakaszoknak eltérő vizuális rendszerekre vagy márkázásra van szükségük.

**Helyőrzőket a master slide-hoz vagy a layout slide-hoz kellene hozzáadni?**

A legtöbb esetben a helyőrzőket a layout slide-okra kell tenni. A közös vizuális elemeket és a közös formázást a master slide-ra helyezzük, majd a tartalomhelyőrzőket azokra a layout slide-okra, amelyeket a normál diák használnak.

**Törölhetek egy még használatban lévő master slide-ot?**

Nem. Egy olyan master slide, amelynek függő diái vannak, nem távolítható el biztonságosan közvetlenül. Először mozgasd át ezeket a diát egy másik master alatti elrendezésekbe, vagy használd a használaton kívüli master törlésének módszerét, amely csak a nem használt master diákat távolítja el.