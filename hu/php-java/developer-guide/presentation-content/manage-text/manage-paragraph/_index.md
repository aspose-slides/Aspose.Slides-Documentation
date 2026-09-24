---
title: PowerPoint szöveg bekezdések kezelése PHP-ben
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- szöveg hozzáadása
- bekezdés hozzáadása
- szöveg kezelése
- bekezdés kezelése
- bullet kezelése
- bekezdés behúzás
- függő behúzás
- bekezdés bullet
- számozott lista
- felsorolt lista
- bekezdés tulajdonságok
- HTML importálása
- szöveg HTML-re
- bekezdés HTML-re
- bekezdés képre
- szöveg képre
- bekezdés exportálása
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, szakaszokat, bullet‑eket, számozott listákat, behúzásokat, HTML tartalmat és bekezdés képeket az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for PHP via Java a szöveget a szövegkeretek, bekezdések és szakaszok hierarchiájaként ábrázolja:

* [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) a formákban lévő szövegtárolót képviseli, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) egy bekezdést jelöl egy szövegkeretben, és hozzáférést biztosít a szakaszaihoz és a bekezdésszintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) egy szövegfolyamot képvisel egy bekezdésen belül. Minden szakasz saját szöveggel és karakter-szintű formázással rendelkezhet.

Egy bekezdés tehát több szakasz használatával tartalmazhat különböző betűtípusú, színű, méretű és egyéb formázású szöveget.

## **Bekezdések létrehozása és formázása**

### **Több szakaszos bekezdések létrehozása**

Az alábbi lépések egy szövegkeretet hoznak létre három bekezdéssel, amelyek mindegyike három szakaszt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő diát indexe alapján.
3. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
4. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) részét.
5. Használja az alapértelmezett bekezdést, és adjon hozzá két további [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) objektumot a szövegkerethez.
6. Adjon elegendő [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) objektumot minden bekezdéshez, hogy három szakaszt tartalmazzanak. Az alapértelmezett bekezdés már egy üres szakaszt tartalmaz.
7. Állítsa be minden szakasz szövegét.
8. Alkalmazzon karakter-szintű formázást a [Portion::getPortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/#getPortionFormat--) segítségével.
9. Mentse a módosított bemutatót.

Ez a PHP példa a fenti lépéseket valósítja meg:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Felsorolás és számozott lista létrehozása**

### **Felsorolás vagy számozott lista létrehozása**

A felsorolás‑ és számozási jelek segítenek a kapcsolódó elemek gyors áttekintésében. Az Aspose.Slides‑ben a lista beállításait a [BulletFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő diát indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a kiválasztott diára.
4. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) részét.
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) elemet egy szimbólum‑bullethez.
7. Állítsa be a [BulletFormat::setType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setType-int-) értékét a [BulletType::Symbol](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bullettype/) típusra, és adja meg a bullet karaktert.
8. Állítsa be a bekezdés szövegét, behúzását, bullet színét és magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa be a [BulletFormat::setType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setType-int-) értékét a [BulletType::Numbered](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bullettype/) típusra.
11. Konfigurálja a számozott bullet stílusát, és adja hozzá a bekezdést a szövegkerethez.
12. Mentse a bemutatót.

Ez a PHP példa egy szimbólum‑bulletet és egy számozott bulletet hoz létre:

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Képes bullet használata**

A képes bullet lehetővé teszi egy egyedi kép használatát szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő diát indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet, és szerezze meg annak [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) részét.
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltse be a bullet képet, és adja hozzá a bemutató képgyűjteményéhez [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) formájában.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa be a [BulletFormat::setType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setType-int-) értékét a [BulletType::Picture](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bullettype/) típusra.
8. Azonosítsa a képet a [BulletFormat::getPicture](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#getPicture--) segítségével, és állítsa be a bullet magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse a módosított bemutatót.

Ez a PHP példa egy képes bulletet hoz létre:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **Többszintű lista létrehozása**

Állítsa be a [ParagraphFormat::setDepth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setDepth-short-) értékét, hogy a bekezdéseket a lista különböző szintjeire helyezze. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) objektumot, és érje el egy diát.
2. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet, és törölje az alapértelmezett bekezdést a szövegkeretéből.
3. Hozzon létre négy bekezdést, és konfigurálja azok bullet szimbólumait.
4. Állítsa be a [ParagraphFormat::setDepth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setDepth-short-) értékeket `0`, `1`, `2` és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, majd mentse a bemutatót.

Ez a PHP példa egy négyszintű felsorolást hoz létre:

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Számozott listaelemek egyedi kezdőértékkel**

Használja a [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) metódust a számozott bekezdés kezdeti számának megadásához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) objektumot, és adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet egy diához.
2. Törölje a forma szövegkeretéből az alapértelmezett bekezdést.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be a [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) értékét `2`, `3` és `7`‑re a megfelelő bekezdéseknél.
5. Adja hozzá a bekezdéseket a szövegkerethez, majd mentse a bemutatót.

Ez a PHP példa minden bekezdéshez egyedi kezdőszámot rendel:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bekezdéselrendezés és végjellemzők vezérlése**

### **Első sor behúzásának beállítása**

Használja a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setIndent-float-) metódust a bekezdés első sorának behúzásának szabályozásához. Ez a módszer csak az első sort mozgatja a bekezdés bal margójához képest. Pozitív érték esetén az első sor jobbra tolódik, míg a többi sor a bekezdés törzséhez igazodik.

Ha az egész bekezdést szeretné eltolni, használja a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) metódust. Ha csak az első sort kívánja eltolni, használja a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setIndent-float-) metódust.

Az alábbi példa több bekezdést hoz létre, és különböző [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setIndent-float-) értékekkel mutatja be, hogyan befolyásolja a első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Érje el a cél diát.
3. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
4. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) részét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setIndent-float-) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított bemutatót.

Ez a PHP kód megmutatja, hogyan állíthat be bekezdésbehúzást:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A bekezdések első sorának behúzása](first_line_indent.png)

### **Függő behúzás beállítása**

A függő behúzás olyan bekezdéselrendezés, ahol az első sor balra kezdődik a többi sorhoz képest. Az Aspose.Slides‑ben ezt a hatást a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setIndent-float-) segítségével hozhatja létre. Negatív érték megadása az első sort balra tolja a bekezdés törzséhez képest.

Gyakorlatban a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) határozza meg a bekezdés törzsének bal pozícióját, míg a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setIndent-float-) az első sor pozícióját a már megadott margóhoz képest. Függő behúzás létrehozásához pozitív értéket adjon a `setMarginLeft`‑nek, és negatív értéket a `setIndent`‑nek.

Ez a formázás hasznos bibliográfiák, hivatkozások, szójegyzékek és egyéb bekezdések esetén, ahol a sortöréseknek a bekezdés törzsének alá kell illeszkedniük, nem pedig az első sor első karakteréhez.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Érje el a cél diát.
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diához.
4. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) részét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) számára adjon meg pozitív értéket minden bekezdésnél.
6. A [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setIndent-float-) számára adjon meg negatív értéket a függő behúzás létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított bemutatót.

Ez a PHP kód megmutatja, hogyan állíthat be függő behúzást egy bekezdéshez:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A bekezdések függő behúzása](hanging_indent.png)

### **A bekezdés befejező tulajdonságainak beállítása**

A [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) szabályozza a bekezdés zárójelzésének formázását. Az alábbi PHP példa betűméretet és latin betűtípust állít be a második bekezdés zárójelzésére:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) objektumot, és érje el egy diát.
2. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet, és törölje annak alapértelmezett bekezdését.
3. Hozzon létre két bekezdést, és adjon hozzá szövegszakaszokat.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/) objektumot a második bekezdés zárójelzéséhez.
5. Állítsa be a [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) és a [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) értékeket.
6. Rendelje hozzá a formázást a [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) metódussal, majd mentse a bemutatót.

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Megjelenített sorok számlálása**

Használja a [Paragraph::getLinesCount](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#getLinesCount--) metódust a bekezdés által a szövegelrendezés után elfoglalt sorok számának meghatározásához, beleértve az automatikus sortörést. Ez akkor hasznos, ha a szöveg hosszát és elrendezését kell ellenőrizni a prezentációs sablonokban.

Egy bekezdés egy elem a [TextFrame::getParagraphs](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#getParagraphs--) gyűjteményében, és több megjelenített sort is elfoglalhat. Egy explicit sortörés egy bekezdésen belül új sort hoz létre anélkül, hogy új bekezdést generálna. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat, anélkül, hogy explicit sortörő karaktereket illesztene a szövegbe. Ennek megfelelően a bekezdések vagy sortörő karakterek számlálása nem adja meg a tényleges megjelenített sorok számát.

Az alábbi példa létrehoz egy szöveges formát, megszámolja a sorait, szűkíti a formát, majd a szöveget egy rövidebb karakterláncra cseréli. A sortörés engedélyezett, az automatikus illesztés (autofit) le van tiltva, így a forma szélessége szabályozza a sortörést, anélkül, hogy a szöveg vagy a forma automatikusan zsugorodna. A forma méretei pontban vannak megadva. Végül a példa egy további bekezdést ad hozzá, és összeadja a sorok számát a szövegkereten belül.

```php
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    echo "Original width: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $shape->setWidth(150);
    echo "Narrower shape: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $paragraph->setText("Short text.");
    echo "Shorter text: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Another paragraph.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $textFrame->getParagraphs()->add($secondParagraph);

    $totalLineCount = 0;
    for ($i = 0; $i < java_values($textFrame->getParagraphs()->getCount()); $i++) {
        $currentParagraph = $textFrame->getParagraphs()->get_Item($i);
        $totalLineCount += java_values($currentParagraph->getLinesCount());
    }
    echo "Total lines in the text frame: " . $totalLineCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Ezzel a szöveggel és ezekkel a méretekkel a forma szűkítése növeli a sorok számát, míg a rövid szövegre cserélés csökkenti azt. A pontos számok változhatnak a betűtípus elérhetősége és helyettesítése, betűméret, margók, behúzás, sortörés és autofit beállítások függvényében. A sablon ellenőrzésekor használja a célnak megfelelő betűtípusokat és elrendezési beállításokat.

A sorok száma önmagában nem határozza meg, hogy a szöveg túllépi-e a tárolóját. A rendelkezésre álló magasság, sormagasság, bekezdés‑ és sor‑köz, valamint az autofit viselkedés is szerepet játszik; még egyetlen sor is túlságosan széles lehet, ha a sortörés ki van kapcsolva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódust a HTML megjelölés bekezdésekké és szakaszokká való konvertálásához egy szövegkeretben.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Érje el egy diát, és adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet.
3. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) részét, és távolítsa el az alapértelmezett bekezdést.
4. Olvassa be a forrás HTML‑fájlt.
5. Adja át a HTML‑szöveget a [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódusnak.
6. Mentse a módosított bemutatót.

Ez a PHP példa HTML‑t importál egy szövegkeretbe:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **Bekezdés szövegének exportálása HTML‑be**

Használja a [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust a kiválasztott bekezdéstartomány HTML‑ként történő exportálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból, és töltse be a kívánt bemutatót.
2. Érje el a diát, és keresse meg azt az [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet, amely a szöveget tartalmazza.
3. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) részét.
4. Hívja meg a [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust a kezdő bekezdésindex és az exportálandó bekezdések számának megadásával.
5. Írja a visszaadott HTML‑szöveget egy fájlba.

Ez a PHP példa az első szöveges forma összes bekezdését exportálja:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **Bekezdés renderelése képként**

A [Paragraph::getImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#getImage--) egy egyedi bekezdést renderel közvetlenül, és egy [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/) objektumot ad vissza. Mentse az eredményt fájlba vagy streambe a [IImage::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/#save-java.lang.String-int-) segítségével. Nem szükséges a szülő forma renderelése vagy bitmap manuális kivágása.

A [Paragraph::getImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#getImage--) `null`‑t adhat vissza, ha a bekezdés nem található meg a szülő gyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és a kép használata után szabadítsa fel.

#### **Bekezdés renderelése alapértelmezett méretezéssel**

Tegyük fel, hogy van egy `sample.pptx` nevű bemutatófájl egy diával, ahol az első forma egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi PHP példa a második bekezdést egy szabályos szövegformában alapértelmezett méretezéssel rendereli, majd a visszakapott képet PNG formátumban menti. A `finally` blokk biztosítja, hogy a kép helyesen legyen felszabadítva.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A bekezdés képe](paragraph_to_image_output.png)

#### **Bekezdés renderelése táblázatcellában méretezéssel**

Használja a [Paragraph::getImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#getImage-float-float-) túlterhetést, amely a `$scaleX` és `$scaleY` paramétereket fogadja a vízszintes és függőleges skálázási tényezők beállításához. Az alábbi PHP példa egy táblázatot hoz létre, a bekezdést az első cellájában kétszeres alapmérettel rendereli, majd az eredményt PNG képként menti.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

Az `1` skálázási tényező megtartja az adott tengely alap pixelméretét. Például a `2` mindkét tényezőnél olyan képet eredményez, amelynek szélessége és magassága megközelítőleg kétszerese az alapméreteknek, így négyzetesére nő a pixel számnak. A nagyobb tényezők általában élesebb szöveget eredményeznek nagyítás vagy nagy felbontású kimenet esetén, de a memóriát és a fájlméretet is növelik. Az `1`‑nél kisebb tényezők kisebb, részletmentesebb képeket adnak. Használjon egyenlő tényezőket a bekezdés arányának megőrzéséhez; a különböző vízszintes és függőleges tényezők önállóan nyújtják a kimenetet.

Az egész forma renderelése a [Shape::getImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getImage--) segítségével akkor hasznos, ha a kimenetnek tartalmaznia kell a forma kitöltését, keretét vagy egyéb vizuális kontextusát. A csak bekezdésre korlátozott képhez használja a [Paragraph::getImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#getImage--) metódust.

## **GYIK**

**Teljesen letilthatom a sortörést egy szövegkereten belül?**

Igen. A [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setWrapText-byte-) beállításával letilthatja a sortörést, így a sorok nem törnek a szövegkeret szélei mentén.

**Hogyan kaphatom meg egy adott bekezdés pontos dián lévő határait?**

Használja a [Paragraph::getRect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#getRect--) metódust a bekezdés határoló téglalapjának lekéréséhez. A [Portion::getRect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/#getRect--) egy egyedi szakasz határait adja vissza.

**Hol szabályozható a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

A [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setAlignment-int-) bekezdés‑szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyes szakaszok formázásától.

**Beállíthatom a helyesírási nyelvet a bekezdés egy részére?**

Igen. Állítsa be a [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) értékét egyedi szakaszokra, így egy bekezdés több nyelven írt szöveget is tartalmazhat.