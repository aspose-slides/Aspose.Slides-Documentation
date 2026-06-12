---
title: Vytvoření 3D efektů v prezentacích pomocí PHP
linktitle: 3D prezentace
type: docs
weight: 232
url: /cs/php-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentace
- 3D otáčení
- 3D hloubka
- 3D extruze
- 3D gradient
- 3D text
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Použijte a vykreslete 3D efekty pro tvary a text PowerPointu v PHP s Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides pro PHP přes Java může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek se zabývá 3D efekty, jako je otáčení, extruze, zkosení, osvětlení, materiál, výplně gradientem nebo obrázkem a 3D text.

{{% alert color="primary" %}}
Tento článek se týká 3D formátovacích efektů na tvarech a textu v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných souborů 3D modelů. Když exportujete snímek jako obrázek, PDF nebo HTML, Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Koncepty 3D formátování**

Použijte třídu [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/) a její metodu [Shape::getThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getThreeDFormat--) k aplikaci 3D formátování na tvar. Metoda vrací [ThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/), který řídí 3D scénu pro daný tvar.

Pro text použijte třídu [TextFrameFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/) a její metodu [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#getThreeDFormat--) . Tím se použije 3D formátování na textový rámec namísto těla tvaru.

Nejdůležitější nastavení jsou:

| Metoda nebo nastavení | Co ovládá | Kdy ji použít |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getCamera--) | Pohled, přednastavený typ kamery, otáčení, zvětšení a perspektiva. | Otočte objekt ve 3D prostoru nebo odpovídá přednastavenému 3D otočení v PowerPointu. |
| [getLightRig](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getLightRig--) | Přednastavení světla, směr a otáčení světla. | Změňte, jak se na 3D povrchu zobrazují odlesky a stíny. |
| [setMaterial](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Materiál povrchu, například plochý, matný, plastový nebo kovový. | Nechte stejnou geometrii vypadat plochěji, měkčeji, leskleji nebo kovově. |
| [setExtrusionHeight](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Jak daleko se tvar prodlužuje dozadu od své přední plochy. | Přeměňte plochý tvar na viditelně silný 3D objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Barva extrudovaných stran. | Udělejte hloubku viditelnou nebo sladěte barvu stran s přední výplní. |
| [setDepth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#setDepth-double-) | Další 3D hloubka používaná v 3D formátování PowerPointu. | Doladíte hloubku pro tvary nebo text, zejména spolu s nastavením zkosení a materiálu. |
| [getBevelTop](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getBevelTop--) a [getBevelBottom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getBevelBottom--) | Vyzvednuté nebo zakulacené hrany na přední a zadní straně. | Přidejte zjemněnou nebo tvářenou hranu místo ostré ploché strany. |
| [getContourColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getContourColor--) a [setContourWidth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Obrys kolem 3D objektu. | Zdůrazněte hranice objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři typy nastavení, než vypadá přesvědčivě 3D:

- Nastavení kamery, protože výchozí přední pohled může skrýt extruzi.
- Nastavení světla, protože osvětlení umožňuje rozpoznat plochy a strany.
- Nastavení materiálu, protože povrch ovlivňuje, jak je světlo vykresleno.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední stranu, použije 3D formátování, uloží prezentaci jako PPTX a vykreslí snímek do PNG obrázku.

```php
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

Vykreslený obrázek snímku ukazuje obdélník jako silný 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední straně](img_01_01.png)

## **Otáčení tvaru pomocí kamery**

V PowerPointu se 3D otáčení nastavuje v panelu 3‑D Rotation. Hodnoty otáčení X, Y a Z odpovídají otáčení, které nastavíte přes API kamery.

![Panel 3‑D otáčení v PowerPointu se zvýrazněnými hodnotami otáčení X, Y a Z](img_02_01.png)

V Aspose.Slides nastavte typ kamery a otáčení pomocí [ThreeDFormat::getCamera](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getCamera--):

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

Použijte kameru, když potřebujete změnit, jak divák vidí objekt. Nemění 2D geometrii tvaru na snímku. Mění 3D pohled použitého PowerPointem i Aspose.Slides při renderování.

## **Přidání extruze a hloubky**

Extruze způsobí, že tvar vypadá tlustě tím, že se prodlouží za přední plochu. V PowerPointu nastavení hloubky určuje tuto viditelnou tloušťku a nastavení barvy určuje barvu bočních ploch.

![Ovládací prvky hloubky v PowerPointu mapované na barvu extruze a vlastnosti výšky extruze](img_02_02.png)

Nastavte [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) pro tloušťku a [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getExtrusionColor--) pro barvu stran:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

Použijte [ThreeDFormat::setDepth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#setDepth-double-) když potřebujete přímo pracovat s hodnotou hloubky v PowerPointu nebo kombinovat hloubku se zkosením, materiálem a textovými efekty. V mnoha scénářích tvaru je `setExtrusionHeight` přehlednější nastavení, protože přímo vyjadřuje viditelnou extruzi.

## **Použití gradientových nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete na přední stranu aplikovat jednolitou barvu, gradient, vzor nebo obrázkovou výplň a stále použít stejné nastavení kamery, světla, materiálu a extruze.

Tento příklad použije gradientní výplň na tvar a tmavší barvu extruze na strany:

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

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

![Vykreslený 3D obdélník s gradientní výplní od modré po oranžovou a oranžovou extruzí](img_02_03.png)

Pro použití obrázkové výplně místo toho přidejte obrázek do prezentace a přiřaďte jej výplni tvaru:

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

![Vykreslený 3D obdélník s fotografickou výplní na přední straně a oranžovou extruzí](img_02_04.png)

## **Aplikace 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s výplní vzoru, použije transformaci WordArt a nakonfiguruje 3D nastavení na [TextFrameFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/):

```php
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
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
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

![Vykreslený 3D text s zakřivenou WordArt transformací, oranžovou výplní vzoru a tmavou extruzí](img_02_05.png)

## **Chování exportu a renderování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při renderování nebo exportu do formátů s pevnou velikostí se 3D scéna rasterizuje nebo vloží do výstupu jako 2D výsledek. To platí, když renderujete snímky do [PNG](/slides/cs/php-java/convert-powerpoint-to-png/), exportujete do [PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/), exportujete do [HTML](/slides/cs/php-java/convert-powerpoint-to-html/), nebo generujete snímky pro [video conversion](/slides/cs/php-java/convert-powerpoint-to-video/).

Mějte na paměti následující body:

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet.
- Konečný vzhled závisí na kombinaci kamery, světelného rig, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete zkontrolovat zděděné nebo tématem určené hodnoty formátování, přečtěte si [efektivní vlastnosti tvaru](/slides/cs/php-java/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech je vizuální výsledek vykreslen namísto zachování jako editovatelné 3D nastavení.

## **Často kladené otázky**

**Může Aspose.Slides vytvořit interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje 3D efekty PowerPointu pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML stránkách, které by divák mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje úpravy.

**Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, například otáčení, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá 3D efekty.

**Jaká nastavení jsou nutná pro viditelný 3D tvar?**

Minimálně nastavte otáčení kamery a buď extruzi, nebo hloubku. V praxi také nastavte světelný rig a materiál, aby měly vykreslené plochy jasné odlesky a stíny.

**Mohu použít 3D efekty na tvary i text?**

Ano. Použijte [Shape::getThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getThreeDFormat--) pro tělo tvaru a [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#getThreeDFormat--) pro text.

**Objeví se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykreslí 3D efekty při tvorbě obrázků snímků, PDF výstupu, HTML výstupu a snímků používaných pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

**Mohu přečíst konečné 3D hodnoty po aplikaci dědičnosti a nastavení motivu?**

Ano. Použijte API pro efektivní formátování popsané v [Shape Effective Properties](/slides/cs/php-java/shape-effective-properties/), abyste načetli konečnou kameru, světelný rig, zkosení a související 3D hodnoty.