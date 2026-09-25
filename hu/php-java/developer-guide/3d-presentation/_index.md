---
title: 3D Effektek létrehozása prezentációkban PHP használatával
linktitle: 3D Prezentáció
type: docs
weight: 232
url: /hu/php-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentáció
- 3D forgatás
- 3D mélység
- 3D extrúzió
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Alkalmazd és rendereld a 3D hatásokat a PowerPoint alakzatokra és szövegre PHP-ben az Aspose.Slides segítségével. Állíts be kamerát, megvilágítást, anyagot, extrúziót, kitöltéseket és 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java képes elkészíteni, szerkeszteni, megőrizni és megjeleníteni a PowerPoint-szerű 3D formázást alakzatok és szöveg számára. Ez a cikk olyan 3D hatásokat fed le, mint a forgatás, extrúzió, rézszegélyek, megvilágítás, anyag, színátmenetes vagy képpel töltött kitöltés, valamint a 3D szöveg.

{{% alert color="info" title="Note" %}}
Ez a cikk a PowerPoint alakzatok és szöveg 3D formázási hatásairól szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről szól. Amikor egy diát képre, PDF-re vagy HTML-re exportálsz, az Aspose.Slides ezeket a 3D hatásokat a exportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási koncepciók**

Használd a [Shape::getThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getThreeDFormat--) metódust a 3D formázás alkalmazásához egy alakzatra. A metódus visszaadja a [ThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/) objektumot, amely az alakzat 3D jelenetét vezérli.

Szöveg esetén használd a [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#getThreeDFormat--) metódust. Ez a szövegkeretre alkalmazza a 3D formázást, nem pedig az alakzat testére.

A legfontosabb API tagok a következők:

| API tag | Mit vezérel | Mikor használjuk |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getCamera--) | Nézőpont, előre beállított kamera típus, forgatás, nagyítás és perspektíva. | Az objektum forgatása 3D térben vagy egy PowerPoint 3D forgatás előbeállításának egyezése. |
| [getLightRig](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getLightRig--) | Világítás előbeállítás, irány és fény forgatása. | Módosítja, hogy a kiemelések és árnyékok hogyan jelennek meg a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getMaterial--) and [setMaterial](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Felületi anyag, például lapos, matt, műanyag vagy fém. | Azonos geometriát laposabbá, lágyabbá, fényesebbé vagy fémesebbé tenni. |
| [getExtrusionHeight](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getExtrusionHeight--) and [setExtrusionHeight](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Milyen messze nyúlik visszafelé az alakzat az első felületéről. | Egy lapos alakzatot láthatóan vastag 3D objektummá alakít. |
| [getExtrusionColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Az extrudált oldalak színe. | A mélység láthatóvá tétele vagy az oldal színének összehangolása az első kitöltéssel. |
| [getDepth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getDepth--) and [setDepth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#setDepth-double-) | A PowerPoint 3D formázás által használt további 3D mélység. | Finomhangolja a mélységet alakzatok vagy szöveg esetén, különösen a rézszegély és az anyag beállításaival együtt. |
| [getBevelTop](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getBevelTop--) and [getBevelBottom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getBevelBottom--) | Emelkedett vagy lekerekített élek az első és hátsó felületeken. | Lágyabb vagy formázott él hozzáadása ahelyett, hogy éles, lapos felület lenne. |
| [getContourColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getContourColor--) and [getContourWidth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getContourWidth--) and [setContourWidth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Körvonal a 3D objektum körül. | Kiemeli az objektum határát a renderelt kimenetben. |

## **3D alakzat létrehozása**

Egy alakzat általában négyféle beállítást igényel, mielőtt meggyőzően 3D-snek tűnik:

- Kamera beállítások, mert az alapértelmezett elülső nézet elrejtheti az extrudálást.
- Megvilágítási beállítások, mert a fény megjeleníti a felületeket és oldalakat.
- Anyag beállítások, mert a felület befolyásolja, hogyan jelenik meg a fény.
- Extrúzió vagy mélység beállítások, mert egy lapos alakzathoz vastagság szükséges.

A következő példa egy téglalapot hoz létre, szöveget ad az első felületéhez, és alkalmaz 3D formázást. A kamera forgatási értékei fokban vannak, és az extrúzió magassága 100 pont. A példa a diát egy PNG képre rendereli kétszeres alapméretben, és a prezentációt PPTX-ként menti.

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

A renderelt dia kép egy vastag 3D blokk formájában mutatja a téglalapot:

![Renderelt kék 3D téglalap fehér 3D szöveggel az első felületen](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPoint-ban a 3D forgatás a 3-D Forgatás panelen állítható be. Az X, Y és Z forgatási értékek megfelelnek a kamera API-n keresztül beállított forgatásnak.

![PowerPoint 3-D Forgatás panel kiemelt X, Y és Z forgatási értékekkel](img_02_01.png)

Az Aspose.Slides-ban a kamerához a [ThreeDFormat::getCamera](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getCamera--) segítségével férhetsz hozzá. Ez a példa egy téglalapot hoz létre, ortográfiai elülső nézetet választ, és az X, Y és Z forgatásait 20, 30 és 40 fokra állítja. A alakzatot a memóriában konfigurálja a fájl mentése nélkül:

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

A kamerát akkor használod, amikor a néző számára megváltoztatni akarod, hogy úgy lássa az objektumot. Nem változtatja meg a dia 2D alakzatának geometriáját. A PowerPoint és az Aspose.Slides által a renderelés során használt 3D nézőpontot módosítja.

## **Extrúzió és mélység hozzáadása**

Az extrúzió egy alakzatot vastagnak mutat, ha meghosszabbítja a frontális felület mögé. PowerPoint-ban a mélység szabályzó beállítja ezt a látható vastagságot, és a szín szabályzó állítja be az oldalfelületek színét.

![PowerPoint mélység szabályzók leképezve az extrúzió színre és magasságra](img_02_02.png)

A [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) metódussal állítható be a vastagság, a [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getExtrusionColor--) segítségével pedig lekérdezhető az oldal színe. Ez a példa egy 100 pont extrúzióval, lila oldalakkal rendelkező téglalapot ad, és elforgatja a kamerát, hogy látható legyen a vastagsága. Az alakzatot a memóriában konfigurálja a fájl mentése nélkül:

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

A [ThreeDFormat::setDepth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#setDepth-double-) metódus a 3D alakzat mélységét állítja be. A [setExtrusionHeight](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) metódus szabályozza az extrúzió magasságát, ahogyan ez a példában látható.

## **Színátmenetes vagy képes kitöltés használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhatsz egy egyszínű, színátmenetes, mintás vagy képes kitöltést az első felületre, miközben ugyanazokat a kamera, megvilágítás, anyag és extrúzió beállításokat használod.

Ez a példa egy kék‑narancssárga színátmenetet alkalmaz az első felületre és egy sötét narancssárga színt a 150 pontra beállított extrúzióra. A színátmenet megállási pontjai 0 és 100 jelölik a színátmenet kezdetét és végét. A kamera forgatási értékei fokban vannak. A diát egy PNG képre rendereli kétszeres alapméretben:

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

A renderelt kimenet megtartja a színátmenetet az első felületen, és az extrúziót külön rendereli:

![Renderelt 3D téglalap kék‑narancssárga színátmenetes kitöltéssel és narancssárga extrúzióval](img_02_03.png)

A képes kitöltés használatához add hozzá a képet a prezentációhoz, és rendeld hozzá az alakzat kitöltéséhez. Ez a példa egy "image.jpg" nevű fájlt feltételez a munkakönyvtárban. A képet kiterjeszti, hogy kitöltse a téglalapot, 150 pont extrúziót alkalmaz, és fokban állítja be a kamera forgatását. Az alakzatot a memóriában konfigurálja a fájl mentése vagy renderelése nélkül:

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

![Renderelt 3D téglalap fotó kitöltéssel az első felületen és narancssárga extrúzióval](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása az alakzat testére hat. A szöveg 3D formázása a szövegkeretre. Ez hasznos olyan WordArt-szerű hatásokhoz, ahol a betűknek maguknak is szükségük van extrúzióra, anyagra, megvilágításra és kamera beállításokra.

A következő példa egy narancssárga‑fehér rácsmintával rendelkező szöveget hoz létre, felülről íves ívet alkalmaz, és a 3D beállításokat a [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#getThreeDFormat--) segítségével konfigurálja. Az extrúzió magassága és mélysége pontban, a fény forgatása fokban van. Az alakzat kitöltése és körvonala rejtve van, hogy csak a szöveg legyen látható. A példa egy PNG képet renderel kétszeres alapmérettel, és a prezentációt PPTXként menti:

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

![Renderelt 3D szöveg ívelt WordArt átalakítással, narancssárga mintás kitöltéssel és sötét extrúzióval](img_02_05.png)

## **A szöveg sík tartása 3D alakzaton**

A szöveg olvashatóságának megtartásához, miközben az alakzat 3D megjelenését megőrzöd, hívd meg a [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setKeepTextFlat-boolean-) metódust a [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#getTextFrameFormat--) segítségével. Ha az érték `true`, a szöveg kívül marad a 3D jeleneten. Ha `false`, a szöveg részt vesz a jelenetben és követi annak 3D orientációját.

Ez a beállítás nem távolítja el az alakzat 3D formázását: a kamera, megvilágítás, anyag és extrúzió továbbra is a [Shape::getThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getThreeDFormat--) segítségével van beállítva. Emellett különbözik a szokásos forgatástól. A [Shape::setRotation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#setRotation-float-) forgatja az alakzatot a dia síkjában, míg a [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setRotationAngle-float-) szabályozza a szöveg egyéni forgatását a keretén belül. A szöveg 3D jelenetből való kivételével egyik szöget sem állítja vissza.

A következő önálló példa egy kék téglalapot hoz létre szöveggel, és klónozza az eredeti mellett. Mindkét alakzat ugyanazt a 3D formázást kapja; csak a szöveg beállítása eltér: bal oldalon `false`, jobb oldalon `true`. A kamera szögei fokban vannak, és az extrúzió magassága 40 pont. A példa a prezentációt PPTXként menti, és a összehasonlító diát PNG-re rendereli kétszeres alapmérettel.

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

Bal oldalon a szöveg követi a 3D orientációt. Jobb oldalon sík marad, és könnyebben olvasható. Mindkét téglalap ugyanazt a látható extrúziót és 3D orientációt tartja meg.

![Mellékkel elhelyezett 3D téglalapok: a szöveg bal oldalon követi a 3D orientációt, jobb oldalon sík marad](keep_text_flat.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba, például PPTX-be ment. Rendereléskor vagy rögzített elrendezésű formátumokba történő exportáláskor a 3D jelenet raszterizálódik vagy 2D eredményként kerül a kimenetbe. Ez akkor is érvényes, amikor diákat renderelsz [PNG](/slides/hu/php-java/convert-powerpoint-to-png/) formátumba, exportálsz [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/) formátumba, exportálsz [HTML](/slides/hu/php-java/convert-powerpoint-to-html/) formátumba, vagy kereteket generálsz [videó konverzióhoz](/slides/hu/php-java/convert-powerpoint-to-video/).

- Az exportált képek és PDF-ek nem interaktívak. Az objektumot a néző nem tudja elforgatni az export után.
- A végső megjelenés a kamera, megvilágítás, anyag, extrúzió, kitöltés és dia méretezés kombinációjától függ.
- Ha meg kell vizsgálnod az örökölt vagy téma-alapú formázási értékeket, olvasd el a [effective shape properties](/slides/hu/php-java/shape-effective-properties/).
- Egyes kimeneti formátumok nem tudják tárolni a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelve van, nem szerkeszthető 3D beállításként tárolva.

## **GYIK**

**Készíthet‑e az Aspose.Slides interaktív 3D prezentációkat?**

Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D hatásait alakzatok és szöveg számára. Nem teszi interaktív 3D jelenetté az exportált képeket, PDF‑eket vagy HTML oldalakat, amelyeket a néző elforgathat. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPointban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D hatás között?**

Egy 3D modell egy különálló 3D objektum, amely a prezentációba van beszúrva. Egy 3D effektus formázás, amely egy szabályos PowerPoint alakzatra vagy szövegre van alkalmazva, például forgatás, extrúzió, rézszegély, megvilágítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**

Minimum egy kamera forgatás és vagy extrúzió vagy mélység beállítása szükséges. Gyakorlati szempontból érdemes beállítani egy megvilágítást és anyagot is, hogy a renderelt felületeknek világos kiemelései és árnyékai legyenek.

**Alkalmazhatok‑e 3D hatásokat alakzatokra és szövegre egyaránt?**

Igen. Használd a [Shape::getThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getThreeDFormat--) metódust az alakzat testére és a [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#getThreeDFormat--) metódust a szövegre.

**Megjelennek‑e a 3D hatások képek, PDF, HTML vagy videókeretek exportálásakor?**

Igen. Az Aspose.Slides rendereli a 3D hatásokat, amikor diaképeket, PDF kimenetet, HTML kimenetet és videó konverzióhoz használt kereteket állít elő. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Kiolvashatom‑e a végső 3D értékeket az öröklődés és a téma beállítások alkalmazása után?**

Igen. Használd a [Shape Effective Properties](/slides/hu/php-java/shape-effective-properties/) leírt hatékony formázási API‑kat a végső kamera, megvilágítás, rézszegély és kapcsolódó 3D értékek kiolvasásához.