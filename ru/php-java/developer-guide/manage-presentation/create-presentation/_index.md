---
title: Создание презентации PowerPoint с использованием PHP
linktitle: Создать презентацию
type: docs
weight: 10
url: /php-java/create-presentation/
keywords: создать ppt java, создать ppt презентацию, создать pptx java
description: Узнайте, как создавать презентации PowerPoint, например PPT, PPTX с использованием PHP с нуля.
---

## **Создание презентации PowerPoint**
Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте автопараметр типа линия с помощью метода addAutoShape, предоставленного объектом Shapes.
1. Запишите измененную презентацию в виде файла PPTX.

В приведенном ниже примере мы добавили линию на первый слайд презентации.

```php
  # Создайте объект Presentation, представляющий файл презентации
  $pres = new Presentation();
  try {
    # Получите первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавьте автопараметр типа линия
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```