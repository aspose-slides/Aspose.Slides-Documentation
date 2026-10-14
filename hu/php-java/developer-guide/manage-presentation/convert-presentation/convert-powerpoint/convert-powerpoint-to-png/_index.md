---
title: PowerPoint diák konvertálása PNG-be PHP-ben
linktitle: PowerPoint PNG-re
type: docs
weight: 30
url: /hu/php-java/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint PNG-re
- prezentáció PNG-re
- dia PNG-re
- PPT PNG-re
- PPTX PNG-re
- PPT mentése PNG-ként
- PPTX mentése PNG-ként
- PPT exportálása PNG-be
- PPTX exportálása PNG-be
- PHP
- Aspose.Slides
description: "PowerPoint prezentációkat gyorsan magas minőségű PNG képekké konvertál az Aspose.Slides for PHP Java-on keresztül, biztosítva a pontos, automatizált eredményeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan konvertálhatók a bemutatódiák PNG képekké az Aspose.Slides for PHP via Java használatával. Betöltheti a prezentációkat PPT, PPTX és ODP formátumokban, renderelheti az egyes diát, és külön PNG képként mentheti el.  
Az alábbi példák az alapértelmezett méretezés szerinti renderelést, a méretek növelését, a kimeneti méretek pixelben történő megadását, valamint a gradientes renderelési stílus kiválasztását mutatják be.

## **PowerPoint konvertálása PNG-be**

Töltsön be egy prezentációt a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztállyal, és érje el a diákat a [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) gyűjteményen keresztül. A példában minden diát a [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) paraméter nélküli hívásával rendereljük, hogy bélyegképet kapjunk. Ezután a [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) metódust használjuk a [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) formátummal, hogy az egyes renderelt diák PNG képként legyenek mentve.

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

{{% alert color="info" title="Note" %}}
A paraméter nélküli [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) túlterhelés 0,2‑s méretarányban renderel. Például egy 720 × 540 pont méretű dia 144 × 108 pixeles bélyegképet eredményez. A kimeneti méretek szabályozásához használja a méretarányokkal vagy az alább látható explicit képmérettel rendelkező túlterheléseket.
{{% /alert %}}

## **PowerPoint konvertálása PNG-be egyedi méretekkel**

A vízszintes és függőleges méretarányokat a [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) metódusnak adva szabályozhatja a renderelt méreteket. Ebben a példában mindkét tényező 2, így egy 720 × 540 pont méretű dia 1440 × 1080 pixeles képet eredményez. Azonos méretarányok megőrzik a dia képarányát. Minden képet PNG formátumban mentünk a [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) metódussal.

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

## **PowerPoint konvertálása PNG-be egyedi mérettel**

A kimeneti méretek pixelekben történő megadásához adjon meg egy méretet a [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) metódusnak a méretarányok helyett. Ez a példa minden diát 960 × 720 pixelen renderel, és az eredményt a [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) segítségével menti. Válasszon a dia képarányához illeszkedő méreteket, hogy elkerülje a kép nyújtását.

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

## **Gradient renderelési stílus kiválasztása**

Tegyük fel, hogy egy dia gradient kitöltéseket tartalmaz, de az exportált PNG‑ben a átmenetek világosabbak vagy másképp különböznek attól, amit a PowerPointban lát. A [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) metódust, amely a [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) osztályból öröklődik, használhatja a gradientek renderelésének módjának kiválasztásához.

Töltse le a [gradient-styles.pptx](gradient-styles.pptx) fájlt, és helyezze el az alkalmazás munkakönyvtárában. Az első dia két lineáris gradientet tartalmaz: a tetején cian‑narancs, az alján kék‑sárga átmenettel. Minden gradientnek két színállomása van, 0 % és 100 % ponton.

A következő példa betölti ezt a prezentációt, és a [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) segítségével mindkét módban rendereli az első diát.

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

| Default | PowerPointUI |
| --- | --- |
| ![Cian-narancs és kék-sárga gradientek, Default rendereles](gradient-Default.png) | ![Ugyanazok a gradientek, PowerPointUI rendereles](gradient-PowerPointUI.png) |

Ebben a példában a `Default` világosabb köztes színeket eredményez, míg a `PowerPointUI` sötétebb köztes színeket. A különbség a gradient színeitől és színállomásaitól függ.

Válassza a `Default` beállítást, ha a standard Aspose.Slides kimenet megfelel az igényeinek. Próbálja ki a `PowerPointUI` módot, ha az elsődleges cél a PowerPoint megjelenésével való egyezés. Hasonlítsa össze mindkét kimenetet a kívánt eredménnyel; egyik mód sem általánosan előnyösebb.

## **GYIK**

**Hogyan exportálhatok egy konkrét alakzatot, például diagramot vagy képet, a teljes dia helyett?**  
Az Aspose.Slides támogatja az [egyedi alakzatok bélyegképének generálását](/slides/hu/php-java/create-shape-thumbnails/), amely lehetővé teszi egy alakzat PNG képként történő renderelését.

**Támogatott a párhuzamos konvertálás a szerveren?**  
Igen. Használjon külön prezentációs példányt minden szál vagy folyamat számára; [ne osszon meg egyetlen példányt a szálak között](/slides/hu/php-java/multithreading/).

**Mik azok a kiértékelési korlátozások PNG exportáláskor?**  
A kiértékelési módban vízjel kerül a kimeneti képekre, és [egyéb korlátozások](/slides/hu/php-java/licensing/) érvényesülnek, amíg licencet nem alkalmaznak.