---
title: "Felsorolásjeles és számozott listák kezelése prezentációkban PHP használatával"
linktitle: "Listák kezelése"
type: docs
weight: 60
url: /hu/php-java/manage-lists/
keywords:
- "jelölő"
- "felsorolásjeles lista"
- "számozott lista"
- "szimbólum jelölő"
- "képes jelölő"
- "egyéni jelölő"
- "többszintű lista"
- "jelölő létrehozása"
- "jelölő hozzáadása"
- "lista hozzáadása"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "PHP"
- "Aspose.Slides"
description: "Ismerje meg, hogyan hozhat létre és formázhat felsorolásjeles, képes, többszintű és számozott listákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP via Java használatával."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy felsorolásjeles és számozott listákat hozzon létre és formázzon PowerPoint és OpenDocument prezentációkban. Egy listaelem egy bekezdés, amelynek a jelölő beállításait a bekezdés formátuma vezérli.

Használja a [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#getParagraphFormat--) metódust a bekezdés szintű lista beállítások eléréséhez. A fő belépési pont a [ParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#getBullet--) amely egy [BulletFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a jelölő típusát, szimbólumát, képét, színét, méretét, számozási stílusát és kezdő számát.

Ez a cikk bemutatja, hogyan:

- hozzon létre egy egyéni szimbólummal rendelkező felsorolásjeles listát
- hozzon létre képes jelölőt
- hozzon létre többszintű listát a bekezdés mélységének beállításával
- hozzon létre számozott listát
- vizsgálja meg és módosítsa a lista formázását egy meglévő prezentációban

## **Felsorolásjeles lista létrehozása**

A felsorolásjeles lista létrehozásához adjon [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) objektumokat egy [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)-hez, és állítsa be a [BulletFormat.setType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setType-int-) értékét a [BulletType.Symbol](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bullettype/#Symbol) típusra. Ezután a [BulletFormat.setChar](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setChar-char-), a [BulletFormat.getColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#getColor--) és a [BulletFormat.setHeight](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setHeight-float-) beállításokkal szabályozhatja a jelölő megjelenését.

A következő PHP kód bemutatja, hogyan hozhat létre felsorolásjeles listát egy dián:

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Az eredmény:

![A szimbólum jelölők](symbol_bullets.png)

## **Számozott lista létrehozása**

Használjon számozott listákat, ha az elemek sorrendje fontos. Állítsa a [BulletFormat.setType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setType-int-) értékét a [BulletType.Numbered](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bullettype/#Numbered) típusra. Ezen felül megadhat számozási formátumot a [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) segítségével, vagy beállíthatja a [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) értékét, ha a lista nem 1‑től kezdődik.

A következő PHP kód megmutatja, hogyan hozhat létre számozott listát egy dián:

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Az eredmény:

![A számozott jelölők](numbered_bullets.png)

## **Képes jelölő létrehozása**

Az Aspose.Slides lehetővé teszi, hogy egy szabályos jelölő szimbólumát képpel helyettesítse. A képes jelölők leginkább egyszerű képekkel működnek, amelyek kis méretben is olvashatóak maradnak, például ikonok vagy kis átlátszó PNG fájlok.

{{% alert color="primary" %}}
Ideális esetben, ha a szabályos jelölő szimbólumát képpel szeretné helyettesíteni, egy egyszerű, átlátszó hátterű grafikát válasszon. Az ilyen képek jól használhatók egyéni jelölő szimbólumokként.
{{% /alert %}}

Ne feledje, hogy a képet nagyon kicsire méretezzük le. Emiatt erősen ajánljuk, hogy olyan képet válasszon, amely tiszta és vizuálisan hatékony marad, ha jelölőként kerül felhasználásra egy listában.

Képes jelölő létrehozásához adjon képet a [Presentation.getImages](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getImages--) metódushoz, és rendelje hozzá a visszaadott [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot a [BulletFormat.getPicture](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#getPicture--) metódushoz. Mielőtt a képet hozzárendeli, állítsa be a [BulletFormat.setType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bulletformat/#setType-int-) értékét a [BulletType.Picture](https://reference.aspose.com/slides/hu/php-java/aspose.slides/bullettype/#Picture) típusra.

Tegyük fel, hogy van egy "image.png" fájlunk:

![Kép a jelölőkhöz](picture_for_bullets.png)

A következő PHP kód megmutatja, hogyan hozhat létre képes jelölőket egy dián:

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Az eredmény:

![A képes jelölők](picture_bullets.png)

## **Többszintű lista létrehozása**

Használja a [ParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setDepth-short-) metódust, hogy a listaelemeket különböző szintekre helyezze. Az 0‑szint a legfelső szint, az 1‑szint alatta ágazik, és így tovább.

A következő PHP kód megmutatja, hogyan hozhat létre többszintű felsorolásjeles listát:

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Az eredmény:

![A többszintű lista](multilevel_list.png)

## **Meglévő lista módosítása**

Egy meglévő prezentációban a lista formázásának módosításához érje el a cél bekezdést, és frissítse annak a [ParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#getBullet--) beállításait. A listák létrehozásához használt ugyanazok a tulajdonságok felhasználhatók a PPT, PPTX vagy ODP fájlból betöltött listák megtekintésére vagy módosítására.

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **GYIK**

**Exportálhatók a felsorolásjeles és számozott listák PDF‑be vagy képekre?**

Igen. Az Aspose.Slides megőrzi a lista formázását, ha a célformátum támogatja a megfelelő szövegelrendezést és jelölő funkciókat.

**Szerkeszthetek listákat meglévő prezentációkban?**

Igen. Töltse be a prezentációt, érje el a cél bekezdést, vizsgálja meg vagy frissítse annak a [ParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#getBullet--) beállításait, majd mentse a prezentációt.

**Tartalmazhatnak a listák nem latin szöveget?**

Igen. A listaelemek szövege Unicode karaktereket is tartalmazhat, így többszörös nyelvű prezentációkban is létrehozhat listákat. Győződjön meg arról, hogy a prezentációban használt betűtípusok támogatják a szükséges karaktereket.