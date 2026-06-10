---
title: 3D hatások létrehozása prezentációkban PHP-vel
linktitle: 3D prezentáció
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
description: "Alkalmazza és renderelje a 3D hatásokat PowerPoint alakzatokra és szövegre PHP-ben az Aspose.Slides segítségével. Állítsa be a kamerát, világítást, anyagot, extrúziót, kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java képes létrehozni, szerkeszteni, megőrizni és renderelni a PowerPoint‑szerű 3D formázást alakzatokra és szövegre. Ez a cikk a 3D hatásokat tárgyalja, például a forgatást, extrúziót, rézsút, világítást, anyagot, színátmenetes vagy képtöltést, valamint a 3D szöveget.

{{% alert color="primary" %}}
Ez a cikk a PowerPoint alakzatok és szövegek 3D formázási hatásairól szól. Nem az önálló 3D modellfájlok beszúrásáról vagy szerkesztéséről. Amikor egy diát képre, PDF‑re vagy HTML‑re exportál, az Aspose.Slides ezeket a 3D hatásokat a exportált 2D kimenetben rendereli.
{{% /alert %}}

## **3D formázási koncepciók**

Használja a [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) osztályt és a [Shape::getThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getThreeDFormat--) metódust a 3D formázás alkalmazásához egy alakzatra. A metódus egy [ThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/) objektumot ad vissza, amely az adott alakzat 3D jelenetét irányítja.

Szöveg esetén használja a [TextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/) osztályt és a [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#getThreeDFormat--) metódust. Ez a szövegkeretre alkalmaz 3D formázást a forma testének helyett.

A legfontosabb beállítások:

| Metódus vagy beállítás | Mit szabályoz | Mikor kell használni |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getCamera--) | Nézőpont, előre beállított kamera típus, forgatás, nagyítás és perspektíva. | Az objektum forgatása 3D térben vagy egy PowerPoint 3D forgatási előbeállítás használata. |
| [getLightRig](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getLightRig--) | Fény előbeállítás, irány és fény forgatás. | Megváltoztatja, hogyan jelennek meg a fénycsúcsok és árnyékok a 3D felületen. |
| [setMaterial](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Felület anyaga, például sima, matt, műanyag vagy fém. | Ugyanazt a geometriát laposabbá, puhábbá, fényesebbé vagy fémivé teszi. |
| [setExtrusionHeight](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Milyen messze nyúlik visszafelé az alakzat az első felületétől. | Egy sík alakzatot láthatóan vastag 3D objektummá alakít. |
| [getExtrusionColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Az extrudált oldalak színe. | Mélységet láthatóvá teszi vagy összhangot teremt az oldalszín és az első felület töltése között. |
| [setDepth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#setDepth-double-) | További 3D mélység, amelyet a PowerPoint 3D formázás használ. | Finomhangolja a mélységet alakzatok vagy szöveg esetén, különösen a rézsút és anyag beállításokkal együtt. |
| [getBevelTop](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getBevelTop--) és [getBevelBottom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getBevelBottom--) | Emelt vagy lekerekített élek az első és hátsó felületeken. | Lágyabb vagy formázott szegély hozzáadása egy éles sík felület helyett. |
| [getContourColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getContourColor--) és [setContourWidth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Körvonal a 3D objektum körül. | Kiemeli az objektum határát a renderelt kimenetben. |

## **3D alakzat létrehozása**

Egy alakzathoz általában négy típusú beállításra van szükség, mielőtt meggyőzően 3D‑snek tűnik:

- Kamera beállítások, mivel az alapértelmezett előnézet elrejtheti az extrudálást.
- Fény beállítások, mivel a világítás teszi olvashatóvá az felületeket és oldalakat.
- Anyag beállítások, mivel a felület befolyásolja, hogyan jelenik meg a fény.
- Extrúzió vagy mélység beállítások, mivel egy sík alakzathoz vastagságra van szükség.

Az alábbi példa egy téglalapot hoz létre, szöveget ad az első felülethez, 3D formázást alkalmaz, PPTX‑ként menti a prezentációt, és a diát PNG képre rendereli.

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

A renderelt diakép a téglalapot egy vastag 3D blokkként mutatja:

![Renderelt kék 3D téglalap fehér 3D szöveggel az első felületen](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPointban a 3D forgatást a 3‑D forgatás panelből konfigurálják. Az X, Y és Z forgatási értékek megfelelnek a kamera API‑n keresztül beállított forgatásnak.

![PowerPoint 3‑D forgatás panel X, Y és Z forgatási értékek kiemelésével](img_02_01.png)

Aspose.Slides‑ben a kamera típusát és forgatását a [ThreeDFormat::getCamera](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getCamera--) segítségével állíthatja be:

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

Használja a kamerát, amikor meg kell változtatni, hogy a néző hogyan látja az objektumot. Nem módosítja a 2D alakzat geometriáját a dián. A PowerPoint és az Aspose.Slides által a rendereléskor használt 3D nézőpontot változtatja.

## **Extrúzió és mélység hozzáadása**

Az extrúzió egy alakzatot vastagnak mutat azáltal, hogy kiterjeszti az első felület mögé. PowerPointban a mélység vezérlő állítja be ezt a látható vastagságot, a szín vezérlő pedig az oldalfalak színét.

![PowerPoint mélység beállítások leképezése az extrúzió színre és magasságra vonatkozó tulajdonságokra](img_02_02.png)

Állítsa be a [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) értéket a vastagságra, és a [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#getExtrusionColor--) értéket az oldalszínre:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

Használja a [ThreeDFormat::setDepth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/#setDepth-double-) metódust, amikor közvetlenül a PowerPoint mélységértékével szeretne dolgozni, vagy a mélységet rézsúttal, anyaggal és szövegeffektusokkal kombinálni. Sok alakzatos esetben a `setExtrusionHeight` egyértelműbb beállítás, mivel közvetlenül kifejezi a látható extrudálást.

## **Gradiens vagy képtöltés használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat szilárd színt, színátmenetet, mintát vagy képet az első felületre, és továbbra is használhatja ugyanazt a kamerát, világítást, anyagot és extrúziót.

Ez a példa színátmenetes kitöltést alkalmaz az alakzaton, és sötétebb extrúziószínt ad az oldalaknak:

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

A renderelt kimenet megtartja a gradienst az első felületen, és az extrúziót külön rendereli:

![Renderelt 3D téglalap kék‑narancs színátmenetes kitöltéssel és narancssárga extrúzióval](img_02_03.png)

Képtöltés használatához adja hozzá a képet a prezentációhoz, és rendelje az alakzat kitöltéséhez:

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

A kép az első felületen jelenik meg, míg az extrúzió a 3D oldalfelületként renderelődik:

![Renderelt 3D téglalap fotótöltéssel az első felületen és narancssárga extrúzióval](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása a forma testére hat. A szöveg 3D formázása a szövegkeretre. Ez hasznos WordArt‑szerű effektusokhoz, ahol maguknak a betűknek kell extrúzió, anyag, világítás és kamera beállítások.

A következő példa mintatöltésű szöveget hoz létre, WordArt átalakítást alkalmaz, és 3D beállításokat konfigurál a [TextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/) osztályon:

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

A szöveg ívelt, extrudált 3D betűként jelenik meg:

![Renderelt 3D szöveg ívelt WordArt átalakítással, narancssárga mintatöltéssel és sötét extrúzióval](img_02_05.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PPTX‑hez hasonló PowerPoint formátumba ment. Renderelés vagy exportálás rögzített elrendezésű formátumokba esetén a 3D jelenet raszterizálódik vagy 2D eredményként kerül a kimenetre. Ez akkor is érvényes, amikor a diákat [PNG](/slides/hu/php-java/convert-powerpoint-to-png/), [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/hu/php-java/convert-powerpoint-to-html/) formátumba rendereli vagy [videó átalakítás](/slides/hu/php-java/convert-powerpoint-to-video/) kereteket generál.

Vegye figyelembe a következőket:

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot az export után a néző nem forgathatja.
- A végső megjelenés a kamera, fényrendszer, anyag, extrúzió, kitöltés és dia méretezés kombinációjától függ.
- Ha meg kell vizsgálnia a örökölt vagy téma alapú formázási értékeket, olvassa el a [hatékony alakzat tulajdonságok](/slides/hu/php-java/shape-effective-properties/) leírását.
- Néhány kimeneti formátum nem tudja tárolni a szerkeszthető PowerPoint 3D formázást. Ilyen formátumokban a vizuális eredmény renderelődik, nem pedig szerkeszthető 3D beállításként marad meg.

## **GYIK**

**Készíthet‑e az Aspose.Slides interaktív 3D prezentációkat?**  
Az Aspose.Slides PowerPoint 3D effektusokat hoz létre és renderel alakzatokra és szövegre. Nem teszi az exportált képeket, PDF‑eket vagy HTML‑oldalakat interaktív 3D jelenetté, amelyet a néző forgathat. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPointban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D effekt között?**  
A 3D modell egy különálló 3D objektum, amely a prezentációba van beszúrva. A 3D effektus a szabványos PowerPoint alakzatra vagy szövegre alkalmazott formázás, például forgatás, extrúzió, rézsút, világítás és anyag. Ez a cikk a 3D effektusokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**  
Minimum egy kamera forgatásra és vagy extrúzióra, vagy mélységre van szükség. Gyakorlati szempontból érdemes beállítani a fényrendszert és az anyagot is, hogy a renderelt felületeknek legyenek kiemelkedő fény- és árnyékhatásai.

**Alkalmazhatok‑e 3D effektusokat alakzatokra és szövegre egyaránt?**  
Igen. Használja a [Shape::getThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getThreeDFormat--) metódust a forma testére, és a [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#getThreeDFormat--) metódust a szövegre.

**Megjelennek‑e a 3D effektusok, amikor képekre, PDF‑re, HTML‑re vagy videókeretekre exportálok?**  
Igen. Az Aspose.Slides a 3D effektusokat rendereli, amikor dia képeket, PDF‑kimenetet, HTML‑kimenetet vagy videókonvertáláshoz használt kereteket állít elő. Az exportált kimenet a renderelt megjelenést tartalmazza, nem pedig szerkeszthető 3D objektumot.

**Olvashatom‑e a végső 3D értékeket öröklődés és téma beállítások alkalmazása után?**  
Igen. Használja a [hatékony alakzat tulajdonságok](/slides/hu/php-java/shape-effective-properties/) API‑kat a végső kamera, fényrendszer, rézsút és egyéb 3D értékek beolvasásához.