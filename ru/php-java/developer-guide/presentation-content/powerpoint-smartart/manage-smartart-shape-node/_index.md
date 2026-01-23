---
title: Управление узлами SmartArt в презентациях с помощью PHP
linktitle: Узел фигуры SmartArt
type: docs
weight: 30
url: /ru/php-java/manage-smartart-shape-node/
keywords:
- узел SmartArt
- дочерний узел
- добавить узел
- позиция узла
- доступ к узлу
- удалить узел
- пользовательская позиция
- узел‑ассистент
- формат заливки
- отрисовка узла
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Управляйте узлами фигур SmartArt в PPT и PPTX с помощью Aspose.Slides for PHP via Java. Получайте понятные примеры кода и рекомендации для оптимизации ваших презентаций."
---

## **Добавить узел SmartArt**
Aspose.Slides for PHP via Java предоставил самый простой API для управления фигурами SmartArt самым удобным способом. Следующий пример кода поможет добавить узел и дочерний узел внутри фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдите по всем фигурам на первом слайде.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/), если это SmartArt.
1. [Добавить новый узел](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode) в фигуру SmartArt [**NodeCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/#getAllNodes) и задайте текст в TextFrame.
1. Теперь, [Добавить] [**Дочерний узел**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/#getChildNodes) в недавно добавленный узел [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) и задайте текст в TextFrame.
1. Сохраните презентацию.
```php
  # Загрузите нужную презентацию
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Пройдитесь по всем фигурам на первом слайде
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Проверьте, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Приведите тип фигуры к SmartArt
        $smart = $shape;
        # Добавление нового узла SmartArt
        $TemNode = $smart->getAllNodes()->addNode();
        # Добавление текста
        $TemNode->getTextFrame()->setText("Test");
        # Добавление нового дочернего узла в родительский узел. Он будет добавлен в конец коллекции
        $newNode = $TemNode->getChildNodes()->addNode();
        # Добавление текста
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # Сохранение презентации
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Добавить узел SmartArt в определенной позиции**
В следующем примере кода объясняется, как добавить дочерние узлы, принадлежащие соответствующим узлам фигуры SmartArt, в конкретной позиции.

1. Создайте экземпляр класса Presentation.
1. Получите ссылку на первый слайд, используя его индекс.
1. Добавьте фигуру [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) типа [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) на выбранный слайд.
1. Получите первый узел в добавленной фигуре SmartArt.
1. Теперь добавьте [**Дочерний узел**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/#getChildNodes) для выбранного [**Узла**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) на позиции 2 и задайте его текст.
1. Сохраните презентацию.
```php
  # Создание экземпляра презентации
  $pres = new Presentation();
  try {
    # Доступ к слайду презентации
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Доступ к узлу SmartArt с индексом 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Добавление нового дочернего узла на позицию 2 в родительском узле
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Добавить текст
    $chNode->getTextFrame()->setText("Sample Text Added");
    # Сохранить презентацию
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Доступ к узлу SmartArt**
Следующий пример кода поможет получить доступ к узлам внутри фигуры SmartArt. Обратите внимание, что тип LayoutType фигуры SmartArt только для чтения и задается только при добавлении фигуры.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдите по всем фигурам на первом слайде.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/), если это SmartArt.
1. Пройдите по всем [**Узлам**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) внутри фигуры SmartArt.
1. Получите и отобразите информацию, такую как позиция узла SmartArt, уровень и текст.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Обойти все фигуры на первом слайде
    foreach($slide->getShapes() as $shape) {
      # Проверить, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести тип фигуры к SmartArt
        $smart = $shape;
        # Обойти все узлы внутри SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Доступ к узлу SmartArt с индексом i
          $node = $smart->getAllNodes()->get_Item($i);
          # Вывод параметров узла SmartArt
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Доступ к дочернему узлу SmartArt**
Следующий пример кода поможет получить доступ к дочерним узлам, принадлежащим соответствующим узлам фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдите по всем фигурам на первом слайде.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/), если это SmartArt.
1. Пройдите по всем [**Узлам**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) внутри фигуры SmartArt.
1. Для каждого выбранного [**Узла**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) фигуры SmartArt пройдите по всем [**Дочерним узлам**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--) внутри конкретного узла.
1. Получите и отобразите информацию, такую как позиция [**Дочернего узла**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/#getChildNodes), уровень и текст.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Обойти каждую фигуру на первом слайде
    foreach($slide->getShapes() as $shape) {
      # Проверить, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести тип фигуры к SmartArt
        $smart = $shape;
        # Обойти все узлы внутри SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Доступ к узлу SmartArt с индексом i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Обход дочерних узлов в узле SmartArt с индексом i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Доступ к дочернему узлу в узле SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # Вывод параметров дочернего узла SmartArt
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Доступ к дочернему узлу SmartArt в определенной позиции**
В этом примере мы изучим, как получить доступ к дочерним узлам в определенной позиции, принадлежащим соответствующим узлам фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите ссылку на первый слайд, используя его индекс.
1. Добавьте фигуру SmartArt типа [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList).
1. Получите добавленную фигуру SmartArt.
1. Получите узел с индексом 0 в полученной фигуре SmartArt.
1. Теперь получите [**Дочерний узел**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/#getChildNodes) на позиции 1 для выбранного узла SmartArt с помощью метода **get_Item()**.
1. Получите и отобразите информацию, такую как позиция [**Дочернего узла**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/#getChildNodes), уровень и текст.
```php
  # Создать экземпляр презентации
  $pres = new Presentation();
  try {
    # Доступ к первому слайду
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление фигуры SmartArt на первый слайд
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Доступ к узлу SmartArt с индексом 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Доступ к дочернему узлу на позиции 1 в родительском узле
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # Вывод параметров дочернего узла SmartArt
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Удалить узел SmartArt**
В этом примере мы изучим, как удалять узлы внутри фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдите по всем фигурам на первом слайде.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/), если это SmartArt.
1. Проверьте, содержит ли фигура SmartArt более 0 узлов.
1. Выберите узел SmartArt, который необходимо удалить.
1. Теперь удалите выбранный узел с помощью метода [**removeNode**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#removeNode).
1. Сохраните презентацию.
```php
  # Загрузить нужную презентацию
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Пройти по всем фигурам на первом слайде
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Проверьте, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести тип фигуры к SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Доступ к узлу SmartArt с индексом 0
          $node = $smart->getAllNodes()->get_Item(0);
          # Удалить выбранный узел
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Сохранить презентацию
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Удалить узел SmartArt из определенной позиции**
В этом примере мы изучим, как удалять узлы внутри фигуры SmartArt в конкретной позиции.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдите по всем фигурам на первом слайде.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/), если это SmartArt.
1. Выберите узел фигуры SmartArt с индексом 0.
1. Проверьте, содержит ли выбранный узел SmartArt более 2 дочерних узлов.
1. Теперь удалите узел на **позиции 1** с помощью метода [**removeNode**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#removeNode).
1. Сохраните презентацию.
```php
  # Загрузить нужную презентацию
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Обойти все фигуры на первом слайде
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Проверить, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести тип фигуры к SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Доступ к узлу SmartArt с индексом 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Удалить дочерний узел на позиции 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # Сохранить презентацию
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установить пользовательскую позицию для дочернего узла в объекте SmartArt**
Aspose.Slides for PHP via Java поддерживает установку свойств [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setX) и [Y](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setY). Ниже приведён фрагмент кода, показывающий, как установить пользовательскую позицию, размер и вращение SmartArtShape; также обратите внимание, что добавление новых узлов вызывает перерасчёт позиций и размеров всех узлов. При пользовательских настройках позиции пользователь может задавать узлы согласно требованиям.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Переместить фигуру SmartArt в новую позицию
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Изменить ширину фигуры SmartArt
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # Изменить высоту фигуры SmartArt
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # Изменить поворот фигуры SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Проверка узла‑ассистента**
{{% alert color="primary" %}} 

В этой статье мы подробнее рассмотрим функции фигур SmartArt, добавленных в слайды презентаций программно с помощью Aspose.Slides for PHP via Java.

{{% /alert %}} 

Мы будем использовать следующую исходную фигуру SmartArt для наших исследований в разных разделах этой статьи.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Рисунок: Исходная фигура SmartArt на слайде**|

В следующем примере кода мы исследуем, как определить **Узлы‑ассистенты** в коллекции узлов SmartArt и изменить их.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на второй слайд, используя его индекс.
1. Пройдите по всем фигурам внутри первого слайда.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/), если это SmartArt.
1. Пройдите по всем узлам внутри фигуры SmartArt и проверьте, являются ли они [**Узлами‑ассистентами**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--).
1. Измените статус узла‑ассистента на обычный узел.
1. Сохраните презентацию.
```php
  # Создание экземпляра презентации
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Обход всех фигур на первом слайде
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Проверка, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Приведение типа фигуры к SmartArt
        $smart = $shape;
        # Обход всех узлов фигуры SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Проверка, является ли узел узлом‑ассистентом
          if ($node->isAssistant()) {
            # Установка свойства Assistant узла в false и превращение его в обычный узел
            $node->isAssistant();
          }
        }
      }
    }
    # Сохранение презентации
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Рисунок: Узлы‑ассистенты изменены в фигуре SmartArt на слайде**|

## **Установить формат заливки узла**
Aspose.Slides for PHP via Java позволяет добавлять пользовательские фигуры SmartArt и задавать их формат заливки. В этой статье объясняется, как создавать и получать доступ к фигурам SmartArt и задавать их формат заливки с помощью Aspose.Slides for PHP via Java.

Пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте фигуру [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) задав её [**LayoutType**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Задайте [**Fill Format**](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFillFormat) для узлов фигуры SmartArt.
1. Запишите изменённую презентацию в файл PPTX.
```php
  # Создать экземпляр презентации
  $pres = new Presentation();
  try {
    # Доступ к слайду
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление фигуры SmartArt и узлов
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # Установка цвета заливки узла
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # Сохранить презентацию
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Создать миниатюру дочернего узла SmartArt**
Разработчики могут создавать миниатюру дочернего узла SmartArt, выполнив следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. [Добавить SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode).
1. Получите ссылку на узел, используя его индекс.
1. Получите изображение миниатюры.
1. Сохраните изображение миниатюры в любом желаемом формате изображений.
```php
  # Создать экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Добавить SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Получить ссылку на узел, используя его индекс
    $node = $smart->getNodes()->get_Item(1);
    # Получить миниатюру
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Сохранить миниатюру
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Поддерживается ли анимация SmartArt?**

Да. SmartArt рассматривается как обычная фигура, поэтому вы можете [применять стандартные анимации](/slides/ru/php-java/shape-animation/) (вход, выход, акцент, траектории движения) и настраивать тайминг. При необходимости можно анимировать фигуры внутри узлов SmartArt.

**Как надёжно найти конкретный SmartArt на слайде, если его внутренний ID неизвестен?**

Назначьте и ищите по [альтернативному тексту](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/). Установка отличительного AltText у SmartArt позволяет программно находить его без обращения к внутренним идентификаторам.

**Сохранится ли внешний вид SmartArt при конвертации презентации в PDF?**

Да. Aspose.Slides рендерит SmartArt с высокой визуальной точностью во время [экспорта в PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/), сохраняя макет, цвета и эффекты.

**Можно ли извлечь изображение всего SmartArt (для предварительных просмотров или отчетов)?**

Да. Вы можете рендерить фигуру SmartArt в [растровые форматы](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) или в [SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) для масштабируемого векторного вывода, что подходит для миниатюр, отчетов или веб‑использования.