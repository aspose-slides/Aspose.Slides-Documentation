---
title: Управление маркированными и нумерованными списками в презентациях с помощью PHP
linktitle: Управление списками
type: docs
weight: 60
url: /ru/php-java/manage-lists/
keywords:
- маркер
- маркированный список
- нумерованный список
- символический маркер
- маркер-изображение
- пользовательский маркер
- многоуровневый список
- создать маркер
- добавить маркер
- добавить список
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как создавать и форматировать маркированные, маркер-изображения, многоуровневые и нумерованные списки в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java."
---
## **Обзор**

Aspose.Slides for PHP via Java позволяет создавать и форматировать маркированные и нумерованные списки в презентациях PowerPoint и OpenDocument. Элемент списка — это абзац, настройки маркера которого управляются через его формат абзаца.

Используйте метод [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) для доступа к настройкам списка на уровне абзаца. Основной точкой входа является [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet), который возвращает объект [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) . С помощью этого объекта вы можете задать тип маркера, символ, изображение, цвет, размер, стиль нумерации и начальный номер.

This article shows how to:

- создать маркированный список с пользовательским символом
- создать маркер‑изображение
- создать многоуровневый список, задав глубину абзаца
- создать нумерованный список
- просмотреть и изменить форматирование списка в существующей презентации
- прочитать фактические маркеры списка и номера вместе с текстом абзаца

## **Создать маркированный список**

To create a bulleted list, add [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) objects to a [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) and set [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) to [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Symbol). You can then set [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar), [BulletFormat::getColor](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getColor), and [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) to control the bullet appearance.

The following PHP code demonstrates how to create a bulleted list in a slide:

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

Результат:

![Символьные маркеры](symbol_bullets.png)

## **Создать нумерованный список**

Use numbered lists when the order of items matters. Set [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) to [BulletType::Numbered](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Numbered). You can also choose a numbering format with [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) or set [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) when the list should start from a value other than 1.

The following PHP code shows how to create a numbered list in a slide:

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

Результат:

![Нумерованные маркеры](numbered_bullets.png)

## **Создать маркер‑изображение**

Aspose.Slides позволяет заменить обычный символ маркера изображением. Маркеры‑изображения лучше всего работают с простыми картинками, которые остаются разборчивыми при небольшом размере, например иконками или небольшими прозрачными PNG‑файлами.

{{% alert color="info" title="Note" %}}
Ideally, if you plan to replace the regular bullet symbol with an image, it's best to choose a simple graphic with a transparent background. Such images work well as custom bullet symbols.
Keep in mind that the image will be scaled down to a very small size. For that reason, we strongly recommend selecting an image that remains clear and visually effective when used as a bullet in a list.
{{% /alert %}}

To create a picture bullet, add an image to [Presentation::getImages](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getImages) and assign the returned [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) object to [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture). Set [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) to [BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture) before assigning the image.

Допустим, у нас есть "image.png":

![Изображение для маркеров](picture_for_bullets.png)

The following PHP code shows how to create picture bullets in a slide:

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

Результат:

![Маркер‑изображение](picture_bullets.png)

## **Создать многоуровневый список**

Use [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) to place list items on different levels. Level 0 is the top level, level 1 is nested below it, and so on.

The following PHP code shows how to create a multilevel bulleted list:

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

Результат:

![Многоуровневый список](multilevel_list.png)

## **Изменить существующий список**

To change list formatting in an existing presentation, access the target paragraph and update its [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) settings. The same properties used to create lists can be used to inspect or modify lists loaded from a PPT, PPTX, or ODP file.

The following PHP code changes the first paragraph in a text frame to use a numbered list style:

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

## **Прочитать фактические значения маркеров**

When extracting presentation content, keep list markers alongside paragraph text. Call [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getEffective) and access [ParagraphFormatEffectiveData::getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) to obtain the effective bullet format. Check its [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) before reading [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--).

For numbered lists, distinguish these three values:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) determines the format, such as Arabic numbers followed by a period or lowercase letters followed by a period.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) specifies the starting number for a group of numbered paragraphs.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) returns the formatted marker for a particular paragraph. For example, the second item in a list starting at 5 returns `6.`.

Preserve [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDepth) with each paragraph to retain its nesting level. The actual marker does not encode the full hierarchy: a nested item can return `c.` rather than a combined label such as `6.c.`.

The following self-contained example creates lists, saves them to a presentation, and reloads the presentation to report each paragraph's text, depth, bullet type, and actual value. The small blue picture marker is created from inline SVG.

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

    // Создать маркер‑изображение без внешнего файла изображения.
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

Исходные списки показаны ниже.

![Списки, начинающиеся с 5, вложенные элементы с буквами и римскими цифрами, символьный маркер, абзац без маркера и синий маркер‑изображение](actual_bullet_values.png)

Отчет соответствует маркерам, отображаемым в PowerPoint:

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

For [BulletType::None and BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/), [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) returns `null`, not an empty string. Handle these types separately: the former has no marker, while the latter requires extracting the bullet image separately. A picture bullet cannot be reproduced solely by extracting a text marker.

## **Часто задаваемые вопросы**

**Можно ли экспортировать маркированные и нумерованные списки в PDF или изображения?**

Yes. Aspose.Slides preserves list formatting when the target format supports the corresponding text layout and bullet features.

**Могу ли я редактировать списки в существующих презентациях?**

Yes. Load the presentation, access the target paragraph, inspect or update its [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) settings, and save the presentation.

**Могут ли списки содержать нелатинский текст?**

Yes. List item text can contain Unicode characters, so you can create lists in multilingual presentations. Make sure the fonts used in the presentation support the characters you need.