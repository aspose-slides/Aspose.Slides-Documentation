---
title: Správa rámečků obrázků v prezentacích pomocí PHP
linktitle: Rámeček obrázku
type: docs
weight: 10
url: /cs/php-java/picture-frame/
keywords:
- rámeček obrázku
- přidat rámeček obrázku
- vytvořit rámeček obrázku
- vložený obrázek
- propojený obrázek
- extrahovat obrázek
- rastrový obrázek
- SVG obrázek
- oříznout obrázek
- smazat ořezané oblasti
- komprimovat obrázek
- StretchOffset
- formátování rámečku obrázku
- relativní měřítko
- efekt obrázku
- poměr stran
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Vytvářejte, formátujte, propojujte, ořezávejte, extrahujte a komprimujte rámečky obrázků v prezentacích s Aspose.Slides pro PHP pomocí Java."
---
## **Přehled**

Rámeček obrázku je tvar snímku, který zobrazuje obrázek. V Aspose.Slides jsou zdroj obrázku a tvar, který jej zobrazuje, samostatné objekty: [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) vlastní vložené zdroje obrázků prostřednictvím své [ImageCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagecollection/), zatímco [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) řídí pozici obrázku, velikost, formátování čáry, otáčení, oříznutí, efekty obrázku a další nastavení úrovně rámečku.

Toto oddělení je užitečné, když se stejný obrázek zobrazuje vícekrát. Přidejte obrázek do prezentace jednou, uchovejte vrácený [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/), a použijte tento zdroj obrázku při vytváření rámečků obrázků.

Rámečky obrázků mohou obsahovat rastrové obrázky, jako jsou PNG nebo JPEG, a vektorové SVG obrázky. Mohou také odkazovat na propojené obrázky místo uložení bytů obrázku v prezentaci. Volba ovlivňuje přenositelnost, velikost souboru, extrakci i chování při exportu, takže je užitečné se rozhodnout, jak má být obrázek uložen, před aplikací formátování nebo optimalizace.

## **Přidání a formátování vloženého obrázku**

U vloženého obrázku přidejte data obrázku do prezentace a vytvořte rámeček obrázku pomocí [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addpictureframe/). Obrázek se stane součástí balíčku prezentace, takže prezentace zůstane samoobsažná při přesunu na jiný počítač.

Následující příklad přidává JPEG obrázek, vytváří rámeček s nativními rozměry obrázku a aplikuje formátování čáry a otáčení:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Rámeček obrázku řídí zobrazovanou geometrii; změna velikosti rámečku nemění původní rozměry pixelů uložené ve vloženém zdroji obrázku. Tento rozdíl je důležitý při pozdějším ořezávání nebo kompresi obrázku.

## **Použití relativního měřítka**

[PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) nabízí relativní škálování šířky a výšky rámečku prostřednictvím [setRelativeScaleWidth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/setrelativescalewidth/) a [setRelativeScaleHeight](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když workflow potřebuje zachovat vztah k velikosti zdrojového obrázku místo ručního výpočtu konečných rozměrů.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Relativní měřítko mění nastavení měřítka rámečku; neprovádí přeresamplování ani kompresi vloženého obrázku.

## **Vložené a propojené obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je tak nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění pomocí metody [Picture::setLinkPathLong](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picture/setlinkpathlong/) místo vložení dat obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat uložených v PPTX, ale zavádějí externí závislost. Propojený soubor musí zůstávat přístupný aplikaci, která prezentaci otevírá nebo vykresluje. Pokud se cesta změní, soubor je přesunut nebo není dostupný, může se propojený obrázek nezobrazit podle očekávání. Pro prezentace, které mají být e‑mailem zasílány, archivovány nebo vykreslovány v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Přidání propojeného obrázku**

Následující příklad vytvoří rámeček obrázku a nasměruje jej na lokální soubor obrázku. Zabývá se pouze propojením obrázku; propojení videa je samostatný mediální workflow a není v tomto příkladu smícháno.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Používejte odkazy, když je externí správa souborů úmyslná. Nepoužívejte je jen jako náhradu komprese: malý PPTX s nefunkčními závislostmi na obrázcích je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z rámečků obrázků**

Před extrahováním obrázku z existující prezentace ověřte, že tvar je opravdu [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) a že obsahuje vložený obrázek. Propojené rámečky obrázků nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

### **Extrahování rastrového obrázku**

Moderní API obrázku používá přímo [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/). Následující příklad najde první vložený rastrový obrázek na snímku a uloží jej jako PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Ukládání pomocí [IImage::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/#save) převádí extrahovaný obrázek do požadovaného výstupního formátu. Pokud potřebujete bajty uložené v prezentaci místo konvertovaného rastrového souboru, použijte binární data zdroje obrázku.

### **Extrahování SVG obrázku**

U SVG obrázku [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) poskytuje objekt [SvgImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/). Ten vám umožní získat SVG data přímo místo rasterizace obrázku nejprve.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Uchovávání SVG obsahu jako SVG zachovává vektorový zdroj uvnitř prezentace. Rasterové exporty jako PNG nebo JPEG nutně převádějí tento vektorový obsah na pixely. Export snímku do PDF nebo SVG je také operací vykreslování, takže exportovaná grafika by neměla být považována za bit‑k‑bit kopii původního vloženého SVG; použijte data [SvgImage::getSvgData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/getsvgdata/) při požadavku na samotný vektorový zdroj.

## **Ořez obrázku**

Ořez mění, která část obrázku je viditelná uvnitř rámečku. Hodnoty ořezu na [PictureFillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořez zpočátku neodstraňuje skryté pixely z vloženého obrázku; pouze mění viditelnou oblast.

Následující příklad bezpečně najde rámeček obrázku a aplikuje hodnoty ořezu:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Protože skrytá data obrázku jsou stále přítomna, lze ořez později změnit bez ztráty původních pixelů. Pokud je velikost souboru důležitější než reverzibilita, lze ořezané oblasti fyzicky odstranit, jak je popsáno v další sekci.

## **Odstranění ořezaných dat obrázku**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací vzniklý zdroj obrázku. To může snížit velikost souboru, ale jedná se o destruktivní optimalizaci: po uložení prezentace nejsou odstraněné pixely nadále k dispozici pro pozdější operaci uncrop.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Metoda může do prezentace přidat nový zdroj obrázku. Pokud je původní obrázek také používán jinými rámečky, tyto rámečky stále potřebují svůj existující zdroj, takže mazání ořezaných oblastí nutně nesníží celkový počet obrázků. Ořezování WMF nebo EMF pomocí této metody rasterizuje ořezaný výsledek do PNG.

## **Kompresce rastrových obrázků**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) snižuje rozlišení rastrového obrázku relativně k velikosti, při které je obrázek zobrazován. Může také v jednom kroku odstranit ořezané oblasti. Metoda vrací `true`, když byl obrázek změněn velikostí nebo oříznut, a `false`, když změna nebyla nutná.

Použijte předdefinovanou hodnotu [PicturesCompression](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturescompression/), pokud stačí standardní cílové rozlišení:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Místo předdefinované hodnoty lze předat vlastní kladnou hodnotu DPI, když je vyžadován konkrétní cíl.

Komprese je určena pro rastrové obrázky. SVG a obsah metafile nejsou tímto rasterovým workflow zmenšeny. Také si pamatujte, že nižší rozlišení a odstraněné ořezané oblasti nelze z optimalizované prezentace obnovit. Zvolte cílové rozlišení podle největší velikosti, při které bude obrázek skutečně zobrazován nebo exportován, místo použití nejnižšího DPI globálně.

## **Kontrola efektů obrázku**

Efekty obrázku jsou uloženy na obrázku použitém v rámečku. Kolekce transformací obrázku může obsahovat efekty jako pevná alfa modulace pro průhlednost a luminance pro jas a kontrast. Níže uvedený příklad bezpečně čte oba typy efektů z prvního rámečku obrázku na snímku:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $effect = $imageTransform->get_Item($index);

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $transparency = 100 - java_values($effect->getAmount());
                echo "Transparency: " . $transparency . PHP_EOL;
            }

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
                $luminance = $effect->getEffective();
                echo "Brightness: " . java_values($luminance->getBrightness()) . PHP_EOL;
                echo "Contrast: " . java_values($luminance->getContrast()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Tyto efekty mění způsob, jakým je obrázek vykreslen v rámečku; nepřepisují původní bajty vloženého obrázku.

## **Uzamčení geometrie rámečku obrázku**

Nastavení [PictureFrameLock](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframelock/) řídí, které operace úprav jsou pro rámeček obrázku zakázány. Například [setAspectRatioLocked](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) zachovává proporce tvaru při změně velikosti.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Uzamčení se vztahuje na tvar rámečku obrázku. Neznamená to, že by byl zdrojový obrázek přeresamplován nebo trvale změněn na stejný poměr stran.

## **Úprava hodnot StretchOffset**

Když je režim výplně obrázku nastavený na stretch, hodnoty stretch‑offset na [PictureFillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/) definují výplňový obdélník relativně k ohraničující krabici rámečku obrázku. Kladná procenta vytvoří odsazení od okraje, záporná procenta vytvoří přesah.

To se liší od ořezu. Hodnoty ořezu vybírají, která část zdrojového obrázku je viditelná; stretch‑offsety mění obdélník, do kterého se viditelná výplň rozprostírá.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Používejte stretch‑offsety pro umístění výplně. Používejte vlastnosti ořezu, když je cílem skrýt okraje zdrojového obrázku.

## **Úložiště, velikost souboru a úvahy o exportu**

Hlavní kompromisy jsou snazší řídit, když jsou úložiště obrázků a formátování rámečků oddělené:

- **Vložené obrázky** činí prezentaci samostatnou a jsou nejspolehlivější pro sdílení a serverové vykreslování, ale velké rastrové obrázky zvyšují velikost PPTX a paměťovou náročnost.
- **Propojené obrázky** mohou balíček udržet menší, ale prezentace závisí na externích souborech, které musí zůstávat dostupné na uložených cestách nebo umístěních.
- **Ořez** je zpočátku nedestruktivní. Skryté pixely zůstávají vložené, dokud nejsou ořezané oblasti výslovně smazány nebo odstraněny během komprese.
- **Komprese** může výrazně snížit velikost souboru u nadměrných rastrových obrázků, ale obětuje zdrojové rozlišení. Měla by být použita po určení zamýšlené velikosti na snímku.
- **SVG obrázky** by měly zůstat jako SVG, když je důležitá zachování vektoru. Extrahujte vložené SVG přímo, pokud potřebujete samotný vektorový zdroj. Rasterové exporty snímků vždy převádějí vykreslený snímek na pixely.
- **Opakované obrázky** by měly znovu použít existující zdroj [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/), pokud je to možné, místo opakovaného načítání stejného souboru do workflow prezentace.

U velkých prezentací je optimalizace obrázků obvykle nejúčinnější, když se provádí selektivně: loga a diagramy ponechte jako vektorový obsah, komprimujte fotografie podle jejich skutečné zobrazovací velikosti, odstraňujte ořezané pixely jen když následná úprava není vyžadována, a vyhněte se externím odkazům, pokud není správa závislostí součástí návrhu nasazení.

## **Často kladené otázky**

**Jaký je rozdíl mezi rámečkem obrázku a zdrojem obrázku?**

[PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) představuje zdroj obrázku spojený s prezentací. [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) je tvar na snímku, který obrázek zobrazuje a ukládá geometrii a formátování úrovně rámečku, jako jsou velikost, otáčení, hodnoty ořezu, efekty a zámky.

**Mám obrázky vkládat nebo propojovat?**

Vkládejte obrázky, když musí být prezentace přenosná, archivovaná nebo vykreslená bez přístupu k externím zdrojům. Propojujte obrázky jen když je úmyslné mít soubory obrázků mimo PPTX a externí umístění lze spolehlivě udržovat.

**Snižuje ořez velikost souboru PPTX?**

Ne, samotně ne. Normální nastavení ořezu skryje části zdrojového obrázku, ale zachovává podkladové pixely. Použijte [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) nebo kompresi obrázku s odstraněním ořezaných oblastí, když lze tyto pixely trvale odstranit.

**Mohu po kompresi obnovit kvalitu obrázku?**

Ne. Komprese může snížit uložené rastrové rozlišení a odstranění ořezaných oblastí zruší data obrázku. Uchovejte původní zdrojový obrázek mimo prezentaci, pokud může být později potřeba úprava v vysokém rozlišení.

**Jak by se měly zacházet s SVG obrázky?**

Uchovávejte SVG obsah jako SVG, když je důležitá věrnost vektoru. Vložený [SvgImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/) lze extrahovat přímo. Vykreslení snímku do rastrového formátu, jako je PNG nebo JPEG, rasterizuje SVG jako součást obrázku snímku.

**Jak se vyhnout nebezpečným přetypováním při čtení existujících snímků?**

Zkontrolujte typ tvaru před použitím členů specifických pro rámeček obrázku. Kontrola `java_instanceof` proti [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) zabrání neplatným přetypováním a umožní kódu zvládnout snímky, které neobsahují rámečky obrázků.