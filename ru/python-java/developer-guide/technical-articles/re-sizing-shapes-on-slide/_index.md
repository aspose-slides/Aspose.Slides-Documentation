---
title: Изменение размеров фигур на слайдах презентации в Python через Java
type: docs
weight: 110
url: /ru/python-java/resizing-shapes-on-slide/
aliases:
  - /ru/python-java/re-sizing-shapes-on-slide/
  /python-java/re-sizing-shapes-on-slide/
keywords:
- изменить размер фигуры
- изменить размер фигуры
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Легко изменяйте размеры фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Python через Java — автоматизируйте корректировку макета слайдов и повышайте производительность."
---
## **Обзор**

Когда вы меняете размер слайда презентации, вам также может потребоваться изменить размер и позицию фигур, чтобы они соответствовали новым габаритам. Эта статья показывает, как масштабировать фигуры вручную и как обрабатывать таблицы на слайдах, мастерах и макетах.

## **Изменение размера фигур**

Чтобы сохранить относительное положение и размер каждой фигуры, умножьте её горизонтальные координаты и ширину на коэффициент отношения новой ширины слайда к исходной ширине. Примените соответствующий коэффициент высоты к её вертикальным координатам и высоте.

В первом примере загружается презентация, в которой слайды не содержат таблиц, меняется размер слайда на A4 и сохраняется результат. Используется [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) с [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale), чтобы последующий цикл контролировал масштабирование. Коэффициенты безразмерные; позиции фигур и их размеры измеряются в пунктах. Разные коэффициенты ширины и высоты могут искажать фигуры, а изменение размеров фигуры не масштабирует размеры шрифтов.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Вычислить независимые горизонтальные и вертикальные коэффициенты масштабирования.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Таблицы требуют отдельной обработки: масштабируйте их ширины столбцов и высоты строк вместо назначения общей ширины и высоты таблицы. Высота строк может оставаться больше запрошенного, если содержимое ячейки требует большего пространства.
{{% /alert %}}

Во втором примере поддерживаются таблицы и обрабатываются фигуры на мастерах и макетах, а также отдельные слайды перед сохранением изменённой презентации. Его вспомогательный метод обрабатывает каждую [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) путем масштабирования ширины столбцов с помощью [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) и минимальной высоты строк с помощью [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). Затем он масштабирует позицию таблицы без отдельного масштабирования её общих размеров.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # Размеры таблицы управляются ширинами столбцов и высотами строк.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # Вычислить независимые горизонтальные и вертикальные коэффициенты масштабирования.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # Изменить размер фигур, определённых на мастерах и макетах, а также на отдельных слайдах.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Почему фигуры выглядят искажёнными или обрезанными после изменения размера слайда?**

Если изменить размер слайда без масштабирования фигур, они сохраняют свои исходные позиции и размеры и могут выходить за пределы слайда. Масштабирование ширины и высоты разными коэффициентами также может искажать фигуры.

**Работает ли предоставленный код для всех типов фигур?**

Первый пример изменяет границы фигур напрямую и предназначен для слайдов без таблиц. Второй пример обрабатывает таблицы отдельно. Проверьте получившийся макет, особенно текст и таблицы, поскольку эти примеры не масштабируют размеры шрифтов, а содержимое таблиц может ограничивать высоту строк.

**Как изменять размер таблиц при изменении размера слайда?**

Масштабируйте ширины столбцов по коэффициенту ширины и минимальные высоты строк по коэффициенту высоты, затем масштабируйте позицию таблицы, как показано во втором примере.

**Будет ли это масштабирование работать для мастер‑слайдов и макетных слайдов?**

Да. Во втором примере происходит итерация через [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) и каждый [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) мастера, применяя ту же логику изменения размера к их фигурам.

**Можно ли изменить ориентацию слайда (портрет/ландшафт) вместе с изменением размера?**

Да. Вызовите [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) после изменения размера слайда и перед чтением целевых размеров, чтобы коэффициенты масштабирования учитывали окончательную ориентацию.

**Есть ли ограничение на размер слайда, который я могу установить?**

Вы можете указать пользовательские размеры слайда с помощью [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). Поддерживаемые размеры также зависят от формата презентации и приложения, используемого для её открытия.

**Как предотвратить искажение фигур с фиксированным соотношением сторон?**

Используйте одинаковый коэффициент масштабирования для ширины и высоты. Чтобы разместить оригинальный макет в новых габаритах слайда, используйте меньший из коэффициентов ширины и высоты для обеих размеров и позиций. Это сохраняет пропорции, но может оставить неиспользуемое пространство вдоль одной из сторон.