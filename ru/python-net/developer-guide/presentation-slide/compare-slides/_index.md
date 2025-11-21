---
title: Сравнение слайдов презентации в Python
linktitle: Сравнить слайды
type: docs
weight: 50
url: /ru/python-net/compare-slides/
keywords:
- сравнение слайдов
- анализ слайдов
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Сравнивайте презентации PowerPoint и OpenDocument программно с помощью Aspose.Slides для Python через .NET. Быстро определяйте различия между слайдами в коде."
---

## **Сравнение двух слайдов**
Метод Equals был добавлен в интерфейс [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) и класс [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/). Он возвращает true для слайдов/макетов и слайдов‑мастеров, которые идентичны по своей структуре и статическому содержимому.

Два слайда считаются равными, если все формы, стили, тексты, анимация и другие настройки и т.д. Сравнение не учитывает значения уникальных идентификаторов, например SlideId, и динамического содержимого, например текущее значение даты в заполнителе даты.
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i] == p2.masters[j]:
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```


## **FAQ**

**Влияет ли факт скрытия слайда на сравнение самих слайдов?**

[Hidden status](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) — это свойство уровня презентации/воспроизведения, а не визуального содержимого. Равенство двух конкретных слайдов определяется их структурой и статическим содержимым; сам факт скрытия слайда не делает слайды разными.

**Учитываются ли гиперссылки и их параметры?**

Да. Ссылки являются частью статического содержимого слайда. Если URL или действие гиперссылки отличаются, это обычно считается различием в статическом содержимом.

**Если диаграмма ссылается на внешний файл Excel, будет ли содержимое этого файла учитываться?**

Нет. Сравнение выполняется на основе самих слайдов. Внешние источники данных обычно не читаются во время сравнения; учитывается только то, что присутствует в структуре и статическом состоянии слайда.