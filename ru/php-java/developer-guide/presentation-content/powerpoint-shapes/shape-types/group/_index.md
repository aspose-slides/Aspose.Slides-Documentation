---
title: Группа
type: docs
weight: 40
url: /php-java/group/
---

## **Добавить группу фигур**
Aspose.Slides поддерживает работу с группами фигур на слайдах. Эта функция помогает разработчикам создавать более насыщенные презентации. Aspose.Slides для PHP через Java поддерживает добавление или доступ к группам фигур. Можно добавлять фигуры в добавленную группу фигур, чтобы заполнить ее, или получить доступ к любому свойству группы фигур. Чтобы добавить группу фигур на слайд с использованием Aspose.Slides для PHP через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте группу фигур на слайд.
1. Добавьте фигуры в добавленную группу фигур.
1. Сохраните измененную презентацию в файл PPTX.

Пример ниже добавляет группу фигур на слайд.

```php
  # Создание экземпляра класса Presentation
  $pres = new Presentation();
  try {
    # Получение первого слайда
    $sld = $pres->getSlides()->get_Item(0);
    # Доступ к коллекции фигур на слайдах
    $slideShapes = $sld->getShapes();
    # Добавление группы фигур на слайд
    $groupShape = $slideShapes->addGroupShape();
    # Добавление фигур внутри добавленной группы фигур
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Добавление рамки группы фигур
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # Запись файла PPTX на диск
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Получение свойства AltText**
Эта тема показывает простые шаги, включающие примеры кода, для добавления группы фигур и доступа к свойству AltText групп фигур на слайдах. Чтобы получить доступ к AltText группы фигур на слайде с использованием Aspose.Slides для PHP через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), который представляет файл PPTX.
1. Получите ссылку на слайд, используя его индекс.
1. Доступ к коллекции фигур на слайдах.
1. Доступ к группе фигур.
1. Доступ к свойству [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--).

Пример ниже получает альтернативный текст группы фигур.

```php
  # Создание экземпляра класса Presentation, который представляет файл PPTX
  $pres = new Presentation("AltText.pptx");
  try {
    # Получение первого слайда
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Доступ к коллекции фигур на слайдах
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Доступ к группе фигур.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Доступ к свойству AltText
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```