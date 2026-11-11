---
title: Vykreslení snímků prezentace jako SVG obrázky v PHP
linktitle: Snímek do SVG
type: docs
weight: 50
url: /cs/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint do SVG
- prezentace do SVG
- snímek do SVG
- PPT do SVG
- PPTX do SVG
- volby exportu SVG
- interaktivní SVG
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Exportujte snímky PowerPointu jako SVG obrázky v PHP a pomocí Aspose.Slides ovládejte písma, text, obrázky, ID a události."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který se výborně hodí pro webové publikování, prohlížeče prezentací, workflow přístupnosti i automatické post‑zpracování. Aspose.Slides exportuje každou snímek do samostatného souboru SVG a umožňuje řídit, jak jsou zapisovány text, písma, obrázky a prvky SVG.

Použijte [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/), pokud musí být exportované SVG kompaktní, předvídatelné napříč prohlížeči nebo připravené k interaktivnímu použití.

## **Export snímku jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), vyberte snímek a zapište jej do proudu pomocí [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg). Následující příklad exportuje každý snímek v prezentaci jako samostatný soubor SVG.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Název souboru používá [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) namísto indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg), pokud prohlížeč snímků nebo webová stránka potřebuje jen tento tvar.

## **Konfigurace výstupu SVG**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) řídí vykreslování SVG. Pro textové rámečky zahrnuje [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) textový rámeček do oblasti vykreslování a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) určuje, zda se použije otočení rámečku. Nastavte [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) na `true`, když musí být text vykreslen bez ligatur.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Řízení ořezávání konců čar u šipek**

SVG 1.1 nemá nastavení vnitřního posunutí značky, které by určovalo, kde má čára končit pod špičkou šipky. Ve výchozím stavu Aspose.Slides zkracuje exportovanou čáru, aby její tah nevyčníval přes značku. Zavolejte [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) s hodnotou `true`, aby se tah kreslil až po původní koncový bod čáry. Toto nastavení ovlivňuje jen výstup SVG. Čára si zachová svou pozici a délku na snímku.

Příklad vykresluje trojúhelníkové a diamantové šipky na čárach o šířce 2 a 10 bodů. Exportuje stejný snímek dvakrát, mění pouze volbu ořezávání.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

Porovnání ukazuje trojúhelníkovou šipku na 10‑bodové čáře. Při povoleném ořezávání je špička ostrá. Při zakázaném ořezávání tah vyčnívá přes šikmé strany značky a zůstává plochý konec.

![Zvětšený 10‑bodový trojúhelník s ostrou špičkou při povoleném ořezávání a plochým koncem při zakázaném ořezávání](line-end-cropping.png)

U ostatních čar v příkladu je vyčnívající tah méně viditelný na 2‑bodovém trojúhelníku. Vyplněný diamant zakrývá konec tahu u obou šířek.

## **Řízení textu a písem**

Při exportu snímků do SVG můžete řídit, zda text zůstane jako text nebo bude převeden na vektorovou grafiku, a jak jsou zahrnuta nebo odkazována externí písma. Následující možnosti vám pomohou vyvážit vizuální konzistenci, výběr textu a závislosti na písmu v exportovaném SVG.

### **Vektorizovat celý text**

Nastavte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) na `true`, aby se celý text snímku zapisoval jako vektorová grafika. Tím se eliminuje závislost na písmu a výsledek je vizuálně konzistentnější napříč prohlížeči, ale text již není možné vybírat ani vyhledávat jako SVG‑text.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **Zvolte, jak se zacházejí s externími písmy**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) pro písma načítaná externě. Vyberte `AddLinksToFontFiles` pro odkazování na samostatné soubory písem, `Embed` pro zahrnutí dat písma do SVG, nebo `Vectorize` pro vykreslení pouze textu používajícího externí písma jako grafiky. Před embedováním ověřte licenční podmínky písem.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Redukce velikosti vložených obrázků**

Použijte [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) ke snížení rozlišení vložených obrázků, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) k vynechání oříznutých částí zdrojových obrázků a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) k řízení kvality JPEG komprese. Tato nastavení snižují velikost souboru na úkor kvality obrazu nebo zachování dat obrázku.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Řízení rozlišení rasterizace metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) nastavuje spodní limit rozlišení pro rasterizaci metafile během exportu SVG. Použijte jej pro vyvážení detailu a velikosti souboru, když je rasterizován obrázek EMF nebo WMF. Nedefinuje globální DPI pro SVG ani nenutí každý objekt na snímku stát se rastrovým obrázkem.

Stáhněte [metafile-rasterization.pptx](metafile-rasterization.pptx), který obsahuje EMF obrázek s úzce umístěnými úhlopříčnými čarami. Následující příklad exportuje první snímek při třech rozlišeních rasterizace pomocí [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). Všechna ostatní nastavení exportu zůstávají stejné, aby bylo možné výsledky porovnat.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

Ve výstupu se EMF změnilo na jeden vložený PNG v každém SVG. Následující měření se vztahují k dodané prezentaci; nejsou obecným vzorcem pro převod DPI na rozměry v pixelech.

| Rozlišení rasterizace metafile (DPI) | Rozměry vloženého PNG | Velikost souboru SVG (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Porovnání níže ukazuje stejnou oblast vloženého rastrového obrázku při stejném zvětšeném zobrazení. Úhlopříčné čáry vykazují viditelnou pixelaci při 72 DPI a hladší hrany při vyšších rozlišeních, přičemž soubor SVG roste. Zvýšení hodnoty nutně neznamená zlepšení každého detailu ani změnu každého exportovaného obrázku.

![Zvětšený detail úhlopříčné čáry při 72, 150 a 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) řídí redukci rozlišení obrázku a může zakrýt efekt změny rozlišení rasterizace metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) řídí kvalitu JPEG komprese, nikoli rozlišení rasterizace metafile.

## **Přiřazení stabilních ID tvarům a textu**

Poskytněte formátovací callback metodě [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController), aby nastavil [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) pro každý SVG tvar. Callback může také nastavit hodnoty [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) na textových elementech `tspan`.

PhpJavaBridge nemůže vyvolat PHP callback z `writeAsSvg`, když běží v režimu proudu. Vložte logiku formátování do malé pomocné třídy v Javě, zkompilujte ji a přidejte vzniklý JAR soubor do classpath mostu. Pomocná třída může použít [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId), který je stabilní po celou dobu existence tvaru, a opakovatelný čítač pro jeho textové úseky. Viz [Java implementace `StableSvgIdController`](/slides/cs/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) pro kód pomocníka.

Po přidání zkompilované třídy `com.example.slides.StableSvgIdController` do classpath mostu ji z PHP vytvořte a přiřaďte k `SVGOptions`:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Přidání SVG událostních handlerů**

Ve formátovacím callbacku zavolejte [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) s hodnotou [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/), aby se k exportovanému tvaru přidal JavaScriptový událostní handler. Callback přiřaďte pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) a definujte JavaScriptovou funkci v stránce nebo SVG dokumentu, který výsledek hostí.

Stejně jako u stabilních ID implementujte callback v Javě, pokud PhpJavaBridge používá režim proudu. [Java implementace `SvgEventController`](/slides/cs/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) přiřadí ID a handler `OnClick` k tvaru pojmenovanému `ActionButton`. Zkompilujte tento pomocník, přidejte jej do classpath mostu jako `com.example.slides.SvgEventController` a použijte jej z PHP následovně:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

Hostitelská stránka může definovat JavaScriptovou funkci odkazovanou handlerem. Přiřazení ID a událostních handlerů umožňuje prohlížeče snímků, vylepšení přístupnosti a další interaktivní SVG workflowy.

## **Časté dotazy**

**Kdy bych měl použít [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) místo [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

Použijte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText), když musí být veškerý text nezávislý na písmu. Použijte [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/), když by měl být vektorován jen text, který používá externí písma.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, odstraněním oříznutých oblastí obrázků a zvolením odkazovaných souborů písem, pokud je cílové prostředí schopno je poskytovat. Otestujte výsledek, protože nižší rozlišení obrázku, nižší kvalita JPEG a vektorizovaný text mají různé kompromisy mezi kvalitou a velikostí.

**Mohu po exportu SVG prvky upravovat?**

Ano. Přiřaďte ID pomocí formátovacího callbacku a poté vyberte odpovídající SVG prvky ve vašem nástroji post‑zpracování nebo v browser skriptu.