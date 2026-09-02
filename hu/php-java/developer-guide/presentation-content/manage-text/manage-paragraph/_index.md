---
title: "PowerPoint szöveg bekezdések kezelése PHP-ben"
linktitle: "Bekezdés kezelése"
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
- felsorolás kezelése
- bekezdés behúzása
- függőleges behúzás
- bekezdés pont
- számozott lista
- felsoroláslista
- bekezdés tulajdonságai
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
description: "Tanulja meg, hogyan hozhat létre és formázhat bekezdéseket, részegységeket, felsorolásjeleket, számozott listákat, behúzásokat, HTML tartalmat, és bekezdés képeket az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java a szöveget a szövegkeretek, bekezdések és részegységek hierarchiájaként reprezentálja:

* [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) a szövegtárolót jelenti egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést ad a részegységekhez és a bekezdésszintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) egy szövegrészt jelent egy bekezdésen belül. Minden részegységnek lehet saját szövege és karakter‑szintű formázása.

Egy bekezdés ezért több részegység használatával különböző betűtípusokat, színeket, méreteket és egyéb formázásokat tartalmazhat.

## **Bekezdések létrehozása és formázása**

### **Bekezdések létrehozása több részegységgel**

Az alábbi lépések egy szövegkeretet hoznak létre három bekezdéssel, mindegyik három részegységet tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Lépjen hozzá a megfelelő diára az indexén keresztül.
3. Adjon egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diára.
4. Hozzáférés a forma [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) eleméhez.
5. Használja az alapértelmezett bekezdést, és adjon hozzá két további [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) objektumot a szövegkerethez.
6. Adjon elegendő [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) objektumot minden bekezdéshez, hogy három részegységet tartalmazzanak. Az alapértelmezett bekezdés már egy üres részegységet tartalmaz.
7. Állítsa be minden részegység szövegét.
8. Alkalmazzon karakter‑szintű formázást a [Portion::getPortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/#getPortionFormat--) segítségével.
9. Mentse a módosított prezentációt.

Ez a PHP példa megvalósítja a fenti lépéseket:

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

## **Felsorolás és számozott listák létrehozása**

### **Felsorolás vagy számozott lista létrehozása**

A pontok és a számozás megkönnyítik a kapcsolódó elemek áttekintését. Az Aspose.Slides‑ben a lista beállításait a [BulletFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/) definiálja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Lépjen hozzá a megfelelő diára az indexén keresztül.
3. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a kiválasztott diára.
4. Hozzáférés a forma [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) eleméhez.
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) elemet egy szimbólum pont számára.
7. Állítsa a [BulletFormat::setType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setType-int-) értékét a [BulletType::Symbol](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bullettype/) típusra, és adja meg a pont karakterét.
8. Állítsa be a bekezdés szövegét, behúzását, pont színét és pont magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa a [BulletFormat::setType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setType-int-) értékét a [BulletType::Numbered](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bullettype/) típusra.
11. Konfigurálja a számozott pont stílusát, és adja hozzá a bekezdést a szövegkerethez.
12. Mentse a prezentációt.

Ez a PHP példa létrehoz egy szimbólum pontot és egy számozott pontot:

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

### **Kép pontok használata**

A kép pontok lehetővé teszik egy egyedi kép használatát a szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Lépjen hozzá a megfelelő diára az indexén keresztül.
3. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet, és érje el a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) elemet.
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltse be a pont képet, és adja hozzá a prezentáció képgyűjteményéhez [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) formájában.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa a [BulletFormat::setType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setType-int-) értékét a [BulletType::Picture](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bullettype/) típusra.
8. Rendelje hozzá a képet a [BulletFormat::getPicture](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#getPicture--) segítségével, és állítsa be a pont magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse a módosított prezentációt.

Ez a PHP példa létrehoz egy kép pontot:

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

A [ParagraphFormat::setDepth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setDepth-short-) beállításával helyezhetjük a bekezdéseket egy lista különböző szintjeire. A felső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) elemet, és lépjen hozzá egy diára.
2. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet, és törölje az alapértelmezett bekezdést a szövegkeretből.
3. Hozzon létre négy bekezdést, és állítsa be azok pont szimbólumait.
4. Állítsa be a [ParagraphFormat::setDepth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setDepth-short-) értékeket `0`, `1`, `2` és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse a prezentációt.

Ez a PHP példa létrehoz egy négyszintű felsorolt listát:

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

### **Számozott listaelemek egyéni kezdőértékkel**

Használja a [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) metódust a számozott bekezdés kezdeti számának beállításához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) elemet, és adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet egy diára.
2. Törölje az alapértelmezett bekezdést a forma szövegkeretéből.
3. Hozzon létre három számozott bekezdést.
4. Állítsa a [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) értékét `2`, `3` és `7`‑re a megfelelő bekezdésekhez.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse a prezentációt.

Ez a PHP példa minden bekezdésnek egyedi kezdőszámot ad meg:

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

## **Bekezdés elrendezés és végpont tulajdonságok szabályozása**

### **Első sor behúzás beállítása**

Használja a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setIndent-float-) metódust az első sor behúzásának szabályozásához. Ez a módszer csak az első sort mozgatja a bekezdés bal margójához képest. Pozitív érték esetén az első sor jobbra tolódik, míg a többi sor igazodik a bekezdéstörzshöz.

Használja a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) metódust, ha az egész bekezdést szeretné eltolni. Használja a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setIndent-float-) metódust, ha csak az első sorra van szükség.

Az alábbi példa több bekezdést hoz létre, és különböző [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setIndent-float-) értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Lépjen a cél diára.
3. Adjon egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diára.
4. Hozzáférés a forma [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) eleméhez, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setIndent-float-) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított prezentációt.

Ez a PHP kód megmutatja, hogyan állíthat be bekezdés behúzást:

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

### **Függőleges behúzás beállítása**

A függőleges behúzás (hanging indent) olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides‑ben ezt a hatást a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setIndent-float-) segítségével hozhatjuk létre. Negatív érték megadásával az első sor balra tolódik a bekezdés törzséhez képest.

Gyakorlatban a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) határozza meg a bekezdés törzs bal pozícióját, a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setIndent-float-) pedig az első sor pozícióját ehhez a margóhoz képest. Függőleges behúzás létrehozásához adjon meg egy pozitív értéket a `setMarginLeft`‑nak, és egy negatív értéket a `setIndent`‑nak.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedet-bejegyzések és más bekezdések esetén, ahol a sortörés alatti soroknak a bekezdés törzsénél kell igazodniuk, nem pedig az első sor első karakterénél.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Lépjen a cél diára.
3. Adjon egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet a diára.
4. Hozzáférés a forma [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) eleméhez, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és minden bekezdéshez adjon pozitív értéket a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) metódusnak.
6. Adjon negatív értéket a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setIndent-float-) metódusnak a függőleges behúzás hatás létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított prezentációt.

Ez a PHP kód megmutatja, hogyan állíthat be függőleges behúzást egy bekezdéshez:

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

![A bekezdések függőleges behúzása](hanging_indent.png)

### **Bekezdés vége tulajdonságainak beállítása**

A [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) szabályozza a bekezdés végjelének formázását. Az alábbi PHP példa a második bekezdés végjelére betűméretet és latin betűtípust állít be:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) elemet, és lépjen hozzá egy diára.
2. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet, és törölje az alapértelmezett bekezdést.
3. Hozzon létre két bekezdést, és adjon hozzá szövegrészeket.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/) objektumot a második bekezdés végjeléhez.
5. Állítsa be a [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) és a [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) értékeket.
6. Rendelje hozzá a formátumot a [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) metódussal, és mentse a prezentációt.

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

## **Bekezdés tartalom importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódust a HTML jelölők bekezdésekké és részegységekké konvertálásához egy szövegkeretben.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Lépjen egy diára, és adjon egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet.
3. Hozzáférés a forma [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) eleméhez, és távolítsa el az alapértelmezett bekezdést.
4. Olvassa be a forrás HTML fájlt.
5. Adja át a HTML szöveget a [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódusnak.
6. Mentse a módosított prezentációt.

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

### **Bekezdés szöveg exportálása HTML‑be**

Használja a [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust a kiválasztott bekezdéstartomány HTML‑ként való exportálásához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt, és töltse be a kívánt prezentációt.
2. Lépjen a diára, és keresse meg azt az [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet, amely a szöveget tartalmazza.
3. Hozzáférés a forma [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) eleméhez.
4. Hívja meg a [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszakapott HTML szöveget egy fájlba.

Ez a PHP példa exportálja az összes bekezdést az első szöveges alakzatról:

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

A [Paragraph::getImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#getImage--) közvetlenül rendereli az egyes bekezdéseket, és egy [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/) objektumot ad vissza. A visszakapott képet mentse fájlba vagy streambe a [IImage::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/#save-java.lang.String-int-) metódussal. Nem szükséges a tartalmazó alakzatot renderelni vagy bitmapet kézzel kivágni.

A [Paragraph::getImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#getImage--) `null` értéket adhat vissza, ha a bekezdés nem található a szülő gyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és a használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett méretezésben**

Tegyük fel, hogy van egy *sample.pptx* nevű prezentációs fájl egyetlen diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi PHP példa a második bekezdést rendereli egy szabványos szöveges alakzaton alapértelmezett méretezésben, és PNG formátumban menti a visszakapott képet. A `finally` blokk biztosítja a kép megfelelő felszabadítását.

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

Használja a [Paragraph::getImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#getImage-float-float-) túlterhelést, amely a `$scaleX` és `$scaleY` paramétereket fogadja a vízszintes és függőleges méretezési tényezők beállításához. Az alábbi PHP példa egy táblázatot hoz létre, a bekezdést az első cellájában kétszeres szélességre és magasságra rendereli, és PNG képként menti az eredményt.

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

Az `1` méretezési tényező megtartja az adott tengely alapértelmezett pixelméretét. Például a `2` mindkét tényezőre egy olyan képet eredményez, amelynek szélessége és magassága nagyjából kétszerese az alapértelmezettnek, így négyzetes pixelek száma négyszeres lesz. A nagyobb tényezők általában élesebb szöveget adnak nagyítás vagy nagy felbontású kimenet esetén, de növelik a memóriahasználatot és a fájlméretet. Az `1`‑nél kisebb tényezők kisebb, kevésbé részletes képeket eredményeznek. Azonos tényezők esetén megmarad a bekezdés aránya; a különböző vízszintes és függőleges tényezők függetlenül nyújtják a kimenetet.

Egy teljes alakzat renderelése a [Shape::getImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getImage--) metódussal akkor lehet hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, keretét vagy egyéb vizuális kontextusát. Kizárólag bekezdés‑képekhez használja a [Paragraph::getImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#getImage--) metódust.

## **GYIK**

**Teljesen letilthatom a sorok tördelését egy szövegkereten belül?**

Igen. Állítsa a [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setWrapText-byte-) értékét a tördelés letiltásához, így a sorok nem törnek a szövegkeret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos dián belüli határait?**

Használja a [Paragraph::getRect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#getRect--) metódust a bekezdés határoló téglalapjának lekéréséhez. A [Portion::getRect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/#getRect--) egyetlen részegység határait adja vissza.

**Hol szabályozható a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

A [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setAlignment-int-) bekezdés‑szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyes részegységek formázásától.

**Beállíthatok helyesírási nyelvet egy bekezdés egy részére?**

Igen. Állítsa a [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) értékét az egyes részegységekhez, így egy bekezdés több nyelvű szöveget is tartalmazhat.