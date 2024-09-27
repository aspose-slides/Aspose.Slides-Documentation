---
title: Сравнить слайды
type: docs
weight: 50
url: /ru/androidjava/compare-slides/
---

## **Сравнить два слайда**
Метод Equals был добавлен в интерфейс [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) и класс [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BaseSlide). Он возвращает true для слайдов/макетов и слайдов/мастер-слайдов, которые идентичны по своей структуре и статическому содержимому.

Два слайда равны, если все фигуры, стили, тексты, анимация и другие настройки, и т.д. равны. Сравнение не учитывает значения уникальных идентификаторов, например, SlideId, и динамическое содержимое, например, текущее значение даты в заполнителе даты.

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
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d равен SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```