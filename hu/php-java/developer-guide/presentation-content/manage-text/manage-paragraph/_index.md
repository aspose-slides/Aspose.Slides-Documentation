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
- felsoroláslista
- bekezdés tulajdonságai
- HTML importálása
- szöveg HTML-be
- bekezdés HTML-be
- bekezdés képpé
- szöveg képpé
- bekezdés exportálása
- PowerPoint
- bemutató
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, felsorolásokat, számozott listákat, behúzásokat, HTML tartalmakat és bekezdés képeket az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java a szöveget szövegdobozok, bekezdések és részletek hierarchiájaként ábrázolja:

* [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) egy alakzat szövegtárolója, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) egy bekezdést képvisel egy szövegdobozban, és hozzáférést biztosít a részleteihez és a bekezdés-szintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) egy szövegszakaszt képvisel egy bekezdésen belül. Minden részlet saját szöveggel és karakter-szintű formázással rendelkezhet.

Ezáltal egy bekezdés több részlet használatával különböző betűtípusú, színű, méretű és egyéb formázású szöveget tartalmazhat.

## **Bekezdések létrehozása és formázása**

### **Több részlettel rendelkező bekezdések létrehozása**

A következő lépések egy szövegdobozt hoznak létre három bekezdéssel, amely mindegyike három részt tartalmaz:

1. Hozzon létre egy példányt a [Presentation] osztályból.
2. Hozzáférés a megfelelő diához az indexén keresztül.
3. Hozzon egy téglalap alakú [AutoShape]-t a diára.
4. Hozzáférés az alakzat [TextFrame]-hez.
5. Használja az alapértelmezett bekezdést, és adjon hozzá két további [Paragraph] objektumot a szövegdobozhoz.
6. Hozzon elegendő [Portion] objektumot minden bekezdéshez, hogy három részt tartalmazzanak. Az alapértelmezett bekezdés már egy üres részt tartalmaz.
7. Állítsa be minden részlet szövegét.
8. Alkalmazza a karakter-szintű formázást a [Portion::getPortionFormat] segítségével.
9. Mentse a módosított bemutatót.

Ez a PHP példa a lépéseket valósítja meg:

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

A felsorolások és a számozás megkönnyítik a kapcsolódó elemek átláthatóbbá tételét. Az Aspose.Slides‑ben a lista beállításait a [BulletFormat] határozza meg.

1. Hozzon létre egy példányt a [Presentation] osztályból.
2. Hozzáférés a megfelelő diához az indexén keresztül.
3. Hozzon egy [AutoShape]-t a kiválasztott diára.
4. Hozzáférés az alakzat [TextFrame]-hez.
5. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
6. Hozzon létre egy [Paragraph]-t egy szimbólum felsoroláshoz.
7. Állítsa a [BulletFormat::setType] értékét [BulletType::Symbol]-ra, és adja meg a felsorolás karakterét.
8. Állítsa be a bekezdés szövegét, behúzását, a felsorolás színét és magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Hozzon létre egy második bekezdést, és állítsa a [BulletFormat::setType] értékét [BulletType::Numbered]-ra.
11. Konfigurálja a számozott felsorolás stílusát, majd adja hozzá a bekezdést a szövegdobozhoz.
12. Mentse a bemutatót.

Ez a PHP példa egy szimbólum felsorolást és egy számozott felsorolást hoz létre:

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

### **Képes felsorolások használata**

A képes felsorolások lehetővé teszik egyedi kép használatát szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation] osztályból.
2. Hozzáférés a megfelelő diához az indexén keresztül.
3. Hozzon egy [AutoShape]-t, és férjen hozzá a [TextFrame]-hez.
4. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
5. Töltse be a felsorolás képet, és adja hozzá a bemutató képgyűjteményéhez [PPImage]-ként.
6. Hozzon létre egy [Paragraph]-t, és állítsa be a szövegét.
7. Állítsa a [BulletFormat::setType] értékét [BulletType::Picture]-ra.
8. Adja hozzárendelésként a képet a [BulletFormat::getPicture] segítségével, és állítsa be a felsorolás magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Mentse a módosított bemutatót.

Ez a PHP példa egy képes felsorolást hoz létre:

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

A [ParagraphFormat::setDepth] beállításával a bekezdéseket a lista különböző szintjeire helyezheti. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation]-t, és férjen hozzá egy diához.
2. Hozzon egy [AutoShape]-t, és tisztítsa meg a szövegdoboz alapértelmezett bekezdését.
3. Hozzon létre négy bekezdést, és állítsa be a felsorolás szimbólumait.
4. Állítsa be a [ParagraphFormat::setDepth] értékeket `0`, `1`, `2` és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, majd mentse a bemutatót.

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

### **Számozott listaelemek indítása egyedi értékekkel**

A [BulletFormat::setNumberedBulletStartWith] használatával beállíthatja a számozott bekezdés kezdeti számát.

1. Hozzon létre egy [Presentation]-t, és adjon egy [AutoShape]-t egy diához.
2. Tisztítsa meg az alakzat szövegdobozának alapértelmezett bekezdését.
3. Hozzon létre három számozott bekezdést.
4. Állítsa a [BulletFormat::setNumberedBulletStartWith] értékét `2`, `3` és `7`‑re a megfelelő bekezdésekhez.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, majd mentse a bemutatót.

Ez a PHP példa minden bekezdéshez egyedi kezdőszámot állít be:

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

## **Bekezdés elrendezés és végjellemzők vezérlése**

### **Első sor behúzásának beállítása**

A [ParagraphFormat::setIndent] használatával szabályozhatja egy bekezdés első sorának behúzását. Ez a módszer csak az első sort mozdítja el a bekezdés bal margójához képest. Pozitív érték esetén az első sor jobbra tolódik, míg a többi sor a bekezdés törzséhez igazodik.

Ha az egész bekezdést szeretné eltolni, használja a [ParagraphFormat::setMarginLeft]‑t. Ha csak az első sort akarja eltolni, használja a [ParagraphFormat::setIndent]‑t.

Az alábbi példa több bekezdést hoz létre, és különböző [ParagraphFormat::setIndent] értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation] osztályból.
2. Hozzáférés a céldiához.
3. Hozzon egy téglalap alakú [AutoShape]-t a diára.
4. Hozzáférés az alakzat [TextFrame]-hez, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [ParagraphFormat::setIndent] értékeket számukra.
6. Adja hozzá a bekezdéseket a szövegdobozhoz.
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

A függő behúzás egy olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides‑ben ezt a hatást a [ParagraphFormat::setIndent] segítségével hozhatja létre. Negatív érték megadásával az első sor balra kerül a bekezdés törzséhez képest.

A gyakorlatban a [ParagraphFormat::setMarginLeft] határozza meg a bekezdés törzs bal pozícióját, a [ParagraphFormat::setIndent] pedig az első sor relatív helyzetét ehhez a margóhoz képest. Függő behúzás létrehozásához adjon pozitív értéket a `setMarginLeft`‑nek, és negatív értéket a `setIndent`‑nek.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedetek és egyéb bekezdések esetén, ahol a sortöréses soroknak a bekezdés törzsének alá kell illeszkedniük, nem pedig az első sor első karaktere alá.

1. Hozzon létre egy példányt a [Presentation] osztályból.
2. Hozzáférés a céldiához.
3. Hozzon egy téglalap alakú [AutoShape]-t a diára.
4. Hozzáférés az alakzat [TextFrame]-hez, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és adjon minden bekezdéshez pozitív értéket a [ParagraphFormat::setMarginLeft]‑nek.
6. Adjon negatív értéket a [ParagraphFormat::setIndent]‑nek a függő behúzás létrehozásához.
7. Adja hozzá a bekezdéseket a szövegdobozhoz.
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

### **Bekezdés végjellemzőinek beállítása**

A [Paragraph::setEndParagraphPortionFormat] szabályozza a bekezdés végjeleinek formázását. Az alábbi PHP példa egy betűméretet és latin betűtípust állít be a második bekezdés végjele számára:

1. Töltsön be egy [Presentation]‑t, és férjen hozzá egy diához.
2. Adjon egy [AutoShape]-t, és törölje annak alapértelmezett bekezdését.
3. Hozzon létre két bekezdést, és adjon hozzá szövegrészeket.
4. Hozzon létre egy [PortionFormat]-ot a második bekezdés végjeléhez.
5. Állítsa be a [BasePortionFormat::setFontHeight] és a [BasePortionFormat::setLatinFont] értékeket.
6. Rendelje hozzá a formátumot a [Paragraph::setEndParagraphPortionFormat]‑nel, majd mentse a bemutatót.

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

A bekezdés szabályok, amelyek az automatikus sortörést és a sorvégi írásjelek kezelését befolyásolják, lásd a [Sorok tördelésének vezérlése](/slides/hu/php-java/text-formatting/#control-line-breaking) és a [Függő központozás vezérlése](/slides/hu/php-java/text-formatting/#control-hanging-punctuation) című oldalakon.

Használja a [Paragraph::getLinesCount]‑t, hogy megszámolja egy bekezdés által a szöveg elrendezése után foglalt sorokat, beleértve az automatikus sortörést. Ez akkor hasznos, ha a szöveg hossza és elrendezése ellenőrzése a prezentációs sablonokban történik.

A bekezdés a [TextFrame::getParagraphs] egy eleme, és több megjelenített sort is elfoglalhat. Egy explicita sortörés a bekezdésen belül új sort hoz létre anélkül, hogy új bekezdést generálna. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat, anélkül, hogy a szövegbe explicita sortörést illesztene. Így a bekezdések vagy sortörés karakterek számlálása nem adja meg a megjelenített sorok számát.

Az alábbi példa egy szövegalakzatot hoz létre, megszámolja a sorait, szűkíti az alakzatot, majd rövidebb szövegre cseréli. A sortörés be van kapcsolva, a méretezés automatikus igazítása le van tiltva, így a forma szélessége szabályozza a sortörést anélkül, hogy a szöveget automatikusan kicsinyítené vagy az alakzat méretét módosítaná. A forma méretei pontban vannak megadva. Végül a példa egy további bekezdést ad hozzá, és összeadja a sorok számát a szövegdobozon belül.

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

Ezzel a szöveggel és ezekkel a méretekkel a forma szűkítése növeli a sorok számát, míg a rövid szövegre cserélés csökkenti azt. A pontos számok a betűtípusok elérhetőségétől, a helyettesítésektől, a betűmérettől, a margóktól, a behúzásoktól, a sorcímzéstől és az automatikus igazítás beállításaitól függnek. A sablon ellenőrzésekor használja a célnyelv környezetéhez tervezett betűtípusokat és elrendezési beállításokat.

A sorok száma önmagában nem határozza meg, hogy a szöveg túllépi‑e a tárolóját. A rendelkezésre álló magasság, a sormagasság, a bekezdés‑ és sorköz, valamint az automatikus igazítás viselkedése is számít; még egyetlen sor is túlságosan széles lehet, ha a sortörés ki van kapcsolva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

A [ParagraphCollection::addFromHtml] használatával a HTML‑mark-upot átalakíthatja bekezdésekké és részekké egy szövegdobozban.

1. Hozzon létre egy példányt a [Presentation] osztályból.
2. Hozzáférés egy diához, és adjon egy [AutoShape]-t.
3. Hozzáférés az alakzat [TextFrame]-hez, és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás‑HTML‑fájlt.
5. Adja át a HTML‑szöveget a [ParagraphCollection::addFromHtml]‑nek.
6. Mentse a módosított bemutatót.

Ez a PHP példa a HTML‑t importálja egy szövegdobozba:

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

A [ParagraphCollection::exportToHtml] használatával egy kiválasztott bekezdéssort exportálhat HTML‑ként.

1. Hozzon létre egy példányt a [Presentation] osztályból, és töltse be a kívánt bemutatót.
2. Hozzáférés a diához, és keresse meg a szöveget tartalmazó [AutoShape]-t.
3. Hozzáférés az alakzat [TextFrame]-hez.
4. Hívja meg a [ParagraphCollection::exportToHtml]‑t a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszaadott HTML‑szöveget egy fájlba.

Ez a PHP példa az első szövegalakzat összes bekezdését exportálja:

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

A [Paragraph::getImage] közvetlenül egy bekezdést renderel, és egy [IImage] objektumot ad vissza. A kép menthető fájlba vagy stream‑be a [IImage::save]‑val. Nem szükséges a tartalmazó alakzatot renderelni vagy bitmapet manuálisan kivágni.

A [Paragraph::getImage] `null`‑t adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt mentés előtt, és a használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett méretezésben**

Tegyük fel, hogy van egy sample.pptx nevű prezentációfájl egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi PHP példa a második bekezdést egy szabályos szövegalakzatban alapértelmezett méretezésben rendereli, és PNG formátumban menti a kapott képet. A `finally` blokk biztosítja, hogy a kép helyesen legyen felszabadítva.

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

Használja a [Paragraph::getImage]‑t, amely a `$scaleX` és `$scaleY` paramétereket fogadja, hogy beállítsa a horizontális és vertikális skálafaktorokat. Az alábbi PHP példa létrehoz egy táblázatot, a bekezdést az első cellájában kétszeres alapméretű szélességgel és magassággal rendereli, majd PNG képként menti az eredményt.

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

Az 1‑es skálafaktor megtartja az adott tengely alappixelméretét. Például a 2‑es érték mindkét tengelyen egy képet eredményez, amelynek szélessége és magassága körülbelül kétszerese az alapméreteknek, ezáltal négyzetes pixelarányú. A nagyobb faktort általában élesebb szöveghez használják nagy felbontású kimenet vagy nagyítás esetén, de a memóriahasználatot és a fájlméretet is növelik. 1‑nél kisebb faktort kisebb, kevésbé részletgazdag képekhez használunk. Egyenlő faktorok esetén a bekezdés arányait megőrizhetjük; eltérő horizontális és vertikális faktort alkalmazva a kimenet külön-külön nyúlik.

Egy egész alakzat renderelése a [Shape::getImage]‑vel akkor is hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, keretét vagy más vizuális kontextusát. Ha csak a bekezdésre van szükség, használja a [Paragraph::getImage]‑t.

## **GYIK**

**Letilthatom teljesen a sorok automatikus tördelését egy szövegdobozban?**

Igen. Állítsa a [TextFrameFormat::setWrapText] értékét, hogy letiltsa a tördelést, így a sorok nem törnek meg a szövegdoboz szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos helyi határait a dián?**

Használja a [Paragraph::getRect]‑et a bekezdés körülhatároló téglalap lekéréséhez. A [Portion::getRect] egyedi részlet határait adja vissza.

**Hol szabályozható a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

A [ParagraphFormat::setAlignment] egy bekezdés‑szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyedi részletek formázásától.

**Beállíthatok lektorálási nyelvet a bekezdés egy részére?**

Igen. Állítsa a [BasePortionFormat::setLanguageId]‑t egyedi részletekhez, így egy bekezdés több nyelven írt szöveget tartalmazhat.