---
title: Управление параграфами текста PowerPoint в PHP
linktitle: Управление параграфом
type: docs
weight: 40
url: /ru/php-java/manage-paragraph/
keywords:
- добавить текст
- добавить параграф
- управлять текстом
- управлять параграфом
- управлять маркером
- отступ параграфа
- висячий отступ
- маркер параграфа
- нумерованный список
- маркированный список
- свойства параграфа
- импорт HTML
- текст в HTML
- параграф в HTML
- параграф в изображение
- текст в изображение
- экспортировать параграф
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Мастерское форматирование параграфов с Aspose.Slides для PHP через Java — оптимизировать выравнивание, интервалы и стиль в презентациях PPT, PPTX и ODP."
---

Aspose.Slides предоставляет все необходимые классы для работы с текстом PowerPoint, абзацами и фрагментами.

* Aspose.Slides предоставляет класс [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) для добавления объектов, представляющих абзац. Объект `TextFame` может содержать один или несколько абзацев (каждый абзац создаётся с помощью символа возврата каретки).
* Aspose.Slides предоставляет класс [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) для добавления объектов, представляющих фрагменты. Объект `Paragraph` может содержать один или несколько фрагментов (коллекцию объектов `Portion`).
* Aspose.Slides предоставляет класс [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) для добавления объектов, представляющих текст и его свойства форматирования.

Объект `Paragraph` способен обрабатывать текст с различными свойствами форматирования через вложенные объекты `Portion`.

## **Добавление нескольких абзацев, содержащих несколько фрагментов**

Эти шаги показывают, как добавить текстовый фрейм, содержащий 3 абзаца, каждый из которых содержит 3 фрагмента:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
4. Получите объект ITextFrame, связанный с [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
5. Создайте два объекта [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) и добавьте их в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
6. Создайте три объекта [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) для каждого нового `Paragraph` (два объекта Portion для абзаца по умолчанию) и добавьте каждый объект `Portion` в соответствующую коллекцию фрагментов каждого `Paragraph`.
7. Установите текст для каждого фрагмента.
8. Примените желаемые свойства форматирования к каждому фрагменту, используя свойства форматирования, доступные в объекте `Portion`.
9. Сохраните изменённую презентацию.

Этот PHP‑код реализует перечисленные шаги по добавлению абзацев с фрагментами:
```php
# Создать экземпляр класса Presentation, представляющего файл PPTX
$pres = new Presentation();
try {
    # Доступ к первому слайду
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Получить TextFrame AutoShape
    $tf = $ashp->getTextFrame();
    # Создать Paragraph и Portion с разными форматами текста
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

Маркированные списки помогают быстро и эффективно структурировать и представлять информацию. Абзацы с маркерами всегда проще читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) автоконтурного объекта.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый объект абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. Установите для абзаца тип маркера `Type` как `Symbol` и задайте символ маркера.
8. Установите текст абзаца.
9. Установите отступ `Indent` для маркера абзаца.
10. Задайте цвет маркера.
11. Задайте высоту маркера.
12. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
13. Добавьте второй абзац и повторите процесс, описанный в пунктах 7‑13.
14. Сохраните презентацию.

Этот PHP‑код показывает, как добавить маркер к абзацу:
```php
# Создает экземпляр класса Presentation, представляющего файл PPTX
$pres = new Presentation();
try {
    # Получает первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавляет и получает AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Получает текстовый фрейм автофигуры
    $txtFrm = $aShp->getTextFrame();
    # Удаляет абзац по умолчанию
    $txtFrm->getParagraphs()->removeAt(0);
    # Создает абзац
    $para = new Paragraph();
    # Устанавливает стиль маркера абзаца и символ
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
    # Добавляет абзац в текстовый фрейм
    $txtFrm->getParagraphs()->add($para);
    # Создает второй абзац
    $para2 = new Paragraph();
    # Устанавливает тип маркера абзаца и стиль
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
    # Добавляет абзац в текстовый фрейм
    $txtFrm->getParagraphs()->add($para2);
    # Сохраняет измененную презентацию
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Управление маркерами‑изображениями**

Маркированные списки помогают быстро и эффективно структурировать и представлять информацию. Абзацы с изображениями легко читаются и понимаются.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) автоконтурного объекта.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый объект абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. Загрузите изображение в [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/).
8. Установите тип маркера как [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture) и задайте изображение.
9. Установите текст абзаца.
10. Установите отступ `Indent` для маркера.
11. Задайте цвет маркера.
12. Задайте высоту маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
14. Добавьте второй абзац и повторите процесс, основанный на предыдущих шагах.
15. Сохраните изменённую презентацию.

Этот PHP‑код показывает, как добавить и управлять маркерами‑изображениями:
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
    # Добавляет и получает AutoShape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Получает текстовый фрейм автофигуры
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
    # Добавляет абзац в текстовый фрейм
    $textFrame->getParagraphs()->add($paragraph);
    # Записывает презентацию в файл PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Записывает презентацию в файл PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


## **Управление многоуровневыми маркерами**

Маркированные списки помогают быстро и эффективно структурировать и представлять информацию. Многоуровневые маркеры легко читаются и понимаются.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на новый слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) автоконтурного объекта.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый объект абзаца через класс [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) и задайте глубину 0.
7. Создайте второй объект абзаца через класс `Paragraph` и задайте глубину 1.
8. Создайте третий объект абзаца через класс `Paragraph` и задайте глубину 2.
9. Создайте четвёртый объект абзаца через класс `Paragraph` и задайте глубину 3.
10. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
11. Сохраните изменённую презентацию.

Этот PHP‑код показывает, как добавить и управлять многоуровневыми маркерами:
```php
# Создает экземпляр класса Presentation, представляющего файл PPTX
$pres = new Presentation();
try {
    # Получает первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавляет и получает AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Получает текстовый фрейм созданной AutoShape
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
    # Записывает презентацию в файл PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Управление абзацем с пользовательским нумерованным списком**

Класс [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) предоставляет метод [setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) и другие, позволяющие управлять абзацами с пользовательской нумерацией или форматированием.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите слайд, содержащий абзац.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) автоконтурного объекта.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый объект абзаца через класс [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) и установите [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) в значение 2.
7. Создайте второй объект абзаца через класс `Paragraph` и установите `NumberedBulletStartWith` в значение 3.
8. Создайте третий объект абзаца через класс `Paragraph` и установите `NumberedBulletStartWith` в значение 7.
9. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
10. Сохраните изменённую презентацию.

Этот PHP‑код показывает, как добавить и управлять абзацами с пользовательской нумерацией или форматированием:
```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Получает текстовый фрейм созданной автофигуры
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


## **Установка отступа абзаца**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на нужный слайд по его индексу.
1. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) с тремя абзацами в прямоугольный автоконтур.
1. Спрячьте линии прямоугольника.
1. Установите отступ для каждого [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) через его свойство `BulletOffset`.
1. Запишите изменённую презентацию в файл PPT.

Этот PHP‑код показывает, как задать отступ абзаца:
```php
# Создает экземпляр класса Presentation
$pres = new Presentation();
try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавляет прямоугольную форму
    $rect = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 150);
    # Добавляет TextFrame к прямоугольнику
    $tf = $rect->addTextFrame("This is first line \rThis is second line \rThis is third line");
    # Устанавливает автоподгонку текста к форме
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Скрывает линии прямоугольника
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # Получает первый абзац в TextFrame и задает его отступ
    $para1 = $tf->getParagraphs()->get_Item(0);
    # Устанавливает стиль маркера абзаца и символ
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para1->getParagraphFormat()->setDepth(2);
    $para1->getParagraphFormat()->setIndent(30);
    # Получает второй абзац в TextFrame и задает его отступ
    $para2 = $tf->getParagraphs()->get_Item(1);
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar(8226);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para2->getParagraphFormat()->setDepth(2);
    $para2->getParagraphFormat()->setIndent(40);
    # Получает третий абзац в TextFrame и задает его отступ
    $para3 = $tf->getParagraphs()->get_Item(2);
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para3->getParagraphFormat()->setDepth(2);
    $para3->getParagraphFormat()->setIndent(50);
    # Сохраняет презентацию на диск
    $pres->save("InOutDent_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Установка висячего отступа для абзаца**

Этот PHP‑код показывает, как задать висячий отступ для абзаца:
```php
$pres = new Presentation();
try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 550, 150);
    $para1 = new Paragraph();
    $para1->setText("Example");
    $para2 = new Paragraph();
    $para2->setText("Set Hanging Indent for Paragraph");
    $para3 = new Paragraph();
    $para3->setText("This code shows you how to set the hanging indent for a paragraph: ");
    $para2->getParagraphFormat()->setMarginLeft(10.0);
    $para3->getParagraphFormat()->setMarginLeft(20.0);
    $autoShape->getTextFrame()->getParagraphs()->add($para1);
    $autoShape->getTextFrame()->getParagraphs()->add($para2);
    $autoShape->getTextFrame()->getParagraphs()->add($para3);
    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Управление свойствами конца абзаца**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд, содержащий абзац, по его позиции.
1. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) с двумя абзацами в прямоугольник.
1. Установите высоту шрифта и тип шрифта для абзацев.
1. Установите свойства End для абзацев.
1. Запишите изменённую презентацию в файл PPTX.

Этот PHP‑код показывает, как задать свойства End для абзацев в PowerPoint:
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

Aspose.Slides предоставляет расширенную поддержку импорта HTML‑текста в абзацы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
4. Добавьте и получите [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) автоконтурного объекта.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Прочитайте исходный HTML‑файл с помощью TextReader.
7. Создайте первый объект абзаца через класс [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
8. Добавьте содержимое HTML‑файла из прочитанного TextReader в [ParagraphCollection](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/) TextFrame.
9. Сохраните изменённую презентацию.

Этот PHP‑код реализует шаги по импорту HTML‑текстов в абзацы:
```php
# Создать пустой экземпляр презентации
$pres = new Presentation();
try {
    # Получить первый слайд презентации по умолчанию
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape для размещения HTML‑содержимого
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Добавить текстовый фрейм к форме
    $ashape->addTextFrame("");
    # Очистить все абзацы в добавленном текстовом фрейме
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Загрузить HTML‑файл с помощью StreamReader
    $tr = new StreamReader("file.html");
    # Добавить текст из HTML‑потока в текстовый фрейм
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Сохранить презентацию
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Экспорт текста абзаца в HTML**

Aspose.Slides предоставляет расширенную поддержку экспорта текстов (содержащихся в абзацах) в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и загрузите необходимую презентацию.
2. Получите ссылку на нужный слайд по его индексу.
3. Получите форму, содержащую текст, который будет экспортирован в HTML.
4. Получите [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) формы.
5. Создайте экземпляр `StreamWriter` и добавьте новый HTML‑файл.
6. Укажите начальный индекс для `StreamWriter` и экспортируйте выбранные абзацы.

Этот PHP‑код показывает, как экспортировать тексты абзацев PowerPoint в HTML:
```php
# Загрузить файл презентации
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Получить первый слайд презентации по умолчанию
    $slide = $pres->getSlides()->get_Item(0);
    # Желаемый индекс
    $index = 0;
    # Доступ к добавленной форме
    $ashape = $slide->getShapes()->get_Item($index);
    # Создание выходного HTML‑файла
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Извлечение первого абзаца в виде HTML
    # Запись данных абзацев в HTML с указанием начального индекса абзаца и общего количества копируемых абзацев
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

В этом разделе рассмотрены два примера, демонстрирующие, как сохранить текстовый абзац, представленный классом [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/), в виде изображения. Оба примера включают получение изображения формы, содержащей абзац, с помощью методов `getImage` класса [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), вычисление границ абзаца внутри формы и экспорт его как растрового изображения. Такие подходы позволяют извлекать отдельные части текста из презентаций PowerPoint и сохранять их как отдельные изображения, что может быть полезно в различных сценариях.

Предположим, что у нас есть файл презентации sample.pptx с одним слайдом, где первая форма — текстовое поле, содержащее три абзаца.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Пример 1**

В этом примере мы получаем второй абзац в виде изображения. Для этого извлекаем изображение формы с первого слайда презентации, затем вычисляем границы второго абзаца в текстовом фрейме формы. После этого абзац перерисовывается на новом растровом изображении, которое сохраняется в формате PNG. Такой метод особенно полезен, когда необходимо сохранить конкретный абзац как отдельное изображение, сохраняя точные размеры и форматирование текста.
```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Сохранить форму в памяти как растровое изображение.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Создать растровое изображение формы из памяти.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Вычислить границы второго абзаца.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Вычислить координаты и размер выходного изображения (минимальный размер - 1x1 пиксель).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Обрезать растровое изображение формы, чтобы получить только растровое изображение абзаца.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


Результат:

![The paragraph image](paragraph_to_image_output.png)

**Пример 2**

В этом примере мы расширяем предыдущий подход, добавляя коэффициенты масштабирования к изображению абзаца. Форма извлекается из презентации и сохраняется как изображение с коэффициентом масштабирования `2`. Это обеспечивает более высокое разрешение при экспорте абзаца. Затем границы абзаца вычисляются с учётом масштаба. Масштабирование особенно полезно, когда требуется более детальное изображение, например, для печатных материалов высокого качества.
```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Сохранить форму в памяти как растровое изображение с масштабированием.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Создать растровое изображение формы из памяти.
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

    // Обрезать растровое изображение формы, чтобы получить только растровое изображение абзаца.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


## **FAQ**

**Можно ли полностью отключить перенос строк внутри текстового фрейма?**

Да. Используйте настройку переноса текста у фрейма ([setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/)), чтобы отключить перенос, и строки не будут разрываться у краёв фрейма.

**Как получить точные границы конкретного абзаца на слайде?**

Вы можете получить прямоугольник ограничивающий абзац (и даже отдельный фрагмент), чтобы узнать его точное положение и размер на слайде.

**Где контролируется выравнивание абзаца (left/right/center/justify)?**

[Alignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) — это настройка уровня абзаца в [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/); она применяется к всему абзацу независимо от форматирования отдельных фрагментов.

**Можно ли задать язык проверки правописания только для части абзаца (например, одного слова)?**

Да. Язык задаётся на уровне фрагмента ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId)), поэтому в одном абзаце могут одновременно использоваться несколько языков.