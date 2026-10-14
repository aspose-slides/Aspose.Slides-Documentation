---
title: Преобразование слайдов PowerPoint в PNG на Python
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/python-java/convert-powerpoint-to-png/
keywords:
- преобразовать PowerPoint
- преобразовать презентацию
- преобразовать слайд
- преобразовать PPT
- преобразовать PPTX
- PowerPoint в PNG
- презентацию в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- сохранить PPT как PNG
- сохранить PPTX как PNG
- экспортировать PPT в PNG
- экспортировать PPTX в PNG
- Python
- Java
- Aspose.Slides
description: "Преобразуйте слайды PowerPoint в изображения PNG на Python через Java. Экспортируйте презентации PPT, PPTX и ODP с пользовательскими масштабами или точными размерами изображений."
---
## **Обзор**

В этой статье объясняется, как преобразовать слайды презентации в изображения PNG с помощью Aspose.Slides для Python через Java. Вы можете загружать презентации в форматах PPT, PPTX и ODP, рендерить каждый слайд и сохранять его как отдельное изображение PNG.

Ниже приведённые примеры демонстрируют рендеринг с масштабом по умолчанию, увеличение масштаба, указание размеров вывода в пикселях и выбор стиля рендеринга градиентов.

## **Конвертировать PowerPoint в PNG**

Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) и получите доступ к её слайдам через коллекцию [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides). В примере каждый слайд рендерится с помощью [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) без параметров для создания миниатюры. Затем вызывается [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) с [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) для сохранения каждого отрендеренного слайда в формате PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Перегрузка [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) без параметров рендерит с масштабом 0.2. Например, слайд размером 720 × 540 пунктов создаёт миниатюру 144 × 108 пикселей. Чтобы управлять размерами вывода, используйте перегрузки с коэффициентами масштабирования или явно указанный размер изображения, как показано ниже.
{{% /alert %}}

## **Конвертировать PowerPoint в PNG с пользовательскими размерами**

Передайте горизонтальные и вертикальные коэффициенты масштабирования в [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage), чтобы контролировать размеры рендеринга. В этом примере оба коэффициента равны 2, поэтому слайд размером 720 × 540 пунктов создаёт изображение 1440 × 1080 пикселей. Равные коэффициенты сохраняют соотношение сторон слайда. Каждое отрендеренное изображение сохраняется в формате PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Конвертировать PowerPoint в PNG с пользовательским размером**

Чтобы указать размеры вывода в пикселях, передайте размер в [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) вместо коэффициентов масштабирования. В этом примере каждый слайд рендерится с размером 960 × 720 пикселей и сохраняется в формате PNG. Выбирайте размеры, соответствующие соотношению сторон слайда, чтобы избежать растягивания изображения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Выбор стиля рендеринга градиента**

Предположим, что слайд содержит градиентные заливки, но переходы в экспортированном PNG выглядят светлее или иначе, чем в PowerPoint. Вы можете использовать метод [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle), унаследованный от [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/), чтобы выбрать способ рендеринга градиентов.

Скачайте [gradient-styles.pptx](gradient-styles.pptx) и поместите его в рабочий каталог приложения. Первый слайд содержит два линейных градиента: от голубого к оранжевому сверху и от синего к желтому снизу. Каждый градиент имеет две остановки — на 0% и 100%.

В следующем примере эта презентация загружается и первый слайд рендерится в обоих режимах с помощью [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

| Default | PowerPointUI |
| --- | --- |
| ![Градиенты от цианового к оранжевому и от синего к желтому, отрендеренные с Default](gradient-Default.png) | ![Те же градиенты, отрендеренные с PowerPointUI](gradient-PowerPointUI.png) |

В этом примере `Default` создаёт более светлые промежуточные цвета, тогда как `PowerPointUI` создаёт более тёмные промежуточные цвета. Разница зависит от цветов и остановок в градиенте.

Выбирайте `Default`, если стандартный вывод Aspose.Slides вас устраивает. Попробуйте `PowerPointUI`, если вашей целью является точное соответствие внешнему виду в PowerPoint. Сравните оба результата с желаемым результатом; ни один из режимов не является универсально лучшим.

## **FAQ**

**Как я могу экспортировать конкретную форму, например диаграмму или изображение, вместо всего слайда?**

Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/python-java/create-shape-thumbnails/), позволяя рендерить фигуру в виде изображения PNG.

**Поддерживается ли параллельное преобразование на сервере?**

Да. Используйте отдельный экземпляр презентации для каждого потока или процесса; [не делить один экземпляр между потоками](/slides/ru/python-java/multithreading/).

**Каковы ограничения оценки при экспорте в PNG?**

Режим оценки добавляет водяной знак к выходным изображениям и применяет [другие ограничения](/slides/ru/python-java/licensing/), пока лицензия не будет применена.