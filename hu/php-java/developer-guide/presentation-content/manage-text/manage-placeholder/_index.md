---
title: Prezentáció helyőrzőinek kezelése PHP-ben
linktitle: Helyőrzők kezelése
type: docs
weight: 10
url: /hu/php-java/manage-placeholder/
keywords:
- helyőrző
- szöveg helyőrző
- kép helyőrző
- diagram helyőrző
- tartalom helyőrző
- utasító szöveg
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan ellenőrizheti és szerkesztheti a szöveg, kép, diagram és tartalom helyőrzőket, valamint értheti meg a helyőrző öröklődést az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

A helyőrző egy alakzat, amely helyet foglal egy adott típusú tartalom számára egy prezentációs sablonban. Gyakori példák a cím, törzs, kép, diagram és általános célú tartalomhelyőrzők. Egy szokásos alakzattól eltérően a helyőrző örökölheti pozícióját, méretét, formázását és egyéb beállításait egy elrendezési vagy fődia (master slide) beállításából.

Az Aspose.Slides a helyőrző információkat a [Shape::getPlaceholder](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getplaceholder/) metóduson keresztül teszi elérhetővé. A metódus egy [Placeholder](https://reference.aspose.com/slides/hu/php-java/aspose.slides/placeholder/) objektumot vagy `null`‑t ad vissza egy normál alakzatra. A [Placeholder::getType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/placeholder/gettype/) segítségével meghatározható, hogy milyen tartalomra szolgál a helyőrző.

A forma (shape) osztálya továbbra is fontos, miután ismerjük a helyőrző típusát:

- Egy üres szöveg-, kép-, diagram- vagy tartalomhelyőrző általában egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) által van reprezentálva.
- Egy már feltöltött képhelyőrző a [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) segítségével jelenik meg.
- Egy már feltöltött diagramhelyőrző a [Chart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/) segítségével jelenik meg.
- Egy tartalomhelyőrző többféle tartalmat is tartalmazhat. Ellenőrizze mind a [Placeholder::getType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/placeholder/gettype/), mind a futási időben (runtime) lévő forma osztályát, ahelyett, hogy feltételezné, hogy minden helyőrző egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/placeholder/gettype/) leírja egy helyőrző szerepét; ez nem garantálja a forma futási időbeli osztályát. Mindig végezzen típusellenőrzést szöveg, kép, diagram, táblázat vagy média specifikus tagok elérése előtt.
{{% /alert %}}

## **A helyőrzők öröklődésének megértése**

A helyőrzők hierarchiát alkotnak:

1. A fődia (master slide) definiálja az újrahasználható stílusokat, és egyes esetekben fődiai helyőrzőket is.
2. Egy elrendezésdia (layout slide) határozza meg a elrendezést, amelyet egy vagy több normál dia használ, és örökölhet a fődiától.
3. Egy normál dia tartalmazza a saját helyőrzőit, és örökölhet az elrendezésétől.

A [Shape::getBasePlaceholder](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getbaseplaceholder/) meghívásával léphet egy szinttel feljebb ebben a hierarchiában. Egy diahelyőrző általában visszaadja az elrendezéshelyőrzőt; egy elrendezéshelyőrző visszaadhatja a fődiai helyőrzőt. A metódus `null`‑t ad, ha az alakzatnak nincs alaphelyőrzője.

Az alábbi példa felsorolja az első dián lévő helyőrzőket, és jelentést készít azok alaphelyőrzőiről:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Egy normál dián lévő helyőrző szerkesztése helyi felülírást hoz létre vagy módosít arra a diára. A kapcsolódó elrendezés vagy fődia szerkesztése pedig az összes olyan diára hat, amely még örökli azt a beállítást. Egy helyi, egyszerű alakzatnak nincs alaphelyőrzője, és nem kezd örökölni csak azért, mert ugyanazokat a koordinátákat foglalja el.

## **Szöveg módosítása egy helyőrzőben**

A cím, középre igazított cím, alcím, törzs és szöveghelyőrzők általában támogatják a szöveget. Mielőtt a [getTextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/gettextframe/) metódust használná, ellenőrizze, hogy az alakzat egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/).

Ez a példa frissíti az első címhelyőrzőt az első dián, majd elmenti az eredményt:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ez a minta elkerüli, hogy kép-, diagram-, táblázat- vagy médiahelyőrzőket [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) objektumként kezeljen. Emellett a helyőrzőt a célja alapján azonosítja, ahelyett, hogy egy törékeny formaindexre támaszkodna.

## **Üzenetszöveg beállítása egy elrendezésen**

Az üzenetszöveg (prompt text) a tervezési időben megjelenő instrukció egy üres helyőrzőben, például *Kattintson a cím hozzáadásához*. Az egyéni üzenetszöveget az elrendezéshelyőrzőre állítsa be, ne pedig egy normál dia alakzattárán keresztül próbálja elérni. Az elrendezést a [Slide::getLayoutSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#getLayoutSlide) segítségével érheti el, és iteráljon a [BaseSlide::getShapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/#getShapes) által visszaadott gyűjteményen.

Az alábbi példa megváltoztatja a cím és alcím üzeneteit az első dia által használt elrendezésen:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az üzenetszöveg nem normál dia tartalom. A PowerPoint-hoz hasonló szerkesztő alkalmazásokban üres helyőrzőkre szolgál. Amint a felhasználó vagy egy program valós tartalmat ad meg, az üzenet többé nem jelenik meg. Egy üzenet módosítása nem helyettesíti a már létező szöveget azokban a diákban, amelyek az elrendezést használják.

## **Kép helyőrző frissítése**

Két esetet kell kezelni:

- Ha a képhelyőrző már feltöltött és egy [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) képviseli, cserélje ki a képet a [PictureFillFormat::getPicture](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/getpicture/) és a [SlidesPicture::setImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidespicture/setimage/) segítségével.
- Ha még üres helyőrző, adjon hozzá egy képkeretet a helyőrző koordinátáihoz a [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addpictureframe/) segítségével, majd távolítsa el az üres helyőrzőt.

A következő példa mindkét esetet támogatja, és elmenti a prezentációt:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az üres helyőrzőhöz létrehozott cserélő egy helyi képkeret, nem új helyőrző, mivel a [Shape::getPlaceholder](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getplaceholder/) nem biztosít beállítót. Megőrzi a lefoglalt pozíciót, de már nem örököl helyőrző-specifikus viselkedést. Ha a helyőrzőkapcsolat megőrzése lényeges, először hozzon létre és töltse ki a helyőrzőt PowerPointban, majd a kapott [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) objektumot frissítse az Aspose.Slides segítségével.

Képátlátszóság, vágás és más kép-specifikus hatások esetén lásd a [Képkeretek kezelése](/slides/hu/php-java/picture-frame/) cikket. Ezek a műveletek a képkerethez vagy a kép kitöltéséhez (picture fill) tartoznak, nem a helyőrző metaadataihoz.

## **Diagram- és tartalomhelyőrzők kezelése**

Egy feltöltött diagramhelyőrző a [Chart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/) segítségével jelenik meg. Ez a példa a diagramot mind a helyőrző típusa, mind a futási időbeli osztálya alapján megtalálja, megváltoztatja a címét, majd elmenti a fájlt:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Egy általános tartalomhelyőrző általában a [PlaceholderType::Object](https://reference.aspose.com/slides/hu/php-java/aspose.slides/placeholdertype/) értékkel rendelkezik. PowerPointban ez több tartalomtípus indítójaként működik, beleértve a diagramokat, táblázatokat, diagrammákat, képeket és médiát. Miután feltöltötték, ellenőrizze a tényleges formaosztályt, hogy megtudja, mit tartalmaz. Specializált elrendezések a [PlaceholderType::Chart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/placeholdertype/), a [PlaceholderType::Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/placeholdertype/), a [PlaceholderType::Picture](https://reference.aspose.com/slides/hu/php-java/aspose.slides/placeholdertype/), a [PlaceholderType::Media](https://reference.aspose.com/slides/hu/php-java/aspose.slides/placeholdertype/) vagy a [PlaceholderType::Diagram](https://reference.aspose.com/slides/hu/php-java/aspose.slides/placeholdertype/) értékeket is kiexponálhatják.

Az Aspose.Slides nem alakít át egy üres [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) helyőrzőt [Chart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/) objektummá pusztán a [Placeholder::getType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/placeholder/gettype/) módosításával; a típust az osztályon keresztül nem lehet megváltoztatni. Üres diagram vagy tartalom terület programozott feltöltéséhez adja hozzá a szükséges objektumot a helyőrző koordinátáihoz, majd távolítsa el az üres helyőrzőt. Az alábbi példa ezt végzi diagram esetén:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A hozzáadott diagram egy egyszerű helyi diagram. Elfoglalja a helyőrző területét, de nem örököl az elrendezés helyőrzőjétől. Használja a dedikált [diagramkezelő cikkeket](/slides/hu/php-java/powerpoint-charts/) amikor a kategóriák, sorozatok vagy munkafüzet adatok cseréje szükséges.

## **Teljes példa: Szöveg vagy kép tartalom frissítése**

Az alábbi végponttól végpontig tartó példa megnyit egy sablont, keres az első dián egy cím- vagy képhelyőrzőt, ellenőrzi a helyőrző és forma típusát, frissíti a megfelelő tartalmat, majd elmenti a kimenetet. A példa szándékosan elkerüli a formaindex feltételezését, illetve minden helyőrző egyenlő osztályként való kezelését.

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **GYIK**

**Mi az a bázishelyőrző?**

A bázishelyőrző a megfelelő alakzat az elrendezésen vagy a fődián, amelyből egy másik helyőrző örököl. A [Shape::getBasePlaceholder](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getbaseplaceholder/) segítségével lekérhető. Egy egyszerű helyi alakzat `null`‑t ad vissza, mert nem része a helyőrzőhierarchiának.

**Meg tudom változtatni az összes dia címsorát egy elrendezéshelyőrző szerkesztésével?**

Az örökölt formázást vagy az üzenetszöveget módosíthatja egy elrendezésen keresztül, de a meglévő cím tartalom a normál diákon van tárolva. A valódi cím szövegének cseréjéhez egy prezentációban iteráljon a diákon, és minden címhelyőrzőt frissítsen.

**Hogyan kezelem a dátum, dia szám, fejléc és lábléc helyőrzőket?**

Használja a fejléc és lábléc kezelőket a megfelelő dia, elrendezés, fődia, jegyzet vagy kézjegy (handout) tartományban. Tekintse meg a [Prezentáció fejléc és lábléc kezelése](/slides/hu/php-java/presentation-header-and-footer/) oldalt a teljes példákért.