---
title: Pontozott és számozott listák kezelése bemutatókban PHP használatával
linktitle: Listák kezelése
type: docs
weight: 60
url: /hu/php-java/manage-lists/
keywords:
- jelölő
- pontozott lista
- számozott lista
- szimbólum jelölő
- képes jelölő
- egyéni jelölő
- többszintű lista
- jelölő létrehozása
- jelölő hozzáadása
- lista hozzáadása
- PowerPoint
- OpenDocument
- bemutató
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat pontozott, képes, többszintű és számozott listákat PowerPoint és OpenDocument bemutatókban az Aspose.Slides for PHP via Java használatával."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java lehetővé teszi felsorolások (pontozott és számozott listák) létrehozását és formázását PowerPoint és OpenDocument bemutatókban. Egy listaelem egy bekezdés, amelynek a jelölő beállításait a bekezdés formátuma vezérli.

Használd a [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) metódust a bekezdés szintű lista beállítások eléréséhez. A fő belépési pont a [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) amely egy [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatod a jelölő típusát, szimbólumát, képét, színét, méretét, számozási stílusát és a kezdő számot.

Ez a cikk bemutatja, hogyan:

- hozz létre egy pontozott listát egy egyéni szimbólummal
- hozz létre egy képes jelölőt
- hozz létre többszintű listát a bekezdés mélységének beállításával
- hozz létre számozott listát
- vizsgáld meg és módosítsd a lista formázását egy meglévő bemutatóban
- olvasd ki a tényleges lista jeleit és számokat a bekezdés szövege mellett

## **Hozz létre egy pontozott listát**

Pontozott lista létrehozásához adj [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) objektumokat egy [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)-hez, és állítsd be a [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) értékét a [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Symbol)-ra. Ezután a [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar), a [BulletFormat::getColor](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getColor) és a [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) beállításával szabályozhatod a jelölő megjelenését.

A következő PHP kód bemutatja, hogyan hozhatsz létre pontozott listát egy dián:

```php
use aspose\slides\BulletType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A szimbólum jelölők](symbol_bullets.png)

## **Hozz létre számozott listát**

Használd a számozott listákat, amikor az elemek sorrendje fontos. Állítsd be a [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) értékét a [BulletType::Numbered](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Numbered)-ra. Választhatsz számozási formát is a [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) segítségével, vagy beállíthatod a [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith), ha a lista 1-től eltérő értékkel kell, hogy kezdődjön.

A következő PHP kód mutatja, hogyan hozhatsz létre számozott listát egy dián:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A számozott jelölők](numbered_bullets.png)

## **Hozz létre képes jelölőt**

Az Aspose.Slides lehetővé teszi, hogy a normál jelölő szimbólumot egy képpel helyettesítsd. A képes jelölők a legegyszerűbb, kis méretben is olvasható képekkel működnek a legjobban, például ikonokkal vagy kicsi átlátszó PNG fájlokkal.

{{% alert color="info" title="Note" %}}
Ideális esetben, ha a normál jelölő szimbólumot képpel szeretnéd helyettesíteni, a legjobb egy egyszerű, átlátszó háttérrel rendelkező grafikát választani. Ilyen képek jól használhatók egyéni jelölő szimbólumként.
Vedd figyelembe, hogy a kép nagyon kicsire lesz méretezve. Emiatt erősen ajánljuk, hogy olyan képet válassz, amely tiszta marad és vizuálisan hatékony, amikor listában jelölőként használod.
{{% /alert %}}

Képes jelölő létrehozásához adj egy képet a [Presentation::getImages](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getImages)‑hez, és rendeld hozzá a visszakapott [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) objektumot a [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture)‑hez. Állítsd be a [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) értékét a [BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture)‑ra a kép hozzárendelése előtt.

Tegyük fel, hogy van egy "image.png" nevű fájlunk:

![Kép a jelölőkhöz](picture_for_bullets.png)

A következő PHP kód mutatja, hogyan hozhatsz létre képes jelölőket egy dián:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A képes jelölők](picture_bullets.png)

## **Hozz létre többszintű listát**

A listaelemek különböző szintekre helyezéséhez használd a [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) metódust. Az 0. szint a legfelső, az 1. szint alatta van, és így tovább.

A következő PHP kód mutatja, hogyan hozhatsz létre többszintű pontozott listát:

```php
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A többszintű lista](multilevel_list.png)

## **Módosíts egy meglévő listát**

A lista formázásának módosításához egy meglévő bemutatóban, érj el a cél bekezdést, és frissítsd a [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) beállításait. Ugyanazokat a tulajdonságokat, amelyeket a listák létrehozásához használsz, felhasználhatod a PPT, PPTX vagy ODP fájlból betöltött listák megtekintésére vagy módosítására.

A következő PHP kód módosítja a szövegkeret első bekezdését, hogy számozott lista stílust használjon:

```php
use aspose\slides\BulletType;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Olvasd ki a tényleges jelölő értékeket**

A bemutató tartalmának kinyerésekor tartsd meg a lista jeleit a bekezdés szövege mellett. Hívd meg a [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getEffective) metódust, és férj hozzá a [ParagraphFormatEffectiveData::getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--)‑hez a tényleges jelölő formátum megszerzéséhez. Olvasás előtt ellenőrizd a [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) értékét, majd a [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--)‑t.

Számozott listáknál különböztess meg ezt a három értéket:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) meghatározza a formátumot, például arab számok ponttal, vagy kisbetűk ponttal.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) adja meg a kezdő számot egy számolt bekezdéscsoportnál.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) visszaadja a formázott jelölőt egy adott bekezdéshez. Például egy 5-től induló lista második eleme `6.`-ot ad.

Tartsd meg a [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDepth) értékét minden bekezdésnél, hogy megőrizd a beágyazási szintjét. A tényleges jelölő nem kódolja a teljes hierarchiát: egy beágyazott elem `c.`-t adhat vissza egy kombinált címke helyett, például `6.c.`.

A következő önálló példa listákat hoz létre, elmenti őket egy bemutatóba, majd újratölti a bemutatót, hogy jelentést készítsen minden bekezdés szövegéről, mélységéről, jelölőtípusáról és tényleges értékéről. A kis kék képi jelölő beágyazott SVG-ből készült.

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 440, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20, 660, 400);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    // Készítsen egy képes jelölőt külső képfájl nélkül.
    $svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    $bulletImage = $presentation->getImages()->addImage($svg);

    $black = new Java("java.awt.Color", 0, 0, 0);
    $addParagraph = function ($text, $depth, $type, $start, $style) use ($textFrame, $bulletImage, $black) {
        $paragraph = new Paragraph();
        $paragraph->setText($text);

        $format = $paragraph->getParagraphFormat();
        $format->setDepth($depth);
        $format->setMarginLeft(30 + $depth * 40);
        $format->setIndent(-28);
        $format->setSpaceAfter(8);
        $format->getDefaultPortionFormat()->setFontHeight(22);
        $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $format->getBullet()->setType($type);
        $format->getBullet()->setBulletHardColor(NullableBool::True);
        $format->getBullet()->getColor()->setColor($black);
        if ($type == BulletType::Numbered) {
            $format->getBullet()->setNumberedBulletStyle($style);
            $format->getBullet()->setNumberedBulletStartWith($start);
        } else if ($type == BulletType::Symbol) {
            $format->getBullet()->setChar("\u{2022}");
        } else if ($type == BulletType::Picture) {
            $format->getBullet()->getPicture()->setImage($bulletImage);
        }

        $textFrame->getParagraphs()->add($paragraph);
    };

    $addParagraph("First item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Second item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Next nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Deep item", 2, BulletType::Numbered, 4, NumberedBulletStyle::BulletRomanLCPeriod);
    $addParagraph("Back to top level", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Symbol marker", 0, BulletType::Symbol, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("No bullet", 0, BulletType::None, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Picture marker", 0, BulletType::Picture, 1, NumberedBulletStyle::BulletArabicPeriod);
    $presentation->save("actual_bullet_values.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    $loadedShape = $loadedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Text | Depth | Type | Actual value\n";
    $paragraphs = $loadedShape->getTextFrame()->getParagraphs();
    for ($i = 0; $i < java_values($paragraphs->getCount()); $i++) {
        $paragraph = $paragraphs->get_Item($i);
        $bullet = $paragraph->getParagraphFormat()->getEffective()->getBullet();
        switch (java_values($bullet->getType())) {
            case BulletType::Numbered:
            case BulletType::Symbol:
                $marker = $bullet->getActualBulletValue();
                break;
            case BulletType::None:
                $marker = "null (no bullet)";
                break;
            case BulletType::Picture:
                $marker = "null (image required)";
                break;
            default:
                $marker = "unsupported bullet type";
                break;
        }
        $typeNames = [BulletType::Numbered => "Numbered", BulletType::Symbol => "Symbol", BulletType::None => "None", BulletType::Picture => "Picture"];
        $typeName = $typeNames[java_values($bullet->getType())] ?? "Unknown";
        echo $paragraph->getText() . " | " . $paragraph->getParagraphFormat()->getDepth() . " | " . $typeName . " | " . $marker . "\n";
    }
} finally {
    $loadedPresentation->dispose();
}
```

Az eredeti listák alább láthatók.

![5-től kezdődő listák, beágyazott betű- és római számú elemek, egy szimbólum jelölő, egy bekezdés jelölő nélkül, és egy kék képi jelölő](actual_bullet_values.png)

A jelentés megegyezik a PowerPoint-ban megjelenő jelölőkkel:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

A [BulletType::None és BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/) esetén a [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) `null`-t ad vissza, nem üres karakterláncot. Ezeket a típusokat külön kezeld: az előbbinek nincs jelölője, míg az utóbbihoz a jelölő képet külön kell kinyerni. A képes jelölőt nem lehet csak a szöveges jelölő kinyerésével reprodukálni.

## **GYIK**

**Exportálhatók a pontozott és számozott listák PDF-be vagy képekbe?**

Igen. Az Aspose.Slides megőrzi a lista formázását, ha a célformátum támogatja a megfelelő szövegelrendezést és jelölő funkciókat.

**Szerkeszthetek listákat meglévő bemutatókban?**

Igen. Töltsd be a bemutatót, érj el a cél bekezdést, vizsgáld meg vagy frissítsd a [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) beállításait, majd mentsd el a bemutatót.

**Tartalmazhatnak a listák nem latin szöveget?**

Igen. A listaelemek szövege tartalmazhat Unicode karaktereket, így többnyelvű bemutatókban is létrehozhatsz listákat. Győződj meg róla, hogy a bemutatóban használt betűtípusok támogatják a szükséges karaktereket.