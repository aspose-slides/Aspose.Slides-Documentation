---
title: Správa textových odstavců PowerPoint v PHP
linktitle: Správa odstavce
type: docs
weight: 40
url: /cs/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- přidat text
- přidat odstavec
- spravovat text
- spravovat odstavec
- spravovat odrážku
- odsazení odstavce
- zavěšené odsazení
- odrážka odstavce
- číslovaný seznam
- odrážkový seznam
- vlastnosti odstavce
- importovat HTML
- text do HTML
- odstavec do HTML
- odstavec na obrázek
- text na obrázek
- exportovat odstavec
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak vytvářet a formátovat odstavce, části, odrážky, číslované seznamy, odsazení, HTML obsah a obrázky odstavců pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Aspose.Slides for PHP via Java představuje text jako hierarchii textových rámců, odstavců a částí:

* [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) představuje kontejner textu ve tvaru a poskytuje přístup k jeho kolekci odstavců.
* [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/) představuje jeden odstavec v textovém rámci a poskytuje přístup k jeho částem a formátování na úrovni odstavce.
* [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/) představuje úsek textu v odstavci. Každá část může mít vlastní text a formátování na úrovni znaků.

Odstavec tak může obsahovat text s různými písmy, barvami, velikostmi a dalším formátováním pomocí více částí.

## **Vytváření a formátování odstavců**

### **Vytvoření odstavců s více částmi**

Následující kroky vytvoří textový rámec se třemi odstavci, přičemž každý obsahuje tři části:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte požadovaný snímek pomocí jeho indexu.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) tvaru.
5. Použijte výchozí odstavec a přidejte dva další objekty [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/) do textového rámce.
6. Přidejte dostatek objektů [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/) tak, aby každý odstavec obsahoval tři části. Výchozí odstavec již obsahuje jednu prázdnou část.
7. Nastavte text každé části.
8. Použijte formátování na úrovni znaků pomocí [Portion::getPortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/#getPortionFormat--).
9. Uložte upravenou prezentaci.

Tento příklad v PHP implementuje výše uvedené kroky:

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

## **Vytvoření odrážkových a číslovaných seznamů**

### **Vytvoření odrážkového nebo číslovaného seznamu**

Odrážky a číslování usnadňují skenování souvisejících položek. V Aspose.Slides jsou nastavení seznamu definována pomocí [BulletFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte požadovaný snímek pomocí jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na vybraný snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) tvaru.
5. Odstraňte výchozí odstavec z textového rámce.
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/) pro symbolickou odrážku.
7. Nastavte [BulletFormat::setType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#setType-int-) na [BulletType::Symbol](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bullettype/) a určete znak odrážky.
8. Nastavte text odstavce, odsazení, barvu odrážky a výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Vytvořte druhý odstavec a nastavte [BulletFormat::setType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#setType-int-) na [BulletType::Numbered](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bullettype/).
11. Nakonfigurujte styl číslované odrážky a přidejte odstavec do textového rámce.
12. Uložte prezentaci.

Tento příklad v PHP vytvoří symbolickou odrážku a číslovanou odrážku:

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

### **Použití obrázkových odrážek**

Obrázkové odrážky umožňují použít vlastní obrázek místo symbolu nebo čísla.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte požadovaný snímek pomocí jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) a získejte jeho [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/).
4. Odstraňte výchozí odstavec z textového rámce.
5. Načtěte obrázek odrážky a přidejte jej do kolekce obrázků prezentace jako [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/).
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/) a nastavte jeho text.
7. Nastavte [BulletFormat::setType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#setType-int-) na [BulletType::Picture](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bullettype/).
8. Přiřaďte obrázek pomocí [BulletFormat::getPicture](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#getPicture--) a nastavte výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Uložte upravenou prezentaci.

Tento příklad v PHP vytvoří obrázkovou odrážku:

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

### **Vytvoření vícestupňového seznamu**

Nastavte [ParagraphFormat::setDepth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setDepth-short-) pro umístění odstavců na různých úrovních seznamu. Nejvyšší úroveň má hloubku `0`.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a přistupte k snímku.
2. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) a vymažte výchozí odstavec z jeho textového rámce.
3. Vytvořte čtyři odstavce a nakonfigurujte jejich symboly odrážek.
4. Nastavte jejich hodnoty [ParagraphFormat::setDepth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setDepth-short-) na `0`, `1`, `2` a `3`.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

Tento příklad v PHP vytvoří čtyřúrovňový odrážkový seznam:

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

### **Zahájení číslovaných položek seznamu vlastními hodnotami**

Použijte [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) pro nastavení počátečního čísla zobrazeného u číslovaného odstavce.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
2. Vymažte výchozí odstavec z textového rámce tvaru.
3. Vytvořte tři číslované odstavce.
4. Nastavte [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) na `2`, `3` a `7` pro příslušné odstavce.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

Tento příklad v PHP přiřadí vlastní počáteční číslo každému odstavci:

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

## **Řízení rozvržení odstavce a koncových vlastností**

### **Nastavení odsazení první řádky**

Použijte [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setIndent-float-) pro ovládání odsazení první řádky odstavce. Tato metoda posune pouze první řádek relativně k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco ostatní řádky zůstávají zarovnány k tělu odstavce.

Použijte [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) pokud potřebujete posunout celý odstavec. Použijte [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setIndent-float-) pokud potřebujete posunout pouze první řádek.

Níže uvedený příklad vytváří několik odstavců a aplikuje různé hodnoty [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setIndent-float-) pro demonstraci, jak odsazení první řádky ovlivňuje rozvržení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Přistupte k cílovému snímku.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) tvaru a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte pro ně různé hodnoty [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setIndent-float-).
6. Přidejte odstavce do textového rámce.
7. Uložte upravenou prezentaci.

Tento PHP kód ukazuje, jak nastavit odsazení odstavce:

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

Výsledek:

![Odsazení první řádky odstavců](first_line_indent.png)

### **Nastavení zavěšeného odsazení**

Zavěšené odsazení je rozvržení odstavce, kde první řádek začíná vlevo od zbytku řádků. V Aspose.Slides tento efekt vytvoříte pomocí [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setIndent-float-). Přiřaďte zápornou hodnotu pro posunutí první řádky doleva relativně k tělu odstavce.

V praxi [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) určuje levou pozici těla odstavce a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setIndent-float-) určuje pozici první řádky relativně k tomuto okraji. Pro vytvoření zavěšeného odsazení přiřaďte kladnou hodnotu metodě `setMarginLeft` a zápornou hodnotu metodě `setIndent`.

Toto formátování je užitečné pro bibliografie, reference, položky glosáře a další odstavce, kde musí být zalomené řádky zarovnány pod tělo odstavce namísto pod první znak první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Přistupte k cílovému snímku.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) tvaru a odstraňte výchozí odstavec.
5. Vytvořte odstavce a přiřaďte každému kladnou hodnotu [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-).
6. Přiřaďte zápornou hodnotu [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setIndent-float-) pro vytvoření efektu zavěšeného odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

Tento PHP kód ukazuje, jak nastavit zavěšené odsazení odstavce:

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

Výsledek:

![Zavěšené odsazení odstavců](hanging_indent.png)

### **Nastavení koncových vlastností odstavce**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) řídí formátování koncové značky odstavce. Následující PHP příklad přiřadí velikost písma a latinské písmo ke koncové značce druhého odstavce:

1. Načtěte [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a přistupte k snímku.
2. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) a vymažte jeho výchozí odstavec.
3. Vytvořte dva odstavce a přidejte k nim textové části.
4. Vytvořte [PortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portionformat/) pro koncovou značku druhého odstavce.
5. Nastavte [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) a [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Přiřaďte formát pomocí [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) a uložte prezentaci.

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

## **Počítání vykreslených řádků**

Použijte [Paragraph::getLinesCount](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#getLinesCount--) pro spočítání řádků, které odstavec zabírá po rozložení textu, včetně automatického zalamování. To je užitečné při kontrole délky textu a rozvržení v šablonách prezentací.

Odstavec je jednou položkou v [TextFrame::getParagraphs](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#getParagraphs--), a může zabírat několik vykreslených řádků. Výslovný zalamovací znak v odstavci vynutí nový řádek bez vytvoření dalšího odstavce. Automatické zalamování vytváří řádky na základě dostupné šířky, aniž by vkládalo výslovné znaky nových řádků do textu. Počítání odstavců nebo znaků pro zalomení řádku tedy nedává počet vykreslených řádků.

Následující příklad vytvoří textový tvar, spočítá jeho řádky, zúží tvar a poté nahradí text kratším řetězcem. Zalamování je povoleno a automatické přizpůsobení je zakázáno, aby šířka tvaru řídila zalamování bez automatického zmenšování textu nebo změny velikosti tvaru. Rozměry tvaru jsou v bodech. Nakonec příklad přidá další odstavec a sečte počty řádků napříč textovým rámcem.

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

S tímto textem a těmito rozměry zúžení tvaru zvýší počet řádků, zatímco nahrazení textu krátkým řetězcem jej sníží. Přesné počty se mohou lišit podle dostupnosti písma a substituce, velikosti písma, okrajů, odsazení, zalamování a nastavení automatického přizpůsobení. Při kontrole šablony používejte písma a nastavení rozvržení určená pro cílové prostředí.

Pouze počet řádků neurčuje, zda text přesahuje svůj kontejner. Důležitá je také dostupná výška, výšky řádků, mezery mezi odstavci a řádky a chování automatického přizpůsobení; i jediný řádek může překročit dostupnou šířku, pokud je zalamování vypnuto.

## **Import a export obsahu odstavců**

### **Import HTML textu do odstavců**

Použijte [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) pro převod HTML značek na odstavce a části v textovém rámci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Přistupte k snímku a přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
3. Získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) tvaru a vymažte jeho výchozí odstavec.
4. Načtěte zdrojový HTML soubor.
5. Předávejte HTML řetězec metodě [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Uložte upravenou prezentaci.

Tento PHP příklad importuje HTML do textového rámce:

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

### **Export textu odstavce do HTML**

Použijte [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) pro export vybraného rozsahu odstavců jako HTML.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a načtěte požadovanou prezentaci.
2. Přistupte k snímku a najděte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/), který obsahuje text.
3. Získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) tvaru.
4. Zavolejte [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) s indexem počátečního odstavce a počtem odstavců k exportu.
5. Zapište vrácený HTML řetězec do souboru.

Tento PHP příklad exportuje všechny odstavce z prvního textového tvaru:

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

### **Vykreslení odstavce jako obrázku**

[Paragraph::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#getImage--) vykreslí jednotlivý odstavec přímo a vrátí objekt [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/). Výsledek uložte do souboru nebo streamu pomocí [IImage::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/#save-java.lang.String-int-). Nemusíte vykreslovat obklopující tvar ani ručně ořezávat bitmapu.

[Paragraph::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#getImage--) může vrátit `null`, pokud odstavec nelze najít v nadřazené kolekci, nemá platné vykreslovací hranice nebo jej nelze vykreslit. Výsledek před uložením zkontrolujte a po použití uvolněte vrácený obrázek.

#### **Vykreslení odstavce v výchozím měřítku**

Předpokládejme, že máme soubor prezentace s názvem sample.pptx s jedním snímkem, kde je první tvar textovým polem obsahujícím tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

Následující PHP příklad vykreslí druhý odstavec v běžném textovém tvaru ve výchozím měřítku a uloží získaný obrázek ve formátu PNG. Blok `finally` zajistí správné uvolnění obrázku.

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

Výsledek:

![Obrázek odstavce](paragraph_to_image_output.png)

#### **Vykreslení odstavce v buňce tabulky se škálováním**

Použijte přetíženou metodu [Paragraph::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#getImage-float-float-), která přijímá parametry `$scaleX` a `$scaleY` pro nastavení horizontálního a vertikálního měřítka. Následující PHP příklad vytvoří tabulku, vykreslí odstavec v její první buňce se dvojnásobnou šířkou a výškou a výsledek uloží jako PNG obrázek.

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

Měřítkový faktor `1` ponechá danou osu v její výchozí velikosti pixelů. Například `2` pro oba faktory vytvoří obrázek, jehož šířka i výška jsou přibližně dvojnásobkem výchozích rozměrů, což vede ke čtyřnásobnému počtu pixelů. Větší faktory obecně poskytují ostřejší text pro přiblížení nebo výstup ve vysokém rozlišení, ale také zvyšují paměťovou náročnost a velikost souboru. Faktory menší než `1` vytvářejí menší obrázky s menším detailem. Používejte stejné faktory pro zachování poměru stran odstavce; odlišné horizontální a vertikální faktory roztaží výstup nezávisle.

Vykreslení celého tvaru pomocí [Shape::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getImage--) je užitečné, když výstup musí zahrnovat výplň, okraj nebo jiný vizuální kontext tvaru. Pro obrázek pouze s odstavcem použijte [Paragraph::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#getImage--).

## **Často kladené otázky**

**Mohu zcela zakázat zalamování řádků uvnitř textového rámce?**

Ano. Nastavte [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#setWrapText-byte-) pro zakázání zalamování, aby se řádky nelámal na okrajích textového rámce.

**Jak získám přesné on‑slide rozměry konkrétního odstavce?**

Použijte [Paragraph::getRect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#getRect--) pro získání ohraničujícího obdélníku odstavce. [Portion::getRect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/#getRect--) poskytuje rozměry jednotlivé části.

**Kde se řídí zarovnání odstavce (vlevo, vpravo, na střed nebo do bloku)?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setAlignment-int-) je nastavení na úrovni odstavce a vztahuje se na celý odstavec bez ohledu na formátování jednotlivých částí.

**Mohu nastavit jazyk kontroly pravopisu pro část odstavce?**

Ano. Nastavte [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) pro jednotlivé části, takže jeden odstavec může obsahovat text v několika jazycích.