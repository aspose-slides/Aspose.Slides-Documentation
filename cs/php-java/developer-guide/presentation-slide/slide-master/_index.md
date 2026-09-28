---
title: Správa hlavních snímků prezentace v PHP
linktitle: Hlavní snímek
type: docs
weight: 70
url: /cs/php-java/slide-master/
keywords:
- hlavní snímek
- hlavní snímek
- PPT hlavní snímek
- více hlavních snímků
- porovnání hlavních snímků
- pozadí
- zástupný objekt
- klonovat hlavní snímek
- kopírovat hlavní snímek
- duplikovat hlavní snímek
- nepoužitý hlavní snímek
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte hlavní snímky v Aspose.Slides pro PHP přes Java: přístup, úpravy, klonování, porovnávání a odstraňování hlavních snímků v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

**slide master** definuje sdílené nastavení návrhu pro skupinu snímků. Může obsahovat společné tvary, loga, pozadí, styly textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava **slide master** obvyklý způsob, jak udržet prezentaci konzistentní, aniž byste opakovali stejné formátování na každém snímku.

Aspose.Slides for PHP via Java podporuje stejný model. Prezentace může obsahovat jeden nebo více hlavních snímků a každý hlavní snímek může obsahovat několik rozvržení snímku. Normální snímky se obvykle nepřipojují přímo k hlavnímu snímku. Místo toho normální snímek používá rozvržení snímku, které patří k hlavnímu snímku.

Hierarchie je:

1. **Slide master** – definuje sdílený návrh a motiv.
1. **Layout slide** – definuje konkrétní uspořádání zástupných objektů a formátování úrovně rozvržení.
1. **Normal slide** – obsahuje skutečný obsah prezentace a používá jedno rozvržení snímku.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

V Aspose.Slides je hlavní snímek reprezentován třídou [MasterSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/). Všechny hlavní snímky v prezentaci jsou dostupné prostřednictvím metody [Presentation.getMasters](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getMasters), která vrací objekt [MasterSlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Dědičnost" %}}

Když je stejná vlastnost definována na více úrovních, vyhrává konkrétnější úroveň. Například pokud hlavní snímek i rozvržení snímku definují pozadí, snímky založené na tomto rozvržení použijí pozadí rozvržení. Další informace o rozvrženích snímků najdete v [Apply or Change Slide Layouts](/slides/cs/php-java/slide-layout/).

{{% /alert %}}

## **Přístup k Slide Masterům**

V PowerPointu můžete otevřít zobrazení **Slide Master** přes **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

V Aspose.Slides použijte metodu `getMasters` pro přístup k hlavním snímkům:

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

Můžete také získat hlavní snímek použité normálním snímkem prostřednictvím jeho rozvržení:

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

## **Co obsahuje Slide Master**

Hlavní snímek je objekt podobný snímku. Rozšiřuje [BaseSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/), takže vystavuje mnoho stejných vlastností snímku používaných normálními a rozvrženými snímky. Členové specifické pro hlavní snímek jsou uvedeni na stránce API [MasterSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/).

Mezi běžně používané členy hlavního snímku patří:

| Člen | Účel |
| --- | --- |
| `getBackground` | Nastavuje pozadí na úrovni hlavního snímku. |
| `getShapes` | Uchovává tvary umístěné na hlavním snímku, např. loga, rámy obrázků a sdílený text. |
| `getLayoutSlides` | Uchovává rozvržení snímků, která patří k hlavnímu snímku. |
| `getThemeManager` | Poskytuje přístup k API motivu hlavního snímku. |
| `getHeaderFooterManager` | Řídí záhlaví, zápatí, datum a čísla snímků pro hlavní snímek a jeho podřízená rozvržení. |
| `getDependingSlides` | Vrací normální snímky, které závisí na hlavním snímku skrze svá rozvržení. |

## **Přidání obrázku do Slide Masteru**

Když přidáte obrázek do hlavního snímku, objeví se na snímcích, které používají rozvržení z tohoto hlavního snímku. To je užitečné pro loga, vodoznaky, dekorativní pásy a jiné opakující se vizuální prvky.

Následující příklad přidá logo na první hlavní snímek:

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

Další informace o rámečcích obrázků najdete v [Picture Frame](/slides/cs/php-java/picture-frame/).

## **Řízení viditelnosti grafiky hlavního snímku**

Použijte [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/#setShowMasterShapes) k skrytí zděděné grafiky hlavního snímku, jako jsou loga nebo dekorativní tvary, aniž byste je mazali z hlavního snímku. Na snímku, který má tyto grafiky vynechat, předejte `false` metodě [Slide::setShowMasterShapes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#setShowMasterShapes) a na snímcích, které je mají zobrazovat, ponechte `true`.

Následující samostatný příklad vytvoří modrý dekorativní pás na hlavním snímku a dva snímky používající stejné prázdné rozvržení. Pás je viditelný na prvním snímku a skrytý na druhém. Není potřeba žádná vstupní prezentace ani obrázek.

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

Příklad používá rozvržení **Blank** dodané s novou prezentací a odstraňuje počáteční zástupné objekty snímku.

### **Zvolte rozsah nastavení**

Normální snímek používá svého hlavního snímku přes [Slide::getLayoutSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getLayoutSlide) a [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/#getMasterSlide). Nastavení vlastnosti na jednotlivém snímku ovlivní jen tento snímek. Předáním `false` metodě [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/#setShowMasterShapes) skryjete grafiku hlavního snímku pro všechny snímky používající toto sdílené rozvržení, i když jejich vlastní nastavení je `true`. Pro skrytí grafiky jen na jednom snímku změňte vlastnost snímku a ponechte rozvržení nezměněné.

Nastavení není podporováno jako řízení viditelnosti přímo na hlavním snímku. Na hlavním snímku [getShowMasterShapes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/#getShowMasterShapes) vždy vrací `false` a předání `true` metodě [setShowMasterShapes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/#setShowMasterShapes) vyvolá výjimku. Použijte ho na normálním snímku nebo na rozvržení.

### **Odlište grafiku od pozadí**

| Operace | Efekt |
| --- | --- |
| Skrýt grafiku hlavního snímku | Řídí viditelnost zděděných tvarů hlavního snímku bez jejich mazání nebo změny tvarů snímku. |
| Změnit výplň pozadí snímku | Mění barvu, gradient nebo obrázek pozadí. Grafika hlavního snímku je samostatný tvar a může zůstat viditelná nad tímto pozadím. Viz [Presentation Background](/slides/cs/php-java/presentation-background/). |
| Smazat tvar z hlavního snímku | Odstraní sdílený zdrojový tvar, takže už není dostupný žádnému snímku používajícímu tohoto hlavního snímku. |

## **Práce se zástupnými objekty**

Zástupné objekty jsou obvykle definovány na rozvrženích snímků. Hlavní snímek poskytuje sdílený styl a motiv, který rozvržení dědí, zatímco každé rozvržení rozhoduje, které zástupné objekty jsou k dispozici a kde jsou umístěny.

V PowerPointu jsou příkazy pro zástupné objekty dostupné v zobrazení Slide Master.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Pro přidání nových zástupných objektů s Aspose.Slides pracujte s rozvržením snímku, které patří k hlavnímu snímku:

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

Můžete také formátovat tvary zástupných objektů, které již existují na hlavním snímku. Následující příklad najde zástupný objekt titulu a použije lineární gradientní výplň:

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

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Další možnosti formátování zástupných objektů a textu najdete v [Set Prompt Text in Placeholder](/slides/cs/php-java/manage-placeholder/) a [Text Formatting](/slides/cs/php-java/text-formatting/).

## **Změna pozadí Slide Masteru**

Pozadí hlavního snímku je zděděno rozvrženími a snímky, které ho nepřepisují. Následující příklad nastaví jednotnou barvu pozadí pro první hlavní snímek:

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

Pro související témata viz [Presentation Background](/slides/cs/php-java/presentation-background/) a [Presentation Theme](/slides/cs/php-java/presentation-theme/).

## **Klonování Slide Masteru do jiné prezentace**

Použijte `addClone` z [MasterSlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslidecollection/) k zkopírování hlavního snímku do jiné prezentace. Zkopírovaný hlavní snímek pak může být použit rozvrženími a snímky v cílové prezentaci.

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

Pokud potřebujete klonovat normální snímky spolu s jejich hlavním snímkem, viz [Clone Slides](/slides/cs/php-java/clone-slides/).

## **Přidání více Slide Masterů**

Prezentace může obsahovat více hlavních snímků. To je užitečné, když různé sekce vyžadují odlišné značení, strukturu stránek nebo nastavení motivu.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Následující příklad zklonuje výchozí hlavní snímek, dá klonu jiné pozadí, vytvoří rozvržení pod tímto klonovaným hlavním snímkem a přidá nový snímek založený na tomto rozvržení:

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

## **Porovnání Slide Masterů**

Hlavní snímky lze porovnat metodou `equals`, která je zděděna od [BaseSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/). Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Není porovnáváno jedinečné identifikátory, jako jsou ID snímků, ani dynamické hodnoty zástupných objektů, například aktuální datum.

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

Další informace naleznete v [Compare Presentation Slides](/slides/cs/php-java/compare-slides/).

## **Nastavení Slide Master View jako výchozího zobrazení**

Použijte metodu `setLastView` na [ViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/) k ovládání pohledu, který PowerPoint otevře jako první. Následující příklad otevře prezentaci v zobrazení Slide Master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Další nastavení zobrazení najdete v [Save Presentation](/slides/cs/php-java/save-presentation/).

## **Odstranění nepoužívaných Slide Masterů**

Někdy prezentace obsahují hlavní snímky, které již žádný normální snímek nepoužívá. Odstranění nepoužívaných hlavních snímků může zmenšit velikost souboru a zjednodušit údržbu šablony.

Použijte `removeUnused` z [MasterSlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslidecollection/) k odstranění nepoužívaných hlavních snímků ze sbírky `getMasters`:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Můžete také použít low‑code metodu `removeUnusedMasterSlides` ze třídy [Compress](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Často kladené otázky**

**Jaký je rozdíl mezi slide master a layout slide?**

Slide master definuje sdílené nastavení návrhu, jako je motiv, pozadí, společné tvary a styly textu. Layout slide patří k slide masteru a určuje konkrétní uspořádání zástupných objektů. Normální snímek používá layout slide, takže dědí jak z layoutu, tak ze slide masteru.

**Může jedna prezentace obsahovat několik slide masterů?**

Ano. Prezentace může obsahovat několik slide masterů. Použijte více masterů, když různé sekce potřebují odlišné vizuální systémy nebo značky.

**Mám přidávat zástupné objekty na slide master nebo na layout slide?**

Ve většině případů přidávejte zástupné objekty na layout slide. Na slide masteru umístěte sdílené vizuální prvky a společné formátování, poté na rozvržení umístěte obsahové zástupné objekty, které budou používat normální snímky.

**Mohu smazat slide master, který je stále používán?**

Ne. Slide master, který má závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesuňte tyto snímky na rozvržení pod jiný slide master nebo použijte metodu pro úklid nepoužívaných masterů, která odstraňuje jen ty mastery, které nejsou v použití.