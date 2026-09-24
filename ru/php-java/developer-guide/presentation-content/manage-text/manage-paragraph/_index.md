---
title: Управление абзацами PowerPoint в PHP
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- добавить текст
- добавить абзац
- управлять текстом
- управлять абзацем
- управлять маркером
- отступ абзаца
- висячий отступ
- маркер абзаца
- нумерованный список
- маркированный список
- свойства абзаца
- импортировать HTML
- текст в HTML
- абзац в HTML
- абзац в изображение
- текст в изображение
- экспортировать абзац
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как создавать и форматировать абзацы, части, маркеры, нумерованные списки, отступы, HTML‑содержимое и изображения абзацев с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Aspose.Slides для PHP через Java представляет текст как иерархию текстовых фреймов, абзацев и частей:

* [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) представляет контейнер текста в фигуре и предоставляет доступ к его коллекции абзацев.
* [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/) представляет один абзац в текстовом фрейме и предоставляет доступ к его частям и форматированию уровня абзаца.
* [Portion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/) представляет фрагмент текста внутри абзаца. Каждая часть может иметь собственный текст и форматирование на уровне символов.

Таким образом, абзац может содержать текст с разными шрифтами, цветами, размерами и другим форматированием, используя несколько частей.

## **Создание и форматирование абзацев**

### **Создание абзацев с несколькими частями**

Следующие шаги создают текстовый фрейм с тремя абзацами, каждый из которых содержит три части:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите нужный слайд по его индексу.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) фигуры.
5. Используйте абзац по умолчанию и добавьте два дополнительных объекта [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/) в текстовый фрейм.
6. Добавьте достаточное количество объектов [Portion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/) для каждого абзаца, чтобы он содержал три части. Абзац по умолчанию уже содержит одну пустую часть.
7. Установите текст каждой части.
8. Примените форматирование на уровне символов с помощью [Portion::getPortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/#getPortionFormat--).
9. Сохраните изменённую презентацию.

Этот пример на PHP реализует шаги:

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

## **Создание маркированных и нумерованных списков**

### **Создание маркированного или нумерованного списка**

Маркированные и нумерованные списки упрощают восприятие связанных элементов. В Aspose.Slides параметры списка задаются через [BulletFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) фигуры.
5. Удалите абзац по умолчанию из текстового фрейма.
6. Создайте [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/) для символа маркера.
7. Установите [BulletFormat::setType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setType-int-) в значение [BulletType::Symbol](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bullettype/) и укажите символ маркера.
8. Задайте текст абзаца, отступ, цвет маркера и высоту маркера.
9. Добавьте абзац в текстовый фрейм.
10. Создайте второй абзац и установите [BulletFormat::setType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setType-int-) в значение [BulletType::Numbered](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bullettype/).
11. Настройте стиль нумерованного маркера и добавьте абзац в текстовый фрейм.
12. Сохраните презентацию.

Этот пример на PHP создает символный маркер и нумерованный маркер:

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

### **Использовать картинные маркеры**

Картинные маркеры позволяют использовать пользовательское изображение вместо символа или числа.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) и получите его [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/).
4. Удалите абзац по умолчанию из текстового фрейма.
5. Загрузите изображение маркера и добавьте его в коллекцию изображений презентации как [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/).
6. Создайте [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/) и задайте его текст.
7. Установите [BulletFormat::setType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setType-int-) в значение [BulletType::Picture](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bullettype/).
8. Назначьте изображение через [BulletFormat::getPicture](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#getPicture--) и задайте высоту маркера.
9. Добавьте абзац в текстовый фрейм.
10. Сохраните изменённую презентацию.

Этот пример на PHP создаёт картинный маркер:

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

### **Создание многоуровневого списка**

Установите [ParagraphFormat::setDepth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setDepth-short-) для размещения абзацев на разных уровнях списка. Верхний уровень имеет глубину `0`.

1. Создайте [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и откройте слайд.
2. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) и очистите абзац по умолчанию из его текстового фрейма.
3. Создайте четыре абзаца и настройте их символы маркеров.
4. Установите их значения [ParagraphFormat::setDepth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setDepth-short-) в `0`, `1`, `2` и `3`.
5. Добавьте абзацы в текстовый фрейм и сохраните презентацию.

Этот пример на PHP создает четырехуровневый маркированный список:

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

### **Начало нумерованных элементов списка со своих значений**

Используйте [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) для задания начального числа, отображаемого для нумерованного абзаца.

1. Создайте [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
2. Очистите абзац по умолчанию из текстового фрейма фигуры.
3. Создайте три нумерованных абзаца.
4. Установите [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) в `2`, `3` и `7` для соответствующих абзацев.
5. Добавьте абзацы в текстовый фрейм и сохраните презентацию.

Этот пример на PHP присваивает каждому абзацу собственное начальное число:

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

## **Управление макетом абзаца и конечными свойствами**

### **Установка отступа первой строки**

Используйте [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setIndent-float-) для управления отступом первой строки абзаца. Этот метод смещает только первую строку относительно левого поля абзаца. Положительное значение перемещает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Используйте [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-), когда нужно сместить весь абзац. Используйте [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setIndent-float-), когда требуется сместить только первую строку.

Ниже показан пример, создающий несколько абзацев и применяющий различные значения [ParagraphFormat::setIndent] для демонстрации влияния отступа первой строки на макет абзаца.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Откройте целевой слайд.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) фигуры и удалите абзац по умолчанию.
5. Создайте несколько абзацев и задайте им разные значения [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setIndent-float-).
6. Добавьте абзацы в текстовый фрейм.
7. Сохраните изменённую презентацию.

Этот код на PHP показывает, как установить отступ абзаца:

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

Результат:

![Отступ первой строки абзацев](first_line_indent.png)

### **Установка висячего отступа**

Висячий отступ — это макет абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides такой эффект создаётся с помощью [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setIndent-float-). Передайте отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) определяет левую позицию тела абзаца, а [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setIndent-float-) задаёт позицию первой строки относительно этого поля. Чтобы создать висячий отступ, передайте положительное значение в `setMarginLeft` и отрицательное значение в `setIndent`.

Это форматирование удобно для библиографий, ссылок, глоссариев и других абзацев, где перенесённые строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Откройте целевой слайд.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) фигуры и удалите абзац по умолчанию.
5. Создайте абзацы и передайте положительное значение в [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) для каждого абзаца.
6. Передайте отрицательное значение в [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setIndent-float-) для создания эффекта висячего отступа.
7. Добавьте абзацы в текстовый фрейм.
8. Сохраните изменённую презентацию.

Этот код на PHP показывает, как установить висячий отступ для абзаца:

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

Результат:

![Висячий отступ абзацев](hanging_indent.png)

### **Установка свойств конечной части абзаца**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) управляет форматированием конечного маркера абзаца. Ниже приведён пример на PHP, который задаёт размер шрифта и латинский шрифт для конечного маркера второго абзаца:

1. Загрузите [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и откройте слайд.
2. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) и очистите его абзац по умолчанию.
3. Создайте два абзаца и добавьте к ним текстовые части.
4. Создайте [PortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/) для конечного маркера второго абзаца.
5. Установите [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) и [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Примените формат с помощью [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) и сохраните презентацию.

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

## **Подсчёт отрисованных строк**

Используйте [Paragraph::getLinesCount](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#getLinesCount--) для подсчёта строк, занимаемых абзацем после размещения текста, включая автоматический перенос. Это полезно при проверке длины текста и макета в шаблонах презентаций.

Абзац является одним из элементов [TextFrame::getParagraphs](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#getParagraphs--) и может занимать несколько отрисованных строк. Явный разрыв строки внутри абзаца заставляет начать новую строку без создания нового абзаца. Автоматический перенос создаёт строки в зависимости от доступной ширины без вставки явных разрывов в текст. Поэтому подсчёт абзацев или символов разрыва строк не даёт количества отрисованных строк.

Ниже пример, создающий текстовую фигуру, подсчитывающий её строки, сужающий фигуру и затем заменяющий текст более короткой строкой. Перенос включён, а автоподгонка отключена, чтобы ширина фигуры управляла переносом без автоматического уменьшения текста или изменения размеров фигуры. Размеры фигуры указаны в пунктах. Затем пример добавляет ещё один абзац и суммирует количество строк во всём текстовом фрейме.

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

При данном тексте и этих размерах сужение фигуры увеличивает количество строк, а замена текста короткой строкой уменьшает его. Точные подсчёты могут различаться в зависимости от доступных шрифтов и их замен, размера шрифта, полей, отступов, переноса и настроек автоподгонки. При проверке шаблона используйте шрифты и параметры макета, предназначенные для целевой среды.

Само количество строк не определяет, выходит ли текст за пределы контейнера. Важны доступная высота, высота строк, интервалы абзацев и строк, а также поведение автоподгонки; даже одна строка может превышать доступную ширину, если перенос отключён.

## **Импорт и экспорт содержимого абзаца**

### **Импорт HTML‑текста в абзацы**

Используйте [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) для преобразования разметки HTML в абзацы и части внутри текстового фрейма.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Откройте слайд и добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/).
3. Получите [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) фигуры и очистите абзац по умолчанию.
4. Прочитайте исходный файл HTML.
5. Передайте строку HTML в [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Сохраните изменённую презентацию.

Этот пример на PHP импортирует HTML в текстовый фрейм:

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

### **Экспорт текста абзаца в HTML**

Используйте [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) для экспорта выбранного диапазона абзацев в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и загрузите нужную презентацию.
2. Откройте слайд и найдите [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/), содержащий текст.
3. Получите [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) фигуры.
4. Вызовите [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) с указанием индекса начального абзаца и количества экспортируемых абзацев.
5. Запишите полученную строку HTML в файл.

Этот пример на PHP экспортирует все абзацы из первой текстовой фигуры:

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

### **Отрисовка абзаца как изображения**

[Paragraph::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#getImage--) отрисовывает отдельный абзац напрямую и возвращает объект [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/). Сохраните результат в файл или поток с помощью [IImage::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/#save-java.lang.String-int-). Нет необходимости отрисовывать содержащую фигуру или вручную обрезать bitmap.

[Paragraph::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#getImage--) может вернуть `null`, если абзац не найден в родительской коллекции, не имеет валидных границ отрисовки или не может быть отрисован. Проверьте результат перед сохранением и освободите полученное изображение после использования.

#### **Отрисовка абзаца в масштабе по умолчанию**

Предположим, у нас есть файл презентации sample.pptx с одним слайдом, где первая фигура — текстовый блок, содержащий три абзаца.

![Текстовый блок с тремя абзацами](paragraph_to_image_input.png)

Следующий пример на PHP отрисовывает второй абзац в обычной текстовой фигуре в масштабе по умолчанию и сохраняет полученное изображение в формате PNG. Блок `finally` гарантирует корректное освобождение изображения.

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

Результат:

![Изображение абзаца](paragraph_to_image_output.png)

#### **Отрисовка абзаца в ячейке таблицы с масштабированием**

Используйте перегрузку [Paragraph::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#getImage-float-float-) с параметрами `$scaleX` и `$scaleY` для задания горизонтального и вертикального коэффициентов масштабирования. Ниже пример на PHP, который создаёт таблицу, отрисовывает абзац в её первой ячейке с двойной шириной и высотой относительно значений по умолчанию и сохраняет результат в PNG‑изображение.

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

Коэффициент `1` сохраняет размер оси по умолчанию в пикселях. Например, `2` для обоих коэффициентов даёт изображение, ширина и высота которого примерно в два раза больше исходных размеров, а количество пикселей увеличивается в четыре раза. Большие коэффициенты обычно дают более чёткий текст при масштабировании или выводе в высоком разрешении, но также увеличивают потребление памяти и размер файла. Коэффициенты ниже `1` producen более мелкие изображения с меньшей детализацией. Используйте одинаковые коэффициенты, чтобы сохранить соотношение сторон абзаца; разные горизонтальный и вертикальный коэффициенты растягивают вывод независимо.

Отрисовка всей фигуры с помощью [Shape::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#getImage--) остаётся полезной, когда необходимо включить заливку, контур или другой визуальный контекст фигуры. Для изображения только абзаца используйте [Paragraph::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#getImage--).

## **Часто задаваемые вопросы**

**Могу ли я полностью отключить перенос строк внутри текстового фрейма?**

Да. Установите [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setWrapText-byte-) чтобы отключить перенос, и строки не будут разрываться у краёв текстового фрейма.

**Как получить точные границы конкретного абзаца на слайде?**

Используйте [Paragraph::getRect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#getRect--) для получения ограничивающего прямоугольника абзаца. [Portion::getRect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/#getRect--) предоставляет границы отдельной части.

**Где контролируется выравнивание абзаца (по левому, правому краю, по центру или по ширине)?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setAlignment-int-) — это настройка уровня абзаца и применяется ко всему абзацу независимо от форматирования отдельных частей.

**Можно ли задать язык проверки правописания для части абзаца?**

Да. Установите [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) для отдельных частей, так что один абзац может содержать текст на разных языках.