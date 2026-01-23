---
title: Управление графикой SmartArt в презентациях с использованием PHP
linktitle: Графика SmartArt
type: docs
weight: 20
url: /ru/php-java/manage-smartart-shape/
keywords:
- Объект SmartArt
- Графика SmartArt
- Стиль SmartArt
- Цвет SmartArt
- Создание SmartArt
- Добавление SmartArt
- Редактирование SmartArt
- Изменение SmartArt
- Доступ к SmartArt
- Тип макета SmartArt
- PowerPoint
- Презентация
- PHP
- Aspose.Slides
description: "Автоматизируйте создание, редактирование и стилизацию SmartArt в PowerPoint с помощью PHP и Aspose.Slides, предоставляя лаконичные примеры кода и рекомендации, ориентированные на производительность."
---

## **Создание фигуры SmartArt**
Aspose.Slides for PHP via Java предоставляет API для создания фигур SmartArt. Чтобы создать фигуру SmartArt на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. [Добавить фигуру SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSmartArt) путем установки её [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType).
4. Сохраните изменённую презентацию в файл PPTX.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить фигуру SmartArt
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Сохранить презентацию
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Рисунок: Фигура SmartArt добавлена на слайд**|

## **Доступ к фигуре SmartArt на слайде**
В следующем коде будет показано, как получить доступ к фигурам SmartArt, добавленным в слайд презентации. В примере кода мы будем проходить по каждой фигуре внутри слайда и проверять, является ли она фигурой [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Если фигура относится к типу SmartArt, мы приведём её к экземпляру [**SmartArt**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) .
```php
  # Загрузить нужную презентацию
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Обойти каждую фигуру на первом слайде
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Проверить, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести фигуру к типу SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Доступ к фигуре SmartArt с определённым типом макета**
В следующем примере кода показано, как получить доступ к фигуре [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) с определённым LayoutType. Обратите внимание, что изменить LayoutType у SmartArt нельзя, так как он только для чтения и задаётся только при добавлении фигуры [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и загрузите презентацию с фигурой SmartArt.
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдитесь по каждой фигуре внутри первого слайда.
4. Проверьте, относится ли фигура к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), и приведите выбранную фигуру к SmartArt, если это SmartArt.
5. Проверьте фигуру SmartArt с определённым LayoutType и выполните необходимые действия.
```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Обойти каждую фигуру на первом слайде
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Проверить, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести фигуру к типу SmartArtEx
        $smart = $shape;
        # Проверка макета SmartArt
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Изменение стиля фигуры SmartArt**
В этом примере мы научимся изменять быстрый стиль любой фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и загрузите презентацию с фигурой SmartArt.
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдитесь по каждой фигуре внутри первого слайда.
4. Проверьте, относится ли фигура к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), и приведите выбранную фигуру к SmartArt, если это SmartArt.
5. Найдите фигуру SmartArt с определённым Style.
6. Установите новый Style для фигуры SmartArt.
7. Сохраните презентацию.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Обойти каждую фигуру в первом слайде
    foreach($slide->getShapes() as $shape) {
      # Проверить, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести фигуру к типу SmartArtEx
        $smart = $shape;
        # Проверка стиля SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Изменение стиля SmartArt
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Сохранить презентацию
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Рисунок: Фигура SmartArt со изменённым стилем**|

## **Изменение цветового стиля фигуры SmartArt**
В этом примере мы научимся изменять цветовой стиль любой фигуры SmartArt. В следующем примере кода будет показано, как получить доступ к фигуре SmartArt с определённым цветовым стилем и изменить его.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и загрузите презентацию с фигурой SmartArt.
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдитесь по каждой фигуре внутри первого слайда.
4. Проверьте, относится ли фигура к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), и приведите выбранную фигуру к SmartArt, если это SmartArt.
5. Найдите фигуру SmartArt с определённым Color Style.
6. Установите новый Color Style для фигуры SmartArt.
7. Сохраните презентацию.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Обойти каждую фигуру в первом слайде
    foreach($slide->getShapes() as $shape) {
      # Проверить, является ли фигура типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести фигуру к типу SmartArtEx
        $smart = $shape;
        # Проверка типа цвета SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Изменение типа цвета SmartArt
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Сохранить презентацию
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Рисунок: Фигура SmartArt с изменённым цветовым стилем**|

## **Часто задаваемые вопросы**

**Могу ли я анимировать SmartArt как единый объект?**

Да. SmartArt является фигурой, поэтому вы можете применять [стандартные анимации](/slides/ru/php-java/powerpoint-animation/) через API анимаций (вход, выход, акцент, траектории движения), как и для других фигур.

**Как найти определённый SmartArt на слайде, если я не знаю его внутренний ID?**

Задайте и используйте альтернативный текст (AltText) и ищите фигуру по этому значению — это рекомендуемый способ найти нужную фигуру.

**Могу ли я сгруппировать SmartArt с другими фигурами?**

Да. Вы можете сгруппировать SmartArt с другими фигурами (изображениями, таблицами и т.д.), а затем [управлять группой](/slides/ru/php-java/group/).

**Как получить изображение конкретного SmartArt (например, для предварительного просмотра или отчёта)?**

Экспортируйте миниатюру/изображение фигуры; библиотека может [рисовать отдельные фигуры](/slides/ru/php-java/create-shape-thumbnails/) в растровые файлы (PNG/JPG/TIFF).

**Сохранится ли внешний вид SmartArt при конвертации всей презентации в PDF?**

Да. Рендеринговый движок обеспечивает высокую точность при [экспорте в PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/), предлагая различные варианты качества и совместимости.