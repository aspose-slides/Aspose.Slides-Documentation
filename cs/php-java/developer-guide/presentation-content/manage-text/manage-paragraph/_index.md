---
title: Spravujte odstavce textu PowerPoint v PHP
linktitle: Spravovat odstavec
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
- závěsné odsazení
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
description: "Naučte se vytvářet a formátovat odstavce, části, odrážky, číslované seznamy, odsazení, HTML obsah a obrázky odstavců pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Aspose.Slides pro PHP via Java představuje text jako hierarchii textových rámců, odstavců a částí:

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) představuje kontejner textu ve tvaru a poskytuje přístup ke kolekci odstavců.
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) představuje jeden odstavec v textovém rámci a poskytuje přístup k jeho částem a formátování na úrovni odstavce.
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) představuje úsek textu v odstavci. Každý úsek může mít vlastní text a formátování na úrovni znaku.

Odstavec tak může obsahovat text s různými písmy, barvami, velikostmi a dalším formátováním pomocí více částí.

## **Vytvoření a formátování odstavců**

Vytvářejte odstavce v textovém rámci tvaru a používejte části k formátování jednotlivých úseků textu. V této sekci se ukazuje, jak kombinovat více částí v každém odstavci a aplikovat různé barvy, velikosti písma a styly.

### **Vytvoření odstavců s více částmi**

Následující příklad v PHP vytváří tři odstavce, z nichž každý obsahuje tři úseky textu ve sbírce vrácené metodou [Paragraph::getPortions](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getPortions). Znovu používá výchozí odstavec a jeho prázdnou část, poté přidá zbývající odstavce a části. Formátování je aplikováno pomocí [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat): první část v každém odstavci je červená, tučná a 15 bodů; druhá je modrá, kurzíva a 18 bodů. Třetí část si ponechává výchozí formátování:

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

Organizujte text odstavců do seznamů se symboly, čísly nebo vlastními obrázky. Příklady v této sekci pokrývají formátování odrážek, víceúrovňové seznamy a vlastní počáteční čísla.

### **Vytvoření odrážkového nebo číslovaného seznamu**

Odrážky a číslování usnadňují prohlížení souvisejících položek. V Aspose.Slides jsou nastavení seznamu definována pomocí [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/).

Tento příklad v PHP přidává symbolickou odrážku a číslovanou položku do stejného textového rámce. [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) vybírá typ odrážky, zatímco [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) určuje symbol a [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) vybírá styl číslování. Obě položky používají černé odrážky s výškou 100 % a odsazením odstavce 25 bodů:

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

Tento příklad v PHP přidává obrázek do kolekce obrázků prezentace jako [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) a používá jej jako odrážku odstavce. Volá [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) pro použití obrázkové odrážky a přiřazuje obrázek pomocí [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture). [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) je nastaven na 100 % pro velikost odrážky relativně k textu odstavce:

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

Nastavte [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) pro umístění odstavců na různé úrovně seznamu. Nejvyšší úroveň má hloubku `0`.

Tento příklad v PHP přiřazuje hodnoty [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) od 0 do 3 čtyřům odstavcům, čímž vytváří hierarchii v jednom textovém rámci. Každý odstavec používá symbolickou odrážku, přičemž [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) střídavě používá kulatou odrážku a pomlčku pro odlišení sousedních úrovní:

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

### **Zahájení číslovaných položek seznamu na vlastní hodnoty**

Použijte [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) pro nastavení počátečního čísla zobrazovaného u číslovaného odstavce.

Tento příklad v PHP nastavuje [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) pro číslování tří odstavců a přiřazuje hodnoty [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) 2, 3 a 7. Počáteční hodnota je konfigurována zvlášť pro každý odstavec, což umožňuje, aby se zobrazovaná čísla přeskočila:

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

## **Řízení rozvržení odstavce a koncových vlastností**

Upravujte okraje a odsazení odstavců pro kontrolu polohy první řádky a zalomených řádků. Můžete také formátovat koncový znak odstavce odděleně od viditelných částí textu.

### **Nastavení odsazení první řádky**

Použijte metodu [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) pro ovlivnění odsazení první řádky odstavce. Toto nastavení posouvá jen první řádku relativně k levému okraji odstavce. Kladná hodnota posune první řádku doprava, zatímco zbývající řádky zůstávají zarovnány k tělu odstavce.

Použijte [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft), pokud potřebujete posunout celý odstavec. Použijte [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent), pokud potřebujete posunout jen první řádku.

Následující příklad dává třem odstavcům stejné [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) 20 bodů a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) hodnoty 0, 20 a 40 bodů. První řádky začínají na postupně větších offsetech, zatímco zalomené řádky si zachovávají stejný levý okraj:

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

### **Nastavení závěsného odsazení**

Závěsné odsazení je rozvržení odstavce, ve kterém první řádka začíná vlevo od zbývajících řádků. V Aspose.Slides vytvoříte tento efekt pomocí vlastnosti [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent). Nastavte `Indent` na zápornou hodnotu, aby se první řádka posunula vlevo vůči tělu odstavce.

V praxi [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) určuje levou pozici těla odstavce a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) určuje pozici první řádky relativně k tomuto okraji. Pro vytvoření závěsného odsazení nastavte kladnou hodnotu `MarginLeft` a zápornou hodnotu `Indent`.

Toto formátování je užitečné pro bibliografie, reference, glosáře a další odstavce, kde musí být zalomené řádky zarovnány pod tělo odstavce, nikoli pod první znak první řádky.

Následující příklad v PHP spojuje hodnoty [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) 40 a 60 bodů s hodnotami [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) -20 a -30 bodů. V každém odstavci první řádka začíná vlevo od zalomených řádků; druhý odstavec má hlubší závěsné odsazení:

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

![Závěsné odsazení odstavců](hanging_indent.png)

### **Nastavení vlastností koncové běhu odstavce**

Metoda [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) řídí formátování koncového znaku odstavce. Následující příklad vytváří [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) s [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) nastaveným na 48 bodů a [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont) nastaveným na Times New Roman. Tento formát přiřadí koncovému znaku druhého odstavce, přičemž viditelné textové části zůstávají nezměněny:

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

Pro pravidla odstavců, která ovlivňují automatické zalamování a interpunkci na konci řádku, viz [Control Line Breaking](/slides/cs/php-java/text-formatting/#control-line-breaking) a [Control Hanging Punctuation](/slides/cs/php-java/text-formatting/#control-hanging-punctuation).

Použijte [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) pro spočítání řádků obsazených odstavcem po rozložení textu, včetně automatického zalamování. To je užitečné při kontrole délky textu a rozvržení v šablonách prezentací.

Odstavec je jednou položkou v [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs) a může zabírat několik vykreslených řádků. Explicitní zalomení řádku v odstavci vynutí nový řádek, aniž by vytvořilo další odstavec. Automatické zalamování vytváří řádky na základě dostupné šířky, aniž by vkládalo explicitní znaky zalomení do textu. Počítání odstavců nebo znaků zalomení proto nedává počet vykreslených řádků.

Následující příklad vytváří textový tvar, počítá jeho řádky, zužuje tvar a poté nahrazuje text kratším řetězcem. Příklad povoluje zalamování pomocí [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) a vypíná automatické přizpůsobení pomocí [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType), takže šířka tvaru řídí zalamování bez automatického zmenšování textu nebo změny velikosti tvaru. Každé měření používá [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount). Rozměry tvaru jsou v bodech. Nakonec příklad přidá další odstavec a sečte počty řádků napříč textovým rámcem.

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

Se zmenšením tvaru se počet řádků zvyšuje, zatímco nahrazení textu krátkým řetězcem jej snižuje. Přesné počty se mohou lišit podle dostupnosti písma a jeho náhrad, velikosti písma, okrajů, odsazení, zalamování a nastavení automatického přizpůsobení. Používejte písma a nastavení rozvržení určená pro cílové prostředí při kontrole šablony.

Samotný počet řádků neurčuje, zda text přesahuje kontejner. Důležité jsou také dostupná výška, výšky řádků, mezery mezi odstavci a řádky a chování automatického přizpůsobení; i jeden řádek může překročit dostupnou šířku, pokud je zalamování vypnuté.

## **Import a export obsahu odstavců**

Použijte HTML pro vložení textu do prezentace nebo export existujících odstavců pro použití mimo ni. Tato sekce také ukazuje, jak vykreslit jednotlivé odstavce jako obrázky, včetně odstavců v buňkách tabulek.

### **Import HTML textu do odstavců**

Použijte [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) pro převod HTML značek na odstavce a části v textovém rámci.

Tento příklad v PHP čte HTML ze souboru a předává značky metodě [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml). Vymaže výchozí odstavec textového rámce, aby rámec obsahoval jen importovaný obsah. Obdélníkový tvar ponechává okraj 10 bodů na každé straně snímku:

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

### **Export textu odstavců do HTML**

Použijte [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml) pro export vybraného rozsahu odstavců jako HTML. Při opětovném použití textu prezentace na webu můžete chtít zachovat lokální zvýraznění bez přenášení písma, velikosti nebo stylů textového pole z prezentace. Nastavte [TextToHtmlConversionOptions::setTextInheritanceLimit](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) pro řízení, jak daleko exportér sleduje dědičnost formátování.

Stáhněte [vzorkovou prezentaci](text-inheritance.pptx) a umístěte ji do pracovního adresáře aplikace. Její první snímek obsahuje jeden textový tvar s textem „Inherited text; explicit red 18pt“. Vstup záměrně používá několik úrovní formátování:

- Výchozí styl textu prezentace poskytuje Calibri a velikost 28 pt.
- První úroveň stylu textového rámce poskytuje modrý text a kurzívu.
- Odstavec explicitně nastavuje tučný text.
- Druhá část, „explicit red 18pt“, explicitně nastavuje červený text a velikost 18 pt.

Následující kompletní příklad exportuje stejné odstavce třikrát. Předává [TextToHtmlConversionOptions](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/) metodě exportu a zapisuje každý výsledek jako samostatný soubor UTF‑8 HTML:

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

Vygenerované HTML obsahuje následující CSS pro první část, „Inherited text; “. Tabulka uvádí relevantní deklarace; ostatní vygenerované vlastnosti jsou vynechány pro přehlednost.

| Výstup | Relevantní CSS pro první část | Vzhled |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Modrý, tučný, kurzívní text 28 pt v Calibri, pokud je toto písmo k dispozici. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Modrý, tučný, kurzívní text; okolní stránka nebo prohlížeč dodává rodinu písma a velikost. |
| `ParagraphOnly.html` | `font-weight:bold` | Tučný text; okolní stránka nebo prohlížeč dodává rodinu písma, velikost, barvu a kurzívní styl. |

Druhá část si zachovává `color:#ff0000`, `font-size:18pt` a `font-weight:bold` ve všech třech výstupech. Také si zachovává kurzívu v `All` a `TextBox`, ale ne v `ParagraphOnly`. Omezení dědičnosti tedy neodstraňuje formátování, které bylo výslovně přiřazeno odstavci nebo části.

Otevřete soubory ve stejném prohlížeči a porovnejte je. V dvou omezených režimech jsou vynechané CSS vlastnosti řešeny styly cílové stránky nebo výchozími nastaveními prohlížeče, takže výsledný vzhled závisí na tom, kde je HTML použito.

### **Vykreslení odstavce jako obrázku**

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) vykreslí jednotlivý odstavec přímo a vrátí [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/). Výsledek uložte do souboru nebo proudu pomocí [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Nemusíte vykreslovat celý tvar nebo ručně ořezávat bitmapu.

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) může vrátit `null`, pokud odstavec nelze najít v nadřazené kolekci, nemá platné vykreslovací hranice nebo jej nelze vykreslit. Zkontrolujte výsledek před uložením a po použití uvolněte vrácený obrázek.

#### **Vykreslení odstavce v základním měřítku**

Příklad používá prezentaci s jedním snímkem, jehož první tvar je textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

Následující příklad vybírá druhý odstavec s indexem 1 a volá [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) bez parametrů měřítka. Kontroluje, že tvar obsahuje požadovaný odstavec a že vykreslení vrátí obrázek, než zavolá [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) pro uložení ve formátu PNG. Blok `finally` uvolňuje obrázek po použití.

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

Použijte přetíženou verzi [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage), která přijímá parametry `$scaleX` a `$scaleY` pro nastavení horizontálního a vertikálního faktoru měřítka. Následující příklad vytvoří tabulku, vykreslí odstavec v její první buňce při dvojnásobné šířce i výšce oproti výchozímu a uloží výsledek jako PNG obrázek.

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

Faktor měřítka `1` zachovává osu v její výchozí velikosti pixelů. Například `2` pro oba faktory vytvoří obrázek, jehož šířka a výška jsou přibližně dvojnásobné oproti výchozím rozměrům, což vede ke čtyřnásobnému počtu pixelů. Větší faktory obecně poskytují ostřejší text pro zvětšení nebo výstup ve vysokém rozlišení, ale také zvyšují spotřebu paměti a velikost souboru. Faktory pod `1` vytvářejí menší obrázky s menšími detaily. Použijte stejné faktory pro zachování poměru stran odstavce; odlišné horizontální a vertikální faktory obraz roztaží nezávisle.

Vykreslení celého tvaru pomocí [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) je užitečné, když výstup musí zahrnovat výplň, okraj nebo jiný vizuální kontext tvaru. Pro obrázek pouze odstavce použijte [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Mohu zcela zakázat zalamování řádků uvnitř textového rámce?**

Ano. Nastavte [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) na vypnutí zalamování, aby řádky nevybíhaly na okrajích textového rámce.

**Jak mohu získat přesné souřadnice konkrétního odstavce na snímku?**

Použijte [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) pro získání ohraničujícího obdélníku odstavce. [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect) poskytuje souřadnice jednotlivé části.

**Kde se řídí zarovnání odstavce (vlevo, vpravo, na střed nebo do bloku)?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) je nastavení na úrovni odstavce a platí pro celý odstavec bez ohledu na formátování jednotlivých částí.

Pro vertikální zarovnání částí s různými velikostmi písma v každém řádku viz [Align Fonts Within a Line](/slides/cs/php-java/text-formatting/#align-fonts-within-a-line).

**Mohu nastavit jazyk kontroly pravopisu pro část odstavce?**

Ano. Nastavte [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) pro jednotlivé části, takže jeden odstavec může obsahovat text v několika jazycích.