---
title: Групповые формы презентаций в PHP
linktitle: Группа форм
type: docs
weight: 40
url: /ru/php-java/group/
keywords:
- групповая форма
- группа форм
- добавить группу
- альтернативный текст
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как группировать и разгруппировать формы в презентациях PowerPoint с помощью Aspose.Slides for PHP via Java — быстрый пошаговый гид с бесплатным кодом."
---

## **Добавить групповую форму**
Aspose.Slides поддерживает работу с групповыми формами на слайдах. Эта функция помогает разработчикам создавать более богатые презентации. Aspose.Slides for PHP via Java поддерживает добавление или доступ к групповым формам. Можно добавить формы в созданную групповую форму, чтобы заполнить её, или получить доступ к любому свойству групповой формы. Чтобы добавить групповую форму на слайд с использованием Aspose.Slides for PHP via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его Index
1. Добавьте групповую форму на слайд.
1. Добавьте формы в созданную групповую форму.
1. Сохраните изменённую презентацию в файл PPTX.

Пример ниже добавляет групповую форму на слайд.
```php
  # Создать объект класса Presentation
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Получение коллекции фигур слайдов
    $slideShapes = $sld->getShapes();
    # Добавление групповой формы на слайд
    $groupShape = $slideShapes->addGroupShape();
    # Добавление фигур в созданную групповую форму
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Добавление рамки групповой формы
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # Записать файл PPTX на диск
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Доступ к свойству AltText**
В этой статье показаны простые шаги с примерами кода для добавления групповой формы и доступа к свойству AltText групповых форм на слайдах. Чтобы получить доступ к AltText групповой формы на слайде с использованием Aspose.Slides for PHP via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), представляющего файл PPTX.
1. Получите ссылку на слайд, используя его Index.
1. Получите доступ к коллекции форм слайдов.
1. Получите доступ к групповой форме.
1. Получите доступ к свойству [Alternative Text](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getAlternativeText).

Пример ниже получает доступ к альтернативному тексту групповой формы.
```php
  # Создать объект класса Presentation, представляющий файл PPTX
  $pres = new Presentation("AltText.pptx");
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Получение коллекции фигур слайдов
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Получение групповой формы.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Получение свойства AltText.
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


## **FAQ**

**Поддерживается ли вложенное группирование (группа внутри группы)?**

Да. У [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) есть метод [getParentGroup](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getparentgroup/), который непосредственно указывает на поддержку иерархии (группа может быть дочерней по отношению к другой группе).

**Как контролировать порядок наложения группы относительно других объектов на слайде?**

Используйте метод [getZOrderPosition](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) объекта [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), чтобы проверить его позицию в стеке отображения.

**Могу ли я предотвратить перемещение/редактирование/разгруппировку?**

Да. Раздел блокировки группы доступен через [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/getgroupshapelock/), что позволяет ограничить операции над объектом.