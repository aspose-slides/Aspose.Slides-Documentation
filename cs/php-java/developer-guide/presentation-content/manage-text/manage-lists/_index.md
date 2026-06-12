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
- symbolová odrážka
- obrázková odrážka
- vlastní odrážka
- víceúrovňový seznam
- vytvořit odrážku
- přidat odrážku
- přidat seznam
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se vytvářet a formátovat odrážkové, obrázkové, víceúrovňové a číslované seznamy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Aspose.Slides for PHP via Java vám umožňuje vytvářet a formátovat odrážkové a číslované seznamy v prezentacích PowerPoint a OpenDocument. Položka seznamu je odstavec, jehož nastavení odrážek je řízeno prostřednictvím formátu odstavce.

Použijte metodu [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#getParagraphFormat--) k přístupu k nastavením seznamu na úrovni odstavce. Hlavním vstupním bodem je [ParagraphFormat.getBullet](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#getBullet--) , který vrací objekt [BulletFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/) . S tímto objektem můžete nastavit typ odrážky, symbol, obrázek, barvu, velikost, styl číslování a počáteční číslo.

Tento článek ukazuje, jak:

- vytvořit odrážkový seznam s vlastním symbolem
- vytvořit obrázkovou odrážku
- vytvořit víces úrovňový seznam nastavením hloubky odstavce
- vytvořit číslovaný seznam
- prohlédnout a změnit formátování seznamu v existující prezentaci

## **Vytvořit odrážkový seznam**

Chcete-li vytvořit odrážkový seznam, přidejte objekty [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/) do [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) a nastavte [BulletFormat.setType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#setType-int-) na [BulletType.Symbol](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bullettype/#Symbol) . Pak můžete nastavit [BulletFormat.setChar](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#setChar-char-) , [BulletFormat.getColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#getColor--) a [BulletFormat.setHeight](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#setHeight-float-) pro kontrolu vzhledu odrážky.

The following PHP code demonstrates how to create a bulleted list in a slide:

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

Výsledek:

![Symbolické odrážky](symbol_bullets.png)

## **Vytvořit číslovaný seznam**

Číslované seznamy použijte, když je důležitý pořadí položek. Nastavte [BulletFormat.setType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#setType-int-) na [BulletType.Numbered](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bullettype/#Numbered) . Můžete také zvolit formát číslování pomocí [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) nebo nastavit [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) , pokud má seznam začínat hodnotou jinou než 1.

The following PHP code shows how to create a numbered list in a slide:

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

Výsledek:

![Číslované odrážky](numbered_bullets.png)

## **Vytvořit obrázkovou odrážku**

Aspose.Slides vám umožňuje nahradit běžný symbol odrážky obrázkem. Obrázkové odrážky fungují nejlépe s jednoduchými obrázky, které zůstávají čitelné v malé velikosti, například ikony nebo malé průhledné soubory PNG.

{{% alert color="primary" %}}
Ideálně, pokud chcete nahradit běžný symbol odrážky obrázkem, je nejlepší zvolit jednoduchou grafiku s průhledným pozadím. Takové obrázky se dobře hodí jako vlastní symboly odrážek.

Mějte na paměti, že obrázek bude zmenšen na velmi malou velikost. Z tohoto důvodu důrazně doporučujeme vybrat obrázek, který zůstane jasný a vizuálně účinný, když se použije jako odrážka v seznamu.
{{% /alert %}}

Pro vytvoření obrázkové odrážky přidejte obrázek do [Presentation.getImages](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getImages--) a přiřaďte vrácený objekt [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) metodě [BulletFormat.getPicture](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#getPicture--) . Nastavte [BulletFormat.setType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bulletformat/#setType-int-) na [BulletType.Picture](https://reference.aspose.com/slides/cs/php-java/aspose.slides/bullettype/#Picture) před přiřazením obrázku.

Předpokládejme, že máme soubor "image.png":

![Obrázek pro odrážky](picture_for_bullets.png)

The following PHP code shows how to create picture bullets in a slide:

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

Výsledek:

![Obrázkové odrážky](picture_bullets.png)

## **Vytvořit víceúrovňový seznam**

Použijte [ParagraphFormat.setDepth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setDepth-short-) , abyste položky seznamu umístili na různé úrovně. Úroveň 0 je nejvyšší úroveň, úroveň 1 je pod ní a tak dále.

The following PHP code shows how to create a multilevel bulleted list:

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

Výsledek:

![Víceúrovňový seznam](multilevel_list.png)

## **Změnit existující seznam**

Pro změnu formátování seznamu v existující prezentaci přistupte k cílovému odstavci a aktualizujte jeho nastavení [ParagraphFormat.getBullet](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#getBullet--) . Stejné vlastnosti použité pro vytváření seznamů lze použít k prohlížení nebo úpravě seznamů načtených ze souboru PPT, PPTX nebo ODP.

The following PHP code changes the first paragraph in a text frame to use a numbered list style:

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

## **Často kladené otázky**

**Lze odrážkové a číslované seznamy exportovat do PDF nebo obrázků?**

Ano. Aspose.Slides zachovává formátování seznamu, pokud cílový formát podporuje odpovídající rozvržení textu a funkce odrážek.

**Mohu upravovat seznamy v existujících prezentacích?**

Ano. Načtěte prezentaci, přistupte k cílovému odstavci, prohlédněte nebo aktualizujte jeho nastavení [ParagraphFormat.getBullet](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#getBullet--) , a prezentaci uložte.

**Mohou seznamy obsahovat text mimo latinku?**

Ano. Text položek seznamu může obsahovat Unicode znaky, takže můžete vytvářet seznamy ve vícejazyčných prezentacích. Ujistěte se, že písma použitá v prezentaci podporují požadované znaky.