---
title: Spravovat rámy obrázků v prezentacích pomocí PHP
linktitle: Rám obrázku
type: docs
weight: 10
url: /cs/php-java/picture-frame/
keywords:
- rám obrázku
- přidat rám obrázku
- vytvořit rám obrázku
- vložený obrázek
- propojený obrázek
- extrahovat obrázek
- rastrový obrázek
- SVG obrázek
- oříznout obrázek
- smazat ořezané oblasti
- komprimovat obrázek
- StretchOffset
- formátování rámu obrázku
- relativní měřítko
- efekt obrázku
- poměr stran
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Vytvářejte, formátujte, propojujte, ořezávejte, extrahujte a komprimujte rámy obrázků v prezentacích pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Rám obrázku je tvar na snímku, který zobrazuje obrázek. V Aspose.Slides jsou zdroj obrázku a tvar, který jej zobrazuje, oddělené objekty: [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) vlastní vložené zdroje obrázků prostřednictvím své [ImageCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagecollection/), zatímco [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) řídí pozici obrázku, velikost, formátování čar, otáčení, oříznutí, efekty obrázku a další nastavení na úrovni rámu.

Toto oddělení je užitečné, když je stejný obrázek zobrazen vícekrát. Přidejte obrázek do prezentace jednou, uchovejte vrácený [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/), a použijte tento zdroj obrázku při vytváření rámů obrázků.

Rámy obrázků mohou obsahovat rastrové obrázky, jako jsou PNG nebo JPEG, i vektorové SVG obrázky. Mohou také odkazovat na propojené obrázky místo ukládání bajtů obrázku v prezentaci. Volba ovlivňuje přenositelnost, velikost souboru, extrakci a chování při exportu, takže je užitečné rozhodnout, jak má být obrázek uložen, před aplikací formátování nebo optimalizace.

## **Přidání a formátování vloženého obrázku**

Pro vložený obrázek přidejte data obrázku do prezentace a vytvořte rám obrázku pomocí [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addpictureframe/). Obrázek se stane součástí balíčku prezentace, takže prezentace zůstane samostatná při přesunu na jiný počítač.

Následující příklad přidá JPEG obrázek, vytvoří rám v nativních rozměrech obrázku a použije formátování čar a otáčení:

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

Rám obrázku řídí zobrazenou geometrii; změna velikosti rámu nemění původní rozměry pixelů uložené ve vloženém zdroji obrázku. Toto rozlišení se stává důležitým při ořezávání nebo kompresi obrázku později.

## **Použití relativní škály**

[PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) poskytuje relativní škálu šířky a výšky rámu prostřednictvím [setRelativeScaleWidth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/setrelativescalewidth/) a [setRelativeScaleHeight](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní škála je užitečná, když workflow potřebuje zachovat poměr k velikosti zdrojového obrázku místo ručního výpočtu finálních rozměrů.

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

Relativní škála mění nastavení škály rámu; nepřevzorkuje ani nekonprimuje vložený obrázek.

## **Vložené a propojené obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je tak nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění pomocí metody [Picture::setLinkPathLong](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picture/setlinkpathlong/) místo vkládání dat obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat obrázku uložených v PPTX, ale zavádějí externí závislost. Propojený soubor musí zůstat přístupný aplikaci, která prezentaci otevírá nebo vykresluje. Pokud se cesta změní, soubor se přesune nebo zdroj není dostupný, může se propojený obrázek nezobrazit podle očekávání. Pro prezentace, které musí být posílány e‑mailem, archivovány nebo vykreslovány v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Přidání propojeného obrázku**

Následující příklad vytvoří rám obrázku a nasměruje jej na místní soubor obrázku. Zabývá se pouze odkazováním na obrázek; odkazování na video je samostatný workflow a je úmyslně v tomto příkladu nepletené.

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

Používejte odkazy, když je správa externích souborů záměrná. Nepoužívejte je jen jako náhradu za kompresi: malý PPTX s poškozenými závislostmi na obrázcích je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z rámů obrázků**

Před extrahováním obrázku z existující prezentace zkontrolujte, že tvar je skutečně [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) a že obsahuje vložený obrázek. Propojené rámy obrázků nemusí obsahovat bajty obrazu, které lze extrahovat stejným způsobem.

### **Extrahování rastrového obrázku**

Moderní API pro obrázky používá přímo [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/). Následující příklad najde první vložený rastrový obrázek na snímku a uloží jej jako PNG:

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

Ukládání pomocí [IImage::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/#save) převádí extrahovaný obrázek do požadovaného výstupního formátu. Pokud potřebujete kódované bajty uložené v prezentaci místo převedeného rastrového souboru, použijte binární data zdroje obrázku.

### **Extrahování SVG obrázku**

Pro SVG obrázek poskytuje [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) objekt [SvgImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/). To vám umožní získat SVG data přímo místo rasterizace obrázku nejprve.

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

Uchování SVG obsahu jako SVG zachovává vektorový zdroj v prezentaci. Rasterové exporty jako PNG nebo JPEG nutně renderují tento vektorový obsah do pixelů. Export snímku do PDF nebo SVG je také renderovací operace, takže exportovaná grafika by neměla být považována za bit‑podle‑bitovou kopii původního vloženého SVG; použijte data [SvgImage::getSvgData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/getsvgdata/) při potřebě samotného vektorového zdroje.

## **Ořezávání obrázku**

Ořezávání mění, která část obrázku je viditelná uvnitř rámu. Hodnoty ořezu na [PictureFillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořezování počátečně neodstraňuje skryté pixely z vloženého obrázku; pouze mění viditelnou oblast.

Následující příklad bezpečně najde rám obrázku a použije hodnoty ořezu:

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

Protože skrytá data obrázku jsou stále přítomna, lze ořez později změnit, aniž by se ztratily původní pixely. Pokud je velikost souboru důležitější než reverzibilita, lze ořezané oblasti fyzicky odstranit, jak je popsáno v následující sekci.

## **Odstranění ořezaných dat obrázku**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací výsledný zdroj obrázku. To může snížit velikost souboru, ale jedná se o destruktivní optimalizaci: po uložení prezentace již nejsou odstraněné pixely k dispozici pro pozdější ne‑ořez operaci.

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

Metoda může do prezentace přidat nový zdroj obrázku. Pokud je původní obrázek také používán jinými rámy, tyto rámy stále potřebují svůj existující zdroj, takže mazání ořezaných oblastí nutně nesnižuje celkový počet obrázků. Ořezávání obsahu WMF nebo EMF touto metodou rasterizuje ořezaný výsledek do PNG.

## **Kompresi rastrových obrázků**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) snižuje rozlišení rastrových obrázků vzhledem k velikosti, při které je obrázek zobrazen. Může také v téže operaci odstranit ořezané oblasti. Metoda vrací `true`, když byl obrázek změněn velikostí nebo oříznut, a `false`, když žádná změna nebyla potřebná.

Použijte předdefinovanou hodnotu [PicturesCompression](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturescompression/), když stačí standardní cílové rozlišení:

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

Místo předdefinované hodnoty lze zadat vlastní kladnou DPI, pokud je vyžadován konkrétní cíl.

Komprese je určena pro rastrové obrázky. SVG a metafile obsah není touto rasterovou kompresí zmenšen. Také pamatujte, že nižší rozlišení a odstraněné ořezané oblasti nelze z optimalizované prezentace obnovit. Zvolte cílové rozlišení na základě největší velikosti, při které bude obrázek skutečně zobrazen nebo exportován, místo aby se globálně aplikovalo nejnižší DPI.

## **Správa transformačních efektů obrázku**

Pro kompletní workflow zahrnující jas, kontrast, barevné transformace, rozostření, alfa efekty, řetězce, inspekci, odstranění a ověření round‑trip viz [Image Transform Effects](/slides/cs/php-java/image-transform-effects/).

## **Uzamčení geometrie rámu obrázku**

Nastavení [PictureFrameLock](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframelock/) řídí, které editační operace jsou pro rám obrázku zakázány. Například [setAspectRatioLocked](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) zachovává proporce tvaru při jeho změně velikosti.

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

Uzamčení se vztahuje na tvar rámu obrázku. Nevyžaduje, aby byl zdrojový obrázek převeden nebo trvale změněn na stejný poměr stran.

## **Úprava hodnot StretchOffset**

Když je režim výplně obrázku nastaven na „stretch“, hodnoty stretch‑offset na [PictureFillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/) definují výplňový obdélník relativně k ohraničovacímu rámečku rámu obrázku. Kladná procenta vytvářejí vstup z okraje, záporná procenta pak výstup.

To se liší od ořezávání. Hodnoty ořezu vybírají, která část zdrojového obrázku je viditelná; stretch offsety mění obdélník, do kterého je viditelná výplň obrázku natažena.

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

Používejte stretch offsety pro umístění výplně. Používejte vlastnosti ořezu, když je cílem skrýt okraje zdrojového obrázku.

## **Úložiště, velikost souboru a úvahy o exportu**

Hlavní kompromisy jsou snáze říditelné, když je ukládání obrázků a formátování rámu oddělené:

- **Vložené obrázky** činí prezentaci samostatnou a jsou nejspolehlivější pro sdílení a server‑side vykreslování, ale velké rastrové obrázky zvyšují velikost PPTX a spotřebu paměti.
- **Propojené obrázky** mohou udržet balíček menší, ale prezentace závisí na externích souborech, které musí zůstat dostupné na uložených cestách nebo místech.
- **Ořezávání** je zpočátku ne‑destruktivní. Skryté pixely zůstávají vložené, dokud nejsou ořezané oblasti výslovně smazány nebo odstraněny během komprese.
- **Kompresí** lze výrazně snížit velikost souboru u převyšujících rastrových obrázků, ale snižuje se rozlišení zdroje. Měla by být aplikována po určení zamýšlené velikosti na snímku.
- **SVG obrázky** by měly zůstat jako SVG, když je důležitá zachování vektorové podoby. Vložený SVG lze extrahovat přímo, pokud potřebujete samotný vektorový zdroj. Rasterové exporty snímků vždy převádějí vykreslený snímek na pixely.
- **Opakované obrázky** by měly při možnosti znovu použít existující zdroj [PPImage] místo opakovaného načítání stejného souboru do workflow prezentace.

U velkých prezentací je optimalizace obrázků obvykle nejúčinnější, když je prováděna selektivně: ponechejte loga a diagramy jako vektorový obsah, komprimujte fotografie podle jejich skutečné velikosti zobrazení, odstraňujte ořezané pixely jen tehdy, když není potřeba další úpravy, a vyhněte se externím odkazům, pokud není správa závislostí součástí návrhu nasazení.

## **Často kladené otázky**

**Jaký je rozdíl mezi rámem obrázku a zdrojem obrázku?**

[PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) představuje zdroj obrázku spojený s prezentací. [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) je tvar na snímku, který zobrazí obrázek a ukládá geometrické a formátovací informace na úrovni rámu, jako jsou velikost, otáčení, hodnoty ořezu, efekty a uzamčení.

**Mám obrázky vkládat nebo linkovat?**

Vkládejte obrázky, když musí být prezentace přenosná, archivována nebo vykreslována bez přístupu k externím zdrojům. Linkujte obrázky pouze tehdy, když je úmyslné mít soubory mimo PPTX a externí umístění lze spolehlivě udržovat.

**Snižuje ořezávání velikost souboru PPTX?**

Samotné ořezání ne. Normální nastavení ořezu skryje části zdrojového obrázku, ale zachovává podkladové pixely. Použijte [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) nebo kompresi obrázku s odstraněním ořezaných oblastí, když lze tyto pixely trvale odstranit.

**Mohu po kompresi obnovit kvalitu obrázku?**

Ne. Komprese může snížit uložené rozlišení rastrového obrázku a odstranění ořezaných oblastí ztrácí data obrázku. Uchovejte původní zdrojový obrázek mimo prezentaci, pokud může být později potřeba úprava ve vysokém rozlišení.

**Jak mám zacházet s SVG obrázky?**

Uchovávejte SVG obsah jako SVG, když je důležitá vektorová věrnost. Vložený [SvgImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/) lze extrahovat přímo. Rendering snímku do rastrového formátu, jako je PNG nebo JPEG, rasterizuje SVG jako součást obrázku snímku.

**Jak mohu předejít nebezpečným přetypováním při čtení existujících snímků?**

Před použitím členů specifických pro rám obrázku zkontrolujte typ tvaru. Kontrola `java_instanceof` vůči [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) zabrání neplatným přetypováním a umožní kódu zpracovat snímky, které neobsahují rámy obrázků.