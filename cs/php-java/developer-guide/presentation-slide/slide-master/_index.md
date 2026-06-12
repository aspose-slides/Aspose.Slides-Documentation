---
title: Správa slide masterů prezentace v PHP
linktitle: Slide master
type: docs
weight: 70
url: /cs/php-java/slide-master/
keywords:
- hlavní snímek
- master snímek
- PPT hlavní snímek
- více hlavních snímků
- porovnat hlavní snímky
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
description: "Spravovat slide mastery v Aspose.Slides for PHP via Java: přístup, úpravy, klonování, porovnání a odstranění hlavních snímků v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

**Slide master** definuje sdílená nastavení designu pro skupinu snímků. Může obsahovat společné tvary, loga, pozadí, styl textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava slide masteru obvyklý způsob, jak udržet prezentaci konzistentní, aniž byste opakovali stejné formátování na každém snímku.

Aspose.Slides for PHP via Java podporuje stejný model. Prezentace může obsahovat jeden nebo více master snímků a každý master snímek může obsahovat několik layout snímků. Normální snímky se obvykle nepřipojují přímo k master snímku. Místo toho normální snímek používá layout snímek, který náleží k master snímku.

Hierarchie je:

1. **Slide master** – definuje sdílený design a motiv.
1. **Layout snímek** – definuje konkrétní uspořádání zástupných objektů a formátování na úrovni layoutu.
1. **Normální snímek** – obsahuje skutečný obsah prezentace a používá jeden layout snímek.

![Hierarchie master snímků, layout snímků a normálních snímků](slide-master_2.jpg)

V Aspose.Slides je slide master reprezentován třídou [MasterSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/). Všechny master snímky v prezentaci jsou dostupné přes metodu [Presentation.getMasters](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getMasters), která vrací objekt [MasterSlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Dědičnost" %}}

Když je stejná vlastnost definována na více úrovních, platí specifikovanější úroveň. Například pokud master snímek i layout snímek definují pozadí, snímky založené na tomto layoutu použijí pozadí layoutu. Další informace o layout snímcích najdete v [Apply or Change Slide Layouts](/slides/cs/php-java/slide-layout/).

{{% /alert %}}

## **Přístup k Slide Masterům**

V PowerPointu můžete otevřít zobrazení Slide Master z **Zobrazení** > **Slide Master**.

![Příkaz Slide Master na kartě Zobrazení v PowerPointu](slide-master_3.jpg)

V Aspose.Slides použijte metodu `getMasters` pro přístup k master snímkům:

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

Můžete také získat master snímek použitý normálním snímkem prostřednictvím jeho layoutu:

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

## **Co Slide Master Obsahuje**

Master snímek je objekt podobný snímku. Dědí z [BaseSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/), takže vystavuje mnoho stejných vlastností snímku, které používají normální a layout snímky. Členy specifické pro master jsou popsané na stránce API [MasterSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/).

Často používané členy master snímku zahrnují:

| Člen | Účel |
| --- | --- |
| `getBackground` | Nastavuje pozadí na úrovni master snímku. |
| `getShapes` | Uchovává tvary umístěné na masteru, jako jsou loga, rámečky obrázků a sdílený text. |
| `getLayoutSlides` | Uchovává layout snímky, které patří k masteru. |
| `getThemeManager` | Poskytuje přístup k API motivu masteru. |
| `getHeaderFooterManager` | Řídí záhlaví, zápatí, datum a číslo snímku pro master a jeho podřízené layouty. |
| `getDependingSlides` | Vrací normální snímky, které jsou závislé na masteru skrze své layouty. |

## **Přidání Obrázku do Slide Masteru**

Když přidáte obrázek do master snímku, objeví se na snímcích, které používají layouty z tohoto masteru. To je užitečné pro loga, vodoznaky, dekorativní pruhy a další opakující se vizuální prvky.

Následující příklad přidá logo na první master snímek:

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

## **Práce se Zástupnými Objekty**

Zástupné objekty jsou normálně definovány na layout snímcích. Master snímek poskytuje sdílený styl a motiv, které layouty dědí, zatímco každý layout rozhoduje, které zástupné objekty jsou dostupné a kde jsou umístěny.

V PowerPointu jsou příkazy pro zástupné objekty dostupné v zobrazení Slide Master.

![Příkaz Insert Placeholder v zobrazení Slide Master v PowerPointu](slide-master_5.png)

Pro přidání nových zástupných objektů s Aspose.Slides pracujte s layout snímkem, který patří k masteru:

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

Můžete také formátovat tvary zástupných objektů, které už na master snímku existují. Následující příklad najde zástupný objekt titulku a aplikuje lineární gradientní výplň:

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

![Naformátovaný titulní zástupný objekt zděděný normálními snímky](slide-master_8.png)

Další možnosti formátování zástupných objektů a textu najdete v [Set Prompt Text in Placeholder](/slides/cs/php-java/manage-placeholder/) a [Text Formatting](/slides/cs/php-java/text-formatting/).

## **Změna Pozadí Slide Masteru**

Pozadí masteru je zděděno layouty a snímky, které jej nepřepíšou. Následující příklad nastaví jednotnou barvu pozadí pro první master snímek:

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

Související témata najdete v [Presentation Background](/slides/cs/php-java/presentation-background/) a [Presentation Theme](/slides/cs/php-java/presentation-theme/).

## **Klonování Slide Masteru do Jiné Prezentace**

Použijte `addClone` z [MasterSlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslidecollection/) k zkopírování master snímku do jiné prezentace. Zkopírovaný master pak může být použit layouty a snímky v cílové prezentaci.

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

Pokud potřebujete klonovat normální snímky spolu s jejich masterem, podívejte se na [Clone Slides](/slides/cs/php-java/clone-slides/).

## **Přidání Více Slide Masterů**

Prezentace může obsahovat více master snímků. To je užitečné, když různé sekce vyžadují odlišné brandování, strukturu stránek nebo nastavení motivu.

![Příkazy PowerPointu pro vkládání a správu master snímků](slide-master_9.jpg)

Následující příklad klonuje výchozí master, dá klonu jiné pozadí, vytvoří layout pod tímto klonovaným masterem a přidá nový snímek založený na tomto layoutu:

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

Master snímky lze porovnat pomocí metody `equals`, kterou dědí z [BaseSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/). Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Neshoduje se však s unikátními identifikátory, jako jsou ID snímků, nebo dynamickými hodnotami zástupných objektů, například aktuálním datem.

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

Pro více informací viz [Compare Presentation Slides](/slides/cs/php-java/compare-slides/).

## **Nastavení Slide Master View jako Výchozího Zobrazení**

Použijte metodu `setLastView` na [ViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/) k řízení zobrazení, které PowerPoint otevře jako první. Následující příklad otevře prezentaci v zobrazení Slide Master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Další nastavení zobrazení naleznete v [Save Presentation](/slides/cs/php-java/save-presentation/).

## **Odstranění Nepoužívaných Master Snímků**

Prezentace někdy obsahují master snímky, které již nejsou používány žádnými normálními snímky. Odstraněním nepoužívaných masterů lze snížit velikost souboru a zjednodušit údržbu šablon.

Použijte `removeUnused` z [MasterSlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslidecollection/) k odstranění nepoužívaných masterů ze sbírky `getMasters`:

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

**Jaký je rozdíl mezi slide masterem a layout snímkem?**

Slide master definuje sdílená nastavení designu jako motiv, pozadí, společné tvary a styly textu. Layout snímek patří k masteru a určuje konkrétní uspořádání zástupných objektů. Normální snímek používá layout snímek, takže dědí jak z layoutu, tak z masteru.

**Může jedna prezentace obsahovat několik slide masterů?**

Ano. Prezentace může obsahovat několik master snímků. Použijte více masterů, když různé sekce potřebují odlišné vizuální systémy nebo brandování.

**Mám do master snímku nebo do layout snímku přidávat zástupné objekty?**

Ve většině případů přidávejte zástupné objekty do layout snímků. Na master snímek umístěte sdílené vizuální prvky a formátování, poté na layouty přidejte obsahové zástupné objekty, které použijí normální snímky.

**Mohu odstranit master snímek, který je stále používán?**

Ne. Master snímek, který má závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesuňte tyto snímky na layouty pod jiný master, nebo použijte metodu pro úklid nepoužívaných masterů, která odstraní pouze master snímky, které nejsou v použití.