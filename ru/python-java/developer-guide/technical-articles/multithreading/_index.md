---
title: Многопоточность в Aspose.Slides для Python через Java
linktitle: Многопоточность
type: docs
weight: 310
url: /ru/python-java/multithreading/
keywords:
- многопоточность
- несколько потоков
- параллельная работа
- конвертация слайдов
- слайды в изображения
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Многопоточность Aspose.Slides для Python через Java ускоряет обработку PowerPoint и OpenDocument. Откройте лучшие практики для эффективных рабочих процессов с презентациями."
---
## **Введение**

Хотя параллельная работа с презентациями возможна (за исключением разбора, загрузки и клонирования) и обычно работает хорошо, существует небольшая вероятность получения неверных результатов при использовании библиотеки в нескольких потоках.

Мы настоятельно рекомендуем **не** использовать один экземпляр [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) в многопоточной среде, поскольку это может привести к непредсказуемым ошибкам или сбоям, которые трудно обнаружить.

Загрузка, сохранение и/или клонирование экземпляра [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) в нескольких потоках **не** безопасно. Такие операции **не** поддерживаются. Если необходимо выполнять такие задачи, необходимо параллелить их, используя несколько однопоточных процессов — каждый процесс должен использовать собственный экземпляр презентации.

## **Параллельное преобразование слайдов презентации в изображения**

Предположим, нам нужно одновременно преобразовать все слайды PowerPoint‑презентации в PNG‑изображения. Поскольку использовать один [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) в нескольких потоках небезопасно, мы разбиваем слайды презентации на отдельные презентации и конвертируем слайды в изображения параллельно, используя каждую презентацию в отдельном потоке. Ниже приведён пример кода, показывающий, как это сделать.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # Извлеките слайд в отдельную презентацию.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # Преобразуйте слайд в изображение в отдельной задаче.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # Ожидайте завершения всех задач.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**Нужно ли вызывать настройку лицензии в каждом потоке?**

Нет. Достаточно выполнить её один раз на процесс до запуска потоков. Если [license setup](/slides/ru/python-java/licensing/) может вызываться одновременно (например, при отложенной инициализации), синхронизируйте этот вызов, поскольку метод настройки лицензии сам по себе не является потокобезопасным.

**Могу ли я передавать объекты [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) или [Slide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/) между потоками?**

Передача «живых» объектов презентации между потоками не рекомендуется: используйте независимые экземпляры на каждый поток либо создайте отдельные презентации или контейнеры слайдов для каждого потока заранее. Такой подход соответствует общему совету не делиться одним экземпляром презентации между потоками.

**Безопасно ли параллелить экспорт в различные форматы (PDF, HTML, изображения), при условии, что каждый поток имеет собственный [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) экземпляр?**

Да. При независимых экземплярах и отдельных путях вывода такие задачи обычно корректно параллелятся; избегайте общих объектов презентации и общих потоков ввода‑вывода.

**Что делать с глобальными настройками шрифтов (папки, замены) в многопоточности?**

Инициализируйте все глобальные [font settings](/slides/ru/python-java/powerpoint-fonts/) до запуска потоков и не меняйте их во время параллельной работы. Это устраняет гонки при доступе к общим ресурсам шрифтов.