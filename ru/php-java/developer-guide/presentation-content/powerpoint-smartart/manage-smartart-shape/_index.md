---
title: Управление графикой SmartArt в презентациях с помощью PHP
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

## **Создание SmartArt-формы**
Aspose.Slides for PHP via Java предоставляет API для создания SmartArt‑форм. Чтобы создать SmartArt‑форму на слайде, выполнениейте следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте SmartArt‑форму, вызвав [Add a SmartArt shape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) и задав её [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType).
4. Сохраните изменённую презентацию в файл PPTX.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить Smart Art форму
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
|**Рисунок: SmartArt‑форма, добавленная на слайд**|

## **Доступ к SmartArt‑форме на слайде**
В следующем коде будет получен доступ к SmartArt‑формам, добавленным в слайд презентации. В примере кода мы пройдем по всем формам на слайде и проверим, является ли форма [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Если форма относится к типу SmartArt, мы приведём её к экземпляру [**SmartArt**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).
```php
  # Загрузить нужную презентацию
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Пройти каждую форму внутри первого слайда
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Проверить, является ли форма типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести форму к SmartArtEx
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


## **Доступ к SmartArt‑форме с определённым типом компоновки**
Следующий пример кода поможет получить доступ к форме [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) с определённым LayoutType. Обратите внимание, что изменить LayoutType у SmartArt нельзя — он только для чтения и устанавливается только при добавлении формы [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и загрузите презентацию, содержащую SmartArt‑форму.
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдите по всем формам на первом слайде.
4. Проверьте, относится ли форма к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), и при необходимости выполните приведение выбранной формы к SmartArt.
5. Проверьте SmartArt‑форму с заданным LayoutType и выполните необходимые действия.
```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Пройти каждую форму внутри первого слайда
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Проверить, является ли форма типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести форму к SmartArtEx
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


## **Изменение стиля SmartArt‑формы**
В этом примере мы научимся менять быстрый стиль любой SmartArt‑формы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и загрузите презентацию, содержащую SmartArt‑форму.
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдите по всем формам на первом слайде.
4. Проверьте, относится ли форма к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), и при необходимости выполните приведение выбранной формы к SmartArt.
5. Найдите SmartArt‑форму с определённым стилем.
6. Установите новый стиль для SmartArt‑формы.
7. Сохраните презентацию.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Пройти каждую форму внутри первого слайда
    foreach($slide->getShapes() as $shape) {
      # Проверить, является ли форма типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести форму к SmartArtEx
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
|**Рисунок: SmartArt‑форма с изменённым стилем**|

## **Изменение цветового стиля SmartArt‑формы**
В этом примере мы научимся менять цветовой стиль любой SmartArt‑формы. В следующем примере кода будет получен доступ к SmartArt‑форме с определённым цветовым стилем и он будет изменён.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и загрузите презентацию, содержащую SmartArt‑форму.
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдите по всем формам на первом слайде.
4. Проверьте, относится ли форма к типу [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt), и при необходимости выполните приведение выбранной формы к SmartArt.
5. Найдите SmartArt‑форму с определённым цветовым стилем.
6. Установите новый цветовой стиль для SmartArt‑формы.
7. Сохраните презентацию.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Пройти каждую форму внутри первого слайда
    foreach($slide->getShapes() as $shape) {
      # Проверить, является ли форма типом SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Привести форму к SmartArtEx
        $smart = $shape;
        # Проверка типа цвета SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Изменение типа цвета SmartArt
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
|**Рисунок: SmartArt‑форма с изменённым цветовым стилем**|

## **FAQ**

**Могу ли я анимировать SmartArt как единый объект?**

Да. SmartArt — это форма, поэтому её можно анимировать с помощью [стандартных анимаций](/slides/ru/php-java/powerpoint-animation/) через API анимаций (вход, выход, акцент, траектории движения), так же как и другие формы.

**Как найти конкретный SmartArt на слайде, если я не знаю его внутренний идентификатор?**

Установите и используйте альтернативный текст (AltText) и ищите форму по этому значению — рекомендуется для поиска нужной формы.

**Могу ли я сгруппировать SmartArt с другими формами?**

Да. Вы можете сгруппировать SmartArt с другими формами (изображения, таблицы и т.д.) и затем [манипулировать группой](/slides/ru/php-java/group/).

**Как получить изображение конкретного SmartArt (например, для превью или отчёта)?**

Экспортируйте миниатюру/изображение формы; библиотека может [рендерить отдельные формы](/slides/ru/php-java/create-shape-thumbnails/) в растровые файлы (PNG/JPG/TIFF).

**Будет ли внешний вид SmartArt сохранён при конвертации всей презентации в PDF?**

Да. Движок рендеринга обеспечивает высокую точность при [экспорте в PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/), предоставляя набор опций качества и совместимости.