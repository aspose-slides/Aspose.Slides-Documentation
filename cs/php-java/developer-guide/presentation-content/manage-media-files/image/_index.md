---
title: Optimalizace správy obrázků v prezentacích pomocí PHP
linktitle: Správa obrázků
type: docs
weight: 10
url: /cs/php-java/image/
keywords:
  - přidat obrázek
  - přidat obrázek
  - nahradit obrázek
  - kolekce obrázků
  - rámeček obrázku
  - odkazovaný obrázek
  - pozadí
  - přidat PNG
  - přidat JPG
  - přidat SVG
  - SVG na tvary
  - externí SVG zdroje
  - PowerPoint
  - OpenDocument
  - prezentace
  - PHP
  - Aspose.Slides
description: "Naučte se, jak přidávat, znovu používat, odkazovat, nahrazovat a spravovat rastrové i SVG obrázky v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java."
---
## **Úvod**

Aspose.Slides pro PHP přes Java poskytuje několik způsobů práce s obrázky a každý slouží jinému účelu. Můžete uložit obrázek v prezentaci, zobrazit jej v rámečku obrázku, použít jej jako pozadí snímku, odkazovat na externí obrázek, nahradit sdílený zdroj obrázku nebo převést obsah SVG na editovatelné tvary.

Tento článek se zaměřuje na zdroje obrázků a jak jsou používány v celé prezentaci. Pro oříznutí, průhlednost, efekty, roztažení a další formátování aplikované na jednotlivý rámeček obrázku viz [Rámeček obrázku](/slides/cs/php-java/picture-frame/).

## **Pochopení modelu obrázku**

- [Kolekce obrázků prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagecollection/) ukládá obrazové zdroje používané v prezentaci. Použijte [ImageCollection::addImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagecollection/) k přidání dat obrázku a získání zdroje [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/).
- [Rámeček obrázku](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) je tvar, který zobrazuje obrázek na snímku, rozložení nebo hlavě. Použijte [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addpictureframe/) k umístění zdroje obrázku na snímek.
- Pozadí snímku používá obrázek jako součást výplně snímku místo tvaru. Proto se nebehová jako rámeček obrázku.
- [PPImage::replaceImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) nahradí zdroj obrázku. Pokud několik prvků prezentace používá tento zdroj, všichni používají náhradu.
- Převod SVG na tvary vytvoří editovatelné tvary snímku. Po převodu není obsah již spravován jako jeden obrázkový zdroj.

Typický postup je tedy: přidat data obrázku do kolekce obrázků, získat [PPImage] a následně použít tento zdroj v jednom nebo více rámečcích obrázků nebo výplních.

## **Přidání vloženého obrázku**

Pro vložení lokálního obrázku načtěte soubor, přidejte jej do kolekce obrázků a vytvořte rámeček obrázku, který používá vrácený `PPImage`.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Obrázek přidaný tímto způsobem je vložen do prezentace, takže výsledný soubor nezávisí na tom, zda je původní soubor obrázku nadále k dispozici.

### **Přidání obrázku z webu**

Když je obrázek dostupný prostřednictvím HTTP nebo HTTPS, stáhněte jeho bajty, přidejte je do kolekce obrázků prezentace a použijte vrácený zdroj obrázku stejným způsobem jako lokální obrázek.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

V dlouhodobých aplikacích opakovaně používejte HTTP klienta nebo strategii správy připojení vhodnou pro aplikaci, namísto opakovaného vytváření zbytečné síťové infrastruktury. Také ověřujte vzdálené URL, velikosti odpovědí a typy obsahu, pokud zdroj není důvěryhodný.

## **Znovupoužití obrázků napříč snímky**

Pokud je stejný obrázek potřeba více než jednou, přidejte jej do prezentace jednou a znovu použijte vrácený [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) při vytváření dalších rámečků obrázku. Tím se vyhnete opakovanému načítání stejných zdrojových dat a vztah mezi sdíleným zdrojem obrázku a jeho použitím se stane explicitním.

Pro grafiku, která by se měla automaticky objevovat na mnoha snímcích, například firemní logo, zvažte umístění rámečku obrázku na [hlavní snímek](/slides/cs/php-java/slide-master/) nebo rozložení místo přidávání ekvivalentního tvaru na každý snímek.

## **Použití obrázku jako pozadí snímku**

Obrázek pozadí je přiřazen k výplni snímku; není přidán jako tvar rámečku obrázku. To je užitečné, když má obrázek pokrýt pozadí snímku a neměl by být manipulován jako běžný objekt snímku.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Další možnosti pozadí, včetně pozadí hlav a rozložení, viz [Pozadí prezentace](/slides/cs/php-java/presentation-background/).

## **Vložené a odkazované obrázky**

Vložené a odkazované obrázky mají odlišné kompromisy v přenositelnosti a velikosti souboru:

- **Vložený obrázek:** data obrázku jsou uložena uvnitř prezentace. Prezentace je samostatná, ale velikost souboru zahrnuje data obrázku.
- **Odkazovaný obrázek:** prezentace ukládá cestu nebo URL k externímu obrázku. To může snížit velikost prezentace, ale externí zdroj musí být přístupný při otevírání nebo vykreslování prezentace.

Odkazovaný obrázek lze vytvořit přiřazením externí cesty nebo URL pomocí [Picture::setLinkPathLong](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picture/) místo vložení dat obrázku.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Používejte odkazované obrázky pouze tehdy, když nasazovací prostředí může spolehlivě přistupovat k externímu zdroji. Pro prezentace, které musí fungovat offline nebo být přesouvány mezi systémy, jsou vložené obrázky obvykle bezpečnější.

## **Práce s SVG obrázky**

SVG je vektorový formát, takže je užitečný pro ikony, diagramy a další grafiku, která by se měla škálovat bez ztráty detailů jako rastrové obrázky. Aspose.Slides podporuje SVG jak jako zdroj obrázku, tak jako zdroj pro editovatelné tvary snímku.

### **Přidání SVG jako obrázku**

Vytvořte [SvgImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/), přidejte jej do kolekce obrázků a umístěte vzniklý zdroj obrázku do rámečku obrázku.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **SVG soubory s externími zdroji**

SVG může odkazovat na externí obrázky, styly nebo fonty. Pro tyto případy [SvgImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/) poskytuje konstruktory, které přijímají [ExternalResourceResolver](https://reference.aspose.com/slides/cs/php-java/aspose.slides/externalresourceresolver/) a základní URI. Resolver může převést relativní URI na povolené absolutní URI a vrátit stream požadovaného zdroje.

Resolver zpřístupní externí zdroje během zpracování SVG v Aspose.Slides, ale nepřepíše SVG na samostatný dokument. Pokud SVG musí zůstat přenosný, vložte požadované zdroje přímo do SVG, například pomocí `data:` URI pro odkazované obrázky.

Když SVG soubory pocházejí z nedůvěryhodných zdrojů, omezte schémata, umístění souborů a hosty, ke kterým může resolver přistupovat. Síťové resolvery by také měly aplikovat časové limity, limity velikosti odpovědi a validaci obsahu.

### **Převod SVG na editovatelné tvary**

Aspose.Slides může převést SVG na skupinu editovatelných tvarů snímku, podobně jako odpovídající příkaz PowerPoint.

![PowerPoint vyskakovací nabídka](img_01_01.png)

Použijte přetížení [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addgroupshape/), které přijímá [SvgImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/), k provedení převodu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Používejte převod SVG na tvary, když je potřeba jednotlivé vektorové elementy upravovat jako tvary PowerPointu. Pokud je potřeba SVG pouze zobrazit, je jednodušší nechat jej jako obrázek a vyhnout se vytváření mnoha samostatných tvarů.

## **Nahrazení existujícího zdroje obrázku**

Použijte [PPImage::replaceImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) když chcete nahradit existující zdroj obrázku. To je obzvláště užitečné pro sdílenou grafiku, jako jsou loga.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pokud několik rámečků obrázků, pozadí, hlav nebo rozložení používá stejný zdroj obrázku, jeho nahrazení aktualizuje všechny tyto použití. Pokud má být změněn jen jeden rámeček obrázku, přiřaďte tomuto rámečku jiný obrázek místo nahrazení sdíleného zdroje.

`PPImage::replaceImage` také poskytuje přetížení, která přijímají pole bajtů nebo jiný [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/).

## **Praktické pokyny pro správu obrázků**

### **Kontrola velikosti prezentace**

Velké rastrové obrázky mohou způsobit zbytečně velkou prezentaci. Používejte zdrojové obrázky s rozměry odpovídajícími zamýšlené velikosti zobrazení, opakovaně využívejte sdílené zdroje obrázků, kde je to možné, a vyhněte se vkládání opakovaných kopií stejné grafiky ve vysokém rozlišení.

Pro rastrové obrázky, které již byly umístěny v rámečcích obrázků, může [PictureFillFormat::compressImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/) snížit data obrázku podle zvolené rozlišení a nastavení ořezu. Jedná se o zpracování rámečku obrázku, nikoli o správu kolekce obrázků, proto viz [Rámeček obrázku](/slides/cs/php-java/picture-frame/) pro související operace formátování.

### **Volba mezi vloženým a odkazovaným obsahem**

Vložení činí prezentaci přenosnou, protože všechna potřebná data obrázku jsou součástí souboru. Odkazování může snížit velikost souboru, ale zavádí externí závislost. Odkazy používejte pouze tehdy, když je tato závislost přijatelná a stabilní.

### **Opakované použití sdílené značky**

Pro opakovaná loga, vodoznaky nebo dekorativní grafiku použijte jeden zdroj obrázku a opakujte jej. Pokud grafika patří do návrhu prezentace spíše než do obsahu snímku, umístěte ji na hlavní snímek nebo rozložení, aby ji dědily příslušné snímky.

### **Udržujte SVG zdroje přenosné**

Samostatný SVG je snazší přesunout a vykreslovat konzistentně než SVG, který závisí na externích souborech nebo síťových zdrojích. Kdy je to možné, vložte požadované zdroje před importem SVG. Převádějte SVG na tvary pouze tehdy, když je potřeba jednotlivé vektorové elementy upravovat.

### **Použijte moderní multiplatformní Image API**

Pro nový kód PHP přes Java použijte Aspose.Slides API [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/) a [Images](https://reference.aspose.com/slides/cs/php-java/aspose.slides/images/) namísto zastaralého veřejného API založeného na `java.awt.image.BufferedImage`. Viz [Moderní API](/slides/cs/php-java/modern-api/) pro pokyny k migraci.

Formáty WMF a EMF vyžadují zvláštní úvahu. Když jsou tyto formáty předány přes [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/), [ImageCollection::addImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagecollection/) převádí metafile na rastrovou PNG reprezentaci před vložením. Pokud je důležité zachovat data metafile, použijte místo toho přetížení [ImageCollection::addImage] založené na streamu. Generování EMF obsahu z tabulek nebo jiných produktů je samostatný integrační postup a není součástí tohoto článku.

## **Časté otázky**

**Jaký je rozdíl mezi kolekcí obrázků a rámečkem obrázku?**

Kolekce obrázků ukládá znovu použitelné zdroje obrázků. Rámeček obrázku je tvar na snímku, který zobrazuje jeden z těchto zdrojů a poskytuje specifické formátování obrázku, jako je ořez a efekty.

**Jaký je nejlepší způsob, jak nahradit stejné logo všude?**

Pokud je logo již sdílené jako jeden zdroj obrázku, nahraďte tento zdroj pomocí [PPImage::replaceImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/). Pro značku napříč celou prezentací může umístění loga na hlavní snímek nebo rozložení také snížit duplicitní obsah snímků.

**Proč odkazovaný obrázek zmizí na jiném počítači?**

Odkazovaný obrázek závisí na externím souboru nebo URL. Pokud tento zdroj není z jiného počítače dosažitelný, odkazovaný obrázek může být nedostupný. Vložte obrázek, když musí být prezentace samostatná.

**Lze vložené SVG upravit jako tvary PowerPointu?**

Ano. Převod SVG pomocí [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addgroupshape/); výsledná skupina obsahuje editovatelné tvary snímku namísto jednoho SVG obrázku.

**Jak mohu udržet prezentace s mnoha obrázky menší?**

Opakovaně používejte sdílené zdroje obrázků, vyhněte se zbytečně velkým rastrovým zdrojům, komprimujte vhodné rastrové obrázky podle potřeby, udržujte opakovanou značku na hlavních snímcích nebo rozloženích a používejte odkazované obrázky pouze tehdy, když je externí závislost přijatelná.