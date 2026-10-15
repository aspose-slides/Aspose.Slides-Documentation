---
title: Управление абзацами текста PowerPoint в PHP
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
- экспорт абзаца
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как создавать и форматировать абзацы, фрагменты, маркеры, нумерованные списки, отступы, HTML‑контент и изображения абзацев с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Aspose.Slides for PHP via Java представляет текст как иерархию текстовых рамок, абзацев и фрагментов:

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) представляет контейнер текста в фигуре и предоставляет доступ к коллекции абзацев.
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) представляет один абзац в текстовой рамке и предоставляет доступ к его фрагментам и форматированию уровня абзаца.
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) представляет фрагмент текста внутри абзаца. Каждый фрагмент может иметь собственный текст и форматирование символов.

Таким образом, абзац может содержать текст с разными шрифтами, цветами, размерами и другим форматированием, используя несколько фрагментов.

## **Создание и форматирование абзацев**

Создавайте абзацы в текстовой рамке фигуры и используйте фрагменты для форматирования отдельных фрагментов текста. В этом разделе показано, как объединять несколько фрагментов внутри каждого абзаца и применять разные цвета, размеры шрифтов и стили.

### **Создание абзацев с несколькими фрагментами**

Следующий пример PHP создаёт три абзаца, каждый из которых содержит три текстовых фрагмента в коллекции, возвращаемой [Paragraph::getPortions](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getPortions). Он переиспользует абзац по умолчанию и его пустой фрагмент, затем добавляет оставшиеся абзацы и фрагменты. Форматирование применяется через [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat): первый фрагмент в каждом абзаце — красный, полужирный, 15 пунктов; второй — синий, курсив, 18 пунктов. Третий фрагмент сохраняет форматирование по умолчанию:

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

Организуйте текст абзацев в списки с символами, цифрами или пользовательскими изображениями. Примеры в этом разделе охватывают форматирование маркеров, многоуровневые списки и пользовательские начальные номера.

### **Создание маркированного или нумерованного списка**

Маркеры и нумерация упрощают восприятие связанных элементов. В Aspose.Slides параметры списка задаются через [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/).

Этот пример PHP добавляет символный маркер и нумерованный элемент в одну и ту же текстовую рамку. [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) выбирает тип маркера, а [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) задаёт символ, и [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) выбирает стиль нумерации. Оба элемента используют чёрные маркеры высотой 100 % и отступ абзаца 25 пунктов:

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

### **Использование изображений в качестве маркеров**

Изображения‑маркеры позволяют использовать собственное изображение вместо символа или цифры.

Этот пример PHP добавляет изображение в коллекцию изображений презентации как [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) и использует его в качестве маркера абзаца. Он вызывает [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) для выбора маркера‑изображения и назначает изображение через [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture). [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) устанавливается в 100 % для размера маркера относительно текста абзаца:

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

Установите [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth), чтобы разместить абзацы на разных уровнях списка. Верхний уровень имеет глубину `0`.

Этот пример PHP задаёт значения [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) от 0 до 3 для четырёх абзацев, создавая иерархию в одной текстовой рамке. Каждый абзац использует символный маркер, при этом [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) чередуется между круглым маркером и дефисом для различения соседних уровней:

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

### **Задание пользовательских значений начала нумерованных пунктов**

Используйте [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith), чтобы установить начальное число, отображаемое для нумерованного абзаца.

Этот пример PHP устанавливает [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) для нумерации трёх абзацев и задаёт значения [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) 2, 3 и 7. Начальное значение задаётся отдельно для каждого абзаца, позволяя пропускать числа:

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

## **Управление макетом абзаца и свойствами конца**

Регулируйте отступы и поля абзаца, чтобы управлять положением первой строки и строк переноса. Вы также можете форматировать знак конца абзаца отдельно от видимых текстовых фрагментов.

### **Установка отступа первой строки**

Используйте метод [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) для управления отступом первой строки абзаца. Эта настройка смещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Используйте [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft), когда требуется переместить весь абзац. Используйте [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent), когда нужно сместить только первую строку.

В следующем примере три абзаца получают одинаковый [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) в 20 пунктов и значения [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) 0, 20 и 40 пунктов. Первые строки начинают с постепенно увеличивающихся смещений, тогда как строки переноса сохраняют одинаковое левое поле:

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

Висячий отступ — это макет абзаца, в котором первая строка начинается левее остальных строк. В Aspose.Slides этот эффект создаётся с помощью свойства [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent). Установите `Indent` в отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) определяет левую позицию тела абзаца, а [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) задаёт позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение `MarginLeft` и отрицательное значение `Indent`.

Это форматирование полезно для библиографий, ссылок, глоссариев и других абзацев, где строки переноса должны выравниваться под телом абзаца, а не под первым символом первой строки.

В следующем примере PHP сочетает значения [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) 40 и 60 пунктов с [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) -20 и -30 пунктов. В каждом абзаце первая строка начинается левее строк переноса; во втором абзаце висячий отступ глубже:

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

### **Установка свойств знака конца абзаца**

Метод [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) управляет форматированием знака конца абзаца. В следующем примере создаётся [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) с [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) 48 пунктов и [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont) Times New Roman. Этот формат присваивается знаку конца второго абзаца, оставляя видимые текстовые фрагменты без изменений:

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

Для правил абзаца, влияющих на автоматический перенос и пунктуацию в конце строк, смотрите [Control Line Breaking](/slides/ru/php-java/text-formatting/#control-line-breaking) и [Control Hanging Punctuation](/slides/ru/php-java/text-formatting/#control-hanging-punctuation).

Используйте [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) для подсчёта строк, занимаемых абзацем после размещения текста, включая автоматический перенос. Это полезно при проверке длины текста и макета в шаблонах презентаций.

Абзац — это один элемент в [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs) и может занимать несколько отрисованных строк. Явный разрыв строки внутри абзаца заставляет перейти на новую строку без создания нового абзаца. Автоматический перенос создаёт строки в зависимости от доступной ширины, не вставляя явные разрывы в текст. Поэтому подсчёт абзацев или символов разрыва строки не даёт количества отрисованных строк.

В следующем примере создаётся текстовая фигура, считается её количество строк, сужается фигура, а затем текст заменяется более короткой строкой. Пример включает включение переноса через [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) и отключение автоподгонки через [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType), чтобы ширина фигуры контролировала перенос без автоматического уменьшения текста или изменения размеров фигуры. Каждое измерение использует [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount). Размеры фигуры указаны в пунктах. В конце пример добавляет ещё один абзац и суммирует количество строк по всей текстовой рамке:

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

С указанным текстом и размерами сужение фигуры увеличивает количество строк, а замена текста короткой строкой уменьшает его. Точные подсчёты могут различаться в зависимости от доступных шрифтов и их подстановки, размера шрифта, полей, отступов, переноса и настроек автоподгонки. При проверке шаблона используйте шрифты и настройки макета, предназначенные для целевой среды.

Одно лишь количество строк не определяет, выходит ли текст за пределы контейнера. Важны доступная высота, высота строк, межабзацные и межстрочные интервалы, а также поведение автоподгонки; даже одна строка может превышать доступную ширину при отключённом переносе.

## **Импорт и экспорт содержимого абзацев**

Используйте HTML для импорта текста в презентацию или экспорта существующих абзацев для использования вне её. В этом разделе также показано, как отрисовывать отдельные абзацы как изображения, включая абзацы в ячейках таблиц.

### **Импорт HTML‑текста в абзацы**

Используйте [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) для преобразования HTML‑разметки в абзацы и фрагменты в текстовой рамке.

Этот пример PHP читает HTML из файла и передаёт разметку в [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml). Он очищает абзац по умолчанию в текстовой рамке, чтобы она содержала только импортированный контент. Прямоугольная фигура оставляет по 10 пунктов отступа со всех сторон слайда:

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

Используйте [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml) для экспорта выбранного диапазона абзацев в HTML. При повторном использовании текста презентации на сайте вы можете захотеть сохранить локальное выделение без переноса шрифта, размера или стилей текстового поля презентации. Установите [TextToHtmlConversionOptions::setTextInheritanceLimit](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit), чтобы контролировать степень следования экспортёра наследованию форматирования.

Скачайте [пример презентации](text-inheritance.pptx) и поместите его в рабочий каталог приложения. На первом слайде находится одна текстовая фигура с текстом «Inherited text; explicit red 18pt». Ввод умышленно использует несколько уровней форматирования:

- Стиль текста по умолчанию презентации задаёт Calibri размером 28 pt.
- Стиль первого уровня текстовой рамки задаёт синий цвет и курсив.
- Абзац явно задаёт полужирный текст.
- Второй фрагмент «explicit red 18pt» явно задаёт красный цвет и размер 18 pt.

Следующий полноценный пример экспортирует те же абзацы три раза. Он передаёт [TextToHtmlConversionOptions](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/) в метод экспорта и пишет каждый результат в отдельный UTF‑8 HTML‑файл:

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

Сгенерированный HTML содержит следующий CSS для первого фрагмента «Inherited text; ». Таблица перечисляет соответствующие объявления; остальные сгенерированные свойства опущены ради ясности.

| Вывод | Соответствующий CSS для первого фрагмента | Внешний вид |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Синий, полужирный, курсивный текст 28 pt в Calibri, если шрифт доступен. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Синий, полужирный, курсивный текст; шрифт и размер задаются страницей или браузером. |
| `ParagraphOnly.html` | `font-weight:bold` | Полужирный текст; шрифт, размер, цвет и курсив задаются страницей или браузером. |

Второй фрагмент сохраняет `color:#ff0000`, `font-size:18pt` и `font-weight:bold` во всех трёх выводах. Он также сохраняет курсив в `All` и `TextBox`, но не в `ParagraphOnly`. Ограничение наследования поэтому не удаляет явно заданное форматирование абзаца или фрагмента.

Откройте файлы в одном браузере для сравнения. В двух ограниченных режимах опущенные свойства CSS берутся из стилей целевой страницы или из стандартных стилей браузера, поэтому итоговый вид зависит от места использования HTML.

### **Отрисовка абзаца как изображения**

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) отрисовывает отдельный абзац напрямую и возвращает [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/). Сохраните результат в файл или поток с помощью [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Нет необходимости отрисовывать содержащую фигуру или вручную обрезать bitmap.

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) может вернуть `null`, если абзац не найден в родительской коллекции, не имеет допустимых границ отрисовки или не может быть отрисован. Проверьте результат перед сохранением и освободите полученное изображение после использования.

#### **Отрисовка абзаца в масштабе по умолчанию**

Пример использует презентацию с одним слайдом, у которого первая фигура — текстовое поле с тремя абзацами.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

Следующий пример выбирает второй абзац с индексом 1 и вызывает [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) без параметров масштаба. Он проверяет, что фигура содержит требуемый абзац и что отрисовка вернула изображение, прежде чем вызвать [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) для сохранения в PNG. Блок `finally` освобождает изображение после использования.

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

Используйте перегрузку [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage), принимающую параметры `$scaleX` и `$scaleY` для задания горизонтального и вертикального коэффициентов масштаба. В следующем примере создаётся таблица, абзац в её первой ячейке отрисовывается вдвое шире и выше своего обычного размера, и результат сохраняется как PNG‑изображение.

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

Коэффициент масштаба `1` сохраняет размер по умолчанию. Например, `2` для обеих осей даёт изображение, ширина и высота которого примерно вдвое превышают обычные размеры, а количество пикселей — вчетыре раза. Большие коэффициенты обычно дают более чёткий текст для увеличения или вывода в высоком разрешении, но также увеличивают потребление памяти и размер файла. Коэффициенты ниже `1` дают более мелкие изображения с меньшей детализацией. Используйте одинаковые коэффициенты, чтобы сохранить пропорции абзаца; разные горизонтальный и вертикальный коэффициенты растягивают вывод независимо.

Отрисовка всей фигуры с помощью [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) остаётся полезной, когда требуется включить заливку, границу или другой визуальный контекст фигуры. Для изображения только абзаца используйте [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Можно ли полностью отключить перенос строк внутри текстовой рамки?**

Да. Установите [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText), чтобы отключить перенос, и строки не будут разрываться у краёв рамки.

**Как получить точные границы конкретного абзаца на слайде?**

Используйте [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) для получения прямоугольника, ограничивающего абзац. [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect) предоставляет границы отдельного фрагмента.

**Где контролируется выравнивание абзаца (по левому, правому краю, по центру или по ширине)?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) — это настройка уровня абзаца и применяется ко всему абзацу независимо от форматирования отдельных фрагментов.

Чтобы вертикально выровнять фрагменты разного размера шрифта в одной строке, смотрите [Align Fonts Within a Line](/slides/ru/php-java/text-formatting/#align-fonts-within-a-line).

**Можно ли задать язык проверки орфографии только для части абзаца?**

Да. Установите [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) для отдельных фрагментов, позволяя одному абзацу содержать текст на нескольких языках.