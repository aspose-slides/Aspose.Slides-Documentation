---
title: PowerPoint szöveg bekezdések kezelése PHP-ben
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/php-java/manage-paragraph/
keywords:
- szöveg hozzáadása
- bekezdés hozzáadása
- szöveg kezelése
- bekezdés kezelése
- pont kezelése
- bekezdés behúzása
- függőleges behúzás
- bekezdés pont
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
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Mestere a bekezdésformázásnak az Aspose.Slides for PHP via Java használatával — optimalizálja az igazítást, távolságot és a stílust PPT, PPTX és ODP prezentációkban."
---
## **Bevezetés**

Az Aspose.Slides minden osztályt biztosít, amelyre a PowerPoint szövegek, bekezdések és szakaszok kezeléséhez szükség van.

* Az Aspose.Slides a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) osztályt biztosítja, amely lehetővé teszi bekezdést reprezentáló objektumok hozzáadását. egy `TextFame` objektum egy vagy több bekezdést tartalmazhat (minden bekezdés egy sortöréssel jön létre).
* Az Aspose.Slides a [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) osztályt biztosítja, amely lehetővé teszi szakaszokat reprezentáló objektumok hozzáadását. egy `Paragraph` objektum egy vagy több szakaszt tartalmazhat (szakaszobjektumok gyűjteménye).
* Az Aspose.Slides a [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) osztályt biztosítja, amely lehetővé teszi szöveget és annak formázási tulajdonságait reprezentáló objektumok hozzáadását.

Egy `Paragraph` objektum a hozzá tartozó `Portion` objektumok révén képes a különböző formázási tulajdonságú szövegek kezelésére.

## **Több bekezdés hozzáadása, amelyek több szakaszt tartalmaznak**

Az alábbi lépések bemutatják, hogyan adjon hozzá egy szövegkeretet, amely 3 bekezdést, és minden bekezdés 3 szakaszt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a megfelelő dia referenciáját az indexe alapján.
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)-t a diára.
4. Szerezze meg az [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)-hez tartozó ITextFrame-et.
5. Hozzon létre két [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) objektumot, és adja hozzá őket a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) bekezdéggyűjteményéhez.
6. Hozzon létre három [Portion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) objektumot minden új `Paragraph`-hoz (alapértelmezett Paragraph esetén két Portion objektum), és adja hozzá minden `Portion` objektumot a megfelelő `Paragraph` szakaszgyűjteményéhez.
7. Állítson be szöveget minden szakaszhoz.
8. Alkalmazza a kívánt formázási beállításokat minden szakaszon a `Portion` objektum által biztosított formázási tulajdonságokkal.
9. Mentse a módosított prezentációt.

Ez a PHP kód a fenti lépések megvalósítása:

```php
# Hozzon létre egy Presentation osztályt, amely egy PPTX fájlt képvisel
$pres = new Presentation();
try {
    # Az első dia elérése
    $slide = $pres->getSlides()->get_Item(0);
    # Téglalap típusú AutoShape hozzáadása
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Az AutoShape TextFrame-jének elérése
    $tf = $ashp->getTextFrame();
    # Bekezdések és szakaszok létrehozása különböző szövegformátumokkal
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # PPTX mentése lemezre
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Bekezdés pontok kezelése**

A pontlisták segítenek az információk gyors és hatékony szervezésében és bemutatásában. A pontozott bekezdések mindig könnyebben olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a megfelelő dia referenciáját az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)-t a kiválasztott diához.
4. Szerezze meg az autoshape [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)-jét.
5. Távolítsa el a `TextFrame` alapértelmezett bekezdését.
6. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) osztállyal.
7. Állítsa be a pont `Type` értékét `Symbol`-ra, és adja meg a pont karakterét.
8. Állítsa be a bekezdés `Text` értékét.
9. Állítsa be a bekezdés `Indent` értékét a pont számára.
10. Állítson be színt a pontnak.
11. Állítson be magasságot a ponthoz.
12. Adja hozzá az új bekezdést a `TextFrame` bekezdéggyűjteményéhez.
13. Adja hozzá a második bekezdést, és ismételje meg a 7‑13. lépésekben leírtakat.
14. Mentse a prezentációt.

Ez a PHP kód bemutatja, hogyan adjon hozzá egy bekezdés pontot:

```php
# Létrehoz egy Presentation osztályt, amely egy PPTX fájlt képvisel
$pres = new Presentation();
try {
    # Eléri az első diát
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape hozzáadása és elérése
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Az autoshape szövegkeretének elérése
    $txtFrm = $aShp->getTextFrame();
    # Eltávolítja az alapértelmezett bekezdést
    $txtFrm->getParagraphs()->removeAt(0);
    # Létrehozza a bekezdést
    $para = new Paragraph();
    # Beállítja a bekezdés pont stílusát és szimbólumát
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Beállítja a bekezdés szövegét
    $para->setText("Welcome to Aspose.Slides");
    # Beállítja a pont behúzását
    $para->getParagraphFormat()->setIndent(25);
    # Beállítja a pont színét
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// beállítja az IsBulletHardColor értékét true-ra, hogy saját pontszínt használjon

    # Beállítja a pont magasságát
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Bekezdés hozzáadása a szövegkerethez
    $txtFrm->getParagraphs()->add($para);
    # Második bekezdés létrehozása
    $para2 = new Paragraph();
    # Beállítja a bekezdés pont típusát és stílusát
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Bekezdés szövegének hozzáadása
    $para2->setText("This is numbered bullet");
    # Beállítja a pont behúzását
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// beállítja az IsBulletHardColor értékét true-ra, hogy saját pontszínt használjon

    # Beállítja a pont magasságát
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Bekezdés hozzáadása a szövegkerethez
    $txtFrm->getParagraphs()->add($para2);
    # Mentse a módosított prezentációt
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Kép pontok kezelése**

A pontlisták segítenek az információk gyors és hatékony szervezésében és bemutatásában. A képes bekezdések könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a megfelelő dia referenciáját az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)-t a diára.
4. Szerezze meg az autoshape [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)-jét.
5. Távolítsa el a `TextFrame` alapértelmezett bekezdését.
6. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) osztállyal.
7. Töltse be a képet a [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/)-ben.
8. Állítsa be a pont típusát [Picture](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bullettype/#Picture)-ra, és adja meg a képet.
9. Állítsa be a Paragraph `Text` értékét.
10. Állítsa be a Paragraph `Indent` értékét a pont számára.
11. Állítson be színt a pontnak.
12. Állítson be magasságot a ponthoz.
13. Adja hozzá az új bekezdést a `TextFrame` bekezdéggyűjteményéhez.
14. Adja hozzá a második bekezdést, és ismételje meg az előző lépéseket.
15. Mentse a módosított prezentációt.

Ez a PHP kód bemutatja, hogyan adjon hozzá és kezeljen képes pontokat:

```php
# Létrehoz egy Presentation osztályt, amely egy PPTX fájlt képvisel
$presentation = new Presentation();
try {
    # Eléri az első diát
    $slide = $presentation->getSlides()->get_Item(0);
    # Létrehozza a képet a pontokhoz
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # AutoShape hozzáadása és elérése
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Az autoshape szövegkeretének elérése
    $textFrame = $autoShape->getTextFrame();
    # Eltávolítja az alapértelmezett bekezdést
    $textFrame->getParagraphs()->removeAt(0);
    # Új bekezdés létrehozása
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Beállítja a bekezdés pont stílusát és képét
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Beállítja a pont magasságát
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Bekezdés hozzáadása a szövegkerethez
    $textFrame->getParagraphs()->add($paragraph);
    # A prezentáció mentése PPTX fájlként
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # A prezentáció mentése PPT fájlként
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Többszintű pontok kezelése**

A pontlisták segítenek az információk gyors és hatékony szervezésében és bemutatásában. A többszintű pontok könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a megfelelő dia referenciáját az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)-t az új diára.
4. Szerezze meg az autoshape [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)-jét.
5. Távolítsa el a `TextFrame` alapértelmezett bekezdését.
6. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) osztállyal, és állítsa a mélységet 0-ra.
7. Hozza létre a második bekezdést a `Paragraph` osztállyal, és állítsa a mélységet 1-re.
8. Hozza létre a harmadik bekezdést a `Paragraph` osztállyal, és állítsa a mélységet 2-re.
9. Hozza létre a negyedik bekezdést a `Paragraph` osztállyal, és állítsa a mélységet 3-ra.
10. Adja hozzá az új bekezdéseket a `TextFrame` bekezdéggyűjteményéhez.
11. Mentse a módosított prezentációt.

Ez a PHP kód bemutatja, hogyan adjon hozzá és kezeljen többszintű pontokat:

```php
# Létrehoz egy Presentation osztályt, amely egy PPTX fájlt képvisel
$pres = new Presentation();
try {
    # Eléri az első diát
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape hozzáadása és elérése
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # A létrehozott autoshape szövegkeretének elérése
    $text = $aShp->addTextFrame("");
    # Törli az alapértelmezett bekezdést
    $text->getParagraphs()->clear();
    # Az első bekezdés hozzáadása
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Beállítja a pont szintjét
    $para1->getParagraphFormat()->setDepth(0);
    # A második bekezdés hozzáadása
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Beállítja a pont szintjét
    $para2->getParagraphFormat()->setDepth(1);
    # A harmadik bekezdés hozzáadása
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Beállítja a pont szintjét
    $para3->getParagraphFormat()->setDepth(2);
    # A negyedik bekezdés hozzáadása
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Beállítja a pont szintjét
    $para4->getParagraphFormat()->setDepth(3);
    # Bekezdések hozzáadása a gyűjteményhez
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # A prezentáció mentése PPTX fájlként
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Egy bekezdés kezelése egy egyéni számozott listával**

A [BulletFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/) osztály a [setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) metódust és másokat biztosít, amelyekkel egyedi számozású vagy formázott bekezdéseket kezelhet.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a bekezdést tartalmazó diát.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)-t a diához.
4. Szerezze meg az autoshape [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)-jét.
5. Távolítsa el a `TextFrame` alapértelmezett bekezdését.
6. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) osztállyal, és állítsa a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) értékét 2-re.
7. Hozza létre a második bekezdést a `Paragraph` osztállyal, és állítsa a `NumberedBulletStartWith` értékét 3-ra.
8. Hozza létre a harmadik bekezdést a `Paragraph` osztállyal, és állítsa a `NumberedBulletStartWith` értékét 7-re.
9. Adja hozzá az új bekezdéseket a `TextFrame` bekezdéggyűjteményéhez.
10. Mentse a módosított prezentációt.

Ez a PHP kód bemutatja, hogyan adjon hozzá és kezeljen egyéni számozású vagy formázott bekezdéseket:

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Hozzáfér a létrehozott autoshape szövegkeretéhez
    $textFrame = $shape->getTextFrame();
    # Eltávolítja az alapértelmezett létező bekezdést
    $textFrame->getParagraphs()->removeAt(0);
    # Első lista
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Első sor behúzásának beállítása egy bekezdéshez**

Használja a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setindent/) metódust az első sor behúzásának szabályozásához. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés testhez igazítva marad.

Használja a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setmarginleft/)‑t, ha a teljes bekezdést szeretné eltolni. Használja a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setindent/)‑t, ha csak az első sort akarja eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző behúzási értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a cél diákat.
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)-t a diára.
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)-et a formához, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [Indent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setindent/) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított prezentációt.

Ez a kód bemutatja, hogyan állíthat be bekezdésbehúzást:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
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

## **Függőleges behúzás beállítása egy bekezdéshez**

A függőleges behúzás olyan bekezdéselrendezés, amelyben az első sor balra indul a többi sorhoz képest. Az Aspose.Slides‑ben ezt a hatást a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setindent/) metódussal hozhatja létre. Állítson negatív értéket a behúzásra, hogy az első sort balra mozgassa a bekezdés testhez képest.

Gyakorlatban a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setmarginleft/) határozza meg a bekezdés test bal pozícióját, a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setindent/) pedig az első sor helyzetét ehhez a margóhoz képest. Függőleges behúzás létrehozásához állítson pozitív `MarginLeft` értéket, és negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedetek és egyéb bekezdések esetén, ahol a sortöréses soroknak a bekezdés test alatt kell elhelyezkedniük, nem az első sor első karaktere alatti helyen.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a cél diákat.
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)-t a diára.
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)-et a formához, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be pozitív [MarginLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setmarginleft/) értéket minden bekezdéshez.
6. Állítson negatív [Indent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setindent/) értéket a függőleges behúzás hatásának létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított prezentációt.

Ez a kód bemutatja, hogyan állíthat be függőleges behúzást egy bekezdéshez:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
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

## **Befejező bekezdés futtatási tulajdonságok kezelése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezze meg a bekezdést tartalmazó dia referenciáját a pozíciója alapján.
1. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)-t a diára.
1. Adjon egy [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)-et két bekezdéssel a téglalaphoz.
1. Állítsa be a betűmagasságot és a betűtípust a bekezdésekhez.
1. Állítsa be a Befejező (End) tulajdonságokat a bekezdésekhez.
1. Írja ki a módosított prezentációt PPTX fájlként.

Ez a PHP kód bemutatja, hogyan állíthatja be a Befejező tulajdonságokat a PowerPoint bekezdéseknél:

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **HTML szöveg importálása bekezdésekbe**

Az Aspose.Slides kibővített támogatást nyújt HTML szöveg bekezdésekbe való importálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a megfelelő dia referenciáját az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)-t a diára.
4. Adjon hozzá és szerezze meg az `AutoShape` [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)-jét.
5. Távolítsa el a `TextFrame` alapértelmezett bekezdését.
6. Olvassa be a forrás HTML fájlt egy TextReader‑ben.
7. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) osztállyal.
8. Adja hozzá a HTML fájl tartalmát a TextReader‑ből a TextFrame [ParagraphCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphcollection/)-hez.
9. Mentse a módosított prezentációt.

Ez a PHP kód a HTML szövegek bekezdésekbe importálásának lépéseit valósítja meg:

```php
# Üres prezentációs példány létrehozása
$pres = new Presentation();
try {
    # A prezentáció alapértelmezett első diájának elérése
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape hozzáadása a HTML tartalom befogadásához
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Szövegkeret hozzáadása a formához
    $ashape->addTextFrame("");
    # Az hozzáadott szövegkeret összes bekezdésének törlése
    $ashape->getTextFrame()->getParagraphs()->clear();
    # HTML fájl betöltése stream reader-rel
    $tr = new StreamReader("file.html");
    # Szöveg hozzáadása a HTML stream readerből a szövegkeretbe
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Prezentáció mentése
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Bekezdés szövegének exportálása HTML‑be**

Az Aspose.Slides kibővített támogatást nyújt a bekezdésekben lévő szövegek HTML‑be exportálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból, és töltse be a kívánt prezentációt.
2. Szerezze meg a megfelelő dia referenciáját az indexe alapján.
3. Szerezze meg a szöveget tartalmazó formát, amelyet HTML‑be exportál.
4. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)-jét.
5. Hozzon létre egy `StreamWriter` példányt, és adja hozzá az új HTML fájlt.
6. Adja meg a kezdőindexet a StreamWriter‑nek, és exportálja a kívánt bekezdéseket.

Ez a PHP kód bemutatja, hogyan exportálhat PowerPoint bekezdés szövegeket HTML‑be:

```php
# Betölti a prezentáció fájlt
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # A prezentáció alapértelmezett első diájának elérése
    $slide = $pres->getSlides()->get_Item(0);
    # Kívánt index
    $index = 0;
    # Hozzáadott forma elérése
    $ashape = $slide->getShapes()->get_Item($index);
    # Kimeneti HTML fájl létrehozása
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Első bekezdés kinyerése HTML-ként
    # Bekezdések adatainak írása HTML-be a bekezdés kezdőindexének és a másolandó bekezdések számának megadásával
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Bekezdés mentése képként**

Ebben a részben két példát mutatunk be, amelyek azt demonstrálják, hogyan menthet egy szöveg bekezdést, amelyet a [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) osztály képvisel, képként. Mindkét példa magában foglalja a bekezdést tartalmazó forma képének megszerzését a [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) osztály `getImage` metódusaival, a bekezdés határainak kiszámítását a formán belül, valamint a bitmap képbe való exportálását. Ezek a megközelítések lehetővé teszik a PowerPoint prezentációkból származó szöveg meghatározott részeinek kivonását és külön képként való mentését, ami számos további felhasználási esetben hasznos lehet.

Tegyük fel, hogy van egy sample.pptx nevű prezentációs fájlunk, amely egy diát tartalmaz, ahol az első forma egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

**Példa 1**

Ebben a példában a második bekezdést mentjük képként. Ehhez a prezentáció első diájának formájának képét nyerjük ki, majd kiszámítjuk a második bekezdés határait a forma szövegkeretében. A bekezdést ezután egy új bitmap képre rajzoljuk, amelyet PNG formátumban mentünk. Ez a módszer különösen hasznos, ha egy adott bekezdést külön képként szeretne menteni, miközben megőrzi a szöveg pontos méreteit és formázását.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Mentse a formát memóriában bitmapként.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Hozzon létre egy forma bitmapet a memóriából.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Számolja ki a második bekezdés határait.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Számolja ki a kimeneti kép koordinátáit és méretét (minimum méret - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Vágja le a forma bitmapet, hogy csak a bekezdés bitmap legyen.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Az eredmény:

![A bekezdés képe](paragraph_to_image_output.png)

**Példa 2**

Ebben a példában a korábbi megközelítést bővítjük egy méretezési tényező hozzáadásával a bekezdés képéhez. A forma a prezentációból ki lesz nyerve, és `2` méretezési tényezővel kerül mentésre. Ez magasabb felbontású kimenetet tesz lehetővé a bekezdés exportálásakor. A bekezdés határait ezután a skálázás figyelembevételével számítjuk ki. A méretezés különösen akkor lehet hasznos, ha részletesebb képre van szükség, például magas minőségű nyomtatott anyagokhoz.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Mentse a formát memóriában bitmapként skálázással.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Hozzon létre egy forma bitmapet a memóriából.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Számolja ki a második bekezdés határait.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Számolja ki a kimeneti kép koordinátáit és méretét (minimum méret - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Vágja le a forma bitmapet, hogy csak a bekezdés bitmap legyen.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **GYIK**

**Teljesen letilthatom a sorok tördelését egy szövegkeretben?**

Igen. Használja a szövegkeret tördelési beállítását ([setWrapText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/setwraptext/)) a tördelés kikapcsolásához, így a sorok nem törnek meg a keret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos dián belüli határait?**

Lekérheti a bekezdés (vagy akár egyetlen szakasz) határoló téglalapját, hogy pontosan tudja, hol helyezkedik el a dián.

**Hol szabályozzák a bekezdés igazítását (bal/jobb/közép/justifikált)?**

[Alignment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setalignment/) egy bekezdés‑szintű beállítás a [ParagraphFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/)-ban; a teljes bekezdésre érvényes, függetlenül az egyes szakaszok formázásától.

**Beállíthatok helyesírási nyelvet csak a bekezdés egy részére (például egy szóra)?**

Igen. A nyelvet a szakasz szintjén állítják be ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setLanguageId)), így egy bekezdésen belül több nyelv is létezhet.