---
title: Vytvořte prohlížeč prezentací v PHP
linktitle: Prohlížeč prezentací
type: docs
weight: 50
url: /cs/php-java/presentation-viewer/
keywords:
- zobrazit prezentaci
- prohlížeč prezentací
- vytvořit prohlížeč prezentací
- zobrazit PPT
- zobrazit PPTX
- zobrazit ODP
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Vytvořte vlastní prohlížeč prezentací pomocí Aspose.Slides for PHP via Java. Jednoduše zobrazujte soubory PowerPoint a OpenDocument bez Microsoft PowerPoint."
---
## **Úvod**

Aspose.Slides for PHP via Java se používá k vytváření souborů prezentací se snímky. Tyto snímky lze zobrazit otevřením prezentací v Microsoft PowerPointu, například. Někdy však vývojáři potřebují zobrazit snímky jako obrázky ve svém preferovaném prohlížeči obrázků nebo si vytvořit vlastní prohlížeč prezentací. V takových případech umožňuje Aspose.Slides exportovat jednotlivý snímek jako obrázek. Tento článek popisuje, jak to provést.

## **Generování SVG obrázku ze snímku**

Pro vygenerování SVG obrázku ze snímku prezentace pomocí Aspose.Slides postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
1. Získejte referenci na snímek podle jeho indexu.
1. Otevřete souborový stream.
1. Uložte snímek jako SVG obrázek do souborového streamu.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```

## **Vytvoření SVG s vlastní ID tvaru**

Aspose.Slides lze použít k vytvoření [SVG](https://docs.fileformat.com/page-description-language/svg/) ze snímku s vlastním ID tvaru. K tomu použijte metodu `setId` z [SvgShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` může být použit pro nastavení ID tvaru.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```
```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```

## **Vytvoření miniatury snímku**

Aspose.Slides vám pomáhá generovat miniatury obrázků snímků. Pro vygenerování miniatury snímku pomocí Aspose.Slides postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
1. Získejte referenci na snímek podle jeho indexu.
1. Získejte miniaturu obrázku referencovaného snímku v definovaném měřítku.
1. Uložte miniaturu obrázku v libovolném požadovaném formátu.

```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Vytvoření miniatury snímku s uživatelem definovanými rozměry**

Pro vytvoření miniatury snímku s uživatelem definovanými rozměry postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
1. Získejte referenci na snímek podle jeho indexu.
1. Získejte miniaturu obrázku referencovaného snímku s definovanými rozměry.
1. Uložte miniaturu obrázku v libovolném požadovaném formátu.

```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Vytvoření miniatury snímku s poznámkami ke snímku**

Pro vygenerování miniatury snímku s poznámkami ke snímku pomocí Aspose.Slides postupujte podle následujících kroků:

1. Vytvořte instanci třídy [RenderingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/renderingoptions/) .
1. Použijte metodu `RenderingOptions.setSlidesLayoutOptions` pro nastavení polohy poznámek ke snímku.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
1. Získejte referenci na snímek podle jeho indexu.
1. Získejte miniaturu obrázku referencovaného snímku s nastavenými možnostmi renderování.
1. Uložte miniaturu obrázku v libovolném požadovaném formátu.

```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```

## **Živý příklad**

Můžete vyzkoušet bezplatnou aplikaci [**Aspose.Slides Viewer**](https://products.aspose.app/slides/cs/viewer/) a zjistit, co můžete implementovat pomocí Aspose.Slides API:

![Online PowerPoint prohlížeč](online-PowerPoint-viewer.png)

## **Často kladené otázky**

**Mohu vložit prohlížeč prezentací do webové aplikace?**

Ano. Můžete použít Aspose.Slides na straně serveru k vykreslení snímků jako obrázků nebo HTML a zobrazit je v prohlížeči. Navigační a přiblížovací funkce lze implementovat pomocí JavaScriptu pro interaktivní zážitek.

**Jaký je nejlepší způsob, jak zobrazit snímky v vlastním prohlížeči?**

Doporučený postup je vykreslit každý snímek jako obrázek (např. PNG nebo SVG) nebo jej převést do HTML pomocí Aspose.Slides a poté zobrazit výstup v prvku obrázku (pro desktop) nebo v HTML kontejneru (pro web).

**Jak zacházet s velkými prezentacemi s mnoha snímky?**

U velkých prezentací zvažte lazy-loading nebo vykreslování snímků na vyžádání. To znamená generovat obsah snímku pouze ve chvíli, kdy uživatel na něj přejde, čímž se sníží paměťová náročnost a doba načítání.