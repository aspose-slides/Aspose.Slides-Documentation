---
title: Сравнение слайдов презентации в Python
linktitle: Сравнение слайдов
type: docs
weight: 50
url: /ru/python-java/compare-slides/
keywords:
- сравнение слайдов
- сравнение слайдов
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Сравнивайте презентации PowerPoint и OpenDocument программно с помощью Aspose.Slides для Python через Java. Быстро определяйте различия между слайдами в коде."
---
## **Обзор**

Aspose.Slides позволяет сравнивать слайды, макетные слайды и шаблонные слайды, используя метод [equals](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#equals), предоставляемый классом [BaseSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/). Этот метод возвращает `True`, когда сравниваемые слайды идентичны по своей структуре и статическому содержимому.

## **Сравнение двух слайдов**

Метод [equals](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#equals) в классе [BaseSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/) возвращает `True` для слайдов, макетных слайдов и шаблонных слайдов, которые идентичны по структуре и статическому содержимому.

Два слайда считаются равными, если все их фигуры, стили, текст, анимации и другие настройки совпадают. При сравнении не учитываются уникальные идентификаторы, такие как ID слайда, или динамическое содержимое, например текущая дата в заполнителе даты.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **FAQ**

**Влияет ли то, что слайд скрыт, на сравнение самих слайдов?**

[Hidden status](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getHidden) является свойством уровня презентации/воспроизведения, а не визуального содержимого. Эквивалентность двух конкретных слайдов определяется их структурой и статическим содержимым; сам факт, что слайд скрыт, не делает слайды различными.

**Учитываются ли гиперссылки и их параметры?**

Да. Ссылки являются частью статического содержимого слайда. Если URL или действие гиперссылки отличаются, это обычно считается различием в статическом содержимом.

**Если диаграмма ссылается на внешний файл Excel, будет ли содержимое этого файла учитываться?**

Нет. Сравнение выполняется на основе самих слайдов. Внешние источники данных, как правило, не читаются во время сравнения; учитывается только то, что присутствует в структуре и статическом состоянии слайда.