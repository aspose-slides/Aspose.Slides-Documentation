---
title: Управление SmartArt в презентациях PowerPoint с использованием PHP
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/php-java/manage-smartart/
keywords:
- SmartArt
- Текст SmartArt
- Тип макета
- Скрытое свойство
- Организационная диаграмма
- Диаграмма организационной схемы с изображением
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Изучите, как создавать и редактировать SmartArt в PowerPoint с Aspose.Slides для PHP через Java, используя понятные примеры кода, ускоряющие разработку слайдов и автоматизацию."
---

## **Получить текст из объекта SmartArt**
Теперь метод TextFrame был добавлен в интерфейс [ISmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtShape) и класс [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) соответственно. Это свойство позволяет получить весь текст из [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), если он содержит не только текст узлов. Следующий пример кода поможет вам получить текст из узла SmartArt.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $smartArt = $slide->getShapes()->get_Item(0);
    $smartArtNodes = $smartArt->getAllNodes();
    foreach($smartArtNodes as $smartArtNode) {
      foreach($smartArtNode->getShapes() as $nodeShape) {
        if (!java_is_null($nodeShape->getTextFrame())) {
          echo($nodeShape->getTextFrame()->getText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Изменить тип макета объекта SmartArt**
Чтобы изменить тип макета [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Измените [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setLayout-int-) на BasicProcess.
- Сохраните презентацию в файл PPTX.
  В приведённом ниже примере мы добавили соединитель между двумя фигурами.
```php
  $pres = new Presentation();
  try {
    # Добавить SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    # Изменить LayoutType на BasicProcess
    $smart->setLayout(SmartArtLayoutType::BasicProcess);
    # Сохранение презентации
    $pres->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Проверить свойство Hidden объекта SmartArt**
Обратите внимание: метод [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--)) возвращает true, если этот узел является скрытым в модели данных. Чтобы проверить свойство hidden любого узла [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Пожалуйста, выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Добавьте [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Добавьте узел в SmartArt.
- Проверьте свойство [isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--) .
- Сохраните презентацию в файл PPTX.

  В приведённом ниже примере мы добавили соединитель между двумя фигурами.
```php
  $pres = new Presentation();
  try {
    # Добавить SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    # Добавить узел в SmartArt
    $node = $smart->getAllNodes()->addNode();
    # Проверить свойство isHidden
    $hidden = $node->isHidden();// Возвращает true

    if ($hidden) {
      # Выполнить некоторые действия или уведомления
    }
    # Сохранение презентации
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Получить или установить тип организационной схемы**
Методы [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getOrganizationChartLayout--) , [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) позволяют получить или задать тип организационной схемы, связанный с текущим узлом. Чтобы получить или задать тип организационной схемы, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Добавьте [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) на слайд.
- Получите или [задать тип организационной схемы](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Сохраните презентацию в файл PPTX.
  В приведённом ниже примере мы добавили соединитель между двумя фигурами.
```php
  $pres = new Presentation();
  try {
    # Добавить SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # Получить или установить тип организационной схемы
    $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
    # Сохранение презентации
    $pres->save("OrganizeChartLayoutType_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Создать организационную схему Picture**
Aspose.Slides for PHP via Java предоставляет простой API для создания и управления диаграммами PictureOrganization. Чтобы создать диаграмму на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и желаемым типом (ChartType::PictureOrganizationChart).
1. Запишите изменённую презентацию в файл PPTX

Следующий код используется для создания диаграммы.
```php
  $pres = new Presentation("test.pptx");
  try {
    $smartArt = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);
    $pres->save("OrganizationChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Получить или установить состояние SmartArt**
Чтобы изменить тип макета [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Добавьте [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) на слайд.
1. [Получить](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#isReversed--) или [задать](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setReversed-boolean-) состояние диаграммы SmartArt.
1. Сохраните презентацию в файл PPTX.

Следующий код используется для создания диаграммы.
```php
  # Создать экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Добавить SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
    # Получить или задать состояние диаграммы SmartArt
    $smart->setReversed(true);
    $flag = $smart->isReversed();
    # Сохранение презентации
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Поддерживает ли SmartArt зеркальное отображение/реверсирование для RTL-языков?**

Да. Метод [setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) переключает направление диаграммы (LTR/RTL), если выбранный тип SmartArt поддерживает реверс.

**Как скопировать SmartArt на тот же слайд или в другое представление, сохранив форматирование?**

Вы можете [клонировать фигуру SmartArt](/slides/ru/php-java/shape-manipulations/) через коллекцию фигур ([ShapeCollection.addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/)) или [клонировать весь слайд](/slides/ru/php-java/clone-slides/), содержащий эту фигуру. Оба подхода сохраняют размер, позицию и стиль.

**Как отрендерить SmartArt в растровое изображение для предварительного просмотра или веб-экспорта?**

[Отрендерите слайд](/slides/ru/php-java/convert-powerpoint-to-png/) (или всю презентацию) в PNG/JPEG с помощью API, который преобразует слайды/презентации в изображения — SmartArt будет отрисован как часть слайда.

**Как программно выбрать конкретный SmartArt на слайде, если их несколько?**

Обычно используют [альтернативный текст](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) (Alt Text) или [имя](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getname/) и ищут фигуру по этому атрибуту внутри [формы слайда](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes), затем проверяют тип, чтобы убедиться, что это [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/). Документация описывает типичные техники поиска и работы с фигурами.