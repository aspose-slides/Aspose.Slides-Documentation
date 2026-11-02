---
title: Správa odrážkových a číslovaných seznamů v prezentacích pomocí PHP
linktitle: Správa seznamů
type: docs
weight: 60
url: /cs/php-java/manage-lists/
keywords:
- odrážka
- odrážkový seznam
- číslovaný seznam
- symbolická odrážka
- obrázková odrážka
- vlastní odrážka
- vícestupňový seznam
- vytvořit odrážku
- přidat odrážku
- přidat seznam
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak vytvořit a formátovat odrážkové, obrázkové, vícestupňové a číslované seznamy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides for PHP via Java."
---
## **Přehled**

Aspose.Slides for PHP via Java vám umožňuje vytvářet a formátovat odrážkové i číslované seznamy v prezentacích PowerPoint a OpenDocument. Položka seznamu je odstavec, jehož nastavení odrážky je řízeno prostřednictvím formátu odstavce.

Použijte metodu [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) k získání nastavení seznamu na úrovni odstavce. Hlavním vstupním bodem je [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet), který vrací objekt [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/). Pomocí tohoto objektu můžete nastavit typ odrážky, symbol, obrázek, barvu, velikost, styl číslování a počáteční číslo.

Tento článek ukazuje, jak:

- vytvořit odrážkový seznam s vlastním symbolem
- vytvořit obrázkovou odrážku
- vytvořit vícestupňový seznam nastavením hloubky odstavce
- vytvořit číslovaný seznam
- prozkoumat a změnit formátování seznamu v existující prezentaci
- přečíst skutečné značky a čísla seznamu vedle textu odstavce

## **Vytvoření odrážkového seznamu**

Chcete‑li vytvořit odrážkový seznam, přidejte objekty [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) do [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) a nastavte [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) na [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Symbol). Poté můžete nastavit [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar), [BulletFormat::getColor](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getColor) a [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) pro kontrolu vzhledu odrážky.

Následující kód PHP ukazuje, jak vytvořit odrážkový seznam na snímku:

```php
use aspose\slides\BulletType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

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
    $presentation->dispose();
}
```

Výsledek:

![Symbolické odrážky](symbol_bullets.png)

## **Vytvoření číslovaného seznamu**

Používejte číslované seznamy, když je důležité pořadí položek. Nastavte [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) na [BulletType::Numbered](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Numbered). Můžete také zvolit formát číslování pomocí [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) nebo nastavit [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith), pokud má seznam začít od hodnoty jiného než 1.

Následující kód PHP ukazuje, jak vytvořit číslovaný seznam na snímku:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

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
    $presentation->dispose();
}
```

Výsledek:

![Číslované odrážky](numbered_bullets.png)

## **Vytvoření obrázkové odrážky**

Aspose.Slides vám umožňuje nahradit běžný symbol odrážky obrázkem. Obrázkové odrážky fungují nejlépe s jednoduchými obrázky, které zůstávají čitelné při malé velikosti, například ikony nebo malé průhledné PNG soubory.

{{% alert color="info" title="Note" %}}
Ideálně, pokud plánujete nahradit běžný symbol odrážky obrázkem, je nejlepší zvolit jednoduchou grafiku s průhledným pozadím. Takové obrázky dobře fungují jako vlastní symboly odrážek.
{{% /alert %}}

Chcete‑li vytvořit obrázkovou odrážku, přidejte obrázek do [Presentation::getImages](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getImages) a přiřaďte vrácený objekt [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) k [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture). Před přiřazením obrázku nastavte [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) na [BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture).

Řekněme, že máme soubor "image.png":

![Obrázek pro odrážky](picture_for_bullets.png)

Následující kód PHP ukazuje, jak vytvořit obrázkové odrážky na snímku:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

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
    $presentation->dispose();
}
```

Výsledek:

![Obrázkové odrážky](picture_bullets.png)

## **Vytvoření vícestupňového seznamu**

Použijte [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) k umístění položek seznamu na různé úrovně. Úroveň 0 je nejvyšší úroveň, úroveň 1 je pod ní vnořená atd.

Následující kód PHP ukazuje, jak vytvořit vícestupňový odrážkový seznam:

```php
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

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
    $presentation->dispose();
}
```

Výsledek:

![Vícestupňový seznam](multilevel_list.png)

## **Změna existujícího seznamu**

Chcete‑li změnit formátování seznamu v existující prezentaci, získáte cílový odstavec a aktualizujete jeho nastavení [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet). Stejné vlastnosti použité k tvorbě seznamů lze použít k prozkoumání nebo úpravě seznamů načtených ze souborů PPT, PPTX nebo ODP.

Následující kód PHP mění první odstavec v textovém rámci tak, aby používal styl číslovaného seznamu:

```php
use aspose\slides\BulletType;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
    $presentation->dispose();
}
```

## **Čtení skutečných hodnot odrážek**

Při extrahování obsahu prezentace uchovávejte značky seznamu vedle textu odstavce. Zavolejte [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getEffective) a přistupte k [ParagraphFormatEffectiveData::getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) pro získání účinného formátu odrážky. Před čtením [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) zkontrolujte jeho [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--).

Pro číslované seznamy rozlište tyto tři hodnoty:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) určuje formát, například arabské číslice následované tečkou nebo malá písmena následovaná tečkou.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) určuje počáteční číslo pro skupinu číslovaných odstavců.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) vrací formátovanou značku pro konkrétní odstavec. Například druhá položka v seznamu začínajícím od 5 vrátí `6.`.

Uchovávejte [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDepth) u každého odstavce, aby zůstal jeho úroveň vnoření. Skutečná značka nezakóduje celou hierarchii: vnořená položka může vrátit `c.` místo kombinovaného popisku jako `6.c.`.

Následující samostatný příklad vytvoří seznamy, uloží je do prezentace a znovu načte prezentaci, aby nahlásil text, hloubku, typ odrážky a skutečnou hodnotu každého odstavce. Malý modrý obrázkový marker je vytvořen z vloženého SVG.

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 440, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20, 660, 400);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    // Vytvořte obrázkový marker bez externího souboru obrázku.
    $svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    $bulletImage = $presentation->getImages()->addImage($svg);

    $black = new Java("java.awt.Color", 0, 0, 0);
    $addParagraph = function ($text, $depth, $type, $start, $style) use ($textFrame, $bulletImage, $black) {
        $paragraph = new Paragraph();
        $paragraph->setText($text);

        $format = $paragraph->getParagraphFormat();
        $format->setDepth($depth);
        $format->setMarginLeft(30 + $depth * 40);
        $format->setIndent(-28);
        $format->setSpaceAfter(8);
        $format->getDefaultPortionFormat()->setFontHeight(22);
        $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $format->getBullet()->setType($type);
        $format->getBullet()->setBulletHardColor(NullableBool::True);
        $format->getBullet()->getColor()->setColor($black);
        if ($type == BulletType::Numbered) {
            $format->getBullet()->setNumberedBulletStyle($style);
            $format->getBullet()->setNumberedBulletStartWith($start);
        } else if ($type == BulletType::Symbol) {
            $format->getBullet()->setChar("\u{2022}");
        } else if ($type == BulletType::Picture) {
            $format->getBullet()->getPicture()->setImage($bulletImage);
        }

        $textFrame->getParagraphs()->add($paragraph);
    };

    $addParagraph("First item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Second item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Next nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Deep item", 2, BulletType::Numbered, 4, NumberedBulletStyle::BulletRomanLCPeriod);
    $addParagraph("Back to top level", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Symbol marker", 0, BulletType::Symbol, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("No bullet", 0, BulletType::None, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Picture marker", 0, BulletType::Picture, 1, NumberedBulletStyle::BulletArabicPeriod);
    $presentation->save("actual_bullet_values.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    $loadedShape = $loadedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Text | Depth | Type | Actual value\n";
    $paragraphs = $loadedShape->getTextFrame()->getParagraphs();
    for ($i = 0; $i < java_values($paragraphs->getCount()); $i++) {
        $paragraph = $paragraphs->get_Item($i);
        $bullet = $paragraph->getParagraphFormat()->getEffective()->getBullet();
        switch (java_values($bullet->getType())) {
            case BulletType::Numbered:
            case BulletType::Symbol:
                $marker = $bullet->getActualBulletValue();
                break;
            case BulletType::None:
                $marker = "null (no bullet)";
                break;
            case BulletType::Picture:
                $marker = "null (image required)";
                break;
            default:
                $marker = "unsupported bullet type";
                break;
        }
        $typeNames = [BulletType::Numbered => "Numbered", BulletType::Symbol => "Symbol", BulletType::None => "None", BulletType::Picture => "Picture"];
        $typeName = $typeNames[java_values($bullet->getType())] ?? "Unknown";
        echo $paragraph->getText() . " | " . $paragraph->getParagraphFormat()->getDepth() . " | " . $typeName . " | " . $marker . "\n";
    }
} finally {
    $loadedPresentation->dispose();
}
```

Zdrojové seznamy jsou zobrazeny níže.

![Seznamy začínající od 5, vnořené položky s písmeny a římskými čísly, symbolická značka, odstavec bez odrážky a modrý obrázkový marker](actual_bullet_values.png)

Report odpovídá značkám zobrazeným v PowerPointu:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Pro [BulletType::None and BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/) [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) vrací `null`, nikoli prázdný řetězec. Tyto typy zacházejte odděleně: první nemá žádnou značku, zatímco druhý vyžaduje samostatné získání obrázku odrážky. Obrázkovou odrážku nelze reprodukovat pouze extrahováním textové značky.

## **Často kladené otázky**

**Lze odrážkové a číslované seznamy exportovat do PDF nebo obrázků?**

Ano. Aspose.Slides zachovává formátování seznamu, pokud cílový formát podporuje odpovídající rozvržení textu a funkce odrážek.

**Mohu upravovat seznamy v existujících prezentacích?**

Ano. Načtěte prezentaci, přistupte k cílovému odstavci, prohlédněte nebo aktualizujte jeho nastavení [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet), a uložte prezentaci.

**Mohou seznamy obsahovat ne-latinský text?**

Ano. Text položek seznamu může obsahovat Unicode znaky, takže můžete vytvářet seznamy ve vícejazyčných prezentacích. Ujistěte se, že použité fonty v prezentaci podporují požadované znaky.