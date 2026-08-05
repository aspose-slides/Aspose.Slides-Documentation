---
title: Управление абзацами текста PowerPoint в PHP
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
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
  - OpenDocument
  - презентация
  - PHP
  - Aspose.Slides
description: "Освойте форматирование абзацев с Aspose.Slides для PHP через Java — оптимизируйте выравнивание, интервал и стиль в презентациях PPT, PPTX и ODP."
---
## **Введение**

Aspose.Slides предоставляет все классы, необходимые для работы с текстами, абзацами и частями PowerPoint.

* Aspose.Slides предоставляет класс [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/), позволяющий добавлять объекты, представляющие абзац. Объект `TextFame` может содержать один или несколько абзацев (каждый абзац создаётся через перевод строки).
* Aspose.Slides предоставляет класс [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/), позволяющий добавлять объекты, представляющие части. Объект `Paragraph` может иметь одну или несколько частей (коллекция объектов части).
* Aspose.Slides предоставляет класс [Portion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/), позволяющий добавлять объекты, представляющие тексты и их свойства форматирования.

Объект `Paragraph` способен обрабатывать тексты с различными свойствами форматирования через вложенные объекты `Portion`.

## **Добавление нескольких абзацев, содержащих несколько частей**

Эти шаги показывают, как добавить текстовый кадр, содержащий 3 абзаца, каждый из которых содержит 3 части:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
4. Получите ITextFrame, связанный с [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/).
5. Создайте два объекта [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/) и добавьте их в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/).
6. Создайте три объекта [Portion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/) для каждого нового `Paragraph` (по два объекта Portion для абзаца по умолчанию) и добавьте каждый объект `Portion` в коллекцию частей соответствующего `Paragraph`.
7. Установите текст для каждой части.
8. Примените желаемые свойства форматирования к каждой части, используя свойства форматирования, доступные в объекте `Portion`.
9. Сохраните изменённую презентацию.

Этот PHP‑код реализует указанные шаги по добавлению абзацев, содержащих части:

```php
# Создать экземпляр класса Presentation, представляющий файл PPTX
$pres = new Presentation();
try {
    # Получение первого слайда
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Доступ к TextFrame AutoShape
    $tf = $ashp->getTextFrame();
    # Создать абзацы и части с различными форматами текста
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # Сохранить PPTX на диск
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Управление маркерами абзацев**

Маркированные списки помогают быстро и эффективно организовать и представить информацию. Маркированные абзацы всегда легче читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) автосущности.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/).
7. Установите тип маркера `Type` для абзаца в `Symbol` и задайте символ маркера.
8. Установите `Text` абзаца.
9. Установите `Indent` абзаца для маркера.
10. Задайте цвет маркера.
11. Задайте высоту маркера.
12. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
13. Добавьте второй абзац и повторите процесс, описанный в пунктах 7–13.
14. Сохраните презентацию.

Этот PHP‑код показывает, как добавить маркер к абзацу:

```php
# Создает экземпляр класса Presentation, представляющего файл PPTX
$pres = new Presentation();
try {
    # Получает первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавляет и получает доступ к AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Получает текстовый кадр автофигуры
    $txtFrm = $aShp->getTextFrame();
    # Удаляет абзац по умолчанию
    $txtFrm->getParagraphs()->removeAt(0);
    # Создает абзац
    $para = new Paragraph();
    # Устанавливает стиль и символ маркера абзаца
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Устанавливает текст абзаца
    $para->setText("Welcome to Aspose.Slides");
    # Устанавливает отступ маркера
    $para->getParagraphFormat()->setIndent(25);
    # Устанавливает цвет маркера
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// установить IsBulletHardColor в true, чтобы использовать собственный цвет маркера

    # Устанавливает высоту маркера
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Добавляет абзац в текстовый кадр
    $txtFrm->getParagraphs()->add($para);
    # Создает второй абзац
    $para2 = new Paragraph();
    # Устанавливает тип и стиль маркера абзаца
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Добавляет текст абзаца
    $para2->setText("This is numbered bullet");
    # Устанавливает отступ маркера
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// установить IsBulletHardColor в true, чтобы использовать собственный цвет маркера

    # Устанавливает высоту маркера
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Добавляет абзац в текстовый кадр
    $txtFrm->getParagraphs()->add($para2);
    # Сохраняет измененную презентацию
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Управление маркерами‑картинками**

Маркированные списки помогают быстро и эффективно организовать и представить информацию. Абзацы с картинками легко читаются и понимаются.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) автосущности.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/).
7. Загрузите изображение в [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/).
8. Установите тип маркера в [Picture](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bullettype/#Picture) и задайте изображение.
9. Установите `Text` абзаца.
10. Установите `Indent` абзаца для маркера.
11. Задайте цвет маркера.
12. Задайте высоту маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
14. Добавьте второй абзац и повторите процесс, основанный на предыдущих шагах.
15. Сохраните изменённую презентацию.

Этот PHP‑код показывает, как добавить и управлять маркерами‑картинками:

```php
# Создает экземпляр класса Presentation, представляющего файл PPTX
$presentation = new Presentation();
try {
    # Получает первый слайд
    $slide = $presentation->getSlides()->get_Item(0);
    # Создает изображение для маркеров
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Добавляет и получает доступ к AutoShape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Получает текстовый кадр автофигуры
    $textFrame = $autoShape->getTextFrame();
    # Удаляет абзац по умолчанию
    $textFrame->getParagraphs()->removeAt(0);
    # Создает новый абзац
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Устанавливает стиль маркера абзаца и изображение
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Устанавливает высоту маркера
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Добавляет абзац в текстовый кадр
    $textFrame->getParagraphs()->add($paragraph);
    # Сохраняет презентацию в файл PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Сохраняет презентацию в файл PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Управление многоуровневыми маркерами**

Маркированные списки помогают быстро и эффективно организовать и представить информацию. Многоуровневые маркеры легко читаются и понимаются.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на новый слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) автосущности.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый абзац через класс [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/) и задайте глубину 0.
7. Создайте второй абзац через класс `Paragraph` и задайте глубину 1.
8. Создайте третий абзац через класс `Paragraph` и задайте глубину 2.
9. Создайте четвёртый абзац через класс `Paragraph` и задайте глубину 3.
10. Добавьте новые абзцы в коллекцию абзацев `TextFrame`.
11. Сохраните изменённую презентацию.

Этот PHP‑код показывает, как добавить и управлять многоуровневыми маркерами:

```php
# Создает экземпляр класса Presentation, представляющего файл PPTX
$pres = new Presentation();
try {
    # Получает первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавляет и получает доступ к AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Получает текстовый кадр созданной автофигуры
    $text = $aShp->addTextFrame("");
    # Очищает абзац по умолчанию
    $text->getParagraphs()->clear();
    # Добавляет первый абзац
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Устанавливает уровень маркера
    $para1->getParagraphFormat()->setDepth(0);
    # Добавляет второй абзац
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Устанавливает уровень маркера
    $para2->getParagraphFormat()->setDepth(1);
    # Добавляет третий абзац
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Устанавливает уровень маркера
    $para3->getParagraphFormat()->setDepth(2);
    # Добавляет четвертый абзац
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Устанавливает уровень маркера
    $para4->getParagraphFormat()->setDepth(3);
    # Добавляет абзацы в коллекцию
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # Сохраняет презентацию в файл PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Управление абзацем с пользовательским нумерованным списком**

Класс [BulletFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/) предоставляет метод [setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) и другие, позволяющие управлять абзацами с пользовательской нумерацией или форматированием.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите слайд, содержащий абзац.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) автосущности.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый абзац через класс [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/) и задайте [NumberedBulletStartWith](https://reference.aspose.com/slides/ru/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) равным 2.
7. Создайте второй абзац через класс `Paragraph` и задайте `NumberedBulletStartWith` равным 3.
8. Создайте третий абзац через класс `Paragraph` и задайте `NumberedBulletStartWith` равным 7.
9. Добавьте новые абзцы в коллекцию абзацев `TextFrame`.
10. Сохраните изменённую презентацию.

Этот PHP‑код показывает, как добавить и управлять абзацами с пользовательской нумерацией или форматированием:

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Получает текстовый кадр созданной автофигуры
    $textFrame = $shape->getTextFrame();
    # Удаляет существующий абзац по умолчанию
    $textFrame->getParagraphs()->removeAt(0);
    # Первый список
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Установка отступа первой строки для абзаца**

Используйте метод [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/setindent/) для управления отступом первой строки абзаца. Этот метод смещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Используйте [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/setmarginleft()), когда необходимо сместить весь абзац. Используйте [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/setindent()), когда нужно сместить только первую строку.

В примере ниже создаются несколько абзацев и задаются разные значения отступа, чтобы продемонстрировать влияние отступа первой строки на макет абзаца.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите целевой слайд.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
4. Добавьте пустой [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) к фигурe и удалите абзац по умолчанию.
5. Создайте несколько абзацев и задайте им разные значения [Indent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/setindent/).
6. Добавьте абзацы в текстовый кадр.
7. Сохраните изменённую презентацию.

Этот код показывает, как установить отступ абзаца:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
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

## **Установка висячего отступа для абзаца**

Висячий отступ — это макет абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides этот эффект достигается методом [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/setindent()). Установите отрицательное значение отступа, чтобы первая строка сместилась влево относительно тела абзаца.

На практике [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/setmarginleft()) определяет левую позицию тела абзаца, а [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/setindent()) задаёт позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение `MarginLeft` и отрицательное значение `Indent`.

Этот тип форматирования полезен для библиографий, ссылок, глоссариев и других абзацев, где перенесённые строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите целевой слайд.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
4. Добавьте пустой [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) к фигурe и удалите абзац по умолчанию.
5. Создайте абзацы и задайте каждому положительное значение [MarginLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/setmarginleft/).
6. Задайте отрицательное значение [Indent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/setindent/) для создания эффекта висячего отступа.
7. Добавьте абзацы в текстовый кадр.
8. Сохраните изменённую презентацию.

Этот код показывает, как установить висячий отступ для абзаца:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
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

## **Управление свойствами End параграфа**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, содержащий абзац, по его позиции.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
4. Добавьте [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) с двумя абзацами в прямоугольник.
5. Установите высоту шрифта и тип шрифта для абзацев.
6. Установите свойства End для абзацев.
7. Сохраните изменённую презентацию в файл PPTX.

Этот PHP‑код показывает, как установить свойства End для абзацев в PowerPoint:

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Импорт HTML‑текста в абзацы**

Aspose.Slides расширенно поддерживает импорт HTML‑текста в абзацы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
4. Добавьте и получите [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) автосущности.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Прочитайте исходный HTML‑файл в TextReader.
7. Создайте первый абзац через класс [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/).
8. Добавьте содержимое HTML‑файла из прочитанного TextReader в [ParagraphCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphcollection/) TextFrame.
9. Сохраните изменённую презентацию.

Этот PHP‑код реализует шаги по импорту HTML‑текстов в абзацы:

```php
# Создать пустой экземпляр презентации
$pres = new Presentation();
try {
    # Получить первый слайд презентации по умолчанию
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление AutoShape для размещения HTML‑содержимого
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Добавление текстового кадра к фигуре
    $ashape->addTextFrame("");
    # Очистка всех абзацев в добавленном текстовом кадре
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Загрузка HTML‑файла с помощью StreamReader
    $tr = new StreamReader("file.html");
    # Добавление текста из HTML‑потока в текстовый кадр
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Сохранение презентации
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Экспорт текста абзаца в HTML**

Aspose.Slides расширенно поддерживает экспорт текстов (содержащихся в абзацах) в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и загрузите нужную презентацию.
2. Получите ссылку на нужный слайд по его индексу.
3. Получите форму, содержащую текст, который будет экспортирован в HTML.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) формы.
5. Создайте объект `StreamWriter` и откройте новый HTML‑файл.
6. Установите начальный индекс для StreamWriter и экспортируйте выбранные абзацы.

Этот PHP‑код показывает, как экспортировать тексты абзацев PowerPoint в HTML:

```php
# Загрузить файл презентации
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Получить первый слайд презентации по умолчанию
    $slide = $pres->getSlides()->get_Item(0);
    # Требуемый индекс
    $index = 0;
    # Доступ к добавленной фигуре
    $ashape = $slide->getShapes()->get_Item($index);
    # Создание выходного HTML‑файла
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Извлечение первого абзаца в виде HTML
    # Запись данных абзацев в HTML, указав начальный индекс абзаца и общее количество копируемых абзацев
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Сохранение абзаца как изображения**

В этом разделе мы рассмотрим два примера, демонстрирующие, как сохранить текстовый абзац, представленный классом [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/), в виде изображения. Оба примера включают получение изображения формы, содержащей абзац, с помощью методов `getImage` класса [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/), вычисление границ абзаца внутри формы и экспорт его как растрового изображения. Эти подходы позволяют извлекать отдельные части текста из презентаций PowerPoint и сохранять их как отдельные изображения, что может быть полезно в различных сценариях.

Предположим, у нас есть файл презентации sample.pptx с одним слайдом, где первая форма — это текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

**Пример 1**

В этом примере мы получаем второй абзац в виде изображения. Для этого извлекаем изображение формы с первого слайда презентации, затем вычисляем границы второго абзаца в текстовом кадре формы. После этого абзац перерисовывается на новом растровом изображении, которое сохраняется в формате PNG. Этот метод особенно полезен, когда необходимо сохранить конкретный абзац как отдельное изображение, сохранив точные размеры и форматирование текста.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Сохранить форму в памяти как растр.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Создать растр формы из памяти.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Вычислить границы второго абзаца.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Вычислить координаты и размер выходного изображения (минимальный размер — 1×1 пиксель).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Обрезать растр формы, чтобы получить только растр абзаца.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Результат:

![Изображение абзаца](paragraph_to_image_output.png)

**Пример 2**

Во втором примере мы расширяем предыдущий подход, добавляя коэффициенты масштабирования к изображению абзаца. Форма извлекается из презентации и сохраняется как изображение с коэффициентом масштабирования `2`. Это обеспечивает более высокое разрешение при экспорте абзаца. Затем границы абзаца рассчитываются с учётом масштаба. Масштабирование может быть особенно полезным, когда требуется более детализированное изображение, например, для печатных материалов высокого качества.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Сохранить форму в памяти как растр с масштабированием.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Создать растр формы из памяти.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Вычислить границы второго абзаца.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Вычислить координаты и размер выходного изображения (минимальный размер - 1x1 пиксель).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Обрезать растр формы, чтобы получить только растр абзаца.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Можно ли полностью отключить перенос строк внутри текстового кадра?**

Да. Используйте настройку обтекания текстового кадра ([setWrapText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/setwraptext/)), чтобы отключить перенос; строки не будут разрываться у краёв кадра.

**Как получить точные границы конкретного абзаца на слайде?**

Можно получить прямоугольник ограничивающий абзац (и даже отдельную часть), чтобы узнать его точное положение и размер на слайде.

**Где управляется выравнивание абзаца (по левому/правому/центру/по ширине)?**

[Alignment](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/setalignment/) — это настройка уровня абзаца в [ParagraphFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/); она применяется ко всему абзацу независимо от индивидуального форматирования частей.

**Можно ли задать язык проверки правописания только для части абзаца (например, одного слова)?**

Да. Язык задаётся на уровне части ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setLanguageId)), поэтому в одном абзаце могут сосуществовать несколько языков.