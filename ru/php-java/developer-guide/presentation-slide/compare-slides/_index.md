---
title: Сравнение слайдов презентации в PHP
linktitle: Сравнение слайдов
type: docs
weight: 50
url: /ru/php-java/compare-slides/
keywords:
- сравнение слайдов
- сравнение слайдов
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Программно сравнивайте презентации PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java. Быстро выявляйте различия слайдов в коде."
---

## **Сравнение двух слайдов**
Метод Equals был добавлен в класс [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide). Он возвращает true для слайдов/макетов и слайдов-мастеров, которые идентичны по своей структуре и статическому содержимому.  

Два слайда считаются равными, если все фигуры, стили, тексты, анимация и другие настройки и т.д. одинаковы. При сравнении не учитываются уникальные идентификаторы, например SlideId, а также динамическое содержимое, например текущее значение даты в заполнителе даты.
```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
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


## **FAQ**

**Влияет ли то, что слайд скрыт, на сравнение самих слайдов?**

[Состояние скрытия](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) – это свойство уровня презентации/воспроизведения, а не визуального содержимого. Равенство двух конкретных слайдов определяется их структурой и статическим содержимым; сам факт того, что слайд скрыт, не делает слайды разными.

**Учитываются ли гиперссылки и их параметры?**

Да. Ссылки являются частью статического содержимого слайда. Если URL или действие гиперссылки отличаются, это обычно считается разницей в статическом содержимом.

**Если диаграмма ссылается на внешний файл Excel, будет ли содержимое этого файла учитываться?**

Нет. Сравнение производится на основе самих слайдов. Внешние источники данных обычно не читаются во время сравнения; учитывается только то, что присутствует в структуре и статическом состоянии слайда.