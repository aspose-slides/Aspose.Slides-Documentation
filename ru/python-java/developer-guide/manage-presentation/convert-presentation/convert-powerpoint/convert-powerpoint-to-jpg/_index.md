---
title: Конвертировать PPT и PPTX в JPG на Python
linktitle: PowerPoint в JPG
type: docs
weight: 60
url: /ru/python-java/convert-powerpoint-to-jpg/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- PowerPoint в JPG
- PPT в JPG
- PPTX в JPG
- сохранить слайд как JPG
- экспортировать PPT в JPG
- экспортировать PPTX в JPG
- Python
- Java
- Aspose.Slides
description: "Конвертировать слайды PowerPoint (PPT, PPTX) в изображения JPG на Python через Java. Установить пользовательские размеры изображения и отрисовать заметки и комментарии с помощью Aspose.Slides."
---
## **Введение**

Aspose.Slides for Python via Java позволяет конвертировать презентации PowerPoint и OpenDocument (PPT, PPTX и ODP) в изображения JPEG. Вы можете экспортировать каждый слайд или выбранный слайд, чтобы создавать миниатюры, создавать просмотрщик презентаций или встраивать предварительные просмотры слайдов в веб‑сайт или приложение.

## **Конвертировать PowerPoint PPT/PPTX в JPG**

1. Загрузите презентацию с помощью [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите слайды, используя [getSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSlides).
3. Вызовите [Slide.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage) с горизонтальными и вертикальными коэффициентами масштабирования, чтобы отрисовать каждый слайд.
4. Сохраните каждое отрисованное изображение в формате JPEG с помощью [ImageFormat.Jpeg](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imageformat/#Jpeg), затем освободите ресурсы изображения.

{{% alert color="info" title="Note" %}}
Экспорт в JPG создает отдельное изображение для каждого слайда. Сохраните отрисованное изображение, а не сохраняйте презентацию напрямую в формат изображения.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Конвертировать PowerPoint PPT/PPTX в JPG с пользовательскими размерами**

Вычислите горизонтальные и вертикальные коэффициенты масштабирования на основе требуемых размеров в пикселях и исходного размера слайда, затем передайте их в [Slide.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage). В следующем примере цель состоит в получении изображения размером 1200 × 800 пикселей для каждого слайда.

Использование разных коэффициентов масштабирования может растянуть слайд. Чтобы сохранить его пропорции, используйте одинаковый коэффициент масштабирования для обеих осей; тогда полученная ширина и высота будут соответствовать исходным пропорциям слайда.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Отрисовка комментариев при сохранении слайдов как изображений**

Используйте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/) для настройки заметок и комментариев и примените макет через [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions). В этом примере заметки размещаются внизу, обрезая те, которые не помещаются, а комментарии отображаются справа в области шириной 200 пикселей. Каждый отрисованный слайд сохраняется как изображение JPG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**Могу ли я конвертировать несколько слайдов или презентаций в JPG?**

Да. В примерах происходит цикл по всем слайдам и сохраняется один JPG на каждый слайд. Чтобы обработать несколько презентаций, повторите конверсию для каждого входного файла и используйте отдельные папки вывода или уникальные имена файлов, чтобы избежать перезаписи изображений.

**Включены ли в изображения диаграммы, SmartArt, таблицы и фигуры?**

Эти объекты отрисовываются как часть слайда. Обеспечьте наличие шрифтов, используемых в презентации, в среде конвертации, чтобы уменьшить различия, вызванные заменой шрифтов.

**Как можно уменьшить потребление памяти при экспорте больших презентаций?**

Обрабатывайте изображения по одному, освобождая каждое изображение после его сохранения, и избегайте излишне больших размеров вывода. Требования к памяти зависят от содержимого слайда и размера изображения.

## **См. также**

- [Конвертировать PowerPoint в PNG](/slides/ru/python-java/convert-powerpoint-to-png/).
- [Отрисовать слайд как изображение SVG](/slides/ru/python-java/render-a-slide-as-an-svg-image/).