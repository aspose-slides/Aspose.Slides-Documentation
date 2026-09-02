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
- import HTML
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

Aspose.Slides pro PHP přes Java představuje text jako hierarchii textových rámců, odstavců a částí:

* [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) představuje kontejner textu ve tvaru a poskytuje přístup k jeho sbírce odstavců.
* [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/) představuje jeden odstavec v textovém rámci a poskytuje přístup k jeho částem a formátování na úrovni odstavce.
* [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/) představuje běh textu v odstavci. Každá část může mít vlastní text a formátování na úrovni znaků.

Odstavec tak může obsahovat text s různými písmy, barvami, velikostmi a dalším formátováním pomocí více částí.

## **Vytváření a formátování odstavců**

### **Vytváření odstavců s více částmi**

Následující kroky vytvoří textový rámec se třemi odstavci, z nichž každý obsahuje tři části:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte požadovaný snímek podle jeho indexu.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) do snímku.
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

## **Vytváření odrážkových a číslovaných seznamů**

### **Vytvoření odrážkového nebo číslovaného seznamu**

Odrážky a číslování usnadňují skenování souvisejících položek. V Aspose.Slides jsou nastavení seznamu definována pomocí [BulletFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte požadovaný snímek podle jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) k vybranému snímku.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) tvaru.
5. Odstraňte výchozí odstavec z textového rámce.
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/) pro symbolickou odrážku.
7. Nastavte [BulletFormat::setType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#setType-int-) na [BulletType::Symbol](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bullettype/) a určete znak odrážky.
8. Nastavte text odstavce, odsazení, barvu odrážky a výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Vytvořte druhý odstavec a nastavte [BulletFormat::setType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#setType-int-) na [BulletType::Numbered](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bullettype/).
11. Nakonfigurujte styl číslované odrážky a přidejte odstavec do textového rámce.
12. Uložte prezentaci.

Tento příklad v PHP vytváří symbolickou odrážku a číslovanou odrážku:

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

Obrázkové odrážky vám umožní použít vlastní obrázek místo symbolu nebo čísla.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte požadovaný snímek podle jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) a získejte jeho [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/).
4. Odstraňte výchozí odstavec z textového rámce.
5. Načtěte obrázek odrážky a přidejte jej do kolekce obrázků prezentace jako [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/).
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/) a nastavte jeho text.
7. Nastavte [BulletFormat::setType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#setType-int-) na [BulletType::Picture](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bullettype/).
8. Přiřaďte obrázek pomocí [BulletFormat::getPicture](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#getPicture--) a nastavte výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Uložte upravenou prezentaci.

Tento příklad v PHP vytváří obrázkovou odrážku:

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

### **Vytvoření víceúrovňového seznamu**

Nastavte [ParagraphFormat::setDepth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setDepth-short-) pro umístění odstavců na různé úrovně seznamu. Nejvyšší úroveň má hloubku `0`.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a získejte snímek.
2. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) a vymažte výchozí odstavec z jeho textového rámce.
3. Vytvořte čtyři odstavce a nakonfigurujte jejich symboly odrážek.
4. Nastavte jejich hodnoty [ParagraphFormat::setDepth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setDepth-short-) na `0`, `1`, `2` a `3`.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

Tento příklad v PHP vytváří čtyřúrovňový odrážkový seznam:

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

Tento příklad v PHP přiřazuje vlastní počáteční číslo každému odstavci:

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

## **Řízení rozvržení odstavců a vlastností konce**

### **Nastavení odsazení první řádky**

Použijte [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setIndent-float-) pro ovládání odsazení první řádky odstavce. Tato metoda posouvá pouze první řádku vzhledem k levému okraji odstavce. Kladná hodnota posouvá první řádku doprava, zatímco zbylé řádky zůstávají zarovnané k tělu odstavce.

Použijte [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) když potřebujete posunout celý odstavec. Použijte [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setIndent-float-) když chcete posunout jen první řádku.

Níže uvedený příklad vytváří několik odstavců a aplikuje různé hodnoty [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setIndent-float-) pro demonstraci, jak odsazení první řádky ovlivňuje rozvržení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) do snímku.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) tvaru a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte pro ně různé hodnoty [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setIndent-float-).
6. Přidejte odstavce do textového rámce.
7. Uložte upravenou prezentaci.

Tento kód v PHP ukazuje, jak nastavit odsazení odstavce:

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

Zavěšené odsazení je rozvržení odstavce, kde první řádka začíná vlevo od zbytku řádků. V Aspose.Slides tento efekt vytvoříte pomocí [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setIndent-float-). Přiřaďte zápornou hodnotu pro posun první řádky vlevo vzhledem k tělu odstavce.

V praxi [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) definuje levý okraj těla odstavce a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setIndent-float-) určuje pozici první řádky vzhledem k tomuto okraji. Pro vytvoření zavěšeného odsazení použijte kladnou hodnotu pro `setMarginLeft` a zápornou hodnotu pro `setIndent`.

Toto formátování je užitečné pro bibliografie, reference, glosáře a další odstavce, kde musí být zalomené řádky zarovnány pod tělo odstavce, nikoli pod první znak první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) do snímku.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) tvaru a odstraňte výchozí odstavec.
5. Vytvořte odstavce a přiřaďte kladnou hodnotu [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) pro každý odstavec.
6. Přiřaďte zápornou hodnotu [ParagraphFormat::setIndent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setIndent-float-) pro vytvoření efektu zavěšeného odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

Tento kód v PHP ukazuje, jak nastavit zavěšené odsazení pro odstavec:

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

### **Nastavení vlastností koncového běhu odstavce**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) řídí formátování koncového znaku odstavce. Následující příklad v PHP přiřazuje velikost písma a latinské písmo ke koncovému znaku druhého odstavce:

1. Načtěte [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a získejte snímek.
2. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) a vymažte jeho výchozí odstavec.
3. Vytvořte dva odstavce a přidejte k nim textové části.
4. Vytvořte [PortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portionformat/) pro koncový znak druhého odstavce.
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

## **Import a export obsahu odstavců**

### **Import HTML textu do odstavců**

Použijte [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) k převodu HTML značek na odstavce a části v textovém rámci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte snímek a přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
3. Získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) tvaru a vymažte jeho výchozí odstavec.
4. Přečtěte zdrojový soubor HTML.
5. Předávejte řetězec HTML metodě [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Uložte upravenou prezentaci.

Tento příklad v PHP importuje HTML do textového rámce:

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

Použijte [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) k exportu vybraného rozsahu odstavců jako HTML.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a načtěte požadovanou prezentaci.
2. Získejte snímek a najděte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/), který obsahuje text.
3. Získejte [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) tvaru.
4. Zavolejte [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) s počátečním indexem odstavce a počtem odstavců k exportu.
5. Zapište vrácený řetězec HTML do souboru.

Tento příklad v PHP exportuje všechny odstavce z prvního textového tvaru:

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

[Paragraph::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#getImage--) vykreslí jednotlivý odstavec přímo a vrátí objekt [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/). Výsledek uložte do souboru nebo proudu pomocí [IImage::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/#save-java.lang.String-int-). Nemusíte vykreslovat celý tvar ani ručně ořezávat bitmapu.

[Paragraph::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#getImage--) může vrátit `null`, pokud není odstavec nalezen v nadřazené kolekci, nemá platné vykreslovací hranice nebo nelze vykreslit. Zkontrolujte výsledek před uložením a po použití uvolněte vrácený obrázek.

#### **Vykreslení odstavce ve výchozím měřítku**

Předpokládejme, že máme soubor prezentace s názvem sample.pptx s jedním snímkem, kde je první tvar textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

Následující příklad v PHP vykreslí druhý odstavec v běžném textovém tvaru ve výchozím měřítku a uloží vrácený obrázek ve formátu PNG. Blok `finally` zajistí správné uvolnění obrázku.

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

Použijte přetížení [Paragraph::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#getImage-float-float-) přijímající parametry `$scaleX` a `$scaleY` pro nastavení horizontálního a vertikálního škálovacího faktoru. Následující příklad v PHP vytvoří tabulku, vykreslí odstavec v její první buňce dvakrát širší a vyšší než výchozí a uloží výsledek jako PNG obrázek.

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

Škálovací faktor `1` zachová výchozí velikost pixelu na dané ose. Například `2` pro oba faktory vytvoří obrázek, jehož šířka i výška jsou přibližně dvojnásobek výchozích rozměrů, tedy čtyřnásobek počtu pixelů. Větší faktory obecně poskytují ostřejší text při zoomování nebo výstupu ve vysokém rozlišení, ale také zvyšují využití paměti a velikost souboru. Faktory menší než `1` produkují menší obrázky s menšími detaily. Použijte stejné faktory pro zachování poměru stran odstavce; různé horizontální a vertikální faktory rozšiřují výstup nezávisle.

Vykreslení celého tvaru pomocí [Shape::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getImage--) je užitečné, když výstup musí zahrnovat výplň, okraj nebo další vizuální kontext tvaru. Pro obrázek pouze odstavce použijte [Paragraph::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#getImage--).

## **Často kladené otázky**

**Mohu zcela zakázat zalamování textu uvnitř textového rámce?**

Ano. Nastavte [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#setWrapText-byte-) pro zakázání zalamování, aby řádky nečelily okrajům textového rámce.

**Jak mohu získat přesné souřadnice odstavce na snímku?**

Použijte [Paragraph::getRect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#getRect--) k získání ohraničujícího obdélníku odstavce. [Portion::getRect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/#getRect--) poskytuje souřadnice jednotlivé části.

**Kde se řídí zarovnání odstavce (leve, pravé, středové nebo do bloku)?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setAlignment-int-) je nastavení na úrovni odstavce a vztahuje se na celý odstavec bez ohledu na formátování jednotlivých částí.

**Mohu nastavit jazyk kontroly pravopisu pro část odstavce?**

Ano. Nastavte [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) pro jednotlivé části, takže jeden odstavec může obsahovat text v několika jazycích.