---
title: Управление маркированными и нумерованными списками в презентациях с помощью PHP
linktitle: Управление списками
type: docs
weight: 60
url: /ru/php-java/manage-bullet/
keywords:
- маркер
- маркированный список
- нумерованный список
- символьный маркер
- картинный маркер
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
description: "Узнайте, как управлять маркированными и нумерованными списками в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java. Пошаговое руководство."
---

В **Microsoft PowerPoint** вы можете создавать маркированные и нумерованные списки так же, как в Word и других текстовых редакторах. **Aspose.Slides for PHP via Java** также позволяет использовать маркеры и нумерацию в слайдах ваших презентаций.

## **Почему использовать маркированные списки?**

Маркированные списки помогают быстро и эффективно организовать и представить информацию.

**Пример маркированного списка**

В большинстве случаев маркированный список выполняет три основных функции:

- привлекает внимание читателей или зрителей к важной информации
- позволяет им легко просканировать ключевые моменты
- эффективно передаёт и доставляет важные детали.

## **Почему использовать нумерованные списки?**

Нумерованные списки также помогают в организации и представлении информации. Обычно следует использовать цифры (вместо маркеров), когда порядок элементов (например, *шаг 1, шаг 2* и т.д.) важен или когда необходимо ссылаться на элемент (например, *см. шаг 3*).

**Пример нумерованного списка**

Это сводка шагов (шаг 1 — шаг 15) в процедуре **Creating Bullets**, приведённой ниже:

1. Создайте экземпляр класса презентации. 
2. Выполните несколько задач (шаг 3 — шаг 14).
3. Сохраните презентацию. 

## **Create Bullets**
Эта тема также является частью серии тем по управлению текстовыми абзацами. На этой странице показано, как управлять маркерами абзацев. Маркеры полезны, когда необходимо описать что‑то по шагам. Кроме того, текст выглядит более упорядоченным при использовании маркеров. Абзацы с маркерами всегда легче читать и понимать. Мы покажем, как разработчики могут использовать эту небольшую, но мощную возможность Aspose.Slides for PHP via Java. Пожалуйста, следуйте приведённым ниже шагам для управления маркерами абзацев с помощью Aspose.Slides for PHP via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Получите доступ к нужному слайду в коллекции слайдов с помощью объекта [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) .
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на выбранный слайд.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) добавленной формы.
1. Удалите абзац по умолчанию в TextFrame.
1. Создайте первый экземпляр абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) .
1. Установите тип маркера абзаца.
1. Установите тип маркера в [Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Symbol) и задайте символ маркера.
1. Установите текст абзаца.
1. Установите отступ абзаца, чтобы задать маркер.
1. Установите цвет маркера.
1. Установите высоту маркеров.
1. Добавьте созданный абзац в коллекцию абзацев TextFrame.
1. Добавьте второй абзац и повторите процесс, указанный в шагах **7 to 13**.
1. Сохраните презентацию.

Этот пример кода — реализация вышеописанных шагов — показывает, как создать маркированный список на слайде:
```php
  # Создать экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получение первого слайда
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление и получение AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Получение текстового фрейма созданной AutoShape
    $txtFrm = $aShp->getTextFrame();
    # Удаление существующего абзаца по умолчанию
    $txtFrm->getParagraphs()->removeAt(0);
    # Создание абзаца
    $para = new Paragraph();
    # Установка стиля маркера абзаца и символа
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Установка текста абзаца
    $para->setText("Welcome to Aspose.Slides");
    # Установка отступа маркера
    $para->getParagraphFormat()->setIndent(25);
    # Установка цвета маркера
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    # Установить IsBulletHardColor в true, чтобы использовать собственный цвет маркера
    $para->getParagraphFormat()->getBullet()->isBulletHardColor();
    # Установка высоты маркера
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Добавление абзаца в текстовый фрейм
    $txtFrm->getParagraphs()->add($para);
    # Сохранение презентации в файл PPTX
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Create Picture Bullets**

Aspose.Slides for PHP via Java позволяет менять маркеры в маркированных списках. Вы можете заменить маркеры пользовательскими символами или изображениями. Если вы хотите добавить визуальный интерес к списку или привлечь ещё больше внимания к элементам списка, можете использовать своё изображение в качестве маркера.

{{% alert color="primary" %}} 

Идеально, если вы планируете заменить обычный символ маркера картинкой, стоит выбрать простое графическое изображение с прозрачным фоном. Такие изображения лучше всего подходят в качестве пользовательских символов маркеров. 

В любом случае выбранное изображение будет уменьшено до очень небольшого размера, поэтому настоятельно рекомендуется выбирать изображение, которое выглядит хорошо (в качестве замены символа маркера) в списке. 

{{% /alert %}} 

Чтобы создать картинный маркер, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 
1. Получите доступ к нужному слайду в коллекции слайдов с помощью объекта [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) 
1. Добавьте автосферу на выбранный слайд
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) добавленной формы
1. Удалите абзац по умолчанию в [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)
1. Создайте первый экземпляр абзаца с помощью класса Paragraph
1. Загрузите изображение с диска в [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)
1. Установите тип маркера в Picture и задайте изображение
1. Установите текст абзаца
1. Установите отступ абзаца, чтобы задать маркер
1. Установите цвет маркера
1. Установите высоту маркеров
1. Добавьте созданный абзац в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)
1. Добавьте второй абзац и повторите процесс, указанный в предыдущих шагах
1. Сохраните презентацию

Этот PHP‑код показывает, как создать картинный маркер на слайде:
```php
  $pres = new Presentation();
  try {
    # Доступ к первому слайду
    $slide = $pres->getSlides()->get_Item(0);
    # Создание изображения для маркеров
    $picture;
    $image = Images->fromFile("asp1.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Добавление и получение AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Получение текстового фрейма созданного AutoShape
    $txtFrm = $aShp->getTextFrame();
    # Удаление существующего абзаца по умолчанию
    $txtFrm->getParagraphs()->removeAt(0);
    # Создание нового абзаца
    $para = new Paragraph();
    $para->setText("Welcome to Aspose.Slides");
    # Установка стиля маркера абзаца и изображения
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $para->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Установка высоты маркера
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Добавление абзаца в текстовый фрейм
    $txtFrm->getParagraphs()->add($para);
    # Запись презентации в файл PPTX
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Create Multilevel Bullets**

Чтобы создать маркированный список, содержащий элементы разных уровней — дополнительные списки под главным списком — выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Получите доступ к нужному слайду в коллекции слайдов с помощью объекта [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) .
1. Добавьте автосферу на выбранный слайд.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) добавленной формы.
1. Удалите абзац по умолчанию в [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) .
1. Создайте первый экземпляр абзаца с помощью класса Paragraph и задайте глубину 0.
1. Создайте второй экземпляр абзаца с помощью класса Paragraph и задайте глубину 1.
1. Создайте третий экземпляр абзаца с помощью класса Paragraph и задайте глубину 2.
1. Создайте четвёртый экземпляр абзаца с помощью класса Paragraph и задайте глубину 3.
1. Добавьте созданные абзацы в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) .
1. Сохраните презентацию.

Этот код, реализующий вышеуказанные шаги, показывает, как создать многоуровневый маркированный список :
```php
  # Создать экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Доступ к первому слайду
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление и доступ к AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Получение текстового фрейма созданного AutoShape
    $txtFrm = $aShp->addTextFrame("");
    # Удаление существующего абзаца по умолчанию
    $txtFrm->getParagraphs()->clear();
    # Создание первого абзаца
    $para1 = new Paragraph();
    # Установка стиля маркера абзаца и символа
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Установка уровня маркера
    $para1->getParagraphFormat()->setDepth(0);
    # Создание второго абзаца
    $para2 = new Paragraph();
    # Установка стиля маркера абзаца и символа
    $para2->setText("Second level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Установка уровня маркера
    $para2->getParagraphFormat()->setDepth(1);
    # Создание третьего абзаца
    $para3 = new Paragraph();
    # Установка стиля маркера абзаца и символа
    $para3->setText("Third level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Установка уровня маркера
    $para3->getParagraphFormat()->setDepth(2);
    # Создание четвертого абзаца
    $para4 = new Paragraph();
    # Установка стиля маркера абзаца и символа
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Установка уровня маркера
    $para4->getParagraphFormat()->setDepth(3);
    # Добавление абзаца в текстовый фрейм
    $txtFrm->getParagraphs()->add($para1);
    $txtFrm->getParagraphs()->add($para2);
    $txtFrm->getParagraphs()->add($para3);
    $txtFrm->getParagraphs()->add($para4);
    # Сохранение презентации в файл PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Create Custom Numbered Lists**
Aspose.Slides for PHP via Java предоставляет простой API для управления абзацами с пользовательским форматированием нумерации. Чтобы добавить пользовательский нумерованный список в абзац, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Получите доступ к нужному слайду в коллекции слайдов с помощью объекта [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) .
1. Добавьте автосферу на выбранный слайд.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) добавленной формы.
1. Удалите абзац по умолчанию в [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) .
1. Создайте первый экземпляр абзаца с помощью класса Paragraph и задайте **NumberedBulletStartWith** = 2
1. Создайте второй экземпляр абзаца с помощью класса Paragraph и задайте **NumberedBulletStartWith** = 3
1. Создайте третий экземпляр абзаца с помощью класса Paragraph и задайте **NumberedBulletStartWith** = 7
1. Добавьте созданные абзацы в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) .
1. Сохраните презентацию.

Этот PHP‑код показывает, как создать нумерованный список на слайде:
```php
  # Создать экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получение первого слайда
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление и получение AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Получение текстового фрейма созданной AutoShape
    $txtFrm = $aShp->addTextFrame("");
    # Удаление существующего абзаца по умолчанию
    $txtFrm->getParagraphs()->clear();
    # Первый список
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph2);
    # Второй список
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 5");
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


## **FAQ**

**Можно ли экспортировать маркированные и нумерованные списки, созданные с помощью Aspose.Slides, в другие форматы, такие как PDF или изображения?**

Да, Aspose.Slides полностью сохраняет форматирование и структуру маркированных и нумерованных списков при экспорте презентаций в такие форматы, как PDF, изображения и другие, гарантируя последовательные результаты.

**Можно ли импортировать маркированные или нумерованные списки из существующих презентаций?**

Да, Aspose.Slides позволяет импортировать и редактировать маркированные и нумерованные списки из существующих презентаций, сохраняя их исходное форматирование и внешний вид.

**Поддерживает ли Aspose.Slides маркированные и нумерованные списки в презентациях, созданных на разных языках?**

Да, Aspose.Slides полностью поддерживает мультиязычные презентации, позволяя создавать маркированные и нумерованные списки на любом языке, включая специальные или нелатинские символы.