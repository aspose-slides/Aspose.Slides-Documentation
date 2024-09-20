---
title: Управление маркерами
type: docs
weight: 60
url: /php-java/manage-bullet/
keywords: "Маркеры, Маркерные списки, Числа, Нумерованные списки, Изображения маркеров, многоуровневые маркеры, Презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Создание маркерных и нумерованных списков в презентации PowerPoint"
---

В **Microsoft PowerPoint** вы можете создавать маркерные и нумерованные списки так же, как и в Word и других текстовых редакторах. **Aspose.Slides для PHP через Java** также позволяет использовать маркеры и номера на слайдах ваших презентаций.

## Почему стоит использовать маркерные списки?

Маркерные списки помогают вам быстро и эффективно организовывать и представлять информацию.

**Пример маркерного списка**

В большинстве случаев маркерный список выполняет три основные функции:

- привлекает внимание ваших читателей или зрителей к важной информации
- позволяет вашим читателям или зрителям легко находить ключевые моменты
- эффективно передает важные детали.

## Почему стоит использовать нумерованные списки?

Нумерованные списки также помогают в организации и представлении информации. В идеале, вам следует использовать номера (вместо маркеров), когда порядок записей (например, *шаг 1, шаг 2* и т.д.) важен или когда запись должна быть процитирована (например, *см. шаг 3*).

**Пример нумерованного списка**

Это сводка шагов (от шага 1 до шага 15) в процедуре **Создание маркеров** ниже:

1. Создайте экземпляр класса презентации.
2. Выполните несколько задач (от шага 3 до шага 14).
3. Сохраните презентацию.

## Создание маркеров
Эта тема также является частью серии тем по управлению текстовыми абзацами. Эта страница иллюстрирует, как мы можем управлять маркерами абзацев. Маркеры полезнее там, где что-то описывается по шагам. Более того, текст выглядит хорошо организованным с использованием маркеров. Абзацы с маркерами всегда легче читать и понимать. Мы увидим, как разработчики могут использовать эту небольшую, но мощную функцию Aspose.Slides для PHP через Java. Пожалуйста, выполните шаги ниже, чтобы управлять маркерами абзацев с помощью Aspose.Slides для PHP через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите доступ к необходимому слайду в коллекции слайдов, используя объект [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) на выбранном слайде.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) добавленной формы.
1. Удалите стандартный абзац в TextFrame.
1. Создайте первый экземпляр абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph).
1. Установите тип маркера абзаца.
1. Установите тип маркера на [Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/BulletType#Symbol) и задайте символ маркера.
1. Установите текст абзаца.
1. Установите отступ абзаца для задания маркера.
1. Установите цвет маркера.
1. Установите высоту маркеров.
1. Добавьте созданный абзац в коллекцию абзацев TextFrame.
1. Добавьте второй абзац и повторите процесс, указанный в шагах **7–13**.
1. Сохраните презентацию.

Этот пример кода — реализация вышеуказанных шагов — показывает, как создать маркерный список на слайде:

```php
  # Создаем экземпляр класса Presentation, который представляет файл PPTX
  $pres = new Presentation();
  try {
    # Доступ к первому слайду
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление и доступ к AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Доступ к текстовому фрейму созданного автоперекрытия
    $txtFrm = $aShp->getTextFrame();
    # Удаление существующего стандартного абзаца
    $txtFrm->getParagraphs()->removeAt(0);
    # Создаем абзац
    $para = new Paragraph();
    # Установка стиля и символа маркера абзаца
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Установка текста абзаца
    $para->setText("Добро пожаловать в Aspose.Slides");
    # Установка отступа маркера
    $para->getParagraphFormat()->setIndent(25);
    # Установка цвета маркера
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    # Установите IsBulletHardColor в true, чтобы использовать свой цвет маркера
    $para->getParagraphFormat()->getBullet()->isBulletHardColor();
    # Установка высоты маркера
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Добавление абзаца в текстовый фрейм
    $txtFrm->getParagraphs()->add($para);
    # Сохранение презентации как файла PPTX
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## Создание изображений маркеров

Aspose.Slides для PHP через Java позволяет вам менять маркеры в маркерных списках. Вы можете заменить маркеры на пользовательские символы или изображения. Если вы хотите добавить визуальный интерес к списку или привлечь еще больше внимания к записям в списке, вы можете использовать свое изображение в качестве маркера.

{{% alert color="primary" %}} 

В идеале, если вы намерены заменить обычный символ маркера на изображение, вам может быть полезно выбрать простой графический изображение с прозрачным фоном. Такие изображения лучше всего подходят в качестве пользовательских символов маркеров.

В любом случае изображение, которое вы выберете, будет уменьшено до очень маленького размера, поэтому мы настоятельно рекомендуем вам выбрать изображение, которое хорошо смотрится (в качестве замены для символа маркера) в списке.

{{% /alert %}} 

Чтобы создать изображение маркера, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите доступ к необходимому слайду в коллекции слайдов, используя объект [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
1. Добавьте автоперекрытие на выбранном слайде.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) добавленной формы.
1. Удалите стандартный абзац в [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Создайте первый экземпляр абзаца с помощью класса Paragraph.
1. Загрузите изображение с диска в [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPPImage).
1. Установите тип маркера на изображение и задайте изображение.
1. Установите текст абзаца.
1. Установите отступ абзаца для задания маркера.
1. Установите цвет маркера.
1. Установите высоту маркеров.
1. Добавьте созданный абзац в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Добавьте второй абзац и повторите процесс, указанный в предыдущих шагах.
1. Сохраните презентацию.

Этот PHP код показывает, как создать изображение маркера на слайде:

```php
  $pres = new Presentation();
  try {
    # Доступ к первому слайду
    $slide = $pres->getSlides()->get_Item(0);
    # Создаем изображение для маркеров
    $picture;
    $image = Images->fromFile("asp1.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Добавление и доступ к AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Доступ к текстовому фрейму созданного автоперекрытия
    $txtFrm = $aShp->getTextFrame();
    # Удаление существующего стандартного абзаца
    $txtFrm->getParagraphs()->removeAt(0);
    # Создание нового абзаца
    $para = new Paragraph();
    $para->setText("Добро пожаловать в Aspose.Slides");
    # Установка стиля и изображения маркера абзаца
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $para->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Установка высоты маркера
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Добавление абзаца в текстовый фрейм
    $txtFrm->getParagraphs()->add($para);
    # Запись презентации как файла PPTX
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Создание многоуровневых маркеров

Чтобы создать маркерный список, содержащий элементы на разных уровнях — дополнительные списки под основным маркерным списком — выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите доступ к необходимому слайду в коллекции слайдов, используя объект [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
1. Добавьте автоперекрытие на выбранном слайде.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) добавленной формы.
1. Удалите стандартный абзац в [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Создайте первый экземпляр абзаца с помощью класса Paragraph и установите глубину на 0.
1. Создайте второй экземпляр абзаца с помощью класса Paragraph и установите глубину на 1.
1. Создайте третий экземпляр абзаца с помощью класса Paragraph и установите глубину на 2.
1. Создайте четвертый экземпляр абзаца с помощью класса Paragraph и установите глубину на 3.
1. Добавьте созданные абзацы в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Сохраните презентацию.

Этот код, который является реализацией вышеуказанных шагов, показывает, как создать многоуровневый маркерный список:

```php
  # Создаем экземпляр класса Presentation, который представляет файл PPTX
  $pres = new Presentation();
  try {
    # Доступ к первому слайду
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление и доступ к AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Доступ к текстовому фрейму созданного автоперекрытия
    $txtFrm = $aShp->addTextFrame("");
    # Удаление существующего стандартного абзаца
    $txtFrm->getParagraphs()->clear();
    # Создание первого абзаца
    $para1 = new Paragraph();
    # Установка стиля и символа маркера абзаца
    $para1->setText("Содержание");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Установка уровня маркера
    $para1->getParagraphFormat()->setDepth(0);
    # Создание второго абзаца
    $para2 = new Paragraph();
    # Установка стиля и символа маркера абзаца
    $para2->setText("Второй уровень");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Установка уровня маркера
    $para2->getParagraphFormat()->setDepth(1);
    # Создание третьего абзаца
    $para3 = new Paragraph();
    # Установка стиля и символа маркера абзаца
    $para3->setText("Третий уровень");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Установка уровня маркера
    $para3->getParagraphFormat()->setDepth(2);
    # Создание четвертого абзаца
    $para4 = new Paragraph();
    # Установка стиля и символа маркера абзаца
    $para4->setText("Четвертый уровень");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Установка уровня маркера
    $para4->getParagraphFormat()->setDepth(3);
    # Добавление абзацев в текстовый фрейм
    $txtFrm->getParagraphs()->add($para1);
    $txtFrm->getParagraphs()->add($para2);
    $txtFrm->getParagraphs()->add($para3);
    $txtFrm->getParagraphs()->add($para4);
    # Сохранение презентации как файла PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Создать пользовательский нумерованный список
Aspose.Slides для PHP через Java предоставляет простой API для управления абзацами с пользовательским форматированием номеров. Чтобы добавить пользовательский числовой список в абзац, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите доступ к необходимому слайду в коллекции слайдов, используя объект [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
1. Добавьте автоперекрытие на выбранном слайде.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) добавленной формы.
1. Удалите стандартный абзац в [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Создайте первый экземпляр абзаца с помощью класса Paragraph и установите **NumberedBulletStartWith** на 2.
1. Создайте второй экземпляр абзаца с помощью класса Paragraph и установите **NumberedBulletStartWith** на 3.
1. Создайте третий экземпляр абзаца с помощью класса Paragraph и установите **NumberedBulletStartWith** на 7.
1. Добавьте созданные абзацы в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Сохраните презентацию.

Этот код PHP показывает, как создать нумерованный список на слайде:

```php
  # Создаем экземпляр класса Presentation, который представляет файл PPTX
  $pres = new Presentation();
  try {
    # Доступ к первому слайду
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление и доступ к AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Доступ к текстовому фрейму созданного автоперекрытия
    $txtFrm = $aShp->addTextFrame("");
    # Удаление существующего стандартного абзаца
    $txtFrm->getParagraphs()->clear();
    # Первый список
    $paragraph1 = new Paragraph();
    $paragraph1->setText("маркер 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("маркер 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph2);
    # Второй список
    $paragraph5 = new Paragraph();
    $paragraph5->setText("маркер 5");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(5);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph5);
    $pres->save($resourcesOutputPath . "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```