---
title: Управление Заполнителем
type: docs
weight: 10
url: /php-java/manage-placeholder/
description: Измените текст в заполнителе в слайдах PowerPoint, используя PHP. Установите текст подсказки в заполнителе в слайдах PowerPoint, используя PHP.
---

## **Изменение текста в заполнителе**
С помощью [Aspose.Slides для PHP через Java](/slides/php-java/) вы можете находить и изменять заполнители на слайдах в презентациях. Aspose.Slides позволяет вносить изменения в текст в заполнителе.

**Предварительные требования**: Вам нужна презентация, содержащая заполнители. Вы можете создать такую презентацию в стандартном приложении Microsoft PowerPoint.

Вот как использовать Aspose.Slides для замены текста в заполнителе этой презентации:

1. Создайте экземпляр класса [`Presentation`](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и передайте презентацию в качестве аргумента.
2. Получите ссылку на слайд по его индексу.
3. Переберите фигуры, чтобы найти заполнитель.
4. Приведите форму заполнителя к типу [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) и измените текст, используя [`TextFrame`](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame), связанный с [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
5. Сохраните измененную презентацию.

Этот код PHP показывает, как изменить текст в заполнителе:

```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation("ЗаменаТекста.pptx");
  try {
    # Получает доступ к первому слайду
    $sld = $pres->getSlides()->get_Item(0);
    # Перебирает фигуры, чтобы найти заполнитель
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Изменяет текст в каждом заполнителе
        $shp->getTextFrame()->setText("Это Заполнитель");
      }
    }
    # Сохраняет презентацию на диск
    $pres->save("output_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка текста подсказки в заполнителе**
Стандартные и предварительно созданные макеты содержат подсказки заполнителей, такие как ***Нажмите, чтобы добавить заголовок*** или ***Нажмите, чтобы добавить подзаголовок***. Используя Aspose.Slides, вы можете вставить свои предпочтительные подсказки в макеты заполнителей.

Этот код PHP показывает, как установить подсказку в заполнителе:

```php
  $pres = new Presentation("Презентация.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Перебирает слайд
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint отображает "Нажмите, чтобы добавить заголовок"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Добавить заголовок";
        } else // Добавляет подзаголовок
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Добавить подзаголовок";
        }
        $shape->getTextFrame()->setText($text);
        echo("Заполнитель с текстом: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка прозрачности изображения заполнителя**

Aspose.Slides позволяет установить прозрачность фоновое изображения в текстовом заполнителе. Изменяя прозрачность изображения в такой рамке, вы можете сделать текст или изображение более заметными (в зависимости от цветов текста и изображения).

Этот код PHP показывает, как установить прозрачность для фона изображения (внутри фигуры):

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Текущая значение прозрачности: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);

```