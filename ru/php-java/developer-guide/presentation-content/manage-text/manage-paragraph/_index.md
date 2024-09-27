---
title: Управление абзацами PowerPoint
type: docs
weight: 40
url: /ru/php-java/manage-paragraph/
keywords: "Добавить абзац PowerPoint, Управлять абзацами, Отступ абзаца, Свойства абзаца, HTML текст, Экспорт текста абзаца, Презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Создайте и управляйте абзацами, текстом, отступами и свойствами в презентациях PowerPoint"
---

Aspose.Slides предоставляет все интерфейсы и классы, необходимые для работы с текстами, абзацами и частями в PowerPoint.

* Aspose.Slides предоставляет интерфейс [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/), который позволяет вам добавлять объекты, представляющие абзац. Объект `ITextFrame` может содержать один или несколько абзацев (каждый абзац создается с помощью переноса строки).
* Aspose.Slides предоставляет интерфейс [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/), который позволяет вам добавлять объекты, представляющие части. Объект `IParagraph` может содержать один или несколько частей (коллекция объектов iPortions).
* Aspose.Slides предоставляет интерфейс [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/), который позволяет вам добавлять объекты, представляющие тексты и их свойства форматирования.

Объект `IParagraph` способен обрабатывать тексты с различными форматами свойств через свои подлежащие объекты `IPortion`.

## **Добавление нескольких абзацев, содержащих несколько частей**

Эти шаги показывают, как добавить текстовый фрейм, содержащий 3 абзаца, каждый из которых содержит 3 части:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте прямоугольник [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) на слайд.
4. Получите ITextFrame, связанный с [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/).
5. Создайте два объекта [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) и добавьте их в коллекцию `IParagraphs` [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/).
6. Создайте три объекта [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) для каждого нового `IParagraph` (два объекта Portion для абзаца по умолчанию) и добавьте каждый объект `IPortion` в коллекцию IPortion каждого `IParagraph`.
7. Установите текст для каждой части.
8. Примените свои предпочтительные функции форматирования к каждой части, используя свойства форматирования, предоставленные объектом `IPortion`.
9. Сохраните измененную презентацию.

Этот код PHP является реализацией шагов для добавления абзацев, содержащих части:

```php
  # Создайте экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получение первого слайда
    $slide = $pres->getSlides()->get_Item(0);
    # Добавьте AutoShape прямоугольной формы
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Получите TextFrame AutoShape
    $tf = $ashp->getTextFrame();
    # Создайте абзацы и части с различными форматами текста
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
    # Запишите PPTX на диск
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Управление маркерами абзацев**

Маркированные списки помогают вам организовать и быстро представить информацию. Абзацы с маркерами всегда легче читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте экземпляр первого абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. Установите тип маркера абзаца на `Symbol` и задайте символ маркера.
8. Установите текст абзаца.
9. Установите отступ абзаца для маркера.
10. Установите цвет для маркера.
11. Установите высоту маркера.
12. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
13. Добавьте второй абзац и повторите процесс, описанный в шагах 7–13.
14. Сохраните презентацию.

Этот код PHP показывает, как добавить маркер абзаца:

```php
  # Создайте экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получение первого слайда
    $slide = $pres->getSlides()->get_Item(0);
    # Добавляем и получаем автофигуру
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Получаем текстовый фрейм автофигуры
    $txtFrm = $aShp->getTextFrame();
    # Удаляем абзац по умолчанию
    $txtFrm->getParagraphs()->removeAt(0);
    # Создаем абзац
    $para = new Paragraph();
    # Устанавливаем стиль и символ маркера абзаца
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Устанавливаем текст абзаца
    $para->setText("Добро пожаловать в Aspose.Slides");
    # Устанавливаем отступ маркера
    $para->getParagraphFormat()->setIndent(25);
    # Устанавливаем цвет маркера
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True); // установите IsBulletHardColor в true, чтобы использовать свой цвет маркера

    # Устанавливаем высоту маркера
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Добавляем абзац в текстовый фрейм
    $txtFrm->getParagraphs()->add($para);
    # Создаем второй абзац
    $para2 = new Paragraph();
    # Устанавливаем тип и стиль маркера абзаца
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Добавляем текст абзаца
    $para2->setText("Это нумерованный маркер");
    # Устанавливаем отступ маркера
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True); // установите IsBulletHardColor в true, чтобы использовать свой цвет маркера

    # Устанавливаем высоту маркера
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Добавляем абзац в текстовый фрейм
    $txtFrm->getParagraphs()->add($para2);
    # Сохраняем модифицированную презентацию
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Управление картинными маркерами**

Маркированные списки помогают вам организовать и быстро представить информацию. Абзацы с картинками легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте экземпляр первого абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. Загрузите изображение в [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/).
8. Установите тип маркера на [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/) и установите изображение.
9. Установите текст абзаца.
10. Установите отступ абзаца для маркера.
11. Установите цвет для маркера.
12. Установите высоту для маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
14. Добавьте второй абзац и повторите процесс, основываясь на предыдущих шагах.
15. Сохраните модифицированную презентацию.

Этот код PHP показывает, как добавить и управлять картинными маркерами:

```php
  # Создайте экземпляр класса Presentation, представляющего файл PPTX
  $presentation = new Presentation();
  try {
    # Получение первого слайда
    $slide = $presentation->getSlides()->get_Item(0);
    # Создание изображения для маркеров
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
      $picture = $presentation->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Добавляем и получаем автофигуру
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Получаем текстовый фрейм автофигуры
    $textFrame = $autoShape->getTextFrame();
    # Удаляем абзац по умолчанию
    $textFrame->getParagraphs()->removeAt(0);
    # Создаем новый абзац
    $paragraph = new Paragraph();
    $paragraph->setText("Добро пожаловать в Aspose.Slides");
    # Устанавливаем стиль маркера абзаца и изображение
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Устанавливаем высоту маркера
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Добавляем абзац в текстовый фрейм
    $textFrame->getParagraphs()->add($paragraph);
    # Записываем презентацию как файл PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Записываем презентацию как файл PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Управление многоуровневыми маркерами**

Маркированные списки помогают вам быстро организовать и представить информацию. Многоуровневые маркеры легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) на новый слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте экземпляр первого абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) и установите уровень на 0.
7. Создайте экземпляр второго абзаца с помощью класса `Paragraph` и установите уровень на 1.
8. Создайте экземпляр третьего абзаца с помощью класса `Paragraph` и установите уровень на 2.
9. Создайте экземпляр четвертого абзаца с помощью класса `Paragraph` и установите уровень на 3.
10. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
11. Сохраните измененную презентацию.

Этот код PHP показывает, как добавить и управлять многоуровневыми маркерами:

```php
  # Создайте экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получение первого слайда
    $slide = $pres->getSlides()->get_Item(0);
    # Добавляем и получаем Автофигуру
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Получаем текстовый фрейм созданной автофигуры
    $text = $aShp->addTextFrame("");
    # Очищаем абзац по умолчанию
    $text->getParagraphs()->clear();
    # Добавляем первый абзац
    $para1 = new Paragraph();
    $para1->setText("Содержимое");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Устанавливаем уровень маркера
    $para1->getParagraphFormat()->setDepth(0);
    # Добавляем второй абзац
    $para2 = new Paragraph();
    $para2->setText("Второй уровень");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Устанавливаем уровень маркера
    $para2->getParagraphFormat()->setDepth(1);
    # Добавляем третий абзац
    $para3 = new Paragraph();
    $para3->setText("Третий уровень");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Устанавливаем уровень маркера
    $para3->getParagraphFormat()->setDepth(2);
    # Добавляем четвертый абзац
    $para4 = new Paragraph();
    $para4->setText("Четвертый уровень");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Устанавливаем уровень маркера
    $para4->getParagraphFormat()->setDepth(3);
    # Добавляем абзацы в коллекцию
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # Записываем презентацию как файл PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Управление абзацем с пользовательским нумерованным списком**

Интерфейс [IBulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/) предоставляет свойство [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) и другие, которые позволяют управлять абзацами с пользовательской нумерацией или форматированием.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите слайд, содержащий абзац.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте экземпляр первого абзаца через класс [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) и установите [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) на 2.
7. Создайте экземпляр второго абзаца через класс `Paragraph` и установите `NumberedBulletStartWith` на 3.
8. Создайте экземпляр третьего абзаца через класс `Paragraph` и установите `NumberedBulletStartWith` на 7.
9. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
10. Сохраните измененную презентацию.

Этот код PHP показывает, как добавить и управлять абзацами с пользовательской нумерацией или форматированием:

```php
  $presentation = new Presentation();
  try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Получаем текстовый фрейм созданной автофигуры
    $textFrame = $shape->getTextFrame();
    # Удаляем существующий абзац по умолчанию
    $textFrame->getParagraphs()->removeAt(0);
    # Первый список
    $paragraph1 = new Paragraph();
    $paragraph1->setText("маркер 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("маркер 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("маркер 7");
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
1. Получите ссылку на соответствующий слайд через его индекс.
1. Добавьте прямоугольную [автофигуру](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) с тремя абзацами в прямоугольную автофигуру.
1. Спрячьте линии прямоугольника.
1. Установите отступ для каждого [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) через свойство BulletOffset.
1. Запишите измененную презентацию как файл PPT.

Этот код PHP показывает, как установить отступ абзаца:

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получите первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавьте прямоугольную фигуру
    $rect = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 150);
    # Добавьте текстовый фрейм к прямоугольнику
    $tf = $rect->addTextFrame("Это первая строка \rЭто вторая строка \rЭто третья строка");
    # Установите текст так, чтобы он помещался в фигуру
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Спрячьте линии прямоугольника
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # Получите первый абзац в текстовом фрейме и установите его отступ
    $para1 = $tf->getParagraphs()->get_Item(0);
    # Устанавливаем стиль и символ для маркера абзаца
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para1->getParagraphFormat()->setDepth(2);
    $para1->getParagraphFormat()->setIndent(30);
    # Получите второй абзац в текстовом фрейме и установите его отступ
    $para2 = $tf->getParagraphs()->get_Item(1);
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar(8226);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para2->getParagraphFormat()->setDepth(2);
    $para2->getParagraphFormat()->setIndent(40);
    # Получите третий абзац в текстовом фрейме и установите его отступ
    $para3 = $tf->getParagraphs()->get_Item(2);
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para3->getParagraphFormat()->setDepth(2);
    $para3->getParagraphFormat()->setIndent(50);
    # Запишите презентацию на диск
    $pres->save("InOutDent_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка висячего отступа для абзаца**

Этот код PHP показывает, как установить висячий отступ для абзаца:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 550, 150);
    $para1 = new Paragraph();
    $para1->setText("Пример");
    $para2 = new Paragraph();
    $para2->setText("Установка висячего отступа для абзаца");
    $para3 = new Paragraph();
    $para3->setText("Этот код C# показывает вам, как установить висячий отступ для абзаца: ");
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

## **Управление свойствами завершающего элемента абзаца**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд, содержащий абзац, через его позицию.
1. Добавьте прямоугольную [автофигуру](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) с двумя абзацами в прямоугольник.
1. Установите `FontHeight` и тип шрифта для абзацев.
1. Установите завершающие свойства для абзацев.
1. Запишите измененную презентацию как файл PPTX.

Этот код PHP показывает, как установить завершающие свойства для абзацев в PowerPoint:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Пример текста"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Пример текста 2"));
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

## **Импорт HTML текста в абзацы**

Aspose.Slides предоставляет расширенную поддержку для импорта HTML текста в абзацы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) на слайд.
4. Добавьте и получите `автофигуру` [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/).
5. Удалите абзац по умолчанию в `ITextFrame`.
6. Прочтите исходный HTML файл в TextReader.
7. Создайте экземпляр первого абзаца через класс [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
8. Добавьте содержимое HTML файла, прочитанное из TextReader, в коллекцию [ParagraphCollection](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/) текстового фрейма.
9. Сохраните измененную презентацию.

Этот код PHP является реализацией шагов для импорта HTML текстов в абзацы:

```php
  # Создайте пустой экземпляр презентации
  $pres = new Presentation();
  try {
    # Получите первый слайд презентации
    $slide = $pres->getSlides()->get_Item(0);
    # Добавьте автофигуру для размещения HTML содержимого
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Добавьте текстовый фрейм к фигуре
    $ashape->addTextFrame("");
    # Очистите все абзацы в добавленном текстовом фрейме
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Загружайте HTML файл с использованием Stream Reader
    $tr = new StreamReader("file.html");
    # Добавление текста из HTML Stream Reader в текстовый фрейм
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Сохраните презентацию
    $pres->save("output_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Экспорт текста абзацев в HTML**

Aspose.Slides предоставляет расширенную поддержку для экспорта текстов (содержащихся в абзацах) в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и загрузите нужную презентацию.
2. Получите ссылку на соответствующий слайд через его индекс.
3. Получите фигуру, содержащую текст, который будет экспортирован в HTML.
4. Получите [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) фигуры.
5. Создайте экземпляр `StreamWriter` и добавьте новый HTML файл.
6. Укажите начальный индекс для StreamWriter и экспортируйте ваши предпочтительные абзацы.

Этот код PHP показывает, как экспортировать тексты абзацев PowerPoint в HTML:

```php
  # Загружаем файл презентации
  $pres = new Presentation("ExportingHTMLText.pptx");
  try {
    # Получаем первый слайд презентации
    $slide = $pres->getSlides()->get_Item(0);
    # Желаемый индекс
    $index = 0;
    # Получаем добавленную фигуру
    $ashape = $slide->getShapes()->get_Item($index);
    # Создание выходного HTML файла
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Извлекаем первый абзац в формате HTML
    # Записываем данные абзацев в HTML, указывая начальный индекс абзаца, общее количество абзацев для копирования
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```