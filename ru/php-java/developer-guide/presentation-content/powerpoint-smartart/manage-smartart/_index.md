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
- Диаграмма Picture Organization
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides for PHP via Java, используя понятные примеры кода, ускоряющие разработку слайдов и автоматизацию."
---

## **Получить текст из объекта SmartArt**
Теперь метод TextFrame был добавлен в класс [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape). Это свойство позволяет получать весь текст из [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), если у него есть не только текст узлов. Следующий пример кода поможет получить текст из узла SmartArt.
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
Чтобы изменить тип макета [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) BasicBlockList.
- Измените [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) на BasicProcess.
- Запишите презентацию в файл PPTX.
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


## **Проверка свойства Hidden у объекта SmartArt**
Обратите внимание: метод [SmartArtNode::isHidden()](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) возвращает `true`, если этот узел скрыт в модели данных. Чтобы проверить свойство скрытия любого узла [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Добавьте [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) RadialCycle.
- Добавьте узел в SmartArt.
- Проверьте свойство [visibility](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/).
- Запишите презентацию в файл PPTX.
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


## **Получить или установить тип организационной диаграммы**
Методы [SmartArtNode::getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) и [SmartArtNode::setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) позволяют получить или задать тип организационной диаграммы, связанный с текущим узлом. Чтобы получить или задать тип организационной диаграммы, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Добавьте [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) на слайд.
- Получите или [set the organization chart type](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/).
- Запишите презентацию в файл PPTX.
В приведённом ниже примере мы добавили соединитель между двумя фигурами.
```php
  $pres = new Presentation();
  try {
    # Добавить SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # Получить или установить тип организационной диаграммы
    $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
    # Сохранение презентации
    $pres->save("OrganizeChartLayoutType_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Создать диаграмму Picture Organization**
Aspose.Slides for PHP via Java предоставляет простой API для создания диаграмм PictureOrganization простым способом. Чтобы создать диаграмму на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию и нужным типом (ChartType::PictureOrganizationChart).
4. Запишите изменённую презентацию в файл PPTX

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
Чтобы изменить тип макета [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Добавьте [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) на слайд.
3. [Get](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/isreversed/) или [Set](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) состояние диаграммы SmartArt.
4. Запишите презентацию в файл PPTX.

Следующий код используется для создания диаграммы.
```php
  # Создать экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Добавить SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
    # Получить или установить состояние диаграммы SmartArt
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

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать форму SmartArt](/slides/ru/php-java/shape-manipulations/) через коллекцию фигур ([ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/)) или [клонировать весь слайд](/slides/ru/php-java/clone-slides/), содержащий эту форму. Оба подхода сохраняют размер, положение и стили.

**Как отобразить SmartArt в растровом изображении для предварительного просмотра или веб-экспорта?**

[Отрендерите слайд](/slides/ru/php-java/convert-powerpoint-to-png/) (или всю презентацию) в PNG/JPEG с помощью API, преобразующего слайды/презентации в изображения — SmartArt будет отрисован как часть слайда.

**Как программно выбрать конкретный SmartArt на слайде, если их несколько?**

Обычной практикой является использование [альтернативного текста](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) (Alt Text) или [имени](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getname/), и поиск фигуры по этому атрибуту в [фигурах слайда](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes). Затем проверьте тип, чтобы убедиться, что это [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/). Документация описывает типичные методы поиска и работы с фигурами.