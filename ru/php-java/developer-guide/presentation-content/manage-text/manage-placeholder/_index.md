---
title: Управление заполнителями презентаций в PHP
linktitle: Управление заполнителями
type: docs
weight: 10
url: /ru/php-java/manage-placeholder/
keywords:
- заполнитель
- текстовый заполнитель
- заполнитель изображения
- заполнитель диаграммы
- текст подсказки
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Легко управляйте заполнителями в Aspose.Slides для PHP через Java: заменяйте текст, настраивайте подсказки и задавайте прозрачность изображений в PowerPoint и OpenDocument."
---

## **Изменить текст в заполнителе**
С помощью [Aspose.Slides for PHP via Java](/slides/ru/php-java/), вы можете находить и изменять заполнители на слайдах презентаций. Aspose.Slides позволяет вносить изменения в текст заполнителя.

**Требование**: Вам нужна презентация, содержащая заполнитель. Вы можете создать такую презентацию в стандартном приложении Microsoft PowerPoint.

Вот как использовать Aspose.Slides для замены текста в заполнителе в этой презентации:

1. Создайте экземпляр класса [`Presentation`](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и передайте презентацию в качестве аргумента.
2. Получите ссылку на слайд через его индекс.
3. Пройдитесь по коллекции фигур, чтобы найти заполнитель.
4. Приведите форму заполнителя к типу [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) и измените текст, используя [`TextFrame`](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame), связанный с [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
5. Сохраните изменённую презентацию.

Этот PHP‑код показывает, как изменить текст в заполнителе:
```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Перебирает фигуры, чтобы найти заполнитель
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Изменяет текст в каждом заполнителе
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # Сохраняет презентацию на диск
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установить подсказочный текст в заполнителе**
Стандартные и встроенные макеты содержат подсказки-заполнители, такие как ***Нажмите, чтобы добавить заголовок*** или ***Нажмите, чтобы добавить подзаголовок***. С помощью Aspose.Slides вы можете вставлять свои собственные подсказочные тексты в макеты заполнителей.

Этот PHP‑код показывает, как установить подсказочный текст в заполнителе:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Перебирает слайд
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint отображает "Нажмите, чтобы добавить заголовок"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // Добавляет подзаголовок
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установить прозрачность изображения в заполнителе**
Aspose.Slides позволяет установить прозрачность фонового изображения в текстовом заполнителе. Регулируя прозрачность картинки в таком кадре, вы можете выделить текст или изображение (в зависимости от цветов текста и картинки).

Этот PHP‑код показывает, как установить прозрачность фоновой картинки (внутри формы):
```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Что такое базовый заполнитель и чем он отличается от локальной фигуры на слайде?**

Базовый заполнитель — это исходная форма в макете или шаблоне, от которой наследуется форма слайда — тип, позиция и часть форматирования берутся от него. Локальная форма независима; если базового заполнителя нет, наследование не применяется.

**Как обновить все заголовки или подписи во всей презентации без обхода каждого слайда?**

Отредактируйте соответствующий заполнитель в макете или шаблоне. Слайды, основанные на этих макетах/шаблоне, автоматически унаследуют изменения.

**Как управлять стандартными заполнителями заголовка/подвала — датой и временем, номером слайда и текстом подвала?**

Используйте менеджеры HeaderFooter в соответствующей области (обычные слайды, макеты, шаблон, заметки/раздаточные материалы), чтобы включать или отключать эти заполнители и задавать их содержание.