---
title: Vytvoření 3D efektů v prezentacích pomocí PHP
linktitle: 3D prezentace
type: docs
weight: 232
url: /cs/php-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentace
- 3D rotace
- 3D hloubka
- 3D extruze
- 3D gradient
- 3D text
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Použijte a renderujte 3D efekty pro tvary a text v PowerPointu v PHP s knihovnou Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides for PHP via Java může vytvářet, editovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek pokrývá 3D efekty jako otočení, extruzi, zkosení, osvětlení, materiál, gradientní nebo obrázkové výplně a 3D text.

{{% alert color="info" title="Note" %}}
Tento článek se zabývá efekty 3D formátování na tvary a textu v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných souborů 3D modelů. Při exportu snímku do obrázku, PDF nebo HTML Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Použijte metodu [Shape::getThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getThreeDFormat--) k aplikaci 3D formátování na tvar. Metoda vrací [ThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/), který řídí 3D scénu pro tento tvar.

Pro text použijte metodu [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#getThreeDFormat--) . Tím se aplikuje 3D formátování na textový rámeček místo těla tvaru.

Nejdůležitější členové API jsou:

| Člen API | Co řídí | Kdy jej použít |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getCamera--) | Pohled, přednastavený typ kamery, rotace, přiblížení a perspektiva. | Otočte objekt ve 3D prostoru nebo použijte přednastavený 3D otočný úhel PowerPointu. |
| [getLightRig](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getLightRig--) | Přednastavení světla, směr a rotace světla. | Změňte vzhled zvýraznění a stínů na 3D povrchu. |
| [getMaterial](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getMaterial--) a [setMaterial](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Učinte stejnou geometrii plochější, měkčí, lesklou nebo kovovou. |
| [getExtrusionHeight](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getExtrusionHeight--) a [setExtrusionHeight](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Jak daleko tvar vyčnívá dozadu od své přední plochy. | Přeměňte plochý tvar na viditelně silný 3D objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Barva extrudovaných stran. | Zviditelněte hloubku nebo sladťte barvu stran s přední výplní. |
| [getDepth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getDepth--) a [setDepth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#setDepth-double-) | Další 3D hloubka používaná formátováním 3D v PowerPointu. | Jemně doladit hloubku pro tvary nebo text, zvláště spolu s nastavením zkosení a materiálu. |
| [getBevelTop](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getBevelTop--) a [getBevelBottom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getBevelBottom--) | Zvednuté nebo zaoblené hrany na přední a zadní straně. | Přidejte změkčený nebo formovaný okraj místo ostré ploché stěny. |
| [getContourColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getContourColor--) a [getContourWidth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getContourWidth--) a [setContourWidth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Obrys kolem 3D objektu. | Zvýrazněte hranice objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři typy nastavení, než vypadá věrohodně 3D:

- Nastavení kamery, protože výchozí přední pohled může extruzi skrývat.
- Nastavení světla, protože osvětlení umožňuje čitelnost ploch a stran.
- Nastavení materiálu, protože povrch ovlivňuje, jak je světlo vykresleno.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední plochu a aplikuje 3D formátování. Hodnoty rotace kamery jsou ve stupních a výška extruze je 100 bodů. Příklad vykreslí snímek do PNG obrázku při dvojnásobné výchozí velikosti a uloží prezentaci jako PPTX.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Vykreslený obrázek snímku ukazuje obdélník jako tlustý 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední ploše](img_01_01.png)

## **Otočení tvaru pomocí kamery**

V PowerPointu je 3D otočení nastaveno v panelu 3‑D Rotation. Hodnoty rotace X, Y a Z odpovídají rotaci, kterou nastavíte pomocí API kamery.

![Panel PowerPointu 3‑D Rotation se zvýrazněnými hodnotami rotace X, Y a Z](img_02_01.png)

V Aspose.Slides získáte kameru přes [ThreeDFormat::getCamera](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getCamera--). Tento příklad vytvoří obdélník, vybere ortografický přední pohled a nastaví jeho rotace X, Y a Z na 20, 30 a 40 stupňů. Konfigurace tvaru probíhá v paměti, bez ukládání souboru:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

Používejte kameru, když potřebujete změnit, jak divák vidí objekt. Nemění 2D geometrii tvaru na snímku. Mění jen 3D úhel pohledu, který používá PowerPoint a Aspose.Slides při vykreslování.

## **Přidání extruze a hloubky**

Extruze způsobí, že tvar vypadá tlustě tím, že se prodlouží za přední plochu. V PowerPointu kontrola hloubky nastavuje tuto viditelnou tloušťku a kontrola barvy nastavuje barvu bočních ploch.

![Ovládací prvky hloubky v PowerPointu mapované na vlastnosti barvy extruze a výšky extruze](img_02_02.png)

Pro nastavení tloušťky použijte [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-), a pro přístup k barvě stran [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getExtrusionColor--). Tento příklad dává obdélníku 100‑bodovou extruzi s fialovými stranami a otáčí kameru, aby odhalila jeho tloušťku. Konfigurace tvaru probíhá v paměti, bez ukládání souboru:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

Metoda [ThreeDFormat::setDepth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#setDepth-double-) nastavuje hloubku 3D tvaru. Metoda [setExtrusionHeight](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) řídí výšku efektu extruze, jak je ukázáno v tomto příkladu.

## **Použití gradientních nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete použít jednolitou barvu, gradient, vzor nebo obrázkovou výplň na přední plochu a stále použít stejnou kameru, osvětlení, materiál a nastavení extruze.

Tento příklad aplikuje gradient od modré k oranžové na přední plochu a tmavě oranžovou barvu na 150‑bodovou extruzi. Zastavení gradientu na 0 % a 100 % označují začátek a konec gradientu. Hodnoty rotace kamery jsou ve stupních. Snímek je vykreslen do PNG obrázku při dvojnásobné výchozí velikosti:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Vykreslený výstup zachovává gradient na přední ploše a extruzi vykresluje odděleně:

![Vykreslený 3D obdélník s gradientní výplní od modré k oranžové a oranžovou extruzí](img_02_03.png)

Chcete‑li použít místo toho obrázkovou výplň, přidejte obrázek do prezentace a přiřaďte jej výplni tvaru. Tento příklad předpokládá existující soubor s názvem „image.jpg“ v pracovním adresáři. Obrázek roztáhne tak, aby vyplnil obdélník, aplikuje 150‑bodovou extruzi a nastaví rotaci kamery ve stupních. Konfigurace tvaru probíhá v paměti, bez ukládání nebo vykreslování souboru:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

Obrázek je vykreslen na přední ploše, zatímco extruze je vykreslena jako 3D boční povrch:

![Vykreslený 3D obdélník s fotografickou výplní na přední ploše a oranžovou extruzí](img_02_04.png)

## **Aplikace 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámeček. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s oranžovo‑bílým vzorem mřížky, použije horní oblouk a nastaví 3D parametry přes [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Výška extruze a hloubka jsou v bodech, rotace světla ve stupních. Výplň tvaru i obrys jsou skryté, aby byl viditelný jen text. Příklad vykreslí PNG obrázek při dvojnásobné výchozí velikosti snímku a uloží prezentaci jako PPTX:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Text je vykreslen jako zakřivený, extrudovaný 3D nápis:

![Vykreslený 3D text s zakřivenou WordArt transformací, oranžovou výplní vzoru a tmavou extruzí](img_02_05.png)

## **Udržet text plochý na 3D tvaru**

Aby byl text čitelný a přitom zachovával 3D vzhled tvaru, zavolejte [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#setKeepTextFlat-boolean-) přes [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#getTextFrameFormat--). Když je hodnota `true`, text zůstane mimo 3D scénu. Když je `false`, text se zapojuje do scény a následuje její 3D orientaci.

Toto nastavení neodstraňuje 3D formátování tvaru: jeho kamera, osvětlení, materiál a extruze zůstávají nastaveny přes [Shape::getThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getThreeDFormat--). Je to také odlišné od běžného otáčení. [Shape::setRotation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#setRotation-float-) otáčí tvar v rovině snímku, zatímco [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#setRotationAngle-float-) řídí vlastní rotaci textu v jeho ohraničujícím rámečku. Zachování textu mimo 3D scénu nerestartuje ani jeden z těchto úhlů.

Následující samostatný příklad vytvoří modrý obdélník s textem a zkopíruje jej vedle originálu. Oba tvary mají stejné 3D formátování; liší se jen nastavením textu: `false` vlevo a `true` vpravo. Úhly kamery jsou ve stupních a výška extruze je 40 bodů. Příklad uloží prezentaci jako PPTX a vykreslí srovnávací snímek do PNG při dvojnásobné výchozí velikosti.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Vlevo text sleduje 3D orientaci. Vpravo zůstává plochý a lépe čitelný. Oba obdélníky zachovávají stejnou viditelnou extruzi a 3D orientaci.

![Postranné 3D obdélníky: text sleduje 3D orientaci vlevo a zůstává plochý vpravo](keep_text_flat.png)

## **Chování při exportu a vykreslování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při vykreslování nebo exportu do formátů se pevnou rozlohou je 3D scéna rasterizována nebo nakreslena do výstupu jako 2D výsledek. To platí při vykreslování snímků do [PNG](/slides/cs/php-java/convert-powerpoint-to-png/), exportu do [PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/), exportu do [HTML](/slides/cs/php-java/convert-powerpoint-to-html/) nebo generování snímků pro [konverzi videa](/slides/cs/php-java/convert-powerpoint-to-video/).

Mějte na paměti následující body:

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet.
- Konečný vzhled závisí na kombinaci kamery, osvětlení, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete zjistit zděděné nebo tématem definované hodnoty formátování, přečtěte [efektivní vlastnosti tvaru](/slides/cs/php-java/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech je vizuální výsledek vykreslený místo zachování jako editovatelná 3D nastavení.

## **Často kladené otázky**

**Může Aspose.Slides vytvořit interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML, které by divák mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje úpravy.

** Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, jako je rotace, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá 3D efekty.

** Jaká nastavení jsou vyžadována pro viditelný 3D tvar?**

Minimálně nastavte rotaci kamery a buď extruzi, nebo hloubku. V praxi také nastavte osvětlení a materiál, aby měly vykreslené plochy jasné zvýraznění a stíny.

** Mohu použít 3D efekty jak na tvary, tak na text?**

Ano. Použijte [Shape::getThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getThreeDFormat--) pro tělo tvaru a [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#getThreeDFormat--) pro text.

** Zobrazí se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykreslí 3D efekty při tvorbě obrázků snímků, PDF, HTML výstupu a snímků používaných pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, ne editovatelný 3D objekt.

** Můžu přečíst konečné 3D hodnoty po aplikaci dědičnosti a tématických nastavení?**

Ano. Použijte API efektivního formátování popsané v [Efektivní vlastnosti tvaru](/slides/cs/php-java/shape-effective-properties/), abyste získali konečnou kameru, osvětlení, zkosení a související 3D hodnoty.