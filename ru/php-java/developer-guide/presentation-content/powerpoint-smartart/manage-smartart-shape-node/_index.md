---
title: Управление узлами формы SmartArt в презентациях с использованием PHP
linktitle: Узел формы SmartArt
type: docs
weight: 30
url: /ru/php-java/manage-smartart-shape-node/
keywords:
- Узел SmartArt
- Дочерний узел
- Добавить узел
- Позиция узла
- Доступ к узлу
- Удалить узел
- Пользовательская позиция
- Узел‑ассистент
- Формат заливки
- Отрисовка узла
- PowerPoint
- Презентация
- PHP
- Aspose.Slides
description: "Управляйте узлами формы SmartArt в PPT и PPTX с помощью Aspose.Slides for PHP via Java. Получите понятные примеры кода и советы по оптимизации ваших презентаций."
---

## **Добавить узел SmartArt**
Aspose.Slides for PHP via Java предоставил самый простой API для управления фигурами SmartArt самым удобным способом. Следующий пример кода поможет добавить узел и дочерний узел внутри фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и загрузите презентацию с фигурой SmartArt.
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдитесь по всем фигурам на первом слайде.
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), если это SmartArt.
5. [Добавьте новый узел](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) в фигуру SmartArt [**NodeCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#getAllNodes--) и задайте текст в TextFrame.
6. Теперь [добавьте](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) [**дочерний узел**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) в недавно добавленный узел [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) и задайте текст в TextFrame.
7. Сохраните презентацию.
```php
  # Загрузить нужную презентацию
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Пройти по всем фигурам на первом слайде
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Проверить, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести тип фигуры к SmartArt
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


## **Добавить узел SmartArt в определённой позиции**
В следующем примере кода мы объяснили, как добавить дочерние узлы, принадлежащие соответствующим узлам фигуры SmartArt, в определённой позиции.

1. Создайте экземпляр класса Presentation.
2. Получите ссылку на первый слайд, используя его индекс.
3. Добавьте фигуру [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) типа [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) на выбранный слайд.
4. Получите доступ к первому узлу в добавленной фигуре SmartArt.
5. Теперь добавьте [**дочерний узел**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) для выбранного [**узла**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) в позицию 2 и задайте его текст.
6. Сохраните презентацию.
```php
  # Создание экземпляра презентации
  $pres = new Presentation();
  try {
    # Получить слайд презентации
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Получение узла SmartArt с индексом 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Добавление нового дочернего узла в позицию 2 родительского узла
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
Следующий пример кода поможет получить доступ к узлам внутри фигуры SmartArt. Обратите внимание, что вы не можете изменить LayoutType SmartArt, так как он только для чтения и задаётся только при добавлении фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдитесь по всем фигурам на первом слайде.
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), если это SmartArt.
5. Пройдитесь по всем [**узлам**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) внутри фигуры SmartArt.
6. Получите и отобразите информацию, такую как позиция узла SmartArt, уровень и текст.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Пройти по всем фигурам на первом слайде
    foreach($slide->getShapes() as $shape) {
      # Проверить, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести тип фигуры к SmartArt
        $smart = $shape;
        # Пройти по всем узлам внутри SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Получить узел SmartArt по индексу i
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
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдитесь по всем фигурам на первом слайде.
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), если это SmartArt.
5. Пройдитесь по всем [**узлам**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) внутри фигуры SmartArt.
6. Для каждого выбранного [**узла**] фигуры SmartArt пройдитесь по всем [**дочерним узлам**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--) внутри конкретного узла.
7. Получите и отобразите информацию, такую как позиция [**дочернего узла**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) , уровень и текст.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Пройти по всем фигурам на первом слайде
    foreach($slide->getShapes() as $shape) {
      # Проверить, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести тип фигуры к SmartArt
        $smart = $shape;
        # Пройти по всем узлам внутри SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Получить узел SmartArt по индексу i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Проход по дочерним узлам узла SmartArt с индексом i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Получить дочерний узел в узле SmartArt
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


## **Доступ к дочернему узлу SmartArt в определённой позиции**
В этом примере мы узнаем, как получить доступ к дочерним узлам в определённой позиции, принадлежащим соответствующим узлам фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
2. Получите ссылку на первый слайд, используя его индекс.
3. Добавьте фигуру [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) типа SmartArt.
4. Получите доступ к добавленной фигуре SmartArt.
5. Получите доступ к узлу с индексом 0 для выбранной фигуры SmartArt.
6. Теперь получите доступ к [**дочернему узлу**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) в позиции 1 для выбранного узла SmartArt, используя метод **get_Item()**.
7. Получите и отобразите информацию, такую как позиция [**дочернего узла**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) , уровень и текст.
```php
  # Создать экземпляр презентации
  $pres = new Presentation();
  try {
    # Доступ к первому слайду
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление SmartArt фигуры на первый слайд
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Доступ к узлу SmartArt с индексом 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Доступ к дочернему узлу в позиции 1 родительского узла
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
В этом примере мы узнаем, как удалить узлы внутри фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдитесь по всем фигурам на первом слайде.
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), если это SmartArt.
5. Проверьте, имеет ли [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) более 0 узлов.
6. Выберите узел SmartArt, который нужно удалить.
7. Теперь удалите выбранный узел, используя метод [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .
8. Сохраните презентацию.
```php
  # Загрузить требуемую презентацию
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Пройти по всем фигурам на первом слайде
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Проверить, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести тип фигуры к SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Получить узел SmartArt по индексу 0
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


## **Удалить узел SmartArt из определённой позиции**
В этом примере мы узнаем, как удалить узлы внутри фигуры SmartArt из определённой позиции.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдитесь по всем фигурам на первом слайде.
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), если это SmartArt.
5. Выберите узел фигуры SmartArt с индексом 0.
6. Теперь проверьте, имеет ли выбранный узел SmartArt более 2 дочерних узлов.
7. Теперь удалите узел в **позиции 1**, используя метод [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-int-) .
8. Сохраните презентацию.
```php
  # Загрузить нужную презентацию
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Пройти по всем фигурам на первом слайде
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Проверить, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести тип фигуры к SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Получить узел SmartArt по индексу 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Удалить дочерний узел в позиции 1
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
Теперь Aspose.Slides for PHP via Java поддерживает установку свойств [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setX-float-) и [Y](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setY-float-). Ниже приведён фрагмент кода, показывающий, как задать пользовательскую позицию, размер и вращение SmartArtShape; также обратите внимание, что добавление новых узлов приводит к пересчёту позиций и размеров всех узлов. С пользовательскими настройками позиции пользователь может задавать узлы в соответствии с требованиями.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Переместить SmartArt фигуру в новое положение
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
    # Изменить вращение фигуры SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Check an Assistant Node**
{{% alert color="primary" %}} 

В этой статье мы подробнее исследуем функции фигур SmartArt, добавленных в слайды презентации программно с использованием Aspose.Slides for PHP via Java.

{{% /alert %}} 

Мы будем использовать следующую исходную фигуру SmartArt для нашего исследования в различных разделах этой статьи.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure: Source SmartArt shape in slide**|

В следующем примере кода мы исследуем, как определить **узлы‑ассистенты** в коллекции узлов SmartArt и изменить их.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
2. Получите ссылку на второй слайд, используя его индекс.
3. Пройдитесь по всем фигурам на первом слайде.
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt), если это SmartArt.
5. Пройдитесь по всем узлам внутри фигуры SmartArt и проверьте, являются ли они [**узлами‑ассистентами**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--).
6. Измените статус узла‑ассистента на обычный узел.
7. Сохраните презентацию.
```php
  # Создание экземпляра презентации
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Пройти по всем фигурам на первом слайде
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Проверить, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести тип фигуры к SmartArt
        $smart = $shape;
        # Обход всех узлов фигуры SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Проверить, является ли узел узлом‑ассистентом
          if ($node->isAssistant()) {
            # Установить Assistant узел в false и сделать его обычным узлом
            $node->isAssistant();
          }
        }
      }
    }
    # Сохранить презентацию
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure: Assistant Nodes Changed in SmartArt shape inside slide**|

## **Установить формат заливки узла**
Aspose.Slides for PHP via Java позволяет добавлять пользовательские фигуры SmartArt и задавать их формат заливки. В этой статье объясняется, как создавать и получать доступ к фигурам SmartArt и задавать их формат заливки с помощью Aspose.Slides for PHP via Java.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте фигуру [SmartArt], задав её [**LayoutType**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
4. Задайте [**FillFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getFillFormat--) для узлов фигуры SmartArt.
5. Сохраните изменённую презентацию в файл PPTX.
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
Разработчики могут создать миниатюру дочернего узла SmartArt, выполнив следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. [Добавьте SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--).
3. Получите ссылку на узел, используя его индекс.
4. Получите изображение миниатюры.
5. Сохраните изображение миниатюры в любом желаемом формате изображения.
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

Да. SmartArt рассматривается как обычная фигура, поэтому вы можете [применять стандартные анимации](/slides/ru/php-java/shape-animation/) (вход, выход, акцент, траектории движения) и настраивать время. При необходимости вы также можете анимировать фигуры внутри узлов SmartArt.

**Как надёжно найти конкретный SmartArt на слайде, если его внутренний ID неизвестен?**

Назначьте и ищите по [альтернативному тексту](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/). Установка отличительного AltText у SmartArt позволяет находить его программно без использования внутренних идентификаторов.

**Сохранится ли внешний вид SmartArt при конвертации презентации в PDF?**

Да. Aspose.Slides отображает SmartArt с высокой визуальной точностью при [экспорте в PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/), сохраняет макет, цвета и эффекты.

**Могу ли я извлечь изображение всего SmartArt (для превью или отчетов)?**

Да. Вы можете отобразить фигуру SmartArt в [растровые форматы](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) или в [SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) для масштабируемого векторного вывода, что подходит для миниатюр, отчетов или веб-использования.