---
title: Управление маркированными и нумерованными списками в презентациях с использованием PHP
linktitle: Управление списками
type: docs
weight: 60
url: /ru/php-java/manage-lists/
keywords:
- маркер
- маркированный список
- нумерованный список
- символьный маркер
- маркер‑изображение
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
description: "Узнайте, как создавать и форматировать маркированные, маркеры‑изображения, многоуровневые и нумерованные списки в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Aspose.Slides for PHP via Java позволяет создавать и форматировать маркированные и нумерованные списки в презентациях PowerPoint и OpenDocument. Элемент списка — это абзац, настройки маркера которого управляются через его формат абзаца.

Use the [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#getParagraphFormat--) method to access paragraph-level list settings. The main entry point is [ParagraphFormat.getBullet](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#getBullet--) which returns a [BulletFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/) object. With this object, you can set the bullet type, symbol, picture, color, size, numbering style, and starting number.

Эта статья показывает, как:

- создать маркированный список с пользовательским символом
- создать изображение‑маркер
- создать многоуровневый список, задав глубину абзаца
- создать нумерованный список
- просмотреть и изменить форматирование списка в существующей презентации

## **Создать маркированный список**

To create a bulleted list, add [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/) objects to a [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) and set [BulletFormat.setType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setType-int-) to [BulletType.Symbol](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bullettype/#Symbol). You can then set [BulletFormat.setChar](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setChar-char-), [BulletFormat.getColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#getColor--), and [BulletFormat.setHeight](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setHeight-float-) to control the bullet appearance.

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

Результат:

![Символьные маркеры](symbol_bullets.png)

## **Создать нумерованный список**

Use numbered lists when the order of items matters. Set [BulletFormat.setType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setType-int-) to [BulletType.Numbered](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bullettype/#Numbered). You can also choose a numbering format with [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) or set [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) when the list should start from a value other than 1.

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

Результат:

![Нумерованные маркеры](numbered_bullets.png)

## **Создать маркер‑изображение**

Aspose.Slides позволяет заменить обычный символ маркера на изображение. Маркеры‑изображения работают лучше всего с простыми изображениями, которые остаются читаемыми при небольшом размере, например, значками или небольшими прозрачными PNG‑файлами.

{{% alert color="primary" %}}
Идеально, если вы планируете заменить обычный символ маркера изображением, выбирать простую графику с прозрачным фоном. Такие изображения хорошо подходят в качестве пользовательских маркеров.

Имейте в виду, что изображение будет уменьшено до очень малого размера. По этой причине мы настоятельно рекомендуем выбирать изображение, которое остаётся чётким и визуально эффективным при использовании в качестве маркера в списке.
{{% /alert %}}

To create a picture bullet, add an image to [Presentation.getImages](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getImages--) and assign the returned [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) object to [BulletFormat.getPicture](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#getPicture--). Set [BulletFormat.setType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setType-int-) to [BulletType.Picture](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bullettype/#Picture) before assigning the image.

Допустим, у нас есть файл "image.png":

![Изображение для маркеров](picture_for_bullets.png)

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

Результат:

![Маркер‑изображения](picture_bullets.png)

## **Создать многоуровневый список**

Use [ParagraphFormat.setDepth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setDepth-short-) to place list items on different levels. Level 0 is the top level, level 1 is nested below it, and so on.

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

Результат:

![Многоуровневый список](multilevel_list.png)

## **Изменить существующий список**

To change list formatting in an existing presentation, access the target paragraph and update its [ParagraphFormat.getBullet](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#getBullet--) settings. The same properties used to create lists can be used to inspect or modify lists loaded from a PPT, PPTX, or ODP file.

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

## **Часто задаваемые вопросы**

**Можно ли экспортировать маркированные и нумерованные списки в PDF или изображения?**

Да. Aspose.Slides сохраняет форматирование списка, если целевой формат поддерживает соответствующее расположение текста и функции маркеров.

**Можно ли редактировать списки в существующих презентациях?**

Да. Загрузите презентацию, получите нужный абзац, просмотрите или измените его настройки [ParagraphFormat.getBullet](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#getBullet--), и сохраните презентацию.

**Могут ли списки содержать нелатинские символы?**

Да. Текст элементов списка может содержать Unicode‑символы, поэтому вы можете создавать списки в многоязычных презентациях. Убедитесь, что шрифты, используемые в презентации, поддерживают необходимые символы.