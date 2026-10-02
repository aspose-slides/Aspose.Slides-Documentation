---
title: PowerPoint szövegbekezdések kezelése PHP-ben
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
  - golyó kezelése
  - bekezdés behúzása
  - függő behúzás
  - bekezdés golyó
  - számozott lista
  - pontozott lista
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
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, golyókat, számozott listákat, behúzásokat, HTML tartalmat és bekezdésképeket az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for PHP via Java a szöveget szövegdobozok, bekezdések és részek hierarchiájában ábrázolja:

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) a szövegkonténert jelenti egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) egy bekezdést jelöl egy szövegdobozban, és hozzáférést ad a részeihez valamint a bekezdés szintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) egy szövegrészt képvisel egy bekezdésen belül. Minden rész saját szöveggel és karakter szintű formázással rendelkezhet.

Egy bekezdés ezért különböző betűtípusú, színű, méretű és egyéb formázású szöveget tartalmazhat több rész használatával.

## **Bekezdések létrehozása és formázása**

### **Több részt tartalmazó bekezdések létrehozása**

Az alábbi lépések egy szövegdobozt hoznak létre három bekezdéssel, mindegyik három részt tartalmazva:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztálypéldányt.
2. Szerezze meg a megfelelő diát az indexe alapján.
3. Adj egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) elemet a diára.
4. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) objektumát.
5. Használja az alapértelmezett bekezdést, és adjon hozzá két további [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) objektumot a szövegdobozhoz.
6. Adjon elegendő [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) objektumot minden bekezdéshez, hogy három részt tartalmazzanak. Az alapértelmezett bekezdés már egy üres részt tartalmaz.
7. Állítsa be minden rész szövegét.
8. Alkalmazzon karakter szintű formázást a [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat--) segítségével.
9. Mentse el a módosított prezentációt.

Ez a PHP példa megvalósítja a lépéseket:

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

## **Felsorolások és számozott listák létrehozása**

### **Felsorolás vagy számozott lista létrehozása**

A golyók és a számozás megkönnyítik a kapcsolódó elemek átláthatóságát. Az Aspose.Slides-ben a lista beállításait a [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) határozza meg.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztálypéldányt.
2. Szerezze meg a megfelelő diát az indexe alapján.
3. Adj egy [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) elemet a kiválasztott diára.
4. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) objektumát.
5. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) elemet egy szimbólum golyóhoz.
7. Állítsa be a [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType-int-) értékét a [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/) típusra, és adja meg a golyó karakterét.
8. Állítsa be a bekezdés szövegét, behúzását, golyó színét és golyó magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Hozzon létre egy második bekezdést, és állítsa be a [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType-int-) értékét a [BulletType::Numbered](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/) típusra.
11. Konfigurálja a számozott golyó stílusát, és adja hozzá a bekezdést a szövegdobozhoz.
12. Mentse el a prezentációt.

Ez a PHP példa egy szimbólum golyót és egy számozott golyót hoz létre:

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

### **Képgolyók használata**

A képgolyók lehetővé teszik egy egyéni kép használatát szimbólum vagy szám helyett.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztálypéldányt.
2. Szerezze meg a megfelelő diát az indexe alapján.
3. Adj egy [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) elemet, és szerezze meg annak [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) objektumát.
4. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
5. Töltse be a golyó képet, és adja hozzá a prezentáció képgyűjteményéhez egy [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) formájában.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa be a [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType-int-) értékét a [BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/) típusra.
8. Rendelje hozzá a képet a [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture--) segítségével, és állítsa be a golyó magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Mentse el a módosított prezentációt.

Ez a PHP példa egy képgolyót hoz létre:

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

Állítsa be a [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth-short-) értékét a bekezdések listában való különböző szintekre helyezéséhez. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) objektumot, és szerezze meg egy diát.
2. Adj egy [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) elemet, és távolítsa el az alapértelmezett bekezdést a szövegdobozából.
3. Hozzon létre négy bekezdést, és konfigurálja azok golyó szimbólumait.
4. Állítsa be a [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth-short-) értékét `0`, `1`, `2` és `3` mélységre.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, és mentse el a prezentációt.

Ez a PHP példa egy négy szintű golyólistát hoz létre:

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

### **Számozott listaelemek kezdőértékének egyedi beállítása**

Használja a [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) metódust a számozott bekezdés kezdeti számának beállításához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) objektumot, és adj egy [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) elemet egy diára.
2. Távolítsa el az alapértelmezett bekezdést a forma szövegdobozából.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be a [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) értékét `2`, `3` és `7`‑re a megfelelő bekezdésekhez.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, és mentse el a prezentációt.

Ez a PHP példa egyéni kezdőszámot rendel minden bekezdéshez:

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

## **Bekezdéselrendezés és befejező tulajdonságok vezérlése**

### **Első sor behúzásának beállítása**

Használja a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) metódust az első sor behúzásának szabályozásához. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) metódust, ha a teljes bekezdést szeretné eltolni. Használja a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) metódust, ha csak az első sort akarja eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) értékeket alkalmaz, hogy bemutassa, miként befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztálypéldányt.
2. Szerezze meg a cél diát.
3. Adj egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) elemet a diára.
4. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) objektumát, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) értékeket.
6. Adja hozzá a bekezdéseket a szövegdobozhoz.
7. Mentse el a módosított prezentációt.

Ez a PHP kód bemutatja, hogyan állíthat be bekezdésbehúzást:

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

A függő behúzás egy olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides-ben ezt a hatást a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) segítségével hozhatja létre. Negatív értékkel mozgathatja az első sort balra a bekezdés törzséhez képest.

Gyakorlatban a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) határozza meg a bekezdés törzsének bal pozícióját, míg a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) állítja be az első sor pozícióját ehhez a margóhoz képest. Függő behúzás létrehozásához adjon pozitív értéket a `setMarginLeft`‑nek, és negatív értéket a `setIndent`‑nek.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedet-bejegyzések és más olyan bekezdések esetén, ahol a sortörésnek a bekezdés törzsének alá kell esnie, nem pedig az első sor első karaktere alá.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztálypéldányt.
2. Szerezze meg a cél diát.
3. Adj egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) elemet a diára.
4. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) objektumát, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és adjon pozitív értéket a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) minden bekezdéshez.
6. Adjon negatív értéket a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) számára a függő behúzás hatásának eléréséhez.
7. Adja hozzá a bekezdéseket a szövegdobozhoz.
8. Mentse el a módosított prezentációt.

Ez a PHP kód bemutatja, hogyan állíthat be függő behúzást egy bekezdéshez:

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

![A bekezdések függőbehúzása](hanging_indent.png)

### **Befejező bekezdésformázás beállítása**

A [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) vezérli a bekezdés befejező jelének formázását. Az alábbi PHP példa betűméretet és latin betűtípust rendel a második bekezdés befejező jeléhez:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) objektumot, és szerezze meg egy diát.
2. Adj egy [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) elemet, és törölje az alapértelmezett bekezdést.
3. Hozzon létre két bekezdést, és adjon hozzá szövegrészeket.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) objektumot a második bekezdés befejező jeléhez.
5. Állítsa be a [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) és a [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) értékeket.
6. Rendelje hozzá a formátumot a [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) segítségével, és mentse el a prezentációt.

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

A bekezdés szabályok, amelyek az automatikus tördelést és a sortörésnél lévő írásjeleket érintik, a [Control Line Breaking](/slides/hu/php-java/text-formatting/#control-line-breaking) és a [Control Hanging Punctuation](/slides/hu/php-java/text-formatting/#control-hanging-punctuation) oldalakon találhatók.

Használja a [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount--) metódust a bekezdés által elfoglalt sorok számának meghatározásához a szöveg elrendezése után, beleértve az automatikus tördelést. Ez hasznos a szöveghossz és az elrendezés ellenőrzésénél prezentációs sablonokban.

Egy bekezdés a [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs--) egy elemét képezi, és több megjelenített sort is elfoglalhat. Egy explicit sortörés a bekezdésen belül új sort kényszerít anélkül, hogy új bekezdést hozna létre. Az automatikus tördelés a rendelkezésre álló szélesség alapján hoz létre sorokat anélkül, hogy explicit sortöréseket illesztene a szövegbe. Így a bekezdések vagy a sortörés karakterek számlálása nem adja meg a megjelenített sorok számát.

Az alábbi példa egy szöveges alakzatot hoz létre, megszámolja a sorokat, szűkíti az alakzatot, majd egy rövidebb szövegre cseréli a tartalmat. A tördelés engedélyezett, az automatikus méretezés (autofit) le van tiltva, így az alakzat szélessége szabályozza a tördelést anélkül, hogy a szöveget vagy az alakzat méretét automatikusan csökkentené. Az alakzat méretei pontban vannak megadva. Végül a példa egy újabb bekezdést ad hozzá, és összegzi a sorok számát a szövegdobozban.

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

Ezzel a szöveggel és ezekkel a méretekkel a szűkítés növeli a sorok számát, míg a rövid szövegre való cserélés csökkenti azt. A pontos számlálás a betűtípus elérhetőségétől, helyettesítésétől, betűmérettől, margóktól, behúzásoktól, tördeléstől és az autofit beállításoktól függ. A célkörnyezethez szánt betűtípusok és elrendezési beállítások használata ajánlott sablon ellenőrzésekor.

A sorok száma önmagában nem határozza meg, hogy a szöveg túlnyúlik-e a tárolóján. A rendelkezésre álló magasság, a sormagasságok, a bekezdés- és sorköz, valamint az autofit viselkedés is számít; még egyetlen sor is túllépheti a rendelkezésre álló szélességet, ha a tördelés le van tiltva.

## **Bekezdéses tartalom importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódust HTML jelölőnyelv átalakításához bekezdésekké és részekké egy szövegdobozban.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztálypéldányt.
2. Szerezzen egy diát, és adj egy [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) elemet.
3. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) objektumát, és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás HTML fájlt.
5. Adja át a HTML karakterláncot a [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódusnak.
6. Mentse el a módosított prezentációt.

Ez a PHP példa HTML-t importál egy szövegdobozba:

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

### **Bekezdésszöveg exportálása HTML-be**

Használja a [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust a kiválasztott bekezdés-tartomány HTML-ként való exportálásához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztálypéldányt, és töltse be a kívánt prezentációt.
2. Szerezze meg a diát, és keresse meg azt az [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) elemet, amely a szöveget tartalmazza.
3. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) objektumát.
4. Hívja meg a [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a kapott HTML karakterláncot egy fájlba.

Ez a PHP példa az első szöveges alakzat összes bekezdését exportálja:

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

### **Bekezdés megjelenítése képként**

A [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage--) közvetlenül rendereli az egyes bekezdést, és egy [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) objektumot ad vissza. A végeredményt mentse fájlba vagy adatfolyamba a [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save-java.lang.String-int-) segítségével. Nem szükséges a tartalmazó alakzatot renderelni vagy a bitmapet manuálisan kivágni.

A [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage--) `null`‑t adhat vissza, ha a bekezdés nem található meg a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és a kép használata után szabadítsa fel.

#### **Bekezdés renderelése alapértelmezett méretarányban**

Tegyük fel, hogy van egy sample.pptx nevű prezentációs fájlunk egyetlen diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi PHP példa a második bekezdést rendeli a szokásos szöveges alakzatba alapértelmezett méretarányban, és a visszakapott képet PNG formátumban menti. A `finally` blokk biztosítja, hogy a kép helyesen legyen felszabadítva.

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

Használja a [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage-float-float-) túlterhelést, amely elfogadja a `$scaleX` és `$scaleY` paramétereket a vízszintes és függőleges méretarány beállításához. Az alábbi PHP példa egy táblázatot hoz létre, a bekezdést az első cellájában kétszeres szélesség és magasság mellett rendereli, és PNG képként menti az eredményt.

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

Az `1` méretarány megtartja az adott tengely alapértelmezett képpontméretét. Például a `2` mindkét tényezőnél két‑szoros szélességű és magasságú képet eredményez, ami négyszer annyi képpontot jelent. A nagyobb tényezők általában élesebb szöveget adnak a zoomoláshoz vagy a nagy felbontású kimenethez, de növelik a memóriahasználatot és a fájlméretet. Az `1`‑nél kisebb tényezők kisebb, kevésbé részletes képeket eredményeznek. Az arányok megtartásához használjon egyenlő tényezőket; a különböző vízszintes és függőleges tényezők függetlenül nyújtják a képet.

A forma teljes renderelése a [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage--) segítségével akkor hasznos, amikor a kimenetnek tartalmaznia kell a forma kitöltését, szegélyét vagy egyéb vizuális kontextusát. Egy csak bekezdés‑képhez használja a [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage--) metódust.

## **GYIK**

**Teljesen le lehet tiltani a sortörést egy szövegdobozon belül?**

Igen. Állítsa a [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText-byte-) értékét a tördelés letiltásához, így a sorok nem törnek meg a szövegdoboz szélén.

**Hogyan lehet lekérni egy adott bekezdés pontos dián lévő határait?**

Használja a [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect--) metódust a bekezdés körülhatároló téglalap lekéréséhez. A [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect--) egyetlen rész határait adja vissza.

**Hol van vezérelve a bekezdés igazítása (balra, jobbra, középre vagy sorkizárás)?**

A [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment-int-) bekezdés‑szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

A különböző betűméretű részek függőleges központosításához lásd a [Align Fonts Within a Line](/slides/hu/php-java/text-formatting/#align-fonts-within-a-line) cikket.

**Be lehet állítani a helyesírás-nyelvet a bekezdés egy részére?**

Igen. Állítsa be a [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) értékét az egyes részeknél, így egy bekezdés több nyelvet is tartalmazhat.