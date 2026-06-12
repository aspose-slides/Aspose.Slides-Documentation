---
title: Správa textových odstavců PowerPointu v PHP
linktitle: Správa odstavce
type: docs
weight: 40
url: /cs/php-java/manage-paragraph/
keywords:
- přidat text
- přidat odstavec
- spravovat text
- spravovat odstavec
- spravovat odrážku
- odsazení odstavce
- visící odsazení
- odrážka odstavce
- číslovaný seznam
- seznam s odrážkami
- vlastnosti odstavce
- importovat HTML
- text do HTML
- odstavec do HTML
- odstavec na obrázek
- text na obrázek
- exportovat odstavec
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Mistrovské formátování odstavců s Aspose.Slides pro PHP přes Java — optimalizujte zarovnání, mezery a styl v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Aspose.Slides poskytuje všechny třídy, které potřebujete pro práci s texty, odstavci a částmi v PowerPointu.

* Aspose.Slides poskytuje třídu [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) , která vám umožní přidávat objekty představující odstavec. Objekt `TextFame` může obsahovat jeden nebo více odstavců (každý odstavec je vytvořen pomocí návratu řádku).
* Aspose.Slides poskytuje třídu [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/) , která vám umožní přidávat objekty představující části. Objekt `Paragraph` může mít jednu nebo více částí (kolekci objektů částí).
* Aspose.Slides poskytuje třídu [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/) , která vám umožní přidávat objekty představující texty a jejich formátovací vlastnosti.

Objekt `Paragraph` je schopen zpracovávat texty s různými formátovacími vlastnostmi prostřednictvím svých podkladových objektů `Portion`.

## **Přidání více odstavců obsahujících více částí**

Tyto kroky ukazují, jak přidat textový rámec obsahující 3 odstavce a každý odstavec obsahující 3 části:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
4. Získejte ITextFrame spojený s [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
5. Vytvořte dva objekty [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/) a přidejte je do kolekce odstavců [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/).
6. Vytvořte tři objekty [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/) pro každý nový `Paragraph` (dvě objekty Portion pro výchozí odstavec) a přidejte každý objekt `Portion` do kolekce částí každého `Paragraph`.
7. Nastavte text pro každou část.
8. Použijte požadované formátovací funkce na každou část pomocí formátovacích vlastností poskytovaných objektem `Portion`.
9. Uložte upravenou prezentaci.

```php
# Vytvořte instanci třídy Presentation, která představuje soubor PPTX
$pres = new Presentation();
try {
    # Přístup k prvnímu snímku
    $slide = $pres->getSlides()->get_Item(0);
    # Přidejte AutoShape typu Obdélník
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Získejte TextFrame AutoShape
    $tf = $ashp->getTextFrame();
    # Vytvořte odstavce a části s různými formáty textu
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
    # Uložte PPTX na disk
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Správa odstavcových odrážek**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Odstavce s odrážkami jsou vždy snazší číst a pochopit.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na vybraný snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/).
7. Nastavte pro odstavec typ odrážky `Type` na `Symbol` a nastavte znak odrážky.
8. Nastavte odstavci `Text`.
9. Nastavte odstavci `Indent` pro odrážku.
10. Nastavte barvu odrážky.
11. Nastavte výšku odrážky.
12. Přidejte nový odstavec do kolekce odstavců `TextFrame`.
13. Přidejte druhý odstavec a opakujte postup uvedený v krocích 7 až 13.
14. Uložte prezentaci.

```php
# Vytvoří instanci třídy Presentation, která představuje soubor PPTX
$pres = new Presentation();
try {
    # Přistupuje k prvnímu snímku
    $slide = $pres->getSlides()->get_Item(0);
    # Přidá a přistoupí k Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Přistupuje k textovému rámci autoshape
    $txtFrm = $aShp->getTextFrame();
    # Odstraní výchozí odstavec
    $txtFrm->getParagraphs()->removeAt(0);
    # Vytvoří odstavec
    $para = new Paragraph();
    # Nastaví styl odrážky odstavce a symbol
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Nastaví text odstavce
    $para->setText("Welcome to Aspose.Slides");
    # Nastaví odsazení odrážky
    $para->getParagraphFormat()->setIndent(25);
    # Nastaví barvu odrážky
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// nastavit IsBulletHardColor na true pro použití vlastní barvy odrážky

    # Nastaví výšku odrážky
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Přidá odstavec do textového rámce
    $txtFrm->getParagraphs()->add($para);
    # Vytvoří druhý odstavec
    $para2 = new Paragraph();
    # Nastaví typ a styl odrážky odstavce
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Přidá text odstavce
    $para2->setText("This is numbered bullet");
    # Nastaví odsazení odrážky
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// nastavit IsBulletHardColor na true pro použití vlastní barvy odrážky

    # Nastaví výšku odrážky
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Přidá odstavec do textového rámce
    $txtFrm->getParagraphs()->add($para2);
    # Uloží upravenou prezentaci
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Správa obrázkových odrážek**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Odstavce s obrázkovými odrážkami jsou snadno čitelné a pochopitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/).
7. Načtěte obrázek pomocí [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/).
8. Nastavte typ odrážky na [Picture](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bullettype/#Picture) a přiřaďte obrázek.
9. Nastavte odstavci `Text`.
10. Nastavte odstavci `Indent` pro odrážku.
11. Nastavte barvu odrážky.
12. Nastavte výšku odrážky.
13. Přidejte nový odstavec do kolekce odstavců `TextFrame`.
14. Přidejte druhý odstavec a opakujte postup podle předchozích kroků.
15. Uložte upravenou prezentaci.

```php
# Vytvoří instanci třídy Presentation, která představuje soubor PPTX
$presentation = new Presentation();
try {
    # Přistupuje k prvnímu snímku
    $slide = $presentation->getSlides()->get_Item(0);
    # Vytvoří obrázek pro odrážky
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Přidá a přistoupí k Autoshape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Přistupuje k textovému rámci autoshape
    $textFrame = $autoShape->getTextFrame();
    # Odstraní výchozí odstavec
    $textFrame->getParagraphs()->removeAt(0);
    # Vytvoří nový odstavec
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Nastaví styl odrážky odstavce a obrázek
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Nastaví výšku odrážky
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Přidá odstavec do textového rámce
    $textFrame->getParagraphs()->add($paragraph);
    # Zapíše prezentaci jako soubor PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Zapíše prezentaci jako soubor PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Správa víceúrovňových odrážek**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Víceúrovňové odrážky jsou snadno čitelné a pochopitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [AutoShape] na nový snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/) a nastavte úroveň (depth) na 0.
7. Vytvořte druhý odstavec pomocí třídy `Paragraph` a nastavte úroveň na 1.
8. Vytvořte třetí odstavec pomocí třídy `Paragraph` a nastavte úroveň na 2.
9. Vytvořte čtvrtý odstavec pomocí třídy `Paragraph` a nastavte úroveň na 3.
10. Přidejte nové odstavce do kolekce odstavců `TextFrame`.
11. Uložte upravenou prezentaci.

```php
# Vytvoří instanci třídy Presentation, která představuje soubor PPTX
$pres = new Presentation();
try {
    # Přistupuje k prvnímu snímku
    $slide = $pres->getSlides()->get_Item(0);
    # Přidá a přistoupí k Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Přistupuje k textovému rámci vytvořeného autoshape
    $text = $aShp->addTextFrame("");
    # Vymaže výchozí odstavec
    $text->getParagraphs()->clear();
    # Přidá první odstavec
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Nastaví úroveň odrážky
    $para1->getParagraphFormat()->setDepth(0);
    # Přidá druhý odstavec
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Nastaví úroveň odrážky
    $para2->getParagraphFormat()->setDepth(1);
    # Přidá třetí odstavec
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Nastaví úroveň odrážky
    $para3->getParagraphFormat()->setDepth(2);
    # Přidá čtvrtý odstavec
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Nastaví úroveň odrážky
    $para4->getParagraphFormat()->setDepth(3);
    # Přidá odstavce do kolekce
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # Zapíše prezentaci jako soubor PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Správa odstavce s vlastním číslovaným seznamem**

Třída [BulletFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/) poskytuje metodu [setNumberedBulletStartWith](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) a další, které vám umožní spravovat odstavce s vlastním číslováním nebo formátováním.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte snímek obsahující odstavec.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/) a nastavte [NumberedBulletStartWith] na 2.
7. Vytvořte druhý odstavec pomocí třídy `Paragraph` a nastavte `NumberedBulletStartWith` na 3.
8. Vytvořte třetí odstavec pomocí třídy `Paragraph` a nastavte `NumberedBulletStartWith` na 7.
9. Přidejte nové odstavce do kolekce odstavců `TextFrame`.
10. Uložte upravenou prezentaci.

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Přistupuje k textovému rámci vytvořeného autoshape
    $textFrame = $shape->getTextFrame();
    # Odstraňuje výchozí existující odstavec
    $textFrame->getParagraphs()->removeAt(0);
    # První seznam
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

## **Nastavení odsazení první řádky odstavce**

Použijte metodu [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setindent/), která řídí odsazení první řádky odstavce. Tato metoda posouvá pouze první řádek vzhledem k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco zbylé řádky zůstávají zarovnané k tělu odstavce.

Použijte [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setmarginleft/), pokud potřebujete přesunout celý odstavec. Použijte [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setindent/), pokud chcete přesunout pouze první řádek.

Následující příklad vytvoří několik odstavců a použije různé hodnoty odsazení, aby ukázal, jak odsazení první řádky ovlivňuje rozvržení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
4. Přidejte prázdný [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) do tvaru a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte pro ně různé hodnoty [Indent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setindent/).
6. Přidejte odstavce do textového rámce.
7. Uložte upravenou prezentaci.

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

![Odsazení první řádky odstavců](first_line_indent.png)

## **Nastavení visícího odsazení odstavce**

Visící odsazení je rozvržení odstavce, ve kterém první řádek začíná vlevo od zbylých řádků. V Aspose.Slides vytvoříte tento efekt pomocí metody [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setindent/). Nastavte odsazení na zápornou hodnotu, aby se první řádek posunul doleva vzhledem k tělu odstavce.

V praxi [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setmarginleft/) určuje levý požadavek těla odstavce a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setindent/) určuje polohu první řádky vůči tomuto okraji. Pro vytvoření visícího odsazení nastavte kladnou hodnotu `MarginLeft` a zápornou hodnotu `Indent`.

Toto formátování je užitečné pro bibliografie, odkazy, položky glosáře a další odstavce, kde zalomené řádky musí být zarovnány pod tělo odstavce místo pod první znak první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
4. Přidejte prázdný [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) do tvaru a odstraňte výchozí odstavec.
5. Vytvořte odstavce a nastavte pro každý odstavec kladnou hodnotu [MarginLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setmarginleft/).
6. Nastavte zápornou hodnotu [Indent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setindent/) pro vytvoření efektu visícího odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

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

![Visící odsazení odstavců](hanging_indent.png)

## **Správa koncových vlastností odstavce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek obsahující odstavec podle jeho pozice.
1. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
1. Přidejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) se dvěma odstavci do obdélníku.
1. Nastavte výšku písma a typ písma pro odstavce.
1. Nastavte koncové vlastnosti pro odstavce.
1. Uložte upravenou prezentaci jako soubor PPTX.

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

## **Import HTML textu do odstavců**

Aspose.Slides poskytuje rozšířenou podporu pro import HTML textu do odstavců.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
4. Přidejte a získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) AutoShape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Přečtěte zdrojový HTML soubor pomocí TextReader.
7. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/).
8. Přidejte obsah HTML souboru ze čteného TextReader do [ParagraphCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphcollection/) TextFrame.
9. Uložte upravenou prezentaci.

```php
# Vytvořte prázdnou instanci prezentace
$pres = new Presentation();
try {
    # Přístup k výchozímu prvnímu snímku prezentace
    $slide = $pres->getSlides()->get_Item(0);
    # Přidání AutoShape pro uložení HTML obsahu
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Přidání textového rámce do tvaru
    $ashape->addTextFrame("");
    # Vyčištění všech odstavců v přidaném textovém rámci
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Načtení HTML souboru pomocí StreamReaderu
    $tr = new StreamReader("file.html");
    # Přidání textu z HTML stream readeru do textového rámce
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Uložit prezentaci
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Export textu odstavce do HTML**

Aspose.Slides poskytuje rozšířenou podporu pro export textů (obsažených v odstavcích) do HTML.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a načtěte požadovanou prezentaci.
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Získejte tvar obsahující text, který bude exportován do HTML.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) tvaru.
5. Vytvořte instanci `StreamWriter` a přidejte nový HTML soubor.
6. Poskytněte počáteční index StreamWriteru a exportujte požadované odstavce.

```php
# Načíst soubor prezentace
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Přístup k výchozímu prvnímu snímku prezentace
    $slide = $pres->getSlides()->get_Item(0);
    # Požadovaný index
    $index = 0;
    # Přístup k přidanému tvaru
    $ashape = $slide->getShapes()->get_Item($index);
    # Vytvoření výstupního HTML souboru
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Extrahování prvního odstavce jako HTML
    # Zapisování dat odstavců do HTML poskytnutím počátečního indexu odstavce a celkového počtu odstavců ke kopírování
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Uložení odstavce jako obrázku**

V této sekci prozkoumáme dva příklady, které ukazují, jak uložit textový odstavec reprezentovaný třídou [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/) jako obrázek. Oba příklady zahrnují získání obrázku tvaru obsahujícího odstavec pomocí metod `getImage` ze třídy [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/), výpočet ohraničení odstavce v rámci tvaru a jeho export jako bitmapový obrázek. Tyto přístupy vám umožňují extrahovat konkrétní části textu z prezentací PowerPoint a uložit je jako samostatné obrázky, což může být užitečné pro další použití v různých scénářích.

Předpokládejme, že máme soubor prezentace nazvaný sample.pptx s jedním snímkem, kde je první tvar textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

**Příklad 1**

V tomto příkladu získáme druhý odstavec jako obrázek. K tomu nejprve extrahujeme obrázek tvaru z prvního snímku prezentace a poté vypočítáme ohraničení druhého odstavce v textovém rámci tvaru. Odstavec je následně překreslen na nový bitmapový obrázek, který je uložen ve formátu PNG. Tato metoda je zvláště užitečná, když potřebujete uložit konkrétní odstavec jako samostatný obrázek při zachování přesných rozměrů a formátování textu.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Uložte tvar v paměti jako bitmapu.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Vytvořte bitmapu tvaru z paměti.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Vypočítejte ohraničení druhého odstavce.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Vypočítejte souřadnice a velikost výstupního obrázku (minimální velikost - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Ořežte bitmapu tvaru, aby obsahovala jen bitmapu odstavce.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Výsledek:

![Obrázek odstavce](paragraph_to_image_output.png)

**Příklad 2**

V tomto příkladu rozšiřujeme předchozí přístup přidáním škálovacích faktorů k obrázku odstavce. Tvar je extrahován z prezentace a uložen jako obrázek se škálovacím faktorem `2`. To umožňuje výstup s vyšším rozlišením při exportu odstavce. Ohraničení odstavce je pak vypočítáno s ohledem na měřítko. Škálování může být zvláště užitečné, když je potřeba podrobnější obrázek, například pro použití v vysoce kvalitních tištěných materiálech.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Uložte tvar v paměti jako bitmapu se škálováním.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Vytvořte bitmapu tvaru z paměti.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Vypočítejte ohraničení druhého odstavce.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Vypočítejte souřadnice a velikost výstupního obrázku (minimální velikost - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Ořízněte bitmapu tvaru, aby obsahovala jen bitmapu odstavce.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Mohu zcela zakázat zalamování řádků v textovém rámci?**

Ano. Použijte nastavení zalamování textového rámce ([setWrapText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/setwraptext/)) a vypněte zalamování, aby se řádky nelámají na okrajích rámce.

**Jak mohu získat přesné ohraničení konkrétního odstavce na snímku?**

Můžete získat ohraničující obdélník odstavce (a dokonce i jedné části), abyste znali jeho přesnou polohu a velikost na snímku.

**Kde se řídí zarovnání odstavce (levé/pravé/středové/justify)?**

[Alignment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setalignment/) je nastavení na úrovni odstavce v [ParagraphFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/); vztahuje se na celý odstavec bez ohledu na formátování jednotlivých částí.

**Mohu nastavit jazyk kontroly pravopisu jen pro část odstavce (např. jedno slovo)?**

Ano. Jazyk se nastavuje na úrovni části ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setLanguageId)), takže v jednom odstavci může koexistovat více jazyků.