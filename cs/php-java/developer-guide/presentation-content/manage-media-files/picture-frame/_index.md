---
title: Správa obrázkových rámů v prezentacích pomocí PHP
linktitle: Obrázkový rám
type: docs
weight: 10
url: /cs/php-java/picture-frame/
keywords:
- obrázkový rám
- přidat obrázkový rám
- vytvořit obrázkový rám
- vložený obrázek
- propojený obrázek
- extrahovat obrázek
- rastrový obrázek
- SVG obrázek
- oříznout obrázek
- smazat ořezané oblasti
- komprimovat obrázek
- StretchOffset
- formátování obrázkového rámu
- relativní měřítko
- efekt obrázku
- poměr stran
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Vytvářejte, formátujte, propojujte, ořezávejte, extrahujte a komprimujte obrázkové rámy v prezentacích pomocí Aspose.Slides pro PHP přes Java."
---
## **Overview**

Obrázkový rám je tvar na snímku, který zobrazuje obrázek. V Aspose.Slides jsou prostředek obrázku a tvar, který jej zobrazuje, samostatné objekty: [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) vlastní vložené prostředky obrázků přes svou [ImageCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagecollection/), zatímco [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) řídí pozici, velikost, formátování čáry, otočení, ořez, efekty obrázku a další nastavení na úrovni rámu.

Toto oddělení je užitečné, když se stejný obrázek zobrazí vícekrát. Přidejte obrázek do prezentace jednou, uchovejte vrácený [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/), a použijte tento prostředek obrázku při vytváření obrázkových rámů.

Obrázkové rámy mohou obsahovat rastrové obrázky, jako jsou PNG nebo JPEG, a vektorové SVG obrázky. Můžou se také odkazovat na propojené obrázky místo ukládání bajtů obrázku do prezentace. Volba ovlivňuje přenositelnost, velikost souboru, extrakci a chování exportu, takže je vhodné rozhodnout, jak má být obrázek uložen, ještě před aplikací formátování nebo optimalizace.

## **Add and Format an Embedded Image**

Pro vložený obrázek přidejte data obrázku do prezentace a vytvořte obrázkový rám pomocí [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addpictureframe/). Obrázek se stane součástí balíčku prezentace, takže prezentace zůstane samostatná, i když je přesunuta na jiný počítač.

Následující příklad přidá JPEG obrázek, vytvoří rám v nativních rozměrech obrázku a použije formátování čáry a otočení:

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

Obrázkový rám řídí zobrazenou geometrii; změna velikosti rámu nemění původní rozměry pixelů uložené ve vloženém prostředku obrázku. Toto rozlišení je důležité při následném ořezávání nebo komprimaci obrázku.

## **Use Relative Scale**

[PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) poskytuje relativní škálování šířky a výšky rámu pomocí [setRelativeScaleWidth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/setrelativescalewidth/) a [setRelativeScaleHeight](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když workflow potřebuje zachovat vztah k velikosti zdrojového obrázku místo ručního výpočtu konečných rozměrů.

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

Relativní měřítko mění nastavení měřítka rámu; nepřevzorkovává ani nekomprimuje vložený obrázek.

## **Embedded and Linked Images**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je proto nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění pomocí metody [Picture::setLinkPathLong](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picture/setlinkpathlong/) místo vložení dat obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat uložených v PPTX, ale zavádějí externí závislost. Propojený soubor musí zůstat přístupný aplikaci, která prezentaci otevírá nebo vykresluje. Pokud se cesta změní, soubor se přesune nebo prostředek není dostupný, může se propojený obrázek nezobrazit podle očekávání. Pro prezentace, které mají být e-mailem odesílány, archivovány nebo vykreslovány v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Add a Linked Image**

Následující příklad vytvoří obrázkový rám a nasměruje jej na lokální soubor obrázku. Zabývá se pouze propojováním obrázků; propojování videa je samostatný mediální workflow a není v tomto příkladu smícháno.

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

Používejte odkazy, když je externí správa souborů úmyslná. Nepoužívejte je jen jako náhradu za kompresi: malý PPTX s poškozenými závislostmi na obrázcích je obvykle méně užitečný než větší samostatná prezentace.

## **Extract Images from Picture Frames**

Před extrakcí obrázku ze stávající prezentace ověřte, že tvar je skutečně [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) a že obsahuje vložený obrázek. Propojené rámce nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

### **Extract a Raster Image**

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

Ukládání pomocí [IImage::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/#save) převádí extrahovaný obrázek do požadovaného výstupního formátu. Pokud potřebujete kódované bajty uložené v prezentaci místo konvertovaného rastrového souboru, použijte binární data prostředku obrázku.

### **Extract an SVG Image**

Pro SVG obrázek [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) poskytuje objekt [SvgImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/). To vám umožní získat data SVG přímo místo rasterizace obrázku nejprve.

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

Uchování obsahu SVG jako SVG zachovává vektorový zdroj uvnitř prezentace. Rasterové exporty jako PNG nebo JPEG nutně renderují tento vektorový obsah do pixelů. Export snímků do PDF nebo SVG je také renderovací operací, takže exportovaná grafika by neměla být považována za bit‑pro‑bit kopii původního vloženého SVG; použijte data [SvgImage::getSvgData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/getsvgdata/) při potřebě samotného vektorového prostředku.

## **Crop an Image**

Ořez mění, která část obrázku je viditelná uvnitř rámu. Hodnoty ořezu na [PictureFillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořezování zpočátku neodstraňuje skryté pixely z vloženého obrázku; pouze mění viditelnou oblast.

Následující příklad bezpečně najde obrázkový rám a použije hodnoty ořezu:

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

Protože skrytá data obrázku jsou stále přítomna, lze ořez později změnit bez ztráty původních pixelů. Pokud je velikost souboru důležitější než možnost vrácení, mohou být ořezané oblasti fyzicky odstraněny, jak je popsáno v další sekci.

## **Remove Cropped Image Data**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací vzniklý prostředek obrázku. To může zmenšit velikost souboru, ale jedná se o destruktivní optimalizaci: po uložení prezentace již odstraněné pixely nejsou k dispozici pro pozdější operaci „uncrop“.

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

Metoda může do prezentace přidat nový prostředek obrázku. Pokud je původní obrázek také používán jinými obrázkovými rámci, tyto rámce stále potřebují svůj existující prostředek, takže mazání ořezaných oblastí nutně nesníží celkový počet obrázků. Ořezávání obsahu WMF nebo EMF touto metodou rasterizuje výsledek do PNG.

## **Compress Raster Images**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) snižuje rozlišení rastrového obrázku relativně k velikosti, při které je obrázek zobrazován. Může také v jedné operaci odstranit ořezané oblasti. Metoda vrací `true`, když byl obrázek změněn velikostí nebo oříznut, a `false`, když nebyla nutná žádná změna.

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

Komprese je určena pro rastrové obrázky. SVG a obsah metafile nejsou tímto rasterovým kompresním workflow zmenšeny. Také si pamatujte, že nižší rozlišení a smazané ořezané oblasti nelze z optimalizované prezentace obnovit. Zvolte cílové rozlišení podle největší velikosti, při které bude obrázek skutečně zobrazen nebo exportován, místo aby se globálně aplikovalo nejnižší DPI.

## **Manage Image Transform Effects**

Kompletní workflow zahrnující jas, kontrast, barevné transformace, rozostření, alfa efekty, řetězce příkazů, inspekci, odstranění a ověření round‑trip najdete v [Image Transform Effects](/php-java/image-transform-effects/).

## **Lock Picture Frame Geometry**

Nastavení [PictureFrameLock](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframelock/) řídí, které editační operace jsou pro obrázkový rám zakázány. Například [setAspectRatioLocked](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) zachovává proporce tvaru při změně velikosti.

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

Zámek platí pro tvar obrázkového rámu. Nenutí zdrojový obrázek být převzorkován ani trvale změněn na stejný poměr stran.

## **Adjust the StretchOffset Values**

Když je režim výplně obrázku nastaven na „stretch“, hodnoty stretch‑offset na [PictureFillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/) definují výplňový obdélník relativně k ohraničujícímu rámečku obrázkového rámu. Kladná procenta vytvářejí vnitřní odsazení od hrany, záporná procenta vytvářejí výstupek.

To se liší od ořezu. Hodnoty ořezu vybírají, která část zdrojového obrázku je viditelná; stretch‑offsety mění obdélník, do kterého je viditelná výplň obrázku roztahována.

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

## **Storage, File Size, and Export Considerations**

Hlavní kompromisy je snazší spravovat, když jsou úložiště obrázků a formátování obrázkových rámů řešeny odděleně:

- **Embedded images** činí prezentaci samostatnou a jsou nejspolehlivější pro sdílení a server‑side vykreslování, ale velké rastrové obrázky zvětšují velikost PPTX a paměťovou náročnost.
- **Linked images** mohou udržet balíček menší, ale prezentace závisí na tom, že externí soubory zůstanou dostupné na uložených cestách nebo místech.
- **Cropping** je zpočátku ne‑destruktivní. Skryté pixely zůstávají vložené, dokud nejsou ořezané oblasti explicitně smazány nebo odstraněny během komprese.
- **Compression** může podstatně zmenšit velikost souboru u převelikých rastrových obrázků, ale snižuje rozlišení zdroje. Měla by být použita po určení zamýšlené velikosti na snímku.
- **SVG images** by měly zůstat jako SVG, když je důležitá zachování vektoru. Vložené SVG extrahujte přímo, když potřebujete samotný vektorový prostředek. Rasterové exporty snímků vždy převádějí vykreslený snímek na pixely.
- **Repeated images** by měly opětovně využívat existující prostředek [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/), pokud je to možné, místo opakovaného načítání stejného souboru do workflow prezentace.

U velkých prezentací je optimalizace obrázků obvykle nejúčinnější, když se provádí selektivně: ponechte loga a diagramy jako vektorový obsah, komprimujte fotografie podle jejich skutečné velikosti zobrazení, odstraňujte ořezané pixely jen když není potřeba další úprava, a vyhněte se externím odkazům, pokud není správa závislostí součástí návrhu nasazení.

## **FAQ**

**What is the difference between a picture frame and an image resource?**

[PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) představuje prostředek obrázku spojený s prezentací. [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) je tvar na snímku, který obrázek zobrazuje a ukládá geometrii a formátování na úrovni rámu, jako jsou velikost, otočení, hodnoty ořezu, efekty a zamčení.

**Should I embed or link images?**

Vkládejte obrázky, když musí být prezentace přenosná, archivovaná nebo vykreslená bez přístupu k externím prostředkům. Propojujte obrázky jen tehdy, když je úmyslné mít soubory obrázků mimo PPTX a externí umístění lze spolehlivě udržovat.

**Does cropping reduce PPTX file size?**

Samotné ořezání ne. Normální nastavení ořezu skrývá části zdrojového obrázku, ale zachovává podkladové pixely. Použijte [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) nebo kompresi obrázku s odstraněním ořezaných oblastí, když lze tyto pixely trvale zrušit.

**Can I restore image quality after compression?**

Ne. Komprese může snížit uložené rasterové rozlišení a odstranění ořezaných oblastí zahazuje data obrázku. Uchovejte originální zdrojový obrázek mimo prezentaci, pokud může být později potřeba úprava v plném rozlišení.

**How should SVG images be handled?**

Uchovávejte SVG obsah jako SVG, když je důležitá vektorová věrnost. Vložený [SvgImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/) lze extrahovat přímo. Rendering snímku do rastrového formátu, jako je PNG nebo JPEG, rasterizuje SVG jako součást obrázku snímku.

**How can I avoid unsafe casts when reading existing slides?**

Zkontrolujte typ tvaru před použitím členů specifických pro obrázkový rám. Kontrola `java_instanceof` vůči [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) zabrání neplatným přetypováním a umožní kódu ošetřit snímky, které neobsahují obrázkové rámy.