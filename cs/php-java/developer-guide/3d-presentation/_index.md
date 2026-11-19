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
description: "Použijte a vykreslete 3D efekty pro tvary a text v PowerPointu v PHP pomocí Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides for PHP via Java může vytvářet, upravovat, zachovávat a vykreslovat PowerPoint‑style 3D formátování pro tvary a text. Tento článek se věnuje 3D efektům, jako jsou rotace, extruze, zkosení, osvětlení, materiál, gradientní nebo obrázkové výplně a 3D text.

{{% alert color="info" title="Poznámka" %}}
Tento článek se zabývá 3D formátovacími efekty na tvarech a textu v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných 3D modelových souborů. Při exportu snímku do obrazu, PDF nebo HTML Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Použijte metodu [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) k aplikaci 3D formátování na tvar. Metoda vrací [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/), který řídí 3D scénu pro daný tvar.

Pro text použijte metodu [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). Tím se použije 3D formátování na textový rámec místo těla tvaru.

Nejdůležitější členové API jsou:

| Člen API | Co řídí | Kdy ho použít |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | Pohled, přednastavený typ kamery, otáčení, zoom a perspektiva. | Otočte objekt ve 3D prostoru nebo odpovídajte přednastavení rotace 3D v PowerPointu. |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | Přednastavení světla, směr a otáčení světla. | Změňte, jak se na 3D povrchu zobrazují zvýraznění a stíny. |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) a [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Udělejte, aby stejná geometrie vypadala plochěji, měkčeji, leskleji nebo kovově. |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) a [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | Jak daleko se tvar rozšiřuje dozadu od své přední plochy. | Proměňte plochý tvar na viditelně tlustý 3D objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | Barva extrudovaných stran. | Zobrazte hloubku nebo sjednoťte barvu stran s předním výplní. |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) a [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | Další 3D hloubka používaná v 3D formátování PowerPointu. | Jemně doladíte hloubku tvarů nebo textu, zejména spolu s nastavením sklonu a materiálu. |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) a [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | Vyzvednuté nebo zaoblené hrany na přední a zadní ploše. | Přidejte změkčený nebo tvarovaný okraj místo ostré ploché strany. |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) a [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) a [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | Obrys kolem 3D objektu. | Zvýrazněte hranice objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři typy nastavení, aby vypadal přesvědčivě 3D:

- Nastavení kamery, protože výchozí přední pohled může skrýt extruzi.
- Nastavení světla, protože osvětlení umožňuje čitelnost ploch a stran.
- Nastavení materiálu, protože povrch ovlivňuje, jak je světlo renderováno.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední plochu a použije 3D formátování. Hodnoty rotace kamery jsou ve stupních a výška extruze je 100 bodů. Příklad vykreslí snímek do PNG obrazu v dvojnásobku výchozích rozměrů a uloží prezentaci jako PPTX.

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

Vykreslený snímek ukazuje obdélník jako tlustý 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední ploše](img_01_01.png)

## **Otočení tvaru pomocí kamery**

V PowerPointu se 3D rotace nastavuje v panelu 3‑D Rotace. Hodnoty rotace X, Y a Z odpovídají rotaci nastavené přes API kamery.

![Panel 3‑D rotace v PowerPointu se zvýrazněnými hodnotami rotace X, Y a Z](img_02_01.png)

V Aspose.Slides přistupujte ke kameře přes [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera). Tento příklad vytvoří obdélník, vybere ortografický přední pohled a nastaví jeho rotace X, Y a Z na 20, 30 a 40 stupňů. Konfigurace probíhá v paměti bez ukládání souboru:

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

Používejte kameru, když potřebujete změnit, jak pozorovatel vidí objekt. Nemění geometrii 2D tvaru na snímku. Mění 3D úhel pohledu, který používá PowerPoint i Aspose.Slides při vykreslování.

### **Zkopírovat orientaci kamery ze šablonového tvaru**

Pro odpovídající orientaci šablonového tvaru přečtěte jeho přednastavení kamery pomocí [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) a úhly rotace pomocí [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation). Příklad otevře `template.pptx` a zkopíruje orientaci kamery z prvního tvaru na první snímku do druhého tvaru. Oba tvary již mají 3D osvětlení a druhý tvar nemá explicitní rotaci kamery.

Úhly jsou ve stupních. Index `0` je zeměpisná šířka, index `1` délka a index `2` revoluce. Předávejte je metodě [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) tímto pořadím. Pokud zdroj vrátí `null`, nemá explicitní rotaci, takže úhly druhého tvaru ponechte nenastavené. Explicitní rotace `(0, 0, 0)` vrací tři nuly a měla by být zkopírována.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $sourceCamera = $shapes->get_Item(0)->getThreeDFormat()->getCamera();
    $destinationCamera = $shapes->get_Item(1)->getThreeDFormat()->getCamera();

    $destinationCamera->setCameraType($sourceCamera->getCameraType());
    $angles = java_values($sourceCamera->getRotation());
    if ($angles !== null) {
        $destinationCamera->setRotation($angles[0], $angles[1], $angles[2]);
    }

    $presentation->save("camera-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Po opětovném otevření `camera-copy.pptx` v PowerPointu má šipka vpravo stejnou přednastavenou kameru a rotaci jako obdélník vlevo. Oba tvary používají stejné osvětlení a hloubku extruze.

![Modrý 3D obdélník a pravá šipka s odpovídající orientací kamery, zobrazena shora a zprava](camera-orientation.png)

## **Přidání extruze a hloubky**

Extruze způsobí, že se tvar jeví jako tlustý tím, že se rozšiřuje za přední plochu. V PowerPointu kontrola hloubky nastavuje tuto viditelnou tloušťku a řízení barvy nastavuje barvu bočních ploch.

![Ovládání hloubky v PowerPointu přiřazené k vlastnostem barvy a výšky extruze](img_02_02.png)

Použijte [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) k nastavení tloušťky a [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) k přístupu k barvě bočních stran. Tento příklad dá obdélníku 100‑bodovou extruzi s fialovými stranami a otočí kameru, aby odhalila jeho tloušťku. Konfigurace probíhá v paměti bez ukládání souboru:

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

Metoda [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) nastavuje hloubku 3D tvaru. Metoda [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) řídí výšku extruze, jak ukazuje tento příklad.

## **Použití gradientových nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete aplikovat plnou barvu, gradient, vzor nebo obrázkovou výplň na přední plochu a stále používat stejné nastavení kamery, světla, materiálu a extruze.

Tento příklad aplikuje gradient od modré k oranžové na přední plochu a tmavě oranžovou barvu na 150‑bodovou extruzi. Gradientové zastávky při 0 a 100 označují začátek a konec gradientu. Hodnoty rotace kamery jsou ve stupních. Snímek je vykreslen do PNG obrazu v dvojnásobku výchozích rozměrů:

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

Vykreslený výstup zachovává gradient na přední ploše a extruze je vykreslena odděleně:

![Vykreslený 3D obdélník s gradientní výplní od modré k oranžové a oranžovou extruzí](img_02_03.png)

Pro použití obrázkové výplně přidejte obrázek do prezentace a přiřaďte ho výplni tvaru. Tento příklad vyžaduje existující soubor s názvem "image.jpg" v pracovním adresáři. Roztažením obrázku vyplníte obdélník, použije se 150‑bodová extruze a nastaví se rotace kamery ve stupních. Konfigurace probíhá v paměti bez ukládání nebo vykreslování souboru:

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

Formátování 3D tvaru ovlivňuje tělo tvaru. Formátování 3D textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s oranžovo‑bílým mřížkovým vzorem, aplikuje obloukový oblouk a nastaví 3D parametry pomocí [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). Výška extruze a hloubka jsou v bodech, otáčení světla ve stupních. Výplň tvaru a obrys jsou skryté, aby byl viditelný pouze text. Příklad vykreslí PNG obraz v dvojnásobku výchozích rozměrů snímku a uloží prezentaci jako PPTX:

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

Text je vykreslen jako zakřivené, extrudované 3D písmo:

![Vykreslený 3D text s obloukovou WordArt transformací, oranžovou vzorovou výplní a tmavou extruzí](img_02_05.png)

## **Udržet text plochý na 3D tvaru**

Pro zachování čitelnosti textu při zachování 3D vzhledu tvaru zavolejte [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat) přes [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat). Když je hodnota `true`, text zůstane mimo 3D scénu. Když je `false`, text se scéně účastní a následuje její 3D orientaci.

Toto nastavení neodstraňuje 3D formátování tvaru: kamera, osvětlení, materiál a extruze zůstávají nastaveny přes [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat). Je to také odlišné od běžné rotace. [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) otáčí tvarem v rovině snímku, zatímco [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) řídí vlastní rotaci textu v jeho ohraničujícím rámečku. Uchování textu mimo 3D scénu resetuje žádný z těchto úhlů.

Následující samostatný příklad vytvoří modrý obdélník s textem a zkopíruje jej vedle originálu. Oba tvary mají stejné 3D formátování; liší se pouze nastavením textu: `false` vlevo a `true` vpravo. Úhly kamery jsou ve stupních a výška extruze je 40 bodů. Příklad uloží prezentaci jako PPTX a vykreslí porovnávací snímek do PNG v dvojnásobku výchozích rozměrů.

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

Vlevo text následuje 3D orientaci. Vpravo zůstává plochý a snadněji čitelný. Oba obdélníky si zachovávají stejnou viditelnou extruzi a 3D orientaci.

![Postranně zobrazené 3D obdélníky: text následuje 3D orientaci vlevo a zůstává plochý vpravo](keep_text_flat.png)

## **Chování exportu a vykreslování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při vykreslování nebo exportu do formátů s pevnou rozlohou se 3D scéna rasterizuje nebo nakreslí do výstupu jako 2D výsledek. To platí při vykreslování snímků do [PNG](/slides/cs/php-java/convert-powerpoint-to-png/), exportu do [PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/), exportu do [HTML](/slides/cs/php-java/convert-powerpoint-to-html/), nebo generování snímků pro [video conversion](/slides/cs/php-java/convert-powerpoint-to-video/).

Mějte na paměti následující body:

- Exportované obrázky a PDF nejsou interaktivní. Objekt není po exportu možné otáčet ve vieweru.
- Konečný vzhled závisí na kombinaci kamery, osvětlení, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete zkontrolovat zděděné nebo na motivu založené hodnoty formátování, přečtěte [efektivní vlastnosti tvaru](/slides/cs/php-java/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech je vizuální výsledek vykreslený místo toho, aby byl uložen jako editovatelné 3D nastavení.

## **Často kladené otázky**

**Může Aspose.Slides vytvářet interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML, které by uživatel mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje tuto funkci.

**Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, jako je rotace, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá 3D efekty.

**Jaká nastavení jsou vyžadována pro viditelný 3D tvar?**

Minimálně nastavte rotaci kamery a buď extruzi, nebo hloubku. V praxi také nastavte osvětlení a materiál, aby měly vykreslené plochy jasné zvýraznění a stíny.

**Mohu aplikovat 3D efekty jak na tvary, tak na text?**

Ano. Použijte [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) pro tělo tvaru a [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) pro text.

**Ukážou se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykresluje 3D efekty při tvorbě obrázků snímků, PDF výstupu, HTML výstupu a snímků používaných pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

**Mohu po aplikování dědictví a motivů přečíst finální 3D hodnoty?**

Ano. Použijte API pro efektivní formátování popsané v [efektivní vlastnosti tvaru](/slides/cs/php-java/shape-effective-properties/), abyste získali finální hodnoty kamery, osvětlení, zkosení a souvisejících 3D parametrů.