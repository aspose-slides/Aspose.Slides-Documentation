---
title: Vykreslit snímky prezentace jako SVG obrázky v PHP
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
- Možnosti exportu SVG
- interaktivní SVG
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Exportujte PowerPoint snímky jako SVG obrázky v PHP a ovládejte písma, text, obrázky, ID a události pomocí Aspose.Slides."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který se dobře hodí pro webové publikování, prohlížeče snímků, workflow přístupnosti a automatické následné zpracování. Aspose.Slides exportuje každý snímek do samostatného souboru SVG a umožňuje vám řídit, jak jsou zapisovány text, písma, obrázky a prvky SVG.

Použijte [SVGOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/) když exportované SVG musí být kompaktní, předvídatelné napříč prohlížeči nebo připravené pro interaktivní použití.

## **Exportovat snímek jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/), vyberte snímek a zapište jej do proudu pomocí [Slide.writeAsSvg](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#writeAsSvg). Následující příklad exportuje každý snímek v prezentaci jako samostatný soubor SVG.

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

Název souboru používá [Slide.getSlideNumber](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getSlideNumber) místo indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [Shape.writeAsSvg](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#writeAsSvg), pokud prohlížeč snímků nebo webová stránka potřebuje pouze tento tvar.

## **Konfigurovat výstup SVG**

[SVGOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/) řídí vykreslování SVG. Pro textové rámečky zahrnuje [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/#setUseFrameSize) textový rámeček do oblasti vykreslování a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/#setUseFrameRotation) určuje, zda se použije otáčení rámečku. Nastavte [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) na `true`, když text musí být vykreslen bez ligatur.

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

## **Řízení textu a písem**

### **Vektorizovat celý text**

Nastavte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/#setVectorizeText) na `true`, aby byl celý text snímku zapisován jako vektorová grafika. Toto eliminuje závislosti na písmech a výsledný vzhled je konzistentnější napříč prohlížeči, ale text již není jako SVG text vybratelný ani prohledávatelný.

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

### **Zvolte způsob zpracování externích písem**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgexternalfontshandling/) pro písma načtená externě. Zvolte `AddLinksToFontFiles` pro odkaz na samostatné soubory písem, `Embed` pro zahrnutí dat písma do SVG, nebo `Vectorize` pro vykreslení pouze textu používajícího externí písma jako grafiky. Před vložením písem ověřte licencování písem.

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

## **Snížit velikost vložených obrázků**

Použijte [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/#setPicturesCompression) pro snížení rozlišení vložených obrázků, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) pro vynechání oříznutých částí zdroje a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/#setJpegQuality) pro řízení kvality JPEG kódování. Tato nastavení snižují velikost souboru na úkor věrnosti obrazu nebo zachovaných dat obrázku.

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

## **Přiřadit stabilní ID tvarům a textu**

Poskytněte formátovací callback metodě [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/#setShapeFormattingController), aby nastavil [SvgShape.setId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgshape/#setId) pro každý SVG tvar. Callback může také nastavit hodnoty [SvgTSpan.setId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgtspan/#setId) na textových prvcích `tspan`.

PhpJavaBridge nemůže zavolat PHP callback z `writeAsSvg`, když běží v režimu proudu. Umístěte logiku formátování do malé Java pomocné třídy, zkompilujte ji a přidejte výsledný JAR soubor do classpath mostu. Pomocná třída může použít [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getOfficeInteropShapeId), který je stabilní po celou životnost tvaru, a opakovatelný čítač pro jeho textové úseky. Viz [Java implementation of `StableSvgIdController`](/slides/cs/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) pro kód pomoci.

Po přidání zkompilované třídy `com.example.slides.StableSvgIdController` do classpath mostu ji vytvořte z PHP a přiřaďte ji k `SVGOptions`:

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

## **Přidat SVG událostní ošetřovače**

Ve formátovacím callbacku zavolejte [SvgShape.setEventHandler](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgshape/#setEventHandler) s hodnotou [SvgEvent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgevent/) pro přidání JavaScriptového událostního ošetřovače k exportovanému tvaru. Callback přiřaďte pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/#setShapeFormattingController) a definujte JavaScriptovou funkci na stránce nebo v SVG dokumentu, který výsledek hostí.

Stejně jako u stabilních ID implementujte callback v Java pomocné třídě, když PhpJavaBridge používá režim proudu. [Java implementation of `SvgEventController`](/slides/cs/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) přiřadí ID a `OnClick` ošetřovač k tvaru pojmenovanému `ActionButton`. Zkompilujte tuto pomocnou třídu, přidejte ji do classpath mostu jako `com.example.slides.SvgEventController` a použijte ji z PHP následujícím způsobem:

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

Hostitelská stránka může definovat JavaScriptovou funkci, na kterou odkazuje ošetřovač. Přiřazení ID a událostních ošetřovačů umožňuje prohlížečům snímků, zlepšení přístupnosti a další interaktivní SVG workflowy.

## **Často kladené otázky**

**Kdy bych měl použít [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/#setVectorizeText) místo [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgexternalfontshandling/)?**

Použijte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/#setVectorizeText), když musí být celý text nezávislý na písmech. Použijte [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgexternalfontshandling/), když by měl být pouze text používající externí písma převeden na grafiku.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, odstraněním oříznutých oblastí obrázků a volbou odkazovaných souborů písem, pokud je cílové prostředí schopno je poskytovat. Otestujte výsledek, protože nižší rozlišení obrázku, nižší kvalita JPEG a vektorizovaný text mají různé kompromisy mezi kvalitou a velikostí.

**Mohu po exportu upravovat exportované SVG elementy?**

Ano. Přidělte ID pomocí formátovacího callbacku a poté vyberte odpovídající SVG elementy ve vašem nástroji pro následné zpracování nebo v skriptu prohlížeče.