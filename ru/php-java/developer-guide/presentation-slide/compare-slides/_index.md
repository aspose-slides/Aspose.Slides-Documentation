---
title: Сравнить Слайды
type: docs
weight: 50
url: /php-java/compare-slides/
---

## **Сравнить Два Слайда**
Метод Equals был добавлен в интерфейс [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) и класс [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide). Он возвращает true для слайдов/макетов и слайдов/мастер-слайдов, которые идентичны по своей структуре и статическому содержимому.

Два слайда равны, если все формы, стили, тексты, анимация и другие настройки и т. д. равны. Сравнение не учитывает значения уникальных идентификаторов, например, SlideId, и динамическое содержимое, например, текущее значение даты в Заполнителе Даты.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("MasterSlide#%d из SomePresentation1 равен MasterSlide#%d из SomePresentation2", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```