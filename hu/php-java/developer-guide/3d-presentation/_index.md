---
title: 3D hatások létrehozása prezentációkban PHP-vel
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
description: "Alkalmazzon és rendereljen 3D hatásokat PowerPoint alakzatokra és szövegre PHP-ben az Aspose.Slides segítségével. Állítsa be a kamerát, a megvilágítást, az anyagot, az extrúziót, a kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java képes létrehozni, szerkeszteni, megőrizni és megjeleníteni a PowerPoint‑szerű 3D formázást alakzatok és szöveg esetén. Ez a cikk olyan 3D hatásokat fed le, mint a forgatás, extrúzió, lekerekítések, megvilágítás, anyag, színátmenetes vagy képes kitöltések, valamint a 3D szöveg.

{{% alert color="info" title="Note" %}}
Ez a cikk a PowerPoint alakzatok és szöveg 3D formázási hatásairól szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről szól. Amikor egy diát képre, PDF‑re vagy HTML‑re exportál, az Aspose.Slides ezeket a 3D hatásokat az exportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási koncepciók**

Használja a [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) metódust a 3D formázás alkalmazásához egy alakzatra. A metódus visszaad egy [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) objektumot, amely az adott alakzat 3D jelenetét irányítja.

Szöveghez használja a [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) metódust. Ez a 3D formázást a szövegkeretre alkalmazza, nem pedig az alakzat testére.

A legfontosabb API tagok a következők:

| API tag | Mit irányít | Mikor kell használni |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | Nézőpont, előre beállított kamera típus, forgatás, nagyítás és perspektíva. | Az objektum forgatása 3D térben vagy egy PowerPoint 3D forgatási előbeállításnak megfelelően. |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | Fény előbeállítás, irány és fény forgatás. | Megváltoztatja, hogyan jelennek meg a kiemelések és árnyékok a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) és [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | Felületi anyag, például sík, matt, műanyag vagy fém. | Ugyanazt a geometriát laposabbá, lágyabbá, fényesebbé vagy fémesebbé teszi. |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) és [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | Milyen messzire nyúlik ki az alakzat a frontális felületétől hátrafelé. | Lapos alakzatot láthatóan vastag 3D objektummá alakít. |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | Az extrudált oldalak színe. | Mélységet láthatóvá tesz, vagy összehangolja az oldal színét a frontális kitöltéssel. |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) és [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | További 3D mélység, amit a PowerPoint 3D formázás használ. | Finomhangolja a mélységet alakzatok vagy szöveg esetén, különösen a bevel és anyag beállításokkal együtt. |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) és [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | Emelkedett vagy lekerekített élek a frontális és hátuljáró felületeken. | Lágyabb vagy öntött élt ad a határozott lapos felület helyett. |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) és [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) és [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | Körvonal a 3D objektum körül. | Kiemeli az objektum határát a megjelenített kimenetben. |

## **3D alakzat létrehozása**

Egy alakzat általában négyféle beállítást igényel, mielőtt meggyőzően 3D‑nek tűnik:

- Kamera beállítások, mivel az alapértelmezett előnézet elrejtheti az extrúziót.
- Fény beállítások, mert a megvilágítás teszi olvashatóvá a felületeket és oldalakat.
- Anyag beállítások, mivel a felület befolyásolja, hogyan jelenik meg a fény.
- Extrúzió vagy mélység beállítások, mivel egy lapos alakzatnak vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad hozzá az előoldalához, és alkalmaz 3D formázást. A kamera forgatási értékek fokban vannak megadva, az extrúzió magassága 100 pont. A példa a diát PNG képre rendereli, kétszeres alapméretben, és a prezentációt PPTX‑ként menti.

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

A renderelt dia képe a téglalapot vastagnak tűnő 3D blokként mutatja:
![Renderelt kék 3D téglalap fehér 3D szöveggel az előoldalon](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPointban a 3‑D forgatást a 3‑D forgatás panelen állítják be. Az X, Y és Z forgatási értékek megfelelnek a kamera API‑n keresztül beállított forgatásnak.
![PowerPoint 3‑D forgatás panel X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Aspose.Slides‑ben a kamerához a [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) metódussal férhet hozzá. Ez a példa egy téglalapot hoz létre, ortografikus előnézetet választ, és X, Y, Z forgatásait rendre 20, 30 és 40 fokra állítja. A alakzatot memóriában konfigurálja fájl mentése nélkül:

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

Használja a kamerát, ha meg kell változtatni, hogyan látja a néző az objektumot. Nem változtatja meg a 2D alakzat geometriáját a dián. A PowerPoint és az Aspose.Slides által a renderelés során használt 3D nézetpontot módosítja.

### **Kameraorientáció másolása egy sablon alakzatból**

A sablon alakzat orientációjának egyezéséhez olvassa ki a kamera előbeállítását a [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) metódussal, valamint forgatási szögeit a [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation) metódussal. A példa megnyitja a `template.pptx`‑t, és átmásolja a kamera orientációt az első dián lévő első alakzatról a második alakzatra. Mindkét alakzat már rendelkezik 3D megvilágítással, a második alakzatnak pedig nincs kifejezett kamera forgatása.

Az szögek fokban vannak megadva. A `0`‑s index a szélesség, az `1`‑s index a hosszúság, a `2`‑s az forgás. Ezeket ebben a sorrendben adja át a [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) metódusnak. Ha a forrás `null`‑t ad vissza, nincs kifejezett forgatása, ezért hagyja üresen a második alakzat szögeit. A `(0, 0, 0)` kifejezett forgatás három nullát ad vissza, és azt másolni kell.

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

Amikor újra megnyitja a `camera-copy.pptx`‑t PowerPointban, a jobb oldali nyíl ugyanazzal a kamera előbeállítással és forgatással rendelkezik, mint a bal oldali téglalap. Mindkét alakzat ugyanazt a megvilágítást és extrúzió mélységet használja.
![Egy kék 3D téglalap és egy jobbra mutató nyíl egyező kameraorientációval, felülről és jobbról nézve](camera-orientation.png)

## **Extrúzió és mélység hozzáadása**

Az extrúzió egy alakzatot vastagabbá tesz, ha a frontális felület mögé nyújtja. PowerPointban a mélység vezérlő állítja be ezt a látható vastagságot, a szín vezérlő pedig az oldalfelületek színét határozza meg.
![PowerPoint mélység vezérlők leképezve az extrúzió színre és magasságra](img_02_02.png)

Használja a [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) metódust a vastagság beállításához, és a [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) metódust az oldal színének eléréséhez. Ez a példa egy 100 pontos extrúziót ad a téglalapnak lila oldalakkal, és forgatja a kamerát, hogy látható legyen a vastagsága. A alakzatot memóriában konfigurálja fájl mentése nélkül:

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

A [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) metódus beállítja egy 3D alakzat mélységét. A [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) metódus szabályozza az extrúzió hatás magasságát, ahogyan ez a példában látható.

## **Színátmenetes vagy képes kitöltések használata 3D hatásokkal**

A 3D formázás független a alakzat kitöltésétől. Alkalmazhat egy egyszínű, színátmenetes, mintás vagy képes kitöltést az előoldalra, és továbbra is ugyanazokat a kamera, fény, anyag és extrúzió beállításokat használhatja.

Ez a példa kék‑narancssárga színátmenetet alkalmaz az előoldalra, és sötét narancssárga színt a 150 pontos extrúzióra. A színátmenet 0‑nál és 100‑nál áll le, jelezve a kezdést és a végét. A kamera forgatási értékek fokban vannak. A diát PNG képre rendereli kétszeres alapméretben:

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

A renderelt kimenet megőrzi a színátmenetet az előoldalon, és külön rendereli az extrúziót:
![Renderelt 3D téglalap kék‑narancssárga színátmenetes kitöltéssel és narancssárga extrúzióval](img_02_03.png)

A képes kitöltés helyett adja hozzá a képet a prezentációhoz, és rendelje hozzá az alakzat kitöltéséhez. Ez a példa egy `image.jpg` nevű meglévő fájlt igényel a munkakönyvtárban. A képet nyújtja, hogy kitöltse a téglalapot, 150 pontos extrúziót alkalmaz, és fokban állítja be a kamera forgatást. A alakzatot memóriában konfigurálja fájl mentés vagy renderelés nélkül:

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

![Renderelt 3D téglalap foto kitöltéssel az előoldalon és narancssárga extrúzióval](img_02_04.png)

## **3D formázás alkalmazása szövegre**

A alakzat 3D formázása az alakzat testére hat. A szöveg 3D formázása a szövegkeretre hat. Ez hasznos WordArt‑szerű hatásoknál, ahol a betűknek maguknak is szükségük van extrúzióra, anyagra, megvilágításra és kamera beállításokra.

A következő példa egy narancssárga‑fehér rácsmintával rendelkező szöveget hoz létre, felfelé íves hatást alkalmaz, és a 3D beállításokat a [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) segítségével konfigurálja. Az extrúzió magassága és mélysége pontban, a fény forgatása fokban van. Az alakzat kitöltése és kontúrja rejtve van, így csak a szöveg látható. A példa PNG képet renderel kétszeres alapdiamérettel, és PPTX‑ként menti a prezentációt:

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

![Renderelt 3D szöveg íves WordArt transformációval, narancssárga mintás kitöltéssel és sötét extrúzióval](img_02_05.png)

## **Szöveg lapos tartása 3D alakzaton**

A szöveg olvashatóságának megőrzéséhez, miközben az alakzat 3D megjelenését megtartja, hívja meg a [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat) metódust a [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat) segítségével. Ha az érték `true`, a szöveg kívül marad a 3D jeleneten. Ha `false`, a szöveg részt vesz a jelenetben és követi a 3D orientációt.

Ez a beállítás nem távolítja el az alakzat 3D formázását: a kamera, megvilágítás, anyag és extrúzió továbbra is a [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) segítségével van beállítva. Emellett különbözik a szokásos forgatástól. A [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) forgatja az alakzatot a dia síkjában, míg a [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) szabályozza a szöveg egyéni forgatását a határoló keretén belül. A szöveg 3D jelenetből való kivételével egyik szöget sem állítja vissza.

A következő önálló példa egy kék téglalapot hoz létre szöveggel, és az eredeti mellett átmásolja. Mindkét alakzat ugyanazzal a 3D formázással rendelkezik; csak a szöveg beállítás különbözik: bal oldalon `false`, jobb oldalon `true`. A kamera szögek fokban vannak, az extrúzió magassága 40 pont. A példa PPTX‑ként menti a prezentációt, és a összehasonlító diát PNG‑re rendereli kétszeres alapmérettel.

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

![Egymás mellett lévő 3D téglalapok: a szöveg követi a 3D orientációt bal oldalon, és lapos marad jobbon](keep_text_flat.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba, például PPTX‑be ment. Rendereléskor vagy fix elrendezésű formátumokba exportáláskor a 3D jelenet raszterizálódik vagy 2D eredményként kerül a kimenetre. Ez akkor is érvényes, amikor diákat renderel a [PNG](/slides/hu/php-java/convert-powerpoint-to-png/), exportál a [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/), exportál a [HTML](/slides/hu/php-java/convert-powerpoint-to-html/), vagy videó konverzióhoz [video conversion](/slides/hu/php-java/convert-powerpoint-to-video/) kereteket generál.

Tartsa szem előtt a következőket:

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző export után nem tudja elforgatni.
- A végső megjelenés a kamera, a fény rig, anyag, extrúzió, kitöltés és dia méretezés kombinációjától függ.
- Ha meg kell vizsgálnia az örökölt vagy téma‑alapú formázási értékeket, olvassa el a [hatékony alakzattulajdonságok](/slides/hu/php-java/shape-effective-properties/).
- Néhány kimeneti formátum nem képes szerkeszthető PowerPoint 3D formázást tárolni. Ezekben a formátumokban a vizuális eredmény renderelve jelenik meg, nem szerkeszthető 3D beállításként.

## **GYIK**

**Készíthet az Aspose.Slides interaktív 3D prezentációkat?**  
Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D hatásait alakzatok és szöveg számára. Nem teszi interaktívvá az exportált képeket, PDF‑eket vagy HTML‑oldalakat úgy, hogy a néző el tudja forgatni a 3D jelenetet. PPTX‑ben a 3D formázás szerkeszthető marad PowerPointban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D effektus között?**  
Egy 3D modell egy különálló, a prezentációba beszúrt 3D objektum. Egy 3D effektus egy formázás, amelyet egy normál PowerPoint alakzatra vagy szövegre alkalmazunk, például forgatás, extrúzió, bevel, megvilágítás és anyag. Ez a cikk a 3D effektusokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**  
Legkevésbé egy kamera forgatást és vagy extrúziót, vagy mélységet kell beállítani. Gyakorlati esetben érdemes a fény riget és az anyagot is beállítani, hogy a renderelt felületeknek legyenek egyértelmű kiemelései és árnyékai.

**Alkalmazhatok 3D effektusokat alakzatokra és szövegre is?**  
Igen. Az alakzat testére a [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) metódust, a szövegre pedig a [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) metódust kell használni.

**Megjelennek a 3D effektusok képek, PDF, HTML vagy videó keretek exportálásakor?**  
Igen. Az Aspose.Slides a 3D effektusokat rendereli diaképek, PDF, HTML kimenet és videókonverzióhoz használt keretek készítésekor. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Kiolvashatom a végső 3D értékeket az öröklődés és a téma beállítások alkalmazása után?**  
Igen. Használja a hatékony formázási API‑kat, amelyeket a [Alakzat hatékony tulajdonságai](/slides/hu/php-java/shape-effective-properties/) leírása tartalmaz.