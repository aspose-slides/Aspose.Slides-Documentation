---
title: Prezentációhelykitöltők kezelése PHP-ben
linktitle: Helykitöltők kezelése
type: docs
weight: 10
url: /hu/php-java/manage-placeholder/
keywords:
- helykitöltő
- szöveghelykitöltő
- képhelykitöltő
- diagramhelykitöltő
- tartalomhelykitöltő
- prompt szöveg
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan lehet ellenőrizni és szerkeszteni a szöveg-, kép-, diagram- és tartalomhelykitöltőket, valamint megérteni a helykitöltő öröklődést az Aspose.Slides for PHP (Java) segítségével."
---
## **Áttekintés**

A helykitöltő olyan alakzat, amely helyet foglal egy adott típusú tartalom számára egy prezentációs sablonban. Gyakori példák a cím, a törzs, a kép, a diagram és az általános célú tartalomhelykitöltők. Egy szokásos alakzattól eltérően a helykitöltő örökölheti a pozícióját, méretét, formázását és egyéb beállításait egy elrendezési diáról vagy mester diáról.

Az Aspose.Slides a helykitöltő információkat a [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) metóduson keresztül teszi elérhetővé. A metódus egy [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) objektumot ad vissza, vagy `null`‑t egy normál alakzat esetén. Használja a [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) metódust annak meghatározásához, hogy a helykitöltő milyen tartalmat vár.

Az alakzat osztálya továbbra is fontos, miután ismeri a helykitöltő típusát:

- Egy üres szöveg, kép, diagram vagy tartalomhelykitöltőt általában egy [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) reprezentál.
- Egy már kitöltött képhelykitöltőt egy [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) képviselhet.
- Egy már kitöltött diagramhelykitöltőt egy [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) képviselhet.
- Egy tartalomhelykitöltő többféle tartalmat is tartalmazhat. Ellenőrizze a [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) és a futási időben lévő alakzat osztályát is, ahelyett, hogy feltételezné, hogy minden helykitöltő egy [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
A [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) leírja a helykitöltő szerepét; nem garantálja az alakzat futási időbeli osztályát. Mindig végezzen típusellenőrzést a szöveg, kép, diagram, táblázat vagy médiához kapcsolódó tagok elérése előtt.
{{% /alert %}}

## **A helykitöltő öröklődés megértése**

A helykitöltők hierarchiát alkotnak:

1. A mester dia meghatározza az újrahasznosítható stílusokat, és egyes esetekben a mester szintű helykitöltőket.
2. Az elrendezési dia meghatározza a kiosztást, amelyet egy vagy több normál dia használ, és örökölhet a mestertől.
3. Egy normál dia tartalmazza az adott dia helykitöltőit, és örökölhet az elrendezéséből.

Hívja meg a [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) metódust a hierarchia egy szinttel feljebb lépéshez. Egy diahelykitöltő általában a saját elrendezési helykitöltőjét adja vissza; egy elrendezési helykitöltő visszaadhatja a mester helykitöltőjét. A metódus `null`‑t ad vissza, ha az alakzatnak nincs alaphelykitöltője.

A következő példa felsorolja az első dián lévő helykitöltőket, és jelentést készít az alaphelykitöltőikről:

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

Egy normál dián lévő helykitöltő szerkesztése helyi felülírást hoz létre vagy módosít az adott dián. A kapcsolódó elrendezés vagy mester szerkesztése hatással lehet minden olyan diára, amely még örökli azt a beállítást. Egy helyi szokásos alakzatnak nincs alaphelykitöltője, és nem kezd el örökölni csak azért, mert ugyanazokban a koordinátákban helyezkedik el.

## **Helykitöltő állapot eltávolítása**

Sablon testreszabásakor használja a [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) metódust, hogy egy meglévő objektumot szokásos alakzattá tegye. Az [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) metódusa `null`‑t ad vissza, de az alakzat a dia gyűjteményében marad. Ezzel szemben a [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) törli az alakzatot a gyűjteményből.

A következő példához szükség van egy `template.pptx` fájlra, amely legalább egy diával és egy nem üres szöveghelykitöltővel rendelkezik az első dián. Használjon egy olyan helykitöltőt, amelynek formázása az elrendezésről vagy a mesterről öröklődik, hogy lássa a kapcsolódás eltávolításának hatását. A példa ellenőrzi, hogy ugyanaz az alakzat megmarad, újra meghívja a metódust a most már szokásos alakzaton, és elmenti az eredményt.

{{% alert color="warning" title="Warning" %}}
A helykitöltő állapotának eltávolítása nem őrzi meg automatikusan az örökölt megjelenési beállításokat. Az alábbi példa szándékosan változatlanul hagyja ezeket a beállításokat, ezért a kimenet másképp nézhet ki. Egy teljesen örökölt pozícióval és mérettel rendelkező alakzat a hívás után nullához közelítő koordinátákat és méreteket kaphat, és láthatatlanná válhat, még ha a gyűjteményben marad is.
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // A metódus hívása egy szokásos alakzaton nem jár hatással.
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Egy megfelelő helykitöltő esetén mindhárom ellenőrzés `true` értéket ad. A szöveg megmarad, de az örökölt pozíció, méret, forgatás, betűtípus, bekezdésigazítás, szövegkeret margók, függőleges rögzítés, kitöltés és vonalbeállítások megváltozhatnak, amikor a helykitöltő kapcsolatot eltávolítják. Például az örökölt címformázás visszaeshet a szokásos szövegformázásra. További információkért lásd a [Slide Layout](/slides/hu/php-java/slide-layout/) oldalt.

A kívánt megjelenés megőrzéséhez a hívás előtt rögzítse a feloldott pozíciót, méretet és forgatást, és másolja a szükséges hatékony formázási értékeket külön változókba. Ezeket az értékeket a [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/), [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/), [TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/), [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/), és [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/) metódusokkal szerezze be. Ne csak a hatékony formátumobjektumokra támaszkodjon, mivel a szövegformázási értékek a kapcsolat eltávolítása után megváltozhatnak. Az elkapott értékeket kifejezetten alkalmazza a szokásos alakzatra később, beleértve a betűcsaládot, méretet, stílust, színt, bekezdés beállításokat, szövegkeret beállításokat, kitöltést és vonalat, amelyet a sablonja használ.

Az örökölt alakzateg geometria is explicit módon adható meg a [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType) segítségével. Egy négyszögletes szöveghelykitöltőnél ez azt jelenti, hogy a [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) értéket kell beállítani; csak a kitöltés és vonal visszaállítása nem feltétlenül állítja vissza a látható négyzetet. Az extra effektusokkal vagy összetettebb formázással rendelkező sablonok esetén ezeket a beállításokat is kezelni kell.

## **Szöveg módosítása egy helykitöltőben**

A cím, a középre igazított cím, az alcím, a törzs és a szöveghelykitöltők általában támogatják a szöveget. Ellenőrizze a [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) létezését, mielőtt a [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/) metódusát használja.

A következő példa frissíti az első címhelykitöltőt az első dián, és elmenti az eredményt:

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

Ez a minta elkerüli, hogy a kép, diagram, táblázat vagy média helykitöltőket [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) objektumként kezelje. Emellett a helykitöltőt a célja alapján azonosítja, ahelyett, hogy egy törékeny alakzati indexre támaszkodna.

## **Útmutató szöveg beállítása egy elrendezésen**

A prompt szöveg egy tervezési időben megjelenő utasítás, amely egy üres helykitöltőben látható, például *Kattintson a cím hozzáadásához*. Állítson be egyedi prompt szöveget az elrendezési helykitöltőn, ahelyett, hogy egy normál dia alakzattárolóján keresztül próbálna meg elérni. Az elrendezést a [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) segítségével érheti el, és iterálja végig a [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) által visszaadott gyűjteményt.

A következő példa módosítja a cím és alcím prompt szövegeit az első dián használt elrendezésen:

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

A prompt szöveg nem szokásos dia tartalom. Üres helykitöltők szerkesztési alkalmazásokban, például a PowerPointban való használatra szolgál. Amint egy felhasználó vagy program valós tartalmat ad meg, a prompt már nem jelenik meg. A prompt módosítása nem cseréli le a már meglévő szöveget az elrendezést használó diákon.

## **Képhelykitöltő frissítése**

Két esetet kell kezelni:

- Ha a képhelykitöltő már ki van töltve és egy [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) reprezentálja, cserélje ki a képet a [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) és a [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage) segítségével.
- Ha még üres helykitöltő, adjon hozzá egy képkeretet a helykitöltő koordinátáihoz a [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) segítségével, és távolítsa el az üres helykitöltőt.

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

Az üres helykitöltőhöz létrehozott helyettesítés egy helyi képkeret, nem egy új helykitöltő, mivel a [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) nem biztosít beállítót. Megőrzi a lefoglalt pozíciót, de már nem örököl a helykitöltő-specifikus viselkedést. Ha a helykitöltő kapcsolat megtartása lényeges, először készítse elő és töltse ki a helykitöltőt a PowerPointban, majd frissítse a kapott [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) objektumot az Aspose.Slides segítségével.

Az átlátszóság, vágás és egyéb kép-specifikus hatások kezeléséhez lásd a [Manage Picture Frames](/slides/hu/php-java/picture-frame/) cikket. Ezek a műveletek a képkerethez vagy a kép kitöltéséhez tartoznak, nem pedig a helykitöltő metaadatokhoz.

## **Diagram és tartalom helykitöltők kezelése**

Egy kitöltött diagramhelykitöltő egy [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) segítségével ábrázolható. Ez a példa mind a helykitöltő típusa, mind a futási osztály alapján megtalál egy ilyen diagramot, megváltoztatja a címét, és elmenti a fájlt:

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

Egy általános tartalomhelykitöltő általában a [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) típussal rendelkezik. PowerPointban ez többféle tartalomtípus indítójaként működik, beleértve a diagramokat, táblázatokat, diagrammákat, képeket és médiát. Miután fel lett töltve, ellenőrizze a tényleges alakzat osztályát, hogy megtudja, mit tartalmaz. Specializált elrendezések is ki tudják mutatni a [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) vagy [PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) típusokat.

Az Aspose.Slides nem alakítja át egy üres [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) helykitöltőt egy [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) objektummá pusztán a [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) módosításával; a típust az osztályon keresztül nem lehet megváltoztatni. Egy üres diagram vagy tartalomterület programozott feltöltéséhez adja hozzá a szükséges objektumot a helykitöltő koordinátáihoz, majd távolítsa el az üres helykitöltőt. A következő példa ezt teszi meg egy diagram esetén:

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

Az hozzáadott diagram egy szokásos helyi diagram. Kitölti a helykitöltő területét, de nem örököl az elrendezési helykitöltőtől. Használja a dedikált [chart management articles](/slides/hu/php-java/powerpoint-charts/) cikkeket, amikor a kategóriákat, sorozatokat vagy munkafüzet adatokat kell cserélni.

## **Teljes példa: Szöveg vagy kép tartalom frissítése**

A következő végponttól végpontig tartó példa megnyit egy sablont, az első dián keres egy cím vagy kép helykitöltőt, ellenőrzi a helykitöltő és alakzat típusait, frissíti a megfelelő tartalmat, és elmenti a kimenetet. A példa szándékosan elkerüli egy alakzat index feltételezését vagy minden helykitöltő ugyanannak az osztálynak a tekintését:

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

**Mi a alaphelykitöltő?**

Az alaphelykitöltő az elrendezésen vagy a mesterben lévő megfelelő alakzat, amelyből egy másik helykitöltő örököl. Használja a [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) metódust a lekéréshez. Egy szokásos helyi alakzat `null`‑t ad vissza, mivel nem része a helykitöltő hierarchiájának.

**Módosíthatom az összes diacímét egy elrendezés helykitöltőjének szerkesztésével?**

Az öröklött formázást vagy a prompt szöveget módosíthatja egy elrendezésen keresztül, de a meglévő cím tartalmát a normál diák tárolják. A tényleges cím szövegének cseréjéhez egy prezentációban, iteráljon a diákon, és frissítse minden címhelykitöltőt.

**Hogyan kezeljem a dátum, dia-szám, fejléc és lábléc helykitöltőket?**

Használja a fejléc és lábléc kezelőket a megfelelő dia, elrendezés, mester, jegyzet vagy kézjegy hatókörében. Lásd a [Manage Presentation Header and Footer](/slides/hu/php-java/presentation-header-and-footer/) oldalt a teljes példákért.