---
title: Преобразование слайдов PowerPoint в PNG на Python
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/python-net/convert-powerpoint-to-png/
keywords:
  - преобразовать PowerPoint в PNG
  - преобразовать презентацию в PNG
  - преобразовать слайд в PNG
  - преобразовать PPT в PNG
  - преобразовать PPTX в PNG
  - преобразовать ODP в PNG
  - PowerPoint в PNG
  - презентация в PNG
  - слайд в PNG
  - PPT в PNG
  - PPTX в PNG
  - ODP в PNG
  - Python
  - Aspose.Slides
description: "Быстро преобразуйте презентации PowerPoint и OpenDocument в высококачественные PNG‑изображения с помощью Aspose.Slides для Python через .NET, обеспечивая точные и автоматизированные результаты."
---
## **Обзор**

Эта статья объясняет, как преобразовать слайды презентаций в PNG‑изображения с помощью Aspose.Slides для Python через .NET. Вы можете загружать презентации в форматах, таких как PPT, PPTX и ODP, рендерить каждый слайд и сохранять его как отдельное PNG‑изображение.

Приведённые ниже примеры демонстрируют рендеринг с масштабом по умолчанию, увеличение масштаба, указание размеров вывода в пикселях и выбор стиля рендеринга градиента.

## **Преобразование PowerPoint в PNG**

Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и получите доступ к её слайдам через коллекцию [слайды](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/). В примере каждый слайд рендерится с помощью [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) без параметров для создания миниатюры. Затем вызывается [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) с параметром [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) для сохранения каждого отрисованного слайда в формате PNG.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
Перегрузка [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) без параметров рендерит с масштабом 0.2. Например, слайд размером 720 × 540 пунктов создаёт миниатюру 144 × 108 пикселей. Чтобы управлять размерами вывода, используйте перегрузки с коэффициентами масштабирования или явно указанным размером изображения, как показано ниже.
{{% /alert %}}

## **Преобразование PowerPoint в PNG с пользовательскими размерами**

Передайте горизонтальные и вертикальные коэффициенты масштабирования в [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/), чтобы контролировать размеры рендеринга. В этом примере оба коэффициента равны 2, поэтому слайд размером 720 × 540 пунктов будет иметь изображение 1440 × 1080 пикселей. Равные коэффициенты сохраняют соотношение сторон слайда. Каждый файл сохраняется в формате PNG с помощью [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/).

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Преобразование PowerPoint в PNG с пользовательским размером**

Чтобы задать размеры вывода в пикселях, передайте в [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) размер вместо коэффициентов масштабирования. В этом примере каждый слайд рендерится размером 960 × 720 пикселей и сохраняется с помощью [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Выбирайте размеры, соответствующие соотношению сторон слайда, чтобы избежать растягивания изображения.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Выбор стиля рендеринга градиента**

Предположим, что слайд содержит градиентные заливки, но переходы в экспортированном PNG выглядят светлее или иначе, чем в PowerPoint. Вы можете использовать свойство [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) класса [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/), чтобы выбрать способ рендеринга градиентов.

Скачайте [gradient-styles.pptx](gradient-styles.pptx) и поместите его в рабочий каталог приложения. Его первый слайд содержит два линейных градиента: от цианового к оранжевому вверху и от синего к желтому внизу. Каждый градиент имеет две остановки — на 0 % и 100 %.

Следующий пример загружает эту презентацию и рендерит один и тот же первый слайд в обоих режимах с помощью [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/).

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

Ниже приведённые изображения показывают вывод одного и того же слайда, с обоими градиентами на каждом изображении:

| По умолчанию | PowerPointUI |
| --- | --- |
| ![Градиенты от цианового к оранжевому и от синего к желтому, отрисованные по умолчанию](gradient-Default.png) | ![Те же градиенты, отрисованные с PowerPointUI](gradient-PowerPointUI.png) |

В этом примере `DEFAULT` дает более светлые промежуточные цвета, тогда как `POWER_POINT_UI` — более тёмные промежуточные цвета. Разница зависит от цветов и остановок в градиенте.

Выбирайте `DEFAULT`, когда стандартный вывод Aspose.Slides удовлетворяет вашим требованиям. Попробуйте `POWER_POINT_UI`, если ваш приоритет — соответствие внешнему виду в PowerPoint. Сравните оба результата с ожидаемым; ни один из режимов не является универсально предпочтительным.

## **Вопросы и ответы**

**Как экспортировать конкретную форму, например диаграмму или изображение, вместо всего слайда?**

Aspose.Slides поддерживает [создание миниатюр отдельных фигур](/slides/ru/python-net/create-shape-thumbnails/), позволяя рендерить форму в виде PNG‑изображения.

**Поддерживается ли параллельное преобразование на сервере?**

Да. Используйте отдельный экземпляр презентации для каждого потока или процесса; [не делите один экземпляр между потоками](/slides/ru/python-net/multithreading/).

**Каковы ограничения оценочной версии при экспорте в PNG?**

Режим оценки добавляет водяной знак к выводимым изображениям и применяет [другие ограничения](/slides/ru/python-net/licensing/), пока не будет применена лицензия.