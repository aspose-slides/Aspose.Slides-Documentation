---
title: Převod snímků PowerPointu na PNG v PHP
linktitle: PowerPoint na PNG
type: docs
weight: 30
url: /cs/php-java/convert-powerpoint-to-png/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na PNG
- prezentace na PNG
- snímek na PNG
- PPT na PNG
- PPTX na PNG
- uložit PPT jako PNG
- uložit PPTX jako PNG
- exportovat PPT do PNG
- exportovat PPTX do PNG
- PHP
- Aspose.Slides
description: "Převádějte prezentace PowerPoint na vysoce kvalitní PNG obrázky rychle s Aspose.Slides pro PHP přes Java, což zajišťuje přesné a automatizované výsledky."
---
## **Přehled**

Tento článek vysvětluje, jak převést snímky prezentace na obrázky PNG pomocí Aspose.Slides pro PHP přes Java. Můžete načítat prezentace ve formátech jako PPT, PPTX a ODP, vykreslit každý snímek a uložit jej jako samostatný obrázek PNG.

Příklady níže ukazují vykreslování ve výchozím měřítku, zvětšení měřítka, zadání výstupních rozměrů v pixelech a výběr stylu vykreslování gradientu.

## **Převod PowerPointu na PNG**

Načtěte prezentaci pomocí třídy [Prezentace](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) a přistupujte k jejím snímkům skrze kolekci [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides). Příklad vykresluje každý snímek pomocí [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) bez parametrů pro vytvoření miniatury. Poté volá [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) s [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) pro uložení každého vykresleného snímku jako obrázku PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Poznámka" %}}
Parametrický přetížený [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) vykresluje při měřítku 0,2. Například snímek o rozměrech 720 × 540 bodů vytvoří miniaturu 144 × 108 pixelů. Pro řízení výstupních rozměrů použijte přetížené metody s faktory měřítka nebo s explicitní velikostí obrázku, jak je ukázáno níže.
{{% /alert %}}

## **Převod PowerPointu na PNG s vlastním měřítkem**

Předávejte horizontální a vertikální faktory měřítka metodě [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) pro řízení vykreslených rozměrů. V tomto příkladu jsou oba faktory 2, takže snímek o rozměrech 720 — 540 bodů vytvoří obrázek 1440 — 1080 pixelů. Stejné faktory měřítka zachovají poměr stran snímku. Každý obrázek je uložen ve formátu PNG pomocí [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save).

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Převod PowerPointu na PNG s vlastní velikostí**

Pro zadání výstupních rozměrů v pixelech předávejte metodě [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) velikost místo faktorů měřítka. Tento příklad vykresluje každý snímek na 960 — 720 pixelů a výsledek ukládá pomocí [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Zvolte rozměry odpovídající poměru stran snímku, aby nedošlo k roztažení obrázku.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Výběr stylu vykreslování gradientu**

Předpokládejme, že snímek obsahuje gradientní výplně, ale přechody v exportovaném PNG vypadají světleji nebo jinak než v PowerPointu. Můžete použít metodu [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle), která je zděděna třídou [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/), pro výběr způsobu vykreslování gradientů.

Stáhněte soubor [gradient-styles.pptx](gradient-styles.pptx) a umístěte jej do pracovního adresáře aplikace. Jeho první snímek obsahuje dva lineární gradienty: azurově-oranžový v horní části a modro-žlutý ve spodní části. Každý gradient má dva zastávky, při 0 % a 100 %.

Následující příklad načte tuto prezentaci a vykreslí stejný první snímek v obou režimech pomocí [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage).

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Obrázky níže ukazují výstup ze stejného snímku, s gradienty v každém obrázku:

| Default | PowerPointUI |
| --- | --- |
| ![Cyanově-oranžové a modro-žluté gradienty vykreslené pomocí Default](gradient-Default.png) | ![Stejné gradienty vykreslené pomocí PowerPointUI](gradient-PowerPointUI.png) |

V tomto příkladu `Default` vytváří světlejší mezisvětla, zatímco `PowerPointUI` vytváří tmavší mezisvětla. Rozdíl závisí na barvách a zastávkách v gradientu.

Zvolte `Default`, pokud vám vyhovuje standardní výstup Aspose.Slides. Vyzkoušejte `PowerPointUI`, pokud je vaším hlavním cílem shoda s vzhledem v PowerPointu. Porovnejte oba výstupy s požadovaným výsledkem; žádný režim není univerzálně lepší.

## **Často kladené otázky**

**Jak mohu exportovat konkrétní tvar, například graf nebo obrázek, místo celého snímku?**

Aspose.Slides podporuje [vytváření miniatur pro jednotlivé tvary](/slides/cs/php-java/create-shape-thumbnails/), což vám umožní vykreslit tvar jako obrázek PNG.

**Je paralelní převod podporován na serveru?**

Ano. Používejte samostatnou instanci prezentace pro každý vlákno nebo proces; [nesdílejte jednu instanci mezi vlákny](/slides/cs/php-java/multithreading/).

**Jaká jsou omezení evaluace při exportu do PNG?**

Režim evaluace přidává vodoznak do výstupních obrázků a uplatňuje [další omezení](/slides/cs/php-java/licensing/), dokud není nasazena licence.