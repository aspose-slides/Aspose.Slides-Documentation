---
title: Управление текстовыми абзацами PowerPoint в PHP
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
- импорт HTML
- текст в HTML
- абзац в HTML
- абзац в изображение
- текст в изображение
- экспортировать абзац
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как создавать и форматировать абзацы, фрагменты, маркеры, нумерованные списки, отступы, HTML‑контент и изображения абзацев с помощью Aspose.Slides for PHP via Java."
---
## **Обзор**

Aspose.Slides for PHP via Java представляет текст как иерархию текстовых фреймов, абзацев и фрагментов:

* [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) представляет контейнер текста в фигуре и предоставляет доступ к её коллекции абзацев.
* [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/) представляет один абзац в текстовом фрейме и предоставляет доступ к его фрагментам и параметрам форматирования уровня абзаца.
* [Portion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/) представляет фрагмент текста внутри абзаца. Каждый фрагмент может иметь собственный текст и форматирование уровня символов.

Таким образом, абзац может содержать текст с разными шрифтами, цветами, размерами и другими параметрами форматирования, используя несколько фрагментов.

## **Создание и форматирование абзацев**

### **Создание абзацев с несколькими фрагментами**

Следующие шаги создают текстовый фрейм с тремя абзацами, каждый из которых содержит три фрагмента:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите доступ к нужному слайду по его индексу.
3. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
4. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) фигуры.
5. Используйте абзац по умолчанию и добавьте два дополнительных объекта [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/) в текстовый фрейм.
6. Добавьте достаточное количество объектов [Portion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/) для каждого абзаца, чтобы они содержали по три фрагмента. Абзац по умолчанию уже содержит один пустой фрагмент.
7. Установите текст для каждого фрагмента.
8. Примените форматирование уровня символов через [Portion::getPortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/#getPortionFormat--).
9. Сохраните изменённую презентацию.

Этот пример PHP реализует шаги:

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

Маркировка и нумерация упрощают восприятие связанных элементов. В Aspose.Slides параметры списка задаются через [BulletFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите доступ к нужному слайду по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на выбранный слайд.
4. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/).
5. Удалите абзац по умолчанию из текстового фрейма.
6. Создайте [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/) для символической маркера.
7. Установите [BulletFormat::setType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setType-int-) в значение [BulletType::Symbol](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bullettype/) и укажите символ маркера.
8. Задайте текст абзаца, отступ, цвет маркера и высоту маркера.
9. Добавьте абзац в текстовый фрейм.
10. Создайте второй абзац и установите [BulletFormat::setType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setType-int-) в значение [BulletType::Numbered](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bullettype/).
11. Настройте стиль нумерованного маркера и добавьте абзац в текстовый фрейм.
12. Сохраните презентацию.

Этот пример PHP создаёт символический маркер и нумерованный маркер:

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

### **Использование графических маркеров**

Графические маркеры позволяют использовать собственное изображение вместо символа или числа.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите доступ к нужному слайду по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) и получите его [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/).
4. Удалите абзац по умолчанию из текстового фрейма.
5. Загрузите изображение маркера и добавьте его в коллекцию изображений презентации как [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/).
6. Создайте [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/) и задайте его текст.
7. Установите [BulletFormat::setType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setType-int-) в значение [BulletType::Picture](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bullettype/).
8. Присвойте изображение через [BulletFormat::getPicture](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#getPicture--) и задайте высоту маркера.
9. Добавьте абзац в текстовый фрейм.
10. Сохраните изменённую презентацию.

Этот пример PHP создаёт графический маркер:

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

Установите [ParagraphFormat::setDepth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setDepth-short-) чтобы разместить абзацы на разных уровнях списка. Верхний уровень имеет глубину `0`.

1. Создайте [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и получите доступ к слайду.
2. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) и очистите абзац по умолчанию из его текстового фрейма.
3. Создайте четыре абзаца и настройте их символы маркеров.
4. Задайте их значения [ParagraphFormat::setDepth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setDepth-short-) как `0`, `1`, `2` и `3`.
5. Добавьте абзацы в текстовый фрейм и сохраните презентацию.

Этот пример PHP создаёт четырёхуровневый маркированный список:

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

### **Начало нумерованных пунктов списка с пользовательскими значениями**

Используйте [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) чтобы задать начальный номер, отображаемый для нумерованного абзаца.

1. Создайте [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
2. Очистите абзац по умолчанию из текстового фрейма фигуры.
3. Создайте три нумерованных абзаца.
4. Установите [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) в `2`, `3` и `7` соответственно для этих абзацев.
5. Добавьте абзацы в текстовый фрейм и сохраните презентацию.

Этот пример PHP назначает пользовательский начальный номер каждому абзацу:

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

## **Управление расположением абзаца и свойствами конца**

### **Установка отступа первой строки**

Используйте [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setIndent-float-) чтобы задать отступ первой строки абзаца. Этот метод смещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Используйте [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) когда нужно сместить весь абзац. Используйте [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setIndent-float-) когда нужно сместить только первую строку.

Ниже приведён пример, который создаёт несколько абзацев и применяет разные значения [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setIndent-float-) для демонстрации влияния отступа первой строки на расположение абзаца.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите доступ к целевому слайду.
3. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
4. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) фигуры и удалите абзац по умолчанию.
5. Создайте несколько абзацев и задайте им разные значения [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setIndent-float-).
6. Добавьте абзацы в текстовый фрейм.
7. Сохраните изменённую презентацию.

Этот PHP‑код показывает, как задать отступ абзаца:

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

Висячий отступ — это расположение абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides такой эффект создаётся с помощью [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setIndent-float-). Передайте отрицательное значение, чтобы сместить первую строку влево относительно тела абзаца.

На практике [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) определяет левую позицию тела абзаца, а [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setIndent-float-) определяет позицию первой строки относительно этого поля. Чтобы создать висячий отступ, передайте положительное значение в `setMarginLeft` и отрицательное в `setIndent`.

Такое форматирование полезно для библиографий, списков литературы, глоссариев и других абзацев, где перенесённые строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите доступ к целевому слайду.
3. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
4. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) фигуры и удалите абзац по умолчанию.
5. Создайте абзацы и задайте положительное значение [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) для каждого абзаца.
6. Передайте отрицательное значение в [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setIndent-float-) чтобы создать эффект висячего отступа.
7. Добавьте абзацы в текстовый фрейм.
8. Сохраните изменённую презентацию.

Этот PHP‑код показывает, как задать висячий отступ для абзаца:

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

### **Установка свойств конца абзаца**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) управляет форматированием завершающего знака абзаца. Ниже показан PHP‑пример, который задаёт размер шрифта и латинский шрифт для завершающего знака второго абзаца:

1. Загрузите [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и получите доступ к слайду.
2. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) и очистите его абзац по умолчанию.
3. Создайте два абзаца и добавьте к ним текстовые фрагменты.
4. Создайте [PortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/) для завершающего знака второго абзаца.
5. Задайте [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) и [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
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

## **Импорт и экспорт содержимого абзаца**

### **Импорт HTML‑текста в абзацы**

Используйте [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) чтобы преобразовать разметку HTML в абзацы и фрагменты внутри текстового фрейма.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите доступ к слайду и добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/).
3. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) фигуры и очистите абзац по умолчанию.
4. Прочитайте исходный HTML‑файл.
5. Передайте строку HTML в [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Сохраните изменённую презентацию.

Этот пример PHP импортирует HTML в текстовый фрейм:

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

Используйте [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) чтобы экспортировать выбранный диапазон абзацев в виде HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и загрузите нужную презентацию.
2. Получите доступ к слайду и найдите [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) содержащий текст.
3. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/).
4. Вызовите [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) с индексом начального абзаца и количеством экспортируемых абзацев.
5. Запишите полученную строку HTML в файл.

Этот пример PHP экспортирует все абзацы из первой текстовой фигуры:

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

### **Отображение абзаца как изображения**

[Paragraph::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#getImage--) рендерит отдельный абзац непосредственно и возвращает объект [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/). Сохраните результат в файл или поток с помощью [IImage::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/#save-java.lang.String-int-). Не требуется рендерить содержащую фигуру или вручную обрезать растровое изображение.

[Paragraph::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#getImage--) может вернуть `null`, если абзац не найден в родительской коллекции, не имеет допустимых границ рендеринга или не может быть отрисован. Проверьте результат перед сохранением и освободите полученное изображение после использования.

#### **Отображение абзаца в масштабе по умолчанию**

Предположим, у нас есть файл презентации sample.pptx с одним слайдом, где первая фигура — текстовое поле с тремя абзацами.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

Следующий пример PHP отображает второй абзац обычной текстовой фигуры в масштабе по умолчанию и сохраняет полученное изображение в формате PNG. Блок `finally` гарантирует корректное освобождение изображения.

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

#### **Отображение абзаца в ячейке таблицы с масштабированием**

Используйте перегрузку [Paragraph::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#getImage-float-float-) принимающую параметры `$scaleX` и `$scaleY` для задания горизонтального и вертикального коэффициентов масштабирования. Ниже пример PHP, который создаёт таблицу, отображает абзац в первой ячейке при двойном размере по ширине и высоте и сохраняет результат как PNG‑изображение.

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

Коэффициент масштабирования `1` сохраняет размер оси по умолчанию. Например, `2` для обоих коэффициентов создаёт изображение, ширина и высота которого примерно вдвое больше стандартных размеров, что приводит к четырём раз больше пикселей. Большие коэффициенты обычно дают более чёткий текст при увеличении или выводе в высоком разрешении, но также увеличивают потребление памяти и размер файла. Коэффициенты ниже `1` дают меньшие изображения с меньшей детализацией. Используйте одинаковые коэффициенты, чтобы сохранить соотношение сторон абзаца; разные горизонтальные и вертикальные коэффициенты растягивают вывод независимо.

Отображение всей фигуры с помощью [Shape::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#getImage--) остаётся полезным, когда в выводе должны быть учтены заливка, граница или другой визуальный контекст фигуры. Для изображения только абзаца используйте [Paragraph::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#getImage--).

## **FAQ**

**Можно ли полностью отключить перенос строк внутри текстового фрейма?**

Да. Установите [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setWrapText-byte-) чтобы отключить перенос, поэтому строки не будут разрываться по краям фрейма.

**Как получить точные границы конкретного абзаца на слайде?**

Используйте [Paragraph::getRect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#getRect--) для получения ограничивающего прямоугольника абзаца. [Portion::getRect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/#getRect--) возвращает границы отдельного фрагмента.

**Где контролируется выравнивание абзаца (по левому, правому краю, по центру или по ширине)?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setAlignment-int-) – это настройка уровня абзаца и применяется ко всему абзацу независимо от форматирования отдельных фрагментов.

**Можно ли задать язык проверки правописания для части абзаца?**

Да. Установите [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) для отдельных фрагментов, чтобы один абзац мог содержать текст на нескольких языках.