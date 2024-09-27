---
title: Создание или управление узлом фигуры SmartArt в PowerPoint
linktitle: Управление узлом фигуры SmartArt
type: docs
weight: 30
url: /ru/php-java/manage-smartart-shape-node/
keywords: smartart powerpoint, узлы smartart, позиция smartart, удалить smartart, добавить узлы smartart, презентация powerpoint, powerpoint java, powerpoint java api
description: Управление узлом smart art и дочерними узлами в презентациях PowerPoint
---

## **Добавление узла SmartArt в презентацию PowerPoint с использованием PHP**
Aspose.Slides для PHP через Java предоставляет самый простой API для управления фигурами SmartArt простым способом. Следующий пример кода поможет добавить узел и дочерний узел внутри фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и загрузите презентацию с фигурой SmartArt.
2. Получите ссылку на первый слайд, используя его индекс.
3. Перейдите через каждую фигуру на первом слайде.
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), и преобразуйте выбранную фигуру в [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), если это SmartArt.
5. [Добавьте новый узел](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) в фигуре SmartArt [**NodeCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#getAllNodes--) и установите текст в TextFrame.
6. Теперь [добавьте](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) [**дочерний узел**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) в недавно добавленный [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) узел и установите текст в TextFrame.
7. Сохраните презентацию.

```php
  # Загрузите нужную презентацию
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Перейдите через каждую фигуру на первом слайде
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Проверьте, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Преобразуйте фигуру в SmartArt
        $smart = $shape;
        # Добавление нового узла SmartArt
        $TemNode = $smart->getAllNodes()->addNode();
        # Добавление текста
        $TemNode->getTextFrame()->setText("Тест");
        # Добавление нового дочернего узла в родительский узел. Он будет добавлен в конец коллекции
        $newNode = $TemNode->getChildNodes()->addNode();
        # Добавление текста
        $newNode->getTextFrame()->setText("Новый узел добавлен");
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

## **Добавление узла SmartArt в конкретной позиции**
В следующем примере кода мы объяснили, как добавить дочерние узлы, принадлежащие соответствующим узлам фигуры SmartArt, в определённой позиции.

1. Создайте экземпляр класса Presentation.
2. Получите ссылку на первый слайд, используя его индекс.
3. Добавьте фигуру типа [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) в доступный слайд.
4. Получите доступ к первому узлу в добавленной фигуре SmartArt.
5. Теперь добавьте [**дочерний узел**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) для выбранного [**узла**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) в позиции 2 и установите его текст.
6. Сохраните презентацию.

```php
  # Создайте экземпляр презентации
  $pres = new Presentation();
  try {
    # Доступ к слайду презентации
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление фигуры Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Получение доступа к узлу SmartArt по индексу 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Добавление нового дочернего узла в позиции 2 в родительском узле
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Добавить текст
    $chNode->getTextFrame()->setText("Добавлен образец текста");
    # Сохранить презентацию
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Доступ к узлу SmartArt в презентации PowerPoint с использованием PHP**
Следующий пример кода поможет получить доступ к узлам внутри фигуры SmartArt. Пожалуйста, обратите внимание, что вы не можете изменить LayoutType SmartArt, так как он является только для чтения и устанавливается только при добавлении фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
2. Получите ссылку на первый слайд, используя его индекс.
3. Перейдите через каждую фигуру на первом слайде.
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), и преобразуйте выбранную фигуру в [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), если это SmartArt.
5. Перейдите через все [**узлы**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) внутри фигуры SmartArt.
6. Получите и отобразите информацию, такую как позиция узла SmartArt, уровень и текст.

```php
  # Создание экземпляра класса Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Получите первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Перейдите через каждую фигуру на первом слайде
    foreach($slide->getShapes() as $shape) {
      # Проверьте, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Преобразуйте фигуру в SmartArt
        $smart = $shape;
        # Перейдите через все узлы внутри SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Получение узла SmartArt по индексу i
          $node = $smart->getAllNodes()->get_Item($i);
          # Печать параметров узла SmartArt
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
2. Получите ссылку на первый слайд, используя его индекс.
3. Перейдите через каждую фигуру на первом слайде.
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), и преобразуйте выбранную фигуру в [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), если это SmartArt.
5. Перейдите через все [**узлы**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) внутри фигуры SmartArt.
6. Для каждого выбранного узла SmartArt [**узла**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) пройдите через все [**дочерние узлы**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--) внутри конкретного узла.
7. Получите и отобразите информацию, такую как позиция [**дочернего узла**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--), уровень и текст.

```php
  # Создание экземпляра класса Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Получение первого слайда
    $slide = $pres->getSlides()->get_Item(0);
    # Перейдите через каждую фигуру на первом слайде
    foreach($slide->getShapes() as $shape) {
      # Проверьте, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Преобразуйте фигуру в SmartArt
        $smart = $shape;
        # Перейдите через все узлы внутри SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Получение узла SmartArt по индексу i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Перейдите через дочерние узлы в узле SmartArt по индексу i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Получение дочернего узла в узле SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # Печать параметров дочернего узла SmartArt
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

## **Доступ к дочернему узлу SmartArt в конкретной позиции**
В этом примере мы изучим, как получить доступ к дочерним узлам в определённой позиции, принадлежащей соответствующим узлам фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Получите ссылку на первый слайд, используя его индекс.
3. Добавьте фигуру типа [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList).
4. Получите доступ к добавленной фигуре SmartArt.
5. Получите узел по индексу 0 для доступа к фигуре SmartArt.
6. Теперь получите доступ к [**дочернему узлу**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) в позиции 1 для доступа к узлу SmartArt, используя метод **get_Item()**.
7. Получите и отобразите информацию, такую как позиция [**дочернего узла**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--), уровень и текст.

```php
  # Создание экземпляра презентации
  $pres = new Presentation();
  try {
    # Доступ к первому слайду
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление фигуры SmartArt на первый слайд
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Доступ к узлу SmartArt по индексу 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Получение дочернего узла в позиции 1 в родительском узле
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # Печать параметров дочернего узла SmartArt
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Удаление узла SmartArt в презентации PowerPoint с использованием PHP**
В этом примере мы изучим, как удалить узлы внутри фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
2. Получите ссылку на первый слайд, используя его индекс.
3. Перейдите через каждую фигуру на первом слайде.
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), и преобразуйте выбранную фигуру в [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), если это SmartArt.
5. Проверьте, содержит ли [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) более 0 узлов.
6. Выберите узел SmartArt для удаления.
7. Теперь удалите выбранный узел с помощью метода [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).
8. Сохраните презентацию.

```php
  # Загрузите нужную презентацию
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Перейдите через каждую фигуру на первом слайде
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Проверьте, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Преобразуйте фигуру в SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Получение узла SmartArt по индексу 0
          $node = $smart->getAllNodes()->get_Item(0);
          # Удаление выбранного узла
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

## **Удаление узла SmartArt в конкретной позиции**
В этом примере мы изучим, как удалить узлы внутри фигуры SmartArt в конкретной позиции.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
2. Получите ссылку на первый слайд, используя его индекс.
3. Перейдите через каждую фигуру на первом слайде.
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), и преобразуйте выбранную фигуру в [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), если это SmartArt.
5. Выберите узел фигуры SmartArt по индексу 0.
6. Теперь проверьте, имеет ли выбранный узел SmartArt более 2 дочерних узлов.
7. Теперь удалите узел по **позиции 1** с помощью метода [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-int-).
8. Сохраните презентацию.

```php
  # Загрузите нужную презентацию
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Перейдите через каждую фигуру на первом слайде
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Проверьте, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Преобразуйте фигуру в SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Получение узла SmartArt по индексу 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Удаление дочернего узла на позиции 1
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

## **Установить пользовательскую позицию для дочернего узла в SmartArt**
Теперь Aspose.Slides для PHP через Java поддерживает установку свойств [X](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setX-float-) и [Y](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setY-float-) для [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape). Код ниже демонстрирует, как установить пользовательскую позицию SmartArtShape, размер и вращение; также обратите внимание, что добавление новых узлов вызывает перерасчет позиций и размеров всех узлов. Кроме того, с помощью пользовательских настроек позиции пользователь может устанавливать узлы в соответствии с требованиями.

```php
  # Создание экземпляра класса Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Перемещаем фигуру SmartArt в новую позицию
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Изменение ширины фигуры SmartArt
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # Изменение высоты фигуры SmartArt
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # Изменение вращения фигуры SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Проверка вспомогательного узла**
{{% alert color="primary" %}} 

В этой статье мы более подробно рассмотрим функции фигур SmartArt, добавленных в слайды презентаций программно с использованием Aspose.Slides для PHP через Java.

{{% /alert %}} 

Мы будем использовать следующую исходную фигуру SmartArt для нашего исследования в различных разделах этой статьи.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Рисунок: Исходная фигура SmartArt на слайде**|

В следующем примере кода мы изучим, как идентифицировать **вспомогательные узлы** в коллекции узлов SmartArt и изменить их.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
2. Получите ссылку на второй слайд, используя его индекс.
3. Перейдите через каждую фигуру на первом слайде.
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), и преобразуйте выбранную фигуру в [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), если это SmartArt.
5. Перейдите через все узлы внутри фигуры SmartArt и проверьте, являются ли они [**вспомогательными узлами**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--).
6. Измените статус вспомогательного узла на обычный узел.
7. Сохраните презентацию.

```php
  # Создание экземпляра презентации
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Перейдите через каждую фигуру на первом слайде
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Проверьте, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Преобразуйте фигуру в SmartArt
        $smart = $shape;
        # Перейдите через все узлы фигуры SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Проверьте, является ли узел вспомогательным
          if ($node->isAssistant()) {
            # Установите вспомогательный узел в false и сделайте его обычным узлом
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
|**Рисунок: Измененные вспомогательные узлы в фигуре SmartArt внутри слайда**|

## **Установить формат заливки узла**
Aspose.Slides для PHP через Java позволяет добавлять пользовательские фигуры SmartArt и устанавливать их формат заливки. Эта статья объясняет, как создавать и получать доступ к фигурам SmartArt и устанавливать их формат заливки с использованием Aspose.Slides для PHP через Java.

Пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте фигуру [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), установив ее [**LayoutType**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
4. Установите [**FillFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getFillFormat--) для узлов фигуры SmartArt.
5. Запишите измененную презентацию в файл PPTX.

```php
  # Создание экземпляра презентации
  $pres = new Presentation();
  try {
    # Получение доступа к слайду
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление фигуры SmartArt и узлов
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Некоторый текст");
    # Установка цвета заливки узла
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # Сохранение презентации
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Генерация миниатюры дочернего узла SmartArt**
Разработчики могут генерировать миниатюру дочернего узла SmartArt, следуя приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. [Добавьте SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--).
3. Получите ссылку на узел, используя его индекс.
4. Получите изображение миниатюры.
5. Сохраните изображение миниатюры в любом желаемом формате.

```php
  # Создание экземпляра класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Добавьте SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Получите ссылку на узел, используя его индекс
    $node = $smart->getNodes()->get_Item(1);
    # Получите миниатюру
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Сохраните миниатюру
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