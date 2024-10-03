---
title: Сравнить слайды
type: docs
weight: 50
url: /ru/java/compare-slides/
---

## **Сравнить два слайда**
Метод Equals был добавлен к интерфейсу [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) и классу [BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/BaseSlide). Он возвращает true для слайдов/макетов и слайдов/мастер-слайдов, которые идентичны по своей структуре и статическому содержимому.

Два слайда равны, если все формы, стили, тексты, анимация и другие параметры и т. д. равны. Сравнение не учитывает значения уникальных идентификаторов, таких как SlideId, и динамическое содержимое, например, значение текущей даты в заполнитель даты.

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("Мастер-слайд SomePresentation1 # %d равен Мастер-слайду SomePresentation2 # %d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```