---
title: Изменение размеров фигур на слайдах презентации в Python
type: docs
weight: 130
url: /ru/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/изменение-размера-фигур-на-слайде/
  - /ru/python-net/re-sizing-shapes-on-slide/
keywords:
  - изменить размер фигуры
  - изменить размер формы
  - PowerPoint
  - OpenDocument
  - презентация
  - Python
  - Aspose.Slides
description: "Легко изменяйте размер фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET — автоматизируйте корректировку макета слайдов и повышайте продуктивность."
---
## **Обзор**

Когда вы меняете размер слайда презентации, вам также может потребоваться изменить размер и переместить её фигуры, чтобы они соответствовали новым габаритам. Эта статья показывает, как вручную масштабировать фигуры и как работать с таблицами на слайдах, мастер‑слайдах и макетах.

## **Изменение размеров фигур**

Чтобы сохранить относительное положение и размер каждой фигуры, умножьте её горизонтальные координаты и ширину на отношение новой ширины слайда к исходной ширине. Примените соответствующее отношение высоты к её вертикальным координатам и высоте.

Первый пример загружает презентацию, слайды которой не содержат таблиц, изменяет размер слайда на A4 и сохраняет результат. Он использует [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) с [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) — так что последующий цикл управляет масштабированием. Коэффициенты безразмерные; позиции и размеры фигур измеряются в пунктах. Разные коэффициенты ширины и высоты могут исказить фигуры, а изменение размеров фигуры не масштабирует размер её шрифта.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Вычислить независимые горизонтальные и вертикальные коэффициенты масштабирования.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Таблицы требуют отдельной обработки: масштабировать их ширины столбцов и высоты строк вместо назначения общей ширины и высоты таблицы. Высота строк может оставаться большей, чем запрошено, если содержимое ячейки требует больше места.
{{% /alert %}}

Во втором примере поддерживаются таблицы, и он обрабатывает фигуры на мастер‑слайдах и макетах, а также отдельные слайды, перед сохранением изменённой презентации. Его вспомогательная функция обрабатывает каждую [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) путем масштабирования [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) и [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/). Затем она масштабирует позицию таблицы без отдельного масштабирования её общих размеров.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # Размеры таблицы контролируются ширинами столбцов и высотой строк.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # Вычислить независимые горизонтальные и вертикальные коэффициенты масштабирования.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Изменить размер фигур, определённых на мастерах и макетах, а также на отдельных слайдах.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Часто задаваемые вопросы**

**Почему фигуры искажаются или обрезаются после изменения размера слайда?**

Если вы меняете размер слайда без масштабирования фигур, они сохраняют свои исходные позиции и размеры и могут выходить за пределы слайда. Масштабирование ширины и высоты разными коэффициентами также может исказить фигуры.

**Работает ли предоставленный код для всех типов фигур?**

Первый пример изменяет границы фигур напрямую и предназначен для слайдов без таблиц. Во втором примере таблицы обрабатываются отдельно. Проверьте получившийся макет, особенно текст и таблицы, поскольку эти примеры не масштабируют размеры шрифтов, а содержимое таблиц может ограничивать высоту строк.

**Как изменить размер таблиц при изменении размера слайда?**

Масштабируйте ширины столбцов по коэффициенту ширины и минимальные высоты строк по коэффициенту высоты, затем масштабируйте позицию таблицы, как показано во втором примере.

**Будет ли такое изменение размера работать для мастер‑слайдов и макетных слайдов?**

Да. Во втором примере происходит перебор [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) и [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) каждого мастера, и к их фигурам применяется та же логика изменения размера.

**Могу ли я изменить ориентацию слайда (портрет/ландшафт) вместе с изменением размера?**

Да. Установите [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) после изменения размера слайда и до чтения целевых размеров, чтобы коэффициенты масштабирования учитывали окончательную ориентацию.

**Есть ли ограничение на размер слайда, который я могу установить?**

Вы можете задать пользовательские размеры слайда с помощью [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/). Поддерживаемые размеры также зависят от формата презентации и приложения, используемого для открытия файла.

**Как избежать искажения фигур с фиксированным соотношением сторон?**

Используйте одинаковый коэффициент масштабирования для ширины и высоты. Чтобы разместить исходный макет внутри новых габаритов слайда, используйте меньший из коэффициентов ширины и высоты для обеих размеров и позиций. Это сохраняет пропорции, но может оставить свободное пространство вдоль одной из сторон.