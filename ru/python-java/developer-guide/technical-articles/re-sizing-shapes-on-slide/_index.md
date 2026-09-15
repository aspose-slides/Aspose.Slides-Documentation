---
title: Изменение размера фигур на слайдах презентаций в Python через Java
type: docs
weight: 110
url: /ru/python-java/re-sizing-shapes-on-slide/
keywords:
- изменение размера фигуры
- изменить размер фигуры
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Легко изменяйте размер фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Python через Java — автоматизируйте настройку макета слайдов и повышайте продуктивность."
---
## **Обзор**

Один из самых часто задаваемых вопросов клиентами Aspose.Slides for Python via Java — как изменить размер фигур так, чтобы при изменении размера слайда данные не обрезались. Эта короткая техническая статья показывает, как это сделать.

## **Изменение размера фигур**

Чтобы фигуры не смещались при изменении размера слайда, обновите позицию и размеры каждой фигуры, чтобы они соответствовали новому макету слайда.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# Загрузить файл презентации.
presentation = Presentation("sample.ppt")
try:
    # Получить исходный размер слайда.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Изменить размер слайда без масштабирования существующих фигур.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # Получить новый размер слайда.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Изменить размер и положение фигур на каждом слайде.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # Масштабировать размер фигуры.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Масштабировать положение фигуры.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Примечание" %}} 

Таблицам не требуется особая обработка: задание ширины и высоты таблицы масштабирует её столбцы и строки пропорционально, поэтому повторное масштабирование высоты строк и ширины столбцов применит коэффициент дважды.

{{% /alert %}} 

Приведённый выше код изменяет только фигуры на слайдах. Мастер‑слайды и слайды‑макеты имеют свои собственные фигуры, поэтому масштабируйте их также, если вы хотите, чтобы вся презентация соответствовала новому размеру слайда:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # Получить исходный размер слайда.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Изменить размер слайда без масштабирования существующих фигур.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # Получить новый размер слайда.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # Масштабировать размер фигуры.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Масштабировать положение фигуры.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # Масштабировать размер фигуры.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # Масштабировать положение фигуры.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # Масштабировать размер фигуры.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Масштабировать положение фигуры.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Вопросы и ответы**

**Почему фигуры искажаются или обрезаются после изменения размера слайда?**

При изменении размера слайда фигуры сохраняют своё исходное положение и размер, если масштаб явно не меняется. Это может привести к обрезке содержимого или смещению фигур.

**Работает ли предоставленный код для всех типов фигур?**

Да. Установка высоты и ширины работает одинаково для текстовых полей, изображений, диаграмм и таблиц.

**Как изменить размер таблиц при изменении размера слайда?**

Масштабируйте саму фигуру таблицы, как любую другую фигуру. Её строки и столбцы масштабируются пропорционально, поэтому не масштабируйте их повторно после этого.

**Будет ли это работать для мастер‑слайдов и слайдов‑макетов?**

Да, но также следует пройтись по [Presentation.getMasters](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getMasters) и [Presentation.getLayoutSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getLayoutSlides) и применить ту же логику масштабирования к их фигурам, чтобы обеспечить согласованность во всей презентации.

**Можно ли изменить ориентацию слайда (портрет/ландшафт) вместе с изменением размера?**

Да. Можно использовать [SlideSize.setOrientation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidesize/#setOrientation) для изменения ориентации. Убедитесь, что логика масштабирования настроена соответствующим образом, чтобы сохранить макет.

**Есть ли ограничение на размер слайда, который можно установить?**

Aspose.Slides поддерживает пользовательские размеры, но очень большие размеры могут влиять на производительность или совместимость с некоторыми версиями PowerPoint.

**Как предотвратить искажение фигур с фиксированным соотношением сторон?**

Перед масштабированием можно проверить метод [getAspectRatioLocked](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) у блокировки фигуры. Если соотношение заблокировано, регулируйте ширину или высоту пропорционально, а не масштабируйте их по отдельности.