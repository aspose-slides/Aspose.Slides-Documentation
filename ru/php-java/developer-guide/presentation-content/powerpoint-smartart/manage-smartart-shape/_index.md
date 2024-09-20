---
title: Управление формой SmartArt
type: docs
weight: 20
url: /php-java/manage-smartart-shape/
---


## **Создание формы SmartArt**
Aspose.Slides для PHP через Java предоставил API для создания форм SmartArt. Чтобы создать форму SmartArt на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. [Добавьте форму SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) с помощью настройки [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType).
1. Сохраните изменённую презентацию в формате PPTX.

```php
  # Создание экземпляра класса Presentation
  $pres = new Presentation();
  try {
    # Получение первого слайда
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление формы SmartArt
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Сохранение презентации
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Рисунок: Форма SmartArt добавлена на слайд**|

## **Доступ к форме SmartArt на слайде**
Следующий код будет использоваться для доступа к формам SmartArt, добавленным на слайд презентации. В образце кода мы будем проходить через каждую форму внутри слайда и проверять, является ли она формой [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Если форма имеет тип SmartArt, мы приведём её к экземпляру [**SmartArt**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).

```php
  # Загрузка необходимой презентации
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Проход через каждую форму внутри первого слайда
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Проверка, является ли форма типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Приведение формы к SmartArtEx
        $smart = $shape;
        echo("Имя формы:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Доступ к форме SmartArt с определённым типом макета**
Следующий образец кода поможет получить доступ к форме [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) с определённым LayoutType:: Обратите внимание, что вы не можете изменить LayoutType формы SmartArt, так как он является только для чтения и устанавливается только при добавлении формы [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и загрузите презентацию с формой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Проходите через каждую форму внутри первого слайда.
1. Проверьте, является ли форма типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) и приведите выбранную форму к SmartArt, если это SmartArt.
1. Проверьте форму SmartArt с определённым LayoutType и выполните необходимые действия.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Проход через каждую форму внутри первого слайда
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Проверка, является ли форма типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Приведение формы к SmartArtEx
        $smart = $shape;
        # Проверка макета SmartArt
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Сделайте что-то здесь....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Изменение стиля формы SmartArt**
В этом примере мы научимся изменять быстрый стиль для любой формы SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и загрузите презентацию с формой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Проходите через каждую форму внутри первого слайда.
1. Проверьте, является ли форма типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) и приведите выбранную форму к SmartArt, если это SmartArt.
1. Найдите форму SmartArt с определённым стилем.
1. Установите новый стиль для формы SmartArt.
1. Сохраните презентацию.

```php
  # Создание экземпляра класса Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Получение первого слайда
    $slide = $pres->getSlides()->get_Item(0);
    # Проход через каждую форму внутри первого слайда
    foreach($slide->getShapes() as $shape) {
      # Проверка, является ли форма типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Приведение формы к SmartArtEx
        $smart = $shape;
        # Проверка стиля SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Изменение стиля SmartArt
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Сохранение презентации
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Рисунок: Форма SmartArt с изменённым стилем**|

## **Изменение цветового стиля формы SmartArt**
В этом примере мы научимся изменять цветовой стиль для любой формы SmartArt. В следующем образце кода будет доступ к форме SmartArt с определённым цветовым стилем и изменение его стиля.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и загрузите презентацию с формой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Проходите через каждую форму внутри первого слайда.
1. Проверьте, является ли форма типом [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) и приведите выбранную форму к SmartArt, если это SmartArt.
1. Найдите форму SmartArt с определённым цветовым стилем.
1. Установите новый цветовой стиль для формы SmartArt.
1. Сохраните презентацию.

```php
  # Создание экземпляра класса Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Получение первого слайда
    $slide = $pres->getSlides()->get_Item(0);
    # Проход через каждую форму внутри первого слайда
    foreach($slide->getShapes() as $shape) {
      # Проверка, является ли форма типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Приведение формы к SmartArtEx
        $smart = $shape;
        # Проверка цветового типа SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Изменение цветового типа SmartArt
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Сохранение презентации
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Рисунок: Форма SmartArt с изменённым цветовым стилем**|