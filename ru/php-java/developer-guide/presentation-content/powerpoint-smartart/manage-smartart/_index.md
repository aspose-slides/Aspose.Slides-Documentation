---
title: Управление SmartArt
type: docs
weight: 10
url: /ru/php-java/manage-smartart/
---

## **Получить текст из SmartArt**
Теперь метод TextFrame был добавлен в интерфейс [ISmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtShape) и класс [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) соответственно. Это свойство позволяет получить весь текст из [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), если он содержит не только текст узлов. Приведенный ниже пример кода поможет вам получить текст из узла SmartArt.

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

## **Изменить тип макета SmartArt**
Чтобы изменить тип макета [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Измените [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setLayout-int-) на BasicProcess.
- Запишите презентацию в файл PPTX.
  В приведенном ниже примере мы добавили соединитель между двумя фигурами.

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

## **Проверить скрытое свойство SmartArt**
Обратите внимание: метод [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--) возвращает true, если этот узел является скрытым узлом в модели данных. Чтобы проверить скрытое свойство любого узла [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Добавьте [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Добавьте узел в SmartArt.
- Проверьте свойство [isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--).
- Запишите презентацию в файл PPTX.

В приведенном ниже примере мы добавили соединитель между двумя фигурами.

```php
  $pres = new Presentation();
  try {
    # Добавить SmartArt RadialCycle
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
Методы [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getOrganizationChartLayout--), [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) позволяют получить или установить тип организационной диаграммы, связанный с текущим узлом. Чтобы получить или установить тип организационной диаграммы, выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Добавьте [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) на слайд.
- Получите или [установите тип организационной диаграммы](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Запишите презентацию в файл PPTX.
  В приведенном ниже примере мы добавили соединитель между двумя фигурами.

```php
  $pres = new Presentation();
  try {
    # Добавить SmartArt OrganizationChart
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

## **Создать организационную диаграмму с изображениями**
Aspose.Slides для PHP через Java предоставляет простой API для создания и организационных диаграмм с изображениями. Чтобы создать диаграмму на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по индексу.
1. Добавьте диаграмму с данными по умолчанию вместе с желаемым типом (ChartType::PictureOrganizationChart).
1. Запишите измененную презентацию в файл PPTX.

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
Чтобы изменить тип макета [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Добавьте [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) на слайд.
1. [Получите](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#isReversed--) или [установите](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setReversed-boolean-) состояние диаграммы SmartArt.
1. Запишите презентацию в файл PPTX.

Следующий код используется для создания диаграммы.

```php
  # Создание класса Presentation, представляющего файл PPTX
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