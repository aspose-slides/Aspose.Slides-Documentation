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
  - felsorolás kezelése
  - bekezdés behúzása
  - függő behúzás
  - bekezdés felsorolás
  - számozott lista
  - felsorolásos lista
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
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, szakaszokat, felsorolásjeleket, számozott listákat, behúzásokat, HTML‑tartalmat és bekezdés képeket az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for PHP via Java a szöveget a szövegkeretek, bekezdések és szakaszok (Portion) hierarchiájaként ábrázolja:

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) a szöveget egy alakzatban tartalmazó konténer, és hozzáférést biztosít a bekezdések gyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést ad a szakaszokhoz és a bekezdés szintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) egy szövegrészt (run) képvisel egy bekezdésen belül. Minden szakasz saját szöveget és karakter szintű formázást tartalmazhat.

Egy bekezdés ezért több szakasz használatával különböző betűtípusú, színű, méretű és egyéb formázású szöveget tartalmazhat.

## **Bebe​dzések létrehozása és formázása**

Bekédzéseket hozunk létre egy alakzat szövegkeretében, és szakaszokkal formázzuk az egyes szövegrészeket. Ez a szakasz bemutatja, hogyan kombináljunk több szakaszt minden bekezdésben, és alkalmazzunk különböző színeket, betűméreteket és stílusokat.

### **Bebe​dzések létrehozása több szakaszzal**

Az alábbi PHP példakód három bekezdést hoz létre, mindegyik három szövegrészt (run) tartalmaz a [Paragraph::getPortions](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getPortions) által visszaadott gyűjteményben. Az alapértelmezett bekezdést és annak üres szakaszát újra felhasználja, majd hozzáadja a maradék bekezdéseket és szakaszokat. A formázás a [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat) segítségével történik: az első szakasz minden bekezdésben piros, félkövér és 15 pt; a második kék, dőlt és 18 pt. A harmadik szakasz az alapértelmezett formázást megtartja:

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

## **Felsorolásos és számozott listák létrehozása**

Rendezzük a bekezdésszöveget listákká szimbólumokkal, számokkal vagy egyedi képekkel. Ebben a szakaszban a felsorolás formázását, többszintű listákat és egyedi kezdőszámokat tárgyaljuk.

### **Felsorolásos vagy számozott lista létrehozása**

A felsorolások és a számozás segítik a kapcsolódó elemek gyors áttekintését. Az Aspose.Slides-ben a lista beállításait a [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) definiálja.

Ez a PHP példa egy szimbólum felsorolást és egy számozott elemet ad hozzá ugyanahhoz a szövegkerethez. A [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) kiválasztja a felsorolás típusát, a [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) a szimbólumot adja meg, a [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) pedig a számozási stílust. Mindkét elem fekete felsorolást használ 100 százalékos magassággal és 25 point bekezdés behúzással:

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

### **Kép alapú felsorolások használata**

A kép alapú felsorolások lehetővé teszik egy egyedi kép használatát szimbólum vagy szám helyett.

Ez a PHP példa egy képet ad a bemutató képgyűjteményéhez, mint egy [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/), és azt használja bekezdés felsorolásként. A [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) hívással képfelsorolást állít be, és a képet a [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture) segítségével rendeli hozzá. A [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) 100 százalékra van állítva, hogy a felsorolás mérete a bekezdés szövegéhez viszonyítva legyen:

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

A [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) beállítása lehetővé teszi a bekezdések elhelyezését a lista különböző szintjein. A legfelső szint mélysége `0`.

Ez a PHP példa a [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) értékét 0‑tól 3‑ig állítja négy bekezdésre, egy hierarchiát hozva létre egy szövegkeretben. Minden bekezdés szimbólum felsorolást használ, a [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) váltogatva egy kört és egy kötőjelet a szintkülönbségek jelzésére:

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

### **Számozott listaelemek indítása egyedi értékekkel**

A [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) segítségével beállítható a számozott bekezdés kezdeti száma.

Ez a PHP példa a [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) beállításával három bekezdéshez számozást ad, majd a [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) értékét 2, 3 és 7‑re állítja. A kezdőérték minden bekezdésnél külön konfigurálható, lehetővé téve a számok kihagyását:

```php
use aspose\slides\BulletType;
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

## **A bekezdés elrendezésének és végjellemzőinek vezérlése**

A bekezdés margóinak és behúzásainak módosításával szabályozható az első sor és a tördelés utáni sorok helyzete. A bekezdés végjelét is külön formázhatjuk a látható szövegszakaszoktól.

### **Első sor behúzásának beállítása**

A [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) metódussal szabályozható egy bekezdés első sorának behúzása. Ez a beállítás csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés testhez igazodik.

Használja a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) metódust, ha az egész bekezdést szeretné elmozgatni. Használja a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) metódust, ha csak az első sort szeretné elmozgatni.

Az alábbi példa három bekezdésnek ugyanazt a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) 20 point értéket és a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) 0, 20, 40 point értékeket adja. Az első sorok fokozatosan nagyobb eltolással indulnak, míg a tördelés utáni sorok ugyanazt a bal margót tartják:

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

![Az első sor behúzása a bekezdésekben](first_line_indent.png)

### **Függő behúzás beállítása**

A függő behúzás olyan bekezdéselrendezés, ahol az első sor balra helyezkedik a maradék sorokhoz képest. Az Aspose.Slides-ben ezt a hatást a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) tulajdonsággal hozhatja létre. Az `Indent` negatív értékével az első sor balra tolódik a bekezdés törzséhez képest.

Gyakorlatban a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) határozza meg a bekezdés törzsének bal pozícióját, a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) pedig az első sor pozícióját ehhez a margóhoz képest. Függő behúzás létrehozásához állítson be pozitív `MarginLeft` értéket és negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedetek és más bekezdések esetén, ahol a tördelés utáni sorok a bekezdés törzsének alá kell, hogy illeszkedjenek, nem pedig az első sor első karakteréhez.

Az alábbi PHP példa a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) 40 és 60 point értékeit párosítja a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) -20 és -30 point értékeivel. Minden bekezdésnél az első sor balra indul a tördelés utáni sorokhoz képest; a második bekezdés mélyebb függő behúzást mutat:

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

### **A bekezdés végjellemzőinek beállítása**

A [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) metódus szabályozza a bekezdés végjellemzőjének formázását. Az alábbi példa egy [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) objektumot hoz létre, amelynek [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) értéke 48 point, és [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont) értéke Times New Roman. Ezt a formátumot a második bekezdés végjellemzőjéhez rendeli, a látható szövegszakaszokat változatlanul hagyva:

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

## **Renderelt sorok számlálása**

A bekezdés szabályairól, amelyek az automatikus tördelést és a sorvégi írásjeleket befolyásolják, lásd a [Control Line Breaking](/slides/hu/php-java/text-formatting/#control-line-breaking) és a [Control Hanging Punctuation](/slides/hu/php-java/text-formatting/#control-hanging-punctuation) oldalakat.

A [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) metódus segítségével megszámolhatók a bekezdés által elfoglalt sorok a szöveg elrendezése után, beleértve az automatikus tördelést. Ez hasznos a szöveg hossza és elrendezése ellenőrzésénél prezentációs sablonokban.

Egy bekezdés egy elem a [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs) gyűjteményben, és akár több renderelt sort is elfoglalhat. Egy expliciten beillesztett sortörés a bekezdésen belül új sort hoz létre anélkül, hogy új bekezdést generálna. Az automatikus tördelés a rendelkezésre álló szélesség alapján hoz létre sorokat anélkül, hogy explicit sortöréseket illesztene a szövegbe. Így a bekezdések vagy sortörés karakterek számlálása nem adja meg a renderelt sorok számát.

Az alábbi példa létrehoz egy szövegalakzatot, megszámolja a sorait, szűkíti az alakzatot, majd egy rövidebb karakterlánccal helyettesíti a szöveget. A példa engedélyezi a tördelést a [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) használatával, és letiltja az autofit-et a [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) segítségével, így az alakzat szélessége szabályozza a tördelést anélkül, hogy automatikusan kicsinyítené a szöveget vagy átméretezné az alakzatot. Minden mérés a [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) metódusra épül. Az alakzat méretei pontban vannak megadva. Végül a példa egy újabb bekezdést ad hozzá, és összeadja a sorok számát a szövegkeretben.

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

Ezzel a szöveggel és ezekkel a méretekkel a forma szűkítése növeli a sorok számát, míg a szöveg rövid karakterlánccal való cseréje csökkenti azt. A pontos számok változhatnak a betűtípus elérhetősége és helyettesítése, betűméret, margók, behúzások, tördelés és autofit beállítások függvényében. A célkörnyezethez szánt betűtípusok és elrendezési beállítások használata ajánlott sablonellenőrzéskor.

A sorok száma önmagában nem határozza meg, hogy a szöveg túlcsordul‑e a tárolóján. A rendelkezésre álló magasság, sormagasság, bekezdés‑ és sorköz, valamint az autofit viselkedése is számít; még egyetlen sor is túllépheti a rendelkezésre álló szélességet, ha a tördelés ki van kapcsolva.

## **Bekédzések tartalmának importálása és exportálása**

Használjon HTML‑t a szöveg bemutatóba történő beviteléhez vagy a meglévő bekezdések exportálásához, hogy azokat a prezentáción kívül is felhasználhassa. Ez a szakasz bemutatja, hogyan rendereljünk egyedi bekezdéseket képként, beleértve a táblázatcellákban lévő bekezdéseket is.

### **HTML‑szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) metódust, hogy a HTML‑markupot bekezdésekké és szakaszokká konvertálja egy szövegkeretben.

Ez a PHP példa egy fájlból olvas be HTML‑t, és azt a [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) metódusnak adja át. Törli a szövegkeret alapértelmezett bekezdését, így a keret csak a importált tartalmat tartalmazza. A téglalap alakzat minden dián 10 point margót hagy a széleken:

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

### **Bekédzés szövegének exportálása HTML‑be**

Használja a [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml) metódust, hogy a kiválasztott bekezdéstaranyagot HTML‑ként exportálja. Amikor egy prezentáció szövegét egy weboldalon szeretné újra felhasználni, megőrizheti a helyi hangsúlyt anélkül, hogy a prezentáció betűtípusát, méretét vagy szövegdoboz‑stílusait átvenné. Állítsa be a [TextToHtmlConversionOptions::setTextInheritanceLimit](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) értékét, hogy meghatározza, mennyire követi az exportáló a formázási öröklődést.

Töltse le a [példa‑prezentációt](text-inheritance.pptx), és helyezze az alkalmazás munkakönyvtárába. Az első dián egy szövegdoboz található a "Inherited text; explicit red 18pt" szöveggel. A bemenet szándékosan több formázási szintet használ:

- A prezentáció alapértelmezett szövegstílusa Calibri‑t és 28 pt méretet biztosít.
- A szövegkeret első szintű szövegstílusa kék szöveget és dőlt formátumot ad.
- A bekezdés expliciten félkövér szöveget állít be.
- A második szakasz, "explicit red 18pt", expliciten piros szöveget és 18 pt méretet ad meg.

Az alábbi teljes példa háromszor exportálja ugyanazokat a bekezdéseket. A [TextToHtmlConversionOptions](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/) objektumot átadja az exportálási metódusnak, és minden eredményt külön UTF‑8 HTML‑fájlba ír:

```php
use aspose\slides\Presentation;
use aspose\slides\TextInheritanceLimit;
use aspose\slides\TextToHtmlConversionOptions;

$presentation = new Presentation("text-inheritance.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();

            $modes = array(TextInheritanceLimit::All, TextInheritanceLimit::TextBox, TextInheritanceLimit::ParagraphOnly);
            $fileNames = array("All.html", "TextBox.html", "ParagraphOnly.html");

            for ($i = 0; $i < count($modes); $i++) {
                $options = new TextToHtmlConversionOptions();
                $options->setTextInheritanceLimit($modes[$i]);

                $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), $options);
                if (file_put_contents($fileNames[$i], java_values($html)) === false) {
                    echo "The HTML file could not be written." . PHP_EOL;
                }
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

A generált HTML a következő CSS‑t tartalmazza az első szakaszhoz, "Inherited text; ". A táblázat a releváns deklarációkat sorolja fel; a többi generált tulajdonság el van hagyva az egyszerűség kedvéért.

| Kimenet | Az első szakaszra vonatkozó releváns CSS | Megjelenés |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg 28 pt Calibri betűtípussal, ha ez a betűtípus elérhető. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg; a környező oldal vagy böngésző biztosítja a betűcsaládot és a méretet. |
| `ParagraphOnly.html` | `font-weight:bold` | Félkövér szöveg; a környező oldal vagy böngésző biztosítja a betűcsaládot, méretet, színt és a dőlt stílust. |

A második szakasz minden három kimenetben megtartja a `color:#ff0000`, `font-size:18pt` és `font-weight:bold` beállításokat. Emellett az `All` és a `TextBox` esetén megtartja a dőlt stílust, de a `ParagraphOnly` nem. Az öröklődés korlátozása tehát nem távolítja el a bekezdéshez vagy szakaszhoz explicit módon hozzárendelt formázást.

Nyissa meg a fájlokat ugyanabban a böngészőben a összehasonlításhoz. A két korlátozott módban a kihagyott CSS‑tulajdonságok a céloldal stílusai vagy a böngésző alapértékei alapján kerülnek feloldásra, így a végső megjelenés a HTML használati környezetétől függ.

### **HTML‑vágólap‑fragmentum generálása**

Használja a [TextToHtmlConversionOptions::setAddClipboardFragmentHeader](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/#setAddClipboardFragmentHeader) beállítást, hogy kiválassza a [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml) kimenet típusát. `false` esetén a metódus szokványos HTML‑t ad vissza. `true` esetén a visszaadott sztring egy Windows vágólap‑fejlécet tartalmaz. A `StartHTML` és `EndHTML` mezők a HTML UTF‑8 bájteltolását adják meg, míg a `StartFragment` és `EndFragment` a beillesztendő tartalmat jelöli.

Ez a példa két formázott bekezdést exportál szokványos HTML‑ként (`$html`) és HTML‑vágólap‑fragmentumként (`$clipboardHtml`). Az alkalmazás ezután a fragmentumot a rendszer‑vágólapra írhatja. Ha a vágólap‑API nyers bájtokat vár, adja át a fragmentumot UTF‑8‑ként BOM nélkül.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextToHtmlConversionOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 400, 100);
    $paragraphs = $shape->getTextFrame()->getParagraphs();
    $paragraphs->clear();
    $paragraphs->addFromHtml("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>");

    $options = new TextToHtmlConversionOptions();
    $options->setAddClipboardFragmentHeader(false);
    $html = java_values($paragraphs->exportToHtml(0, $paragraphs->getCount(), $options));

    $options->setAddClipboardFragmentHeader(true);
    $clipboardHtml = java_values($paragraphs->exportToHtml(0, $paragraphs->getCount(), $options));
} finally {
    $presentation->dispose();
}
```

### **Bekédzés renderelése képként**

A [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) közvetlenül renderel egy egyedi bekezdést, és egy [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) objektumot ad vissza. Az eredményt a [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) segítségével fájlba vagy streambe mentheti. Nem szükséges a környező alakzatot renderelni vagy kézzel bitmapet vágni.

A [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) `null`‑t adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és a felhasználás után szabadítsa fel a visszaadott képet.

#### **Bekédzés renderelése az alapértelmezett méretezésben**

A példa egy egyetlen diát tartalmazó prezentációt használ, amelynek első alakzata egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdéses szövegdoboz](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést (index 1) választja ki, és a [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) metódust skálaparaméterek nélkül hívja meg. Ellenőrzi, hogy az alakzat tartalmazza‑e a szükséges bekezdést, és a renderelés visszaad-e képet, mielőtt a [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) metódussal PNG formátumban mentené. A `finally` blokk a használat után felszabadítja a képet.

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

#### **Bekédzés renderelése táblázat‑cellában skálázással**

Használja a [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) túltöltését, amely `$scaleX` és `$scaleY` paraméterekkel veszi a vízszintes és függőleges skálafaktorokat. Az alábbi példa egy táblázatot hoz létre, és a bekezdést az első cellájában a alapméret kétszeres szélességén és magasságán rendereli, majd PNG képként menti.

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

Az `1` érték megtartja az adott tengelyt az alap pixelméretén. Például a `2` mindkét faktor esetén olyan képet eredményez, amelynek szélessége és magassága megközelítőleg kétszerese az alapméreteknek, így négyzet alakú pixelek keletkeznek. A nagyobb faktorok általában élesebb szöveget eredményeznek nagyítás vagy nagy felbontású kimenet esetén, de növelik a memóriahasználatot és a fájlméretet. Az `1` alatti faktorok kisebb képet hoznak kevesebb részlettel. A bekezdés arányának megőrzéséhez használjon azonos faktorokat; a különböző vízszintes és függőleges faktorok függetlenül nyújtják a kimenetet.

Az egész alakzat renderelése a [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) segítségével akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Egy csak bekezdés‑képre, a [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) használata a megfelelő megoldás.

## **GYIK**

**Teljesen le szeretném tiltani a sorok automatikus tördelését egy szövegkereten belül?**

Igen. Állítsa a [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) értékét úgy, hogy letiltsa a tördelést, így a sorok nem szakadnak meg a szövegkeret szélein.

**Hogyan kaphatom meg egy adott bekezdés pontos, dián lévő határait?**

Használja a [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) metódust a bekezdés körülhatároló téglalap lekéréséhez. A [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect) egy egyedi szakasz határait adja vissza.

**Hol vezérelhető a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

A [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) bekezdés‑szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyes szakaszok formázásától.

A különböző betűméretű szakaszok függőleges igazításához minden sorban lásd a [Align Fonts Within a Line](/slides/hu/php-java/text-formatting/#align-fonts-within-a-line) oldalt.

**Beállíthatom a nyelvtani ellenőrzés nyelvét a bekezdés egy részére?**

Igen. Állítsa a [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) értékét egyedi szakaszokra, így egy bekezdés több nyelven is tartalmazhat szöveget.