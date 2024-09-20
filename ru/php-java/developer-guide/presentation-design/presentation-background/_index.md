---
title: Фон Презентации
type: docs
weight: 20
url: /php-java/presentation-background/
keywords: "фон PowerPoint, установить фон"
description: "Установить фон в презентации PowerPoint"
---

Сплошные цвета, градиентные цвета и изображения часто используются как фон для слайдов. Вы можете установить фон как для **обычного слайда** (один слайд), так и для **мастер-слайда** (несколько слайдов сразу).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Установить сплошной цвет в качестве фона для обычного слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для конкретного слайда в презентации (даже если эта презентация содержит мастер-слайд). Изменение фона затрагивает только выбранный слайд.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) для слайда в `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) для фона слайда в `Solid`.
4. Используйте свойство [SolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor--) класса [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/), чтобы указать сплошной цвет для фона.
5. Сохраните измененную презентацию.

Этот код на PHP показывает, как установить сплошной цвет (синий) в качестве фона для обычного слайда:

```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation("MasterBG.pptx");
  try {
    # Устанавливает цвет фона для первого ISlide в синий
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Записывает презентацию на диск
    $pres->save("ContentBG.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установить сплошной цвет в качестве фона для мастер-слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для мастер-слайда в презентации. Мастер-слайд действует как шаблон, который содержит и контролирует параметры форматирования для всех слайдов. Поэтому, когда вы выбираете сплошной цвет в качестве фона для мастер-слайда, этот новый фон будет использоваться для всех слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) для мастер-слайда (`Masters`) в `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) для фона мастер-слайда в `Solid`.
4. Используйте свойство [SolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor--) класса [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/), чтобы указать сплошной цвет для фона.
5. Сохраните измененную презентацию.

Этот код на PHP показывает, как установить сплошной цвет (лесной зеленый) в качестве фона для мастер-слайда в презентации:

```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Устанавливает цвет фона для мастер ISlide в лесной зеленый
    $pres->getMasters()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Записывает презентацию на диск
    $pres->save("MasterBG.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установить градиентный цвет в качестве фона для слайда**

Градиент — это графический эффект, основанный на постепенном изменении цвета. Градиентные цвета, используемые в качестве фонов для слайдов, делают презентации более художественными и профессиональными. Aspose.Slides позволяет установить градиентный цвет в качестве фона для слайдов в презентациях.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) для слайда в `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) для фона мастер-слайда в `Gradient`.
4. Используйте свойство [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat--) класса [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/), чтобы указать ваши предпочтительные параметры градиента.
5. Сохраните измененную презентацию.

Этот код на PHP показывает, как установить градиентный цвет в качестве фона для слайда:

```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation("MasterBG.pptx");
  try {
    # Применяет градиентный эффект к фону
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip->FlipBoth);
    # Записывает презентацию на диск
    $pres->save("ContentBG_Grad.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установить изображение в качестве фона для слайда**

Помимо сплошных и градиентных цветов, Aspose.Slides также позволяет устанавливать изображения в качестве фонов для слайдов в презентациях.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) для слайда в `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) для фона мастер-слайда в `Picture`.
4. Загрузите изображение, которое вы хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Используйте свойство [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getPictureFillFormat--) класса [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/), чтобы установить изображение в качестве фона.
7. Сохраните измененную презентацию.

Этот код на PHP показывает, как установить изображение в качестве фона для слайда:

```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Устанавливает условия для фона изображения
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Загружает изображение
    $imgx;
    $image = Images->fromFile("Desert.jpg");
    try {
      $imgx = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Добавляет изображение в коллекцию изображений презентации
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($imgx);
    # Записывает презентацию на диск
    $pres->save("ContentBG_Img.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Изменить прозрачность фонового изображения**

Вы можете захотеть отрегулировать прозрачность фонового изображения слайда, чтобы сделать его содержание более заметным. Этот код на PHP показывает, как изменить прозрачность фонового изображения слайда:

```php
  $transparencyValue = 30;// например

  # Получает коллекцию операций преобразования изображения
  $imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  # Находит эффект прозрачности с фиксированным процентом.
  $transparencyOperation = null;
  foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $transparencyOperation = $operation;
      break;
    }
  }
  # Устанавливает новое значение прозрачности.
  if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
  } else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
  }
```

## **Получить значение фона слайда**

Aspose.Slides предоставляет интерфейс [IBackgroundEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/), который позволяет получить эффективные значения фонов слайдов. Этот интерфейс содержит информацию о эффективном [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/#getFillFormat--) и эффективном [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Используя свойство [Background](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getBackground--) класса [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/), вы можете получить эффективное значение для фона слайда.

Этот код на PHP показывает, как получить эффективное значение фона для слайда:

```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation("SamplePresentation.pptx");
  try {
    $effBackground = $pres->getSlides()->get_Item(0)->getBackground()->getEffective();
    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid) {
      echo("Цвет заливки: " . $effBackground->getFillFormat()->getSolidFillColor());
    } else {
      echo("Тип заливки: " . $effBackground->getFillFormat()->getFillType());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```