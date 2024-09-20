---
title: Сравнить слайды
type: docs
weight: 50
url: /python-net/compare-slides/
keywords: "Сравнить слайды PowerPoint, Сравнить два слайда, Презентация, Python, Aspose.Slides"
description: "Сравнить слайды презентации PowerPoint на Python"
---

## **Сравнить два слайда**
Метод Equals был добавлен в интерфейс [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) и класс [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/). Он возвращает true для слайдов/шаблонов и слайдов/мастер-слайдов, которые идентичны по своей структуре и статическому содержимому.

Два слайда равны, если все формы, стили, тексты, анимация и другие настройки и т.д. Сравнение не учитывает значения уникальных идентификаторов, например, SlideId и динамическое содержимое, например, текущее значение даты в поле даты.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i] == p2.masters[j]:
                    print("Мастер-слайд Презентации1#{0} равен Мастер-слайду Презентации2#{1}".format(i,j))
```